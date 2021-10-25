using BlueprintCore.Blueprints.Classes;
using Kingmaker.Blueprints.Classes;

namespace BlueprintCore.Test.Blueprints.Classes
{
  /// <summary>
  /// Feature specific tests should go in CommonFeatureConfiguratorTest which is shared with
  /// classes inheriting from BlueprintFeature.
  /// </summary>
  public class FeatureConfiguratorTest : CommonFeatureConfiguratorTest<BlueprintFeature, FeatureConfigurator>
  {
    public FeatureConfiguratorTest() : base()
    {
      BlueprintPatch.Create<BlueprintFeature>(Guid);
    }

    protected override FeatureConfigurator GetConfigurator(string guid)
    {
      return FeatureConfigurator.For(guid);
    }
  }
}
