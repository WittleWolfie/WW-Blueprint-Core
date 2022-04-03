//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Kingmaker.Utility;
using Kingmaker.View.Animation;

namespace BlueprintCore.Conditions.Builder.ContextEx
{
  /// <summary>
  /// Extension to <see cref="ConditionsBuilder"/> for most <see cref="ContextCondition"/> types. Some <see cref="ContextCondition"/> types are in more specific extensions such as <see cref="KingdomEx.ConditionsBuilderKingdomEx">KingdomEx</see>.
  /// </summary>
  /// <inheritdoc cref="ConditionsBuilder"/>
  public static class ConditionsBuilderContextEx
  {

    /// <summary>
    /// Adds <see cref="ContextConditionHasBuffFromCaster"/>
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
    public static ConditionsBuilder ContextConditionHasBuffFromCaster(
        this ConditionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference> buff,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionHasBuffFromCaster>();
      element.m_Buff = buff?.Reference;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionCasterHasFact"/>
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
    public static ConditionsBuilder ContextConditionCasterHasFact(
        this ConditionsBuilder builder,
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference> fact,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionCasterHasFact>();
      element.m_Fact = fact?.Reference;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionHasFact"/>
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
    public static ConditionsBuilder ContextConditionHasFact(
        this ConditionsBuilder builder,
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference> fact,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionHasFact>();
      element.m_Fact = fact?.Reference;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionDistanceToTarget"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionDistanceToTarget(
        this ConditionsBuilder builder,
        Feet? distanceGreater = null,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionDistanceToTarget>();
      element.DistanceGreater = distanceGreater ?? element.DistanceGreater;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionAlignment"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionAlignment(
        this ConditionsBuilder builder,
        AlignmentComponent? alignment = null,
        bool? checkCaster = null,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionAlignment>();
      element.Alignment = alignment ?? element.Alignment;
      element.CheckCaster = checkCaster ?? element.CheckCaster;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionAlignmentDifference"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionAlignmentDifference(
        this ConditionsBuilder builder,
        int? alignmentStepDifference = null,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionAlignmentDifference>();
      element.AlignmentStepDifference = alignmentStepDifference ?? element.AlignmentStepDifference;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionAlive"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionAlive(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionAlive>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionBuffRank"/>
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
    public static ConditionsBuilder ContextConditionBuffRank(
        this ConditionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? buff = null,
        bool negate = false,
        ContextValue? rankValue = null)
    {
      var element = ElementTool.Create<ContextConditionBuffRank>();
      element.Buff = buff?.Reference ?? element.Buff;
      if (element.Buff is null)
      {
        element.Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      element.Not = negate;
      element.RankValue = rankValue ?? element.RankValue;
      if (element.RankValue is null)
      {
        element.RankValue = ContextValues.Constant(0);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionCasterHasBuffWithDescriptor"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionCasterHasBuffWithDescriptor(
        this ConditionsBuilder builder,
        bool negate = false,
        SpellDescriptorWrapper? spellDescriptor = null)
    {
      var element = ElementTool.Create<ContextConditionCasterHasBuffWithDescriptor>();
      element.Not = negate;
      element.SpellDescriptor = spellDescriptor ?? element.SpellDescriptor;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionCasterIsPartyEnemy"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionCasterIsPartyEnemy(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionCasterIsPartyEnemy>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionCasterWeaponInTwoHands"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionCasterWeaponInTwoHands(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionCasterWeaponInTwoHands>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionCharacterClass"/>
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
    public static ConditionsBuilder ContextConditionCharacterClass(
        this ConditionsBuilder builder,
        bool? checkCaster = null,
        Blueprint<BlueprintCharacterClass, BlueprintCharacterClassReference>? clazz = null,
        int? minLevel = null,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionCharacterClass>();
      element.CheckCaster = checkCaster ?? element.CheckCaster;
      element.m_Class = clazz?.Reference ?? element.m_Class;
      if (element.m_Class is null)
      {
        element.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(null);
      }
      element.MinLevel = minLevel ?? element.MinLevel;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionCompare"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionCompare(
        this ConditionsBuilder builder,
        ContextValue? checkValue = null,
        bool negate = false,
        ContextValue? targetValue = null,
        ContextConditionCompare.Type? type = null)
    {
      var element = ElementTool.Create<ContextConditionCompare>();
      element.CheckValue = checkValue ?? element.CheckValue;
      if (element.CheckValue is null)
      {
        element.CheckValue = ContextValues.Constant(0);
      }
      element.Not = negate;
      element.TargetValue = targetValue ?? element.TargetValue;
      if (element.TargetValue is null)
      {
        element.TargetValue = ContextValues.Constant(0);
      }
      element.m_Type = type ?? element.m_Type;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionCompareCasterHP"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionCompareCasterHP(
        this ConditionsBuilder builder,
        ContextConditionCompareCasterHP.CompareType? compareType = null,
        bool negate = false,
        ContextValue? value = null)
    {
      var element = ElementTool.Create<ContextConditionCompareCasterHP>();
      element.m_CompareType = compareType ?? element.m_CompareType;
      element.Not = negate;
      element.Value = value ?? element.Value;
      if (element.Value is null)
      {
        element.Value = ContextValues.Constant(0);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionCompareTargetHP"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionCompareTargetHP(
        this ConditionsBuilder builder,
        ContextConditionCompareTargetHP.CompareType? compareType = null,
        bool negate = false,
        ContextValue? value = null)
    {
      var element = ElementTool.Create<ContextConditionCompareTargetHP>();
      element.m_CompareType = compareType ?? element.m_CompareType;
      element.Not = negate;
      element.Value = value ?? element.Value;
      if (element.Value is null)
      {
        element.Value = ContextValues.Constant(0);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionFavoredEnemy"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionFavoredEnemy(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionFavoredEnemy>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionGender"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionGender(
        this ConditionsBuilder builder,
        Gender? gender = null,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionGender>();
      element.Gender = gender ?? element.Gender;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionHasBuff"/>
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
    public static ConditionsBuilder ContextConditionHasBuff(
        this ConditionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? buff = null,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionHasBuff>();
      element.m_Buff = buff?.Reference ?? element.m_Buff;
      if (element.m_Buff is null)
      {
        element.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionHasBuffFromThisAreaEffect"/>
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
    public static ConditionsBuilder ContextConditionHasBuffFromThisAreaEffect(
        this ConditionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? buff = null,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionHasBuffFromThisAreaEffect>();
      element.m_Buff = buff?.Reference ?? element.m_Buff;
      if (element.m_Buff is null)
      {
        element.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionHasBuffImmunityWithDescriptor"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionHasBuffImmunityWithDescriptor(
        this ConditionsBuilder builder,
        bool? checkBuffDescriptorComponent = null,
        bool? checkSpellDescriptorComponent = null,
        bool negate = false,
        SpellDescriptorWrapper? spellDescriptor = null)
    {
      var element = ElementTool.Create<ContextConditionHasBuffImmunityWithDescriptor>();
      element.CheckBuffDescriptorComponent = checkBuffDescriptorComponent ?? element.CheckBuffDescriptorComponent;
      element.CheckSpellDescriptorComponent = checkSpellDescriptorComponent ?? element.CheckSpellDescriptorComponent;
      element.Not = negate;
      element.SpellDescriptor = spellDescriptor ?? element.SpellDescriptor;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionHasBuffWithDescriptor"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionHasBuffWithDescriptor(
        this ConditionsBuilder builder,
        bool negate = false,
        SpellDescriptorWrapper? spellDescriptor = null)
    {
      var element = ElementTool.Create<ContextConditionHasBuffWithDescriptor>();
      element.Not = negate;
      element.SpellDescriptor = spellDescriptor ?? element.SpellDescriptor;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionHasItem"/>
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
    public static ConditionsBuilder ContextConditionHasItem(
        this ConditionsBuilder builder,
        Blueprint<BlueprintItem, BlueprintItemReference>? itemToCheck = null,
        bool? money = null,
        bool negate = false,
        int? quantity = null)
    {
      var element = ElementTool.Create<ContextConditionHasItem>();
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
    /// Adds <see cref="ContextConditionHasTouchSpellCharge"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionHasTouchSpellCharge(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionHasTouchSpellCharge>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionHasUniqueBuff"/>
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
    public static ConditionsBuilder ContextConditionHasUniqueBuff(
        this ConditionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? buff = null,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionHasUniqueBuff>();
      element.m_Buff = buff?.Reference ?? element.m_Buff;
      if (element.m_Buff is null)
      {
        element.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionHitDice"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionHitDice(
        this ConditionsBuilder builder,
        bool? addSharedValue = null,
        int? hitDice = null,
        bool negate = false,
        AbilitySharedValue? sharedValue = null)
    {
      var element = ElementTool.Create<ContextConditionHitDice>();
      element.AddSharedValue = addSharedValue ?? element.AddSharedValue;
      element.HitDice = hitDice ?? element.HitDice;
      element.Not = negate;
      element.SharedValue = sharedValue ?? element.SharedValue;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsAlly"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionIsAlly(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsAlly>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsAmuletEquipped"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionIsAmuletEquipped(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsAmuletEquipped>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsAnimalCompanion"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionIsAnimalCompanion(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsAnimalCompanion>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsCaster"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionIsCaster(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsCaster>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsEnemy"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionIsEnemy(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsEnemy>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsFlanked"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionIsFlanked(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsFlanked>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsFlatFooted"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionIsFlatFooted(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsFlatFooted>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsHelpless"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionIsHelpless(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsHelpless>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsInCombat"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionIsInCombat(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsInCombat>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsMainTarget"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionIsMainTarget(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsMainTarget>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsPartyMember"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionIsPartyMember(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsPartyMember>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsPetDead"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionIsPetDead(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsPetDead>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsRing1Equipped"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionIsRing1Equipped(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsRing1Equipped>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsRing2Equipped"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionIsRing2Equipped(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsRing2Equipped>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsShieldEquipped"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionIsShieldEquipped(
        this ConditionsBuilder builder,
        bool? checkCaster = null,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsShieldEquipped>();
      element.CheckCaster = checkCaster ?? element.CheckCaster;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsTwoHandedEquipped"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionIsTwoHandedEquipped(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsTwoHandedEquipped>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsUnconscious"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionIsUnconscious(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsUnconscious>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsWeaponEquipped"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionIsWeaponEquipped(
        this ConditionsBuilder builder,
        WeaponCategory? category = null,
        bool? checkOnCaster = null,
        bool? checkWeaponCategory = null,
        bool? checkWeaponRangeType = null,
        bool negate = false,
        WeaponRangeType? rangeType = null)
    {
      var element = ElementTool.Create<ContextConditionIsWeaponEquipped>();
      element.Category = category ?? element.Category;
      element.CheckOnCaster = checkOnCaster ?? element.CheckOnCaster;
      element.CheckWeaponCategory = checkWeaponCategory ?? element.CheckWeaponCategory;
      element.CheckWeaponRangeType = checkWeaponRangeType ?? element.CheckWeaponRangeType;
      element.Not = negate;
      element.RangeType = rangeType ?? element.RangeType;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionMaximumBurn"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionMaximumBurn(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionMaximumBurn>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionPeaceful"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionPeaceful(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionPeaceful>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionSharedValueHigher"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionSharedValueHigher(
        this ConditionsBuilder builder,
        int? higherOrEqual = null,
        bool? inverted = null,
        bool negate = false,
        AbilitySharedValue? sharedValue = null)
    {
      var element = ElementTool.Create<ContextConditionSharedValueHigher>();
      element.HigherOrEqual = higherOrEqual ?? element.HigherOrEqual;
      element.Inverted = inverted ?? element.Inverted;
      element.Not = negate;
      element.SharedValue = sharedValue ?? element.SharedValue;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionSharedValueHitDice"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionSharedValueHitDice(
        this ConditionsBuilder builder,
        bool? inverted = null,
        bool negate = false,
        AbilitySharedValue? sharedValue = null)
    {
      var element = ElementTool.Create<ContextConditionSharedValueHitDice>();
      element.Inverted = inverted ?? element.Inverted;
      element.Not = negate;
      element.SharedValue = sharedValue ?? element.SharedValue;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionSize"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionSize(
        this ConditionsBuilder builder,
        bool? checkCaster = null,
        bool? invert = null,
        bool negate = false,
        Size? size = null)
    {
      var element = ElementTool.Create<ContextConditionSize>();
      element.CheckCaster = checkCaster ?? element.CheckCaster;
      element.Invert = invert ?? element.Invert;
      element.Not = negate;
      element.Size = size ?? element.Size;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionStatValue"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionStatValue(
        this ConditionsBuilder builder,
        int? n = null,
        bool negate = false,
        StatType? stat = null)
    {
      var element = ElementTool.Create<ContextConditionStatValue>();
      element.N = n ?? element.N;
      element.Not = negate;
      element.Stat = stat ?? element.Stat;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionStealth"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionStealth(
        this ConditionsBuilder builder,
        ContextConditionStealth.CheckTarget? checkTarget = null,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionStealth>();
      element.m_CheckTarget = checkTarget ?? element.m_CheckTarget;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionTargetCanSeeInvisible"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionTargetCanSeeInvisible(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionTargetCanSeeInvisible>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionTargetIsArcaneCaster"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionTargetIsArcaneCaster(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionTargetIsArcaneCaster>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionTargetIsBlueprint"/>
    /// </summary>
    ///
    /// <param name="unit">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder ContextConditionTargetIsBlueprint(
        this ConditionsBuilder builder,
        bool negate = false,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? unit = null)
    {
      var element = ElementTool.Create<ContextConditionTargetIsBlueprint>();
      element.Not = negate;
      element.m_Unit = unit?.Reference ?? element.m_Unit;
      if (element.m_Unit is null)
      {
        element.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionTargetIsDivineCaster"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionTargetIsDivineCaster(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionTargetIsDivineCaster>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionTargetIsEngaged"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionTargetIsEngaged(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionTargetIsEngaged>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionTargetIsYourself"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionTargetIsYourself(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionTargetIsYourself>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionUnconsciousAllyFarThan"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionUnconsciousAllyFarThan(
        this ConditionsBuilder builder,
        Feet? distance = null,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionUnconsciousAllyFarThan>();
      element.Distance = distance ?? element.Distance;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionWeaponAnimationStyle"/>
    /// </summary>
    public static ConditionsBuilder ContextConditionWeaponAnimationStyle(
        this ConditionsBuilder builder,
        WeaponAnimationStyle? animationStyle = null,
        bool? checkOnCaster = null,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionWeaponAnimationStyle>();
      element.AnimationStyle = animationStyle ?? element.AnimationStyle;
      element.CheckOnCaster = checkOnCaster ?? element.CheckOnCaster;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextSwarmHasEnemiesInInnerCircle"/>
    /// </summary>
    public static ConditionsBuilder ContextSwarmHasEnemiesInInnerCircle(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextSwarmHasEnemiesInInnerCircle>();
      element.Not = negate;
      return builder.Add(element);
    }
  }
}
