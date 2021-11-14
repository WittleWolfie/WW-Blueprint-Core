using BlueprintCore.Blueprints.Configurators.AI.Considerations;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="HealthConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(HealthConsideration))]
  public class HealthConsiderationConfigurator : BaseConsiderationConfigurator<HealthConsideration, HealthConsiderationConfigurator>
  {
     private HealthConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static HealthConsiderationConfigurator For(string name)
    {
      return new HealthConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static HealthConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<HealthConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static HealthConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<HealthConsideration>(name, assetId);
      return For(name);
    }
  }
}
