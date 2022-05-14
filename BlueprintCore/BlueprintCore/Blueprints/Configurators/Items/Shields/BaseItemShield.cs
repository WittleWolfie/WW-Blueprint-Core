//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.Items.Equipment;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Shields;

namespace BlueprintCore.Blueprints.Configurators.Items.Shields
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemShield"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseItemShieldConfigurator<T, TBuilder>
    : BaseItemEquipmentHandConfigurator<T, TBuilder>
    where T : BlueprintItemShield
    where TBuilder : BaseItemShieldConfigurator<T, TBuilder>
  {
    protected BaseItemShieldConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
