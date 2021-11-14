using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Area;
using Kingmaker.Designers.EventConditionActionSystem.Events;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums.Damage;
using System;
namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintLogicConnector"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintLogicConnector))]
  public abstract class BaseLogicConnectorConfigurator<T, TBuilder>
      : BaseFactConfigurator<T, TBuilder>
      where T : BlueprintLogicConnector
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseLogicConnectorConfigurator(string name) : base(name) { }



    /// <summary>
    /// Adds <see cref="DamageToMapObjectTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageToMapObjectTrigger))]
    public TBuilder AddDamageToMapObjectTrigger(
        ActionsBuilder Actions,
        bool CheckEnergyType,
        DamageEnergyType EnergyType,
        bool CheckPhysicalDamageForm,
        PhysicalDamageForm PhysicalDamageForm)
    {
      ValidateParam(CheckEnergyType);
      ValidateParam(EnergyType);
      ValidateParam(CheckPhysicalDamageForm);
      ValidateParam(PhysicalDamageForm);
      
      var component =  new DamageToMapObjectTrigger();
      component.Actions = Actions.Build();
      component.CheckEnergyType = CheckEnergyType;
      component.EnergyType = EnergyType;
      component.CheckPhysicalDamageForm = CheckPhysicalDamageForm;
      component.PhysicalDamageForm = PhysicalDamageForm;
      return AddComponent(component);
    }  }

  /// <summary>Configurator for <see cref="BlueprintLogicConnector"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintLogicConnector))]
  public class LogicConnectorConfigurator : BaseFactConfigurator<BlueprintLogicConnector, LogicConnectorConfigurator>
  {
     private LogicConnectorConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static LogicConnectorConfigurator For(string name)
    {
      return new LogicConnectorConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static LogicConnectorConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintLogicConnector>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static LogicConnectorConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintLogicConnector>(name, assetId);
      return For(name);
    }



    /// <summary>
    /// Adds <see cref="DamageToMapObjectTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageToMapObjectTrigger))]
    public LogicConnectorConfigurator AddDamageToMapObjectTrigger(
        ActionsBuilder Actions,
        bool CheckEnergyType,
        DamageEnergyType EnergyType,
        bool CheckPhysicalDamageForm,
        PhysicalDamageForm PhysicalDamageForm)
    {
      ValidateParam(CheckEnergyType);
      ValidateParam(EnergyType);
      ValidateParam(CheckPhysicalDamageForm);
      ValidateParam(PhysicalDamageForm);
      
      var component =  new DamageToMapObjectTrigger();
      component.Actions = Actions.Build();
      component.CheckEnergyType = CheckEnergyType;
      component.EnergyType = EnergyType;
      component.CheckPhysicalDamageForm = CheckPhysicalDamageForm;
      component.PhysicalDamageForm = PhysicalDamageForm;
      return AddComponent(component);
    }  }
}
