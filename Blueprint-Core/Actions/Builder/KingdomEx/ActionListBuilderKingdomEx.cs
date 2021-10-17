using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Armies;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Armies.TacticalCombat.GameActions;
using Kingmaker.Blueprints;
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
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using System.Linq;

namespace BlueprintCore.Actions.Builder.KingdomEx
{
  /// <summary>
  /// Extension to <see cref="ActionListBuilder"/> for actions involving the Kingdom and Crusade
  /// system.
  /// </summary>
  /// <inheritdoc cref="ActionListBuilder"/>
  public static class ActionListBuilderKingdomEx
  {
    //----- Kingmaker.Armies.TacticalCombat.GameActions -----//

    /// <summary>
    /// Adds <see cref="ArmyAdditionalAction"/>
    /// </summary>
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

    /// <summary>
    /// Adds <see cref="ContextActionAddCrusadeResource"/>
    /// </summary>
    public static ActionListBuilder AddCrusadeResource(
        this ActionListBuilder builder, KingdomResourcesAmount amount)
    {
      var addResource = ElementTool.Create<ContextActionAddCrusadeResource>();
      addResource.m_ResourcesAmount = amount;
      return builder.Add(addResource);
    }

    /// <summary>
    /// Adds <see cref="ContextActionArmyRemoveFacts"/>
    /// </summary>
    /// 
    /// <param name="facts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact">BlueprintUnitFact</see></param>
    public static ActionListBuilder RemoveArmyFacts(
        this ActionListBuilder builder, params string[] facts)
    {
      var removeFacts = ElementTool.Create<ContextActionArmyRemoveFacts>();
      removeFacts.m_FactsToRemove =
          facts.Select(fact => BlueprintTool.GetRef<BlueprintUnitFactReference>(fact)).ToArray();
      return builder.Add(removeFacts);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRestoreLeaderAction"/>
    /// </summary>
    public static ActionListBuilder RestoreLeaderAction(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionRestoreLeaderAction>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionStopUnit"/>
    /// </summary>
    public static ActionListBuilder StopUnit(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionStopUnit>());
    }

    //----- Kingmaker.Crusade.GlobalMagic.Actions -----//

    /// <summary>
    /// Adds <see cref="AddBuffToSquad"/>
    /// </summary>
    /// 
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff">BlueprintBuff</see></param>
    public static ActionListBuilder BuffSquad(
        this ActionListBuilder builder,
        string buff,
        GlobalMagicValue durationHours,
        SquadFilter filter)
    {
      var buffSquad = ElementTool.Create<AddBuffToSquad>();
      buffSquad.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      buffSquad.m_HoursDuration = durationHours;
      buffSquad.m_Filter = filter;
      return builder.Add(buffSquad);
    }

    /// <summary>
    /// Adds <see cref="ChangeArmyMorale"/>
    /// </summary>
    public static ActionListBuilder ChangeArmyMorale(
          this ActionListBuilder builder, GlobalMagicValue duration, GlobalMagicValue change)
    {
      var changeMorale = ElementTool.Create<ChangeArmyMorale>();
      changeMorale.m_Duration = duration;
      changeMorale.m_ChangeValue = change;
      return builder.Add(changeMorale);
    }

    /// <summary>
    /// Adds <see cref="FakeSkipTime"/>
    /// </summary>
    public static ActionListBuilder FakeSkipTime(this ActionListBuilder builder, GlobalMagicValue days)
    {
      var skipTime = ElementTool.Create<FakeSkipTime>();
      skipTime.m_SkipDays = days;
      return builder.Add(skipTime);
    }

    /// <summary>
    /// Adds <see cref="GainDiceArmyDamage"/>
    /// </summary>
    public static ActionListBuilder GainArmyDamage(
        this ActionListBuilder builder, SquadFilter filter, GlobalMagicValue dmgDice)
    {
      var gainDmg = ElementTool.Create<GainDiceArmyDamage>();
      gainDmg.m_Filter = filter;
      gainDmg.m_DiceValue = dmgDice;
      return builder.Add(gainDmg);
    }

    /// <summary>
    /// Adds <see cref="RemoveUnitsByExp"/>
    /// </summary>
    public static ActionListBuilder RemoveUnitsByExp(
        this ActionListBuilder builder, SquadFilter filter, GlobalMagicValue exp)
    {
      var removeUnits = ElementTool.Create<RemoveUnitsByExp>();
      removeUnits.m_Filter = filter;
      removeUnits.m_ExpValue = exp;
      return builder.Add(removeUnits);
    }

    /// <summary>
    /// Adds <see cref="GainGlobalMagicSpell"/>
    /// </summary>
    /// 
    /// <param name="spell"><see cref="BlueprintGlobalMagicSpell"/></param>
    public static ActionListBuilder GainGlobalSpell(this ActionListBuilder builder, string spell)
    {
      var gainSpell = ElementTool.Create<GainGlobalMagicSpell>();
      gainSpell.m_Spell = BlueprintTool.GetRef<BlueprintGlobalMagicSpell.Reference>(spell);
      return builder.Add(gainSpell);
    }

    /// <summary>
    /// Adds <see cref="ManuallySetGlobalSpellCooldown"/>
    /// </summary>
    /// 
    /// <param name="spell"><see cref="BlueprintGlobalMagicSpell"/></param>
    public static ActionListBuilder PutGlobalSpellOnCooldown(this ActionListBuilder builder, string spell)
    {
      var activateCooldown = ElementTool.Create<ManuallySetGlobalSpellCooldown>();
      activateCooldown.m_Spell = BlueprintTool.GetRef<BlueprintGlobalMagicSpell.Reference>(spell);
      return builder.Add(activateCooldown);
    }

    /// <summary>
    /// Adds <see cref="OpenTeleportationInterface"/>
    /// </summary>
    public static ActionListBuilder GlobalTeleport(this ActionListBuilder builder, ActionListBuilder onTeleport)
    {
      var teleport = ElementTool.Create<OpenTeleportationInterface>();
      teleport.m_OnTeleportActions = onTeleport.Build();
      return builder.Add(teleport);
    }

    /// <summary>
    /// Adds <see cref="RemoveGlobalMagicSpell"/>
    /// </summary>
    /// 
    /// <param name="spell"><see cref="BlueprintGlobalMagicSpell"/></param>
    public static ActionListBuilder RemoveGlobalSpell(this ActionListBuilder builder, string spell)
    {
      var removespell = ElementTool.Create<RemoveGlobalMagicSpell>();
      removespell.m_Spell = BlueprintTool.GetRef<BlueprintGlobalMagicSpell.Reference>(spell);
      return builder.Add(removespell);
    }

    /// <summary>
    /// Adds <see cref="RepairLeaderMana"/>
    /// </summary>
    public static ActionListBuilder RestoreLeaderMana(this ActionListBuilder builder, GlobalMagicValue value)
    {
      var restoreMana = ElementTool.Create<RepairLeaderMana>();
      restoreMana.m_Value = value;
      return builder.Add(restoreMana);
    }

    /// <summary>
    /// Adds <see cref="SummonExistUnits"/>
    /// </summary>
    public static ActionListBuilder SummonMoreUnits(
        this ActionListBuilder builder, GlobalMagicValue expCost)
    {
      var summon = ElementTool.Create<SummonExistUnits>();
      summon.m_SumExpCost = expCost;
      return builder.Add(summon);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Crusade.GlobalMagic.Actions.SummonLogics.SummonRandomGroup">SummonRandomGroup</see>
    /// </summary>
    public static ActionListBuilder SummonRandomGroup(
        this ActionListBuilder builder,
        params SummonRandomGroup.RandomGroup[] groups)
    {
      var summon = ElementTool.Create<SummonRandomGroup>();
      summon.m_RandomGroups = groups;
      return builder.Add(summon);
    }

    /// <summary>
    /// Adds <see cref="TeleportArmyAction"/>
    /// </summary>
    public static ActionListBuilder TeleportArmy(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<TeleportArmyAction>());
    }

    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.CreateArmy">CreateArmy</see>
    /// </summary>
    /// 
    /// <param name="army"><see cref="BlueprintArmyPreset"/></param>
    /// <param name="location"><see cref="BlueprintGlobalMapPoint"/></param>
    /// <param name="leader"><see cref="BlueprintArmyLeader"/></param>
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

    /// <inheritdoc cref="CreateCrusaderArmy"/>
    public static ActionListBuilder CreateCrusaderArmyFromLosses(
        this ActionListBuilder builder,
        string location,
        int sumExperience,
        int maxSquads,
        bool applyRecruitIncrease = false)
    {
      var createArmy = ElementTool.Create<CreateArmyFromLosses>();
      createArmy.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(location);
      createArmy.m_SumExperience = sumExperience;
      createArmy.m_SquadsMaxCount = maxSquads;
      createArmy.m_ApplyRecruitIncrease = applyRecruitIncrease;
      return builder.Add(createArmy);
    }

    /// <inheritdoc cref="CreateCrusaderArmy"/>
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


    /// <inheritdoc cref="CreateCrusaderArmy"/>
    /// 
    /// <param name="targetLocation"><see cref="BlueprintGlobalMapPoint"/></param>
    /// <param name="onTargetReached"><see cref="BlueprintActionList"/></param>
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
      createArmy.Preset = BlueprintTool.GetRef<BlueprintArmyPreset.Reference>(army);
      createArmy.Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(location);
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
        createArmy.ArmyLeader = BlueprintTool.GetRef<ArmyLeader.Reference>(leader);
        createArmy.WithLeader = true;
      }
      createArmy.m_TargetLocation =
          BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(targetLocation);
      createArmy.m_CompleteActions =
          BlueprintTool.GetRef<BlueprintActionList.Reference>(onTargetReached);
      return createArmy;
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.CreateGarrison">CreateGarrison</see>
    /// </summary>
    /// 
    /// <param name="army"><see cref="BlueprintArmyPreset"/></param>
    /// <param name="location"><see cref="BlueprintGlobalMapPoint"/></param>
    /// <param name="leader"><see cref="BlueprintArmyLeader"/></param>
    public static ActionListBuilder CreateGarrison(
        this ActionListBuilder builder,
        string army,
        string location,
        string leader = null,
        bool noReward = true)
    {
      var createGarrison = ElementTool.Create<CreateGarrison>();
      createGarrison.Preset = BlueprintTool.GetRef<BlueprintArmyPreset.Reference>(army);
      createGarrison.Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(location);
      createGarrison.HasNoReward = noReward;

      if (leader == null)
      {
        createGarrison.ArmyLeader = BlueprintReferenceBase.CreateTyped<ArmyLeader.Reference>(null);
      }
      else
      {
        createGarrison.WithLeader = true;
        createGarrison.ArmyLeader = BlueprintTool.GetRef<ArmyLeader.Reference>(leader);
      }
      return builder.Add(createGarrison);
    }

    //----- Kingmaker.Kingdom.Actions -----//

    /// <summary>
    /// Adds <see cref="AddMorale"/>
    /// </summary>
    public static ActionListBuilder IncreaseMorale(this ActionListBuilder builder, DiceFormula value, int bonus)
    {
      var increaseMorale = ElementTool.Create<AddMorale>();
      increaseMorale.Change = value;
      increaseMorale.Bonus = bonus;
      return builder.Add(increaseMorale);
    }

    /// <inheritdoc cref="IncreaseMorale"/>
    public static ActionListBuilder ReduceMorale(this ActionListBuilder builder, DiceFormula value, int bonus)
    {
      var reduceMorale = ElementTool.Create<AddMorale>();
      reduceMorale.Change = value;
      reduceMorale.Bonus = bonus;
      reduceMorale.Substract = true;
      return builder.Add(reduceMorale);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionActivateEventDeck"/>
    /// </summary>
    /// 
    /// <param name="deck"><see cref="BlueprintKingdomDeck"/></param>
    public static ActionListBuilder ActivateEventDeck(this ActionListBuilder builder, string deck)
    {
      var activateDeck = ElementTool.Create<KingdomActionActivateEventDeck>();
      activateDeck.m_Deck = BlueprintTool.GetRef<BlueprintKingdomDeckReference>(deck);
      return builder.Add(activateDeck);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionAddBPRandom"/>
    /// </summary>
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

    /// <summary>
    /// Adds <see cref="KingdomActionAddBuff"/>
    /// </summary>
    /// 
    /// <param name="buff"><see cref="BlueprintKingdomBuff"/></param>
    /// <param name="targetRegion"><see cref="BlueprintRegion"/></param>
    public static ActionListBuilder AddKingdomBuff(
        this ActionListBuilder builder,
        string buff,
        int durationOverrideDays = 0,
        string targetRegion = null,
        bool applyToRegion = true,
        bool applyToAdjacentRegions = false)
    {
      var addBuff = ElementTool.Create<KingdomActionAddBuff>();
      addBuff.m_Blueprint = BlueprintTool.GetRef<BlueprintKingdomBuffReference>(buff);
      addBuff.OverrideDuration = durationOverrideDays;
      addBuff.m_Region = BlueprintTool.GetRef<BlueprintRegionReference>(targetRegion);
      addBuff.ApplyToRegion = applyToRegion;
      addBuff.CopyToAdjacentRegions = applyToAdjacentRegions;
      return builder.Add(addBuff);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionAddFreeBuilding"/>
    /// </summary>
    /// 
    /// <param name="building"><see cref="Kingmaker.Kingdom.Settlements.BlueprintSettlementBuilding">BlueprintSettlementBuilding</see></param>
    /// <param name="settlement"><see cref="BlueprintSettlement"/></param>
    public static ActionListBuilder AddFreeBuilding(
        this ActionListBuilder builder, string building, int count = 1, string settlement = null)
    {
      var addBuilding = ElementTool.Create<KingdomActionAddFreeBuilding>();
      addBuilding.m_Building = BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(building);
      addBuilding.Count = count;
      if (settlement == null)
      {
        addBuilding.Anywhere = true;
      }
      else
      {
        addBuilding.Anywhere = false;
        addBuilding.m_Settlement = BlueprintTool.GetRef<BlueprintSettlement.Reference>(settlement);
      }
      return builder.Add(addBuilding);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionAddMercenaryReroll"/>
    /// </summary>
    public static ActionListBuilder AddFreeMercRerolls(this ActionListBuilder builder, int count = 1)
    {
      var addMercRerolls = ElementTool.Create<KingdomActionAddMercenaryReroll>();
      addMercRerolls.m_FreeRerollsToAdd = count;
      return builder.Add(addMercRerolls);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionAddRandomBuff"/>
    /// </summary>
    /// 
    /// <param name="buffs"><see cref="BlueprintKingdomBuff"/></param>
    public static ActionListBuilder AddRandomKingdomBuff(
        this ActionListBuilder builder, string[] buffs, int durationOverrideDays = 0)
    {
      var addBuff = ElementTool.Create<KingdomActionAddRandomBuff>();
      addBuff.m_Buffs =
          buffs.Select(buff => BlueprintTool.GetRef<BlueprintKingdomBuffReference>(buff)).ToList();
      addBuff.OverrideDurationDays = durationOverrideDays;
      return builder.Add(addBuff);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionArtisanRequestHelp"/>
    /// </summary>
    /// 
    /// <param name="artisan"><see cref="Kingmaker.Kingdom.Artisans.BlueprintKingdomArtisan">BlueprintKingdomArtisan</see></param>
    /// <param name="project"><see cref="BlueprintKingdomProject"/></param>
    public static ActionListBuilder ArtisanRequestHelp(this ActionListBuilder builder, string artisan, string project)
    {
      var requestHelp = ElementTool.Create<KingdomActionArtisanRequestHelp>();
      requestHelp.m_Artisan = BlueprintTool.GetRef<BlueprintKingdomArtisanReference>(artisan);
      requestHelp.m_Project = BlueprintTool.GetRef<BlueprintKingdomProjectReference>(project);
      return builder.Add(requestHelp);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionChangeToAutoCrusade"/>
    /// </summary>
    public static ActionListBuilder EnableAutoCrusade(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionChangeToAutoCrusade>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionCollectLoot"/>
    /// </summary>
    public static ActionListBuilder CollectKingdomLoot(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionCollectLoot>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionConquerRegion"/>
    /// </summary>
    /// 
    /// <param name="region"><see cref="BlueprintRegion"/></param>
    public static ActionListBuilder ConquerRegion(this ActionListBuilder builder, string region)
    {
      var conquer = ElementTool.Create<KingdomActionConquerRegion>();
      conquer.m_Region = BlueprintTool.GetRef<BlueprintRegionReference>(region);
      return builder.Add(conquer);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionDestroyAllSettlements"/>
    /// </summary>
    public static ActionListBuilder DestroyAllSettlements(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionDestroyAllSettlements>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionDisable"/>
    /// </summary>
    public static ActionListBuilder DisableKingdom(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionDisable>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionEnable"/>
    /// </summary>
    public static ActionListBuilder EnableKingdom(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionEnable>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionFillSettlement"/>
    /// </summary>
    /// 
    /// <param name="settlement"><see cref="BlueprintSettlement"/></param>
    /// <param name="buildList"><see cref="Kingmaker.Kingdom.AI.SettlementBuildList">SettlementBuildList</see></param>
    public static ActionListBuilder FillSettlement(
        this ActionListBuilder builder, string settlement, string buildList)
    {
      var fill = ElementTool.Create<KingdomActionFillSettlement>();
      fill.m_SpecificSettlement = BlueprintTool.GetRef<BlueprintSettlement.Reference>(settlement);
      fill.m_BuildList = BlueprintTool.GetRef<SettlementBuildListReference>(buildList);
      return builder.Add(fill);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionFillSettlementByLocation"/>
    /// </summary>
    /// 
    /// <param name="location"><see cref="BlueprintGlobalMapPoint"/></param>
    /// <param name="buildList"><see cref="Kingmaker.Kingdom.AI.SettlementBuildList">SettlementBuildList</see></param>
    public static ActionListBuilder FillSettlementByLocation(
        this ActionListBuilder builder, string location, string buildList)
    {
      var fill = ElementTool.Create<KingdomActionFillSettlementByLocation>();
      fill.m_SpecificSettlementLocation =
          BlueprintTool.GetRef<BlueprintGlobalMapPointReference>(location);
      fill.m_BuildList = BlueprintTool.GetRef<SettlementBuildListReference>(buildList);
      return builder.Add(fill);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionFinishRandomBuilding"/>
    /// </summary>
    public static ActionListBuilder FinishRandomBuilding(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionFinishRandomBuilding>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionFoundKingdom"/>
    /// </summary>
    public static ActionListBuilder FoundKingdom(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<KingdomActionFoundKingdom>());
    }

    /// <summary>
    /// Adds <see cref="KingdomActionFoundSettlement"/>
    /// </summary>
    /// 
    /// <param name="location"><see cref="BlueprintGlobalMapPoint"/></param>
    /// <param name="settlement"><see cref="BlueprintSettlement"/></param>
    public static ActionListBuilder FoundSettlement(
        this ActionListBuilder builder, string location, string settlement)
    {
      var found = ElementTool.Create<KingdomActionFoundSettlement>();
      found.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(location);
      found.m_Settlement = BlueprintTool.GetRef<BlueprintSettlement.Reference>(settlement);
      return builder.Add(found);
    }

    /// <summary>
    /// Adds <see cref="KingdomActionGainLeaderExperience"/>
    /// </summary>
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

    /// <summary>
    /// Adds <see cref="Kingmaker.Kingdom.Blueprints.AddCrusadeResources">AddCrusadeResources</see>
    /// </summary>
    public static ActionListBuilder AddCrusadeResources(
        this ActionListBuilder builder, KingdomResourcesAmount resources)
    {
      var addResources = ElementTool.Create<AddCrusadeResources>();
      addResources._resourcesAmount = resources;
      return builder.Add(addResources);
    }

    //----- Kingmaker.UnitLogic.Mechanics.Actions -----//

    /// <summary>
    /// Adds <see cref="Kingmaker.UnitLogic.Mechanics.Actions.ChangeTacticalMorale">ChangeTacticalMorale</see>
    /// </summary>
    public static ActionListBuilder ChangeTacticalMorale(
        this ActionListBuilder builder, ContextValue value)
    {
      var changeMorale = ElementTool.Create<ChangeTacticalMorale>();
      changeMorale.m_Value = value;
      return builder.Add(changeMorale);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSquadUnitsKill"/>
    /// </summary>
    /// 
    /// <remarks>
    /// Use this to kill non-leader units from the caster's squad. Use <see cref="KillSquadLeaders"/> for leaders units.
    /// </remarks>
    /// 
    /// <param name="percent">Percentage of squad units to kill as a float between 0.0 and 1.0.</param>
    public static ActionListBuilder KillSquadUnits(this ActionListBuilder builder, float percent)
    {
      var kill = ElementTool.Create<ContextActionSquadUnitsKill>();
      kill.m_UseFloatValue = true;
      kill.m_FloatCount = percent;
      return builder.Add(kill);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSquadUnitsKill"/>
    /// </summary>
    /// 
    /// <remarks>
    /// Use this to kill leader units from the caster's squad. Use <see cref="KillSquadUnits"/> for regular units.
    /// </remarks>
    public static ActionListBuilder KillSquadLeaders(
        this ActionListBuilder builder, ContextDiceValue count)
    {
      var kill = ElementTool.Create<ContextActionSquadUnitsKill>();
      kill.m_Count = count;
      return builder.Add(kill);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSummonTacticalSquad"/>
    /// </summary>
    /// 
    /// <param name="unit"><see cref="BlueprintUnit"/></param>
    /// <param name="summonPool"><see cref="BlueprintSummonPool"/></param>
    public static ActionListBuilder SummonSquad(
        this ActionListBuilder builder,
        string unit,
        ContextValue count,
        ActionListBuilder onSpawn = null,
        string summonPool = null)
    {
      var summon = ElementTool.Create<ContextActionSummonTacticalSquad>();
      summon.m_Blueprint = BlueprintTool.GetRef<BlueprintUnitReference>(unit);
      summon.m_Count = count;
      summon.m_AfterSpawn = onSpawn?.Build() ?? Constants.Empty.Actions;
      summon.m_SummonPool =
          summonPool is null
              ? null
              : BlueprintTool.GetRef<BlueprintSummonPoolReference>(summonPool);
      return builder.Add(summon);
    }

    /// <summary>
    /// Adds <see cref="ContextActionTacticalCombatDealDamage"/>
    /// </summary>
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

    /// <summary>
    /// Adds <see cref="ContextActionTacticalCombatHealTarget"/>
    /// </summary>
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