//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Persistence.Versioning;
using System;

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
    /// Modifies <see cref="BlueprintUnitUpgrader.ApplyFromPlaceholder"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyApplyFromPlaceholder(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ApplyFromPlaceholder);
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
          if (bp.Actions is null)
          {
            bp.Actions = Utils.Constants.Empty.Actions;
          }
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
  }
}
