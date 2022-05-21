//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Credits;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Credits
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCreditsRoles"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCreditsRolesConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintCreditsRoles
    where TBuilder : BaseCreditsRolesConfigurator<T, TBuilder>
  {
    protected BaseCreditsRolesConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCreditsRoles.Roles"/>
    /// </summary>
    public TBuilder SetRoles(params CreditRole[] roles)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in roles) { Validate(item); }
          bp.Roles = roles.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintCreditsRoles.Roles"/>
    /// </summary>
    public TBuilder AddToRoles(params CreditRole[] roles)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Roles = bp.Roles ?? new();
          bp.Roles.AddRange(roles);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCreditsRoles.Roles"/>
    /// </summary>
    public TBuilder RemoveFromRoles(params CreditRole[] roles)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Roles is null) { return; }
          bp.Roles = bp.Roles.Where(val => !roles.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCreditsRoles.Roles"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromRoles(Func<CreditRole, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Roles is null) { return; }
          bp.Roles = bp.Roles.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintCreditsRoles.Roles"/>
    /// </summary>
    public TBuilder ClearRoles()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Roles = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCreditsRoles.Roles"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyRoles(Action<CreditRole> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Roles is null) { return; }
          bp.Roles.ForEach(action);
        });
    }
  }
}
