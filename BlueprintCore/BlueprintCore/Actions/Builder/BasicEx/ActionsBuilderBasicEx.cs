//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Experience;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Corruption;
using Kingmaker.Designers;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.NamedParameters;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BlueprintCore.Actions.Builder.BasicEx
{
  /// <summary>
  /// Extension to <see cref="ActionsBuilder"/> for most game mechanics related actions not included in <see cref="ContextEx.ActionsBuilderContextEx">ContextEx</see>.
  /// </summary>
  /// <inheritdoc cref="ActionsBuilder"/>
  public static class ActionsBuilderBasicEx
  {

    /// <summary>
    /// Adds <see cref="AddFact"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>[core++][Melazmera]_SpawnActions</term><description>9a3e4288325998c429b38b024fc710c7</description></item>
    /// <item><term>Cue_17</term><description>c3c277fbe80748378a9f7f2db9802318</description></item>
    /// <item><term>Yozz_SpawnActions</term><description>fd9c741b62d849e8bf451cdf8ad9751d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="fact">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder AddFact(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnitFactReference> fact,
        UnitEvaluator unit)
    {
      var element = ElementTool.Create<AddFact>();
      element.m_Fact = fact?.Reference;
      builder.Validate(unit);
      element.Unit = unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddFatigueHours"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/AddFatigueHours
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction</term><description>f6741784e15c5bb498f40a05204e0770</description></item>
    /// <item><term>Cue_0017</term><description>15b4735f80767214a8665c9cb71992ed</description></item>
    /// <item><term>WayUpInteraction04_CheckFailedActions</term><description>16cabbc936a0180469521f3c8bedd1f2</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder AddFatigueHours(
        this ActionsBuilder builder,
        IntEvaluator hours,
        UnitEvaluator unit)
    {
      var element = ElementTool.Create<AddFatigueHours>();
      builder.Validate(hours);
      element.Hours = hours;
      builder.Validate(unit);
      element.Unit = unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddItemsToCollection"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AlushinyrraFleshmarket_DefaultEtude</term><description>c9e64ecd28a6f6c429786c97fc9cd189</description></item>
    /// <item><term>DLC3_BrokenTricksterGlassesArtifact</term><description>b8082bfe7f00438ca2122acbeed5073d</description></item>
    /// <item><term>WakeUp</term><description>cab903611be84934b8ebb21623db4cfa</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder AddItems(
        this ActionsBuilder builder,
        ItemsCollectionEvaluator items,
        bool? identify = null,
        List<LootEntry>? loot = null,
        bool? silent = null,
        bool? useBlueprintUnitLoot = null)
    {
      var element = ElementTool.Create<AddItemsToCollection>();
      builder.Validate(items);
      element.ItemsCollection = items;
      element.Identify = identify ?? element.Identify;
      builder.Validate(loot);
      element.Loot = loot ?? element.Loot;
      if (element.Loot is null)
      {
        element.Loot = new();
      }
      element.Silent = silent ?? element.Silent;
      element.UseBlueprintUnitLoot = useBlueprintUnitLoot ?? element.UseBlueprintUnitLoot;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddItemsToCollection"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AlushinyrraFleshmarket_DefaultEtude</term><description>c9e64ecd28a6f6c429786c97fc9cd189</description></item>
    /// <item><term>DLC3_BrokenTricksterGlassesArtifact</term><description>b8082bfe7f00438ca2122acbeed5073d</description></item>
    /// <item><term>WakeUp</term><description>cab903611be84934b8ebb21623db4cfa</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="blueprintLoot">
    /// <para>
    /// Blueprint of type BlueprintUnitLoot. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder AddItemsFromBlueprint(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnitLootReference> blueprintLoot,
        ItemsCollectionEvaluator items,
        bool? identify = null,
        bool? silent = null,
        bool? useBlueprintUnitLoot = null)
    {
      var element = ElementTool.Create<AddItemsToCollection>();
      element.m_BlueprintLoot = blueprintLoot?.Reference;
      builder.Validate(items);
      element.ItemsCollection = items;
      element.Identify = identify ?? element.Identify;
      element.Silent = silent ?? element.Silent;
      element.UseBlueprintUnitLoot = useBlueprintUnitLoot ?? element.UseBlueprintUnitLoot;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddItemToPlayer"/>
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// If the item is a <see cref="BlueprintItemEquipmentHand"/> use <see cref="GiveHandSlotItemToPlayer"/>
    /// </para>
    /// <para>
    /// If the item is a <see cref="BlueprintItemEquipment"/> use <see cref="GiveEquipmentToPlayer"/>
    /// </para>
    /// <para>
    /// For any other items use <see cref="GiveItemToPlayer"/>.
    /// </para>
    ///
    /// <para>
    /// ComponentName: Actions/AddItemToPlayer
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcidButton1_CheckPassedActions</term><description>2a969038211346358597f80d271d9b94</description></item>
    /// <item><term>Cue_0120</term><description>2440461bbb59f004aa6cca08406febaa</description></item>
    /// <item><term>Ziggurat_PharasmaAttack_Preset</term><description>a13c8eec8c81b054ea12caf6b7584a93</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="itemToGive">
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
    public static ActionsBuilder GiveItemToPlayer(
        this ActionsBuilder builder,
        Blueprint<BlueprintItemReference> itemToGive,
        bool? identify = null,
        int? quantity = null,
        bool? silent = null)
    {
      var element = ElementTool.Create<AddItemToPlayer>();
      element.m_ItemToGive = itemToGive?.Reference;
      var bp = itemToGive.Reference.Get();
      if (bp is BlueprintItemEquipmentHand)
      {
        throw new InvalidOperationException("Item fits in hand slot. Use GiveHandSlotItemToPlayer.");
      }
      else if (bp is BlueprintItemEquipment)
      {
        throw new InvalidOperationException("Item is equipment. Use GiveEquipmentToPlayer.");
      }
      element.Identify = identify ?? element.Identify;
      element.Quantity = quantity ?? element.Quantity;
      element.Silent = silent ?? element.Silent;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddItemToPlayer"/>
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// If the item is a <see cref="BlueprintItemEquipmentHand"/> use <see cref="GiveHandSlotItemToPlayer"/>
    /// </para>
    /// <para>
    /// If the item is a <see cref="BlueprintItemEquipment"/> use <see cref="GiveEquipmentToPlayer"/>
    /// </para>
    /// <para>
    /// For any other items use <see cref="GiveItemToPlayer"/>.
    /// </para>
    ///
    /// <para>
    /// ComponentName: Actions/AddItemToPlayer
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcidButton1_CheckPassedActions</term><description>2a969038211346358597f80d271d9b94</description></item>
    /// <item><term>Cue_0120</term><description>2440461bbb59f004aa6cca08406febaa</description></item>
    /// <item><term>Ziggurat_PharasmaAttack_Preset</term><description>a13c8eec8c81b054ea12caf6b7584a93</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="itemToGive">
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
    public static ActionsBuilder GiveEquipmentToPlayer(
        this ActionsBuilder builder,
        Blueprint<BlueprintItemReference> itemToGive,
        bool? equip = null,
        UnitEvaluator? equipOn = null,
        bool? errorIfDidNotEquip = null,
        bool? identify = null,
        int? quantity = null,
        bool? silent = null)
    {
      var element = ElementTool.Create<AddItemToPlayer>();
      element.m_ItemToGive = itemToGive?.Reference;
      var bp = itemToGive.Reference.Get();
      if (bp is BlueprintItemEquipmentHand)
      {
        throw new InvalidOperationException("Item fits in hand slot. Use GiveHandSlotItemToPlayer.");
      }
      else if (bp is not BlueprintItemEquipment)
      {
        throw new InvalidOperationException("Item is not equipment. Use GiveItemToPlayer.");
      }
      element.Equip = equip ?? element.Equip;
      builder.Validate(equipOn);
      element.EquipOn = equipOn ?? element.EquipOn;
      element.ErrorIfDidNotEquip = errorIfDidNotEquip ?? element.ErrorIfDidNotEquip;
      element.Identify = identify ?? element.Identify;
      element.Quantity = quantity ?? element.Quantity;
      element.Silent = silent ?? element.Silent;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddItemToPlayer"/>
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// If the item is a <see cref="BlueprintItemEquipmentHand"/> use <see cref="GiveHandSlotItemToPlayer"/>
    /// </para>
    /// <para>
    /// If the item is a <see cref="BlueprintItemEquipment"/> use <see cref="GiveEquipmentToPlayer"/>
    /// </para>
    /// <para>
    /// For any other items use <see cref="GiveItemToPlayer"/>.
    /// </para>
    ///
    /// <para>
    /// ComponentName: Actions/AddItemToPlayer
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcidButton1_CheckPassedActions</term><description>2a969038211346358597f80d271d9b94</description></item>
    /// <item><term>Cue_0120</term><description>2440461bbb59f004aa6cca08406febaa</description></item>
    /// <item><term>Ziggurat_PharasmaAttack_Preset</term><description>a13c8eec8c81b054ea12caf6b7584a93</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="itemToGive">
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
    /// <param name="preferredWeaponSet">
    /// <para>
    /// Tooltip: Select weaponset number for a weapon. 0 means first available, 1-4 to select specific slot
    /// </para>
    /// </param>
    public static ActionsBuilder GiveHandSlotItemToPlayer(
        this ActionsBuilder builder,
        Blueprint<BlueprintItemReference> itemToGive,
        bool? equip = null,
        UnitEvaluator? equipOn = null,
        bool? errorIfDidNotEquip = null,
        bool? identify = null,
        int? preferredWeaponSet = null,
        int? quantity = null,
        bool? silent = null)
    {
      var element = ElementTool.Create<AddItemToPlayer>();
      element.m_ItemToGive = itemToGive?.Reference;
      var bp = itemToGive.Reference.Get();
      if (bp is not BlueprintItemEquipmentHand)
      {
        if (bp is BlueprintItemEquipment)
        {
          throw new InvalidOperationException("Item does not fit in hand slot. Use GiveEquipmentToPlayer.");
        }
        else
        {
          throw new InvalidOperationException("Item is not equipment. Use GiveItemToPlayer.");
        }
      }
      element.Equip = equip ?? element.Equip;
      builder.Validate(equipOn);
      element.EquipOn = equipOn ?? element.EquipOn;
      element.ErrorIfDidNotEquip = errorIfDidNotEquip ?? element.ErrorIfDidNotEquip;
      element.Identify = identify ?? element.Identify;
      element.PreferredWeaponSet = preferredWeaponSet ?? element.PreferredWeaponSet;
      element.Quantity = quantity ?? element.Quantity;
      element.Silent = silent ?? element.Silent;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddUnitToSummonPool"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/AddUnitToSummonPool
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Add2Pool_SpawnActions</term><description>28ded583139864e428a5646acf7d97d4</description></item>
    /// <item><term>CommandAction8</term><description>c95966979def42e7bdd8c17570d63b12</description></item>
    /// <item><term>ZigguratZachariusInZiggurat</term><description>2844d387f27a0bb468f72603dd15eda2</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="summonPool">
    /// <para>
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder AddUnitToSummonPool(
        this ActionsBuilder builder,
        Blueprint<BlueprintSummonPoolReference> summonPool,
        UnitEvaluator unit)
    {
      var element = ElementTool.Create<AddUnitToSummonPool>();
      element.m_SummonPool = summonPool?.Reference;
      builder.Validate(unit);
      element.Unit = unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AttachBuff"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/AttachBuff
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>(CR 6) Necromancer_SpawnActions</term><description>966067be66094e699fd7247f4507dd1a</description></item>
    /// <item><term>CommonAttachBuff(VisionRange2)_SpawnActions</term><description>929ac6d9b2123ba4cb043864adac8828</description></item>
    /// <item><term>ZigguratZachariusInZiggurat</term><description>2844d387f27a0bb468f72603dd15eda2</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="buff">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="customBattleLogMessage">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public static ActionsBuilder AttachBuff(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuffReference> buff,
        IntEvaluator duration,
        UnitEvaluator target,
        bool? battleLog = null,
        LocalString? customBattleLogMessage = null,
        bool? hasCustomBattleLogMessage = null)
    {
      var element = ElementTool.Create<AttachBuff>();
      element.m_Buff = buff?.Reference;
      builder.Validate(duration);
      element.Duration = duration;
      builder.Validate(target);
      element.Target = target;
      element.BattleLog = battleLog ?? element.BattleLog;
      element.CustomBattleLogMessage = customBattleLogMessage?.LocalizedString ?? element.CustomBattleLogMessage;
      if (element.CustomBattleLogMessage is null)
      {
        element.CustomBattleLogMessage = Utils.Constants.Empty.String;
      }
      element.HasCustomBattleLogMessage = hasCustomBattleLogMessage ?? element.HasCustomBattleLogMessage;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ChangeAlignment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Cue_0002</term><description>8705301a2f15c6a46b68eb799e79e3b7</description></item>
    /// <item><term>Cue_0030</term><description>b81f18abf6968ac47bb86d727f57c9c3</description></item>
    /// <item><term>PF-288723</term><description>b22e5fbcafaf4488b83001ca8f919ab0</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder ChangeAlignment(
        this ActionsBuilder builder,
        Alignment alignment,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<ChangeAlignment>();
      element.Alignment = alignment;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ChangePlayerAlignment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0139</term><description>f165187fb9d7f9144a00f9ae7f4cd617</description></item>
    /// <item><term>DevilExAeon</term><description>1f8f094f7dcf4c6e8ddead6f1900c57b</description></item>
    /// <item><term>DevilExAzata</term><description>40f5e905f9bf4aedbdb0148ff04f370e</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder ChangePlayerAlignment(
        this ActionsBuilder builder,
        Alignment targetAlignment,
        bool? canUnlockAlignment = null)
    {
      var element = ElementTool.Create<ChangePlayerAlignment>();
      element.TargetAlignment = targetAlignment;
      element.CanUnlockAlignment = canUnlockAlignment ?? element.CanUnlockAlignment;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ClearUnitReturnPosition"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction</term><description>34415d0af612475fbae6e67c90d25a13</description></item>
    /// <item><term>CommandAction7</term><description>e601c30adfa34b988621b8bcaa68af7c</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder ClearUnitReturnPosition(
        this ActionsBuilder builder,
        UnitEvaluator unit)
    {
      var element = ElementTool.Create<ClearUnitReturnPosition>();
      builder.Validate(unit);
      element.Unit = unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ClearUnitReturnPosition"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction</term><description>34415d0af612475fbae6e67c90d25a13</description></item>
    /// <item><term>CommandAction7</term><description>e601c30adfa34b988621b8bcaa68af7c</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder ClearAllUnitReturnPosition(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ClearUnitReturnPosition>());
    }

    /// <summary>
    /// Adds <see cref="CombineToGroup"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0038</term><description>8bfe04d1e0bccbd4fac00a23aa7f206c</description></item>
    /// <item><term>CommandAction1</term><description>564ad4c002ab445db93f4a35b4b06e0b</description></item>
    /// <item><term>WenduagTraitor_CombatStart</term><description>12d9b3713fd74349ac6cba4e34590d6a</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder CombineToGroup(
        this ActionsBuilder builder,
        UnitEvaluator groupHolder,
        UnitEvaluator targetUnit)
    {
      var element = ElementTool.Create<CombineToGroup>();
      builder.Validate(groupHolder);
      element.GroupHolder = groupHolder;
      builder.Validate(targetUnit);
      element.TargetUnit = targetUnit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CreaturesAround"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/CreaturesAround
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BattleBlissLastHalf</term><description>f86683ed8003c8c4aa002a1bd8293360</description></item>
    /// <item><term>DrezenToLevel2Transition</term><description>a43ea93b123ff224abf1c0cf89621d4b</description></item>
    /// <item><term>ThresholdIndoor_SecondFloor</term><description>8b1257aca48c59844a85dd1b11e5df7f</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder OnCreaturesAround(
        this ActionsBuilder builder,
        ActionsBuilder actions,
        PositionEvaluator center,
        FloatEvaluator radius,
        bool? checkLos = null,
        bool? includeDead = null)
    {
      var element = ElementTool.Create<CreaturesAround>();
      element.Actions = actions?.Build();
      builder.Validate(center);
      element.Center = center;
      builder.Validate(radius);
      element.Radius = radius;
      element.CheckLos = checkLos ?? element.CheckLos;
      element.IncludeDead = includeDead ?? element.IncludeDead;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DamageParty"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/DamageParty
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcrobaticCheckS1_CheckFailedActions</term><description>024cfea8fa605e5438485ae1bdb6c4f8</description></item>
    /// <item><term>DamageParty(1d6)_CheckFailedActions</term><description>0fffeb82c3a4ad34888b1f18203c74eb</description></item>
    /// <item><term>WayUpInteraction04_CheckFailedActions</term><description>16cabbc936a0180469521f3c8bedd1f2</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder DamageParty(
        this ActionsBuilder builder,
        DamageDescription damage,
        UnitEvaluator? damageSource = null,
        bool? disableBattleLog = null)
    {
      var element = ElementTool.Create<DamageParty>();
      builder.Validate(damage);
      element.Damage = damage;
      builder.Validate(damageSource);
      element.DamageSource = damageSource ?? element.DamageSource;
      element.NoSource = damageSource is null;
      element.DisableBattleLog = disableBattleLog ?? element.DisableBattleLog;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DealDamage"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcidButton_CheckFailedActions</term><description>f2d080fe523049cea7039b64baeed252</description></item>
    /// <item><term>Cue_0053</term><description>1785f3ebdfcb89f44ae691a06d336273</description></item>
    /// <item><term>YeribethHall_ResetCipher</term><description>6613c051209b7ef49a3653bc1d87fa36</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="source">
    /// <para>
    /// InfoBox: Note: If Target is peaceful NPC, damage wont be dealt. Use `NoSource = true` for such cases.
    /// </para>
    /// </param>
    public static ActionsBuilder DealDamage(
        this ActionsBuilder builder,
        DamageDescription damage,
        UnitEvaluator target,
        bool? disableBattleLog = null,
        bool? disableFxAndSound = null,
        UnitEvaluator? source = null)
    {
      var element = ElementTool.Create<DealDamage>();
      builder.Validate(damage);
      element.Damage = damage;
      builder.Validate(target);
      element.Target = target;
      element.DisableBattleLog = disableBattleLog ?? element.DisableBattleLog;
      element.DisableFxAndSound = disableFxAndSound ?? element.DisableFxAndSound;
      builder.Validate(source);
      element.Source = source ?? element.Source;
      element.NoSource = source is null;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DealStatDamage"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Cue_0053</term><description>c1830009abed0e44791d8b0b93b6575e</description></item>
    /// <item><term>Cue_0054</term><description>6137550ce20b37540ad1a3a5be8da0e2</description></item>
    /// <item><term>Cue_0055</term><description>84f296b72cdda8649bc68c0991a5ccde</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder DealStatDamage(
        this ActionsBuilder builder,
        DiceFormula damageDice,
        StatType stat,
        UnitEvaluator target,
        int? damageBonus = null,
        bool? disableBattleLog = null,
        bool? isDrain = null,
        UnitEvaluator? source = null)
    {
      var element = ElementTool.Create<DealStatDamage>();
      element.DamageDice = damageDice;
      element.Stat = stat;
      builder.Validate(target);
      element.Target = target;
      element.DamageBonus = damageBonus ?? element.DamageBonus;
      element.DisableBattleLog = disableBattleLog ?? element.DisableBattleLog;
      element.IsDrain = isDrain ?? element.IsDrain;
      builder.Validate(source);
      element.Source = source ?? element.Source;
      element.NoSource = source is null;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DeleteUnitFromSummonPool"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/DeleteUnitFromSummonPool
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0048_Merge</term><description>19f6bd3c47d39f040a523cdb591209fb</description></item>
    /// <item><term>Cue_0008</term><description>3c7cb627b3874dd9b018b0e6cc1e76fb</description></item>
    /// <item><term>VellexiaThirdDate</term><description>02ffbe686c198854da2d51e72fccb9ca</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="summonPool">
    /// <para>
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder DeleteUnitFromSummonPool(
        this ActionsBuilder builder,
        Blueprint<BlueprintSummonPoolReference> summonPool,
        UnitEvaluator unit)
    {
      var element = ElementTool.Create<DeleteUnitFromSummonPool>();
      element.m_SummonPool = summonPool?.Reference;
      builder.Validate(unit);
      element.Unit = unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DestroyUnit"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AfterFinalDIalog_EpicRelief</term><description>2fa48a4ad45a0f64d8f2881ff9802dd8</description></item>
    /// <item><term>CommandAction2</term><description>75c164fae3cd49c7a7b08c8099ccd909</description></item>
    /// <item><term>ZigguratZachariusInZiggurat</term><description>2844d387f27a0bb468f72603dd15eda2</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder DestroyUnit(
        this ActionsBuilder builder,
        UnitEvaluator target,
        bool? fadeOut = null)
    {
      var element = ElementTool.Create<DestroyUnit>();
      builder.Validate(target);
      element.Target = target;
      element.FadeOut = fadeOut ?? element.FadeOut;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PartyUnits"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/PartyUnits
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcrobaticCheckS1_CheckFailedActions</term><description>024cfea8fa605e5438485ae1bdb6c4f8</description></item>
    /// <item><term>Cue_0002</term><description>0bcc673bb9dcdd6479c9cf177934bbd6</description></item>
    /// <item><term>YeribethHall_ResetCipher</term><description>6613c051209b7ef49a3653bc1d87fa36</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder OnPartyUnits(
        this ActionsBuilder builder,
        ActionsBuilder actions,
        Player.CharactersList unitsList)
    {
      var element = ElementTool.Create<PartyUnits>();
      element.Actions = actions?.Build();
      element.m_UnitsList = unitsList;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ClearCorruptionLevelAction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CorruptionReset</term><description>ca0e397b189f4f83843a92adc8caf5b1</description></item>
    /// <item><term>RestBookEvent_1</term><description>3086724dfdd247d99abb16c9fc78875c</description></item>
    /// <item><term>Table</term><description>0de716585d1144adb266fd99570d8632</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder ClearCorruptionLevelAction(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ClearCorruptionLevelAction>());
    }

    /// <summary>
    /// Adds <see cref="DetachBuff"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>2Wave</term><description>4e1dcba08c1e4a89aea4aaa07f8f89ae</description></item>
    /// <item><term>CommandAction46</term><description>f33bcc52ecc5447db88afdb5a2cbbac3</description></item>
    /// <item><term>ZachariusEnemyInZiggurat</term><description>63cc30e6086ce1842997d0924677019c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="buff">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder DetachBuff(
        this ActionsBuilder builder,
        Blueprint<BlueprintBuffReference>? buff = null,
        UnitEvaluator? target = null)
    {
      var element = ElementTool.Create<DetachBuff>();
      element.m_Buff = buff?.Reference ?? element.m_Buff;
      if (element.m_Buff is null)
      {
        element.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      builder.Validate(target);
      element.Target = target ?? element.Target;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DisableExperienceFromUnit"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AlushinyrraHigherCity_DefaultEtude</term><description>41574c2d4b6d89e41b096094d0aed4f2</description></item>
    /// <item><term>CommandAction 7</term><description>ea51dc74e43bdb149b70e8661a71bad1</description></item>
    /// <item><term>MinotaurGhostBossNoExp</term><description>a1448e99c655531448f4e54ae5ea388a</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder DisableExperienceFromUnit(
        this ActionsBuilder builder,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<DisableExperienceFromUnit>();
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DrainEnergy"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Cue_0019</term><description>8ae08b543e9b29142983a7fec087982c</description></item>
    /// <item><term>Cue_0035</term><description>62d54f591bc9d3a45b3d5ab50b9fc08d</description></item>
    /// <item><term>Cue_0043</term><description>1f92270b60d2e2b43b58db696e7543bb</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder DrainEnergy(
        this ActionsBuilder builder,
        int? damageBonus = null,
        DiceFormula? damageDice = null,
        bool? disableBattleLog = null,
        Rounds? duration = null,
        bool? noSource = null,
        UnitEvaluator? source = null,
        UnitEvaluator? target = null,
        EnergyDrainType? type = null)
    {
      var element = ElementTool.Create<DrainEnergy>();
      element.DamageBonus = damageBonus ?? element.DamageBonus;
      element.DamageDice = damageDice ?? element.DamageDice;
      element.DisableBattleLog = disableBattleLog ?? element.DisableBattleLog;
      element.Duration = duration ?? element.Duration;
      element.NoSource = noSource ?? element.NoSource;
      builder.Validate(source);
      element.Source = source ?? element.Source;
      builder.Validate(target);
      element.Target = target ?? element.Target;
      element.Type = type ?? element.Type;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="FakePartyRest"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AirAdventures_BookEvent</term><description>a07f6d1f93531e048928c5c9de328a92</description></item>
    /// <item><term>Cue_0015</term><description>9b70b905e836ed84da3526a021f4d6a2</description></item>
    /// <item><term>WarCamp_GorgoyleAttack</term><description>29990bd61e5e3d84195f4f0d0ae81ec8</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="immediate">
    /// <para>
    /// InfoBox: false - action shows rest UI and start Rest game mode true - action apply rest immediately without starting Rest game mode
    /// </para>
    /// </param>
    public static ActionsBuilder FakePartyRest(
        this ActionsBuilder builder,
        ActionsBuilder? actionsOnRestEnd = null,
        bool? ignoreCorruption = null,
        bool? immediate = null,
        bool? restWithCraft = null)
    {
      var element = ElementTool.Create<FakePartyRest>();
      element.m_ActionsOnRestEnd = actionsOnRestEnd?.Build() ?? element.m_ActionsOnRestEnd;
      if (element.m_ActionsOnRestEnd is null)
      {
        element.m_ActionsOnRestEnd = Utils.Constants.Empty.Actions;
      }
      element.m_IgnoreCorruption = ignoreCorruption ?? element.m_IgnoreCorruption;
      element.m_Immediate = immediate ?? element.m_Immediate;
      element.m_RestWithCraft = restWithCraft ?? element.m_RestWithCraft;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ForceLevelup"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction3</term><description>45c4a84e66b543a298190e1024f3a824</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder ForceLevelup(
        this ActionsBuilder builder,
        ActionsHolder? actions = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<ForceLevelup>();
      builder.Validate(actions);
      element.Actions = actions ?? element.Actions;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="GainExp"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>03_SanctumBosses</term><description>d44f91b07f9914349aa0b6c082d98c25</description></item>
    /// <item><term>Cue_0029</term><description>385f63ce5de55114e9b63099dafd3967</description></item>
    /// <item><term>WatchPoint_SZHouse_Camera</term><description>782f3b6f96c840f99b785c32bdfb5e98</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="customBattlelogMessage">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public static ActionsBuilder GainExp(
        this ActionsBuilder builder,
        IntEvaluator? count = null,
        int? cR = null,
        LocalString? customBattlelogMessage = null,
        bool? dummy = null,
        EncounterType? encounter = null,
        bool? gainPureExp = null,
        float? modifier = null,
        bool? useCustomBattlelogMessage = null)
    {
      var element = ElementTool.Create<GainExp>();
      builder.Validate(count);
      element.Count = count ?? element.Count;
      element.CR = cR ?? element.CR;
      element.CustomBattlelogMessage = customBattlelogMessage?.LocalizedString ?? element.CustomBattlelogMessage;
      if (element.CustomBattlelogMessage is null)
      {
        element.CustomBattlelogMessage = Utils.Constants.Empty.String;
      }
      element.Dummy = dummy ?? element.Dummy;
      element.Encounter = encounter ?? element.Encounter;
      element.GainPureExp = gainPureExp ?? element.GainPureExp;
      element.Modifier = modifier ?? element.Modifier;
      element.UseCustomBattlelogMessage = useCustomBattlelogMessage ?? element.UseCustomBattlelogMessage;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="GainMythicLevel"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BlueprintRoot</term><description>2d77316c72b9ed44f888ceefc2a131f6</description></item>
    /// <item><term>Cue_0038</term><description>b408553de904b1d4ea0878629e02fe4e</description></item>
    /// <item><term>Zacharius_FinalBetrayal_dialogue</term><description>5ec3e47a05de18c46b36f08c8dfbeafb</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder GainMythicLevel(
        this ActionsBuilder builder,
        int? levels = null,
        bool? specificUnit = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<GainMythicLevel>();
      element.Levels = levels ?? element.Levels;
      element.SpecificUnit = specificUnit ?? element.SpecificUnit;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HealParty"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/HealParty
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction 1</term><description>382654689098a824e9c318b2f8139084</description></item>
    /// <item><term>CommandAction2</term><description>36a97593d5af4275954534d4cea9b50f</description></item>
    /// <item><term>Cue_0270</term><description>953d001457113a84cb9e22f62bca3d38</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder HealParty(
        this ActionsBuilder builder,
        UnitEvaluator? healSource = null)
    {
      var element = ElementTool.Create<HealParty>();
      builder.Validate(healSource);
      element.HealSource = healSource ?? element.HealSource;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HealUnit"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/HealUnit
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0015</term><description>72050eac97c4b944f9a99ce16a680f16</description></item>
    /// <item><term>CommandAction1</term><description>6d9657aaeeea4b51ae0cf77de45f6208</description></item>
    /// <item><term>Revival</term><description>3007b582267846e9a66718459f62a0c3</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder HealUnit(
        this ActionsBuilder builder,
        IntEvaluator? healAmount = null,
        UnitEvaluator? source = null,
        UnitEvaluator? target = null,
        bool? toFullHP = null)
    {
      var element = ElementTool.Create<HealUnit>();
      builder.Validate(healAmount);
      element.HealAmount = healAmount ?? element.HealAmount;
      builder.Validate(source);
      element.Source = source ?? element.Source;
      builder.Validate(target);
      element.Target = target ?? element.Target;
      element.ToFullHP = toFullHP ?? element.ToFullHP;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="Kill"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/Kill
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Abad_state_4</term><description>b08d18580c6a4e41b803ca3f48a58c01</description></item>
    /// <item><term>CommandAction 6</term><description>894d85b3b48495342826c255fca4d6b3</description></item>
    /// <item><term>Woljif_Q3_AbandonedMansion_Default</term><description>7a56583bbe8854d44a0d9fde9ee3acee</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder Kill(
        this ActionsBuilder builder,
        bool? critical = null,
        bool? disableBattleLog = null,
        UnitEvaluator? killer = null,
        bool? removeExp = null,
        UnitEvaluator? target = null)
    {
      var element = ElementTool.Create<Kill>();
      element.Critical = critical ?? element.Critical;
      element.DisableBattleLog = disableBattleLog ?? element.DisableBattleLog;
      builder.Validate(killer);
      element.Killer = killer ?? element.Killer;
      element.RemoveExp = removeExp ?? element.RemoveExp;
      builder.Validate(target);
      element.Target = target ?? element.Target;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="LevelUpUnit"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC1_Levelup</term><description>dca1299c933b43dd8078cdf078ee6121</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder LevelUpUnit(
        this ActionsBuilder builder,
        IntEvaluator? targetLevel = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<LevelUpUnit>();
      builder.Validate(targetLevel);
      element.TargetLevel = targetLevel ?? element.TargetLevel;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MeleeAttack"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction</term><description>508cf873310b4d08ac472cf3782cace6</description></item>
    /// <item><term>CommandAction2</term><description>bf98c604a48143c68ccb2fd00e21f3e2</description></item>
    /// <item><term>Cue_3</term><description>33efc09d6531415c965a7de5b9fa3289</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder MeleeAttack(
        this ActionsBuilder builder,
        bool? autoHit = null,
        UnitEvaluator? caster = null,
        bool? ignoreStatBonus = null,
        UnitEvaluator? target = null)
    {
      var element = ElementTool.Create<MeleeAttack>();
      element.AutoHit = autoHit ?? element.AutoHit;
      builder.Validate(caster);
      element.Caster = caster ?? element.Caster;
      element.IgnoreStatBonus = ignoreStatBonus ?? element.IgnoreStatBonus;
      builder.Validate(target);
      element.Target = target ?? element.Target;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PartyUseAbility"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0006</term><description>39c2a30940f0eb24fbda31b5272bff51</description></item>
    /// <item><term>Answer_0017</term><description>2a1c520b0512a0d49a638f026a1fb1c4</description></item>
    /// <item><term>Answer_0068</term><description>9f98ffa7f2c71cb4c9e5da0c7a053876</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder PartyUseAbility(
        this ActionsBuilder builder,
        bool? allowItems = null,
        AbilitiesHelper.AbilityDescription? description = null)
    {
      var element = ElementTool.Create<PartyUseAbility>();
      element.AllowItems = allowItems ?? element.AllowItems;
      builder.Validate(description);
      element.Description = description ?? element.Description;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RaiseDead"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/RaiseDead
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0015</term><description>72050eac97c4b944f9a99ce16a680f16</description></item>
    /// <item><term>Epilogues_afterlogues_dialogue</term><description>57e18f5158904030a84a772fb361ceb4</description></item>
    /// <item><term>ZigguratDeadRomance</term><description>f792eb37f0e41bb4aa23332e892ad6b1</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="companion">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder RaiseDead(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnitReference>? companion = null,
        bool? riseAllCompanions = null)
    {
      var element = ElementTool.Create<RaiseDead>();
      element.m_companion = companion?.Reference ?? element.m_companion;
      if (element.m_companion is null)
      {
        element.m_companion = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      element.riseAllCompanions = riseAllCompanions ?? element.riseAllCompanions;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RandomAction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AasimarSlaveGirlBarks</term><description>efdea0fb268e5e14391ef8bf672f25e5</description></item>
    /// <item><term>GolarionGladiator_Barks</term><description>41a6177759c2d4a419c7da61bace3513</description></item>
    /// <item><term>ZiforianBeggar_Actions</term><description>a741a5da0622e434e9e8da521a34e4e6</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder RandomAction(
        this ActionsBuilder builder,
        ActionAndWeight[]? actions = null,
        bool? calculateSeed = null,
        IntEvaluator? salt = null,
        IntEvaluator? seed = null)
    {
      var element = ElementTool.Create<RandomAction>();
      element.Actions = actions ?? element.Actions;
      if (element.Actions is null)
      {
        element.Actions = new ActionAndWeight[0];
      }
      element.CalculateSeed = calculateSeed ?? element.CalculateSeed;
      builder.Validate(salt);
      element.Salt = salt ?? element.Salt;
      builder.Validate(seed);
      element.Seed = seed ?? element.Seed;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveDeathDoor"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Capter03_Intro_DrezenAreaMechanic</term><description>fc592ded9a9ea4f44808a55c55b299b0</description></item>
    /// <item><term>CommandAction</term><description>5219554519381f749a7b876a73ed0287</description></item>
    /// <item><term>Supplies_Actions_RemoveDathDoor</term><description>784b72fb34265604080c985eef646c2a</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder RemoveDeathDoor(
        this ActionsBuilder builder,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<RemoveDeathDoor>();
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveFact"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AutoAggroBuff_SpawnActions</term><description>68073f3e7d394c56961c6143b20ff8d8</description></item>
    /// <item><term>DLC3_BesmaraMod_IsPB2</term><description>d461960c88b44b4a8d7a4ed3e5bfd143</description></item>
    /// <item><term>Valmallos_Stage2</term><description>511aa03d9a17499d9a6c71e0ab8bd47a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="fact">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder RemoveFact(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnitFactReference>? fact = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<RemoveFact>();
      element.m_Fact = fact?.Reference ?? element.m_Fact;
      if (element.m_Fact is null)
      {
        element.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RollPartySkillCheck"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/SkillCheck Party
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BrokenBridgeAction_Actions</term><description>d58f48230ed845209b8e7e322701e631</description></item>
    /// <item><term>DLC2_Catacombs_AmbushPerception_SZ</term><description>fe1f98f3fe5e4f01be616edf35e80cd7</description></item>
    /// <item><term>ToLevel2_1_CheckFailedActions</term><description>8db94fbf0dac11847b39714bc489baa9</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder RollPartySkillCheck(
        this ActionsBuilder builder,
        int? dC = null,
        bool? logFailure = null,
        bool? logSuccess = null,
        ActionsBuilder? onFailure = null,
        ActionsBuilder? onSuccess = null,
        StatType? stat = null)
    {
      var element = ElementTool.Create<RollPartySkillCheck>();
      element.DC = dC ?? element.DC;
      element.LogFailure = logFailure ?? element.LogFailure;
      element.LogSuccess = logSuccess ?? element.LogSuccess;
      element.OnFailure = onFailure?.Build() ?? element.OnFailure;
      if (element.OnFailure is null)
      {
        element.OnFailure = Utils.Constants.Empty.Actions;
      }
      element.OnSuccess = onSuccess?.Build() ?? element.OnSuccess;
      if (element.OnSuccess is null)
      {
        element.OnSuccess = Utils.Constants.Empty.Actions;
      }
      element.Stat = stat ?? element.Stat;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RollSkillCheck"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/SkillCheck
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CheckFailedActionsDamageParty(3d6)AttachProneToAllDC31</term><description>221d9fceb641dc24da55cce775d86937</description></item>
    /// <item><term>CommandAction 5</term><description>aba52c9d17f9c534e86ba5a41486b354</description></item>
    /// <item><term>DoorBark</term><description>5d43a8c010054c7698e21b5d4b8bfa2d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="forbidPartyHelpInCamp">
    /// <para>
    /// InfoBox: In capital and camp all rolls are made by party (by default). Set to true to prevent it
    /// </para>
    /// </param>
    public static ActionsBuilder RollSkillCheck(
        this ActionsBuilder builder,
        int? dC = null,
        bool? forbidPartyHelpInCamp = null,
        bool? logFailure = null,
        bool? logSuccess = null,
        ActionsBuilder? onFailure = null,
        ActionsBuilder? onSuccess = null,
        StatType? stat = null,
        UnitEvaluator? unit = null,
        bool? voice = null)
    {
      var element = ElementTool.Create<RollSkillCheck>();
      element.DC = dC ?? element.DC;
      element.ForbidPartyHelpInCamp = forbidPartyHelpInCamp ?? element.ForbidPartyHelpInCamp;
      element.LogFailure = logFailure ?? element.LogFailure;
      element.LogSuccess = logSuccess ?? element.LogSuccess;
      element.OnFailure = onFailure?.Build() ?? element.OnFailure;
      if (element.OnFailure is null)
      {
        element.OnFailure = Utils.Constants.Empty.Actions;
      }
      element.OnSuccess = onSuccess?.Build() ?? element.OnSuccess;
      if (element.OnSuccess is null)
      {
        element.OnSuccess = Utils.Constants.Empty.Actions;
      }
      element.Stat = stat ?? element.Stat;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      element.Voice = voice ?? element.Voice;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RunActionHolder"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Add_2_Anevia</term><description>1416247b0d6a45943aa58c58b4205cef</description></item>
    /// <item><term>Cue_0085</term><description>322a030bba9bf6f47ba9a7fe6777c12f</description></item>
    /// <item><term>ZigguratSkeletonsUrgathoa</term><description>d2913b3385ef71e418e05eb76bd6265b</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="holder">
    /// <para>
    /// Blueprint of type ActionsHolder. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder RunActionHolder(
        this ActionsBuilder builder,
        string? comment = null,
        Blueprint<ActionsReference>? holder = null,
        ParametrizedContextSetter? parameters = null)
    {
      var element = ElementTool.Create<RunActionHolder>();
      element.Comment = comment ?? element.Comment;
      element.Holder = holder?.Reference ?? element.Holder;
      if (element.Holder is null)
      {
        element.Holder = BlueprintTool.GetRef<ActionsReference>(null);
      }
      builder.Validate(parameters);
      element.Parameters = parameters ?? element.Parameters;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="Spawn"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/Spawn
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>2Xantir_AreaTransition</term><description>e9b7f82f10b54e4bb624d523a4b3306a</description></item>
    /// <item><term>CommandAction 6</term><description>1d7713980eae62e4a5368b74eb121afb</description></item>
    /// <item><term>ZigguratDeadRomance</term><description>f792eb37f0e41bb4aa23332e892ad6b1</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="respawnIfDead">
    /// <para>
    /// InfoBox: By default dead units are not respawned. This option ignores RespawnIfDead on spawner
    /// </para>
    /// </param>
    public static ActionsBuilder Spawn(
        this ActionsBuilder builder,
        ActionsBuilder? actionsOnSpawn = null,
        bool? respawnIfDead = null,
        EntityReference[]? spawners = null)
    {
      var element = ElementTool.Create<Spawn>();
      element.ActionsOnSpawn = actionsOnSpawn?.Build() ?? element.ActionsOnSpawn;
      if (element.ActionsOnSpawn is null)
      {
        element.ActionsOnSpawn = Utils.Constants.Empty.Actions;
      }
      element.RespawnIfDead = respawnIfDead ?? element.RespawnIfDead;
      builder.Validate(spawners);
      element.Spawners = spawners ?? element.Spawners;
      if (element.Spawners is null)
      {
        element.Spawners = new EntityReference[0];
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SpawnBySummonPool"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>1ArenaCombat</term><description>8e64ed1e12bc30c498402e99c95e75e3</description></item>
    /// <item><term>CommandAction1</term><description>e9ee9e54830640999c83b81f97913dfe</description></item>
    /// <item><term>ZombiesOnStreets</term><description>ffcf5bca11694784686d9947ed226a88</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="pool">
    /// <para>
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder SpawnBySummonPool(
        this ActionsBuilder builder,
        ActionsBuilder? actionsOnSpawn = null,
        bool? ignoreSpawnerConditions = null,
        Blueprint<BlueprintSummonPoolReference>? pool = null)
    {
      var element = ElementTool.Create<SpawnBySummonPool>();
      element.ActionsOnSpawn = actionsOnSpawn?.Build() ?? element.ActionsOnSpawn;
      if (element.ActionsOnSpawn is null)
      {
        element.ActionsOnSpawn = Utils.Constants.Empty.Actions;
      }
      element.m_IgnoreSpawnerConditions = ignoreSpawnerConditions ?? element.m_IgnoreSpawnerConditions;
      element.m_Pool = pool?.Reference ?? element.m_Pool;
      if (element.m_Pool is null)
      {
        element.m_Pool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SpawnByUnitGroup"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon_AxiomitesAndInevitable</term><description>0e9add6a45f445cf8a9f9c71ea2d789d</description></item>
    /// <item><term>CommandAction2</term><description>41442c14c08545e4ab8d61b599b2407c</description></item>
    /// <item><term>ZigguratRiot</term><description>5ecb3695c95e4bd4b836a0deac1ecfd7</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder SpawnByUnitGroup(
        this ActionsBuilder builder,
        ActionsBuilder? actionsOnSpawn = null,
        EntityReference? group = null)
    {
      var element = ElementTool.Create<SpawnByUnitGroup>();
      element.ActionsOnSpawn = actionsOnSpawn?.Build() ?? element.ActionsOnSpawn;
      if (element.ActionsOnSpawn is null)
      {
        element.ActionsOnSpawn = Utils.Constants.Empty.Actions;
      }
      builder.Validate(group);
      element.Group = group ?? element.Group;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="Summon"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BattleBliss_Guards</term><description>3ba5f66ac34f8e846acb60750095ca07</description></item>
    /// <item><term>CommandAction 3</term><description>80d3dddabda52d84cafaaba7f5b86ceb</description></item>
    /// <item><term>ZigguratZachariusInZiggurat</term><description>2844d387f27a0bb468f72603dd15eda2</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="summonPool">
    /// <para>
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="unit">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder Summon(
        this ActionsBuilder builder,
        bool? groupBySummonPool = null,
        Vector3? offset = null,
        ActionsBuilder? onSummmon = null,
        bool? placeNearWhenBusy = null,
        Blueprint<BlueprintSummonPoolReference>? summonPool = null,
        TransformEvaluator? transform = null,
        Blueprint<BlueprintUnitReference>? unit = null)
    {
      var element = ElementTool.Create<Summon>();
      element.GroupBySummonPool = groupBySummonPool ?? element.GroupBySummonPool;
      element.Offset = offset ?? element.Offset;
      element.OnSummmon = onSummmon?.Build() ?? element.OnSummmon;
      if (element.OnSummmon is null)
      {
        element.OnSummmon = Utils.Constants.Empty.Actions;
      }
      element.m_PlaceNearWhenBusy = placeNearWhenBusy ?? element.m_PlaceNearWhenBusy;
      element.m_SummonPool = summonPool?.Reference ?? element.m_SummonPool;
      if (element.m_SummonPool is null)
      {
        element.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      builder.Validate(transform);
      element.Transform = transform ?? element.Transform;
      element.m_Unit = unit?.Reference ?? element.m_Unit;
      if (element.m_Unit is null)
      {
        element.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SummonPoolUnits"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/SummonPoolUnits
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>1ArenaCombat</term><description>8e64ed1e12bc30c498402e99c95e75e3</description></item>
    /// <item><term>CommandAction2</term><description>4486e3afc7bc44fa8058e10e22220268</description></item>
    /// <item><term>ZombiesOnStreets</term><description>ffcf5bca11694784686d9947ed226a88</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="summonPool">
    /// <para>
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder SummonPoolUnits(
        this ActionsBuilder builder,
        ActionsBuilder? actions = null,
        ConditionsBuilder? conditions = null,
        Blueprint<BlueprintSummonPoolReference>? summonPool = null)
    {
      var element = ElementTool.Create<SummonPoolUnits>();
      element.Actions = actions?.Build() ?? element.Actions;
      if (element.Actions is null)
      {
        element.Actions = Utils.Constants.Empty.Actions;
      }
      element.Conditions = conditions?.Build() ?? element.Conditions;
      if (element.Conditions is null)
      {
        element.Conditions = Utils.Constants.Empty.Conditions;
      }
      element.m_SummonPool = summonPool?.Reference ?? element.m_SummonPool;
      if (element.m_SummonPool is null)
      {
        element.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SummonUnitCopy"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CamelliaQ2</term><description>ab6e8c0132ddd2a4495408cfacb660f7</description></item>
    /// <item><term>CommandAction2</term><description>3a3b18e62f6d43b0bc3e57f0c3a7fa50</description></item>
    /// <item><term>KenabresInThePast_Beginning</term><description>28ad9f1ffbb3a454d93ad3573e8b62af</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="copyBlueprint">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="summonPool">
    /// <para>
    /// Blueprint of type BlueprintSummonPool. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder SummonUnitCopy(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnitReference>? copyBlueprint = null,
        UnitEvaluator? copyFrom = null,
        bool? doNotCreateItems = null,
        LocatorEvaluator? locator = null,
        ActionsBuilder? onSummon = null,
        Blueprint<BlueprintSummonPoolReference>? summonPool = null)
    {
      var element = ElementTool.Create<SummonUnitCopy>();
      element.m_CopyBlueprint = copyBlueprint?.Reference ?? element.m_CopyBlueprint;
      if (element.m_CopyBlueprint is null)
      {
        element.m_CopyBlueprint = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      builder.Validate(copyFrom);
      element.CopyFrom = copyFrom ?? element.CopyFrom;
      element.DoNotCreateItems = doNotCreateItems ?? element.DoNotCreateItems;
      builder.Validate(locator);
      element.Locator = locator ?? element.Locator;
      element.OnSummon = onSummon?.Build() ?? element.OnSummon;
      if (element.OnSummon is null)
      {
        element.OnSummon = Utils.Constants.Empty.Actions;
      }
      element.m_SummonPool = summonPool?.Reference ?? element.m_SummonPool;
      if (element.m_SummonPool is null)
      {
        element.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SwitchActivatableAbility"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction</term><description>4fa67e84c3ddbd5448debce210a6d7b6</description></item>
    /// <item><term>Cue_0063</term><description>d611e716c4ceac643b68bad6416678f9</description></item>
    /// <item><term>NamelessRuins_Default_Preset</term><description>cf3ca9742b488b94daeb3083d41e2cfa</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="ability">
    /// <para>
    /// Blueprint of type BlueprintActivatableAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder SwitchActivatableAbility(
        this ActionsBuilder builder,
        Blueprint<BlueprintActivatableAbilityReference>? ability = null,
        bool? isOn = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<SwitchActivatableAbility>();
      element.m_Ability = ability?.Reference ?? element.m_Ability;
      if (element.m_Ability is null)
      {
        element.m_Ability = BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(null);
      }
      element.IsOn = isOn ?? element.IsOn;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitsFromSpawnersInUnitGroup"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aeon_AxiomitesAndInevitable</term><description>0e9add6a45f445cf8a9f9c71ea2d789d</description></item>
    /// <item><term>Cue_0012</term><description>e5b6a3b105d0ea94da93642b85e08bdf</description></item>
    /// <item><term>YouOnlyMortalsCombatStart_Actions</term><description>9ee2523b28aa61e498d1eb0ef8ea3b3c</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder UnitsFromSpawnersInUnitGroup(
        this ActionsBuilder builder,
        ActionsBuilder? actions = null,
        EntityReference? group = null)
    {
      var element = ElementTool.Create<UnitsFromSpawnersInUnitGroup>();
      element.Actions = actions?.Build() ?? element.Actions;
      if (element.Actions is null)
      {
        element.Actions = Utils.Constants.Empty.Actions;
      }
      builder.Validate(group);
      element.m_Group = group ?? element.m_Group;
      return builder.Add(element);
    }
  }
}
