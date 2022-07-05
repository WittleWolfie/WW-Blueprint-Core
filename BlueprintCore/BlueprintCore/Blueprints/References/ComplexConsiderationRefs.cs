using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.AI.Blueprints.Considerations;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to ComplexConsideration blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class ComplexConsiderationRefs
  {
    public static readonly Blueprint<BlueprintReference<ComplexConsideration>> AttackTargetsPriority = "7a2b25dcc09cd244db261ce0a70cca84";
    public static readonly Blueprint<BlueprintReference<ComplexConsideration>> Cultist_FireRasing_Consideration = "53d9b8e1faaf533498f20c47ecdd4d40";
    public static readonly Blueprint<BlueprintReference<ComplexConsideration>> CultistSelfSacrificePriority = "d1470daab96eb964fa58cfa43f6f4a2d";
    public static readonly Blueprint<BlueprintReference<ComplexConsideration>> HelpTargetsPriority = "36010f75540818a48879f220efd2fa6f";
    public static readonly Blueprint<BlueprintReference<ComplexConsideration>> SwarmTargetsPriority = "d82db5159ede4127a69c9b6330b0b86e";
    public static readonly Blueprint<BlueprintReference<ComplexConsideration>> SwiftAction = "f335c9d35bc608648af2ca45ef2e096c";

    public static readonly List<Blueprint<BlueprintReference<ComplexConsideration>>> All =
      new()
      {
          AttackTargetsPriority,
          Cultist_FireRasing_Consideration,
          CultistSelfSacrificePriority,
          HelpTargetsPriority,
          SwarmTargetsPriority,
          SwiftAction,
      };
  }
}
