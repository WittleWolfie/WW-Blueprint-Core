using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using BlueprintCore.Test.Blueprints.Configurators.Classes;
using BlueprintCore.Utils;
using Xunit;
using static BlueprintCore.Test.TestData;

namespace BlueprintCore.Test.Blueprints.Classes.Features
{
  public class FeatureSelectionConfiguratorTest
      : BaseFeatureConfiguratorTest<BlueprintFeatureSelection, FeatureSelectionConfigurator>
  {
    public FeatureSelectionConfiguratorTest() : base()
    {
      BlueprintPatch.Create<BlueprintFeatureSelection>(Guid);
    }

    protected override FeatureSelectionConfigurator GetConfigurator(string guid)
    {
      return FeatureSelectionConfigurator.For(guid);
    }

    [Fact]
    public void SetIgnorePrerequisites()
    {
      GetConfigurator(Guid)
          .SetIgnorePrerequisites()
          .Configure();

      var selection = BlueprintTool.Get<BlueprintFeatureSelection>(Guid);
      Assert.True(selection.IgnorePrerequisites);
    }

    [Fact]
    public void SetIgnorePrerequisites_False()
    {
      GetConfigurator(Guid)
          .SetIgnorePrerequisites(false)
          .Configure();

      var selection = BlueprintTool.Get<BlueprintFeatureSelection>(Guid);
      Assert.False(selection.IgnorePrerequisites);
    }

    [Fact]
    public void SetMode()
    {
      GetConfigurator(Guid)
          .SetMode(SelectionMode.OnlyRankUp)
          .Configure();

      var selection = BlueprintTool.Get<BlueprintFeatureSelection>(Guid);
      Assert.Equal(SelectionMode.OnlyRankUp, selection.Mode);
    }

    [Fact]
    public void SetPrimaryGroup()
    {
      GetConfigurator(Guid)
          .SetPrimaryGroup(FeatureGroup.AnimalCompanion)
          .Configure();

      var selection = BlueprintTool.Get<BlueprintFeatureSelection>(Guid);
      Assert.Equal(FeatureGroup.AnimalCompanion, selection.Group);
    }

    [Fact]
    public void SetSecondaryGroup()
    {
      GetConfigurator(Guid)
          .SetSecondaryGroup(FeatureGroup.ArcaneTricksterSpellbook)
          .Configure();

      var selection = BlueprintTool.Get<BlueprintFeatureSelection>(Guid);
      Assert.Equal(FeatureGroup.ArcaneTricksterSpellbook, selection.Group2);
    }

    [Fact]
    public void SetFeatures()
    {
      // First pass
      GetConfigurator(Guid).SetFeatures(FeatureGuid).Configure();

      GetConfigurator(Guid).SetFeatures(ExtraFeatureGuid).Configure();

      var selection = BlueprintTool.Get<BlueprintFeatureSelection>(Guid);

      Assert.Single(selection.m_AllFeatures);
      Assert.Contains(ExtraFeature.ToReference<BlueprintFeatureReference>(), selection.m_AllFeatures);
    }

    [Fact]
    public void AddFeatures()
    {
      GetConfigurator(Guid)
          .AddToFeatures(FeatureGuid, ExtraFeatureGuid)
          .Configure();

      var selection = BlueprintTool.Get<BlueprintFeatureSelection>(Guid);

      Assert.Equal(2, selection.m_AllFeatures.Length);
      Assert.Contains(TestFeature.ToReference<BlueprintFeatureReference>(), selection.m_AllFeatures);
      Assert.Contains(ExtraFeature.ToReference<BlueprintFeatureReference>(), selection.m_AllFeatures);
    }

    [Fact]
    public void AddFeatures_WithExisting()
    {
      // First pass
      GetConfigurator(Guid)
          .SetFeatures(FeatureGuid)
          .Configure();

      GetConfigurator(Guid)
          .AddToFeatures(ExtraFeatureGuid)
          .Configure();

      var selection = BlueprintTool.Get<BlueprintFeatureSelection>(Guid);

      Assert.Equal(2, selection.m_AllFeatures.Length);
      Assert.Contains(TestFeature.ToReference<BlueprintFeatureReference>(), selection.m_AllFeatures);
      Assert.Contains(ExtraFeature.ToReference<BlueprintFeatureReference>(), selection.m_AllFeatures);
    }

    [Fact]
    public void RemoveFeatures()
    {
      // First pass
      GetConfigurator(Guid)
          .SetFeatures(FeatureGuid, ExtraFeatureGuid)
          .Configure();

      GetConfigurator(Guid)
          .RemoveFromFeatures(FeatureGuid)
          .Configure();

      var selection = BlueprintTool.Get<BlueprintFeatureSelection>(Guid);

      Assert.Single(selection.m_AllFeatures);
      Assert.Contains(ExtraFeature.ToReference<BlueprintFeatureReference>(), selection.m_AllFeatures);
    }

    [Fact]
    public void PrerequisiteSelectionPossible()
    {
      GetConfigurator(Guid)
          .PrerequisiteSelectionPossible()
          .Configure();

      var blueprint = BlueprintTool.Get<BlueprintFeatureSelection>(Guid);
      var selectionPossible = blueprint.GetComponent<PrerequisiteSelectionPossible>();
      Assert.NotNull(selectionPossible);

      Assert.Equal(
          blueprint.ToReference<BlueprintFeatureSelectionReference>(),
          selectionPossible.m_ThisFeature);
    }
  }
}
