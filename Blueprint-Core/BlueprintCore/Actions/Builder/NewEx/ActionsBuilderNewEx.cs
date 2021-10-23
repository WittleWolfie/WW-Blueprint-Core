using BlueprintCore.Actions.New;
using BlueprintCore.Utils;

namespace BlueprintCore.Actions.Builder.NewEx
{
  /// <summary>
  /// Extension to <see cref="ActionsBuilder"/> for actions defined in BlueprintCore and not available in the base
  /// game.
  /// </summary>
  /// <inheritdoc cref="ActionsBuilder"/>
  public static class ActionsBuilderNewEx
  {
    /// <summary>
    /// Adds <see cref="SwitchToDemoralizeTarget"/>
    /// </summary>
    public static ActionsBuilder SwitchToDemoralizeTarget(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<SwitchToDemoralizeTarget>());
    }
  }
}