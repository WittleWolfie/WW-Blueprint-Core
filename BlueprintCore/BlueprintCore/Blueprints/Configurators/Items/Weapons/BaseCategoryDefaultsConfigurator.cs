//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
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
    protected BaseCategoryDefaultsConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintCategoryDefaults>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Entries = copyFrom.Entries;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCategoryDefaults.Entries"/>
    /// </summary>
    public TBuilder SetEntries(params BlueprintCategoryDefaults.CategoryDefaultEntry[] entries)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(entries);
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
          bp.Entries = bp.Entries.Where(e => !predicate(e)).ToArray();
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

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Entries is null)
      {
        Blueprint.Entries = new BlueprintCategoryDefaults.CategoryDefaultEntry[0];
      }
    }
  }
}
