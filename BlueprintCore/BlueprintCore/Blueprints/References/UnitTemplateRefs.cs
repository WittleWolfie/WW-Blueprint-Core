using BlueprintCore.Utils;
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
    public static readonly Blueprint<BlueprintReference<BlueprintUnitTemplate>> DungeonTemplateAdvanced_X1 = "4e6302f39f714b309027924a725d76cd";
    public static readonly Blueprint<BlueprintReference<BlueprintUnitTemplate>> DungeonTemplateAdvanced_X2 = "e0065cfffef145749588a85fc71a1912";
    public static readonly Blueprint<BlueprintReference<BlueprintUnitTemplate>> DungeonTemplateAdvanced_X3 = "0d74d65b992741108d0363623f36de1d";
    public static readonly Blueprint<BlueprintReference<BlueprintUnitTemplate>> DungeonTemplateAdvanced_X4 = "b37744503a5647e6a816090f308960f6";
    public static readonly Blueprint<BlueprintReference<BlueprintUnitTemplate>> DungeonTemplateAdvanced_X5 = "957260c91c05435eae82a54ba17e6053";
    public static readonly Blueprint<BlueprintReference<BlueprintUnitTemplate>> DungeonTemplateEnlarge = "0900aef6c17a469d86d3447fb012c7bb";
    public static readonly Blueprint<BlueprintReference<BlueprintUnitTemplate>> DungeonTemplateLegendaryProportions = "24bf85d41ff24d29aab2300a3a28969e";
    public static readonly Blueprint<BlueprintReference<BlueprintUnitTemplate>> Template_healer = "21294f60731f81f479d83b46e7a7df57";

    public static readonly List<Blueprint<BlueprintReference<BlueprintUnitTemplate>>> All =
      new()
      {
          Branded,
          DungeonTemplateAdvanced_X1,
          DungeonTemplateAdvanced_X2,
          DungeonTemplateAdvanced_X3,
          DungeonTemplateAdvanced_X4,
          DungeonTemplateAdvanced_X5,
          DungeonTemplateEnlarge,
          DungeonTemplateLegendaryProportions,
          Template_healer,
      };
  }
}
