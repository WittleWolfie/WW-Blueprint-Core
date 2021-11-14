using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.TurnBasedModifiers;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.UI.UnitSettings.Blueprints;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.ActivatableAbilities.Restrictions;
using Kingmaker.UnitLogic.Class.Kineticist.ActivatableAbility;
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
    /// Adds <see cref="RestrictionCanGatherPower"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RestrictionCanGatherPower))]
    public ActivatableAbilityConfigurator AddRestrictionCanGatherPower()
    {
      return AddComponent(new RestrictionCanGatherPower());
    }

    /// <summary>
    /// Adds <see cref="RestrictionCanUseKineticBlade"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RestrictionCanUseKineticBlade))]
    public ActivatableAbilityConfigurator AddRestrictionCanUseKineticBlade()
    {
      return AddComponent(new RestrictionCanUseKineticBlade());
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
    /// Adds <see cref="ActivatableAbilityResourceLogic"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_RequiredResource"><see cref="BlueprintAbilityResource"/></param>
    /// <param name="m_FreeBlueprint"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ActivatableAbilityResourceLogic))]
    public ActivatableAbilityConfigurator AddActivatableAbilityResourceLogic(
        ActivatableAbilityResourceLogic.ResourceSpendType SpendType,
        string m_RequiredResource,
        string m_FreeBlueprint,
        WeaponCategory[] Categories)
    {
      ValidateParam(SpendType);
      foreach (var item in Categories)
      {
        ValidateParam(item);
      }
      
      var component =  new ActivatableAbilityResourceLogic();
      component.SpendType = SpendType;
      component.m_RequiredResource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(m_RequiredResource);
      component.m_FreeBlueprint = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_FreeBlueprint);
      component.Categories = Categories;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ActivatableAbilityUnitCommand"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ActivatableAbilityUnitCommand))]
    public ActivatableAbilityConfigurator AddActivatableAbilityUnitCommand(
        UnitCommand.CommandType Type)
    {
      ValidateParam(Type);
      
      var component =  new ActivatableAbilityUnitCommand();
      component.Type = Type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DeactivateImmediatelyIfNoAttacksThisRound"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DeactivateImmediatelyIfNoAttacksThisRound))]
    public ActivatableAbilityConfigurator AddDeactivateImmediatelyIfNoAttacksThisRound()
    {
      return AddComponent(new DeactivateImmediatelyIfNoAttacksThisRound());
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
    /// Adds <see cref="RestrictionHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Feature"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(RestrictionHasFact))]
    public ActivatableAbilityConfigurator AddRestrictionHasFact(
        string m_Feature,
        bool Not)
    {
      
      var component =  new RestrictionHasFact();
      component.m_Feature = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_Feature);
      component.Not = Not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RestrictionHasUnitCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RestrictionHasUnitCondition))]
    public ActivatableAbilityConfigurator AddRestrictionHasUnitCondition(
        UnitCondition Condition,
        bool Invert)
    {
      ValidateParam(Condition);
      
      var component =  new RestrictionHasUnitCondition();
      component.Condition = Condition;
      component.Invert = Invert;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RestrictionKensaiWeapon"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CharacterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_ChosenWeaponBlueprint"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(RestrictionKensaiWeapon))]
    public ActivatableAbilityConfigurator AddRestrictionKensaiWeapon(
        string m_CharacterClass,
        string m_ChosenWeaponBlueprint)
    {
      
      var component =  new RestrictionKensaiWeapon();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_CharacterClass);
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(m_ChosenWeaponBlueprint);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RestrictionRangedWeapon"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RestrictionRangedWeapon))]
    public ActivatableAbilityConfigurator AddRestrictionRangedWeapon()
    {
      return AddComponent(new RestrictionRangedWeapon());
    }

    /// <summary>
    /// Adds <see cref="RestrictionUnitConditionUnlessFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(RestrictionUnitConditionUnlessFact))]
    public ActivatableAbilityConfigurator AddRestrictionUnitConditionUnlessFact(
        UnitCondition Condition,
        string m_CheckedFact)
    {
      ValidateParam(Condition);
      
      var component =  new RestrictionUnitConditionUnlessFact();
      component.Condition = Condition;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_CheckedFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RestrictionUnlockableFlag"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_NeededFlag"><see cref="BlueprintUnlockableFlag"/></param>
    [Generated]
    [Implements(typeof(RestrictionUnlockableFlag))]
    public ActivatableAbilityConfigurator AddRestrictionUnlockableFlag(
        string m_NeededFlag,
        bool Invert)
    {
      
      var component =  new RestrictionUnlockableFlag();
      component.m_NeededFlag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(m_NeededFlag);
      component.Invert = Invert;
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
