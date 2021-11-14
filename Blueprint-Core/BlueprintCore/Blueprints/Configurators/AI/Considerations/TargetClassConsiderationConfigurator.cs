using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="TargetClassConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(TargetClassConsideration))]
  public class TargetClassConsiderationConfigurator : BaseConsiderationConfigurator<TargetClassConsideration, TargetClassConsiderationConfigurator>
  {
     private TargetClassConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TargetClassConsiderationConfigurator For(string name)
    {
      return new TargetClassConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static TargetClassConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<TargetClassConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TargetClassConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<TargetClassConsideration>(name, assetId);
      return For(name);
    }
  }
}
