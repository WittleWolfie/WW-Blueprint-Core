using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints;
using BlueprintCore.Blueprints.Facts;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using Kingmaker.Settings;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Xunit;
using static BlueprintCore.Test.TestData;

namespace BlueprintCore.Test.Blueprints.Facts
{
  public abstract class BlueprintUnitFactConfiguratorTest<T, TBuilder>
      : BaseBlueprintConfiguratorTest<T, TBuilder>
      where T : BlueprintUnitFact
      where TBuilder : BlueprintUnitFactConfigurator<T, TBuilder>
  {
    protected BlueprintUnitFactConfiguratorTest() : base() { }

    [Fact]
    public void SetDisplayName()
    {
      GetConfigurator(Guid)
          .SetDisplayName(new LocalizedString { m_Key = "name_key" })
          .Configure();

      var blueprint = BlueprintTool.Get<T>(Guid);
      Assert.Equal("name_key", blueprint.m_DisplayName.m_Key);
    }

    [Fact]
    public void SetDescription()
    {
      GetConfigurator(Guid)
          .SetDescription(new LocalizedString { m_Key = "description_key" })
          .Configure();

      var blueprint = BlueprintTool.Get<T>(Guid);
      Assert.Equal("description_key", blueprint.m_Description.m_Key);
    }

    [Fact]
    public void SetDescriptionShort()
    {
      GetConfigurator(Guid)
          .SetDescriptionShort(new LocalizedString { m_Key = "short_key" })
          .Configure();

      var blueprint = BlueprintTool.Get<T>(Guid);
      Assert.Equal("short_key", blueprint.m_DescriptionShort.m_Key);
    }

    [Fact]
    public void SetIcon()
    {
      GetConfigurator(Guid)
          .SetIcon(TestSprite)
          .Configure();

      var blueprint = BlueprintTool.Get<T>(Guid);
      Assert.Equal(TestSprite, blueprint.m_Icon);
    }

    [Fact]
    public void AddFacts()
    {
      GetConfigurator(Guid)
          .AddFacts(new string[] { FactGuid, ExtraFactGuid })
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var addFacts = blueprint.GetComponent<AddFacts>();
      Assert.NotNull(addFacts);

      Assert.Equal(2, addFacts.m_Facts.Length);
      Assert.Contains(TestFact.ToReference<BlueprintUnitFactReference>(), addFacts.m_Facts);
      Assert.Contains(ExtraFact.ToReference<BlueprintUnitFactReference>(), addFacts.m_Facts);

      Assert.Equal(0, addFacts.CasterLevel);
      Assert.False(addFacts.HasDifficultyRequirements);
      Assert.False(addFacts.InvertDifficultyRequirements);
      Assert.Equal(GameDifficultyOption.Story, addFacts.MinDifficulty);
    }

    [Fact]
    public void AddFacts_WithOptionalValues()
    {
      GetConfigurator(Guid)
          .AddFacts(
              new string[] { FactGuid, ExtraFactGuid },
              casterLevel: 5,
              hasDifficultyRequirements: true,
              invertDifficultyRequirements: true,
              minDifficulty: GameDifficultyOption.Hard)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var addFacts = blueprint.GetComponent<AddFacts>();
      Assert.NotNull(addFacts);

      Assert.Equal(2, addFacts.m_Facts.Length);
      Assert.Contains(TestFact.ToReference<BlueprintUnitFactReference>(), addFacts.m_Facts);
      Assert.Contains(ExtraFact.ToReference<BlueprintUnitFactReference>(), addFacts.m_Facts);

      Assert.Equal(5, addFacts.CasterLevel);
      Assert.True(addFacts.HasDifficultyRequirements);
      Assert.True(addFacts.InvertDifficultyRequirements);
      Assert.Equal(GameDifficultyOption.Hard, addFacts.MinDifficulty);
    }

    [Fact]
    public void OnSkillCheck()
    {
      GetConfigurator(Guid)
          .OnSkillCheck(
              StatType.CheckIntimidate, ActionsBuilder.New().MeleeAttack().MeleeAttack())
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var onSkillCheck = blueprint.GetComponent<AddInitiatorSkillRollTrigger>();
      Assert.NotNull(onSkillCheck);

      Assert.True(onSkillCheck.OnlySuccess);
      Assert.Equal(StatType.CheckIntimidate, onSkillCheck.Skill);

      Assert.Equal(2, onSkillCheck.Action.Actions.Length);
      Assert.IsType<ContextActionMeleeAttack>(onSkillCheck.Action.Actions[0]);
      Assert.IsType<ContextActionMeleeAttack>(onSkillCheck.Action.Actions[1]);
    }
  }
}
