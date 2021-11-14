using BlueprintCore.Utils;
using BlueprintCoreGen.Blueprints.Configurators.Facts;
using Kingmaker.Blueprints.Classes;

namespace BlueprintCoreGen.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintFeatureBase"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintFeatureBase))]
  public abstract class FeatureBaseConfigurator<T, TBuilder> : BaseUnitFactConfigurator<T, TBuilder>
      where T : BlueprintFeatureBase
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
    protected FeatureBaseConfigurator(string name) : base(name) { }

    // [GenerateComponents]
  }
}
