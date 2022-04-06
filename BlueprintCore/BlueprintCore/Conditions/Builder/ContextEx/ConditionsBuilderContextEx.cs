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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AnomalyDistortionBuff</term><description>599b46d94d454526bf5893a4724d4fbe</description></item>
    /// <item><term>Gibrileth_StenchAreaEffect</term><description>d7a38ef5bd1fffa4aa85a69ff6fe23d4</description></item>
    /// <item><term>WoundWormsLair_BlackDragonFrightfulPresenceArea</term><description>382910feb429e1449b3f8f2a633e3244</description></item>
    /// </list>
    /// </remarks>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcidBomb</term><description>fd101fbc4aacf5d48b76a65e3aa5db6d</description></item>
    /// <item><term>GreaterCognatogenWisdomCharismaBuff</term><description>60eb20b9d1077ed4f8f8a9df5490a208</description></item>
    /// <item><term>WrathOfAncestorEnchantment</term><description>4dbc03bd6223b484d8cd9afc3e0369b0</description></item>
    /// </list>
    /// </remarks>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>1_FirstDeathAbility</term><description>4445d9d1c21141c6a0bb24baf373ef78</description></item>
    /// <item><term>GreyGarrison_MainCharacterMythic</term><description>319593628714e004a888bfda1c1b0cbf</description></item>
    /// <item><term>ZeorisDaggerRing_GoverningAllyBuff</term><description>02680be495534b629d543daa89b47079</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ChameleonStrideGreaterBuff</term><description>6af02d0eed547514792f52bdb741da5d</description></item>
    /// <item><term>DeadeyeEnchantment</term><description>32712327ae4241f47bb7fc96027799dd</description></item>
    /// <item><term>SurefireGlovesFeature</term><description>fe65b4d9191ce494380e3f60f41cec9e</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonAoOGazeArea</term><description>bc346635e3d04df7968249d59ea756ba</description></item>
    /// <item><term>HolyWhisper</term><description>5f1ca17be3ba44949be427f18e696d9b</description></item>
    /// <item><term>WordOfChaos</term><description>69f2e7aff2d1cd148b8075ee476515b1</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DeterminedZeal</term><description>a59b08fdf85465a48b036fd9ef4bcc71</description></item>
    /// <item><term>DivineAnathema</term><description>1777a6ff0ae558749b76766a7a575802</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AngelBringBackTouch</term><description>067035da0186d6e43bb4138f433911ee</description></item>
    /// <item><term>InspiringRecoveryCheckBuff</term><description>dc9a8ddf45adbc74aaff7b309f232072</description></item>
    /// <item><term>SwarmFeastArea</term><description>23d8c63c3af634843aa11f5a169683b5</description></item>
    /// </list>
    /// </remarks>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BearerOfSorrowEnchantment</term><description>8a7d0e599fe6b8c4c9ee034eb6af1830</description></item>
    /// <item><term>GowrowAquaticShortspearEnchantment</term><description>c845e1109500f9a4aaabf7a494c4068d</description></item>
    /// <item><term>RangingShots</term><description>2b558167862b05d47b8472d176257f82</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AnimalisticPerseveranceFeature</term><description>1a3d8a5e342c47a7b721ca699a9613ed</description></item>
    /// <item><term>BlindingEnlightenmentFeature</term><description>e343b492d1182404c91048186b7b58fb</description></item>
    /// <item><term>LizardTailFeature</term><description>036d7e6bf5c14defa8fd90fd83a15e15</description></item>
    /// </list>
    /// </remarks>
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
    /// Adds <see cref="ContextConditionCasterWeaponInTwoHands"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BracersOfDominanceFeature</term><description>cdc4f29bc423d454e9af87a514a14de7</description></item>
    /// </list>
    /// </remarks>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AasimarHaloToggleAbility</term><description>248bbb747c273684d9fdf2ed38935def</description></item>
    /// <item><term>HealingJudgmentAbility</term><description>00b6d36e31548dc4ab0ac9d15e64a980</description></item>
    /// <item><term>ViperFamiliarAbility</term><description>52b0d34465ad50545836fddd437cf5c9</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Areelu_UnbreakableDefenseBuff</term><description>57572f514d5b49bf98432026c80382c3</description></item>
    /// <item><term>DragonLevel2MaxAbilityIntelligenceFeature</term><description>21c84e44bf6c4639a0db1a515c0ee3c0</description></item>
    /// <item><term>TransmutationSchoolStrengthAbility</term><description>aadee249a033b2747b63344a758e91be</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BracersOfOverwhelmingVigorFeature</term><description>b34921b9358e1154783b98fb6aac3cae</description></item>
    /// <item><term>PlagueDeathQuarterstaffFeature</term><description>357d9df84a28fa949a575e8841c4e75e</description></item>
    /// <item><term>ZealousMightItemEnchantment</term><description>819877d9ef15d9d45ac876ca21030279</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BoneSpearConjure</term><description>ca8bc7d438e6b004a87222f3c32572f2</description></item>
    /// <item><term>ImpalerEnchantment</term><description>a70838190b8751e4c93f5c410d8ca356</description></item>
    /// <item><term>Unused_SZ_1</term><description>204c7132bafa41c993ffdb9ae675d5eb</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>MasterHunterCasterBuff</term><description>90889f69c21b32446a21a1c0770237ee</description></item>
    /// <item><term>MasterSpyCasterBuff</term><description>ff2e84b215b187347a406670ab2f5cf7</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>NereidBeguilingAuraAreaEffect</term><description>466ec47d91f209646aa1b66a797b7d8d</description></item>
    /// </list>
    /// </remarks>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AngelSwordEffectBuff</term><description>f5f500d6a2a39fc4181af32ad79af488</description></item>
    /// <item><term>InvisibilityMassBuff</term><description>21d0ca87ffdda4845be154ba0fe3ac6a</description></item>
    /// <item><term>ZeorisDaggerRing_BetrayalFeature</term><description>1f6fabee66d54992bc912236d36b50f8</description></item>
    /// </list>
    /// </remarks>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PillarOfLifeaArea</term><description>7d0cebd89884679469533be8b680d55c</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PurpleWormSwallowWholeFeature</term><description>dee864aec4a0d344b913dd27a4b504cb</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AngelfireApostleVersatileChannelRestorationLesser</term><description>95e3e99ea2f5932408b0310ebc7e9af1</description></item>
    /// <item><term>KineticRestorationAbility</term><description>1dc60bdbf5843f342aaa5e838b66e43a</description></item>
    /// <item><term>WrathOfTheUndeadBuff</term><description>6a30b625459e421d862debf0b3d0214f</description></item>
    /// </list>
    /// </remarks>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>123</term><description>535217378b8a4ca3ba5a45f0002de07c</description></item>
    /// <item><term>DirtySquealerEtude</term><description>073253b35c6147e28b603e7e4cfb2ddd</description></item>
    /// <item><term>ZeorisDaggerEtude</term><description>ad64557f3ad74ff0b36fce6364df6ab2</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Mageblade</term><description>eb130f652be2dc14b9a5f63608672021</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder ContextConditionHasTouchSpellCharge(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionHasTouchSpellCharge>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionHitDice"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Arbitrament</term><description>0f5bd128c76dd374b8cb9111e3b5186b</description></item>
    /// <item><term>Halaseliax_FrightfulPresenceArea</term><description>b2114357604b47809a3808ea6973ce72</description></item>
    /// <item><term>WoundWormsLair_BlackDragonFrightfulPresenceArea</term><description>382910feb429e1449b3f8f2a633e3244</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonAoOGazeArea</term><description>bc346635e3d04df7968249d59ea756ba</description></item>
    /// <item><term>EclipseChillOnBuff</term><description>1d585582fbe72e14aadc5cd7985c06f4</description></item>
    /// <item><term>WrathOfTheUndeadArea</term><description>22e31702587142ddb99391d589ba538b</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>HammerOfMasterpieceAbility</term><description>0781ebffe79c5ee4caf127956b9574eb</description></item>
    /// <item><term>HammerOfMasterpieceEnchantment</term><description>f0a7d830ec5bfa44ba77996938db980f</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AnimalInsightArea</term><description>d3c9117d43833df49a253df19377bbfe</description></item>
    /// <item><term>FightDefensivelyToggleAbility</term><description>09d742e8b50b0214fb71acfc99cc00b3</description></item>
    /// <item><term>ScapegoatAbilityAlly</term><description>b9c07dc0df2977c479d19735d956284a</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AllRoundDefenseAreaEffect</term><description>5e56c4ff29094864aa23ec9b5b4ccf57</description></item>
    /// <item><term>HalfOfPairedPendantArea</term><description>8187fd9306b8c4f46824fbba9808f458</description></item>
    /// <item><term>ZeroState</term><description>c6195ff24255d3f46a26323de9f1187a</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcidBomb</term><description>fd101fbc4aacf5d48b76a65e3aa5db6d</description></item>
    /// <item><term>HexChannelerChannelPositiveHarm</term><description>fb917ad147d846e42ad22c8e14f44b79</description></item>
    /// <item><term>ZippyMagicFeature</term><description>30b4200f897ba25419ba3a292aed4053</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>MarksmansSteadyHandFeature</term><description>86baea5d6bde19d4b9845c5c33eeec1b</description></item>
    /// <item><term>TricksterSneakyQuack</term><description>bf41d492ff138ae4e9775e6fd9c8011e</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>MusicOfDeathEnchantment</term><description>183a4d2cc996c6f4db8641bed4b3b0c1</description></item>
    /// <item><term>TeamworkFeature</term><description>bf416f1805710104cad270bd81727274</description></item>
    /// <item><term>VigilantWatchFeature</term><description>d4cf7afc49b81e34989f2dfa76889fed</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>MusicOfDeathEnchantment</term><description>183a4d2cc996c6f4db8641bed4b3b0c1</description></item>
    /// <item><term>SoundOfVoidEnchantment</term><description>69df5e137a08d9b4ead5d87bf4d5d0ac</description></item>
    /// <item><term>TheDissectorEnchantment</term><description>3e90ab8205854cd591538c1aff04b901</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AngelHaloArea</term><description>7aa654dc15f051b4e865dc82b6765b0c</description></item>
    /// <item><term>DeathAttackAbility</term><description>14f11007d016ec94682af6de83959a83</description></item>
    /// <item><term>WoundingBattleaxeBleedBuff</term><description>b6452a2ac912260409a18aa8e69e60f7</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder ContextConditionIsInCombat(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsInCombat>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsMainCharacter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonMythicClass</term><description>15a85e67b7d69554cab9ed5830d0268e</description></item>
    /// <item><term>AzataMythicClass</term><description>9a3b2c63afa79744cbca46bea0da9a16</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder ContextConditionIsMainCharacter(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionIsMainCharacter>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionIsMainTarget"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbandonedKeep_AcidTrap</term><description>e7dadeb8b1d78a341bb4357b502da424</description></item>
    /// <item><term>CurseWeaknessBomb</term><description>197624a197c10cb48bc4dcb229efb91b</description></item>
    /// <item><term>WideSweepAbility</term><description>69811d984ba4ab8419873b09c1641e36</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AngelBringBackTouch</term><description>067035da0186d6e43bb4138f433911ee</description></item>
    /// <item><term>FlamewardenEmbersTouch</term><description>9c7ebca48b7340242a761a9f53e2f010</description></item>
    /// <item><term>WoundingBattleaxeBleedBuff</term><description>b6452a2ac912260409a18aa8e69e60f7</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AnimalFocusBearBuff</term><description>fa25fec82271c93478194c52a20ce733</description></item>
    /// <item><term>AnimalFocusMouseBuff</term><description>127de9efe375a364d94fc68d94ad231a</description></item>
    /// <item><term>AnimalFocusTigerBuff</term><description>18e0d3842308de14ca3fde356bf92b92</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>HammerOfMasterpieceAbility</term><description>0781ebffe79c5ee4caf127956b9574eb</description></item>
    /// <item><term>HammerOfMasterpieceEnchantment</term><description>f0a7d830ec5bfa44ba77996938db980f</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>HammerOfMasterpieceAbility</term><description>0781ebffe79c5ee4caf127956b9574eb</description></item>
    /// <item><term>HammerOfMasterpieceEnchantment</term><description>f0a7d830ec5bfa44ba77996938db980f</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbruptEndEnchantment</term><description>66f1ac1f205e99f4e83c9b3aa8f0b0b1</description></item>
    /// <item><term>MagicalVestmentShieldBuff</term><description>2e8446f820936a44f951b50d70a82b16</description></item>
    /// <item><term>WarpriestShieldbearerChannelPositiveHarm</term><description>894e20539c353c74ab2733a056351947</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbruptEndEnchantment</term><description>66f1ac1f205e99f4e83c9b3aa8f0b0b1</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DeepSlumber</term><description>7658b74f626c56a49939d9c20580885e</description></item>
    /// <item><term>RainbowPattern</term><description>4b8265132f9c8174f87ce7fa6d0fe47b</description></item>
    /// <item><term>SleepKitsune</term><description>f8a32c60ae1f878408b525bb967ef48c</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AnomalyTemplateDefensiveRandomizerBuff</term><description>1a72d85f20f14f1b84d20b8b6e44734e</description></item>
    /// <item><term>ResoundingBlowBuff</term><description>06173a778d7067a439acffe9004916e9</description></item>
    /// <item><term>SwordlordSteelNetBuff</term><description>dc9738ee4e71f5c4287e37f3b74c6fe6</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ElementalEngineBurnoutTriggerFeature</term><description>090d39a5813d4537ba24b55fff7fe6be</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SoulsCloakCurseBuff</term><description>40f948d8e5ee2534eb3d701f256f96b5</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AmiriCampBuff</term><description>f04177fdba7bb324589b7f2b0fd67604</description></item>
    /// <item><term>ShamanBonesSpiritWanderingFeature</term><description>a3862152ae6010445bc25915ac58fc8e</description></item>
    /// <item><term>WitchHexMajorHealingAbility</term><description>3408c351753aa9049af25af31ebef624</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BloodHazeEffectBuff</term><description>06bd4a59646b7fa468166d1c745f31dc</description></item>
    /// <item><term>SecretOfHookingAndSummoning</term><description>72ae181281075c74ea2d1ae74ad95597</description></item>
    /// <item><term>WitchHexLayToRestAbility</term><description>1bb5466b9bfcb5e47b9f667dad5784f9</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonNormalizeSizeGazeEnemyBuff</term><description>dc42e955adbd444fbb3082687080117b</description></item>
    /// <item><term>MasterSlayerBuff</term><description>d474f18e89348bf4db1ff634040ad283</description></item>
    /// <item><term>WintersMarkEnchantment</term><description>0641db56869d87c4bb387e5ae4a18a0e</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonAoOGazeAllyBuff</term><description>a85b9737fba146dcb3468526d67fbc0e</description></item>
    /// <item><term>DevilApostateEvangelizationAbility</term><description>91ba374366c748348a5c1bf85a8685ea</description></item>
    /// <item><term>Valmallos_Buff_AeonGazeEnemy_Core</term><description>217c83b902de44ffa2602d52bafe3d2e</description></item>
    /// </list>
    /// </remarks>
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
    /// Adds <see cref="ContextConditionTargetCanSeeInvisible"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BlinkBuff</term><description>c168c6a0e471e924b8c69b31c6352587</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Feeblemind</term><description>444eed6e26f773a40ab6e4d160c67faa</description></item>
    /// </list>
    /// </remarks>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>EnhancementBonusWilloWisp</term><description>012f72c2749c2e94eb3c389f3f077aac</description></item>
    /// <item><term>ShamanBattleSpiritAbility</term><description>7eda685d53423de4281d8bc0f1197442</description></item>
    /// <item><term>ThunderingClawPet</term><description>e95c2acd75e1d964eaece4a9958d31d5</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DemodandTarryLairMiniboss_TitansGodslayer</term><description>e990ddcda355abd4396fac5e49895578</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder ContextConditionTargetIsDivineCaster(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionTargetIsDivineCaster>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionTargetIsYourself"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcanistExploitArmoredMaskAbility</term><description>2d7d510c6e2e3e54ab9eee84a41fa2cf</description></item>
    /// <item><term>EnlargeSelf</term><description>549e9fcaadc861348b05bf01624387aa</description></item>
    /// <item><term>Valmallos_Area_Gaze</term><description>d031e701dee3487f8a8b7da39e722267</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ParagonOfDefendersAuraBuff</term><description>b348cf228b07b534cb315e7c54f95379</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>GreyGarrison_SuperMythicBuff</term><description>4b11247a4988c254fb9d1cd67f0b1e4a</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BloodlineSerpentineDenOfSpidersSpiderSwarmDamageBuff</term><description>9c414efda39e67344846171c1547edc1</description></item>
    /// <item><term>MandragoraSwarmDamageBuff</term><description>0f4923163104a8748b88e91ec7e14837</description></item>
    /// <item><term>VescavorSwarmDamageBuff</term><description>ddc847a49246ded4f93fe2bf0e2a7dab</description></item>
    /// </list>
    /// </remarks>
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
