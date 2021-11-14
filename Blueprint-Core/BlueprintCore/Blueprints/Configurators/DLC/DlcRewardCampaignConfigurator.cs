using BlueprintCore.Blueprints.Configurators.DLC;
using BlueprintCore.Utils;
using Kingmaker.DLC;

namespace BlueprintCore.Blueprints.Configurators.DLC
{
  /// <summary>Configurator for <see cref="BlueprintDlcRewardCampaign"/>.</summary>
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
    public static DlcRewardCampaignConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintDlcRewardCampaign>(name, assetId);
      return For(name);
    }
  }
}
