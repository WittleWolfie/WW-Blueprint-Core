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
  }
}
