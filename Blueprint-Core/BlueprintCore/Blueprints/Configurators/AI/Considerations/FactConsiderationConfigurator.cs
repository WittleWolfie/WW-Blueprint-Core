using BlueprintCore.Blueprints.Configurators.AI.Considerations;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="FactConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(FactConsideration))]
  public class FactConsiderationConfigurator : BaseConsiderationConfigurator<FactConsideration, FactConsiderationConfigurator>
  {
     private FactConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static FactConsiderationConfigurator For(string name)
    {
      return new FactConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static FactConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<FactConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static FactConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<FactConsideration>(name, assetId);
      return For(name);
    }

  }
}
