using BlueprintCore.Blueprints.Configurators.AI.Considerations;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="BuffConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BuffConsideration))]
  public class BuffConsiderationConfigurator : BaseConsiderationConfigurator<BuffConsideration, BuffConsiderationConfigurator>
  {
     private BuffConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static BuffConsiderationConfigurator For(string name)
    {
      return new BuffConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static BuffConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<BuffConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static BuffConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BuffConsideration>(name, assetId);
      return For(name);
    }
  }
}
