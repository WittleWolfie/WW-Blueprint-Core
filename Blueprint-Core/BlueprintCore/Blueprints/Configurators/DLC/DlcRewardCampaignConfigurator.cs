using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DLC;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.DLC
{
  /// <summary>
  /// Configurator for <see cref="BlueprintDlcRewardCampaign"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintDlcRewardCampaign))]
  public class DlcRewardCampaignConfigurator : BaseDlcRewardConfigurator<BlueprintDlcRewardCampaign, DlcRewardCampaignConfigurator>
  {
    private DlcRewardCampaignConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static DlcRewardCampaignConfigurator For(string name)
    {
      return new DlcRewardCampaignConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static DlcRewardCampaignConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintDlcRewardCampaign>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static DlcRewardCampaignConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintDlcRewardCampaign>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlcRewardCampaign.ScreenshotForImportSave"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DlcRewardCampaignConfigurator SetScreenshotForImportSave(Texture2D screenshotForImportSave)
    {
      ValidateParam(screenshotForImportSave);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.ScreenshotForImportSave = screenshotForImportSave;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDlcRewardCampaign.m_StartGamePreset"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startGamePreset"><see cref="BlueprintAreaPreset"/></param>
    [Generated]
    public DlcRewardCampaignConfigurator SetStartGamePreset(string startGamePreset)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_StartGamePreset = BlueprintTool.GetRef<BlueprintAreaPresetReference>(startGamePreset);
          });
    }
  }
}
