//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintPersonageLimits"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BasePersonageLimitsConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintPersonageLimits
    where TBuilder : BasePersonageLimitsConfigurator<T, TBuilder>
  {
    protected BasePersonageLimitsConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintPersonageLimits>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_DopLimbMaxCount = copyFrom.m_DopLimbMaxCount;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintPersonageLimits>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_DopLimbMaxCount = copyFrom.m_DopLimbMaxCount;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintPersonageLimits.m_DopLimbMaxCount"/>
    /// </summary>
    public TBuilder SetDopLimbMaxCount(params BlueprintPersonageLimits.WeaponSlotCount[] dopLimbMaxCount)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(dopLimbMaxCount);
          bp.m_DopLimbMaxCount = dopLimbMaxCount;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintPersonageLimits.m_DopLimbMaxCount"/>
    /// </summary>
    public TBuilder AddToDopLimbMaxCount(params BlueprintPersonageLimits.WeaponSlotCount[] dopLimbMaxCount)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DopLimbMaxCount = bp.m_DopLimbMaxCount ?? new BlueprintPersonageLimits.WeaponSlotCount[0];
          bp.m_DopLimbMaxCount = CommonTool.Append(bp.m_DopLimbMaxCount, dopLimbMaxCount);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintPersonageLimits.m_DopLimbMaxCount"/>
    /// </summary>
    public TBuilder RemoveFromDopLimbMaxCount(params BlueprintPersonageLimits.WeaponSlotCount[] dopLimbMaxCount)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DopLimbMaxCount is null) { return; }
          bp.m_DopLimbMaxCount = bp.m_DopLimbMaxCount.Where(val => !dopLimbMaxCount.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintPersonageLimits.m_DopLimbMaxCount"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromDopLimbMaxCount(Func<BlueprintPersonageLimits.WeaponSlotCount, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DopLimbMaxCount is null) { return; }
          bp.m_DopLimbMaxCount = bp.m_DopLimbMaxCount.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintPersonageLimits.m_DopLimbMaxCount"/>
    /// </summary>
    public TBuilder ClearDopLimbMaxCount()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DopLimbMaxCount = new BlueprintPersonageLimits.WeaponSlotCount[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintPersonageLimits.m_DopLimbMaxCount"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyDopLimbMaxCount(Action<BlueprintPersonageLimits.WeaponSlotCount> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DopLimbMaxCount is null) { return; }
          bp.m_DopLimbMaxCount.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_DopLimbMaxCount is null)
      {
        Blueprint.m_DopLimbMaxCount = new BlueprintPersonageLimits.WeaponSlotCount[0];
      }
    }
  }
}
