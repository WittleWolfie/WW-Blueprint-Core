using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.AreaEx;
using BlueprintCore.Test.Asserts;
using Xunit;
using static BlueprintCore.Test.TestData;

namespace BlueprintCore.Test.Actions.Builder.AreaEx
{
  public class ActionsBuilderAreaExTest : TestBase
  {
    //----- Kingmaker.Dungeon.Actions -----//

    [Fact]
    public void CreateImportedCompanion()
    {
      var actions = ActionsBuilder.New().CreateImportedCompanion(5).Build();

      Assert.Single(actions.Actions);
      var createCompanion = (ActionCreateImportedCompanion)actions.Actions[0];
      ElementAsserts.IsValid(createCompanion);

      Assert.Equal(5, createCompanion.Index);
    }

    [Fact]
    public void TeleportToLastDungeonStageEntrance()
    {
      var actions = ActionsBuilder.New().TeleportToLastDungeonStageEntrance().Build();

      Assert.Single(actions.Actions);
      var teleport = (ActionEnterToDungeon)actions.Actions[0];
      ElementAsserts.IsValid(teleport);

      Assert.Equal(1, teleport.FirstStage);
    }

    [Fact]
    public void TeleportToLastDungeonStageEntrance_WithMinStage()
    {
      var actions = ActionsBuilder.New().TeleportToLastDungeonStageEntrance(3).Build();

      Assert.Single(actions.Actions);
      var teleport = (ActionEnterToDungeon)actions.Actions[0];
      ElementAsserts.IsValid(teleport);

      Assert.Equal(3, teleport.FirstStage);
    }

    [Fact]
    public void EnterNextDungeonStage()
    {
      var actions = ActionsBuilder.New().EnterNextDungeonStage().Build();

      Assert.Single(actions.Actions);
      var nextStage = (ActionGoDeeperIntoDungeon)actions.Actions[0];
      ElementAsserts.IsValid(nextStage);
    }

    [Fact]
    public void IncrementDungeonStage()
    {
      var actions = ActionsBuilder.New().IncrementDungeonStage().Build();

      Assert.Single(actions.Actions);
      var increment = (ActionIncreaseDungeonStage)actions.Actions[0];
      ElementAsserts.IsValid(increment);
    }

    [Fact]
    public void SetDungeonStage()
    {
      var actions = ActionsBuilder.New().SetDungeonStage().Build();

      Assert.Single(actions.Actions);
      var setStage = (ActionSetDungeonStage)actions.Actions[0];
      ElementAsserts.IsValid(setStage);

      Assert.Equal(1, setStage.Stage);
    }

    [Fact]
    public void SetDungeonStage_WithStage()
    {
      var actions = ActionsBuilder.New().SetDungeonStage(2).Build();

      Assert.Single(actions.Actions);
      var setStage = (ActionSetDungeonStage)actions.Actions[0];
      ElementAsserts.IsValid(setStage);

      Assert.Equal(2, setStage.Stage);
    }

    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

    [Fact]
    public void ChangeAreaEntrance()
    {
      var actions =
          ActionsBuilder.New()
              .ChangeAreaEntrance(GlobalMapPointGuid, AreaEnterPointGuid)
              .Build();

      Assert.Single(actions.Actions);
      var changeEntrance = (AreaEntranceChange)actions.Actions[0];
      ElementAsserts.IsValid(changeEntrance);

      Assert.Equal(
          GlobalMapPoint.ToReference<BlueprintGlobalMapPoint.Reference>(),
          changeEntrance.m_Location);

      Assert.Equal(
          AreaEnterPoint.ToReference<BlueprintAreaEnterPointReference>(),
          changeEntrance.m_NewEntrance);
    }

    [Fact]
    public void ChangeCurrentAreaName()
    {
      var name = new LocalizedString { Key = "name" };

      var actions = ActionsBuilder.New().ChangeCurrentAreaName(name).Build();

      Assert.Single(actions.Actions);
      var changeName = (ChangeCurrentAreaName)actions.Actions[0];
      ElementAsserts.IsValid(changeName);

      Assert.Equal(name, changeName.NewName);
      Assert.False(changeName.RestoreDefault);
    }

    [Fact]
    public void ResetCurrentAreaName()
    {
      var actions = ActionsBuilder.New().ResetCurrentAreaName().Build();

      Assert.Single(actions.Actions);
      var changeName = (ChangeCurrentAreaName)actions.Actions[0];
      ElementAsserts.IsValid(changeName);

      Assert.True(changeName.RestoreDefault);
    }

    [Fact]
    public void AddCampingEncounter()
    {
      var actions = ActionsBuilder.New().AddCampingEncounter(CampingEncounterGuid).Build();

      Assert.Single(actions.Actions);
      var addEncounter = (AddCampingEncounter)actions.Actions[0];
      ElementAsserts.IsValid(addEncounter);

      Assert.Equal(
          CampingEncounter.ToReference<BlueprintCampingEncounterReference>(),
          addEncounter.m_Encounter);
    }

    [Fact]
    public void DestroyMapObject()
    {
      var actions = ActionsBuilder.New().DestroyMapObject(TestTrap).Build();

      Assert.Single(actions.Actions);
      var destroy = (DestroyMapObject)actions.Actions[0];
      ElementAsserts.IsValid(destroy);

      Assert.Equal(TestTrap, destroy.MapObject);
    }
  }
}
