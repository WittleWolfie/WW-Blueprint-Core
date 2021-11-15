using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="RandomConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(RandomConsideration))]
  public class RandomConsiderationConfigurator : BaseConsiderationConfigurator<RandomConsideration, RandomConsiderationConfigurator>
  {
     private RandomConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static RandomConsiderationConfigurator For(string name)
    {
      return new RandomConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static RandomConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<RandomConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static RandomConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<RandomConsideration>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="RandomConsideration.MinScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomConsiderationConfigurator SetMinScore(float value)
    {
      return OnConfigureInternal(bp => bp.MinScore = value);
    }

    /// <summary>
    /// Sets <see cref="RandomConsideration.MaxScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomConsiderationConfigurator SetMaxScore(float value)
    {
      return OnConfigureInternal(bp => bp.MaxScore = value);
    }
  }
}
