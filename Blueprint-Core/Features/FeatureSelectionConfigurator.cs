using BlueprintCore.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;

namespace BlueprintCore.Features
{
  public class FeatureSelectionConfigurator
      : CommonFeatureConfigurator<BlueprintFeatureSelection, FeatureSelectionConfigurator>
  {
    private FeatureSelectionConfigurator(string name) : base(name) { }

    /**
     * Creates a FeatureSelectionConfigurator for the specified blueprint.
     *
     * Use this function if the blueprint already exists. If you're using Owlcat's
     * WrathModificationTemplate all of your JSON blueprints already exist.
     */
    public static FeatureSelectionConfigurator For(string name)
    {
      return new FeatureSelectionConfigurator(name);
    }

    /**
     * Creates a BlueprintFeatureSelection and returns its FeatureSelectionConfigurator.
     * 
     * Use this function to create a Blueprint if you provided a mapping to Guids with an associated
     * guid for the given name.
     */
    public static FeatureSelectionConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintFeatureSelection>(name);
      return For(name);
    }

    /** Creates a BlueprintFeatureSelection and returns its FeatureSelectionConfigurator. */
    public static FeatureSelectionConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintFeatureSelection>(name, assetId);
      return For(name);
    }

    /**
     * PrerequisiteSelectionPossible 
     *
     * A feature selection with this component will only show up if the character is eligible for at
     * least one feature. This is useful when a character may have access to different sets of 
     * features based on some criteria.
     *
     * Examples: Expanded Defense, Wild Talent Bonus Feat (3)
     */
    public FeatureSelectionConfigurator PrerequisiteSelectionPossible()
    {
      var selectionPossible = new PrerequisiteSelectionPossible
      {
        m_ThisFeature = Blueprint.ToReference<BlueprintFeatureSelectionReference>()
      };
      return AddComponent(selectionPossible);
    }
  }
}