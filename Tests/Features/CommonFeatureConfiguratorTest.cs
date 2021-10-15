using BlueprintCore.Blueprints;
using BlueprintCore.Blueprints.Classes;
using BlueprintCore.Tests.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
using Xunit;

namespace BlueprintCore.Tests.Features
{
  public abstract class CommonFeatureConfiguratorTest<T, TBuilder>
      : BlueprintUnitFactConfiguratorTest<T, TBuilder>
      where T : BlueprintFeature
      where TBuilder : CommonFeatureConfigurator<T, TBuilder>
  {
    protected CommonFeatureConfiguratorTest() : base() { }

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

    [Fact]
    public void AddIsPrerequisiteFor()
    {
      GetConfigurator(Guid)
          .AddIsPrerequisiteFor(FeatureGuid, ExtraFeatureGuid)
          .Configure();

      T blueprint = BlueprintTool.Get<T>(Guid);
      Assert.Equal(2, blueprint.IsPrerequisiteFor.Count);
      Assert.Contains(
          Feature.ToReference<BlueprintFeatureReference>(), blueprint.IsPrerequisiteFor);
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
          Feature.ToReference<BlueprintFeatureReference>(), blueprint.IsPrerequisiteFor);
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
          Feature.ToReference<BlueprintFeatureReference>(), blueprint.IsPrerequisiteFor);
    }

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
  }
}
