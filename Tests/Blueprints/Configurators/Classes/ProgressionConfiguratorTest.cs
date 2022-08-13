using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Test.Patches;
using BlueprintCore.Test.TestData;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Xunit;
using static BlueprintCore.Test.TestData.Blueprints;

namespace BlueprintCore.Test.Blueprints.Configurators.Classes
{
  public class ProgressionConfiguratorTest : RootConfiguratorTest<BlueprintProgression, ProgressionConfigurator>
  {
    public ProgressionConfiguratorTest() : base()
    {
      BlueprintPatch.Create<BlueprintProgression>(Guids.Progression);
    }

    protected override ProgressionConfigurator GetConfigurator()
    {
      return ProgressionConfigurator.For(Guids.Progression);
    }

    protected override BlueprintProgression GetBlueprint()
    {
      return BlueprintTool.Get<BlueprintProgression>(Guids.Progression);
    }

    [Fact]
    public void SetClasses()
    {
      GetConfigurator()
        .SetClasses(Clazz, ClazzAlt)
        .Configure();

      var progression = GetBlueprint();
      Assert.Equal(expected: 2, progression.m_Classes.Length);
      Assert.Equal(expected: Clazz.Reference, progression.m_Classes[0].m_Class);
      Assert.Equal(expected: ClazzAlt.Reference, progression.m_Classes[1].m_Class);
    }

    [Fact]
    public void SetClasses_WithAdditionalLevel()
    {
      GetConfigurator()
        .SetClasses((Clazz, 1), (ClazzAlt, 2))
        .Configure();

      var progression = GetBlueprint();
      Assert.Equal(expected: 2, progression.m_Classes.Length);
      Assert.Equal(expected: Clazz.Reference, progression.m_Classes[0].m_Class);
      Assert.Equal(expected: 1, progression.m_Classes[0].AdditionalLevel);
      Assert.Equal(expected: ClazzAlt.Reference, progression.m_Classes[1].m_Class);
      Assert.Equal(expected: 2, progression.m_Classes[1].AdditionalLevel);
    }

    [Fact]
    public void AddToClasses()
    {
      GetConfigurator()
        .SetClasses(Clazz)
        .Configure();

      GetConfigurator()
        .AddToClasses(ClazzAlt)
        .Configure();

      var progression = GetBlueprint();
      Assert.Equal(expected: 2, progression.m_Classes.Length);
      Assert.Equal(expected: Clazz.Reference, progression.m_Classes[0].m_Class);
      Assert.Equal(expected: ClazzAlt.Reference, progression.m_Classes[1].m_Class);
    }

    [Fact]
    public void AddToClasses_WithAdditionalLevel()
    {
      GetConfigurator()
        .SetClasses(Clazz)
        .Configure();

      GetConfigurator()
        .AddToClasses((ClazzAlt, 2))
        .Configure();

      var progression = GetBlueprint();
      Assert.Equal(expected: 2, progression.m_Classes.Length);
      Assert.Equal(expected: Clazz.Reference, progression.m_Classes[0].m_Class);
      Assert.Equal(expected: 0, progression.m_Classes[0].AdditionalLevel);
      Assert.Equal(expected: ClazzAlt.Reference, progression.m_Classes[1].m_Class);
      Assert.Equal(expected: 2, progression.m_Classes[1].AdditionalLevel);
    }

    [Fact]
    public void RemoveFromClasses()
    {
      GetConfigurator()
        .SetClasses(Clazz, Clazz, ClazzAlt)
        .Configure();

      GetConfigurator()
        .RemoveFromClasses(Clazz)
        .Configure();

      var progression = GetBlueprint();
      Assert.Single(progression.m_Classes);
      Assert.Equal(expected: ClazzAlt.Reference, progression.m_Classes[0].m_Class);
    }

    [Fact]
    public void SetAlternateProgressionClasses()
    {
      GetConfigurator()
        .SetAlternateProgressionClasses(Clazz, ClazzAlt)
        .Configure();

      var progression = GetBlueprint();
      Assert.Equal(expected: 2, progression.m_AlternateProgressionClasses.Length);
      Assert.Equal(expected: Clazz.Reference, progression.m_AlternateProgressionClasses[0].m_Class);
      Assert.Equal(expected: ClazzAlt.Reference, progression.m_AlternateProgressionClasses[1].m_Class);
    }

    [Fact]
    public void SetAlternateProgressionClasses_WithAdditionalLevel()
    {
      GetConfigurator()
        .SetAlternateProgressionClasses((Clazz, 1), (ClazzAlt, 2))
        .Configure();

      var progression = GetBlueprint();
      Assert.Equal(expected: 2, progression.m_AlternateProgressionClasses.Length);
      Assert.Equal(expected: Clazz.Reference, progression.m_AlternateProgressionClasses[0].m_Class);
      Assert.Equal(expected: 1, progression.m_AlternateProgressionClasses[0].AdditionalLevel);
      Assert.Equal(expected: ClazzAlt.Reference, progression.m_AlternateProgressionClasses[1].m_Class);
      Assert.Equal(expected: 2, progression.m_AlternateProgressionClasses[1].AdditionalLevel);
    }

    [Fact]
    public void AddToAlternateProgressionClasses()
    {
      GetConfigurator()
        .SetAlternateProgressionClasses(Clazz)
        .Configure();

      GetConfigurator()
        .AddToAlternateProgressionClasses(ClazzAlt)
        .Configure();

      var progression = GetBlueprint();
      Assert.Equal(expected: 2, progression.m_AlternateProgressionClasses.Length);
      Assert.Equal(expected: Clazz.Reference, progression.m_AlternateProgressionClasses[0].m_Class);
      Assert.Equal(expected: ClazzAlt.Reference, progression.m_AlternateProgressionClasses[1].m_Class);
    }

    [Fact]
    public void AddToAlternateProgressionClasses_WithAdditionaLevel()
    {
      GetConfigurator()
        .SetAlternateProgressionClasses(Clazz)
        .Configure();

      GetConfigurator()
        .AddToAlternateProgressionClasses((ClazzAlt, 2))
        .Configure();

      var progression = GetBlueprint();
      Assert.Equal(expected: 2, progression.m_AlternateProgressionClasses.Length);
      Assert.Equal(expected: Clazz.Reference, progression.m_AlternateProgressionClasses[0].m_Class);
      Assert.Equal(expected: 0, progression.m_AlternateProgressionClasses[0].AdditionalLevel);
      Assert.Equal(expected: ClazzAlt.Reference, progression.m_AlternateProgressionClasses[1].m_Class);
      Assert.Equal(expected: 2, progression.m_AlternateProgressionClasses[1].AdditionalLevel);
    }

    [Fact]
    public void RemoveFromAlternateProgressionClasses()
    {
      GetConfigurator()
        .SetAlternateProgressionClasses(Clazz, Clazz, ClazzAlt)
        .Configure();

      GetConfigurator()
        .RemoveFromAlternateProgressionClasses(Clazz)
        .Configure();

      var progression = GetBlueprint();
      Assert.Single(progression.m_AlternateProgressionClasses);
      Assert.Equal(expected: ClazzAlt.Reference, progression.m_AlternateProgressionClasses[0].m_Class);
    }

    [Fact]
    public void SetArchetypes()
    {
      GetConfigurator()
        .SetArchetypes(Archetype, ArchetypeAlt)
        .Configure();

      var progression = GetBlueprint();
      Assert.Equal(expected: 2, progression.m_Archetypes.Length);
      Assert.Equal(expected: Archetype.Reference, progression.m_Archetypes[0].m_Archetype);
      Assert.Equal(expected: ArchetypeAlt.Reference, progression.m_Archetypes[1].m_Archetype);
    }

    [Fact]
    public void SetArchetypes_WithAdditionalLevel()
    {
      GetConfigurator()
        .SetArchetypes((Archetype, 1), (ArchetypeAlt, 2))
        .Configure();

      var progression = GetBlueprint();
      Assert.Equal(expected: 2, progression.m_Archetypes.Length);
      Assert.Equal(expected: Archetype.Reference, progression.m_Archetypes[0].m_Archetype);
      Assert.Equal(expected: 1, progression.m_Archetypes[0].AdditionalLevel);
      Assert.Equal(expected: ArchetypeAlt.Reference, progression.m_Archetypes[1].m_Archetype);
      Assert.Equal(expected: 2, progression.m_Archetypes[1].AdditionalLevel);
    }

    [Fact]
    public void AddToArchetypes()
    {
      GetConfigurator()
        .SetArchetypes(Archetype)
        .Configure();

      GetConfigurator()
        .AddToArchetypes(ArchetypeAlt)
        .Configure();

      var progression = GetBlueprint();
      Assert.Equal(expected: 2, progression.m_Archetypes.Length);
      Assert.Equal(expected: Archetype.Reference, progression.m_Archetypes[0].m_Archetype);
      Assert.Equal(expected: ArchetypeAlt.Reference, progression.m_Archetypes[1].m_Archetype);
    }

    [Fact]
    public void AddToArchetypes_WithAdditionaLevel()
    {
      GetConfigurator()
        .SetArchetypes(Archetype)
        .Configure();

      GetConfigurator()
        .AddToArchetypes((ArchetypeAlt, 2))
        .Configure();

      var progression = GetBlueprint();
      Assert.Equal(expected: 2, progression.m_Archetypes.Length);
      Assert.Equal(expected: Archetype.Reference, progression.m_Archetypes[0].m_Archetype);
      Assert.Equal(expected: 0, progression.m_Archetypes[0].AdditionalLevel);
      Assert.Equal(expected: ArchetypeAlt.Reference, progression.m_Archetypes[1].m_Archetype);
      Assert.Equal(expected: 2, progression.m_Archetypes[1].AdditionalLevel);
    }

    [Fact]
    public void RemoveFromArchetypes()
    {
      GetConfigurator()
        .SetArchetypes(Archetype, Archetype, ArchetypeAlt)
        .Configure();

      GetConfigurator()
        .RemoveFromArchetypes(Archetype)
        .Configure();

      var progression = GetBlueprint();
      Assert.Single(progression.m_Archetypes);
      Assert.Equal(expected: ArchetypeAlt.Reference, progression.m_Archetypes[0].m_Archetype);
    }

    [Fact]
    public void SetUIGroups()
    {
      GetConfigurator()
        .SetUIGroups(UIGroupBuilder.New().AddGroup(Guids.Feature, Guids.FeatureAlt))
        .Configure();

      var progression = GetBlueprint();
      Assert.Single(progression.UIGroups);
      Assert.Equal(expected: 2, actual: progression.UIGroups[0].m_Features.Count);
      Assert.Equal(
        expected: Feature.Cast<BlueprintFeatureBaseReference>().Reference,
        actual: progression.UIGroups[0].m_Features[0]);
      Assert.Equal(
        expected: FeatureAlt.Cast<BlueprintFeatureBaseReference>().Reference,
        actual: progression.UIGroups[0].m_Features[1]);
    }

    [Fact]
    public void SetUIGroups_WithUIDeterminators()
    {
      GetConfigurator()
        .SetUIGroups(
          UIGroupBuilder.New()
            .AddGroup(Guids.Feature, Guids.FeatureAlt)
            .SetGroupDeterminators(Guids.FeatureBase, Guids.FeatureBaseAlt))
        .Configure();

      var progression = GetBlueprint();
      Assert.Single(progression.UIGroups);
      Assert.Equal(expected: 2, actual: progression.UIGroups[0].m_Features.Count);
      Assert.Equal(
        expected: Feature.Cast<BlueprintFeatureBaseReference>().Reference,
        actual: progression.UIGroups[0].m_Features[0]);
      Assert.Equal(
        expected: FeatureAlt.Cast<BlueprintFeatureBaseReference>().Reference,
        actual: progression.UIGroups[0].m_Features[1]);

      Assert.Equal(expected: 2, actual: progression.m_UIDeterminatorsGroup.Length);
      Assert.Equal(expected: FeatureBase.Reference, actual: progression.m_UIDeterminatorsGroup[0]);
      Assert.Equal(expected: FeatureBaseAlt.Reference, actual: progression.m_UIDeterminatorsGroup[1]);
    }

    [Fact]
    public void SetUIGroups_WithMultipleGroups()
    {
      GetConfigurator()
        .SetUIGroups(UIGroupBuilder.New().AddGroup(Guids.Feature).AddGroup(Guids.FeatureAlt))
        .Configure();

      var progression = GetBlueprint();
      Assert.Equal(expected: 2, actual: progression.UIGroups.Length);
      Assert.Single(progression.UIGroups[0].m_Features);
      Assert.Equal(
        expected: Feature.Cast<BlueprintFeatureBaseReference>().Reference,
        actual: progression.UIGroups[0].m_Features[0]);
      Assert.Single(progression.UIGroups[1].m_Features);
      Assert.Equal(
        expected: FeatureAlt.Cast<BlueprintFeatureBaseReference>().Reference,
        actual: progression.UIGroups[1].m_Features[0]);
    }

    [Fact]
    public void AddToUIGroups()
    {
      GetConfigurator()
        .SetUIGroups(UIGroupBuilder.New().AddGroup(Guids.Feature))
        .Configure();

      GetConfigurator()
        .AddToUIGroups(Guids.FeatureAlt)
        .Configure();

      var progression = GetBlueprint();
      Assert.Equal(expected: 2, actual: progression.UIGroups.Length);
      Assert.Single(progression.UIGroups[0].m_Features);
      Assert.Equal(
        expected: Feature.Cast<BlueprintFeatureBaseReference>().Reference,
        actual: progression.UIGroups[0].m_Features[0]);
      Assert.Single(progression.UIGroups[1].m_Features);
      Assert.Equal(
        expected: FeatureAlt.Cast<BlueprintFeatureBaseReference>().Reference,
        actual: progression.UIGroups[1].m_Features[0]);
    }

    [Fact]
    public void SetLevelEntries()
    {
      GetConfigurator()
        .SetLevelEntries(new LevelEntry() { Level = 1 }, new LevelEntry() { Level = 2 })
        .Configure();

      var progression = GetBlueprint();
      Assert.Equal(expected: 2, progression.LevelEntries.Length);
      Assert.Equal(expected: 1, progression.LevelEntries[0].Level);
      Assert.Equal(expected: 2, progression.LevelEntries[1].Level);
    }

    [Fact]
    public void SetLevelEntries_UsingBuilder()
    {
      GetConfigurator()
        .SetLevelEntries(LevelEntryBuilder.New().AddEntry(level: 1).AddEntry(level: 2))
        .Configure();

      var progression = GetBlueprint();
      Assert.Equal(expected: 2, progression.LevelEntries.Length);
      Assert.Equal(expected: 1, progression.LevelEntries[0].Level);
      Assert.Equal(expected: 2, progression.LevelEntries[1].Level);
    }

    [Fact]
    public void SetLevelEntry()
    {
      GetConfigurator()
        .SetLevelEntries(LevelEntryBuilder.New().AddEntry(level: 1, FeatureBase).AddEntry(level: 2))
        .Configure();

      GetConfigurator()
        .SetLevelEntry(level: 1, FeatureBaseAlt, FeatureBase)
        .Configure();

      var progression = GetBlueprint();
      Assert.Equal(expected: 2, actual: progression.LevelEntries.Length);

      foreach (var addFeature in progression.LevelEntries)
      {
        if (addFeature.Level == 1)
        {
          Assert.Equal(expected: 2, actual: addFeature.m_Features.Count);
          Assert.Equal(expected: FeatureBaseAlt.Reference, actual: addFeature.m_Features[0]);
          Assert.Equal(expected: FeatureBase.Reference, actual: addFeature.m_Features[1]);
        }
        else
        {
          Assert.Empty(addFeature.m_Features);
        }
      }
    }

    [Fact]
    public void AddToLevelEntries()
    {
      GetConfigurator()
        .SetLevelEntries(LevelEntryBuilder.New().AddEntry(level: 1))
        .Configure();

      GetConfigurator()
        .AddToLevelEntries(level: 2, FeatureBaseAlt, FeatureBase)
        .Configure();

      var progression = GetBlueprint();
      Assert.Equal(expected: 2, actual: progression.LevelEntries.Length);
      Assert.Equal(expected: 1, actual: progression.LevelEntries[0].Level);
      Assert.Equal(expected: 2, actual: progression.LevelEntries[1].Level);

      Assert.Empty(progression.LevelEntries[0].m_Features);

      Assert.Equal(expected: 2, actual: progression.LevelEntries[1].m_Features.Count);
      Assert.Equal(expected: FeatureBaseAlt.Reference, actual: progression.LevelEntries[1].m_Features[0]);
      Assert.Equal(expected: FeatureBase.Reference, actual: progression.LevelEntries[1].m_Features[1]);
    }

    [Fact]
    public void RemoveFromLevelEntries()
    {
      GetConfigurator()
        .SetLevelEntries(
          LevelEntryBuilder.New()
            .AddEntry(level: 1, FeatureBase, FeatureBase, FeatureBaseAlt)
            .AddEntry(level: 2, FeatureBase))
        .Configure();

      GetConfigurator()
        .RemoveFromLevelEntries(level: 1, FeatureBase)
        .Configure();

      var progression = GetBlueprint();
      Assert.Equal(expected: 2, actual: progression.LevelEntries.Length);
      Assert.Equal(expected: 1, actual: progression.LevelEntries[0].Level);
      Assert.Equal(expected: 2, actual: progression.LevelEntries[1].Level);

      Assert.Single(progression.LevelEntries[0].m_Features);
      Assert.Equal(expected: FeatureBaseAlt.Reference, actual: progression.LevelEntries[0].m_Features[0]);

      Assert.Single(progression.LevelEntries[1].m_Features);
      Assert.Equal(expected: FeatureBase.Reference, actual: progression.LevelEntries[1].m_Features[0]);
    }

    [Fact]
    public void RemoveLevelEntry()
    {
      GetConfigurator()
        .SetLevelEntries(
          LevelEntryBuilder.New()
            .AddEntry(level: 1, FeatureBase, FeatureBase, FeatureBaseAlt)
            .AddEntry(level: 2, FeatureBase))
        .Configure();

      GetConfigurator()
        .RemoveLevelEntry(level: 1)
        .Configure();

      var progression = GetBlueprint();
      Assert.Single(progression.LevelEntries);
      Assert.Equal(expected: 2, actual: progression.LevelEntries[0].Level);

      Assert.Single(progression.LevelEntries[0].m_Features);
      Assert.Equal(expected: FeatureBase.Reference, actual: progression.LevelEntries[0].m_Features[0]);
    }
  }
}
