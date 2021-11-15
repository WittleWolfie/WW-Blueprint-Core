using BlueprintCore.Utils;
using Kingmaker.Blueprints.Credits;
using System.Linq;

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

    /// <summary>
    /// Modifies <see cref="BlueprintCreditsTeams.Teams"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CreditsTeamsConfigurator AddToTeams(params CreditTeam[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Teams.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCreditsTeams.Teams"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CreditsTeamsConfigurator RemoveFromTeams(params CreditTeam[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Teams = bp.Teams.Where(item => !values.Contains(item)).ToList());
    }
  }
}
