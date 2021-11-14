using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
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



    /// <summary>
    /// Adds <see cref="FeatureTagsComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(FeatureTagsComponent))]
    public TBuilder AddFeatureTagsComponent(
        FeatureTag FeatureTags)
    {
      ValidateParam(FeatureTags);
      
      var component =  new FeatureTagsComponent();
      component.FeatureTags = FeatureTags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="HideFeatureInInspect"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HideFeatureInInspect))]
    public TBuilder AddHideFeatureInInspect()
    {
      return AddComponent(new HideFeatureInInspect());
    }  }
}
