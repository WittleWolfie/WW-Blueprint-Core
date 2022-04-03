//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Assets.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items;
using Kingmaker.Designers;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Designers.EventConditionActionSystem.NamedParameters;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Conditions;

namespace BlueprintCore.Conditions.Builder.BasicEx
{
  /// <summary>
  /// Extension to <see cref="ConditionsBuilder"/> for most game mechanics related conditions not included in <see cref="ContextEx.ConditionsBuilderContextEx">ContextEx</see>.
  /// </summary>
  /// <inheritdoc cref="ConditionsBuilder"/>
  public static class ConditionsBuilderBasicEx
  {

    /// <summary>
    /// Adds <see cref="BuffConditionCheckRoundNumber"/>
    /// </summary>
    public static ConditionsBuilder BuffConditionCheckRoundNumber(
        this ConditionsBuilder builder,
        bool negate = false,
        int? roundNumber = null)
    {
      var element = ElementTool.Create<BuffConditionCheckRoundNumber>();
      element.Not = negate;
      element.RoundNumber = roundNumber ?? element.RoundNumber;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CheckConditionsHolder"/>
    /// </summary>
    ///
    /// <param name="conditionsHolder">
    /// Blueprint of type ConditionsHolder. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder CheckConditionsHolder(
        this ConditionsBuilder builder,
        Blueprint<ConditionsHolder, ConditionsReference>? conditionsHolder = null,
        bool negate = false,
        ParametrizedContextSetter? parameters = null)
    {
      var element = ElementTool.Create<CheckConditionsHolder>();
      element.ConditionsHolder = conditionsHolder?.Reference ?? element.ConditionsHolder;
      if (element.ConditionsHolder is null)
      {
        element.ConditionsHolder = BlueprintTool.GetRef<ConditionsReference>(null);
      }
      element.Not = negate;
      builder.Validate(parameters);
      element.Parameters = parameters ?? element.Parameters;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CheckItemCondition"/>
    /// </summary>
    ///
    /// <param name="targetItem">
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder CheckItemCondition(
        this ConditionsBuilder builder,
        bool negate = false,
        CheckItemCondition.RequiredState? requiredState = null,
        Blueprint<BlueprintItem, BlueprintItemReference>? targetItem = null,
        UnitEvaluator? unitEvaluator = null)
    {
      var element = ElementTool.Create<CheckItemCondition>();
      element.Not = negate;
      element.m_RequiredState = requiredState ?? element.m_RequiredState;
      element.m_TargetItem = targetItem?.Reference ?? element.m_TargetItem;
      if (element.m_TargetItem is null)
      {
        element.m_TargetItem = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      builder.Validate(unitEvaluator);
      element.m_UnitEvaluator = unitEvaluator ?? element.m_UnitEvaluator;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CompanionInParty"/>
    /// </summary>
    ///
    /// <param name="companion">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder CompanionInParty(
        this ConditionsBuilder builder,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? companion = null,
        bool? matchWhenActive = null,
        bool? matchWhenDead = null,
        bool? matchWhenDetached = null,
        bool? matchWhenEx = null,
        bool? matchWhenRemote = null,
        bool negate = false)
    {
      var element = ElementTool.Create<CompanionInParty>();
      element.m_companion = companion?.Reference ?? element.m_companion;
      if (element.m_companion is null)
      {
        element.m_companion = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      element.MatchWhenActive = matchWhenActive ?? element.MatchWhenActive;
      element.MatchWhenDead = matchWhenDead ?? element.MatchWhenDead;
      element.MatchWhenDetached = matchWhenDetached ?? element.MatchWhenDetached;
      element.MatchWhenEx = matchWhenEx ?? element.MatchWhenEx;
      element.MatchWhenRemote = matchWhenRemote ?? element.MatchWhenRemote;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CompanionIsDead"/>
    /// </summary>
    ///
    /// <param name="companion">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder CompanionIsDead(
        this ConditionsBuilder builder,
        bool? anyCompanion = null,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? companion = null,
        bool negate = false)
    {
      var element = ElementTool.Create<CompanionIsDead>();
      element.anyCompanion = anyCompanion ?? element.anyCompanion;
      element.m_companion = companion?.Reference ?? element.m_companion;
      if (element.m_companion is null)
      {
        element.m_companion = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CompanionIsLost"/>
    /// </summary>
    ///
    /// <param name="companion">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder CompanionIsLost(
        this ConditionsBuilder builder,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? companion = null,
        bool negate = false)
    {
      var element = ElementTool.Create<CompanionIsLost>();
      element.m_Companion = companion?.Reference ?? element.m_Companion;
      if (element.m_Companion is null)
      {
        element.m_Companion = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CompanionIsUnconscious"/>
    /// </summary>
    ///
    /// <param name="companion">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder CompanionIsUnconscious(
        this ConditionsBuilder builder,
        bool? anyCompanion = null,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? companion = null,
        bool negate = false)
    {
      var element = ElementTool.Create<CompanionIsUnconscious>();
      element.anyCompanion = anyCompanion ?? element.anyCompanion;
      element.companion = companion?.Reference ?? element.companion;
      if (element.companion is null)
      {
        element.companion = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CheckLos"/>
    /// </summary>
    public static ConditionsBuilder CheckLos(
        this ConditionsBuilder builder,
        bool negate = false,
        PositionEvaluator? point1 = null,
        PositionEvaluator? point2 = null)
    {
      var element = ElementTool.Create<CheckLos>();
      element.Not = negate;
      builder.Validate(point1);
      element.Point1 = point1 ?? element.Point1;
      builder.Validate(point2);
      element.Point2 = point2 ?? element.Point2;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DualCompanionInactive"/>
    /// </summary>
    public static ConditionsBuilder DualCompanionInactive(
        this ConditionsBuilder builder,
        bool negate = false,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<DualCompanionInactive>();
      element.Not = negate;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HasBuff"/>
    /// </summary>
    ///
    /// <param name="buff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder HasBuff(
        this ConditionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? buff = null,
        bool negate = false,
        UnitEvaluator? target = null)
    {
      var element = ElementTool.Create<HasBuff>();
      element.m_Buff = buff?.Reference ?? element.m_Buff;
      if (element.m_Buff is null)
      {
        element.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      element.Not = negate;
      builder.Validate(target);
      element.Target = target ?? element.Target;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HasFact"/>
    /// </summary>
    ///
    /// <param name="fact">
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder HasFact(
        this ConditionsBuilder builder,
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>? fact = null,
        bool negate = false,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<HasFact>();
      element.m_Fact = fact?.Reference ?? element.m_Fact;
      if (element.m_Fact is null)
      {
        element.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      element.Not = negate;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsEnemy"/>
    /// </summary>
    public static ConditionsBuilder IsEnemy(
        this ConditionsBuilder builder,
        UnitEvaluator? firstUnit = null,
        bool negate = false,
        UnitEvaluator? secondUnit = null)
    {
      var element = ElementTool.Create<IsEnemy>();
      builder.Validate(firstUnit);
      element.FirstUnit = firstUnit ?? element.FirstUnit;
      element.Not = negate;
      builder.Validate(secondUnit);
      element.SecondUnit = secondUnit ?? element.SecondUnit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsInCombat"/>
    /// </summary>
    public static ConditionsBuilder IsInCombat(
        this ConditionsBuilder builder,
        bool negate = false,
        bool? player = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<IsInCombat>();
      element.Not = negate;
      element.Player = player ?? element.Player;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsInTurnBasedCombat"/>
    /// </summary>
    public static ConditionsBuilder IsInTurnBasedCombat(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<IsInTurnBasedCombat>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsPartyMember"/>
    /// </summary>
    public static ConditionsBuilder IsPartyMember(
        this ConditionsBuilder builder,
        bool negate = false,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<IsPartyMember>();
      element.Not = negate;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsUnconscious"/>
    /// </summary>
    public static ConditionsBuilder IsUnconscious(
        this ConditionsBuilder builder,
        bool negate = false,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<IsUnconscious>();
      element.Not = negate;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsUnitLevelLessThan"/>
    /// </summary>
    public static ConditionsBuilder IsUnitLevelLessThan(
        this ConditionsBuilder builder,
        bool? checkExperience = null,
        int? level = null,
        bool negate = false,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<IsUnitLevelLessThan>();
      element.CheckExperience = checkExperience ?? element.CheckExperience;
      element.Level = level ?? element.Level;
      element.Not = negate;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ItemBlueprint"/>
    /// </summary>
    ///
    /// <param name="blueprint">
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder ItemBlueprint(
        this ConditionsBuilder builder,
        Blueprint<BlueprintItem, BlueprintItemReference>? blueprint = null,
        ItemEvaluator? item = null,
        bool negate = false)
    {
      var element = ElementTool.Create<ItemBlueprint>();
      element.Blueprint = blueprint?.Reference ?? element.Blueprint;
      if (element.Blueprint is null)
      {
        element.Blueprint = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      builder.Validate(item);
      element.Item = item ?? element.Item;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ItemFromCollectionCondition"/>
    /// </summary>
    public static ConditionsBuilder ItemFromCollectionCondition(
        this ConditionsBuilder builder,
        bool? any = null,
        ConditionsBuilder? condition = null,
        ItemsCollectionEvaluator? items = null,
        bool negate = false)
    {
      var element = ElementTool.Create<ItemFromCollectionCondition>();
      element.Any = any ?? element.Any;
      element.Condition = condition?.Build() ?? element.Condition;
      if (element.Condition is null)
      {
        element.Condition = Utils.Constants.Empty.Conditions;
      }
      builder.Validate(items);
      element.Items = items ?? element.Items;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ItemsEnough"/>
    /// </summary>
    ///
    /// <param name="itemToCheck">
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder ItemsEnough(
        this ConditionsBuilder builder,
        Blueprint<BlueprintItem, BlueprintItemReference>? itemToCheck = null,
        bool? money = null,
        bool negate = false,
        int? quantity = null)
    {
      var element = ElementTool.Create<ItemsEnough>();
      element.m_ItemToCheck = itemToCheck?.Reference ?? element.m_ItemToCheck;
      if (element.m_ItemToCheck is null)
      {
        element.m_ItemToCheck = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      element.Money = money ?? element.Money;
      element.Not = negate;
      element.Quantity = quantity ?? element.Quantity;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PartyCanUseAbility"/>
    /// </summary>
    public static ConditionsBuilder PartyCanUseAbility(
        this ConditionsBuilder builder,
        bool? allowItems = null,
        AbilitiesHelper.AbilityDescription? description = null,
        bool negate = false)
    {
      var element = ElementTool.Create<PartyCanUseAbility>();
      element.AllowItems = allowItems ?? element.AllowItems;
      builder.Validate(description);
      element.Description = description ?? element.Description;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PartyUnits"/>
    /// </summary>
    public static ConditionsBuilder PartyUnits(
        this ConditionsBuilder builder,
        bool? any = null,
        ConditionsBuilder? conditions = null,
        bool negate = false)
    {
      var element = ElementTool.Create<PartyUnits>();
      element.Any = any ?? element.Any;
      element.Conditions = conditions?.Build() ?? element.Conditions;
      if (element.Conditions is null)
      {
        element.Conditions = Utils.Constants.Empty.Conditions;
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PcFemale"/>
    /// </summary>
    public static ConditionsBuilder PcFemale(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<PcFemale>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PcMale"/>
    /// </summary>
    public static ConditionsBuilder PcMale(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<PcMale>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PcRace"/>
    /// </summary>
    public static ConditionsBuilder PcRace(
        this ConditionsBuilder builder,
        bool negate = false,
        Race? race = null)
    {
      var element = ElementTool.Create<PcRace>();
      element.Not = negate;
      element.Race = race ?? element.Race;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SummonPoolExistsAndEmpty"/>
    /// </summary>
    ///
    /// <param name="summonPool">
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder SummonPoolExistsAndEmpty(
        this ConditionsBuilder builder,
        bool negate = false,
        Blueprint<BlueprintSummonPool, BlueprintSummonPoolReference>? summonPool = null)
    {
      var element = ElementTool.Create<SummonPoolExistsAndEmpty>();
      element.Not = negate;
      element.m_SummonPool = summonPool?.Reference ?? element.m_SummonPool;
      if (element.m_SummonPool is null)
      {
        element.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitIsDead"/>
    /// </summary>
    public static ConditionsBuilder UnitIsDead(
        this ConditionsBuilder builder,
        bool negate = false,
        UnitEvaluator? target = null)
    {
      var element = ElementTool.Create<UnitIsDead>();
      element.Not = negate;
      builder.Validate(target);
      element.Target = target ?? element.Target;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitIsHidden"/>
    /// </summary>
    public static ConditionsBuilder UnitIsHidden(
        this ConditionsBuilder builder,
        bool negate = false,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<UnitIsHidden>();
      element.Not = negate;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitBlueprint"/>
    /// </summary>
    ///
    /// <param name="blueprint">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder UnitBlueprint(
        this ConditionsBuilder builder,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? blueprint = null,
        bool negate = false,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<UnitBlueprint>();
      element.m_Blueprint = blueprint?.Reference ?? element.m_Blueprint;
      if (element.m_Blueprint is null)
      {
        element.m_Blueprint = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      element.Not = negate;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitClass"/>
    /// </summary>
    ///
    /// <param name="clazz">
    /// Blueprint of type BlueprintCharacterClass. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder UnitClass(
        this ConditionsBuilder builder,
        Blueprint<BlueprintCharacterClass, BlueprintCharacterClassReference>? clazz = null,
        bool? limitMaxLevel = null,
        bool? limitMinLevel = null,
        IntEvaluator? maxLevel = null,
        IntEvaluator? minLevel = null,
        bool negate = false,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<UnitClass>();
      element.m_Class = clazz?.Reference ?? element.m_Class;
      if (element.m_Class is null)
      {
        element.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(null);
      }
      element.LimitMaxLevel = limitMaxLevel ?? element.LimitMaxLevel;
      element.LimitMinLevel = limitMinLevel ?? element.LimitMinLevel;
      builder.Validate(maxLevel);
      element.MaxLevel = maxLevel ?? element.MaxLevel;
      builder.Validate(minLevel);
      element.MinLevel = minLevel ?? element.MinLevel;
      element.Not = negate;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitEqual"/>
    /// </summary>
    public static ConditionsBuilder UnitEqual(
        this ConditionsBuilder builder,
        UnitEvaluator? firstUnit = null,
        bool negate = false,
        UnitEvaluator? secondUnit = null)
    {
      var element = ElementTool.Create<UnitEqual>();
      builder.Validate(firstUnit);
      element.FirstUnit = firstUnit ?? element.FirstUnit;
      element.Not = negate;
      builder.Validate(secondUnit);
      element.SecondUnit = secondUnit ?? element.SecondUnit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitFromSpawnerIsDead"/>
    /// </summary>
    public static ConditionsBuilder UnitFromSpawnerIsDead(
        this ConditionsBuilder builder,
        bool negate = false,
        EntityReference? target = null)
    {
      var element = ElementTool.Create<UnitFromSpawnerIsDead>();
      element.Not = negate;
      builder.Validate(target);
      element.Target = target ?? element.Target;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitFromSummonPool"/>
    /// </summary>
    ///
    /// <param name="summonPool">
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder UnitFromSummonPool(
        this ConditionsBuilder builder,
        bool negate = false,
        Blueprint<BlueprintSummonPool, BlueprintSummonPoolReference>? summonPool = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<UnitFromSummonPool>();
      element.Not = negate;
      element.m_SummonPool = summonPool?.Reference ?? element.m_SummonPool;
      if (element.m_SummonPool is null)
      {
        element.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitGender"/>
    /// </summary>
    public static ConditionsBuilder UnitGender(
        this ConditionsBuilder builder,
        Gender? gender = null,
        bool negate = false,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<UnitGender>();
      element.Gender = gender ?? element.Gender;
      element.Not = negate;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitIsNull"/>
    /// </summary>
    public static ConditionsBuilder UnitIsNull(
        this ConditionsBuilder builder,
        bool negate = false,
        UnitEvaluator? target = null)
    {
      var element = ElementTool.Create<UnitIsNull>();
      element.Not = negate;
      builder.Validate(target);
      element.Target = target ?? element.Target;
      return builder.Add(element);
    }
  }
}
