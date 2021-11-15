using BlueprintCore.Utils;
using Kingmaker.DLC;
using Kingmaker.Localization;
using System;
using System.Linq;

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
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseDlcRewardConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintDlcReward.Description"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetDescription(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Description = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlcReward.m_IsImportRequired"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetIsImportRequired(bool value)
    {
      return OnConfigureInternal(bp => bp.m_IsImportRequired = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlcReward.ImportIntoMainCampaign"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetImportIntoMainCampaign(DlcImportSettings value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ImportIntoMainCampaign = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlcReward.ImportFromMainCampaign"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetImportFromMainCampaign(DlcImportSettings value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ImportFromMainCampaign = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDlcReward.m_Dlcs"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder AddToDlcs(params BlueprintDlc[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_Dlcs.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDlcReward.m_Dlcs"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder RemoveFromDlcs(params BlueprintDlc[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_Dlcs = bp.m_Dlcs.Where(item => !values.Contains(item)).ToList());
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlcReward.m_IsAvailable"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetIsAvailable(Nullable<bool> value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_IsAvailable = value);
    }
  }

  /// <summary>Configurator for <see cref="BlueprintDlcReward"/>.</summary>
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

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static DlcRewardConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintDlcReward>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static DlcRewardConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintDlcReward>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlcReward.Description"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DlcRewardConfigurator SetDescription(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Description = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlcReward.m_IsImportRequired"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DlcRewardConfigurator SetIsImportRequired(bool value)
    {
      return OnConfigureInternal(bp => bp.m_IsImportRequired = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlcReward.ImportIntoMainCampaign"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DlcRewardConfigurator SetImportIntoMainCampaign(DlcImportSettings value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ImportIntoMainCampaign = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlcReward.ImportFromMainCampaign"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DlcRewardConfigurator SetImportFromMainCampaign(DlcImportSettings value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ImportFromMainCampaign = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDlcReward.m_Dlcs"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DlcRewardConfigurator AddToDlcs(params BlueprintDlc[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_Dlcs.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDlcReward.m_Dlcs"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DlcRewardConfigurator RemoveFromDlcs(params BlueprintDlc[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_Dlcs = bp.m_Dlcs.Where(item => !values.Contains(item)).ToList());
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlcReward.m_IsAvailable"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DlcRewardConfigurator SetIsAvailable(Nullable<bool> value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_IsAvailable = value);
    }
  }
}
