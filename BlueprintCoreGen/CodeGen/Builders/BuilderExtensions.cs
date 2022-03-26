using BlueprintCoreGen.CodeGen.Methods;
using Kingmaker.Achievements.Actions;
using Kingmaker.AreaLogic.Capital;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.Armies.TacticalCombat.GameActions;
using Kingmaker.Assets.UnitLogic.Mechanics.Actions;
using Kingmaker.Corruption;
using Kingmaker.Crusade.GlobalMagic.Actions;
using Kingmaker.Crusade.GlobalMagic.Actions.DamageLogic;
using Kingmaker.Crusade.GlobalMagic.Actions.SummonLogics;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Dungeon.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Persistence.Versioning.PlayerUpgraderOnlyActions;
using Kingmaker.EntitySystem.Persistence.Versioning.UnitUpgraderOnlyActions;
using Kingmaker.EntitySystem.Persistence.Versioning.UpgraderOnlyActions;
using Kingmaker.Kingdom.Actions;
using Kingmaker.Kingdom.Armies.Actions;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Kingdom.Flags;
using Kingmaker.Tutorial.Actions;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Buffs.Actions;
using Kingmaker.UnitLogic.Class.Kineticist.Actions;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BlueprintCoreGen.CodeGen.Builders
{
  /// <summary>
  /// Contains basic information needed to generate a builder extension class.
  /// </summary>
  public interface IBuilderExtension
  {
    /// <summary>
    /// Relative file path of the class, e.g. Actions/Builder/AreaEx/ActionsBuilderAreaEx.cs.
    /// </summary>
    public string FilePath { get; }

    /// <summary>
    /// Namespace for the extension class, e.g. BlueprintCore.Actions.Builder.AreaEx
    /// </summary>
    public string Namespace { get; }

    /// <summary>
    /// Name of the extension, e.g. AreaEx for ActionsBuilderAreaEx.
    /// </summary>
    public string ClassName { get; }

    /// <summary>
    /// Extension class summary comment.
    /// </summary>
    public string Summary { get; }

    /// <summary>
    /// Type name for the parent class, e.g. ActionsBuilder
    /// </summary>
    public string ParentType { get; }

    /// <summary>
    /// List of methods in the extension.
    /// </summary>
    public List<BuilderMethod> Methods { get; }
  }

  public enum BuilderType
  {
    Action,
    Condition
  }

  /// <summary>
  /// Contains configuration for the builder extension classes.
  /// </summary>
  /// 
  /// Configuration in this context is everything defined in IBuilderExtension, so it will determine the class names,
  /// file paths, class comment summary, which element types are implemented, etc.
  public static class BuilderExtensions
  {
    public static List<IBuilderExtension> Get(BuilderType type)
    {
      if (type == BuilderType.Action) { return ActionExtensions; }
      return ConditionExtensions;
    }

    private static readonly List<IBuilderExtension> ConditionExtensions = new();

    private static readonly List<IBuilderExtension> ActionExtensions =
      new()
      {
        new ActionExtension(
          ExtensionType.AreaEx,
          "Extension to <see cref=\"ActionsBuilder\"/> for actions involving the game map, dungeons, or locations."
              + " See also <see cref=\"KingdomEx.ActionsBuilderKingdomEx\">KingdomEx</see>.",
          "AreaActions.json"),

        new ActionExtension(
          ExtensionType.AVEx,
          "Extension to <see cref=\"ActionsBuilder\"/> for actions involving audiovisual effects such as dialogs,"
              + " camera, cutscenes, and sounds.",
          "AVActions.json"),

        new ActionExtension(
          ExtensionType.BasicEx,
          "Extension to <see cref=\"ActionsBuilder\"/> for most game mechanics related actions not included in"
              + " <see cref=\"ContextEx.ActionsBuilderContextEx\">ContextEx</see>.",
          "BasicActions.json"),
          //new()
          //{
          //  // Kingmaker.Designers.EventConditionActionSystem.Actions
          //  typeof(AttachBuff),
          //  typeof(CreaturesAround),
          //  typeof(AddFact),
          //  typeof(AddFatigueHours),
          //  typeof(ChangeAlignment),
          //  typeof(ChangePlayerAlignment),
          //  typeof(DamageParty),
          //  typeof(DealDamage),
          //  typeof(DealStatDamage),
          //  typeof(AddItemsToCollection),
          //  typeof(AddItemToPlayer),
          //  typeof(AdvanceUnitLevel),
          //  typeof(DestroyUnit),
          //  typeof(CombineToGroup),
          //  typeof(ClearUnitReturnPosition),
          //  typeof(AddUnitToSummonPool),
          //  typeof(DeleteUnitFromSummonPool),
          //  typeof(DetachBuff),
          //  typeof(DisableExperienceFromUnit),
          //  typeof(DrainEnergy),
          //  typeof(FakePartyRest),
          //  typeof(GainExp),
          //  typeof(GainMythicLevel),
          //  typeof(HealParty),
          //  typeof(HealUnit),
          //  typeof(ItemSetCharges),
          //  typeof(Kill),
          //  typeof(LevelUpUnit),
          //  typeof(MeleeAttack),
          //  typeof(PartyUnits),
          //  typeof(PartyUseAbility),
          //  typeof(RaiseDead),
          //  typeof(RandomAction),
          //  typeof(RemoveDeathDoor),
          //  typeof(Kingmaker.Designers.EventConditionActionSystem.Actions.RemoveFact),
          //  typeof(RollPartySkillCheck),
          //  typeof(RollSkillCheck),
          //  typeof(RunActionHolder),
          //  typeof(Spawn),
          //  typeof(SpawnBySummonPool),
          //  typeof(SpawnByUnitGroup),
          //  typeof(StatusEffect),
          //  typeof(Summon),
          //  typeof(SummonPoolUnits),
          //  typeof(SummonUnitCopy),
          //  typeof(SwitchActivatableAbility),
          //  typeof(SwitchDualCompanion),
          //  typeof(UnitsFromSpawnersInUnitGroup)
          //}),

        new ActionExtension(
          ExtensionType.ContextEx,
          "Extension to <see cref=\"ActionsBuilder\"/> for most <see cref=\"ContextAction\"/> types. Some"
              + " <see cref=\"ContextAction\"/> types are in more specific extensions such as"
              + " <see cref=\"AVEx.ActionsBuilderAVEx\">AVEx</see> or"
              + " <see cref=\"KingdomEx.ActionsBuilderKingdomEx\">KingdomEx</see>.",
          "ContextActions.json"),
          //new()
          //{
          //  // Kingmaker.Assets.UnitLogic.Mechanics.Actions
          //  typeof(ContextActionResetAlignment),
          //  typeof(ContextActionSwarmAttack),
          //  typeof(ContextActionSwitchDualCompanion),

          //  // Kingmaker.Designers.EventConditionActionSystem.Actions
          //  typeof(ContextActionAddRandomTrashItem),

          //  // Kingmaker.UnitLogic.Abilities.Components
          //  typeof(ContextActionRestoreAllSpellSlots),

          //  // Kingmaker.UnitLogic.Buffs.Actions
          //  typeof(BuffActionAddStatBonus),

          //  // Kingmaker.UnitLogic.Class.Kineticist.Actions
          //  typeof(ContextActionAcceptBurn),
          //  typeof(ContextActionHealBurn),

          //  // Kingmaker.UnitLogic.Mechanics.Actions
          //  typeof(AbilityCustomSharedBurden),
          //  typeof(AbilityCustomSharedGrace),
          //  typeof(ContextActionAddFeature),
          //  typeof(ContextActionAddLocustClone),
          //  typeof(ContextActionAeonRollbackToSavedState),
          //  typeof(ContextActionApplyBuff),
          //  typeof(ContextActionArmorEnchantPool),
          //  typeof(ContextActionShieldArmorEnchantPool),
          //  typeof(ContextActionWeaponEnchantPool),
          //  typeof(ContextActionShieldWeaponEnchantPool),
          //  typeof(ContextActionAttackWithWeapon),
          //  typeof(ContextActionBatteringBlast),
          //  typeof(ContextActionBreakFree),
          //  typeof(ContextActionBreathOfLife),
          //  typeof(ContextActionBreathOfMoney),
          //  typeof(ContextActionCastSpell),
          //  typeof(ContextActionChangeSharedValue),
          //  typeof(ContextActionClearSummonPool),
          //  typeof(ContextActionCombatManeuver),
          //  typeof(ContextActionCombatManeuverCustom),
          //  typeof(ContextActionConditionalSaved),
          //  typeof(ContextActionDealDamage),
          //  typeof(ContextActionDealWeaponDamage),
          //  typeof(ContextActionDetachFromSpawner),
          //  typeof(ContextActionDetectSecretDoors),
          //  typeof(ContextActionDevourBySwarm),
          //  typeof(ContextActionDisarm),
          //  typeof(ContextActionDismissAreaEffect),
          //  typeof(ContextActionDismount),
          //  typeof(ContextActionDispelMagic),
          //  typeof(ContextActionDropItems),
          //  typeof(ContextActionEnchantWornItem),
          //  typeof(ContextActionFinishObjective),
          //  typeof(ContextActionForEachSwallowedUnit),
          //  typeof(ContextActionGiveExperience),
          //  typeof(ContextActionGrapple),
          //  typeof(ContextActionHealEnergyDrain),
          //  typeof(ContextActionHealStatDamage),
          //  typeof(ContextActionHealTarget),
          //  typeof(ContextActionHideInPlainSight),
          //  typeof(ContextActionKill),
          //  typeof(ContextActionKnockdownTarget),
          //  typeof(ContextActionMakeKnowledgeCheck),
          //  typeof(ContextActionMarkForceDismemberOwner),
          //  typeof(ContextActionMeleeAttack),
          //  typeof(ContextActionMount),
          //  typeof(ContextActionOnContextCaster),
          //  typeof(ContextActionOnOwner),
          //  typeof(ContextActionOnRandomAreaTarget),
          //  typeof(ContextActionOnRandomTargetsAround),
          //  typeof(ContextActionOnSwarmTargets),
          //  typeof(ContextActionPrintHDRestrictionToCombatLog),
          //  typeof(ContextActionProjectileFx),
          //  typeof(ContextActionProvokeAttackFromCaster),
          //  typeof(ContextActionProvokeAttackOfOpportunity),
          //  typeof(ContextActionPush),
          //  typeof(ContextActionRandomize),
          //  typeof(ContextActionRangedAttack),
          //  typeof(ContextActionRecoverItemCharges),
          //  typeof(ContextActionReduceBuffDuration),
          //  typeof(ContextActionRemoveBuff),
          //  typeof(ContextActionRemoveBuffsByDescriptor),
          //  typeof(ContextActionRemoveBuffSingleStack),
          //  typeof(ContextActionReduceDebilitatingBuffsDuration),
          //  typeof(ContextActionRemoveDeathDoor),
          //  typeof(ContextActionRemoveSelf),
          //  typeof(ContextActionRepeatedActions),
          //  typeof(ContextActionRestoreSpells),
          //  typeof(ContextActionResurrect),
          //  typeof(ContextActionSavingThrow),
          //  typeof(ContextActionSelectByValue),
          //  typeof(ContextActionSkillCheck),
          //  typeof(ContextActionsOnPet),
          //  typeof(ContextActionSpawnAreaEffect),
          //  typeof(ContextActionSpawnControllableProjectile),
          //  typeof(ContextActionSpawnMonster),
          //  typeof(ContextActionSpawnUnlinkedMonster),
          //  typeof(ContextActionSpendAttackOfOpportunity),
          //  typeof(ContextActionStealBuffs),
          //  typeof(ContextActionSwallowWhole),
          //  typeof(ContextActionSwarmTarget),
          //  typeof(ContextActionTranslocate),
          //  typeof(ContextActionUnsummon),
          //  typeof(ContextRestoreResource),
          //  typeof(ContextSpendResource),
          //  typeof(Demoralize),
          //  typeof(EnhanceWeapon),
          //  typeof(SwordlordAdaptiveTacticsAdd),
          //  typeof(SwordlordAdaptiveTacticsClear)
          //}),

        //new ActionExtension(
        //  ExtensionType.KingdomEx,
        //  "Extension to <see cref=\"ActionsBuilder\"/> for actions involving the Kingdom and Crusade system.",
        //  "KingdomActions.json"),
          //new()
          //{
          //  // Kingmaker.Armies.TacticalCombat.Components
          //  typeof(BlockTacticalCell),
          //  typeof(TacticalCombatRecoverLeaderMana),

          //  // Kingmaker.Armies.TacticalCombat.GameActions
          //  typeof(ArmyAdditionalAction),
          //  typeof(ContextActionAddCrusadeResource),
          //  typeof(ContextActionArmyRemoveFacts),
          //  typeof(ContextActionRestoreLeaderAction),
          //  typeof(ContextActionStopUnit),

          //  // Kingmaker.Crusade.GlobalMagic.Actions
          //  typeof(AddBuffToSquad),
          //  typeof(ChangeArmyMorale),
          //  typeof(FakeSkipTime),
          //  typeof(GainGlobalMagicSpell),
          //  typeof(ManuallySetGlobalSpellCooldown),
          //  typeof(OpenTeleportationInterface),
          //  typeof(RemoveGlobalMagicSpell),
          //  typeof(RepairLeaderMana),
          //  typeof(TeleportArmyAction),

          //  // Kingmaker.Crusade.GlobalMagic.Actions.DamageLogic
          //  typeof(GainDiceArmyDamage),
          //  typeof(RemoveUnitsByExp),

          //  // Kingmaker.Crusade.GlobalMagic.Actions.SummonLogics
          //  typeof(SummonExistUnits),
          //  typeof(SummonRandomGroup),

          //  // Kingmaker.Designers.EventConditionActionSystem.Actions
          //  typeof(CreateArmy),
          //  typeof(CreateGarrison),
          //  typeof(CreateArmyFromLosses),
          //  typeof(EnterKingdomInterface),
          //  typeof(RecruiteArmyLeader),
          //  typeof(RemoveDemonArmies),
          //  typeof(RemoveGarrison),
          //  typeof(RemoveUnitFromArmy),
          //  typeof(SetWarCampLocation),

          //  // Kingmaker.Kingdom.Actions
          //  typeof(AddMorale),
          //  typeof(KingdomActionActivateEventDeck),
          //  typeof(KingdomActionAddBPRandom),
          //  typeof(KingdomActionAddBuff),
          //  typeof(KingdomActionAddFreeBuilding),
          //  typeof(KingdomActionAddMercenaryReroll),
          //  typeof(KingdomActionAddRandomBuff),
          //  typeof(KingdomActionArtisanRequestHelp),
          //  typeof(KingdomActionChangeToAutoCrusade),
          //  typeof(KingdomActionCollectLoot),
          //  typeof(KingdomActionConquerRegion),
          //  typeof(KingdomActionDestroyAllSettlements),
          //  typeof(KingdomActionDisable),
          //  typeof(KingdomActionEnable),
          //  typeof(KingdomActionFillSettlement),
          //  typeof(KingdomActionFillSettlementByLocation),
          //  typeof(KingdomActionFinishRandomBuilding),
          //  typeof(KingdomActionFoundKingdom),
          //  typeof(KingdomActionFoundSettlement),
          //  typeof(KingdomActionGainLeaderExperience),
          //  typeof(KingdomIncreaseIncome),
          //  typeof(KingdomActionGetArtisanGift),
          //  typeof(KingdomActionGetArtisanGiftWithCertainTier),
          //  typeof(KingdomActionGetPartyGoldByUnitsCount),
          //  typeof(KingdomActionGetResourcesByUnitsCount),
          //  typeof(KingdomActionGetResourcesPercent),
          //  typeof(KingdomActionGiveLoot),
          //  typeof(KingdomActionImproveSettlement),
          //  typeof(KingdomActionImproveStat),
          //  typeof(KingdomActionMakeRoll),
          //  typeof(KingdomActionModifyBuildTime),
          //  typeof(KingdomActionModifyClaims),
          //  typeof(KingdomActionModifyEventDC),
          //  typeof(KingdomActionModifyRE),
          //  typeof(KingdomActionModifyRankTime),
          //  typeof(KingdomActionModifyStatRandom),
          //  typeof(KingdomActionModifyStats),
          //  typeof(KingdomActionModifyUnrest),
          //  typeof(KingdomActionNextChapter),
          //  typeof(KingdomActionPullRankupChangesIntoDialog),
          //  typeof(KingdomActionRemoveAllLeaders),
          //  typeof(KingdomActionRemoveBuff),
          //  typeof(KingdomActionRemoveEvent),
          //  typeof(KingdomActionRemoveEventDeck),
          //  typeof(KingdomActionRequestArtisanGift),
          //  typeof(KingdomActionResetRecurrence),
          //  typeof(KingdomActionResolveCrusadeEvent),
          //  typeof(KingdomActionResolveEvent),
          //  typeof(KingdomActionResolveProject),
          //  typeof(KingdomActionRestartEvent),
          //  typeof(KingdomActionRollbackRecurrence),
          //  typeof(KingdomActionSetAlignment),
          //  typeof(KingdomActionSetNotVisible),
          //  typeof(KingdomActionSetRegionalIncome),
          //  typeof(KingdomActionSetVisible),
          //  typeof(KingdomActionSpawnRandomArmy),
          //  typeof(KingdomActionStartEvent),
          //  typeof(KingdomActionUnlockArtisan),

          //  // Kingmaker.Kingdom.Armies.Actions
          //  typeof(AddGrowthBonus),
          //  typeof(AddMercenaryToPool),
          //  typeof(AddTacticalArmyFeature),
          //  typeof(ChangeMercenaryWeight),
          //  typeof(DecreaseRecruitsGrowth),
          //  typeof(DecreaseRecruitsPool),
          //  typeof(ExchangeRecruits),
          //  typeof(IncreaseRecruitsGrowth),
          //  typeof(IncreaseRecruitsPool),
          //  typeof(RemoveMercenaryFromPool),
          //  typeof(ReplaceBuildings),
          //  typeof(SetRecruitPoint),
          //  typeof(UnlockUnitsGrowth),

          //  // Kingmaker.Kingdom.Blueprints
          //  typeof(AddCrusadeResources),
          //  typeof(RemoveCrusadeResources),

          //  // Kingmaker.Kingdom.Flags
          //  typeof(ChangeKingdomMoraleMaximum),
          //  typeof(KingdomAddMoraleFlags),
          //  typeof(KingdomFlagIncrement),
          //  typeof(KingdomMoraleFlagUpdateIncome),
          //  typeof(KingdomRemoveMoraleFlags),
          //  typeof(KingdomSetFlagState),
          //  typeof(ReduceNegativeMorale),

          //  // Kingmaker.UnitLogic.Mechanics.Actions
          //  typeof(ChangeTacticalMorale),
          //  typeof(ContextActionSquadUnitsKill),
          //  typeof(ContextActionSummonTacticalSquad),
          //  typeof(ContextActionTacticalCombatDealDamage),
          //  typeof(ContextActionTacticalCombatHealTarget)
          //}),

        //new ActionExtension(
        //  ExtensionType.MiscEx,
        //  "Extension to <see cref=\"ActionsBuilder\"/> for actions without a better extension container such as"
        //      + " achievements vendor actions, and CustomEvent.",
        //  "MiscActions.json"),
          //new()
          //{
          //  // Kingmaker.Achievements.Actions
          //  typeof(ActionAchievementIncrementCounter),
          //  typeof(ActionAchievementUnlock),

          //  // Kingmaker.Designers.EventConditionActionSystem.Actions
          //  typeof(CreateCustomCompanion),
          //  typeof(CustomEvent),
          //  typeof(AddPremiumReward),
          //  typeof(DebugLog),
          //  typeof(GameOver),
          //  typeof(MakeAutoSave),
          //  typeof(MakeItemNonRemovable),
          //  typeof(MovePartyItemsAction),
          //  typeof(OpenSelectMythicUI),
          //  typeof(RemoveItemFromPlayer),
          //  typeof(RemoveItemsFromCollection),
          //  typeof(RemoveDuplicateItems),
          //  typeof(RestoreItemsCountInCollection),
          //  typeof(SellCollectibleItems),
          //  typeof(SetStartDate),
          //  typeof(SetVendorPriceModifier),
          //  typeof(ShowPartySelection),
          //  typeof(StartTrade),
          //  typeof(UnequipAllItems),
          //  typeof(UnequipItem),

          //  // Kingmaker.Tutorial.Actions
          //  typeof(ShowNewTutorial),

          //  // Kingmaker.UnitLogic.FactLogic
          //  typeof(AddVendorItemsAction),
          //  typeof(ClearVendorTable)
          //}),

        //new ActionExtension(
        //  ExtensionType.NewEx,
        //  "Extension to <see cref=\"ActionsBuilder\"/> for actions defined in BlueprintCore and not available in the"
        //      + " base game.",
        //  "NewActions.json"),
        // // new()),

        //new ActionExtension(
        //  ExtensionType.StoryEx,
        //  "Extension to <see cref=\"ActionsBuilder\"/> for actions related to the story such as companion stories,"
        //      + " quests, name changes, and etudes.",
        //  "StoryActions.json"),
          //new()
          //{
          //  // Kingmaker.Designers.EventConditionActionSystem.Actions
          //  typeof(AlignmentSelector),
          //  typeof(CompleteEtude),
          //  typeof(ChangeRomance),
          //  typeof(ChangeUnitName),
          //  typeof(DismissAllCompanions),
          //  typeof(GiveObjective),
          //  typeof(HideUnit),
          //  typeof(HideWeapons),
          //  typeof(IncrementFlagValue),
          //  typeof(InterruptAllActions),
          //  typeof(LockAlignment),
          //  typeof(LockFlag),
          //  typeof(LockRomance),
          //  typeof(MarkAnswersSelected),
          //  typeof(MarkCuesSeen),
          //  typeof(MoveAzataIslandToLocation),
          //  typeof(MoveAzataIslandToNearestCrossroad),
          //  typeof(OverrideUnitReturnPosition),
          //  typeof(PartyMembersAttach),
          //  typeof(PartyMembersDetach),
          //  typeof(PartyMembersDetachEvaluated),
          //  typeof(PartyMembersSwapAttachedAndDetached),
          //  typeof(Recruit),
          //  typeof(RecruitInactive),
          //  typeof(RelockInteraction),
          //  typeof(RemoveMythicLevels),
          //  typeof(ReplaceAllMythicLevelsWithMythicHeroLevels),
          //  typeof(ReplaceFeatureInProgression),
          //  typeof(ResetQuest),
          //  typeof(ResetQuestObjective),
          //  typeof(RespecCompanion),
          //  typeof(RomanceSetMaximum),
          //  typeof(RomanceSetMinimum),
          //  typeof(SetDialogPosition),
          //  typeof(SetMythicLevelForMainCharacter),
          //  typeof(SetObjectiveStatus),
          //  typeof(SetPortrait),
          //  typeof(ShiftAlignment),
          //  typeof(ShowDialogBox),
          //  typeof(ShowMessageBox),
          //  typeof(ShowUIWarning),
          //  typeof(SplitUnitGroup),
          //  typeof(StartCombat),
          //  typeof(StartDialog),
          //  typeof(StartEncounter),
          //  typeof(StartEtude),
          //  typeof(SwitchAzataIsland),
          //  typeof(SwitchChapter),
          //  typeof(SwitchDoor),
          //  typeof(SwitchFaction),
          //  typeof(SwitchInteraction),
          //  typeof(SwitchRoaming),
          //  typeof(SwitchToEnemy),
          //  typeof(SwitchToNeutral),
          //  typeof(TimeSkip),
          //  typeof(UnitLookAt),
          //  typeof(UnlinkDualCompanions),
          //  typeof(UnlockCompanionStory),
          //  typeof(UnlockFlag),
          //  typeof(UnmarkAnswersSelected),
          //  typeof(Unrecruit),
          //  typeof(UpdateEtudeProgressBar),
          //  typeof(UpdateEtudes)
          //}),

        //new ActionExtension(
        //  ExtensionType.UpgraderEx,
        //  "Extension to <see cref=\"ActionsBuilder\"/> for all UpgraderOnlyActions.",
        //  "UpgraderActions.json"),
          //new()
          //{
          //  // Kingmaker.EntitySystem.Persistence.Versioning.PlayerUpgraderOnlyActions
          //  typeof(AddFactIfEtudePlaying),
          //  typeof(FixKingdomSystemBuffsAndStats),
          //  typeof(ReenterScriptzone),
          //  typeof(Kingmaker.EntitySystem.Persistence.Versioning.PlayerUpgraderOnlyActions.RemoveFact),
          //  typeof(RefreshCrusadeLogistic),
          //  typeof(RefreshSettingsPreset),
          //  typeof(RemoveSpell),
          //  typeof(ResetMinDifficulty),
          //  typeof(RestoreClassFeature),

          //  // Kingmaker.EntitySystem.Persistence.Versioning.UnitUpgraderOnlyActions
          //  typeof(FixItemInInventory),
          //  typeof(RecreateOnLoad),
          //  typeof(SetAlignmentFromBlueprint),
          //  typeof(SetHandsFromBlueprint),
          //  typeof(SetRaceFromBlueprint),

          //  // Kingmaker.EntitySystem.Persistence.Versioning.UpgraderOnlyActions
          //  typeof(AddFeatureFromProgression),
          //  typeof(RecheckEtude),
          //  typeof(RefreshAllArmyLeaders),
          //  typeof(RemoveFeatureFromProgression),
          //  typeof(ReplaceFeature),
          //  typeof(SetSharedVendorTable),
          //  typeof(StartEtudeForced),
          //  typeof(UnStartEtude),
          //  typeof(RestartTacticalCombat),
          //}),
      };

    // Used in class names and namespaces directly
    private enum ExtensionType
    {
      AreaEx,
      AVEx,
      BasicEx,
      ContextEx,
      KingdomEx,
      MiscEx,
      NewEx,
      StoryEx,
      UpgraderEx,
    }

    private abstract class BuilderExtensionImpl : IBuilderExtension
    {
      public string FilePath { get; }

      public string Namespace { get; }

      public string ClassName { get; }

      public string Summary { get; }

      public string ParentType { get; }

      private readonly string OverrideFile;
      private List<BuilderMethod>? m_BuilderMethods;
      public List<BuilderMethod> Methods
      {
        get
        {
          if (m_BuilderMethods == null)
          {
            JArray array = JArray.Parse(File.ReadAllText($"CodeGen/Overrides/{OverrideFile}"));
            m_BuilderMethods = array.ToObject<List<BuilderMethod>>();
          }
          return m_BuilderMethods!;
        }
      }

      protected BuilderExtensionImpl(
          BuilderType builderType, ExtensionType extensionType, string summary, string overrideFile)
      {
        Summary = summary;
        OverrideFile = overrideFile;

        if (builderType == BuilderType.Action)
        {
          ClassName = $"ActionsBuilder{extensionType}";
          FilePath = $"Actions\\Builder\\{extensionType}\\{ClassName}.cs";
          Namespace = $"BlueprintCore.Actions.Builder.{extensionType}";
          ParentType = "ActionsBuilder";
        }
        else
        {
          ClassName = $"ConditionsBuilder{extensionType}";
          FilePath = $"Conditions\\Builder\\{extensionType}\\{ClassName}.cs";
          Namespace = $"BlueprintCore.Conditions.Builder.{extensionType}";
          ParentType = "ConditionsBuilder";
        }
      }
    }

    private class ActionExtension : BuilderExtensionImpl
    {
      public ActionExtension(ExtensionType type, string summary, string overrideFile)
        : base(BuilderType.Action, type, summary, overrideFile)
      { }
    }

    private class ConditionExtension : BuilderExtensionImpl
    {
      public ConditionExtension(ExtensionType type, string summary, string overrideFile)
        : base(BuilderType.Condition, type, summary, overrideFile)
      { }
    }
  }
}
