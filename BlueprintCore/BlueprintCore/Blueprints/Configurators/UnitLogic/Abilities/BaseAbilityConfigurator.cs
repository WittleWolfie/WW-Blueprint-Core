//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Abilities.Restrictions.New;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using BlueprintCore.Utils.Types;
using Kingmaker.AI.Blueprints;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Blueprints.TurnBasedModifiers;
using Kingmaker.Craft;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Designers.Mechanics.Recommendations;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.UI.UnitSettings.Blueprints;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Abilities.Components.CasterCheckers;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.Class.Kineticist;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using Kingmaker.Visual.HitSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.UnitLogic.Abilities
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAbility"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAbilityConfigurator<T, TBuilder>
    : BaseUnitFactConfigurator<T, TBuilder>
    where T : BlueprintAbility
    where TBuilder : BaseAbilityConfigurator<T, TBuilder>
  {
    protected BaseAbilityConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.m_DefaultAiAction"/>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The provided AI Cast Spell blueprint should set <see cref="BlueprintAiCastSpell.m_Ability"/> to reference this ability.
    /// </para>
    /// </remarks>
    ///
    /// <param name="defaultAiAction">
    /// <para>
    /// Blueprint of type BlueprintAiCastSpell. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetDefaultAiAction(Blueprint<BlueprintAiCastSpell.Reference> defaultAiAction)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DefaultAiAction = defaultAiAction?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAbility.m_DefaultAiAction"/> by invoking the provided action.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The provided AI Cast Spell blueprint should set <see cref="BlueprintAiCastSpell.m_Ability"/> to reference this ability.
    /// </para>
    /// </remarks>
    public TBuilder ModifyDefaultAiAction(Action<BlueprintAiCastSpell.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DefaultAiAction is null) { return; }
          action.Invoke(bp.m_DefaultAiAction);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.Range"/>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use <see cref="SetCustomRange(Feet)"/> for AbilityRange.Custom.
    /// </para>
    /// </remarks>
    public TBuilder SetRange(AbilityRange range)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Range = range;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.m_Parent"/>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Set this to the base ability for all ability variants. See <see cref="AbilityVariants"/>.
    /// </para>
    /// </remarks>
    ///
    /// <param name="parent">
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
    public TBuilder SetParent(Blueprint<BlueprintAbilityReference> parent)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Parent = parent?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAbility.m_Parent"/> by invoking the provided action.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Set this to the base ability for all ability variants. See <see cref="AbilityVariants"/>.
    /// </para>
    /// </remarks>
    public TBuilder ModifyParent(Action<BlueprintAbilityReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Parent is null) { return; }
          action.Invoke(bp.m_Parent);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.Type"/>
    /// </summary>
    public TBuilder SetType(AbilityType type)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Type = type;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.IgnoreMinimalRangeLimit"/>
    /// </summary>
    public TBuilder SetIgnoreMinimalRangeLimit(bool ignoreMinimalRangeLimit = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IgnoreMinimalRangeLimit = ignoreMinimalRangeLimit;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.CustomRange"/>
    /// </summary>
    public TBuilder SetCustomRange(Feet customRange)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CustomRange = customRange;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAbility.CustomRange"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCustomRange(Action<Feet> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.CustomRange);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.ShowNameForVariant"/>
    /// </summary>
    ///
    /// <param name="showNameForVariant">
    /// <para>
    /// Tooltip: Включать имя данного спела в имя его варианта
    /// </para>
    /// </param>
    public TBuilder SetShowNameForVariant(bool showNameForVariant = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ShowNameForVariant = showNameForVariant;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.OnlyForAllyCaster"/>
    /// </summary>
    ///
    /// <param name="onlyForAllyCaster">
    /// <para>
    /// Tooltip: Применять опцию выше только, если кастер - IsPlayerFaction
    /// </para>
    /// </param>
    public TBuilder SetOnlyForAllyCaster(bool onlyForAllyCaster = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OnlyForAllyCaster = onlyForAllyCaster;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.CanTargetPoint"/>
    /// </summary>
    public TBuilder SetCanTargetPoint(bool canTargetPoint = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CanTargetPoint = canTargetPoint;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.CanTargetEnemies"/>
    /// </summary>
    public TBuilder SetCanTargetEnemies(bool canTargetEnemies = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CanTargetEnemies = canTargetEnemies;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.CanTargetFriends"/>
    /// </summary>
    ///
    /// <param name="canTargetFriends">
    /// <para>
    /// InfoBox: Allows to cast on allies. But does not prevent from casting on enemies if only selected
    /// </para>
    /// </param>
    public TBuilder SetCanTargetFriends(bool canTargetFriends = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CanTargetFriends = canTargetFriends;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.CanTargetSelf"/>
    /// </summary>
    public TBuilder SetCanTargetSelf(bool canTargetSelf = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CanTargetSelf = canTargetSelf;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.ShouldTurnToTarget"/>
    /// </summary>
    public TBuilder SetShouldTurnToTarget(bool shouldTurnToTarget = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ShouldTurnToTarget = shouldTurnToTarget;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.SpellResistance"/>
    /// </summary>
    public TBuilder SetSpellResistance(bool spellResistance = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SpellResistance = spellResistance;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.ActionBarAutoFillIgnored"/>
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
    /// Sets the value of <see cref="BlueprintAbility.Hidden"/>
    /// </summary>
    public TBuilder SetHidden(bool hidden = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Hidden = hidden;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.NeedEquipWeapons"/>
    /// </summary>
    public TBuilder SetNeedEquipWeapons(bool needEquipWeapons = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NeedEquipWeapons = needEquipWeapons;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.NotOffensive"/>
    /// </summary>
    public TBuilder SetNotOffensive(bool notOffensive = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NotOffensive = notOffensive;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.EffectOnAlly"/>
    /// </summary>
    public TBuilder SetEffectOnAlly(AbilityEffectOnUnit effectOnAlly)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.EffectOnAlly = effectOnAlly;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.EffectOnEnemy"/>
    /// </summary>
    public TBuilder SetEffectOnEnemy(AbilityEffectOnUnit effectOnEnemy)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.EffectOnEnemy = effectOnEnemy;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.Animation"/>
    /// </summary>
    public TBuilder SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle animation)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Animation = animation;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.HasFastAnimation"/>
    /// </summary>
    public TBuilder SetHasFastAnimation(bool hasFastAnimation = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HasFastAnimation = hasFastAnimation;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.m_TargetMapObjects"/>
    /// </summary>
    public TBuilder SetTargetMapObjects(bool targetMapObjects = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TargetMapObjects = targetMapObjects;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.ActionType"/>
    /// </summary>
    public TBuilder SetActionType(UnitCommand.CommandType actionType)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ActionType = actionType;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.AvailableMetamagic"/>
    /// </summary>
    public TBuilder SetAvailableMetamagic(params Metamagic[] availableMetamagic)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AvailableMetamagic = availableMetamagic.Aggregate((Metamagic) 0, (f1, f2) => f1 | f2);
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintAbility.AvailableMetamagic"/>
    /// </summary>
    public TBuilder AddToAvailableMetamagic(params Metamagic[] availableMetamagic)
    {
      return OnConfigureInternal(
        bp =>
        {
          availableMetamagic.ForEach(f => bp.AvailableMetamagic |= f);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAbility.AvailableMetamagic"/>
    /// </summary>
    public TBuilder RemoveFromAvailableMetamagic(params Metamagic[] availableMetamagic)
    {
      return OnConfigureInternal(
        bp =>
        {
          availableMetamagic.ForEach(f => bp.AvailableMetamagic &= ~f);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.m_IsFullRoundAction"/>
    /// </summary>
    public TBuilder SetIsFullRoundAction(bool isFullRoundAction = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IsFullRoundAction = isFullRoundAction;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.LocalizedDuration"/>
    /// </summary>
    ///
    /// <param name="localizedDuration">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetLocalizedDuration(LocalString localizedDuration)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LocalizedDuration = localizedDuration?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAbility.LocalizedDuration"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLocalizedDuration(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LocalizedDuration is null) { return; }
          action.Invoke(bp.LocalizedDuration);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.LocalizedSavingThrow"/>
    /// </summary>
    ///
    /// <param name="localizedSavingThrow">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetLocalizedSavingThrow(LocalString localizedSavingThrow)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LocalizedSavingThrow = localizedSavingThrow?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAbility.LocalizedSavingThrow"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLocalizedSavingThrow(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LocalizedSavingThrow is null) { return; }
          action.Invoke(bp.LocalizedSavingThrow);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.MaterialComponent"/>
    /// </summary>
    public TBuilder SetMaterialComponent(BlueprintAbility.MaterialComponentData materialComponent)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(materialComponent);
          bp.MaterialComponent = materialComponent;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAbility.MaterialComponent"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMaterialComponent(Action<BlueprintAbility.MaterialComponentData> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.MaterialComponent is null) { return; }
          action.Invoke(bp.MaterialComponent);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.DisableLog"/>
    /// </summary>
    public TBuilder SetDisableLog(bool disableLog = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DisableLog = disableLog;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.ResourceAssetIds"/>
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
    /// Adds to the contents of <see cref="BlueprintAbility.ResourceAssetIds"/>
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
    /// Removes elements from <see cref="BlueprintAbility.ResourceAssetIds"/>
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
    /// Removes elements from <see cref="BlueprintAbility.ResourceAssetIds"/> that match the provided predicate.
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
    /// Removes all elements from <see cref="BlueprintAbility.ResourceAssetIds"/>
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
    /// Modifies <see cref="BlueprintAbility.ResourceAssetIds"/> by invoking the provided action on each element.
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
    /// Sets the value of <see cref="BlueprintAbility.m_SpellComponent"/>
    /// </summary>
    public TBuilder SetSpellComponent(Cacheable<SpellComponent> spellComponent)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SpellComponent = spellComponent;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAbility.m_SpellComponent"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySpellComponent(Action<Cacheable<SpellComponent>> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_SpellComponent);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.m_AbilityIsFullRoundInTurnBased"/>
    /// </summary>
    public TBuilder SetAbilityIsFullRoundInTurnBased(Cacheable<AbilityIsFullRoundInTurnBased> abilityIsFullRoundInTurnBased)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AbilityIsFullRoundInTurnBased = abilityIsFullRoundInTurnBased;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAbility.m_AbilityIsFullRoundInTurnBased"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAbilityIsFullRoundInTurnBased(Action<Cacheable<AbilityIsFullRoundInTurnBased>> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_AbilityIsFullRoundInTurnBased);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.m_StickyTouch"/>
    /// </summary>
    public TBuilder SetStickyTouch(Cacheable<AbilityEffectStickyTouch> stickyTouch)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_StickyTouch = stickyTouch;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAbility.m_StickyTouch"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyStickyTouch(Action<Cacheable<AbilityEffectStickyTouch>> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_StickyTouch);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.m_AbilityVariants"/>
    /// </summary>
    public TBuilder SetAbilityVariants(Cacheable<AbilityVariants> abilityVariants)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AbilityVariants = abilityVariants;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAbility.m_AbilityVariants"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAbilityVariants(Action<Cacheable<AbilityVariants>> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_AbilityVariants);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.m_AbilityShadowSpell"/>
    /// </summary>
    public TBuilder SetAbilityShadowSpell(Cacheable<AbilityShadowSpell> abilityShadowSpell)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AbilityShadowSpell = abilityShadowSpell;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAbility.m_AbilityShadowSpell"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAbilityShadowSpell(Action<Cacheable<AbilityShadowSpell>> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_AbilityShadowSpell);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.m_AbilityKineticist"/>
    /// </summary>
    public TBuilder SetAbilityKineticist(Cacheable<AbilityKineticist> abilityKineticist)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AbilityKineticist = abilityKineticist;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAbility.m_AbilityKineticist"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAbilityKineticist(Action<Cacheable<AbilityKineticist>> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_AbilityKineticist);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.m_HasVariants"/>
    /// </summary>
    public TBuilder SetHasVariants(bool hasVariants)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_HasVariants = hasVariants;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAbility.m_HasVariants"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHasVariants(Action<bool?> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_HasVariants);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.m_IsCantrip"/>
    /// </summary>
    public TBuilder SetIsCantrip(bool isCantrip)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IsCantrip = isCantrip;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAbility.m_IsCantrip"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIsCantrip(Action<bool?> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_IsCantrip);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbility.m_SpellDescriptor"/>
    /// </summary>
    public TBuilder SetSpellDescriptor(Nullable<SpellDescriptor> spellDescriptor)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SpellDescriptor = spellDescriptor;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAbility.m_SpellDescriptor"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySpellDescriptor(Action<SpellDescriptor?> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_SpellDescriptor);
        });
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterAlignment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AuraOfJusticeAbility</term><description>7a4f0c48829952e47bb1fd1e4e9da83a</description></item>
    /// <item><term>LayOnHandsOthers</term><description>caae1dc6fcf7b37408686971ee27db13</description></item>
    /// <item><term>WeaponBondSwitchAbility</term><description>7ff088ab58c69854b82ea95c2b0e35b4</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="ignoreFact">
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
    public TBuilder AddAbilityCasterAlignment(
        AlignmentMaskType? alignment = null,
        Blueprint<BlueprintUnitFactReference>? ignoreFact = null)
    {
      var component = new AbilityCasterAlignment();
      component.Alignment = alignment ?? component.Alignment;
      component.m_IgnoreFact = ignoreFact?.Reference ?? component.m_IgnoreFact;
      if (component.m_IgnoreFact is null)
      {
        component.m_IgnoreFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterHasChosenWeapon"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DazzlingDisplayAction</term><description>5f3126d4120b2b244a95cb2ec23d69fb</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="chosenWeaponFeature">
    /// <para>
    /// Blueprint of type BlueprintParametrizedFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="ignoreWeaponFact">
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
    public TBuilder AddAbilityCasterHasChosenWeapon(
        Blueprint<BlueprintParametrizedFeatureReference> chosenWeaponFeature,
        Blueprint<BlueprintUnitFactReference>? ignoreWeaponFact = null)
    {
      var component = new AbilityCasterHasChosenWeapon();
      component.m_ChosenWeaponFeature = chosenWeaponFeature?.Reference;
      component.m_IgnoreWeaponFact = ignoreWeaponFact?.Reference ?? component.m_IgnoreWeaponFact;
      if (component.m_IgnoreWeaponFact is null)
      {
        component.m_IgnoreWeaponFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterHasWeaponWithRangeType"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DivineHunterBondSwitchAbility</term><description>8b405b057dc5051448e20041bd366592</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddAbilityCasterHasWeaponWithRangeType(
        WeaponRangeType rangeType)
    {
      var component = new AbilityCasterHasWeaponWithRangeType();
      component.RangeType = rangeType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityEffectMiss"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbandonedKeep_AcidTrap</term><description>e7dadeb8b1d78a341bb4357b502da424</description></item>
    /// <item><term>ConcentratedAcidFlaskAbility</term><description>3b3cbf88432eef046afd627d2b67142b</description></item>
    /// <item><term>TanglefootBomb</term><description>526aa6319e9174e4ab2026e0f299b011</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityEffectMiss(
        ActionsBuilder missAction,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? useTargetSelector = null)
    {
      var component = new AbilityEffectMiss();
      component.MissAction = missAction?.Build();
      component.UseTargetSelector = useTargetSelector ?? component.UseTargetSelector;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityEffectRunAction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>1_FirstDeathAbility</term><description>4445d9d1c21141c6a0bb24baf373ef78</description></item>
    /// <item><term>HurricaneBow</term><description>3e9d1119d43d07c4c8ba9ebfd1671952</description></item>
    /// <item><term>ZoneOfPredetermination</term><description>756f1d07f9ae29448888ecf016fa40a7</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityEffectRunAction(
        ActionsBuilder actions,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        SavingThrowType? savingThrowType = null)
    {
      var component = new AbilityEffectRunAction();
      component.Actions = actions?.Build();
      component.SavingThrowType = savingThrowType ?? component.SavingThrowType;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityExecuteActionOnCast"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Ability/ExecuteActions
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcidBreathSpell_Cutscene</term><description>1153db4515d4f2b4188a13336930c7cb</description></item>
    /// <item><term>GeniekindEfreeti</term><description>a4864f723e1700d4785ac5ad9aefc5f2</description></item>
    /// <item><term>WitchOfTheVeilShroudedStepAbility8</term><description>5713b048d3a24959b7a27eac48e69943</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddAbilityExecuteActionOnCast(
        ActionsBuilder actions,
        ConditionsBuilder? conditions = null)
    {
      var component = new AbilityExecuteActionOnCast();
      component.Actions = actions?.Build();
      component.Conditions = conditions?.Build() ?? component.Conditions;
      if (component.Conditions is null)
      {
        component.Conditions = Utils.Constants.Empty.Conditions;
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityVariants"/>
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// This ability should be the parent as defined in <see cref="BlueprintAbility.m_Parent"/> for each variant.
    /// </para>
    /// <para>
    /// If you remove a variant be sure to clear <see cref="BlueprintAbility.m_Parent"/> for that ability. You can set it to <c>BlueprintTool.GetRef&lt;BlueprintAbilityReference&gt;(null)</c>.
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbsoluteOrder</term><description>b1723a0239d428243a1be2299696eb85</description></item>
    /// <item><term>MadnessDomainBaseAbility</term><description>9246020fe13095346946ff3101d9f60d</description></item>
    /// <item><term>WitchHexRegenerativeSinewAbility</term><description>40d201c6fbbb46e46a63dec8508de65a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="variants">
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
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityVariants(
        List<Blueprint<BlueprintAbilityReference>> variants,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityVariants();
      component.m_Variants = variants?.Select(bp => bp.Reference)?.ToArray();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ContextRankConfig"/>
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Use <see cref="Utils.Types.ContextRankConfigs"/> to create the ContextRankConfig component.
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>5_DeadStage_AcidBuff</term><description>96afbbab53c34c549a5313a1f7aed13b</description></item>
    /// <item><term>HellsSealVariantDevouringFlamesBuff</term><description>5617dbbb3890e2f4b96b47318c5c438b</description></item>
    /// <item><term>ZoneOfPredeterminationArea</term><description>1ff4dfed4f7eb504fa0447e93d1bcf64</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddContextRankConfig(ContextRankConfig component)
    {
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationBaseAttackPart"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcaneStrikeFeature</term><description>0ab2f21a922feee4dab116238e3150b4</description></item>
    /// <item><term>PowerAttackFeature</term><description>9972f33f977fc724c838e59641b2fca5</description></item>
    /// <item><term>WeaponFocus</term><description>1e1f627d26ad36f43bbd26cc2bf8ac7e</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddRecommendationBAB(
        float minPart,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? notRecommendIfHigher = null)
    {
      var component = new RecommendationBaseAttackPart();
      component.MinPart = minPart;
      component.NotRecommendIfHigher = notRecommendIfHigher ?? component.NotRecommendIfHigher;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RecommendationBaseAttackPart"/>
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Sets MinPart to 0.45
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcaneStrikeFeature</term><description>0ab2f21a922feee4dab116238e3150b4</description></item>
    /// <item><term>PowerAttackFeature</term><description>9972f33f977fc724c838e59641b2fca5</description></item>
    /// <item><term>WeaponFocus</term><description>1e1f627d26ad36f43bbd26cc2bf8ac7e</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddRecommendationHalfBAB(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? notRecommendIfHigher = null)
    {
      var component = new RecommendationBaseAttackPart();
      component.NotRecommendIfHigher = notRecommendIfHigher ?? component.NotRecommendIfHigher;
      component.MinPart = 0.45f;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RecommendationBaseAttackPart"/>
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Sets MinPart to 0.7
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcaneStrikeFeature</term><description>0ab2f21a922feee4dab116238e3150b4</description></item>
    /// <item><term>PowerAttackFeature</term><description>9972f33f977fc724c838e59641b2fca5</description></item>
    /// <item><term>WeaponFocus</term><description>1e1f627d26ad36f43bbd26cc2bf8ac7e</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddRecommendationThreeQuartersBAB(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? notRecommendIfHigher = null)
    {
      var component = new RecommendationBaseAttackPart();
      component.NotRecommendIfHigher = notRecommendIfHigher ?? component.NotRecommendIfHigher;
      component.MinPart = 0.7f;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RecommendationBaseAttackPart"/>
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Sets MinPart to 0.95
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcaneStrikeFeature</term><description>0ab2f21a922feee4dab116238e3150b4</description></item>
    /// <item><term>PowerAttackFeature</term><description>9972f33f977fc724c838e59641b2fca5</description></item>
    /// <item><term>WeaponFocus</term><description>1e1f627d26ad36f43bbd26cc2bf8ac7e</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddRecommendationFullBAB(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? notRecommendIfHigher = null)
    {
      var component = new RecommendationBaseAttackPart();
      component.NotRecommendIfHigher = notRecommendIfHigher ?? component.NotRecommendIfHigher;
      component.MinPart = 0.95f;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RecommendationCompanionBoon"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CompanionBoon</term><description>8fc01f06eab4dd946baa5bc658cac556</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="companionRank">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddRecommendationCompanionBoon(
        Blueprint<BlueprintFeatureReference> companionRank)
    {
      var component = new RecommendationCompanionBoon();
      component.m_CompanionRank = companionRank?.Reference;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationHasFeature"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AgileManeuvers</term><description>197306972c98bb843af738dc7529a7ac</description></item>
    /// <item><term>ShieldBashFeature</term><description>121811173a614534e8720d7550aae253</description></item>
    /// <item><term>WeaponSpecializationGreater</term><description>7cf5edc65e785a24f9cf93af987d66b3</description></item>
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
    public TBuilder AddRecommendationHasFeature(
        Blueprint<BlueprintUnitFactReference> feature,
        bool? mandatory = null)
    {
      var component = new RecommendationHasFeature();
      component.m_Feature = feature?.Reference;
      component.Mandatory = mandatory ?? component.Mandatory;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationNoFeatFromGroup"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcidArrow</term><description>9a46dfd390f943647ab4395fc997936d</description></item>
    /// <item><term>HideousLaughter</term><description>fd4d9fd7f87575d47aafe2a64a6e2d8d</description></item>
    /// <item><term>WhiteMageCureLightWoundsCast</term><description>83d6d8f4c4d296941838086f60485fb7</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="features">
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
    public TBuilder AddRecommendationNoFeatFromGroup(
        List<Blueprint<BlueprintUnitFactReference>> features,
        bool? goodIfNoFeature = null)
    {
      var component = new RecommendationNoFeatFromGroup();
      component.m_Features = features?.Select(bp => bp.Reference)?.ToArray();
      component.GoodIfNoFeature = goodIfNoFeature ?? component.GoodIfNoFeature;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationRequiresSpellbookSource"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcaneArmorMastery</term><description>453f5181a5ed3a445abfa3bcd3f4ac0c</description></item>
    /// <item><term>ArcaneArmorTraining</term><description>1a0298abacb6e0f45b7e28553e99e76c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder RecommendationRequiresSpellbookSource(
        bool? alchemist = null,
        bool? arcane = null,
        bool? divine = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new RecommendationRequiresSpellbookSource();
      component.Alchemist = alchemist ?? component.Alchemist;
      component.Arcane = arcane ?? component.Arcane;
      component.Divine = divine ?? component.Divine;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RecommendationRequiresSpellbookSource"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcaneArmorMastery</term><description>453f5181a5ed3a445abfa3bcd3f4ac0c</description></item>
    /// <item><term>ArcaneArmorTraining</term><description>1a0298abacb6e0f45b7e28553e99e76c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder RecommendationAlchemistSpells(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new RecommendationRequiresSpellbookSource();
      component.Alchemist = true;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RecommendationRequiresSpellbookSource"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcaneArmorMastery</term><description>453f5181a5ed3a445abfa3bcd3f4ac0c</description></item>
    /// <item><term>ArcaneArmorTraining</term><description>1a0298abacb6e0f45b7e28553e99e76c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder RecommendationArcaneSpells(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new RecommendationRequiresSpellbookSource();
      component.Arcane = true;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RecommendationRequiresSpellbookSource"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcaneArmorMastery</term><description>453f5181a5ed3a445abfa3bcd3f4ac0c</description></item>
    /// <item><term>ArcaneArmorTraining</term><description>1a0298abacb6e0f45b7e28553e99e76c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder RecommendationDivineSpells(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new RecommendationRequiresSpellbookSource();
      component.Divine = true;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RecommendationStatComparison"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DragonStyle</term><description>87ec6541cddfa394ab540dd13399d319</description></item>
    /// <item><term>SlashingGrace</term><description>697d64669eb2c0543abb9c9b07998a38</description></item>
    /// <item><term>WeaponFinesse</term><description>90e54424d682d104ab36436bd527af09</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddRecommendationStatComparison(
        StatType higherStat,
        StatType lowerStat,
        int? diff = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new RecommendationStatComparison();
      component.HigherStat = higherStat;
      component.LowerStat = lowerStat;
      component.Diff = diff ?? component.Diff;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RecommendationStatMiminum"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CombatReflexes</term><description>0f8939ae6f220984e8fb568abbdfba95</description></item>
    /// <item><term>SnapShot</term><description>7115a6c08bd101247b70d72a4ff99453</description></item>
    /// <item><term>WeaponFinesse</term><description>90e54424d682d104ab36436bd527af09</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddRecommendationStatMiminum(
        int minimalValue,
        StatType stat,
        bool? goodIfHigher = null)
    {
      var component = new RecommendationStatMiminum();
      component.MinimalValue = minimalValue;
      component.Stat = stat;
      component.GoodIfHigher = goodIfHigher ?? component.GoodIfHigher;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationWeaponSubcategoryFocus"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FencingGrace</term><description>47b352ea0f73c354aba777945760b441</description></item>
    /// <item><term>PowerAttackFeature</term><description>9972f33f977fc724c838e59641b2fca5</description></item>
    /// <item><term>TwoWeaponFighting</term><description>ac8aaf29054f5b74eb18f2af950e752d</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddRecommendationWeaponSubcategoryFocus(
        WeaponSubCategory subcategory,
        bool? badIfNoFocus = null,
        bool? hasFocus = null)
    {
      var component = new RecommendationWeaponSubcategoryFocus();
      component.Subcategory = subcategory;
      component.BadIfNoFocus = badIfNoFocus ?? component.BadIfNoFocus;
      component.HasFocus = hasFocus ?? component.HasFocus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationWeaponTypeFocus"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ClusteredShots</term><description>f7de245bb20f12f47864c7cb8b1d1abb</description></item>
    /// <item><term>PointBlankShot</term><description>0da0c194d6e1d43419eb8d990b28e0ab</description></item>
    /// <item><term>WeaponFinesse</term><description>90e54424d682d104ab36436bd527af09</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddRecommendationWeaponTypeFocus(
        WeaponRangeType weaponRangeType,
        bool? hasFocus = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new RecommendationWeaponTypeFocus();
      component.WeaponRangeType = weaponRangeType;
      component.HasFocus = hasFocus ?? component.HasFocus;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="SpellComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Spell
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AasimarRedMask_Ability_CombatInstantBuff</term><description>4b8d9931bcfc4a6b8fbe50fd8097ff20</description></item>
    /// <item><term>GoodHope_LostlarnCutscene</term><description>2704fe47ceeaf2f4496da3fc06355154</description></item>
    /// <item><term>ZoneOfPredetermination</term><description>756f1d07f9ae29448888ecf016fa40a7</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddSpellComponent(
        SpellSchool school,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new SpellComponent();
      component.School = school;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="SpellDescriptorComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Abrikandilu_Frozen_Buff</term><description>b2df7031cdad480caddf962c894ca484</description></item>
    /// <item><term>HealingDomainBaseAbility</term><description>18f734e40dd7966438ab32086c3574e1</description></item>
    /// <item><term>ZachariusFearAuraBuff</term><description>4d9144b465bbefe4786cfe86c745ea4e</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddSpellDescriptorComponent(
        SpellDescriptorWrapper descriptor,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new SpellDescriptorComponent();
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TargetHasBuffsFromCaster"/>
    /// </summary>
    ///
    /// <param name="buffs">
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
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTargetHasBuffsFromCaster(
        List<Blueprint<BlueprintBuffReference>> buffs,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? requireAllBuffs = null)
    {
      var component = new TargetHasBuffsFromCaster();
      component.Buffs = buffs?.Select(bp => bp.Reference)?.ToArray();
      component.RequireAllBuffs = requireAllBuffs ?? component.RequireAllBuffs;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="InPowerDismemberComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CoupDeGraceAbility</term><description>32280b137ca642c45be17e2d92898758</description></item>
    /// <item><term>CoupDeGraceSelfAbility</term><description>059c9f3bba1a42e8a1a898987522dae6</description></item>
    /// <item><term>ExecutionerAssassinateAbility</term><description>3dad7f131aa884f4c972f2fb759d0df4</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddInPowerDismemberComponent(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new InPowerDismemberComponent();
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// Adds <see cref="CraftInfoComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcidArrow</term><description>9a46dfd390f943647ab4395fc997936d</description></item>
    /// <item><term>InflictCriticalWoundsCast</term><description>651110ed4f117a948b41c05c5c7624c0</description></item>
    /// <item><term>WrackingRay</term><description>1cde0691195feae45bab5b83ea3f221e</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddCraftInfoComponent(
        CraftAOE? aOEType = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        CraftSavingThrow? savingThrow = null,
        CraftSpellType? spellType = null)
    {
      var component = new CraftInfoComponent();
      component.AOEType = aOEType ?? component.AOEType;
      component.SavingThrow = savingThrow ?? component.SavingThrow;
      component.SpellType = spellType ?? component.SpellType;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityIsFullRoundInTurnBased"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ChargeAbility</term><description>c78506dd0e14f7c45a599990e4e65038</description></item>
    /// <item><term>FlyTrampleTest</term><description>f0b622ab2d18ef7439feb8aa5680d6e5</description></item>
    /// <item><term>OverrunAbility</term><description>1a3b471ecea51f7439a946b23577fd70</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityIsFullRoundInTurnBased(
        bool? fullRoundIfTurnBased = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityIsFullRoundInTurnBased();
      component.FullRoundIfTurnBased = fullRoundIfTurnBased ?? component.FullRoundIfTurnBased;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="LevelUpRecommendation"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SpellPenetration</term><description>ee7dc126939e4d9438357fbd5980d459</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddLevelUpRecommendation(
        ClassesPriority[]? classPriorities = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new LevelUpRecommendation();
      Validate(classPriorities);
      component.ClassPriorities = classPriorities ?? component.ClassPriorities;
      if (component.ClassPriorities is null)
      {
        component.ClassPriorities = new ClassesPriority[0];
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ArmorWeightCoef"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PurifierCelestialArmorFeature</term><description>7dc8d7dede2704640956f7bc4102760a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddArmorWeightCoef(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        float? weightCoef = null)
    {
      var component = new ArmorWeightCoef();
      component.WeightCoef = weightCoef ?? component.WeightCoef;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="CantripComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Spell
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcidSplash</term><description>0c852a2405dd9f14a8bbcfaf245ff823</description></item>
    /// <item><term>Lullaby</term><description>877297946a6b70744a188eb15dd2daab</description></item>
    /// <item><term>Virtue</term><description>d3a852385ba4cd740992d1970170301a</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddCantripComponent()
    {
      return AddComponent(new CantripComponent());
    }

    /// <summary>
    /// Adds <see cref="ChirurgeonSpell"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyACBonus3AuraAbility</term><description>7963fb8f26574efcb4e0cb35166d4ce9</description></item>
    /// <item><term>CureCriticalWounds</term><description>0d657aa811b310e4bbd8586e60156a2d</description></item>
    /// <item><term>RemoveDisease</term><description>4093d5a0eb5cae94e909eb1e0e1a6b36</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddChirurgeonSpell()
    {
      return AddComponent(new ChirurgeonSpell());
    }

    /// <summary>
    /// Adds <see cref="PretendSpellLevel"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BurningArcAasimar</term><description>e3e1bc1cab8e8d24583d24d7b6c2b900</description></item>
    /// <item><term>QuestElectriLightningBoltSpell</term><description>59c805b711d65dd4b80f6a43f249a574</description></item>
    /// <item><term>SummonNaturesAllyAasimarSingle</term><description>b1326a7a72fae4c4996339e14715c08d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddPretendSpellLevel(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        int? spellLevel = null)
    {
      var component = new PretendSpellLevel();
      component.SpellLevel = spellLevel ?? component.SpellLevel;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="SpellListComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Spell list belonging
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbsoluteDeath</term><description>7d721be6d74f07f4d952ee8d6f8f44a0</description></item>
    /// <item><term>HoldPersonMass</term><description>defbbeaef79eda64abc645036228a31b</description></item>
    /// <item><term>ZoneOfPredetermination</term><description>756f1d07f9ae29448888ecf016fa40a7</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="spellList">
    /// <para>
    /// Blueprint of type BlueprintSpellList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddSpellListComponent(
        int? spellLevel = null,
        Blueprint<BlueprintSpellListReference>? spellList = null)
    {
      var component = new SpellListComponent();
      component.SpellLevel = spellLevel ?? component.SpellLevel;
      component.m_SpellList = spellList?.Reference ?? component.m_SpellList;
      if (component.m_SpellList is null)
      {
        component.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellTypeOverride"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Override arcane/divine type
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AreshkagalRetriever_Ability_MendingRay</term><description>d223cb940ef646748a0f4ae6de345a59</description></item>
    /// <item><term>DemonCutsceneChain</term><description>8300f4890a5f4fbc821ec7985e2ec69c</description></item>
    /// <item><term>MagicMissile05_Cutscene</term><description>6b995ea6ac8a2c84a9db7a9e4cfd8cca</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddSpellTypeOverride(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        SpellSource? type = null)
    {
      var component = new SpellTypeOverride();
      component.Type = type ?? component.Type;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="UniqueSpellComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Spell
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BoneshakerSwift</term><description>e80632b0e6c34ee41832f13d056a1ea7</description></item>
    /// <item><term>BoneshatterMax</term><description>45c720cc87cf92542b827b1292e44459</description></item>
    /// <item><term>MageShieldSwift</term><description>3c1b92a0a3ce0754a889fb0d7b2c23a4</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddUniqueSpellComponent()
    {
      return AddComponent(new UniqueSpellComponent());
    }

    /// <summary>
    /// Adds <see cref="AbilityAcceptBurnOnCast"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AerialEvasionAbility</term><description>41281aa38b6b27f4fa3a05c97cc01783</description></item>
    /// <item><term>SearingFleshAbility</term><description>04a61f1221b79a742912cfd847b65911</description></item>
    /// <item><term>ShroudOFWaterUpgradeAbility</term><description>84d77a1c06b800545aacd91210d3505c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityAcceptBurnOnCast(
        int? burnValue = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityAcceptBurnOnCast();
      component.BurnValue = burnValue ?? component.BurnValue;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityKineticist"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AirBlastAbility</term><description>31f668b12011e344aa542aa07ab6c8d9</description></item>
    /// <item><term>KineticBladeMetalBlastBurnAbility</term><description>b66add7c13a8398488ed3e915ade09d3</description></item>
    /// <item><term>WrackBloodBlastAbility</term><description>0199d49f59833104198e2c0196235a45</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="cachedDamageSource">
    /// <para>
    /// Blueprint of type BlueprintScriptableObject. You can pass in the blueprint using:
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
    public TBuilder AddAbilityKineticist(
        int? amount = null,
        int? blastBurnCost = null,
        List<AbilityKineticist.DamageInfo>? cachedDamageInfo = null,
        Blueprint<AnyBlueprintReference>? cachedDamageSource = null,
        bool? costIsCustom = null,
        int? infusionBurnCost = null,
        bool? isSpendResource = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Blueprint<BlueprintAbilityResourceReference>? requiredResource = null,
        List<Blueprint<BlueprintUnitFactReference>>? resourceCostDecreasingFacts = null,
        List<Blueprint<BlueprintUnitFactReference>>? resourceCostIncreasingFacts = null,
        int? wildTalentBurnCost = null)
    {
      var component = new AbilityKineticist();
      component.Amount = amount ?? component.Amount;
      component.BlastBurnCost = blastBurnCost ?? component.BlastBurnCost;
      component.CachedDamageInfo = cachedDamageInfo ?? component.CachedDamageInfo;
      if (component.CachedDamageInfo is null)
      {
        component.CachedDamageInfo = new();
      }
      component.CachedDamageSource = cachedDamageSource?.Reference ?? component.CachedDamageSource;
      if (component.CachedDamageSource is null)
      {
        component.CachedDamageSource = BlueprintTool.GetRef<AnyBlueprintReference>(null);
      }
      component.CostIsCustom = costIsCustom ?? component.CostIsCustom;
      component.InfusionBurnCost = infusionBurnCost ?? component.InfusionBurnCost;
      component.m_IsSpendResource = isSpendResource ?? component.m_IsSpendResource;
      component.m_RequiredResource = requiredResource?.Reference ?? component.m_RequiredResource;
      if (component.m_RequiredResource is null)
      {
        component.m_RequiredResource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(null);
      }
      component.ResourceCostDecreasingFacts = resourceCostDecreasingFacts?.Select(bp => bp.Reference)?.ToList() ?? component.ResourceCostDecreasingFacts;
      if (component.ResourceCostDecreasingFacts is null)
      {
        component.ResourceCostDecreasingFacts = new();
      }
      component.ResourceCostIncreasingFacts = resourceCostIncreasingFacts?.Select(bp => bp.Reference)?.ToList() ?? component.ResourceCostIncreasingFacts;
      if (component.ResourceCostIncreasingFacts is null)
      {
        component.ResourceCostIncreasingFacts = new();
      }
      component.WildTalentBurnCost = wildTalentBurnCost ?? component.WildTalentBurnCost;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateAbilityParams"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>1_FirstStage_AcidBuff</term><description>6afe27c9a2d64eb890673ff3649dacb3</description></item>
    /// <item><term>DeathsnatcherEnergyDrainFeature</term><description>e4c3976c40072a747b1a9ba2d8f166f2</description></item>
    /// <item><term>Yozz_Feature_AdditionalAttacks</term><description>bcf37abbb0b1485b83059600ed440881</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="customProperty">
    /// <para>
    /// Blueprint of type BlueprintUnitProperty. You can pass in the blueprint using:
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
    public TBuilder AddContextCalculateAbilityParams(
        ContextValue? casterLevel = null,
        Blueprint<BlueprintUnitPropertyReference>? customProperty = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? replaceCasterLevel = null,
        bool? replaceSpellLevel = null,
        ContextValue? spellLevel = null,
        StatType? statType = null,
        bool? statTypeFromCustomProperty = null,
        bool? useKineticistMainStat = null)
    {
      var component = new ContextCalculateAbilityParams();
      component.CasterLevel = casterLevel ?? component.CasterLevel;
      if (component.CasterLevel is null)
      {
        component.CasterLevel = ContextValues.Constant(0);
      }
      component.m_CustomProperty = customProperty?.Reference ?? component.m_CustomProperty;
      if (component.m_CustomProperty is null)
      {
        component.m_CustomProperty = BlueprintTool.GetRef<BlueprintUnitPropertyReference>(null);
      }
      component.ReplaceCasterLevel = replaceCasterLevel ?? component.ReplaceCasterLevel;
      component.ReplaceSpellLevel = replaceSpellLevel ?? component.ReplaceSpellLevel;
      component.SpellLevel = spellLevel ?? component.SpellLevel;
      if (component.SpellLevel is null)
      {
        component.SpellLevel = ContextValues.Constant(0);
      }
      component.StatType = statType ?? component.StatType;
      component.StatTypeFromCustomProperty = statTypeFromCustomProperty ?? component.StatTypeFromCustomProperty;
      component.UseKineticistMainStat = useKineticistMainStat ?? component.UseKineticistMainStat;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateAbilityParamsBasedOnClass"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AirBlastAbility</term><description>31f668b12011e344aa542aa07ab6c8d9</description></item>
    /// <item><term>PlasmaBlastAbility</term><description>a5631955254ae5c4d9cc2d16870448a2</description></item>
    /// <item><term>XantirOnlySwarm_MidnightFaneInThePastFeature</term><description>5131c4b93f314bd4589edf612b4eb600</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="characterClass">
    /// <para>
    /// Blueprint of type BlueprintCharacterClass. You can pass in the blueprint using:
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
    public TBuilder AddContextCalculateAbilityParamsBasedOnClass(
        Blueprint<BlueprintCharacterClassReference>? characterClass = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        StatType? statType = null,
        bool? useKineticistMainStat = null)
    {
      var component = new ContextCalculateAbilityParamsBasedOnClass();
      component.m_CharacterClass = characterClass?.Reference ?? component.m_CharacterClass;
      if (component.m_CharacterClass is null)
      {
        component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(null);
      }
      component.StatType = statType ?? component.StatType;
      component.UseKineticistMainStat = useKineticistMainStat ?? component.UseKineticistMainStat;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateSharedValue"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbyssalCreatureAcidTemplate</term><description>6e6fda1c8a35069468e7398082cd30f5</description></item>
    /// <item><term>LeyLineGuardianConduitSurgeBuff</term><description>4770ff0074ebb6246ab1d09b9b261103</description></item>
    /// <item><term>WreckingBlowsEffectBuff</term><description>15dd42009de61334692b22fd7a576b79</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddContextCalculateSharedValue(
        double? modifier = null,
        ContextDiceValue? value = null,
        AbilitySharedValue? valueType = null)
    {
      var component = new ContextCalculateSharedValue();
      component.Modifier = modifier ?? component.Modifier;
      component.Value = value ?? component.Value;
      if (component.Value is null)
      {
        component.Value = Utils.Constants.Empty.DiceValue;
      }
      component.ValueType = valueType ?? component.ValueType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextSetAbilityParams"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbruptForceEnchantment</term><description>c31b3edcf2088a64e80133ebbd6374cb</description></item>
    /// <item><term>HellKnightOrderOfTheRackAbility</term><description>2714684e63581ed41b3b13b62d648621</description></item>
    /// <item><term>ZombieSlashingExplosion</term><description>f6b63adab8b645c8beb9cab170dac9d3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="casterLevel">
    /// <para>
    /// InfoBox: If set to negative value, will be calculated by default mechanic. Positive or zero value will be set as is (plus bonuses)
    /// </para>
    /// </param>
    /// <param name="concentration">
    /// <para>
    /// InfoBox: If set to negative value, will be calculated by default mechanic. Positive or zero value will be set as is (plus bonuses)
    /// </para>
    /// </param>
    /// <param name="dC">
    /// <para>
    /// InfoBox: If set to negative value, will be calculated by default mechanic. Positive or zero value will be set as is (plus bonuses)
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="spellLevel">
    /// <para>
    /// InfoBox: If set to negative value, will be calculated by default mechanic. Positive or zero value will be set as is
    /// </para>
    /// </param>
    public TBuilder AddContextSetAbilityParams(
        bool? add10ToDC = null,
        ContextValue? casterLevel = null,
        ContextValue? concentration = null,
        ContextValue? dC = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        ContextValue? spellLevel = null)
    {
      var component = new ContextSetAbilityParams();
      component.Add10ToDC = add10ToDC ?? component.Add10ToDC;
      component.CasterLevel = casterLevel ?? component.CasterLevel;
      if (component.CasterLevel is null)
      {
        component.CasterLevel = ContextValues.Constant(0);
      }
      component.Concentration = concentration ?? component.Concentration;
      if (component.Concentration is null)
      {
        component.Concentration = ContextValues.Constant(0);
      }
      component.DC = dC ?? component.DC;
      if (component.DC is null)
      {
        component.DC = ContextValues.Constant(0);
      }
      component.SpellLevel = spellLevel ?? component.SpellLevel;
      if (component.SpellLevel is null)
      {
        component.SpellLevel = ContextValues.Constant(0);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ArmyAbilityTeleportation"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyAssassinTeleportAbility</term><description>37bc4746de7f413daa212b17b81a7b5c</description></item>
    /// <item><term>ArmyJestersJauntAbility</term><description>15134afbfb034e15b2cb6ebed552aa7e</description></item>
    /// <item><term>ArmyTeleportWarwarpriestAbility</term><description>b8031ba31e4c4277981734d91bb335a5</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="casterAppearFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="casterAppearProjectile">
    /// <para>
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="casterDisappearFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="casterDisappearProjectile">
    /// <para>
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
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
    /// <param name="portalFromPrefab">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="portalToPrefab">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="sideAppearFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="sideAppearProjectile">
    /// <para>
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="sideDisappearFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="sideDisappearProjectile">
    /// <para>
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddArmyAbilityTeleportation(
        bool? cameraShouldFollow = null,
        AssetLink<PrefabLink>? casterAppearFx = null,
        Blueprint<BlueprintProjectileReference>? casterAppearProjectile = null,
        AssetLink<PrefabLink>? casterDisappearFx = null,
        Blueprint<BlueprintProjectileReference>? casterDisappearProjectile = null,
        bool? hasIsAllyEffectRunConditions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        string? portalBone = null,
        AssetLink<PrefabLink>? portalFromPrefab = null,
        AssetLink<PrefabLink>? portalToPrefab = null,
        Feet? radius = null,
        AssetLink<PrefabLink>? sideAppearFx = null,
        Blueprint<BlueprintProjectileReference>? sideAppearProjectile = null,
        AssetLink<PrefabLink>? sideDisappearFx = null,
        Blueprint<BlueprintProjectileReference>? sideDisappearProjectile = null)
    {
      var component = new ArmyAbilityTeleportation();
      component.m_CameraShouldFollow = cameraShouldFollow ?? component.m_CameraShouldFollow;
      component.CasterAppearFx = casterAppearFx?.Get() ?? component.CasterAppearFx;
      if (component.CasterAppearFx is null)
      {
        component.CasterAppearFx = Utils.Constants.Empty.PrefabLink;
      }
      component.m_CasterAppearProjectile = casterAppearProjectile?.Reference ?? component.m_CasterAppearProjectile;
      if (component.m_CasterAppearProjectile is null)
      {
        component.m_CasterAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(null);
      }
      component.CasterDisappearFx = casterDisappearFx?.Get() ?? component.CasterDisappearFx;
      if (component.CasterDisappearFx is null)
      {
        component.CasterDisappearFx = Utils.Constants.Empty.PrefabLink;
      }
      component.m_CasterDisappearProjectile = casterDisappearProjectile?.Reference ?? component.m_CasterDisappearProjectile;
      if (component.m_CasterDisappearProjectile is null)
      {
        component.m_CasterDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(null);
      }
      component.m_HasIsAllyEffectRunConditions = hasIsAllyEffectRunConditions ?? component.m_HasIsAllyEffectRunConditions;
      component.PortalBone = portalBone ?? component.PortalBone;
      component.PortalFromPrefab = portalFromPrefab?.Get() ?? component.PortalFromPrefab;
      if (component.PortalFromPrefab is null)
      {
        component.PortalFromPrefab = Utils.Constants.Empty.PrefabLink;
      }
      component.PortalToPrefab = portalToPrefab?.Get() ?? component.PortalToPrefab;
      if (component.PortalToPrefab is null)
      {
        component.PortalToPrefab = Utils.Constants.Empty.PrefabLink;
      }
      component.Radius = radius ?? component.Radius;
      component.SideAppearFx = sideAppearFx?.Get() ?? component.SideAppearFx;
      if (component.SideAppearFx is null)
      {
        component.SideAppearFx = Utils.Constants.Empty.PrefabLink;
      }
      component.m_SideAppearProjectile = sideAppearProjectile?.Reference ?? component.m_SideAppearProjectile;
      if (component.m_SideAppearProjectile is null)
      {
        component.m_SideAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(null);
      }
      component.SideDisappearFx = sideDisappearFx?.Get() ?? component.SideDisappearFx;
      if (component.SideDisappearFx is null)
      {
        component.SideDisappearFx = Utils.Constants.Empty.PrefabLink;
      }
      component.m_SideDisappearProjectile = sideDisappearProjectile?.Reference ?? component.m_SideDisappearProjectile;
      if (component.m_SideDisappearProjectile is null)
      {
        component.m_SideDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityAffectLineOnGrid"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Angel4BladeOfTheSunAbility</term><description>b7b4901fed7b4229b2f85541de80d64c</description></item>
    /// <item><term>RitualBoneArrowAbility</term><description>f96761c8b20647298197348d8d8907fe</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="spreadSpeed">
    /// <para>
    /// Tooltip: Feet per second
    /// </para>
    /// </param>
    public TBuilder AddAbilityAffectLineOnGrid(
        ConditionsBuilder? condition = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Feet? spreadSpeed = null,
        Kingmaker.UnitLogic.Abilities.Components.TargetType? targetType = null,
        bool? vertical = null)
    {
      var component = new AbilityAffectLineOnGrid();
      component.m_Condition = condition?.Build() ?? component.m_Condition;
      if (component.m_Condition is null)
      {
        component.m_Condition = Utils.Constants.Empty.Conditions;
      }
      component.m_SpreadSpeed = spreadSpeed ?? component.m_SpreadSpeed;
      component.m_TargetType = targetType ?? component.m_TargetType;
      component.m_Vertical = vertical ?? component.m_Vertical;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityAoERadius"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcidFog</term><description>dbf99b00cd35d0a4491c6cc9e771b487</description></item>
    /// <item><term>HungryPit</term><description>f63f4d1806b78604a952b3958892ce1c</description></item>
    /// <item><term>ZoneOfPredetermination</term><description>756f1d07f9ae29448888ecf016fa40a7</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="diameterInCells">
    /// <para>
    /// InfoBox: For now only odd diameters can be used. 1 -&amp;gt; 1 cell, 3 -&amp;gt; 9 cells, ...
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityAoERadius(
        bool? canBeUsedInTacticalCombat = null,
        int? diameterInCells = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Feet? radius = null,
        Kingmaker.UnitLogic.Abilities.Components.TargetType? targetType = null)
    {
      var component = new AbilityAoERadius();
      component.m_CanBeUsedInTacticalCombat = canBeUsedInTacticalCombat ?? component.m_CanBeUsedInTacticalCombat;
      component.m_DiameterInCells = diameterInCells ?? component.m_DiameterInCells;
      component.m_Radius = radius ?? component.m_Radius;
      component.m_TargetType = targetType ?? component.m_TargetType;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityApplyFact"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CavalierTacticianAbility</term><description>3ff8ef7ba7b5be0429cf32cd4ddf637c</description></item>
    /// <item><term>UnswornShamanMinorSpiritAbility 2</term><description>8e37166acde792f458c1c02a7392ab7c</description></item>
    /// <item><term>WitchWanderingHexAbility</term><description>b209beab784d93546b40a2fa2a09ffa8</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="facts">
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
    public TBuilder AddAbilityApplyFact(
        ContextDurationValue? duration = null,
        List<Blueprint<BlueprintUnitFactReference>>? facts = null,
        bool? hasDuration = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        AbilityApplyFact.FactRestriction? restriction = null)
    {
      var component = new AbilityApplyFact();
      Validate(duration);
      component.m_Duration = duration ?? component.m_Duration;
      component.m_Facts = facts?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Facts;
      if (component.m_Facts is null)
      {
        component.m_Facts = new BlueprintUnitFactReference[0];
      }
      component.m_HasDuration = hasDuration ?? component.m_HasDuration;
      component.m_Restriction = restriction ?? component.m_Restriction;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityConvertSpellLevelToResource"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PrismaticRingRestore1ResourceAbility</term><description>4f01fea2d2ad45df865548d584ef5bef</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="resource">
    /// <para>
    /// Blueprint of type BlueprintScriptableObject. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddAbilityConvertSpellLevelToResource(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Blueprint<AnyBlueprintReference>? resource = null)
    {
      var component = new AbilityConvertSpellLevelToResource();
      component.m_Resource = resource?.Reference ?? component.m_Resource;
      if (component.m_Resource is null)
      {
        component.m_Resource = BlueprintTool.GetRef<AnyBlueprintReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomAnimationByBuff"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>NightcrawlerBurrowAbility</term><description>06501fbe848142008b21b2065c4c7fbc</description></item>
    /// <item><term>PurpleWormBurrowAbility</term><description>345329c09ee0f1343a7e61564468c6b9</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityCustomAnimationByBuff(
        UnitAnimationActionClip? defaultAnimation = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        AbilityCustomAnimationByBuff.Entry[]? variants = null)
    {
      var component = new AbilityCustomAnimationByBuff();
      Validate(defaultAnimation);
      component.DefaultAnimation = defaultAnimation ?? component.DefaultAnimation;
      Validate(variants);
      component.Variants = variants ?? component.Variants;
      if (component.Variants is null)
      {
        component.Variants = new AbilityCustomAnimationByBuff.Entry[0];
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomCharge"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ChargeAbility</term><description>c78506dd0e14f7c45a599990e4e65038</description></item>
    /// <item><term>SwiftBlowImprovedChargeAbility</term><description>d4b4757660cb66e4fbf376a43f1ffb13</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityCustomCharge(
        bool? hasIsAllyEffectRunConditions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityCustomCharge();
      component.m_HasIsAllyEffectRunConditions = hasIsAllyEffectRunConditions ?? component.m_HasIsAllyEffectRunConditions;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomCleave"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CleaveAction</term><description>6447d104a2222c14d9c9b8a36e4eb242</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="greaterFeature">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
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
    public TBuilder AddAbilityCustomCleave(
        Blueprint<BlueprintFeatureReference>? greaterFeature = null,
        bool? hasIsAllyEffectRunConditions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityCustomCleave();
      component.m_GreaterFeature = greaterFeature?.Reference ?? component.m_GreaterFeature;
      if (component.m_GreaterFeature is null)
      {
        component.m_GreaterFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      component.m_HasIsAllyEffectRunConditions = hasIsAllyEffectRunConditions ?? component.m_HasIsAllyEffectRunConditions;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomDimensionDoor"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcanistExploitDimensionalSlideAbility</term><description>e81570b9df7758e4195346340231e6e3</description></item>
    /// <item><term>DimensionDoorMassDLC_cutscene_2</term><description>8bdb37323a2f4457a1556ede3098036e</description></item>
    /// <item><term>WitchOfTheVeilShroudedStepAbility8</term><description>5713b048d3a24959b7a27eac48e69943</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="casterAppearFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="casterAppearProjectile">
    /// <para>
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="casterDisappearFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="casterDisappearProjectile">
    /// <para>
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
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
    /// <param name="portalFromPrefab">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="portalToPrefab">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="sideAppearFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="sideAppearProjectile">
    /// <para>
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="sideDisappearFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="sideDisappearProjectile">
    /// <para>
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddAbilityCustomDimensionDoor(
        bool? cameraShouldFollow = null,
        AssetLink<PrefabLink>? casterAppearFx = null,
        Blueprint<BlueprintProjectileReference>? casterAppearProjectile = null,
        AssetLink<PrefabLink>? casterDisappearFx = null,
        Blueprint<BlueprintProjectileReference>? casterDisappearProjectile = null,
        bool? hasIsAllyEffectRunConditions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        string? portalBone = null,
        AssetLink<PrefabLink>? portalFromPrefab = null,
        AssetLink<PrefabLink>? portalToPrefab = null,
        Feet? radius = null,
        AssetLink<PrefabLink>? sideAppearFx = null,
        Blueprint<BlueprintProjectileReference>? sideAppearProjectile = null,
        AssetLink<PrefabLink>? sideDisappearFx = null,
        Blueprint<BlueprintProjectileReference>? sideDisappearProjectile = null)
    {
      var component = new AbilityCustomDimensionDoor();
      component.m_CameraShouldFollow = cameraShouldFollow ?? component.m_CameraShouldFollow;
      component.CasterAppearFx = casterAppearFx?.Get() ?? component.CasterAppearFx;
      if (component.CasterAppearFx is null)
      {
        component.CasterAppearFx = Utils.Constants.Empty.PrefabLink;
      }
      component.m_CasterAppearProjectile = casterAppearProjectile?.Reference ?? component.m_CasterAppearProjectile;
      if (component.m_CasterAppearProjectile is null)
      {
        component.m_CasterAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(null);
      }
      component.CasterDisappearFx = casterDisappearFx?.Get() ?? component.CasterDisappearFx;
      if (component.CasterDisappearFx is null)
      {
        component.CasterDisappearFx = Utils.Constants.Empty.PrefabLink;
      }
      component.m_CasterDisappearProjectile = casterDisappearProjectile?.Reference ?? component.m_CasterDisappearProjectile;
      if (component.m_CasterDisappearProjectile is null)
      {
        component.m_CasterDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(null);
      }
      component.m_HasIsAllyEffectRunConditions = hasIsAllyEffectRunConditions ?? component.m_HasIsAllyEffectRunConditions;
      component.PortalBone = portalBone ?? component.PortalBone;
      component.PortalFromPrefab = portalFromPrefab?.Get() ?? component.PortalFromPrefab;
      if (component.PortalFromPrefab is null)
      {
        component.PortalFromPrefab = Utils.Constants.Empty.PrefabLink;
      }
      component.PortalToPrefab = portalToPrefab?.Get() ?? component.PortalToPrefab;
      if (component.PortalToPrefab is null)
      {
        component.PortalToPrefab = Utils.Constants.Empty.PrefabLink;
      }
      component.Radius = radius ?? component.Radius;
      component.SideAppearFx = sideAppearFx?.Get() ?? component.SideAppearFx;
      if (component.SideAppearFx is null)
      {
        component.SideAppearFx = Utils.Constants.Empty.PrefabLink;
      }
      component.m_SideAppearProjectile = sideAppearProjectile?.Reference ?? component.m_SideAppearProjectile;
      if (component.m_SideAppearProjectile is null)
      {
        component.m_SideAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(null);
      }
      component.SideDisappearFx = sideDisappearFx?.Get() ?? component.SideDisappearFx;
      if (component.SideDisappearFx is null)
      {
        component.SideDisappearFx = Utils.Constants.Empty.PrefabLink;
      }
      component.m_SideDisappearProjectile = sideDisappearProjectile?.Reference ?? component.m_SideDisappearProjectile;
      if (component.m_SideDisappearProjectile is null)
      {
        component.m_SideDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomDimensionDoorSwap"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>EmergencySwapAbility</term><description>b50ca9b5d6292fb42b8eab8e5d64842d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="appearFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="appearProjectile">
    /// <para>
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="disappearFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="disappearProjectile">
    /// <para>
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
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
    /// <param name="portalFromPrefab">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder AddAbilityCustomDimensionDoorSwap(
        AssetLink<PrefabLink>? appearFx = null,
        Blueprint<BlueprintProjectileReference>? appearProjectile = null,
        AssetLink<PrefabLink>? disappearFx = null,
        Blueprint<BlueprintProjectileReference>? disappearProjectile = null,
        bool? hasIsAllyEffectRunConditions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        string? portalBone = null,
        AssetLink<PrefabLink>? portalFromPrefab = null)
    {
      var component = new AbilityCustomDimensionDoorSwap();
      component.AppearFx = appearFx?.Get() ?? component.AppearFx;
      if (component.AppearFx is null)
      {
        component.AppearFx = Utils.Constants.Empty.PrefabLink;
      }
      component.m_AppearProjectile = appearProjectile?.Reference ?? component.m_AppearProjectile;
      if (component.m_AppearProjectile is null)
      {
        component.m_AppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(null);
      }
      component.DisappearFx = disappearFx?.Get() ?? component.DisappearFx;
      if (component.DisappearFx is null)
      {
        component.DisappearFx = Utils.Constants.Empty.PrefabLink;
      }
      component.m_DisappearProjectile = disappearProjectile?.Reference ?? component.m_DisappearProjectile;
      if (component.m_DisappearProjectile is null)
      {
        component.m_DisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(null);
      }
      component.m_HasIsAllyEffectRunConditions = hasIsAllyEffectRunConditions ?? component.m_HasIsAllyEffectRunConditions;
      component.PortalBone = portalBone ?? component.PortalBone;
      component.PortalFromPrefab = portalFromPrefab?.Get() ?? component.PortalFromPrefab;
      if (component.PortalFromPrefab is null)
      {
        component.PortalFromPrefab = Utils.Constants.Empty.PrefabLink;
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomDimensionDoorTargets"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DimensionDoor_CutsceneAreeluAndStitch</term><description>e973b7e09758eed4da0a72605798b6fb</description></item>
    /// <item><term>PuluraFall_EchoSpell_DimensionDoorKatair</term><description>1488cf53a9d958347a8c395f475f62c3</description></item>
    /// <item><term>QuickenedDimensionDoorAoEZiggurat_Cutscene</term><description>61e196105ca548d7bbd0c3a484c4cab4</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="casterAppearFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="casterAppearProjectile">
    /// <para>
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="casterDisappearFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="casterDisappearProjectile">
    /// <para>
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
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
    /// <param name="portalFromPrefab">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="portalToPrefab">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="sideAppearFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="sideAppearProjectile">
    /// <para>
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="sideDisappearFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="sideDisappearProjectile">
    /// <para>
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddAbilityCustomDimensionDoorTargets(
        bool? cameraShouldFollow = null,
        AssetLink<PrefabLink>? casterAppearFx = null,
        Blueprint<BlueprintProjectileReference>? casterAppearProjectile = null,
        AssetLink<PrefabLink>? casterDisappearFx = null,
        Blueprint<BlueprintProjectileReference>? casterDisappearProjectile = null,
        bool? hasIsAllyEffectRunConditions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        string? portalBone = null,
        AssetLink<PrefabLink>? portalFromPrefab = null,
        AssetLink<PrefabLink>? portalToPrefab = null,
        Feet? radius = null,
        AssetLink<PrefabLink>? sideAppearFx = null,
        Blueprint<BlueprintProjectileReference>? sideAppearProjectile = null,
        AssetLink<PrefabLink>? sideDisappearFx = null,
        Blueprint<BlueprintProjectileReference>? sideDisappearProjectile = null,
        UnitEvaluator[]? targets = null)
    {
      var component = new AbilityCustomDimensionDoorTargets();
      component.m_CameraShouldFollow = cameraShouldFollow ?? component.m_CameraShouldFollow;
      component.CasterAppearFx = casterAppearFx?.Get() ?? component.CasterAppearFx;
      if (component.CasterAppearFx is null)
      {
        component.CasterAppearFx = Utils.Constants.Empty.PrefabLink;
      }
      component.m_CasterAppearProjectile = casterAppearProjectile?.Reference ?? component.m_CasterAppearProjectile;
      if (component.m_CasterAppearProjectile is null)
      {
        component.m_CasterAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(null);
      }
      component.CasterDisappearFx = casterDisappearFx?.Get() ?? component.CasterDisappearFx;
      if (component.CasterDisappearFx is null)
      {
        component.CasterDisappearFx = Utils.Constants.Empty.PrefabLink;
      }
      component.m_CasterDisappearProjectile = casterDisappearProjectile?.Reference ?? component.m_CasterDisappearProjectile;
      if (component.m_CasterDisappearProjectile is null)
      {
        component.m_CasterDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(null);
      }
      component.m_HasIsAllyEffectRunConditions = hasIsAllyEffectRunConditions ?? component.m_HasIsAllyEffectRunConditions;
      component.PortalBone = portalBone ?? component.PortalBone;
      component.PortalFromPrefab = portalFromPrefab?.Get() ?? component.PortalFromPrefab;
      if (component.PortalFromPrefab is null)
      {
        component.PortalFromPrefab = Utils.Constants.Empty.PrefabLink;
      }
      component.PortalToPrefab = portalToPrefab?.Get() ?? component.PortalToPrefab;
      if (component.PortalToPrefab is null)
      {
        component.PortalToPrefab = Utils.Constants.Empty.PrefabLink;
      }
      component.Radius = radius ?? component.Radius;
      component.SideAppearFx = sideAppearFx?.Get() ?? component.SideAppearFx;
      if (component.SideAppearFx is null)
      {
        component.SideAppearFx = Utils.Constants.Empty.PrefabLink;
      }
      component.m_SideAppearProjectile = sideAppearProjectile?.Reference ?? component.m_SideAppearProjectile;
      if (component.m_SideAppearProjectile is null)
      {
        component.m_SideAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(null);
      }
      component.SideDisappearFx = sideDisappearFx?.Get() ?? component.SideDisappearFx;
      if (component.SideDisappearFx is null)
      {
        component.SideDisappearFx = Utils.Constants.Empty.PrefabLink;
      }
      component.m_SideDisappearProjectile = sideDisappearProjectile?.Reference ?? component.m_SideDisappearProjectile;
      if (component.m_SideDisappearProjectile is null)
      {
        component.m_SideDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(null);
      }
      Validate(targets);
      component.Targets = targets ?? component.Targets;
      if (component.Targets is null)
      {
        component.Targets = new UnitEvaluator[0];
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomDweomerLeap"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AnomalyTemplateDefensive_AnomalyShiftAbility</term><description>8971ae39737a420daa5d440924af6ae9</description></item>
    /// <item><term>DweomercatDweomerleap</term><description>cde8c0c172c9fa34cba7703ba4824d32</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="casterAppearFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="casterAppearProjectile">
    /// <para>
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="casterDisappearFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="casterDisappearProjectile">
    /// <para>
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
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
    /// <param name="portalFromPrefab">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="portalToPrefab">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="sideAppearFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="sideAppearProjectile">
    /// <para>
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="sideDisappearFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="sideDisappearProjectile">
    /// <para>
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddAbilityCustomDweomerLeap(
        bool? cameraShouldFollow = null,
        AssetLink<PrefabLink>? casterAppearFx = null,
        Blueprint<BlueprintProjectileReference>? casterAppearProjectile = null,
        AssetLink<PrefabLink>? casterDisappearFx = null,
        Blueprint<BlueprintProjectileReference>? casterDisappearProjectile = null,
        bool? hasIsAllyEffectRunConditions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        string? portalBone = null,
        AssetLink<PrefabLink>? portalFromPrefab = null,
        AssetLink<PrefabLink>? portalToPrefab = null,
        Feet? radius = null,
        AssetLink<PrefabLink>? sideAppearFx = null,
        Blueprint<BlueprintProjectileReference>? sideAppearProjectile = null,
        AssetLink<PrefabLink>? sideDisappearFx = null,
        Blueprint<BlueprintProjectileReference>? sideDisappearProjectile = null)
    {
      var component = new AbilityCustomDweomerLeap();
      component.m_CameraShouldFollow = cameraShouldFollow ?? component.m_CameraShouldFollow;
      component.CasterAppearFx = casterAppearFx?.Get() ?? component.CasterAppearFx;
      if (component.CasterAppearFx is null)
      {
        component.CasterAppearFx = Utils.Constants.Empty.PrefabLink;
      }
      component.m_CasterAppearProjectile = casterAppearProjectile?.Reference ?? component.m_CasterAppearProjectile;
      if (component.m_CasterAppearProjectile is null)
      {
        component.m_CasterAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(null);
      }
      component.CasterDisappearFx = casterDisappearFx?.Get() ?? component.CasterDisappearFx;
      if (component.CasterDisappearFx is null)
      {
        component.CasterDisappearFx = Utils.Constants.Empty.PrefabLink;
      }
      component.m_CasterDisappearProjectile = casterDisappearProjectile?.Reference ?? component.m_CasterDisappearProjectile;
      if (component.m_CasterDisappearProjectile is null)
      {
        component.m_CasterDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(null);
      }
      component.m_HasIsAllyEffectRunConditions = hasIsAllyEffectRunConditions ?? component.m_HasIsAllyEffectRunConditions;
      component.PortalBone = portalBone ?? component.PortalBone;
      component.PortalFromPrefab = portalFromPrefab?.Get() ?? component.PortalFromPrefab;
      if (component.PortalFromPrefab is null)
      {
        component.PortalFromPrefab = Utils.Constants.Empty.PrefabLink;
      }
      component.PortalToPrefab = portalToPrefab?.Get() ?? component.PortalToPrefab;
      if (component.PortalToPrefab is null)
      {
        component.PortalToPrefab = Utils.Constants.Empty.PrefabLink;
      }
      component.Radius = radius ?? component.Radius;
      component.SideAppearFx = sideAppearFx?.Get() ?? component.SideAppearFx;
      if (component.SideAppearFx is null)
      {
        component.SideAppearFx = Utils.Constants.Empty.PrefabLink;
      }
      component.m_SideAppearProjectile = sideAppearProjectile?.Reference ?? component.m_SideAppearProjectile;
      if (component.m_SideAppearProjectile is null)
      {
        component.m_SideAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(null);
      }
      component.SideDisappearFx = sideDisappearFx?.Get() ?? component.SideDisappearFx;
      if (component.SideDisappearFx is null)
      {
        component.SideDisappearFx = Utils.Constants.Empty.PrefabLink;
      }
      component.m_SideDisappearProjectile = sideDisappearProjectile?.Reference ?? component.m_SideDisappearProjectile;
      if (component.m_SideDisappearProjectile is null)
      {
        component.m_SideDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomFlashStep"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>StormwalkerFlashStepAbility</term><description>e10424c1afe70cb4384090f4dab8d437</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="casterAppearFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="casterAppearProjectile">
    /// <para>
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="casterDisappearFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="casterDisappearProjectile">
    /// <para>
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="flashShot">
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
    /// <param name="portalFromPrefab">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="portalToPrefab">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="sideAppearFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="sideAppearProjectile">
    /// <para>
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="sideDisappearFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="sideDisappearProjectile">
    /// <para>
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddAbilityCustomFlashStep(
        bool? cameraShouldFollow = null,
        AssetLink<PrefabLink>? casterAppearFx = null,
        Blueprint<BlueprintProjectileReference>? casterAppearProjectile = null,
        AssetLink<PrefabLink>? casterDisappearFx = null,
        Blueprint<BlueprintProjectileReference>? casterDisappearProjectile = null,
        Blueprint<BlueprintUnitFactReference>? flashShot = null,
        bool? hasIsAllyEffectRunConditions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        string? portalBone = null,
        AssetLink<PrefabLink>? portalFromPrefab = null,
        AssetLink<PrefabLink>? portalToPrefab = null,
        Feet? radius = null,
        AssetLink<PrefabLink>? sideAppearFx = null,
        Blueprint<BlueprintProjectileReference>? sideAppearProjectile = null,
        AssetLink<PrefabLink>? sideDisappearFx = null,
        Blueprint<BlueprintProjectileReference>? sideDisappearProjectile = null)
    {
      var component = new AbilityCustomFlashStep();
      component.m_CameraShouldFollow = cameraShouldFollow ?? component.m_CameraShouldFollow;
      component.CasterAppearFx = casterAppearFx?.Get() ?? component.CasterAppearFx;
      if (component.CasterAppearFx is null)
      {
        component.CasterAppearFx = Utils.Constants.Empty.PrefabLink;
      }
      component.m_CasterAppearProjectile = casterAppearProjectile?.Reference ?? component.m_CasterAppearProjectile;
      if (component.m_CasterAppearProjectile is null)
      {
        component.m_CasterAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(null);
      }
      component.CasterDisappearFx = casterDisappearFx?.Get() ?? component.CasterDisappearFx;
      if (component.CasterDisappearFx is null)
      {
        component.CasterDisappearFx = Utils.Constants.Empty.PrefabLink;
      }
      component.m_CasterDisappearProjectile = casterDisappearProjectile?.Reference ?? component.m_CasterDisappearProjectile;
      if (component.m_CasterDisappearProjectile is null)
      {
        component.m_CasterDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(null);
      }
      component.m_FlashShot = flashShot?.Reference ?? component.m_FlashShot;
      if (component.m_FlashShot is null)
      {
        component.m_FlashShot = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      component.m_HasIsAllyEffectRunConditions = hasIsAllyEffectRunConditions ?? component.m_HasIsAllyEffectRunConditions;
      component.PortalBone = portalBone ?? component.PortalBone;
      component.PortalFromPrefab = portalFromPrefab?.Get() ?? component.PortalFromPrefab;
      if (component.PortalFromPrefab is null)
      {
        component.PortalFromPrefab = Utils.Constants.Empty.PrefabLink;
      }
      component.PortalToPrefab = portalToPrefab?.Get() ?? component.PortalToPrefab;
      if (component.PortalToPrefab is null)
      {
        component.PortalToPrefab = Utils.Constants.Empty.PrefabLink;
      }
      component.Radius = radius ?? component.Radius;
      component.SideAppearFx = sideAppearFx?.Get() ?? component.SideAppearFx;
      if (component.SideAppearFx is null)
      {
        component.SideAppearFx = Utils.Constants.Empty.PrefabLink;
      }
      component.m_SideAppearProjectile = sideAppearProjectile?.Reference ?? component.m_SideAppearProjectile;
      if (component.m_SideAppearProjectile is null)
      {
        component.m_SideAppearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(null);
      }
      component.SideDisappearFx = sideDisappearFx?.Get() ?? component.SideDisappearFx;
      if (component.SideDisappearFx is null)
      {
        component.SideDisappearFx = Utils.Constants.Empty.PrefabLink;
      }
      component.m_SideDisappearProjectile = sideDisappearProjectile?.Reference ?? component.m_SideDisappearProjectile;
      if (component.m_SideDisappearProjectile is null)
      {
        component.m_SideDisappearProjectile = BlueprintTool.GetRef<BlueprintProjectileReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomMeleeAttack"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>TwoHandedFighterDevastatingBlowAbility</term><description>13da184c7ffe08345aab674fd3a55eb0</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityCustomMeleeAttack(
        bool? hasIsAllyEffectRunConditions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        AbilityCustomMeleeAttack.AttackType? type = null)
    {
      var component = new AbilityCustomMeleeAttack();
      component.m_HasIsAllyEffectRunConditions = hasIsAllyEffectRunConditions ?? component.m_HasIsAllyEffectRunConditions;
      component.m_Type = type ?? component.m_Type;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomOverrun"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_Nahyndri_Golemlike_Overrun</term><description>a07795a1da3f4934ac6a87e11cc534f3</description></item>
    /// <item><term>OverrunAbility</term><description>1a3b471ecea51f7439a946b23577fd70</description></item>
    /// <item><term>TrampleAbility</term><description>c0045819547c07e40be13fe0a60e16d2</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="addBuffWhileRunning">
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
    /// <param name="delayAfterFinish">
    /// <para>
    /// Tooltip: Use delays to accomodate starting and finishing animations like takeoff/landing
    /// </para>
    /// </param>
    /// <param name="delayBeforeStart">
    /// <para>
    /// Tooltip: Use delays to accomodate starting and finishing animations like takeoff/landing
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityCustomOverrun(
        ActionsBuilder? actions = null,
        Blueprint<BlueprintBuffReference>? addBuffWhileRunning = null,
        bool? alongPath = null,
        bool? autoSuccess = null,
        float? delayAfterFinish = null,
        float? delayBeforeStart = null,
        bool? firstTargetOnly = null,
        bool? hasIsAllyEffectRunConditions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? stopOnCorpulence = null)
    {
      var component = new AbilityCustomOverrun();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.m_AddBuffWhileRunning = addBuffWhileRunning?.Reference ?? component.m_AddBuffWhileRunning;
      if (component.m_AddBuffWhileRunning is null)
      {
        component.m_AddBuffWhileRunning = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      component.AlongPath = alongPath ?? component.AlongPath;
      component.AutoSuccess = autoSuccess ?? component.AutoSuccess;
      component.DelayAfterFinish = delayAfterFinish ?? component.DelayAfterFinish;
      component.DelayBeforeStart = delayBeforeStart ?? component.DelayBeforeStart;
      component.FirstTargetOnly = firstTargetOnly ?? component.FirstTargetOnly;
      component.m_HasIsAllyEffectRunConditions = hasIsAllyEffectRunConditions ?? component.m_HasIsAllyEffectRunConditions;
      component.StopOnCorpulence = stopOnCorpulence ?? component.StopOnCorpulence;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomTeleportation"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonTeleport_Cutscene</term><description>9c2c6db42de64374bf2d26c08c573c92</description></item>
    /// <item><term>DemonTeleportCutsceneQuickened</term><description>3f4e1cc438ea4db198261b5a3e9b0307</description></item>
    /// <item><term>UncertanityPrincipleTeleport</term><description>66bbb0079b595874f8c698451be2329c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="appearFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="disappearFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="projectile">
    /// <para>
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddAbilityCustomTeleportation(
        bool? alongPath = null,
        float? alongPathDistanceMuliplier = null,
        float? appearDuration = null,
        AssetLink<PrefabLink>? appearFx = null,
        float? disappearDuration = null,
        AssetLink<PrefabLink>? disappearFx = null,
        bool? hasIsAllyEffectRunConditions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Blueprint<BlueprintProjectileReference>? projectile = null)
    {
      var component = new AbilityCustomTeleportation();
      component.AlongPath = alongPath ?? component.AlongPath;
      component.AlongPathDistanceMuliplier = alongPathDistanceMuliplier ?? component.AlongPathDistanceMuliplier;
      component.AppearDuration = appearDuration ?? component.AppearDuration;
      component.AppearFx = appearFx?.Get() ?? component.AppearFx;
      if (component.AppearFx is null)
      {
        component.AppearFx = Utils.Constants.Empty.PrefabLink;
      }
      component.DisappearDuration = disappearDuration ?? component.DisappearDuration;
      component.DisappearFx = disappearFx?.Get() ?? component.DisappearFx;
      if (component.DisappearFx is null)
      {
        component.DisappearFx = Utils.Constants.Empty.PrefabLink;
      }
      component.m_HasIsAllyEffectRunConditions = hasIsAllyEffectRunConditions ?? component.m_HasIsAllyEffectRunConditions;
      component.m_Projectile = projectile?.Reference ?? component.m_Projectile;
      if (component.m_Projectile is null)
      {
        component.m_Projectile = BlueprintTool.GetRef<BlueprintProjectileReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomVitalStrike"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>VitalStrikeAbility</term><description>efc60c91b8e64f244b95c66b270dbd7c</description></item>
    /// <item><term>VitalStrikeAbilityGreater</term><description>11f971b6453f74d4594c538e3c88d499</description></item>
    /// <item><term>VitalStrikeAbilityImproved</term><description>c714cd636700ac24a91ca3df43326b00</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="mythicBlueprint">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="rowdyFeature">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddAbilityCustomVitalStrike(
        bool? hasIsAllyEffectRunConditions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Blueprint<BlueprintFeatureReference>? mythicBlueprint = null,
        Blueprint<BlueprintFeatureReference>? rowdyFeature = null,
        int? vitalStrikeMod = null)
    {
      var component = new AbilityCustomVitalStrike();
      component.m_HasIsAllyEffectRunConditions = hasIsAllyEffectRunConditions ?? component.m_HasIsAllyEffectRunConditions;
      component.m_MythicBlueprint = mythicBlueprint?.Reference ?? component.m_MythicBlueprint;
      if (component.m_MythicBlueprint is null)
      {
        component.m_MythicBlueprint = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      component.m_RowdyFeature = rowdyFeature?.Reference ?? component.m_RowdyFeature;
      if (component.m_RowdyFeature is null)
      {
        component.m_RowdyFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      component.VitalStrikeMod = vitalStrikeMod ?? component.VitalStrikeMod;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityDeliverAttackWithWeapon"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CrushingBlowAbility</term><description>957a10e303269324dbf1a70513f37559</description></item>
    /// <item><term>TwoHandedFighterPiledriverBullRushAbility</term><description>b789cfc41fa326f419d77efc2e5c6632</description></item>
    /// <item><term>TwoHandedFighterPiledriverTripAbility</term><description>1202b3d188c9bdc46987a5da168ec6d9</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityDeliverAttackWithWeapon(
        bool? hasIsAllyEffectRunConditions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityDeliverAttackWithWeapon();
      component.m_HasIsAllyEffectRunConditions = hasIsAllyEffectRunConditions ?? component.m_HasIsAllyEffectRunConditions;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityDeliverChain"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbyssalChains</term><description>3b86de15c18e4b44bb7315fc6c116b4d</description></item>
    /// <item><term>MudBlastBladeDamage</term><description>f82cfcf11b94bef49bf1a8f57aad5c13</description></item>
    /// <item><term>WaterBlastBladeDamage</term><description>92724a6d6a6225d4895b41e35e973599</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="projectile">
    /// <para>
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="projectileFirst">
    /// <para>
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddAbilityDeliverChain(
        ConditionsBuilder? condition = null,
        bool? copyAttackRollFromWeaponEvent = null,
        bool? hasIsAllyEffectRunConditions = null,
        bool? ignoreFirst = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Blueprint<BlueprintProjectileReference>? projectile = null,
        Blueprint<BlueprintProjectileReference>? projectileFirst = null,
        Feet? radius = null,
        bool? targetDead = null,
        ContextValue? targetsCount = null,
        Kingmaker.UnitLogic.Abilities.Components.TargetType? targetType = null,
        bool? usedTargetsAgain = null)
    {
      var component = new AbilityDeliverChain();
      component.m_Condition = condition?.Build() ?? component.m_Condition;
      if (component.m_Condition is null)
      {
        component.m_Condition = Utils.Constants.Empty.Conditions;
      }
      component.m_CopyAttackRollFromWeaponEvent = copyAttackRollFromWeaponEvent ?? component.m_CopyAttackRollFromWeaponEvent;
      component.m_HasIsAllyEffectRunConditions = hasIsAllyEffectRunConditions ?? component.m_HasIsAllyEffectRunConditions;
      component.m_IgnoreFirst = ignoreFirst ?? component.m_IgnoreFirst;
      component.m_Projectile = projectile?.Reference ?? component.m_Projectile;
      if (component.m_Projectile is null)
      {
        component.m_Projectile = BlueprintTool.GetRef<BlueprintProjectileReference>(null);
      }
      component.m_ProjectileFirst = projectileFirst?.Reference ?? component.m_ProjectileFirst;
      if (component.m_ProjectileFirst is null)
      {
        component.m_ProjectileFirst = BlueprintTool.GetRef<BlueprintProjectileReference>(null);
      }
      component.Radius = radius ?? component.Radius;
      component.TargetDead = targetDead ?? component.TargetDead;
      component.TargetsCount = targetsCount ?? component.TargetsCount;
      if (component.TargetsCount is null)
      {
        component.TargetsCount = ContextValues.Constant(0);
      }
      component.m_TargetType = targetType ?? component.m_TargetType;
      component.m_UsedTargetsAgain = usedTargetsAgain ?? component.m_UsedTargetsAgain;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityDeliverClashingRocks"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ClashingRocks</term><description>01300baad090d634cb1a1b2defe068d6</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="projectile">
    /// <para>
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="weapon">
    /// <para>
    /// Blueprint of type BlueprintItemWeapon. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddAbilityDeliverClashingRocks(
        Feet? distanceToTarget = null,
        bool? hasIsAllyEffectRunConditions = null,
        bool? ignoreConcealment = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? needAttackRoll = null,
        Blueprint<BlueprintProjectileReference>? projectile = null,
        Blueprint<BlueprintItemWeaponReference>? weapon = null,
        Feet? width = null)
    {
      var component = new AbilityDeliverClashingRocks();
      component.DistanceToTarget = distanceToTarget ?? component.DistanceToTarget;
      component.m_HasIsAllyEffectRunConditions = hasIsAllyEffectRunConditions ?? component.m_HasIsAllyEffectRunConditions;
      component.IgnoreConcealment = ignoreConcealment ?? component.IgnoreConcealment;
      component.NeedAttackRoll = needAttackRoll ?? component.NeedAttackRoll;
      component.m_Projectile = projectile?.Reference ?? component.m_Projectile;
      if (component.m_Projectile is null)
      {
        component.m_Projectile = BlueprintTool.GetRef<BlueprintProjectileReference>(null);
      }
      component.m_Weapon = weapon?.Reference ?? component.m_Weapon;
      if (component.m_Weapon is null)
      {
        component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(null);
      }
      component.Width = width ?? component.Width;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityDeliverDelay"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbsoluteDeath</term><description>7d721be6d74f07f4d952ee8d6f8f44a0</description></item>
    /// <item><term>FlameStrike</term><description>f9910c76efc34af41b6e43d5d8752f0f</description></item>
    /// <item><term>Waterfall</term><description>e05a95d3cf386844f98e4710d9a4730b</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityDeliverDelay(
        float? delaySeconds = null,
        bool? hasIsAllyEffectRunConditions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityDeliverDelay();
      component.DelaySeconds = delaySeconds ?? component.DelaySeconds;
      component.m_HasIsAllyEffectRunConditions = hasIsAllyEffectRunConditions ?? component.m_HasIsAllyEffectRunConditions;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityDeliverProjectile"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbandonedKeep_AcidTrap</term><description>e7dadeb8b1d78a341bb4357b502da424</description></item>
    /// <item><term>FlamesOfTheAbyssRay</term><description>1f62a2340209bfb49843a9cdc08635e7</description></item>
    /// <item><term>Yozz_Ability_DirtyTrickBomb</term><description>5caabe7c38d24e7f905bb6f723d1eccc</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="controlledProjectileHolderBuff">
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
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="projectiles">
    /// <para>
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="weapon">
    /// <para>
    /// Blueprint of type BlueprintItemWeapon. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddAbilityDeliverProjectile(
        StatType? attackRollBonusStat = null,
        Blueprint<BlueprintBuffReference>? controlledProjectileHolderBuff = null,
        float? delayBetweenProjectiles = null,
        bool? hasIsAllyEffectRunConditions = null,
        bool? isHandOfTheApprentice = null,
        Feet? length = null,
        Feet? lineWidth = null,
        AbilityRankType? maxProjectilesCountRank = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? needAttackRoll = null,
        List<Blueprint<BlueprintProjectileReference>>? projectiles = null,
        bool? replaceAttackRollBonusStat = null,
        AbilityProjectileType? type = null,
        bool? useMaxProjectilesCount = null,
        Blueprint<BlueprintItemWeaponReference>? weapon = null)
    {
      var component = new AbilityDeliverProjectile();
      component.AttackRollBonusStat = attackRollBonusStat ?? component.AttackRollBonusStat;
      component.m_ControlledProjectileHolderBuff = controlledProjectileHolderBuff?.Reference ?? component.m_ControlledProjectileHolderBuff;
      if (component.m_ControlledProjectileHolderBuff is null)
      {
        component.m_ControlledProjectileHolderBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      component.DelayBetweenProjectiles = delayBetweenProjectiles ?? component.DelayBetweenProjectiles;
      component.m_HasIsAllyEffectRunConditions = hasIsAllyEffectRunConditions ?? component.m_HasIsAllyEffectRunConditions;
      component.IsHandOfTheApprentice = isHandOfTheApprentice ?? component.IsHandOfTheApprentice;
      component.m_Length = length ?? component.m_Length;
      component.m_LineWidth = lineWidth ?? component.m_LineWidth;
      component.MaxProjectilesCountRank = maxProjectilesCountRank ?? component.MaxProjectilesCountRank;
      component.NeedAttackRoll = needAttackRoll ?? component.NeedAttackRoll;
      component.m_Projectiles = projectiles?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Projectiles;
      if (component.m_Projectiles is null)
      {
        component.m_Projectiles = new BlueprintProjectileReference[0];
      }
      component.ReplaceAttackRollBonusStat = replaceAttackRollBonusStat ?? component.ReplaceAttackRollBonusStat;
      component.Type = type ?? component.Type;
      component.UseMaxProjectilesCount = useMaxProjectilesCount ?? component.UseMaxProjectilesCount;
      component.m_Weapon = weapon?.Reference ?? component.m_Weapon;
      if (component.m_Weapon is null)
      {
        component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityDeliverProjectileOnGrid"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Angel4BladeOfTheSunAbility</term><description>b7b4901fed7b4229b2f85541de80d64c</description></item>
    /// <item><term>ArmyBreathWeaponAbilitySilverDragon</term><description>ba072e384d6c417b822f518999b3c85b</description></item>
    /// <item><term>RitualBoneArrowAbility</term><description>f96761c8b20647298197348d8d8907fe</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="controlledProjectileHolderBuff">
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
    /// <param name="launchProjectileOnGridLine">
    /// <para>
    /// InfoBox: Get start and target positions for projectiles from AbilityAffectLineOnGrid
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="projectiles">
    /// <para>
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="weapon">
    /// <para>
    /// Blueprint of type BlueprintItemWeapon. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddAbilityDeliverProjectileOnGrid(
        StatType? attackRollBonusStat = null,
        Blueprint<BlueprintBuffReference>? controlledProjectileHolderBuff = null,
        float? delayBetweenProjectiles = null,
        bool? hasIsAllyEffectRunConditions = null,
        bool? isHandOfTheApprentice = null,
        bool? launchProjectileOnGridLine = null,
        Feet? length = null,
        int? lengthInCells = null,
        Feet? lineWidth = null,
        AbilityRankType? maxProjectilesCountRank = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? needAttackRoll = null,
        List<Blueprint<BlueprintProjectileReference>>? projectiles = null,
        bool? replaceAttackRollBonusStat = null,
        AbilityProjectileType? type = null,
        bool? useMaxProjectilesCount = null,
        Blueprint<BlueprintItemWeaponReference>? weapon = null)
    {
      var component = new AbilityDeliverProjectileOnGrid();
      component.AttackRollBonusStat = attackRollBonusStat ?? component.AttackRollBonusStat;
      component.m_ControlledProjectileHolderBuff = controlledProjectileHolderBuff?.Reference ?? component.m_ControlledProjectileHolderBuff;
      if (component.m_ControlledProjectileHolderBuff is null)
      {
        component.m_ControlledProjectileHolderBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      component.DelayBetweenProjectiles = delayBetweenProjectiles ?? component.DelayBetweenProjectiles;
      component.m_HasIsAllyEffectRunConditions = hasIsAllyEffectRunConditions ?? component.m_HasIsAllyEffectRunConditions;
      component.IsHandOfTheApprentice = isHandOfTheApprentice ?? component.IsHandOfTheApprentice;
      component.LaunchProjectileOnGridLine = launchProjectileOnGridLine ?? component.LaunchProjectileOnGridLine;
      component.m_Length = length ?? component.m_Length;
      component.LengthInCells = lengthInCells ?? component.LengthInCells;
      component.m_LineWidth = lineWidth ?? component.m_LineWidth;
      component.MaxProjectilesCountRank = maxProjectilesCountRank ?? component.MaxProjectilesCountRank;
      component.NeedAttackRoll = needAttackRoll ?? component.NeedAttackRoll;
      component.m_Projectiles = projectiles?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Projectiles;
      if (component.m_Projectiles is null)
      {
        component.m_Projectiles = new BlueprintProjectileReference[0];
      }
      component.ReplaceAttackRollBonusStat = replaceAttackRollBonusStat ?? component.ReplaceAttackRollBonusStat;
      component.Type = type ?? component.Type;
      component.UseMaxProjectilesCount = useMaxProjectilesCount ?? component.UseMaxProjectilesCount;
      component.m_Weapon = weapon?.Reference ?? component.m_Weapon;
      if (component.m_Weapon is null)
      {
        component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityDeliverTouch"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AngelBringBackTouch</term><description>067035da0186d6e43bb4138f433911ee</description></item>
    /// <item><term>Heal</term><description>ff8f1534f66559c478448723e16b6624</description></item>
    /// <item><term>ZachariusParalyzingTouchAbility</term><description>dbd157bc98c11a341b3b605ad58d5a57</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="touchWeapon">
    /// <para>
    /// Blueprint of type BlueprintItemWeapon. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddAbilityDeliverTouch(
        bool? hasIsAllyEffectRunConditions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Blueprint<BlueprintItemWeaponReference>? touchWeapon = null)
    {
      var component = new AbilityDeliverTouch();
      component.m_HasIsAllyEffectRunConditions = hasIsAllyEffectRunConditions ?? component.m_HasIsAllyEffectRunConditions;
      component.m_TouchWeapon = touchWeapon?.Reference ?? component.m_TouchWeapon;
      if (component.m_TouchWeapon is null)
      {
        component.m_TouchWeapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityDeliveredByWeapon"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AirBlastKineticBladeDamage</term><description>89cc522f2e1444b40ba1757320c58530</description></item>
    /// <item><term>IceBlastBladeDamage</term><description>8c8dd4e7c07e468498a6f5ed2c01063f</description></item>
    /// <item><term>WaterBlastBladeDamage</term><description>92724a6d6a6225d4895b41e35e973599</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityDeliveredByWeapon(
        bool? hasIsAllyEffectRunConditions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityDeliveredByWeapon();
      component.m_HasIsAllyEffectRunConditions = hasIsAllyEffectRunConditions ?? component.m_HasIsAllyEffectRunConditions;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityDifficultyLimitDC"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>StewardOfTheSkeinGazeBuff</term><description>4f18044ca197eb945b7d1b557dd9b447</description></item>
    /// <item><term>Weird</term><description>870af83be6572594d84d276d7fc583e0</description></item>
    /// <item><term>WildHunt_ScoutCrystalAbility</term><description>c470c62b38db74e4fb6b84b331beda30</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityDifficultyLimitDC(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityDifficultyLimitDC();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityEffectRunActionOnClickedTarget"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BatteringBlast</term><description>0a2f7c6aa81bc6548ac7780d8b70bcbc</description></item>
    /// <item><term>ObsidianFlow</term><description>e48638596c955a74c8a32dbc90b518c1</description></item>
    /// <item><term>VolcanicStorm</term><description>16ce660837fb2544e96c3b7eaad73c63</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityEffectRunActionOnClickedTarget(
        ActionsBuilder? action = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityEffectRunActionOnClickedTarget();
      component.Action = action?.Build() ?? component.Action;
      if (component.Action is null)
      {
        component.Action = Utils.Constants.Empty.Actions;
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityEffectStickyTouch"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AngelBringBackCast</term><description>eb0d3e22826725d4199a3aac0db0ad50</description></item>
    /// <item><term>ForcePunchCast</term><description>fc58ddcff6ab1394eb6c18e9126bb990</description></item>
    /// <item><term>WhiteMageCureSeriousWoundsCast</term><description>1203e2dab8a593a459c0cc688f568052</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="touchDeliveryAbility">
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
    public TBuilder AddAbilityEffectStickyTouch(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Blueprint<BlueprintAbilityReference>? touchDeliveryAbility = null)
    {
      var component = new AbilityEffectStickyTouch();
      component.m_TouchDeliveryAbility = touchDeliveryAbility?.Reference ?? component.m_TouchDeliveryAbility;
      if (component.m_TouchDeliveryAbility is null)
      {
        component.m_TouchDeliveryAbility = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityIsBomb"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcidBomb</term><description>fd101fbc4aacf5d48b76a65e3aa5db6d</description></item>
    /// <item><term>CurseWeaknessBomb</term><description>197624a197c10cb48bc4dcb229efb91b</description></item>
    /// <item><term>TanglefootBomb</term><description>526aa6319e9174e4ab2026e0f299b011</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityIsBomb(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityIsBomb();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityKineticBlade"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>KineticBladeAirBlastBurnAbility</term><description>77cb8c607b263194894a929c8ac59708</description></item>
    /// <item><term>KineticBladeIceBlastBurnAbility</term><description>9b8ea70f14970f946ad6c26694062a3f</description></item>
    /// <item><term>KineticBladeWaterBlastBurnAbility</term><description>cf09fb24e432a5c49a1bd9add89699ee</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityKineticBlade(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityKineticBlade();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityRequirementCanMove"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ChargeAbility</term><description>c78506dd0e14f7c45a599990e4e65038</description></item>
    /// <item><term>DLC3_Nahyndri_Golemlike_Overrun</term><description>a07795a1da3f4934ac6a87e11cc534f3</description></item>
    /// <item><term>OverrunAbility</term><description>1a3b471ecea51f7439a946b23577fd70</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityRequirementCanMove(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityRequirementCanMove();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityRequirementHasCondition"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ChargeAbility</term><description>c78506dd0e14f7c45a599990e4e65038</description></item>
    /// <item><term>SwiftBlowImprovedChargeAbility</term><description>d4b4757660cb66e4fbf376a43f1ffb13</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityRequirementHasCondition(
        UnitCondition[]? conditions = null,
        List<UnitCondition>? conditionsCache = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? not = null)
    {
      var component = new AbilityRequirementHasCondition();
      component.Conditions = conditions ?? component.Conditions;
      if (component.Conditions is null)
      {
        component.Conditions = new UnitCondition[0];
      }
      component.m_ConditionsCache = conditionsCache ?? component.m_ConditionsCache;
      if (component.m_ConditionsCache is null)
      {
        component.m_ConditionsCache = new();
      }
      component.Not = not ?? component.Not;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityRequirementHasItemInHands"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ChargeAbility</term><description>c78506dd0e14f7c45a599990e4e65038</description></item>
    /// <item><term>SwiftBlowImprovedChargeAbility</term><description>d4b4757660cb66e4fbf376a43f1ffb13</description></item>
    /// <item><term>WarpriestShieldbearerChannelPositiveHarm</term><description>894e20539c353c74ab2733a056351947</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityRequirementHasItemInHands(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        AbilityRequirementHasItemInHands.RequirementType? type = null)
    {
      var component = new AbilityRequirementHasItemInHands();
      component.m_Type = type ?? component.m_Type;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityResourceLogic"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbjurationResistanceAcidAbility</term><description>9b415e09847398644ad6e57a9e3ab06a</description></item>
    /// <item><term>HellsSealVariantDevouringFlames</term><description>0130bffa460e0b4439e7283b68db025c</description></item>
    /// <item><term>WitchWanderingHexAbility</term><description>b209beab784d93546b40a2fa2a09ffa8</description></item>
    /// </list>
    /// </remarks>
    ///
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
    public TBuilder AddAbilityResourceLogic(
        int? amount = null,
        bool? costIsCustom = null,
        bool? isSpendResource = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Blueprint<BlueprintAbilityResourceReference>? requiredResource = null,
        List<Blueprint<BlueprintUnitFactReference>>? resourceCostDecreasingFacts = null,
        List<Blueprint<BlueprintUnitFactReference>>? resourceCostIncreasingFacts = null)
    {
      var component = new AbilityResourceLogic();
      component.Amount = amount ?? component.Amount;
      component.CostIsCustom = costIsCustom ?? component.CostIsCustom;
      component.m_IsSpendResource = isSpendResource ?? component.m_IsSpendResource;
      component.m_RequiredResource = requiredResource?.Reference ?? component.m_RequiredResource;
      if (component.m_RequiredResource is null)
      {
        component.m_RequiredResource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(null);
      }
      component.ResourceCostDecreasingFacts = resourceCostDecreasingFacts?.Select(bp => bp.Reference)?.ToList() ?? component.ResourceCostDecreasingFacts;
      if (component.ResourceCostDecreasingFacts is null)
      {
        component.ResourceCostDecreasingFacts = new();
      }
      component.ResourceCostIncreasingFacts = resourceCostIncreasingFacts?.Select(bp => bp.Reference)?.ToList() ?? component.ResourceCostIncreasingFacts;
      if (component.ResourceCostIncreasingFacts is null)
      {
        component.ResourceCostIncreasingFacts = new();
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityRestoreSpellSlot"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>EcclesitheurgeBondAbility</term><description>f7ca063cf120f9f49a81fd3fca3484a8</description></item>
    /// <item><term>MagicBlessingMajorAbility</term><description>f67e58b9bb7003a4aaea0deba52b3fd9</description></item>
    /// <item><term>ShamanItemBondAbility</term><description>182479736b748334db21b4e72ca67382</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityRestoreSpellSlot(
        bool? anySpellLevel = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        int? spellLevel = null)
    {
      var component = new AbilityRestoreSpellSlot();
      component.AnySpellLevel = anySpellLevel ?? component.AnySpellLevel;
      component.SpellLevel = spellLevel ?? component.SpellLevel;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityRestoreSpontaneousSpell"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BloodlineArcaneItemBondAbility</term><description>f53bcb83230246a78ba283edb32648bc</description></item>
    /// <item><term>HeraldOfTheHornItemBondAbility</term><description>60aafc4ffa732bb4a96c6c981658d072</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityRestoreSpontaneousSpell(
        bool? anySpellLevel = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        int? spellLevel = null)
    {
      var component = new AbilityRestoreSpontaneousSpell();
      component.AnySpellLevel = anySpellLevel ?? component.AnySpellLevel;
      component.SpellLevel = spellLevel ?? component.SpellLevel;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityShadowSpell"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AnomalyTemplateAnomalySpell</term><description>963476dd42ad4ae6ac744eb32cb6ec2d</description></item>
    /// <item><term>ShadowConjurationGreater</term><description>08255ea4cdd812341af93f9cd113acb9</description></item>
    /// <item><term>ShadowEvocationGreater</term><description>3c4a2d4181482e84d9cd752ef8edc3b6</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="factor">
    /// <para>
    /// Tooltip: Occur chance and damage factor
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintUnitProperty. You can pass in the blueprint using:
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
    /// <param name="spellList">
    /// <para>
    /// Blueprint of type BlueprintSpellList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddAbilityShadowSpell(
        bool? anySchool = null,
        Blueprint<BlueprintUnitPropertyReference>? factor = null,
        bool? hasIsAllyEffectRunConditions = null,
        int? maxSpellLevel = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        SpellSchool? school = null,
        Blueprint<BlueprintSpellListReference>? spellList = null)
    {
      var component = new AbilityShadowSpell();
      component.AnySchool = anySchool ?? component.AnySchool;
      component.m_Factor = factor?.Reference ?? component.m_Factor;
      if (component.m_Factor is null)
      {
        component.m_Factor = BlueprintTool.GetRef<BlueprintUnitPropertyReference>(null);
      }
      component.m_HasIsAllyEffectRunConditions = hasIsAllyEffectRunConditions ?? component.m_HasIsAllyEffectRunConditions;
      component.MaxSpellLevel = maxSpellLevel ?? component.MaxSpellLevel;
      component.School = school ?? component.School;
      component.SpellList = spellList?.Reference ?? component.SpellList;
      if (component.SpellList is null)
      {
        component.SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityShowIfCasterHasFact"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AirBlastBase</term><description>0ab1552e2ebdacf44bb7b20f5393366d</description></item>
    /// <item><term>MagmaBlastBase</term><description>8c25f52fce5113a4491229fd1265fc3c</description></item>
    /// <item><term>WrackBloodBlastAbility</term><description>0199d49f59833104198e2c0196235a45</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="unitFact">
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
    public TBuilder AddAbilityShowIfCasterHasFact(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? not = null,
        Blueprint<BlueprintUnitFactReference>? unitFact = null)
    {
      var component = new AbilityShowIfCasterHasFact();
      component.Not = not ?? component.Not;
      component.m_UnitFact = unitFact?.Reference ?? component.m_UnitFact;
      if (component.m_UnitFact is null)
      {
        component.m_UnitFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetsAround"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>1_FirstDeathAbility</term><description>4445d9d1c21141c6a0bb24baf373ef78</description></item>
    /// <item><term>HellknightCommandGreaterFlee</term><description>e79bc406d19f69447b9dae2efc6803ab</description></item>
    /// <item><term>ZombieSlashingExplosion</term><description>f6b63adab8b645c8beb9cab170dac9d3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="spreadSpeed">
    /// <para>
    /// Tooltip: Feet per second
    /// </para>
    /// </param>
    public TBuilder AddAbilityTargetsAround(
        ConditionsBuilder? condition = null,
        bool? includeDead = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Feet? radius = null,
        Feet? spreadSpeed = null,
        Kingmaker.UnitLogic.Abilities.Components.TargetType? targetType = null)
    {
      var component = new AbilityTargetsAround();
      component.m_Condition = condition?.Build() ?? component.m_Condition;
      if (component.m_Condition is null)
      {
        component.m_Condition = Utils.Constants.Empty.Conditions;
      }
      component.m_IncludeDead = includeDead ?? component.m_IncludeDead;
      component.m_Radius = radius ?? component.m_Radius;
      component.m_SpreadSpeed = spreadSpeed ?? component.m_SpreadSpeed;
      component.m_TargetType = targetType ?? component.m_TargetType;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetsAroundOnGrid"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon5BaneOfDemonsAbility</term><description>843145bc1b9b45229c40b1a2128095f0</description></item>
    /// <item><term>Azata5SongOfTheLastPushAbility</term><description>c3528f00073846f39a14546b4026a1b1</description></item>
    /// <item><term>RitualTrueStrikeAbility</term><description>f0a80ef2bcf447058148c9547b9afabe</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="diameterInCells">
    /// <para>
    /// InfoBox: For now only odd diameters can be used. 1 -&amp;gt; 1 cell, 3 -&amp;gt; 9 cells, ...
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="spreadSpeed">
    /// <para>
    /// Tooltip: Feet per second
    /// </para>
    /// </param>
    public TBuilder AddAbilityTargetsAroundOnGrid(
        ConditionsBuilder? condition = null,
        int? diameterInCells = null,
        bool? includeDead = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Feet? spreadSpeed = null,
        Kingmaker.UnitLogic.Abilities.Components.TargetType? targetType = null)
    {
      var component = new AbilityTargetsAroundOnGrid();
      component.m_Condition = condition?.Build() ?? component.m_Condition;
      if (component.m_Condition is null)
      {
        component.m_Condition = Utils.Constants.Empty.Conditions;
      }
      component.m_DiameterInCells = diameterInCells ?? component.m_DiameterInCells;
      component.m_IncludeDead = includeDead ?? component.m_IncludeDead;
      component.m_SpreadSpeed = spreadSpeed ?? component.m_SpreadSpeed;
      component.m_TargetType = targetType ?? component.m_TargetType;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityUseOnRest"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AngelBringBackCast</term><description>eb0d3e22826725d4199a3aac0db0ad50</description></item>
    /// <item><term>InflictLightWoundsMass</term><description>9da37873d79ef0a468f969e4e5116ad2</description></item>
    /// <item><term>WitchDoctorChannelEnergy</term><description>d470eb6b3b31fde4bb44ec753de0b862</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="baseValue">
    /// <para>
    /// InfoBox: `Approximated minimum` that would be used in Rest days count calculations
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityUseOnRest(
        bool? addCasterLevel = null,
        int? baseValue = null,
        int? maxCasterLevel = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? multiplyByCasterLevel = null,
        AbilityUseOnRestType? type = null)
    {
      var component = new AbilityUseOnRest();
      component.AddCasterLevel = addCasterLevel ?? component.AddCasterLevel;
      component.BaseValue = baseValue ?? component.BaseValue;
      component.MaxCasterLevel = maxCasterLevel ?? component.MaxCasterLevel;
      component.MultiplyByCasterLevel = multiplyByCasterLevel ?? component.MultiplyByCasterLevel;
      component.Type = type ?? component.Type;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityCanTargetDead"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Archpriest_PossessionAbility</term><description>a3855d55b2304f89b63ebd1a9b1dc144</description></item>
    /// <item><term>FocusCrystall_Ability_DeathThroes</term><description>dd70e56b1c494c468150f5e320effbb0</description></item>
    /// <item><term>ZombieSlashingExplosion</term><description>f6b63adab8b645c8beb9cab170dac9d3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityCanTargetDead(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityCanTargetDead();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetAlignment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Predicates/Target has alignment
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BestowGraceOfTheChampionCast</term><description>199d585bff173c74b86387856919242c</description></item>
    /// <item><term>BloodlineCelestialHeavenlyFireAbility</term><description>64aca51981fc11346a20b723d7667e47</description></item>
    /// <item><term>ChallengeEvil</term><description>57aae1aa36b8022479e1cd39f3a85ef9</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityTargetAlignment(
        AlignmentMaskType? alignment = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityTargetAlignment();
      component.Alignment = alignment ?? component.Alignment;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetBreathOfLife"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AngelBringBackCast</term><description>eb0d3e22826725d4199a3aac0db0ad50</description></item>
    /// <item><term>FlamewardenEmbersCast</term><description>8c95de0803fdfbd458fa7c0d29d5d8b9</description></item>
    /// <item><term>WhiteMageBreathOfLifeCast</term><description>5a90d9e5854c36e459de57318a45af97</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="recentlyDeadBuff">
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
    /// <param name="undeadFact">
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
    public TBuilder AddAbilityTargetBreathOfLife(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Blueprint<BlueprintBuffReference>? recentlyDeadBuff = null,
        Blueprint<BlueprintUnitFactReference>? undeadFact = null)
    {
      var component = new AbilityTargetBreathOfLife();
      component.m_RecentlyDeadBuff = recentlyDeadBuff?.Reference ?? component.m_RecentlyDeadBuff;
      if (component.m_RecentlyDeadBuff is null)
      {
        component.m_RecentlyDeadBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      component.m_UndeadFact = undeadFact?.Reference ?? component.m_UndeadFact;
      if (component.m_UndeadFact is null)
      {
        component.m_UndeadFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetCanSeeCaster"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Predicates/Target can see caster
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AssassinDeathAttackAbility</term><description>744e7c7fd58bd6040b40210cf0864692</description></item>
    /// <item><term>AssassinDeathAttackAbilityParalyze</term><description>452b64ffab80cff40bd27dc5f350d80c</description></item>
    /// <item><term>ExecutionerAssassinateAbility</term><description>3dad7f131aa884f4c972f2fb759d0df4</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddAbilityTargetCanSeeCaster(
        bool? not = null)
    {
      var component = new AbilityTargetCanSeeCaster();
      component.Not = not ?? component.Not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetCellsRestriction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Angel3SummonHeavenlyHostAbility</term><description>f317d44314a843e7aaf3fc202cbe9577</description></item>
    /// <item><term>ArmySummonSchir</term><description>4212e78cab304071801f7cb6e9accc48</description></item>
    /// <item><term>SummonSquad</term><description>6fd4d245dd129af45a802dedff113c0d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="allowedColumns">
    /// <para>
    /// InfoBox: Keep empty to allow all cells
    /// </para>
    /// </param>
    /// <param name="factionDependent">
    /// <para>
    /// InfoBox: If True, 0 column means left for Crusaders and right for Demons
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityTargetCellsRestriction(
        List<int>? allowedColumns = null,
        int? diameter = null,
        bool? factionDependent = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? onlyEmptyCells = null)
    {
      var component = new AbilityTargetCellsRestriction();
      component.m_AllowedColumns = allowedColumns ?? component.m_AllowedColumns;
      if (component.m_AllowedColumns is null)
      {
        component.m_AllowedColumns = new();
      }
      component.m_Diameter = diameter ?? component.m_Diameter;
      component.m_FactionDependent = factionDependent ?? component.m_FactionDependent;
      component.m_OnlyEmptyCells = onlyEmptyCells ?? component.m_OnlyEmptyCells;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetDivineTroth"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Predicates/Target has fact
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>LayOnHandsSelfOrTroth</term><description>8337cea04c8afd1428aad69defbfc365</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="checkBuff">
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
    public TBuilder AddAbilityTargetDivineTroth(
        Blueprint<BlueprintBuffReference>? checkBuff = null)
    {
      var component = new AbilityTargetDivineTroth();
      component.m_CheckBuff = checkBuff?.Reference ?? component.m_CheckBuff;
      if (component.m_CheckBuff is null)
      {
        component.m_CheckBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetHPCondition"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Predicates/Target HP condition
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>EmergencyHelpAbility</term><description>21d6ed348ed6b754c937085dd75bc08d</description></item>
    /// <item><term>PowerWordBlind</term><description>261e1788bfc5ac1419eec68b1d485dbc</description></item>
    /// <item><term>Stabilize</term><description>0557ccee0a86dc44cb3d3f6a3b235329</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="factToCheck">
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
    /// <param name="overrideCurrentHPLessThan">
    /// <para>
    /// InfoBox: If caster has fact to check, then override CurrentHPLessThan
    /// </para>
    /// </param>
    public TBuilder AddAbilityTargetHPCondition(
        bool? checkFact = null,
        int? currentHPLessThan = null,
        Blueprint<BlueprintUnitFactReference>? factToCheck = null,
        bool? inverted = null,
        int? overrideCurrentHPLessThan = null)
    {
      var component = new AbilityTargetHPCondition();
      component.CheckFact = checkFact ?? component.CheckFact;
      component.CurrentHPLessThan = currentHPLessThan ?? component.CurrentHPLessThan;
      component.m_FactToCheck = factToCheck?.Reference ?? component.m_FactToCheck;
      if (component.m_FactToCheck is null)
      {
        component.m_FactToCheck = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      component.Inverted = inverted ?? component.Inverted;
      component.OverrideCurrentHPLessThan = overrideCurrentHPLessThan ?? component.OverrideCurrentHPLessThan;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetHasCondition"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BloodlineElementalWaterElementalMovementFeature</term><description>737ef897849327b45b88b83a797918c8</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddAbilityTargetHasCondition(
        UnitCondition? condition = null,
        bool? not = null)
    {
      var component = new AbilityTargetHasCondition();
      component.Condition = condition ?? component.Condition;
      component.Not = not ?? component.Not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetHasConditionOrBuff"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Archpriest_PossessionAbility_ShadowBalorEncounter</term><description>281769cdd7d94eb799e3c5071289fbf7</description></item>
    /// <item><term>DLC3_Nahyndri_FinalBoss_LongRageSpikes</term><description>6bb4e58567574e2bbd2c7d581280a8d8</description></item>
    /// <item><term>RepurposeForcedEnd</term><description>9520c680f8584c3b8c165fae9f05278d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="buffs">
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
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityTargetHasConditionOrBuff(
        List<Blueprint<BlueprintBuffReference>>? buffs = null,
        UnitCondition? condition = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? not = null)
    {
      var component = new AbilityTargetHasConditionOrBuff();
      component.m_Buffs = buffs?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Buffs;
      if (component.m_Buffs is null)
      {
        component.m_Buffs = new BlueprintBuffReference[0];
      }
      component.Condition = condition ?? component.Condition;
      component.Not = not ?? component.Not;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetHasFact"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Predicates/Target has fact
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbsoluteOrderApproach</term><description>d5f853d35d58c104eaa7eab50c25de39</description></item>
    /// <item><term>OracleBonesPowerWordKill</term><description>f010e072fd6c1794baf2975e446577e7</description></item>
    /// <item><term>WitchHexVulnerabilityCurseAbility</term><description>8f0eb58c2d6aeab4e8523ec85b4b2bc7</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="checkedFacts">
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
    public TBuilder AddAbilityTargetHasFact(
        List<Blueprint<BlueprintUnitFactReference>>? checkedFacts = null,
        bool? inverted = null)
    {
      var component = new AbilityTargetHasFact();
      component.m_CheckedFacts = checkedFacts?.Select(bp => bp.Reference)?.ToArray() ?? component.m_CheckedFacts;
      if (component.m_CheckedFacts is null)
      {
        component.m_CheckedFacts = new BlueprintUnitFactReference[0];
      }
      component.Inverted = inverted ?? component.Inverted;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetHasMeleeWeaponInPrimaryHand"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CrusadersEdge</term><description>a26c23a887a6f154491dc2cefdad2c35</description></item>
    /// <item><term>CrusadersEdgeCast</term><description>be5452c422a6ea744bf1037b0a443bb1</description></item>
    /// <item><term>ResoundingBlow</term><description>9047cb1797639924487ec0ad566a3fea</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityTargetHasMeleeWeaponInPrimaryHand(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityTargetHasMeleeWeaponInPrimaryHand();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetHasNoFactUnless"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Predicates/Target has fact
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbsoluteOrderApproach</term><description>d5f853d35d58c104eaa7eab50c25de39</description></item>
    /// <item><term>DominatePersonKitsune</term><description>2e963a674f99c4c48baabcc515360611</description></item>
    /// <item><term>PowerWordKill</term><description>2f8a67c483dfa0f439b293e094ca9e3c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="checkedFacts">
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
    /// <param name="unlessFact">
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
    public TBuilder AddAbilityTargetHasNoFactUnless(
        List<Blueprint<BlueprintUnitFactReference>>? checkedFacts = null,
        Blueprint<BlueprintUnitFactReference>? unlessFact = null)
    {
      var component = new AbilityTargetHasNoFactUnless();
      component.m_CheckedFacts = checkedFacts?.Select(bp => bp.Reference)?.ToArray() ?? component.m_CheckedFacts;
      if (component.m_CheckedFacts is null)
      {
        component.m_CheckedFacts = new BlueprintUnitFactReference[0];
      }
      component.m_UnlessFact = unlessFact?.Reference ?? component.m_UnlessFact;
      if (component.m_UnlessFact is null)
      {
        component.m_UnlessFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetHasOneOfConditionsOrHP"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BloodDrinkerAbility</term><description>be35623d2c561c649b98a1794216e9f9</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityTargetHasOneOfConditionsOrHP(
        UnitCondition[]? condition = null,
        int? currentHPLessThan = null,
        bool? invertedHP = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? needHPCondition = null)
    {
      var component = new AbilityTargetHasOneOfConditionsOrHP();
      component.Condition = condition ?? component.Condition;
      if (component.Condition is null)
      {
        component.Condition = new UnitCondition[0];
      }
      component.CurrentHPLessThan = currentHPLessThan ?? component.CurrentHPLessThan;
      component.InvertedHP = invertedHP ?? component.InvertedHP;
      component.NeedHPCondition = needHPCondition ?? component.NeedHPCondition;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsAlly"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Predicates/Target has fact
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonSecondLevelAbility</term><description>d87bd4bfc3e50af4ea1d9be5b4735ea1</description></item>
    /// <item><term>RemoveCurse 4</term><description>55b85c03103de184091a96eeaed4de25</description></item>
    /// <item><term>WitchHexVulnerabilityCurseAbility</term><description>8f0eb58c2d6aeab4e8523ec85b4b2bc7</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddAbilityTargetIsAlly(
        bool? not = null)
    {
      var component = new AbilityTargetIsAlly();
      component.Not = not ?? component.Not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsAnimalCompanion"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>EmergencySwapAbility</term><description>b50ca9b5d6292fb42b8eab8e5d64842d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityTargetIsAnimalCompanion(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? not = null)
    {
      var component = new AbilityTargetIsAnimalCompanion();
      component.Not = not ?? component.Not;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsAreaEffectFromCaster"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DismissAreaEffect</term><description>97a23111df7547fd8f6417f9ba9b9775</description></item>
    /// <item><term>DismissInfusionAbility</term><description>feba4322f7614276a69efece6d5093c3</description></item>
    /// <item><term>DLC3_Nahyndri_Golemlike_Ranged_Spikes</term><description>618ab32332774a978c0f762c1e3505fa</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityTargetIsAreaEffectFromCaster(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityTargetIsAreaEffectFromCaster();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsDeadAnimalCompanion"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>HunterRaiseCompanionAbility</term><description>247bb6b853aa06149b5ec9d5908ea0cd</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityTargetIsDeadAnimalCompanion(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityTargetIsDeadAnimalCompanion();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsDeadCompanion"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AngelfireApostleVersatileChannelResurrection</term><description>ad3aa8d5ef1c870448c23aae301a45b6</description></item>
    /// <item><term>RaiseDead</term><description>a0fc99f0933d01643b2b8fe570caa4c5</description></item>
    /// <item><term>WitchHexLifeGiverAbility</term><description>cedc4959ab311d548881844eecddf57a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityTargetIsDeadCompanion(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityTargetIsDeadCompanion();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsNotDevoured"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SwarmDevourAbility</term><description>dabe876d25b785d4caa22b7a23b6fa67</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityTargetIsNotDevoured(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityTargetIsNotDevoured();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsPartyMember"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Predicates/Target has fact
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Blur</term><description>14ec7a4e52e90fa47a4c8d63c69fd5c1</description></item>
    /// <item><term>MageLightBackgrounds</term><description>3487a9c9caf2f7748add6ebe74cda867</description></item>
    /// <item><term>StoneskinQuickened_Cutscene</term><description>3629dda7a449e4547939024611400e13</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddAbilityTargetIsPartyMember(
        bool? not = null)
    {
      var component = new AbilityTargetIsPartyMember();
      component.Not = not ?? component.Not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsSuitableMount"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>MountTargetAbility</term><description>9f8c0f4fcabdb3145b449826d17da18d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityTargetIsSuitableMount(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityTargetIsSuitableMount();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetIsSuitableMountSize"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>MountTargetAbility</term><description>9f8c0f4fcabdb3145b449826d17da18d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityTargetIsSuitableMountSize(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityTargetIsSuitableMountSize();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetMaximumHitDice"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Predicates/Target has Hit Dice lower
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Daze</term><description>55f14bc84d7c85446b07a1b5dd6b2b4c</description></item>
    /// <item><term>DazeBackgrounds</term><description>1619178bcceb4744db1755672746173c</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddAbilityTargetMaximumHitDice(
        int? hitDice = null)
    {
      var component = new AbilityTargetMaximumHitDice();
      component.HitDice = hitDice ?? component.HitDice;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetNotSelf"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyLayOnHandsAbility</term><description>9065aa008176426b80729aac297f117b</description></item>
    /// <item><term>LayOnHandsOthers</term><description>caae1dc6fcf7b37408686971ee27db13</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityTargetNotSelf(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityTargetNotSelf();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetRangeRestriction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>EmergencySwapAbility</term><description>b50ca9b5d6292fb42b8eab8e5d64842d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityTargetRangeRestriction(
        CompareOperation.Type? compareType = null,
        Feet? distance = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityTargetRangeRestriction();
      component.CompareType = compareType ?? component.CompareType;
      component.Distance = distance ?? component.Distance;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityTargetStatCondition"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Predicates/Target has stat
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>HideousLaughter</term><description>fd4d9fd7f87575d47aafe2a64a6e2d8d</description></item>
    /// <item><term>HideousLaughterTiefling</term><description>ae9e3a143e40f20419aa2b1ec92e2e06</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddAbilityTargetStatCondition(
        int? greaterThan = null,
        bool? inverted = null,
        StatType? stat = null)
    {
      var component = new AbilityTargetStatCondition();
      component.GreaterThan = greaterThan ?? component.GreaterThan;
      component.Inverted = inverted ?? component.Inverted;
      component.Stat = stat ?? component.Stat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DimensionDoorRestrictionIgnorance"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BabauAlarmerGreaterTeleport</term><description>5e8eeeb90defcf94c8a8c974e8d229e6</description></item>
    /// <item><term>DimensionDoorAoE_Cutscene</term><description>5cc1fd2f01b4d9e459cc4a976bc42eaa</description></item>
    /// <item><term>QuickenedDimensionDoorAoEZiggurat_Cutscene</term><description>61e196105ca548d7bbd0c3a484c4cab4</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddDimensionDoorRestrictionIgnorance(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new DimensionDoorRestrictionIgnorance();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="LineOfSightIgnorance"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AreeluShadow_Charging</term><description>e65515f300c04ec786608600e2c8edcf</description></item>
    /// <item><term>DLC2_FrostWizard_Spell</term><description>5a37bf5ff28f46d09598c8d8c811c857</description></item>
    /// <item><term>Shrine_Ability_QuickenedGreaterTeleport</term><description>0e1875d30b5640549938298458348d10</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddLineOfSightIgnorance(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new LineOfSightIgnorance();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterHasFacts"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AngelfireApostleCleansingFlamesAbility</term><description>778bd83be4d52cf44951f6cba779a398</description></item>
    /// <item><term>RenewedDefenseAbility</term><description>ce50ad6751d7eec44a888c78b249050e</description></item>
    /// <item><term>WallWaterBlastAbility</term><description>1ab8c76ac4983174dbffa35e2a87e582</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="facts">
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
    public TBuilder AddAbilityCasterHasFacts(
        List<Blueprint<BlueprintUnitFactReference>>? facts = null,
        List<BlueprintUnitFact>? factsMissingCache = null,
        bool? needsAll = null)
    {
      var component = new AbilityCasterHasFacts();
      component.m_Facts = facts?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Facts;
      if (component.m_Facts is null)
      {
        component.m_Facts = new BlueprintUnitFactReference[0];
      }
      Validate(factsMissingCache);
      component.m_FactsMissingCache = factsMissingCache ?? component.m_FactsMissingCache;
      if (component.m_FactsMissingCache is null)
      {
        component.m_FactsMissingCache = new();
      }
      component.NeedsAll = needsAll ?? component.NeedsAll;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterHasNoFacts"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon5BaneOfDemonsAbility</term><description>843145bc1b9b45229c40b1a2128095f0</description></item>
    /// <item><term>FighterPoisonousStrike3Ability</term><description>abe824a513784ef08d66b08847b4efa5</description></item>
    /// <item><term>Trickster3PlaceOfPowerAbility</term><description>918a7c225837410299c7dcb5db68370d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="facts">
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
    public TBuilder AddAbilityCasterHasNoFacts(
        List<Blueprint<BlueprintUnitFactReference>>? facts = null,
        List<BlueprintUnitFact>? factsPresentedCache = null)
    {
      var component = new AbilityCasterHasNoFacts();
      component.m_Facts = facts?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Facts;
      if (component.m_Facts is null)
      {
        component.m_Facts = new BlueprintUnitFactReference[0];
      }
      Validate(factsPresentedCache);
      component.m_FactsPresentedCache = factsPresentedCache ?? component.m_FactsPresentedCache;
      if (component.m_FactsPresentedCache is null)
      {
        component.m_FactsPresentedCache = new();
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterInCombat"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DemonRageActivateAbility</term><description>260daa5144194a8ab5117ff568b680f5</description></item>
    /// <item><term>TacticalLeaderBattleAcumenProtection</term><description>7ff9c15f86e5739419dd128fe2e2a418</description></item>
    /// <item><term>TacticalLeaderBattleAcumenSmiting</term><description>43f1d29da0bd6d74ba158d5983711be1</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddAbilityCasterInCombat(
        bool? not = null)
    {
      var component = new AbilityCasterInCombat();
      component.Not = not ?? component.Not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterIsOnFavoredTerrain"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CamouflageAbility</term><description>b26a123a009d4a141ac9c19355913285</description></item>
    /// <item><term>ForesterCamouflageAbility</term><description>5fb85744155126d4fb2b01767705c24c</description></item>
    /// <item><term>SlayerCamouflageAbility</term><description>0d9e2a7b692c8e74d8e9779160d58047</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="ignoreFeature">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddAbilityCasterIsOnFavoredTerrain(
        Blueprint<BlueprintFeatureReference>? ignoreFeature = null)
    {
      var component = new AbilityCasterIsOnFavoredTerrain();
      component.m_IgnoreFeature = ignoreFeature?.Reference ?? component.m_IgnoreFeature;
      if (component.m_IgnoreFeature is null)
      {
        component.m_IgnoreFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterMainWeaponCheck"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CrushingBlowAbility</term><description>957a10e303269324dbf1a70513f37559</description></item>
    /// <item><term>StunningFistAbility</term><description>732ae7773baf15447a6737ae6547fc1e</description></item>
    /// <item><term>StunningFistSickenedAbility</term><description>c81906c75821cbe4c897fa11bdaeee01</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddAbilityCasterMainWeaponCheck(params WeaponCategory[] category)
    {
      var component = new AbilityCasterMainWeaponCheck();
      component.Category = category;
      if (component.Category is null)
      {
        component.Category = new WeaponCategory[0];
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterMainWeaponIsMelee"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AssassinDeathAttackAbility</term><description>744e7c7fd58bd6040b40210cf0864692</description></item>
    /// <item><term>AssassinDeathAttackAbilityParalyze</term><description>452b64ffab80cff40bd27dc5f350d80c</description></item>
    /// <item><term>AssassinDeathAttackAbilityStandard</term><description>68a6086913b7cca4283c62be2295ce81</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddAbilityCasterMainWeaponIsMelee()
    {
      return AddComponent(new AbilityCasterMainWeaponIsMelee());
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterMainWeaponIsTwoHanded"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>TwoHandedFighterPiledriverBullRushAbility</term><description>b789cfc41fa326f419d77efc2e5c6632</description></item>
    /// <item><term>TwoHandedFighterPiledriverTripAbility</term><description>1202b3d188c9bdc46987a5da168ec6d9</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddAbilityCasterMainWeaponIsTwoHanded()
    {
      return AddComponent(new AbilityCasterMainWeaponIsTwoHanded());
    }

    /// <summary>
    /// Adds <see cref="AbilityCasterNotPolymorphed"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcidBomb</term><description>fd101fbc4aacf5d48b76a65e3aa5db6d</description></item>
    /// <item><term>GrandMutagenStrengthDexterity</term><description>8444394f44f56b842bc2252782fde2e0</description></item>
    /// <item><term>TrueMutagenAbility</term><description>17903369fcc1aa241a87ec264597aed5</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityCasterNotPolymorphed(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityCasterNotPolymorphed();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityMaxSquadsRestriction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Angel3SummonHeavenlyHostAbility</term><description>f317d44314a843e7aaf3fc202cbe9577</description></item>
    /// <item><term>ArmySummonMarilith</term><description>78c258abcb744f75ab6b71121aadf47d</description></item>
    /// <item><term>SummonSquad</term><description>6fd4d245dd129af45a802dedff113c0d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityMaxSquadsRestriction(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityMaxSquadsRestriction();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilitySpawnFx"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbandonedKeep_AcidTrap</term><description>e7dadeb8b1d78a341bb4357b502da424</description></item>
    /// <item><term>HagboundWitchVileCurseFeebleBody</term><description>9c3c5329d49df524b885f9ccce392cad</description></item>
    /// <item><term>ZombieSlashingExplosion</term><description>f6b63adab8b645c8beb9cab170dac9d3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="prefabLink">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder AddAbilitySpawnFx(
        AbilitySpawnFxAnchor? anchor = null,
        float? delay = null,
        bool? destroyOnCast = null,
        AbilitySpawnFxAnchor? orientationAnchor = null,
        AbilitySpawnFxOrientation? orientationMode = null,
        AbilitySpawnFxAnchor? positionAnchor = null,
        AssetLink<PrefabLink>? prefabLink = null,
        AbilitySpawnFxTime? time = null,
        AbilitySpawnFxWeaponTarget? weaponTarget = null)
    {
      var component = new AbilitySpawnFx();
      component.Anchor = anchor ?? component.Anchor;
      component.Delay = delay ?? component.Delay;
      component.DestroyOnCast = destroyOnCast ?? component.DestroyOnCast;
      component.OrientationAnchor = orientationAnchor ?? component.OrientationAnchor;
      component.OrientationMode = orientationMode ?? component.OrientationMode;
      component.PositionAnchor = positionAnchor ?? component.PositionAnchor;
      component.PrefabLink = prefabLink?.Get() ?? component.PrefabLink;
      if (component.PrefabLink is null)
      {
        component.PrefabLink = Utils.Constants.Empty.PrefabLink;
      }
      component.Time = time ?? component.Time;
      component.WeaponTarget = weaponTarget ?? component.WeaponTarget;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyAbilityHook"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyHarpoonAbility</term><description>d213bb6eec4442b28b1393c4ef694d68</description></item>
    /// <item><term>ArmyLassoAbility</term><description>5e8d9aacca404a2da805c5e9bc63ac16</description></item>
    /// <item><term>RangerHarpoonAbility</term><description>1d0cdbc55942444293032edaf1f41673</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddArmyAbilityHook(
        bool? hasIsAllyEffectRunConditions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        AnimationCurve? pullCurve = null,
        int? pullDistanceInCells = null,
        float? pullSpeed = null)
    {
      var component = new ArmyAbilityHook();
      component.m_HasIsAllyEffectRunConditions = hasIsAllyEffectRunConditions ?? component.m_HasIsAllyEffectRunConditions;
      Validate(pullCurve);
      component.PullCurve = pullCurve ?? component.PullCurve;
      component.PullDistanceInCells = pullDistanceInCells ?? component.PullDistanceInCells;
      component.PullSpeed = pullSpeed ?? component.PullSpeed;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="CustomAreaOnGrid"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmySummonGlabrezu</term><description>7453306a53e94766aad9fa716acaaada</description></item>
    /// <item><term>RangerExplosivesTrapAbility</term><description>8f684342b757e0f47adfb5edaaabc488</description></item>
    /// <item><term>RangerWeakeningTrapArea</term><description>f3c79a96342c37e4d9ec7cbe35dcbda0</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="affectedCells">
    /// <para>
    /// InfoBox: In relative coordinates where left-bottom cell is (0, 0)
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddCustomAreaOnGrid(
        List<Vector2Int>? affectedCells = null,
        bool? ignoreObstaclesAndUnits = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? spawnFxInEveryCell = null)
    {
      var component = new CustomAreaOnGrid();
      component.AffectedCells = affectedCells ?? component.AffectedCells;
      if (component.AffectedCells is null)
      {
        component.AffectedCells = new();
      }
      component.IgnoreObstaclesAndUnits = ignoreObstaclesAndUnits ?? component.IgnoreObstaclesAndUnits;
      component.SpawnFxInEveryCell = spawnFxInEveryCell ?? component.SpawnFxInEveryCell;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatCellsProviderLink"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyReachingStrikeActivatableAbility</term><description>6e8cad7fbb534154a0b3c83102e37323</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="abilityWithCellsProvider">
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
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTacticalCombatCellsProviderLink(
        Blueprint<BlueprintAbilityReference>? abilityWithCellsProvider = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TacticalCombatCellsProviderLink();
      component.m_AbilityWithCellsProvider = abilityWithCellsProvider?.Reference ?? component.m_AbilityWithCellsProvider;
      if (component.m_AbilityWithCellsProvider is null)
      {
        component.m_AbilityWithCellsProvider = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatDefenseAbility"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyDrink</term><description>594a8c1667524da58974ce7dbf9885d8</description></item>
    /// <item><term>ArmyTotalDefense</term><description>5fcc24b820f55104892097782b92228e</description></item>
    /// <item><term>ArmyTotalDefenseImproved</term><description>80e5956beb4c4786bae0b1e1b4e1fbe9</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTacticalCombatDefenseAbility(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TacticalCombatDefenseAbility();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PureRecommendation"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BashingFinish</term><description>0b442a7b4aa598d4e912a4ecee0500ff</description></item>
    /// <item><term>GreaterSunder</term><description>54d824028117e884a8f9356c7c66149b</description></item>
    /// <item><term>TwoWeaponFightingImproved</term><description>9af88f3ed8a017b45a6837eab7437629</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddPureRecommendation(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        RecommendationPriority? priority = null)
    {
      var component = new PureRecommendation();
      component.Priority = priority ?? component.Priority;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="RecommendationRequiresSpellbook"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AlliedSpellcaster</term><description>9093ceeefe9b84746a5993d619d7c86f</description></item>
    /// <item><term>HeightenSpellFeat</term><description>2f5d1e705c7967546b72ad8218ccf99c</description></item>
    /// <item><term>SpellPenetration</term><description>ee7dc126939e4d9438357fbd5980d459</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddRecommendationRequiresSpellbook(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new RecommendationRequiresSpellbook();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="StatRecommendationChange"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Camelia_FeatureList</term><description>c84c2f0728cc18f46a9e2796fcc08ac4</description></item>
    /// <item><term>CameliaPregenFeatureList</term><description>e88190db18af8d54f99ea9e649632957</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddStatRecommendationChange(
        bool? recommended = null,
        StatType? stat = null)
    {
      var component = new StatRecommendationChange();
      component.Recommended = recommended ?? component.Recommended;
      component.Stat = stat ?? component.Stat;
      return AddComponent(component);
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
    /// <item><term>PersuasionUseAbility</term><description>7d2233c3b7a0b984ba058a83b736e6ac</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddHideFeatureInInspect()
    {
      return AddComponent(new HideFeatureInInspect());
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_DefaultAiAction is null)
      {
        Blueprint.m_DefaultAiAction = BlueprintTool.GetRef<BlueprintAiCastSpell.Reference>(null);
      }
      if (Blueprint.m_Parent is null)
      {
        Blueprint.m_Parent = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      }
      if (Blueprint.LocalizedDuration is null)
      {
        Blueprint.LocalizedDuration = Utils.Constants.Empty.String;
      }
      if (Blueprint.LocalizedSavingThrow is null)
      {
        Blueprint.LocalizedSavingThrow = Utils.Constants.Empty.String;
      }
      if (Blueprint.ResourceAssetIds is null)
      {
        Blueprint.ResourceAssetIds = new string[0];
      }
    }
  }
}
