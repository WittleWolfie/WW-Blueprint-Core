using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Test.Asserts;
using BlueprintCore.Test.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Alignments;
using Xunit;
using static BlueprintCore.Test.TestData;

namespace BlueprintCore.Test.Blueprints.Configurators.Classes
{
  public abstract class BaseFeatureConfiguratorTest<T, TBuilder> : BaseUnitFactConfiguratorTest<T, TBuilder>
      where T : BlueprintFeature
      where TBuilder : BaseFeatureConfigurator<T, TBuilder>
  {
    protected BaseFeatureConfiguratorTest() : base() { }

    [Fact]
    public void AddFeatureGroups()
    {
      GetConfigurator(Guid)
          .AddFeatureGroups(FeatureGroup.WizardFeat, FeatureGroup.Domain)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      Assert.Equal(2, blueprint.Groups.Length);
      Assert.Contains(FeatureGroup.WizardFeat, blueprint.Groups);
      Assert.Contains(FeatureGroup.Domain, blueprint.Groups);
    }

    [Fact]
    public void AddFeatureGroups_WithExisting()
    {
      // First pass
      GetConfigurator(Guid)
          .AddFeatureGroups(FeatureGroup.WizardFeat, FeatureGroup.Domain)
          .Configure();

      GetConfigurator(Guid)
          .AddFeatureGroups(FeatureGroup.Feat)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      Assert.Equal(3, blueprint.Groups.Length);
      Assert.Contains(FeatureGroup.WizardFeat, blueprint.Groups);
      Assert.Contains(FeatureGroup.Domain, blueprint.Groups);
      Assert.Contains(FeatureGroup.Feat, blueprint.Groups);
    }

    [Fact]
    public void RemoveFeatureGroups()
    {
      // First pass
      GetConfigurator(Guid)
          .AddFeatureGroups(FeatureGroup.WizardFeat, FeatureGroup.Domain)
          .Configure();

      GetConfigurator(Guid)
          .RemoveFeatureGroups(FeatureGroup.Domain)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      Assert.Single(blueprint.Groups);
      Assert.Contains(FeatureGroup.WizardFeat, blueprint.Groups);
    }

    [Fact]
    public void SetIsClassFeature()
    {
      GetConfigurator(Guid)
          .SetIsClassFeature()
          .Configure();

      var feature = BlueprintTool.Get<T>(Guid);
      Assert.True(feature.IsClassFeature);
    }

    [Fact]
    public void SetIsClassFeature_False()
    {
      GetConfigurator(Guid)
          .SetIsClassFeature(false)
          .Configure();

      var feature = BlueprintTool.Get<T>(Guid);
      Assert.False(feature.IsClassFeature);
    }

    [Fact]
    public void AddIsPrerequisiteFor()
    {
      GetConfigurator(Guid)
          .AddIsPrerequisiteFor(FeatureGuid, ExtraFeatureGuid)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      Assert.Equal(2, blueprint.IsPrerequisiteFor.Count);
      Assert.Contains(
          TestFeature.ToReference<BlueprintFeatureReference>(), blueprint.IsPrerequisiteFor);
      Assert.Contains(
          ExtraFeature.ToReference<BlueprintFeatureReference>(), blueprint.IsPrerequisiteFor);
    }

    [Fact]
    public void AddIsPrerequisiteFor_WithExisting()
    {
      // First pass
      GetConfigurator(Guid)
          .AddIsPrerequisiteFor(FeatureGuid)
          .Configure();

      GetConfigurator(Guid)
          .AddIsPrerequisiteFor(ExtraFeatureGuid)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      Assert.Equal(2, blueprint.IsPrerequisiteFor.Count);
      Assert.Contains(
          TestFeature.ToReference<BlueprintFeatureReference>(), blueprint.IsPrerequisiteFor);
      Assert.Contains(
          ExtraFeature.ToReference<BlueprintFeatureReference>(), blueprint.IsPrerequisiteFor);
    }

    [Fact]
    public void RemoveIsPrerequisiteFor()
    {
      // First pass
      GetConfigurator(Guid)
          .AddIsPrerequisiteFor(FeatureGuid, ExtraFeatureGuid)
          .Configure();

      GetConfigurator(Guid)
          .RemoveIsPrerequisiteFor(ExtraFeatureGuid)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      Assert.Single(blueprint.IsPrerequisiteFor);
      Assert.Contains(
          TestFeature.ToReference<BlueprintFeatureReference>(), blueprint.IsPrerequisiteFor);
    }

    [Fact]
    public void SetRanks()
    {
      GetConfigurator(Guid)
          .SetRanks(3)
          .Configure();

      var feature = BlueprintTool.Get<T>(Guid);
      Assert.Equal(3, feature.Ranks);
    }

    [Fact]
    public void SetReapplyOnLevelUp()
    {
      GetConfigurator(Guid)
          .SetReapplyOnLevelUp()
          .Configure();

      var feature = BlueprintTool.Get<T>(Guid);
      Assert.True(feature.ReapplyOnLevelUp);
    }

    [Fact]
    public void SetReapplyOnLevelUp_False()
    {
      GetConfigurator(Guid)
          .SetReapplyOnLevelUp(false)
          .Configure();

      var feature = BlueprintTool.Get<T>(Guid);
      Assert.False(feature.ReapplyOnLevelUp);
    }

    [Fact]
    public void AddFeatureTags()
    {
      GetConfigurator(Guid)
          .AddFeatureTags(FeatureTag.Mounted, FeatureTag.Defense)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var tags = blueprint.GetComponent<FeatureTagsComponent>();
      Assert.NotNull(tags);

      Assert.True(tags.FeatureTags.HasFlag(FeatureTag.Mounted));
      Assert.True(tags.FeatureTags.HasFlag(FeatureTag.Defense));
    }

    [Fact]
    public void AddFeatureTags_WithExisting()
    {
      // First pass
      GetConfigurator(Guid)
          .AddFeatureTags(FeatureTag.Mounted, FeatureTag.Defense)
          .Configure();

      GetConfigurator(Guid)
          .AddFeatureTags(FeatureTag.Teamwork)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var tags = blueprint.GetComponent<FeatureTagsComponent>();
      Assert.NotNull(tags);

      Assert.True(tags.FeatureTags.HasFlag(FeatureTag.Mounted));
      Assert.True(tags.FeatureTags.HasFlag(FeatureTag.Defense));
      Assert.True(tags.FeatureTags.HasFlag(FeatureTag.Teamwork));
    }

    [Fact]
    public void RemoveFeatureTags()
    {
      // First pass
      GetConfigurator(Guid)
          .AddFeatureTags(FeatureTag.Mounted, FeatureTag.Defense)
          .Configure();

      GetConfigurator(Guid)
          .RemoveFeatureTags(FeatureTag.Defense)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var tags = blueprint.GetComponent<FeatureTagsComponent>();
      Assert.NotNull(tags);

      Assert.True(tags.FeatureTags.HasFlag(FeatureTag.Mounted));
      Assert.False(tags.FeatureTags.HasFlag(FeatureTag.Defense));
    }

    //----- Start: AddPrerequisiteAlignment

    [Fact]
    public void AddPrerequisiteAlignment()
    {
      GetConfigurator(Guid)
          .AddPrerequisiteAlignment(AlignmentMaskType.LawfulGood, AlignmentMaskType.LawfulNeutral)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteAlignment>();
      Assert.NotNull(prereq);

      Assert.True(prereq.Alignment.HasFlag(AlignmentMaskType.LawfulGood));
      Assert.True(prereq.Alignment.HasFlag(AlignmentMaskType.LawfulNeutral));
    }

    [Fact]
    public void AddPrerequisiteAlignment_WithExisting()
    {
      // First pass
      GetConfigurator(Guid)
          .AddPrerequisiteAlignment(AlignmentMaskType.LawfulGood, AlignmentMaskType.LawfulNeutral)
          .Configure();

      GetConfigurator(Guid)
          .AddPrerequisiteAlignment(AlignmentMaskType.ChaoticGood)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteAlignment>();
      Assert.NotNull(prereq);

      Assert.True(prereq.Alignment.HasFlag(AlignmentMaskType.LawfulGood));
      Assert.True(prereq.Alignment.HasFlag(AlignmentMaskType.LawfulNeutral));
      Assert.True(prereq.Alignment.HasFlag(AlignmentMaskType.ChaoticGood));
    }

    //----- Start: RemovePrerequisiteAlignment

    [Fact]
    public void RemovePrerequisiteAlignment()
    {
      // First pass
      GetConfigurator(Guid)
          .AddPrerequisiteAlignment(AlignmentMaskType.LawfulGood, AlignmentMaskType.LawfulNeutral)
          .Configure();

      GetConfigurator(Guid)
          .RemovePrerequisiteAlignment(AlignmentMaskType.LawfulGood)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteAlignment>();
      Assert.NotNull(prereq);

      Assert.False(prereq.Alignment.HasFlag(AlignmentMaskType.LawfulGood));
      Assert.True(prereq.Alignment.HasFlag(AlignmentMaskType.LawfulNeutral));
    }

    //----- Start: PrerequisiteArchetype

    [Fact]
    public void PrerequisiteArchetype()
    {
      GetConfigurator(Guid)
          .PrerequisiteArchetype(ClassGuid, ArchetypeGuid)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteArchetypeLevel>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(Clazz.ToReference<BlueprintCharacterClassReference>(), prereq.m_CharacterClass);
      Assert.Equal(Archetype.ToReference<BlueprintArchetypeReference>(), prereq.m_Archetype);
      Assert.Equal(1, prereq.Level);
    }

    [Fact]
    public void PrerequisiteArchetype_WithCommonPrereqValues()
    {
      GetConfigurator(Guid)
          .PrerequisiteArchetype(
              ClassGuid,
              ArchetypeGuid,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteArchetypeLevel>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(Clazz.ToReference<BlueprintCharacterClassReference>(), prereq.m_CharacterClass);
      Assert.Equal(Archetype.ToReference<BlueprintArchetypeReference>(), prereq.m_Archetype);
      Assert.Equal(1, prereq.Level);
    }

    [Fact]
    public void PrerequisiteArchetype_WithLevel()
    {
      GetConfigurator(Guid)
          .PrerequisiteArchetype(ClassGuid, ArchetypeGuid, 5)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteArchetypeLevel>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(Clazz.ToReference<BlueprintCharacterClassReference>(), prereq.m_CharacterClass);
      Assert.Equal(Archetype.ToReference<BlueprintArchetypeReference>(), prereq.m_Archetype);
      Assert.Equal(5, prereq.Level);
    }

    //----- Start: PrerequisiteCasterType

    [Fact]
    public void PrerequisiteCasterType()
    {
      GetConfigurator(Guid)
          .PrerequisiteCasterType(/* isArcane= */ true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteCasterType>();
      PrereqAsserts.Check(prereq);

      Assert.True(prereq.IsArcane);
    }

    [Fact]
    public void PrerequisiteCasterType_WithCommonPrereqValues()
    {
      GetConfigurator(Guid)
          .PrerequisiteCasterType(
              /* isArcane= */ true,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteCasterType>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.True(prereq.IsArcane);
    }

    [Fact]
    public void PrerequisiteCasterType_WithExisting()
    {
      // First pass
      GetConfigurator(Guid)
          .PrerequisiteCasterType(/* isArcane= */ true)
          .Configure();

      GetConfigurator(Guid)
          .PrerequisiteCasterType(/* isArcane= */ false)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteCasterType>();
      PrereqAsserts.Check(prereq);

      Assert.False(prereq.IsArcane);
    }

    //----- Start: PrerequisiteCasterTypeSpellLevel

    [Fact]
    public void PrerequisiteCasterTypeSpellLevel()
    {
      GetConfigurator(Guid)
          .PrerequisiteCasterTypeSpellLevel(
              /* isArcane= */ true, /* onlySpontaneous= */ true, 3)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteCasterTypeSpellLevel>();
      PrereqAsserts.Check(prereq);

      Assert.True(prereq.IsArcane);
      Assert.True(prereq.OnlySpontaneous);
      Assert.Equal(3, prereq.RequiredSpellLevel);
    }

    [Fact]
    public void PrerequisiteCasterTypeSpellLevel_WithCommonPrereqValues()
    {
      GetConfigurator(Guid)
          .PrerequisiteCasterTypeSpellLevel(
              /* isArcane= */ true,
              /* onlySpontaneous= */ true,
              /* minLevel= */ 3,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteCasterTypeSpellLevel>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.True(prereq.IsArcane);
      Assert.True(prereq.OnlySpontaneous);
      Assert.Equal(3, prereq.RequiredSpellLevel);
    }

    //----- Start: PrerequisiteCharacterLevel

    [Fact]
    public void PrerequisiteCharacterLevel()
    {
      GetConfigurator(Guid)
          .PrerequisiteCharacterLevel(6)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteCharacterLevel>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(6, prereq.Level);
    }

    [Fact]
    public void PrerequisiteCharacterLevel_WithCommonPrereqValues()
    {
      GetConfigurator(Guid)
          .PrerequisiteCharacterLevel(
              6,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteCharacterLevel>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(6, prereq.Level);
    }

    [Fact]
    public void PrerequisiteCharacterLevel_WithExisting()
    {
      // First pass
      GetConfigurator(Guid)
          .PrerequisiteCharacterLevel(6)
          .Configure();

      GetConfigurator(Guid)
          .PrerequisiteCharacterLevel(3)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteCharacterLevel>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(3, prereq.Level);
    }

    //----- Start: PrerequisiteClassLevel

    [Fact]
    public void PrerequisiteClassLevel()
    {
      GetConfigurator(Guid)
          .PrerequisiteClassLevel(ClassGuid, 2)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteClassLevel>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(Clazz.ToReference<BlueprintCharacterClassReference>(), prereq.m_CharacterClass);
      Assert.Equal(2, prereq.Level);
      Assert.False(prereq.Not);
    }

    [Fact]
    public void PrerequisiteClassLevel_ReplaceExisting()
    {
      // First pass
      GetConfigurator(Guid)
          .PrerequisiteClassLevel(ClassGuid, 2)
          .Configure();

      GetConfigurator(Guid)
          .PrerequisiteClassLevel(ExtraClassGuid, 3)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteClassLevel>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(
          ExtraClass.ToReference<BlueprintCharacterClassReference>(), prereq.m_CharacterClass);
      Assert.Equal(3, prereq.Level);
      Assert.False(prereq.Not);
    }

    [Fact]
    public void PrerequisiteClassLevel_WithCommonPrereqValues()
    {
      GetConfigurator(Guid)
          .PrerequisiteClassLevel(
              ClassGuid,
              2,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteClassLevel>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(Clazz.ToReference<BlueprintCharacterClassReference>(), prereq.m_CharacterClass);
      Assert.Equal(2, prereq.Level);
      Assert.False(prereq.Not);
    }

    [Fact]
    public void PrerequisiteClassLevel_Negated()
    {
      GetConfigurator(Guid)
          .PrerequisiteClassLevel(ClassGuid, 2, /* negate= */ true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteClassLevel>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(Clazz.ToReference<BlueprintCharacterClassReference>(), prereq.m_CharacterClass);
      Assert.Equal(2, prereq.Level);
      Assert.True(prereq.Not);
    }

    [Fact]
    public void PrerequisiteClassSpellLevel()
    {
      GetConfigurator(Guid)
          .PrerequisiteClassSpellLevel(ClassGuid, 3)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteClassSpellLevel>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(Clazz.ToReference<BlueprintCharacterClassReference>(), prereq.m_CharacterClass);
      Assert.Equal(3, prereq.RequiredSpellLevel);
    }

    [Fact]
    public void PrerequisiteClassSpellLevel_ReplaceExisting()
    {
      // First pass
      GetConfigurator(Guid)
          .PrerequisiteClassSpellLevel(ExtraClassGuid, 5)
          .Configure();

      GetConfigurator(Guid)
          .PrerequisiteClassSpellLevel(ClassGuid, 1)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteClassSpellLevel>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(Clazz.ToReference<BlueprintCharacterClassReference>(), prereq.m_CharacterClass);
      Assert.Equal(1, prereq.RequiredSpellLevel);
    }

    [Fact]
    public void PrerequisiteClassSpellLevel_WithCommonPrereqValues()
    {
      GetConfigurator(Guid)
          .PrerequisiteClassSpellLevel(
              ClassGuid,
              3,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteClassSpellLevel>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(Clazz.ToReference<BlueprintCharacterClassReference>(), prereq.m_CharacterClass);
      Assert.Equal(3, prereq.RequiredSpellLevel);
    }

    //----- Start: PrerequisiteEtude

    [Fact]
    public void PrerequisiteEtude()
    {
      GetConfigurator(Guid)
          .PrerequisiteEtude(EtudeGuid)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteEtude>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(TestEtude.ToReference<BlueprintEtudeReference>(), prereq.Etude);
      Assert.False(prereq.NotPlaying);
    }

    [Fact]
    public void PrerequisiteEtude_WithCommonPrereqValues()
    {
      GetConfigurator(Guid)
          .PrerequisiteEtude(
              EtudeGuid,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteEtude>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(TestEtude.ToReference<BlueprintEtudeReference>(), prereq.Etude);
      Assert.False(prereq.NotPlaying);
    }

    [Fact]
    public void PrerequisiteEtude_NotPlaying()
    {
      GetConfigurator(Guid)
          .PrerequisiteEtude(EtudeGuid, /* playing= */ false)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteEtude>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(TestEtude.ToReference<BlueprintEtudeReference>(), prereq.Etude);
      Assert.True(prereq.NotPlaying);
    }

    //----- Start: PrerequisiteFeature

    [Fact]
    public void PrerequisiteFeature()
    {
      GetConfigurator(Guid)
          .PrerequisiteFeature(FeatureGuid)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteFeature>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);
    }

    [Fact]
    public void PrerequisiteFeature_WithCommonPrereqValues()
    {
      GetConfigurator(Guid)
          .PrerequisiteFeature(
              FeatureGuid,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteFeature>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);
    }

    //----- Start: PrerequisiteFeaturesFromList

    [Fact]
    public void PrerequisiteFeaturesFromList()
    {
      GetConfigurator(Guid)
          .PrerequisiteFeaturesFromList(new string[] { FeatureGuid, ExtraFeatureGuid })
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteFeaturesFromList>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(2, prereq.m_Features.Length);
      Assert.Contains(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Features);
      Assert.Contains(ExtraFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Features);
      Assert.Equal(1, prereq.Amount);
    }

    [Fact]
    public void PrerequisiteFeaturesFromList_WithCommonPrereqValues()
    {
      GetConfigurator(Guid)
          .PrerequisiteFeaturesFromList(
              new string[] { FeatureGuid, ExtraFeatureGuid },
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteFeaturesFromList>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(2, prereq.m_Features.Length);
      Assert.Contains(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Features);
      Assert.Contains(ExtraFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Features);
      Assert.Equal(1, prereq.Amount);
    }

    [Fact]
    public void PrerequisiteFeaturesFromList_WithRequiredNumber()
    {
      GetConfigurator(Guid)
          .PrerequisiteFeaturesFromList(new string[] { FeatureGuid, ExtraFeatureGuid }, 2)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteFeaturesFromList>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(2, prereq.m_Features.Length);
      Assert.Contains(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Features);
      Assert.Contains(ExtraFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Features);
      Assert.Equal(2, prereq.Amount);
    }

    //----- Start: PrerequisiteIsPet

    [Fact]
    public void PrerequisiteIsPet()
    {
      GetConfigurator(Guid)
          .PrerequisiteIsPet()
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteIsPet>();
      PrereqAsserts.Check(prereq);

      Assert.False(prereq.Not);
    }

    [Fact]
    public void PrerequisiteIsPet_WithCommonPrereqValues()
    {
      GetConfigurator(Guid)
          .PrerequisiteIsPet(
              group: Prerequisite.GroupType.Any, checkInProgression: true, hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteIsPet>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.False(prereq.Not);
    }

    [Fact]
    public void PrerequisiteIsPet_Negated()
    {
      GetConfigurator(Guid)
          .PrerequisiteIsPet(/* negate= */ true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteIsPet>();
      PrereqAsserts.Check(prereq);

      Assert.True(prereq.Not);
    }

    //----- Start: PrerequisiteMainCharacter

    [Fact]
    public void PrerequisiteMainCharacter()
    {
      GetConfigurator(Guid)
          .PrerequisiteMainCharacter()
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteMainCharacter>();
      PrereqAsserts.Check(prereq);

      Assert.False(prereq.Companion);
    }

    [Fact]
    public void PrerequisiteMainCharacter_ReplaceExisting()
    {
      // First pass
      GetConfigurator(Guid)
          .PrerequisiteCompanion()
          .Configure();

      GetConfigurator(Guid)
          .PrerequisiteMainCharacter()
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteMainCharacter>();
      PrereqAsserts.Check(prereq);

      Assert.False(prereq.Companion);
    }

    [Fact]
    public void PrerequisiteMainCharacter_WithCommonPrereqValues()
    {
      GetConfigurator(Guid)
          .PrerequisiteMainCharacter(
              group: Prerequisite.GroupType.Any, checkInProgression: true, hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteMainCharacter>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.False(prereq.Companion);
    }

    //----- Start: PrerequisiteCompanion

    [Fact]
    public void PrerequisiteCompanion()
    {
      GetConfigurator(Guid)
          .PrerequisiteCompanion()
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteMainCharacter>();
      PrereqAsserts.Check(prereq);

      Assert.True(prereq.Companion);
    }

    [Fact]
    public void PrerequisiteCompanion_ReplaceExisting()
    {
      // First pass
      GetConfigurator(Guid)
          .PrerequisiteMainCharacter()
          .Configure();

      GetConfigurator(Guid)
          .PrerequisiteCompanion()
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteMainCharacter>();
      PrereqAsserts.Check(prereq);

      Assert.True(prereq.Companion);
    }

    [Fact]
    public void PrerequisiteCompanion_WithCommonPrereqValues()
    {
      GetConfigurator(Guid)
          .PrerequisiteCompanion(
              group: Prerequisite.GroupType.Any, checkInProgression: true, hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteMainCharacter>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.True(prereq.Companion);
    }

    //----- Start: PrerequisiteMythicLevel

    [Fact]
    public void PrerequisiteMythicLevel()
    {
      GetConfigurator(Guid)
          .PrerequisiteMythicLevel(2)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteMythicLevel>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(2, prereq.Level);
    }

    [Fact]
    public void PrerequisiteMythicLevel_ReplaceExisting()
    {
      // First pass
      GetConfigurator(Guid)
          .PrerequisiteMythicLevel(2)
          .Configure();

      GetConfigurator(Guid)
          .PrerequisiteMythicLevel(6)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteMythicLevel>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(6, prereq.Level);
    }

    [Fact]
    public void PrerequisiteMythicLevel_WithCommonPrereqValues()
    {
      GetConfigurator(Guid)
          .PrerequisiteMythicLevel(
              2,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteMythicLevel>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(2, prereq.Level);
    }

    //----- Start: RemoveSpellDescriptors

    [Fact]
    public void PrerequisiteNoArchetype()
    {
      GetConfigurator(Guid)
          .PrerequisiteNoArchetype(ClassGuid, ArchetypeGuid)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteNoArchetype>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(Clazz.ToReference<BlueprintCharacterClassReference>(), prereq.m_CharacterClass);
      Assert.Equal(Archetype.ToReference<BlueprintArchetypeReference>(), prereq.m_Archetype);
    }

    [Fact]
    public void PrerequisiteNoArchetype_WithCommonPrereqValues()
    {
      GetConfigurator(Guid)
          .PrerequisiteNoArchetype(
              ClassGuid,
              ArchetypeGuid,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteNoArchetype>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(Clazz.ToReference<BlueprintCharacterClassReference>(), prereq.m_CharacterClass);
      Assert.Equal(Archetype.ToReference<BlueprintArchetypeReference>(), prereq.m_Archetype);
    }

    //----- Start: PrerequisiteNoClass

    [Fact]
    public void PrerequisiteNoClass()
    {
      GetConfigurator(Guid)
          .PrerequisiteNoClass(ClassGuid)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteNoClassLevel>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(Clazz.ToReference<BlueprintCharacterClassReference>(), prereq.m_CharacterClass);
    }

    [Fact]
    public void PrerequisiteNoClass_WithCommonPrereqValues()
    {
      GetConfigurator(Guid)
          .PrerequisiteNoClass(
              ClassGuid,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteNoClassLevel>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(Clazz.ToReference<BlueprintCharacterClassReference>(), prereq.m_CharacterClass);
    }

    //----- Start: PrerequisiteNoFeature

    [Fact]
    public void PrerequisiteNoFeature()
    {
      GetConfigurator(Guid)
          .PrerequisiteNoFeature(FeatureGuid)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteNoFeature>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);
    }

    [Fact]
    public void PrerequisiteNoFeature_WithCommonPrereqValues()
    {
      GetConfigurator(Guid)
          .PrerequisiteNoFeature(
              FeatureGuid,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteNoFeature>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);
    }

    //----- Start: PrerequisiteNotProficient

    [Fact]
    public void PrerequisiteNotProficient()
    {
      GetConfigurator(Guid)
          .PrerequisiteNotProficient(
              new WeaponCategory[] { WeaponCategory.Longspear, WeaponCategory.Trident },
              new ArmorProficiencyGroup[]
              {
                ArmorProficiencyGroup.Light, ArmorProficiencyGroup.Medium
              })
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteNotProficient>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(2, prereq.WeaponProficiencies.Length);
      Assert.Contains(WeaponCategory.Longspear, prereq.WeaponProficiencies);
      Assert.Contains(WeaponCategory.Trident, prereq.WeaponProficiencies);

      Assert.Equal(2, prereq.ArmorProficiencies.Length);
      Assert.Contains(ArmorProficiencyGroup.Light, prereq.ArmorProficiencies);
      Assert.Contains(ArmorProficiencyGroup.Medium, prereq.ArmorProficiencies);
    }

    [Fact]
    public void PrerequisiteNotProficient_ReplaceExisting()
    {
      // First pass
      GetConfigurator(Guid)
          .PrerequisiteNotProficient(
              new WeaponCategory[] { WeaponCategory.Longspear, WeaponCategory.Trident },
              new ArmorProficiencyGroup[]
              {
                ArmorProficiencyGroup.Light, ArmorProficiencyGroup.Medium
              })
          .Configure();

      GetConfigurator(Guid)
          .PrerequisiteNotProficient(
              new WeaponCategory[] { WeaponCategory.Sling, WeaponCategory.Starknife },
              new ArmorProficiencyGroup[] { ArmorProficiencyGroup.Heavy })
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteNotProficient>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(2, prereq.WeaponProficiencies.Length);
      Assert.Contains(WeaponCategory.Sling, prereq.WeaponProficiencies);
      Assert.Contains(WeaponCategory.Starknife, prereq.WeaponProficiencies);

      Assert.Single(prereq.ArmorProficiencies);
      Assert.Contains(ArmorProficiencyGroup.Heavy, prereq.ArmorProficiencies);
    }

    [Fact]
    public void PrerequisiteNotProficient_WithCommonPrereqValues()
    {
      GetConfigurator(Guid)
          .PrerequisiteNotProficient(
              new WeaponCategory[] { WeaponCategory.Longspear, WeaponCategory.Trident },
              new ArmorProficiencyGroup[]
              {
                ArmorProficiencyGroup.Light, ArmorProficiencyGroup.Medium
              },
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteNotProficient>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(2, prereq.WeaponProficiencies.Length);
      Assert.Contains(WeaponCategory.Longspear, prereq.WeaponProficiencies);
      Assert.Contains(WeaponCategory.Trident, prereq.WeaponProficiencies);

      Assert.Equal(2, prereq.ArmorProficiencies.Length);
      Assert.Contains(ArmorProficiencyGroup.Light, prereq.ArmorProficiencies);
      Assert.Contains(ArmorProficiencyGroup.Medium, prereq.ArmorProficiencies);
    }

    //----- Start: PrerequisiteParameterizedSpellFeature

    [Fact]
    public void PrerequisiteParameterizedSpellFeature()
    {
      GetConfigurator(Guid)
          .PrerequisiteParameterizedSpellFeature(FeatureGuid, AbilityGuid)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteParametrizedFeature>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);

      Assert.Equal(FeatureParameterType.LearnSpell, prereq.ParameterType);
      Assert.Equal(TestAbility.ToReference<BlueprintAbilityReference>(), prereq.m_Spell);
    }

    [Fact]
    public void PrerequisiteParameterizedSpellFeature_WithCommonPrereqValues()
    {
      GetConfigurator(Guid)
          .PrerequisiteParameterizedSpellFeature(
              FeatureGuid,
              AbilityGuid,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteParametrizedFeature>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);

      Assert.Equal(FeatureParameterType.LearnSpell, prereq.ParameterType);
      Assert.Equal(TestAbility.ToReference<BlueprintAbilityReference>(), prereq.m_Spell);
    }

    //----- Start: PrerequisiteParameterizedWeaponFeature

    [Fact]
    public void PrerequisiteParameterizedWeaponFeature()
    {
      GetConfigurator(Guid)
          .PrerequisiteParameterizedWeaponFeature(FeatureGuid, WeaponCategory.Sling)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteParametrizedFeature>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);

      Assert.Equal(FeatureParameterType.WeaponCategory, prereq.ParameterType);
      Assert.Equal(WeaponCategory.Sling, prereq.WeaponCategory);
    }

    [Fact]
    public void PrerequisiteParameterizedWeaponFeature_WithCommonPrereqValues()
    {
      GetConfigurator(Guid)
          .PrerequisiteParameterizedWeaponFeature(
              FeatureGuid,
              WeaponCategory.Flail,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteParametrizedFeature>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);

      Assert.Equal(FeatureParameterType.WeaponCategory, prereq.ParameterType);
      Assert.Equal(WeaponCategory.Flail, prereq.WeaponCategory);
    }

    //----- Start: PrerequisiteParameterizedSpellSchoolFeature

    [Fact]
    public void PrerequisiteParameterizedSpellSchoolFeature()
    {
      GetConfigurator(Guid)
          .PrerequisiteParameterizedSpellSchoolFeature(FeatureGuid, SpellSchool.Illusion)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteParametrizedFeature>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);

      Assert.Equal(FeatureParameterType.SpellSchool, prereq.ParameterType);
      Assert.Equal(SpellSchool.Illusion, prereq.SpellSchool);
    }

    [Fact]
    public void PrerequisiteParameterizedSpellSchoolFeature_WithCommonPrereqValues()
    {
      GetConfigurator(Guid)
          .PrerequisiteParameterizedSpellSchoolFeature(
              FeatureGuid,
              SpellSchool.Abjuration,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteParametrizedFeature>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);

      Assert.Equal(FeatureParameterType.SpellSchool, prereq.ParameterType);
      Assert.Equal(SpellSchool.Abjuration, prereq.SpellSchool);
    }

    //----- Start: PrerequisiteParameterizedWeaponSubcategory

    [Fact]
    public void PrerequisiteParameterizedWeaponSubcategory()
    {
      GetConfigurator(Guid)
          .PrerequisiteParameterizedWeaponSubcategory(FeatureGuid, WeaponSubCategory.Thrown)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteParametrizedWeaponSubcategory>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);

      Assert.Equal(WeaponSubCategory.Thrown, prereq.SubCategory);
    }

    [Fact]
    public void PrerequisiteParameterizedWeaponSubcategory_WithCommonPrereqValues()
    {
      GetConfigurator(Guid)
          .PrerequisiteParameterizedWeaponSubcategory(
              FeatureGuid,
              WeaponSubCategory.Natural,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteParametrizedWeaponSubcategory>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);

      Assert.Equal(WeaponSubCategory.Natural, prereq.SubCategory);
    }

    //----- Start: PrerequisitePet

    [Fact]
    public void PrerequisitePet()
    {
      GetConfigurator(Guid)
          .PrerequisitePet(PetType.AzataHavocDragon)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisitePet>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(PetType.AzataHavocDragon, prereq.Type);
      Assert.False(prereq.NoCompanion);
    }

    [Fact]
    public void PrerequisitePet_Negated()
    {
      GetConfigurator(Guid)
          .PrerequisitePet(PetType.AzataHavocDragon, negate: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisitePet>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(PetType.AzataHavocDragon, prereq.Type);
      Assert.True(prereq.NoCompanion);
    }

    [Fact]
    public void PrerequisitePet_WithCommonPrereqValues()
    {
      GetConfigurator(Guid)
          .PrerequisitePet(
              PetType.AnimalCompanion,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisitePet>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(PetType.AnimalCompanion, prereq.Type);
      Assert.False(prereq.NoCompanion);
    }

    //----- Start: PrerequisitePlayerHasFeature

    [Fact]
    public void PrerequisitePlayerHasFeature()
    {
      GetConfigurator(Guid)
          .PrerequisitePlayerHasFeature(FeatureGuid)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisitePlayerHasFeature>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);
    }

    [Fact]
    public void PrerequisitePlayerHasFeature_WithCommonPrereqValues()
    {
      GetConfigurator(Guid)
          .PrerequisitePlayerHasFeature(
              FeatureGuid,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisitePlayerHasFeature>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(TestFeature.ToReference<BlueprintFeatureReference>(), prereq.m_Feature);
    }

    //----- Start: PrerequisiteProficient

    [Fact]
    public void PrerequisiteProficient()
    {
      GetConfigurator(Guid)
          .PrerequisiteProficient(
              new WeaponCategory[] { WeaponCategory.Longspear, WeaponCategory.Trident },
              new ArmorProficiencyGroup[]
              {
                ArmorProficiencyGroup.Light, ArmorProficiencyGroup.Medium
              })
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteProficiency>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(2, prereq.WeaponProficiencies.Length);
      Assert.Contains(WeaponCategory.Longspear, prereq.WeaponProficiencies);
      Assert.Contains(WeaponCategory.Trident, prereq.WeaponProficiencies);

      Assert.Equal(2, prereq.ArmorProficiencies.Length);
      Assert.Contains(ArmorProficiencyGroup.Light, prereq.ArmorProficiencies);
      Assert.Contains(ArmorProficiencyGroup.Medium, prereq.ArmorProficiencies);
    }

    [Fact]
    public void PrerequisiteProficient_ReplaceExisting()
    {
      // First pass
      GetConfigurator(Guid)
          .PrerequisiteProficient(
              new WeaponCategory[] { WeaponCategory.Longspear, WeaponCategory.Trident },
              new ArmorProficiencyGroup[]
              {
                ArmorProficiencyGroup.Light, ArmorProficiencyGroup.Medium
              })
          .Configure();

      GetConfigurator(Guid)
          .PrerequisiteProficient(
              new WeaponCategory[] { WeaponCategory.Sling, WeaponCategory.Starknife },
              new ArmorProficiencyGroup[] { ArmorProficiencyGroup.Heavy })
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteProficiency>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(2, prereq.WeaponProficiencies.Length);
      Assert.Contains(WeaponCategory.Sling, prereq.WeaponProficiencies);
      Assert.Contains(WeaponCategory.Starknife, prereq.WeaponProficiencies);

      Assert.Single(prereq.ArmorProficiencies);
      Assert.Contains(ArmorProficiencyGroup.Heavy, prereq.ArmorProficiencies);
    }

    [Fact]
    public void PrerequisiteProficient_WithCommonPrereqValues()
    {
      GetConfigurator(Guid)
          .PrerequisiteProficient(
              new WeaponCategory[] { WeaponCategory.Longspear, WeaponCategory.Trident },
              new ArmorProficiencyGroup[]
              {
                ArmorProficiencyGroup.Light, ArmorProficiencyGroup.Medium
              },
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteProficiency>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(2, prereq.WeaponProficiencies.Length);
      Assert.Contains(WeaponCategory.Longspear, prereq.WeaponProficiencies);
      Assert.Contains(WeaponCategory.Trident, prereq.WeaponProficiencies);

      Assert.Equal(2, prereq.ArmorProficiencies.Length);
      Assert.Contains(ArmorProficiencyGroup.Light, prereq.ArmorProficiencies);
      Assert.Contains(ArmorProficiencyGroup.Medium, prereq.ArmorProficiencies);
    }

    //----- Start: PrerequisiteStat

    [Fact]
    public void PrerequisiteStat()
    {
      GetConfigurator(Guid)
          .PrerequisiteStat(StatType.SaveWill, 5)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteStatValue>();
      PrereqAsserts.Check(prereq);

      Assert.Equal(StatType.SaveWill, prereq.Stat);
      Assert.Equal(5, prereq.Value);
    }

    [Fact]
    public void PrerequisiteStat_WithCommonPrereqValues()
    {
      GetConfigurator(Guid)
          .PrerequisiteStat(
              StatType.SaveReflex,
              2,
              group: Prerequisite.GroupType.Any,
              checkInProgression: true,
              hideInUI: true)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var prereq = blueprint.GetComponent<PrerequisiteStatValue>();
      PrereqAsserts.Check(prereq, Prerequisite.GroupType.Any, true, true);

      Assert.Equal(StatType.SaveReflex, prereq.Stat);
      Assert.Equal(2, prereq.Value);
    }

    //----- Start: AddSpellDescriptors

    [Fact]
    public void AddSpellDescriptors()
    {
      GetConfigurator(Guid)
          .AddSpellDescriptors(SpellDescriptor.Fire, SpellDescriptor.Evil)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var descriptors = blueprint.GetComponent<SpellDescriptorComponent>();
      Assert.NotNull(descriptors);

      Assert.True(descriptors.Descriptor.HasAnyFlag(SpellDescriptor.Fire));
      Assert.True(descriptors.Descriptor.HasAnyFlag(SpellDescriptor.Evil));
    }

    [Fact]
    public void AddSpellDescriptors_WithExisting()
    {
      // First pass
      GetConfigurator(Guid)
          .AddSpellDescriptors(SpellDescriptor.Fire, SpellDescriptor.Evil)
          .Configure();

      GetConfigurator(Guid)
          .AddSpellDescriptors(SpellDescriptor.Law)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var descriptors = blueprint.GetComponent<SpellDescriptorComponent>();
      Assert.NotNull(descriptors);

      Assert.True(descriptors.Descriptor.HasAnyFlag(SpellDescriptor.Fire));
      Assert.True(descriptors.Descriptor.HasAnyFlag(SpellDescriptor.Evil));
      Assert.True(descriptors.Descriptor.HasAnyFlag(SpellDescriptor.Law));
    }

    //----- Start: RemoveSpellDescriptors

    [Fact]
    public void RemoveSpellDescriptors()
    {
      // First pass
      GetConfigurator(Guid)
          .AddSpellDescriptors(SpellDescriptor.Fire, SpellDescriptor.Evil)
          .Configure();

      GetConfigurator(Guid)
          .RemoveSpellDescriptors(SpellDescriptor.Fire)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      var descriptors = blueprint.GetComponent<SpellDescriptorComponent>();
      Assert.NotNull(descriptors);

      Assert.False(descriptors.Descriptor.HasAnyFlag(SpellDescriptor.Fire));
      Assert.True(descriptors.Descriptor.HasAnyFlag(SpellDescriptor.Evil));
    }
  }

  /// <summary>
  /// Feature specific tests should go in CommonFeatureConfiguratorTest which is shared with
  /// classes inheriting from BlueprintFeature.
  /// </summary>
  public class FeatureConfiguratorTest : BaseFeatureConfiguratorTest<BlueprintFeature, FeatureConfigurator>
  {
    public FeatureConfiguratorTest() : base()
    {
      BlueprintPatch.Create<BlueprintFeature>(Guid);
    }

    protected override FeatureConfigurator GetConfigurator(string guid)
    {
      return FeatureConfigurator.For(guid);
    }
  }
}
