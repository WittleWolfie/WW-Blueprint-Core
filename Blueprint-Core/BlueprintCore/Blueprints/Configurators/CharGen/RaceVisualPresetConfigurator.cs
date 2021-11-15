using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.CharGen;
using Kingmaker.Visual.CharacterSystem;

namespace BlueprintCore.Blueprints.Configurators.CharGen
{
  /// <summary>Configurator for <see cref="BlueprintRaceVisualPreset"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintRaceVisualPreset))]
  public class RaceVisualPresetConfigurator : BaseBlueprintConfigurator<BlueprintRaceVisualPreset, RaceVisualPresetConfigurator>
  {
     private RaceVisualPresetConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static RaceVisualPresetConfigurator For(string name)
    {
      return new RaceVisualPresetConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static RaceVisualPresetConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintRaceVisualPreset>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static RaceVisualPresetConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintRaceVisualPreset>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRaceVisualPreset.RaceId"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceVisualPresetConfigurator SetRaceId(Race value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.RaceId = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRaceVisualPreset.MaleSkeleton"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceVisualPresetConfigurator SetMaleSkeleton(Skeleton value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.MaleSkeleton = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRaceVisualPreset.FemaleSkeleton"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceVisualPresetConfigurator SetFemaleSkeleton(Skeleton value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.FemaleSkeleton = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRaceVisualPreset.m_Skin"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="KingmakerEquipmentEntity"/></param>
    [Generated]
    public RaceVisualPresetConfigurator SetSkin(string value)
    {
      return OnConfigureInternal(bp => bp.m_Skin = BlueprintTool.GetRef<KingmakerEquipmentEntityReference>(value));
    }
  }
}
