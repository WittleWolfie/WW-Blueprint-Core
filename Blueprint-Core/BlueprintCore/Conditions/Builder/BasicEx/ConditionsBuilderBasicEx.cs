using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Designers;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Designers.EventConditionActionSystem.NamedParameters;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Buffs.Conditions;
using System;
namespace BlueprintCore.Conditions.Builder.BasicEx
{
  /// <summary>
  /// Extension to <see cref="ConditionsBuilder"/> for most game mechanics related conditions not included in
  /// <see cref="ContextEx.ConditionsBuilderContextEx">ContextEx</see>.
  /// </summary>
  /// <inheritdoc cref="ConditionsBuilder"/>
  public static class ConditionsBuilderBasicEx
  {
    //----- Auto Generated -----//



    /// <summary>
    /// Adds <see cref="BuffConditionCheckRoundNumber"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffConditionCheckRoundNumber))]
    public static ConditionsBuilder AddBuffConditionCheckRoundNumber(
        this ConditionsBuilder builder,
        Int32 RoundNumber,
        bool negate = false)
    {
      builder.Validate(RoundNumber);
      
      var element = ElementTool.Create<BuffConditionCheckRoundNumber>();
      element.RoundNumber = RoundNumber;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CheckConditionsHolder"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ConditionsHolder"><see cref="ConditionsHolder"/></param>
    [Generated]
    [Implements(typeof(CheckConditionsHolder))]
    public static ConditionsBuilder AddCheckConditionsHolder(
        this ConditionsBuilder builder,
        string ConditionsHolder,
        ParametrizedContextSetter Parameters,
        bool negate = false)
    {
      builder.Validate(Parameters);
      
      var element = ElementTool.Create<CheckConditionsHolder>();
      element.ConditionsHolder = BlueprintTool.GetRef<ConditionsReference>(ConditionsHolder);
      element.Parameters = Parameters;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CheckLos"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CheckLos))]
    public static ConditionsBuilder AddCheckLos(
        this ConditionsBuilder builder,
        PositionEvaluator Point1,
        PositionEvaluator Point2,
        bool negate = false)
    {
      builder.Validate(Point1);
      builder.Validate(Point2);
      
      var element = ElementTool.Create<CheckLos>();
      element.Point1 = Point1;
      element.Point2 = Point2;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HasBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(HasBuff))]
    public static ConditionsBuilder AddHasBuff(
        this ConditionsBuilder builder,
        UnitEvaluator Target,
        string m_Buff,
        bool negate = false)
    {
      builder.Validate(Target);
      
      var element = ElementTool.Create<HasBuff>();
      element.Target = Target;
      element.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Fact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(HasFact))]
    public static ConditionsBuilder AddHasFact(
        this ConditionsBuilder builder,
        UnitEvaluator Unit,
        string m_Fact,
        bool negate = false)
    {
      builder.Validate(Unit);
      
      var element = ElementTool.Create<HasFact>();
      element.Unit = Unit;
      element.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_Fact);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsEnemy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IsEnemy))]
    public static ConditionsBuilder AddIsEnemy(
        this ConditionsBuilder builder,
        UnitEvaluator FirstUnit,
        UnitEvaluator SecondUnit,
        bool negate = false)
    {
      builder.Validate(FirstUnit);
      builder.Validate(SecondUnit);
      
      var element = ElementTool.Create<IsEnemy>();
      element.FirstUnit = FirstUnit;
      element.SecondUnit = SecondUnit;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsInCombat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IsInCombat))]
    public static ConditionsBuilder AddIsInCombat(
        this ConditionsBuilder builder,
        UnitEvaluator Unit,
        Boolean Player,
        bool negate = false)
    {
      builder.Validate(Unit);
      builder.Validate(Player);
      
      var element = ElementTool.Create<IsInCombat>();
      element.Unit = Unit;
      element.Player = Player;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsInTurnBasedCombat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IsInTurnBasedCombat))]
    public static ConditionsBuilder AddIsInTurnBasedCombat(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      
      var element = ElementTool.Create<IsInTurnBasedCombat>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsPartyMember"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IsPartyMember))]
    public static ConditionsBuilder AddIsPartyMember(
        this ConditionsBuilder builder,
        UnitEvaluator Unit,
        bool negate = false)
    {
      builder.Validate(Unit);
      
      var element = ElementTool.Create<IsPartyMember>();
      element.Unit = Unit;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsUnconscious"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IsUnconscious))]
    public static ConditionsBuilder AddIsUnconscious(
        this ConditionsBuilder builder,
        UnitEvaluator Unit,
        bool negate = false)
    {
      builder.Validate(Unit);
      
      var element = ElementTool.Create<IsUnconscious>();
      element.Unit = Unit;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PartyCanUseAbility"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PartyCanUseAbility))]
    public static ConditionsBuilder AddPartyCanUseAbility(
        this ConditionsBuilder builder,
        AbilitiesHelper.AbilityDescription Description,
        Boolean AllowItems,
        bool negate = false)
    {
      builder.Validate(Description);
      builder.Validate(AllowItems);
      
      var element = ElementTool.Create<PartyCanUseAbility>();
      element.Description = Description;
      element.AllowItems = AllowItems;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SummonPoolExistsAndEmpty"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_SummonPool"><see cref="BlueprintSummonPool"/></param>
    [Generated]
    [Implements(typeof(SummonPoolExistsAndEmpty))]
    public static ConditionsBuilder AddSummonPoolExistsAndEmpty(
        this ConditionsBuilder builder,
        string m_SummonPool,
        bool negate = false)
    {
      
      var element = ElementTool.Create<SummonPoolExistsAndEmpty>();
      element.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(m_SummonPool);
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitIsDead"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitIsDead))]
    public static ConditionsBuilder AddUnitIsDead(
        this ConditionsBuilder builder,
        UnitEvaluator Target,
        bool negate = false)
    {
      builder.Validate(Target);
      
      var element = ElementTool.Create<UnitIsDead>();
      element.Target = Target;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitIsHidden"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitIsHidden))]
    public static ConditionsBuilder AddUnitIsHidden(
        this ConditionsBuilder builder,
        UnitEvaluator Unit,
        bool negate = false)
    {
      builder.Validate(Unit);
      
      var element = ElementTool.Create<UnitIsHidden>();
      element.Unit = Unit;
      element.Not = negate;
      return builder.Add(element);
    }
  }
}
