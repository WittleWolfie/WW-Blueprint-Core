//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Items.Components;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Controllers.Rest.Cooking;
using Kingmaker.Designers.Mechanics.EquipmentEnchants;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.DLC;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
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
    protected BaseItemConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintItem>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_DisplayNameText = copyFrom.m_DisplayNameText;
          bp.m_DescriptionText = copyFrom.m_DescriptionText;
          bp.m_FlavorText = copyFrom.m_FlavorText;
          bp.m_NonIdentifiedNameText = copyFrom.m_NonIdentifiedNameText;
          bp.m_NonIdentifiedDescriptionText = copyFrom.m_NonIdentifiedDescriptionText;
          bp.m_Icon = copyFrom.m_Icon;
          bp.m_Cost = copyFrom.m_Cost;
          bp.m_Weight = copyFrom.m_Weight;
          bp.m_IsNotable = copyFrom.m_IsNotable;
          bp.m_IsJunk = copyFrom.m_IsJunk;
          bp.m_ForceStackable = copyFrom.m_ForceStackable;
          bp.m_Destructible = copyFrom.m_Destructible;
          bp.m_ShardItem = copyFrom.m_ShardItem;
          bp.m_MiscellaneousType = copyFrom.m_MiscellaneousType;
          bp.m_InventoryPutSound = copyFrom.m_InventoryPutSound;
          bp.m_InventoryTakeSound = copyFrom.m_InventoryTakeSound;
          bp.NeedSkinningForCollect = copyFrom.NeedSkinningForCollect;
          bp.TrashLootTypes = copyFrom.TrashLootTypes;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintItem>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_DisplayNameText = copyFrom.m_DisplayNameText;
          bp.m_DescriptionText = copyFrom.m_DescriptionText;
          bp.m_FlavorText = copyFrom.m_FlavorText;
          bp.m_NonIdentifiedNameText = copyFrom.m_NonIdentifiedNameText;
          bp.m_NonIdentifiedDescriptionText = copyFrom.m_NonIdentifiedDescriptionText;
          bp.m_Icon = copyFrom.m_Icon;
          bp.m_Cost = copyFrom.m_Cost;
          bp.m_Weight = copyFrom.m_Weight;
          bp.m_IsNotable = copyFrom.m_IsNotable;
          bp.m_IsJunk = copyFrom.m_IsJunk;
          bp.m_ForceStackable = copyFrom.m_ForceStackable;
          bp.m_Destructible = copyFrom.m_Destructible;
          bp.m_ShardItem = copyFrom.m_ShardItem;
          bp.m_MiscellaneousType = copyFrom.m_MiscellaneousType;
          bp.m_InventoryPutSound = copyFrom.m_InventoryPutSound;
          bp.m_InventoryTakeSound = copyFrom.m_InventoryTakeSound;
          bp.NeedSkinningForCollect = copyFrom.NeedSkinningForCollect;
          bp.TrashLootTypes = copyFrom.TrashLootTypes;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItem.m_DisplayNameText"/>
    /// </summary>
    ///
    /// <param name="displayNameText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetDisplayNameText(LocalString displayNameText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DisplayNameText = displayNameText?.LocalizedString;
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
    ///
    /// <param name="flavorText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetFlavorText(LocalString flavorText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_FlavorText = flavorText?.LocalizedString;
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
    ///
    /// <param name="nonIdentifiedNameText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetNonIdentifiedNameText(LocalString nonIdentifiedNameText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_NonIdentifiedNameText = nonIdentifiedNameText?.LocalizedString;
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
    ///
    /// <param name="nonIdentifiedDescriptionText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetNonIdentifiedDescriptionText(LocalString nonIdentifiedDescriptionText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_NonIdentifiedDescriptionText = nonIdentifiedDescriptionText?.LocalizedString;
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
    /// Modifies <see cref="BlueprintItem.m_ShardItem"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintItem.TrashLootTypes"/>
    /// </summary>
    public TBuilder SetTrashLootTypes(params TrashLootType[] trashLootTypes)
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
          bp.TrashLootTypes = bp.TrashLootTypes.Where(e => !predicate(e)).ToArray();
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
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddItemShowInfoCallback(
        ActionsBuilder? action = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? once = null)
    {
      var component = new AddItemShowInfoCallback();
      component.Action = action?.Build() ?? component.Action;
      if (component.Action is null)
      {
        component.Action = Utils.Constants.Empty.Actions;
      }
      component.Once = once ?? component.Once;
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddBuildPointsReplacement(
        int? cost = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new BuildPointsReplacement();
      component.Cost = cost ?? component.Cost;
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddConsumableEventBonusReplacement(
        int? cost = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new ConsumableEventBonusReplacement();
      component.Cost = cost ?? component.Cost;
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>GlowingCroissant_item</term><description>adba05c4956e8844592f49acaaa4d4ea</description></item>
    /// <item><term>SpicyPastry_item</term><description>b0a3bb682cfe6054bac65d0f4d68d3d0</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="recipe">
    /// <para>
    /// Blueprint of type BlueprintCookingRecipe. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddCopyRecipe(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Blueprint<BlueprintCookingRecipeReference>? recipe = null)
    {
      var component = new CopyRecipe();
      component.m_Recipe = recipe?.Reference ?? component.m_Recipe;
      if (component.m_Recipe is null)
      {
        component.m_Recipe = BlueprintTool.GetRef<BlueprintCookingRecipeReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>ScrollOfInflictSeriousWoundsMass</term><description>2d9149f08a6ff4149a76b7a1bb560c6c</description></item>
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
    public TBuilder AddCopyScroll(
        Blueprint<BlueprintAbilityReference>? customSpell = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new CopyScroll();
      component.m_CustomSpell = customSpell?.Reference ?? component.m_CustomSpell;
      if (component.m_CustomSpell is null)
      {
        component.m_CustomSpell = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="CustomItemAbilityActionType"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BrokenPhylacterySoulRingItem</term><description>29c12c43b02e5ad41895388d47bf4efb</description></item>
    /// <item><term>ColorlessRemainsGoggles_MadnessItem</term><description>5b2fa590883042948dcebfa162025ead</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddCustomItemAbilityActionType(
        UnitCommand.CommandType? actionType = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new CustomItemAbilityActionType();
      component.m_ActionType = actionType ?? component.m_ActionType;
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="itemName">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddItemDialog(
        ConditionsBuilder? conditions = null,
        Blueprint<BlueprintDialogReference>? dialogReference = null,
        LocalString? itemName = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
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
      component.m_ItemName = itemName?.LocalizedString ?? component.m_ItemName;
      if (component.m_ItemName is null)
      {
        component.m_ItemName = Utils.Constants.Empty.String;
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>SwarmbaneClaspItem</term><description>a4dda39fab2d4e99884a71ecdc8f77ad</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="dlcReward">
    /// <para>
    /// Blueprint of type BlueprintDlcReward. You can pass in the blueprint using:
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
    public TBuilder AddItemDlcRestriction(
        Blueprint<BlueprintItemReference>? changeTo = null,
        Blueprint<BlueprintDlcRewardReference>? dlcReward = null,
        bool? hideInVendors = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
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
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="polymorphItems">
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
    public TBuilder AddItemPolymorph(
        Blueprint<BlueprintUnlockableFlagReference>? flagToCheck = null,
        List<Blueprint<BlueprintItemReference>>? polymorphItems = null)
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
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MoneyReplacement"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_GnomeCashItem</term><description>97ea0b53288d46b0aed65f0e3ac3037e</description></item>
    /// <item><term>DLC3_StartingCash</term><description>620107fe863540b7907df92b1bc8d1c8</description></item>
    /// <item><term>GoldCoins</term><description>f2bc0997c24e573448c6c91d2be88afa</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddMoneyReplacement(
        long? cost = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new MoneyReplacement();
      component.Cost = cost ?? component.Cost;
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddIgnoreResistanceForDamageFromEnchantment(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        IgnoreResistanceForDamageFromEnchantment.IgnoreType? type = null)
    {
      var component = new IgnoreResistanceForDamageFromEnchantment();
      component.m_Type = type ?? component.m_Type;
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>DLC2ShortspearEnchantment</term><description>07de6c83aa2c423f897b6904ba270216</description></item>
    /// <item><term>TouchEnchant2</term><description>2431f5f8d2ffe854784429b989d1e8a3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="type">
    /// <para>
    /// Blueprint of type BlueprintWeaponType. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddWeaponTypeAttackEnchant(
        int? bonus = null,
        ModifierDescriptor? descriptor = null,
        Blueprint<BlueprintWeaponTypeReference>? type = null)
    {
      var component = new WeaponTypeAttackEnchant();
      component.Bonus = bonus ?? component.Bonus;
      component.Descriptor = descriptor ?? component.Descriptor;
      component.m_Type = type?.Reference ?? component.m_Type;
      if (component.m_Type is null)
      {
        component.m_Type = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(null);
      }
      return AddComponent(component);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_DisplayNameText is null)
      {
        Blueprint.m_DisplayNameText = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_DescriptionText is null)
      {
        Blueprint.m_DescriptionText = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_FlavorText is null)
      {
        Blueprint.m_FlavorText = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_NonIdentifiedNameText is null)
      {
        Blueprint.m_NonIdentifiedNameText = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_NonIdentifiedDescriptionText is null)
      {
        Blueprint.m_NonIdentifiedDescriptionText = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_ShardItem is null)
      {
        Blueprint.m_ShardItem = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      if (Blueprint.TrashLootTypes is null)
      {
        Blueprint.TrashLootTypes = new TrashLootType[0];
      }
    }
  }
}
