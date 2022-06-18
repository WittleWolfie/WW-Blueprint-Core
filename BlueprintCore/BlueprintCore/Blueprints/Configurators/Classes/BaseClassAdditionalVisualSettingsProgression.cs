//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintClassAdditionalVisualSettingsProgression"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseClassAdditionalVisualSettingsProgressionConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintClassAdditionalVisualSettingsProgression
    where TBuilder : BaseClassAdditionalVisualSettingsProgressionConfigurator<T, TBuilder>
  {
    protected BaseClassAdditionalVisualSettingsProgressionConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintClassAdditionalVisualSettingsProgression.Entries"/>
    /// </summary>
    public TBuilder SetEntries(params BlueprintClassAdditionalVisualSettingsProgression.Entry[] entries)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(entries);
          bp.Entries = entries;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintClassAdditionalVisualSettingsProgression.Entries"/>
    /// </summary>
    public TBuilder AddToEntries(params BlueprintClassAdditionalVisualSettingsProgression.Entry[] entries)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Entries = bp.Entries ?? new BlueprintClassAdditionalVisualSettingsProgression.Entry[0];
          bp.Entries = CommonTool.Append(bp.Entries, entries);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClassAdditionalVisualSettingsProgression.Entries"/>
    /// </summary>
    public TBuilder RemoveFromEntries(params BlueprintClassAdditionalVisualSettingsProgression.Entry[] entries)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Entries is null) { return; }
          bp.Entries = bp.Entries.Where(val => !entries.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintClassAdditionalVisualSettingsProgression.Entries"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromEntries(Func<BlueprintClassAdditionalVisualSettingsProgression.Entry, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Entries is null) { return; }
          bp.Entries = bp.Entries.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintClassAdditionalVisualSettingsProgression.Entries"/>
    /// </summary>
    public TBuilder ClearEntries()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Entries = new BlueprintClassAdditionalVisualSettingsProgression.Entry[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintClassAdditionalVisualSettingsProgression.Entries"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyEntries(Action<BlueprintClassAdditionalVisualSettingsProgression.Entry> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Entries is null) { return; }
          bp.Entries.ForEach(action);
        });
    }

    protected override void SetDefaults()
    {
      base.SetDefaults();
    
      if (Blueprint.Entries is null)
      {
        Blueprint.Entries = new BlueprintClassAdditionalVisualSettingsProgression.Entry[0];
      }
    }
  }
}
