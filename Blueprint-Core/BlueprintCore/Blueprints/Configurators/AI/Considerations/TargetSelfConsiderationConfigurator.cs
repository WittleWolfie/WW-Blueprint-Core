using BlueprintCore.Blueprints.Configurators.AI.Considerations;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="TargetSelfConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(TargetSelfConsideration))]
  public class TargetSelfConsiderationConfigurator : BaseConsiderationConfigurator<TargetSelfConsideration, TargetSelfConsiderationConfigurator>
  {
     private TargetSelfConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TargetSelfConsiderationConfigurator For(string name)
    {
      return new TargetSelfConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static TargetSelfConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<TargetSelfConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TargetSelfConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<TargetSelfConsideration>(name, assetId);
      return For(name);
    }
  }
}
