using BlueprintCore.Utils;
using Kingmaker.BarkBanters;

namespace BlueprintCore.Blueprints.Configurators.BarkBanters
{
  /// <summary>Configurator for <see cref="BlueprintBarkBanter"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintBarkBanter))]
  public class BarkBanterConfigurator : BaseBlueprintConfigurator<BlueprintBarkBanter, BarkBanterConfigurator>
  {
     private BarkBanterConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static BarkBanterConfigurator For(string name)
    {
      return new BarkBanterConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static BarkBanterConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintBarkBanter>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static BarkBanterConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintBarkBanter>(name, assetId);
      return For(name);
    }
  }
}
