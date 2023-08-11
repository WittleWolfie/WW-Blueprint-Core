using BlueprintCoreGen.CodeGen;
using BlueprintCoreGen.CodeGen.Methods;
using BlueprintCoreGen.CodeGen.Overrides.Ignored;
using Kingmaker.AI.Blueprints;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.AreaLogic.Cutscenes;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Armies.TacticalCombat.Blueprints;
using Kingmaker.Armies.TacticalCombat.Brain;
using Kingmaker.Armies.TacticalCombat.Brain.Considerations;
using Kingmaker.BarkBanters;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Blueprints.Quests;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Formations;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.QA.Arbiter;
using Kingmaker.UI;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Customization;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.Visual.CharacterSystem;
using Kingmaker.Visual.Sound;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace BlueprintCoreGen.Analysis
{
  public static class TypeUsageAnalyzer
	{
		// When set to a positive number, limits the number of blueprints processed to allow for quicker iteration.
		private static readonly int DebugLimit = -1;
		// How many blueprints to process before reporting on progress & speed
		private static readonly int ReportThreshold = 10000;

		private static readonly Dictionary<string, Type> TypesById = new();
		private static readonly Dictionary<string, Type> TypesByName = new();
		private static readonly HashSet<string> DuplicateTypeIds = new();

		private static readonly Dictionary<string, Blueprint> BlueprintsByGuid = new();
		private static readonly Dictionary<Type, HashSet<Blueprint>> BlueprintsByType = new();
		private static readonly Dictionary<Type, HashSet<Blueprint>> ExamplesByType = new();

		private static readonly List<SearchFilter> SearchFilters = new()
		{
			new()
			{
				Name = "ReadPreRolledFromSharedValue",
				ElementFilter = typeof(ContextActionDealDamage),
				FieldNameFilter = "ReadPreRolledFromSharedValue",
				StringFieldValue = "True",
			},
			new()
			{
				Name = "IsTargeted",
        BlueprintFilter = typeof(BlueprintActivatableAbility),
				FieldNameFilter = "IsTargeted",
				StringFieldValue = "True",
			}
		};

		public static void Analyze(Type[] gameTypes)
		{
			ProcessGameTypes(gameTypes);

			ProcessDB();

			ProcessUnusedTypes(typeof(GameAction), gameTypes);
			ProcessUnusedTypes(typeof(Condition), gameTypes);
			ProcessUnusedTypes(typeof(BlueprintScriptableObject), gameTypes);
			ProcessUnusedTypes(typeof(BlueprintComponent), gameTypes);

			ProcessExamples(typeof(GameAction));
			ProcessExamples(typeof(Condition));
			ProcessExamples(typeof(BlueprintScriptableObject));
			ProcessExamples(typeof(BlueprintComponent));

			ProcessBlueprintReferences(gameTypes);
		}

		// Generates a Type ID (or name if Type ID is not available) > Type mapping. This is safer since some blueprints
		// refer to old class names, and it is faster than using AccessTools to lookup type by name.
		private static void ProcessGameTypes(Type[] gameTypes)
		{
			foreach (var type in gameTypes)
			{
				// Filter to only types relevant to processing
				if (
					!type.IsAbstract &&
					(type.IsSubclassOf(typeof(GameAction))
					|| type.IsSubclassOf(typeof(Condition))
					|| type.IsSubclassOf(typeof(BlueprintComponent))
					|| type.IsSubclassOf(typeof(SimpleBlueprint))))
				{
					var typeId =
						type.GetCustomAttributes(typeof(TypeIdAttribute), inherit: false).Cast<TypeIdAttribute>().FirstOrDefault();
					if (typeId is not null)
					{
						if (TypesById.ContainsKey(typeId.GuidString))
						{
							// There are some types that have duplicate TypeID. Technically this shouldn't be functional but they
							// seem to occur only for unused types.
							Console.WriteLine(
								$"Found duplicate types for TypeID: {typeId.GuidString} - {type.Name} and {TypesById[typeId.GuidString]}");
							TypesById.Remove(typeId.GuidString);
							DuplicateTypeIds.Add(typeId.GuidString);
						}
						else
						{
							TypesById.Add(typeId.GuidString, type);
						}
					}
					else
					{
						TypesByName.Add(type.Name, type);
					}
				}
			}
		}

		private static void ProcessUnusedTypes(Type baseType, Type[] gameTypes)
		{
			StringBuilder unusedTypes = new();
			gameTypes.Where(t => !t.IsAbstract && t.IsSubclassOf(baseType) && !ExamplesByType.ContainsKey(t))
				.ToList()
				.ForEach(t => unusedTypes.AppendLine($"        typeof({GetTypeName(t)}),"));

			var fileText = new StringBuilder();
			fileText.AppendLine("using System;");
			fileText.AppendLine("using System.Collections.Generic;");
			fileText.AppendLine("");
			fileText.AppendLine(@"namespace BlueprintCoreGen.CodeGen.Overrides.Ignored");
			fileText.AppendLine(@"{");
			fileText.AppendLine($"  // Examples generated by TypeUsageAnalyzer");
			fileText.AppendLine($"  internal static class Ignored{baseType.Name}s");
			fileText.AppendLine(@"  {");
			fileText.AppendLine($"    public static readonly List<Type> Types =");
			fileText.AppendLine($"      new()");
			fileText.AppendLine(@"      {");
			fileText.Append(unusedTypes);
			fileText.AppendLine(@"      };");
			fileText.AppendLine(@"  }");
			fileText.AppendLine(@"}");
			Directory.CreateDirectory(Program.AnalysisDir);
			File.WriteAllText($"{Program.AnalysisDir}/Ignored{baseType.Name}s.cs", fileText.ToString());
		}

		// Handles type name for generics. Note that TypeTool.GetTypeName() doesn't work because it generates a name for a
		// type with defined generic arguments. i.e. TypeTool produces "GenericType<A,B>", this produces "GenericType<,>".
		private static string GetTypeName(Type type)
		{
			var typeName = type.Name;
			if (type.IsGenericType)
			{
				var rawTypeName = type.GetGenericTypeDefinition().Name;
				StringBuilder typeNameBuilder = new(rawTypeName[..rawTypeName.IndexOf('`')]);
				typeNameBuilder.Append('<');
				for (int i = 1; i < type.GenericTypeArguments.Length; i++)
				{
					typeNameBuilder.Append(',');
				}
				typeNameBuilder.Append('>');
				typeName = typeNameBuilder.ToString();
			}

			if (string.IsNullOrEmpty(type.Namespace))
      {
				return typeName;
      }
			return $"{type.Namespace}.{typeName}";
		}

		// Types ignored because they have too many blueprints or referencing by name is not very helpful.
		private static List<Type> SkipBlueprintReferences =
			new()
			{
				typeof(ActiveCommandConsideration),
				typeof(AlignmentConsideration),
				typeof(BlueprintAiAttack),
				typeof(BlueprintAiCastSpell),
				typeof(BlueprintAiFollow),
				typeof(BlueprintAiTouch),
				typeof(BlueprintAiSwitchWeapon),
				typeof(BlueprintAnswer),
				typeof(BlueprintAnswersList),
				typeof(BlueprintArbiterInstruction),
				typeof(BlueprintArea),
				typeof(BlueprintAreaMechanics),
				typeof(BlueprintAreaPart),
				typeof(BlueprintAreaPreset),
				typeof(ArmorTypeConsideration),
				typeof(ArmyHealthConsideration),
				typeof(BlueprintArmyPreset),
				typeof(BlueprintAreaTransition),
				typeof(BlueprintBarkBanter),
				typeof(BlueprintBookPage),
				typeof(BlueprintBrain),
				typeof(BuffsAroundConsideration),
				typeof(BuffConsideration),
				typeof(BuffNotFromCasterConsideration),
				typeof(CanMakeFullAttackConsideration),
				typeof(CanUseSpellCombatConsideration),
				typeof(CasterClassConsideration),
				typeof(BlueprintCheck),
				typeof(CommandCooldownConsideration),
				typeof(ConditionConsideration),
				typeof(BlueprintCrusadeEvent),
				typeof(BlueprintCue),
				typeof(BlueprintCueSequence),
				typeof(Cutscene),
				typeof(BlueprintDialog),
				typeof(DistanceConsideration),
				typeof(DistanceRangeConsideration),
				typeof(BlueprintDungeonLocalizedStrings),
				typeof(BlueprintEtude),
				typeof(BlueprintEtudeConflictingGroup),
				typeof(FactConsideration),
				typeof(FollowersFormation),
				typeof(Gate),
				typeof(BlueprintGlobalMap),
				typeof(BlueprintGlobalMapEdge),
				typeof(BlueprintGlobalMapPoint),
				typeof(BlueprintGlobalMapPointVariation),
				typeof(HasAutoCastConsideraion),
				typeof(HasManualTargetConsideration),
				typeof(HealthConsideration),
				typeof(HitThisRoundConsideration),
				typeof(InRangeConsideration),
				typeof(KingmakerEquipmentEntity),
				typeof(LastTargetConsideration),
				typeof(LifeStateConsideration),
				typeof(LineOfSightConsideration),
				typeof(BlueprintLoot),
				typeof(ManualTargetConsideration),
				typeof(BlueprintMultiEntrance),
				typeof(BlueprintMultiEntranceEntry),
				typeof(NotImpatientConsideration),
				typeof(BlueprintPortrait),
				typeof(BlueprintQuest),
				typeof(BlueprintQuestGroups),
				typeof(BlueprintQuestObjective),
				typeof(RaceGenderDistribution),
				typeof(BlueprintScriptZone),
				typeof(BlueprintSequenceExit),
				typeof(StatConsideration),
				typeof(BlueprintSummonPool),
				typeof(SwarmTargetsConsideration),
				typeof(BlueprintTacticalCombatAiAttack),
				typeof(BlueprintTacticalCombatAiCastSpell),
				typeof(BlueprintTacticalCombatBrain),
				typeof(TacticalCombatCanAttackThisTurnConsideration),
				typeof(BlueprintTacticalCombatObstaclesMap),
				typeof(TacticalCombatTagConsideration),
				typeof(TargetClassConsideration),
				typeof(TargetMainCharacter),
				typeof(ThreatedByConsideration),
				typeof(BlueprintUIInteractionTypeSprites),
				typeof(BlueprintUISound),
				typeof(BlueprintUnlockableFlag),
				typeof(BlueprintUnitAsksList),
				typeof(UnitsAroundConsideration),
				typeof(UnitsThreateningConsideration),
			};
		// Generates constant reference classes for blueprints
		private static void ProcessBlueprintReferences(Type[] gameTypes)
		{
			var bpTypes = gameTypes.Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(BlueprintScriptableObject)));
			foreach (var bpType in bpTypes)
			{
				if (Ignored.ShouldIgnore(bpType)
					|| SkipBlueprintReferences.Contains(bpType)
					|| !BlueprintsByType.ContainsKey(bpType))
				{
					continue;
				}

				var blueprints = BlueprintsByType[bpType].OrderBy(bp => bp.BlueprintName).ToList();
				var typeName = TypeTool.GetName(bpType);
				var className = $"{typeName.Replace("Blueprint", "")}Refs";

				if (blueprints.Count > 10000)
        {
					Console.WriteLine($"Skipping {className}, too many: {blueprints.Count}");
					continue;
        }

				var bpNames = new HashSet<string>();
				var fileText = new StringBuilder();
				fileText.AppendLine("using BlueprintCore.Utils;");
				fileText.AppendLine("using Kingmaker.Blueprints;");
				fileText.AppendLine(TypeTool.GetImport(bpType));
				fileText.AppendLine("using System.Collections.Generic;");
				fileText.AppendLine();
				fileText.AppendLine(@"namespace BlueprintCore.Blueprints.References");
				fileText.AppendLine(@"{");
				fileText.AppendLine($"  /// <summary>");
				fileText.AppendLine($"  /// Constant references to {typeName} blueprints");
				fileText.AppendLine($"  /// </summary>");
				fileText.AppendLine($"  ///");
				fileText.AppendLine($"  /// <remarks>");
				fileText.AppendLine($"  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>");
				fileText.AppendLine($"  /// <p>If you need a different reference type you can cast using <see cref=\"Blueprint{{TRef}}.Cast{{T}}\"/></p>.");
				fileText.AppendLine($"  /// </remarks>");
				fileText.AppendLine($"  public static class {className}");
				fileText.AppendLine(@"  {");
				blueprints.ForEach(
					bp =>
					{
						string sanitizedName;
						if (BlueprintReferenceOverrides.BlueprintNameByGuid.ContainsKey(bp.BlueprintGuid))
						{
							sanitizedName = BlueprintReferenceOverrides.BlueprintNameByGuid[bp.BlueprintGuid];
						}
						else
						{
							sanitizedName = SanitizeBlueprintName(bp.BlueprintName, className, bpNames);
						}
						bpNames.Add(sanitizedName);
						fileText.AppendLine($"    public static readonly Blueprint<BlueprintReference<{typeName}>> {sanitizedName} = \"{bp.BlueprintGuid}\";");
					});
        if (bpNames.Count > 1)
        {
          fileText.AppendLine();
          fileText.AppendLine($"    public static readonly List<Blueprint<BlueprintReference<{typeName}>>> All =");
          fileText.AppendLine($"      new()");
          fileText.AppendLine($"      {{");
          bpNames.ToList().ForEach(bp => fileText.AppendLine($"          {bp},"));
          fileText.AppendLine($"      }};");
        }
        fileText.AppendLine(@"  }");
				fileText.AppendLine(@"}");

				Directory.CreateDirectory($"{Program.AnalysisDir}/References");
				File.WriteAllText($"{Program.AnalysisDir}/References/{className}.cs", fileText.ToString());
			}
		}

		// Ensures there are no name collisions or invalid characters.
		private static string SanitizeBlueprintName(string bpName, string className, HashSet<string> bpNames)
    {
			var baseSanitizedName = Regex.Replace(bpName, "[^A-Za-z0-9]", "_");
			if (char.IsDigit(baseSanitizedName[0]) || baseSanitizedName.Equals(className))
			{
				baseSanitizedName = $"_{baseSanitizedName}";
			}
			int dupeCount = 0;
			string sanitizedName = baseSanitizedName;
			while (bpNames.Contains(sanitizedName))
			{
				sanitizedName = $"{baseSanitizedName}_{dupeCount}";
				dupeCount++;
			}
			if (dupeCount > 1)
      {
				Console.WriteLine($"{className} {bpName} has too many dupes: {dupeCount}");
      }
			return sanitizedName;
    }

		private static void ProcessExamples(Type baseType)
		{
			StringBuilder examples = new();
			var entries = ExamplesByType.Where(entry => entry.Key.IsSubclassOf(baseType));
			foreach (var entry in entries)
			{
				var sortedExamples = entry.Value.OrderBy(ex => ex.BlueprintName).ToList();
				List<Blueprint> exampleBlueprints = new();
				if (sortedExamples.Count > 3)
				{
					// Use the first, last, and middle blueprints as examples. This should keep things relatively stable between
					// game patches and avoid biasing towards the first three entries alphabetically.
					exampleBlueprints.Add(sortedExamples.First());
					exampleBlueprints.Add(sortedExamples[sortedExamples.Count / 2]);
					exampleBlueprints.Add(sortedExamples.Last());
				}
				else
				{
					exampleBlueprints.AddRange(sortedExamples);
				}

				examples.AppendLine("");
				examples.AppendLine(@"        {");
				if (exampleBlueprints.Count < 3)
        {
					examples.AppendLine($"          // Flag for review");
        }
				examples.AppendLine($"          typeof({GetTypeName(entry.Key)}),");
				examples.AppendLine($"          new()");
				examples.AppendLine(@"          {");
				exampleBlueprints.ForEach(
					ex => examples.AppendLine($"            new Blueprint(\"{ex.BlueprintName}\", \"{ex.BlueprintGuid}\"),"));
				examples.AppendLine(@"          }");
				examples.AppendLine(@"        },");
			}

			var fileText = new StringBuilder();
			fileText.AppendLine("using BlueprintCoreGen.CodeGen.Methods;");
			fileText.AppendLine("using System;");
			fileText.AppendLine("using System.Collections.Generic;");
			fileText.AppendLine("");
			fileText.AppendLine(@"namespace BlueprintCoreGen.CodeGen.Overrides.Examples");
			fileText.AppendLine(@"{");
			fileText.AppendLine($"  // Examples generated by TypeUsageAnalyzer");
			fileText.AppendLine($"  internal static class Example{baseType.Name}s");
			fileText.AppendLine(@"  {");
			fileText.AppendLine($"    public static readonly Dictionary<Type, List<Blueprint>> Examples =");
			fileText.AppendLine($"      new()");
			fileText.AppendLine(@"      {");
			fileText.Append(examples);
			fileText.AppendLine(@"      };");
			fileText.AppendLine(@"  }");
			fileText.AppendLine(@"}");
			File.WriteAllText($"{Program.AnalysisDir}/Example{baseType.Name}s.cs", fileText.ToString());
		}

		// Populates BlueprintsByGuid and ExamplesByType
		private static void ProcessDB()
		{
			Stopwatch sw = Stopwatch.StartNew();
			ProcessBpZip();
			sw.Stop();
			Console.WriteLine($"Elapsed time: {sw.Elapsed}");
		}

		private static void ProcessBpZip()
		{
			StringBuilder searchResults = new();
			using var bpDump = ZipFile.OpenRead(Environment.ExpandEnvironmentVariables("%WrathPath%/blueprints.zip"));
			var processed = 0;
			foreach (var entry in bpDump.Entries)
			{
				if (!entry.Name.EndsWith(".jbp")) { continue; }

				var stream =
					entry
						.GetType()
						.GetMethod("OpenInReadMode", BindingFlags.NonPublic | BindingFlags.Instance)!
						.Invoke(entry, new object[] { false }) as Stream;
				var bp = JsonConvert.DeserializeObject<JObject>(new StreamReader(stream!).ReadToEnd());

				var guid = bp.Value<string>("AssetId");
				var data = bp.GetValue("Data");
				var bpType = GetType(data)!;
				
				// Weird case w/ AppsFlyer
				if (bpType is null)
					continue;

				if (SearchFilters.Any())
        {
					foreach (var search in SearchFilters)
          {
						if (search.Check(bpType, data))
            {
							searchResults.AppendLine($"{search.Name} found: {guid}");
            }
          }
        }

				// Fetch / create the Blueprint
				if (!BlueprintsByGuid.TryGetValue(guid, out Blueprint blueprint))
				{
					var name = entry.Name[0..^4];
					blueprint = new Blueprint(name, guid);
					BlueprintsByGuid.Add(guid, blueprint);
				}

				if (!BlueprintsByType.TryGetValue(bpType, out HashSet<Blueprint> blueprints))
				{
					blueprints = new();
					BlueprintsByType.Add(bpType, blueprints);
				}
				blueprints.Add(blueprint);

				// Add as an example blueprint type
				if (!ExamplesByType.TryGetValue(bpType, out HashSet<Blueprint> blueprintExamples))
				{
					blueprintExamples = new();
					ExamplesByType.Add(bpType, blueprintExamples);
				}
				blueprintExamples.Add(blueprint);

				List<Type> referencedTypes = new();
				GetTypes(data, referencedTypes);

				// Add as an example for the referenced action types
				var actionTypes = referencedTypes.Where(type => type.IsSubclassOf(typeof(GameAction)));
				foreach (var actionType in actionTypes)
				{
					if (!ExamplesByType.TryGetValue(actionType, out HashSet<Blueprint> actionExamples))
					{
						actionExamples = new();
						ExamplesByType.Add(actionType, actionExamples);
					}
					actionExamples.Add(blueprint);
				}

				// Add as an example for the referenced condition types
				var conditionTypes = referencedTypes.Where(type => type.IsSubclassOf(typeof(Condition)));
				foreach (var conditionType in conditionTypes)
				{
					if (!ExamplesByType.TryGetValue(conditionType, out HashSet<Blueprint> conditionExamples))
					{
						conditionExamples = new();
						ExamplesByType.Add(conditionType, conditionExamples);
					}
					conditionExamples.Add(blueprint);
				}

				// Add as an example for the referenced components types
				var componentTypes = referencedTypes.Where(type => type.IsSubclassOf(typeof(BlueprintComponent)));
				foreach (var componentType in componentTypes)
				{
					if (!ExamplesByType.TryGetValue(componentType, out HashSet<Blueprint> componentExamples))
					{
						componentExamples = new();
						ExamplesByType.Add(componentType, componentExamples);
					}
					componentExamples.Add(blueprint);
				}

				processed++;
				if (DebugLimit > 0 && processed > DebugLimit) { return; }
				if (processed % ReportThreshold == 0)
				{
					float progress = processed / (float)bpDump.Entries.Count;
					Console.WriteLine(string.Format("Progress: {0:P2}", progress));
				}
			}

			if (searchResults.Length > 0)
      {
				Console.WriteLine("\nSearch Results:");
				Console.WriteLine(searchResults);
      }
		}

		private static Type? GetType(JToken data)
		{
			var typeString = data.Value<string>("$type");
			if (typeString is not null)
			{
				var typeId = typeString[0..typeString.IndexOf(",")];
				if (TypesById.ContainsKey(typeId)) { return TypesById[typeId]; }

				var typeName = typeString[typeString.IndexOf(" ")..].Trim();
				if (TypesByName.ContainsKey(typeName)) { return TypesByName[typeName]; }

				if (DuplicateTypeIds.Contains(typeId))
				{
					Console.WriteLine($"Found reference to duplicate Type ID: {typeString}");
				}
			}
			return null;
		}

		// Recursively search the JToken to find all referenced types
		private static void GetTypes(JToken data, List<Type> types)
		{
			if (data.Type == JTokenType.Object)
			{
				// Only object types can have a property
				var type = GetType(data);
				if (type is not null) { types.Add(type); }
			}

			// No matter what kind of token, foreach loop will get all children
			foreach (var token in data)
			{
				GetTypes(token, types);
			}
		}

		private class SearchFilter
		{
			public string Name = string.Empty;
			public Type? BlueprintFilter = null;
			public Type? ComponentFilter = null;
			public Type? ElementFilter = null;
			public string FieldNameFilter = string.Empty;
			public string StringFieldValue = string.Empty;
			public bool InvertFieldValue = false;

			public bool Check(Type bpType, JToken data)
      {
				if (BlueprintFilter is not null && bpType != BlueprintFilter)
        {
					return false;
        }

				List<JToken> matchingTypes = new();
				if (ComponentFilter is not null)
        {
					GetMatchingTypes(data, ComponentFilter, matchingTypes);
        }

				if (ElementFilter is not null)
				{
					GetMatchingTypes(data, ElementFilter, matchingTypes);
				}

				if (ComponentFilter is null && ElementFilter is null)
        {
					matchingTypes.Add(data);
        }

				if (!matchingTypes.Any())
        {
					return false;
        }

				if (string.IsNullOrEmpty(FieldNameFilter))
        {
					return true;
        }

				foreach (var match in matchingTypes)
        {
					var fieldValue = match.Value<object?>(FieldNameFilter);

					if (fieldValue is null)
          {
						continue;
          }						

					if (StringFieldValue is null)
          {
						return true;
          }

					if (InvertFieldValue)
          {
						if (!fieldValue.ToString().Equals(StringFieldValue)) { return true; }
          }
				  else if (fieldValue.ToString().Equals(StringFieldValue))
          {
						return true;
          }
        }
				return false;
      }

			private void GetMatchingTypes(JToken data, Type targetType, List<JToken> matching)
			{
				if (data.Type == JTokenType.Object)
				{
					// Only object types can have a property
					var type = TypeUsageAnalyzer.GetType(data);
					if (type is not null && type == targetType) { matching.Add(data); }
				}

				// No matter what kind of token, foreach loop will get all children
				foreach (var token in data)
				{
					GetMatchingTypes(token, targetType, matching);
				}
			}
		}
	}
}
