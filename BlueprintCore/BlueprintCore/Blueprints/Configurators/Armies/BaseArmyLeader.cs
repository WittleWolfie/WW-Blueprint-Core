//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Armies;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintArmyLeader"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseArmyLeaderConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintArmyLeader
    where TBuilder : BaseArmyLeaderConfigurator<T, TBuilder>
  {
    protected BaseArmyLeaderConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
