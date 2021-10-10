using System;
using System.Collections.Generic;
using System.Linq;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Actions.Builder.MetaEx;
using BlueprintCore.Tests.Asserts;
using BlueprintCore.Utils;
using Kingmaker.Achievements.Actions;
using Kingmaker.Armies;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Armies.Components;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Crusade.GlobalMagic;
using Kingmaker.Crusade.GlobalMagic.Actions;
using Kingmaker.Crusade.GlobalMagic.Actions.DamageLogic;
using Kingmaker.Crusade.GlobalMagic.Actions.SummonLogics;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.Dungeon.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Persistence.Versioning.PlayerUpgraderOnlyActions;
using Kingmaker.EntitySystem.Persistence.Versioning.UnitUpgraderOnlyActions;
using Kingmaker.EntitySystem.Persistence.Versioning.UpgraderOnlyActions;
using Kingmaker.Enums;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Globalmap.State;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Xunit;

namespace BlueprintCore.Tests.Actions
{
  public class ActionListBuilderMetaExTest : ActionListBuilderTestBase
  {
    //----- Kingmaker.Achievements.Actions -----//

    [Fact]
    public void IncrementAchievement()
    {
      var actions =
          ActionListBuilder.New()
              .IncrementAchievement(AchievementGuid)
              .Build();

      Assert.Single(actions.Actions);
      var increment = (ActionAchievementIncrementCounter)actions.Actions[0];
      ElementAsserts.IsValid(increment);

      Assert.Equal(Achievement.ToReference<AchievementDataReference>(), increment.m_Achievement);
    }

    [Fact]
    public void UnlockAchievement()
    {
      var actions =
          ActionListBuilder.New()
              .UnlockAchievement(AchievementGuid)
              .Build();

      Assert.Single(actions.Actions);
      var unlock = (ActionAchievementUnlock)actions.Actions[0];
      ElementAsserts.IsValid(unlock);

      Assert.Equal(Achievement.ToReference<AchievementDataReference>(), unlock.m_Achievement);
    }

    //----- Kingmaker.Crusade.GlobalMagic.Actions

    [Fact]
    public void BuffSquad()
    {
      var actions =
          ActionListBuilder.New()
              .BuffSquad(
                  BuffGuid,
                  new GlobalMagicValue { m_SingleValue = 3 },
                  new SquadFilter { Properties = ArmyProperties.Armored })
              .Build();

      Assert.Single(actions.Actions);
      var buffSquad = (AddBuffToSquad)actions.Actions[0];
      ElementAsserts.IsValid(buffSquad);

      Assert.Equal(Buff.ToReference<BlueprintBuffReference>(), buffSquad.m_Buff);
      Assert.Equal(3, buffSquad.m_HoursDuration.m_SingleValue);
      Assert.Equal(ArmyProperties.Armored, buffSquad.m_Filter.Properties);
    }

    [Fact]
    public void ChangeArmyMorale()
    {
      var actions =
          ActionListBuilder.New()
              .ChangeArmyMorale(
                  new GlobalMagicValue { m_SingleValue = 5 },
                  new GlobalMagicValue { m_SingleValue = 2 })
              .Build();

      Assert.Single(actions.Actions);
      var changeMorale = (ChangeArmyMorale)actions.Actions[0];
      ElementAsserts.IsValid(changeMorale);

      Assert.Equal(5, changeMorale.m_Duration.m_SingleValue);
      Assert.Equal(2, changeMorale.m_ChangeValue.m_SingleValue);
    }

    [Fact]
    public void FakeSkipTime()
    {
      var actions =
          ActionListBuilder.New().FakeSkipTime(new GlobalMagicValue { m_SingleValue = 3 }).Build();

      Assert.Single(actions.Actions);
      var skipTime = (FakeSkipTime)actions.Actions[0];
      ElementAsserts.IsValid(skipTime);

      Assert.Equal(3, skipTime.m_SkipDays.m_SingleValue);
    }

    [Fact]
    public void GainArmyDamage()
    {
      var actions =
          ActionListBuilder.New()
              .GainArmyDamage(
                  new SquadFilter { Properties = ArmyProperties.Flying },
                  new GlobalMagicValue { m_SingleValue = 7 })
              .Build();

      Assert.Single(actions.Actions);
      var gainDmg = (GainDiceArmyDamage)actions.Actions[0];
      ElementAsserts.IsValid(gainDmg);

      Assert.Equal(ArmyProperties.Flying, gainDmg.m_Filter.Properties);
      Assert.Equal(7, gainDmg.m_DiceValue.m_SingleValue);
    }

    [Fact]
    public void RemoveUnitsByExp()
    {
      var actions =
          ActionListBuilder.New()
              .RemoveUnitsByExp(
                  new SquadFilter { Properties = ArmyProperties.GrandTier },
                  new GlobalMagicValue { m_SingleValue = 2 })
              .Build();

      Assert.Single(actions.Actions);
      var removeUnits = (RemoveUnitsByExp)actions.Actions[0];
      ElementAsserts.IsValid(removeUnits);

      Assert.Equal(ArmyProperties.GrandTier, removeUnits.m_Filter.Properties);
      Assert.Equal(2, removeUnits.m_ExpValue.m_SingleValue);
    }

    [Fact]
    public void GainGlobalSpell()
    {
      var actions = ActionListBuilder.New().GainGlobalSpell(GlobalSpellGuid).Build();

      Assert.Single(actions.Actions);
      var gainSpell = (GainGlobalMagicSpell)actions.Actions[0];
      ElementAsserts.IsValid(gainSpell);

      Assert.Equal(
          GlobalSpell.ToReference<BlueprintGlobalMagicSpell.Reference>(), gainSpell.m_Spell);
    }

    [Fact]
    public void PutGlobalSpellOnCooldown()
    {
      var actions = ActionListBuilder.New().PutGlobalSpellOnCooldown(GlobalSpellGuid).Build();

      Assert.Single(actions.Actions);
      var activateCooldown = (ManuallySetGlobalSpellCooldown)actions.Actions[0];
      ElementAsserts.IsValid(activateCooldown);

      Assert.Equal(
          GlobalSpell.ToReference<BlueprintGlobalMagicSpell.Reference>(), activateCooldown.m_Spell);
    }

    [Fact]
    public void GlobalTeleport()
    {
      var actions =
          ActionListBuilder.New().GlobalTeleport(ActionListBuilder.New().MeleeAttack()).Build();

      Assert.Single(actions.Actions);
      var teleport = (OpenTeleportationInterface)actions.Actions[0];
      ElementAsserts.IsValid(teleport);

      Assert.Single(teleport.m_OnTeleportActions.Actions);
      Assert.IsType<ContextActionMeleeAttack>(teleport.m_OnTeleportActions.Actions[0]);
    }

    [Fact]
    public void RemoveGlobalSpell()
    {
      var actions = ActionListBuilder.New().RemoveGlobalSpell(GlobalSpellGuid).Build();

      Assert.Single(actions.Actions);
      var removespell = (RemoveGlobalMagicSpell)actions.Actions[0];
      ElementAsserts.IsValid(removespell);

      Assert.Equal(
          GlobalSpell.ToReference<BlueprintGlobalMagicSpell.Reference>(), removespell.m_Spell);
    }

    [Fact]
    public void RestoreLeaderMana()
    {
      var actions =
          ActionListBuilder.New()
              .RestoreLeaderMana(new GlobalMagicValue { m_SingleValue = 5 })
              .Build();

      Assert.Single(actions.Actions);
      var restoreMana = (RepairLeaderMana)actions.Actions[0];
      ElementAsserts.IsValid(restoreMana);

      Assert.Equal(5, restoreMana.m_Value.m_SingleValue);
    }

    [Fact]
    public void SummonMoreUnits()
    {
      var actions =
          ActionListBuilder.New()
              .SummonMoreUnits(new GlobalMagicValue { m_SingleValue = 6 })
              .Build();

      Assert.Single(actions.Actions);
      var summon = (SummonExistUnits)actions.Actions[0];
      ElementAsserts.IsValid(summon);

      Assert.Equal(6, summon.m_SumExpCost.m_SingleValue);
    }

    [Fact]
    public void SummonRandomGroup()
    {
      var firstPair =
          new SummonRandomGroup.SummonUnitPair
          {
            Count = new GlobalMagicValue { m_SingleValue = 1 }
          };
      var secondPair =
          new SummonRandomGroup.SummonUnitPair
          {
            Count = new GlobalMagicValue { m_SingleValue = 2 }
          };
      var thirdPair =
          new SummonRandomGroup.SummonUnitPair
          {
            Count = new GlobalMagicValue { m_SingleValue = 3 }
          };

      var actions =
          ActionListBuilder.New()
              .SummonRandomGroup(
                  new SummonRandomGroup.RandomGroup
                  {
                    Units = new SummonRandomGroup.SummonUnitPair[] { firstPair, secondPair }
                  },
                  new SummonRandomGroup.RandomGroup
                  {
                    Units = new SummonRandomGroup.SummonUnitPair[] { thirdPair }
                  })
              .Build();

      Assert.Single(actions.Actions);
      var summon = (SummonRandomGroup)actions.Actions[0];
      ElementAsserts.IsValid(summon);

      Assert.Equal(2, summon.m_RandomGroups.Length);

      Assert.Equal(2, summon.m_RandomGroups[0].Units.Length);
      Assert.Contains(firstPair, summon.m_RandomGroups[0].Units);
      Assert.Contains(secondPair, summon.m_RandomGroups[0].Units);

      Assert.Single(summon.m_RandomGroups[1].Units);
      Assert.Contains(thirdPair, summon.m_RandomGroups[1].Units);
    }

    [Fact]
    public void TeleportArmy()
    {
      var actions = ActionListBuilder.New().TeleportArmy().Build();

      Assert.Single(actions.Actions);
      var teleport = (TeleportArmyAction)actions.Actions[0];
      ElementAsserts.IsValid(teleport);
    }

    //----- Kingmaker.Dungeon.Actions -----//

    [Fact]
    public void CreateImportedCompanion()
    {
      var actions = ActionListBuilder.New().CreateImportedCompanion(5).Build();

      Assert.Single(actions.Actions);
      var createCompanion = (ActionCreateImportedCompanion)actions.Actions[0];
      ElementAsserts.IsValid(createCompanion);

      Assert.Equal(5, createCompanion.Index);
    }

    [Fact]
    public void TeleportToLastDungeonStageEntrance()
    {
      var actions = ActionListBuilder.New().TeleportToLastDungeonStageEntrance().Build();

      Assert.Single(actions.Actions);
      var teleport = (ActionEnterToDungeon)actions.Actions[0];
      ElementAsserts.IsValid(teleport);

      Assert.Equal(1, teleport.FirstStage);
    }

    [Fact]
    public void TeleportToLastDungeonStageEntrance_WithMinStage()
    {
      var actions = ActionListBuilder.New().TeleportToLastDungeonStageEntrance(3).Build();

      Assert.Single(actions.Actions);
      var teleport = (ActionEnterToDungeon)actions.Actions[0];
      ElementAsserts.IsValid(teleport);

      Assert.Equal(3, teleport.FirstStage);
    }

    [Fact]
    public void EnterNextDungeonStage()
    {
      var actions = ActionListBuilder.New().EnterNextDungeonStage().Build();

      Assert.Single(actions.Actions);
      var nextStage = (ActionGoDeeperIntoDungeon)actions.Actions[0];
      ElementAsserts.IsValid(nextStage);
    }

    [Fact]
    public void IncrementDungeonStage()
    {
      var actions = ActionListBuilder.New().IncrementDungeonStage().Build();

      Assert.Single(actions.Actions);
      var increment = (ActionIncreaseDungeonStage)actions.Actions[0];
      ElementAsserts.IsValid(increment);
    }

    [Fact]
    public void SetDungeonStage()
    {
      var actions = ActionListBuilder.New().SetDungeonStage().Build();

      Assert.Single(actions.Actions);
      var setStage = (ActionSetDungeonStage)actions.Actions[0];
      ElementAsserts.IsValid(setStage);

      Assert.Equal(1, setStage.Stage);
    }

    [Fact]
    public void SetDungeonStage_WithStage()
    {
      var actions = ActionListBuilder.New().SetDungeonStage(2).Build();

      Assert.Single(actions.Actions);
      var setStage = (ActionSetDungeonStage)actions.Actions[0];
      ElementAsserts.IsValid(setStage);

      Assert.Equal(2, setStage.Stage);
    }


    //----- Kingmaker.EntitySystem.Persistence.Versioning.*UpgraderOnlyActions -----//

    [Fact]
    public void AddFactIfEtudePlaying_()
    {
      var actions =
          ActionListBuilder.New()
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
      Assert.Equal(Etude.ToReference<BlueprintEtudeReference>(), addFact.m_Etude);
    }

    [Fact]
    public void FixKingdomSystemBuffsAndStats()
    {
      var actions = ActionListBuilder.New().FixKingdomSystemBuffsAndStats().Build();

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
          ActionListBuilder.New()
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
          ActionListBuilder.New()
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
      var actions = ActionListBuilder.New().RefreshCrusadeLogistic().Build();

      Assert.Single(actions.Actions);
      var refresh = (RefreshCrusadeLogistic)actions.Actions[0];
      ElementAsserts.IsValid(refresh);
    }

    [Fact]
    public void RefreshSettingsPreset()
    {
      var actions = ActionListBuilder.New().RefreshSettingsPreset().Build();

      Assert.Single(actions.Actions);
      var refresh = (RefreshSettingsPreset)actions.Actions[0];
      ElementAsserts.IsValid(refresh);
    }

    [Fact]
    public void RemoveFact()
    {
      var actions = ActionListBuilder.New().RemoveFact(BuffGuid, AbilityGuid).Build();

      Assert.Single(actions.Actions);
      var removeFact =
          (Kingmaker.EntitySystem.Persistence.Versioning.PlayerUpgraderOnlyActions.RemoveFact)
              actions.Actions[0];
      ElementAsserts.IsValid(removeFact);

      Assert.Equal(Buff.ToReference<BlueprintUnitFactReference>(), removeFact.m_Fact);

      Assert.Single(removeFact.m_AdditionalExceptHasFacts);
      Assert.Contains(
          Ability.ToReference<BlueprintUnitFactReference>(), removeFact.m_AdditionalExceptHasFacts);
    }

    [Fact]
    public void ResetMinDifficulty()
    {
      var actions = ActionListBuilder.New().ResetMinDifficulty().Build();

      Assert.Single(actions.Actions);
      var resetDifficulty = (ResetMinDifficulty)actions.Actions[0];
      ElementAsserts.IsValid(resetDifficulty);
    }

    [Fact]
    public void FixItemInInventory()
    {
      var actions = ActionListBuilder.New().FixItemInInventory(removeItem: ItemGuid).Build();

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
          ActionListBuilder.New().FixItemInInventory(addItem: ItemGuid, equipItem: true).Build();

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
      var actions = ActionListBuilder.New().ReCreateOnLoad().Build();

      Assert.Single(actions.Actions);
      var reCreate = (RecreateOnLoad)actions.Actions[0];
      ElementAsserts.IsValid(reCreate);
    }

    [Fact]
    public void SetAlignmentFromBlueprint()
    {
      var actions = ActionListBuilder.New().SetAlignmentFromBlueprint().Build();

      Assert.Single(actions.Actions);
      var setAlignment = (SetAlignmentFromBlueprint)actions.Actions[0];
      ElementAsserts.IsValid(setAlignment);
    }

    [Fact]
    public void SetHandsFromBlueprint()
    {
      var actions = ActionListBuilder.New().SetHandsFromBlueprint().Build();

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
                Feature.ToReference<BlueprintFeatureBaseReference>(),
                FeatureSelection.ToReference<BlueprintFeatureBaseReference>()
              }
              .ToList()
        }
      };
      FeatureSelection.m_AllFeatures =
          new BlueprintFeatureReference[] { Feature.ToReference<BlueprintFeatureReference>() };
    }

    [Fact]
    public void AddFeatureFromProgression()
    {
      SetUpFeatureFromProgression();

      var actions =
          ActionListBuilder.New()
              .AddFeatureFromProgression(FeatureGuid, ProgressionGuid, 5)
              .Build();

      Assert.Single(actions.Actions);
      var addFeature = (AddFeatureFromProgression)actions.Actions[0];
      ElementAsserts.IsValid(addFeature);

      Assert.Equal(Feature.ToReference<BlueprintFeatureReference>(), addFeature.m_Feature);
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
          ActionListBuilder.New()
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

      Assert.Equal(Feature.ToReference<BlueprintFeatureReference>(), addFeature.m_Feature);
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
      var actions = ActionListBuilder.New().ReCheckEtude(EtudeGuid).Build();

      Assert.Single(actions.Actions);
      var reCheck = (RecheckEtude)actions.Actions[0];
      ElementAsserts.IsValid(reCheck);

      Assert.Equal(Etude.ToReference<BlueprintEtudeReference>(), reCheck.Etude);
      Assert.False(reCheck.m_RedoOnceTriggers);
    }

    [Fact]
    public void ReCheckEtude_redoAfterTrigger()
    {
      var actions = ActionListBuilder.New().ReCheckEtude(EtudeGuid, redoAfterTrigger: true).Build();

      Assert.Single(actions.Actions);
      var reCheck = (RecheckEtude)actions.Actions[0];
      ElementAsserts.IsValid(reCheck);

      Assert.Equal(Etude.ToReference<BlueprintEtudeReference>(), reCheck.Etude);
      Assert.True(reCheck.m_RedoOnceTriggers);
    }

    [Fact]
    public void RefreshAllArmyLeaders()
    {
      var actions = ActionListBuilder.New().RefreshAllArmyLeaders().Build();

      Assert.Single(actions.Actions);
      var refresh = (RefreshAllArmyLeaders)actions.Actions[0];
      ElementAsserts.IsValid(refresh);

      Assert.False(refresh.m_OnlyPlayerLeaders);
    }

    [Fact]
    public void RefreshAllArmyLeaders_OnlyPlayer()
    {
      var actions = ActionListBuilder.New().RefreshAllArmyLeaders(true).Build();

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
          ActionListBuilder.New()
              .RemoveFeatureFromProgression(FeatureGuid, ProgressionGuid, 5)
              .Build();

      Assert.Single(actions.Actions);
      var addFeature = (RemoveFeatureFromProgression)actions.Actions[0];
      ElementAsserts.IsValid(addFeature);

      Assert.Equal(Feature.ToReference<BlueprintFeatureReference>(), addFeature.m_Feature);
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
          ActionListBuilder.New()
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

      Assert.Equal(Feature.ToReference<BlueprintFeatureReference>(), addFeature.m_Feature);
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
          ActionListBuilder.New()
              .ReplaceFeature(FeatureGuid, ExtraFeatureGuid, ProgressionGuid)
              .Build();

      Assert.Single(actions.Actions);
      var replaceFeature = (ReplaceFeature)actions.Actions[0];
      ElementAsserts.IsValid(replaceFeature);

      Assert.Equal(
          Feature.ToReference<BlueprintFeatureReference>(), replaceFeature.m_ToReplace);
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
          ActionListBuilder.New()
              .ReplaceFeature(
                  FeatureGuid, ExtraFeatureGuid, ProgressionGuid, ignoreFeature: ExtraFeatureGuid)
              .Build();

      Assert.Single(actions.Actions);
      var replaceFeature = (ReplaceFeature)actions.Actions[0];
      ElementAsserts.IsValid(replaceFeature);

      Assert.Equal(
          Feature.ToReference<BlueprintFeatureReference>(), replaceFeature.m_ToReplace);
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
      var actions = ActionListBuilder.New().RestartTacticalCombat().Build();

      Assert.Single(actions.Actions);
      var restart = (RestartTacticalCombat)actions.Actions[0];
      ElementAsserts.IsValid(restart);
    }

    [Fact]
    public void SetSharedVendorTable()
    {
      var actions =
          ActionListBuilder.New()
              .SetSharedVendorTable(VendorTableGuid, ClickedUnit)
              .Build();

      Assert.Single(actions.Actions);
      var setVendorTable = (SetSharedVendorTable)actions.Actions[0];
      ElementAsserts.IsValid(setVendorTable);

      Assert.Equal(
          VendorTable.ToReference<BlueprintSharedVendorTableReference>(), setVendorTable.m_Table);
      Assert.Equal(ClickedUnit, setVendorTable.m_Unit);
    }

    [Fact]
    public void ForceStartEtude()
    {
      var actions = ActionListBuilder.New().ForceStartEtude(EtudeGuid).Build();

      Assert.Single(actions.Actions);
      var startEtude = (StartEtudeForced)actions.Actions[0];
      ElementAsserts.IsValid(startEtude);

      Assert.Equal(Etude.ToReference<BlueprintEtudeReference>(), startEtude.Etude);
    }

    [Fact]
    public void UnStartEtude()
    {
      var actions = ActionListBuilder.New().UnStartEtude(EtudeGuid).Build();

      Assert.Single(actions.Actions);
      var unStartEtude = (UnStartEtude)actions.Actions[0];
      ElementAsserts.IsValid(unStartEtude);

      Assert.Equal(Etude.ToReference<BlueprintEtudeReference>(), unStartEtude.Etude);
    }

    //----- -----//

    [Fact]
    public void ChangeAlignment()
    {
      var actions =
          ActionListBuilder.New().ChangeAlignment(ClickedUnit, Alignment.LawfulEvil).Build();

      Assert.Single(actions.Actions);
      var changeAlignment = (ChangeAlignment)actions.Actions[0];
      ElementAsserts.IsValid(changeAlignment);

      Assert.Equal(ClickedUnit, changeAlignment.Unit);
      Assert.Equal(Alignment.LawfulEvil, changeAlignment.Alignment);
    }

    [Fact]
    public void ChangePlayerAlignment()
    {
      var actions = ActionListBuilder.New().ChangePlayerAlignment(Alignment.ChaoticGood).Build();

      Assert.Single(actions.Actions);
      var changeAlignment = (ChangePlayerAlignment)actions.Actions[0];
      ElementAsserts.IsValid(changeAlignment);

      Assert.Equal(Alignment.ChaoticGood, changeAlignment.TargetAlignment);
      Assert.False(changeAlignment.CanUnlockAlignment);
    }

    [Fact]
    public void ChangePlayerAlignment_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .ChangePlayerAlignment(Alignment.TrueNeutral, unlockAlignment: true)
              .Build();

      Assert.Single(actions.Actions);
      var changeAlignment = (ChangePlayerAlignment)actions.Actions[0];
      ElementAsserts.IsValid(changeAlignment);

      Assert.Equal(Alignment.TrueNeutral, changeAlignment.TargetAlignment);
      Assert.True(changeAlignment.CanUnlockAlignment);
    }

    [Fact]
    public void ChangeAreaEntrance()
    {
      var actions =
          ActionListBuilder.New()
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

      var actions = ActionListBuilder.New().ChangeCurrentAreaName(name).Build();

      Assert.Single(actions.Actions);
      var changeName = (ChangeCurrentAreaName)actions.Actions[0];
      ElementAsserts.IsValid(changeName);

      Assert.Equal(name, changeName.NewName);
      Assert.False(changeName.RestoreDefault);
    }

    [Fact]
    public void ResetCurrentAreaName()
    {
      var actions = ActionListBuilder.New().ResetCurrentAreaName().Build();

      Assert.Single(actions.Actions);
      var changeName = (ChangeCurrentAreaName)actions.Actions[0];
      ElementAsserts.IsValid(changeName);

      Assert.True(changeName.RestoreDefault);
    }

    [Fact]
    public void CreateCrusaderArmy()
    {
      var actions =
          ActionListBuilder.New().CreateCrusaderArmy(ArmyGuid, GlobalMapPointGuid).Build();

      Assert.Single(actions.Actions);
      var createArmy = (CreateArmy)actions.Actions[0];
      ElementAsserts.IsValid(createArmy);

      Assert.Equal(ArmyFaction.Crusaders, createArmy.Faction);
      Assert.Equal(Army.ToReference<BlueprintArmyPreset.Reference>(), createArmy.Preset);
      Assert.Equal(
          GlobalMapPoint.ToReference<BlueprintGlobalMapPoint.Reference>(), createArmy.Location);
      Assert.Equal(TravelLogicType.None, createArmy.m_MoveTarget);

      Assert.Equal(60, createArmy.MovementPoints);
      Assert.Equal(1f, createArmy.m_ArmySpeed);
      Assert.False(createArmy.m_ApplyRecruitIncrease);

      Assert.False(createArmy.WithLeader);
      Assert.NotNull(createArmy.ArmyLeader);

      Assert.NotNull(createArmy.m_TargetLocation);
      Assert.NotNull(createArmy.m_CompleteActions);
    }

    [Fact]
    public void CreateCrusaderArmy_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .CreateCrusaderArmy(
                  ArmyGuid,
                  GlobalMapPointGuid,
                  leader: ArmyLeaderGuid,
                  movePoints: 100,
                  speed: 2f,
                  applyRecruitIncrease: true)
              .Build();

      Assert.Single(actions.Actions);
      var createArmy = (CreateArmy)actions.Actions[0];
      ElementAsserts.IsValid(createArmy);

      Assert.Equal(ArmyFaction.Crusaders, createArmy.Faction);
      Assert.Equal(Army.ToReference<BlueprintArmyPreset.Reference>(), createArmy.Preset);
      Assert.Equal(
          GlobalMapPoint.ToReference<BlueprintGlobalMapPoint.Reference>(), createArmy.Location);
      Assert.Equal(TravelLogicType.None, createArmy.m_MoveTarget);

      Assert.Equal(100, createArmy.MovementPoints);
      Assert.Equal(2f, createArmy.m_ArmySpeed);
      Assert.True(createArmy.m_ApplyRecruitIncrease);

      Assert.True(createArmy.WithLeader);
      Assert.Equal(ArmyLeader.ToReference<ArmyLeader.Reference>(), createArmy.ArmyLeader);

      Assert.NotNull(createArmy.m_TargetLocation);
      Assert.NotNull(createArmy.m_CompleteActions);
    }

    [Fact]
    public void CreateDemonArmy()
    {
      var actions = ActionListBuilder.New().CreateDemonArmy(ArmyGuid, GlobalMapPointGuid).Build();

      Assert.Single(actions.Actions);
      var createArmy = (CreateArmy)actions.Actions[0];
      ElementAsserts.IsValid(createArmy);

      Assert.Equal(ArmyFaction.Demons, createArmy.Faction);
      Assert.Equal(Army.ToReference<BlueprintArmyPreset.Reference>(), createArmy.Preset);
      Assert.Equal(
          GlobalMapPoint.ToReference<BlueprintGlobalMapPoint.Reference>(), createArmy.Location);

      Assert.Equal(TravelLogicType.None, createArmy.m_MoveTarget);
      Assert.Equal(1f, createArmy.m_ArmySpeed);

      Assert.False(createArmy.WithLeader);
      Assert.NotNull(createArmy.ArmyLeader);

      Assert.NotNull(createArmy.m_TargetLocation);
      Assert.NotNull(createArmy.m_CompleteActions);
    }

    [Fact]
    public void CreateDemonArmy_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .CreateDemonArmy(
                  ArmyGuid,
                  GlobalMapPointGuid,
                  leader: ArmyLeaderGuid,
                  targetNearestEnemy: true,
                  speed: 2f)
              .Build();

      Assert.Single(actions.Actions);
      var createArmy = (CreateArmy)actions.Actions[0];
      ElementAsserts.IsValid(createArmy);

      Assert.Equal(ArmyFaction.Demons, createArmy.Faction);
      Assert.Equal(Army.ToReference<BlueprintArmyPreset.Reference>(), createArmy.Preset);
      Assert.Equal(
          GlobalMapPoint.ToReference<BlueprintGlobalMapPoint.Reference>(), createArmy.Location);

      Assert.Equal(TravelLogicType.NearestEnemy, createArmy.m_MoveTarget);
      Assert.Equal(2f, createArmy.m_ArmySpeed);

      Assert.True(createArmy.WithLeader);
      Assert.Equal(ArmyLeader.ToReference<ArmyLeader.Reference>(), createArmy.ArmyLeader);

      Assert.NotNull(createArmy.m_TargetLocation);
      Assert.NotNull(createArmy.m_CompleteActions);
    }

    [Fact]
    public void CreateCrusaderArmyFromLosses()
    {
      var actions =
          ActionListBuilder.New()
              .CreateCrusaderArmyFromLosses(GlobalMapPointGuid, 10, 2)
              .Build();

      Assert.Single(actions.Actions);
      var createArmy = (CreateArmyFromLosses)actions.Actions[0];
      ElementAsserts.IsValid(createArmy);

      Assert.Equal(
          GlobalMapPoint.ToReference<BlueprintGlobalMapPoint.Reference>(), createArmy.m_Location);
      Assert.Equal(10, createArmy.m_SumExperience);
      Assert.Equal(2, createArmy.m_SquadsMaxCount);
      Assert.False(createArmy.m_ApplyRecruitIncrease);
    }

    [Fact]
    public void CreateCrusaderArmyFromLosses_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .CreateCrusaderArmyFromLosses(GlobalMapPointGuid, 15, 3, applyRecruitIncrease: true)
              .Build();

      Assert.Single(actions.Actions);
      var createArmy = (CreateArmyFromLosses)actions.Actions[0];
      ElementAsserts.IsValid(createArmy);

      Assert.Equal(
          GlobalMapPoint.ToReference<BlueprintGlobalMapPoint.Reference>(), createArmy.m_Location);
      Assert.Equal(15, createArmy.m_SumExperience);
      Assert.Equal(3, createArmy.m_SquadsMaxCount);
      Assert.True(createArmy.m_ApplyRecruitIncrease);
    }

    [Fact]
    public void CreateDemonArmyTargetingLocation()
    {
      var actions =
          ActionListBuilder.New()
              .CreateDemonArmyTargetingLocation(ArmyGuid, GlobalMapPointGuid, GlobalMapPointGuid)
              .Build();

      Assert.Single(actions.Actions);
      var createArmy = (CreateArmy)actions.Actions[0];
      ElementAsserts.IsValid(createArmy);

      Assert.Equal(ArmyFaction.Demons, createArmy.Faction);
      Assert.Equal(Army.ToReference<BlueprintArmyPreset.Reference>(), createArmy.Preset);
      Assert.Equal(
          GlobalMapPoint.ToReference<BlueprintGlobalMapPoint.Reference>(), createArmy.Location);

      Assert.Equal(TravelLogicType.Location, createArmy.m_MoveTarget);
      Assert.Equal(7, createArmy.m_DaysToDestination);

      Assert.False(createArmy.WithLeader);
      Assert.NotNull(createArmy.ArmyLeader);

      Assert.Equal(
          GlobalMapPoint.ToReference<BlueprintGlobalMapPoint.Reference>(),
          createArmy.m_TargetLocation);
      Assert.NotNull(createArmy.m_CompleteActions);
    }

    [Fact]
    public void CreateDemonArmyTargetingLocation_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .CreateDemonArmyTargetingLocation(
                  ArmyGuid,
                  GlobalMapPointGuid,
                  GlobalMapPointGuid,
                  onTargetReached: ActionListGuid,
                  leader: ArmyLeaderGuid,
                  daysToTarget: 14)
              .Build();

      Assert.Single(actions.Actions);
      var createArmy = (CreateArmy)actions.Actions[0];
      ElementAsserts.IsValid(createArmy);

      Assert.Equal(ArmyFaction.Demons, createArmy.Faction);
      Assert.Equal(Army.ToReference<BlueprintArmyPreset.Reference>(), createArmy.Preset);
      Assert.Equal(
          GlobalMapPoint.ToReference<BlueprintGlobalMapPoint.Reference>(), createArmy.Location);

      Assert.Equal(TravelLogicType.Location, createArmy.m_MoveTarget);
      Assert.Equal(14, createArmy.m_DaysToDestination);

      Assert.True(createArmy.WithLeader);
      Assert.Equal(ArmyLeader.ToReference<ArmyLeader.Reference>(), createArmy.ArmyLeader);

      Assert.Equal(
          GlobalMapPoint.ToReference<BlueprintGlobalMapPoint.Reference>(),
          createArmy.m_TargetLocation);
      Assert.Equal(
          ActionList.ToReference<BlueprintActionList.Reference>(), createArmy.m_CompleteActions);
    }

    [Fact]
    public void ChangeBookImage()
    {
      var image = new SpriteLink { AssetId = "hi" };

      var actions = ActionListBuilder.New().ChangeBookImage(image).Build();

      Assert.Single(actions.Actions);
      var setImage = (ChangeBookEventImage)actions.Actions[0];
      ElementAsserts.IsValid(setImage);

      Assert.Equal(image, setImage.m_Image);
    }

    [Fact]
    public void MoveCamera()
    {
      var position = ElementTool.Create<UnitPosition>();
      position.Unit = ClickedUnit;

      var actions = ActionListBuilder.New().MoveCamera(position).Build();

      Assert.Single(actions.Actions);
      var moveCamera = (CameraToPosition)actions.Actions[0];
      ElementAsserts.IsValid(moveCamera);

      Assert.Equal(position, moveCamera.Position);
    }

    [Fact]
    public void AddCampingEncounter()
    {
      var actions = ActionListBuilder.New().AddCampingEncounter(CampingEncounterGuid).Build();

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
      var actions = ActionListBuilder.New().DestroyMapObject(Trap).Build();

      Assert.Single(actions.Actions);
      var destroy = (DestroyMapObject)actions.Actions[0];
      ElementAsserts.IsValid(destroy);

      Assert.Equal(Trap, destroy.MapObject);
    }

    [Fact]
    public void CreateCustomCompanion()
    {
      var actions = ActionListBuilder.New().CreateCustomCompanion().Build();

      Assert.Single(actions.Actions);
      var createCompanion = (CreateCustomCompanion)actions.Actions[0];
      ElementAsserts.IsValid(createCompanion);

      Assert.False(createCompanion.ForFree);
      Assert.False(createCompanion.MatchPlayerXpExactly);
      Assert.NotNull(createCompanion.OnCreate.Actions);
    }

    [Fact]
    public void CreateCustomCompanion_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .CreateCustomCompanion(
                  free: true,
                  matchPlayerXp: true,
                  onCreate: ActionListBuilder.New().MeleeAttack())
              .Build();

      Assert.Single(actions.Actions);
      var createCompanion = (CreateCustomCompanion)actions.Actions[0];
      ElementAsserts.IsValid(createCompanion);

      Assert.True(createCompanion.ForFree);
      Assert.True(createCompanion.MatchPlayerXpExactly);
      Assert.Single(createCompanion.OnCreate.Actions);
      Assert.IsType<ContextActionMeleeAttack>(createCompanion.OnCreate.Actions[0]);
    }

    [Fact]
    public void AddCrusadeResources()
    {
      var resources = KingdomResourcesAmount.Create(1, 2, 3);

      var actions =
          ActionListBuilder.New()
              .AddCrusadeResources(resources)
              .Build();

      Assert.Single(actions.Actions);
      var addResources = (AddCrusadeResources)actions.Actions[0];
      ElementAsserts.IsValid(addResources);

      Assert.Equal(resources, addResources._resourcesAmount);
    }

    [Fact]
    public void CreateGarrison()
    {
      var actions = ActionListBuilder.New().CreateGarrison(ArmyGuid, GlobalMapPointGuid).Build();

      Assert.Single(actions.Actions);
      var createGarrison = (CreateGarrison)actions.Actions[0];
      ElementAsserts.IsValid(createGarrison);

      Assert.Equal(Army.ToReference<BlueprintArmyPreset.Reference>(), createGarrison.Preset);
      Assert.Equal(
          GlobalMapPoint.ToReference<BlueprintGlobalMapPoint.Reference>(), createGarrison.Location);
      Assert.True(createGarrison.HasNoReward);

      Assert.False(createGarrison.WithLeader);
      Assert.NotNull(createGarrison.ArmyLeader);
    }

    [Fact]
    public void CreateGarrison_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .CreateGarrison(
                  ArmyGuid, GlobalMapPointGuid, leader: ArmyLeaderGuid, noReward: false)
              .Build();

      Assert.Single(actions.Actions);
      var createGarrison = (CreateGarrison)actions.Actions[0];
      ElementAsserts.IsValid(createGarrison);

      Assert.Equal(Army.ToReference<BlueprintArmyPreset.Reference>(), createGarrison.Preset);
      Assert.Equal(
          GlobalMapPoint.ToReference<BlueprintGlobalMapPoint.Reference>(), createGarrison.Location);
      Assert.False(createGarrison.HasNoReward);

      Assert.True(createGarrison.WithLeader);
      Assert.Equal(ArmyLeader.ToReference<ArmyLeader.Reference>(), createGarrison.ArmyLeader);
    }

    [Fact]
    public void AddDialogNotification()
    {
      var text = new LocalizedString { Key = "test_key" };

      var actions =
          ActionListBuilder.New().AddDialogNotification(text).Build();

      Assert.Single(actions.Actions);
      var notification = (AddDialogNotification)actions.Actions[0];
      ElementAsserts.IsValid(notification);

      Assert.Equal(text.Key, notification.Text.Key);
    }

    [Fact]
    public void CompleteEtude()
    {
      var actions = ActionListBuilder.New().CompleteEtude(EtudeGuid).Build();

      Assert.Single(actions.Actions);
      var completeEtude = (CompleteEtude)actions.Actions[0];
      ElementAsserts.IsValid(completeEtude);

      Assert.Equal(Etude.ToReference<BlueprintEtudeReference>(), completeEtude.Etude);
      Assert.False(completeEtude.Evaluate);
    }

    [Fact]
    public void CompleteEtude_WithEvaluator()
    {
      var evaluator = ElementTool.Create<Dialog>();

      var actions = ActionListBuilder.New().CompleteEtude(EtudeGuid, evaluator: evaluator).Build();

      Assert.Single(actions.Actions);
      var completeEtude = (CompleteEtude)actions.Actions[0];
      ElementAsserts.IsValid(completeEtude);

      Assert.Equal(Etude.ToReference<BlueprintEtudeReference>(), completeEtude.Etude);
      Assert.Equal(evaluator, completeEtude.EtudeEvaluator);
      Assert.True(completeEtude.Evaluate);
    }

    [Fact]
    public void CustomEvent()
    {
      var eventId = "event_id";
      var actions = ActionListBuilder.New().CustomEvent(eventId).Build();

      Assert.Single(actions.Actions);
      var customEvent = (CustomEvent)actions.Actions[0];
      ElementAsserts.IsValid(customEvent);

      Assert.Equal(eventId, customEvent.EventId);
    }

    [Fact]
    public void AddItems()
    {
      var items = new List<LootEntry>();
      var toCollection = ElementTool.Create<UnitInventory>();

      var actions = ActionListBuilder.New().AddItems(items, toCollection).Build();

      Assert.Single(actions.Actions);
      var addItems = (AddItemsToCollection)actions.Actions[0];
      ElementAsserts.IsValid(addItems);

      Assert.Equal(items, addItems.Loot);
      Assert.Equal(toCollection, addItems.ItemsCollection);
      Assert.False(addItems.Silent);
      Assert.False(addItems.Identify);
    }

    [Fact]
    public void AddItems_WithOptionalValues()
    {
      var items = new List<LootEntry>();
      var toCollection = ElementTool.Create<UnitInventory>();

      var actions =
          ActionListBuilder.New()
              .AddItems(items, toCollection, silent: true, identify: true)
              .Build();

      Assert.Single(actions.Actions);
      var addItems = (AddItemsToCollection)actions.Actions[0];
      ElementAsserts.IsValid(addItems);

      Assert.Equal(items, addItems.Loot);
      Assert.Equal(toCollection, addItems.ItemsCollection);
      Assert.True(addItems.Silent);
      Assert.True(addItems.Identify);
    }

    [Fact]
    public void AddItemsFromBlueprint()
    {
      var toCollection = ElementTool.Create<UnitInventory>();

      var actions =
          ActionListBuilder.New().AddItemsFromBlueprint(LootGuid, toCollection).Build();

      Assert.Single(actions.Actions);
      var addItems = (AddItemsToCollection)actions.Actions[0];
      ElementAsserts.IsValid(addItems);

      Assert.Equal(Loot.ToReference<BlueprintUnitLootReference>(), addItems.m_BlueprintLoot);
      Assert.Equal(toCollection, addItems.ItemsCollection);
      Assert.False(addItems.Silent);
      Assert.False(addItems.Identify);
    }

    [Fact]
    public void AddItemsFromBlueprint_WithOptionalValues()
    {
      var toCollection = ElementTool.Create<UnitInventory>();

      var actions =
          ActionListBuilder.New()
              .AddItemsFromBlueprint(LootGuid, toCollection, silent: true, identify: true)
              .Build();

      Assert.Single(actions.Actions);
      var addItems = (AddItemsToCollection)actions.Actions[0];
      ElementAsserts.IsValid(addItems);

      Assert.Equal(Loot.ToReference<BlueprintUnitLootReference>(), addItems.m_BlueprintLoot);
      Assert.Equal(toCollection, addItems.ItemsCollection);
      Assert.True(addItems.Silent);
      Assert.True(addItems.Identify);
    }

    [Fact]
    public void GiveItemToPlayer()
    {
      var actions = ActionListBuilder.New().GiveItemToPlayer(ItemGuid).Build();

      Assert.Single(actions.Actions);
      var addItem = (AddItemToPlayer)actions.Actions[0];
      ElementAsserts.IsValid(addItem);

      Assert.Equal(Item.ToReference<BlueprintItemReference>(), addItem.m_ItemToGive);
      Assert.False(addItem.Equip);
      Assert.Null(addItem.EquipOn);
      Assert.True(addItem.ErrorIfDidNotEquip);
      Assert.Equal(0, addItem.PreferredWeaponSet);
      Assert.Equal(1, addItem.Quantity);
      Assert.False(addItem.Silent);
      Assert.False(addItem.Identify);
    }

    [Fact]
    public void GiveItemToPlayer_WithEquipment()
    {
      Assert.Throws<InvalidOperationException>(
          () =>
            ActionListBuilder.New().GiveItemToPlayer(ArmorGuid).Build());
    }

    [Fact]
    public void GiveItemToPlayer_WithHandSlotItem()
    {
      Assert.Throws<InvalidOperationException>(
          () =>
            ActionListBuilder.New().GiveItemToPlayer(SimpleHandItemGuid).Build());
    }

    [Fact]
    public void GiveItemToPlayer_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .GiveItemToPlayer(ItemGuid, count: 2, silent: true, identify: true)
              .Build();

      Assert.Single(actions.Actions);
      var addItem = (AddItemToPlayer)actions.Actions[0];
      ElementAsserts.IsValid(addItem);

      Assert.Equal(Item.ToReference<BlueprintItemReference>(), addItem.m_ItemToGive);
      Assert.False(addItem.Equip);
      Assert.Null(addItem.EquipOn);
      Assert.True(addItem.ErrorIfDidNotEquip);
      Assert.Equal(0, addItem.PreferredWeaponSet);
      Assert.Equal(2, addItem.Quantity);
      Assert.True(addItem.Silent);
      Assert.True(addItem.Identify);
    }

    [Fact]
    public void GiveEquipmentToPlayer()
    {
      var actions =
          ActionListBuilder.New().GiveEquipmentToPlayer(ArmorGuid).Build();

      Assert.Single(actions.Actions);
      var addItem = (AddItemToPlayer)actions.Actions[0];
      ElementAsserts.IsValid(addItem);

      Assert.Equal(Armor.ToReference<BlueprintItemReference>(), addItem.m_ItemToGive);
      Assert.False(addItem.Equip);
      Assert.Null(addItem.EquipOn);
      Assert.True(addItem.ErrorIfDidNotEquip);
      Assert.Equal(0, addItem.PreferredWeaponSet);
      Assert.Equal(1, addItem.Quantity);
      Assert.False(addItem.Silent);
      Assert.False(addItem.Identify);
    }

    [Fact]
    public void GiveEquipmentToPlayer_WithHandSlotItem()
    {
      Assert.Throws<InvalidOperationException>(
          () =>
            ActionListBuilder.New().GiveEquipmentToPlayer(SimpleHandItemGuid, ClickedUnit).Build());
    }

    [Fact]
    public void GiveEquipmentToPlayer_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .GiveEquipmentToPlayer(
                  ArmorGuid,
                  equip: true,
                  equipOn: ClickedUnit,
                  errorIfDidNotEquip: false,
                  count: 2,
                  silent: true,
                  identify: true)
              .Build();

      Assert.Single(actions.Actions);
      var addItem = (AddItemToPlayer)actions.Actions[0];
      ElementAsserts.IsValid(addItem);

      Assert.Equal(Armor.ToReference<BlueprintItemReference>(), addItem.m_ItemToGive);
      Assert.True(addItem.Equip);
      Assert.Equal(ClickedUnit, addItem.EquipOn);
      Assert.False(addItem.ErrorIfDidNotEquip);
      Assert.Equal(0, addItem.PreferredWeaponSet);
      Assert.Equal(2, addItem.Quantity);
      Assert.True(addItem.Silent);
      Assert.True(addItem.Identify);
    }

    [Fact]
    public void GiveHandSlotItemToPlayer()
    {
      var actions = ActionListBuilder.New().GiveHandSlotItemToPlayer(SimpleHandItemGuid).Build();

      Assert.Single(actions.Actions);
      var addItem = (AddItemToPlayer)actions.Actions[0];
      ElementAsserts.IsValid(addItem);

      Assert.Equal(SimpleHandItem.ToReference<BlueprintItemReference>(), addItem.m_ItemToGive);
      Assert.False(addItem.Equip);
      Assert.Null(addItem.EquipOn);
      Assert.True(addItem.ErrorIfDidNotEquip);
      Assert.Equal(0, addItem.PreferredWeaponSet);
      Assert.Equal(1, addItem.Quantity);
      Assert.False(addItem.Silent);
      Assert.False(addItem.Identify);
    }

    [Fact]
    public void GiveHandSlotItemToPlayer_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .GiveHandSlotItemToPlayer(
                  SimpleHandItemGuid,
                  equip: true,
                  equipOn: ClickedUnit,
                  errorIfDidNotEquip: false,
                  preferredHandSlot: 2,
                  count: 2,
                  silent: true,
                  identify: true)
              .Build();

      Assert.Single(actions.Actions);
      var addItem = (AddItemToPlayer)actions.Actions[0];
      ElementAsserts.IsValid(addItem);

      Assert.Equal(SimpleHandItem.ToReference<BlueprintItemReference>(), addItem.m_ItemToGive);
      Assert.True(addItem.Equip);
      Assert.Equal(ClickedUnit, addItem.EquipOn);
      Assert.False(addItem.ErrorIfDidNotEquip);
      Assert.Equal(2, addItem.PreferredWeaponSet);
      Assert.Equal(2, addItem.Quantity);
      Assert.True(addItem.Silent);
      Assert.True(addItem.Identify);
    }

    [Fact]
    public void GiveRandomTrashToPlayer()
    {
      var actions =
          ActionListBuilder.New().GiveRandomTrashToPlayer(TrashLootType.Scrolls, 2).Build();

      Assert.Single(actions.Actions);
      var giveTrash = (ContextActionAddRandomTrashItem)actions.Actions[0];
      ElementAsserts.IsValid(giveTrash);

      Assert.Equal(TrashLootType.Scrolls, giveTrash.m_LootType);
      Assert.Equal(2, giveTrash.m_MaxCost);
      Assert.False(giveTrash.m_Identify);
      Assert.False(giveTrash.m_Silent);
    }

    [Fact]
    public void GiveRandomTrashToPlayer_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .GiveRandomTrashToPlayer(TrashLootType.Scrolls, 3, identify: true, silent: true)
              .Build();

      Assert.Single(actions.Actions);
      var giveTrash = (ContextActionAddRandomTrashItem)actions.Actions[0];
      ElementAsserts.IsValid(giveTrash);

      Assert.Equal(TrashLootType.Scrolls, giveTrash.m_LootType);
      Assert.Equal(3, giveTrash.m_MaxCost);
      Assert.True(giveTrash.m_Identify);
      Assert.True(giveTrash.m_Silent);
    }

    [Fact]
    public void AdvanceLevel()
    {
      var targetLevel = ElementTool.Create<IntConstant>();

      var actions = ActionListBuilder.New().AdvanceLevel(ClickedUnit, targetLevel).Build();

      Assert.Single(actions.Actions);
      var advanceLevel = (AdvanceUnitLevel)actions.Actions[0];
      ElementAsserts.IsValid(advanceLevel);

      Assert.Equal(ClickedUnit, advanceLevel.Unit);
      Assert.Equal(targetLevel, advanceLevel.Level);
    }

    [Fact]
    public void ChangeRomance()
    {
      var value = ElementTool.Create<IntConstant>();
      value.Value = 12;

      var actions = ActionListBuilder.New().ChangeRomance(RomanceGuid, value).Build();

      Assert.Single(actions.Actions);
      var changeRomance = (ChangeRomance)actions.Actions[0];
      ElementAsserts.IsValid(changeRomance);

      Assert.Equal(
          Romance.ToReference<BlueprintRomanceCounterReference>(), changeRomance.m_Romance);
      Assert.Equal(12, changeRomance.ValueEvaluator.GetValue());
    }

    [Fact]
    public void DestroyUnit()
    {
      var actions = ActionListBuilder.New().DestroyUnit(ClickedUnit).Build();

      Assert.Single(actions.Actions);
      var destroy = (DestroyUnit)actions.Actions[0];
      ElementAsserts.IsValid(destroy);

      Assert.Equal(ClickedUnit, destroy.Target);
      Assert.False(destroy.FadeOut);
    }

    [Fact]
    public void DestroyUnit_WithFadeOut()
    {
      var actions = ActionListBuilder.New().DestroyUnit(ClickedUnit, fadeOut: true).Build();

      Assert.Single(actions.Actions);
      var destroy = (DestroyUnit)actions.Actions[0];
      ElementAsserts.IsValid(destroy);

      Assert.Equal(ClickedUnit, destroy.Target);
      Assert.True(destroy.FadeOut);
    }

    [Fact]
    public void AddUnitToGroup()
    {
      var group = ElementTool.Create<PlayerCharacter>();

      var actions = ActionListBuilder.New().AddUnitToGroup(ClickedUnit, group).Build();

      Assert.Single(actions.Actions);
      var addToGroup = (CombineToGroup)actions.Actions[0];
      ElementAsserts.IsValid(addToGroup);

      Assert.Equal(ClickedUnit, addToGroup.TargetUnit);
      Assert.Equal(group, addToGroup.GroupHolder);
    }

    [Fact]
    public void ChangeUnitName()
    {
      var name = new LocalizedString { Key = "new name" };

      var actions = ActionListBuilder.New().ChangeUnitName(ClickedUnit, name).Build();

      Assert.Single(actions.Actions);
      var changeName = (ChangeUnitName)actions.Actions[0];
      ElementAsserts.IsValid(changeName);

      Assert.Equal(ClickedUnit, changeName.Unit);
      Assert.Equal(name, changeName.NewName);
      Assert.False(changeName.AddToTheName);
      Assert.False(changeName.ReturnTheOldName);
    }

    [Fact]
    public void ChangeUnitName_WithAppendName()
    {
      var name = new LocalizedString { Key = "new name" };

      var actions =
          ActionListBuilder.New().ChangeUnitName(ClickedUnit, name, appendName: true).Build();

      Assert.Single(actions.Actions);
      var changeName = (ChangeUnitName)actions.Actions[0];
      ElementAsserts.IsValid(changeName);

      Assert.Equal(ClickedUnit, changeName.Unit);
      Assert.Equal(name, changeName.NewName);
      Assert.True(changeName.AddToTheName);
      Assert.False(changeName.ReturnTheOldName);
    }

    [Fact]
    public void ResetUnitName()
    {
      var actions = ActionListBuilder.New().ResetUnitName(ClickedUnit).Build();

      Assert.Single(actions.Actions);
      var changeName = (ChangeUnitName)actions.Actions[0];
      ElementAsserts.IsValid(changeName);

      Assert.Equal(ClickedUnit, changeName.Unit);
      Assert.False(changeName.AddToTheName);
      Assert.True(changeName.ReturnTheOldName);
    }

    [Fact]
    public void ClearUnitReturnPosition()
    {
      var actions = ActionListBuilder.New().ClearUnitReturnPosition(ClickedUnit).Build();

      Assert.Single(actions.Actions);
      var clearReturnPosition = (ClearUnitReturnPosition)actions.Actions[0];
      ElementAsserts.IsValid(clearReturnPosition);

      Assert.Equal(ClickedUnit, clearReturnPosition.Unit);
    }

    [Fact]
    public void ClearAllUnitReturnPosition()
    {
      var actions = ActionListBuilder.New().ClearAllUnitReturnPosition().Build();

      Assert.Single(actions.Actions);
      var clearReturnPosition = (ClearUnitReturnPosition)actions.Actions[0];
      ElementAsserts.IsValid(clearReturnPosition);

      Assert.Null(clearReturnPosition.Unit);
    }

    [Fact]
    public void AddUnitToSummonPool()
    {
      var actions =
          ActionListBuilder.New().AddUnitToSummonPool(ClickedUnit, SummonPoolGuid).Build();

      Assert.Single(actions.Actions);
      var addSummon = (AddUnitToSummonPool)actions.Actions[0];
      ElementAsserts.IsValid(addSummon);

      Assert.Equal(ClickedUnit, addSummon.Unit);
      Assert.Equal(SummonPool.ToReference<BlueprintSummonPoolReference>(), addSummon.m_SummonPool);
    }

    [Fact]
    public void RemoveUnitFromSummonPool()
    {
      var actions =
          ActionListBuilder.New().RemoveUnitFromSummonPool(ClickedUnit, SummonPoolGuid).Build();

      Assert.Single(actions.Actions);
      var addSummon = (DeleteUnitFromSummonPool)actions.Actions[0];
      ElementAsserts.IsValid(addSummon);

      Assert.Equal(ClickedUnit, addSummon.Unit);
      Assert.Equal(SummonPool.ToReference<BlueprintSummonPoolReference>(), addSummon.m_SummonPool);
    }

    [Fact]
    public void ClearBlood()
    {
      var actions = ActionListBuilder.New().ClearBlood().Build();

      Assert.Single(actions.Actions);
      var clearBlood = (ClearBlood)actions.Actions[0];
      ElementAsserts.IsValid(clearBlood);
    }
  }
}
