using BlueprintCore.Blueprints;
using Kingmaker.Blueprints;

namespace BlueprintCore.Test.Blueprints.Classes
{
  public class BlueprintConfiguratorTest
      : BaseBlueprintConfiguratorTest<BlueprintPet, BlueprintConfigurator<BlueprintPet>>
  {
    public BlueprintConfiguratorTest() : base()
    {
      BlueprintPatch.Create<BlueprintPet>(Guid);
    }

    protected override BlueprintConfigurator<BlueprintPet> GetConfigurator(string guid)
    {
      return BlueprintConfigurator<BlueprintPet>.For(guid);
    }
  }
}
