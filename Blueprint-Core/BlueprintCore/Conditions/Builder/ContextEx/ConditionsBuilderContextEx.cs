using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Kingmaker.Utility;
using System;

namespace BlueprintCore.Conditions.Builder.ContextEx
{
  /// <summary>
  /// Extension to <see cref="ConditionsBuilder"/> for most <see cref="ContextCondition"/> types. Some
  /// <see cref="ContextCondition"/> types are in more specific extensions such as
  /// <see cref="KingdomEx.ConditionsBuilderKingdomEx">KingdomEx</see>.
  /// </summary>
  /// <inheritdoc cref="ConditionsBuilder"/>
  public static class ConditionsBuilderContextEx
  {
    /// <summary>
    /// Adds <see cref="ContextConditionHasBuffFromCaster"/>
    /// </summary>
    /// 
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff">BlueprintBuff</see></param>
    [Implements(typeof(ContextConditionHasBuffFromCaster))]
    public static ConditionsBuilder HasBuffFromCaster(this ConditionsBuilder builder, string buff)
    {
      var hasBuff = ElementTool.Create<ContextConditionHasBuffFromCaster>();
      hasBuff.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      return builder.Add(hasBuff);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionCasterHasFact"/>
    /// </summary>
    /// 
    /// <param name="fact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact">BlueprintUnitFact</see></param>
    [Implements(typeof(ContextConditionCasterHasFact))]
    public static ConditionsBuilder CasterHasFact(this ConditionsBuilder builder, string fact)
    {
      var hasFact = ElementTool.Create<ContextConditionCasterHasFact>();
      hasFact.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(fact);
      return builder.Add(hasFact);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionHasFact"/>
    /// </summary>
    /// 
    /// <param name="fact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact">BlueprintUnitFact</see></param>
    [Implements(typeof(ContextConditionHasFact))]
    public static ConditionsBuilder HasFact(this ConditionsBuilder builder, string fact)
    {
      var hasFact = ElementTool.Create<ContextConditionHasFact>();
      hasFact.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(fact);
      return builder.Add(hasFact);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionTargetIsYourself"/>
    /// </summary>
    [Implements(typeof(ContextConditionTargetIsYourself))]
    public static ConditionsBuilder TargetIsYourself(this ConditionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextConditionTargetIsYourself>());
    }

    //----- Auto Generated -----//



    /// <summary>
    /// Adds <see cref="ContextConditionDistanceToTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionDistanceToTarget))]
    public static ConditionsBuilder AddContextConditionDistanceToTarget(
        this ConditionsBuilder builder,
        Feet DistanceGreater,
        Boolean Not)
    {
      builder.Validate(DistanceGreater);
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionDistanceToTarget>();
      element.DistanceGreater = DistanceGreater;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionAlignment))]
    public static ConditionsBuilder AddContextConditionAlignment(
        this ConditionsBuilder builder,
        Boolean CheckCaster,
        AlignmentComponent Alignment,
        Boolean Not)
    {
      builder.Validate(CheckCaster);
      builder.Validate(Alignment);
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionAlignment>();
      element.CheckCaster = CheckCaster;
      element.Alignment = Alignment;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionAlignmentDifference"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionAlignmentDifference))]
    public static ConditionsBuilder AddContextConditionAlignmentDifference(
        this ConditionsBuilder builder,
        Int32 AlignmentStepDifference,
        Boolean Not)
    {
      builder.Validate(AlignmentStepDifference);
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionAlignmentDifference>();
      element.AlignmentStepDifference = AlignmentStepDifference;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionAlive"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionAlive))]
    public static ConditionsBuilder AddContextConditionAlive(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionAlive>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionBuffRank"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(ContextConditionBuffRank))]
    public static ConditionsBuilder AddContextConditionBuffRank(
        this ConditionsBuilder builder,
        string Buff,
        ContextValue RankValue,
        Boolean Not)
    {
      builder.Validate(RankValue);
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionBuffRank>();
      element.Buff = BlueprintTool.GetRef<BlueprintBuffReference>(Buff);
      element.RankValue = RankValue;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionCasterHasBuffWithDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionCasterHasBuffWithDescriptor))]
    public static ConditionsBuilder AddContextConditionCasterHasBuffWithDescriptor(
        this ConditionsBuilder builder,
        SpellDescriptorWrapper SpellDescriptor,
        Boolean Not)
    {
      builder.Validate(SpellDescriptor);
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionCasterHasBuffWithDescriptor>();
      element.SpellDescriptor = SpellDescriptor;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionCasterIsPartyEnemy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionCasterIsPartyEnemy))]
    public static ConditionsBuilder AddContextConditionCasterIsPartyEnemy(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionCasterIsPartyEnemy>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionCasterWeaponInTwoHands"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionCasterWeaponInTwoHands))]
    public static ConditionsBuilder AddContextConditionCasterWeaponInTwoHands(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionCasterWeaponInTwoHands>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionCharacterClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Class"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(ContextConditionCharacterClass))]
    public static ConditionsBuilder AddContextConditionCharacterClass(
        this ConditionsBuilder builder,
        Boolean CheckCaster,
        string m_Class,
        Int32 MinLevel,
        Boolean Not)
    {
      builder.Validate(CheckCaster);
      builder.Validate(MinLevel);
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionCharacterClass>();
      element.CheckCaster = CheckCaster;
      element.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_Class);
      element.MinLevel = MinLevel;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionCompare"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionCompare))]
    public static ConditionsBuilder AddContextConditionCompare(
        this ConditionsBuilder builder,
        ContextConditionCompare.Type m_Type,
        ContextValue CheckValue,
        ContextValue TargetValue,
        Boolean Not)
    {
      builder.Validate(m_Type);
      builder.Validate(CheckValue);
      builder.Validate(TargetValue);
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionCompare>();
      element.m_Type = m_Type;
      element.CheckValue = CheckValue;
      element.TargetValue = TargetValue;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionCompareCasterHP"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionCompareCasterHP))]
    public static ConditionsBuilder AddContextConditionCompareCasterHP(
        this ConditionsBuilder builder,
        ContextConditionCompareCasterHP.CompareType m_CompareType,
        ContextValue Value,
        Boolean Not)
    {
      builder.Validate(m_CompareType);
      builder.Validate(Value);
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionCompareCasterHP>();
      element.m_CompareType = m_CompareType;
      element.Value = Value;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionCompareTargetHP"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionCompareTargetHP))]
    public static ConditionsBuilder AddContextConditionCompareTargetHP(
        this ConditionsBuilder builder,
        ContextConditionCompareTargetHP.CompareType m_CompareType,
        ContextValue Value,
        Boolean Not)
    {
      builder.Validate(m_CompareType);
      builder.Validate(Value);
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionCompareTargetHP>();
      element.m_CompareType = m_CompareType;
      element.Value = Value;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionFavoredEnemy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionFavoredEnemy))]
    public static ConditionsBuilder AddContextConditionFavoredEnemy(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionFavoredEnemy>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionHasBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(ContextConditionHasBuff))]
    public static ConditionsBuilder AddContextConditionHasBuff(
        this ConditionsBuilder builder,
        string m_Buff,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionHasBuff>();
      element.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionHasBuffWithDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionHasBuffWithDescriptor))]
    public static ConditionsBuilder AddContextConditionHasBuffWithDescriptor(
        this ConditionsBuilder builder,
        SpellDescriptorWrapper SpellDescriptor,
        Boolean Not)
    {
      builder.Validate(SpellDescriptor);
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionHasBuffWithDescriptor>();
      element.SpellDescriptor = SpellDescriptor;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionHasItem"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_ItemToCheck"><see cref="BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(ContextConditionHasItem))]
    public static ConditionsBuilder AddContextConditionHasItem(
        this ConditionsBuilder builder,
        Boolean Money,
        string m_ItemToCheck,
        Int32 Quantity,
        Boolean Not)
    {
      builder.Validate(Money);
      builder.Validate(Quantity);
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionHasItem>();
      element.Money = Money;
      element.m_ItemToCheck = BlueprintTool.GetRef<BlueprintItemReference>(m_ItemToCheck);
      element.Quantity = Quantity;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionHasTouchSpellCharge"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionHasTouchSpellCharge))]
    public static ConditionsBuilder AddContextConditionHasTouchSpellCharge(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionHasTouchSpellCharge>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionHasUniqueBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(ContextConditionHasUniqueBuff))]
    public static ConditionsBuilder AddContextConditionHasUniqueBuff(
        this ConditionsBuilder builder,
        string m_Buff,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionHasUniqueBuff>();
      element.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionHitDice"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionHitDice))]
    public static ConditionsBuilder AddContextConditionHitDice(
        this ConditionsBuilder builder,
        Int32 HitDice,
        Boolean AddSharedValue,
        AbilitySharedValue SharedValue,
        Boolean Not)
    {
      builder.Validate(HitDice);
      builder.Validate(AddSharedValue);
      builder.Validate(SharedValue);
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionHitDice>();
      element.HitDice = HitDice;
      element.AddSharedValue = AddSharedValue;
      element.SharedValue = SharedValue;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsAlly"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsAlly))]
    public static ConditionsBuilder AddContextConditionIsAlly(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionIsAlly>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsAmuletEquipped"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsAmuletEquipped))]
    public static ConditionsBuilder AddContextConditionIsAmuletEquipped(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionIsAmuletEquipped>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsAnimalCompanion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsAnimalCompanion))]
    public static ConditionsBuilder AddContextConditionIsAnimalCompanion(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionIsAnimalCompanion>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsCaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsCaster))]
    public static ConditionsBuilder AddContextConditionIsCaster(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionIsCaster>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsEnemy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsEnemy))]
    public static ConditionsBuilder AddContextConditionIsEnemy(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionIsEnemy>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsFlanked"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsFlanked))]
    public static ConditionsBuilder AddContextConditionIsFlanked(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionIsFlanked>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsFlatFooted"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsFlatFooted))]
    public static ConditionsBuilder AddContextConditionIsFlatFooted(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionIsFlatFooted>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsHelpless"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsHelpless))]
    public static ConditionsBuilder AddContextConditionIsHelpless(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionIsHelpless>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsInCombat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsInCombat))]
    public static ConditionsBuilder AddContextConditionIsInCombat(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionIsInCombat>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsMainTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsMainTarget))]
    public static ConditionsBuilder AddContextConditionIsMainTarget(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionIsMainTarget>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsPartyMember"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsPartyMember))]
    public static ConditionsBuilder AddContextConditionIsPartyMember(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionIsPartyMember>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsPetDead"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsPetDead))]
    public static ConditionsBuilder AddContextConditionIsPetDead(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionIsPetDead>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsRing1Equipped"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsRing1Equipped))]
    public static ConditionsBuilder AddContextConditionIsRing1Equipped(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionIsRing1Equipped>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsRing2Equipped"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsRing2Equipped))]
    public static ConditionsBuilder AddContextConditionIsRing2Equipped(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionIsRing2Equipped>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsShieldEquipped"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsShieldEquipped))]
    public static ConditionsBuilder AddContextConditionIsShieldEquipped(
        this ConditionsBuilder builder,
        Boolean CheckCaster,
        Boolean Not)
    {
      builder.Validate(CheckCaster);
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionIsShieldEquipped>();
      element.CheckCaster = CheckCaster;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsTwoHandedEquipped"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsTwoHandedEquipped))]
    public static ConditionsBuilder AddContextConditionIsTwoHandedEquipped(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionIsTwoHandedEquipped>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsUnconscious"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsUnconscious))]
    public static ConditionsBuilder AddContextConditionIsUnconscious(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionIsUnconscious>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsWeaponEquipped"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionIsWeaponEquipped))]
    public static ConditionsBuilder AddContextConditionIsWeaponEquipped(
        this ConditionsBuilder builder,
        Boolean CheckWeaponRangeType,
        Boolean CheckWeaponCategory,
        WeaponRangeType RangeType,
        WeaponCategory Category,
        Boolean CheckOnCaster,
        Boolean Not)
    {
      builder.Validate(CheckWeaponRangeType);
      builder.Validate(CheckWeaponCategory);
      builder.Validate(RangeType);
      builder.Validate(Category);
      builder.Validate(CheckOnCaster);
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionIsWeaponEquipped>();
      element.CheckWeaponRangeType = CheckWeaponRangeType;
      element.CheckWeaponCategory = CheckWeaponCategory;
      element.RangeType = RangeType;
      element.Category = Category;
      element.CheckOnCaster = CheckOnCaster;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionMaximumBurn"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionMaximumBurn))]
    public static ConditionsBuilder AddContextConditionMaximumBurn(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionMaximumBurn>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionPeaceful"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionPeaceful))]
    public static ConditionsBuilder AddContextConditionPeaceful(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionPeaceful>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionSharedValueHigher"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionSharedValueHigher))]
    public static ConditionsBuilder AddContextConditionSharedValueHigher(
        this ConditionsBuilder builder,
        AbilitySharedValue SharedValue,
        Int32 HigherOrEqual,
        Boolean Inverted,
        Boolean Not)
    {
      builder.Validate(SharedValue);
      builder.Validate(HigherOrEqual);
      builder.Validate(Inverted);
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionSharedValueHigher>();
      element.SharedValue = SharedValue;
      element.HigherOrEqual = HigherOrEqual;
      element.Inverted = Inverted;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionSharedValueHitDice"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionSharedValueHitDice))]
    public static ConditionsBuilder AddContextConditionSharedValueHitDice(
        this ConditionsBuilder builder,
        AbilitySharedValue SharedValue,
        Boolean Inverted,
        Boolean Not)
    {
      builder.Validate(SharedValue);
      builder.Validate(Inverted);
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionSharedValueHitDice>();
      element.SharedValue = SharedValue;
      element.Inverted = Inverted;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionSize"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionSize))]
    public static ConditionsBuilder AddContextConditionSize(
        this ConditionsBuilder builder,
        Size Size,
        Boolean Invert,
        Boolean CheckCaster,
        Boolean Not)
    {
      builder.Validate(Size);
      builder.Validate(Invert);
      builder.Validate(CheckCaster);
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionSize>();
      element.Size = Size;
      element.Invert = Invert;
      element.CheckCaster = CheckCaster;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionStatValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionStatValue))]
    public static ConditionsBuilder AddContextConditionStatValue(
        this ConditionsBuilder builder,
        Int32 N,
        StatType Stat,
        Boolean Not)
    {
      builder.Validate(N);
      builder.Validate(Stat);
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionStatValue>();
      element.N = N;
      element.Stat = Stat;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionStealth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionStealth))]
    public static ConditionsBuilder AddContextConditionStealth(
        this ConditionsBuilder builder,
        ContextConditionStealth.CheckTarget m_CheckTarget,
        Boolean Not)
    {
      builder.Validate(m_CheckTarget);
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionStealth>();
      element.m_CheckTarget = m_CheckTarget;
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionTargetCanSeeInvisible"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionTargetCanSeeInvisible))]
    public static ConditionsBuilder AddContextConditionTargetCanSeeInvisible(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionTargetCanSeeInvisible>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionTargetIsArcaneCaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionTargetIsArcaneCaster))]
    public static ConditionsBuilder AddContextConditionTargetIsArcaneCaster(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionTargetIsArcaneCaster>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionTargetIsBlueprint"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Unit"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(ContextConditionTargetIsBlueprint))]
    public static ConditionsBuilder AddContextConditionTargetIsBlueprint(
        this ConditionsBuilder builder,
        string m_Unit,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionTargetIsBlueprint>();
      element.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(m_Unit);
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionTargetIsDivineCaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionTargetIsDivineCaster))]
    public static ConditionsBuilder AddContextConditionTargetIsDivineCaster(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionTargetIsDivineCaster>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionTargetIsEngaged"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionTargetIsEngaged))]
    public static ConditionsBuilder AddContextConditionTargetIsEngaged(
        this ConditionsBuilder builder,
        Boolean Not)
    {
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionTargetIsEngaged>();
      element.Not = Not;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionUnconsciousAllyFarThan"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextConditionUnconsciousAllyFarThan))]
    public static ConditionsBuilder AddContextConditionUnconsciousAllyFarThan(
        this ConditionsBuilder builder,
        Feet Distance,
        Boolean Not)
    {
      builder.Validate(Distance);
      builder.Validate(Not);
      
      var element = ElementTool.Create<ContextConditionUnconsciousAllyFarThan>();
      element.Distance = Distance;
      element.Not = Not;
      return builder.Add(element);
    }
  }
}
