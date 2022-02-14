using BlueprintCore.Utils;
using Kingmaker.DLC;
using Kingmaker.Localization;
using System;
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
    /// Sets <see cref="BlueprintDlcReward.m_IsImportIntoMainCampaignRequired"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetIsImportIntoMainCampaignRequired(bool isImportIntoMainCampaignRequired)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IsImportIntoMainCampaignRequired = isImportIntoMainCampaignRequired;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlcReward.ImportIntoMainCampaignSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetImportIntoMainCampaignSettings(DlcSaveImportSettings importIntoMainCampaignSettings)
    {
      ValidateParam(importIntoMainCampaignSettings);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.ImportIntoMainCampaignSettings = importIntoMainCampaignSettings;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlcReward.m_IsImportFromMainCampaignRequired"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetIsImportFromMainCampaignRequired(bool isImportFromMainCampaignRequired)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IsImportFromMainCampaignRequired = isImportFromMainCampaignRequired;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlcReward.ImportFromMainCampaignSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetImportFromMainCampaignSettings(DlcSaveImportSettings importFromMainCampaignSettings)
    {
      ValidateParam(importFromMainCampaignSettings);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.ImportFromMainCampaignSettings = importFromMainCampaignSettings;
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
    /// Sets <see cref="BlueprintDlcReward.m_IsImportIntoMainCampaignRequired"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DlcRewardConfigurator SetIsImportIntoMainCampaignRequired(bool isImportIntoMainCampaignRequired)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IsImportIntoMainCampaignRequired = isImportIntoMainCampaignRequired;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlcReward.ImportIntoMainCampaignSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DlcRewardConfigurator SetImportIntoMainCampaignSettings(DlcSaveImportSettings importIntoMainCampaignSettings)
    {
      ValidateParam(importIntoMainCampaignSettings);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.ImportIntoMainCampaignSettings = importIntoMainCampaignSettings;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlcReward.m_IsImportFromMainCampaignRequired"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DlcRewardConfigurator SetIsImportFromMainCampaignRequired(bool isImportFromMainCampaignRequired)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IsImportFromMainCampaignRequired = isImportFromMainCampaignRequired;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlcReward.ImportFromMainCampaignSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DlcRewardConfigurator SetImportFromMainCampaignSettings(DlcSaveImportSettings importFromMainCampaignSettings)
    {
      ValidateParam(importFromMainCampaignSettings);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.ImportFromMainCampaignSettings = importFromMainCampaignSettings;
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
