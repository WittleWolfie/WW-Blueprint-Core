using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="BuffsAroundConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BuffsAroundConsideration))]
  public class BuffsAroundConsiderationConfigurator : BaseUnitsAroundConsiderationConfigurator<BuffsAroundConsideration, BuffsAroundConsiderationConfigurator>
  {
     private BuffsAroundConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static BuffsAroundConsiderationConfigurator For(string name)
    {
      return new BuffsAroundConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static BuffsAroundConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<BuffsAroundConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static BuffsAroundConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BuffsAroundConsideration>(name, assetId);
      return For(name);
    }
  }
}
