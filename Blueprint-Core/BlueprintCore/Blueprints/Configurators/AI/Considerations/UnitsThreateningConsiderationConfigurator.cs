using BlueprintCore.Blueprints.Configurators.AI.Considerations;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="UnitsThreateningConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(UnitsThreateningConsideration))]
  public class UnitsThreateningConsiderationConfigurator : BaseConsiderationConfigurator<UnitsThreateningConsideration, UnitsThreateningConsiderationConfigurator>
  {
     private UnitsThreateningConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnitsThreateningConsiderationConfigurator For(string name)
    {
      return new UnitsThreateningConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static UnitsThreateningConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<UnitsThreateningConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnitsThreateningConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<UnitsThreateningConsideration>(name, assetId);
      return For(name);
    }
  }
}
