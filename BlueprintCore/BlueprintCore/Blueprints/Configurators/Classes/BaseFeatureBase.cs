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
    /// Modifies <see cref="BlueprintFeatureBase.HideInUI"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHideInUI(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.HideInUI);
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
    /// Modifies <see cref="BlueprintFeatureBase.HideInCharacterSheetAndLevelUp"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHideInCharacterSheetAndLevelUp(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.HideInCharacterSheetAndLevelUp);
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
    /// Modifies <see cref="BlueprintFeatureBase.HideNotAvailibleInUI"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHideNotAvailibleInUI(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.HideNotAvailibleInUI);
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
    /// <item><term>IronWillImproved</term><description>3ea2215150a1c8a4a9bfed9d9023903e</description></item>
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
    /// <item><term>FightDefensivelyFeature</term><description>ca22afeb94442b64fb8536e7a9f7dc11</description></item>
    /// <item><term>PersuasionUseAbility</term><description>7d2233c3b7a0b984ba058a83b736e6ac</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddHideFeatureInInspect()
    {
      return AddComponent(new HideFeatureInInspect());
    }
  }
}
