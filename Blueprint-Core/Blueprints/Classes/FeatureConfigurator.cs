using Kingmaker.Blueprints.Classes;

namespace BlueprintCore.Blueprints.Classes
{
  /**
   * Concrete class for configuring BlueprintFeatures. Implementation is inside of
   * CommonFeatureConfigurator for sharing with FeatureSelectionConfigurator.
   */
  public class FeatureConfigurator
      : CommonFeatureConfigurator<BlueprintFeature, FeatureConfigurator>
  {
    private FeatureConfigurator(string name) : base(name) { }

    /**
     * Creates a FeatureConfigurator for the specified blueprint.
     *
     * Use this function if the blueprint already exists. If you're using Owlcat's
     * WrathModificationTemplate all of your JSON blueprints already exist.
     */
    public static FeatureConfigurator For(string name)
    {
      return new FeatureConfigurator(name);
    }

    /**
     * Creates a BlueprintFeature and returns its FeatureConfigurator.
     * 
     * Use this function to create a Blueprint if you provided a mapping to Guids with an associated
     * guid for the given name.
     */
    public static FeatureConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintFeature>(name);
      return For(name);
    }

    /** Creates a BlueprintFeature and returns its FeatureConfigurator. */
    public static FeatureConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintFeature>(name, assetId);
      return For(name);
    }
  }
}