using BlueprintCore.Blueprints.Configurators.AI.Considerations;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="HealthAroundConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(HealthAroundConsideration))]
  public class HealthAroundConsiderationConfigurator : BaseUnitsAroundConsiderationConfigurator<HealthAroundConsideration, HealthAroundConsiderationConfigurator>
  {
     private HealthAroundConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static HealthAroundConsiderationConfigurator For(string name)
    {
      return new HealthAroundConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static HealthAroundConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<HealthAroundConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static HealthAroundConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<HealthAroundConsideration>(name, assetId);
      return For(name);
    }

  }
}
