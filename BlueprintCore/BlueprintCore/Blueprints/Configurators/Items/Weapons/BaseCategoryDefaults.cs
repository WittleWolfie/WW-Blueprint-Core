//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Items.Weapons
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCategoryDefaults"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCategoryDefaultsConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintCategoryDefaults
    where TBuilder : BaseCategoryDefaultsConfigurator<T, TBuilder>
  {
    protected BaseCategoryDefaultsConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCategoryDefaults.Entries"/>
    /// </summary>
    public TBuilder SetEntries(BlueprintCategoryDefaults.CategoryDefaultEntry[] entries)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in entries) { Validate(item); }
          bp.Entries = entries;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintCategoryDefaults.Entries"/>
    /// </summary>
    public TBuilder AddToEntries(params BlueprintCategoryDefaults.CategoryDefaultEntry[] entries)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Entries = bp.Entries ?? new BlueprintCategoryDefaults.CategoryDefaultEntry[0];
          bp.Entries = CommonTool.Append(bp.Entries, entries);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCategoryDefaults.Entries"/>
    /// </summary>
    public TBuilder RemoveFromEntries(params BlueprintCategoryDefaults.CategoryDefaultEntry[] entries)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Entries is null) { return; }
          bp.Entries = bp.Entries.Where(val => !entries.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCategoryDefaults.Entries"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromEntries(Func<BlueprintCategoryDefaults.CategoryDefaultEntry, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Entries is null) { return; }
          bp.Entries = bp.Entries.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintCategoryDefaults.Entries"/>
    /// </summary>
    public TBuilder ClearEntries()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Entries = new BlueprintCategoryDefaults.CategoryDefaultEntry[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCategoryDefaults.Entries"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyEntries(Action<BlueprintCategoryDefaults.CategoryDefaultEntry> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Entries is null) { return; }
          bp.Entries.ForEach(action);
        });
    }
  }
}
