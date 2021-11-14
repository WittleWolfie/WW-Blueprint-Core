using BlueprintCore.Utils;
using Kingmaker.Blueprints.Credits;

namespace BlueprintCore.Blueprints.Configurators.Credits
{
  /// <summary>Configurator for <see cref="BlueprintCreditsGroup"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCreditsGroup))]
  public class CreditsGroupConfigurator : BaseBlueprintConfigurator<BlueprintCreditsGroup, CreditsGroupConfigurator>
  {
     private CreditsGroupConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CreditsGroupConfigurator For(string name)
    {
      return new CreditsGroupConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CreditsGroupConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintCreditsGroup>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CreditsGroupConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintCreditsGroup>(name, assetId);
      return For(name);
    }
  }
}
