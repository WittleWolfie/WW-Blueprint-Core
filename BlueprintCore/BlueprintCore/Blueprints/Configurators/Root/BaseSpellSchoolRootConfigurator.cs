//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Root
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="SpellSchoolRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseSpellSchoolRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : SpellSchoolRoot
    where TBuilder : BaseSpellSchoolRootConfigurator<T, TBuilder>
  {
    protected BaseSpellSchoolRootConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<SpellSchoolRoot>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_OppositeSchools = copyFrom.m_OppositeSchools;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<SpellSchoolRoot>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_OppositeSchools = copyFrom.m_OppositeSchools;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="SpellSchoolRoot.m_OppositeSchools"/>
    /// </summary>
    public TBuilder SetOppositeSchools(params SpellSchoolRoot.OppositePair[] oppositeSchools)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_OppositeSchools = oppositeSchools;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="SpellSchoolRoot.m_OppositeSchools"/>
    /// </summary>
    public TBuilder AddToOppositeSchools(params SpellSchoolRoot.OppositePair[] oppositeSchools)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_OppositeSchools = bp.m_OppositeSchools ?? new SpellSchoolRoot.OppositePair[0];
          bp.m_OppositeSchools = CommonTool.Append(bp.m_OppositeSchools, oppositeSchools);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="SpellSchoolRoot.m_OppositeSchools"/>
    /// </summary>
    public TBuilder RemoveFromOppositeSchools(params SpellSchoolRoot.OppositePair[] oppositeSchools)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_OppositeSchools is null) { return; }
          bp.m_OppositeSchools = bp.m_OppositeSchools.Where(val => !oppositeSchools.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="SpellSchoolRoot.m_OppositeSchools"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromOppositeSchools(Func<SpellSchoolRoot.OppositePair, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_OppositeSchools is null) { return; }
          bp.m_OppositeSchools = bp.m_OppositeSchools.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="SpellSchoolRoot.m_OppositeSchools"/>
    /// </summary>
    public TBuilder ClearOppositeSchools()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_OppositeSchools = new SpellSchoolRoot.OppositePair[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="SpellSchoolRoot.m_OppositeSchools"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyOppositeSchools(Action<SpellSchoolRoot.OppositePair> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_OppositeSchools is null) { return; }
          bp.m_OppositeSchools.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_OppositeSchools is null)
      {
        Blueprint.m_OppositeSchools = new SpellSchoolRoot.OppositePair[0];
      }
    }
  }
}
