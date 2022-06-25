using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintRomanceCounter blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class RomanceCounterRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintRomanceCounter>> CamelliaRomanceRomanceCounter = "74882d9746172bb47beba26e6ee86b5b";
    public static readonly Blueprint<BlueprintReference<BlueprintRomanceCounter>> SosielRomanceRomanceCounter = "420fe10d958094b409dec479fa358bce";

    public static readonly List<Blueprint<BlueprintReference<BlueprintRomanceCounter>>> All =
      new()
      {
          CamelliaRomanceRomanceCounter,
          SosielRomanceRomanceCounter,
      };
  }
}
