using Kingmaker.Blueprints;
using Kingmaker.Localization;
using UnityEngine;

namespace BlueprintCore.Blueprints.Abilities
{
  /// <summary>Configurator for <see cref="BlueprintAbilityResource"/>.</summary>
  /// <inheritdoc/>
  public class AbilityResourceConfigurator
      : BlueprintConfigurator<BlueprintAbilityResource, AbilityResourceConfigurator>
  {
    private AbilityResourceConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AbilityResourceConfigurator For(string name) { return new AbilityResourceConfigurator(name); }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AbilityResourceConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintAbilityResource>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AbilityResourceConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintAbilityResource>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbilityResource.LocalizedName"/>
    /// </summary>
    public AbilityResourceConfigurator SetDisplayName(LocalizedString name)
    {
      return OnConfigureInternal(blueprint => blueprint.LocalizedName = name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbilityResource.LocalizedDescription"/>
    /// </summary>
    public AbilityResourceConfigurator SetDescription(LocalizedString description)
    {
      return OnConfigureInternal(blueprint => blueprint.LocalizedDescription = description);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbilityResource.m_Icon"/>
    /// </summary>
    public AbilityResourceConfigurator SetIcon(Sprite icon)
    {
      return OnConfigureInternal(blueprint => blueprint.m_Icon = icon);
    }

    // TODO: MaxAmount

    /// <summary>
    /// Sets <see cref="BlueprintAbilityResource.m_Max"/> and <see cref="BlueprintAbilityResource.m_UseMax"/>
    /// </summary>
    public AbilityResourceConfigurator SetMax(int max)
    {
      return OnConfigureInternal(
          blueprint =>
          {
            blueprint.m_Max = max;
            blueprint.m_UseMax = true;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbilityResource.m_UseMax"/>
    /// </summary>
    public AbilityResourceConfigurator DisableMax()
    {
      return OnConfigureInternal(blueprint => blueprint.m_UseMax = false);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbilityResource.m_Min"/>
    /// </summary>
    public AbilityResourceConfigurator SetMin(int min)
    {
      return OnConfigureInternal(blueprint => blueprint.m_Min = min);
    }

    protected override void ConfigureInternal() { }

    protected override void ValidateInternal() { }
  }
}