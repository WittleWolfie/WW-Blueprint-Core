using BlueprintCore.Blueprints.Configurators.AI.Considerations;
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
  }
}
