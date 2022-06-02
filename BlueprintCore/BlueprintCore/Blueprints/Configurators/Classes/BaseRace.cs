//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.CharGen;
using Kingmaker.Blueprints.Classes;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Utility;
using Kingmaker.View.Animation;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintRace"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseRaceConfigurator<T, TBuilder>
    : BaseFeatureConfigurator<T, TBuilder>
    where T : BlueprintRace
    where TBuilder : BaseRaceConfigurator<T, TBuilder>
  {
    protected BaseRaceConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRace.SoundKey"/>
    /// </summary>
    public TBuilder SetSoundKey(string soundKey)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SoundKey = soundKey;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRace.SoundKey"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySoundKey(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SoundKey is null) { return; }
          action.Invoke(bp.SoundKey);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRace.RaceId"/>
    /// </summary>
    public TBuilder SetRaceId(Race raceId)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RaceId = raceId;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRace.RaceId"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRaceId(Action<Race> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.RaceId);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRace.SelectableRaceStat"/>
    /// </summary>
    public TBuilder SetSelectableRaceStat(bool selectableRaceStat = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SelectableRaceStat = selectableRaceStat;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRace.SelectableRaceStat"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySelectableRaceStat(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.SelectableRaceStat);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRace.Size"/>
    /// </summary>
    public TBuilder SetSize(Size size)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Size = size;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRace.Size"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySize(Action<Size> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Size);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRace.m_Features"/>
    /// </summary>
    ///
    /// <param name="features">
    /// <para>
    /// Blueprint of type BlueprintFeatureBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetFeatures(params Blueprint<BlueprintFeatureBaseReference>[] features)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Features = features.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintRace.m_Features"/>
    /// </summary>
    ///
    /// <param name="features">
    /// <para>
    /// Blueprint of type BlueprintFeatureBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToFeatures(params Blueprint<BlueprintFeatureBaseReference>[] features)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Features = bp.m_Features ?? new BlueprintFeatureBaseReference[0];
          bp.m_Features = CommonTool.Append(bp.m_Features, features.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintRace.m_Features"/>
    /// </summary>
    ///
    /// <param name="features">
    /// <para>
    /// Blueprint of type BlueprintFeatureBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromFeatures(params Blueprint<BlueprintFeatureBaseReference>[] features)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Features is null) { return; }
          bp.m_Features = bp.m_Features.Where(val => !features.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintRace.m_Features"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromFeatures(Func<BlueprintFeatureBaseReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Features is null) { return; }
          bp.m_Features = bp.m_Features.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintRace.m_Features"/>
    /// </summary>
    public TBuilder ClearFeatures()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Features = new BlueprintFeatureBaseReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRace.m_Features"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyFeatures(Action<BlueprintFeatureBaseReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Features is null) { return; }
          bp.m_Features.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRace.m_Presets"/>
    /// </summary>
    ///
    /// <param name="presets">
    /// <para>
    /// Blueprint of type BlueprintRaceVisualPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetPresets(params Blueprint<BlueprintRaceVisualPresetReference>[] presets)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Presets = presets.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintRace.m_Presets"/>
    /// </summary>
    ///
    /// <param name="presets">
    /// <para>
    /// Blueprint of type BlueprintRaceVisualPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToPresets(params Blueprint<BlueprintRaceVisualPresetReference>[] presets)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Presets = bp.m_Presets ?? new BlueprintRaceVisualPresetReference[0];
          bp.m_Presets = CommonTool.Append(bp.m_Presets, presets.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintRace.m_Presets"/>
    /// </summary>
    ///
    /// <param name="presets">
    /// <para>
    /// Blueprint of type BlueprintRaceVisualPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromPresets(params Blueprint<BlueprintRaceVisualPresetReference>[] presets)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Presets is null) { return; }
          bp.m_Presets = bp.m_Presets.Where(val => !presets.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintRace.m_Presets"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromPresets(Func<BlueprintRaceVisualPresetReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Presets is null) { return; }
          bp.m_Presets = bp.m_Presets.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintRace.m_Presets"/>
    /// </summary>
    public TBuilder ClearPresets()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Presets = new BlueprintRaceVisualPresetReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRace.m_Presets"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyPresets(Action<BlueprintRaceVisualPresetReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Presets is null) { return; }
          bp.m_Presets.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRace.LinkHairAndSkinColorsCondition"/>
    /// </summary>
    public TBuilder SetLinkHairAndSkinColorsCondition(Condition linkHairAndSkinColorsCondition)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(linkHairAndSkinColorsCondition);
          bp.LinkHairAndSkinColorsCondition = linkHairAndSkinColorsCondition;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRace.LinkHairAndSkinColorsCondition"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLinkHairAndSkinColorsCondition(Action<Condition> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LinkHairAndSkinColorsCondition is null) { return; }
          action.Invoke(bp.LinkHairAndSkinColorsCondition);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRace.MaleOptions"/>
    /// </summary>
    public TBuilder SetMaleOptions(CustomizationOptions maleOptions)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(maleOptions);
          bp.MaleOptions = maleOptions;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRace.MaleOptions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMaleOptions(Action<CustomizationOptions> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.MaleOptions is null) { return; }
          action.Invoke(bp.MaleOptions);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRace.FemaleOptions"/>
    /// </summary>
    public TBuilder SetFemaleOptions(CustomizationOptions femaleOptions)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(femaleOptions);
          bp.FemaleOptions = femaleOptions;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRace.FemaleOptions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFemaleOptions(Action<CustomizationOptions> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FemaleOptions is null) { return; }
          action.Invoke(bp.FemaleOptions);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRace.MaleSpeedSettings"/>
    /// </summary>
    public TBuilder SetMaleSpeedSettings(UnitAnimationSettings maleSpeedSettings)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(maleSpeedSettings);
          bp.MaleSpeedSettings = maleSpeedSettings;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRace.MaleSpeedSettings"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMaleSpeedSettings(Action<UnitAnimationSettings> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.MaleSpeedSettings is null) { return; }
          action.Invoke(bp.MaleSpeedSettings);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRace.FemaleSpeedSettings"/>
    /// </summary>
    public TBuilder SetFemaleSpeedSettings(UnitAnimationSettings femaleSpeedSettings)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(femaleSpeedSettings);
          bp.FemaleSpeedSettings = femaleSpeedSettings;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRace.FemaleSpeedSettings"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFemaleSpeedSettings(Action<UnitAnimationSettings> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FemaleSpeedSettings is null) { return; }
          action.Invoke(bp.FemaleSpeedSettings);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRace.SpecialDollTypes"/>
    /// </summary>
    public TBuilder SetSpecialDollTypes(params BlueprintRace.SpecialDollTypeEntry[] specialDollTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(specialDollTypes);
          bp.SpecialDollTypes = specialDollTypes;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintRace.SpecialDollTypes"/>
    /// </summary>
    public TBuilder AddToSpecialDollTypes(params BlueprintRace.SpecialDollTypeEntry[] specialDollTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SpecialDollTypes = bp.SpecialDollTypes ?? new BlueprintRace.SpecialDollTypeEntry[0];
          bp.SpecialDollTypes = CommonTool.Append(bp.SpecialDollTypes, specialDollTypes);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintRace.SpecialDollTypes"/>
    /// </summary>
    public TBuilder RemoveFromSpecialDollTypes(params BlueprintRace.SpecialDollTypeEntry[] specialDollTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SpecialDollTypes is null) { return; }
          bp.SpecialDollTypes = bp.SpecialDollTypes.Where(val => !specialDollTypes.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintRace.SpecialDollTypes"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromSpecialDollTypes(Func<BlueprintRace.SpecialDollTypeEntry, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SpecialDollTypes is null) { return; }
          bp.SpecialDollTypes = bp.SpecialDollTypes.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintRace.SpecialDollTypes"/>
    /// </summary>
    public TBuilder ClearSpecialDollTypes()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SpecialDollTypes = new BlueprintRace.SpecialDollTypeEntry[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRace.SpecialDollTypes"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifySpecialDollTypes(Action<BlueprintRace.SpecialDollTypeEntry> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SpecialDollTypes is null) { return; }
          bp.SpecialDollTypes.ForEach(action);
        });
    }
  }
}
