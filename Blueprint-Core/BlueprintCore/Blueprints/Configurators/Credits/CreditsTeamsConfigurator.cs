using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Credits;

namespace BlueprintCore.Blueprints.Configurators.Credits
{
  /// <summary>Configurator for <see cref="BlueprintCreditsTeams"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCreditsTeams))]
  public class CreditsTeamsConfigurator : BaseBlueprintConfigurator<BlueprintCreditsTeams, CreditsTeamsConfigurator>
  {
     private CreditsTeamsConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CreditsTeamsConfigurator For(string name)
    {
      return new CreditsTeamsConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CreditsTeamsConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintCreditsTeams>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CreditsTeamsConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintCreditsTeams>(name, assetId);
      return For(name);
    }
  }
}
