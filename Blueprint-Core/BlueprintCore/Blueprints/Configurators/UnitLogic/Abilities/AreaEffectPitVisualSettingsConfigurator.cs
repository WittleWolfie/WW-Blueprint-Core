using BlueprintCore.Utils;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.UnitLogic.Abilities
{
  /// <summary>Configurator for <see cref="BlueprintAreaEffectPitVisualSettings"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAreaEffectPitVisualSettings))]
  public class AreaEffectPitVisualSettingsConfigurator : BaseBlueprintConfigurator<BlueprintAreaEffectPitVisualSettings, AreaEffectPitVisualSettingsConfigurator>
  {
     private AreaEffectPitVisualSettingsConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AreaEffectPitVisualSettingsConfigurator For(string name)
    {
      return new AreaEffectPitVisualSettingsConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AreaEffectPitVisualSettingsConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintAreaEffectPitVisualSettings>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AreaEffectPitVisualSettingsConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintAreaEffectPitVisualSettings>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaEffectPitVisualSettings.DepthMeters"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaEffectPitVisualSettingsConfigurator SetDepthMeters(float value)
    {
      return OnConfigureInternal(bp => bp.DepthMeters = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaEffectPitVisualSettings.HoleEdgeMeters"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaEffectPitVisualSettingsConfigurator SetHoleEdgeMeters(float value)
    {
      return OnConfigureInternal(bp => bp.HoleEdgeMeters = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaEffectPitVisualSettings.UnitDisappearFx"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaEffectPitVisualSettingsConfigurator SetUnitDisappearFx(GameObject value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.UnitDisappearFx = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaEffectPitVisualSettings.UnitAppearFx"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaEffectPitVisualSettingsConfigurator SetUnitAppearFx(GameObject value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.UnitAppearFx = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaEffectPitVisualSettings.FallXZCurve"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaEffectPitVisualSettingsConfigurator SetFallXZCurve(AnimationCurve value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.FallXZCurve = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaEffectPitVisualSettings.FallYCurve"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaEffectPitVisualSettingsConfigurator SetFallYCurve(AnimationCurve value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.FallYCurve = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaEffectPitVisualSettings.ClimbXZCurve"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaEffectPitVisualSettingsConfigurator SetClimbXZCurve(AnimationCurve value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ClimbXZCurve = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAreaEffectPitVisualSettings.ClimbYCurve"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaEffectPitVisualSettingsConfigurator SetClimbYCurve(AnimationCurve value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ClimbYCurve = value);
    }
  }
}
