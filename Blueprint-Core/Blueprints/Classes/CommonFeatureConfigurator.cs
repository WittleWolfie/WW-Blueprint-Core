using System;
using System.Collections.Generic;
using System.Linq;
using BlueprintCore.Blueprints.Facts;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;

namespace BlueprintCore.Blueprints.Classes
{
  /**
   * Common class to support FeatureConfigurator and FeatureSelectionConfigurator. This is necessary
   * because BlueprintFeatureSelection is a concrete class that inherits from FeatureConfigurator.
   * Without an abstract common class, there would be no way to implement a
   * FatureSelectionConfigurator since there would be conflict between the method return types.
   *
   * Anything unique to BlueprintFeature should be implemented here. FeatureConfigurator serves only
   * to provide a concrete class.
   */
  public abstract class CommonFeatureConfigurator<T, TBuilder>
      : BlueprintUnitFactConfigurator<T, TBuilder>
      where T : BlueprintFeature
      where TBuilder : BlueprintConfigurator<T, TBuilder>
  {
    private FeatureTag EnableFeatureTags;
    private FeatureTag DisableFeatureTags;

    private readonly List<BlueprintFeatureReference> EnableIsPrerequisiteFor = new();
    private readonly List<BlueprintFeatureReference> DisableIsPrerequisiteFor = new();

    private readonly List<FeatureGroup> EnableGroups = new();
    private readonly List<FeatureGroup> DisableGroups = new();

    protected CommonFeatureConfigurator(string name) : base(name) { }

    /** FeatureTagsComponent */
    public TBuilder AddFeatureTags(params FeatureTag[] tags)
    {
      foreach (FeatureTag tag in tags)
      {
        EnableFeatureTags |= tag;
      }
      return Self;
    }

    /** FeatureTagsComponent */
    public TBuilder RemoveFeatureTags(params FeatureTag[] tags)
    {
      foreach (FeatureTag tag in tags)
      {
        DisableFeatureTags |= tag;
      }
      return Self;
    }

    /**
     * (Field) IsPrerequisiteFor
     *
     * @param features BlueprintFeature
     */
    public TBuilder AddIsPrerequisiteFor(params string[] features)
    {
      EnableIsPrerequisiteFor.AddRange(
          features
              .Select(feature => BlueprintTool.GetRef<BlueprintFeatureReference>(feature))
              .ToArray());
      return Self;
    }

    /**
     * (Field) IsPrerequisiteFor
     *
     * @param features BlueprintFeature
     */
    public TBuilder RemoveIsPrerequisiteFor(params string[] features)
    {
      DisableIsPrerequisiteFor.AddRange(
          features
              .Select(
                  feature => BlueprintTool.GetRef<BlueprintFeatureReference>(feature))
              .ToArray());
      return Self;
    }

    /** (Field) Groups */
    public TBuilder AddFeatureGroups(params FeatureGroup[] groups)
    {
      EnableGroups.AddRange(groups);
      return Self;
    }

    /** (Field) Groups */
    public TBuilder RemoveFeatureGroups(params FeatureGroup[] groups)
    {
      DisableGroups.AddRange(groups);
      return Self;
    }

    protected override void ConfigureInternal()
    {
      base.ConfigureInternal();

      if (EnableFeatureTags > 0 || DisableFeatureTags > 0) { ConfigureFeatureTags(); }

      if (EnableIsPrerequisiteFor.Count > 0 || DisableIsPrerequisiteFor.Count > 0)
      {
        ConfigureIsPrerequisiteFor();
      }
      if (EnableGroups.Count > 0 || DisableGroups.Count > 0) { ConfigureFeatureGroups(); }
    }

    protected override void ValidateInternal()
    {
      base.ValidateInternal();

      if (Blueprint.GetComponents<FeatureTagsComponent>().Count() > 1)
      {
        AddValidationWarning("Multiple FeatureTagsComponents present. Only the first is used.");
      }
    }

    private void ConfigureFeatureTags()
    {
      var component = Blueprint.GetComponent<FeatureTagsComponent>();
      if (component == null)
      {
        // Don't create a component to disable tags
        if (EnableFeatureTags == 0) { return; }

        component = new FeatureTagsComponent();
        AddComponent(component);
      }
      component.FeatureTags |= EnableFeatureTags;
      component.FeatureTags &= ~DisableFeatureTags;
    }

    private void ConfigureIsPrerequisiteFor()
    {
      EnableIsPrerequisiteFor.AddRange(
          Blueprint.IsPrerequisiteFor ?? new List<BlueprintFeatureReference>());
      foreach (BlueprintFeatureReference disableRef in DisableIsPrerequisiteFor)
      {
        EnableIsPrerequisiteFor.Remove(disableRef);
      }
      Blueprint.IsPrerequisiteFor = EnableIsPrerequisiteFor;
    }

    private void ConfigureFeatureGroups()
    {
      EnableGroups.AddRange(Blueprint.Groups ?? Array.Empty<FeatureGroup>());
      foreach (FeatureGroup disableGroup in DisableGroups)
      {
        EnableGroups.Remove(disableGroup);
      }
      Blueprint.Groups = EnableGroups.ToArray();
    }
  }
}