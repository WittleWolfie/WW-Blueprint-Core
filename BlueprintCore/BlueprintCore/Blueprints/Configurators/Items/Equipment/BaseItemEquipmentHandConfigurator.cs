//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
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
    protected BaseItemEquipmentHandConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintItemEquipmentHand>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_VisualParameters = copyFrom.m_VisualParameters;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintItemEquipmentHand>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_VisualParameters = copyFrom.m_VisualParameters;
        });
    }

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
