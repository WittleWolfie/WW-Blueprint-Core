//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker;
using Kingmaker.Achievements.Actions;
using Kingmaker.Achievements.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.DLC;
using Kingmaker.ElementsSystem;
using Kingmaker.Tutorial;
using Kingmaker.Tutorial.Actions;
using Kingmaker.UnitLogic.FactLogic;
using System.Collections.Generic;
using System.Linq;
namespace BlueprintCore.Actions.Builder.MiscEx
{
  /// <summary>
  /// Extension to <see cref="ActionsBuilder"/> for actions without a better extension container such as achievements vendor actions, and CustomEvent.
  /// </summary>
  /// <inheritdoc cref="ActionsBuilder"/>
  public static class ActionsBuilderMiscEx
{

    /// <summary>
    /// Adds <see cref="ActionAchievementIncrementCounter"/>
    /// </summary>
    ///
    /// <param name="achievement">
    /// Blueprint of type AchievementData. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ActionAchievementIncrementCounter(
        this ActionsBuilder builder,
        Blueprint<AchievementData, AchievementDataReference>? achievement = null)
    {
      var element = ElementTool.Create<ActionAchievementIncrementCounter>();
      element.m_Achievement = achievement.Reference ?? element.m_Achievement;
      if (element.m_Achievement is null)
      {
        element.m_Achievement = BlueprintTool.GetRef<AchievementDataReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ActionAchievementUnlock"/>
    /// </summary>
    ///
    /// <param name="achievement">
    /// Blueprint of type AchievementData. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ActionAchievementUnlock(
        this ActionsBuilder builder,
        Blueprint<AchievementData, AchievementDataReference>? achievement = null)
    {
      var element = ElementTool.Create<ActionAchievementUnlock>();
      element.m_Achievement = achievement.Reference ?? element.m_Achievement;
      if (element.m_Achievement is null)
      {
        element.m_Achievement = BlueprintTool.GetRef<AchievementDataReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CreateCustomCompanion"/>
    /// </summary>
    public static ActionsBuilder CreateCustomCompanion(
        this ActionsBuilder builder,
        bool? forFree = null,
        LocatorEvaluator? locator = null,
        bool? matchPlayerXpExactly = null,
        bool? noEquipment = null,
        ActionsBuilder? onCreate = null)
    {
      var element = ElementTool.Create<CreateCustomCompanion>();
      element.ForFree = forFree ?? element.ForFree;
      builder.Validate(locator);
      element.Locator = locator ?? element.Locator;
      element.MatchPlayerXpExactly = matchPlayerXpExactly ?? element.MatchPlayerXpExactly;
      element.NoEquipment = noEquipment ?? element.NoEquipment;
      element.OnCreate = onCreate.Build() ?? element.OnCreate;
      if (element.OnCreate is null)
      {
        element.OnCreate = Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CustomEvent"/>
    /// </summary>
    public static ActionsBuilder CustomEvent(
        this ActionsBuilder builder,
        string? eventId = null)
    {
      var element = ElementTool.Create<CustomEvent>();
      element.EventId = eventId ?? element.EventId;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddPremiumReward"/>
    /// </summary>
    ///
    /// <param name="dlcReward">
    /// Blueprint of type BlueprintDlcReward. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="items">
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="playerFeatures">
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder AddPremiumReward(
        this ActionsBuilder builder,
        ActionsBuilder? additionalActions = null,
        Blueprint<BlueprintDlcReward, BlueprintDlcRewardReference>? dlcReward = null,
        List<Blueprint<BlueprintItem, BlueprintItemReference>>? items = null,
        List<Blueprint<BlueprintFeature, BlueprintFeatureReference>>? playerFeatures = null)
    {
      var element = ElementTool.Create<AddPremiumReward>();
      element.AdditionalActions = additionalActions.Build() ?? element.AdditionalActions;
      if (element.AdditionalActions is null)
      {
        element.AdditionalActions = Constants.Empty.Actions;
      }
      element.m_DlcReward = dlcReward.Reference ?? element.m_DlcReward;
      if (element.m_DlcReward is null)
      {
        element.m_DlcReward = BlueprintTool.GetRef<BlueprintDlcRewardReference>(null);
      }
      element.Items = items.Select(bp => bp.Reference).ToList() ?? element.Items;
      if (element.Items is null)
      {
        element.Items = new();
      }
      element.PlayerFeatures = playerFeatures.Select(bp => bp.Reference).ToList() ?? element.PlayerFeatures;
      if (element.PlayerFeatures is null)
      {
        element.PlayerFeatures = new();
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DebugLog"/>
    /// </summary>
    public static ActionsBuilder DebugLog(
        this ActionsBuilder builder,
        bool? breakValue = null,
        string? log = null)
    {
      var element = ElementTool.Create<DebugLog>();
      element.Break = breakValue ?? element.Break;
      element.Log = log ?? element.Log;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="GameOver"/>
    /// </summary>
    public static ActionsBuilder GameOver(
        this ActionsBuilder builder,
        Player.GameOverReasonType? reason = null)
    {
      var element = ElementTool.Create<GameOver>();
      element.Reason = reason ?? element.Reason;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MakeAutoSave"/>
    /// </summary>
    public static ActionsBuilder MakeAutoSave(
        this ActionsBuilder builder,
        bool? saveForImport = null)
    {
      var element = ElementTool.Create<MakeAutoSave>();
      element.SaveForImport = saveForImport ?? element.SaveForImport;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MakeItemNonRemovable"/>
    /// </summary>
    ///
    /// <param name="item">
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder MakeItemNonRemovable(
        this ActionsBuilder builder,
        Blueprint<BlueprintItem, BlueprintItemReference>? item = null,
        bool? nonRemovable = null)
    {
      var element = ElementTool.Create<MakeItemNonRemovable>();
      element.m_Item = item.Reference ?? element.m_Item;
      if (element.m_Item is null)
      {
        element.m_Item = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      element.NonRemovable = nonRemovable ?? element.NonRemovable;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MovePartyItemsAction"/>
    /// </summary>
    public static ActionsBuilder MovePartyItemsAction(
        this ActionsBuilder builder,
        MovePartyItemsAction.LeaveSettings? leaveEquipmentOf = null,
        MovePartyItemsAction.ItemType? pickupTypes = null,
        ItemsCollectionEvaluator? targetCollection = null)
    {
      var element = ElementTool.Create<MovePartyItemsAction>();
      builder.Validate(leaveEquipmentOf);
      element.m_LeaveEquipmentOf = leaveEquipmentOf ?? element.m_LeaveEquipmentOf;
      element.PickupTypes = pickupTypes ?? element.PickupTypes;
      builder.Validate(targetCollection);
      element.TargetCollection = targetCollection ?? element.TargetCollection;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="OpenSelectMythicUI"/>
    /// </summary>
    public static ActionsBuilder OpenSelectMythicUI(
        this ActionsBuilder builder,
        ActionsBuilder? afterCommitActions = null,
        ActionsBuilder? afterStopActions = null,
        bool? lockStopChargen = null)
    {
      var element = ElementTool.Create<OpenSelectMythicUI>();
      element.m_AfterCommitActions = afterCommitActions.Build() ?? element.m_AfterCommitActions;
      if (element.m_AfterCommitActions is null)
      {
        element.m_AfterCommitActions = Constants.Empty.Actions;
      }
      element.m_AfterStopActions = afterStopActions.Build() ?? element.m_AfterStopActions;
      if (element.m_AfterStopActions is null)
      {
        element.m_AfterStopActions = Constants.Empty.Actions;
      }
      element.m_LockStopChargen = lockStopChargen ?? element.m_LockStopChargen;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveItemFromPlayer"/>
    /// </summary>
    ///
    /// <param name="itemToRemove">
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RemoveItemFromPlayer(
        this ActionsBuilder builder,
        Blueprint<BlueprintItem, BlueprintItemReference>? itemToRemove = null,
        bool? money = null,
        float? percentage = null,
        int? quantity = null,
        bool? removeAll = null,
        bool? silent = null)
    {
      var element = ElementTool.Create<RemoveItemFromPlayer>();
      element.m_ItemToRemove = itemToRemove.Reference ?? element.m_ItemToRemove;
      if (element.m_ItemToRemove is null)
      {
        element.m_ItemToRemove = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      element.Money = money ?? element.Money;
      element.Percentage = percentage ?? element.Percentage;
      element.Quantity = quantity ?? element.Quantity;
      element.RemoveAll = removeAll ?? element.RemoveAll;
      element.m_Silent = silent ?? element.m_Silent;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveItemsFromCollection"/>
    /// </summary>
    public static ActionsBuilder RemoveItemsFromCollection(
        this ActionsBuilder builder,
        ItemsCollectionEvaluator? collection = null,
        List<LootEntry>? loot = null)
    {
      var element = ElementTool.Create<RemoveItemsFromCollection>();
      builder.Validate(collection);
      element.Collection = collection ?? element.Collection;
      foreach (var item in loot) { builder.Validate(item); }
      element.Loot = loot ?? element.Loot;
      if (element.Loot is null)
      {
        element.Loot = new();
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveDuplicateItems"/>
    /// </summary>
    ///
    /// <param name="blueprint">
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RemoveDuplicateItems(
        this ActionsBuilder builder,
        Blueprint<BlueprintItem, BlueprintItemReference>? blueprint = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<RemoveDuplicateItems>();
      element.m_Blueprint = blueprint.Reference ?? element.m_Blueprint;
      if (element.m_Blueprint is null)
      {
        element.m_Blueprint = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RestoreItemsCountInCollection"/>
    /// </summary>
    ///
    /// <param name="item">
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RestoreItemsCountInCollection(
        this ActionsBuilder builder,
        ItemsCollectionEvaluator? collection = null,
        IntEvaluator? count = null,
        Blueprint<BlueprintItem, BlueprintItemReference>? item = null)
    {
      var element = ElementTool.Create<RestoreItemsCountInCollection>();
      builder.Validate(collection);
      element.Collection = collection ?? element.Collection;
      builder.Validate(count);
      element.Count = count ?? element.Count;
      element.m_Item = item.Reference ?? element.m_Item;
      if (element.m_Item is null)
      {
        element.m_Item = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SellCollectibleItems"/>
    /// </summary>
    ///
    /// <param name="itemToSell">
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder SellCollectibleItems(
        this ActionsBuilder builder,
        bool? halfPrice = null,
        Blueprint<BlueprintItem, BlueprintItemReference>? itemToSell = null)
    {
      var element = ElementTool.Create<SellCollectibleItems>();
      element.HalfPrice = halfPrice ?? element.HalfPrice;
      element.m_ItemToSell = itemToSell.Reference ?? element.m_ItemToSell;
      if (element.m_ItemToSell is null)
      {
        element.m_ItemToSell = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetStartDate"/>
    /// </summary>
    public static ActionsBuilder SetStartDate(
        this ActionsBuilder builder,
        string? date = null)
    {
      var element = ElementTool.Create<SetStartDate>();
      element.Date = date ?? element.Date;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetVendorPriceModifier"/>
    /// </summary>
    public static ActionsBuilder SetVendorPriceModifier(
        this ActionsBuilder builder,
        SetVendorPriceModifier.Entry[]? entries = null,
        UnitEvaluator? vendorUnit = null)
    {
      var element = ElementTool.Create<SetVendorPriceModifier>();
      foreach (var item in entries) { builder.Validate(item); }
      element.m_Entries = entries ?? element.m_Entries;
      if (element.m_Entries is null)
      {
        element.m_Entries = new SetVendorPriceModifier.Entry[0];
      }
      builder.Validate(vendorUnit);
      element.VendorUnit = vendorUnit ?? element.VendorUnit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ShowPartySelection"/>
    /// </summary>
    public static ActionsBuilder ShowPartySelection(
        this ActionsBuilder builder,
        ActionsBuilder? actionsAfterPartySelection = null,
        ActionsBuilder? actionsIfCanceled = null)
    {
      var element = ElementTool.Create<ShowPartySelection>();
      element.ActionsAfterPartySelection = actionsAfterPartySelection.Build() ?? element.ActionsAfterPartySelection;
      if (element.ActionsAfterPartySelection is null)
      {
        element.ActionsAfterPartySelection = Constants.Empty.Actions;
      }
      element.ActionsIfCanceled = actionsIfCanceled.Build() ?? element.ActionsIfCanceled;
      if (element.ActionsIfCanceled is null)
      {
        element.ActionsIfCanceled = Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="StartTrade"/>
    /// </summary>
    public static ActionsBuilder StartTrade(
        this ActionsBuilder builder,
        UnitEvaluator? vendor = null)
    {
      var element = ElementTool.Create<StartTrade>();
      builder.Validate(vendor);
      element.Vendor = vendor ?? element.Vendor;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnequipAllItems"/>
    /// </summary>
    public static ActionsBuilder UnequipAllItems(
        this ActionsBuilder builder,
        ItemsCollectionEvaluator? destinationContainer = null,
        bool? silent = null,
        UnitEvaluator? target = null)
    {
      var element = ElementTool.Create<UnequipAllItems>();
      builder.Validate(destinationContainer);
      element.DestinationContainer = destinationContainer ?? element.DestinationContainer;
      element.Silent = silent ?? element.Silent;
      builder.Validate(target);
      element.Target = target ?? element.Target;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnequipItem"/>
    /// </summary>
    ///
    /// <param name="item">
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder UnequipItem(
        this ActionsBuilder builder,
        bool? all = null,
        ItemsCollectionEvaluator? destinationContainer = null,
        Blueprint<BlueprintItem, BlueprintItemReference>? item = null,
        bool? silent = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<UnequipItem>();
      element.All = all ?? element.All;
      builder.Validate(destinationContainer);
      element.DestinationContainer = destinationContainer ?? element.DestinationContainer;
      element.m_Item = item.Reference ?? element.m_Item;
      if (element.m_Item is null)
      {
        element.m_Item = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      element.Silent = silent ?? element.Silent;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ShowNewTutorial"/>
    /// </summary>
    ///
    /// <param name="tutorial">
    /// Blueprint of type BlueprintTutorial. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ShowNewTutorial(
        this ActionsBuilder builder,
        TutorialContextDataEvaluator[]? evaluators = null,
        Blueprint<BlueprintTutorial, BlueprintTutorial.Reference>? tutorial = null)
    {
      var element = ElementTool.Create<ShowNewTutorial>();
      foreach (var item in evaluators) { builder.Validate(item); }
      element.Evaluators = evaluators ?? element.Evaluators;
      if (element.Evaluators is null)
      {
        element.Evaluators = new TutorialContextDataEvaluator[0];
      }
      element.m_Tutorial = tutorial.Reference ?? element.m_Tutorial;
      if (element.m_Tutorial is null)
      {
        element.m_Tutorial = BlueprintTool.GetRef<BlueprintTutorial.Reference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddVendorItemsAction"/>
    /// </summary>
    ///
    /// <param name="vendorTable">
    /// Blueprint of type BlueprintUnitLoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder AddVendorItemsAction(
        this ActionsBuilder builder,
        VendorEvaluator? vendorEvaluator = null,
        Blueprint<BlueprintUnitLoot, BlueprintUnitLootReference>? vendorTable = null)
    {
      var element = ElementTool.Create<AddVendorItemsAction>();
      builder.Validate(vendorEvaluator);
      element.m_VendorEvaluator = vendorEvaluator ?? element.m_VendorEvaluator;
      element.m_VendorTable = vendorTable.Reference ?? element.m_VendorTable;
      if (element.m_VendorTable is null)
      {
        element.m_VendorTable = BlueprintTool.GetRef<BlueprintUnitLootReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ClearVendorTable"/>
    /// </summary>
    ///
    /// <param name="table">
    /// Blueprint of type BlueprintSharedVendorTable. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ClearVendorTable(
        this ActionsBuilder builder,
        Blueprint<BlueprintSharedVendorTable, BlueprintSharedVendorTableReference>? table = null)
    {
      var element = ElementTool.Create<ClearVendorTable>();
      element.m_Table = table.Reference ?? element.m_Table;
      if (element.m_Table is null)
      {
        element.m_Table = BlueprintTool.GetRef<BlueprintSharedVendorTableReference>(null);
      }
      return builder.Add(element);
    }
  }
}
