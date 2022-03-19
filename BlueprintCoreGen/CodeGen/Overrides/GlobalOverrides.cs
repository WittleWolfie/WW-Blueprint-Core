using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.RandomEncounters.Settings;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Class.Kineticist;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using System;
using System.Collections.Generic;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Quests.Logic;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.Blueprints.Quests;
using Kingmaker.ElementsSystem;

namespace BlueprintCoreGen.CodeGen.Overrides
{
  /// <summary>
  /// Stores hardcoded overrides.
  /// </summary>
  public class GlobalOverrides
  {
    /// <summary>
    /// Overrides the supported blueprint types of BlueprintComponents.
    /// </summary>
    public static readonly Dictionary<Type, List<Type>> AllowedBlueprintTypes =
        new()
        {
          { typeof(CombatRandomEncounterAreaSettings), new() { typeof(BlueprintArea) } },
          { typeof(AbilityUseOnRest), new() { typeof(BlueprintAbility) } },
          { typeof(AddFactContextActions), new() { typeof(BlueprintFact) } },
          { typeof(AddBuffActions), new() { typeof(BlueprintFact) } },
          { typeof(AllowOnZoneSettings), new() { typeof(BlueprintAreaEnterPoint) } },
          { typeof(ComponentsList), new() { typeof(BlueprintFact) } },
          { typeof(AddClassLevelsToPets), new() { typeof(BlueprintUnit) } },
          { typeof(ChangeVendorPrices), new() { typeof(BlueprintUnit) } },
          { typeof(AbilityAcceptBurnOnCast), new() { typeof(BlueprintAbility) } },
          { typeof(AbilityAoERadius), new() { typeof(BlueprintAbility) } },
          { typeof(AbilityMagusSpellRecallCostCalculator), new() { typeof(BlueprintAbility) } },
          { typeof(AbilityTargetCellsRestriction), new() { typeof(BlueprintAbility) } },
          { typeof(AbilityTargetHasCondition), new() { typeof(BlueprintAbility) } },
          { typeof(AbilityTargetHasConditionOrBuff), new() { typeof(BlueprintAbility) } },
          { typeof(AbilityTargetHasOneOfConditionsOrHP), new() { typeof(BlueprintAbility) } },
          { typeof(AbilityTargetIsAnimalCompanion), new() { typeof(BlueprintAbility) } },
          { typeof(AbilityTargetIsSuitableMount), new() { typeof(BlueprintAbility) } },
          { typeof(AbilityTargetIsSuitableMountSize), new() { typeof(BlueprintAbility) } },
          { typeof(AbilityTargetRangeRestriction), new() { typeof(BlueprintAbility) } },
          { typeof(AddEquipmentToPet), new() { typeof(BlueprintUnit) } }
        };

    // TODO: Replace this with some automated way of identifying unused components.
    /// <summary>
    /// BlueprintComponent types to ignore because they are unused.
    /// </summary>
    public static readonly List<Type> IgnoredComponentTypes =
        new()
        {
          typeof(QuestComponentDelegate<>),
          typeof(QuestComponentDelegate),
          typeof(UnlockableFlagComponent),
          typeof(UniqueSpellComponent),
          typeof(MobCaster),
          typeof(PortraitPremiumSetting),
          typeof(AreaEffectSpawnLogic),
          typeof(ActivatableAbilityMount),
          typeof(LineOfSightIgnorance),
          typeof(WeaponMagic)
        };

    // TODO: Implement Blueprint Field support w/ config overrides
    public static readonly List<(Type type, List<string> fieldNames)> IgnoredFieldNamesByType =
        new()
        {
          (typeof(BlueprintQuestObjective), new() { "m_AreasProxy", "m_AddendumsProxy", "m_NextObjectivesProxy" }),
        };

    public static readonly List<(Type type, List<string> names)> IgnoredFields =
      new()
      {
        (typeof(Element), new() { "name" }),
        (typeof(BlueprintComponent), new() { "m_Flags", "m_PrototypeLink", "name" }),
      };

    public static Dictionary<Type, string> TypeNameOverrides =
        new()
        {
          // Name conflicts
          { typeof(Kingmaker.AI.Blueprints.TargetType), "Kingmaker.AI.Blueprints.TargetType" },
          { typeof(Kingmaker.UnitLogic.Abilities.Components.TargetType), "Kingmaker.UnitLogic.Abilities.Components.TargetType" },
          { typeof(Kingmaker.UnitLogic.Mechanics.ValueType), "Kingmaker.UnitLogic.Mechanics.ValueType" },

          { typeof(bool), "bool" },
          { typeof(bool?), "bool" },

          { typeof(byte), "byte" },
          { typeof(byte?), "byte" },

          { typeof(sbyte), "sbyte" },
          { typeof(sbyte?), "sbyte" },

          { typeof(ushort), "ushort" },
          { typeof(ushort?), "ushort" },

          { typeof(int), "int" },
          { typeof(int?), "int" },

          { typeof(uint), "uint" },
          { typeof(uint?), "uint" },

          { typeof(long), "long" },
          { typeof(long?), "long" },

          { typeof(ulong), "ulong" },
          { typeof(ulong?), "ulong" },

          { typeof(char), "char" },
          { typeof(char?), "char" },

          { typeof(double), "double" },
          { typeof(double?), "double" },

          { typeof(float), "float" },
          { typeof(float?), "float" },

          { typeof(string), "string" },
        };

    /// <summary>
    /// Ensures parameter names compile successfully. This is for things like 'm_Class' which would map to a parameter
    /// name of 'class' normally.
    /// </summary>
    public static readonly Dictionary<string, string> ParamNameOverrides =
          new()
          {
            { "default", "defaultValue" },
            { "event", "eventValue" },
            { "break", "breakValue" },
            { "string", "stringValue" },
            { "class", "clazz" },
            { "override", "overrideValue" },
            { "continue", "continueValue" },
            { "double", "doubleValue" }
          };
  }
}
