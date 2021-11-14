using BlueprintCore.Blueprints.Configurators.AI.Considerations;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="DistanceRangeConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(DistanceRangeConsideration))]
  public class DistanceRangeConsiderationConfigurator : BaseConsiderationConfigurator<DistanceRangeConsideration, DistanceRangeConsiderationConfigurator>
  {
     private DistanceRangeConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static DistanceRangeConsiderationConfigurator For(string name)
    {
      return new DistanceRangeConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static DistanceRangeConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<DistanceRangeConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static DistanceRangeConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<DistanceRangeConsideration>(name, assetId);
      return For(name);
    }
  }
}
