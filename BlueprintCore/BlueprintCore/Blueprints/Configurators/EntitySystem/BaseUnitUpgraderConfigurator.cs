//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Persistence.Versioning;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.EntitySystem
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintUnitUpgrader"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseUnitUpgraderConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintUnitUpgrader
    where TBuilder : BaseUnitUpgraderConfigurator<T, TBuilder>
  {
    protected BaseUnitUpgraderConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintUnitUpgrader>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.ApplyFromPlaceholder = copyFrom.ApplyFromPlaceholder;
          bp.Actions = copyFrom.Actions;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintUnitUpgrader>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.ApplyFromPlaceholder = copyFrom.ApplyFromPlaceholder;
          bp.Actions = copyFrom.Actions;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnitUpgrader.ApplyFromPlaceholder"/>
    /// </summary>
    public TBuilder SetApplyFromPlaceholder(bool applyFromPlaceholder = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ApplyFromPlaceholder = applyFromPlaceholder;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnitUpgrader.Actions"/>
    /// </summary>
    public TBuilder SetActions(ActionsBuilder actions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Actions = actions?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnitUpgrader.Actions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyActions(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Actions is null) { return; }
          action.Invoke(bp.Actions);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Actions is null)
      {
        Blueprint.Actions = Utils.Constants.Empty.Actions;
      }
    }
  }
}
