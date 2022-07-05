using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.AI.Blueprints.Considerations;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to HealthAroundConsideration blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class HealthAroundConsiderationRefs
  {
    public static readonly Blueprint<BlueprintReference<HealthAroundConsideration>> BanditInjuryAround = "35197d884b2e0c041a615bfe28dcbbc7";
    public static readonly Blueprint<BlueprintReference<HealthAroundConsideration>> Gallu_Consideration_RainOfBlood = "1dc4edbf3acebdf42a58b8f74f19e1e3";
    public static readonly Blueprint<BlueprintReference<HealthAroundConsideration>> InjuryAround = "2a2cfff1d585f3142aadaafe0c1a74e6";
    public static readonly Blueprint<BlueprintReference<HealthAroundConsideration>> InjuryAroundMedium = "8dbc5d7304fd6be4fa34a226aeedfef8";

    public static readonly List<Blueprint<BlueprintReference<HealthAroundConsideration>>> All =
      new()
      {
          BanditInjuryAround,
          Gallu_Consideration_RainOfBlood,
          InjuryAround,
          InjuryAroundMedium,
      };
  }
}
