//***** AUTO-GENERATED - DO NOT EDIT *****//

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
    protected BaseArmyPresetListConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetPresets(List<Blueprint<BlueprintArmyPreset, BlueprintArmyPresetReference>> presets)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Presets = presets?.Select(bp => bp.Reference)?.ToArray();
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToPresets(params Blueprint<BlueprintArmyPreset, BlueprintArmyPresetReference>[] presets)
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromPresets(params Blueprint<BlueprintArmyPreset, BlueprintArmyPresetReference>[] presets)
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromPresets(Func<BlueprintArmyPresetReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Presets is null) { return; }
          bp.m_Presets = bp.m_Presets.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintArmyPresetList.m_Presets"/>
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyPresets(Action<BlueprintArmyPresetReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Presets is null) { return; }
          bp.m_Presets.ForEach(action);
        });
    }
  }
}
