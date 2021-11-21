using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using System.Linq;

namespace BlueprintCoreGen.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Implements common fields and component support for blueprints inheriting from <see cref="BlueprintFeature"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintFeature))]
  public abstract class BaseFeatureConfigurator<T, TBuilder> : FeatureBaseConfigurator<T, TBuilder>
      where T : BlueprintFeature
      where TBuilder : BaseFeatureConfigurator<T, TBuilder>
  {
    protected BaseFeatureConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintFeature.Groups"/>
    /// </summary>
    public TBuilder SetFeatureGroups(params FeatureGroup[] groups)
    {
      return OnConfigureInternal(blueprint => blueprint.Groups = groups);
    }

    /// <summary>
    /// Adds to <see cref="BlueprintFeature.Groups"/>
    /// </summary>
    public TBuilder AddToFeatureGroups(params FeatureGroup[] groups)
    {
      return OnConfigureInternal(bp => bp.Groups = CommonTool.Append(bp.Groups, groups));
    }

    /// <summary>
    /// Removes from <see cref="BlueprintFeature.Groups"/>
    /// </summary>
    public TBuilder RemoveFromFeatureGroups(params FeatureGroup[] groups)
    {
      return OnConfigureInternal(blueprint => blueprint.Groups = blueprint.Groups.Except(groups).ToArray()); ;
    }

    /// <summary>
    /// Sets <see cref="BlueprintFeature.IsClassFeature"/>
    /// </summary>
    public TBuilder SetIsClassFeature(bool isClassFeature = true)
    {
      return OnConfigureInternal(blueprint => blueprint.IsClassFeature = isClassFeature);
    }

    /// <summary>
    /// Sets <see cref="BlueprintFeature.IsPrerequisiteFor"/>
    /// </summary>
    /// 
    /// <param name="features"><see cref="BlueprintFeature"/></param>
    public TBuilder SetIsPrerequisiteFor(params string[] features)
    {
      return OnConfigureInternal(
          bp =>
              bp.IsPrerequisiteFor = features.Select(f => BlueprintTool.GetRef<BlueprintFeatureReference>(f)).ToList());
    }

    /// <summary>
    /// Adds to <see cref="BlueprintFeature.IsPrerequisiteFor"/>
    /// </summary>
    /// 
    /// <param name="features"><see cref="BlueprintFeature"/></param>
    public TBuilder AddToIsPrerequisiteFor(params string[] features)
    {
      return OnConfigureInternal(
          bp =>
          {
            if (bp.IsPrerequisiteFor is null) { bp.IsPrerequisiteFor = new(); }
            bp.IsPrerequisiteFor.AddRange(features.Select(f => BlueprintTool.GetRef<BlueprintFeatureReference>(f)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintFeature.IsPrerequisiteFor"/>
    /// </summary>
    /// 
    /// <param name="features"><see cref="BlueprintFeature"/></param>
    public TBuilder RemoveFromIsPrerequisiteFor(params string[] features)
    {
      return OnConfigureInternal(
          bp =>
          {
            if (bp.IsPrerequisiteFor is null) { return; }
            bp.IsPrerequisiteFor =
                bp.IsPrerequisiteFor
                    .Except(features.Select(f => BlueprintTool.GetRef<BlueprintFeatureReference>(f)))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintFeature.Ranks"/>
    /// </summary>
    public TBuilder SetRanks(int ranks)
    {
      return OnConfigureInternal(blueprint => blueprint.Ranks = ranks);
    }

    /// <summary>
    /// Sets <see cref="BlueprintFeature.ReapplyOnLevelUp"/>
    /// </summary>
    public TBuilder SetReapplyOnLevelUp(bool reapply = true)
    {
      return OnConfigureInternal(blueprint => blueprint.ReapplyOnLevelUp = reapply);
    }

    // [GenerateComponents]

    protected override void ValidateInternal()
    {
      base.ValidateInternal();

      if (Blueprint.GetComponents<FeatureTagsComponent>().Count() > 1)
      {
        AddValidationWarning("Multiple FeatureTagsComponents present. Only the first is used.");
      }
    }
  }

  /// <summary>Configurator for <see cref="BlueprintFeature"/>.</summary>
  /// <inheritdoc/>
  public class FeatureConfigurator : BaseFeatureConfigurator<BlueprintFeature, FeatureConfigurator>
  {
    private FeatureConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static FeatureConfigurator For(string name)
    {
      return new FeatureConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static FeatureConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintFeature>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static FeatureConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintFeature>(name, assetId);
      return For(name);
    }
  }
}