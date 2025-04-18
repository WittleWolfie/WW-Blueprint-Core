//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Formations;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Formations
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="FollowersFormation"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseFollowersFormationConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : FollowersFormation
    where TBuilder : BaseFollowersFormationConfigurator<T, TBuilder>
  {
    protected BaseFollowersFormationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<FollowersFormation>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_PlayerOffset = copyFrom.m_PlayerOffset;
          bp.m_Formation = copyFrom.m_Formation;
          bp.m_RepathDistance = copyFrom.m_RepathDistance;
          bp.m_RepathCooldownSec = copyFrom.m_RepathCooldownSec;
          bp.m_LookAngleRandomSpread = copyFrom.m_LookAngleRandomSpread;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<FollowersFormation>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_PlayerOffset = copyFrom.m_PlayerOffset;
          bp.m_Formation = copyFrom.m_Formation;
          bp.m_RepathDistance = copyFrom.m_RepathDistance;
          bp.m_RepathCooldownSec = copyFrom.m_RepathCooldownSec;
          bp.m_LookAngleRandomSpread = copyFrom.m_LookAngleRandomSpread;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FollowersFormation.m_PlayerOffset"/>
    /// </summary>
    ///
    /// <param name="playerOffset">
    /// <para>
    /// Tooltip: Offset from main character. Y axis is in line with main character forward direction. X axis is in line with main character right direction.
    /// </para>
    /// </param>
    public TBuilder SetPlayerOffset(Vector2 playerOffset)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_PlayerOffset = playerOffset;
        });
    }

    /// <summary>
    /// Modifies <see cref="FollowersFormation.m_PlayerOffset"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPlayerOffset(Action<Vector2> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_PlayerOffset);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FollowersFormation.m_Formation"/>
    /// </summary>
    ///
    /// <param name="formation">
    /// <para>
    /// Tooltip: Followers formation.
    /// </para>
    /// </param>
    public TBuilder SetFormation(params Vector2[] formation)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Formation = formation;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="FollowersFormation.m_Formation"/>
    /// </summary>
    ///
    /// <param name="formation">
    /// <para>
    /// Tooltip: Followers formation.
    /// </para>
    /// </param>
    public TBuilder AddToFormation(params Vector2[] formation)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Formation = bp.m_Formation ?? new Vector2[0];
          bp.m_Formation = CommonTool.Append(bp.m_Formation, formation);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="FollowersFormation.m_Formation"/>
    /// </summary>
    ///
    /// <param name="formation">
    /// <para>
    /// Tooltip: Followers formation.
    /// </para>
    /// </param>
    public TBuilder RemoveFromFormation(params Vector2[] formation)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Formation is null) { return; }
          bp.m_Formation = bp.m_Formation.Where(val => !formation.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="FollowersFormation.m_Formation"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromFormation(Func<Vector2, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Formation is null) { return; }
          bp.m_Formation = bp.m_Formation.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="FollowersFormation.m_Formation"/>
    /// </summary>
    public TBuilder ClearFormation()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Formation = new Vector2[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="FollowersFormation.m_Formation"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyFormation(Action<Vector2> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Formation is null) { return; }
          bp.m_Formation.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FollowersFormation.m_RepathDistance"/>
    /// </summary>
    ///
    /// <param name="repathDistance">
    /// <para>
    /// Tooltip: Distance between current follower position and his target position on which follower remains idle.
    /// </para>
    /// </param>
    public TBuilder SetRepathDistance(float repathDistance)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_RepathDistance = repathDistance;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FollowersFormation.m_RepathCooldownSec"/>
    /// </summary>
    ///
    /// <param name="repathCooldownSec">
    /// <para>
    /// Tooltip: Repath delay in seconds.
    /// </para>
    /// </param>
    public TBuilder SetRepathCooldownSec(float repathCooldownSec)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_RepathCooldownSec = repathCooldownSec;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="FollowersFormation.m_LookAngleRandomSpread"/>
    /// </summary>
    ///
    /// <param name="lookAngleRandomSpread">
    /// <para>
    /// Tooltip: Look angle spread. Follower look angle will be equal to main character look angle + Random(-LookAngleSpread/2,LookAngleSpread/2).
    /// </para>
    /// </param>
    public TBuilder SetLookAngleRandomSpread(float lookAngleRandomSpread)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_LookAngleRandomSpread = lookAngleRandomSpread;
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Formation is null)
      {
        Blueprint.m_Formation = new Vector2[0];
      }
    }
  }
}
