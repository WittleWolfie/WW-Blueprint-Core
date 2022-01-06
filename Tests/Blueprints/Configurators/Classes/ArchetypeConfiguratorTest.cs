using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Utils;
using Xunit;

namespace BlueprintCore.Test.Blueprints.Configurators.Classes
{
  /**
   * Feature specific tests should go in CommonFeatureConfiguratorTest which is shared with
   * FeatureSelectionConfiguratorTest.
   */
  public class ArchetypeConfiguratorTest : BaseBlueprintConfiguratorTest<BlueprintArchetype, ArchetypeConfigurator>
  {
    public ArchetypeConfiguratorTest() : base()
    {
      BlueprintPatch.Create<BlueprintArchetype>(Guid);
    }

    protected override ArchetypeConfigurator GetConfigurator(string guid)
    {
      return ArchetypeConfigurator.For(guid);
    }

    [Fact]
    public void SetDisplayName()
    {
      GetConfigurator(Guid)
          .SetDisplayName(new LocalizedString { m_Key = "name" })
          .Configure();

      var archetype = BlueprintTool.Get<BlueprintArchetype>(Guid);
      Assert.Equal("name", archetype.LocalizedName.m_Key);
    }

    [Fact]
    public void SetDescription()
    {
      GetConfigurator(Guid)
          .SetDescription(new LocalizedString { m_Key = "description" })
          .Configure();

      var archetype = BlueprintTool.Get<BlueprintArchetype>(Guid);
      Assert.Equal("description", archetype.LocalizedDescription.m_Key);
    }
  }
}
