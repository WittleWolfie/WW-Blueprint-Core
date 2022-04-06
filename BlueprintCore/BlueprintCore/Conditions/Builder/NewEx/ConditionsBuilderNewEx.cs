//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Conditions.New;
using BlueprintCore.Utils;

namespace BlueprintCore.Conditions.Builder.NewEx
{
  /// <summary>
  /// Extension to <see cref="ConditionsBuilder"/> for conditions defined in BlueprintCore and not available in the base game.
  /// </summary>
  /// <inheritdoc cref="ConditionsBuilder"/>
  public static class ConditionsBuilderNewEx
  {

    /// <summary>
    /// Adds <see cref="TargetInMeleeRange"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder TargetInMeleeRange(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<TargetInMeleeRange>();
      element.Not = negate;
      return builder.Add(element);
    }
  }
}
