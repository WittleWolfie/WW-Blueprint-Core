using BlueprintCore.Blueprints.Configurators.AI.Considerations;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="LifeStateConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(LifeStateConsideration))]
  public class LifeStateConsiderationConfigurator : BaseConsiderationConfigurator<LifeStateConsideration, LifeStateConsiderationConfigurator>
  {
     private LifeStateConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static LifeStateConsiderationConfigurator For(string name)
    {
      return new LifeStateConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static LifeStateConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<LifeStateConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static LifeStateConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<LifeStateConsideration>(name, assetId);
      return For(name);
    }

  }
}
