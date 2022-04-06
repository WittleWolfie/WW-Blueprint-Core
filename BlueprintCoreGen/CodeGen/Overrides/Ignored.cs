using Kingmaker.Achievements.Actions;
using Kingmaker.AI.Blueprints;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.AreaLogic.Cutscenes.Components;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Armies.Components;
using Kingmaker.Armies.TacticalCombat.Brain;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.Armies.TacticalCombat.LeaderSkills.UnitBuffComponents;
using Kingmaker.Assets.Code.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Assets.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Assets.UnitLogic.Mechanics.Actions;
using Kingmaker.Assets.UnitLogic.Mechanics.Properties;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Encyclopedia;
using Kingmaker.Blueprints.Items.Components;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Blueprints.Quests.Logic;
using Kingmaker.Blueprints.Quests.Logic.CrusadeQuests;
using Kingmaker.Blueprints.TurnBasedModifiers;
using Kingmaker.Corruption;
using Kingmaker.Crusade.GlobalMagic;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Designers.EventConditionActionSystem.Events;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Designers.Mechanics.EquipmentEnchants;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Designers.Quests.Common;
using Kingmaker.DialogSystem;
using Kingmaker.Dungeon.Actions;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.Dungeon.Blueprints.Boons;
using Kingmaker.EntitySystem.Persistence.Versioning.UnitUpgraderOnlyActions;
using Kingmaker.EntitySystem.Persistence.Versioning.UpgraderOnlyActions;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom.Actions;
using Kingmaker.Kingdom.Armies.Actions;
using Kingmaker.Kingdom.Artisans;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Kingdom.Buffs;
using Kingmaker.Kingdom.Conditions;
using Kingmaker.Kingdom.Flags;
using Kingmaker.Kingdom.Settlements.BuildingComponents;
using Kingmaker.QA.Arbiter;
using Kingmaker.Tutorial.Solvers;
using Kingmaker.Tutorial.Triggers;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.ActivatableAbilities.Restrictions;
using Kingmaker.UnitLogic.Buffs;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Class.Kineticist.Properties;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Interaction;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Kingmaker.UnitLogic.Mechanics.Properties;
using Kingmaker.Visual.HitSystem;
using Kingmaker.Visual.LightSelector;
using System;
using System.Collections.Generic;

namespace BlueprintCoreGen.CodeGen.Overrides
{
  /// <summary>
  /// Stores types which should not be included in builders or configurators. Usually this indicates they are unused by
  /// the game but it is also used for some manual overrides such as basic condition operations implemented directly in
  /// ConditionsBuilder.
  /// </summary>
  public static class Ignored
  {
    public static readonly List<Type> BuilderTypes =
      new()
      {
        // ** Types implemented in ActionsBuilder **//

        typeof(Conditional),

        // *****************************************//

        // ** Types implemented in ConditionsBuilder **//

        typeof(False),
        typeof(GreaterThan),
        typeof(LessThan),
        typeof(OrAndLogic),

        // ********************************************//

        // ** BlueprintComponent types from TypeUsageAnalyzer **//

        typeof(EventDynamicCostFeast),
        typeof(TimeOfDaySettingsOverride),
        typeof(SplitDismemberComponent),
        typeof(TutorialTriggerEnemyHasVulnerability),
        typeof(TutorialTriggerLowGroupHealth),
        typeof(TutorialSolverAllFromTrigger),
        typeof(TutorialSolverItemFromTrigger),
        typeof(ArbiterWeaponTest),
        typeof(LocationRevealedTrigger),
        typeof(BoonLogicExperience),
        typeof(BoonLogicExperienceRate),
        typeof(BoonLogicGold),
        typeof(BoonLogicItem),
        typeof(BoonLogicPartyBuff),
        typeof(ActingCompanion),
        typeof(ChangeGlobalMagicPower),
        typeof(EtudeDisableCooking),
        typeof(EtudeOverrideCorruptionGrowth),
        typeof(DualCompanionComponent),
        typeof(LockedCompanionComponent),
        typeof(UnlockableFlagComponent),
        typeof(AbilityActivateWithUnitCommandInTurnBased),
        typeof(QuestComponentDelegate<>),
        typeof(QuestComponentDelegate),
        typeof(QuestObjectiveCallback),
        typeof(QuestRelatesToCompanionStory),
        typeof(TimedObjectiveTrigger),
        typeof(CrusadeMissionComponent),
        typeof(NobilityArmyRequestComponent),
        typeof(NobilityBuildingsRequestComponent),
        typeof(NobilityIncomeRequestComponent),
        typeof(NobilitySettlementsRequestComponent),
        typeof(RoyalCourtLeaderRequestComponent),
        typeof(RoyalCourtMissionsRequestComponent),
        typeof(RoyalCourtRanksRequestComponent),
        typeof(RoyalCourtVictoryRequestComponent),
        typeof(ItemEnchantmentEnableWhileEtudePlaying),
        typeof(WeaponDamageReroll),
        typeof(EquipmentRestrictionSpecialUnit),
        typeof(IdentifySkillReplacement),
        typeof(AddClassLevelsToPets),
        typeof(LevelUpRecommendation),
        typeof(PrerequisiteLoreMaster),
        typeof(AreaSettlementLink),
        typeof(BarkOnClick),
        typeof(AddGoldenDragonSkillBonus),
        typeof(AddIncomingDamageMaximum),
        typeof(AddOppositionDescriptor),
        typeof(AddParametrizedClassSkill),
        typeof(AddParametrizedStatBonus),
        typeof(AddPostLoadActions),
        typeof(AddSpellLevelLimit),
        typeof(AlchemistInfusionFeat),
        typeof(AreaEffectSpawnLogic),
        typeof(BookOfDreamsSummonUnitsCountLogic),
        typeof(ConfusionRollTrigger),
        typeof(DisableAttackType),
        typeof(DisableDeathFXs),
        typeof(ForbidSpellbook),
        typeof(LimbsApartDismembermentRestricted),
        typeof(OverrideUnitHP),
        typeof(ReplaceDamageDice),
        typeof(SpellLinkEvocation),
        typeof(LevelBasedPropertyWithFeatureList),
        typeof(RemoveBuffOnLoad),
        typeof(AddBuffActions),
        typeof(AddEffectProtectionFromElement),
        typeof(AddSpellSchool),
        typeof(SetBuffOnsetDelay),
        typeof(AddActivatableAbilityComponent),
        typeof(RestrictionHasPet),
        typeof(CustomPropertyGetter),
        typeof(UnitWeaponEnhancementGetter),
        typeof(UnitPropertyComponent),
        typeof(InitiatorRuleDealDamageTrigger),
        typeof(NonHumanoidCompanion),
        typeof(AbilityOnInBattleUnits),
        typeof(AbilityCustomAttack),
        typeof(AbilityCustomMove),
        typeof(AbilityDemonCharge),
        typeof(AbilityEffectRunActionOnClickedPoint),
        typeof(AbilityEffectRunActionOnClickedUnit),
        typeof(AbilitySwtichDualCompanionChecker),
        typeof(AbilityTargetIsFavoredEnemy),
        typeof(AdjacencyRestriction),
        typeof(AlignmentRestriction),
        typeof(ArtisanRestriction),
        typeof(Aviary),
        typeof(BuildingAdjacentGrowthIncrease),
        typeof(BuildingAdjacentResourceIncrease),
        typeof(BuildingCountsAs),
        typeof(BuildingGlobalGrowthIncrease),
        typeof(BuildingLoneSlotBonus),
        typeof(BuildingMoraleChangeBonus),
        typeof(BuildingUpgradeBonus),
        typeof(CaptalLevelRestriction),
        typeof(DLCRestriction),
        typeof(LoneSlotRestriction),
        typeof(ProjectRestriction),
        typeof(StatRankRestriction),
        typeof(BirthdayTrigger),
        typeof(BuildingSequenceCostMultiplierReduce),
        typeof(BuildingTrigger),
        typeof(EventResolutonTrigger),
        typeof(EventStartTrigger),
        typeof(KingdomConditionalStatChange),
        typeof(KingdomEventFixedBonus),
        typeof(KingdomEventModifier),
        typeof(KingdomIncomePerSettlement),
        typeof(KingdomIncomePerStat),
        typeof(KingdomIncomePerUnrest),
        typeof(KingdomUnrestChangeTrigger),
        typeof(MaxArmySquadsBonus),
        typeof(RegionBasedPartyBuff),
        typeof(SettlementTrigger),
        typeof(EventAISolution),
        typeof(EventRecurrence),
        typeof(ExclusiveProjects),
        typeof(MarkAsCrusadeProject),
        typeof(AttackBonusAgainstTacticalOwner),
        typeof(AttackBonusAgainstTacticalTarget),
        typeof(DamageBonusAgainstTacticalOwner),
        typeof(ArmyForceMelee),
        typeof(TacticalCombatChangeFaction),
        typeof(TacticalCombatEndMovementTrigger),
        typeof(ArmyAbilityTags),
        typeof(ModifyArmyUnitSpellPower),
        typeof(CustomProgressionPropertyGetter),
        typeof(MaxAttributeBonusGetter),
        typeof(ChangeObjectiveOnUnlockTrigger),
        typeof(GiveUnlockOnObjectiveTrigger),
        typeof(SummonPoolCountTrigger),
        typeof(AddSavesFixerArmorRecalculator),
        typeof(EnchantmentAddBuffWhileInStealth),
        typeof(ImproveEnhancmentIfHasEnchantment),
        typeof(ModifyWeaponStatsConditional),
        typeof(NaturalDamageStatReplacement),
        typeof(WeaponGroupAttackBonusEquipment),
        typeof(WeaponGroupDamageBonusEquipment),
        typeof(AddFactIfArchetype),
        typeof(AllSpellsParamsOverride),
        typeof(AttackDiceBonusOnce),
        typeof(AttackOfOpportunityAttackBonusAgainstFactOwner),
        typeof(CannyDefense),
        typeof(DRWithPool),
        typeof(DamageBonusAgainstSize),
        typeof(DefaultSourceBone),
        typeof(DisableIntelligence),
        typeof(DungeonClassRestrictedBuff),
        typeof(EvasionAgainstDescriptor),
        typeof(HarmoniousMage),
        typeof(IgnoreDamageGrowthByDifficulty),
        typeof(IncreaseWeaponDamageByBuffStack),
        typeof(RecalculateFeatures),
        typeof(RemoveAfterCast),
        typeof(ReplaceCasterLevelOfFeature),
        typeof(SaturationAuraComponent),
        typeof(SpellFixedCL),
        typeof(SpellLevelByRank),
        typeof(SpendChargesOnSpellCast),
        typeof(SwitchOffAtCombatEnd),
        typeof(TwoWeaponDefense),
        typeof(VolleyFireAttackBonus),
        typeof(WeaponCritAutoconfirmAgainstSize),
        typeof(WeaponImprovised),
        typeof(WeaponParametersCriticalMultiplierIncrease),
        typeof(AddStatBonusIfHasSkill),
        typeof(AfterbuffIfHasFact),
        typeof(ApplyBuffOnHit),
        typeof(BuffMiraculousHealing),
        typeof(BuffPerceptionBonus),
        typeof(BuffSaveOrDieEachRound),
        typeof(BuffStatPenaltyDice),
        typeof(BuffStrengthSkillsBonus),
        typeof(DamageOnRemove),
        typeof(DamageWithDescriptorRecievedTrigger),
        typeof(GreaterSnapShotBonus),
        typeof(HealOverTime),
        typeof(HealOverTimeIfHasFact),
        typeof(TemporaryHitPointsEqualCasterLevel),
        typeof(AddEquipmentToPet),
        typeof(CompanionRecruitTrigger),
        typeof(CompanionUnrecruitTrigger),
        typeof(CustomEventTrigger),
        typeof(DamageTypeTrigger),
        typeof(ExperienceTrigger),
        typeof(MapObjectDestroyTrigger),
        typeof(MapObjectPerceptionTrigger),
        typeof(PlayerOpenItemDescriptionFirstTimeTrigger),
        typeof(SkillCheckInteractionTrigger),
        typeof(EtudeBracketShowObjects),
        typeof(EtudeGameOverTrigger),
        typeof(DestroyCutsceneOnLoad),

        // *****************************************************//

        // ** Blueprint types from TypeUsageAnalyzer **//

        typeof(BlueprintDungeonArea),
        typeof(BlueprintDungeonBoon),
        typeof(BlueprintDungeonRoot),
        typeof(BlueprintDungeonShrine),
        typeof(BlueprintGenericPackLoot),
        typeof(BlueprintPet),
        typeof(BlueprintActionList),
        typeof(BlueprintItemEquipmentHandSimple),
        typeof(BlueprintEncyclopediaSkillPage),
        typeof(ArtisanItemDeck),
        typeof(BlueprintKingdomArtisan),
        typeof(BlueprintKingdomClaim),
        typeof(BlueprintKingdomUpgrade),
        typeof(BlueprintTacticalCombatAiPostponeTurn),
        typeof(BuffCollection),
        typeof(BlueprintAiRandomMove),
        typeof(BlueprintAiRunAway),
        typeof(ConsiderationCustom),
        typeof(IsEngagedConsideration),
        typeof(SavingThrowConsideration),
        typeof(SpecificUnitBlueprintConsideration),

        // ********************************************//

        // ** Condition types from TypeUsageAnalyzer **//

        typeof(ContextConditionCasterIsPartyEnemy),
        typeof(ContextConditionDungeonStage),
        typeof(ContextConditionHasUniqueBuff),
        typeof(ContextConditionStealth),
        typeof(ContextConditionTargetIsEngaged),
        typeof(BuildingHasNeighbours),
        typeof(DaysTillNextMonth),
        typeof(EventLifetime),
        typeof(KingdomAlignmentIs),
        typeof(KingdomAllArmiesInRegionDefeated),
        typeof(KingdomArtisanState),
        typeof(KingdomDay),
        typeof(KingdomEventCanStart),
        typeof(KingdomEventIsActive),
        typeof(KingdomHasResolvableEvent),
        typeof(KingdomHasUpgradeableSettlement),
        typeof(KingdomIsVisible),
        typeof(KingdomRegionIsUpgraded),
        typeof(KingdomSettlementHasBuilding),
        typeof(KingdomStatIsMaximum),
        typeof(KingdomTaskResolvedBy),
        typeof(KingdomUnrestCheck),
        typeof(CheckUnitSeeUnit),
        typeof(DualCompanionInactive),
        typeof(Paused),
        typeof(ChangeableDynamicIsLoaded),
        typeof(CheckLos),
        typeof(CompanionIsUnconscious),
        typeof(CompanionStoryUnlocked),
        typeof(CutsceneQueueState),
        typeof(ItemFromCollectionCondition),
        typeof(RomanceLocked),

        // ********************************************//

        // ** GameAction types from TypeUsageAnalyzer **//

        typeof(SetAlignmentFromBlueprint),
        typeof(SetSharedVendorTable),
        typeof(ActionCreateImportedCompanion),
        typeof(ActionEnterToDungeon),
        typeof(ActionGoDeeperIntoDungeon),
        typeof(ActionIncreaseDungeonStage),
        typeof(ActionSetDungeonStage),
        typeof(AbilityCustomSharedBurden),
        typeof(AbilityCustomSharedGrace),
        typeof(ContextActionAeonRollbackToSavedState),
        typeof(ContextActionAttackWithWeapon),
        typeof(ContextActionDetectSecretDoors),
        typeof(ContextActionForEachSwallowedUnit),
        typeof(ContextActionPrintHDRestrictionToCombatLog),
        typeof(ContextActionSpendAttackOfOpportunity),
        typeof(ContextActionStealBuffs),
        typeof(ContextActionTranslocate),
        typeof(KingdomMoraleFlagUpdateIncome),
        typeof(ChangeMercenaryWeight),
        typeof(DecreaseRecruitsPool),
        typeof(KingdomActionActivateEventDeck),
        typeof(KingdomActionAddFreeBuilding),
        typeof(KingdomActionArtisanRequestHelp),
        typeof(KingdomActionCollectLoot),
        typeof(KingdomActionFillSettlementByLocation),
        typeof(KingdomActionGetArtisanGift),
        typeof(KingdomActionGetArtisanGiftWithCertainTier),
        typeof(KingdomActionGetResourcesByUnitsCount),
        typeof(KingdomActionMakeRoll),
        typeof(KingdomActionModifyBuildTime),
        typeof(KingdomActionModifyClaims),
        typeof(KingdomActionModifyEventDC),
        typeof(KingdomActionModifyRE),
        typeof(KingdomActionModifyRankTime),
        typeof(KingdomActionModifyStatRandom),
        typeof(KingdomActionModifyUnrest),
        typeof(KingdomActionPullRankupChangesIntoDialog),
        typeof(KingdomActionRemoveEventDeck),
        typeof(KingdomActionRequestArtisanGift),
        typeof(KingdomActionResetRecurrence),
        typeof(KingdomActionRestartEvent),
        typeof(KingdomActionRollbackRecurrence),
        typeof(KingdomActionSetAlignment),
        typeof(KingdomActionSetRegionalIncome),
        typeof(ContextActionSwitchDualCompanion),
        typeof(AddDialogNotification),
        typeof(AdvanceUnitLevel),
        typeof(AlignmentSelector),
        typeof(AreaEntranceChange),
        typeof(ChangeRomance),
        typeof(ClearBlood),
        typeof(ClearUnitReturnPosition),
        typeof(CustomEvent),
        typeof(DestroyMapObject),
        typeof(ItemSetCharges),
        typeof(LockRomance),
        typeof(MarkUnitEssentialObsolete),
        typeof(OverrideRainIntesity),
        typeof(RelockInteraction),
        typeof(RemoveAllAreasFromSave),
        typeof(RemoveDuplicateItems),
        typeof(ReplaceAllMythicLevelsWithMythicHeroLevels),
        typeof(ReplaceFeatureInProgression),
        typeof(ResetLocationPerceptionCheck),
        typeof(RestoreItemsCountInCollection),
        typeof(RomanceSetMaximum),
        typeof(RomanceSetMinimum),
        typeof(SetStartDate),
        typeof(StatusEffect),
        typeof(SwitchDualCompanion),
        typeof(TransferSharedVendorTable),
        typeof(UnlinkDualCompanions),
        typeof(UnlockCookingRecipe),
        typeof(ActionAchievementIncrementCounter),

        // *********************************************//
      };
  }
}
