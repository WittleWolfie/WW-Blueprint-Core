using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Quests;
using Kingmaker.Blueprints.Quests.Logic;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.ElementsSystem;
using Kingmaker.RandomEncounters.Settings;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;
using Kingmaker.UnitLogic.ActivatableAbilities;
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
          typeof(UnlockableFlagComponent),
          typeof(UniqueSpellComponent),
          typeof(MobCaster),
          typeof(PortraitPremiumSetting),
          typeof(AreaEffectSpawnLogic),
          typeof(ActivatableAbilityMount),
          typeof(LineOfSightIgnorance),
          typeof(WeaponMagic)
        };

    public static readonly List<(Type type, List<string> fieldNames)> IgnoredFieldNamesByType =
        new()
        {
          (typeof(Element), new() { "name" }),
          (typeof(BlueprintComponent), new() { "m_Flags", "name", "m_PrototypeLink" }),
          (typeof(BlueprintQuestObjective), new() { "m_AreasProxy", "m_AddendumsProxy", "m_NextObjectivesProxy" }),
          (typeof(AbilityDeliverEffect), new() { "m_HasIsAllyEffectRunConditions" })
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
