//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.Items.Equipment;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Armors;

namespace BlueprintCore.Blueprints.Configurators.Items.Armors
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemArmor"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseItemArmorConfigurator<T, TBuilder>
    : BaseItemEquipmentConfigurator<T, TBuilder>
    where T : BlueprintItemArmor
    where TBuilder : BaseItemArmorConfigurator<T, TBuilder>
  {
    protected BaseItemArmorConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
