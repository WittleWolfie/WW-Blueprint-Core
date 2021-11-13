using BlueprintCore.Blueprints.Configurators.AI.Considerations;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="SpecificUnitBlueprintConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(SpecificUnitBlueprintConsideration))]
  public class SpecificUnitConsiderationConfigurator : BaseConsiderationConfigurator<SpecificUnitBlueprintConsideration, SpecificUnitConsiderationConfigurator>
  {
     private SpecificUnitConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SpecificUnitConsiderationConfigurator For(string name)
    {
      return new SpecificUnitConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static SpecificUnitConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<SpecificUnitBlueprintConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SpecificUnitConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<SpecificUnitBlueprintConsideration>(name, assetId);
      return For(name);
    }

  }
}
