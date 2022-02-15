using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
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

namespace BlueprintCore.Test.Blueprints.Configurators.Facts
{
  public abstract class BaseUnitFactConfiguratorTest<T, TBuilder>
      : BaseBlueprintConfiguratorTest<T, TBuilder>
      where T : BlueprintUnitFact
      where TBuilder : BaseUnitFactConfigurator<T, TBuilder>
  {
    protected BaseUnitFactConfiguratorTest() : base() { }

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

    //----- Start: FactContextActions

    [Fact]
    public void AddFactContextActions()
    {
      GetConfigurator(Guid)
          .AddFactContextActions(
              onActivated: ActionsBuilder.New().MeleeAttack().MeleeAttack(),
              onDeactivated: ActionsBuilder.New().MeleeAttack(),
              onNewRound: ActionsBuilder.New().BreakFree())
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var contextActions = blueprint.GetComponent<AddFactContextActions>();
      Assert.NotNull(contextActions);

      Assert.Equal(2, contextActions.Activated.Actions.Length);
      Assert.IsType<ContextActionMeleeAttack>(contextActions.Activated.Actions[0]);
      Assert.IsType<ContextActionMeleeAttack>(contextActions.Activated.Actions[1]);

      Assert.Single(contextActions.Deactivated.Actions);
      Assert.IsType<ContextActionMeleeAttack>(contextActions.Deactivated.Actions[0]);

      Assert.Single(contextActions.NewRound.Actions);
      Assert.IsType<ContextActionBreakFree>(contextActions.NewRound.Actions[0]);
    }

    [Fact]
    public void AddFactContextActions_WithActivatedOnly()
    {
      GetConfigurator(Guid)
          .AddFactContextActions(onActivated: ActionsBuilder.New().MeleeAttack().MeleeAttack())
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var contextActions = blueprint.GetComponent<AddFactContextActions>();
      Assert.NotNull(contextActions);

      Assert.Equal(2, contextActions.Activated.Actions.Length);
      Assert.IsType<ContextActionMeleeAttack>(contextActions.Activated.Actions[0]);
      Assert.IsType<ContextActionMeleeAttack>(contextActions.Activated.Actions[1]);

      Assert.NotNull(contextActions.Deactivated.Actions);
      Assert.NotNull(contextActions.NewRound.Actions);
    }

    [Fact]
    public void AddFactContextActions_WithDeactivatedOnly()
    {
      GetConfigurator(Guid)
          .AddFactContextActions(onDeactivated: ActionsBuilder.New().MeleeAttack())
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var contextActions = blueprint.GetComponent<AddFactContextActions>();
      Assert.NotNull(contextActions);

      Assert.Single(contextActions.Deactivated.Actions);
      Assert.IsType<ContextActionMeleeAttack>(contextActions.Deactivated.Actions[0]);

      Assert.NotNull(contextActions.Activated.Actions);
      Assert.NotNull(contextActions.NewRound.Actions);
    }

    [Fact]
    public void AddFactContextActions_WithNewRoundOnly()
    {
      GetConfigurator(Guid)
          .AddFactContextActions(onNewRound: ActionsBuilder.New().BreakFree())
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var contextActions = blueprint.GetComponent<AddFactContextActions>();
      Assert.NotNull(contextActions);

      Assert.Single(contextActions.NewRound.Actions);
      Assert.IsType<ContextActionBreakFree>(contextActions.NewRound.Actions[0]);

      Assert.NotNull(contextActions.Activated.Actions);
      Assert.NotNull(contextActions.Deactivated.Actions);
    }

    [Fact]
    public void AddFactContextActions_WithMerge()
    {
      // First pass
      GetConfigurator(Guid)
          .AddFactContextActions(
              onActivated: ActionsBuilder.New().MeleeAttack().MeleeAttack(),
              onDeactivated: ActionsBuilder.New().MeleeAttack(),
              onNewRound: ActionsBuilder.New().BreakFree())
          .Configure();

      GetConfigurator(Guid)
          .AddFactContextActions(
              onActivated: ActionsBuilder.New().BreakFree(),
              onDeactivated: ActionsBuilder.New().MeleeAttack(),
              onNewRound: ActionsBuilder.New().MeleeAttack())
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var contextActions = blueprint.GetComponent<AddFactContextActions>();
      Assert.NotNull(contextActions);

      Assert.Equal(3, contextActions.Activated.Actions.Length);
      Assert.IsType<ContextActionMeleeAttack>(contextActions.Activated.Actions[0]);
      Assert.IsType<ContextActionMeleeAttack>(contextActions.Activated.Actions[1]);
      Assert.IsType<ContextActionBreakFree>(contextActions.Activated.Actions[2]);

      Assert.Equal(2, contextActions.Deactivated.Actions.Length);
      Assert.IsType<ContextActionMeleeAttack>(contextActions.Deactivated.Actions[0]);
      Assert.IsType<ContextActionMeleeAttack>(contextActions.Deactivated.Actions[1]);

      Assert.Equal(2, contextActions.NewRound.Actions.Length);
      Assert.IsType<ContextActionBreakFree>(contextActions.NewRound.Actions[0]);
      Assert.IsType<ContextActionMeleeAttack>(contextActions.NewRound.Actions[1]);
    }
  }
}
