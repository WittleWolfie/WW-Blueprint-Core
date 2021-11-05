using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Achievements.Actions;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Actions;

namespace BlueprintCoreGen.Actions.Builder.MiscEx
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

    // [Generate(Kingmaker.Tutorial.Actions.ShowNewTutorial)]

    // [Generate(Kingmaker.UnitLogic.FactLogic.AddVendorItemsAction)]

    // [Generate(Kingmaker.UnitLogic.FactLogic.ClearVendorTable)]
  }
}