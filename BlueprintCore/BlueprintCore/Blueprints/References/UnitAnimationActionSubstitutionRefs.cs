using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to UnitAnimationActionSubstitution blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class UnitAnimationActionSubstitutionRefs
  {
    public static readonly Blueprint<BlueprintReference<UnitAnimationActionSubstitution>> CentipedeLocomotion = "e14f88dabb1c479389a35eb9f349c8a1";
    public static readonly Blueprint<BlueprintReference<UnitAnimationActionSubstitution>> DragonsLocomotion = "1702746f82b04db1a4c7cf334b664476";
    public static readonly Blueprint<BlueprintReference<UnitAnimationActionSubstitution>> HumanLocomotion = "cbde3045a9ab46319c8bf9e987bba304";
    public static readonly Blueprint<BlueprintReference<UnitAnimationActionSubstitution>> HumanMicroidle = "049ebeec8d8e4e9db8801fe2db304b11";
    public static readonly Blueprint<BlueprintReference<UnitAnimationActionSubstitution>> MonitorLizardLocomotion = "a3d8ec9931ff4a7f963c8fc14dbb6cd7";

    public static readonly List<Blueprint<BlueprintReference<UnitAnimationActionSubstitution>>> All =
      new()
      {
          CentipedeLocomotion,
          DragonsLocomotion,
          HumanLocomotion,
          HumanMicroidle,
          MonitorLizardLocomotion,
      };
  }
}
