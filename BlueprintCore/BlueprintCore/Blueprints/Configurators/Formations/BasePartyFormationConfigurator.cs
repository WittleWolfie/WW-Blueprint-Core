//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Formations;
using Kingmaker.Localization;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Formations
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintPartyFormation"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BasePartyFormationConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintPartyFormation
    where TBuilder : BasePartyFormationConfigurator<T, TBuilder>
  {
    protected BasePartyFormationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintPartyFormation>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Positions = copyFrom.Positions;
          bp.Type = copyFrom.Type;
          bp.Name = copyFrom.Name;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintPartyFormation>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Positions = copyFrom.Positions;
          bp.Type = copyFrom.Type;
          bp.Name = copyFrom.Name;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintPartyFormation.Positions"/>
    /// </summary>
    public TBuilder SetPositions(params Vector2[] positions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Positions = positions;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintPartyFormation.Positions"/>
    /// </summary>
    public TBuilder AddToPositions(params Vector2[] positions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Positions = bp.Positions ?? new Vector2[0];
          bp.Positions = CommonTool.Append(bp.Positions, positions);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintPartyFormation.Positions"/>
    /// </summary>
    public TBuilder RemoveFromPositions(params Vector2[] positions)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Positions is null) { return; }
          bp.Positions = bp.Positions.Where(val => !positions.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintPartyFormation.Positions"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromPositions(Func<Vector2, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Positions is null) { return; }
          bp.Positions = bp.Positions.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintPartyFormation.Positions"/>
    /// </summary>
    public TBuilder ClearPositions()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Positions = new Vector2[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintPartyFormation.Positions"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyPositions(Action<Vector2> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Positions is null) { return; }
          bp.Positions.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintPartyFormation.Type"/>
    /// </summary>
    public TBuilder SetType(PartyFormationType type)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Type = type;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintPartyFormation.Name"/>
    /// </summary>
    ///
    /// <param name="name">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetName(LocalString name)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Name = name?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintPartyFormation.Name"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Name is null) { return; }
          action.Invoke(bp.Name);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Positions is null)
      {
        Blueprint.Positions = new Vector2[0];
      }
      if (Blueprint.Name is null)
      {
        Blueprint.Name = Utils.Constants.Empty.String;
      }
    }
  }
}
