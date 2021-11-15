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

    /// <summary>
    /// Sets <see cref="DistanceRangeConsideration.MinDistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DistanceRangeConsiderationConfigurator SetMinDistance(float value)
    {
      return OnConfigureInternal(bp => bp.MinDistance = value);
    }

    /// <summary>
    /// Sets <see cref="DistanceRangeConsideration.MaxDistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DistanceRangeConsiderationConfigurator SetMaxDistance(float value)
    {
      return OnConfigureInternal(bp => bp.MaxDistance = value);
    }

    /// <summary>
    /// Sets <see cref="DistanceRangeConsideration.InsideDistanceRangeScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DistanceRangeConsiderationConfigurator SetInsideDistanceRangeScore(float value)
    {
      return OnConfigureInternal(bp => bp.InsideDistanceRangeScore = value);
    }

    /// <summary>
    /// Sets <see cref="DistanceRangeConsideration.OutsideDistanceRangeScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DistanceRangeConsiderationConfigurator SetOutsideDistanceRangeScore(float value)
    {
      return OnConfigureInternal(bp => bp.OutsideDistanceRangeScore = value);
    }
  }
}
