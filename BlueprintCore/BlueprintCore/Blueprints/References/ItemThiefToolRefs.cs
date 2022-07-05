using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintItemThiefTool blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class ItemThiefToolRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintItemThiefTool>> ConsumableLockpickPlus10 = "21d9f25b1f085e747b45621f28908e90";
    public static readonly Blueprint<BlueprintReference<BlueprintItemThiefTool>> ConsumableLockpickPlus5 = "39e4982215f14d44d93a864320df62bd";

    public static readonly List<Blueprint<BlueprintReference<BlueprintItemThiefTool>>> All =
      new()
      {
          ConsumableLockpickPlus10,
          ConsumableLockpickPlus5,
      };
  }
}
