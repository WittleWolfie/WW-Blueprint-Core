using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Weapons;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintCategoryDefaults blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class CategoryDefaultsRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintCategoryDefaults>> DefaultsForWeaponCategories = "567dc59213fd9664c8cb291643439714";
    public static readonly Blueprint<BlueprintReference<BlueprintCategoryDefaults>> WeaponFocusColdIronStarting = "3da85a61d30d4bc483671f58b05bfd90";

    public static readonly List<Blueprint<BlueprintReference<BlueprintCategoryDefaults>>> All =
      new()
      {
          DefaultsForWeaponCategories,
          WeaponFocusColdIronStarting,
      };
  }
}
