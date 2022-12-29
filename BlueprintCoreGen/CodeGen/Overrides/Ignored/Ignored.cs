using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Console;
using Kingmaker.Blueprints.Credits;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Designers.Mechanics.Facts.Behavior;
using Kingmaker.Designers.Mechanics.Recommendations;
using Kingmaker.Designers.Mechanics.WeaponEnchants;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Kingdom.Settlements.BuildingComponents;
using Kingmaker.QA.Arbiter;
using Kingmaker.QA.Clockwork;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;
using Kingmaker.UnitLogic.ActivatableAbilities.Restrictions;
using Kingmaker.UnitLogic.Class.Kineticist.Properties;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Components;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace BlueprintCoreGen.CodeGen.Overrides.Ignored
{
  /// <summary>
  /// Flags whether a type should be ignored. Usually this is for unused fields but there are some manually ignored
  /// types as well.
  /// </summary>
  public static class Ignored
  {
    private static readonly List<(Type type, List<string> names)> IgnoredFields =
      new()
      {
        (typeof(Element), new() { "name" }),
        (typeof(BlueprintComponent), new() { "m_Flags", "m_PrototypeLink", "name" }),
        (
          typeof(BlueprintScriptableObject),
          new()
          {
            "Components",
            "m_AllElements",
            "AssetGuid",
            "m_PrototypeId",
            "m_Overrides",
            "Comment",
            "name",
            "m_ValidationStatus"
          }
        ),
        (typeof(BlueprintFeature), new() { "m_DescriptionModifiersCache" }),
        (typeof(BlueprintFeatureSelection), new() { "m_Features" }),
        (typeof(BlueprintProgression), new() { "AlternateProgressionType" }),
        (typeof(BlueprintAbility), new() { "AnimationStyle" }),
        (typeof(BlueprintAnswer), new() { "RequireValidCue" }),
      };
    public static bool ShouldIgnoreField(FieldInfo info, Type sourceType)
    {
      if (info.FieldType.IsGenericType && info.FieldType.GetGenericTypeDefinition() == typeof(ReferenceListProxy<,>))
      {
        return true;
      }

      var ignoreField = false;
      IgnoredFields.ForEach(
        ignoredFields =>
        {
          if (
            (sourceType == ignoredFields.type || sourceType.IsSubclassOf(ignoredFields.type))
            && ignoredFields.names.Contains(info.Name))
          {
            ignoreField = true;
          }
        });

      return ignoreField
        || info.Name.Contains("_Cached")        // Name used by Owlcat for cache fields
        || info.Name.Contains("__BackingField") // Compiler generated field
                                                // Skip constant, static, and read-only
        || info.IsLiteral
        || info.IsStatic
        || info.IsInitOnly;
    }

    private static readonly List<Type> IgnoredTypes =
      new()
      {
        // Types implemented in ActionsBuilder
        typeof(Conditional),

        // Types implemented in ConditionsBuilder
        typeof(False),
        typeof(GreaterThan),
        typeof(LessThan),
        typeof(OrAndLogic),

        // Legacy types
        typeof(AddStatBonusScaled),

        // QA Types
        typeof(BlueprintArbiterInstruction),
        typeof(BlueprintArbiterRoot),
        typeof(BlueprintClockworkScenario),
        typeof(BlueprintClockworkScenarioPart),

        // Credits
        typeof(BlueprintCreditsGroup),
        typeof(BlueprintCreditsRoles),
        typeof(BlueprintCreditsTeams),

        // Console
        typeof(GamePadTexts),

        // Fixed Components
        typeof(AddStatBonusIfHasFact),

        // Obsolete Components
        typeof(AbilityCustomFly),
        typeof(AbilityCustomTongueGrab),
        typeof(AbilityFocusParametrized),
        typeof(AbilitySillyFeed),
        typeof(AbilityTargetStoneToFlesh),
        typeof(AbilityMagusSpellRecallCostCalculator),
        typeof(AbilitySwitchDualCompanion),
        typeof(AccomplishedSneakAttacker),
        typeof(AcrobaticMovement),
        typeof(AddFortificationObsolete),
        typeof(AddImmunityFirebrand),
        typeof(AddLocustSwarmMechanicPart),
        typeof(AddOutgoingDamageTrigger),
        typeof(AddNimbusDamageDivisor),
        typeof(AddNocticulaBonus),
        typeof(AddTricksterAthleticBonus),
        typeof(AeonSavedStateFeature),
        typeof(AlliedSpellcaster),
        typeof(AngelSwordAdditionalDamageAndHeal),
        typeof(ArcaneBloodlineArcana),
        typeof(ArmagsBladeEnrage),
        typeof(AttackStatReplacement),
        typeof(AzataFavorableMagic),
        typeof(BackToBack),
        typeof(BackToBackBetter),
        typeof(BashingFinish),
        typeof(BodyguardACBonus),
        typeof(BrilliantEnergy),
        typeof(Bugurt),
        typeof(BurstBarrier),
        typeof(CavalierMountedMastery),
        typeof(CavalierRetribution),
        typeof(CavalierStandAgainstDarkness),
        typeof(CavalierStealGlory),
        typeof(CoordinatedDefense),
        typeof(CoordinatedManeuvers),
        typeof(ConduitSurge),
        typeof(DamageBonusOrderOfCockatrice),
        typeof(DamageGrace),
        typeof(DemonSocothbenothAspect),
        typeof(DeskariAspect),
        typeof(DestructiveShockwave),
        typeof(DevilReflectAbility),
        typeof(DuelistPreciseStrike),
        typeof(EchoesOfStoneTerrainBonus),
        typeof(EnduringSpells),
        typeof(EqualForce),
        typeof(EvasionWithTowerShield),
        typeof(ExpandedArsenalMagicSchools),
        typeof(FastBombs),
        typeof(FightingDefensivelyACBonusProperty),
        typeof(FightingDefensivelyAttackPenaltyProperty),
        typeof(FlamewardenBurningRenewal),
        typeof(FullWeaponMasterySkeletonParametrized),
        typeof(GentlePersuasionConditioning),
        typeof(Hardy),
        typeof(ImpatienceCalmingPart),
        typeof(ImpatienceWatcherTickingResolve),
        typeof(ImprovedCriticalParametrized),
        typeof(IndomitableMount),
        typeof(InHarmsWay),
        typeof(IntenseSpells),
        typeof(IsAlchemistSpellbook),
        typeof(KensaiChosenWeapon),
        typeof(KensaiCriticalPerfection),
        typeof(KensaiIaijutsuFocus),
        typeof(KensaiPerfectStrike),
        typeof(KensaiPowerfulCrit),
        typeof(KensaiWeaponMastery),
        typeof(ImprovedCriticalEdgeParametrized),
        typeof(LiquidateTowerShieldPenalty),
        typeof(MountedCombat),
        typeof(MountedShield),
        typeof(MythicUnarmedStrike),
        typeof(Opportunist),
        typeof(OutflankDamageBonus),
        typeof(OutflankProvokeAttack),
        typeof(PenetratingStrike),
        typeof(PreciseStrike),
        typeof(PointBlankMasterParametrized),
        typeof(PowerAttackWatcher),
        typeof(PreciseShot),
        typeof(PreciseShotDivineHunterTarget),
        typeof(PummelingCharge),
        typeof(RecommendationAccomplishedSneakAttacker),
        typeof(RestrictionKensaiWeapon),
        typeof(Revolt),
        typeof(SavingSlash),
        typeof(SchoolMasteryParametrized),
        typeof(ShatterConfidence),
        typeof(ShakeItOff),
        typeof(ShieldedCaster),
        typeof(ShieldFocus),
        typeof(ShieldMaster),
        typeof(ShieldWall),
        typeof(SiezeTheMoment),
        typeof(ShroudOfWater),
        typeof(SpellPenetrationMythicBonus),
        typeof(StonyStepTerrainBonus),
        typeof(SuppressBane),
        typeof(SuppressBuffs),
        typeof(SurpriseSpells),
        typeof(TellingBlow),
        typeof(TeleportationCircle),
        typeof(TowerShieldSpecialistTotalCover),
        typeof(TricksterArcanaAdditionalEnchantments),
        typeof(TricksterArcanaBetterEnhancements),
        typeof(TricksterKnowledgeWorldSkillBonus),
        typeof(TricksterKnowledgeWorldD20),
        typeof(TricksterLoreNatureRestTrigger),
        typeof(TricksterParry),
        typeof(TwoWeaponCriticalAdditionalAttackEnchant),
        typeof(TwoWeaponFightingAttackPenalty),
        typeof(TwoWeaponFightingAttacks),
        typeof(TwoWeaponFightingDamagePenalty),
        typeof(UnfailingBeacon),
        typeof(UnwillingShield),
        typeof(UnwillingShieldTarget),
        typeof(WeaponAngelDamageDice),
        typeof(WeaponBuffOnConfirmedCrit),
        typeof(WeaponFocusParametrized),
        typeof(WeaponMasteryParametrized),
        typeof(WeaponSpecializationParametrized),
        typeof(WeaponTrainingAttackStatReplacement),
        typeof(WizardEnergyAbsorption),
      };
    public static bool ShouldIgnore(Type type)
    {
      return IgnoredTypes.Contains(type)
        || IgnoredBlueprintComponents.Types.Contains(type)
        || IgnoredBlueprintScriptableObjects.Types.Contains(type)
        || IgnoredConditions.Types.Contains(type)
        || IgnoredGameActions.Types.Contains(type);
    }
  }
}
