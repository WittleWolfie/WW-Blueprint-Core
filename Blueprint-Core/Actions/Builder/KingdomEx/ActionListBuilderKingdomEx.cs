using System.Linq;
using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Actions;
using Kingmaker.Kingdom.AI;
using Kingmaker.Kingdom.Artisans;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Kingdom.Settlements;
using Kingmaker.RuleSystem;

namespace BlueprintCore.Actions.Builder.KingdomEx
{

  /** Extension to ActionListBuilder which supports all KingdomAction types. */
  public static class ActionListBuilderKingdomEx
  {
    //----- Kingmaker.Kingdom.Actions -----//

    /** AddMorale */
    public static ActionListBuilder IncreaseMorale(
        this ActionListBuilder builder, DiceFormula value, int bonus)
    {
      var increaseMorale = ElementTool.Create<AddMorale>();
      increaseMorale.Change = value;
      increaseMorale.Bonus = bonus;
      return builder.Add(increaseMorale);
    }

    /** AddMorale */
    public static ActionListBuilder ReduceMorale(
        this ActionListBuilder builder, DiceFormula value, int bonus)
    {
      var reduceMorale = ElementTool.Create<AddMorale>();
      reduceMorale.Change = value;
      reduceMorale.Bonus = bonus;
      reduceMorale.Substract = true;
      return builder.Add(reduceMorale);
    }

    /**
     * KingdomActionActivateEventDeck
     *
     * @param deck BlueprintKingdomDeck
     */
    public static ActionListBuilder ActivateEventDeck(this ActionListBuilder builder, string deck)
    {
      var activateDeck = ElementTool.Create<KingdomActionActivateEventDeck>();
      activateDeck.m_Deck =
          BlueprintTool.GetRef<BlueprintKingdomDeck, BlueprintKingdomDeckReference>(deck);
      return builder.Add(activateDeck);
    }

    /** KingdomActionAddBPRandom */
    public static ActionListBuilder AddBP(
        this ActionListBuilder builder,
        KingdomResource type,
        DiceFormula value,
        int bonus,
        bool showInEventHistory = true)
    {
      var addBP = ElementTool.Create<KingdomActionAddBPRandom>();
      addBP.ResourceType = type;
      addBP.Change = value;
      addBP.Bonus = bonus;
      addBP.IncludeInEventStats = showInEventHistory;
      return builder.Add(addBP);
    }

    /**
     * KingdomActionAddBuff
     *
     * @param buff BluepringKingdomBuff
     * @param targetRegion BlueprintRegion
     */
    public static ActionListBuilder AddKingdomBuff(
        this ActionListBuilder builder,
        string buff,
        int durationOverrideDays = 0,
        string targetRegion = null,
        bool applyToRegion = true,
        bool applyToAdjacentRegions = false)
    {
      var addBuff = ElementTool.Create<KingdomActionAddBuff>();
      addBuff.m_Blueprint =
          BlueprintTool.GetRef<BlueprintKingdomBuff, BlueprintKingdomBuffReference>(buff);
      addBuff.OverrideDuration = durationOverrideDays;
      addBuff.m_Region =
          targetRegion is null
              ? BlueprintReferenceBase.CreateTyped<BlueprintRegionReference>(null)
              : BlueprintTool.GetRef<BlueprintRegion, BlueprintRegionReference>(targetRegion);
      addBuff.ApplyToRegion = applyToRegion;
      addBuff.CopyToAdjacentRegions = applyToAdjacentRegions;
      return builder.Add(addBuff);
    }

    /**
     * KingdomActionAddFreeBuilding
     *
     * @param building BlueprintSettlementBuilding
     * @param settlement BlueprintSettlement If not specified, all settlements are granted the
     *   free building.
     */
    public static ActionListBuilder AddFreeBuilding(
        this ActionListBuilder builder, string building, int count = 1, string settlement = null)
    {
      var addBuilding = ElementTool.Create<KingdomActionAddFreeBuilding>();
      addBuilding.m_Building =
          BlueprintTool
              .GetRef<BlueprintSettlementBuilding, BlueprintSettlementBuildingReference>(building);
      addBuilding.Count = count;
      if (settlement == null)
      {
        addBuilding.Anywhere = true;
      }
      else
      {
        addBuilding.Anywhere = false;
        addBuilding.m_Settlement =
            BlueprintTool.GetRef<BlueprintSettlement, BlueprintSettlement.Reference>(settlement);
      }
      return builder.Add(addBuilding);
    }

    /** KingdomActionAddMercenaryRerolls */
    public static ActionListBuilder AddFreeMercRerolls(
        this ActionListBuilder builder, int count = 1)
    {
      var addMercRerolls = ElementTool.Create<KingdomActionAddMercenaryReroll>();
      addMercRerolls.m_FreeRerollsToAdd = count;
      return builder.Add(addMercRerolls);
    }

    /**
     * KingdomActionAddRandomBuff
     *
     * @param buffs BlueprintKingdomBuff
     */
    public static ActionListBuilder AddRandomKingdomBuff(
        this ActionListBuilder builder, string[] buffs, int durationOverrideDays = 0)
    {
      var addBuff = ElementTool.Create<KingdomActionAddRandomBuff>();
      addBuff.m_Buffs =
          buffs
              .Select(
                  buff =>
                      BlueprintTool
                          .GetRef<BlueprintKingdomBuff, BlueprintKingdomBuffReference>(buff))
              .ToList();
      addBuff.OverrideDurationDays = durationOverrideDays;
      return builder.Add(addBuff);
    }

    /**
     * KingdomActionArtisanRequestHelp
     *
     * @param artisan BlueprintKingdomArtisan
     * @param project BlueprintKingdomProject
     */
    public static ActionListBuilder ArtisanRequestHelp(
        this ActionListBuilder builder, string artisan, string project)
    {
      var requestHelp = ElementTool.Create<KingdomActionArtisanRequestHelp>();
      requestHelp.m_Artisan =
          BlueprintTool.GetRef<BlueprintKingdomArtisan, BlueprintKingdomArtisanReference>(artisan);
      requestHelp.m_Project =
          BlueprintTool.GetRef<BlueprintKingdomProject, BlueprintKingdomProjectReference>(project);
      return builder.Add(requestHelp);
    }

    /** KingdomActionChangeToAutoCrusade */
    public static ActionListBuilder EnableAutoCrusade(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionChangeToAutoCrusade>());
    }

    /** KingdomActionCollectLoot */
    public static ActionListBuilder CollectKingdomLoot(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionCollectLoot>());
    }

    /**
     * KingdomActionConquerRegion
     *
     * @param region BlueprintRegion
     */
    public static ActionListBuilder ConquerRegion(this ActionListBuilder builder, string region)
    {
      var conquer = ElementTool.Create<KingdomActionConquerRegion>();
      conquer.m_Region = BlueprintTool.GetRef<BlueprintRegion, BlueprintRegionReference>(region);
      return builder.Add(conquer);
    }

    /** KingdomActionDestroyAllSettlements */
    public static ActionListBuilder DestroyAllSettlements(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionDestroyAllSettlements>());
    }

    /** KingdomActionDisable */
    public static ActionListBuilder DisableKingdom(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionDisable>());
    }

    /** KingdomActionEnable */
    public static ActionListBuilder EnableKingdom(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionEnable>());
    }

    /**
     * KingdomActionFillSettlement
     *
     * @param settlement BlueprintSettlement
     * @param buildList SettlementBuildList
     */
    public static ActionListBuilder FillSettlement(
        this ActionListBuilder builder, string settlement, string buildList)
    {
      var fill = ElementTool.Create<KingdomActionFillSettlement>();
      fill.m_SpecificSettlement =
          BlueprintTool.GetRef<BlueprintSettlement, BlueprintSettlement.Reference>(settlement);
      fill.m_BuildList =
          BlueprintTool.GetRef<SettlementBuildList, SettlementBuildListReference>(buildList);
      return builder.Add(fill);
    }

    /** 
     * KingdomActionFillSettlementByLocation
     *
     * @param location BlueprintGlobalMapPoint
     * @param buildList SettlementBuildList
     */
    public static ActionListBuilder FillSettlementByLocation(
        this ActionListBuilder builder, string location, string buildList)
    {
      var fill = ElementTool.Create<KingdomActionFillSettlementByLocation>();
      fill.m_SpecificSettlementLocation =
          BlueprintTool.GetRef<BlueprintGlobalMapPoint, BlueprintGlobalMapPointReference>(location);
      fill.m_BuildList =
          BlueprintTool.GetRef<SettlementBuildList, SettlementBuildListReference>(buildList);
      return builder.Add(fill);
    }

    /** KingdomActionFinishRandomBuilding */
    public static ActionListBuilder FinishRandomBuilding(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionFinishRandomBuilding>());
    }

    /** KingdomActionFoundKingdom */
    public static ActionListBuilder FoundKingdom(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionFoundKingdom>());
    }

    /** 
     * KingdomActionFoundSettlement
     *
     * @param location BlueprintGlobalMapPoint
     * @param settlement BlueprintSettlement
     */
    public static ActionListBuilder FoundSettlement(
        this ActionListBuilder builder, string location, string settlement)
    {
      var found = ElementTool.Create<KingdomActionFoundSettlement>();
      found.m_Location =
          BlueprintTool
              .GetRef<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>(location);
      found.m_Settlement =
          BlueprintTool.GetRef<BlueprintSettlement, BlueprintSettlement.Reference>(settlement);
      return builder.Add(found);
    }

    /** KingdomActionGainLeaderExperience */
    public static ActionListBuilder GrantLeaderExp(
        this ActionListBuilder builder, IntEvaluator exp, float? leaderLevelMultiplier = null)
    {
      builder.Validate(exp);

      var grantExp = ElementTool.Create<KingdomActionGainLeaderExperience>();
      grantExp.m_Value = exp;
      if (leaderLevelMultiplier != null)
      {
        grantExp.m_MultiplyByLeaderLevel = true;
        grantExp.m_MultiplierCoefficient = leaderLevelMultiplier.Value;
      }
      return builder.Add(grantExp);
    }
  }
}