using BlueprintCore.Blueprints.Components;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Mechanics.Components;
using Xunit;
using static BlueprintCore.Test.TestData;

namespace BlueprintCore.Test.Blueprints.Components
{
  public class ContextRankConfigsTest : TestBase
  {
    [Fact]
    public void BaseAttack()
    {
      var config = ContextRankConfigs.BaseAttack();

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.BaseAttack, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);
    }

    [Fact]
    public void BaseStat()
    {
      var config = ContextRankConfigs.BaseStat(StatType.AC);

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.BaseStat, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);

      Assert.Equal(StatType.AC, config.m_Stat);
    }

    [Fact]
    public void StatBonus()
    {
      var config = ContextRankConfigs.StatBonus(StatType.Wisdom);

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.StatBonus, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);

      Assert.Equal(StatType.Wisdom, config.m_Stat);
      Assert.Equal(ModifierDescriptor.None, config.m_SpecificModifier);
    }

    [Fact]
    public void StatBonus_WithModDesriptor()
    {
      var config =
          ContextRankConfigs.StatBonus(
              StatType.Wisdom, modDescriptor: ModifierDescriptor.Competence);

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.StatBonus, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);

      Assert.Equal(StatType.Wisdom, config.m_Stat);
      Assert.Equal(ModifierDescriptor.Competence, config.m_SpecificModifier);
    }

    [Fact]
    public void CasterLevel()
    {
      var config = ContextRankConfigs.CasterLevel();

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.CasterLevel, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);
    }

    [Fact]
    public void CasterLevel_UseMax()
    {
      var config = ContextRankConfigs.CasterLevel(useMax: true);

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.MaxCasterLevel, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);
    }

    [Fact]
    public void CharacterLevel()
    {
      var config = ContextRankConfigs.CharacterLevel();

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.CharacterLevel, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);
    }

    [Fact]
    public void CasterCR()
    {
      var config = ContextRankConfigs.CasterCR();

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.CasterCR, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);
    }

    [Fact]
    public void DungeonStage()
    {
      var config = ContextRankConfigs.DungeonStage();

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.DungeonStage, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);
    }

    [Fact]
    public void CustomProperty()
    {
      var config = ContextRankConfigs.CustomProperty(PropertyGuid);

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.CustomProperty, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);

      Assert.Equal(Property.ToReference<BlueprintUnitPropertyReference>(), config.m_CustomProperty);
    }

    [Fact]
    public void MaxCustomProperty()
    {
      var config = ContextRankConfigs.MaxCustomProperty(PropertyGuid, ExtraPropertyGuid);

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.MaxCustomProperty, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);

      Assert.Equal(2, config.m_CustomPropertyList.Length);
      Assert.Contains(
          Property.ToReference<BlueprintUnitPropertyReference>(), config.m_CustomPropertyList);
      Assert.Contains(
          ExtraProperty.ToReference<BlueprintUnitPropertyReference>(), config.m_CustomPropertyList);
    }

    [Fact]
    public void ClassLevel()
    {
      var config = ContextRankConfigs.ClassLevel(new string[] { ClassGuid, ExtraClassGuid });

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.ClassLevel, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);

      Assert.Equal(2, config.m_Class.Length);
      Assert.Contains(Clazz.ToReference<BlueprintCharacterClassReference>(), config.m_Class);
      Assert.Contains(ExtraClass.ToReference<BlueprintCharacterClassReference>(), config.m_Class);
      Assert.False(config.m_ExceptClasses);
    }

    [Fact]
    public void ClassLevel_ExcludeClasses()
    {
      var config =
          ContextRankConfigs.ClassLevel(
              new string[] { ClassGuid, ExtraClassGuid }, excludeClasses: true);

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.ClassLevel, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);

      Assert.Equal(2, config.m_Class.Length);
      Assert.Contains(Clazz.ToReference<BlueprintCharacterClassReference>(), config.m_Class);
      Assert.Contains(ExtraClass.ToReference<BlueprintCharacterClassReference>(), config.m_Class);
      Assert.True(config.m_ExceptClasses);
    }

    [Fact]
    public void MaxClassLevelWithArchetype()
    {
      var config =
          ContextRankConfigs.MaxClassLevelWithArchetype(
              new string[] { ClassGuid, ExtraClassGuid },
              new string[] { ArchetypeGuid, ExtraArchetypeGuid });

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.MaxClassLevelWithArchetype, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);

      Assert.Equal(2, config.m_Class.Length);
      Assert.Contains(Clazz.ToReference<BlueprintCharacterClassReference>(), config.m_Class);
      Assert.Contains(ExtraClass.ToReference<BlueprintCharacterClassReference>(), config.m_Class);
      Assert.False(config.m_ExceptClasses);

      Assert.Equal(2, config.m_AdditionalArchetypes.Length);
      Assert.Contains(
          Archetype.ToReference<BlueprintArchetypeReference>(), config.m_AdditionalArchetypes);
      Assert.Contains(
          ExtraArchetype.ToReference<BlueprintArchetypeReference>(), config.m_AdditionalArchetypes);
    }

    [Fact]
    public void MaxClassLevelWithArchetype_ExcludeClasses()
    {
      var config =
          ContextRankConfigs.MaxClassLevelWithArchetype(
              new string[] { ClassGuid, ExtraClassGuid },
              new string[] { ArchetypeGuid, ExtraArchetypeGuid },
              excludeClasses: true);

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.MaxClassLevelWithArchetype, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);

      Assert.Equal(2, config.m_Class.Length);
      Assert.Contains(Clazz.ToReference<BlueprintCharacterClassReference>(), config.m_Class);
      Assert.Contains(ExtraClass.ToReference<BlueprintCharacterClassReference>(), config.m_Class);
      Assert.True(config.m_ExceptClasses);

      Assert.Equal(2, config.m_AdditionalArchetypes.Length);
      Assert.Contains(
          Archetype.ToReference<BlueprintArchetypeReference>(), config.m_AdditionalArchetypes);
      Assert.Contains(
          ExtraArchetype.ToReference<BlueprintArchetypeReference>(), config.m_AdditionalArchetypes);
    }

    [Fact]
    public void SumClassLevelWithArchetype()
    {
      var config =
          ContextRankConfigs.SumClassLevelWithArchetype(
              new string[] { ClassGuid, ExtraClassGuid },
              new string[] { ArchetypeGuid, ExtraArchetypeGuid });

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.SummClassLevelWithArchetype, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);

      Assert.Equal(2, config.m_Class.Length);
      Assert.Contains(Clazz.ToReference<BlueprintCharacterClassReference>(), config.m_Class);
      Assert.Contains(ExtraClass.ToReference<BlueprintCharacterClassReference>(), config.m_Class);
      Assert.False(config.m_ExceptClasses);

      Assert.Equal(2, config.m_AdditionalArchetypes.Length);
      Assert.Contains(
          Archetype.ToReference<BlueprintArchetypeReference>(), config.m_AdditionalArchetypes);
      Assert.Contains(
          ExtraArchetype.ToReference<BlueprintArchetypeReference>(), config.m_AdditionalArchetypes);
    }

    [Fact]
    public void SumClassLevelWithArchetype_ExcludeClasses()
    {
      var config =
          ContextRankConfigs.SumClassLevelWithArchetype(
              new string[] { ClassGuid, ExtraClassGuid },
              new string[] { ArchetypeGuid, ExtraArchetypeGuid },
              excludeClasses: true);

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.SummClassLevelWithArchetype, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);

      Assert.Equal(2, config.m_Class.Length);
      Assert.Contains(Clazz.ToReference<BlueprintCharacterClassReference>(), config.m_Class);
      Assert.Contains(ExtraClass.ToReference<BlueprintCharacterClassReference>(), config.m_Class);
      Assert.True(config.m_ExceptClasses);

      Assert.Equal(2, config.m_AdditionalArchetypes.Length);
      Assert.Contains(
          Archetype.ToReference<BlueprintArchetypeReference>(), config.m_AdditionalArchetypes);
      Assert.Contains(
          ExtraArchetype.ToReference<BlueprintArchetypeReference>(), config.m_AdditionalArchetypes);
    }

    [Fact]
    public void SumClassLevelWithArchetype_UseOwner()
    {
      var config =
          ContextRankConfigs.SumClassLevelWithArchetype(
              new string[] { ClassGuid, ExtraClassGuid },
              new string[] { ArchetypeGuid, ExtraArchetypeGuid },
              useOwner: true);

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(
          ContextRankBaseValueType.OwnerSummClassLevelWithArchetype, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);

      Assert.Equal(2, config.m_Class.Length);
      Assert.Contains(Clazz.ToReference<BlueprintCharacterClassReference>(), config.m_Class);
      Assert.Contains(ExtraClass.ToReference<BlueprintCharacterClassReference>(), config.m_Class);
      Assert.False(config.m_ExceptClasses);

      Assert.Equal(2, config.m_AdditionalArchetypes.Length);
      Assert.Contains(
          Archetype.ToReference<BlueprintArchetypeReference>(), config.m_AdditionalArchetypes);
      Assert.Contains(
          ExtraArchetype.ToReference<BlueprintArchetypeReference>(), config.m_AdditionalArchetypes);
    }

    [Fact]
    public void SumClassLevelWithArchetype_UseOwner_ExcludeClasses()
    {
      var config =
          ContextRankConfigs.SumClassLevelWithArchetype(
              new string[] { ClassGuid, ExtraClassGuid },
              new string[] { ArchetypeGuid, ExtraArchetypeGuid },
              excludeClasses: true,
              useOwner: true);

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(
          ContextRankBaseValueType.OwnerSummClassLevelWithArchetype, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);

      Assert.Equal(2, config.m_Class.Length);
      Assert.Contains(Clazz.ToReference<BlueprintCharacterClassReference>(), config.m_Class);
      Assert.Contains(ExtraClass.ToReference<BlueprintCharacterClassReference>(), config.m_Class);
      Assert.True(config.m_ExceptClasses);

      Assert.Equal(2, config.m_AdditionalArchetypes.Length);
      Assert.Contains(
          Archetype.ToReference<BlueprintArchetypeReference>(), config.m_AdditionalArchetypes);
      Assert.Contains(
          ExtraArchetype.ToReference<BlueprintArchetypeReference>(), config.m_AdditionalArchetypes);
    }

    [Fact]
    public void Bombs()
    {
      var config =
          ContextRankConfigs.Bombs(
              FeatureGuid,
              new string[] { ClassGuid, ExtraClassGuid },
              new string[] { ArchetypeGuid, ExtraArchetypeGuid });

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.Bombs, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), config.m_Feature);

      Assert.Equal(2, config.m_Class.Length);
      Assert.Contains(Clazz.ToReference<BlueprintCharacterClassReference>(), config.m_Class);
      Assert.Contains(ExtraClass.ToReference<BlueprintCharacterClassReference>(), config.m_Class);
      Assert.False(config.m_ExceptClasses);

      Assert.Equal(2, config.m_AdditionalArchetypes.Length);
      Assert.Contains(
          Archetype.ToReference<BlueprintArchetypeReference>(), config.m_AdditionalArchetypes);
      Assert.Contains(
          ExtraArchetype.ToReference<BlueprintArchetypeReference>(), config.m_AdditionalArchetypes);
    }

    [Fact]
    public void Bombs_ExcludeClasses()
    {
      var config =
          ContextRankConfigs.Bombs(
              FeatureGuid,
              new string[] { ClassGuid, ExtraClassGuid },
              new string[] { ArchetypeGuid, ExtraArchetypeGuid },
              excludeClasses: true);

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.Bombs, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), config.m_Feature);

      Assert.Equal(2, config.m_Class.Length);
      Assert.Contains(Clazz.ToReference<BlueprintCharacterClassReference>(), config.m_Class);
      Assert.Contains(ExtraClass.ToReference<BlueprintCharacterClassReference>(), config.m_Class);
      Assert.True(config.m_ExceptClasses);

      Assert.Equal(2, config.m_AdditionalArchetypes.Length);
      Assert.Contains(
          Archetype.ToReference<BlueprintArchetypeReference>(), config.m_AdditionalArchetypes);
      Assert.Contains(
          ExtraArchetype.ToReference<BlueprintArchetypeReference>(), config.m_AdditionalArchetypes);
    }

    [Fact]
    public void FeatureRank()
    {
      var config = ContextRankConfigs.FeatureRank(FeatureGuid);

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.FeatureRank, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), config.m_Feature);
    }

    [Fact]
    public void FeatureRank_UseMaster()
    {
      var config = ContextRankConfigs.FeatureRank(FeatureGuid, useMaster: true);

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.MasterFeatureRank, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), config.m_Feature);
    }

    [Fact]
    public void FeatureList()
    {
      var config = ContextRankConfigs.FeatureList(new string[] { FeatureGuid, ExtraFeatureGuid });

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.FeatureList, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);

      Assert.Equal(2, config.m_FeatureList.Length);
      Assert.Contains(TestFeature.ToReference<BlueprintFeatureReference>(), config.m_FeatureList);
      Assert.Contains(ExtraFeature.ToReference<BlueprintFeatureReference>(), config.m_FeatureList);
    }

    [Fact]
    public void FeatureList_UseRanks()
    {
      var config =
          ContextRankConfigs.FeatureList(
              new string[] { FeatureGuid, ExtraFeatureGuid }, useRanks: true);

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.FeatureListRanks, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);

      Assert.Equal(2, config.m_FeatureList.Length);
      Assert.Contains(TestFeature.ToReference<BlueprintFeatureReference>(), config.m_FeatureList);
      Assert.Contains(ExtraFeature.ToReference<BlueprintFeatureReference>(), config.m_FeatureList);
    }

    [Fact]
    public void MythicLevel()
    {
      var config = ContextRankConfigs.MythicLevel();

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.MythicLevel, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);
    }

    [Fact]
    public void MythicLevel_UseMaster()
    {
      var config = ContextRankConfigs.MythicLevel(useMaster: true);

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.MasterMythicLevel, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);
    }

    [Fact]
    public void MythicLevelPlusBuffRank()
    {
      var config = ContextRankConfigs.MythicLevelPlusBuffRank(BuffGuid);

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.MythicLevelPlusBuffRank, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);

      Assert.Equal(Buff.ToReference<BlueprintBuffReference>(), config.m_Buff);
    }

    [Fact]
    public void BuffRank()
    {
      var config = ContextRankConfigs.BuffRank(BuffGuid);

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.CasterBuffRank, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);

      Assert.Equal(Buff.ToReference<BlueprintBuffReference>(), config.m_Buff);
    }

    [Fact]
    public void BuffRank_UseTarget()
    {
      var config = ContextRankConfigs.BuffRank(BuffGuid, useTarget: true);

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.TargetBuffRank, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);

      Assert.Equal(Buff.ToReference<BlueprintBuffReference>(), config.m_Buff);
    }

    [Fact]
    public void OfType()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(AbilityRankType.Default, initialConfig.m_Type);

      var config = initialConfig.OfType(AbilityRankType.StatBonus);

      Assert.Equal(initialConfig, config);
      Assert.Equal(AbilityRankType.StatBonus, config.m_Type);
    }

    [Fact]
    public void Max()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.False(initialConfig.m_UseMax);

      var config = initialConfig.Max(2);

      Assert.Equal(initialConfig, config);
      Assert.True(config.m_UseMax);
      Assert.Equal(2, config.m_Max);
    }

    [Fact]
    public void Min()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.False(initialConfig.m_UseMin);

      var config = initialConfig.Min(5);

      Assert.Equal(initialConfig, config);
      Assert.True(config.m_UseMin);
      Assert.Equal(5, config.m_Min);
    }

    [Fact]
    public void DivideBy2()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.DivideBy2();

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.Div2, config.m_Progression);
    }

    [Fact]
    public void DivideBy2_WithBonus()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.DivideBy2(3);

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.Div2PlusStep, config.m_Progression);
      Assert.Equal(3, config.m_StepLevel);
    }

    [Fact]
    public void DivideBy2ThenAdd1()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.DivideBy2ThenAdd1();

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.OnePlusDiv2, config.m_Progression);
    }

    [Fact]
    public void DivideBy()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.DivideBy(6);

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.DivStep, config.m_Progression);
      Assert.Equal(6, config.m_StepLevel);
    }

    [Fact]
    public void DivideByThenAdd1()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.DivideByThenAdd1(4);

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.StartPlusDivStep, config.m_Progression);
      Assert.Equal(4, config.m_StepLevel);
      Assert.Equal(0, config.m_StartLevel);
    }

    [Fact]
    public void DivideByThenAdd1_WithStart()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.DivideByThenAdd1(2, start: 3);

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.StartPlusDivStep, config.m_Progression);
      Assert.Equal(2, config.m_StepLevel);
      Assert.Equal(3, config.m_StartLevel);
    }

    [Fact]
    public void DivideByThenAdd1_WithDelayStart()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.DivideByThenAdd1(5, start: 3, delayStart: true);

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.DelayedStartPlusDivStep, config.m_Progression);
      Assert.Equal(5, config.m_StepLevel);
      Assert.Equal(3, config.m_StartLevel);
    }

    [Fact]
    public void DivideByThenDoubleThenAdd1()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.DivideByThenDoubleThenAdd1(3);

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.StartPlusDoubleDivStep, config.m_Progression);
      Assert.Equal(3, config.m_StepLevel);
      Assert.Equal(0, config.m_StartLevel);
    }

    [Fact]
    public void DivideByThenDoubleThenAdd1_WithStart()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.DivideByThenDoubleThenAdd1(5, start: 2);

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.StartPlusDoubleDivStep, config.m_Progression);
      Assert.Equal(5, config.m_StepLevel);
      Assert.Equal(2, config.m_StartLevel);
    }

    [Fact]
    public void MultiplyBy()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.MultiplyBy(3);

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.MultiplyByModifier, config.m_Progression);
      Assert.Equal(3, config.m_StepLevel);
    }

    [Fact]
    public void Add()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.Add(5);

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.BonusValue, config.m_Progression);
      Assert.Equal(5, config.m_StepLevel);
    }

    [Fact]
    public void Add_DoubleBaseValue()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.Add(2, doubleBaseValue: true);

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.DoublePlusBonusValue, config.m_Progression);
      Assert.Equal(2, config.m_StepLevel);
    }

    [Fact]
    public void AddHalf()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.AddHalf();

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.HalfMore, config.m_Progression);
    }

    [Fact]
    public void CustomProgression()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.CustomProgression((2, 2), (4, 6), (8, 12));

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.Custom, config.m_Progression);

      Assert.Equal(3, config.m_CustomProgression.Length);
      Assert.Equal(2, config.m_CustomProgression[0].BaseValue);
      Assert.Equal(2, config.m_CustomProgression[0].ProgressionValue);
      Assert.Equal(4, config.m_CustomProgression[1].BaseValue);
      Assert.Equal(6, config.m_CustomProgression[1].ProgressionValue);
      Assert.Equal(8, config.m_CustomProgression[2].BaseValue);
      Assert.Equal(12, config.m_CustomProgression[2].ProgressionValue);
    }

    [Fact]
    public void CustomProgression_UsingProgessionEntry()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var levelTwo = new ProgressionEntry(2, 2);
      var levelFour = new ProgressionEntry(4, 6);
      var levelEight = new ProgressionEntry(8, 12);
      var config = initialConfig.CustomProgression(levelTwo, levelFour, levelEight);

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.Custom, config.m_Progression);

      Assert.Equal(3, config.m_CustomProgression.Length);
      Assert.Equal(levelTwo, config.m_CustomProgression[0]);
      Assert.Equal(levelFour, config.m_CustomProgression[1]);
      Assert.Equal(levelEight, config.m_CustomProgression[2]);
    }
    
    [Fact]
    public void LinearProgression()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.LinearProgression(2, 1);

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.Custom, config.m_Progression);

      Assert.Equal(41, config.m_CustomProgression.Length);
      AssertProgressionItem((0, 0), config.m_CustomProgression[0]);
      AssertProgressionItem((1, 3), config.m_CustomProgression[1]);
      AssertProgressionItem((2, 5), config.m_CustomProgression[2]);
      AssertProgressionItem((3, 7), config.m_CustomProgression[3]);
      AssertProgressionItem((4, 9), config.m_CustomProgression[4]);
      AssertProgressionItem((5, 11), config.m_CustomProgression[5]);
      AssertProgressionItem((6, 13), config.m_CustomProgression[6]);
      AssertProgressionItem((7, 15), config.m_CustomProgression[7]);
      AssertProgressionItem((8, 17), config.m_CustomProgression[8]);
      AssertProgressionItem((9, 19), config.m_CustomProgression[9]);
      AssertProgressionItem((10, 21), config.m_CustomProgression[10]);
      AssertProgressionItem((11, 23), config.m_CustomProgression[11]);
      AssertProgressionItem((12, 25), config.m_CustomProgression[12]);
      AssertProgressionItem((13, 27), config.m_CustomProgression[13]);
      AssertProgressionItem((14, 29), config.m_CustomProgression[14]);
      AssertProgressionItem((15, 31), config.m_CustomProgression[15]);
      AssertProgressionItem((16, 33), config.m_CustomProgression[16]);
      AssertProgressionItem((17, 35), config.m_CustomProgression[17]);
      AssertProgressionItem((18, 37), config.m_CustomProgression[18]);
      AssertProgressionItem((19, 39), config.m_CustomProgression[19]);
      AssertProgressionItem((20, 41), config.m_CustomProgression[20]);
      AssertProgressionItem((21, 43), config.m_CustomProgression[21]);
      AssertProgressionItem((22, 45), config.m_CustomProgression[22]);
      AssertProgressionItem((23, 47), config.m_CustomProgression[23]);
      AssertProgressionItem((24, 49), config.m_CustomProgression[24]);
      AssertProgressionItem((25, 51), config.m_CustomProgression[25]);
      AssertProgressionItem((26, 53), config.m_CustomProgression[26]);
      AssertProgressionItem((27, 55), config.m_CustomProgression[27]);
      AssertProgressionItem((28, 57), config.m_CustomProgression[28]);
      AssertProgressionItem((29, 59), config.m_CustomProgression[29]);
      AssertProgressionItem((30, 61), config.m_CustomProgression[30]);
      AssertProgressionItem((31, 63), config.m_CustomProgression[31]);
      AssertProgressionItem((32, 65), config.m_CustomProgression[32]);
      AssertProgressionItem((33, 67), config.m_CustomProgression[33]);
      AssertProgressionItem((34, 69), config.m_CustomProgression[34]);
      AssertProgressionItem((35, 71), config.m_CustomProgression[35]);
      AssertProgressionItem((36, 73), config.m_CustomProgression[36]);
      AssertProgressionItem((37, 75), config.m_CustomProgression[37]);
      AssertProgressionItem((38, 77), config.m_CustomProgression[38]);
      AssertProgressionItem((39, 79), config.m_CustomProgression[39]);
      AssertProgressionItem((40, 81), config.m_CustomProgression[40]);
    }

    [Fact]
    public void LinearProgression_WithOptionalValues()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config =
          initialConfig.LinearProgression(
              0.75f,
              0.25f,
              startingBaseValue: 4,
              maxBaseValue: 20,
              progressionValueBeforeStart: 1,
              minProgressionValue: 4,
              maxProgressionValue: 12);

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.Custom, config.m_Progression);

      Assert.Equal(10, config.m_CustomProgression.Length);
      AssertProgressionItem((3, 1), config.m_CustomProgression[0]);
      AssertProgressionItem((6, 4), config.m_CustomProgression[1]);
      AssertProgressionItem((7, 5), config.m_CustomProgression[2]);
      AssertProgressionItem((8, 6), config.m_CustomProgression[3]);
      AssertProgressionItem((10, 7), config.m_CustomProgression[4]);
      AssertProgressionItem((11, 8), config.m_CustomProgression[5]);
      AssertProgressionItem((12, 9), config.m_CustomProgression[6]);
      AssertProgressionItem((14, 10), config.m_CustomProgression[7]);
      AssertProgressionItem((15, 11), config.m_CustomProgression[8]);
      AssertProgressionItem((20, 12), config.m_CustomProgression[9]);
    }

    private static void AssertProgressionItem(
        (int Base, int Progression) expected, ContextRankConfig.CustomProgressionItem actual)
    {
      Assert.Equal(expected.Base, actual.BaseValue);
      Assert.Equal(expected.Progression, actual.ProgressionValue);
    }
  }
}
