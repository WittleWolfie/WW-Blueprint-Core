using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.UpgraderEx;
using BlueprintCore.Test.Asserts;
using System.Linq;
using Xunit;
using static BlueprintCore.Test.TestData;

namespace BlueprintCore.Test.Actions.Builder.UpgraderEx
{
  public class ActionsBuilderUpgraderExTest : TestBase
  {
    //----- Kingmaker.EntitySystem.Persistence.Versioning.*UpgraderOnlyActions -----//

    [Fact]
    public void TestAddFactIfEtudePlaying()
    {
      var actions =
          ActionsBuilder.New()
              .AddFactIfEtudePlaying(
                  AddFactIfEtudePlaying.TargetType.AllCompanions,
                  BuffGuid,
                  EtudeGuid)
              .Build();

      Assert.Single(actions.Actions);
      var addFact = (AddFactIfEtudePlaying)actions.Actions[0];
      ElementAsserts.IsValid(addFact);

      Assert.Equal(AddFactIfEtudePlaying.TargetType.AllCompanions, addFact.m_Target);
      Assert.Equal(Buff.ToReference<BlueprintUnitFactReference>(), addFact.m_Fact);
      Assert.Equal(TestEtude.ToReference<BlueprintEtudeReference>(), addFact.m_Etude);
    }

    [Fact]
    public void FixKingdomSystemBuffsAndStats()
    {
      var actions = ActionsBuilder.New().FixKingdomSystemBuffsAndStats().Build();

      Assert.Single(actions.Actions);
      var fix = (FixKingdomSystemBuffsAndStats)actions.Actions[0];
      ElementAsserts.IsValid(fix);

      Assert.Equal(1f, fix.m_StatPerFinances);
      Assert.Equal(10f, fix.m_StatPerMaterials);
      Assert.Equal(25f, fix.m_StatPerFavors);
      Assert.Equal(5f, fix.m_UnitExpDiplomacyCoefficient);
      Assert.Equal(1.1f, fix.m_DiplomacyBonusCoefficient);
    }

    [Fact]
    public void FixKingdomSystemBuffsAndStats_WithOptionalValues()
    {
      var actions =
          ActionsBuilder.New()
              .FixKingdomSystemBuffsAndStats(
                  statPerFinances: 2f,
                  statPerMaterials: 20f,
                  statPerFavors: 50f,
                  expDiplomacyCoefficient: 10f,
                  diplomacyBonusCoefficient: 2.2f)
              .Build();

      Assert.Single(actions.Actions);
      var fix = (FixKingdomSystemBuffsAndStats)actions.Actions[0];
      ElementAsserts.IsValid(fix);

      Assert.Equal(2f, fix.m_StatPerFinances);
      Assert.Equal(20f, fix.m_StatPerMaterials);
      Assert.Equal(50f, fix.m_StatPerFavors);
      Assert.Equal(10f, fix.m_UnitExpDiplomacyCoefficient);
      Assert.Equal(2.2f, fix.m_DiplomacyBonusCoefficient);
    }

    [Fact]
    public void ReEnterScriptZone()
    {
      var actions =
          ActionsBuilder.New()
              .ReEnterScriptZone(new EntityReference { EntityNameInEditor = "script" })
              .Build();

      Assert.Single(actions.Actions);
      var reEnter = (ReenterScriptzone)actions.Actions[0];
      ElementAsserts.IsValid(reEnter);

      Assert.Equal("script", reEnter.m_ScriptZone.EntityNameInEditor);
    }

    [Fact]
    public void RefreshCrusadeLogistic()
    {
      var actions = ActionsBuilder.New().RefreshCrusadeLogistic().Build();

      Assert.Single(actions.Actions);
      var refresh = (RefreshCrusadeLogistic)actions.Actions[0];
      ElementAsserts.IsValid(refresh);
    }

    [Fact]
    public void RefreshSettingsPreset()
    {
      var actions = ActionsBuilder.New().RefreshSettingsPreset().Build();

      Assert.Single(actions.Actions);
      var refresh = (RefreshSettingsPreset)actions.Actions[0];
      ElementAsserts.IsValid(refresh);
    }

    [Fact]
    public void RemoveFact()
    {
      var actions = ActionsBuilder.New().RemoveFact(BuffGuid, AbilityGuid).Build();

      Assert.Single(actions.Actions);
      var removeFact =
          (Kingmaker.EntitySystem.Persistence.Versioning.PlayerUpgraderOnlyActions.RemoveFact)
              actions.Actions[0];
      ElementAsserts.IsValid(removeFact);

      Assert.Equal(Buff.ToReference<BlueprintUnitFactReference>(), removeFact.m_Fact);

      Assert.Single(removeFact.m_AdditionalExceptHasFacts);
      Assert.Contains(
          TestAbility.ToReference<BlueprintUnitFactReference>(), removeFact.m_AdditionalExceptHasFacts);
    }

    [Fact]
    public void ResetMinDifficulty()
    {
      var actions = ActionsBuilder.New().ResetMinDifficulty().Build();

      Assert.Single(actions.Actions);
      var resetDifficulty = (ResetMinDifficulty)actions.Actions[0];
      ElementAsserts.IsValid(resetDifficulty);
    }

    [Fact]
    public void FixItemInInventory()
    {
      var actions = ActionsBuilder.New().FixItemInInventory(removeItem: ItemGuid).Build();

      Assert.Single(actions.Actions);
      var fix = (FixItemInInventory)actions.Actions[0];
      ElementAsserts.IsValid(fix);

      Assert.NotNull(fix.m_ToAdd);
      Assert.Equal(Item.ToReference<BlueprintItemReference>(), fix.m_ToRemove);
      Assert.False(fix.m_TryEquip);
    }

    [Fact]
    public void FixItemInInventory_EquipItem()
    {
      var actions =
          ActionsBuilder.New().FixItemInInventory(addItem: ItemGuid, equipItem: true).Build();

      Assert.Single(actions.Actions);
      var fix = (FixItemInInventory)actions.Actions[0];
      ElementAsserts.IsValid(fix);

      Assert.Equal(Item.ToReference<BlueprintItemReference>(), fix.m_ToAdd);
      Assert.NotNull(fix.m_ToRemove);
      Assert.True(fix.m_TryEquip);
    }

    [Fact]
    public void ReCreateOnLoad()
    {
      var actions = ActionsBuilder.New().ReCreateOnLoad().Build();

      Assert.Single(actions.Actions);
      var reCreate = (RecreateOnLoad)actions.Actions[0];
      ElementAsserts.IsValid(reCreate);
    }

    [Fact]
    public void SetAlignmentFromBlueprint()
    {
      var actions = ActionsBuilder.New().SetAlignmentFromBlueprint().Build();

      Assert.Single(actions.Actions);
      var setAlignment = (SetAlignmentFromBlueprint)actions.Actions[0];
      ElementAsserts.IsValid(setAlignment);
    }

    [Fact]
    public void SetHandsFromBlueprint()
    {
      var actions = ActionsBuilder.New().SetHandsFromBlueprint().Build();

      Assert.Single(actions.Actions);
      var setHands = (SetHandsFromBlueprint)actions.Actions[0];
      ElementAsserts.IsValid(setHands);
    }

    private void SetUpFeatureFromProgression()
    {
      Progression.LevelEntries = new Kingmaker.Blueprints.Classes.LevelEntry[]
      {
        new Kingmaker.Blueprints.Classes.LevelEntry
        {
          Level = 1,
          m_Features =
              new BlueprintFeatureBaseReference[]
              {
                TestFeature.ToReference<BlueprintFeatureBaseReference>(),
                FeatureSelection.ToReference<BlueprintFeatureBaseReference>()
              }
              .ToList()
        }
      };
      FeatureSelection.m_AllFeatures =
          new BlueprintFeatureReference[] { TestFeature.ToReference<BlueprintFeatureReference>() };
    }

    [Fact]
    public void AddFeatureFromProgression()
    {
      SetUpFeatureFromProgression();

      var actions =
          ActionsBuilder.New()
              .AddFeatureFromProgression(FeatureGuid, ProgressionGuid, 5)
              .Build();

      Assert.Single(actions.Actions);
      var addFeature = (AddFeatureFromProgression)actions.Actions[0];
      ElementAsserts.IsValid(addFeature);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), addFeature.m_Feature);
      Assert.Equal(
          Progression.ToReference<BlueprintProgressionReference>(), addFeature.m_Progression);
      Assert.Equal(5, addFeature.m_Level);
      Assert.NotNull(addFeature.m_Archetype);
      Assert.NotNull(addFeature.m_Selection);
      Assert.NotNull(addFeature.m_ExceptHasFeature);
    }

    [Fact]
    public void AddFeatureFromProgression_WithOptionalValues()
    {
      SetUpFeatureFromProgression();

      var actions =
          ActionsBuilder.New()
              .AddFeatureFromProgression(
                  FeatureGuid,
                  ProgressionGuid,
                  6,
                  archetype: ArchetypeGuid,
                  selection: FeatureSelectionGuid,
                  ignoreFeature: ExtraFeatureGuid)
              .Build();

      Assert.Single(actions.Actions);
      var addFeature = (AddFeatureFromProgression)actions.Actions[0];
      ElementAsserts.IsValid(addFeature);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), addFeature.m_Feature);
      Assert.Equal(
          Progression.ToReference<BlueprintProgressionReference>(), addFeature.m_Progression);
      Assert.Equal(6, addFeature.m_Level);
      Assert.Equal(Archetype.ToReference<BlueprintArchetypeReference>(), addFeature.m_Archetype);
      Assert.Equal(
          FeatureSelection.ToReference<BlueprintFeatureSelectionReference>(),
          addFeature.m_Selection);
      Assert.Equal(
          ExtraFeature.ToReference<BlueprintFeatureReference>(), addFeature.m_ExceptHasFeature);
    }

    [Fact]
    public void ReCheckEtude()
    {
      var actions = ActionsBuilder.New().ReCheckEtude(EtudeGuid).Build();

      Assert.Single(actions.Actions);
      var reCheck = (RecheckEtude)actions.Actions[0];
      ElementAsserts.IsValid(reCheck);

      Assert.Equal(TestEtude.ToReference<BlueprintEtudeReference>(), reCheck.Etude);
      Assert.False(reCheck.m_RedoOnceTriggers);
    }

    [Fact]
    public void ReCheckEtude_redoAfterTrigger()
    {
      var actions = ActionsBuilder.New().ReCheckEtude(EtudeGuid, redoAfterTrigger: true).Build();

      Assert.Single(actions.Actions);
      var reCheck = (RecheckEtude)actions.Actions[0];
      ElementAsserts.IsValid(reCheck);

      Assert.Equal(TestEtude.ToReference<BlueprintEtudeReference>(), reCheck.Etude);
      Assert.True(reCheck.m_RedoOnceTriggers);
    }

    [Fact]
    public void RefreshAllArmyLeaders()
    {
      var actions = ActionsBuilder.New().RefreshAllArmyLeaders().Build();

      Assert.Single(actions.Actions);
      var refresh = (RefreshAllArmyLeaders)actions.Actions[0];
      ElementAsserts.IsValid(refresh);

      Assert.False(refresh.m_OnlyPlayerLeaders);
    }

    [Fact]
    public void RefreshAllArmyLeaders_OnlyPlayer()
    {
      var actions = ActionsBuilder.New().RefreshAllArmyLeaders(true).Build();

      Assert.Single(actions.Actions);
      var refresh = (RefreshAllArmyLeaders)actions.Actions[0];
      ElementAsserts.IsValid(refresh);

      Assert.True(refresh.m_OnlyPlayerLeaders);
    }

    [Fact]
    public void RemoveFeatureFromProgression()
    {
      SetUpFeatureFromProgression();

      var actions =
          ActionsBuilder.New()
              .RemoveFeatureFromProgression(FeatureGuid, ProgressionGuid, 5)
              .Build();

      Assert.Single(actions.Actions);
      var addFeature = (RemoveFeatureFromProgression)actions.Actions[0];
      ElementAsserts.IsValid(addFeature);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), addFeature.m_Feature);
      Assert.Equal(
          Progression.ToReference<BlueprintProgressionReference>(), addFeature.m_Progression);
      Assert.Equal(5, addFeature.m_Level);
      Assert.NotNull(addFeature.m_Archetype);
      Assert.NotNull(addFeature.m_ExceptHasFeature);
    }

    [Fact]
    public void RemoveFeatureFromProgression_WithOptionalValues()
    {
      SetUpFeatureFromProgression();

      var actions =
          ActionsBuilder.New()
              .RemoveFeatureFromProgression(
                  FeatureGuid,
                  ProgressionGuid,
                  6,
                  archetype: ArchetypeGuid,
                  ignoreFeature: ExtraFeatureGuid)
              .Build();

      Assert.Single(actions.Actions);
      var addFeature = (RemoveFeatureFromProgression)actions.Actions[0];
      ElementAsserts.IsValid(addFeature);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), addFeature.m_Feature);
      Assert.Equal(
          Progression.ToReference<BlueprintProgressionReference>(), addFeature.m_Progression);
      Assert.Equal(6, addFeature.m_Level);
      Assert.Equal(Archetype.ToReference<BlueprintArchetypeReference>(), addFeature.m_Archetype);
      Assert.Equal(
          ExtraFeature.ToReference<BlueprintFeatureReference>(), addFeature.m_ExceptHasFeature);
    }

    [Fact]
    public void ReplaceFeature()
    {
      var actions =
          ActionsBuilder.New()
              .ReplaceFeature(FeatureGuid, ExtraFeatureGuid, ProgressionGuid)
              .Build();

      Assert.Single(actions.Actions);
      var replaceFeature = (ReplaceFeature)actions.Actions[0];
      ElementAsserts.IsValid(replaceFeature);

      Assert.Equal(
          TestFeature.ToReference<BlueprintFeatureReference>(), replaceFeature.m_ToReplace);
      Assert.Equal(
          ExtraFeature.ToReference<BlueprintFeatureReference>(), replaceFeature.m_Replacement);
      Assert.Equal(
          Progression.ToReference<BlueprintProgressionReference>(),
          replaceFeature.m_FromProgression);
      Assert.NotNull(replaceFeature.m_ExceptHasFeature);
    }

    [Fact]
    public void ReplaceFeature_WithIgnoreFeature()
    {
      var actions =
          ActionsBuilder.New()
              .ReplaceFeature(
                  FeatureGuid, ExtraFeatureGuid, ProgressionGuid, ignoreFeature: ExtraFeatureGuid)
              .Build();

      Assert.Single(actions.Actions);
      var replaceFeature = (ReplaceFeature)actions.Actions[0];
      ElementAsserts.IsValid(replaceFeature);

      Assert.Equal(
          TestFeature.ToReference<BlueprintFeatureReference>(), replaceFeature.m_ToReplace);
      Assert.Equal(
          ExtraFeature.ToReference<BlueprintFeatureReference>(), replaceFeature.m_Replacement);
      Assert.Equal(
          Progression.ToReference<BlueprintProgressionReference>(),
          replaceFeature.m_FromProgression);
      Assert.Equal(
          ExtraFeature.ToReference<BlueprintFeatureReference>(), replaceFeature.m_ExceptHasFeature);
    }

    [Fact]
    public void RestartTacticalCombat()
    {
      var actions = ActionsBuilder.New().RestartTacticalCombat().Build();

      Assert.Single(actions.Actions);
      var restart = (RestartTacticalCombat)actions.Actions[0];
      ElementAsserts.IsValid(restart);
    }

    [Fact]
    public void SetSharedVendorTable()
    {
      var actions =
          ActionsBuilder.New()
              .SetSharedVendorTable(VendorTableGuid, TestUnit)
              .Build();

      Assert.Single(actions.Actions);
      var setVendorTable = (SetSharedVendorTable)actions.Actions[0];
      ElementAsserts.IsValid(setVendorTable);

      Assert.Equal(
          VendorTable.ToReference<BlueprintSharedVendorTableReference>(), setVendorTable.m_Table);
      Assert.Equal(TestUnit, setVendorTable.m_Unit);
    }

    [Fact]
    public void ForceStartEtude()
    {
      var actions = ActionsBuilder.New().ForceStartEtude(EtudeGuid).Build();

      Assert.Single(actions.Actions);
      var startEtude = (StartEtudeForced)actions.Actions[0];
      ElementAsserts.IsValid(startEtude);

      Assert.Equal(TestEtude.ToReference<BlueprintEtudeReference>(), startEtude.Etude);
    }

    [Fact]
    public void UnStartEtude()
    {
      var actions = ActionsBuilder.New().UnStartEtude(EtudeGuid).Build();

      Assert.Single(actions.Actions);
      var unStartEtude = (UnStartEtude)actions.Actions[0];
      ElementAsserts.IsValid(unStartEtude);

      Assert.Equal(TestEtude.ToReference<BlueprintEtudeReference>(), unStartEtude.Etude);
    }
  }
}
