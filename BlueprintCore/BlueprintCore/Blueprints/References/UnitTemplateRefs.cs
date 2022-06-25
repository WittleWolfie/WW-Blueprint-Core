using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintUnitTemplate blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class UnitTemplateRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintUnitTemplate>> Branded = "b3fb486ae387c6b4ab8bc52afa6d4131";
    public static readonly Blueprint<BlueprintReference<BlueprintUnitTemplate>> Template_healer = "21294f60731f81f479d83b46e7a7df57";

    public static readonly List<Blueprint<BlueprintReference<BlueprintUnitTemplate>>> All =
      new()
      {
          Branded,
          Template_healer,
      };
  }
}
