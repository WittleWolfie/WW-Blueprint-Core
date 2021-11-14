using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="ThreatedByConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(ThreatedByConsideration))]
  public class ThreatedByConsiderationConfigurator : BaseConsiderationConfigurator<ThreatedByConsideration, ThreatedByConsiderationConfigurator>
  {
     private ThreatedByConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ThreatedByConsiderationConfigurator For(string name)
    {
      return new ThreatedByConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ThreatedByConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<ThreatedByConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ThreatedByConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<ThreatedByConsideration>(name, assetId);
      return For(name);
    }
  }
}
