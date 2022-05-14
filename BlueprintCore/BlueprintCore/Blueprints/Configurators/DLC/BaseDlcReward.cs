//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DLC;

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
    protected BaseDlcRewardConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
