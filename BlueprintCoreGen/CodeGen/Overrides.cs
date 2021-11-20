using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Quests.Logic;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.RandomEncounters.Settings;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Class.Kineticist;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using System;
using System.Collections.Generic;

namespace BlueprintCoreGen.CodeGen
{
  /// <summary>
  /// Stores manual overrides used in code generation.
  /// </summary>
  public static class Overrides
  {
    public static readonly Dictionary<Type, List<Type>> AllowedBlueprintTypesOverride =
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

    public static readonly List<Type> IgnoredComponentTypes =
        new()
        {
          typeof(QuestComponentDelegate<>),
          typeof(QuestComponentDelegate),
          typeof(UnlockableFlagComponent)
        };

    public static readonly Dictionary<Type, string> TypeNameOverrides =
          new()
          {
            { typeof(Kingmaker.UnitLogic.Mechanics.ValueType), "Kingmaker.UnitLogic.Mechanics.ValueType" },
            { typeof(Kingmaker.UnitLogic.Abilities.Components.TargetType), "Kingmaker.UnitLogic.Abilities.Components.TargetType" },
            { typeof(Kingmaker.AI.Blueprints.TargetType), "Kingmaker.AI.Blueprints.TargetType" },
            { typeof(bool), "bool" },
            { typeof(bool?), "bool?" },
            { typeof(byte), "byte" },
            { typeof(byte?), "byte?" },
            { typeof(sbyte), "sbyte" },
            { typeof(sbyte?), "sbyte?" },
            { typeof(ushort), "ushort" },
            { typeof(ushort?), "ushort?" },
            { typeof(int), "int" },
            { typeof(int?), "int?" },
            { typeof(uint), "uint" },
            { typeof(uint?), "uint?" },
            { typeof(long), "long" },
            { typeof(long?), "long?" },
            { typeof(ulong), "ulong" },
            { typeof(ulong?), "ulong?" },
            { typeof(char), "char" },
            { typeof(char?), "char?" },
            { typeof(double), "double" },
            { typeof(double?), "double?" },
            { typeof(float), "float" },
            { typeof(float?), "float?" },
            { typeof(string), "string" },
          };

    public static readonly List<string> IgnoredFieldNames =
        new()
        {
          "m_PrototypeLink",
          "m_HasIsAllyEffectRunConditions",
          "m_NextObjectivesProxy",
          "m_AddendumsProxy",
          "m_AreasProxy",
          "name"
        };

    public static readonly Dictionary<string, string> FriendlyNameOverrides =
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
