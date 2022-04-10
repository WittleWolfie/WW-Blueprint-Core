using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.TurnBasedModifiers;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums;
using Kingmaker.UI.UnitSettings.Blueprints;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.ActivatableAbilities.Restrictions;
using Kingmaker.UnitLogic.Class.Kineticist.ActivatableAbility;
using Kingmaker.UnitLogic.Commands.Base;
using System;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities
{
  /// <summary>
  /// Configurator for <see cref="BlueprintActivatableAbility"/>.
  /// </summary>
  /// <inheritdoc/>
  
  public class ActivatableAbilityConfigurator : BaseUnitFactConfigurator<BlueprintActivatableAbility, ActivatableAbilityConfigurator>
  {
    private ActivatableAbilityConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ActivatableAbilityConfigurator For(string name)
    {
      return new ActivatableAbilityConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ActivatableAbilityConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintActivatableAbility>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintActivatableAbility.m_Buff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    
    public ActivatableAbilityConfigurator SetBuff(string? buff)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintActivatableAbility.Group"/> (Auto Generated)
    /// </summary>
    
    public ActivatableAbilityConfigurator SetGroup(ActivatableAbilityGroup group)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Group = group;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintActivatableAbility.WeightInGroup"/> (Auto Generated)
    /// </summary>
    
    public ActivatableAbilityConfigurator SetWeightInGroup(int weightInGroup)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.WeightInGroup = weightInGroup;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintActivatableAbility.IsOnByDefault"/> (Auto Generated)
    /// </summary>
    
    public ActivatableAbilityConfigurator SetIsOnByDefault(bool isOnByDefault)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsOnByDefault = isOnByDefault;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintActivatableAbility.DeactivateIfCombatEnded"/> (Auto Generated)
    /// </summary>
    
    public ActivatableAbilityConfigurator SetDeactivateIfCombatEnded(bool deactivateIfCombatEnded)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DeactivateIfCombatEnded = deactivateIfCombatEnded;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintActivatableAbility.DeactivateAfterFirstRound"/> (Auto Generated)
    /// </summary>
    
    public ActivatableAbilityConfigurator SetDeactivateAfterFirstRound(bool deactivateAfterFirstRound)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DeactivateAfterFirstRound = deactivateAfterFirstRound;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintActivatableAbility.DeactivateImmediately"/> (Auto Generated)
    /// </summary>
    
    public ActivatableAbilityConfigurator SetDeactivateImmediately(bool deactivateImmediately)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DeactivateImmediately = deactivateImmediately;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintActivatableAbility.IsTargeted"/> (Auto Generated)
    /// </summary>
    
    public ActivatableAbilityConfigurator SetIsTargeted(bool isTargeted)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsTargeted = isTargeted;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintActivatableAbility.DeactivateIfOwnerDisabled"/> (Auto Generated)
    /// </summary>
    
    public ActivatableAbilityConfigurator SetDeactivateIfOwnerDisabled(bool deactivateIfOwnerDisabled)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DeactivateIfOwnerDisabled = deactivateIfOwnerDisabled;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintActivatableAbility.DeactivateIfOwnerUnconscious"/> (Auto Generated)
    /// </summary>
    
    public ActivatableAbilityConfigurator SetDeactivateIfOwnerUnconscious(bool deactivateIfOwnerUnconscious)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DeactivateIfOwnerUnconscious = deactivateIfOwnerUnconscious;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintActivatableAbility.OnlyInCombat"/> (Auto Generated)
    /// </summary>
    
    public ActivatableAbilityConfigurator SetOnlyInCombat(bool onlyInCombat)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OnlyInCombat = onlyInCombat;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintActivatableAbility.DoNotTurnOffOnRest"/> (Auto Generated)
    /// </summary>
    
    public ActivatableAbilityConfigurator SetDoNotTurnOffOnRest(bool doNotTurnOffOnRest)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DoNotTurnOffOnRest = doNotTurnOffOnRest;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintActivatableAbility.ActivationType"/> (Auto Generated)
    /// </summary>
    
    public ActivatableAbilityConfigurator SetActivationType(AbilityActivationType activationType)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ActivationType = activationType;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintActivatableAbility.m_ActivateWithUnitCommand"/> (Auto Generated)
    /// </summary>
    
    public ActivatableAbilityConfigurator SetActivateWithUnitCommand(UnitCommand.CommandType activateWithUnitCommand)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ActivateWithUnitCommand = activateWithUnitCommand;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintActivatableAbility.m_ActivateOnUnitAction"/> (Auto Generated)
    /// </summary>
    
    public ActivatableAbilityConfigurator SetActivateOnUnitAction(AbilityActivateOnUnitActionType activateOnUnitAction)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ActivateOnUnitAction = activateOnUnitAction;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintActivatableAbility.m_SelectTargetAbility"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="selectTargetAbility"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    
    public ActivatableAbilityConfigurator SetSelectTargetAbility(string? selectTargetAbility)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SelectTargetAbility = BlueprintTool.GetRef<BlueprintAbilityReference>(selectTargetAbility);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintActivatableAbility.ResourceAssetIds"/> (Auto Generated)
    /// </summary>
    
    public ActivatableAbilityConfigurator SetResourceAssetIds(string[]? resourceAssetIds)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ResourceAssetIds = resourceAssetIds;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintActivatableAbility.ResourceAssetIds"/> (Auto Generated)
    /// </summary>
    
    public ActivatableAbilityConfigurator AddToResourceAssetIds(params string[] resourceAssetIds)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ResourceAssetIds = CommonTool.Append(bp.ResourceAssetIds, resourceAssetIds ?? new string[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintActivatableAbility.ResourceAssetIds"/> (Auto Generated)
    /// </summary>
    
    public ActivatableAbilityConfigurator RemoveFromResourceAssetIds(params string[] resourceAssetIds)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ResourceAssetIds = bp.ResourceAssetIds.Where(item => !resourceAssetIds.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Adds <see cref="ActionPanelLogic"/> (Auto Generated)
    /// </summary>
    
    
    public ActivatableAbilityConfigurator AddActionPanelLogic(
        int priority = default,
        ConditionsBuilder? autoFillConditions = null,
        ConditionsBuilder? autoCastConditions = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ActionPanelLogic();
      component.Priority = priority;
      component.AutoFillConditions = autoFillConditions?.Build() ?? Constants.Empty.Conditions;
      component.AutoCastConditions = autoCastConditions?.Build() ?? Constants.Empty.Conditions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AbilityActivateWithUnitCommandInTurnBased"/> (Auto Generated)
    /// </summary>
    
    
    public ActivatableAbilityConfigurator AddAbilityActivateWithUnitCommandInTurnBased(
        UnitCommand.CommandType commandType = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AbilityActivateWithUnitCommandInTurnBased();
      component.CommandType = commandType;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RestrictionCanGatherPower"/> (Auto Generated)
    /// </summary>
    
    
    public ActivatableAbilityConfigurator AddRestrictionCanGatherPower(
        bool ignoreIfStarted = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RestrictionCanGatherPower();
      component.IgnoreIfStarted = ignoreIfStarted;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RestrictionCanUseKineticBlade"/> (Auto Generated)
    /// </summary>
    
    
    public ActivatableAbilityConfigurator AddRestrictionCanUseKineticBlade(
        bool ignoreIfStarted = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RestrictionCanUseKineticBlade();
      component.IgnoreIfStarted = ignoreIfStarted;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ActivatableAbilityResourceLogic"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="requiredResource"><see cref="Kingmaker.Blueprints.BlueprintAbilityResource"/></param>
    /// <param name="freeBlueprint"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public ActivatableAbilityConfigurator AddActivatableAbilityResourceLogic(
        ActivatableAbilityResourceLogic.ResourceSpendType spendType = default,
        string? requiredResource = null,
        string? freeBlueprint = null,
        WeaponCategory[]? categories = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ActivatableAbilityResourceLogic();
      component.SpendType = spendType;
      component.m_RequiredResource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(requiredResource);
      component.m_FreeBlueprint = BlueprintTool.GetRef<BlueprintUnitFactReference>(freeBlueprint);
      component.Categories = categories;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ActivatableAbilityUnitCommand"/> (Auto Generated)
    /// </summary>
    
    
    public ActivatableAbilityConfigurator AddActivatableAbilityUnitCommand(
        UnitCommand.CommandType type = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ActivatableAbilityUnitCommand();
      component.Type = type;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DeactivateImmediatelyIfNoAttacksThisRound"/> (Auto Generated)
    /// </summary>
    
    
    public ActivatableAbilityConfigurator AddDeactivateImmediatelyIfNoAttacksThisRound(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DeactivateImmediatelyIfNoAttacksThisRound();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="TurnOffImmediatelyWithUnitCommand"/> (Auto Generated)
    /// </summary>
    
    
    public ActivatableAbilityConfigurator AddTurnOffImmediatelyWithUnitCommand(
        UnitCommand.CommandType commandType = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TurnOffImmediatelyWithUnitCommand();
      component.CommandType = commandType;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RestrictionHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public ActivatableAbilityConfigurator AddRestrictionHasFact(
        string? feature = null,
        bool not = default,
        bool ignoreIfStarted = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RestrictionHasFact();
      component.m_Feature = BlueprintTool.GetRef<BlueprintUnitFactReference>(feature);
      component.Not = not;
      component.IgnoreIfStarted = ignoreIfStarted;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RestrictionHasPet"/> (Auto Generated)
    /// </summary>
    
    
    public ActivatableAbilityConfigurator AddRestrictionHasPet(
        PetType petType = default,
        bool not = default,
        bool ignoreIfStarted = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RestrictionHasPet();
      component.PetType = petType;
      component.Not = not;
      component.IgnoreIfStarted = ignoreIfStarted;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RestrictionHasUnitCondition"/> (Auto Generated)
    /// </summary>
    
    
    public ActivatableAbilityConfigurator AddRestrictionHasUnitCondition(
        UnitCondition condition = default,
        bool invert = default,
        bool ignoreIfStarted = default)
    {
      var component = new RestrictionHasUnitCondition();
      component.Condition = condition;
      component.Invert = invert;
      component.IgnoreIfStarted = ignoreIfStarted;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RestrictionKensaiWeapon"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass"/></param>
    /// <param name="chosenWeaponBlueprint"><see cref="Kingmaker.Blueprints.Classes.Selection.BlueprintParametrizedFeature"/></param>
    
    
    public ActivatableAbilityConfigurator AddRestrictionKensaiWeapon(
        string? characterClass = null,
        string? chosenWeaponBlueprint = null,
        bool ignoreIfStarted = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RestrictionKensaiWeapon();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(chosenWeaponBlueprint);
      component.IgnoreIfStarted = ignoreIfStarted;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RestrictionRangedWeapon"/> (Auto Generated)
    /// </summary>
    
    
    public ActivatableAbilityConfigurator AddRestrictionRangedWeapon(
        bool ignoreIfStarted = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RestrictionRangedWeapon();
      component.IgnoreIfStarted = ignoreIfStarted;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RestrictionUnitConditionUnlessFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact"/></param>
    
    
    public ActivatableAbilityConfigurator AddRestrictionUnitConditionUnlessFact(
        UnitCondition condition = default,
        string? checkedFact = null,
        bool ignoreIfStarted = default)
    {
      var component = new RestrictionUnitConditionUnlessFact();
      component.Condition = condition;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.IgnoreIfStarted = ignoreIfStarted;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RestrictionUnlockableFlag"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="neededFlag"><see cref="Kingmaker.Blueprints.BlueprintUnlockableFlag"/></param>
    
    
    public ActivatableAbilityConfigurator AddRestrictionUnlockableFlag(
        string? neededFlag = null,
        bool invert = default,
        bool ignoreIfStarted = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RestrictionUnlockableFlag();
      component.m_NeededFlag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(neededFlag);
      component.Invert = invert;
      component.IgnoreIfStarted = ignoreIfStarted;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="HideFeatureInInspect"/> (Auto Generated)
    /// </summary>
    
    
    public ActivatableAbilityConfigurator AddHideFeatureInInspect()
    {
      return AddComponent(new HideFeatureInInspect());
    }

    /// <summary>
    /// Adds <see cref="SwitchOffAtCombatEnd"/> (Auto Generated)
    /// </summary>
    
    
    public ActivatableAbilityConfigurator AddSwitchOffAtCombatEnd(
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SwitchOffAtCombatEnd();
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}
