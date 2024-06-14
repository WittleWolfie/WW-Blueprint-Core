//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Items;
using Kingmaker.UI.UnitSettings.Blueprints;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.ActivatableAbilities.Restrictions;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Class.Kineticist.ActivatableAbility;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintActivatableAbility"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseActivatableAbilityConfigurator<T, TBuilder>
    : BaseUnitFactConfigurator<T, TBuilder>
    where T : BlueprintActivatableAbility
    where TBuilder : BaseActivatableAbilityConfigurator<T, TBuilder>
  {
    protected BaseActivatableAbilityConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintActivatableAbility>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Buff = copyFrom.m_Buff;
          bp.Group = copyFrom.Group;
          bp.WeightInGroup = copyFrom.WeightInGroup;
          bp.IsOnByDefault = copyFrom.IsOnByDefault;
          bp.DeactivateIfCombatEnded = copyFrom.DeactivateIfCombatEnded;
          bp.DeactivateAfterFirstRound = copyFrom.DeactivateAfterFirstRound;
          bp.DeactivateImmediately = copyFrom.DeactivateImmediately;
          bp.IsTargeted = copyFrom.IsTargeted;
          bp.DeactivateIfOwnerDisabled = copyFrom.DeactivateIfOwnerDisabled;
          bp.DeactivateIfOwnerUnconscious = copyFrom.DeactivateIfOwnerUnconscious;
          bp.OnlyInCombat = copyFrom.OnlyInCombat;
          bp.DoNotTurnOffOnRest = copyFrom.DoNotTurnOffOnRest;
          bp.ActionBarAutoFillIgnored = copyFrom.ActionBarAutoFillIgnored;
          bp.IsRuntimeOnly = copyFrom.IsRuntimeOnly;
          bp.HiddenInUI = copyFrom.HiddenInUI;
          bp.ActivationType = copyFrom.ActivationType;
          bp.m_ActivateWithUnitCommand = copyFrom.m_ActivateWithUnitCommand;
          bp.m_ActivateOnUnitAction = copyFrom.m_ActivateOnUnitAction;
          bp.m_SelectTargetAbility = copyFrom.m_SelectTargetAbility;
          bp.ResourceAssetIds = copyFrom.ResourceAssetIds;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintActivatableAbility>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Buff = copyFrom.m_Buff;
          bp.Group = copyFrom.Group;
          bp.WeightInGroup = copyFrom.WeightInGroup;
          bp.IsOnByDefault = copyFrom.IsOnByDefault;
          bp.DeactivateIfCombatEnded = copyFrom.DeactivateIfCombatEnded;
          bp.DeactivateAfterFirstRound = copyFrom.DeactivateAfterFirstRound;
          bp.DeactivateImmediately = copyFrom.DeactivateImmediately;
          bp.IsTargeted = copyFrom.IsTargeted;
          bp.DeactivateIfOwnerDisabled = copyFrom.DeactivateIfOwnerDisabled;
          bp.DeactivateIfOwnerUnconscious = copyFrom.DeactivateIfOwnerUnconscious;
          bp.OnlyInCombat = copyFrom.OnlyInCombat;
          bp.DoNotTurnOffOnRest = copyFrom.DoNotTurnOffOnRest;
          bp.ActionBarAutoFillIgnored = copyFrom.ActionBarAutoFillIgnored;
          bp.IsRuntimeOnly = copyFrom.IsRuntimeOnly;
          bp.HiddenInUI = copyFrom.HiddenInUI;
          bp.ActivationType = copyFrom.ActivationType;
          bp.m_ActivateWithUnitCommand = copyFrom.m_ActivateWithUnitCommand;
          bp.m_ActivateOnUnitAction = copyFrom.m_ActivateOnUnitAction;
          bp.m_SelectTargetAbility = copyFrom.m_SelectTargetAbility;
          bp.ResourceAssetIds = copyFrom.ResourceAssetIds;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintActivatableAbility.m_Buff"/>
    /// </summary>
    ///
    /// <param name="buff">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetBuff(Blueprint<BlueprintBuffReference> buff)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Buff = buff?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintActivatableAbility.m_Buff"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBuff(Action<BlueprintBuffReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Buff is null) { return; }
          action.Invoke(bp.m_Buff);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintActivatableAbility.Group"/>
    /// </summary>
    public TBuilder SetGroup(ActivatableAbilityGroup group)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Group = group;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintActivatableAbility.WeightInGroup"/>
    /// </summary>
    public TBuilder SetWeightInGroup(int weightInGroup)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.WeightInGroup = weightInGroup;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintActivatableAbility.IsOnByDefault"/>
    /// </summary>
    public TBuilder SetIsOnByDefault(bool isOnByDefault = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsOnByDefault = isOnByDefault;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintActivatableAbility.DeactivateIfCombatEnded"/>
    /// </summary>
    public TBuilder SetDeactivateIfCombatEnded(bool deactivateIfCombatEnded = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DeactivateIfCombatEnded = deactivateIfCombatEnded;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintActivatableAbility.DeactivateAfterFirstRound"/>
    /// </summary>
    public TBuilder SetDeactivateAfterFirstRound(bool deactivateAfterFirstRound = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DeactivateAfterFirstRound = deactivateAfterFirstRound;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintActivatableAbility.DeactivateImmediately"/>
    /// </summary>
    public TBuilder SetDeactivateImmediately(bool deactivateImmediately = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DeactivateImmediately = deactivateImmediately;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintActivatableAbility.IsTargeted"/>
    /// </summary>
    public TBuilder SetIsTargeted(bool isTargeted = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsTargeted = isTargeted;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintActivatableAbility.DeactivateIfOwnerDisabled"/>
    /// </summary>
    public TBuilder SetDeactivateIfOwnerDisabled(bool deactivateIfOwnerDisabled = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DeactivateIfOwnerDisabled = deactivateIfOwnerDisabled;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintActivatableAbility.DeactivateIfOwnerUnconscious"/>
    /// </summary>
    public TBuilder SetDeactivateIfOwnerUnconscious(bool deactivateIfOwnerUnconscious = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DeactivateIfOwnerUnconscious = deactivateIfOwnerUnconscious;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintActivatableAbility.OnlyInCombat"/>
    /// </summary>
    public TBuilder SetOnlyInCombat(bool onlyInCombat = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OnlyInCombat = onlyInCombat;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintActivatableAbility.DoNotTurnOffOnRest"/>
    /// </summary>
    public TBuilder SetDoNotTurnOffOnRest(bool doNotTurnOffOnRest = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotTurnOffOnRest = doNotTurnOffOnRest;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintActivatableAbility.ActionBarAutoFillIgnored"/>
    /// </summary>
    public TBuilder SetActionBarAutoFillIgnored(bool actionBarAutoFillIgnored = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ActionBarAutoFillIgnored = actionBarAutoFillIgnored;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintActivatableAbility.IsRuntimeOnly"/>
    /// </summary>
    ///
    /// <param name="isRuntimeOnly">
    /// <para>
    /// InfoBox: Disables drag and drop for the ability icon in the action bar
    /// </para>
    /// </param>
    public TBuilder SetIsRuntimeOnly(bool isRuntimeOnly = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsRuntimeOnly = isRuntimeOnly;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintActivatableAbility.HiddenInUI"/>
    /// </summary>
    ///
    /// <param name="hiddenInUI">
    /// <para>
    /// InfoBox: Hides the ability in action bar and character info
    /// </para>
    /// </param>
    public TBuilder SetHiddenInUI(bool hiddenInUI = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HiddenInUI = hiddenInUI;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintActivatableAbility.ActivationType"/>
    /// </summary>
    public TBuilder SetActivationType(AbilityActivationType activationType)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ActivationType = activationType;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintActivatableAbility.m_ActivateWithUnitCommand"/>
    /// </summary>
    public TBuilder SetActivateWithUnitCommand(UnitCommand.CommandType activateWithUnitCommand)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ActivateWithUnitCommand = activateWithUnitCommand;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintActivatableAbility.m_ActivateOnUnitAction"/>
    /// </summary>
    public TBuilder SetActivateOnUnitAction(AbilityActivateOnUnitActionType activateOnUnitAction)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ActivateOnUnitAction = activateOnUnitAction;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintActivatableAbility.m_SelectTargetAbility"/>
    /// </summary>
    ///
    /// <param name="selectTargetAbility">
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetSelectTargetAbility(Blueprint<BlueprintAbilityReference> selectTargetAbility)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SelectTargetAbility = selectTargetAbility?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintActivatableAbility.m_SelectTargetAbility"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySelectTargetAbility(Action<BlueprintAbilityReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SelectTargetAbility is null) { return; }
          action.Invoke(bp.m_SelectTargetAbility);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintActivatableAbility.ResourceAssetIds"/>
    /// </summary>
    public TBuilder SetResourceAssetIds(params string[] resourceAssetIds)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ResourceAssetIds = resourceAssetIds;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintActivatableAbility.ResourceAssetIds"/>
    /// </summary>
    public TBuilder AddToResourceAssetIds(params string[] resourceAssetIds)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ResourceAssetIds = bp.ResourceAssetIds ?? new string[0];
          bp.ResourceAssetIds = CommonTool.Append(bp.ResourceAssetIds, resourceAssetIds);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintActivatableAbility.ResourceAssetIds"/>
    /// </summary>
    public TBuilder RemoveFromResourceAssetIds(params string[] resourceAssetIds)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ResourceAssetIds is null) { return; }
          bp.ResourceAssetIds = bp.ResourceAssetIds.Where(val => !resourceAssetIds.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintActivatableAbility.ResourceAssetIds"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromResourceAssetIds(Func<string, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ResourceAssetIds is null) { return; }
          bp.ResourceAssetIds = bp.ResourceAssetIds.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintActivatableAbility.ResourceAssetIds"/>
    /// </summary>
    public TBuilder ClearResourceAssetIds()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ResourceAssetIds = new string[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintActivatableAbility.ResourceAssetIds"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyResourceAssetIds(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ResourceAssetIds is null) { return; }
          bp.ResourceAssetIds.ForEach(action);
        });
    }

    /// <summary>
    /// Adds <see cref="ActionPanelLogic"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AasimarHaloToggleAbility</term><description>248bbb747c273684d9fdf2ed38935def</description></item>
    /// <item><term>MobilityUseAbility</term><description>4be5757b85af47545a5789f1d03abda9</description></item>
    /// <item><term>ViperFamiliarAbility</term><description>52b0d34465ad50545836fddd437cf5c9</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddActionPanelLogic(
        ConditionsBuilder? autoCastConditions = null,
        ConditionsBuilder? autoFillConditions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        int? priority = null)
    {
      var component = new ActionPanelLogic();
      component.AutoCastConditions = autoCastConditions?.Build() ?? component.AutoCastConditions;
      if (component.AutoCastConditions is null)
      {
        component.AutoCastConditions = Utils.Constants.Empty.Conditions;
      }
      component.AutoFillConditions = autoFillConditions?.Build() ?? component.AutoFillConditions;
      if (component.AutoFillConditions is null)
      {
        component.AutoFillConditions = Utils.Constants.Empty.Conditions;
      }
      component.Priority = priority ?? component.Priority;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddTriggerOnActivationChanged"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArchaeologistLuckAbility</term><description>12dc796147c42e04487fcad3aaa40cea</description></item>
    /// <item><term>InciteRageAllToggleAbility</term><description>32d247b6e6b65794ab47fc372c444a96</description></item>
    /// <item><term>StormCallToggleAbility</term><description>d5ee8a2e5bf46c549988e9b09a59acd4</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddTriggerOnActivationChanged(
        ActionsBuilder? actionList = null,
        AddTriggerOnActivationChanged.Stage? stage = null)
    {
      var component = new AddTriggerOnActivationChanged();
      component.m_ActionList = actionList?.Build() ?? component.m_ActionList;
      if (component.m_ActionList is null)
      {
        component.m_ActionList = Utils.Constants.Empty.Actions;
      }
      component.m_Stage = stage ?? component.m_Stage;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RestrictionCanGatherPower"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>GatherPowerModeHigh</term><description>104a9f275539abf44b594e9e36f71694</description></item>
    /// <item><term>GatherPowerModeLow</term><description>fd51172fef48b1442a88d3dfa4b03ee4</description></item>
    /// <item><term>GatherPowerModeMedium</term><description>38ee9e5fd534f7640baa198b16249fd6</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddRestrictionCanGatherPower(
        bool? ignoreIfStarted = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new RestrictionCanGatherPower();
      component.IgnoreIfStarted = ignoreIfStarted ?? component.IgnoreIfStarted;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RestrictionCanUseKineticBlade"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BladeboundBlackBladeAbilityLeft</term><description>65fd595a95a44cd986d765f4f01c1cfc</description></item>
    /// <item><term>KineticBladeIceBlastAbility</term><description>3f68b8bdd90ccb0428acd38b84934d30</description></item>
    /// <item><term>LivingGrimoireHolyBookAbilitySecondary</term><description>89dd193b6cc946b898667275a7c6731a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddRestrictionCanUseKineticBlade(
        bool? ignoreIfStarted = null,
        bool? ignoreKineticClass = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new RestrictionCanUseKineticBlade();
      component.IgnoreIfStarted = ignoreIfStarted ?? component.IgnoreIfStarted;
      component.IgnoreKineticClass = ignoreKineticClass ?? component.IgnoreKineticClass;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ActivatableAbilityMount"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>MountTargetSwitch</term><description>d340d820867cf9741903c9be9aed1ccc</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddActivatableAbilityMount(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new ActivatableAbilityMount();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ActivatableAbilityResourceLogic"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonAoOGazeAbility</term><description>3e2d25b97be14414b897fc97f2d76c9a</description></item>
    /// <item><term>InciteRageAllToggleAbility</term><description>32d247b6e6b65794ab47fc372c444a96</description></item>
    /// <item><term>WitchHexAuraOfPurityActivatableAbility</term><description>298edc3bc21e61044bba25f4e767cb8b</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="freeBlueprint">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="freeBlueprints">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="requiredResource">
    /// <para>
    /// Blueprint of type BlueprintAbilityResource. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="resourceCostDecreasingFacts">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="resourceCostIncreasingFacts">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="useListForFreeBlueprints">
    /// <para>
    /// InfoBox: If true it&amp;apos;s possible to choose a list of facts to make the resource free instead of the one.
    /// </para>
    /// </param>
    public TBuilder AddActivatableAbilityResourceLogic(
        WeaponCategory[]? categories = null,
        Blueprint<BlueprintUnitFactReference>? freeBlueprint = null,
        List<Blueprint<BlueprintUnitFactReference>>? freeBlueprints = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Blueprint<BlueprintAbilityResourceReference>? requiredResource = null,
        List<Blueprint<BlueprintUnitFactReference>>? resourceCostDecreasingFacts = null,
        List<Blueprint<BlueprintUnitFactReference>>? resourceCostIncreasingFacts = null,
        ActivatableAbilityResourceLogic.ResourceSpendType? spendType = null,
        bool? useListForFreeBlueprints = null)
    {
      var component = new ActivatableAbilityResourceLogic();
      component.Categories = categories ?? component.Categories;
      if (component.Categories is null)
      {
        component.Categories = new WeaponCategory[0];
      }
      component.m_FreeBlueprint = freeBlueprint?.Reference ?? component.m_FreeBlueprint;
      if (component.m_FreeBlueprint is null)
      {
        component.m_FreeBlueprint = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      component.m_FreeBlueprints = freeBlueprints?.Select(bp => bp.Reference)?.ToArray() ?? component.m_FreeBlueprints;
      if (component.m_FreeBlueprints is null)
      {
        component.m_FreeBlueprints = new BlueprintUnitFactReference[0];
      }
      component.m_RequiredResource = requiredResource?.Reference ?? component.m_RequiredResource;
      if (component.m_RequiredResource is null)
      {
        component.m_RequiredResource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(null);
      }
      component.m_ResourceCostDecreasingFacts = resourceCostDecreasingFacts?.Select(bp => bp.Reference)?.ToList() ?? component.m_ResourceCostDecreasingFacts;
      if (component.m_ResourceCostDecreasingFacts is null)
      {
        component.m_ResourceCostDecreasingFacts = new();
      }
      component.m_ResourceCostIncreasingFacts = resourceCostIncreasingFacts?.Select(bp => bp.Reference)?.ToList() ?? component.m_ResourceCostIncreasingFacts;
      if (component.m_ResourceCostIncreasingFacts is null)
      {
        component.m_ResourceCostIncreasingFacts = new();
      }
      component.SpendType = spendType ?? component.SpendType;
      component.m_UseListForFreeBlueprints = useListForFreeBlueprints ?? component.m_UseListForFreeBlueprints;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ActivatableAbilitySet"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ShifterChimeraAspectAcitvatableAbility</term><description>8646ef1b70d84a12b15969fbd46e5502</description></item>
    /// <item><term>ShifterChimeraAspectAcitvatableAbilityGreater</term><description>3dd2025ac4af4d6e8478d54b9eb9276c</description></item>
    /// <item><term>ShifterChimericFiendAcitvatableAbility</term><description>9ac607bac46e4f11becc39f00007ab6a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="setId">
    /// <para>
    /// InfoBox: The set id should be the same for * this component, * ActivatableAbilitySetSwitch component on the Buff of the ability, * ActivatableAbilitySetItem components on Buffs of abilities enlisted below.
    /// </para>
    /// </param>
    /// <param name="subordinateAbilities">
    /// <para>
    /// Blueprint of type BlueprintActivatableAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddActivatableAbilitySet(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        ActivatableAbilitySetId? setId = null,
        List<Blueprint<BlueprintActivatableAbilityReference>>? subordinateAbilities = null)
    {
      var component = new ActivatableAbilitySet();
      component.m_SetId = setId ?? component.m_SetId;
      component.m_SubordinateAbilities = subordinateAbilities?.Select(bp => bp.Reference)?.ToArray() ?? component.m_SubordinateAbilities;
      if (component.m_SubordinateAbilities is null)
      {
        component.m_SubordinateAbilities = new BlueprintActivatableAbilityReference[0];
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ActivatableAbilityUnitCommand"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcaneStrikeAbility</term><description>006c6015761e75e498026cd3cd88de7e</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddActivatableAbilityUnitCommand(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        UnitCommand.CommandType? type = null)
    {
      var component = new ActivatableAbilityUnitCommand();
      component.Type = type ?? component.Type;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ActivatableAbilityVariants"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AnimalFocusHunterActivatable</term><description>bf6bbf41ae5141b29e30307624b8e3d2</description></item>
    /// <item><term>LivingGrimoireSacredWordChoiceAbility</term><description>f068f20ec5274c82aa9cec0cd2835267</description></item>
    /// <item><term>SorcerousClawsAbility</term><description>35da2ec74ea147d3852662c878a38948</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="variants">
    /// <para>
    /// Blueprint of type BlueprintActivatableAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddActivatableAbilityVariants(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        List<Blueprint<BlueprintActivatableAbilityReference>>? variants = null)
    {
      var component = new ActivatableAbilityVariants();
      component.m_Variants = variants?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Variants;
      if (component.m_Variants is null)
      {
        component.m_Variants = new BlueprintActivatableAbilityReference[0];
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ActivationDisable"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AnimalFocusHunterActivatable</term><description>bf6bbf41ae5141b29e30307624b8e3d2</description></item>
    /// <item><term>LivingGrimoireSacredWordChoiceAbility</term><description>f068f20ec5274c82aa9cec0cd2835267</description></item>
    /// <item><term>SorcerousClawsAbility</term><description>35da2ec74ea147d3852662c878a38948</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddActivationDisable(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new ActivationDisable();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="DeactivateImmediatelyIfNoAttacksThisRound"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcaneStrikeAbility</term><description>006c6015761e75e498026cd3cd88de7e</description></item>
    /// <item><term>DivaStyleActivatableAbility</term><description>5fedded3684a40ca870c9b66b43f2e41</description></item>
    /// <item><term>ShaitanStyleToggleAbility</term><description>afa28b1723934561a4fc73e6ec07e5ed</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddDeactivateImmediatelyIfNoAttacksThisRound(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new DeactivateImmediatelyIfNoAttacksThisRound();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="DeactivateOnGripChanged"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SpellCombatAbility</term><description>8898a573e8a8a184b8186dbc3a26da74</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddDeactivateOnGripChanged(
        GripType? gripStyle = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new DeactivateOnGripChanged();
      component.GripStyle = gripStyle ?? component.GripStyle;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ShiftersFury"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ShifterFuryActivatableList</term><description>2d62be90202c41dc9a3618262b147f20</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="itemBlueprint">
    /// <para>
    /// Blueprint of type BlueprintActivatableAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddShiftersFury(
        Blueprint<BlueprintActivatableAbilityReference>? itemBlueprint = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new ShiftersFury();
      component.m_ItemBlueprint = itemBlueprint?.Reference ?? component.m_ItemBlueprint;
      if (component.m_ItemBlueprint is null)
      {
        component.m_ItemBlueprint = BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ShiftersFuryItemAbility"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ShifterFuryWeaponList</term><description>b4f41266d30c41b3a176a486a211ee03</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddShiftersFuryItemAbility(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new ShiftersFuryItemAbility();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TurnOffImmediatelyWithUnitCommand"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>MountTargetSwitch</term><description>d340d820867cf9741903c9be9aed1ccc</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTurnOffImmediatelyWithUnitCommand(
        UnitCommand.CommandType? commandType = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TurnOffImmediatelyWithUnitCommand();
      component.CommandType = commandType ?? component.CommandType;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RestrictionHasFact"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbilityWingsAngel</term><description>13143852b74718144ac4267b949615f0</description></item>
    /// <item><term>GuardedStanceToggleAbility</term><description>7517c892b30fdf643b33807a2f5abd31</description></item>
    /// <item><term>SorcerousClawsVicious</term><description>4f2e31f13b4d4a4eb7aa0ed17d02e765</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="feature">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddRestrictionHasFact(
        Blueprint<BlueprintUnitFactReference>? feature = null,
        bool? ignoreIfStarted = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? not = null)
    {
      var component = new RestrictionHasFact();
      component.m_Feature = feature?.Reference ?? component.m_Feature;
      if (component.m_Feature is null)
      {
        component.m_Feature = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      component.IgnoreIfStarted = ignoreIfStarted ?? component.IgnoreIfStarted;
      component.Not = not ?? component.Not;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RestrictionHasUnitCondition"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: AA restriction unit condition
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BloodragerStandartRageActivateableAbility</term><description>e3a0056eedac7754ca9a50603ba05177</description></item>
    /// <item><term>ResourcelessRageActivateableAbility</term><description>0f6afbc991b272f478d78cf5e3b5a395</description></item>
    /// <item><term>StonelordDefensiveStanceActivateableAbility</term><description>6a8ddcf2fbda4c1ba4d8eccd565db3f9</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddRestrictionHasUnitCondition(
        UnitCondition? condition = null,
        bool? ignoreIfStarted = null,
        bool? invert = null)
    {
      var component = new RestrictionHasUnitCondition();
      component.Condition = condition ?? component.Condition;
      component.IgnoreIfStarted = ignoreIfStarted ?? component.IgnoreIfStarted;
      component.Invert = invert ?? component.Invert;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RestrictionRangedWeapon"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: AA restriction unit condition
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BaneAnimalQuiverAbility</term><description>5a87e26a039902443980a9a8c877036b</description></item>
    /// <item><term>ForcefulPushArrowsQuiverAbility</term><description>771d81c322b197f449f83e121b33afd6</description></item>
    /// <item><term>WeakenArrowsQuiverAbility</term><description>c930416e9939be4489eea9d4e3b18984</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddRestrictionRangedWeapon(
        bool? ignoreIfStarted = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new RestrictionRangedWeapon();
      component.IgnoreIfStarted = ignoreIfStarted ?? component.IgnoreIfStarted;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RestrictionUnitConditionUnlessFact"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: AA restriction unit condition
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DefensiveStanceActivateableAbility</term><description>be68c660b41bc9247bcab727b10d2cd1</description></item>
    /// <item><term>StonelordDefensiveStanceActivateableAbility</term><description>6a8ddcf2fbda4c1ba4d8eccd565db3f9</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="checkedFact">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddRestrictionUnitConditionUnlessFact(
        Blueprint<BlueprintUnitFactReference>? checkedFact = null,
        UnitCondition? condition = null,
        bool? ignoreIfStarted = null)
    {
      var component = new RestrictionUnitConditionUnlessFact();
      component.m_CheckedFact = checkedFact?.Reference ?? component.m_CheckedFact;
      if (component.m_CheckedFact is null)
      {
        component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      component.Condition = condition ?? component.Condition;
      component.IgnoreIfStarted = ignoreIfStarted ?? component.IgnoreIfStarted;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RestrictionUnlockableFlag"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: AA restriction unit condition
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FaerieDragon_01_Ability</term><description>9344f002300f4c54ca2414ed5cfd957a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="neededFlag">
    /// <para>
    /// Blueprint of type BlueprintUnlockableFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddRestrictionUnlockableFlag(
        bool? ignoreIfStarted = null,
        bool? invert = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Blueprint<BlueprintUnlockableFlagReference>? neededFlag = null)
    {
      var component = new RestrictionUnlockableFlag();
      component.IgnoreIfStarted = ignoreIfStarted ?? component.IgnoreIfStarted;
      component.Invert = invert ?? component.Invert;
      component.m_NeededFlag = neededFlag?.Reference ?? component.m_NeededFlag;
      if (component.m_NeededFlag is null)
      {
        component.m_NeededFlag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="HideFeatureInInspect"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbadarFeature</term><description>6122dacf418611540a3c91e67197ee4e</description></item>
    /// <item><term>FightDefensivelyFeature</term><description>ca22afeb94442b64fb8536e7a9f7dc11</description></item>
    /// <item><term>WitchBetterHexProgression</term><description>38d01811fcb32444a8fe372c029fa0c6</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddHideFeatureInInspect()
    {
      return AddComponent(new HideFeatureInInspect());
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Buff is null)
      {
        Blueprint.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      if (Blueprint.m_SelectTargetAbility is null)
      {
        Blueprint.m_SelectTargetAbility = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      }
      if (Blueprint.ResourceAssetIds is null)
      {
        Blueprint.ResourceAssetIds = new string[0];
      }
    }
  }
}
