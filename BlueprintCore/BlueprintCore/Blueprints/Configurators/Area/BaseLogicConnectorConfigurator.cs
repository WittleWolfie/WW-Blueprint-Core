//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Designers.EventConditionActionSystem.Events;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums.Damage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintLogicConnector"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseLogicConnectorConfigurator<T, TBuilder>
    : BaseFactConfigurator<T, TBuilder>
    where T : BlueprintLogicConnector
    where TBuilder : BaseLogicConnectorConfigurator<T, TBuilder>
  {
    protected BaseLogicConnectorConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintLogicConnector>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    return Self;
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintLogicConnector>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    return Self;
    }

    /// <summary>
    /// Adds <see cref="DamageToMapObjectTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Events/DamageToMapObjectTrigger
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Barrel_explosion</term><description>8fdc96985bf749dfb5f8bd9085d4aeda</description></item>
    /// <item><term>MachineDamage_Actions</term><description>3e522e59d3514dea90c56c7ecd6685a0</description></item>
    /// <item><term>TestDamagedMapobject</term><description>149d05c335f0cd24ca4a8866e968bb1d</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddDamageToMapObjectTrigger(
        ActionsBuilder? actions = null,
        bool? checkEnergyType = null,
        bool? checkPhysicalDamageForm = null,
        DamageEnergyType? energyType = null,
        PhysicalDamageForm? physicalDamageForm = null)
    {
      var component = new DamageToMapObjectTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.CheckEnergyType = checkEnergyType ?? component.CheckEnergyType;
      component.CheckPhysicalDamageForm = checkPhysicalDamageForm ?? component.CheckPhysicalDamageForm;
      component.EnergyType = energyType ?? component.EnergyType;
      component.PhysicalDamageForm = physicalDamageForm ?? component.PhysicalDamageForm;
      return AddComponent(component);
    }
  }
}
