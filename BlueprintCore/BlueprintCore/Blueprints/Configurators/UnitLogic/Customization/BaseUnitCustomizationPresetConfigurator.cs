//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Customization;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.UnitLogic.Customization
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="UnitCustomizationPreset"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseUnitCustomizationPresetConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : UnitCustomizationPreset
    where TBuilder : BaseUnitCustomizationPresetConfigurator<T, TBuilder>
  {
    protected BaseUnitCustomizationPresetConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<UnitCustomizationPreset>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.PresetObjects = copyFrom.PresetObjects;
          bp.VariationsCount = copyFrom.VariationsCount;
          bp.m_Distribution = copyFrom.m_Distribution;
          bp.m_Units = copyFrom.m_Units;
          bp.ClothesSelections = copyFrom.ClothesSelections;
          bp.UnitVariations = copyFrom.UnitVariations;
          bp.MaleVoices = copyFrom.MaleVoices;
          bp.FemaleVoices = copyFrom.FemaleVoices;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitCustomizationPreset.PresetObjects"/>
    /// </summary>
    public TBuilder SetPresetObjects(params PresetObject[] presetObjects)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(presetObjects);
          bp.PresetObjects = presetObjects.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="UnitCustomizationPreset.PresetObjects"/>
    /// </summary>
    public TBuilder AddToPresetObjects(params PresetObject[] presetObjects)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.PresetObjects = bp.PresetObjects ?? new();
          bp.PresetObjects.AddRange(presetObjects);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="UnitCustomizationPreset.PresetObjects"/>
    /// </summary>
    public TBuilder RemoveFromPresetObjects(params PresetObject[] presetObjects)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.PresetObjects is null) { return; }
          bp.PresetObjects = bp.PresetObjects.Where(val => !presetObjects.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="UnitCustomizationPreset.PresetObjects"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromPresetObjects(Func<PresetObject, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.PresetObjects is null) { return; }
          bp.PresetObjects = bp.PresetObjects.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="UnitCustomizationPreset.PresetObjects"/>
    /// </summary>
    public TBuilder ClearPresetObjects()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.PresetObjects = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="UnitCustomizationPreset.PresetObjects"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyPresetObjects(Action<PresetObject> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.PresetObjects is null) { return; }
          bp.PresetObjects.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitCustomizationPreset.VariationsCount"/>
    /// </summary>
    public TBuilder SetVariationsCount(int variationsCount)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.VariationsCount = variationsCount;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitCustomizationPreset.m_Distribution"/>
    /// </summary>
    ///
    /// <param name="distribution">
    /// <para>
    /// Blueprint of type RaceGenderDistribution. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetDistribution(Blueprint<RaceGenderDistributionReference> distribution)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Distribution = distribution?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="UnitCustomizationPreset.m_Distribution"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDistribution(Action<RaceGenderDistributionReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Distribution is null) { return; }
          action.Invoke(bp.m_Distribution);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitCustomizationPreset.m_Units"/>
    /// </summary>
    ///
    /// <param name="units">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetUnits(params Blueprint<BlueprintUnitReference>[] units)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Units = units.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="UnitCustomizationPreset.m_Units"/>
    /// </summary>
    ///
    /// <param name="units">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToUnits(params Blueprint<BlueprintUnitReference>[] units)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Units = bp.m_Units ?? new BlueprintUnitReference[0];
          bp.m_Units = CommonTool.Append(bp.m_Units, units.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="UnitCustomizationPreset.m_Units"/>
    /// </summary>
    ///
    /// <param name="units">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromUnits(params Blueprint<BlueprintUnitReference>[] units)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Units is null) { return; }
          bp.m_Units = bp.m_Units.Where(val => !units.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="UnitCustomizationPreset.m_Units"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromUnits(Func<BlueprintUnitReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Units is null) { return; }
          bp.m_Units = bp.m_Units.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="UnitCustomizationPreset.m_Units"/>
    /// </summary>
    public TBuilder ClearUnits()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Units = new BlueprintUnitReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="UnitCustomizationPreset.m_Units"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyUnits(Action<BlueprintUnitReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Units is null) { return; }
          bp.m_Units.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitCustomizationPreset.ClothesSelections"/>
    /// </summary>
    public TBuilder SetClothesSelections(params ClothesSelection[] clothesSelections)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(clothesSelections);
          bp.ClothesSelections = clothesSelections;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="UnitCustomizationPreset.ClothesSelections"/>
    /// </summary>
    public TBuilder AddToClothesSelections(params ClothesSelection[] clothesSelections)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ClothesSelections = bp.ClothesSelections ?? new ClothesSelection[0];
          bp.ClothesSelections = CommonTool.Append(bp.ClothesSelections, clothesSelections);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="UnitCustomizationPreset.ClothesSelections"/>
    /// </summary>
    public TBuilder RemoveFromClothesSelections(params ClothesSelection[] clothesSelections)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ClothesSelections is null) { return; }
          bp.ClothesSelections = bp.ClothesSelections.Where(val => !clothesSelections.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="UnitCustomizationPreset.ClothesSelections"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromClothesSelections(Func<ClothesSelection, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ClothesSelections is null) { return; }
          bp.ClothesSelections = bp.ClothesSelections.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="UnitCustomizationPreset.ClothesSelections"/>
    /// </summary>
    public TBuilder ClearClothesSelections()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ClothesSelections = new ClothesSelection[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="UnitCustomizationPreset.ClothesSelections"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyClothesSelections(Action<ClothesSelection> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ClothesSelections is null) { return; }
          bp.ClothesSelections.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitCustomizationPreset.UnitVariations"/>
    /// </summary>
    public TBuilder SetUnitVariations(params UnitVariations[] unitVariations)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(unitVariations);
          bp.UnitVariations = unitVariations.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="UnitCustomizationPreset.UnitVariations"/>
    /// </summary>
    public TBuilder AddToUnitVariations(params UnitVariations[] unitVariations)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UnitVariations = bp.UnitVariations ?? new();
          bp.UnitVariations.AddRange(unitVariations);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="UnitCustomizationPreset.UnitVariations"/>
    /// </summary>
    public TBuilder RemoveFromUnitVariations(params UnitVariations[] unitVariations)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.UnitVariations is null) { return; }
          bp.UnitVariations = bp.UnitVariations.Where(val => !unitVariations.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="UnitCustomizationPreset.UnitVariations"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromUnitVariations(Func<UnitVariations, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.UnitVariations is null) { return; }
          bp.UnitVariations = bp.UnitVariations.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="UnitCustomizationPreset.UnitVariations"/>
    /// </summary>
    public TBuilder ClearUnitVariations()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UnitVariations = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="UnitCustomizationPreset.UnitVariations"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyUnitVariations(Action<UnitVariations> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.UnitVariations is null) { return; }
          bp.UnitVariations.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitCustomizationPreset.MaleVoices"/>
    /// </summary>
    ///
    /// <param name="maleVoices">
    /// <para>
    /// Blueprint of type BlueprintUnitAsksList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetMaleVoices(params Blueprint<BlueprintUnitAsksListReference>[] maleVoices)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MaleVoices = maleVoices.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="UnitCustomizationPreset.MaleVoices"/>
    /// </summary>
    ///
    /// <param name="maleVoices">
    /// <para>
    /// Blueprint of type BlueprintUnitAsksList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToMaleVoices(params Blueprint<BlueprintUnitAsksListReference>[] maleVoices)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MaleVoices = bp.MaleVoices ?? new();
          bp.MaleVoices.AddRange(maleVoices.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="UnitCustomizationPreset.MaleVoices"/>
    /// </summary>
    ///
    /// <param name="maleVoices">
    /// <para>
    /// Blueprint of type BlueprintUnitAsksList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromMaleVoices(params Blueprint<BlueprintUnitAsksListReference>[] maleVoices)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.MaleVoices is null) { return; }
          bp.MaleVoices = bp.MaleVoices.Where(val => !maleVoices.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="UnitCustomizationPreset.MaleVoices"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromMaleVoices(Func<BlueprintUnitAsksListReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.MaleVoices is null) { return; }
          bp.MaleVoices = bp.MaleVoices.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="UnitCustomizationPreset.MaleVoices"/>
    /// </summary>
    public TBuilder ClearMaleVoices()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MaleVoices = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="UnitCustomizationPreset.MaleVoices"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyMaleVoices(Action<BlueprintUnitAsksListReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.MaleVoices is null) { return; }
          bp.MaleVoices.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitCustomizationPreset.FemaleVoices"/>
    /// </summary>
    ///
    /// <param name="femaleVoices">
    /// <para>
    /// Blueprint of type BlueprintUnitAsksList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetFemaleVoices(params Blueprint<BlueprintUnitAsksListReference>[] femaleVoices)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FemaleVoices = femaleVoices.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="UnitCustomizationPreset.FemaleVoices"/>
    /// </summary>
    ///
    /// <param name="femaleVoices">
    /// <para>
    /// Blueprint of type BlueprintUnitAsksList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToFemaleVoices(params Blueprint<BlueprintUnitAsksListReference>[] femaleVoices)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FemaleVoices = bp.FemaleVoices ?? new();
          bp.FemaleVoices.AddRange(femaleVoices.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="UnitCustomizationPreset.FemaleVoices"/>
    /// </summary>
    ///
    /// <param name="femaleVoices">
    /// <para>
    /// Blueprint of type BlueprintUnitAsksList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromFemaleVoices(params Blueprint<BlueprintUnitAsksListReference>[] femaleVoices)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FemaleVoices is null) { return; }
          bp.FemaleVoices = bp.FemaleVoices.Where(val => !femaleVoices.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="UnitCustomizationPreset.FemaleVoices"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromFemaleVoices(Func<BlueprintUnitAsksListReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FemaleVoices is null) { return; }
          bp.FemaleVoices = bp.FemaleVoices.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="UnitCustomizationPreset.FemaleVoices"/>
    /// </summary>
    public TBuilder ClearFemaleVoices()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FemaleVoices = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="UnitCustomizationPreset.FemaleVoices"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyFemaleVoices(Action<BlueprintUnitAsksListReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FemaleVoices is null) { return; }
          bp.FemaleVoices.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.PresetObjects is null)
      {
        Blueprint.PresetObjects = new();
      }
      if (Blueprint.m_Distribution is null)
      {
        Blueprint.m_Distribution = BlueprintTool.GetRef<RaceGenderDistributionReference>(null);
      }
      if (Blueprint.m_Units is null)
      {
        Blueprint.m_Units = new BlueprintUnitReference[0];
      }
      if (Blueprint.ClothesSelections is null)
      {
        Blueprint.ClothesSelections = new ClothesSelection[0];
      }
      if (Blueprint.UnitVariations is null)
      {
        Blueprint.UnitVariations = new();
      }
      if (Blueprint.MaleVoices is null)
      {
        Blueprint.MaleVoices = new();
      }
      if (Blueprint.FemaleVoices is null)
      {
        Blueprint.FemaleVoices = new();
      }
    }
  }
}
