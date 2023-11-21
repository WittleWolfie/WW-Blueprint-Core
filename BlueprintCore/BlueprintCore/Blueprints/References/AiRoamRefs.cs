using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.AI.Blueprints;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintAiRoam blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class AiRoamRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintAiRoam>> DLC3_Nahyndri_Walk_HighScore = "625a141edc4c4a8e96d78e51953a606a";
    public static readonly Blueprint<BlueprintReference<BlueprintAiRoam>> DLC3_Nahyndri_Walk_LowScore = "11e5722e40e74cf48e45f216806c7294";
    public static readonly Blueprint<BlueprintReference<BlueprintAiRoam>> DLC5_LivingTornadoMoveAction = "708d97f5bc5b44a6b8e47059d34cb45f";

    public static readonly List<Blueprint<BlueprintReference<BlueprintAiRoam>>> All =
      new()
      {
          DLC3_Nahyndri_Walk_HighScore,
          DLC3_Nahyndri_Walk_LowScore,
          DLC5_LivingTornadoMoveAction,
      };
  }
}
