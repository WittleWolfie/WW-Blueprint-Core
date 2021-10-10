using Kingmaker.Blueprints.Classes;

namespace BlueprintCore.Features
{
  /**
   * Concrete class for configuring BlueprintFeatures. Implementation is inside of
   * CommonFeatureConfigurator for sharing with FeatureSelectionConfigurator.
   */
  public class FeatureConfigurator
      : CommonFeatureConfigurator<BlueprintFeature, FeatureConfigurator>
  {
    private FeatureConfigurator(string name) : base(name) { }

    public static FeatureConfigurator For(string name)
    {
      return new FeatureConfigurator(name);
    }
  }
}