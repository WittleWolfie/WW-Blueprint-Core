using BlueprintCore.Utils;
using BlueprintCoreGen.Blueprints.Configurators;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
using System.Linq;

namespace BlueprintCoreGen.Templates.BlueprintComponents
{
  abstract class FeatureTemplates<T, TBuilder> : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintScriptableObject
      where TBuilder : FeatureTemplates<T, TBuilder>
  {
    private FeatureTemplates(string name) : base(name) { }

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
  }
}
