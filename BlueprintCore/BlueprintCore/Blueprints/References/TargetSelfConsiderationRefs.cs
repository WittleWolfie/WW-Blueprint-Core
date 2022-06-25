using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.AI.Blueprints.Considerations;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to TargetSelfConsideration blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class TargetSelfConsiderationRefs
  {
    public static readonly Blueprint<BlueprintReference<TargetSelfConsideration>> TargetOther = "f4be6fc6f46b61044a44715f99f1918d";
    public static readonly Blueprint<BlueprintReference<TargetSelfConsideration>> TargetSelf = "83e2dd97b82d769498394c3edf0d260e";
    public static readonly Blueprint<BlueprintReference<TargetSelfConsideration>> Wintersun_SpectreDruid_NotSelfConsideration = "250a50e06ed7fab4dbd3f93e51fb122d";
    public static readonly Blueprint<BlueprintReference<TargetSelfConsideration>> Xantir_NotSelfConsideration = "ecf7ab4d44a08834daf76b47b10a7ac0";

    public static readonly List<Blueprint<BlueprintReference<TargetSelfConsideration>>> All =
      new()
      {
          TargetOther,
          TargetSelf,
          Wintersun_SpectreDruid_NotSelfConsideration,
          Xantir_NotSelfConsideration,
      };
  }
}
