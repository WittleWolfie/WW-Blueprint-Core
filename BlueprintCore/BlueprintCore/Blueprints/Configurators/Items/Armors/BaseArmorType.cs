//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Localization;
using Kingmaker.Utility;
using Kingmaker.Visual.CharacterSystem;
using System;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Items.Armors
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintArmorType"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseArmorTypeConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintArmorType
    where TBuilder : BaseArmorTypeConfigurator<T, TBuilder>
  {
    protected BaseArmorTypeConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArmorType.m_TypeNameText"/>
    /// </summary>
    public TBuilder SetTypeNameText(LocalizedString typeNameText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TypeNameText = typeNameText;
          if (bp.m_TypeNameText is null)
          {
            bp.m_TypeNameText = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmorType.m_TypeNameText"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintArmorType.m_DefaultNameText"/>
    /// </summary>
    public TBuilder SetDefaultNameText(LocalizedString defaultNameText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DefaultNameText = defaultNameText;
          if (bp.m_DefaultNameText is null)
          {
            bp.m_DefaultNameText = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmorType.m_DefaultNameText"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintArmorType.m_DescriptionText"/>
    /// </summary>
    public TBuilder SetDescriptionText(LocalizedString descriptionText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DescriptionText = descriptionText;
          if (bp.m_DescriptionText is null)
          {
            bp.m_DescriptionText = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmorType.m_DescriptionText"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintArmorType.m_MagicDescriptionText"/>
    /// </summary>
    public TBuilder SetMagicDescriptionText(LocalizedString magicDescriptionText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MagicDescriptionText = magicDescriptionText;
          if (bp.m_MagicDescriptionText is null)
          {
            bp.m_MagicDescriptionText = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmorType.m_MagicDescriptionText"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintArmorType.m_Icon"/>
    /// </summary>
    public TBuilder SetIcon(Sprite icon)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(icon);
          bp.m_Icon = icon;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmorType.m_Icon"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintArmorType.m_VisualParameters"/>
    /// </summary>
    public TBuilder SetVisualParameters(ArmorVisualParameters visualParameters)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(visualParameters);
          bp.m_VisualParameters = visualParameters;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmorType.m_VisualParameters"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyVisualParameters(Action<ArmorVisualParameters> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_VisualParameters is null) { return; }
          action.Invoke(bp.m_VisualParameters);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArmorType.m_ArmorBonus"/>
    /// </summary>
    public TBuilder SetArmorBonus(int armorBonus)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ArmorBonus = armorBonus;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmorType.m_ArmorBonus"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyArmorBonus(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_ArmorBonus);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArmorType.m_ArmorChecksPenalty"/>
    /// </summary>
    public TBuilder SetArmorChecksPenalty(int armorChecksPenalty)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ArmorChecksPenalty = armorChecksPenalty;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmorType.m_ArmorChecksPenalty"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyArmorChecksPenalty(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_ArmorChecksPenalty);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArmorType.m_HasDexterityBonusLimit"/>
    /// </summary>
    public TBuilder SetHasDexterityBonusLimit(bool hasDexterityBonusLimit = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_HasDexterityBonusLimit = hasDexterityBonusLimit;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmorType.m_HasDexterityBonusLimit"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHasDexterityBonusLimit(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_HasDexterityBonusLimit);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArmorType.m_MaxDexterityBonus"/>
    /// </summary>
    public TBuilder SetMaxDexterityBonus(int maxDexterityBonus)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MaxDexterityBonus = maxDexterityBonus;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmorType.m_MaxDexterityBonus"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMaxDexterityBonus(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_MaxDexterityBonus);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArmorType.m_ProficiencyGroup"/>
    /// </summary>
    public TBuilder SetProficiencyGroup(ArmorProficiencyGroup proficiencyGroup)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ProficiencyGroup = proficiencyGroup;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmorType.m_ProficiencyGroup"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyProficiencyGroup(Action<ArmorProficiencyGroup> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_ProficiencyGroup);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArmorType.m_ArcaneSpellFailureChance"/>
    /// </summary>
    public TBuilder SetArcaneSpellFailureChance(int arcaneSpellFailureChance)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ArcaneSpellFailureChance = arcaneSpellFailureChance;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmorType.m_ArcaneSpellFailureChance"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyArcaneSpellFailureChance(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_ArcaneSpellFailureChance);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArmorType.m_Weight"/>
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
    /// Modifies <see cref="BlueprintArmorType.m_Weight"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyWeight(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_Weight);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArmorType.m_IsArmor"/>
    /// </summary>
    public TBuilder SetIsArmor(bool isArmor = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IsArmor = isArmor;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmorType.m_IsArmor"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIsArmor(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_IsArmor);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArmorType.m_IsShield"/>
    /// </summary>
    public TBuilder SetIsShield(bool isShield = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IsShield = isShield;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmorType.m_IsShield"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIsShield(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_IsShield);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArmorType.m_EquipmentEntity"/>
    /// </summary>
    ///
    /// <param name="equipmentEntity">
    /// <para>
    /// Blueprint of type KingmakerEquipmentEntity. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetEquipmentEntity(Blueprint<KingmakerEquipmentEntity, KingmakerEquipmentEntityReference> equipmentEntity)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_EquipmentEntity = equipmentEntity?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmorType.m_EquipmentEntity"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="equipmentEntity">
    /// <para>
    /// Blueprint of type KingmakerEquipmentEntity. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyEquipmentEntity(Action<KingmakerEquipmentEntityReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_EquipmentEntity is null) { return; }
          action.Invoke(bp.m_EquipmentEntity);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArmorType.m_EquipmentEntityAlternatives"/>
    /// </summary>
    ///
    /// <param name="equipmentEntityAlternatives">
    /// <para>
    /// Blueprint of type KingmakerEquipmentEntity. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetEquipmentEntityAlternatives(params Blueprint<KingmakerEquipmentEntity, KingmakerEquipmentEntityReference>[] equipmentEntityAlternatives)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_EquipmentEntityAlternatives = equipmentEntityAlternatives.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintArmorType.m_EquipmentEntityAlternatives"/>
    /// </summary>
    ///
    /// <param name="equipmentEntityAlternatives">
    /// <para>
    /// Blueprint of type KingmakerEquipmentEntity. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToEquipmentEntityAlternatives(params Blueprint<KingmakerEquipmentEntity, KingmakerEquipmentEntityReference>[] equipmentEntityAlternatives)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_EquipmentEntityAlternatives = bp.m_EquipmentEntityAlternatives ?? new KingmakerEquipmentEntityReference[0];
          bp.m_EquipmentEntityAlternatives = CommonTool.Append(bp.m_EquipmentEntityAlternatives, equipmentEntityAlternatives.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintArmorType.m_EquipmentEntityAlternatives"/>
    /// </summary>
    ///
    /// <param name="equipmentEntityAlternatives">
    /// <para>
    /// Blueprint of type KingmakerEquipmentEntity. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromEquipmentEntityAlternatives(params Blueprint<KingmakerEquipmentEntity, KingmakerEquipmentEntityReference>[] equipmentEntityAlternatives)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_EquipmentEntityAlternatives is null) { return; }
          bp.m_EquipmentEntityAlternatives = bp.m_EquipmentEntityAlternatives.Where(val => !equipmentEntityAlternatives.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintArmorType.m_EquipmentEntityAlternatives"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="equipmentEntityAlternatives">
    /// <para>
    /// Blueprint of type KingmakerEquipmentEntity. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromEquipmentEntityAlternatives(Func<KingmakerEquipmentEntityReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_EquipmentEntityAlternatives is null) { return; }
          bp.m_EquipmentEntityAlternatives = bp.m_EquipmentEntityAlternatives.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintArmorType.m_EquipmentEntityAlternatives"/>
    /// </summary>
    ///
    /// <param name="equipmentEntityAlternatives">
    /// <para>
    /// Blueprint of type KingmakerEquipmentEntity. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearEquipmentEntityAlternatives()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_EquipmentEntityAlternatives = new KingmakerEquipmentEntityReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmorType.m_EquipmentEntityAlternatives"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="equipmentEntityAlternatives">
    /// <para>
    /// Blueprint of type KingmakerEquipmentEntity. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyEquipmentEntityAlternatives(Action<KingmakerEquipmentEntityReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_EquipmentEntityAlternatives is null) { return; }
          bp.m_EquipmentEntityAlternatives.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArmorType.m_Enchantments"/>
    /// </summary>
    ///
    /// <param name="enchantments">
    /// <para>
    /// Blueprint of type BlueprintArmorEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetEnchantments(params Blueprint<BlueprintArmorEnchantment, BlueprintArmorEnchantmentReference>[] enchantments)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Enchantments = enchantments.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintArmorType.m_Enchantments"/>
    /// </summary>
    ///
    /// <param name="enchantments">
    /// <para>
    /// Blueprint of type BlueprintArmorEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToEnchantments(params Blueprint<BlueprintArmorEnchantment, BlueprintArmorEnchantmentReference>[] enchantments)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Enchantments = bp.m_Enchantments ?? new BlueprintArmorEnchantmentReference[0];
          bp.m_Enchantments = CommonTool.Append(bp.m_Enchantments, enchantments.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintArmorType.m_Enchantments"/>
    /// </summary>
    ///
    /// <param name="enchantments">
    /// <para>
    /// Blueprint of type BlueprintArmorEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromEnchantments(params Blueprint<BlueprintArmorEnchantment, BlueprintArmorEnchantmentReference>[] enchantments)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Enchantments is null) { return; }
          bp.m_Enchantments = bp.m_Enchantments.Where(val => !enchantments.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintArmorType.m_Enchantments"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="enchantments">
    /// <para>
    /// Blueprint of type BlueprintArmorEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromEnchantments(Func<BlueprintArmorEnchantmentReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Enchantments is null) { return; }
          bp.m_Enchantments = bp.m_Enchantments.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintArmorType.m_Enchantments"/>
    /// </summary>
    ///
    /// <param name="enchantments">
    /// <para>
    /// Blueprint of type BlueprintArmorEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearEnchantments()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Enchantments = new BlueprintArmorEnchantmentReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmorType.m_Enchantments"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="enchantments">
    /// <para>
    /// Blueprint of type BlueprintArmorEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyEnchantments(Action<BlueprintArmorEnchantmentReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Enchantments is null) { return; }
          bp.m_Enchantments.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArmorType.m_ForcedRampColorPresetIndex"/>
    /// </summary>
    public TBuilder SetForcedRampColorPresetIndex(int forcedRampColorPresetIndex)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ForcedRampColorPresetIndex = forcedRampColorPresetIndex;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmorType.m_ForcedRampColorPresetIndex"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyForcedRampColorPresetIndex(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_ForcedRampColorPresetIndex);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArmorType.m_Destructible"/>
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
    /// Modifies <see cref="BlueprintArmorType.m_Destructible"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="destructible">
    /// <para>
    /// InfoBox: Default destructible property for type items. Can be overriden in BlueprintItem
    /// </para>
    /// </param>
    public TBuilder ModifyDestructible(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_Destructible);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArmorType.m_ShardItem"/>
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetShardItem(Blueprint<BlueprintItem, BlueprintItemReference> shardItem)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ShardItem = shardItem?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmorType.m_ShardItem"/> by invoking the provided action.
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyShardItem(Action<BlueprintItemReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ShardItem is null) { return; }
          action.Invoke(bp.m_ShardItem);
        });
    }
  }
}
