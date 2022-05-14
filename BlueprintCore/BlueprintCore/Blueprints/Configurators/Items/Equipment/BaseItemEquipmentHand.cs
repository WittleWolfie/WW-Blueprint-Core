//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Blueprints.Items.Weapons;
using System;

namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemEquipmentHand"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseItemEquipmentHandConfigurator<T, TBuilder>
    : BaseItemEquipmentConfigurator<T, TBuilder>
    where T : BlueprintItemEquipmentHand
    where TBuilder : BaseItemEquipmentHandConfigurator<T, TBuilder>
  {
    protected BaseItemEquipmentHandConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemEquipmentHand.m_VisualParameters"/>
    /// </summary>
    public TBuilder SetVisualParameters(WeaponVisualParameters visualParameters)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(visualParameters);
          bp.m_VisualParameters = visualParameters;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItemEquipmentHand.m_VisualParameters"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyVisualParameters(Action<WeaponVisualParameters> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_VisualParameters is null) { return; }
          action.Invoke(bp.m_VisualParameters);
        });
    }
  }
}
