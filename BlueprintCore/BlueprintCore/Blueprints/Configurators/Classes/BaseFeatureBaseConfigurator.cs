//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
using System;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintFeatureBase"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseFeatureBaseConfigurator<T, TBuilder>
    : BaseUnitFactConfigurator<T, TBuilder>
    where T : BlueprintFeatureBase
    where TBuilder : BaseFeatureBaseConfigurator<T, TBuilder>
  {
    protected BaseFeatureBaseConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintFeatureBase>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.HideInUI = copyFrom.HideInUI;
          bp.HideInCharacterSheetAndLevelUp = copyFrom.HideInCharacterSheetAndLevelUp;
          bp.HideNotAvailibleInUI = copyFrom.HideNotAvailibleInUI;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintFeatureBase>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.HideInUI = copyFrom.HideInUI;
          bp.HideInCharacterSheetAndLevelUp = copyFrom.HideInCharacterSheetAndLevelUp;
          bp.HideNotAvailibleInUI = copyFrom.HideNotAvailibleInUI;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFeatureBase.HideInUI"/>
    /// </summary>
    ///
    /// <param name="hideInUI">
    /// <para>
    /// Tooltip: It will not be showed in any UI screens
    /// </para>
    /// </param>
    public TBuilder SetHideInUI(bool hideInUI = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HideInUI = hideInUI;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFeatureBase.HideInCharacterSheetAndLevelUp"/>
    /// </summary>
    ///
    /// <param name="hideInCharacterSheetAndLevelUp">
    /// <para>
    /// Tooltip: It will not be showed on page Total in LevelUp/Charscreen and Character Sheet &amp;gt; Abilities
    /// </para>
    /// </param>
    public TBuilder SetHideInCharacterSheetAndLevelUp(bool hideInCharacterSheetAndLevelUp = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HideInCharacterSheetAndLevelUp = hideInCharacterSheetAndLevelUp;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFeatureBase.HideNotAvailibleInUI"/>
    /// </summary>
    ///
    /// <param name="hideNotAvailibleInUI">
    /// <para>
    /// Tooltip: For BlueprintFeature: NotAvailible will not be showed in LevelUp/Charscreen selecors. For BlueprintFeatureSelection: all NotAvailible child features will not be showed.
    /// </para>
    /// </param>
    public TBuilder SetHideNotAvailibleInUI(bool hideNotAvailibleInUI = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HideNotAvailibleInUI = hideNotAvailibleInUI;
        });
    }

    /// <summary>
    /// Adds <see cref="FeatureTagsComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AccomplishedSneakAttacker</term><description>9f0187869dc23744292c0e5bb364464e</description></item>
    /// <item><term>ImprovedUnarmedStrike</term><description>7812ad3672a4b9a4fb894ea402095167</description></item>
    /// <item><term>WeaponSpecializationGreater</term><description>7cf5edc65e785a24f9cf93af987d66b3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddFeatureTagsComponent(
        FeatureTag featureTags,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new FeatureTagsComponent();
      component.FeatureTags = featureTags;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="HideFeatureInInspect"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbadarFeature</term><description>6122dacf418611540a3c91e67197ee4e</description></item>
    /// <item><term>FightDefensivelyToggleAbility</term><description>09d742e8b50b0214fb71acfc99cc00b3</description></item>
    /// <item><term>WitchBetterHexProgression</term><description>38d01811fcb32444a8fe372c029fa0c6</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddHideFeatureInInspect()
    {
      return AddComponent(new HideFeatureInInspect());
    }
  }
}
