using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root.Fx;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to CastsGroup blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class CastsGroupRefs
  {
    public static readonly Blueprint<BlueprintReference<CastsGroup>> DoubleHandCastGroup = "780a2d5ad49ca2349be6a572b59f9c70";
    public static readonly Blueprint<BlueprintReference<CastsGroup>> HeadCastGroup = "fb7c52e72472e3746a1e9ad6675eeff3";
    public static readonly Blueprint<BlueprintReference<CastsGroup>> SingleHandCastGroup = "cf2e8b48e31deea4ea62868c0e1784cd";
    public static readonly Blueprint<BlueprintReference<CastsGroup>> TorsoCastGroup = "9a6f13652af861540aedf7a3552104b2";

    public static readonly List<Blueprint<BlueprintReference<CastsGroup>>> All =
      new()
      {
          DoubleHandCastGroup,
          HeadCastGroup,
          SingleHandCastGroup,
          TorsoCastGroup,
      };
  }
}
