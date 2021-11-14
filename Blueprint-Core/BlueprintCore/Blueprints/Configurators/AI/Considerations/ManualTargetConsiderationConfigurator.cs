using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="ManualTargetConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(ManualTargetConsideration))]
  public class ManualTargetConsiderationConfigurator : BaseConsiderationConfigurator<ManualTargetConsideration, ManualTargetConsiderationConfigurator>
  {
     private ManualTargetConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ManualTargetConsiderationConfigurator For(string name)
    {
      return new ManualTargetConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ManualTargetConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<ManualTargetConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ManualTargetConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<ManualTargetConsideration>(name, assetId);
      return For(name);
    }
  }
}
