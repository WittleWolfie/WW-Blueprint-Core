using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.KingdomEx;
using BlueprintCore.Test.Asserts;
using BlueprintCore.Utils;
using Kingmaker.Armies;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Armies.Components;
using Kingmaker.Armies.TacticalCombat.GameActions;
using Kingmaker.Blueprints;
using Kingmaker.Crusade.GlobalMagic;
using Kingmaker.Crusade.GlobalMagic.Actions;
using Kingmaker.Crusade.GlobalMagic.Actions.DamageLogic;
using Kingmaker.Crusade.GlobalMagic.Actions.SummonLogics;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Globalmap.State;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Actions;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Xunit;
using static BlueprintCore.Test.TestData;

namespace BlueprintCore.Test.Actions.Builder.KingdomEx
{
  public class ActionListBuilderKingdomExTest : TestBase
  {
    //----- Kingmaker.Armies.TacticalCombat.GameActions -----//

    [Fact]
    public void GrantExtraArmyAction()
    {
      var actions = ActionListBuilder.New().GrantExtraArmyAction().Build();

      Assert.Single(actions.Actions);
      var grantAction = (ArmyAdditionalAction)actions.Actions[0];
      ElementAsserts.IsValid(grantAction);

      Assert.True(grantAction.m_InCurrentTurn);
      Assert.True(grantAction.m_CanAddInBonusMoraleTurn);
    }

    [Fact]
    public void GrantExtraArmyAction_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .GrantExtraArmyAction(usableInCurrentTurn: false, usableInBonusMoraleTurn: false)
              .Build();

      Assert.Single(actions.Actions);
      var grantAction = (ArmyAdditionalAction)actions.Actions[0];
      ElementAsserts.IsValid(grantAction);

      Assert.False(grantAction.m_InCurrentTurn);
      Assert.False(grantAction.m_CanAddInBonusMoraleTurn);
    }

    [Fact]
    public void AddCrusadeResource()
    {
      var actions =
          ActionListBuilder.New()
              .AddCrusadeResource(new KingdomResourcesAmount { m_Finances = 3 })
              .Build();

      Assert.Single(actions.Actions);
      var addResource = (ContextActionAddCrusadeResource)actions.Actions[0];
      ElementAsserts.IsValid(addResource);

      Assert.Equal(3, addResource.m_ResourcesAmount.m_Finances);
    }

    [Fact]
    public void RemoveArmyFacts()
    {
      var actions = ActionListBuilder.New().RemoveArmyFacts(BuffGuid, AbilityGuid).Build();

      Assert.Single(actions.Actions);
      var removeFacts = (ContextActionArmyRemoveFacts)actions.Actions[0];
      ElementAsserts.IsValid(removeFacts);

      Assert.Equal(2, removeFacts.m_FactsToRemove.Length);
      Assert.Contains(Buff.ToReference<BlueprintUnitFactReference>(), removeFacts.m_FactsToRemove);
      Assert.Contains(
          TestAbility.ToReference<BlueprintUnitFactReference>(), removeFacts.m_FactsToRemove);
    }

    [Fact]
    public void RestoreLeaderAction()
    {
      var actions = ActionListBuilder.New().RestoreLeaderAction().Build();

      Assert.Single(actions.Actions);
      var restoreAction = (ContextActionRestoreLeaderAction)actions.Actions[0];
      ElementAsserts.IsValid(restoreAction);
    }

    [Fact]
    public void StopUnit()
    {
      var actions = ActionListBuilder.New().StopUnit().Build();

      Assert.Single(actions.Actions);
      var stop = (ContextActionStopUnit)actions.Actions[0];
      ElementAsserts.IsValid(stop);
    }

    //----- Kingmaker.Crusade.GlobalMagic.Actions -----//

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
          ActionListBuilder.New().GlobalTeleport(ActionListBuilder.New().EnableKingdom()).Build();

      Assert.Single(actions.Actions);
      var teleport = (OpenTeleportationInterface)actions.Actions[0];
      ElementAsserts.IsValid(teleport);

      Assert.Single(teleport.m_OnTeleportActions.Actions);
      Assert.IsType<KingdomActionEnable>(teleport.m_OnTeleportActions.Actions[0]);
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

    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

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
      Assert.Equal(TestArmyLeader.ToReference<ArmyLeader.Reference>(), createArmy.ArmyLeader);

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
      Assert.Equal(TestArmyLeader.ToReference<ArmyLeader.Reference>(), createArmy.ArmyLeader);

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
      Assert.Equal(TestArmyLeader.ToReference<ArmyLeader.Reference>(), createArmy.ArmyLeader);

      Assert.Equal(
          GlobalMapPoint.ToReference<BlueprintGlobalMapPoint.Reference>(),
          createArmy.m_TargetLocation);
      Assert.Equal(
          ActionList.ToReference<BlueprintActionList.Reference>(), createArmy.m_CompleteActions);
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
      Assert.Equal(TestArmyLeader.ToReference<ArmyLeader.Reference>(), createGarrison.ArmyLeader);
    }

    //----- Kingmaker.Kingdom.Actions -----//

    [Fact]
    public void IncreaseMorale()
    {
      var actions =
          ActionListBuilder.New()
              .IncreaseMorale(new DiceFormula(2, DiceType.D2), 3)
              .Build();

      Assert.Single(actions.Actions);
      var increaseMorale = (AddMorale)actions.Actions[0];
      ElementAsserts.IsValid(increaseMorale);

      Assert.Equal(DiceType.D2, increaseMorale.Change.m_Dice);
      Assert.Equal(2, increaseMorale.Change.m_Rolls);
      Assert.Equal(3, increaseMorale.Bonus);
      Assert.False(increaseMorale.Substract);
    }

    [Fact]
    public void ReduceMorale()
    {
      var actions =
          ActionListBuilder.New()
              .ReduceMorale(new DiceFormula(2, DiceType.D2), 3)
              .Build();

      Assert.Single(actions.Actions);
      var increaseMorale = (AddMorale)actions.Actions[0];
      ElementAsserts.IsValid(increaseMorale);

      Assert.Equal(DiceType.D2, increaseMorale.Change.m_Dice);
      Assert.Equal(2, increaseMorale.Change.m_Rolls);
      Assert.Equal(3, increaseMorale.Bonus);
      Assert.True(increaseMorale.Substract);
    }

    [Fact]
    public void ActivateEventDeck()
    {
      var actions = ActionListBuilder.New().ActivateEventDeck(DeckGuid).Build();

      Assert.Single(actions.Actions);
      var activateDeck = (KingdomActionActivateEventDeck)actions.Actions[0];
      ElementAsserts.IsValid(activateDeck);

      Assert.Equal(Deck.ToReference<BlueprintKingdomDeckReference>(), activateDeck.m_Deck);
    }

    [Fact]
    public void AddBP()
    {
      var actions =
          ActionListBuilder.New()
              .AddBP(KingdomResource.Favors, new DiceFormula(1, DiceType.D4), 4)
              .Build();

      Assert.Single(actions.Actions);
      var addBP = (KingdomActionAddBPRandom)actions.Actions[0];
      ElementAsserts.IsValid(addBP);

      Assert.Equal(KingdomResource.Favors, addBP.ResourceType);
      Assert.Equal(DiceType.D4, addBP.Change.m_Dice);
      Assert.Equal(1, addBP.Change.m_Rolls);
      Assert.Equal(4, addBP.Bonus);
      Assert.True(addBP.IncludeInEventStats);
    }

    [Fact]
    public void AddBP_HideFromEventHistory()
    {
      var actions =
          ActionListBuilder.New()
              .AddBP(
                  KingdomResource.Finances,
                  new DiceFormula(2, DiceType.D4),
                  3,
                  showInEventHistory: false)
              .Build();

      Assert.Single(actions.Actions);
      var addBP = (KingdomActionAddBPRandom)actions.Actions[0];
      ElementAsserts.IsValid(addBP);

      Assert.Equal(KingdomResource.Finances, addBP.ResourceType);
      Assert.Equal(DiceType.D4, addBP.Change.m_Dice);
      Assert.Equal(2, addBP.Change.m_Rolls);
      Assert.Equal(3, addBP.Bonus);
      Assert.False(addBP.IncludeInEventStats);
    }

    [Fact]
    public void AddKingdomBuff()
    {
      var actions = ActionListBuilder.New().AddKingdomBuff(KingdomBuffGuid).Build();

      Assert.Single(actions.Actions);
      var addBuff = (KingdomActionAddBuff)actions.Actions[0];
      ElementAsserts.IsValid(addBuff);

      Assert.Equal(KingdomBuff.ToReference<BlueprintKingdomBuffReference>(), addBuff.m_Blueprint);
      Assert.Equal(0, addBuff.OverrideDuration);
      Assert.NotNull(addBuff.m_Region);
      Assert.True(addBuff.ApplyToRegion);
      Assert.False(addBuff.CopyToAdjacentRegions);
    }

    [Fact]
    public void AddKingdomBuff_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .AddKingdomBuff(
                  KingdomBuffGuid,
                  durationOverrideDays: 5,
                  targetRegion: RegionGuid,
                  applyToRegion: false,
                  applyToAdjacentRegions: true)
              .Build();

      Assert.Single(actions.Actions);
      var addBuff = (KingdomActionAddBuff)actions.Actions[0];
      ElementAsserts.IsValid(addBuff);

      Assert.Equal(KingdomBuff.ToReference<BlueprintKingdomBuffReference>(), addBuff.m_Blueprint);
      Assert.Equal(5, addBuff.OverrideDuration);
      Assert.Equal(Region.ToReference<BlueprintRegionReference>(), addBuff.m_Region);
      Assert.False(addBuff.ApplyToRegion);
      Assert.True(addBuff.CopyToAdjacentRegions);
    }

    [Fact]
    public void AddFreeBuilding()
    {
      var actions = ActionListBuilder.New().AddFreeBuilding(SettlementBuildingGuid).Build();

      Assert.Single(actions.Actions);
      var addBuilding = (KingdomActionAddFreeBuilding)actions.Actions[0];
      ElementAsserts.IsValid(addBuilding);

      Assert.Equal(
          SettlementBuilding.ToReference<BlueprintSettlementBuildingReference>(),
          addBuilding.m_Building);
      Assert.Equal(1, addBuilding.Count);
      Assert.True(addBuilding.Anywhere);
    }

    [Fact]
    public void AddFreeBuilding_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .AddFreeBuilding(SettlementBuildingGuid, count: 2, settlement: SettlementGuid)
              .Build();

      Assert.Single(actions.Actions);
      var addBuilding = (KingdomActionAddFreeBuilding)actions.Actions[0];
      ElementAsserts.IsValid(addBuilding);

      Assert.Equal(
          SettlementBuilding.ToReference<BlueprintSettlementBuildingReference>(),
          addBuilding.m_Building);
      Assert.Equal(2, addBuilding.Count);
      Assert.False(addBuilding.Anywhere);
      Assert.Equal(
          Settlement.ToReference<BlueprintSettlement.Reference>(), addBuilding.m_Settlement);
    }

    [Fact]
    public void AddFreeMercRerolls()
    {
      var actions = ActionListBuilder.New().AddFreeMercRerolls().Build();

      Assert.Single(actions.Actions);
      var addMercRerolls = (KingdomActionAddMercenaryReroll)actions.Actions[0];
      ElementAsserts.IsValid(addMercRerolls);

      Assert.Equal(1, addMercRerolls.m_FreeRerollsToAdd);
    }

    [Fact]
    public void AddFreeMercRerolls_Multiple()
    {
      var actions = ActionListBuilder.New().AddFreeMercRerolls(3).Build();

      Assert.Single(actions.Actions);
      var addMercRerolls = (KingdomActionAddMercenaryReroll)actions.Actions[0];
      ElementAsserts.IsValid(addMercRerolls);

      Assert.Equal(3, addMercRerolls.m_FreeRerollsToAdd);
    }

    [Fact]
    public void AddRandomKingdomBuff()
    {
      var actions =
          ActionListBuilder.New()
              .AddRandomKingdomBuff(new string[] { KingdomBuffGuid, KingdomBuffGuid })
              .Build();

      Assert.Single(actions.Actions);
      var addBuff = (KingdomActionAddRandomBuff)actions.Actions[0];
      ElementAsserts.IsValid(addBuff);

      Assert.Equal(0, addBuff.OverrideDurationDays);

      Assert.Equal(2, addBuff.m_Buffs.Count);
      Assert.Equal(KingdomBuff.ToReference<BlueprintKingdomBuffReference>(), addBuff.m_Buffs[0]);
      Assert.Equal(KingdomBuff.ToReference<BlueprintKingdomBuffReference>(), addBuff.m_Buffs[1]);
    }

    [Fact]
    public void AddRandomKingdomBuff_WithDuration()
    {
      var actions =
          ActionListBuilder.New()
              .AddRandomKingdomBuff(
                  new string[] { KingdomBuffGuid, KingdomBuffGuid }, durationOverrideDays: 3)
              .Build();

      Assert.Single(actions.Actions);
      var addBuff = (KingdomActionAddRandomBuff)actions.Actions[0];
      ElementAsserts.IsValid(addBuff);

      Assert.Equal(3, addBuff.OverrideDurationDays);

      Assert.Equal(2, addBuff.m_Buffs.Count);
      Assert.Equal(KingdomBuff.ToReference<BlueprintKingdomBuffReference>(), addBuff.m_Buffs[0]);
      Assert.Equal(KingdomBuff.ToReference<BlueprintKingdomBuffReference>(), addBuff.m_Buffs[1]);
    }

    [Fact]
    public void ArtisanRequestHelp()
    {
      var actions = ActionListBuilder.New().ArtisanRequestHelp(ArtisanGuid, ProjectGuid).Build();

      Assert.Single(actions.Actions);
      var requestHelp = (KingdomActionArtisanRequestHelp)actions.Actions[0];
      ElementAsserts.IsValid(requestHelp);

      Assert.Equal(Artisan.ToReference<BlueprintKingdomArtisanReference>(), requestHelp.m_Artisan);
      Assert.Equal(Project.ToReference<BlueprintKingdomProjectReference>(), requestHelp.m_Project);
    }

    [Fact]
    public void EnableAutoCrusade()
    {
      var actions = ActionListBuilder.New().EnableAutoCrusade().Build();

      Assert.Single(actions.Actions);
      var enableAutoCrusade = (KingdomActionChangeToAutoCrusade)actions.Actions[0];
      ElementAsserts.IsValid(enableAutoCrusade);
    }

    [Fact]
    public void CollectKingdomLoot()
    {
      var actions = ActionListBuilder.New().CollectKingdomLoot().Build();

      Assert.Single(actions.Actions);
      var collectLoot = (KingdomActionCollectLoot)actions.Actions[0];
      ElementAsserts.IsValid(collectLoot);
    }

    [Fact]
    public void ConquerRegion()
    {
      var actions = ActionListBuilder.New().ConquerRegion(RegionGuid).Build();

      Assert.Single(actions.Actions);
      var conquer = (KingdomActionConquerRegion)actions.Actions[0];
      ElementAsserts.IsValid(conquer);

      Assert.Equal(Region.ToReference<BlueprintRegionReference>(), conquer.m_Region);
    }

    [Fact]
    public void DestroyAllSettlements()
    {
      var actions = ActionListBuilder.New().DestroyAllSettlements().Build();

      Assert.Single(actions.Actions);
      var destroy = (KingdomActionDestroyAllSettlements)actions.Actions[0];
      ElementAsserts.IsValid(destroy);
    }

    [Fact]
    public void DisableKingdom()
    {
      var actions = ActionListBuilder.New().DisableKingdom().Build();

      Assert.Single(actions.Actions);
      var disable = (KingdomActionDisable)actions.Actions[0];
      ElementAsserts.IsValid(disable);
    }

    [Fact]
    public void EnableKingdom()
    {
      var actions = ActionListBuilder.New().EnableKingdom().Build();

      Assert.Single(actions.Actions);
      var enable = (KingdomActionEnable)actions.Actions[0];
      ElementAsserts.IsValid(enable);
    }

    [Fact]
    public void FillSettlement()
    {
      var actions = ActionListBuilder.New().FillSettlement(SettlementGuid, BuildListGuid).Build();

      Assert.Single(actions.Actions);
      var fill = (KingdomActionFillSettlement)actions.Actions[0];
      ElementAsserts.IsValid(fill);

      Assert.Equal(
          Settlement.ToReference<BlueprintSettlement.Reference>(), fill.m_SpecificSettlement);
      Assert.Equal(BuildList.ToReference<SettlementBuildListReference>(), fill.m_BuildList);
    }

    [Fact]
    public void FillSettlementByLocation()
    {
      var actions =
          ActionListBuilder.New()
              .FillSettlementByLocation(GlobalMapPointGuid, BuildListGuid)
              .Build();

      Assert.Single(actions.Actions);
      var fill = (KingdomActionFillSettlementByLocation)actions.Actions[0];
      ElementAsserts.IsValid(fill);

      Assert.Equal(
          GlobalMapPoint.ToReference<BlueprintGlobalMapPointReference>(),
          fill.m_SpecificSettlementLocation);
      Assert.Equal(BuildList.ToReference<SettlementBuildListReference>(), fill.m_BuildList);
    }

    [Fact]
    public void FinishRandomBuilding()
    {
      var actions = ActionListBuilder.New().FinishRandomBuilding().Build();

      Assert.Single(actions.Actions);
      var finish = (KingdomActionFinishRandomBuilding)actions.Actions[0];
      ElementAsserts.IsValid(finish);
    }

    [Fact]
    public void FoundKingdom()
    {
      var actions = ActionListBuilder.New().FoundKingdom().Build();

      Assert.Single(actions.Actions);
      var found = (KingdomActionFoundKingdom)actions.Actions[0];
      ElementAsserts.IsValid(found);
    }

    [Fact]
    public void FoundSettlement()
    {
      var actions =
          ActionListBuilder.New().FoundSettlement(GlobalMapPointGuid, SettlementGuid).Build();

      Assert.Single(actions.Actions);
      var found = (KingdomActionFoundSettlement)actions.Actions[0];
      ElementAsserts.IsValid(found);

      Assert.Equal(
          GlobalMapPoint.ToReference<BlueprintGlobalMapPoint.Reference>(), found.m_Location);
      Assert.Equal(Settlement.ToReference<BlueprintSettlement.Reference>(), found.m_Settlement);
    }

    [Fact]
    public void GrantLeaderExp()
    {
      var actions = ActionListBuilder.New().GrantLeaderExp(TestInt).Build();

      Assert.Single(actions.Actions);
      var grantExp = (KingdomActionGainLeaderExperience)actions.Actions[0];
      ElementAsserts.IsValid(grantExp);

      Assert.Equal(TestInt, grantExp.m_Value);
      Assert.False(grantExp.m_MultiplyByLeaderLevel);
    }

    [Fact]
    public void GrantLeaderExp_WithLeaderLevelMultiplier()
    {
      var actions =
          ActionListBuilder.New().GrantLeaderExp(TestInt, leaderLevelMultiplier: 2f).Build();

      Assert.Single(actions.Actions);
      var grantExp = (KingdomActionGainLeaderExperience)actions.Actions[0];
      ElementAsserts.IsValid(grantExp);

      Assert.Equal(TestInt, grantExp.m_Value);
      Assert.True(grantExp.m_MultiplyByLeaderLevel);
      Assert.Equal(2f, grantExp.m_MultiplierCoefficient);
    }

    //----- Kingmaker.Kingdom.Blueprints -----//

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

    //----- Kingmaker.UnitLogic.Mechanics.Actions -----//

    [Fact]
    public void ChangeTacticalMorale()
    {
      var value = ContextValues.Constant(3);

      var actions = ActionListBuilder.New().ChangeTacticalMorale(value).Build();

      Assert.Single(actions.Actions);
      var changeMorale = (ChangeTacticalMorale)actions.Actions[0];
      ElementAsserts.IsValid(changeMorale);

      Assert.Equal(value, changeMorale.m_Value);
    }

    [Fact]
    public void KillSquadLeaders()
    {
      var actions =
          ActionListBuilder.New().KillSquadLeaders(new ContextDiceValue { BonusValue = 5 }).Build();

      Assert.Single(actions.Actions);
      var kill = (ContextActionSquadUnitsKill)actions.Actions[0];
      ElementAsserts.IsValid(kill);

      Assert.False(kill.m_UseFloatValue);
      Assert.Equal(5, kill.m_Count.BonusValue.Value);
    }

    [Fact]
    public void KillSquadUnits()
    {
      var actions = ActionListBuilder.New().KillSquadUnits(0.25f).Build();

      Assert.Single(actions.Actions);
      var kill = (ContextActionSquadUnitsKill)actions.Actions[0];
      ElementAsserts.IsValid(kill);

      Assert.True(kill.m_UseFloatValue);
      Assert.Equal(0.25f, kill.m_FloatCount);
    }

    [Fact]
    public void SummonSquad()
    {
      var actions = ActionListBuilder.New().SummonSquad(UnitGuid, 2).Build();

      Assert.Single(actions.Actions);
      var summon = (ContextActionSummonTacticalSquad)actions.Actions[0];
      ElementAsserts.IsValid(summon);

      Assert.Equal(Unit.ToReference<BlueprintUnitReference>(), summon.m_Blueprint);
      Assert.Equal(2, summon.m_Count.Value);
      Assert.Null(summon.m_SummonPool);

      Assert.Empty(summon.m_AfterSpawn.Actions);
    }

    [Fact]
    public void SummonSquad_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .SummonSquad(
                  UnitGuid,
                  3,
                  onSpawn: ActionListBuilder.New().EnableKingdom(),
                  summonPool: SummonPoolGuid)
              .Build();

      Assert.Single(actions.Actions);
      var summon = (ContextActionSummonTacticalSquad)actions.Actions[0];
      ElementAsserts.IsValid(summon);

      Assert.Equal(Unit.ToReference<BlueprintUnitReference>(), summon.m_Blueprint);
      Assert.Equal(3, summon.m_Count.Value);
      Assert.Equal(SummonPool.ToReference<BlueprintSummonPoolReference>(), summon.m_SummonPool);

      Assert.Single(summon.m_AfterSpawn.Actions);
      Assert.IsType<KingdomActionEnable>(summon.m_AfterSpawn.Actions[0]);
    }

    [Fact]
    public void TacticalCombatDealDamage()
    {
      var actions =
          ActionListBuilder.New()
              .TacticalCombatDealDamage(TestDamageTypeDescription, DiceType.D4)
              .Build();

      Assert.Single(actions.Actions);
      var dmg = (ContextActionTacticalCombatDealDamage)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(TestDamageTypeDescription, dmg.DamageType);
      Assert.Equal(DiceType.D4, dmg.DiceType);
      Assert.Equal(1, dmg.RollsCount.Value);

      Assert.False(dmg.Half);
      Assert.False(dmg.IgnoreCritical);
      Assert.False(dmg.UseMinHPAfterDamage);
    }

    [Fact]
    public void TacticalCombatDealDamage_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .TacticalCombatDealDamage(
                  TestDamageTypeDescription,
                  DiceType.D4,
                  diceRolls: 3,
                  dealHalf: true,
                  ignoreCrit: true,
                  minHPAfterDmg: 1)
              .Build();

      Assert.Single(actions.Actions);
      var dmg = (ContextActionTacticalCombatDealDamage)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(TestDamageTypeDescription, dmg.DamageType);
      Assert.Equal(DiceType.D4, dmg.DiceType);
      Assert.Equal(3, dmg.RollsCount.Value);

      Assert.True(dmg.Half);
      Assert.True(dmg.IgnoreCritical);
      Assert.True(dmg.UseMinHPAfterDamage);
      Assert.Equal(1, dmg.MinHPAfterDamage);
    }

    [Fact]
    public void TacticalCombatHeal()
    {
      var actions = ActionListBuilder.New().TacticalCombatHeal().Build();

      Assert.Single(actions.Actions);
      var heal = (ContextActionTacticalCombatHealTarget)actions.Actions[0];
      ElementAsserts.IsValid(heal);

      Assert.Equal(DiceType.D6, heal.DiceType);
      Assert.Equal(1, heal.RollsCount.Value);
    }

    [Fact]
    public void TacticalCombatHeal_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New().TacticalCombatHeal(diceType: DiceType.D10, diceRolls: 3).Build();

      Assert.Single(actions.Actions);
      var heal = (ContextActionTacticalCombatHealTarget)actions.Actions[0];
      ElementAsserts.IsValid(heal);

      Assert.Equal(DiceType.D10, heal.DiceType);
      Assert.Equal(3, heal.RollsCount.Value);
    }
  }
}
