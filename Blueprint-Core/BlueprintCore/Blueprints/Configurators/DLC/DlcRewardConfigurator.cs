using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.DLC;

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
  }
}
