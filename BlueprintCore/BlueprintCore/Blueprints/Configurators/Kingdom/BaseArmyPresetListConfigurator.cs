//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintArmyPresetList"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseArmyPresetListConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintArmyPresetList
    where TBuilder : BaseArmyPresetListConfigurator<T, TBuilder>
  {
    protected BaseArmyPresetListConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintArmyPresetList>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Presets = copyFrom.m_Presets;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintArmyPresetList>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Presets = copyFrom.m_Presets;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArmyPresetList.m_Presets"/>
    /// </summary>
    ///
    /// <param name="presets">
    /// <para>
    /// Blueprint of type BlueprintArmyPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetPresets(params Blueprint<BlueprintArmyPresetReference>[] presets)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Presets = presets.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintArmyPresetList.m_Presets"/>
    /// </summary>
    ///
    /// <param name="presets">
    /// <para>
    /// Blueprint of type BlueprintArmyPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToPresets(params Blueprint<BlueprintArmyPresetReference>[] presets)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Presets = bp.m_Presets ?? new BlueprintArmyPresetReference[0];
          bp.m_Presets = CommonTool.Append(bp.m_Presets, presets.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintArmyPresetList.m_Presets"/>
    /// </summary>
    ///
    /// <param name="presets">
    /// <para>
    /// Blueprint of type BlueprintArmyPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromPresets(params Blueprint<BlueprintArmyPresetReference>[] presets)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Presets is null) { return; }
          bp.m_Presets = bp.m_Presets.Where(val => !presets.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintArmyPresetList.m_Presets"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromPresets(Func<BlueprintArmyPresetReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Presets is null) { return; }
          bp.m_Presets = bp.m_Presets.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintArmyPresetList.m_Presets"/>
    /// </summary>
    public TBuilder ClearPresets()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Presets = new BlueprintArmyPresetReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmyPresetList.m_Presets"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyPresets(Action<BlueprintArmyPresetReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Presets is null) { return; }
          bp.m_Presets.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Presets is null)
      {
        Blueprint.m_Presets = new BlueprintArmyPresetReference[0];
      }
    }
  }
}
