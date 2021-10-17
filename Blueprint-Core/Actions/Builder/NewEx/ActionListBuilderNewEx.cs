using BlueprintCore.Actions.New;
using BlueprintCore.Utils;

namespace BlueprintCore.Actions.Builder.NewEx
{
  /// <summary>
  /// Extension to <see cref="ActionListBuilder"/> for actions defined in BlueprintCore and not available in the base
  /// game.
  /// </summary>
  /// <inheritdoc cref="ActionListBuilder"/>
  public static class ActionListBuilderNewEx
  {
    /// <summary>
    /// Adds <see cref="SwitchToDemoralizeTarget"/>
    /// </summary>
    public static ActionListBuilder SwitchToDemoralizeTarget(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<SwitchToDemoralizeTarget>());
    }
  }
}