//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Localization;
using Kingmaker.Utility;
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
    protected BaseArmorTypeConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintArmorType>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_TypeNameText = copyFrom.m_TypeNameText;
          bp.m_DefaultNameText = copyFrom.m_DefaultNameText;
          bp.m_DescriptionText = copyFrom.m_DescriptionText;
          bp.m_MagicDescriptionText = copyFrom.m_MagicDescriptionText;
          bp.m_Icon = copyFrom.m_Icon;
          bp.m_VisualParameters = copyFrom.m_VisualParameters;
          bp.m_ArmorBonus = copyFrom.m_ArmorBonus;
          bp.m_ArmorChecksPenalty = copyFrom.m_ArmorChecksPenalty;
          bp.m_HasDexterityBonusLimit = copyFrom.m_HasDexterityBonusLimit;
          bp.m_MaxDexterityBonus = copyFrom.m_MaxDexterityBonus;
          bp.m_ProficiencyGroup = copyFrom.m_ProficiencyGroup;
          bp.m_ArcaneSpellFailureChance = copyFrom.m_ArcaneSpellFailureChance;
          bp.m_Weight = copyFrom.m_Weight;
          bp.m_IsArmor = copyFrom.m_IsArmor;
          bp.m_IsShield = copyFrom.m_IsShield;
          bp.m_EquipmentEntity = copyFrom.m_EquipmentEntity;
          bp.m_EquipmentEntityAlternatives = copyFrom.m_EquipmentEntityAlternatives;
          bp.m_Enchantments = copyFrom.m_Enchantments;
          bp.m_ForcedRampColorPresetIndex = copyFrom.m_ForcedRampColorPresetIndex;
          bp.m_Destructible = copyFrom.m_Destructible;
          bp.m_ShardItem = copyFrom.m_ShardItem;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArmorType.m_TypeNameText"/>
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
    ///
    /// <param name="icon">
    /// You can pass in the animation using a Sprite or it's AssetId.
    /// </param>
    public TBuilder SetIcon(Asset<Sprite> icon)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Icon = icon?.Get();
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
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetEquipmentEntity(Blueprint<KingmakerEquipmentEntityReference> equipmentEntity)
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
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetEquipmentEntityAlternatives(params Blueprint<KingmakerEquipmentEntityReference>[] equipmentEntityAlternatives)
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
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToEquipmentEntityAlternatives(params Blueprint<KingmakerEquipmentEntityReference>[] equipmentEntityAlternatives)
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
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromEquipmentEntityAlternatives(params Blueprint<KingmakerEquipmentEntityReference>[] equipmentEntityAlternatives)
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
    public TBuilder RemoveFromEquipmentEntityAlternatives(Func<KingmakerEquipmentEntityReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_EquipmentEntityAlternatives is null) { return; }
          bp.m_EquipmentEntityAlternatives = bp.m_EquipmentEntityAlternatives.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintArmorType.m_EquipmentEntityAlternatives"/>
    /// </summary>
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
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetEnchantments(params Blueprint<BlueprintArmorEnchantmentReference>[] enchantments)
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
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToEnchantments(params Blueprint<BlueprintArmorEnchantmentReference>[] enchantments)
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
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromEnchantments(params Blueprint<BlueprintArmorEnchantmentReference>[] enchantments)
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
    public TBuilder RemoveFromEnchantments(Func<BlueprintArmorEnchantmentReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Enchantments is null) { return; }
          bp.m_Enchantments = bp.m_Enchantments.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintArmorType.m_Enchantments"/>
    /// </summary>
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
    /// Modifies <see cref="BlueprintArmorType.m_ShardItem"/> by invoking the provided action.
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
      if (Blueprint.m_MagicDescriptionText is null)
      {
        Blueprint.m_MagicDescriptionText = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_EquipmentEntity is null)
      {
        Blueprint.m_EquipmentEntity = BlueprintTool.GetRef<KingmakerEquipmentEntityReference>(null);
      }
      if (Blueprint.m_EquipmentEntityAlternatives is null)
      {
        Blueprint.m_EquipmentEntityAlternatives = new KingmakerEquipmentEntityReference[0];
      }
      if (Blueprint.m_Enchantments is null)
      {
        Blueprint.m_Enchantments = new BlueprintArmorEnchantmentReference[0];
      }
      if (Blueprint.m_ShardItem is null)
      {
        Blueprint.m_ShardItem = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
    }
  }
}
