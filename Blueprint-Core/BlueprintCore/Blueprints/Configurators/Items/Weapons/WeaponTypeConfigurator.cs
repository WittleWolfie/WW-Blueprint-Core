using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.Localization;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.Utility;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Items.Weapons
{
  /// <summary>Configurator for <see cref="BlueprintWeaponType"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintWeaponType))]
  public class WeaponTypeConfigurator : BaseBlueprintConfigurator<BlueprintWeaponType, WeaponTypeConfigurator>
  {
     private WeaponTypeConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static WeaponTypeConfigurator For(string name)
    {
      return new WeaponTypeConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static WeaponTypeConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintWeaponType>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static WeaponTypeConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintWeaponType>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.Category"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetCategory(WeaponCategory value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Category = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_TypeNameText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetTypeNameText(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_TypeNameText = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_DefaultNameText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetDefaultNameText(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_DefaultNameText = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_DescriptionText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetDescriptionText(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_DescriptionText = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_MasterworkDescriptionText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetMasterworkDescriptionText(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_MasterworkDescriptionText = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_MagicDescriptionText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetMagicDescriptionText(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_MagicDescriptionText = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_Icon"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetIcon(Sprite value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_Icon = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_VisualParameters"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetVisualParameters(WeaponVisualParameters value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_VisualParameters = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_AttackType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetAttackType(AttackType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_AttackType = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_AttackRange"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetAttackRange(Feet value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_AttackRange = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_BaseDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetBaseDamage(DiceFormula value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_BaseDamage = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_DamageType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetDamageType(DamageTypeDescription value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_DamageType = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_CriticalRollEdge"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetCriticalRollEdge(int value)
    {
      return OnConfigureInternal(bp => bp.m_CriticalRollEdge = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_CriticalModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetCriticalModifier(DamageCriticalModifierType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_CriticalModifier = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_FighterGroupFlags"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetFighterGroupFlags(WeaponFighterGroupFlags value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_FighterGroupFlags = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_Weight"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetWeight(float value)
    {
      return OnConfigureInternal(bp => bp.m_Weight = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_IsTwoHanded"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetIsTwoHanded(bool value)
    {
      return OnConfigureInternal(bp => bp.m_IsTwoHanded = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_IsLight"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetIsLight(bool value)
    {
      return OnConfigureInternal(bp => bp.m_IsLight = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_IsMonk"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetIsMonk(bool value)
    {
      return OnConfigureInternal(bp => bp.m_IsMonk = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_IsNatural"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetIsNatural(bool value)
    {
      return OnConfigureInternal(bp => bp.m_IsNatural = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_IsUnarmed"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetIsUnarmed(bool value)
    {
      return OnConfigureInternal(bp => bp.m_IsUnarmed = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_OverrideAttackBonusStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetOverrideAttackBonusStat(bool value)
    {
      return OnConfigureInternal(bp => bp.m_OverrideAttackBonusStat = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_AttackBonusStatOverride"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetAttackBonusStatOverride(StatType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_AttackBonusStatOverride = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintWeaponType.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintWeaponEnchantment"/></param>
    [Generated]
    public WeaponTypeConfigurator AddToEnchantments(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Enchantments = CommonTool.Append(bp.m_Enchantments, values.Select(name => BlueprintTool.GetRef<BlueprintWeaponEnchantmentReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintWeaponType.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintWeaponEnchantment"/></param>
    [Generated]
    public WeaponTypeConfigurator RemoveFromEnchantments(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintWeaponEnchantmentReference>(name));
            bp.m_Enchantments =
                bp.m_Enchantments
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_Destructible"/> (Auto Generated)
    /// </summary>
    [Generated]
    public WeaponTypeConfigurator SetDestructible(bool value)
    {
      return OnConfigureInternal(bp => bp.m_Destructible = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintWeaponType.m_ShardItem"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintItem"/></param>
    [Generated]
    public WeaponTypeConfigurator SetShardItem(string value)
    {
      return OnConfigureInternal(bp => bp.m_ShardItem = BlueprintTool.GetRef<BlueprintItemReference>(value));
    }
  }
}
