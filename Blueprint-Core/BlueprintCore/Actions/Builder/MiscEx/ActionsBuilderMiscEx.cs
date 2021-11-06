using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker;
using Kingmaker.Achievements.Actions;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.Tutorial;
using Kingmaker.Tutorial.Actions;
using Kingmaker.UnitLogic.FactLogic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Actions.Builder.MiscEx
{
  /// <summary>
  /// Extension to <see cref="ActionsBuilder"/> for actions without a better extension container such as achievements
  /// vendor actions, and CustomEvent.
  /// </summary>
  /// <inheritdoc cref="ActionsBuilder"/>
  public static class ActionsBuilderMiscEx
  {
    //----- Kingmaker.Achievements.Actions -----//

    /// <summary>
    /// Adds <see cref="ActionAchievementIncrementCounter"/>
    /// </summary>
    /// 
    /// <param name="achievement"><see cref="Kingmaker.Achievements.Blueprints.AchievementData">AchievementData</see></param>
    [Implements(typeof(ActionAchievementIncrementCounter))]
    public static ActionsBuilder IncrementAchievement(this ActionsBuilder builder, string achievement)
    {
      var increment = ElementTool.Create<ActionAchievementIncrementCounter>();
      increment.m_Achievement = BlueprintTool.GetRef<AchievementDataReference>(achievement);
      return builder.Add(increment);
    }

    /// <summary>
    /// Adds <see cref="ActionAchievementUnlock"/>
    /// </summary>
    /// 
    /// <param name="achievement"><see cref="Kingmaker.Achievements.Blueprints.AchievementData">AchievementData</see></param>
    [Implements(typeof(ActionAchievementUnlock))]
    public static ActionsBuilder UnlockAchievement(this ActionsBuilder builder, string achievement)
    {
      var unlock = ElementTool.Create<ActionAchievementUnlock>();
      unlock.m_Achievement = BlueprintTool.GetRef<AchievementDataReference>(achievement);
      return builder.Add(unlock);
    }

    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.CreateCustomCompanion">CreateCustomCompanion</see>
    /// </summary>
    [Implements(typeof(CreateCustomCompanion))]
    public static ActionsBuilder CreateCustomCompanion(
        this ActionsBuilder builder,
        bool free = false,
        bool matchPlayerXp = false,
        ActionsBuilder onCreate = null)
    {
      var createCompanion = ElementTool.Create<CreateCustomCompanion>();
      createCompanion.ForFree = free;
      createCompanion.MatchPlayerXpExactly = matchPlayerXp;
      createCompanion.OnCreate = onCreate?.Build() ?? Constants.Empty.Actions;
      return builder.Add(createCompanion);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.CustomEvent">CustomEvent</see>
    /// </summary>
    [Implements(typeof(CustomEvent))]
    public static ActionsBuilder CustomEvent(this ActionsBuilder builder, string eventId)
    {
      var customEvent = ElementTool.Create<CustomEvent>();
      customEvent.EventId = eventId;
      return builder.Add(customEvent);
    }

    //----- Auto Generated -----//



    /// <summary>
    /// Adds <see cref="ShowNewTutorial"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Tutorial"><see cref="BlueprintTutorial"/></param>
    [Generated]
    [Implements(typeof(ShowNewTutorial))]
    public static ActionsBuilder AddShowNewTutorial(
        this ActionsBuilder builder,
        string m_Tutorial,
        TutorialContextDataEvaluator[] Evaluators)
    {
      foreach (var item in Evaluators)
      {
        builder.Validate(item);
      }
      
      var element = ElementTool.Create<ShowNewTutorial>();
      element.m_Tutorial = BlueprintTool.GetRef<BlueprintTutorial.Reference>(m_Tutorial);
      element.Evaluators = Evaluators;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddVendorItemsAction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_VendorTable"><see cref="BlueprintUnitLoot"/></param>
    [Generated]
    [Implements(typeof(AddVendorItemsAction))]
    public static ActionsBuilder AddAddVendorItemsAction(
        this ActionsBuilder builder,
        VendorEvaluator m_VendorEvaluator,
        string m_VendorTable)
    {
      builder.Validate(m_VendorEvaluator);
      
      var element = ElementTool.Create<AddVendorItemsAction>();
      element.m_VendorEvaluator = m_VendorEvaluator;
      element.m_VendorTable = BlueprintTool.GetRef<BlueprintUnitLootReference>(m_VendorTable);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ClearVendorTable"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Table"><see cref="BlueprintSharedVendorTable"/></param>
    [Generated]
    [Implements(typeof(ClearVendorTable))]
    public static ActionsBuilder AddClearVendorTable(
        this ActionsBuilder builder,
        string m_Table)
    {
      
      var element = ElementTool.Create<ClearVendorTable>();
      element.m_Table = BlueprintTool.GetRef<BlueprintSharedVendorTableReference>(m_Table);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddPremiumReward"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_DlcReward"><see cref="BlueprintDlcReward"/></param>
    /// <param name="Items"><see cref="BlueprintItem"/></param>
    /// <param name="PlayerFeatures"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddPremiumReward))]
    public static ActionsBuilder AddAddPremiumReward(
        this ActionsBuilder builder,
        string m_DlcReward,
        string[] Items,
        string[] PlayerFeatures,
        ActionsBuilder AdditionalActions)
    {
      
      var element = ElementTool.Create<AddPremiumReward>();
      element.m_DlcReward = BlueprintTool.GetRef<BlueprintDlcRewardReference>(m_DlcReward);
      element.Items = Items.Select(bp => BlueprintTool.GetRef<BlueprintItemReference>(bp)).ToList();
      element.PlayerFeatures = PlayerFeatures.Select(bp => BlueprintTool.GetRef<BlueprintFeatureReference>(bp)).ToList();
      element.AdditionalActions = AdditionalActions.Build();
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DebugLog"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DebugLog))]
    public static ActionsBuilder AddDebugLog(
        this ActionsBuilder builder,
        String Log,
        Boolean Break)
    {
      foreach (var item in Log)
      {
        builder.Validate(item);
      }
      builder.Validate(Break);
      
      var element = ElementTool.Create<DebugLog>();
      element.Log = Log;
      element.Break = Break;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="GameOver"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GameOver))]
    public static ActionsBuilder AddGameOver(
        this ActionsBuilder builder,
        Player.GameOverReasonType Reason)
    {
      builder.Validate(Reason);
      
      var element = ElementTool.Create<GameOver>();
      element.Reason = Reason;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MakeAutoSave"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MakeAutoSave))]
    public static ActionsBuilder AddMakeAutoSave(
        this ActionsBuilder builder,
        Boolean SaveForImport)
    {
      builder.Validate(SaveForImport);
      
      var element = ElementTool.Create<MakeAutoSave>();
      element.SaveForImport = SaveForImport;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="OpenSelectMythicUI"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(OpenSelectMythicUI))]
    public static ActionsBuilder AddOpenSelectMythicUI(
        this ActionsBuilder builder,
        ActionsBuilder m_AfterCommitActions,
        Boolean m_LockStopChargen,
        ActionsBuilder m_AfterStopActions)
    {
      builder.Validate(m_LockStopChargen);
      
      var element = ElementTool.Create<OpenSelectMythicUI>();
      element.m_AfterCommitActions = m_AfterCommitActions.Build();
      element.m_LockStopChargen = m_LockStopChargen;
      element.m_AfterStopActions = m_AfterStopActions.Build();
      return builder.Add(element);
    }
  }
}
