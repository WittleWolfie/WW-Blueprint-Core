//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Equipment;
using System;

namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemEquipmentFeet"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseItemEquipmentFeetConfigurator<T, TBuilder>
    : BaseItemEquipmentSimpleConfigurator<T, TBuilder>
    where T : BlueprintItemEquipmentFeet
    where TBuilder : BaseItemEquipmentFeetConfigurator<T, TBuilder>
  {
    protected BaseItemEquipmentFeetConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintItemEquipmentFeet>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    return Self;
    }
  }
}
