//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.ResourceLinks;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemEquipmentUsable"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseItemEquipmentUsableConfigurator<T, TBuilder>
    : BaseItemEquipmentConfigurator<T, TBuilder>
    where T : BlueprintItemEquipmentUsable
    where TBuilder : BaseItemEquipmentUsableConfigurator<T, TBuilder>
  {
    protected BaseItemEquipmentUsableConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemEquipmentUsable.Type"/>
    /// </summary>
    public TBuilder SetType(UsableItemType type)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Type = type;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemEquipmentUsable.m_IdentifyDC"/>
    /// </summary>
    public TBuilder SetIdentifyDC(int identifyDC)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IdentifyDC = identifyDC;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemEquipmentUsable.m_InventoryEquipSound"/>
    /// </summary>
    public TBuilder SetInventoryEquipSound(string inventoryEquipSound)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_InventoryEquipSound = inventoryEquipSound;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItemEquipmentUsable.m_InventoryEquipSound"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyInventoryEquipSound(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_InventoryEquipSound is null) { return; }
          action.Invoke(bp.m_InventoryEquipSound);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemEquipmentUsable.m_BeltItemPrefab"/>
    /// </summary>
    public TBuilder SetBeltItemPrefab(AssetLink<PrefabLink> beltItemPrefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BeltItemPrefab = beltItemPrefab?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItemEquipmentUsable.m_BeltItemPrefab"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBeltItemPrefab(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BeltItemPrefab is null) { return; }
          action.Invoke(bp.m_BeltItemPrefab);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemEquipmentUsable.m_Enchantments"/>
    /// </summary>
    ///
    /// <param name="enchantments">
    /// <para>
    /// Blueprint of type BlueprintEquipmentEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetEnchantments(params Blueprint<BlueprintEquipmentEnchantmentReference>[] enchantments)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Enchantments = enchantments.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintItemEquipmentUsable.m_Enchantments"/>
    /// </summary>
    ///
    /// <param name="enchantments">
    /// <para>
    /// Blueprint of type BlueprintEquipmentEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToEnchantments(params Blueprint<BlueprintEquipmentEnchantmentReference>[] enchantments)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Enchantments = bp.m_Enchantments ?? new BlueprintEquipmentEnchantmentReference[0];
          bp.m_Enchantments = CommonTool.Append(bp.m_Enchantments, enchantments.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintItemEquipmentUsable.m_Enchantments"/>
    /// </summary>
    ///
    /// <param name="enchantments">
    /// <para>
    /// Blueprint of type BlueprintEquipmentEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromEnchantments(params Blueprint<BlueprintEquipmentEnchantmentReference>[] enchantments)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Enchantments is null) { return; }
          bp.m_Enchantments = bp.m_Enchantments.Where(val => !enchantments.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintItemEquipmentUsable.m_Enchantments"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromEnchantments(Func<BlueprintEquipmentEnchantmentReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Enchantments is null) { return; }
          bp.m_Enchantments = bp.m_Enchantments.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintItemEquipmentUsable.m_Enchantments"/>
    /// </summary>
    public TBuilder ClearEnchantments()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Enchantments = new BlueprintEquipmentEnchantmentReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItemEquipmentUsable.m_Enchantments"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyEnchantments(Action<BlueprintEquipmentEnchantmentReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Enchantments is null) { return; }
          bp.m_Enchantments.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_BeltItemPrefab is null)
      {
        Blueprint.m_BeltItemPrefab = Utils.Constants.Empty.PrefabLink;
      }
      if (Blueprint.m_Enchantments is null)
      {
        Blueprint.m_Enchantments = new BlueprintEquipmentEnchantmentReference[0];
      }
    }
  }
}
