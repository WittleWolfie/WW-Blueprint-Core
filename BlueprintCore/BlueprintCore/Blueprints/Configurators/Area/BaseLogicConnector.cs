//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Designers.EventConditionActionSystem.Events;
using Kingmaker.Enums.Damage;
using System;

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
    protected BaseLogicConnectorConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

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
    /// <item><term>FireDamage_Actions</term><description>209d33847e7d4a33a894f9de8350a9c1</description></item>
    /// <item><term>TestDamagedMapobject</term><description>149d05c335f0cd24ca4a8866e968bb1d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    public TBuilder AddDamageToMapObjectTrigger(
        ActionsBuilder? actions = null,
        bool? checkEnergyType = null,
        bool? checkPhysicalDamageForm = null,
        DamageEnergyType? energyType = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
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
      return AddUniqueComponent(component, mergeBehavior, merge);
    }
  }
}
