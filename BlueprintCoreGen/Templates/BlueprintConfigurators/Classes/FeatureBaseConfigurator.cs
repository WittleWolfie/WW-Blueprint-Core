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
      where TBuilder : FeatureBaseConfigurator<T, TBuilder>
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

    // [GenerateComponents]
  }
}
