using BlueprintCore.Blueprints;
using BlueprintCore.Blueprints.Abilities;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
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
    public void SetMaxAmount()
    {
      GetConfigurator(Guid)
          .SetMaxAmount(ResourceAmountBuilder.New(3))
          .Configure();

      var resource = BlueprintTool.Get<BlueprintAbilityResource>(Guid);
      Assert.Equal(3, resource.m_MaxAmount.BaseValue);
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

    [Fact]
    public void ResourceAmountBuilder_Simple()
    {
      BlueprintAbilityResource.Amount amount = ResourceAmountBuilder.New(4).Build();

      Assert.Equal(4, amount.BaseValue);
      Assert.False(amount.IncreasedByLevel);
      Assert.False(amount.IncreasedByLevelStartPlusDivStep);
      Assert.False(amount.IncreasedByStat);
    }

    [Fact]
    public void ResourceAmountBuilder_IncreaseByLevel()
    {
      BlueprintAbilityResource.Amount amount =
          ResourceAmountBuilder.New(4).IncreaseByLevel(new string[] { ClassGuid }).Build();

      Assert.Equal(4, amount.BaseValue);
      Assert.False(amount.IncreasedByLevelStartPlusDivStep);
      Assert.False(amount.IncreasedByStat);

      Assert.True(amount.IncreasedByLevel);
      Assert.Single(amount.m_Class);
      Assert.Contains(Clazz.ToReference<BlueprintCharacterClassReference>(), amount.m_Class);
    }

    [Fact]
    public void ResourceAmountBuilder_IncreaseByLevel_WithBonusPerLevel()
    {
      BlueprintAbilityResource.Amount amount =
          ResourceAmountBuilder.New(4).IncreaseByLevel(new string[] { ClassGuid }, bonusPerLevel: 2).Build();

      Assert.Equal(4, amount.BaseValue);
      Assert.False(amount.IncreasedByLevelStartPlusDivStep);
      Assert.False(amount.IncreasedByStat);

      Assert.True(amount.IncreasedByLevel);
      Assert.Equal(2, amount.LevelIncrease);
      Assert.Single(amount.m_Class);
      Assert.Contains(Clazz.ToReference<BlueprintCharacterClassReference>(), amount.m_Class);
    }

    [Fact]
    public void ResourceAmountBuilder_IncreaseByStat()
    {
      BlueprintAbilityResource.Amount amount =
          ResourceAmountBuilder.New(1).IncreaseByStat(StatType.Intelligence).Build();

      Assert.Equal(1, amount.BaseValue);
      Assert.False(amount.IncreasedByLevelStartPlusDivStep);
      Assert.False(amount.IncreasedByLevel);

      Assert.True(amount.IncreasedByStat);
      Assert.Equal(StatType.Intelligence, amount.ResourceBonusStat);
    }

    [Fact]
    public void ResourceAmountBuilder_IncreaseByLevelStartPlusDivStep()
    {
      BlueprintAbilityResource.Amount amount =
          ResourceAmountBuilder.New(5).IncreaseByLevelStartPlusDivStep().Build();

      Assert.Equal(5, amount.BaseValue);
      Assert.False(amount.IncreasedByLevel);
      Assert.False(amount.IncreasedByStat);

      Assert.True(amount.IncreasedByLevelStartPlusDivStep);
      Assert.Empty(amount.m_ClassDiv);
      Assert.Equal(0f, amount.OtherClassesModifier);
      Assert.Equal(0, amount.StartingLevel);
      Assert.Equal(0, amount.StartingIncrease);
      Assert.Equal(1, amount.LevelStep);
      Assert.Equal(0, amount.PerStepIncrease);
      Assert.Equal(0, amount.MinClassLevelIncrease);
    }

    [Fact]
    public void ResourceAmountBuilder_IncreaseByLevelStartPlusDivStep_WithOptionalValues()
    {
      BlueprintAbilityResource.Amount amount =
          ResourceAmountBuilder.New(2)
              .IncreaseByLevelStartPlusDivStep(
                  classes: new string[] { ClassGuid },
                  otherClassLevelsMultiplier: 1f,
                  startingLevel: 3,
                  startingBonus: 2,
                  levelsPerStep: 4,
                  bonusPerStep: 5,
                  minBonus: 6)
              .Build();

      Assert.Equal(2, amount.BaseValue);
      Assert.False(amount.IncreasedByLevel);
      Assert.False(amount.IncreasedByStat);

      Assert.True(amount.IncreasedByLevelStartPlusDivStep);
      Assert.Single(amount.m_ClassDiv);
      Assert.Contains(Clazz.ToReference<BlueprintCharacterClassReference>(), amount.m_ClassDiv);
      Assert.Equal(1f, amount.OtherClassesModifier);
      Assert.Equal(3, amount.StartingLevel);
      Assert.Equal(2, amount.StartingIncrease);
      Assert.Equal(4, amount.LevelStep);
      Assert.Equal(5, amount.PerStepIncrease);
      Assert.Equal(6, amount.MinClassLevelIncrease);
    }
  }
}
