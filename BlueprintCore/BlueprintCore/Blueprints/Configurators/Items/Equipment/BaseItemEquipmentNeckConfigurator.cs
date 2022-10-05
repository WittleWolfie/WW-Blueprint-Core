//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Equipment;
using System;

namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemEquipmentNeck"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseItemEquipmentNeckConfigurator<T, TBuilder>
    : BaseItemEquipmentSimpleConfigurator<T, TBuilder>
    where T : BlueprintItemEquipmentNeck
    where TBuilder : BaseItemEquipmentNeckConfigurator<T, TBuilder>
  {
    protected BaseItemEquipmentNeckConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintItemEquipmentNeck>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    return Self;
    }
  }
}
