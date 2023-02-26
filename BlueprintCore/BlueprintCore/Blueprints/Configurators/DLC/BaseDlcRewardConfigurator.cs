//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DLC;
using Kingmaker.Localization;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.DLC
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintDlcReward"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDlcRewardConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintDlcReward
    where TBuilder : BaseDlcRewardConfigurator<T, TBuilder>
  {
    protected BaseDlcRewardConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintDlcReward>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Description = copyFrom.Description;
          bp.m_IncludeAssetPaths = copyFrom.m_IncludeAssetPaths;
          bp.m_IncludeObjects = copyFrom.m_IncludeObjects;
          bp.IsRequiredInSaves = copyFrom.IsRequiredInSaves;
          bp.m_Dlcs = copyFrom.m_Dlcs;
          bp.m_IsAvailable = copyFrom.m_IsAvailable;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintDlcReward>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Description = copyFrom.Description;
          bp.m_IncludeAssetPaths = copyFrom.m_IncludeAssetPaths;
          bp.m_IncludeObjects = copyFrom.m_IncludeObjects;
          bp.IsRequiredInSaves = copyFrom.IsRequiredInSaves;
          bp.m_Dlcs = copyFrom.m_Dlcs;
          bp.m_IsAvailable = copyFrom.m_IsAvailable;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDlcReward.Description"/>
    /// </summary>
    ///
    /// <param name="description">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetDescription(LocalString description)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Description = description?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDlcReward.Description"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDescription(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Description is null) { return; }
          action.Invoke(bp.Description);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDlcReward.m_IncludeAssetPaths"/>
    /// </summary>
    public TBuilder SetIncludeAssetPaths(params BlueprintDlcReward.AssetPath[] includeAssetPaths)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IncludeAssetPaths = includeAssetPaths;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDlcReward.m_IncludeAssetPaths"/>
    /// </summary>
    public TBuilder AddToIncludeAssetPaths(params BlueprintDlcReward.AssetPath[] includeAssetPaths)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IncludeAssetPaths = bp.m_IncludeAssetPaths ?? new BlueprintDlcReward.AssetPath[0];
          bp.m_IncludeAssetPaths = CommonTool.Append(bp.m_IncludeAssetPaths, includeAssetPaths);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDlcReward.m_IncludeAssetPaths"/>
    /// </summary>
    public TBuilder RemoveFromIncludeAssetPaths(params BlueprintDlcReward.AssetPath[] includeAssetPaths)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_IncludeAssetPaths is null) { return; }
          bp.m_IncludeAssetPaths = bp.m_IncludeAssetPaths.Where(val => !includeAssetPaths.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDlcReward.m_IncludeAssetPaths"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromIncludeAssetPaths(Func<BlueprintDlcReward.AssetPath, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_IncludeAssetPaths is null) { return; }
          bp.m_IncludeAssetPaths = bp.m_IncludeAssetPaths.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDlcReward.m_IncludeAssetPaths"/>
    /// </summary>
    public TBuilder ClearIncludeAssetPaths()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IncludeAssetPaths = new BlueprintDlcReward.AssetPath[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDlcReward.m_IncludeAssetPaths"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyIncludeAssetPaths(Action<BlueprintDlcReward.AssetPath> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_IncludeAssetPaths is null) { return; }
          bp.m_IncludeAssetPaths.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDlcReward.m_IncludeObjects"/>
    /// </summary>
    public TBuilder SetIncludeObjects(params UnityEngine.Object[] includeObjects)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(includeObjects);
          bp.m_IncludeObjects = includeObjects;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDlcReward.m_IncludeObjects"/>
    /// </summary>
    public TBuilder AddToIncludeObjects(params UnityEngine.Object[] includeObjects)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IncludeObjects = bp.m_IncludeObjects ?? new UnityEngine.Object[0];
          bp.m_IncludeObjects = CommonTool.Append(bp.m_IncludeObjects, includeObjects);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDlcReward.m_IncludeObjects"/>
    /// </summary>
    public TBuilder RemoveFromIncludeObjects(params UnityEngine.Object[] includeObjects)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_IncludeObjects is null) { return; }
          bp.m_IncludeObjects = bp.m_IncludeObjects.Where(val => !includeObjects.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDlcReward.m_IncludeObjects"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromIncludeObjects(Func<UnityEngine.Object, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_IncludeObjects is null) { return; }
          bp.m_IncludeObjects = bp.m_IncludeObjects.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDlcReward.m_IncludeObjects"/>
    /// </summary>
    public TBuilder ClearIncludeObjects()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IncludeObjects = new UnityEngine.Object[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDlcReward.m_IncludeObjects"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyIncludeObjects(Action<UnityEngine.Object> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_IncludeObjects is null) { return; }
          bp.m_IncludeObjects.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDlcReward.IsRequiredInSaves"/>
    /// </summary>
    ///
    /// <param name="isRequiredInSaves">
    /// <para>
    /// Tooltip: After the reward is used the further saves won&amp;apos;t load if no DLC containing this reward is presented.
    /// </para>
    /// </param>
    public TBuilder SetIsRequiredInSaves(bool isRequiredInSaves = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsRequiredInSaves = isRequiredInSaves;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDlcReward.m_Dlcs"/>
    /// </summary>
    public TBuilder SetDlcs(params BlueprintDlc[] dlcs)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(dlcs);
          bp.m_Dlcs = dlcs.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDlcReward.m_Dlcs"/>
    /// </summary>
    public TBuilder AddToDlcs(params BlueprintDlc[] dlcs)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Dlcs = bp.m_Dlcs ?? new();
          bp.m_Dlcs.AddRange(dlcs);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDlcReward.m_Dlcs"/>
    /// </summary>
    public TBuilder RemoveFromDlcs(params BlueprintDlc[] dlcs)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Dlcs is null) { return; }
          bp.m_Dlcs = bp.m_Dlcs.Where(val => !dlcs.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDlcReward.m_Dlcs"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromDlcs(Func<BlueprintDlc, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Dlcs is null) { return; }
          bp.m_Dlcs = bp.m_Dlcs.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDlcReward.m_Dlcs"/>
    /// </summary>
    public TBuilder ClearDlcs()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Dlcs = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDlcReward.m_Dlcs"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyDlcs(Action<BlueprintDlc> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Dlcs is null) { return; }
          bp.m_Dlcs.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDlcReward.m_IsAvailable"/>
    /// </summary>
    public TBuilder SetIsAvailable(bool isAvailable)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IsAvailable = isAvailable;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDlcReward.m_IsAvailable"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIsAvailable(Action<bool?> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_IsAvailable);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Description is null)
      {
        Blueprint.Description = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_IncludeAssetPaths is null)
      {
        Blueprint.m_IncludeAssetPaths = new BlueprintDlcReward.AssetPath[0];
      }
      if (Blueprint.m_IncludeObjects is null)
      {
        Blueprint.m_IncludeObjects = new UnityEngine.Object[0];
      }
      if (Blueprint.m_Dlcs is null)
      {
        Blueprint.m_Dlcs = new();
      }
    }
  }
}
