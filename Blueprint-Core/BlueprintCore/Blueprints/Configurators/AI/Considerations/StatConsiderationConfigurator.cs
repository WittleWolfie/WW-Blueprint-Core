using BlueprintCore.Blueprints.Configurators.AI.Considerations;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="StatConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(StatConsideration))]
  public class StatConsiderationConfigurator : BaseConsiderationConfigurator<StatConsideration, StatConsiderationConfigurator>
  {
     private StatConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static StatConsiderationConfigurator For(string name)
    {
      return new StatConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static StatConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<StatConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static StatConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<StatConsideration>(name, assetId);
      return For(name);
    }

  }
}
