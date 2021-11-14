using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.TurnBasedModifiers;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.ElementsSystem;
using Kingmaker.UI.UnitSettings.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Commands.Base;
using System;

namespace BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities
{
  /// <summary>Configurator for <see cref="BlueprintActivatableAbility"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintActivatableAbility))]
  public class ActivatableAbilityConfigurator : BaseUnitFactConfigurator<BlueprintActivatableAbility, ActivatableAbilityConfigurator>
  {
     private ActivatableAbilityConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ActivatableAbilityConfigurator For(string name)
    {
      return new ActivatableAbilityConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ActivatableAbilityConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintActivatableAbility>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ActivatableAbilityConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintActivatableAbility>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Adds <see cref="ActionPanelLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ActionPanelLogic))]
    public ActivatableAbilityConfigurator AddActionPanelLogic(
        int Priority,
        ConditionsBuilder AutoFillConditions,
        ConditionsBuilder AutoCastConditions)
    {
      
      var component =  new ActionPanelLogic();
      component.Priority = Priority;
      component.AutoFillConditions = AutoFillConditions.Build();
      component.AutoCastConditions = AutoCastConditions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityActivateWithUnitCommandInTurnBased"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityActivateWithUnitCommandInTurnBased))]
    public ActivatableAbilityConfigurator AddAbilityActivateWithUnitCommandInTurnBased(
        UnitCommand.CommandType CommandType)
    {
      ValidateParam(CommandType);
      
      var component =  new AbilityActivateWithUnitCommandInTurnBased();
      component.CommandType = CommandType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ActivatableAbilityMount"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ActivatableAbilityMount))]
    public ActivatableAbilityConfigurator AddActivatableAbilityMount()
    {
      return AddComponent(new ActivatableAbilityMount());
    }

    /// <summary>
    /// Adds <see cref="TurnOffImmediatelyWithUnitCommand"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TurnOffImmediatelyWithUnitCommand))]
    public ActivatableAbilityConfigurator AddTurnOffImmediatelyWithUnitCommand(
        UnitCommand.CommandType CommandType)
    {
      ValidateParam(CommandType);
      
      var component =  new TurnOffImmediatelyWithUnitCommand();
      component.CommandType = CommandType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SwitchOffAtCombatEnd"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SwitchOffAtCombatEnd))]
    public ActivatableAbilityConfigurator AddSwitchOffAtCombatEnd()
    {
      return AddComponent(new SwitchOffAtCombatEnd());
    }
  }
}
