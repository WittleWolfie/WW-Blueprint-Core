using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;

namespace BlueprintCore.Features
{
  public class FeatureSelectionConfigurator
      : CommonFeatureConfigurator<BlueprintFeatureSelection, FeatureSelectionConfigurator>
  {
    private FeatureSelectionConfigurator(string name) : base(name) { }

    public static FeatureSelectionConfigurator For(string name)
    {
      return new FeatureSelectionConfigurator(name);
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