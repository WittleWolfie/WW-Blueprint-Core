using BlueprintCore.Utils;
using BlueprintCoreGen.Blueprints.Configurators;
using Kingmaker.Blueprints;
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
