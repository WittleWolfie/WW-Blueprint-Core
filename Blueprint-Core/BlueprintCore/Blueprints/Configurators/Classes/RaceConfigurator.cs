using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.CharGen;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums;
using Kingmaker.View.Animation;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>Configurator for <see cref="BlueprintRace"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintRace))]
  public class RaceConfigurator : BaseFeatureConfigurator<BlueprintRace, RaceConfigurator>
  {
     private RaceConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static RaceConfigurator For(string name)
    {
      return new RaceConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static RaceConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintRace>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static RaceConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintRace>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRace.SoundKey"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceConfigurator SetSoundKey(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.SoundKey = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRace.RaceId"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceConfigurator SetRaceId(Race value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.RaceId = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRace.SelectableRaceStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceConfigurator SetSelectableRaceStat(bool value)
    {
      return OnConfigureInternal(bp => bp.SelectableRaceStat = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRace.Size"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceConfigurator SetSize(Size value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Size = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRace.m_Features"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintFeatureBase"/></param>
    [Generated]
    public RaceConfigurator AddToFeatures(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Features = CommonTool.Append(bp.m_Features, values.Select(name => BlueprintTool.GetRef<BlueprintFeatureBaseReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRace.m_Features"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintFeatureBase"/></param>
    [Generated]
    public RaceConfigurator RemoveFromFeatures(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintFeatureBaseReference>(name));
            bp.m_Features =
                bp.m_Features
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRace.m_Presets"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintRaceVisualPreset"/></param>
    [Generated]
    public RaceConfigurator AddToPresets(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Presets = CommonTool.Append(bp.m_Presets, values.Select(name => BlueprintTool.GetRef<BlueprintRaceVisualPresetReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRace.m_Presets"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintRaceVisualPreset"/></param>
    [Generated]
    public RaceConfigurator RemoveFromPresets(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintRaceVisualPresetReference>(name));
            bp.m_Presets =
                bp.m_Presets
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRace.LinkHairAndSkinColors"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceConfigurator SetLinkHairAndSkinColors(bool value)
    {
      return OnConfigureInternal(bp => bp.LinkHairAndSkinColors = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRace.MaleOptions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceConfigurator SetMaleOptions(CustomizationOptions value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.MaleOptions = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRace.FemaleOptions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceConfigurator SetFemaleOptions(CustomizationOptions value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.FemaleOptions = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRace.MaleSpeedSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceConfigurator SetMaleSpeedSettings(UnitAnimationSettings value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.MaleSpeedSettings = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRace.FemaleSpeedSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceConfigurator SetFemaleSpeedSettings(UnitAnimationSettings value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.FemaleSpeedSettings = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRace.SpecialDollTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceConfigurator AddToSpecialDollTypes(params BlueprintRace.SpecialDollTypeEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.SpecialDollTypes = CommonTool.Append(bp.SpecialDollTypes, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRace.SpecialDollTypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceConfigurator RemoveFromSpecialDollTypes(params BlueprintRace.SpecialDollTypeEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.SpecialDollTypes = bp.SpecialDollTypes.Where(item => !values.Contains(item)).ToArray());
    }
  }
}
