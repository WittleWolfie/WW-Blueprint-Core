using BlueprintCore.Conditions.New;
using BlueprintCore.Utils;

namespace BlueprintCore.Conditions.Builder.NewEx
{
  /// <summary>
  /// Extension to <see cref="ConditionsCheckerBuilder"/> for conditions defined in BlueprintCore and not available in
  /// the base game.
  /// </summary>
  /// <inheritdoc cref="ConditionsCheckerBuilder"/>
  public static class ConditionsCheckerBuilderNewEx
  {
    /// <summary>
    /// Adds <see cref="New.IsDemoralizeAction">IsDemoralizeAction</see>
    /// </summary>
    public static ConditionsCheckerBuilder IsDemoralizeAction(this ConditionsCheckerBuilder builder)
    {
      return builder.Add(ElementTool.Create<IsDemoralizeAction>());
    }
    /// <summary>
    /// Adds <see cref="New.TargetInMeleeRange">TargetInMeleeRange</see>
    /// </summary>
    public static ConditionsCheckerBuilder TargetInMeleeRange(this ConditionsCheckerBuilder builder)
    {
      return builder.Add(ElementTool.Create<TargetInMeleeRange>());
    }
  }
}