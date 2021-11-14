using BlueprintCore.Blueprints.Configurators.AI.Considerations;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="LastTargetConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(LastTargetConsideration))]
  public class LastTargetConsiderationConfigurator : BaseConsiderationConfigurator<LastTargetConsideration, LastTargetConsiderationConfigurator>
  {
     private LastTargetConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static LastTargetConsiderationConfigurator For(string name)
    {
      return new LastTargetConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static LastTargetConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<LastTargetConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static LastTargetConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<LastTargetConsideration>(name, assetId);
      return For(name);
    }
  }
}
