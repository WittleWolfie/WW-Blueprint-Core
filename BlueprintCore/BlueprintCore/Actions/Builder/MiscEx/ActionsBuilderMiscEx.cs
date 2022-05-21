//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker;
using Kingmaker.Achievements.Actions;
using Kingmaker.Achievements.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Blueprints.Root;
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
    /// Adds <see cref="ActionAchievementUnlock"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>01_DevouredByDarkness</term><description>67d3321ed01a4e58a9ed3e13f94f1d04</description></item>
    /// <item><term>60_Ascension</term><description>bf2f03321974495bbbcfc89781895757</description></item>
    /// <item><term>SorcScroll_Action</term><description>c99f4c8c4cd44d7293ca5e73efff2a36</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="achievement">
    /// <para>
    /// Blueprint of type AchievementData. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder AchievementUnlock(
        this ActionsBuilder builder,
        Blueprint<AchievementData, AchievementDataReference> achievement)
    {
      var element = ElementTool.Create<ActionAchievementUnlock>();
      element.m_Achievement = achievement?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddPremiumReward"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter01_Extra</term><description>318f49bf0efcfb4449d0973a3cb3bb73</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="dlcReward">
    /// <para>
    /// Blueprint of type BlueprintDlcReward. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="items">
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
    /// <param name="playerFeatures">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder AddPremiumReward(
        this ActionsBuilder builder,
        ActionsBuilder? additionalActions = null,
        Blueprint<BlueprintDlcReward, BlueprintDlcRewardReference>? dlcReward = null,
        List<Blueprint<BlueprintItem, BlueprintItemReference>>? items = null,
        List<Blueprint<BlueprintFeature, BlueprintFeatureReference>>? playerFeatures = null)
    {
      var element = ElementTool.Create<AddPremiumReward>();
      element.AdditionalActions = additionalActions?.Build() ?? element.AdditionalActions;
      if (element.AdditionalActions is null)
      {
        element.AdditionalActions = Utils.Constants.Empty.Actions;
      }
      element.m_DlcReward = dlcReward?.Reference ?? element.m_DlcReward;
      if (element.m_DlcReward is null)
      {
        element.m_DlcReward = BlueprintTool.GetRef<BlueprintDlcRewardReference>(null);
      }
      element.Items = items?.Select(bp => bp.Reference)?.ToList() ?? element.Items;
      if (element.Items is null)
      {
        element.Items = new();
      }
      element.PlayerFeatures = playerFeatures?.Select(bp => bp.Reference)?.ToList() ?? element.PlayerFeatures;
      if (element.PlayerFeatures is null)
      {
        element.PlayerFeatures = new();
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddVendorItemsAction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter02</term><description>0e20d73ea0da6a94d94a6b42035a1ce0</description></item>
    /// <item><term>Chapter04</term><description>637a57423a82b044f888677c92f5d6cb</description></item>
    /// <item><term>Chapter05</term><description>5b01aa690202e584888dfc600a4aac0a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="vendorTable">
    /// <para>
    /// Blueprint of type BlueprintUnitLoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder AddVendorItemsAction(
        this ActionsBuilder builder,
        VendorEvaluator? vendorEvaluator = null,
        Blueprint<BlueprintUnitLoot, BlueprintUnitLootReference>? vendorTable = null)
    {
      var element = ElementTool.Create<AddVendorItemsAction>();
      builder.Validate(vendorEvaluator);
      element.m_VendorEvaluator = vendorEvaluator ?? element.m_VendorEvaluator;
      element.m_VendorTable = vendorTable?.Reference ?? element.m_VendorTable;
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DHLost_Mechanic</term><description>e5961409f47c4d0f9c19e7af184a8eb6</description></item>
    /// <item><term>Test_Bebilith Blueprint Camping Encounter</term><description>f2f8355d4bc8aa34195eeb2f5cf66645</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="table">
    /// <para>
    /// Blueprint of type BlueprintSharedVendorTable. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder ClearVendorTable(
        this ActionsBuilder builder,
        Blueprint<BlueprintSharedVendorTable, BlueprintSharedVendorTableReference>? table = null)
    {
      var element = ElementTool.Create<ClearVendorTable>();
      element.m_Table = table?.Reference ?? element.m_Table;
      if (element.m_Table is null)
      {
        element.m_Table = BlueprintTool.GetRef<BlueprintSharedVendorTableReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CreateCustomCompanion"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Cue_0009</term><description>32d9ef168c6a4b0e9faf49276757bf78</description></item>
    /// <item><term>Cue_0092</term><description>02f78f1ae421a474899f477aed93abd2</description></item>
    /// <item><term>Cue_6</term><description>bce0e0734b514a8194a695aa0dc017f6</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder CreateCustomCompanion(
        this ActionsBuilder builder,
        bool? forFree = null,
        LocatorEvaluator? locator = null,
        bool? lockInUi = null,
        bool? matchPlayerXpExactly = null,
        bool? noEquipment = null,
        ActionsBuilder? onCreate = null)
    {
      var element = ElementTool.Create<CreateCustomCompanion>();
      element.ForFree = forFree ?? element.ForFree;
      builder.Validate(locator);
      element.Locator = locator ?? element.Locator;
      element.LockInUi = lockInUi ?? element.LockInUi;
      element.MatchPlayerXpExactly = matchPlayerXpExactly ?? element.MatchPlayerXpExactly;
      element.NoEquipment = noEquipment ?? element.NoEquipment;
      element.OnCreate = onCreate?.Build() ?? element.OnCreate;
      if (element.OnCreate is null)
      {
        element.OnCreate = Utils.Constants.Empty.Actions;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DebugLog"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0007</term><description>86b05ac8299b6aa4d981d66648fa72b6</description></item>
    /// <item><term>SW_SeelahDoor_Actions</term><description>ee6f1cc0643a6f94cac31290bd6084b2</description></item>
    /// <item><term>ThresholdIndoor_SecondFloor</term><description>8b1257aca48c59844a85dd1b11e5df7f</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction</term><description>5b9e7c0c242f41ea8c880d260ee29892</description></item>
    /// <item><term>CommandAction7</term><description>9cccb946a0f447038eccd011b479ebc7</description></item>
    /// <item><term>Epilogues_afterlogues_dialogue</term><description>57e18f5158904030a84a772fb361ceb4</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder GameOver(
        this ActionsBuilder builder,
        Player.GameOverReasonType? reason = null)
    {
      var element = ElementTool.Create<GameOver>();
      element.Reason = reason ?? element.Reason;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ImportSave"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Cue_0010</term><description>4e1fb44f339e88340b9daee8aca0c463</description></item>
    /// <item><term>DLC1_SaveImport</term><description>31417683088d40b8beb3691c393fb3d3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="autoImportIfOnlyOneSave">
    /// <para>
    /// Tooltip: Import automatically if only one appropriate save file is presented.
    /// </para>
    /// </param>
    /// <param name="campaign">
    /// <para>
    /// Blueprint of type BlueprintCampaign. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="letPlayerChooseSave">
    /// <para>
    /// Tooltip: Display a prompt asking to choose a save from a list, if any. Otherwise the save will be chosen automatically and silently imported.
    /// </para>
    /// </param>
    public static ActionsBuilder ImportSave(
        this ActionsBuilder builder,
        bool? autoImportIfOnlyOneSave = null,
        Blueprint<BlueprintCampaign, BlueprintCampaignReference>? campaign = null,
        bool? letPlayerChooseSave = null)
    {
      var element = ElementTool.Create<ImportSave>();
      element.m_AutoImportIfOnlyOneSave = autoImportIfOnlyOneSave ?? element.m_AutoImportIfOnlyOneSave;
      element.m_Campaign = campaign?.Reference ?? element.m_Campaign;
      if (element.m_Campaign is null)
      {
        element.m_Campaign = BlueprintTool.GetRef<BlueprintCampaignReference>(null);
      }
      element.m_LetPlayerChooseSave = letPlayerChooseSave ?? element.m_LetPlayerChooseSave;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MakeAutoSave"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>2FinalFight</term><description>5ea3f8cc4a6f6b4498e55456a4980f2d</description></item>
    /// <item><term>Cue_0023</term><description>1748505b610131747ae2f80f2286a19a</description></item>
    /// <item><term>ToRoofs_FromMediumToLower_TeleportFail</term><description>cef19ac4f4194e1cb3ddf53cb2793bbe</description></item>
    /// </list>
    /// </remarks>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0066</term><description>6f7cdaa54e3176f4b8f55cb21faa606c</description></item>
    /// <item><term>Cue_0013</term><description>73f984a6ecfe6d64f87f2045aa92fd84</description></item>
    /// <item><term>Wardstone_BookEvent</term><description>b24b879dad653a74d8105f377f2ab1a1</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="item">
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
    public static ActionsBuilder MakeItemNonRemovable(
        this ActionsBuilder builder,
        Blueprint<BlueprintItem, BlueprintItemReference>? item = null,
        bool? nonRemovable = null)
    {
      var element = ElementTool.Create<MakeItemNonRemovable>();
      element.m_Item = item?.Reference ?? element.m_Item;
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ColyphyrPrisonersMechanics</term><description>83d837907d526c144938dc0eff156a41</description></item>
    /// <item><term>IvoryLabyrinth_Prison</term><description>f97f4de6a5073df49b9cac68859f05ae</description></item>
    /// <item><term>Prologue_Caves_1_Default_Preset</term><description>816615290645ad44f9b5e142490ebbd6</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="leaveEquipmentOf">
    /// <para>
    /// Tooltip: Do not remove items equipped on some companions
    /// </para>
    /// </param>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CheliaxWaitingInRuins</term><description>1fb5dba7e2beabe4ebf631c07559f64d</description></item>
    /// <item><term>CommandAction1</term><description>bb530e9345434933ba412402ca787bf1</description></item>
    /// <item><term>CommandAction4</term><description>0deaaa94f48e4efea9fc654d1c3d42f2</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="afterCommitActions">
    /// <para>
    /// Tooltip: If levelUp was complete
    /// </para>
    /// </param>
    /// <param name="afterStopActions">
    /// <para>
    /// Tooltip: If levelUp was close
    /// </para>
    /// </param>
    /// <param name="lockStopChargen">
    /// <para>
    /// Tooltip: If true, buttons Close, Back and Esc will be disable in chargen
    /// </para>
    /// </param>
    public static ActionsBuilder OpenSelectMythicUI(
        this ActionsBuilder builder,
        ActionsBuilder? afterCommitActions = null,
        ActionsBuilder? afterStopActions = null,
        bool? lockStopChargen = null)
    {
      var element = ElementTool.Create<OpenSelectMythicUI>();
      element.m_AfterCommitActions = afterCommitActions?.Build() ?? element.m_AfterCommitActions;
      if (element.m_AfterCommitActions is null)
      {
        element.m_AfterCommitActions = Utils.Constants.Empty.Actions;
      }
      element.m_AfterStopActions = afterStopActions?.Build() ?? element.m_AfterStopActions;
      if (element.m_AfterStopActions is null)
      {
        element.m_AfterStopActions = Utils.Constants.Empty.Actions;
      }
      element.m_LockStopChargen = lockStopChargen ?? element.m_LockStopChargen;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveItemFromPlayer"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/RemoveItemFromPlayer
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcidButton1_CheckPassedActions</term><description>2a969038211346358597f80d271d9b94</description></item>
    /// <item><term>Cue_0029</term><description>2a5f92deaccded945b22cb6efb7c1e21</description></item>
    /// <item><term>ZeorisDaggerRingProject_Enchanting</term><description>0dc3a4e036064970857b3c3e296a7d94</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="itemToRemove">
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
      element.m_ItemToRemove = itemToRemove?.Reference ?? element.m_ItemToRemove;
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0011</term><description>ac4468a7eded7fd43946f1a730791ff0</description></item>
    /// <item><term>Cue_0062</term><description>70f2c9f4876257a4f8c47b5409752aef</description></item>
    /// <item><term>RevertYellow</term><description>0aa2618093d44ed7bce51a1fbadddff8</description></item>
    /// </list>
    /// </remarks>
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
    /// Adds <see cref="SellCollectibleItems"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/SellCollectibleItems
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Cue_0032</term><description>48be2f65960f7074fbcfb369ea4e75b8</description></item>
    /// <item><term>Cue_0215</term><description>fc8766d2613f86b46b35e965324c09f3</description></item>
    /// <item><term>Cue_0433</term><description>12306a8e04af53a4bad19b07e3e58b77</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="itemToSell">
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
    public static ActionsBuilder SellCollectibleItems(
        this ActionsBuilder builder,
        bool? halfPrice = null,
        Blueprint<BlueprintItem, BlueprintItemReference>? itemToSell = null)
    {
      var element = ElementTool.Create<SellCollectibleItems>();
      element.HalfPrice = halfPrice ?? element.HalfPrice;
      element.m_ItemToSell = itemToSell?.Reference ?? element.m_ItemToSell;
      if (element.m_ItemToSell is null)
      {
        element.m_ItemToSell = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetVendorPriceModifier"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0053</term><description>4a39499e080be884b9566f948362f0a1</description></item>
    /// <item><term>DLC2_RichQuarter</term><description>91a2a02a516143f1bee4e428c9d83dad</description></item>
    /// <item><term>Vendor_Tiefling_SetBigPrices</term><description>04e277fd32f342739153f7bd6d2919a9</description></item>
    /// </list>
    /// </remarks>
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
    /// Adds <see cref="ShowNewTutorial"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Alushinyrra_FlyingIsles_HigherCityTutorial</term><description>703a58daf08849d9bb67e328064866ea</description></item>
    /// <item><term>Cue_0062</term><description>bb89e76de056adf4c984110340b738ff</description></item>
    /// <item><term>TutorInspect</term><description>8edce8ffe87051a4eb32293277f7b4be</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="tutorial">
    /// <para>
    /// Blueprint of type BlueprintTutorial. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
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
      element.m_Tutorial = tutorial?.Reference ?? element.m_Tutorial;
      if (element.m_Tutorial is null)
      {
        element.m_Tutorial = BlueprintTool.GetRef<BlueprintTutorial.Reference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ShowPartySelection"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0005</term><description>daab00a6e6c650246a7ebb32c9fd8240</description></item>
    /// <item><term>DLC1_ThresholdOutdoor_BET_NormalCamp</term><description>e67f735c38b444b680c94bf090b3a334</description></item>
    /// <item><term>YozzTeleportsToShamirasPalase</term><description>03e68d18fd2a47fc95917ba3f45d720d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="forceCapitalModeLogic">
    /// <para>
    /// InfoBox: Group selector logic will be similar to Hub exit (all remote companions will be accessible)
    /// </para>
    /// </param>
    public static ActionsBuilder ShowPartySelection(
        this ActionsBuilder builder,
        ActionsBuilder? actionsAfterPartySelection = null,
        ActionsBuilder? actionsIfCanceled = null,
        bool? forceCapitalModeLogic = null)
    {
      var element = ElementTool.Create<ShowPartySelection>();
      element.ActionsAfterPartySelection = actionsAfterPartySelection?.Build() ?? element.ActionsAfterPartySelection;
      if (element.ActionsAfterPartySelection is null)
      {
        element.ActionsAfterPartySelection = Utils.Constants.Empty.Actions;
      }
      element.ActionsIfCanceled = actionsIfCanceled?.Build() ?? element.ActionsIfCanceled;
      if (element.ActionsIfCanceled is null)
      {
        element.ActionsIfCanceled = Utils.Constants.Empty.Actions;
      }
      element.ForceCapitalModeLogic = forceCapitalModeLogic ?? element.ForceCapitalModeLogic;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="StartTrade"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0002</term><description>9ccba3622c4345f1a0d4ab58a5edaab0</description></item>
    /// <item><term>Cue_0006</term><description>5867dfe6156215944ab9b9d8b414c8a7</description></item>
    /// <item><term>WoljifFarewell_dialogue</term><description>0e94cfa04d06db1438eb565f60c0012c</description></item>
    /// </list>
    /// </remarks>
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
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CamelliaQ2</term><description>ab6e8c0132ddd2a4495408cfacb660f7</description></item>
    /// <item><term>CommandAction 1</term><description>e7285ada236157b4aa17c6e53a13d8eb</description></item>
    /// <item><term>LannWantsTraining_Sparring</term><description>35d585854f8cfa84491a58e49642d4c0</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="destinationContainer">
    /// <para>
    /// InfoBox: If not specified, items will be moved to unit&amp;apos;s inventory
    /// </para>
    /// </param>
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction</term><description>bacc9e60f4554ddf9aff4aa5f7dd61ef</description></item>
    /// <item><term>Cue_0051</term><description>3df7adbce79f77f41a2830ac44b85591</description></item>
    /// <item><term>Cue_0052</term><description>728a93278c0029648ab10295221af126</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="destinationContainer">
    /// <para>
    /// InfoBox: If not specified, item will be moved to unit&amp;apos;s inventory
    /// </para>
    /// </param>
    /// <param name="item">
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
      element.m_Item = item?.Reference ?? element.m_Item;
      if (element.m_Item is null)
      {
        element.m_Item = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      element.Silent = silent ?? element.Silent;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }
  }
}
