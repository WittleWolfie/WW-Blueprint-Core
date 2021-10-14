using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Achievements.Actions;
using Kingmaker.Achievements.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Actions;

namespace BlueprintCore.Actions.Builder.MiscEx
{
  /**
   * Extension to ActionListBuilder for miscellaneous actions. Includes things like achievements and
   * CustomEvent.
   */
  public static class ActionListBuilderMetaEx
  {
    //----- Kingmaker.Achievements.Actions -----//

    /**
     * ActionAchievementIncrementCounter
     *
     * @param achievement AchievementData
     */
    public static ActionListBuilder IncrementAchievement(
        this ActionListBuilder builder, string achievement)
    {
      var increment = ElementTool.Create<ActionAchievementIncrementCounter>();
      increment.m_Achievement = BlueprintTool.GetRef<AchievementDataReference>(achievement);
      return builder.Add(increment);
    }

    /**
     * ActionAchievementUnlock
     *
     * @param achievement AchievementData
     */
    public static ActionListBuilder UnlockAchievement(
        this ActionListBuilder builder, string achievement)
    {
      var unlock = ElementTool.Create<ActionAchievementUnlock>();
      unlock.m_Achievement = BlueprintTool.GetRef<AchievementDataReference>(achievement);
      return builder.Add(unlock);
    }

    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

    /** CreateCustomCompanion */
    public static ActionListBuilder CreateCustomCompanion(
        this ActionListBuilder builder,
        bool free = false,
        bool matchPlayerXp = false,
        ActionListBuilder onCreate = null)
    {
      var createCompanion = ElementTool.Create<CreateCustomCompanion>();
      createCompanion.ForFree = free;
      createCompanion.MatchPlayerXpExactly = matchPlayerXp;
      createCompanion.OnCreate = onCreate?.Build() ?? Constants.Empty.Actions;
      return builder.Add(createCompanion);
    }

    /** CustomEvent */
    public static ActionListBuilder CustomEvent(this ActionListBuilder builder, string eventId)
    {
      var customEvent = ElementTool.Create<CustomEvent>();
      customEvent.EventId = eventId;
      return builder.Add(customEvent);
    }
  }
}