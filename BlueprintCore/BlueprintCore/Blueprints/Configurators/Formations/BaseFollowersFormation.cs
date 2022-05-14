//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Formations;

namespace BlueprintCore.Blueprints.Configurators.Formations
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="FollowersFormation"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseFollowersFormationConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : FollowersFormation
    where TBuilder : BaseFollowersFormationConfigurator<T, TBuilder>
  {
    protected BaseFollowersFormationConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
