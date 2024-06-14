//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Root
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="ScenesRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseScenesRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : ScenesRoot
    where TBuilder : BaseScenesRootConfigurator<T, TBuilder>
  {
    protected BaseScenesRootConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<ScenesRoot>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_ShortSceneNameCandidates = copyFrom.m_ShortSceneNameCandidates;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<ScenesRoot>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_ShortSceneNameCandidates = copyFrom.m_ShortSceneNameCandidates;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ScenesRoot.m_ShortSceneNameCandidates"/>
    /// </summary>
    public TBuilder SetShortSceneNameCandidates(params string[] shortSceneNameCandidates)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ShortSceneNameCandidates = shortSceneNameCandidates;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="ScenesRoot.m_ShortSceneNameCandidates"/>
    /// </summary>
    public TBuilder AddToShortSceneNameCandidates(params string[] shortSceneNameCandidates)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ShortSceneNameCandidates = bp.m_ShortSceneNameCandidates ?? new string[0];
          bp.m_ShortSceneNameCandidates = CommonTool.Append(bp.m_ShortSceneNameCandidates, shortSceneNameCandidates);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="ScenesRoot.m_ShortSceneNameCandidates"/>
    /// </summary>
    public TBuilder RemoveFromShortSceneNameCandidates(params string[] shortSceneNameCandidates)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ShortSceneNameCandidates is null) { return; }
          bp.m_ShortSceneNameCandidates = bp.m_ShortSceneNameCandidates.Where(val => !shortSceneNameCandidates.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="ScenesRoot.m_ShortSceneNameCandidates"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromShortSceneNameCandidates(Func<string, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ShortSceneNameCandidates is null) { return; }
          bp.m_ShortSceneNameCandidates = bp.m_ShortSceneNameCandidates.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="ScenesRoot.m_ShortSceneNameCandidates"/>
    /// </summary>
    public TBuilder ClearShortSceneNameCandidates()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ShortSceneNameCandidates = new string[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="ScenesRoot.m_ShortSceneNameCandidates"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyShortSceneNameCandidates(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ShortSceneNameCandidates is null) { return; }
          bp.m_ShortSceneNameCandidates.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_ShortSceneNameCandidates is null)
      {
        Blueprint.m_ShortSceneNameCandidates = new string[0];
      }
    }
  }
}
