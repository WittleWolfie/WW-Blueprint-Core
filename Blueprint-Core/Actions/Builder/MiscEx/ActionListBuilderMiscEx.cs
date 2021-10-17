using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Achievements.Actions;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Actions;

namespace BlueprintCore.Actions.Builder.MiscEx
{
  /// <summary>
  /// Extension to <see cref="ActionListBuilder"/> for actions without a better extension container such as achievements
  /// and CustomEvent.
  /// </summary>
  /// <inheritdoc cref="ActionListBuilder"/>
  public static class ActionListBuilderMiscEx
  {
    //----- Kingmaker.Achievements.Actions -----//

    /// <summary>
    /// Adds <see cref="ActionAchievementIncrementCounter"/>
    /// </summary>
    /// 
    /// <param name="achievement"><see cref="Kingmaker.Achievements.Blueprints.AchievementData">AchievementData</see></param>
    public static ActionListBuilder IncrementAchievement(this ActionListBuilder builder, string achievement)
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
    public static ActionListBuilder UnlockAchievement(this ActionListBuilder builder, string achievement)
    {
      var unlock = ElementTool.Create<ActionAchievementUnlock>();
      unlock.m_Achievement = BlueprintTool.GetRef<AchievementDataReference>(achievement);
      return builder.Add(unlock);
    }

    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.CreateCustomCompanion">CreateCustomCompanion</see>
    /// </summary>
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

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.CustomEvent">CustomEvent</see>
    /// </summary>
    public static ActionListBuilder CustomEvent(this ActionListBuilder builder, string eventId)
    {
      var customEvent = ElementTool.Create<CustomEvent>();
      customEvent.EventId = eventId;
      return builder.Add(customEvent);
    }
  }
}