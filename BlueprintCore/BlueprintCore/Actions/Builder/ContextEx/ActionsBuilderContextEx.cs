using BlueprintCore.Utils;
using Kingmaker.Assets.UnitLogic.Mechanics.Actions;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Blueprints.Quests;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.Settings;
using Kingmaker.UI.GenericSlot;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Actions;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Class.Kineticist.Actions;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.Utility;
using System.Collections.Generic;
using System.Linq;
//***** AUTO-GENERATED - DO NOT EDIT *****//
namespace BlueprintCore.Actions.Builder.ContextEx
{
  /// <summary>
  /// Extension to <see cref="ActionsBuilder"/> for most <see cref="ContextAction"/> types. Some <see cref="ContextAction"/> types are in more specific extensions such as <see cref="AVEx.ActionsBuilderAVEx">AVEx</see> or <see cref="KingdomEx.ActionsBuilderKingdomEx">KingdomEx</see>.
  /// </summary>
  /// <inheritdoc cref="ActionsBuilder"/>
  public static class ActionsBuilderContextEx
{

    /// <summary>
    /// Adds <see cref="ContextActionResetAlignment"/>
    /// </summary>
    public static ActionsBuilder ContextActionResetAlignment(
        this ActionsBuilder builder,
        bool? resetAlignmentLock = null)
    {
      var element = ElementTool.Create<ContextActionResetAlignment>();
      if (resetAlignmentLock is not null)
      {
        element.m_ResetAlignmentLock = resetAlignmentLock;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSwarmAttack"/>
    /// </summary>
    public static ActionsBuilder ContextActionSwarmAttack(
        this ActionsBuilder builder,
        ActionsBuilder? attackActions = null)
    {
      var element = ElementTool.Create<ContextActionSwarmAttack>();
      if (attackActions is not null)
      {
        element.AttackActions = attackActions.Build();
      }
      if (element.AttackActions is null)
      {
        element.AttackActions = Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSwitchDualCompanion"/>
    /// </summary>
    public static ActionsBuilder ContextActionSwitchDualCompanion(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionSwitchDualCompanion>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionAddRandomTrashItem"/>
    /// </summary>
    public static ActionsBuilder ContextActionAddRandomTrashItem(
        this ActionsBuilder builder,
        bool? identify = null,
        TrashLootType? lootType = null,
        int? maxCost = null,
        bool? silent = null)
    {
      var element = ElementTool.Create<ContextActionAddRandomTrashItem>();
      if (identify is not null)
      {
        element.m_Identify = identify;
      }
      if (lootType is not null)
      {
        element.m_LootType = lootType;
      }
      if (maxCost is not null)
      {
        element.m_MaxCost = maxCost;
      }
      if (silent is not null)
      {
        element.m_Silent = silent;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRestoreAllSpellSlots"/>
    /// </summary>
    ///
    /// <param name="excludeSpellbooks">
    /// Blueprint of type BlueprintSpellbook. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextActionRestoreAllSpellSlots(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintSpellbook, BlueprintSpellbookReference>>? excludeSpellbooks = null,
        UnitEvaluator? target = null,
        int? upToSpellLevel = null)
    {
      var element = ElementTool.Create<ContextActionRestoreAllSpellSlots>();
      if (excludeSpellbooks is not null)
      {
        element.m_ExcludeSpellbooks = excludeSpellbooks.Select(bp => bp.Reference).ToList();
      }
      if (element.m_ExcludeSpellbooks is null)
      {
        element.m_ExcludeSpellbooks = new();
      }
      if (target is not null)
      {
        builder.Validate(target);
        element.m_Target = target;
      }
      if (upToSpellLevel is not null)
      {
        element.m_UpToSpellLevel = upToSpellLevel;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="BuffActionAddStatBonus"/>
    /// </summary>
    public static ActionsBuilder BuffActionAddStatBonus(
        this ActionsBuilder builder,
        ModifierDescriptor? descriptor = null,
        StatType? stat = null,
        ContextValue? value = null)
    {
      var element = ElementTool.Create<BuffActionAddStatBonus>();
      if (descriptor is not null)
      {
        element.Descriptor = descriptor;
      }
      if (stat is not null)
      {
        element.Stat = stat;
      }
      if (value is not null)
      {
        element.Value = value;
      }
      if (element.Value is null)
      {
        element.Value = ContextValues.Constant(0);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionAcceptBurn"/>
    /// </summary>
    public static ActionsBuilder ContextActionAcceptBurn(
        this ActionsBuilder builder,
        ContextValue? value = null)
    {
      var element = ElementTool.Create<ContextActionAcceptBurn>();
      if (value is not null)
      {
        element.Value = value;
      }
      if (element.Value is null)
      {
        element.Value = ContextValues.Constant(0);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionHealBurn"/>
    /// </summary>
    public static ActionsBuilder ContextActionHealBurn(
        this ActionsBuilder builder,
        ContextValue? value = null)
    {
      var element = ElementTool.Create<ContextActionHealBurn>();
      if (value is not null)
      {
        element.Value = value;
      }
      if (element.Value is null)
      {
        element.Value = ContextValues.Constant(0);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomSharedBurden"/>
    /// </summary>
    public static ActionsBuilder AbilityCustomSharedBurden(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<AbilityCustomSharedBurden>());
    }

    /// <summary>
    /// Adds <see cref="AbilityCustomSharedGrace"/>
    /// </summary>
    public static ActionsBuilder AbilityCustomSharedGrace(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<AbilityCustomSharedGrace>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionAddFeature"/>
    /// </summary>
    ///
    /// <param name="permanentFeature">
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="setRankFrom">
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextActionAddFeature(
        this ActionsBuilder builder,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? permanentFeature = null,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? setRankFrom = null)
    {
      var element = ElementTool.Create<ContextActionAddFeature>();
      if (permanentFeature is not null)
      {
        element.m_PermanentFeature = permanentFeature.Reference;
      }
      if (element.m_PermanentFeature is null)
      {
        element.m_PermanentFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      if (setRankFrom is not null)
      {
        element.m_SetRankFrom = setRankFrom.Reference;
      }
      if (element.m_SetRankFrom is null)
      {
        element.m_SetRankFrom = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionAddLocustClone"/>
    /// </summary>
    ///
    /// <param name="cloneFeature">
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextActionAddLocustClone(
        this ActionsBuilder builder,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? cloneFeature = null)
    {
      var element = ElementTool.Create<ContextActionAddLocustClone>();
      if (cloneFeature is not null)
      {
        element.m_CloneFeature = cloneFeature.Reference;
      }
      if (element.m_CloneFeature is null)
      {
        element.m_CloneFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionAeonRollbackToSavedState"/>
    /// </summary>
    public static ActionsBuilder ContextActionAeonRollbackToSavedState(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionAeonRollbackToSavedState>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionApplyBuff"/>
    /// </summary>
    ///
    /// <param name="buff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextActionApplyBuff(
        this ActionsBuilder builder,
        bool? asChild = null,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? buff = null,
        float? durationSeconds = null,
        ContextDurationValue? durationValue = null,
        bool? isFromSpell = null,
        bool? isNotDispelable = null,
        bool? permanent = null,
        bool? sameDuration = null,
        bool? toCaster = null,
        bool? useDurationSeconds = null)
    {
      var element = ElementTool.Create<ContextActionApplyBuff>();
      if (asChild is not null)
      {
        element.AsChild = asChild;
      }
      if (buff is not null)
      {
        element.m_Buff = buff.Reference;
      }
      if (element.m_Buff is null)
      {
        element.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      if (durationSeconds is not null)
      {
        element.DurationSeconds = durationSeconds;
      }
      if (durationValue is not null)
      {
        builder.Validate(durationValue);
        element.DurationValue = durationValue;
      }
      if (isFromSpell is not null)
      {
        element.IsFromSpell = isFromSpell;
      }
      if (isNotDispelable is not null)
      {
        element.IsNotDispelable = isNotDispelable;
      }
      if (permanent is not null)
      {
        element.Permanent = permanent;
      }
      if (sameDuration is not null)
      {
        element.SameDuration = sameDuration;
      }
      if (toCaster is not null)
      {
        element.ToCaster = toCaster;
      }
      if (useDurationSeconds is not null)
      {
        element.UseDurationSeconds = useDurationSeconds;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionArmorEnchantPool"/>
    /// </summary>
    ///
    /// <param name="defaultEnchantments">
    /// Blueprint of type BlueprintItemEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextActionArmorEnchantPool(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>>? defaultEnchantments = null,
        ContextDurationValue? durationValue = null,
        EnchantPoolType? enchantPool = null,
        ActivatableAbilityGroup? group = null)
    {
      var element = ElementTool.Create<ContextActionArmorEnchantPool>();
      if (defaultEnchantments is not null)
      {
        element.m_DefaultEnchantments = defaultEnchantments.Select(bp => bp.Reference).ToArray();
      }
      if (element.m_DefaultEnchantments is null)
      {
        element.m_DefaultEnchantments = new BlueprintItemEnchantmentReference[0];
      }
      if (durationValue is not null)
      {
        builder.Validate(durationValue);
        element.DurationValue = durationValue;
      }
      if (enchantPool is not null)
      {
        element.EnchantPool = enchantPool;
      }
      if (group is not null)
      {
        element.Group = group;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionShieldArmorEnchantPool"/>
    /// </summary>
    ///
    /// <param name="defaultEnchantments">
    /// Blueprint of type BlueprintItemEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextActionShieldArmorEnchantPool(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>>? defaultEnchantments = null,
        ContextDurationValue? durationValue = null,
        EnchantPoolType? enchantPool = null,
        ActivatableAbilityGroup? group = null)
    {
      var element = ElementTool.Create<ContextActionShieldArmorEnchantPool>();
      if (defaultEnchantments is not null)
      {
        element.m_DefaultEnchantments = defaultEnchantments.Select(bp => bp.Reference).ToArray();
      }
      if (element.m_DefaultEnchantments is null)
      {
        element.m_DefaultEnchantments = new BlueprintItemEnchantmentReference[0];
      }
      if (durationValue is not null)
      {
        builder.Validate(durationValue);
        element.DurationValue = durationValue;
      }
      if (enchantPool is not null)
      {
        element.EnchantPool = enchantPool;
      }
      if (group is not null)
      {
        element.Group = group;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionWeaponEnchantPool"/>
    /// </summary>
    ///
    /// <param name="defaultEnchantments">
    /// Blueprint of type BlueprintItemEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextActionWeaponEnchantPool(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>>? defaultEnchantments = null,
        ContextDurationValue? durationValue = null,
        EnchantPoolType? enchantPool = null,
        ActivatableAbilityGroup? group = null)
    {
      var element = ElementTool.Create<ContextActionWeaponEnchantPool>();
      if (defaultEnchantments is not null)
      {
        element.m_DefaultEnchantments = defaultEnchantments.Select(bp => bp.Reference).ToArray();
      }
      if (element.m_DefaultEnchantments is null)
      {
        element.m_DefaultEnchantments = new BlueprintItemEnchantmentReference[0];
      }
      if (durationValue is not null)
      {
        builder.Validate(durationValue);
        element.DurationValue = durationValue;
      }
      if (enchantPool is not null)
      {
        element.EnchantPool = enchantPool;
      }
      if (group is not null)
      {
        element.Group = group;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionShieldWeaponEnchantPool"/>
    /// </summary>
    ///
    /// <param name="defaultEnchantments">
    /// Blueprint of type BlueprintItemEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextActionShieldWeaponEnchantPool(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>>? defaultEnchantments = null,
        ContextDurationValue? durationValue = null,
        EnchantPoolType? enchantPool = null,
        ActivatableAbilityGroup? group = null)
    {
      var element = ElementTool.Create<ContextActionShieldWeaponEnchantPool>();
      if (defaultEnchantments is not null)
      {
        element.m_DefaultEnchantments = defaultEnchantments.Select(bp => bp.Reference).ToArray();
      }
      if (element.m_DefaultEnchantments is null)
      {
        element.m_DefaultEnchantments = new BlueprintItemEnchantmentReference[0];
      }
      if (durationValue is not null)
      {
        builder.Validate(durationValue);
        element.DurationValue = durationValue;
      }
      if (enchantPool is not null)
      {
        element.EnchantPool = enchantPool;
      }
      if (group is not null)
      {
        element.Group = group;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionAttackWithWeapon"/>
    /// </summary>
    ///
    /// <param name="weaponRef">
    /// Blueprint of type BlueprintItemWeapon. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextActionAttackWithWeapon(
        this ActionsBuilder builder,
        StatType? stat = null,
        Blueprint<BlueprintItemWeapon, BlueprintItemWeaponReference>? weaponRef = null)
    {
      var element = ElementTool.Create<ContextActionAttackWithWeapon>();
      if (stat is not null)
      {
        element.m_Stat = stat;
      }
      if (weaponRef is not null)
      {
        element.m_WeaponRef = weaponRef.Reference;
      }
      if (element.m_WeaponRef is null)
      {
        element.m_WeaponRef = BlueprintTool.GetRef<BlueprintItemWeaponReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionBatteringBlast"/>
    /// </summary>
    public static ActionsBuilder ContextActionBatteringBlast(
        this ActionsBuilder builder,
        bool? remove = null)
    {
      var element = ElementTool.Create<ContextActionBatteringBlast>();
      if (remove is not null)
      {
        element.Remove = remove;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionBreakFree"/>
    /// </summary>
    public static ActionsBuilder ContextActionBreakFree(
        this ActionsBuilder builder,
        ActionsBuilder? failure = null,
        ActionsBuilder? success = null,
        bool? useCMB = null,
        bool? useCMD = null)
    {
      var element = ElementTool.Create<ContextActionBreakFree>();
      if (failure is not null)
      {
        element.Failure = failure.Build();
      }
      if (element.Failure is null)
      {
        element.Failure = Constants.Empty.Actions;
      }
      if (success is not null)
      {
        element.Success = success.Build();
      }
      if (element.Success is null)
      {
        element.Success = Constants.Empty.Actions;
      }
      if (useCMB is not null)
      {
        element.UseCMB = useCMB;
      }
      if (useCMD is not null)
      {
        element.UseCMD = useCMD;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionBreathOfLife"/>
    /// </summary>
    public static ActionsBuilder ContextActionBreathOfLife(
        this ActionsBuilder builder,
        ContextDiceValue? value = null)
    {
      var element = ElementTool.Create<ContextActionBreathOfLife>();
      if (value is not null)
      {
        element.Value = value;
      }
      if (element.Value is null)
      {
        element.Value = Constants.Empty.DiceValue;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionBreathOfMoney"/>
    /// </summary>
    public static ActionsBuilder ContextActionBreathOfMoney(
        this ActionsBuilder builder,
        ContextValue? maxCoins = null,
        ContextValue? minCoins = null)
    {
      var element = ElementTool.Create<ContextActionBreathOfMoney>();
      if (maxCoins is not null)
      {
        element.MaxCoins = maxCoins;
      }
      if (element.MaxCoins is null)
      {
        element.MaxCoins = ContextValues.Constant(0);
      }
      if (minCoins is not null)
      {
        element.MinCoins = minCoins;
      }
      if (element.MinCoins is null)
      {
        element.MinCoins = ContextValues.Constant(0);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionCastSpell"/>
    /// </summary>
    ///
    /// <param name="spell">
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextActionCastSpell(
        this ActionsBuilder builder,
        bool? castByTarget = null,
        ContextValue? dC = null,
        bool? overrideDC = null,
        bool? overrideSpellLevel = null,
        Blueprint<BlueprintAbility, BlueprintAbilityReference>? spell = null,
        ContextValue? spellLevel = null)
    {
      var element = ElementTool.Create<ContextActionCastSpell>();
      if (castByTarget is not null)
      {
        element.CastByTarget = castByTarget;
      }
      if (dC is not null)
      {
        element.DC = dC;
      }
      if (element.DC is null)
      {
        element.DC = ContextValues.Constant(0);
      }
      if (overrideDC is not null)
      {
        element.OverrideDC = overrideDC;
      }
      if (overrideSpellLevel is not null)
      {
        element.OverrideSpellLevel = overrideSpellLevel;
      }
      if (spell is not null)
      {
        element.m_Spell = spell.Reference;
      }
      if (element.m_Spell is null)
      {
        element.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      }
      if (spellLevel is not null)
      {
        element.SpellLevel = spellLevel;
      }
      if (element.SpellLevel is null)
      {
        element.SpellLevel = ContextValues.Constant(0);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionChangeSharedValue"/>
    /// </summary>
    public static ActionsBuilder ContextActionChangeSharedValue(
        this ActionsBuilder builder,
        ContextValue? addValue = null,
        ContextValue? multiplyValue = null,
        ContextValue? setValue = null,
        AbilitySharedValue? sharedValue = null,
        SharedValueChangeType? type = null)
    {
      var element = ElementTool.Create<ContextActionChangeSharedValue>();
      if (addValue is not null)
      {
        element.AddValue = addValue;
      }
      if (element.AddValue is null)
      {
        element.AddValue = ContextValues.Constant(0);
      }
      if (multiplyValue is not null)
      {
        element.MultiplyValue = multiplyValue;
      }
      if (element.MultiplyValue is null)
      {
        element.MultiplyValue = ContextValues.Constant(0);
      }
      if (setValue is not null)
      {
        element.SetValue = setValue;
      }
      if (element.SetValue is null)
      {
        element.SetValue = ContextValues.Constant(0);
      }
      if (sharedValue is not null)
      {
        element.SharedValue = sharedValue;
      }
      if (type is not null)
      {
        element.Type = type;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionClearSummonPool"/>
    /// </summary>
    ///
    /// <param name="summonPool">
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextActionClearSummonPool(
        this ActionsBuilder builder,
        Blueprint<BlueprintSummonPool, BlueprintSummonPoolReference>? summonPool = null)
    {
      var element = ElementTool.Create<ContextActionClearSummonPool>();
      if (summonPool is not null)
      {
        element.m_SummonPool = summonPool.Reference;
      }
      if (element.m_SummonPool is null)
      {
        element.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionCombatManeuver"/>
    /// </summary>
    public static ActionsBuilder ContextActionCombatManeuver(
        this ActionsBuilder builder,
        bool? batteringBlast = null,
        bool? ignoreConcealment = null,
        StatType? newStat = null,
        ActionsBuilder? onSuccess = null,
        bool? replaceStat = null,
        CombatManeuver? type = null,
        bool? useBestMentalStat = null,
        bool? useCasterLevelAsBaseAttack = null,
        bool? useCastingStat = null,
        bool? useKineticistMainStat = null)
    {
      var element = ElementTool.Create<ContextActionCombatManeuver>();
      if (batteringBlast is not null)
      {
        element.BatteringBlast = batteringBlast;
      }
      if (ignoreConcealment is not null)
      {
        element.IgnoreConcealment = ignoreConcealment;
      }
      if (newStat is not null)
      {
        element.NewStat = newStat;
      }
      if (onSuccess is not null)
      {
        element.OnSuccess = onSuccess.Build();
      }
      if (element.OnSuccess is null)
      {
        element.OnSuccess = Constants.Empty.Actions;
      }
      if (replaceStat is not null)
      {
        element.ReplaceStat = replaceStat;
      }
      if (type is not null)
      {
        element.Type = type;
      }
      if (useBestMentalStat is not null)
      {
        element.UseBestMentalStat = useBestMentalStat;
      }
      if (useCasterLevelAsBaseAttack is not null)
      {
        element.UseCasterLevelAsBaseAttack = useCasterLevelAsBaseAttack;
      }
      if (useCastingStat is not null)
      {
        element.UseCastingStat = useCastingStat;
      }
      if (useKineticistMainStat is not null)
      {
        element.UseKineticistMainStat = useKineticistMainStat;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionCombatManeuverCustom"/>
    /// </summary>
    public static ActionsBuilder ContextActionCombatManeuverCustom(
        this ActionsBuilder builder,
        ActionsBuilder? failure = null,
        ActionsBuilder? success = null,
        CombatManeuver? type = null)
    {
      var element = ElementTool.Create<ContextActionCombatManeuverCustom>();
      if (failure is not null)
      {
        element.Failure = failure.Build();
      }
      if (element.Failure is null)
      {
        element.Failure = Constants.Empty.Actions;
      }
      if (success is not null)
      {
        element.Success = success.Build();
      }
      if (element.Success is null)
      {
        element.Success = Constants.Empty.Actions;
      }
      if (type is not null)
      {
        element.Type = type;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionConditionalSaved"/>
    /// </summary>
    public static ActionsBuilder ContextActionConditionalSaved(
        this ActionsBuilder builder,
        ActionsBuilder? failed = null,
        ActionsBuilder? succeed = null)
    {
      var element = ElementTool.Create<ContextActionConditionalSaved>();
      if (failed is not null)
      {
        element.Failed = failed.Build();
      }
      if (element.Failed is null)
      {
        element.Failed = Constants.Empty.Actions;
      }
      if (succeed is not null)
      {
        element.Succeed = succeed.Build();
      }
      if (element.Succeed is null)
      {
        element.Succeed = Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionDealDamage"/>
    /// </summary>
    public static ActionsBuilder ContextActionDealDamage(
        this ActionsBuilder builder,
        StatType? abilityType = null,
        bool? alreadyHalved = null,
        AbilitySharedValue? criticalSharedValue = null,
        DamageTypeDescription? damageType = null,
        bool? drain = null,
        ContextDurationValue? duration = null,
        EnergyDrainType? energyDrainType = null,
        bool? half = null,
        bool? halfIfSaved = null,
        bool? ignoreCritical = null,
        bool? isAoE = null,
        bool? isAOE = null,
        int? minHPAfterDamage = null,
        AbilitySharedValue? preRolledSharedValue = null,
        bool? readPreRolledFromSharedValue = null,
        AbilitySharedValue? resultSharedValue = null,
        bool? setFactAsReason = null,
        ContextActionDealDamage.Type? type = null,
        bool? useMinHPAfterDamage = null,
        bool? useWeaponDamageModifiers = null,
        ContextDiceValue? value = null,
        bool? writeCriticalToSharedValue = null,
        bool? writeRawResultToSharedValue = null,
        bool? writeResultToSharedValue = null)
    {
      var element = ElementTool.Create<ContextActionDealDamage>();
      if (abilityType is not null)
      {
        element.AbilityType = abilityType;
      }
      if (alreadyHalved is not null)
      {
        element.AlreadyHalved = alreadyHalved;
      }
      if (criticalSharedValue is not null)
      {
        element.CriticalSharedValue = criticalSharedValue;
      }
      if (damageType is not null)
      {
        builder.Validate(damageType);
        element.DamageType = damageType;
      }
      if (drain is not null)
      {
        element.Drain = drain;
      }
      if (duration is not null)
      {
        builder.Validate(duration);
        element.Duration = duration;
      }
      if (energyDrainType is not null)
      {
        element.EnergyDrainType = energyDrainType;
      }
      if (half is not null)
      {
        element.Half = half;
      }
      if (halfIfSaved is not null)
      {
        element.HalfIfSaved = halfIfSaved;
      }
      if (ignoreCritical is not null)
      {
        element.IgnoreCritical = ignoreCritical;
      }
      if (isAoE is not null)
      {
        element.IsAoE = isAoE;
      }
      if (isAOE is not null)
      {
        element.m_IsAOE = isAOE;
      }
      if (minHPAfterDamage is not null)
      {
        element.MinHPAfterDamage = minHPAfterDamage;
      }
      if (preRolledSharedValue is not null)
      {
        element.PreRolledSharedValue = preRolledSharedValue;
      }
      if (readPreRolledFromSharedValue is not null)
      {
        element.ReadPreRolledFromSharedValue = readPreRolledFromSharedValue;
      }
      if (resultSharedValue is not null)
      {
        element.ResultSharedValue = resultSharedValue;
      }
      if (setFactAsReason is not null)
      {
        element.SetFactAsReason = setFactAsReason;
      }
      if (type is not null)
      {
        element.m_Type = type;
      }
      if (useMinHPAfterDamage is not null)
      {
        element.UseMinHPAfterDamage = useMinHPAfterDamage;
      }
      if (useWeaponDamageModifiers is not null)
      {
        element.UseWeaponDamageModifiers = useWeaponDamageModifiers;
      }
      if (value is not null)
      {
        element.Value = value;
      }
      if (element.Value is null)
      {
        element.Value = Constants.Empty.DiceValue;
      }
      if (writeCriticalToSharedValue is not null)
      {
        element.WriteCriticalToSharedValue = writeCriticalToSharedValue;
      }
      if (writeRawResultToSharedValue is not null)
      {
        element.WriteRawResultToSharedValue = writeRawResultToSharedValue;
      }
      if (writeResultToSharedValue is not null)
      {
        element.WriteResultToSharedValue = writeResultToSharedValue;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionDealWeaponDamage"/>
    /// </summary>
    public static ActionsBuilder ContextActionDealWeaponDamage(
        this ActionsBuilder builder,
        bool? canBeRanged = null,
        bool? ignoreAttackRoll = null)
    {
      var element = ElementTool.Create<ContextActionDealWeaponDamage>();
      if (canBeRanged is not null)
      {
        element.CanBeRanged = canBeRanged;
      }
      if (ignoreAttackRoll is not null)
      {
        element.IgnoreAttackRoll = ignoreAttackRoll;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionDetachFromSpawner"/>
    /// </summary>
    public static ActionsBuilder ContextActionDetachFromSpawner(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDetachFromSpawner>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionDetectSecretDoors"/>
    /// </summary>
    public static ActionsBuilder ContextActionDetectSecretDoors(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDetectSecretDoors>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionDevourBySwarm"/>
    /// </summary>
    public static ActionsBuilder ContextActionDevourBySwarm(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDevourBySwarm>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionDisarm"/>
    /// </summary>
    public static ActionsBuilder ContextActionDisarm(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDisarm>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionDismissAreaEffect"/>
    /// </summary>
    public static ActionsBuilder ContextActionDismissAreaEffect(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDismissAreaEffect>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionDismount"/>
    /// </summary>
    public static ActionsBuilder ContextActionDismount(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDismount>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionDispelMagic"/>
    /// </summary>
    public static ActionsBuilder ContextActionDispelMagic(
        this ActionsBuilder builder,
        ContextActionDispelMagic.BuffType? buffType = null,
        int? checkBonus = null,
        bool? checkSchoolOrDescriptor = null,
        RuleDispelMagic.CheckType? checkType = null,
        ContextValue? contextBonus = null,
        ContextValue? countToRemove = null,
        SpellDescriptorWrapper? descriptor = null,
        ContextValue? maxCasterLevel = null,
        ContextValue? maxSpellLevel = null,
        bool? oneRollForAll = null,
        ActionsBuilder? onFail = null,
        bool? onlyEnemyAreaEffects = null,
        bool? onlyTargetEnemyBuffs = null,
        ActionsBuilder? onSuccess = null,
        SpellSchool[]? schools = null,
        StatType? skill = null,
        bool? stopAfterCountRemoved = null,
        bool? useMaxCasterLevel = null)
    {
      var element = ElementTool.Create<ContextActionDispelMagic>();
      if (buffType is not null)
      {
        element.m_BuffType = buffType;
      }
      if (checkBonus is not null)
      {
        element.CheckBonus = checkBonus;
      }
      if (checkSchoolOrDescriptor is not null)
      {
        element.CheckSchoolOrDescriptor = checkSchoolOrDescriptor;
      }
      if (checkType is not null)
      {
        element.m_CheckType = checkType;
      }
      if (contextBonus is not null)
      {
        element.ContextBonus = contextBonus;
      }
      if (element.ContextBonus is null)
      {
        element.ContextBonus = ContextValues.Constant(0);
      }
      if (countToRemove is not null)
      {
        element.m_CountToRemove = countToRemove;
      }
      if (element.m_CountToRemove is null)
      {
        element.m_CountToRemove = ContextValues.Constant(0);
      }
      if (descriptor is not null)
      {
        element.Descriptor = descriptor;
      }
      if (maxCasterLevel is not null)
      {
        element.m_MaxCasterLevel = maxCasterLevel;
      }
      if (element.m_MaxCasterLevel is null)
      {
        element.m_MaxCasterLevel = ContextValues.Constant(0);
      }
      if (maxSpellLevel is not null)
      {
        element.m_MaxSpellLevel = maxSpellLevel;
      }
      if (element.m_MaxSpellLevel is null)
      {
        element.m_MaxSpellLevel = ContextValues.Constant(0);
      }
      if (oneRollForAll is not null)
      {
        element.OneRollForAll = oneRollForAll;
      }
      if (onFail is not null)
      {
        element.OnFail = onFail.Build();
      }
      if (element.OnFail is null)
      {
        element.OnFail = Constants.Empty.Actions;
      }
      if (onlyEnemyAreaEffects is not null)
      {
        element.OnlyEnemyAreaEffects = onlyEnemyAreaEffects;
      }
      if (onlyTargetEnemyBuffs is not null)
      {
        element.OnlyTargetEnemyBuffs = onlyTargetEnemyBuffs;
      }
      if (onSuccess is not null)
      {
        element.OnSuccess = onSuccess.Build();
      }
      if (element.OnSuccess is null)
      {
        element.OnSuccess = Constants.Empty.Actions;
      }
      if (schools is not null)
      {
        element.Schools = schools;
      }
      if (element.Schools is null)
      {
        element.Schools = new SpellSchool[0];
      }
      if (skill is not null)
      {
        element.m_Skill = skill;
      }
      if (stopAfterCountRemoved is not null)
      {
        element.m_StopAfterCountRemoved = stopAfterCountRemoved;
      }
      if (useMaxCasterLevel is not null)
      {
        element.m_UseMaxCasterLevel = useMaxCasterLevel;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionDropItems"/>
    /// </summary>
    public static ActionsBuilder ContextActionDropItems(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionDropItems>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionEnchantWornItem"/>
    /// </summary>
    ///
    /// <param name="enchantment">
    /// Blueprint of type BlueprintItemEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextActionEnchantWornItem(
        this ActionsBuilder builder,
        ContextDurationValue? durationValue = null,
        Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>? enchantment = null,
        bool? permanent = null,
        bool? removeOnUnequip = null,
        EquipSlotBase.SlotType? slot = null,
        bool? toCaster = null)
    {
      var element = ElementTool.Create<ContextActionEnchantWornItem>();
      if (durationValue is not null)
      {
        builder.Validate(durationValue);
        element.DurationValue = durationValue;
      }
      if (enchantment is not null)
      {
        element.m_Enchantment = enchantment.Reference;
      }
      if (element.m_Enchantment is null)
      {
        element.m_Enchantment = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(null);
      }
      if (permanent is not null)
      {
        element.Permanent = permanent;
      }
      if (removeOnUnequip is not null)
      {
        element.RemoveOnUnequip = removeOnUnequip;
      }
      if (slot is not null)
      {
        element.Slot = slot;
      }
      if (toCaster is not null)
      {
        element.ToCaster = toCaster;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionFinishObjective"/>
    /// </summary>
    ///
    /// <param name="objective">
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextActionFinishObjective(
        this ActionsBuilder builder,
        Blueprint<BlueprintQuestObjective, BlueprintQuestObjectiveReference>? objective = null)
    {
      var element = ElementTool.Create<ContextActionFinishObjective>();
      if (objective is not null)
      {
        element.m_Objective = objective.Reference;
      }
      if (element.m_Objective is null)
      {
        element.m_Objective = BlueprintTool.GetRef<BlueprintQuestObjectiveReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionForEachSwallowedUnit"/>
    /// </summary>
    public static ActionsBuilder ContextActionForEachSwallowedUnit(
        this ActionsBuilder builder,
        ActionsBuilder? action = null)
    {
      var element = ElementTool.Create<ContextActionForEachSwallowedUnit>();
      if (action is not null)
      {
        element.Action = action.Build();
      }
      if (element.Action is null)
      {
        element.Action = Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionGiveExperience"/>
    /// </summary>
    public static ActionsBuilder ContextActionGiveExperience(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionGiveExperience>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionGrapple"/>
    /// </summary>
    ///
    /// <param name="casterBuff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="targetBuff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextActionGrapple(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? casterBuff = null,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? targetBuff = null)
    {
      var element = ElementTool.Create<ContextActionGrapple>();
      if (casterBuff is not null)
      {
        element.m_CasterBuff = casterBuff.Reference;
      }
      if (element.m_CasterBuff is null)
      {
        element.m_CasterBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      if (targetBuff is not null)
      {
        element.m_TargetBuff = targetBuff.Reference;
      }
      if (element.m_TargetBuff is null)
      {
        element.m_TargetBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionHealEnergyDrain"/>
    /// </summary>
    public static ActionsBuilder ContextActionHealEnergyDrain(
        this ActionsBuilder builder,
        EnergyDrainHealType? permanentNegativeLevelsHeal = null,
        EnergyDrainHealType? temporaryNegativeLevelsHeal = null)
    {
      var element = ElementTool.Create<ContextActionHealEnergyDrain>();
      if (permanentNegativeLevelsHeal is not null)
      {
        element.PermanentNegativeLevelsHeal = permanentNegativeLevelsHeal;
      }
      if (temporaryNegativeLevelsHeal is not null)
      {
        element.TemporaryNegativeLevelsHeal = temporaryNegativeLevelsHeal;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionHealStatDamage"/>
    /// </summary>
    public static ActionsBuilder ContextActionHealStatDamage(
        this ActionsBuilder builder,
        bool? healDrain = null,
        ContextActionHealStatDamage.StatDamageHealType? healType = null,
        AbilitySharedValue? resultSharedValue = null,
        ContextActionHealStatDamage.StatClass? statClass = null,
        ContextDiceValue? value = null,
        bool? writeResultToSharedValue = null)
    {
      var element = ElementTool.Create<ContextActionHealStatDamage>();
      if (healDrain is not null)
      {
        element.HealDrain = healDrain;
      }
      if (healType is not null)
      {
        element.m_HealType = healType;
      }
      if (resultSharedValue is not null)
      {
        element.ResultSharedValue = resultSharedValue;
      }
      if (statClass is not null)
      {
        element.m_StatClass = statClass;
      }
      if (value is not null)
      {
        element.Value = value;
      }
      if (element.Value is null)
      {
        element.Value = Constants.Empty.DiceValue;
      }
      if (writeResultToSharedValue is not null)
      {
        element.WriteResultToSharedValue = writeResultToSharedValue;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionHealTarget"/>
    /// </summary>
    public static ActionsBuilder ContextActionHealTarget(
        this ActionsBuilder builder,
        ContextDiceValue? value = null)
    {
      var element = ElementTool.Create<ContextActionHealTarget>();
      if (value is not null)
      {
        element.Value = value;
      }
      if (element.Value is null)
      {
        element.Value = Constants.Empty.DiceValue;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionHideInPlainSight"/>
    /// </summary>
    public static ActionsBuilder ContextActionHideInPlainSight(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionHideInPlainSight>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionKill"/>
    /// </summary>
    public static ActionsBuilder ContextActionKill(
        this ActionsBuilder builder,
        UnitState.DismemberType? dismember = null)
    {
      var element = ElementTool.Create<ContextActionKill>();
      if (dismember is not null)
      {
        element.Dismember = dismember;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionKnockdownTarget"/>
    /// </summary>
    public static ActionsBuilder ContextActionKnockdownTarget(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionKnockdownTarget>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionMakeKnowledgeCheck"/>
    /// </summary>
    public static ActionsBuilder ContextActionMakeKnowledgeCheck(
        this ActionsBuilder builder,
        ActionsBuilder? failActions = null,
        ActionsBuilder? successActions = null)
    {
      var element = ElementTool.Create<ContextActionMakeKnowledgeCheck>();
      if (failActions is not null)
      {
        element.FailActions = failActions.Build();
      }
      if (element.FailActions is null)
      {
        element.FailActions = Constants.Empty.Actions;
      }
      if (successActions is not null)
      {
        element.SuccessActions = successActions.Build();
      }
      if (element.SuccessActions is null)
      {
        element.SuccessActions = Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionMarkForceDismemberOwner"/>
    /// </summary>
    public static ActionsBuilder ContextActionMarkForceDismemberOwner(
        this ActionsBuilder builder,
        UnitState.DismemberType? forceDismemberType = null)
    {
      var element = ElementTool.Create<ContextActionMarkForceDismemberOwner>();
      if (forceDismemberType is not null)
      {
        element.ForceDismemberType = forceDismemberType;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionMeleeAttack"/>
    /// </summary>
    public static ActionsBuilder ContextActionMeleeAttack(
        this ActionsBuilder builder,
        bool? autoCritConfirmation = null,
        bool? autoCritThreat = null,
        bool? autoHit = null,
        bool? extraAttack = null,
        bool? fullAttack = null,
        bool? ignoreStatBonus = null,
        bool? selectNewTarget = null)
    {
      var element = ElementTool.Create<ContextActionMeleeAttack>();
      if (autoCritConfirmation is not null)
      {
        element.AutoCritConfirmation = autoCritConfirmation;
      }
      if (autoCritThreat is not null)
      {
        element.AutoCritThreat = autoCritThreat;
      }
      if (autoHit is not null)
      {
        element.AutoHit = autoHit;
      }
      if (extraAttack is not null)
      {
        element.ExtraAttack = extraAttack;
      }
      if (fullAttack is not null)
      {
        element.FullAttack = fullAttack;
      }
      if (ignoreStatBonus is not null)
      {
        element.IgnoreStatBonus = ignoreStatBonus;
      }
      if (selectNewTarget is not null)
      {
        element.SelectNewTarget = selectNewTarget;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionMount"/>
    /// </summary>
    public static ActionsBuilder ContextActionMount(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionMount>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionOnContextCaster"/>
    /// </summary>
    public static ActionsBuilder ContextActionOnContextCaster(
        this ActionsBuilder builder,
        ActionsBuilder? actions = null)
    {
      var element = ElementTool.Create<ContextActionOnContextCaster>();
      if (actions is not null)
      {
        element.Actions = actions.Build();
      }
      if (element.Actions is null)
      {
        element.Actions = Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionOnOwner"/>
    /// </summary>
    public static ActionsBuilder ContextActionOnOwner(
        this ActionsBuilder builder,
        ActionsBuilder? actions = null)
    {
      var element = ElementTool.Create<ContextActionOnOwner>();
      if (actions is not null)
      {
        element.Actions = actions.Build();
      }
      if (element.Actions is null)
      {
        element.Actions = Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionOnRandomAreaTarget"/>
    /// </summary>
    public static ActionsBuilder ContextActionOnRandomAreaTarget(
        this ActionsBuilder builder,
        ActionsBuilder? actions = null,
        bool? onEnemies = null)
    {
      var element = ElementTool.Create<ContextActionOnRandomAreaTarget>();
      if (actions is not null)
      {
        element.Actions = actions.Build();
      }
      if (element.Actions is null)
      {
        element.Actions = Constants.Empty.Actions;
      }
      if (onEnemies is not null)
      {
        element.OnEnemies = onEnemies;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionOnRandomTargetsAround"/>
    /// </summary>
    ///
    /// <param name="filterNoFact">
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextActionOnRandomTargetsAround(
        this ActionsBuilder builder,
        ActionsBuilder? actions = null,
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>? filterNoFact = null,
        int? numberOfTargets = null,
        bool? onEnemies = null,
        Feet? radius = null)
    {
      var element = ElementTool.Create<ContextActionOnRandomTargetsAround>();
      if (actions is not null)
      {
        element.Actions = actions.Build();
      }
      if (element.Actions is null)
      {
        element.Actions = Constants.Empty.Actions;
      }
      if (filterNoFact is not null)
      {
        element.m_FilterNoFact = filterNoFact.Reference;
      }
      if (element.m_FilterNoFact is null)
      {
        element.m_FilterNoFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      if (numberOfTargets is not null)
      {
        element.NumberOfTargets = numberOfTargets;
      }
      if (onEnemies is not null)
      {
        element.OnEnemies = onEnemies;
      }
      if (radius is not null)
      {
        element.Radius = radius;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionOnSwarmTargets"/>
    /// </summary>
    public static ActionsBuilder ContextActionOnSwarmTargets(
        this ActionsBuilder builder,
        ActionsBuilder? actions = null)
    {
      var element = ElementTool.Create<ContextActionOnSwarmTargets>();
      if (actions is not null)
      {
        element.Actions = actions.Build();
      }
      if (element.Actions is null)
      {
        element.Actions = Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionPrintHDRestrictionToCombatLog"/>
    /// </summary>
    public static ActionsBuilder ContextActionPrintHDRestrictionToCombatLog(
        this ActionsBuilder builder,
        ContextValue? hitDice = null)
    {
      var element = ElementTool.Create<ContextActionPrintHDRestrictionToCombatLog>();
      if (hitDice is not null)
      {
        element.HitDice = hitDice;
      }
      if (element.HitDice is null)
      {
        element.HitDice = ContextValues.Constant(0);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionProjectileFx"/>
    /// </summary>
    ///
    /// <param name="projectile">
    /// Blueprint of type BlueprintProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextActionProjectileFx(
        this ActionsBuilder builder,
        Blueprint<BlueprintProjectile, BlueprintProjectileReference>? projectile = null)
    {
      var element = ElementTool.Create<ContextActionProjectileFx>();
      if (projectile is not null)
      {
        element.m_Projectile = projectile.Reference;
      }
      if (element.m_Projectile is null)
      {
        element.m_Projectile = BlueprintTool.GetRef<BlueprintProjectileReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionProvokeAttackFromCaster"/>
    /// </summary>
    public static ActionsBuilder ContextActionProvokeAttackFromCaster(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionProvokeAttackFromCaster>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionProvokeAttackOfOpportunity"/>
    /// </summary>
    public static ActionsBuilder ContextActionProvokeAttackOfOpportunity(
        this ActionsBuilder builder,
        bool? applyToCaster = null)
    {
      var element = ElementTool.Create<ContextActionProvokeAttackOfOpportunity>();
      if (applyToCaster is not null)
      {
        element.ApplyToCaster = applyToCaster;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionPush"/>
    /// </summary>
    public static ActionsBuilder ContextActionPush(
        this ActionsBuilder builder,
        ContextValue? distance = null,
        bool? provokeAttackOfOpportunity = null)
    {
      var element = ElementTool.Create<ContextActionPush>();
      if (distance is not null)
      {
        element.Distance = distance;
      }
      if (element.Distance is null)
      {
        element.Distance = ContextValues.Constant(0);
      }
      if (provokeAttackOfOpportunity is not null)
      {
        element.ProvokeAttackOfOpportunity = provokeAttackOfOpportunity;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRandomize"/>
    /// </summary>
    public static ActionsBuilder ContextActionRandomize(
        this ActionsBuilder builder,
        ContextActionRandomize.ActionWrapper[]? actions = null)
    {
      var element = ElementTool.Create<ContextActionRandomize>();
      if (actions is not null)
      {
        foreach (var item in actions) { builder.Validate(item); }
        element.m_Actions = actions;
      }
      if (element.m_Actions is null)
      {
        element.m_Actions = new ContextActionRandomize.ActionWrapper[0];
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRangedAttack"/>
    /// </summary>
    public static ActionsBuilder ContextActionRangedAttack(
        this ActionsBuilder builder,
        bool? autoCritConfirmation = null,
        bool? autoCritThreat = null,
        bool? autoHit = null,
        bool? extraAttack = null,
        bool? fullAttack = null,
        bool? ignoreStatBonus = null,
        bool? selectNewTarget = null)
    {
      var element = ElementTool.Create<ContextActionRangedAttack>();
      if (autoCritConfirmation is not null)
      {
        element.AutoCritConfirmation = autoCritConfirmation;
      }
      if (autoCritThreat is not null)
      {
        element.AutoCritThreat = autoCritThreat;
      }
      if (autoHit is not null)
      {
        element.AutoHit = autoHit;
      }
      if (extraAttack is not null)
      {
        element.ExtraAttack = extraAttack;
      }
      if (fullAttack is not null)
      {
        element.FullAttack = fullAttack;
      }
      if (ignoreStatBonus is not null)
      {
        element.IgnoreStatBonus = ignoreStatBonus;
      }
      if (selectNewTarget is not null)
      {
        element.SelectNewTarget = selectNewTarget;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRecoverItemCharges"/>
    /// </summary>
    ///
    /// <param name="item">
    /// Blueprint of type BlueprintItemEquipment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextActionRecoverItemCharges(
        this ActionsBuilder builder,
        int? chargesRecoverCount = null,
        Blueprint<BlueprintItemEquipment, BlueprintItemEquipmentReference>? item = null)
    {
      var element = ElementTool.Create<ContextActionRecoverItemCharges>();
      if (chargesRecoverCount is not null)
      {
        element.ChargesRecoverCount = chargesRecoverCount;
      }
      if (item is not null)
      {
        element.m_Item = item.Reference;
      }
      if (element.m_Item is null)
      {
        element.m_Item = BlueprintTool.GetRef<BlueprintItemEquipmentReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionReduceBuffDuration"/>
    /// </summary>
    ///
    /// <param name="targetBuff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextActionReduceBuffDuration(
        this ActionsBuilder builder,
        ContextDurationValue? durationValue = null,
        bool? increase = null,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? targetBuff = null,
        bool? toTarget = null)
    {
      var element = ElementTool.Create<ContextActionReduceBuffDuration>();
      if (durationValue is not null)
      {
        builder.Validate(durationValue);
        element.DurationValue = durationValue;
      }
      if (increase is not null)
      {
        element.Increase = increase;
      }
      if (targetBuff is not null)
      {
        element.m_TargetBuff = targetBuff.Reference;
      }
      if (element.m_TargetBuff is null)
      {
        element.m_TargetBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      if (toTarget is not null)
      {
        element.ToTarget = toTarget;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRemoveBuff"/>
    /// </summary>
    ///
    /// <param name="buff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextActionRemoveBuff(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? buff = null,
        bool? onlyFromCaster = null,
        bool? removeRank = null,
        bool? toCaster = null)
    {
      var element = ElementTool.Create<ContextActionRemoveBuff>();
      if (buff is not null)
      {
        element.m_Buff = buff.Reference;
      }
      if (element.m_Buff is null)
      {
        element.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      if (onlyFromCaster is not null)
      {
        element.OnlyFromCaster = onlyFromCaster;
      }
      if (removeRank is not null)
      {
        element.RemoveRank = removeRank;
      }
      if (toCaster is not null)
      {
        element.ToCaster = toCaster;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRemoveBuffsByDescriptor"/>
    /// </summary>
    public static ActionsBuilder ContextActionRemoveBuffsByDescriptor(
        this ActionsBuilder builder,
        bool? notSelf = null,
        SpellDescriptorWrapper? spellDescriptor = null)
    {
      var element = ElementTool.Create<ContextActionRemoveBuffsByDescriptor>();
      if (notSelf is not null)
      {
        element.NotSelf = notSelf;
      }
      if (spellDescriptor is not null)
      {
        element.SpellDescriptor = spellDescriptor;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRemoveBuffSingleStack"/>
    /// </summary>
    ///
    /// <param name="targetBuff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextActionRemoveBuffSingleStack(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? targetBuff = null)
    {
      var element = ElementTool.Create<ContextActionRemoveBuffSingleStack>();
      if (targetBuff is not null)
      {
        element.m_TargetBuff = targetBuff.Reference;
      }
      if (element.m_TargetBuff is null)
      {
        element.m_TargetBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionReduceDebilitatingBuffsDuration"/>
    /// </summary>
    public static ActionsBuilder ContextActionReduceDebilitatingBuffsDuration(
        this ActionsBuilder builder,
        StatsAdjustmentsType? statsAdjustmentsType = null)
    {
      var element = ElementTool.Create<ContextActionReduceDebilitatingBuffsDuration>();
      if (statsAdjustmentsType is not null)
      {
        element.StatsAdjustmentsType = statsAdjustmentsType;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRemoveDeathDoor"/>
    /// </summary>
    public static ActionsBuilder ContextActionRemoveDeathDoor(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionRemoveDeathDoor>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionRemoveSelf"/>
    /// </summary>
    public static ActionsBuilder ContextActionRemoveSelf(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionRemoveSelf>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionRepeatedActions"/>
    /// </summary>
    public static ActionsBuilder ContextActionRepeatedActions(
        this ActionsBuilder builder,
        ActionsBuilder? actions = null,
        ContextDiceValue? value = null)
    {
      var element = ElementTool.Create<ContextActionRepeatedActions>();
      if (actions is not null)
      {
        element.Actions = actions.Build();
      }
      if (element.Actions is null)
      {
        element.Actions = Constants.Empty.Actions;
      }
      if (value is not null)
      {
        element.Value = value;
      }
      if (element.Value is null)
      {
        element.Value = Constants.Empty.DiceValue;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionRestoreSpells"/>
    /// </summary>
    ///
    /// <param name="spellbooks">
    /// Blueprint of type BlueprintSpellbook. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextActionRestoreSpells(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintSpellbook, BlueprintSpellbookReference>>? spellbooks = null)
    {
      var element = ElementTool.Create<ContextActionRestoreSpells>();
      if (spellbooks is not null)
      {
        element.m_Spellbooks = spellbooks.Select(bp => bp.Reference).ToArray();
      }
      if (element.m_Spellbooks is null)
      {
        element.m_Spellbooks = new BlueprintSpellbookReference[0];
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionResurrect"/>
    /// </summary>
    ///
    /// <param name="customResurrectionBuff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextActionResurrect(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? customResurrectionBuff = null,
        bool? fullRestore = null,
        float? resultHealth = null)
    {
      var element = ElementTool.Create<ContextActionResurrect>();
      if (customResurrectionBuff is not null)
      {
        element.m_CustomResurrectionBuff = customResurrectionBuff.Reference;
      }
      if (element.m_CustomResurrectionBuff is null)
      {
        element.m_CustomResurrectionBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      if (fullRestore is not null)
      {
        element.FullRestore = fullRestore;
      }
      if (resultHealth is not null)
      {
        element.ResultHealth = resultHealth;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSavingThrow"/>
    /// </summary>
    public static ActionsBuilder ContextActionSavingThrow(
        this ActionsBuilder builder,
        ActionsBuilder? actions = null,
        ContextActionSavingThrow.ConditionalDCIncrease[]? conditionalDCIncrease = null,
        ContextValue? customDC = null,
        bool? fromBuff = null,
        bool? hasCustomDC = null,
        SavingThrowType? type = null)
    {
      var element = ElementTool.Create<ContextActionSavingThrow>();
      if (actions is not null)
      {
        element.Actions = actions.Build();
      }
      if (element.Actions is null)
      {
        element.Actions = Constants.Empty.Actions;
      }
      if (conditionalDCIncrease is not null)
      {
        element.m_ConditionalDCIncrease = conditionalDCIncrease;
      }
      if (element.m_ConditionalDCIncrease is null)
      {
        element.m_ConditionalDCIncrease = new ContextActionSavingThrow.ConditionalDCIncrease[0];
      }
      if (customDC is not null)
      {
        element.CustomDC = customDC;
      }
      if (element.CustomDC is null)
      {
        element.CustomDC = ContextValues.Constant(0);
      }
      if (fromBuff is not null)
      {
        element.FromBuff = fromBuff;
      }
      if (hasCustomDC is not null)
      {
        element.HasCustomDC = hasCustomDC;
      }
      if (type is not null)
      {
        element.Type = type;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSelectByValue"/>
    /// </summary>
    public static ActionsBuilder ContextActionSelectByValue(
        this ActionsBuilder builder,
        ContextActionSelectByValue.SelectionType? type = null,
        ContextActionSelectByValue.ValueAndAction[]? variants = null)
    {
      var element = ElementTool.Create<ContextActionSelectByValue>();
      if (type is not null)
      {
        element.m_Type = type;
      }
      if (variants is not null)
      {
        element.m_Variants = variants;
      }
      if (element.m_Variants is null)
      {
        element.m_Variants = new ContextActionSelectByValue.ValueAndAction[0];
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSkillCheck"/>
    /// </summary>
    public static ActionsBuilder ContextActionSkillCheck(
        this ActionsBuilder builder,
        bool? calculateDCDifference = null,
        ContextActionSkillCheck.ConditionalDCIncrease[]? conditionalDCIncrease = null,
        ContextValue? customDC = null,
        ActionsBuilder? failure = null,
        ActionsBuilder? failureDiffMoreOrEqual10 = null,
        ActionsBuilder? failureDiffMoreOrEqual5Less10 = null,
        StatType? stat = null,
        ActionsBuilder? success = null,
        bool? useCustomDC = null)
    {
      var element = ElementTool.Create<ContextActionSkillCheck>();
      if (calculateDCDifference is not null)
      {
        element.CalculateDCDifference = calculateDCDifference;
      }
      if (conditionalDCIncrease is not null)
      {
        element.m_ConditionalDCIncrease = conditionalDCIncrease;
      }
      if (element.m_ConditionalDCIncrease is null)
      {
        element.m_ConditionalDCIncrease = new ContextActionSkillCheck.ConditionalDCIncrease[0];
      }
      if (customDC is not null)
      {
        element.CustomDC = customDC;
      }
      if (element.CustomDC is null)
      {
        element.CustomDC = ContextValues.Constant(0);
      }
      if (failure is not null)
      {
        element.Failure = failure.Build();
      }
      if (element.Failure is null)
      {
        element.Failure = Constants.Empty.Actions;
      }
      if (failureDiffMoreOrEqual10 is not null)
      {
        element.FailureDiffMoreOrEqual10 = failureDiffMoreOrEqual10.Build();
      }
      if (element.FailureDiffMoreOrEqual10 is null)
      {
        element.FailureDiffMoreOrEqual10 = Constants.Empty.Actions;
      }
      if (failureDiffMoreOrEqual5Less10 is not null)
      {
        element.FailureDiffMoreOrEqual5Less10 = failureDiffMoreOrEqual5Less10.Build();
      }
      if (element.FailureDiffMoreOrEqual5Less10 is null)
      {
        element.FailureDiffMoreOrEqual5Less10 = Constants.Empty.Actions;
      }
      if (stat is not null)
      {
        element.Stat = stat;
      }
      if (success is not null)
      {
        element.Success = success.Build();
      }
      if (element.Success is null)
      {
        element.Success = Constants.Empty.Actions;
      }
      if (useCustomDC is not null)
      {
        element.UseCustomDC = useCustomDC;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionsOnPet"/>
    /// </summary>
    public static ActionsBuilder ContextActionsOnPet(
        this ActionsBuilder builder,
        ActionsBuilder? actions = null,
        bool? allPets = null,
        PetType? petType = null)
    {
      var element = ElementTool.Create<ContextActionsOnPet>();
      if (actions is not null)
      {
        element.Actions = actions.Build();
      }
      if (element.Actions is null)
      {
        element.Actions = Constants.Empty.Actions;
      }
      if (allPets is not null)
      {
        element.AllPets = allPets;
      }
      if (petType is not null)
      {
        element.PetType = petType;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSpawnAreaEffect"/>
    /// </summary>
    ///
    /// <param name="areaEffect">
    /// Blueprint of type BlueprintAbilityAreaEffect. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextActionSpawnAreaEffect(
        this ActionsBuilder builder,
        Blueprint<BlueprintAbilityAreaEffect, BlueprintAbilityAreaEffectReference>? areaEffect = null,
        ContextDurationValue? durationValue = null,
        bool? onUnit = null)
    {
      var element = ElementTool.Create<ContextActionSpawnAreaEffect>();
      if (areaEffect is not null)
      {
        element.m_AreaEffect = areaEffect.Reference;
      }
      if (element.m_AreaEffect is null)
      {
        element.m_AreaEffect = BlueprintTool.GetRef<BlueprintAbilityAreaEffectReference>(null);
      }
      if (durationValue is not null)
      {
        builder.Validate(durationValue);
        element.DurationValue = durationValue;
      }
      if (onUnit is not null)
      {
        element.OnUnit = onUnit;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSpawnControllableProjectile"/>
    /// </summary>
    ///
    /// <param name="associatedCasterBuff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="controllableProjectile">
    /// Blueprint of type BlueprintControllableProjectile. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextActionSpawnControllableProjectile(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? associatedCasterBuff = null,
        Blueprint<BlueprintControllableProjectile, BlueprintControllableProjectileReference>? controllableProjectile = null)
    {
      var element = ElementTool.Create<ContextActionSpawnControllableProjectile>();
      if (associatedCasterBuff is not null)
      {
        element.AssociatedCasterBuff = associatedCasterBuff.Reference;
      }
      if (element.AssociatedCasterBuff is null)
      {
        element.AssociatedCasterBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      if (controllableProjectile is not null)
      {
        element.ControllableProjectile = controllableProjectile.Reference;
      }
      if (element.ControllableProjectile is null)
      {
        element.ControllableProjectile = BlueprintTool.GetRef<BlueprintControllableProjectileReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSpawnMonster"/>
    /// </summary>
    ///
    /// <param name="blueprint">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="summonPool">
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextActionSpawnMonster(
        this ActionsBuilder builder,
        ActionsBuilder? afterSpawn = null,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? blueprint = null,
        ContextDiceValue? countValue = null,
        bool? doNotLinkToCaster = null,
        ContextDurationValue? durationValue = null,
        bool? isDirectlyControllable = null,
        ContextValue? levelValue = null,
        Blueprint<BlueprintSummonPool, BlueprintSummonPoolReference>? summonPool = null,
        bool? useLimitFromSummonPool = null)
    {
      var element = ElementTool.Create<ContextActionSpawnMonster>();
      if (afterSpawn is not null)
      {
        element.AfterSpawn = afterSpawn.Build();
      }
      if (element.AfterSpawn is null)
      {
        element.AfterSpawn = Constants.Empty.Actions;
      }
      if (blueprint is not null)
      {
        element.m_Blueprint = blueprint.Reference;
      }
      if (element.m_Blueprint is null)
      {
        element.m_Blueprint = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      if (countValue is not null)
      {
        element.CountValue = countValue;
      }
      if (element.CountValue is null)
      {
        element.CountValue = Constants.Empty.DiceValue;
      }
      if (doNotLinkToCaster is not null)
      {
        element.DoNotLinkToCaster = doNotLinkToCaster;
      }
      if (durationValue is not null)
      {
        builder.Validate(durationValue);
        element.DurationValue = durationValue;
      }
      if (isDirectlyControllable is not null)
      {
        element.IsDirectlyControllable = isDirectlyControllable;
      }
      if (levelValue is not null)
      {
        element.LevelValue = levelValue;
      }
      if (element.LevelValue is null)
      {
        element.LevelValue = ContextValues.Constant(0);
      }
      if (summonPool is not null)
      {
        element.m_SummonPool = summonPool.Reference;
      }
      if (element.m_SummonPool is null)
      {
        element.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      if (useLimitFromSummonPool is not null)
      {
        element.UseLimitFromSummonPool = useLimitFromSummonPool;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSpawnUnlinkedMonster"/>
    /// </summary>
    ///
    /// <param name="blueprint">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextActionSpawnUnlinkedMonster(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? blueprint = null)
    {
      var element = ElementTool.Create<ContextActionSpawnUnlinkedMonster>();
      if (blueprint is not null)
      {
        element.m_Blueprint = blueprint.Reference;
      }
      if (element.m_Blueprint is null)
      {
        element.m_Blueprint = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSpendAttackOfOpportunity"/>
    /// </summary>
    public static ActionsBuilder ContextActionSpendAttackOfOpportunity(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionSpendAttackOfOpportunity>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionStealBuffs"/>
    /// </summary>
    public static ActionsBuilder ContextActionStealBuffs(
        this ActionsBuilder builder,
        SpellDescriptorWrapper? descriptor = null)
    {
      var element = ElementTool.Create<ContextActionStealBuffs>();
      if (descriptor is not null)
      {
        element.m_Descriptor = descriptor;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSwallowWhole"/>
    /// </summary>
    ///
    /// <param name="targetBuff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextActionSwallowWhole(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? targetBuff = null)
    {
      var element = ElementTool.Create<ContextActionSwallowWhole>();
      if (targetBuff is not null)
      {
        element.m_TargetBuff = targetBuff.Reference;
      }
      if (element.m_TargetBuff is null)
      {
        element.m_TargetBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionSwarmTarget"/>
    /// </summary>
    public static ActionsBuilder ContextActionSwarmTarget(
        this ActionsBuilder builder,
        bool? remove = null)
    {
      var element = ElementTool.Create<ContextActionSwarmTarget>();
      if (remove is not null)
      {
        element.Remove = remove;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextActionTranslocate"/>
    /// </summary>
    public static ActionsBuilder ContextActionTranslocate(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionTranslocate>());
    }

    /// <summary>
    /// Adds <see cref="ContextActionUnsummon"/>
    /// </summary>
    public static ActionsBuilder ContextActionUnsummon(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextActionUnsummon>());
    }

    /// <summary>
    /// Adds <see cref="ContextRestoreResource"/>
    /// </summary>
    ///
    /// <param name="resource">
    /// Blueprint of type BlueprintAbilityResource. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextRestoreResource(
        this ActionsBuilder builder,
        bool? contextValueRestoration = null,
        bool? isFullRestoreAllResources = null,
        Blueprint<BlueprintAbilityResource, BlueprintAbilityResourceReference>? resource = null,
        ContextValue? value = null)
    {
      var element = ElementTool.Create<ContextRestoreResource>();
      if (contextValueRestoration is not null)
      {
        element.ContextValueRestoration = contextValueRestoration;
      }
      if (isFullRestoreAllResources is not null)
      {
        element.m_IsFullRestoreAllResources = isFullRestoreAllResources;
      }
      if (resource is not null)
      {
        element.m_Resource = resource.Reference;
      }
      if (element.m_Resource is null)
      {
        element.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(null);
      }
      if (value is not null)
      {
        element.Value = value;
      }
      if (element.Value is null)
      {
        element.Value = ContextValues.Constant(0);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextSpendResource"/>
    /// </summary>
    ///
    /// <param name="resource">
    /// Blueprint of type BlueprintAbilityResource. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ContextSpendResource(
        this ActionsBuilder builder,
        bool? contextValueSpendure = null,
        Blueprint<BlueprintAbilityResource, BlueprintAbilityResourceReference>? resource = null,
        ContextValue? value = null)
    {
      var element = ElementTool.Create<ContextSpendResource>();
      if (contextValueSpendure is not null)
      {
        element.ContextValueSpendure = contextValueSpendure;
      }
      if (resource is not null)
      {
        element.m_Resource = resource.Reference;
      }
      if (element.m_Resource is null)
      {
        element.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(null);
      }
      if (value is not null)
      {
        element.Value = value;
      }
      if (element.Value is null)
      {
        element.Value = ContextValues.Constant(0);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="Demoralize"/>
    /// </summary>
    ///
    /// <param name="buff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="greaterBuff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="shatterConfidenceBuff">
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="shatterConfidenceFeature">
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="swordlordProwessFeature">
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder Demoralize(
        this ActionsBuilder builder,
        int? bonus = null,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? buff = null,
        bool? dazzlingDisplay = null,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? greaterBuff = null,
        Blueprint<BlueprintBuff, BlueprintBuffReference>? shatterConfidenceBuff = null,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? shatterConfidenceFeature = null,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? swordlordProwessFeature = null,
        ActionsBuilder? tricksterRank3Actions = null)
    {
      var element = ElementTool.Create<Demoralize>();
      if (bonus is not null)
      {
        element.Bonus = bonus;
      }
      if (buff is not null)
      {
        element.m_Buff = buff.Reference;
      }
      if (element.m_Buff is null)
      {
        element.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      if (dazzlingDisplay is not null)
      {
        element.DazzlingDisplay = dazzlingDisplay;
      }
      if (greaterBuff is not null)
      {
        element.m_GreaterBuff = greaterBuff.Reference;
      }
      if (element.m_GreaterBuff is null)
      {
        element.m_GreaterBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      if (shatterConfidenceBuff is not null)
      {
        element.m_ShatterConfidenceBuff = shatterConfidenceBuff.Reference;
      }
      if (element.m_ShatterConfidenceBuff is null)
      {
        element.m_ShatterConfidenceBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      if (shatterConfidenceFeature is not null)
      {
        element.m_ShatterConfidenceFeature = shatterConfidenceFeature.Reference;
      }
      if (element.m_ShatterConfidenceFeature is null)
      {
        element.m_ShatterConfidenceFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      if (swordlordProwessFeature is not null)
      {
        element.m_SwordlordProwessFeature = swordlordProwessFeature.Reference;
      }
      if (element.m_SwordlordProwessFeature is null)
      {
        element.m_SwordlordProwessFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      if (tricksterRank3Actions is not null)
      {
        element.TricksterRank3Actions = tricksterRank3Actions.Build();
      }
      if (element.TricksterRank3Actions is null)
      {
        element.TricksterRank3Actions = Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="EnhanceWeapon"/>
    /// </summary>
    ///
    /// <param name="enchantment">
    /// Blueprint of type BlueprintItemEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder EnhanceWeapon(
        this ActionsBuilder builder,
        ContextDurationValue? durationValue = null,
        ContextValue? enchantLevel = null,
        List<Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>>? enchantment = null,
        EnhanceWeapon.EnchantmentApplyType? enchantmentType = null,
        bool? greater = null,
        bool? useSecondaryHand = null)
    {
      var element = ElementTool.Create<EnhanceWeapon>();
      if (durationValue is not null)
      {
        builder.Validate(durationValue);
        element.DurationValue = durationValue;
      }
      if (enchantLevel is not null)
      {
        element.EnchantLevel = enchantLevel;
      }
      if (element.EnchantLevel is null)
      {
        element.EnchantLevel = ContextValues.Constant(0);
      }
      if (enchantment is not null)
      {
        element.m_Enchantment = enchantment.Select(bp => bp.Reference).ToArray();
      }
      if (element.m_Enchantment is null)
      {
        element.m_Enchantment = new BlueprintItemEnchantmentReference[0];
      }
      if (enchantmentType is not null)
      {
        element.EnchantmentType = enchantmentType;
      }
      if (greater is not null)
      {
        element.Greater = greater;
      }
      if (useSecondaryHand is not null)
      {
        element.UseSecondaryHand = useSecondaryHand;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SwordlordAdaptiveTacticsAdd"/>
    /// </summary>
    ///
    /// <param name="source">
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder SwordlordAdaptiveTacticsAdd(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>? source = null)
    {
      var element = ElementTool.Create<SwordlordAdaptiveTacticsAdd>();
      if (source is not null)
      {
        element.m_Source = source.Reference;
      }
      if (element.m_Source is null)
      {
        element.m_Source = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SwordlordAdaptiveTacticsClear"/>
    /// </summary>
    public static ActionsBuilder SwordlordAdaptiveTacticsClear(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<SwordlordAdaptiveTacticsClear>());
    }
  }
}
