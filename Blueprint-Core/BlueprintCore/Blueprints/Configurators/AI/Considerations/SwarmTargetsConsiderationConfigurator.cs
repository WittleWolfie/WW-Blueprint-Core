using BlueprintCore.Blueprints.Configurators.AI.Considerations;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="SwarmTargetsConsideration"/>.</summary>
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
    public static SwarmTargetsConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<SwarmTargetsConsideration>(name, assetId);
      return For(name);
    }
  }
}
