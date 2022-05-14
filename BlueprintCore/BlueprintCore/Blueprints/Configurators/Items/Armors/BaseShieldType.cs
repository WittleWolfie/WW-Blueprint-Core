//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Armors;

namespace BlueprintCore.Blueprints.Configurators.Items.Armors
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintShieldType"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseShieldTypeConfigurator<T, TBuilder>
    : BaseArmorTypeConfigurator<T, TBuilder>
    where T : BlueprintShieldType
    where TBuilder : BaseShieldTypeConfigurator<T, TBuilder>
  {
    protected BaseShieldTypeConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
