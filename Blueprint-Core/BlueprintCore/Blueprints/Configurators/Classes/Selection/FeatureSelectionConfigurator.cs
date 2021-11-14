using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Classes.Selection
{
  /// <summary>Configurator for <see cref="BlueprintFeatureSelection"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintFeatureSelection))]
  public class FeatureSelectionConfigurator
      : BaseFeatureConfigurator<BlueprintFeatureSelection, FeatureSelectionConfigurator>
  {
    private FeatureSelectionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static FeatureSelectionConfigurator For(string name)
    {
      return new FeatureSelectionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static FeatureSelectionConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintFeatureSelection>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static FeatureSelectionConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintFeatureSelection>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintFeatureSelection.IgnorePrerequisites"/>
    /// </summary>
    public FeatureSelectionConfigurator SetIgnorePrerequisites(bool ignore = true)
    {
      return OnConfigureInternal(blueprint => blueprint.IgnorePrerequisites = ignore);
    }

    /// <summary>
    /// Sets <see cref="BlueprintFeatureSelection.Mode"/>
    /// </summary>
    public FeatureSelectionConfigurator SetMode(SelectionMode mode)
    {
      return OnConfigureInternal(blueprint => blueprint.Mode = mode);
    }

    /// <summary>
    /// Sets <see cref="BlueprintFeatureSelection.Group"/>
    /// </summary>
    public FeatureSelectionConfigurator SetPrimaryGroup(FeatureGroup group)
    {
      return OnConfigureInternal(blueprint => blueprint.Group = group);
    }

    /// <summary>
    /// Sets <see cref="BlueprintFeatureSelection.Group2"/>
    /// </summary>
    public FeatureSelectionConfigurator SetSecondaryGroup(FeatureGroup group)
    {
      return OnConfigureInternal(blueprint => blueprint.Group2 = group);
    }

    /// <summary>
    /// Adds to <see cref="BlueprintFeatureSelection.m_AllFeatures"/>
    /// </summary>
    /// 
    /// <param name="features"><see cref="BlueprintFeature"/></param>
    public FeatureSelectionConfigurator AddFeatures(params string[] features)
    {
      return OnConfigureInternal(
          blueprint =>
          {
            blueprint.m_AllFeatures =
                CommonTool.Append(
                    blueprint.m_AllFeatures,
                    features.Select(feature => BlueprintTool.GetRef<BlueprintFeatureReference>(feature)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintFeatureSelection.m_AllFeatures"/>
    /// </summary>
    /// 
    /// <param name="features"><see cref="BlueprintFeature"/></param>
    public FeatureSelectionConfigurator RemoveFeatures(params string[] features)
    {
      return OnConfigureInternal(
          blueprint =>
          {
            var featureRefs = features.Select(feature => BlueprintTool.GetRef<BlueprintFeatureReference>(feature));
            blueprint.m_AllFeatures = blueprint.m_AllFeatures.Except(featureRefs).ToArray();
          });
    }


    /// <summary>
    /// Adds <see cref="NoSelectionIfAlreadyHasFeature"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Features"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(NoSelectionIfAlreadyHasFeature))]
    public FeatureSelectionConfigurator AddNoSelectionIfAlreadyHasFeature(
        bool AnyFeatureFromSelection,
        string[] m_Features)
    {
      
      var component =  new NoSelectionIfAlreadyHasFeature();
      component.AnyFeatureFromSelection = AnyFeatureFromSelection;
      component.m_Features = m_Features.Select(bp => BlueprintTool.GetRef<BlueprintFeatureReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteSelectionPossible"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_ThisFeature"><see cref="BlueprintFeatureSelection"/></param>
    [Generated]
    [Implements(typeof(PrerequisiteSelectionPossible))]
    public FeatureSelectionConfigurator AddPrerequisiteSelectionPossible(
        string m_ThisFeature,
        Prerequisite.GroupType Group,
        bool CheckInProgression,
        bool HideInUI)
    {
      ValidateParam(Group);
      
      var component =  new PrerequisiteSelectionPossible();
      component.m_ThisFeature = BlueprintTool.GetRef<BlueprintFeatureSelectionReference>(m_ThisFeature);
      component.Group = Group;
      component.CheckInProgression = CheckInProgression;
      component.HideInUI = HideInUI;
      return AddComponent(component);
    }
  }
}
