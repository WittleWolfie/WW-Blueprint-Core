using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Actions.Builder.KingdomEx;
using BlueprintCore.Tests.Asserts;
using Kingmaker.Blueprints;
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
  }
}
