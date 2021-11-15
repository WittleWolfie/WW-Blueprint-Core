using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Localization;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Items.Armors
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintArmorType"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArmorType))]
  public abstract class BaseArmorTypeConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintArmorType
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseArmorTypeConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_TypeNameText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetTypeNameText(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_TypeNameText = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_DefaultNameText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetDefaultNameText(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_DefaultNameText = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_DescriptionText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetDescriptionText(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_DescriptionText = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_MagicDescriptionText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetMagicDescriptionText(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_MagicDescriptionText = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_Icon"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetIcon(Sprite value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_Icon = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_VisualParameters"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetVisualParameters(ArmorVisualParameters value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_VisualParameters = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_ArmorBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetArmorBonus(int value)
    {
      return OnConfigureInternal(bp => bp.m_ArmorBonus = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_ArmorChecksPenalty"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetArmorChecksPenalty(int value)
    {
      return OnConfigureInternal(bp => bp.m_ArmorChecksPenalty = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_HasDexterityBonusLimit"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetHasDexterityBonusLimit(bool value)
    {
      return OnConfigureInternal(bp => bp.m_HasDexterityBonusLimit = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_MaxDexterityBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetMaxDexterityBonus(int value)
    {
      return OnConfigureInternal(bp => bp.m_MaxDexterityBonus = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_ProficiencyGroup"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetProficiencyGroup(ArmorProficiencyGroup value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_ProficiencyGroup = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_ArcaneSpellFailureChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetArcaneSpellFailureChance(int value)
    {
      return OnConfigureInternal(bp => bp.m_ArcaneSpellFailureChance = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_Weight"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetWeight(float value)
    {
      return OnConfigureInternal(bp => bp.m_Weight = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_IsArmor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetIsArmor(bool value)
    {
      return OnConfigureInternal(bp => bp.m_IsArmor = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_IsShield"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetIsShield(bool value)
    {
      return OnConfigureInternal(bp => bp.m_IsShield = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_EquipmentEntity"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="KingmakerEquipmentEntity"/></param>
    [Generated]
    public TBuilder SetEquipmentEntity(string value)
    {
      return OnConfigureInternal(bp => bp.m_EquipmentEntity = BlueprintTool.GetRef<KingmakerEquipmentEntityReference>(value));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmorType.m_EquipmentEntityAlternatives"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="KingmakerEquipmentEntity"/></param>
    [Generated]
    public TBuilder AddToEquipmentEntityAlternatives(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_EquipmentEntityAlternatives = CommonTool.Append(bp.m_EquipmentEntityAlternatives, values.Select(name => BlueprintTool.GetRef<KingmakerEquipmentEntityReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmorType.m_EquipmentEntityAlternatives"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="KingmakerEquipmentEntity"/></param>
    [Generated]
    public TBuilder RemoveFromEquipmentEntityAlternatives(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<KingmakerEquipmentEntityReference>(name));
            bp.m_EquipmentEntityAlternatives =
                bp.m_EquipmentEntityAlternatives
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmorType.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintArmorEnchantment"/></param>
    [Generated]
    public TBuilder AddToEnchantments(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Enchantments = CommonTool.Append(bp.m_Enchantments, values.Select(name => BlueprintTool.GetRef<BlueprintArmorEnchantmentReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmorType.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintArmorEnchantment"/></param>
    [Generated]
    public TBuilder RemoveFromEnchantments(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintArmorEnchantmentReference>(name));
            bp.m_Enchantments =
                bp.m_Enchantments
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_ForcedRampColorPresetIndex"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetForcedRampColorPresetIndex(int value)
    {
      return OnConfigureInternal(bp => bp.m_ForcedRampColorPresetIndex = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_Destructible"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetDestructible(bool value)
    {
      return OnConfigureInternal(bp => bp.m_Destructible = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_ShardItem"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintItem"/></param>
    [Generated]
    public TBuilder SetShardItem(string value)
    {
      return OnConfigureInternal(bp => bp.m_ShardItem = BlueprintTool.GetRef<BlueprintItemReference>(value));
    }
  }

  /// <summary>Configurator for <see cref="BlueprintArmorType"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArmorType))]
  public class ArmorTypeConfigurator : BaseBlueprintConfigurator<BlueprintArmorType, ArmorTypeConfigurator>
  {
     private ArmorTypeConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ArmorTypeConfigurator For(string name)
    {
      return new ArmorTypeConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ArmorTypeConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintArmorType>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ArmorTypeConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintArmorType>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_TypeNameText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetTypeNameText(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_TypeNameText = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_DefaultNameText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetDefaultNameText(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_DefaultNameText = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_DescriptionText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetDescriptionText(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_DescriptionText = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_MagicDescriptionText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetMagicDescriptionText(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_MagicDescriptionText = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_Icon"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetIcon(Sprite value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_Icon = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_VisualParameters"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetVisualParameters(ArmorVisualParameters value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_VisualParameters = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_ArmorBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetArmorBonus(int value)
    {
      return OnConfigureInternal(bp => bp.m_ArmorBonus = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_ArmorChecksPenalty"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetArmorChecksPenalty(int value)
    {
      return OnConfigureInternal(bp => bp.m_ArmorChecksPenalty = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_HasDexterityBonusLimit"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetHasDexterityBonusLimit(bool value)
    {
      return OnConfigureInternal(bp => bp.m_HasDexterityBonusLimit = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_MaxDexterityBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetMaxDexterityBonus(int value)
    {
      return OnConfigureInternal(bp => bp.m_MaxDexterityBonus = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_ProficiencyGroup"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetProficiencyGroup(ArmorProficiencyGroup value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_ProficiencyGroup = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_ArcaneSpellFailureChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetArcaneSpellFailureChance(int value)
    {
      return OnConfigureInternal(bp => bp.m_ArcaneSpellFailureChance = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_Weight"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetWeight(float value)
    {
      return OnConfigureInternal(bp => bp.m_Weight = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_IsArmor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetIsArmor(bool value)
    {
      return OnConfigureInternal(bp => bp.m_IsArmor = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_IsShield"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetIsShield(bool value)
    {
      return OnConfigureInternal(bp => bp.m_IsShield = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_EquipmentEntity"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="KingmakerEquipmentEntity"/></param>
    [Generated]
    public ArmorTypeConfigurator SetEquipmentEntity(string value)
    {
      return OnConfigureInternal(bp => bp.m_EquipmentEntity = BlueprintTool.GetRef<KingmakerEquipmentEntityReference>(value));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmorType.m_EquipmentEntityAlternatives"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="KingmakerEquipmentEntity"/></param>
    [Generated]
    public ArmorTypeConfigurator AddToEquipmentEntityAlternatives(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_EquipmentEntityAlternatives = CommonTool.Append(bp.m_EquipmentEntityAlternatives, values.Select(name => BlueprintTool.GetRef<KingmakerEquipmentEntityReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmorType.m_EquipmentEntityAlternatives"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="KingmakerEquipmentEntity"/></param>
    [Generated]
    public ArmorTypeConfigurator RemoveFromEquipmentEntityAlternatives(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<KingmakerEquipmentEntityReference>(name));
            bp.m_EquipmentEntityAlternatives =
                bp.m_EquipmentEntityAlternatives
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmorType.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintArmorEnchantment"/></param>
    [Generated]
    public ArmorTypeConfigurator AddToEnchantments(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Enchantments = CommonTool.Append(bp.m_Enchantments, values.Select(name => BlueprintTool.GetRef<BlueprintArmorEnchantmentReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmorType.m_Enchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintArmorEnchantment"/></param>
    [Generated]
    public ArmorTypeConfigurator RemoveFromEnchantments(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintArmorEnchantmentReference>(name));
            bp.m_Enchantments =
                bp.m_Enchantments
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_ForcedRampColorPresetIndex"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetForcedRampColorPresetIndex(int value)
    {
      return OnConfigureInternal(bp => bp.m_ForcedRampColorPresetIndex = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_Destructible"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmorTypeConfigurator SetDestructible(bool value)
    {
      return OnConfigureInternal(bp => bp.m_Destructible = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmorType.m_ShardItem"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintItem"/></param>
    [Generated]
    public ArmorTypeConfigurator SetShardItem(string value)
    {
      return OnConfigureInternal(bp => bp.m_ShardItem = BlueprintTool.GetRef<BlueprintItemReference>(value));
    }
  }
}
