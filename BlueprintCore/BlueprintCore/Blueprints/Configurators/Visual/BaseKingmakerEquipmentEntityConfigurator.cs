//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.ResourceLinks;
using Kingmaker.Utility;
using Kingmaker.Visual.CharacterSystem;
using System;
using System.Collections.Generic;
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

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<KingmakerEquipmentEntity>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_MaleArray = copyFrom.m_MaleArray;
          bp.m_FemaleArray = copyFrom.m_FemaleArray;
          bp.m_RaceDependent = copyFrom.m_RaceDependent;
          bp.m_RaceDependentArrays = copyFrom.m_RaceDependentArrays;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<KingmakerEquipmentEntity>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_MaleArray = copyFrom.m_MaleArray;
          bp.m_FemaleArray = copyFrom.m_FemaleArray;
          bp.m_RaceDependent = copyFrom.m_RaceDependent;
          bp.m_RaceDependentArrays = copyFrom.m_RaceDependentArrays;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingmakerEquipmentEntity.m_MaleArray"/>
    /// </summary>
    ///
    /// <param name="maleArray">
    /// You can pass in the animation using an EquipmentEntityLink or it's AssetId.
    /// </param>
    public TBuilder SetMaleArray(params AssetLink<EquipmentEntityLink>[] maleArray)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MaleArray = maleArray?.Select(entry => entry?.Get())?.ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="KingmakerEquipmentEntity.m_MaleArray"/>
    /// </summary>
    ///
    /// <param name="maleArray">
    /// You can pass in the animation using an EquipmentEntityLink or it's AssetId.
    /// </param>
    public TBuilder AddToMaleArray(params AssetLink<EquipmentEntityLink>[] maleArray)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MaleArray = bp.m_MaleArray ?? new EquipmentEntityLink[0];
          bp.m_MaleArray = CommonTool.Append(bp.m_MaleArray, maleArray?.Select(entry => entry?.Get()).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingmakerEquipmentEntity.m_MaleArray"/>
    /// </summary>
    ///
    /// <param name="maleArray">
    /// You can pass in the animation using an EquipmentEntityLink or it's AssetId.
    /// </param>
    public TBuilder RemoveFromMaleArray(params AssetLink<EquipmentEntityLink>[] maleArray)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_MaleArray is null) { return; }
          var convertedParams = maleArray.Select(entry => entry?.Get());
          bp.m_MaleArray = bp.m_MaleArray.Where(val => !convertedParams.Contains(val)).ToArray();
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
          bp.m_MaleArray = bp.m_MaleArray.Where(e => !predicate(e)).ToArray();
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
    ///
    /// <param name="femaleArray">
    /// You can pass in the animation using an EquipmentEntityLink or it's AssetId.
    /// </param>
    public TBuilder SetFemaleArray(params AssetLink<EquipmentEntityLink>[] femaleArray)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_FemaleArray = femaleArray?.Select(entry => entry?.Get())?.ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="KingmakerEquipmentEntity.m_FemaleArray"/>
    /// </summary>
    ///
    /// <param name="femaleArray">
    /// You can pass in the animation using an EquipmentEntityLink or it's AssetId.
    /// </param>
    public TBuilder AddToFemaleArray(params AssetLink<EquipmentEntityLink>[] femaleArray)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_FemaleArray = bp.m_FemaleArray ?? new EquipmentEntityLink[0];
          bp.m_FemaleArray = CommonTool.Append(bp.m_FemaleArray, femaleArray?.Select(entry => entry?.Get()).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingmakerEquipmentEntity.m_FemaleArray"/>
    /// </summary>
    ///
    /// <param name="femaleArray">
    /// You can pass in the animation using an EquipmentEntityLink or it's AssetId.
    /// </param>
    public TBuilder RemoveFromFemaleArray(params AssetLink<EquipmentEntityLink>[] femaleArray)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_FemaleArray is null) { return; }
          var convertedParams = femaleArray.Select(entry => entry?.Get());
          bp.m_FemaleArray = bp.m_FemaleArray.Where(val => !convertedParams.Contains(val)).ToArray();
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
          bp.m_FemaleArray = bp.m_FemaleArray.Where(e => !predicate(e)).ToArray();
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
          bp.m_RaceDependentArrays = bp.m_RaceDependentArrays.Where(e => !predicate(e)).ToArray();
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

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_MaleArray is null)
      {
        Blueprint.m_MaleArray = new EquipmentEntityLink[0];
      }
      if (Blueprint.m_FemaleArray is null)
      {
        Blueprint.m_FemaleArray = new EquipmentEntityLink[0];
      }
      if (Blueprint.m_RaceDependentArrays is null)
      {
        Blueprint.m_RaceDependentArrays = new KingmakerEquipmentEntity.TwoLists[0];
      }
    }
  }
}
