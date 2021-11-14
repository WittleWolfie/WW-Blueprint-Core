using BlueprintCore.Blueprints.Configurators.AI.Considerations;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="ArmorTypeConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(ArmorTypeConsideration))]
  public class ArmorTypeConsiderationConfigurator : BaseConsiderationConfigurator<ArmorTypeConsideration, ArmorTypeConsiderationConfigurator>
  {
     private ArmorTypeConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ArmorTypeConsiderationConfigurator For(string name)
    {
      return new ArmorTypeConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ArmorTypeConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<ArmorTypeConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ArmorTypeConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<ArmorTypeConsideration>(name, assetId);
      return For(name);
    }
  }
}
