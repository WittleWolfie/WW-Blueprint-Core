using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Customization;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.UnitLogic.Customization
{
  /// <summary>Configurator for <see cref="UnitCustomizationPreset"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(UnitCustomizationPreset))]
  public class UnitCustomizationPresetConfigurator : BaseBlueprintConfigurator<UnitCustomizationPreset, UnitCustomizationPresetConfigurator>
  {
     private UnitCustomizationPresetConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnitCustomizationPresetConfigurator For(string name)
    {
      return new UnitCustomizationPresetConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static UnitCustomizationPresetConfigurator New(string name)
    {
      BlueprintTool.Create<UnitCustomizationPreset>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnitCustomizationPresetConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<UnitCustomizationPreset>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="UnitCustomizationPreset.PresetObjects"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitCustomizationPresetConfigurator AddToPresetObjects(params PresetObject[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.PresetObjects.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="UnitCustomizationPreset.PresetObjects"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitCustomizationPresetConfigurator RemoveFromPresetObjects(params PresetObject[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.PresetObjects = bp.PresetObjects.Where(item => !values.Contains(item)).ToList());
    }

    /// <summary>
    /// Sets <see cref="UnitCustomizationPreset.VariationsCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitCustomizationPresetConfigurator SetVariationsCount(int value)
    {
      return OnConfigureInternal(bp => bp.VariationsCount = value);
    }

    /// <summary>
    /// Sets <see cref="UnitCustomizationPreset.m_Distribution"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="RaceGenderDistribution"/></param>
    [Generated]
    public UnitCustomizationPresetConfigurator SetDistribution(string value)
    {
      return OnConfigureInternal(bp => bp.m_Distribution = BlueprintTool.GetRef<RaceGenderDistributionReference>(value));
    }

    /// <summary>
    /// Modifies <see cref="UnitCustomizationPreset.m_Units"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnit"/></param>
    [Generated]
    public UnitCustomizationPresetConfigurator AddToUnits(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Units = CommonTool.Append(bp.m_Units, values.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="UnitCustomizationPreset.m_Units"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnit"/></param>
    [Generated]
    public UnitCustomizationPresetConfigurator RemoveFromUnits(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name));
            bp.m_Units =
                bp.m_Units
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Modifies <see cref="UnitCustomizationPreset.ClothesSelections"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitCustomizationPresetConfigurator AddToClothesSelections(params ClothesSelection[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.ClothesSelections = CommonTool.Append(bp.ClothesSelections, values));
    }

    /// <summary>
    /// Modifies <see cref="UnitCustomizationPreset.ClothesSelections"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitCustomizationPresetConfigurator RemoveFromClothesSelections(params ClothesSelection[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.ClothesSelections = bp.ClothesSelections.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="UnitCustomizationPreset.UnitVariations"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitCustomizationPresetConfigurator AddToUnitVariations(params UnitVariations[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.UnitVariations.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="UnitCustomizationPreset.UnitVariations"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitCustomizationPresetConfigurator RemoveFromUnitVariations(params UnitVariations[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.UnitVariations = bp.UnitVariations.Where(item => !values.Contains(item)).ToList());
    }

    /// <summary>
    /// Modifies <see cref="UnitCustomizationPreset.MaleVoices"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnitAsksList"/></param>
    [Generated]
    public UnitCustomizationPresetConfigurator AddToMaleVoices(params string[] values)
    {
      return OnConfigureInternal(bp => bp.MaleVoices.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintUnitAsksListReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="UnitCustomizationPreset.MaleVoices"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnitAsksList"/></param>
    [Generated]
    public UnitCustomizationPresetConfigurator RemoveFromMaleVoices(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintUnitAsksListReference>(name));
            bp.MaleVoices =
                bp.MaleVoices
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="UnitCustomizationPreset.FemaleVoices"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnitAsksList"/></param>
    [Generated]
    public UnitCustomizationPresetConfigurator AddToFemaleVoices(params string[] values)
    {
      return OnConfigureInternal(bp => bp.FemaleVoices.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintUnitAsksListReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="UnitCustomizationPreset.FemaleVoices"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnitAsksList"/></param>
    [Generated]
    public UnitCustomizationPresetConfigurator RemoveFromFemaleVoices(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintUnitAsksListReference>(name));
            bp.FemaleVoices =
                bp.FemaleVoices
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="UnitCustomizationPreset.randomParameters"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="RandomParameters"/></param>
    [Generated]
    public UnitCustomizationPresetConfigurator SetrandomParameters(string value)
    {
      return OnConfigureInternal(bp => bp.randomParameters = BlueprintTool.GetRef<RandomParametersReference>(value));
    }
  }
}
