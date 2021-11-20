using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DLC;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Xunit;

namespace BlueprintCore.Test.Blueprints.Configurators
{
  [Collection("Harmony")]
  public abstract class BaseBlueprintConfiguratorTest<T, TBuilder> : TestBase
      where T : BlueprintScriptableObject
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
    // Serves as the guid for the primary test blueprint. Concrete child classes must instantiate
    // create and register a blueprint using this guid;
    protected static readonly string Guid = "137f7548-e57f-4e4a-8d76-7f2d174c6d5d";

    /** Creates and returns a configurator of type TBuilder. */
    protected abstract TBuilder GetConfigurator(string guid);

    [Fact]
    public void AddComponent_WithInit()
    {
      GetConfigurator(Guid).AddComponent<DlcCondition>(c => c.m_HideInstead = true).Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var component = blueprint.GetComponent<DlcCondition>();
      Assert.NotNull(component);

      Assert.True(component.m_HideInstead);
    }

    //----- Start: FactContextActions

    [Fact]
    public void FactContextActions()
    {
      GetConfigurator(Guid)
          .FactContextActions(
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
    public void FactContextActions_WithActivatedOnly()
    {
      GetConfigurator(Guid)
          .FactContextActions(onActivated: ActionsBuilder.New().MeleeAttack().MeleeAttack())
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
    public void FactContextActions_WithDeactivatedOnly()
    {
      GetConfigurator(Guid)
          .FactContextActions(onDeactivated: ActionsBuilder.New().MeleeAttack())
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
    public void FactContextActions_WithNewRoundOnly()
    {
      GetConfigurator(Guid)
          .FactContextActions(onNewRound: ActionsBuilder.New().BreakFree())
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
    public void FactContextActions_WithMerge()
    {
      // First pass
      GetConfigurator(Guid)
          .FactContextActions(
              onActivated: ActionsBuilder.New().MeleeAttack().MeleeAttack(),
              onDeactivated: ActionsBuilder.New().MeleeAttack(),
              onNewRound: ActionsBuilder.New().BreakFree())
          .Configure();

      GetConfigurator(Guid)
          .FactContextActions(
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
