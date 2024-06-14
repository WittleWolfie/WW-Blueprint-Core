//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="OverrideLegacyUnits"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseOverrideLegacyUnitsConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : OverrideLegacyUnits
    where TBuilder : BaseOverrideLegacyUnitsConfigurator<T, TBuilder>
  {
    protected BaseOverrideLegacyUnitsConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<OverrideLegacyUnits>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.OverrideRecords = copyFrom.OverrideRecords;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<OverrideLegacyUnits>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.OverrideRecords = copyFrom.OverrideRecords;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="OverrideLegacyUnits.OverrideRecords"/>
    /// </summary>
    public TBuilder SetOverrideRecords(params OverrideLegacyUnits.OverrideRecord[] overrideRecords)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(overrideRecords);
          bp.OverrideRecords = overrideRecords;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="OverrideLegacyUnits.OverrideRecords"/>
    /// </summary>
    public TBuilder AddToOverrideRecords(params OverrideLegacyUnits.OverrideRecord[] overrideRecords)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OverrideRecords = bp.OverrideRecords ?? new OverrideLegacyUnits.OverrideRecord[0];
          bp.OverrideRecords = CommonTool.Append(bp.OverrideRecords, overrideRecords);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="OverrideLegacyUnits.OverrideRecords"/>
    /// </summary>
    public TBuilder RemoveFromOverrideRecords(params OverrideLegacyUnits.OverrideRecord[] overrideRecords)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OverrideRecords is null) { return; }
          bp.OverrideRecords = bp.OverrideRecords.Where(val => !overrideRecords.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="OverrideLegacyUnits.OverrideRecords"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromOverrideRecords(Func<OverrideLegacyUnits.OverrideRecord, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OverrideRecords is null) { return; }
          bp.OverrideRecords = bp.OverrideRecords.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="OverrideLegacyUnits.OverrideRecords"/>
    /// </summary>
    public TBuilder ClearOverrideRecords()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OverrideRecords = new OverrideLegacyUnits.OverrideRecord[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="OverrideLegacyUnits.OverrideRecords"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyOverrideRecords(Action<OverrideLegacyUnits.OverrideRecord> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OverrideRecords is null) { return; }
          bp.OverrideRecords.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.OverrideRecords is null)
      {
        Blueprint.OverrideRecords = new OverrideLegacyUnits.OverrideRecord[0];
      }
    }
  }
}
