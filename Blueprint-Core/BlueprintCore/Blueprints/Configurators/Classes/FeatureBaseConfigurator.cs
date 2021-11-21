using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Classes
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


    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteSelectionPossible">PrerequisiteSelectionPossible</see>
    /// </summary>
    /// 
    /// <remarks>
    /// <para>
    /// A feature selection with this component only shows up if the character is eligible for at least one feature.
    /// This is useful when a character has access to different feature selections based on some criteria.
    /// </para>
    /// 
    /// <para>
    /// See ExpandedDefense and WildTalentBonusFeatAir3 blueprints for example usages.
    /// </para>
    /// </remarks>
    public TBuilder PrerequisiteSelectionPossible(
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var selectionPossible = PrereqTool.Create<PrerequisiteSelectionPossible>(group, checkInProgression, hideInUI);
      selectionPossible.m_ThisFeature = Blueprint.ToReference<BlueprintFeatureSelectionReference>();
      return AddComponent(selectionPossible);
    }

    /// <summary>
    /// Sets the contents of <see cref="FeatureTagsComponent"/>
    /// </summary>
    [Implements(typeof(FeatureTagsComponent))]
    public TBuilder SetFeatureTags(params FeatureTag[] tags)
    {
      return OnConfigureInternal(
          bp =>
          {
            var component = bp.GetComponent<FeatureTagsComponent>();
            if (component == null)
            {
              component = new FeatureTagsComponent();
              bp.AddComponents(component);
            }
            component.FeatureTags = 0;
            tags.ToList().ForEach(t => component.FeatureTags |= t);
          });
    }

    /// <summary>
    /// Adds to <see cref="FeatureTagsComponent"/>
    /// </summary>
    [Implements(typeof(FeatureTagsComponent))]
    public TBuilder AddToFeatureTags(params FeatureTag[] tags)
    {
      return OnConfigureInternal(
          bp =>
          {
            var component = bp.GetComponent<FeatureTagsComponent>();
            if (component == null)
            {
              component = new FeatureTagsComponent();
              bp.AddComponents(component);
            }
            tags.ToList().ForEach(t => component.FeatureTags |= t);
          });
    }

    /// <summary>
    /// Removes from <see cref="FeatureTagsComponent"/>
    /// </summary>
    [Implements(typeof(FeatureTagsComponent))]
    public TBuilder RemoveFromFeatureTags(params FeatureTag[] tags)
    {
      return OnConfigureInternal(
          bp =>
          {
            var component = bp.GetComponent<FeatureTagsComponent>();
            if (component == null) { return; }
            tags.ToList().ForEach(t => component.FeatureTags &= ~t);
          });
    }

    /// <summary>
    /// Adds <see cref="HideFeatureInInspect"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HideFeatureInInspect))]
    public TBuilder AddHideFeatureInInspect(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent> mergeAction = null)
    {
      var component = new HideFeatureInInspect();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}
