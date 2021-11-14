using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="HasManualTargetConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(HasManualTargetConsideration))]
  public class HasManualTargetConsiderationConfigurator : BaseConsiderationConfigurator<HasManualTargetConsideration, HasManualTargetConsiderationConfigurator>
  {
     private HasManualTargetConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static HasManualTargetConsiderationConfigurator For(string name)
    {
      return new HasManualTargetConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static HasManualTargetConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<HasManualTargetConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static HasManualTargetConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<HasManualTargetConsideration>(name, assetId);
      return For(name);
    }
  }
}
