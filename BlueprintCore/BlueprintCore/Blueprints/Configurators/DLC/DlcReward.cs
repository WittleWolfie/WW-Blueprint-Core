using BlueprintCore.Utils;
using Kingmaker.DLC;
using Kingmaker.Localization;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.DLC
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintDlcReward"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintDlcReward))]
  public abstract class BaseDlcRewardConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintDlcReward
      where TBuilder : BaseDlcRewardConfigurator<T, TBuilder>
  {
    protected BaseDlcRewardConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintDlcReward.Description"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetDescription(LocalizedString? description)
    {
      ValidateParam(description);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Description = description ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlcReward.m_IncludeAssetPaths"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetIncludeAssetPaths(BlueprintDlcReward.AssetPath[]? includeAssetPaths)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IncludeAssetPaths = includeAssetPaths;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDlcReward.m_IncludeAssetPaths"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder AddToIncludeAssetPaths(params BlueprintDlcReward.AssetPath[] includeAssetPaths)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IncludeAssetPaths = CommonTool.Append(bp.m_IncludeAssetPaths, includeAssetPaths ?? new BlueprintDlcReward.AssetPath[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDlcReward.m_IncludeAssetPaths"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder RemoveFromIncludeAssetPaths(params BlueprintDlcReward.AssetPath[] includeAssetPaths)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IncludeAssetPaths = bp.m_IncludeAssetPaths.Where(item => !includeAssetPaths.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlcReward.m_IncludeObjects"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetIncludeObjects(UnityEngine.Object[]? includeObjects)
    {
      ValidateParam(includeObjects);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IncludeObjects = includeObjects;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDlcReward.m_IncludeObjects"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder AddToIncludeObjects(params UnityEngine.Object[] includeObjects)
    {
      ValidateParam(includeObjects);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IncludeObjects = CommonTool.Append(bp.m_IncludeObjects, includeObjects ?? new UnityEngine.Object[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDlcReward.m_IncludeObjects"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder RemoveFromIncludeObjects(params UnityEngine.Object[] includeObjects)
    {
      ValidateParam(includeObjects);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IncludeObjects = bp.m_IncludeObjects.Where(item => !includeObjects.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlcReward.m_Dlcs"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetDlcs(List<BlueprintDlc>? dlcs)
    {
      ValidateParam(dlcs);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Dlcs = dlcs;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDlcReward.m_Dlcs"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder AddToDlcs(params BlueprintDlc[] dlcs)
    {
      ValidateParam(dlcs);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Dlcs.AddRange(dlcs.ToList() ?? new List<BlueprintDlc>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDlcReward.m_Dlcs"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder RemoveFromDlcs(params BlueprintDlc[] dlcs)
    {
      ValidateParam(dlcs);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Dlcs = bp.m_Dlcs.Where(item => !dlcs.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlcReward.m_IsAvailable"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetIsAvailable(bool? isAvailable)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IsAvailable = isAvailable;
          });
    }
  }

  /// <summary>
  /// Configurator for <see cref="BlueprintDlcReward"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintDlcReward))]
  public class DlcRewardConfigurator : BaseBlueprintConfigurator<BlueprintDlcReward, DlcRewardConfigurator>
  {
    private DlcRewardConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static DlcRewardConfigurator For(string name)
    {
      return new DlcRewardConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static DlcRewardConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintDlcReward>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlcReward.Description"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DlcRewardConfigurator SetDescription(LocalizedString? description)
    {
      ValidateParam(description);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Description = description ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlcReward.m_IncludeAssetPaths"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DlcRewardConfigurator SetIncludeAssetPaths(BlueprintDlcReward.AssetPath[]? includeAssetPaths)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IncludeAssetPaths = includeAssetPaths;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDlcReward.m_IncludeAssetPaths"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DlcRewardConfigurator AddToIncludeAssetPaths(params BlueprintDlcReward.AssetPath[] includeAssetPaths)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IncludeAssetPaths = CommonTool.Append(bp.m_IncludeAssetPaths, includeAssetPaths ?? new BlueprintDlcReward.AssetPath[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDlcReward.m_IncludeAssetPaths"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DlcRewardConfigurator RemoveFromIncludeAssetPaths(params BlueprintDlcReward.AssetPath[] includeAssetPaths)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IncludeAssetPaths = bp.m_IncludeAssetPaths.Where(item => !includeAssetPaths.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlcReward.m_IncludeObjects"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DlcRewardConfigurator SetIncludeObjects(UnityEngine.Object[]? includeObjects)
    {
      ValidateParam(includeObjects);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IncludeObjects = includeObjects;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDlcReward.m_IncludeObjects"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DlcRewardConfigurator AddToIncludeObjects(params UnityEngine.Object[] includeObjects)
    {
      ValidateParam(includeObjects);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IncludeObjects = CommonTool.Append(bp.m_IncludeObjects, includeObjects ?? new UnityEngine.Object[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDlcReward.m_IncludeObjects"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DlcRewardConfigurator RemoveFromIncludeObjects(params UnityEngine.Object[] includeObjects)
    {
      ValidateParam(includeObjects);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IncludeObjects = bp.m_IncludeObjects.Where(item => !includeObjects.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlcReward.m_Dlcs"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DlcRewardConfigurator SetDlcs(List<BlueprintDlc>? dlcs)
    {
      ValidateParam(dlcs);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Dlcs = dlcs;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintDlcReward.m_Dlcs"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DlcRewardConfigurator AddToDlcs(params BlueprintDlc[] dlcs)
    {
      ValidateParam(dlcs);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Dlcs.AddRange(dlcs.ToList() ?? new List<BlueprintDlc>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintDlcReward.m_Dlcs"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DlcRewardConfigurator RemoveFromDlcs(params BlueprintDlc[] dlcs)
    {
      ValidateParam(dlcs);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Dlcs = bp.m_Dlcs.Where(item => !dlcs.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlcReward.m_IsAvailable"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DlcRewardConfigurator SetIsAvailable(bool? isAvailable)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IsAvailable = isAvailable;
          });
    }
  }
}
