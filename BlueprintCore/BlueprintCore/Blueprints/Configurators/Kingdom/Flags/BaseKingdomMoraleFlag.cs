//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Flags;

namespace BlueprintCore.Blueprints.Configurators.Kingdom.Flags
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintKingdomMoraleFlag"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseKingdomMoraleFlagConfigurator<T, TBuilder>
    : BaseFactConfigurator<T, TBuilder>
    where T : BlueprintKingdomMoraleFlag
    where TBuilder : BaseKingdomMoraleFlagConfigurator<T, TBuilder>
  {
    protected BaseKingdomMoraleFlagConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
