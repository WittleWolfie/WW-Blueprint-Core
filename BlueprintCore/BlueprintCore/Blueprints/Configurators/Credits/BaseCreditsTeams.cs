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
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCreditsTeams"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCreditsTeamsConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintCreditsTeams
    where TBuilder : BaseCreditsTeamsConfigurator<T, TBuilder>
  {
    protected BaseCreditsTeamsConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCreditsTeams.Teams"/>
    /// </summary>
    public TBuilder SetTeams(params CreditTeam[] teams)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(teams);
          bp.Teams = teams.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintCreditsTeams.Teams"/>
    /// </summary>
    public TBuilder AddToTeams(params CreditTeam[] teams)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Teams = bp.Teams ?? new();
          bp.Teams.AddRange(teams);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCreditsTeams.Teams"/>
    /// </summary>
    public TBuilder RemoveFromTeams(params CreditTeam[] teams)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Teams is null) { return; }
          bp.Teams = bp.Teams.Where(val => !teams.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCreditsTeams.Teams"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromTeams(Func<CreditTeam, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Teams is null) { return; }
          bp.Teams = bp.Teams.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintCreditsTeams.Teams"/>
    /// </summary>
    public TBuilder ClearTeams()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Teams = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCreditsTeams.Teams"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyTeams(Action<CreditTeam> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Teams is null) { return; }
          bp.Teams.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Teams is null)
      {
        Blueprint.Teams = new();
      }
    }
  }
}
