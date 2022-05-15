//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Items.Components;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Controllers.Rest.Cooking;
using Kingmaker.Designers.Mechanics.EquipmentEnchants;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.DLC;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Items
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItem"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseItemConfigurator<T, TBuilder>
    : BaseFactConfigurator<T, TBuilder>
    where T : BlueprintItem
    where TBuilder : BaseItemConfigurator<T, TBuilder>
  {
    protected BaseItemConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItem.m_DisplayNameText"/>
    /// </summary>
    public TBuilder SetDisplayNameText(LocalizedString displayNameText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DisplayNameText = displayNameText;
          if (bp.m_DisplayNameText is null)
          {
            bp.m_DisplayNameText = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItem.m_DisplayNameText"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDisplayNameText(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DisplayNameText is null) { return; }
          action.Invoke(bp.m_DisplayNameText);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItem.m_DescriptionText"/>
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
    /// Modifies <see cref="BlueprintItem.m_DescriptionText"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintItem.m_FlavorText"/>
    /// </summary>
    public TBuilder SetFlavorText(LocalizedString flavorText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_FlavorText = flavorText;
          if (bp.m_FlavorText is null)
          {
            bp.m_FlavorText = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItem.m_FlavorText"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFlavorText(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_FlavorText is null) { return; }
          action.Invoke(bp.m_FlavorText);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItem.m_NonIdentifiedNameText"/>
    /// </summary>
    public TBuilder SetNonIdentifiedNameText(LocalizedString nonIdentifiedNameText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_NonIdentifiedNameText = nonIdentifiedNameText;
          if (bp.m_NonIdentifiedNameText is null)
          {
            bp.m_NonIdentifiedNameText = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItem.m_NonIdentifiedNameText"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNonIdentifiedNameText(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_NonIdentifiedNameText is null) { return; }
          action.Invoke(bp.m_NonIdentifiedNameText);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItem.m_NonIdentifiedDescriptionText"/>
    /// </summary>
    public TBuilder SetNonIdentifiedDescriptionText(LocalizedString nonIdentifiedDescriptionText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_NonIdentifiedDescriptionText = nonIdentifiedDescriptionText;
          if (bp.m_NonIdentifiedDescriptionText is null)
          {
            bp.m_NonIdentifiedDescriptionText = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItem.m_NonIdentifiedDescriptionText"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNonIdentifiedDescriptionText(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_NonIdentifiedDescriptionText is null) { return; }
          action.Invoke(bp.m_NonIdentifiedDescriptionText);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItem.m_Icon"/>
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
    /// Modifies <see cref="BlueprintItem.m_Icon"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintItem.m_Cost"/>
    /// </summary>
    public TBuilder SetCost(int cost)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Cost = cost;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItem.m_Cost"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCost(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_Cost);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItem.m_Weight"/>
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
    /// Modifies <see cref="BlueprintItem.m_Weight"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintItem.m_IsNotable"/>
    /// </summary>
    public TBuilder SetIsNotable(bool isNotable = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IsNotable = isNotable;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItem.m_IsNotable"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIsNotable(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_IsNotable);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItem.m_IsJunk"/>
    /// </summary>
    ///
    /// <param name="isJunk">
    /// <para>
    /// Tooltip: Include in the Mass Sell option at vendors
    /// </para>
    /// </param>
    public TBuilder SetIsJunk(bool isJunk = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IsJunk = isJunk;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItem.m_IsJunk"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="isJunk">
    /// <para>
    /// Tooltip: Include in the Mass Sell option at vendors
    /// </para>
    /// </param>
    public TBuilder ModifyIsJunk(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_IsJunk);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItem.m_ForceStackable"/>
    /// </summary>
    public TBuilder SetForceStackable(bool forceStackable = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ForceStackable = forceStackable;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItem.m_ForceStackable"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyForceStackable(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_ForceStackable);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItem.m_Destructible"/>
    /// </summary>
    public TBuilder SetDestructible(bool destructible = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Destructible = destructible;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItem.m_Destructible"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDestructible(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_Destructible);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItem.m_ShardItem"/>
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
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
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
    /// Modifies <see cref="BlueprintItem.m_ShardItem"/> by invoking the provided action.
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
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
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

    /// <summary>
    /// Sets the value of <see cref="BlueprintItem.m_MiscellaneousType"/>
    /// </summary>
    public TBuilder SetMiscellaneousType(BlueprintItem.MiscellaneousItemType miscellaneousType)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MiscellaneousType = miscellaneousType;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItem.m_MiscellaneousType"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMiscellaneousType(Action<BlueprintItem.MiscellaneousItemType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_MiscellaneousType);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItem.m_InventoryPutSound"/>
    /// </summary>
    public TBuilder SetInventoryPutSound(string inventoryPutSound)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_InventoryPutSound = inventoryPutSound;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItem.m_InventoryPutSound"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyInventoryPutSound(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_InventoryPutSound is null) { return; }
          action.Invoke(bp.m_InventoryPutSound);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItem.m_InventoryTakeSound"/>
    /// </summary>
    public TBuilder SetInventoryTakeSound(string inventoryTakeSound)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_InventoryTakeSound = inventoryTakeSound;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItem.m_InventoryTakeSound"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyInventoryTakeSound(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_InventoryTakeSound is null) { return; }
          action.Invoke(bp.m_InventoryTakeSound);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItem.NeedSkinningForCollect"/>
    /// </summary>
    public TBuilder SetNeedSkinningForCollect(bool needSkinningForCollect = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NeedSkinningForCollect = needSkinningForCollect;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItem.NeedSkinningForCollect"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNeedSkinningForCollect(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.NeedSkinningForCollect);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItem.TrashLootTypes"/>
    /// </summary>
    public TBuilder SetTrashLootTypes(TrashLootType[] trashLootTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.TrashLootTypes = trashLootTypes;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintItem.TrashLootTypes"/>
    /// </summary>
    public TBuilder AddToTrashLootTypes(params TrashLootType[] trashLootTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.TrashLootTypes = bp.TrashLootTypes ?? new TrashLootType[0];
          bp.TrashLootTypes = CommonTool.Append(bp.TrashLootTypes, trashLootTypes);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintItem.TrashLootTypes"/>
    /// </summary>
    public TBuilder RemoveFromTrashLootTypes(params TrashLootType[] trashLootTypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.TrashLootTypes is null) { return; }
          bp.TrashLootTypes = bp.TrashLootTypes.Where(val => !trashLootTypes.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintItem.TrashLootTypes"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromTrashLootTypes(Func<TrashLootType, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.TrashLootTypes is null) { return; }
          bp.TrashLootTypes = bp.TrashLootTypes.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintItem.TrashLootTypes"/>
    /// </summary>
    public TBuilder ClearTrashLootTypes()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.TrashLootTypes = new TrashLootType[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItem.TrashLootTypes"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyTrashLootTypes(Action<TrashLootType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.TrashLootTypes is null) { return; }
          bp.TrashLootTypes.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItem.m_CachedEnchantments"/>
    /// </summary>
    public TBuilder SetCachedEnchantments(List<BlueprintItemEnchantment> cachedEnchantments)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in cachedEnchantments) { Validate(item); }
          bp.m_CachedEnchantments = cachedEnchantments;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintItem.m_CachedEnchantments"/>
    /// </summary>
    public TBuilder AddToCachedEnchantments(params BlueprintItemEnchantment[] cachedEnchantments)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CachedEnchantments = bp.m_CachedEnchantments ?? new();
          bp.m_CachedEnchantments.AddRange(cachedEnchantments);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintItem.m_CachedEnchantments"/>
    /// </summary>
    public TBuilder RemoveFromCachedEnchantments(params BlueprintItemEnchantment[] cachedEnchantments)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CachedEnchantments is null) { return; }
          bp.m_CachedEnchantments = bp.m_CachedEnchantments.Where(val => !cachedEnchantments.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintItem.m_CachedEnchantments"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCachedEnchantments(Func<BlueprintItemEnchantment, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CachedEnchantments is null) { return; }
          bp.m_CachedEnchantments = bp.m_CachedEnchantments.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintItem.m_CachedEnchantments"/>
    /// </summary>
    public TBuilder ClearCachedEnchantments()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CachedEnchantments = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItem.m_CachedEnchantments"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCachedEnchantments(Action<BlueprintItemEnchantment> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CachedEnchantments is null) { return; }
          bp.m_CachedEnchantments.ForEach(action);
        });
    }

    /// <summary>
    /// Adds <see cref="AddItemShowInfoCallback"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AboutIzyagna</term><description>fa1f67444ec844508ea2eb6549581d5d</description></item>
    /// <item><term>KenabresWardstone</term><description>6e09b855929d419893eb2fbaeec80e51</description></item>
    /// <item><term>ZoeyPendantTeleport</term><description>9a90929e2db1be448b495509170a4251</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddItemShowInfoCallback(
        ActionsBuilder? action = null,
        bool? once = null)
    {
      var component = new AddItemShowInfoCallback();
      component.Action = action?.Build() ?? component.Action;
      if (component.Action is null)
      {
        component.Action = Utils.Constants.Empty.Actions;
      }
      component.Once = once ?? component.Once;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuildPointsReplacement"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BPCoins</term><description>995a5ff780c5fc541a0969e309c4de36</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddBuildPointsReplacement(
        int? cost = null)
    {
      var component = new BuildPointsReplacement();
      component.Cost = cost ?? component.Cost;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ConsumableEventBonusReplacement"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ConsumableEventBonusItem</term><description>1ab90b3b5d7cd1045b86ae5b9410af70</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddConsumableEventBonusReplacement(
        int? cost = null)
    {
      var component = new ConsumableEventBonusReplacement();
      component.Cost = cost ?? component.Cost;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CopyRecipe"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcornPie_item</term><description>83864a3611c89f047b4242f139872fff</description></item>
    /// <item><term>GodspeedSalad_item</term><description>95de2a5a9e9f6f94381ace2b1c7d74ba</description></item>
    /// <item><term>SpicyPastry_item</term><description>b0a3bb682cfe6054bac65d0f4d68d3d0</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="recipe">
    /// <para>
    /// Blueprint of type BlueprintCookingRecipe. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddCopyRecipe(
        Blueprint<BlueprintCookingRecipe, BlueprintCookingRecipeReference>? recipe = null)
    {
      var component = new CopyRecipe();
      component.m_Recipe = recipe?.Reference ?? component.m_Recipe;
      if (component.m_Recipe is null)
      {
        component.m_Recipe = BlueprintTool.GetRef<BlueprintCookingRecipeReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CopyScroll"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ScrollHealMass</term><description>e19e85bfe282a1145a6075567a71970f</description></item>
    /// <item><term>ScrollOfInflictSeriousWounds</term><description>47d41dd302a14d04faa7df70697d23ec</description></item>
    /// <item><term>ScrollOfWrackingRay</term><description>e3af1f25d3d4fcf439f508377c7493cd</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="customSpell">
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddCopyScroll(
        Blueprint<BlueprintAbility, BlueprintAbilityReference>? customSpell = null)
    {
      var component = new CopyScroll();
      component.m_CustomSpell = customSpell?.Reference ?? component.m_CustomSpell;
      if (component.m_CustomSpell is null)
      {
        component.m_CustomSpell = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ItemDialog"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FinneanBaseItem</term><description>95c126deb99ba054aa5b84710520c035</description></item>
    /// <item><term>LexiconHalf2</term><description>b2e062dac1c7a7d45a21280601f2075f</description></item>
    /// <item><term>ZachariusFallenWandItem</term><description>622bb73ea55945b6a3d082e73166cc5c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="dialogReference">
    /// <para>
    /// Blueprint of type BlueprintDialog. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddItemDialog(
        ConditionsBuilder? conditions = null,
        Blueprint<BlueprintDialog, BlueprintDialogReference>? dialogReference = null,
        LocalizedString? itemName = null)
    {
      var component = new ItemDialog();
      component.m_Conditions = conditions?.Build() ?? component.m_Conditions;
      if (component.m_Conditions is null)
      {
        component.m_Conditions = Utils.Constants.Empty.Conditions;
      }
      component.m_DialogReference = dialogReference?.Reference ?? component.m_DialogReference;
      if (component.m_DialogReference is null)
      {
        component.m_DialogReference = BlueprintTool.GetRef<BlueprintDialogReference>(null);
      }
      component.m_ItemName = itemName ?? component.m_ItemName;
      if (component.m_ItemName is null)
      {
        component.m_ItemName = Utils.Constants.Empty.String;
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ItemDlcRestriction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DashingCavaliersGlovesItem</term><description>176da707c9c9d764e972a9da8b444ff3</description></item>
    /// <item><term>Owlcat_Item</term><description>6ea6d3b50bfa24e46a710beafbd95cd0</description></item>
    /// <item><term>SilverTongueAmuletItem</term><description>4d4231b4a395bba4b9819dfbb2dc785d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="changeTo">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="dlcReward">
    /// <para>
    /// Blueprint of type BlueprintDlcReward. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddItemDlcRestriction(
        Blueprint<BlueprintItem, BlueprintItemReference>? changeTo = null,
        Blueprint<BlueprintDlcReward, BlueprintDlcRewardReference>? dlcReward = null,
        bool? hideInVendors = null)
    {
      var component = new ItemDlcRestriction();
      component.m_ChangeTo = changeTo?.Reference ?? component.m_ChangeTo;
      if (component.m_ChangeTo is null)
      {
        component.m_ChangeTo = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      component.m_DlcReward = dlcReward?.Reference ?? component.m_DlcReward;
      if (component.m_DlcReward is null)
      {
        component.m_DlcReward = BlueprintTool.GetRef<BlueprintDlcRewardReference>(null);
      }
      component.HideInVendors = hideInVendors ?? component.HideInVendors;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ItemPolymorph"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FinneanBaseItem</term><description>95c126deb99ba054aa5b84710520c035</description></item>
    /// <item><term>TestFinneanItem</term><description>508d135c08de4661ba32b27e424e6a4c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="flagToCheck">
    /// <para>
    /// Blueprint of type BlueprintUnlockableFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="polymorphItems">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddItemPolymorph(
        Blueprint<BlueprintUnlockableFlag, BlueprintUnlockableFlagReference>? flagToCheck = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        List<Blueprint<BlueprintItem, BlueprintItemReference>>? polymorphItems = null)
    {
      var component = new ItemPolymorph();
      component.m_FlagToCheck = flagToCheck?.Reference ?? component.m_FlagToCheck;
      if (component.m_FlagToCheck is null)
      {
        component.m_FlagToCheck = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(null);
      }
      component.m_PolymorphItems = polymorphItems?.Select(bp => bp.Reference)?.ToList() ?? component.m_PolymorphItems;
      if (component.m_PolymorphItems is null)
      {
        component.m_PolymorphItems = new();
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="MoneyReplacement"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>GoldCoins</term><description>f2bc0997c24e573448c6c91d2be88afa</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddMoneyReplacement(
        long? cost = null)
    {
      var component = new MoneyReplacement();
      component.Cost = cost ?? component.Cost;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreResistanceForDamageFromEnchantment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ElderBrass</term><description>0a8f3559cfcc4d38961bd9658d026cc8</description></item>
    /// <item><term>ElderFrost</term><description>c9c2580b9b6c43e992acae157615deb5</description></item>
    /// <item><term>ElderShockingBurst</term><description>a30a16ee048e4d1fb186c5cf4a0984b0</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddIgnoreResistanceForDamageFromEnchantment(
        IgnoreResistanceForDamageFromEnchantment.IgnoreType? type = null)
    {
      var component = new IgnoreResistanceForDamageFromEnchantment();
      component.m_Type = type ?? component.m_Type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTypeAttackEnchant"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Weapon Type Attack Enchant
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BombAttack2</term><description>22cef8e691a75674d8bc33ea986ea4fa</description></item>
    /// <item><term>DLCBardicheRustyEnchantment</term><description>d579b18e60ea4d868a4c43f23aba35b8</description></item>
    /// <item><term>TouchEnchant2</term><description>2431f5f8d2ffe854784429b989d1e8a3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="type">
    /// <para>
    /// Blueprint of type BlueprintWeaponType. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddWeaponTypeAttackEnchant(
        int? bonus = null,
        ModifierDescriptor? descriptor = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        Blueprint<BlueprintWeaponType, BlueprintWeaponTypeReference>? type = null)
    {
      var component = new WeaponTypeAttackEnchant();
      component.Bonus = bonus ?? component.Bonus;
      component.Descriptor = descriptor ?? component.Descriptor;
      component.m_Type = type?.Reference ?? component.m_Type;
      if (component.m_Type is null)
      {
        component.m_Type = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }
  }
}
