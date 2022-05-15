//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.Items.Equipment;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Enums;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Items.Armors
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemArmor"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseItemArmorConfigurator<T, TBuilder>
    : BaseItemEquipmentConfigurator<T, TBuilder>
    where T : BlueprintItemArmor
    where TBuilder : BaseItemArmorConfigurator<T, TBuilder>
  {
    protected BaseItemArmorConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemArmor.m_Type"/>
    /// </summary>
    ///
    /// <param name="type">
    /// <para>
    /// Blueprint of type BlueprintArmorType. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetType(Blueprint<BlueprintArmorType, BlueprintArmorTypeReference> type)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Type = type?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItemArmor.m_Type"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="type">
    /// <para>
    /// Blueprint of type BlueprintArmorType. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyType(Action<BlueprintArmorTypeReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Type is null) { return; }
          action.Invoke(bp.m_Type);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemArmor.m_Size"/>
    /// </summary>
    public TBuilder SetSize(Size size)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Size = size;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItemArmor.m_Size"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySize(Action<Size> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_Size);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemArmor.m_VisualParameters"/>
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
    /// Modifies <see cref="BlueprintItemArmor.m_VisualParameters"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintItemArmor.m_Enchantments"/>
    /// </summary>
    ///
    /// <param name="enchantments">
    /// <para>
    /// Blueprint of type BlueprintEquipmentEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetEnchantments(List<Blueprint<BlueprintEquipmentEnchantment, BlueprintEquipmentEnchantmentReference>> enchantments)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Enchantments = enchantments?.Select(bp => bp.Reference)?.ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintItemArmor.m_Enchantments"/>
    /// </summary>
    ///
    /// <param name="enchantments">
    /// <para>
    /// Blueprint of type BlueprintEquipmentEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToEnchantments(params Blueprint<BlueprintEquipmentEnchantment, BlueprintEquipmentEnchantmentReference>[] enchantments)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Enchantments = bp.m_Enchantments ?? new BlueprintEquipmentEnchantmentReference[0];
          bp.m_Enchantments = CommonTool.Append(bp.m_Enchantments, enchantments.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintItemArmor.m_Enchantments"/>
    /// </summary>
    ///
    /// <param name="enchantments">
    /// <para>
    /// Blueprint of type BlueprintEquipmentEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromEnchantments(params Blueprint<BlueprintEquipmentEnchantment, BlueprintEquipmentEnchantmentReference>[] enchantments)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Enchantments is null) { return; }
          bp.m_Enchantments = bp.m_Enchantments.Where(val => !enchantments.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintItemArmor.m_Enchantments"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="enchantments">
    /// <para>
    /// Blueprint of type BlueprintEquipmentEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromEnchantments(Func<BlueprintEquipmentEnchantmentReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Enchantments is null) { return; }
          bp.m_Enchantments = bp.m_Enchantments.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintItemArmor.m_Enchantments"/>
    /// </summary>
    ///
    /// <param name="enchantments">
    /// <para>
    /// Blueprint of type BlueprintEquipmentEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearEnchantments()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Enchantments = new BlueprintEquipmentEnchantmentReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItemArmor.m_Enchantments"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="enchantments">
    /// <para>
    /// Blueprint of type BlueprintEquipmentEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyEnchantments(Action<BlueprintEquipmentEnchantmentReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Enchantments is null) { return; }
          bp.m_Enchantments.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemArmor.m_OverrideShardItem"/>
    /// </summary>
    ///
    /// <param name="overrideShardItem">
    /// <para>
    /// InfoBox: If true, ignores shard item from armor type and uses shard from this blueprint.
    /// </para>
    /// </param>
    public TBuilder SetOverrideShardItem(bool overrideShardItem = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_OverrideShardItem = overrideShardItem;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItemArmor.m_OverrideShardItem"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="overrideShardItem">
    /// <para>
    /// InfoBox: If true, ignores shard item from armor type and uses shard from this blueprint.
    /// </para>
    /// </param>
    public TBuilder ModifyOverrideShardItem(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_OverrideShardItem);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemArmor.m_OverrideDestructible"/>
    /// </summary>
    ///
    /// <param name="overrideDestructible">
    /// <para>
    /// InfoBox: If true, ignores destructible property value from armor type and uses it from blueprint item.
    /// </para>
    /// </param>
    public TBuilder SetOverrideDestructible(bool overrideDestructible = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_OverrideDestructible = overrideDestructible;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItemArmor.m_OverrideDestructible"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="overrideDestructible">
    /// <para>
    /// InfoBox: If true, ignores destructible property value from armor type and uses it from blueprint item.
    /// </para>
    /// </param>
    public TBuilder ModifyOverrideDestructible(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_OverrideDestructible);
        });
    }
  }
}
