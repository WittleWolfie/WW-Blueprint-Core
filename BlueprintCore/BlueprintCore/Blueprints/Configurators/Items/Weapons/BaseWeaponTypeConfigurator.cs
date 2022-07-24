//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.Localization;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.Utility;
using System;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Items.Weapons
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintWeaponType"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseWeaponTypeConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintWeaponType
    where TBuilder : BaseWeaponTypeConfigurator<T, TBuilder>
  {
    protected BaseWeaponTypeConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintWeaponType.Category"/>
    /// </summary>
    public TBuilder SetCategory(WeaponCategory category)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Category = category;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintWeaponType.m_TypeNameText"/>
    /// </summary>
    ///
    /// <param name="typeNameText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetTypeNameText(LocalString typeNameText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TypeNameText = typeNameText?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintWeaponType.m_TypeNameText"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTypeNameText(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TypeNameText is null) { return; }
          action.Invoke(bp.m_TypeNameText);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintWeaponType.m_DefaultNameText"/>
    /// </summary>
    ///
    /// <param name="defaultNameText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetDefaultNameText(LocalString defaultNameText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DefaultNameText = defaultNameText?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintWeaponType.m_DefaultNameText"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDefaultNameText(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DefaultNameText is null) { return; }
          action.Invoke(bp.m_DefaultNameText);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintWeaponType.m_DescriptionText"/>
    /// </summary>
    ///
    /// <param name="descriptionText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetDescriptionText(LocalString descriptionText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DescriptionText = descriptionText?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintWeaponType.m_DescriptionText"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDescriptionText(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DescriptionText is null) { return; }
          action.Invoke(bp.m_DescriptionText);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintWeaponType.m_MasterworkDescriptionText"/>
    /// </summary>
    ///
    /// <param name="masterworkDescriptionText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetMasterworkDescriptionText(LocalString masterworkDescriptionText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MasterworkDescriptionText = masterworkDescriptionText?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintWeaponType.m_MasterworkDescriptionText"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMasterworkDescriptionText(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_MasterworkDescriptionText is null) { return; }
          action.Invoke(bp.m_MasterworkDescriptionText);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintWeaponType.m_MagicDescriptionText"/>
    /// </summary>
    ///
    /// <param name="magicDescriptionText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetMagicDescriptionText(LocalString magicDescriptionText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MagicDescriptionText = magicDescriptionText?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintWeaponType.m_MagicDescriptionText"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMagicDescriptionText(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_MagicDescriptionText is null) { return; }
          action.Invoke(bp.m_MagicDescriptionText);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintWeaponType.m_Icon"/>
    /// </summary>
    public TBuilder SetIcon(Asset<Sprite> icon)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Icon = icon?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintWeaponType.m_Icon"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIcon(Action<Sprite> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Icon is null) { return; }
          action.Invoke(bp.m_Icon);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintWeaponType.m_VisualParameters"/>
    /// </summary>
    public TBuilder SetVisualParameters(WeaponVisualParameters visualParameters)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(visualParameters);
          bp.m_VisualParameters = visualParameters;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintWeaponType.m_VisualParameters"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyVisualParameters(Action<WeaponVisualParameters> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_VisualParameters is null) { return; }
          action.Invoke(bp.m_VisualParameters);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintWeaponType.m_AttackType"/>
    /// </summary>
    public TBuilder SetAttackType(AttackType attackType)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AttackType = attackType;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintWeaponType.m_AttackRange"/>
    /// </summary>
    public TBuilder SetAttackRange(Feet attackRange)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AttackRange = attackRange;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintWeaponType.m_AttackRange"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAttackRange(Action<Feet> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_AttackRange);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintWeaponType.m_BaseDamage"/>
    /// </summary>
    public TBuilder SetBaseDamage(DiceFormula baseDamage)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BaseDamage = baseDamage;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintWeaponType.m_BaseDamage"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBaseDamage(Action<DiceFormula> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_BaseDamage);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintWeaponType.m_DamageType"/>
    /// </summary>
    public TBuilder SetDamageType(DamageTypeDescription damageType)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(damageType);
          bp.m_DamageType = damageType;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintWeaponType.m_DamageType"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDamageType(Action<DamageTypeDescription> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DamageType is null) { return; }
          action.Invoke(bp.m_DamageType);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintWeaponType.m_CriticalRollEdge"/>
    /// </summary>
    public TBuilder SetCriticalRollEdge(int criticalRollEdge)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CriticalRollEdge = criticalRollEdge;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintWeaponType.m_CriticalModifier"/>
    /// </summary>
    public TBuilder SetCriticalModifier(DamageCriticalModifierType criticalModifier)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CriticalModifier = criticalModifier;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintWeaponType.m_FighterGroupFlags"/>
    /// </summary>
    public TBuilder SetFighterGroupFlags(params WeaponFighterGroupFlags[] fighterGroupFlags)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_FighterGroupFlags = fighterGroupFlags.Aggregate((WeaponFighterGroupFlags) 0, (f1, f2) => f1 | f2);
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintWeaponType.m_FighterGroupFlags"/>
    /// </summary>
    public TBuilder AddToFighterGroupFlags(params WeaponFighterGroupFlags[] fighterGroupFlags)
    {
      return OnConfigureInternal(
        bp =>
        {
          fighterGroupFlags.ForEach(f => bp.m_FighterGroupFlags |= f);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintWeaponType.m_FighterGroupFlags"/>
    /// </summary>
    public TBuilder RemoveFromFighterGroupFlags(params WeaponFighterGroupFlags[] fighterGroupFlags)
    {
      return OnConfigureInternal(
        bp =>
        {
          fighterGroupFlags.ForEach(f => bp.m_FighterGroupFlags &= ~f);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintWeaponType.m_Weight"/>
    /// </summary>
    public TBuilder SetWeight(float weight)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Weight = weight;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintWeaponType.m_IsTwoHanded"/>
    /// </summary>
    public TBuilder SetIsTwoHanded(bool isTwoHanded = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IsTwoHanded = isTwoHanded;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintWeaponType.m_IsLight"/>
    /// </summary>
    public TBuilder SetIsLight(bool isLight = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IsLight = isLight;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintWeaponType.m_IsMonk"/>
    /// </summary>
    public TBuilder SetIsMonk(bool isMonk = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IsMonk = isMonk;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintWeaponType.m_IsNatural"/>
    /// </summary>
    public TBuilder SetIsNatural(bool isNatural = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IsNatural = isNatural;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintWeaponType.m_IsUnarmed"/>
    /// </summary>
    public TBuilder SetIsUnarmed(bool isUnarmed = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IsUnarmed = isUnarmed;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintWeaponType.m_OverrideAttackBonusStat"/>
    /// </summary>
    public TBuilder SetOverrideAttackBonusStat(bool overrideAttackBonusStat = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_OverrideAttackBonusStat = overrideAttackBonusStat;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintWeaponType.m_AttackBonusStatOverride"/>
    /// </summary>
    public TBuilder SetAttackBonusStatOverride(StatType attackBonusStatOverride)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AttackBonusStatOverride = attackBonusStatOverride;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintWeaponType.m_Enchantments"/>
    /// </summary>
    ///
    /// <param name="enchantments">
    /// <para>
    /// Blueprint of type BlueprintWeaponEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetEnchantments(params Blueprint<BlueprintWeaponEnchantmentReference>[] enchantments)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Enchantments = enchantments.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintWeaponType.m_Enchantments"/>
    /// </summary>
    ///
    /// <param name="enchantments">
    /// <para>
    /// Blueprint of type BlueprintWeaponEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToEnchantments(params Blueprint<BlueprintWeaponEnchantmentReference>[] enchantments)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Enchantments = bp.m_Enchantments ?? new BlueprintWeaponEnchantmentReference[0];
          bp.m_Enchantments = CommonTool.Append(bp.m_Enchantments, enchantments.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintWeaponType.m_Enchantments"/>
    /// </summary>
    ///
    /// <param name="enchantments">
    /// <para>
    /// Blueprint of type BlueprintWeaponEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromEnchantments(params Blueprint<BlueprintWeaponEnchantmentReference>[] enchantments)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Enchantments is null) { return; }
          bp.m_Enchantments = bp.m_Enchantments.Where(val => !enchantments.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintWeaponType.m_Enchantments"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromEnchantments(Func<BlueprintWeaponEnchantmentReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Enchantments is null) { return; }
          bp.m_Enchantments = bp.m_Enchantments.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintWeaponType.m_Enchantments"/>
    /// </summary>
    public TBuilder ClearEnchantments()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Enchantments = new BlueprintWeaponEnchantmentReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintWeaponType.m_Enchantments"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyEnchantments(Action<BlueprintWeaponEnchantmentReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Enchantments is null) { return; }
          bp.m_Enchantments.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintWeaponType.m_Destructible"/>
    /// </summary>
    ///
    /// <param name="destructible">
    /// <para>
    /// InfoBox: Default destructible property for type items. Can be overriden in BlueprintItem
    /// </para>
    /// </param>
    public TBuilder SetDestructible(bool destructible = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Destructible = destructible;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintWeaponType.m_ShardItem"/>
    /// </summary>
    ///
    /// <param name="shardItem">
    /// <para>
    /// InfoBox: Trash-item that remains after destruction. Gives a hint to user what source item was like.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetShardItem(Blueprint<BlueprintItemReference> shardItem)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ShardItem = shardItem?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintWeaponType.m_ShardItem"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyShardItem(Action<BlueprintItemReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ShardItem is null) { return; }
          action.Invoke(bp.m_ShardItem);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_TypeNameText is null)
      {
        Blueprint.m_TypeNameText = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_DefaultNameText is null)
      {
        Blueprint.m_DefaultNameText = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_DescriptionText is null)
      {
        Blueprint.m_DescriptionText = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_MasterworkDescriptionText is null)
      {
        Blueprint.m_MasterworkDescriptionText = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_MagicDescriptionText is null)
      {
        Blueprint.m_MagicDescriptionText = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_Enchantments is null)
      {
        Blueprint.m_Enchantments = new BlueprintWeaponEnchantmentReference[0];
      }
      if (Blueprint.m_ShardItem is null)
      {
        Blueprint.m_ShardItem = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
    }
  }
}
