using BlueprintCore.Features;
using Kingmaker.Blueprints.Classes;

namespace BlueprintCore.Tests.Features
{
  /**
   * Feature specific tests should go in CommonFeatureConfiguratorTest which is shared with
   * FeatureSelectionConfiguratorTest.
   */
  public class FeatureConfiguratorTest
      : CommonFeatureConfiguratorTest<BlueprintFeature, FeatureConfigurator>
  {
    public FeatureConfiguratorTest() : base()
    {
      CreateBlueprint<BlueprintFeature>(Guid);
    }

    protected override FeatureConfigurator GetConfigurator(string guid)
    {
      return FeatureConfigurator.For(guid);
    }
  }
}
