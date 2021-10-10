using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.KingdomEx;
using BlueprintCore.Tests.Asserts;
using Kingmaker.Blueprints;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Actions;
using Kingmaker.RuleSystem;
using Xunit;

namespace BlueprintCore.Tests.Actions
{
  public class ActionListBuilderKingdomExTest : ActionListBuilderTestBase
  {
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
      var actions = ActionListBuilder.New().GrantLeaderExp(IntConstant).Build();

      Assert.Single(actions.Actions);
      var grantExp = (KingdomActionGainLeaderExperience)actions.Actions[0];
      ElementAsserts.IsValid(grantExp);

      Assert.Equal(IntConstant, grantExp.m_Value);
      Assert.False(grantExp.m_MultiplyByLeaderLevel);
    }

    [Fact]
    public void GrantLeaderExp_WithLeaderLevelMultiplier()
    {
      var actions =
          ActionListBuilder.New().GrantLeaderExp(IntConstant, leaderLevelMultiplier: 2f).Build();

      Assert.Single(actions.Actions);
      var grantExp = (KingdomActionGainLeaderExperience)actions.Actions[0];
      ElementAsserts.IsValid(grantExp);

      Assert.Equal(IntConstant, grantExp.m_Value);
      Assert.True(grantExp.m_MultiplyByLeaderLevel);
      Assert.Equal(2f, grantExp.m_MultiplierCoefficient);
    }
  }
}
