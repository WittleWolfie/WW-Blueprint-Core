using BlueprintCore.Actions.New;
using BlueprintCore.Utils;

namespace BlueprintCore.Actions.Builder.NewEx
{
  /** Extension to ActionListBuilder which supports new action types. */
  public static class ActionListBuilderNewEx
  {
    /** SwitchToDemoralizeTarget */
    public static ActionListBuilder SwitchToDemoralizeTarget(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<SwitchToDemoralizeTarget>());
    }
  }
}