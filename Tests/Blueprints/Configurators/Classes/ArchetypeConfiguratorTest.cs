using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Test.Patches;
using BlueprintCore.Test.TestData;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using Xunit;
using static BlueprintCore.Test.TestData.Blueprints;

namespace BlueprintCore.Test.Blueprints.Configurators.Classes
{
  public class ArchetypeConfiguratorTest : RootConfiguratorTest<BlueprintArchetype, ArchetypeConfigurator>
  {
    public ArchetypeConfiguratorTest() : base()
    {
      BlueprintPatch.Create<BlueprintArchetype>(Guids.Archetype);
    }

    protected override ArchetypeConfigurator GetConfigurator()
    {
      return ArchetypeConfigurator.For(Guids.Archetype);
    }

    protected override BlueprintArchetype GetBlueprint()
    {
      return BlueprintTool.Get<BlueprintArchetype>(Guids.Archetype);
    }

    [Fact]
    public void SetAddFeatures()
    {
      GetConfigurator()
        .SetAddFeatures(new LevelEntry() { Level = 1 }, new LevelEntry() { Level = 2 })
        .Configure();

      var archetype = GetBlueprint();
      Assert.Equal(expected: 2, archetype.AddFeatures.Length);
      Assert.Equal(expected: 1, archetype.AddFeatures[0].Level);
      Assert.Equal(expected: 2, archetype.AddFeatures[1].Level);
    }

    [Fact]
    public void SetAddFeatures_UsingBuilder()
    {
      GetConfigurator()
        .SetAddFeatures(LevelEntryBuilder.New().AddEntry(level: 1).AddEntry(level: 2))
        .Configure();

      var archetype = GetBlueprint();
      Assert.Equal(expected: 2, archetype.AddFeatures.Length);
      Assert.Equal(expected: 1, archetype.AddFeatures[0].Level);
      Assert.Equal(expected: 2, archetype.AddFeatures[1].Level);
    }

    [Fact]
    public void SetAddFeatureEntry()
    {
      GetConfigurator()
        .SetAddFeatures(LevelEntryBuilder.New().AddEntry(level: 1, FeatureBase).AddEntry(level: 2))
        .Configure();

      GetConfigurator()
        .SetAddFeatureEntry(level: 1, FeatureBaseAlt, FeatureBase)
        .Configure();

      var archetype = GetBlueprint();
      Assert.Equal(expected: 2, actual: archetype.AddFeatures.Length);

      foreach (var addFeature in archetype.AddFeatures)
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
    public void AddToAddFeatures()
    {
      GetConfigurator()
        .SetAddFeatures(LevelEntryBuilder.New().AddEntry(level: 1))
        .Configure();

      GetConfigurator()
        .AddToAddFeatures(level: 2, FeatureBaseAlt, FeatureBase)
        .Configure();

      var archetype = GetBlueprint();
      Assert.Equal(expected: 2, actual: archetype.AddFeatures.Length);
      Assert.Equal(expected: 1, actual: archetype.AddFeatures[0].Level);
      Assert.Equal(expected: 2, actual: archetype.AddFeatures[1].Level);

      Assert.Empty(archetype.AddFeatures[0].m_Features);

      Assert.Equal(expected: 2, actual: archetype.AddFeatures[1].m_Features.Count);
      Assert.Equal(expected: FeatureBaseAlt.Reference, actual: archetype.AddFeatures[1].m_Features[0]);
      Assert.Equal(expected: FeatureBase.Reference, actual: archetype.AddFeatures[1].m_Features[1]);
    }

    [Fact]
    public void RemoveFromAddFeatures()
    {
      GetConfigurator()
        .SetAddFeatures(
          LevelEntryBuilder.New()
            .AddEntry(level: 1, FeatureBase, FeatureBase, FeatureBaseAlt)
            .AddEntry(level: 2, FeatureBase))
        .Configure();

      GetConfigurator()
        .RemoveFromAddFeatures(level: 1, FeatureBase)
        .Configure();

      var archetype = GetBlueprint();
      Assert.Equal(expected: 2, actual: archetype.AddFeatures.Length);
      Assert.Equal(expected: 1, actual: archetype.AddFeatures[0].Level);
      Assert.Equal(expected: 2, actual: archetype.AddFeatures[1].Level);

      Assert.Single(archetype.AddFeatures[0].m_Features);
      Assert.Equal(expected: FeatureBaseAlt.Reference, actual: archetype.AddFeatures[0].m_Features[0]);

      Assert.Single(archetype.AddFeatures[1].m_Features);
      Assert.Equal(expected: FeatureBase.Reference, actual: archetype.AddFeatures[1].m_Features[0]);
    }

    [Fact]
    public void RemoveAddFeaturesEntry()
    {
      GetConfigurator()
        .SetAddFeatures(
          LevelEntryBuilder.New()
            .AddEntry(level: 1, FeatureBase, FeatureBase, FeatureBaseAlt)
            .AddEntry(level: 2, FeatureBase))
        .Configure();

      GetConfigurator()
        .RemoveAddFeaturesEntry(level: 1)
        .Configure();

      var archetype = GetBlueprint();
      Assert.Single(archetype.AddFeatures);
      Assert.Equal(expected: 2, actual: archetype.AddFeatures[0].Level);

      Assert.Single(archetype.AddFeatures[0].m_Features);
      Assert.Equal(expected: FeatureBase.Reference, actual: archetype.AddFeatures[0].m_Features[0]);
    }

    [Fact]
    public void SetRemoveFeatures()
    {
      GetConfigurator()
        .SetRemoveFeatures(new LevelEntry() { Level = 1 }, new LevelEntry() { Level = 2 })
        .Configure();

      var archetype = GetBlueprint();
      Assert.Equal(expected: 2, archetype.RemoveFeatures.Length);
      Assert.Equal(expected: 1, archetype.RemoveFeatures[0].Level);
      Assert.Equal(expected: 2, archetype.RemoveFeatures[1].Level);
    }

    [Fact]
    public void SetRemoveFeatures_UsingBuilder()
    {
      GetConfigurator()
        .SetRemoveFeatures(LevelEntryBuilder.New().AddEntry(level: 1).AddEntry(level: 2))
        .Configure();

      var archetype = GetBlueprint();
      Assert.Equal(expected: 2, archetype.RemoveFeatures.Length);
      Assert.Equal(expected: 1, archetype.RemoveFeatures[0].Level);
      Assert.Equal(expected: 2, archetype.RemoveFeatures[1].Level);
    }

    [Fact]
    public void SetRemoveFeaturesEntry()
    {
      GetConfigurator()
        .SetRemoveFeatures(LevelEntryBuilder.New().AddEntry(level: 1, FeatureBase).AddEntry(level: 2))
        .Configure();

      GetConfigurator()
        .SetRemoveFeaturesEntry(level: 1, FeatureBaseAlt, FeatureBase)
        .Configure();

      var archetype = GetBlueprint();
      Assert.Equal(expected: 2, actual: archetype.RemoveFeatures.Length);

      foreach (var removeFeature in archetype.RemoveFeatures)
      {
        if (removeFeature.Level == 1)
        {
          Assert.Equal(expected: 2, actual: removeFeature.m_Features.Count);
          Assert.Equal(expected: FeatureBaseAlt.Reference, actual: removeFeature.m_Features[0]);
          Assert.Equal(expected: FeatureBase.Reference, actual: removeFeature.m_Features[1]);
        }
        else
        {
          Assert.Empty(removeFeature.m_Features);
        }
      }
    }

    [Fact]
    public void AddToRemoveFeatures()
    {
      GetConfigurator()
        .SetRemoveFeatures(LevelEntryBuilder.New().AddEntry(level: 1))
        .Configure();

      GetConfigurator()
        .AddToRemoveFeatures(level: 2, FeatureBaseAlt, FeatureBase)
        .Configure();

      var archetype = GetBlueprint();
      Assert.Equal(expected: 2, actual: archetype.RemoveFeatures.Length);
      Assert.Equal(expected: 1, actual: archetype.RemoveFeatures[0].Level);
      Assert.Equal(expected: 2, actual: archetype.RemoveFeatures[1].Level);

      Assert.Empty(archetype.RemoveFeatures[0].m_Features);

      Assert.Equal(expected: 2, actual: archetype.RemoveFeatures[1].m_Features.Count);
      Assert.Equal(expected: FeatureBaseAlt.Reference, actual: archetype.RemoveFeatures[1].m_Features[0]);
      Assert.Equal(expected: FeatureBase.Reference, actual: archetype.RemoveFeatures[1].m_Features[1]);
    }

    [Fact]
    public void RemoveFromRemoveFeatures()
    {
      GetConfigurator()
        .SetRemoveFeatures(
          LevelEntryBuilder.New()
            .AddEntry(level: 1, FeatureBase, FeatureBase, FeatureBaseAlt)
            .AddEntry(level: 2, FeatureBase))
        .Configure();

      GetConfigurator()
        .RemoveFromRemoveFeatures(level: 1, FeatureBase)
        .Configure();

      var archetype = GetBlueprint();
      Assert.Equal(expected: 2, actual: archetype.RemoveFeatures.Length);
      Assert.Equal(expected: 1, actual: archetype.RemoveFeatures[0].Level);
      Assert.Equal(expected: 2, actual: archetype.RemoveFeatures[1].Level);

      Assert.Single(archetype.RemoveFeatures[0].m_Features);
      Assert.Equal(expected: FeatureBaseAlt.Reference, actual: archetype.RemoveFeatures[0].m_Features[0]);

      Assert.Single(archetype.RemoveFeatures[1].m_Features);
      Assert.Equal(expected: FeatureBase.Reference, actual: archetype.RemoveFeatures[1].m_Features[0]);
    }

    [Fact]
    public void RemoveRemoveFeaturesEntry()
    {
      GetConfigurator()
        .SetRemoveFeatures(
          LevelEntryBuilder.New()
            .AddEntry(level: 1, FeatureBase, FeatureBase, FeatureBaseAlt)
            .AddEntry(level: 2, FeatureBase))
        .Configure();

      GetConfigurator()
        .RemoveRemoveFeaturesEntry(level: 1)
        .Configure();

      var archetype = GetBlueprint();
      Assert.Single(archetype.RemoveFeatures);
      Assert.Equal(expected: 2, actual: archetype.RemoveFeatures[0].Level);

      Assert.Single(archetype.RemoveFeatures[0].m_Features);
      Assert.Equal(expected: FeatureBase.Reference, actual: archetype.RemoveFeatures[0].m_Features[0]);
    }
  }
}
