using BlueprintCore.Blueprints.Configurators.AI.Considerations;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="BuffNotFromCasterConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BuffNotFromCasterConsideration))]
  public class BuffNotFromCasterConsiderationConfigurator : BaseConsiderationConfigurator<BuffNotFromCasterConsideration, BuffNotFromCasterConsiderationConfigurator>
  {
     private BuffNotFromCasterConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static BuffNotFromCasterConsiderationConfigurator For(string name)
    {
      return new BuffNotFromCasterConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static BuffNotFromCasterConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<BuffNotFromCasterConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static BuffNotFromCasterConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BuffNotFromCasterConsideration>(name, assetId);
      return For(name);
    }
  }
}
