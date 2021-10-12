using System.Linq;
using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Armies;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Armies.TacticalCombat.GameActions;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Crusade.GlobalMagic;
using Kingmaker.Crusade.GlobalMagic.Actions;
using Kingmaker.Crusade.GlobalMagic.Actions.DamageLogic;
using Kingmaker.Crusade.GlobalMagic.Actions.SummonLogics;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Globalmap.State;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Actions;
using Kingmaker.Kingdom.AI;
using Kingmaker.Kingdom.Artisans;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Kingdom.Settlements;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;

namespace BlueprintCore.Actions.Builder.KingdomEx
{
  /** Extension to ActionListBuilder for Kingdom and Crusade related actions. */
  public static class ActionListBuilderKingdomEx
  {
    //----- Kingmaker.Armies.TacticalCombat.GameActions -----//

    /** ArmyAdditionalAction */
    public static ActionListBuilder GrantExtraArmyAction(
        this ActionListBuilder builder,
        bool usableInCurrentTurn = true,
        bool usableInBonusMoraleTurn = true)
    {
      var grantAction = ElementTool.Create<ArmyAdditionalAction>();
      grantAction.m_InCurrentTurn = usableInCurrentTurn;
      grantAction.m_CanAddInBonusMoraleTurn = usableInBonusMoraleTurn;
      return builder.Add(grantAction);
    }

    /** ContextActionAddCrusadeResource */
    public static ActionListBuilder AddCrusadeResource(
        this ActionListBuilder builder, KingdomResourcesAmount amount)
    {
      var addResource = ElementTool.Create<ContextActionAddCrusadeResource>();
      addResource.m_ResourcesAmount = amount;
      return builder.Add(addResource);
    }

    /**
     * ContextActionArmyRemoveFacts
     *
     * @param facts BlueprintUnitFact
     */
    public static ActionListBuilder RemoveArmyFacts(
        this ActionListBuilder builder, params string[] facts)
    {
      var removeFacts = ElementTool.Create<ContextActionArmyRemoveFacts>();
      removeFacts.m_FactsToRemove =
          facts
              .Select(
                  fact => BlueprintTool.GetRef<BlueprintUnitFact, BlueprintUnitFactReference>(fact))
              .ToArray();
      return builder.Add(removeFacts);
    }

    /** ContextActionRestoreLeaderAction */
    public static ActionListBuilder RestoreLeaderAction(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionRestoreLeaderAction>());
    }

    /** ContextActionStopUnit */
    public static ActionListBuilder StopUnit(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionStopUnit>());
    }

    //----- Kingmaker.Crusade.GlobalMagic.Actions -----//

    /**
     * AddBuffToSquad
     *
     * @param buff BlueprintBuff
     */
    public static ActionListBuilder BuffSquad(
        this ActionListBuilder builder,
        string buff,
        GlobalMagicValue durationHours,
        SquadFilter filter)
    {
      var buffSquad = ElementTool.Create<AddBuffToSquad>();
      buffSquad.m_Buff = BlueprintTool.GetRef<BlueprintBuff, BlueprintBuffReference>(buff);
      buffSquad.m_HoursDuration = durationHours;
      buffSquad.m_Filter = filter;
      return builder.Add(buffSquad);
    }

    /** ChangeArmyMorale */
    public static ActionListBuilder ChangeArmyMorale(
          this ActionListBuilder builder, GlobalMagicValue duration, GlobalMagicValue change)
    {
      var changeMorale = ElementTool.Create<ChangeArmyMorale>();
      changeMorale.m_Duration = duration;
      changeMorale.m_ChangeValue = change;
      return builder.Add(changeMorale);
    }

    /** FakeSkipTime */
    public static ActionListBuilder FakeSkipTime(
        this ActionListBuilder builder, GlobalMagicValue days)
    {
      var skipTime = ElementTool.Create<FakeSkipTime>();
      skipTime.m_SkipDays = days;
      return builder.Add(skipTime);
    }

    /** GainArmyDamage */
    public static ActionListBuilder GainArmyDamage(
        this ActionListBuilder builder, SquadFilter filter, GlobalMagicValue dmgDice)
    {
      var gainDmg = ElementTool.Create<GainDiceArmyDamage>();
      gainDmg.m_Filter = filter;
      gainDmg.m_DiceValue = dmgDice;
      return builder.Add(gainDmg);
    }

    /** RemoveUnitsByExp */
    public static ActionListBuilder RemoveUnitsByExp(
        this ActionListBuilder builder, SquadFilter filter, GlobalMagicValue exp)
    {
      var removeUnits = ElementTool.Create<RemoveUnitsByExp>();
      removeUnits.m_Filter = filter;
      removeUnits.m_ExpValue = exp;
      return builder.Add(removeUnits);
    }

    /**
     * GainGlobalMagicSpell
     *
     * @param spell BlueprintGlobalMagicSpell
     */
    public static ActionListBuilder GainGlobalSpell(this ActionListBuilder builder, string spell)
    {
      var gainSpell = ElementTool.Create<GainGlobalMagicSpell>();
      gainSpell.m_Spell =
          BlueprintTool
              .GetRef<BlueprintGlobalMagicSpell, BlueprintGlobalMagicSpell.Reference>(spell);
      return builder.Add(gainSpell);
    }

    /**
     * ManuallySetGlobalSpellCooldown
     *
     * @param spell BlueprintGlobalMagicSpell
     */
    public static ActionListBuilder PutGlobalSpellOnCooldown(
        this ActionListBuilder builder, string spell)
    {
      var activateCooldown = ElementTool.Create<ManuallySetGlobalSpellCooldown>();
      activateCooldown.m_Spell =
          BlueprintTool
              .GetRef<BlueprintGlobalMagicSpell, BlueprintGlobalMagicSpell.Reference>(spell);
      return builder.Add(activateCooldown);
    }

    /** OpenTeleportationInterface */
    public static ActionListBuilder GlobalTeleport(
        this ActionListBuilder builder, ActionListBuilder onTeleport)
    {
      var teleport = ElementTool.Create<OpenTeleportationInterface>();
      teleport.m_OnTeleportActions = onTeleport.Build();
      return builder.Add(teleport);
    }

    /**
     * RemoveGlobalMagicSpell
     *
     * @param spell BlueprintGlobalMagicSpell
     */
    public static ActionListBuilder RemoveGlobalSpell(this ActionListBuilder builder, string spell)
    {
      var removespell = ElementTool.Create<RemoveGlobalMagicSpell>();
      removespell.m_Spell =
          BlueprintTool
              .GetRef<BlueprintGlobalMagicSpell, BlueprintGlobalMagicSpell.Reference>(spell);
      return builder.Add(removespell);
    }

    /** RepairLeaderMana */
    public static ActionListBuilder RestoreLeaderMana(
        this ActionListBuilder builder, GlobalMagicValue value)
    {
      var restoreMana = ElementTool.Create<RepairLeaderMana>();
      restoreMana.m_Value = value;
      return builder.Add(restoreMana);
    }

    /** SummonExistUnits */
    public static ActionListBuilder SummonMoreUnits(
        this ActionListBuilder builder, GlobalMagicValue expCost)
    {
      var summon = ElementTool.Create<SummonExistUnits>();
      summon.m_SumExpCost = expCost;
      return builder.Add(summon);
    }

    /** SummonRandomGroup */
    public static ActionListBuilder SummonRandomGroup(
        this ActionListBuilder builder,
        params SummonRandomGroup.RandomGroup[] groups)
    {
      var summon = ElementTool.Create<SummonRandomGroup>();
      summon.m_RandomGroups = groups;
      return builder.Add(summon);
    }

    /** TeleportArmyAction */
    public static ActionListBuilder TeleportArmy(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<TeleportArmyAction>());
    }

    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

    /**
     * CreateArmy
     *
     * @param army BlueprintArmyPreset
     * @param location BlueprintGlobalMapPoint
     * @param leader BlueprintArmyLeader
     */
    public static ActionListBuilder CreateCrusaderArmy(
        this ActionListBuilder builder,
        string army,
        string location,
        string leader = null,
        int? movePoints = null,
        float? speed = null,
        bool? applyRecruitIncrease = null)
    {
      return builder.Add(
          CreateArmy(
              ArmyFaction.Crusaders,
              army,
              location,
              leader,
              movePoints: movePoints,
              speed: speed,
              applyRecruitIncrease: applyRecruitIncrease));
    }

    /**
     * CreateArmyFromLosses
     *
     * @param location BlueprintGlobalMapPoint
     */
    public static ActionListBuilder CreateCrusaderArmyFromLosses(
        this ActionListBuilder builder,
        string location,
        int sumExperience,
        int maxSquads,
        bool applyRecruitIncrease = false)
    {
      var createArmy = ElementTool.Create<CreateArmyFromLosses>();
      createArmy.m_Location =
          BlueprintTool
              .GetRef<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>(location);
      createArmy.m_SumExperience = sumExperience;
      createArmy.m_SquadsMaxCount = maxSquads;
      createArmy.m_ApplyRecruitIncrease = applyRecruitIncrease;
      return builder.Add(createArmy);
    }

    /**
     * CreateArmy
     *
     * @param army BlueprintArmyPreset
     * @param location BlueprintGlobalMapPoint
     * @param leader BlueprintArmyLeader
     */
    public static ActionListBuilder CreateDemonArmy(
        this ActionListBuilder builder,
        string army,
        string location,
        string leader = null,
        bool targetNearestEnemy = false,
        float? speed = null)
    {
      return builder.Add(
          CreateArmy(
              ArmyFaction.Demons,
              army,
              location,
              leader,
              target: targetNearestEnemy ? TravelLogicType.NearestEnemy : TravelLogicType.None,
              speed: speed));
    }

    /**
     * CreateArmy
     *
     * @param army BlueprintArmyPreset
     * @param location BlueprintGlobalMapPoint
     * @param targetLocation BlueprintGlobalMapPoint
     * @param onTargetReached BlueprintActionList
     * @param leader BlueprintArmyLeader
     */
    public static ActionListBuilder CreateDemonArmyTargetingLocation(
        this ActionListBuilder builder,
        string army,
        string location,
        string targetLocation,
        string onTargetReached = null,
        string leader = null,
        int? daysToTarget = null)
    {
      return builder.Add(
          CreateArmy(
              ArmyFaction.Demons,
              army,
              location,
              leader,
              targetLocation: targetLocation,
              onTargetReached: onTargetReached,
              daysToTarget: daysToTarget,
              target: TravelLogicType.Location));
    }

    private static CreateArmy CreateArmy(
        ArmyFaction faction,
        string army,
        string location,
        string leader,
        string targetLocation = null,
        string onTargetReached = null,
        int? daysToTarget = null,
        int? movePoints = null,
        float? speed = null,
        bool? applyRecruitIncrease = null,
        TravelLogicType target = TravelLogicType.None)
    {
      var createArmy = ElementTool.Create<CreateArmy>();
      createArmy.Faction = faction;
      createArmy.Preset =
          BlueprintTool.GetRef<BlueprintArmyPreset, BlueprintArmyPreset.Reference>(army);
      createArmy.Location =
          BlueprintTool
              .GetRef<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>(location);
      createArmy.m_MoveTarget = target;

      createArmy.m_DaysToDestination = daysToTarget ?? 7;
      createArmy.MovementPoints = movePoints ?? 60;
      createArmy.m_ArmySpeed = speed ?? 1f;
      createArmy.m_ApplyRecruitIncrease = applyRecruitIncrease ?? false;

      if (leader == null)
      {
        createArmy.ArmyLeader = BlueprintReferenceBase.CreateTyped<ArmyLeader.Reference>(null);
      }
      else
      {
        createArmy.ArmyLeader =
            BlueprintTool.GetRef<BlueprintArmyLeader, ArmyLeader.Reference>(leader);
        createArmy.WithLeader = true;
      }
      createArmy.m_TargetLocation =
          targetLocation == null
              ? BlueprintReferenceBase.CreateTyped<BlueprintGlobalMapPoint.Reference>(null)
              : BlueprintTool
                  .GetRef<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>(
                      targetLocation);
      createArmy.m_CompleteActions =
          onTargetReached == null
              ? BlueprintReferenceBase.CreateTyped<BlueprintActionList.Reference>(null)
              : BlueprintTool
                  .GetRef<BlueprintActionList, BlueprintActionList.Reference>(onTargetReached);
      return createArmy;
    }

    /**
     * CreateGarrison
     *
     * @param army BlueprintArmyPreset
     * @param location BlueprintGlobalMapPoint
     * @param leader BlueprintArmyLeader
     */
    public static ActionListBuilder CreateGarrison(
        this ActionListBuilder builder,
        string army,
        string location,
        string leader = null,
        bool noReward = true)
    {
      var createGarrison = ElementTool.Create<CreateGarrison>();
      createGarrison.Preset =
          BlueprintTool.GetRef<BlueprintArmyPreset, BlueprintArmyPreset.Reference>(army);
      createGarrison.Location =
          BlueprintTool
              .GetRef<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>(location);
      createGarrison.HasNoReward = noReward;

      if (leader == null)
      {
        createGarrison.ArmyLeader = BlueprintReferenceBase.CreateTyped<ArmyLeader.Reference>(null);
      }
      else
      {
        createGarrison.WithLeader = true;
        createGarrison.ArmyLeader =
            BlueprintTool.GetRef<BlueprintArmyLeader, ArmyLeader.Reference>(leader);
      }
      return builder.Add(createGarrison);
    }

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

    //----- Kingmaker.Kingdom.Blueprints -----//

    /** AddCrusadeResources */
    public static ActionListBuilder AddCrusadeResources(
        this ActionListBuilder builder, KingdomResourcesAmount resources)
    {
      var addResources = ElementTool.Create<AddCrusadeResources>();
      addResources._resourcesAmount = resources;
      return builder.Add(addResources);
    }

    //----- Kingmaker.UnitLogic.Mechanics.Actions -----//

    /** ChangeTacticalMorale */
    public static ActionListBuilder ChangeTacticalMorale(
        this ActionListBuilder builder, ContextValue value)
    {
      var changeMorale = ElementTool.Create<ChangeTacticalMorale>();
      changeMorale.m_Value = value;
      return builder.Add(changeMorale);
    }

    /**
     * ContextActionSquadUnitsKill
     *
     * Use this to kill non-leader units from the caster's squad. Use KillSquadLeaders for leader
     * units.
     *
     * @param percent float Value from 0.0-1.0 indicating the percent of squad units to kill.
     */
    public static ActionListBuilder KillSquadUnits(this ActionListBuilder builder, float percent)
    {
      var kill = ElementTool.Create<ContextActionSquadUnitsKill>();
      kill.m_UseFloatValue = true;
      kill.m_FloatCount = percent;
      return builder.Add(kill);
    }

    /**
     * ContextActionSquadUnitsKill
     *
     * Use this to kill leader units from the caster's squad. Use KillSquadUnits for regular units.
     */
    public static ActionListBuilder KillSquadLeaders(
        this ActionListBuilder builder, ContextDiceValue count)
    {
      var kill = ElementTool.Create<ContextActionSquadUnitsKill>();
      kill.m_Count = count;
      return builder.Add(kill);
    }

    /**
     * ContextActionSummonTacticalSquad
     *
     * @param unit BlueprintUnit
     * @param summonPool BlueprintSummonPool
     */
    public static ActionListBuilder SummonSquad(
        this ActionListBuilder builder,
        string unit,
        ContextValue count,
        ActionListBuilder onSpawn = null,
        string summonPool = null)
    {
      var summon = ElementTool.Create<ContextActionSummonTacticalSquad>();
      summon.m_Blueprint = BlueprintTool.GetRef<BlueprintUnit, BlueprintUnitReference>(unit);
      summon.m_Count = count;
      summon.m_AfterSpawn = onSpawn?.Build() ?? Constants.Empty.Actions;
      summon.m_SummonPool =
          summonPool is null
              ? null
              : BlueprintTool.GetRef<BlueprintSummonPool, BlueprintSummonPoolReference>(summonPool);
      return builder.Add(summon);
    }

    /** ContextActionTacticalCombatDealDamage */
    public static ActionListBuilder TacticalCombatDealDamage(
        this ActionListBuilder builder,
        DamageTypeDescription type,
        DiceType diceType,
        ContextValue diceRolls = null,
        bool dealHalf = false,
        bool ignoreCrit = false,
        int? minHPAfterDmg = null)
    {
      var dmg = ElementTool.Create<ContextActionTacticalCombatDealDamage>();
      dmg.DamageType = type;
      dmg.DiceType = diceType;
      dmg.RollsCount = diceRolls ?? dmg.RollsCount;
      dmg.Half = dealHalf;
      dmg.IgnoreCritical = ignoreCrit;

      if (minHPAfterDmg != null)
      {
        dmg.UseMinHPAfterDamage = true;
        dmg.MinHPAfterDamage = minHPAfterDmg.Value;
      }
      return builder.Add(dmg);
    }

    /** ContextActionTacticalCombatHealTarget */
    public static ActionListBuilder TacticalCombatHeal(
        this ActionListBuilder builder,
        DiceType diceType = DiceType.D6,
        ContextValue diceRolls = null)
    {
      var heal = ElementTool.Create<ContextActionTacticalCombatHealTarget>();
      heal.DiceType = diceType;
      heal.RollsCount = diceRolls ?? heal.RollsCount;
      return builder.Add(heal);
    }
  }
}