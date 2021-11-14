using BlueprintCore.Blueprints.Configurators.AI.Considerations;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="ConditionConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(ConditionConsideration))]
  public class ConditionConsiderationConfigurator : BaseConsiderationConfigurator<ConditionConsideration, ConditionConsiderationConfigurator>
  {
     private ConditionConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ConditionConsiderationConfigurator For(string name)
    {
      return new ConditionConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ConditionConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<ConditionConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ConditionConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<ConditionConsideration>(name, assetId);
      return For(name);
    }
  }
}
