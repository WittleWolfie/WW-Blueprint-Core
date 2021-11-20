using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>
  /// Configurator for <see cref="SwarmTargetsConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(SwarmTargetsConsideration))]
  public class SwarmTargetsConsiderationConfigurator : BaseConsiderationConfigurator<SwarmTargetsConsideration, SwarmTargetsConsiderationConfigurator>
  {
    private SwarmTargetsConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SwarmTargetsConsiderationConfigurator For(string name)
    {
      return new SwarmTargetsConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static SwarmTargetsConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<SwarmTargetsConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SwarmTargetsConsiderationConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<SwarmTargetsConsideration>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="SwarmTargetsConsideration.HasEnemiesScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SwarmTargetsConsiderationConfigurator SetHasEnemiesScore(float hasEnemiesScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HasEnemiesScore = hasEnemiesScore;
          });
    }

    /// <summary>
    /// Sets <see cref="SwarmTargetsConsideration.NoEnemiesScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SwarmTargetsConsiderationConfigurator SetNoEnemiesScore(float noEnemiesScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.NoEnemiesScore = noEnemiesScore;
          });
    }
  }
}
