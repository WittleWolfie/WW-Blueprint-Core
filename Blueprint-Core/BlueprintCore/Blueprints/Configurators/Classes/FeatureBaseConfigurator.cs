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
  public abstract class FeatureBaseConfigurator<T, TBuilder> : BaseUnitFactConfigurator<T, TBuilder>
      where T : BlueprintFeatureBase
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
    protected FeatureBaseConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintFeatureBase.HideInUi"/>
    /// </summary>
    public TBuilder SetHideInUi(bool hide = true)
    {
      return OnConfigureInternal(blueprint => blueprint.HideInUI = hide);
    }

    /// <summary>
    /// Sets <see cref="BlueprintFeatureBase.HideInCharacterSheetAndLevelUp"/>
    /// </summary>
    public TBuilder SetHideInCharacterSheetAndLevelUp(bool hide = true)
    {
      return OnConfigureInternal(blueprint => blueprint.HideInCharacterSheetAndLevelUp = hide);
    }

    /// <summary>
    /// Sets <see cref="BlueprintFeatureBase.HideNotAvailibleInUI"/>
    /// </summary>
    public TBuilder SetHideNotAvailableInUI(bool hide = true)
    {
      return OnConfigureInternal(blueprint => blueprint.HideNotAvailibleInUI = hide);
    }


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
    }
  }
}
