using BlueprintCore.Blueprints.Configurators.AI.Considerations;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="DistanceConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(DistanceConsideration))]
  public class DistanceConsiderationConfigurator : BaseConsiderationConfigurator<DistanceConsideration, DistanceConsiderationConfigurator>
  {
     private DistanceConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static DistanceConsiderationConfigurator For(string name)
    {
      return new DistanceConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static DistanceConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<DistanceConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static DistanceConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<DistanceConsideration>(name, assetId);
      return For(name);
    }

  }
}