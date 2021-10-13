using BlueprintCore.Conditions.New;
using BlueprintCore.Utils;

namespace BlueprintCore.Conditions.Builder.NewEx
{
  /** Extension to ConditionsCheckerBuilder which supports new condition types. */
  public static class ConditionsCheckerBuilderNewEx
  {
    /** IsDemoralizeAction */
    public static ConditionsCheckerBuilder IsDemoralizeAction(this ConditionsCheckerBuilder builder)
    {
      return builder.Add(ElementTool.Create<IsDemoralizeAction>());
    }

    /** TargetInMeleeRange */
    public static ConditionsCheckerBuilder TargetInMeleeRange(this ConditionsCheckerBuilder builder)
    {
      return builder.Add(ElementTool.Create<TargetInMeleeRange>());
    }
  }
}