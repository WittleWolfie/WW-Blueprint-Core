using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes.Selection;

namespace BlueprintCore.Blueprints.Configurators.Classes.Selection
{
  /// <summary>Configurator for <see cref="BlueprintParametrizedFeature"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintParametrizedFeature))]
  public class ParametrizedFeatureConfigurator : BaseFeatureConfigurator<BlueprintParametrizedFeature, ParametrizedFeatureConfigurator>
  {
     private ParametrizedFeatureConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ParametrizedFeatureConfigurator For(string name)
    {
      return new ParametrizedFeatureConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ParametrizedFeatureConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintParametrizedFeature>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ParametrizedFeatureConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintParametrizedFeature>(name, assetId);
      return For(name);
    }
  }
}
