using BlueprintCore.Blueprints.Components;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Mechanics.Components;
using System;
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

      Assert.False(config.m_UseMax);
      Assert.False(config.m_UseMin);
    }

    [Fact]
    public void BaseAttack_WithCommonParams()
    {
      var config = ContextRankConfigs.BaseAttack(type: AbilityRankType.DamageBonus, max: 10, min: 1);

      Assert.Equal(AbilityRankType.DamageBonus, config.m_Type);
      Assert.True(config.m_UseMax);
      Assert.Equal(10, config.m_Max);
      Assert.True(config.m_UseMin);
      Assert.Equal(1, config.m_Min);
    }

    [Fact]
    public void BaseStat()
    {
      var config = ContextRankConfigs.BaseStat(StatType.AC);

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.BaseStat, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);

      Assert.Equal(StatType.AC, config.m_Stat);

      Assert.False(config.m_UseMax);
      Assert.False(config.m_UseMin);
    }

    [Fact]
    public void BaseStat_WithCommonParams()
    {
      var config =
          ContextRankConfigs.BaseStat(StatType.AC, type: AbilityRankType.DamageDiceAlternative, max: 3, min: 3);

      Assert.Equal(AbilityRankType.DamageDiceAlternative, config.m_Type);
      Assert.True(config.m_UseMax);
      Assert.Equal(3, config.m_Max);
      Assert.True(config.m_UseMin);
      Assert.Equal(3, config.m_Min);
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

      Assert.False(config.m_UseMax);
      Assert.False(config.m_UseMin);
    }

    [Fact]
    public void StatBonus_WithCommonParams()
    {
      var config =
          ContextRankConfigs.StatBonus(StatType.Wisdom, type: AbilityRankType.ProjectilesCount, max: 4, min: 8);

      Assert.Equal(AbilityRankType.ProjectilesCount, config.m_Type);
      Assert.True(config.m_UseMax);
      Assert.Equal(4, config.m_Max);
      Assert.True(config.m_UseMin);
      Assert.Equal(8, config.m_Min);
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

      Assert.False(config.m_UseMax);
      Assert.False(config.m_UseMin);
    }

    [Fact]
    public void CasterLevel_WithCommonParams()
    {
      var config = ContextRankConfigs.CasterLevel(type: AbilityRankType.StatBonus, max: 1, min: 4);

      Assert.Equal(AbilityRankType.StatBonus, config.m_Type);
      Assert.True(config.m_UseMax);
      Assert.Equal(1, config.m_Max);
      Assert.True(config.m_UseMin);
      Assert.Equal(4, config.m_Min);
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

      Assert.False(config.m_UseMax);
      Assert.False(config.m_UseMin);
    }

    [Fact]
    public void CharacterLevel_WithCommonParams()
    {
      var config = ContextRankConfigs.CharacterLevel(type: AbilityRankType.SpeedBonus, max: 2, min: 2);

      Assert.Equal(AbilityRankType.SpeedBonus, config.m_Type);
      Assert.True(config.m_UseMax);
      Assert.Equal(2, config.m_Max);
      Assert.True(config.m_UseMin);
      Assert.Equal(2, config.m_Min);
    }

    [Fact]
    public void CasterCR()
    {
      var config = ContextRankConfigs.CasterCR();

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.CasterCR, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);

      Assert.False(config.m_UseMax);
      Assert.False(config.m_UseMin);
    }

    [Fact]
    public void CasterCR_WithCommonParams()
    {
      var config = ContextRankConfigs.CasterCR(type: AbilityRankType.StatBonus, max: 8, min: 6);

      Assert.Equal(AbilityRankType.StatBonus, config.m_Type);
      Assert.True(config.m_UseMax);
      Assert.Equal(8, config.m_Max);
      Assert.True(config.m_UseMin);
      Assert.Equal(6, config.m_Min);
    }

    [Fact]
    public void DungeonStage()
    {
      var config = ContextRankConfigs.DungeonStage();

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.DungeonStage, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);

      Assert.False(config.m_UseMax);
      Assert.False(config.m_UseMin);
    }

    [Fact]
    public void DungeonStage_WithCommonParams()
    {
      var config = ContextRankConfigs.DungeonStage(type: AbilityRankType.DamageBonus, max: 1, min: 1);

      Assert.Equal(AbilityRankType.DamageBonus, config.m_Type);
      Assert.True(config.m_UseMax);
      Assert.Equal(1, config.m_Max);
      Assert.True(config.m_UseMin);
      Assert.Equal(1, config.m_Min);
    }

    [Fact]
    public void CustomProperty()
    {
      var config = ContextRankConfigs.CustomProperty(PropertyGuid);

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.CustomProperty, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);

      Assert.Equal(Property.ToReference<BlueprintUnitPropertyReference>(), config.m_CustomProperty);

      Assert.False(config.m_UseMax);
      Assert.False(config.m_UseMin);
    }

    [Fact]
    public void CustomProperty_WithCommonParams()
    {
      var config = ContextRankConfigs.CustomProperty(PropertyGuid, type: AbilityRankType.StatBonus, max: 12, min: 3);

      Assert.Equal(AbilityRankType.StatBonus, config.m_Type);
      Assert.True(config.m_UseMax);
      Assert.Equal(12, config.m_Max);
      Assert.True(config.m_UseMin);
      Assert.Equal(3, config.m_Min);
    }

    [Fact]
    public void MaxCustomProperty()
    {
      var config = ContextRankConfigs.MaxCustomProperty(new string[] { PropertyGuid, ExtraPropertyGuid });

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.MaxCustomProperty, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);

      Assert.Equal(2, config.m_CustomPropertyList.Length);
      Assert.Contains(
          Property.ToReference<BlueprintUnitPropertyReference>(), config.m_CustomPropertyList);
      Assert.Contains(
          ExtraProperty.ToReference<BlueprintUnitPropertyReference>(), config.m_CustomPropertyList);

      Assert.False(config.m_UseMax);
      Assert.False(config.m_UseMin);
    }

    [Fact]
    public void MaxCustomProperty_WithCommonParams()
    {
      var config =
          ContextRankConfigs.MaxCustomProperty(
              new string[] { PropertyGuid, ExtraPropertyGuid }, type: AbilityRankType.DamageDice, max: 2, min: 3);

      Assert.Equal(AbilityRankType.DamageDice, config.m_Type);
      Assert.True(config.m_UseMax);
      Assert.Equal(2, config.m_Max);
      Assert.True(config.m_UseMin);
      Assert.Equal(3, config.m_Min);
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

      Assert.False(config.m_UseMax);
      Assert.False(config.m_UseMin);
    }

    [Fact]
    public void ClassLevel_WithCommonParams()
    {
      var config =
          ContextRankConfigs.ClassLevel(
              new string[] { ClassGuid, ExtraClassGuid }, type: AbilityRankType.DamageBonus, max: 13, min: 10);

      Assert.Equal(AbilityRankType.DamageBonus, config.m_Type);
      Assert.True(config.m_UseMax);
      Assert.Equal(13, config.m_Max);
      Assert.True(config.m_UseMin);
      Assert.Equal(10, config.m_Min);
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

      Assert.False(config.m_UseMax);
      Assert.False(config.m_UseMin);
    }

    [Fact]
    public void MaxClassLevelWithArchetype_WithCommonParams()
    {
      var config =
          ContextRankConfigs.MaxClassLevelWithArchetype(
              new string[] { ClassGuid, ExtraClassGuid },
              new string[] { ArchetypeGuid, ExtraArchetypeGuid },
              type: AbilityRankType.ProjectilesCount,
              max: 16,
              min: 11);

      Assert.Equal(AbilityRankType.ProjectilesCount, config.m_Type);
      Assert.True(config.m_UseMax);
      Assert.Equal(16, config.m_Max);
      Assert.True(config.m_UseMin);
      Assert.Equal(11, config.m_Min);
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

      Assert.False(config.m_UseMax);
      Assert.False(config.m_UseMin);
    }

    [Fact]
    public void SumClassLevelWithArchetype_WithCommonParams()
    {
      var config =
          ContextRankConfigs.SumClassLevelWithArchetype(
              new string[] { ClassGuid, ExtraClassGuid },
              new string[] { ArchetypeGuid, ExtraArchetypeGuid },
              type: AbilityRankType.SpeedBonus,
              max: 4,
              min: 2);

      Assert.Equal(AbilityRankType.SpeedBonus, config.m_Type);
      Assert.True(config.m_UseMax);
      Assert.Equal(4, config.m_Max);
      Assert.True(config.m_UseMin);
      Assert.Equal(2, config.m_Min);
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

      Assert.False(config.m_UseMax);
      Assert.False(config.m_UseMin);
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

      Assert.False(config.m_UseMax);
      Assert.False(config.m_UseMin);
    }

    [Fact]
    public void Bombs_WithCommonParams()
    {
      var config =
          ContextRankConfigs.Bombs(
              FeatureGuid,
              new string[] { ClassGuid, ExtraClassGuid },
              new string[] { ArchetypeGuid, ExtraArchetypeGuid },
              type: AbilityRankType.StatBonus,
              max: 7,
              min: 6);

      Assert.Equal(AbilityRankType.StatBonus, config.m_Type);
      Assert.True(config.m_UseMax);
      Assert.Equal(7, config.m_Max);
      Assert.True(config.m_UseMin);
      Assert.Equal(6, config.m_Min);
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

      Assert.False(config.m_UseMax);
      Assert.False(config.m_UseMin);
    }

    [Fact]
    public void FeatureRank_WithCommonParams()
    {
      var config =
          ContextRankConfigs.FeatureRank(FeatureGuid, type: AbilityRankType.DamageBonus, max: 11, min: 5);

      Assert.Equal(AbilityRankType.DamageBonus, config.m_Type);
      Assert.True(config.m_UseMax);
      Assert.Equal(11, config.m_Max);
      Assert.True(config.m_UseMin);
      Assert.Equal(5, config.m_Min);
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

      Assert.False(config.m_UseMax);
      Assert.False(config.m_UseMin);
    }

    [Fact]
    public void FeatureList_WithCommonParams()
    {
      var config =
          ContextRankConfigs.FeatureList(
              new string[] { FeatureGuid, ExtraFeatureGuid }, type: AbilityRankType.DamageDice, max: 14, min: 2);

      Assert.Equal(AbilityRankType.DamageDice, config.m_Type);
      Assert.True(config.m_UseMax);
      Assert.Equal(14, config.m_Max);
      Assert.True(config.m_UseMin);
      Assert.Equal(2, config.m_Min);
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

      Assert.False(config.m_UseMax);
      Assert.False(config.m_UseMin);
    }

    [Fact]
    public void MythicLevel_WithCommonParams()
    {
      var config = ContextRankConfigs.MythicLevel(type: AbilityRankType.DamageDice, max: 10, min: 3);

      Assert.Equal(AbilityRankType.DamageDice, config.m_Type);
      Assert.True(config.m_UseMax);
      Assert.Equal(10, config.m_Max);
      Assert.True(config.m_UseMin);
      Assert.Equal(3, config.m_Min);
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

      Assert.False(config.m_UseMax);
      Assert.False(config.m_UseMin);
    }

    [Fact]
    public void BuffRank()
    {
      var config = ContextRankConfigs.BuffRank(BuffGuid);

      Assert.Equal(AbilityRankType.Default, config.m_Type);
      Assert.Equal(ContextRankBaseValueType.CasterBuffRank, config.m_BaseValueType);
      Assert.Equal(ContextRankProgression.AsIs, config.m_Progression);

      Assert.Equal(Buff.ToReference<BlueprintBuffReference>(), config.m_Buff);

      Assert.False(config.m_UseMax);
      Assert.False(config.m_UseMin);
    }

    [Fact]
    public void BuffRank_WithCommonParams()
    {
      var config = ContextRankConfigs.BuffRank(BuffGuid, type: AbilityRankType.DamageDiceAlternative, max: 5, min: 1);

      Assert.Equal(AbilityRankType.DamageDiceAlternative, config.m_Type);
      Assert.True(config.m_UseMax);
      Assert.Equal(5, config.m_Max);
      Assert.True(config.m_UseMin);
      Assert.Equal(1, config.m_Min);
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
    public void WithDiv2Progression()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.WithDiv2Progression();

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.Div2, config.m_Progression);
    }

    [Fact]
    public void WithDiv2Progression_WithBonus()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.WithDiv2Progression(3);

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.Div2PlusStep, config.m_Progression);
      Assert.Equal(3, config.m_StepLevel);
    }

    [Fact]
    public void WithOnePlusDiv2Progression()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.WithOnePlusDiv2Progression();

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.OnePlusDiv2, config.m_Progression);
    }

    [Fact]
    public void WithDivStepProgression()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.WithDivStepProgression(6);

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.DivStep, config.m_Progression);
      Assert.Equal(6, config.m_StepLevel);
    }

    [Fact]
    public void WithStartPlusDivStepProgression()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.WithStartPlusDivStepProgression(4);

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.StartPlusDivStep, config.m_Progression);
      Assert.Equal(4, config.m_StepLevel);
      Assert.Equal(0, config.m_StartLevel);
    }

    [Fact]
    public void WithStartPlusDivStepProgression_WithStart()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.WithStartPlusDivStepProgression(2, start: 3);

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.StartPlusDivStep, config.m_Progression);
      Assert.Equal(2, config.m_StepLevel);
      Assert.Equal(3, config.m_StartLevel);
    }

    [Fact]
    public void WithStartPlusDivStepProgression_WithDelayStart()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.WithStartPlusDivStepProgression(5, start: 3, delayStart: true);

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.DelayedStartPlusDivStep, config.m_Progression);
      Assert.Equal(5, config.m_StepLevel);
      Assert.Equal(3, config.m_StartLevel);
    }

    [Fact]
    public void WithStartPlusDoubleDivStepProgression()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.WithStartPlusDoubleDivStepProgression(3);

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.StartPlusDoubleDivStep, config.m_Progression);
      Assert.Equal(3, config.m_StepLevel);
      Assert.Equal(0, config.m_StartLevel);
    }

    [Fact]
    public void WithStartPlusDoubleDivStepProgression_WithStart()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.WithStartPlusDoubleDivStepProgression(5, start: 2);

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.StartPlusDoubleDivStep, config.m_Progression);
      Assert.Equal(5, config.m_StepLevel);
      Assert.Equal(2, config.m_StartLevel);
    }

    [Fact]
    public void WithMultiplyByModifierProgression()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.WithMultiplyByModifierProgression(3);

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.MultiplyByModifier, config.m_Progression);
      Assert.Equal(3, config.m_StepLevel);
    }

    [Fact]
    public void WithBonusValueProgression()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.WithBonusValueProgression(5);

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.BonusValue, config.m_Progression);
      Assert.Equal(5, config.m_StepLevel);
    }

    [Fact]
    public void WithBonusValueProgression_DoubleBaseValue()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.WithBonusValueProgression(2, doubleBaseValue: true);

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.DoublePlusBonusValue, config.m_Progression);
      Assert.Equal(2, config.m_StepLevel);
    }

    [Fact]
    public void WithHalfMoreProgression()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.WithHalfMoreProgression();

      Assert.Equal(initialConfig, config);
      Assert.Equal(ContextRankProgression.HalfMore, config.m_Progression);
    }

    [Fact]
    public void WithCustomProgression()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.WithCustomProgression((2, 2), (4, 6), (8, 12));

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
    public void WithLinearProgression()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config = initialConfig.WithLinearProgression(2, 1);

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
    public void WithLinearProgression_WithOptionalValues()
    {
      var initialConfig = ContextRankConfigs.CharacterLevel();
      Assert.Equal(ContextRankProgression.AsIs, initialConfig.m_Progression);

      var config =
          initialConfig.WithLinearProgression(
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
