using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintFeatureBase"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintFeatureBase))]
  public abstract class BaseFeatureBaseConfigurator<T, TBuilder>
      : BaseUnitFactConfigurator<T, TBuilder>
      where T : BlueprintFeatureBase
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseFeatureBaseConfigurator(string name) : base(name) { }

  }
}
