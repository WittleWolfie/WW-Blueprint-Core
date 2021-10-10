using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Properties;

namespace BlueprintCore.Blueprints.Components
{
  /**
   * Provides simple constructors for ContextRankConfig objects, ensuring the correct fields are
   * populated. To configure the progression, use the extensions provided by ProgressionExtensions.
   * To configure AbilityRankType, max value, and min value use the extensions provided by
   * CommonExtensions.
   *
   * Example:
   * var rankConfig = ContextRankConfigs.BaseStat(StatType.Strength).Max(30).Add(2);
   *
   * The resulting component will return Strength + 2 with a max of 30.
   *   - The call to Max is a CommonExtension
   *   - The call to Add is a ProgressionExtension
   */
  public static class ContextRankConfigs
  {
    private static ContextRankConfig NewConfig(
        ContextRankBaseValueType valueType,
        string feature = null,
        string[] featureList = null,
        StatType stat = StatType.Unknown,
        ModifierDescriptor modDescriptor = ModifierDescriptor.None,
        string buff = null,
        bool excludeClasses = false,
        string[] archetypes = null,
        string[] classes = null,
        string property = null,
        string[] propertyList = null)
    {
      return new ContextRankConfig
      {
        m_Type = AbilityRankType.Default,
        m_BaseValueType = valueType,
        m_Feature =
            feature == null
                ? BlueprintReferenceBase.CreateTyped<BlueprintFeatureReference>(null)
                : BlueprintTool.GetRef<BlueprintFeature, BlueprintFeatureReference>(feature),
        m_FeatureList =
            featureList?.Select(
                feature =>
                    BlueprintTool.GetRef<BlueprintFeature, BlueprintFeatureReference>(feature))
                .ToArray(),
        m_Stat = stat,
        m_SpecificModifier = modDescriptor,
        m_Buff =
            buff == null
                ? BlueprintReferenceBase.CreateTyped<BlueprintBuffReference>(null)
                : BlueprintTool.GetRef<BlueprintBuff, BlueprintBuffReference>(buff),
        m_ExceptClasses = excludeClasses,
        m_AdditionalArchetypes =
            archetypes?.Select(
                archetype =>
                    BlueprintTool
                        .GetRef<BlueprintArchetype, BlueprintArchetypeReference>(archetype))
                .ToArray(),
        m_Class =
            classes?.Select(
                clazz =>
                    BlueprintTool
                        .GetRef<BlueprintCharacterClass, BlueprintCharacterClassReference>(clazz))
                .ToArray(),
        m_CustomProperty =
            property == null
                ? BlueprintReferenceBase.CreateTyped<BlueprintUnitPropertyReference>(null)
                : BlueprintTool
                    .GetRef<BlueprintUnitProperty, BlueprintUnitPropertyReference>(property),
        m_CustomPropertyList =
            propertyList?.Select(
                property =>
                    BlueprintTool
                        .GetRef<BlueprintUnitProperty, BlueprintUnitPropertyReference>(property))
                .ToArray(),
        m_Progression = ContextRankProgression.AsIs
      };
    }

    public static ContextRankConfig BaseAttack()
    {
      return NewConfig(ContextRankBaseValueType.BaseAttack);
    }

    public static ContextRankConfig BaseStat(StatType stat)
    {
      return NewConfig(ContextRankBaseValueType.BaseStat, stat: stat);
    }

    public static ContextRankConfig StatBonus(
        StatType stat, ModifierDescriptor modDescriptor = ModifierDescriptor.None)
    {
      return NewConfig(
          ContextRankBaseValueType.StatBonus, stat: stat, modDescriptor: modDescriptor);
    }

    public static ContextRankConfig CasterLevel(bool useMax = false)
    {
      return NewConfig(
          useMax
              ? ContextRankBaseValueType.MaxCasterLevel
              : ContextRankBaseValueType.CasterLevel);
    }

    public static ContextRankConfig CharacterLevel()
    {
      return NewConfig(ContextRankBaseValueType.CharacterLevel);
    }

    public static ContextRankConfig CasterCR()
    {
      return NewConfig(ContextRankBaseValueType.CasterCR);
    }

    public static ContextRankConfig DungeonStage()
    {
      return NewConfig(ContextRankBaseValueType.DungeonStage);
    }

    public static ContextRankConfig CustomProperty(string property)
    {
      return NewConfig(ContextRankBaseValueType.CustomProperty, property: property);
    }

    public static ContextRankConfig MaxCustomProperty(params string[] properties)
    {
      return NewConfig(ContextRankBaseValueType.MaxCustomProperty, propertyList: properties);
    }

    public static ContextRankConfig ClassLevel(string[] classes, bool excludeClasses = false)
    {
      return NewConfig(
          ContextRankBaseValueType.ClassLevel,
          classes: classes,
          excludeClasses: excludeClasses);
    }

    public static ContextRankConfig MaxClassLevelWithArchetype(
        string[] classes,
        string[] archetypes,
        bool excludeClasses = false)
    {
      return NewConfig(
          ContextRankBaseValueType.MaxClassLevelWithArchetype,
          classes: classes,
          archetypes: archetypes,
          excludeClasses: excludeClasses);
    }

    public static ContextRankConfig SumClassLevelWithArchetype(
        string[] classes,
        string[] archetypes,
        bool excludeClasses = false,
        bool useOwner = false)
    {
      return NewConfig(
          useOwner
              ? ContextRankBaseValueType.OwnerSummClassLevelWithArchetype
              : ContextRankBaseValueType.SummClassLevelWithArchetype,
          classes: classes,
          archetypes: archetypes,
          excludeClasses: excludeClasses);
    }

    public static ContextRankConfig Bombs(
        string feature,
        string[] classes,
        string[] archetypes,
        bool excludeClasses = false)
    {
      return NewConfig(
          ContextRankBaseValueType.Bombs,
          feature: feature,
          classes: classes,
          archetypes: archetypes,
          excludeClasses: excludeClasses);
    }

    public static ContextRankConfig FeatureRank(string feature, bool useMaster = false)
    {
      return NewConfig(
          useMaster
              ? ContextRankBaseValueType.MasterFeatureRank
              : ContextRankBaseValueType.FeatureRank,
          feature: feature);
    }

    public static ContextRankConfig FeatureList(string[] features, bool useRanks = false)
    {
      return NewConfig(
          useRanks
              ? ContextRankBaseValueType.FeatureListRanks
              : ContextRankBaseValueType.FeatureList,
          featureList: features);
    }

    public static ContextRankConfig MythicLevel(bool useMaster = false)
    {
      return NewConfig(
          useMaster
              ? ContextRankBaseValueType.MasterMythicLevel
              : ContextRankBaseValueType.MythicLevel);
    }

    public static ContextRankConfig MythicLevelPlusBuffRank(string buff)
    {
      return NewConfig(ContextRankBaseValueType.MythicLevelPlusBuffRank, buff: buff);
    }

    public static ContextRankConfig BuffRank(string buff, bool useTarget = false)
    {
      return NewConfig(
          useTarget
              ? ContextRankBaseValueType.TargetBuffRank
              : ContextRankBaseValueType.CasterBuffRank,
          buff: buff);
    }
  }

  /** Contains extension methods to apply common parameters to a ContextRankConfig. */
  public static class CommonExtensions
  {
    public static ContextRankConfig OfType(this ContextRankConfig config, AbilityRankType rankType)
    {
      config.m_Type = rankType;
      return config;
    }

    public static ContextRankConfig Max(this ContextRankConfig config, int max)
    {
      config.m_UseMax = true;
      config.m_Max = max;
      return config;
    }

    public static ContextRankConfig Min(this ContextRankConfig config, int min)
    {
      config.m_UseMin = true;
      config.m_Min = min;
      return config;
    }
  }

  /**
   * Contains extension methods which apply a progression to a ContextRankConfig. Only one should
   * be called on a given ContextRankConfig. All ContextRankConfigs will default to AsIs if no
   * progression is applied.
   *
   * Integer division is truncated, so 3 / 2 = 1 (round down) and -3 / 2 = -1 (round up).
   *
   * These functions try to simplify choosing a progression, but for additional reference there is
   * a calculator: https://docs.google.com/spreadsheets/d/11nQdJ7DFzS73gwR9xk3gsKbyGgtDM51yNoMv7nNYnPw/edit?usp=sharing
   */
  public static class ProgressionExtensions
  {
    /**
     * Result = BaseValue / 2 + Bonus
     *
     * Implements Div2, Div2PlusStep.
     */
    public static ContextRankConfig DivideBy2(this ContextRankConfig config, int bonus = 0)
    {
      if (bonus > 0)
      {
        config.m_Progression = ContextRankProgression.Div2PlusStep;
        config.m_StepLevel = bonus;
      }
      else
      {
        config.m_Progression = ContextRankProgression.Div2;
      }
      return config;
    }

    /**
     * Result = 1 + (BaseValue - 1) / 2
     *
     * Implements OnePlusDiv2.
     */
    public static ContextRankConfig DivideBy2ThenAdd1(this ContextRankConfig config)
    {
      config.m_Progression = ContextRankProgression.OnePlusDiv2;
      return config;
    }

    /**
     * Result = BaseValue / Divisor
     *
     * Implements DivStep.
     */
    public static ContextRankConfig DivideBy(this ContextRankConfig config, int divisor)
    {
      config.m_Progression = ContextRankProgression.DivStep;
      config.m_StepLevel = divisor;
      return config;
    }

    /**
     * Result = 1 + Max((BaseValue - Start) / Divisor, 0)
     *     OR = 0, if delayStart is true and BaseValue < Start
     *
     * Implements StartPlusDivStep, DelayedStartPlusDivStep, OnePlusDivStep.
     */
    public static ContextRankConfig DivideByThenAdd1(
        this ContextRankConfig config, int divisor, int start = 0, bool delayStart = false)
    {
      config.m_Progression =
          delayStart
              ? ContextRankProgression.DelayedStartPlusDivStep
              : ContextRankProgression.StartPlusDivStep;
      config.m_StepLevel = divisor;
      config.m_StartLevel = start;
      return config;
    }

    /**
     * Result = 1 + 2 * Max((BaseValue - Start) / Divisor, 0)
     *
     * Implements StartPlusDoubleDivStep.
     */
    public static ContextRankConfig DivideByThenDoubleThenAdd1(
        this ContextRankConfig config, int divisor, int start = 0)
    {
      config.m_Progression = ContextRankProgression.StartPlusDoubleDivStep;
      config.m_StepLevel = divisor;
      config.m_StartLevel = start;
      return config;
    }

    /**
     * Result = BaseValue * Multiplier
     *
     * Implements MultiplyByModifier.
     */
    public static ContextRankConfig MultiplyBy(this ContextRankConfig config, int multiplier)
    {
      config.m_Progression = ContextRankProgression.MultiplyByModifier;
      config.m_StepLevel = multiplier;
      return config;
    }

    /**
     * Result = BaseValue + Bonus
     *     OR = 2*BaseValue + Bonus, if doubleBaseValue is true
     *
     * Implements BonusValue, DoublePlusBonusValue.
     */
    public static ContextRankConfig Add(
        this ContextRankConfig config, int bonus, bool doubleBaseValue = false)
    {
      config.m_Progression =
          doubleBaseValue
              ? ContextRankProgression.DoublePlusBonusValue
              : ContextRankProgression.BonusValue;
      config.m_StepLevel = bonus;
      return config;
    }

    /**
     * Result = BaseValue + BaseValue / 2
     *
     * Implements HalfMore.
     */
    public static ContextRankConfig AddHalf(this ContextRankConfig config)
    {
      config.m_Progression = ContextRankProgression.HalfMore;
      return config;
    }

    /**
     * Entries must be provided in ascending order by their BaseValue.
     *
     * The resulting value is the ProgressionValue of the first entry where the config's
     * BaseValue <= the entry's BaseValue. If the config's BaseValue is greater than all entry
     * BaseValues, the last entry's ProgressionValue is returned.
     *
     * Example:
     * contextRankConfig.Custom(
     *     new ProgessionEntry(5, 1),
     *     new ProgessionEntry(10, 2),
     *     new ProgessionEntry(13, 4),
     *     new ProgessionEntry(18, 6));
     *
     * Result:
     *   - Levels 1-9:   1
     *   - Levels 10-12: 2
     *   - Levels 13-17: 4
     *   - Levels 18+:   6
     *
     * Implements Custom.
     */
    public static ContextRankConfig CustomProgression(
        this ContextRankConfig config, params ProgressionEntry[] entries)
    {
      config.m_Progression = ContextRankProgression.Custom;
      config.m_CustomProgression = entries;
      return config;
    }
  }

  public class ProgressionEntry : ContextRankConfig.CustomProgressionItem
  {
    public ProgressionEntry(int baseValue, int progressionValue) : base()
    {
      BaseValue = baseValue;
      ProgressionValue = progressionValue;
    }
  }
}