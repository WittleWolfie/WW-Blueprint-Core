//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ResourceLinks;
using Kingmaker.Utility;
using Kingmaker.Visual.CharacterSystem;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Visual
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="KingmakerEquipmentEntity"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseKingmakerEquipmentEntityConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : KingmakerEquipmentEntity
    where TBuilder : BaseKingmakerEquipmentEntityConfigurator<T, TBuilder>
  {
    protected BaseKingmakerEquipmentEntityConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="KingmakerEquipmentEntity.m_MaleArray"/>
    /// </summary>
    public TBuilder SetMaleArray(params EquipmentEntityLink[] maleArray)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(maleArray);
          bp.m_MaleArray = maleArray;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="KingmakerEquipmentEntity.m_MaleArray"/>
    /// </summary>
    public TBuilder AddToMaleArray(params EquipmentEntityLink[] maleArray)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MaleArray = bp.m_MaleArray ?? new EquipmentEntityLink[0];
          bp.m_MaleArray = CommonTool.Append(bp.m_MaleArray, maleArray);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingmakerEquipmentEntity.m_MaleArray"/>
    /// </summary>
    public TBuilder RemoveFromMaleArray(params EquipmentEntityLink[] maleArray)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_MaleArray is null) { return; }
          bp.m_MaleArray = bp.m_MaleArray.Where(val => !maleArray.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingmakerEquipmentEntity.m_MaleArray"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromMaleArray(Func<EquipmentEntityLink, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_MaleArray is null) { return; }
          bp.m_MaleArray = bp.m_MaleArray.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="KingmakerEquipmentEntity.m_MaleArray"/>
    /// </summary>
    public TBuilder ClearMaleArray()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MaleArray = new EquipmentEntityLink[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="KingmakerEquipmentEntity.m_MaleArray"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyMaleArray(Action<EquipmentEntityLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_MaleArray is null) { return; }
          bp.m_MaleArray.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingmakerEquipmentEntity.m_FemaleArray"/>
    /// </summary>
    public TBuilder SetFemaleArray(params EquipmentEntityLink[] femaleArray)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(femaleArray);
          bp.m_FemaleArray = femaleArray;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="KingmakerEquipmentEntity.m_FemaleArray"/>
    /// </summary>
    public TBuilder AddToFemaleArray(params EquipmentEntityLink[] femaleArray)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_FemaleArray = bp.m_FemaleArray ?? new EquipmentEntityLink[0];
          bp.m_FemaleArray = CommonTool.Append(bp.m_FemaleArray, femaleArray);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingmakerEquipmentEntity.m_FemaleArray"/>
    /// </summary>
    public TBuilder RemoveFromFemaleArray(params EquipmentEntityLink[] femaleArray)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_FemaleArray is null) { return; }
          bp.m_FemaleArray = bp.m_FemaleArray.Where(val => !femaleArray.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingmakerEquipmentEntity.m_FemaleArray"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromFemaleArray(Func<EquipmentEntityLink, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_FemaleArray is null) { return; }
          bp.m_FemaleArray = bp.m_FemaleArray.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="KingmakerEquipmentEntity.m_FemaleArray"/>
    /// </summary>
    public TBuilder ClearFemaleArray()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_FemaleArray = new EquipmentEntityLink[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="KingmakerEquipmentEntity.m_FemaleArray"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyFemaleArray(Action<EquipmentEntityLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_FemaleArray is null) { return; }
          bp.m_FemaleArray.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingmakerEquipmentEntity.m_RaceDependent"/>
    /// </summary>
    public TBuilder SetRaceDependent(bool raceDependent = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_RaceDependent = raceDependent;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingmakerEquipmentEntity.m_RaceDependent"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRaceDependent(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_RaceDependent);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingmakerEquipmentEntity.m_RaceDependentArrays"/>
    /// </summary>
    public TBuilder SetRaceDependentArrays(params KingmakerEquipmentEntity.TwoLists[] raceDependentArrays)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(raceDependentArrays);
          bp.m_RaceDependentArrays = raceDependentArrays;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="KingmakerEquipmentEntity.m_RaceDependentArrays"/>
    /// </summary>
    public TBuilder AddToRaceDependentArrays(params KingmakerEquipmentEntity.TwoLists[] raceDependentArrays)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_RaceDependentArrays = bp.m_RaceDependentArrays ?? new KingmakerEquipmentEntity.TwoLists[0];
          bp.m_RaceDependentArrays = CommonTool.Append(bp.m_RaceDependentArrays, raceDependentArrays);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingmakerEquipmentEntity.m_RaceDependentArrays"/>
    /// </summary>
    public TBuilder RemoveFromRaceDependentArrays(params KingmakerEquipmentEntity.TwoLists[] raceDependentArrays)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_RaceDependentArrays is null) { return; }
          bp.m_RaceDependentArrays = bp.m_RaceDependentArrays.Where(val => !raceDependentArrays.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingmakerEquipmentEntity.m_RaceDependentArrays"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromRaceDependentArrays(Func<KingmakerEquipmentEntity.TwoLists, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_RaceDependentArrays is null) { return; }
          bp.m_RaceDependentArrays = bp.m_RaceDependentArrays.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="KingmakerEquipmentEntity.m_RaceDependentArrays"/>
    /// </summary>
    public TBuilder ClearRaceDependentArrays()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_RaceDependentArrays = new KingmakerEquipmentEntity.TwoLists[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="KingmakerEquipmentEntity.m_RaceDependentArrays"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyRaceDependentArrays(Action<KingmakerEquipmentEntity.TwoLists> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_RaceDependentArrays is null) { return; }
          bp.m_RaceDependentArrays.ForEach(action);
        });
    }
  }
}
