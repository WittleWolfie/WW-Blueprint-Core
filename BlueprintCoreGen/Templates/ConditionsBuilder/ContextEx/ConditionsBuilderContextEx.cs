using BlueprintCore.Blueprints;
using BlueprintCore.Conditions.New;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Conditions;

namespace BlueprintCoreGen.Conditions.Builder.ContextEx
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
    public static ConditionsBuilder HasBuffFromCaster(this ConditionsBuilder builder, string buff, bool negate = false)
    {
      var hasBuff = ElementTool.Create<ContextConditionHasBuffFromCaster>();
      hasBuff.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      hasBuff.Not = negate;
      return builder.Add(hasBuff);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionCasterHasFact"/>
    /// </summary>
    /// 
    /// <param name="fact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact">BlueprintUnitFact</see></param>
    [Implements(typeof(ContextConditionCasterHasFact))]
    public static ConditionsBuilder CasterHasFact(this ConditionsBuilder builder, string fact, bool negate = false)
    {
      var hasFact = ElementTool.Create<ContextConditionCasterHasFact>();
      hasFact.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(fact);
      hasFact.Not = negate;
      return builder.Add(hasFact);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionHasFact"/>
    /// </summary>
    /// 
    /// <param name="fact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact">BlueprintUnitFact</see></param>
    [Implements(typeof(ContextConditionHasFact))]
    public static ConditionsBuilder HasFact(this ConditionsBuilder builder, string fact, bool negate = false)
    {
      var hasFact = ElementTool.Create<ContextConditionHasFact>();
      hasFact.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(fact);
      hasFact.Not = negate;
      return builder.Add(hasFact);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionTargetIsYourself"/>
    /// </summary>
    [Implements(typeof(ContextConditionTargetIsYourself))]
    public static ConditionsBuilder TargetIsYourself(this ConditionsBuilder builder, bool negate = false)
    {
      var condition = ElementTool.Create<ContextConditionTargetIsYourself>();
      condition.Not = negate;
      return builder.Add(condition);
    }

    //----- Auto Generated -----//

    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionDistanceToTarget)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionAlignment)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionAlignmentDifference)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionAlive)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionBuffRank)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionCasterHasBuffWithDescriptor)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionCasterIsPartyEnemy)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionCasterWeaponInTwoHands)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionCharacterClass)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionCompare)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionCompareCasterHP)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionCompareTargetHP)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionFavoredEnemy)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionGender)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionHasBuff)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionHasBuffWithDescriptor)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionHasItem)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionHasTouchSpellCharge)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionHasUniqueBuff)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionHitDice)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionIsAlly)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionIsAmuletEquipped)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionIsAnimalCompanion)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionIsCaster)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionIsEnemy)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionIsFlanked)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionIsFlatFooted)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionIsHelpless)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionIsInCombat)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionIsMainTarget)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionIsPartyMember)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionIsPetDead)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionIsRing1Equipped)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionIsRing2Equipped)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionIsShieldEquipped)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionIsTwoHandedEquipped)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionIsUnconscious)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionIsWeaponEquipped)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionMaximumBurn)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionPeaceful)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionSharedValueHigher)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionSharedValueHitDice)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionSize)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionStatValue)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionStealth)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionTargetCanSeeInvisible)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionTargetIsArcaneCaster)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionTargetIsBlueprint)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionTargetIsDivineCaster)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionTargetIsEngaged)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionUnconsciousAllyFarThan)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionWeaponAnimationStyle)]
    // [Generate(Kingmaker.UnitLogic.Mechanics.Conditions.ContextSwarmHasEnemiesInInnerCircle)]

  }
}