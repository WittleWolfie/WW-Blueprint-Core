using BlueprintCore.Blueprints;
using BlueprintCore.Blueprints.Abilities;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using Xunit;
using static BlueprintCore.Test.TestData;

namespace BlueprintCore.Test.Blueprints.Abilities
{
  public class AbilityResourceConfiguratorTest
      : BlueprintConfiguratorTest<BlueprintAbilityResource, AbilityResourceConfigurator>
  {
    public AbilityResourceConfiguratorTest() : base()
    {
      BlueprintPatch.Create<BlueprintAbilityResource>(Guid);
    }

    protected override AbilityResourceConfigurator GetConfigurator(string guid)
    {
      return AbilityResourceConfigurator.For(guid);
    }

    [Fact]
    public void SetDisplayName()
    {
      GetConfigurator(Guid)
          .SetDisplayName(new LocalizedString { m_Key = "name" })
          .Configure();

      var resource = BlueprintTool.Get<BlueprintAbilityResource>(Guid);
      Assert.Equal("name", resource.LocalizedName.m_Key);
    }

    [Fact]
    public void SetDescription()
    {
      GetConfigurator(Guid)
          .SetDescription(new LocalizedString { m_Key = "description" })
          .Configure();

      var resource = BlueprintTool.Get<BlueprintAbilityResource>(Guid);
      Assert.Equal("description", resource.LocalizedDescription.m_Key);
    }

    [Fact]
    public void SetIcon()
    {
      GetConfigurator(Guid)
          .SetIcon(TestSprite)
          .Configure();

      var resource = BlueprintTool.Get<BlueprintAbilityResource>(Guid);
      Assert.Equal(TestSprite, resource.m_Icon);
    }

    [Fact]
    public void SetMax()
    {
      GetConfigurator(Guid)
          .SetMax(6)
          .Configure();

      var resource = BlueprintTool.Get<BlueprintAbilityResource>(Guid);

      Assert.Equal(6, resource.m_Max);
      Assert.True(resource.m_UseMax);
    }

    [Fact]
    public void DisableMax()
    {
      GetConfigurator(Guid)
          .DisableMax()
          .Configure();

      var resource = BlueprintTool.Get<BlueprintAbilityResource>(Guid);
      Assert.False(resource.m_UseMax);
    }

    [Fact]
    public void SetMin()
    {
      GetConfigurator(Guid)
          .SetMin(2)
          .Configure();

      var resource = BlueprintTool.Get<BlueprintAbilityResource>(Guid);
      Assert.Equal(2, resource.m_Min);
    }
  }
}
