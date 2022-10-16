//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Capital;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Corruption;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Dungeon.Actions;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Persistence;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Actions.Builder.AreaEx
{
  /// <summary>
  /// Extension to <see cref="ActionsBuilder"/> for actions involving the game map, dungeons, or locations. See also <see cref="KingdomEx.ActionsBuilderKingdomEx">KingdomEx</see>.
  /// </summary>
  /// <inheritdoc cref="ActionsBuilder"/>
  public static class ActionsBuilderAreaEx
  {

    /// <summary>
    /// Adds <see cref="AddCampingEncounter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0247</term><description>ac5dd1491a051a64b9bc4ff283c8b128</description></item>
    /// <item><term>LannRomance_LannTrue2</term><description>6a13b7c436f5fb548b6475106d88de1c</description></item>
    /// <item><term>WenduagRomance</term><description>39c388b5f2ab0f14b90030bab1b676b9</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="encounter">
    /// <para>
    /// Blueprint of type BlueprintCampingEncounter. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder AddCampingEncounter(
        this ActionsBuilder builder,
        Blueprint<BlueprintCampingEncounterReference> encounter)
    {
      var element = ElementTool.Create<AddCampingEncounter>();
      element.m_Encounter = encounter?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ChangeCurrentAreaName"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AreeluLabFalseName</term><description>2bbe2729cac14033a4aa094f2df60fdc</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="newName">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public static ActionsBuilder ChangeCurrentAreaName(
        this ActionsBuilder builder,
        LocalString newName)
    {
      var element = ElementTool.Create<ChangeCurrentAreaName>();
      element.NewName = newName?.LocalizedString;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ChangeCurrentAreaName"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AreeluLabFalseName</term><description>2bbe2729cac14033a4aa094f2df60fdc</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder ResetCurrentAreaName(this ActionsBuilder builder)
    {
      var element = ElementTool.Create<ChangeCurrentAreaName>();
      element.RestoreDefault = true;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AskPlayerForLocationName"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Cue_0045</term><description>f14bee80a5921d74b99835f2f58986c7</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="defaultValue">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    /// <param name="hint">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    /// <param name="location">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="title">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public static ActionsBuilder AskPlayerForLocationName(
        this ActionsBuilder builder,
        LocalString? defaultValue = null,
        LocalString? hint = null,
        Blueprint<BlueprintGlobalMapPoint.Reference>? location = null,
        bool? obligatory = null,
        LocalString? title = null)
    {
      var element = ElementTool.Create<AskPlayerForLocationName>();
      element.Default = defaultValue?.LocalizedString ?? element.Default;
      if (element.Default is null)
      {
        element.Default = Utils.Constants.Empty.String;
      }
      element.Hint = hint?.LocalizedString ?? element.Hint;
      if (element.Hint is null)
      {
        element.Hint = Utils.Constants.Empty.String;
      }
      element.m_Location = location?.Reference ?? element.m_Location;
      if (element.m_Location is null)
      {
        element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
      }
      element.Obligatory = obligatory ?? element.Obligatory;
      element.Title = title?.LocalizedString ?? element.Title;
      if (element.Title is null)
      {
        element.Title = Utils.Constants.Empty.String;
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CapitalExit"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>2Alushinyrra_Transition</term><description>33cfb285cf8bfa34ca1279106ab9446d</description></item>
    /// <item><term>DefendersHeart_ToGlobalMap1</term><description>747235f613a4a704fa86ecc2c081e0cb</description></item>
    /// <item><term>WarCamp_ToGlobalMap</term><description>2f34d3bdede6897419a34c7eb7f97784</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="destination">
    /// <para>
    /// Blueprint of type BlueprintAreaEnterPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder CapitalExit(
        this ActionsBuilder builder,
        AutoSaveMode? autoSaveMode = null,
        Blueprint<BlueprintAreaEnterPointReference>? destination = null)
    {
      var element = ElementTool.Create<CapitalExit>();
      element.AutoSaveMode = autoSaveMode ?? element.AutoSaveMode;
      element.m_Destination = destination?.Reference ?? element.m_Destination;
      if (element.m_Destination is null)
      {
        element.m_Destination = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DecreaseCorruptionLevelAction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AreeluLab_CorruptionReducer_Cleanse8_CheckPassedActions</term><description>a1354f7a7921ec743938e2146aca0743</description></item>
    /// <item><term>GrayGarrison_CorruptionReducer_Cleanse_CheckPassedActions</term><description>88447572d376422439e3510d3d830a6f</description></item>
    /// <item><term>Ziggurat_CorruptionReducer_Cleanse_CheckPassedActions</term><description>a53e004ccda24065b81f49c9ee3b0e49</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder DecreaseCorruptionLevelAction(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<DecreaseCorruptionLevelAction>());
    }

    /// <summary>
    /// Adds <see cref="DLC3CampaignMap"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/CampaignMap
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_NoTier_NextIsland_Actions</term><description>576a6aa6c0ea4342a67fc8423d0d7d2d</description></item>
    /// <item><term>DLC3_Tier_2_NextIsland_Actions</term><description>caf83c3f65df4c5595a51fb2fa1d41d1</description></item>
    /// <item><term>DLC3_Tier_3_NextIsland_Actions</term><description>d380e23062864561b6963f9eaf691e9b</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder DLC3CampaignMap(
        this ActionsBuilder builder,
        int? tierIndex = null)
    {
      var element = ElementTool.Create<DLC3CampaignMap>();
      element.TierIndex = tierIndex ?? element.TierIndex;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DungeonFinishCurrentIsland"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_ToxicPrison_Exit</term><description>cb065eb340a74c61b2d805109cff19c1</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder DungeonFinishCurrentIsland(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<DungeonFinishCurrentIsland>());
    }

    /// <summary>
    /// Adds <see cref="DungeonLevelUpNextCharacter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_RewardStatueLegacy_Actions</term><description>a84bfcbb31f444078e18484061dd66f2</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder DungeonLevelUpNextCharacter(
        this ActionsBuilder builder,
        IntEvaluator? advancedLevels = null)
    {
      var element = ElementTool.Create<DungeonLevelUpNextCharacter>();
      builder.Validate(advancedLevels);
      element.AdvancedLevels = advancedLevels ?? element.AdvancedLevels;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DungeonLoadBossHealth"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction</term><description>fb8eab9f4c5e400ab38562ae491f843e</description></item>
    /// <item><term>CommandAction17</term><description>ce866e9058514c4fab0de44752baed52</description></item>
    /// <item><term>CommandSpawnUnits1</term><description>ddb2b653994048bcb83bac85b5b8dff6</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder DungeonLoadBossHealth(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<DungeonLoadBossHealth>());
    }

    /// <summary>
    /// Adds <see cref="DungeonMoveToNextExpedition"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction4</term><description>4d5ef33e94fb415d9ffd1848b9218986</description></item>
    /// <item><term>Next_expidition</term><description>35a9bd65fd264c358d9ee8b70a1b8369</description></item>
    /// <item><term>Next_expidition_Tier_3</term><description>70b3311941cc4d1a9b5a37790b5e5bb9</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder DungeonMoveToNextExpedition(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<DungeonMoveToNextExpedition>());
    }

    /// <summary>
    /// Adds <see cref="DungeonOverrideBesmaritToBossLocation"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_BesmarQuest_PT2</term><description>513f653affb04035b879406578334d2e</description></item>
    /// <item><term>DungeonRoot</term><description>096f36d4e55b49129ddd2211b2c50513</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder DungeonOverrideBesmaritToBossLocation(
        this ActionsBuilder builder,
        bool? overrideValue = null)
    {
      var element = ElementTool.Create<DungeonOverrideBesmaritToBossLocation>();
      element.Override = overrideValue ?? element.Override;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DungeonRewardReveal"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_DungeonReward_SZ</term><description>38dfa89689804c08a1f31debe136353c</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder DungeonRewardReveal(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<DungeonRewardReveal>());
    }

    /// <summary>
    /// Adds <see cref="DungeonRunActionHolderForNextParty"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_AlushinyrraWhorehouse_Portal</term><description>4319d090d03444d68b8d8ffe41b875ea</description></item>
    /// <item><term>DLC3_Kohh_Portal</term><description>9a97d36c8b1b4f5396518e7828aae78e</description></item>
    /// <item><term>DLC3_ToxicPrison_Portal</term><description>d6ccd4dba45a438bb859a074bd0c43e7</description></item>
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
    public static ActionsBuilder DungeonRunActionHolderForNextParty(
        this ActionsBuilder builder,
        string? comment = null,
        Blueprint<ActionsReference>? holder = null)
    {
      var element = ElementTool.Create<DungeonRunActionHolderForNextParty>();
      element.Comment = comment ?? element.Comment;
      element.Holder = holder?.Reference ?? element.Holder;
      if (element.Holder is null)
      {
        element.Holder = BlueprintTool.GetRef<ActionsReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DungeonSaveBossHealth"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Balor_save_health</term><description>ad452511a21544c384af7d640ceb105b</description></item>
    /// <item><term>DarkBalorFight_HideUnits</term><description>5bc605a8f4624ec08d857dcc52378eb5</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder DungeonSaveBossHealth(
        this ActionsBuilder builder,
        bool? reset = null)
    {
      var element = ElementTool.Create<DungeonSaveBossHealth>();
      element.Reset = reset ?? element.Reset;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DungeonSetModificatorIcon"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_Int_Tier_1_Island_10</term><description>9a1e689e6c0046eba81b05be0086442a</description></item>
    /// <item><term>DLC3_Int_Tier_2_Island_2</term><description>9673a525df1d4f0aa659f7a3191cd444</description></item>
    /// <item><term>DLC3_Int_Tier_3_Island_6</term><description>d6dcb7d0e14949dcab6343d4d89e8860</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="modificators">
    /// <para>
    /// Blueprint of type BlueprintDungeonModificator. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder DungeonSetModificatorIcon(this ActionsBuilder builder, params Blueprint<BlueprintDungeonModificatorReference>[] modificators)
    {
      var element = ElementTool.Create<DungeonSetModificatorIcon>();
      element.m_Modificators = modificators.Select(bp => bp.Reference).ToArray();
      if (element.m_Modificators is null)
      {
        element.m_Modificators = new BlueprintDungeonModificatorReference[0];
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DungeonShowBoons"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction2</term><description>f2dfaee4521342c9bb777feecfa943a3</description></item>
    /// <item><term>CommandAction2</term><description>97a69941c5ca4083ae319769dbd23934</description></item>
    /// <item><term>CommandAction2</term><description>7c90919f3e8745ae9920fd81e2d6a80b</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder DungeonShowBoons(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<DungeonShowBoons>());
    }

    /// <summary>
    /// Adds <see cref="DungeonShowMap"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Map_interaction</term><description>118c96de738b4bc8a91ba59de1173acc</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder DungeonShowMap(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<DungeonShowMap>());
    }

    /// <summary>
    /// Adds <see cref="DungeonShowResults"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0010</term><description>2a963629dcc546698375453a9f1f6c87</description></item>
    /// <item><term>CommandAction5</term><description>7b931f2bde4b4000a856621e3daa7e3a</description></item>
    /// <item><term>Cue_38</term><description>f0d4fe8dc81c4d78a52c94b3e93fe43b</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder DungeonShowResults(
        this ActionsBuilder builder,
        DungeonShowResults.Result? result = null)
    {
      var element = ElementTool.Create<DungeonShowResults>();
      element.result = result ?? element.result;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="EndAreaEffects"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction</term><description>c2fba818bb632aa4bb5908337b9f5b51</description></item>
    /// <item><term>CommandAction</term><description>4286b17faaf948f79bad431506aad27f</description></item>
    /// <item><term>FourthPart</term><description>24417ce44ab52e24388edd18d6b5e115</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="areaEffects">
    /// <para>
    /// Blueprint of type BlueprintAbilityAreaEffect. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder EndAreaEffects(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintAbilityAreaEffectReference>>? areaEffects = null,
        EndAreaEffects.FilterType? filter = null,
        AreaEffectTags? tags = null)
    {
      var element = ElementTool.Create<EndAreaEffects>();
      element.m_AreaEffects = areaEffects?.Select(bp => bp.Reference)?.ToArray() ?? element.m_AreaEffects;
      if (element.m_AreaEffects is null)
      {
        element.m_AreaEffects = new BlueprintAbilityAreaEffectReference[0];
      }
      element.m_Filter = filter ?? element.m_Filter;
      element.m_Tags = tags ?? element.m_Tags;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="GameActionSetIsleLock"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Angel_TargonnaTrip_Mechanic</term><description>da4b0127f31252242bea430ccc7f020f</description></item>
    /// <item><term>FlyingIsles_VellexiaIslandZone</term><description>d8fa3f9825f8014408b99080a126ba65</description></item>
    /// <item><term>ToLootBack_CheckPassedActions</term><description>1ba08cf9dd9e4f02837a335081f3b44d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="isLock">
    /// <para>
    /// Tooltip: If true - isle will be lock, else will unlock
    /// </para>
    /// <para>
    /// InfoBox: Note: Locking should be launched once, or it will lock isle forever! And lock-unlock should be launched on area with isle, or it wont work!
    /// </para>
    /// </param>
    public static ActionsBuilder GameActionSetIsleLock(
        this ActionsBuilder builder,
        IsleEvaluator? isle = null,
        bool? isLock = null)
    {
      var element = ElementTool.Create<GameActionSetIsleLock>();
      builder.Validate(isle);
      element.m_Isle = isle ?? element.m_Isle;
      element.m_IsLock = isLock ?? element.m_IsLock;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="GameActionSetIsleState"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AlushinyrraFleshmarketMultiEntranceEntry</term><description>52c989e280833b44e818f63fd147b287</description></item>
    /// <item><term>FlyingIsles_StorytellerIslandZone</term><description>2bfc5644f7ba1844a97e24ca798c955b</description></item>
    /// <item><term>ShamiraHouseExit</term><description>13a0bf2ece5ccbe41b0be9c6312c29b8</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder GameActionSetIsleState(
        this ActionsBuilder builder,
        IsleEvaluator? isle = null,
        string? stateName = null)
    {
      var element = ElementTool.Create<GameActionSetIsleState>();
      builder.Validate(isle);
      element.m_Isle = isle ?? element.m_Isle;
      element.m_StateName = stateName ?? element.m_StateName;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="GlobalMapTeleport"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0003</term><description>e4bf5e3beae06ca4da6dfa1191026031</description></item>
    /// <item><term>GrayGarrison_FinalSiege</term><description>65d1f8bdc93f3234e9e7537c172336a6</description></item>
    /// <item><term>WorldWoundGMReturn2KenabresTestPreset</term><description>bc2c980845879dd4fa97f97cb9dadb0b</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder GlobalMapTeleport(
        this ActionsBuilder builder,
        LocationEvaluator? destination = null,
        FloatEvaluator? skipHours = null,
        bool? updateLocationVisitedTime = null)
    {
      var element = ElementTool.Create<GlobalMapTeleport>();
      builder.Validate(destination);
      element.Destination = destination ?? element.Destination;
      builder.Validate(skipHours);
      element.SkipHours = skipHours ?? element.SkipHours;
      element.UpdateLocationVisitedTime = updateLocationVisitedTime ?? element.UpdateLocationVisitedTime;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="HideMapObject"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/HideMapObject
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>02_TargonaSearch</term><description>34246eb4ed22ea44cb2e84c278d9e14d</description></item>
    /// <item><term>DragonFalseTreasures_Actions</term><description>dd1c93a0ce6e49a5b1fe496b99b5108f</description></item>
    /// <item><term>ZigguratUpgradedInside</term><description>e531191d4ecff7b44a18f614b5ec1e1a</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder HideMapObject(
        this ActionsBuilder builder,
        MapObjectEvaluator? mapObject = null,
        bool? unhide = null)
    {
      var element = ElementTool.Create<HideMapObject>();
      builder.Validate(mapObject);
      element.MapObject = mapObject ?? element.MapObject;
      element.Unhide = unhide ?? element.Unhide;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="LocalMapSetDirty"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/LocalMapSetDirty
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Alushinyrra_HigherCity_MainIsland_FirstStateEnter</term><description>31588bd2dcef49b7a09b340df68696aa</description></item>
    /// <item><term>Alushinyrra_MediumCity_MainIsland_FirstStateEnter</term><description>6fec3b8d9ad74ed8a9b09631a01f09c4</description></item>
    /// <item><term>Elevator_CheckFailedActions</term><description>ee8ceb87afe04362917bdeea08b8558f</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder LocalMapSetDirty(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<LocalMapSetDirty>());
    }

    /// <summary>
    /// Adds <see cref="MakeServiceCaster"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_SpellService</term><description>b51f4e2d99ff4c889a665b6a195596de</description></item>
    /// <item><term>Nexus_DivineService</term><description>be1c434716bd35e4bba2c5631ca77ee3</description></item>
    /// <item><term>WarCamp_EarlyBeginning</term><description>4be1dcbb5f0a05f43b8915e14251b76c</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder MakeServiceCaster(
        this ActionsBuilder builder,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<MakeServiceCaster>();
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MarkLocationClosed"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonKenabresRebuilded</term><description>470c835355608c34fa4571ba4f65cbc3</description></item>
    /// <item><term>DLC3_TwilightWaters</term><description>b5779a222f98475b87ffb13337cdffda</description></item>
    /// <item><term>TheBridgeIsBuilt</term><description>048ce8550994326429f73b6119270293</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="location">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder MarkLocationClosed(
        this ActionsBuilder builder,
        bool? closed = null,
        Blueprint<BlueprintGlobalMapPoint.Reference>? location = null)
    {
      var element = ElementTool.Create<MarkLocationClosed>();
      element.Closed = closed ?? element.Closed;
      element.m_Location = location?.Reference ?? element.m_Location;
      if (element.m_Location is null)
      {
        element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MarkLocationExplored"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0122</term><description>789e5370d3e5ccc4cac43c204b42b373</description></item>
    /// <item><term>RedDragonDead</term><description>581521b398fb9dd4eb52bbfffb3b5c43</description></item>
    /// <item><term>VerbovezzorGM_Bookevent_Passed</term><description>5a7a6b17e3bab57498006ab622e99284</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="location">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder MarkLocationExplored(
        this ActionsBuilder builder,
        bool? explored = null,
        Blueprint<BlueprintGlobalMapPoint.Reference>? location = null)
    {
      var element = ElementTool.Create<MarkLocationExplored>();
      element.Explored = explored ?? element.Explored;
      element.m_Location = location?.Reference ?? element.m_Location;
      if (element.m_Location is null)
      {
        element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MarkOnLocalMap"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/MarkOnLocalMap
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Cue_0016</term><description>70f77f3074555b740b28a98256a9f680</description></item>
    /// <item><term>Cue_0018</term><description>48a30933475067546ab008bdf5ee3c87</description></item>
    /// <item><term>Greybor_Q2_Acepted</term><description>efeba5b983e4ad446b4919cdcf4bfdeb</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder MarkOnLocalMap(
        this ActionsBuilder builder,
        bool? hidden = null,
        MapObjectEvaluator? mapObject = null)
    {
      var element = ElementTool.Create<MarkOnLocalMap>();
      element.Hidden = hidden ?? element.Hidden;
      builder.Validate(mapObject);
      element.MapObject = mapObject ?? element.MapObject;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="OpenLootContainer"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/OpenLootContainer
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CombineS_1_1</term><description>ecd04cedec8a498cb07d1c50951d0310</description></item>
    /// <item><term>CombineS_3_5</term><description>a142978194ec4efa894b16194e659a55</description></item>
    /// <item><term>SecretCompartment_Actions</term><description>9fa9b3ba43252124ba4021816436cdbd</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder OpenLootContainer(
        this ActionsBuilder builder,
        MapObjectEvaluator? mapObject = null)
    {
      var element = ElementTool.Create<OpenLootContainer>();
      builder.Validate(mapObject);
      element.MapObject = mapObject ?? element.MapObject;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="OpenOutgoingEdgesOnGlobalMap"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyWorldWound</term><description>b4fae6a8d0ad427d90283bf665908e05</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder OpenOutgoingEdgesOnGlobalMap(
        this ActionsBuilder builder,
        bool? onlyForVisited = null)
    {
      var element = ElementTool.Create<OpenOutgoingEdgesOnGlobalMap>();
      element.m_OnlyForVisited = onlyForVisited ?? element.m_OnlyForVisited;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveAmbush"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CarnivorousCrystal_Buff_Freeze</term><description>65668390437fa744683e61c7b2ae119d</description></item>
    /// <item><term>CommandAction 3</term><description>7977c68c9cf5be244985f0dd07fcf86b</description></item>
    /// <item><term>MimicPolymorphVisualBuff</term><description>b2698f67038156f48984c6bd02a7a88c</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder RemoveAmbush(
        this ActionsBuilder builder,
        bool? exitStealth = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<RemoveAmbush>();
      element.m_ExitStealth = exitStealth ?? element.m_ExitStealth;
      builder.Validate(unit);
      element.m_Unit = unit ?? element.m_Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveAreaFromSave"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Chapter01</term><description>df17ab913c348644b9bd3fe3f9781a84</description></item>
    /// <item><term>Chapter03</term><description>15e0048c7daf0ac4999c2313b58df0e3</description></item>
    /// <item><term>Chapter04</term><description>637a57423a82b044f888677c92f5d6cb</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="area">
    /// <para>
    /// Blueprint of type BlueprintArea. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="specificMechanic">
    /// <para>
    /// Blueprint of type BlueprintAreaMechanics. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder RemoveAreaFromSave(
        this ActionsBuilder builder,
        Blueprint<BlueprintAreaReference>? area = null,
        Blueprint<BlueprintAreaMechanicsReference>? specificMechanic = null)
    {
      var element = ElementTool.Create<RemoveAreaFromSave>();
      element.m_Area = area?.Reference ?? element.m_Area;
      if (element.m_Area is null)
      {
        element.m_Area = BlueprintTool.GetRef<BlueprintAreaReference>(null);
      }
      element.SpecificMechanic = specificMechanic?.Reference ?? element.SpecificMechanic;
      if (element.SpecificMechanic is null)
      {
        element.SpecificMechanic = BlueprintTool.GetRef<BlueprintAreaMechanicsReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveCampingEncounter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArueshalaeAfterLab_CampingEncounter</term><description>b1501473507eb00418ab14db5fd9f23a</description></item>
    /// <item><term>Locust_DeskariDream</term><description>dfbc6d9a48144c08b3172e6aebe38310</description></item>
    /// <item><term>WenduRom_SomeThingsAboutMyFather_CampingEncounter</term><description>a659923cdc1497044a2e385212c114f6</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="encounter">
    /// <para>
    /// Blueprint of type BlueprintCampingEncounter. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder RemoveCampingEncounter(
        this ActionsBuilder builder,
        Blueprint<BlueprintCampingEncounterReference>? encounter = null)
    {
      var element = ElementTool.Create<RemoveCampingEncounter>();
      element.m_Encounter = encounter?.Reference ?? element.m_Encounter;
      if (element.m_Encounter is null)
      {
        element.m_Encounter = BlueprintTool.GetRef<BlueprintCampingEncounterReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RevealGlobalMap"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BookPage_0020</term><description>01e99c8eeb4cf51448287f17d6a71b97</description></item>
    /// <item><term>KenabresMapRevealAllPreset</term><description>da444f1dce68ef343ba4a1909ee35555</description></item>
    /// <item><term>WorldWoundGMReturn2KenabresTestPreset</term><description>bc2c980845879dd4fa97f97cb9dadb0b</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="points">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder RevealGlobalMap(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintGlobalMapPoint.Reference>>? points = null,
        bool? revealEdges = null)
    {
      var element = ElementTool.Create<RevealGlobalMap>();
      element.Points = points?.Select(bp => bp.Reference)?.ToArray() ?? element.Points;
      if (element.Points is null)
      {
        element.Points = new BlueprintGlobalMapPoint.Reference[0];
      }
      element.RevealEdges = revealEdges ?? element.RevealEdges;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ScriptZoneActivate"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/ScriptZoneActivate
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AddAeonEyeActionsHolder</term><description>c6738bf1a8f74dc8b0a1762a721e1eb6</description></item>
    /// <item><term>CommandAction7</term><description>ac9df44f8e2c47e596f6c5f37cdad048</description></item>
    /// <item><term>WoundWormLair_Event_Mechanics</term><description>fa1e44ec4639c4242b745b9b7c72cc03</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="scriptZoneEvaluator">
    /// <para>
    /// InfoBox: NOTE: Should evaluate scriptZone!
    /// </para>
    /// </param>
    public static ActionsBuilder ScriptZoneActivate(
        this ActionsBuilder builder,
        EntityReference? scriptZone = null,
        MapObjectEvaluator? scriptZoneEvaluator = null,
        bool? useEvaluator = null)
    {
      var element = ElementTool.Create<ScriptZoneActivate>();
      builder.Validate(scriptZone);
      element.ScriptZone = scriptZone ?? element.ScriptZone;
      builder.Validate(scriptZoneEvaluator);
      element.ScriptZoneEvaluator = scriptZoneEvaluator ?? element.ScriptZoneEvaluator;
      element.UseEvaluator = useEvaluator ?? element.UseEvaluator;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ScriptZoneDeactivate"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/ScriptZoneDeactivate
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonQ3Scene_DayTime</term><description>ffb3b99adfa368444b4a46ea36e5aec9</description></item>
    /// <item><term>Desnits03a_Sleep</term><description>a5b4e591c5965074799c91d53f8eef47</description></item>
    /// <item><term>WP_1_ScriptZone</term><description>0613d54edb72463e8bcada03f359bf91</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="scriptZoneEvaluator">
    /// <para>
    /// InfoBox: NOTE: Should evaluate scriptZone!
    /// </para>
    /// </param>
    public static ActionsBuilder ScriptZoneDeactivate(
        this ActionsBuilder builder,
        EntityReference? scriptZone = null,
        MapObjectEvaluator? scriptZoneEvaluator = null,
        bool? useEvaluator = null)
    {
      var element = ElementTool.Create<ScriptZoneDeactivate>();
      builder.Validate(scriptZone);
      element.ScriptZone = scriptZone ?? element.ScriptZone;
      builder.Validate(scriptZoneEvaluator);
      element.ScriptZoneEvaluator = scriptZoneEvaluator ?? element.ScriptZoneEvaluator;
      element.UseEvaluator = useEvaluator ?? element.UseEvaluator;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ScripZoneUnits"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/ScripZoneUnits
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction</term><description>d36dcab7631c4ad0b4d71ed4483b1973</description></item>
    /// <item><term>CommandAction1</term><description>9df78bb01373451bab52aa8b3e53255a</description></item>
    /// <item><term>Poisons_dmg_zone3</term><description>a98b6c45026a4845b7827c767a832dde</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder ScripZoneUnits(
        this ActionsBuilder builder,
        ActionsBuilder? actions = null,
        EntityReference? scriptZone = null)
    {
      var element = ElementTool.Create<ScripZoneUnits>();
      element.Actions = actions?.Build() ?? element.Actions;
      if (element.Actions is null)
      {
        element.Actions = Utils.Constants.Empty.Actions;
      }
      builder.Validate(scriptZone);
      element.ScriptZone = scriptZone ?? element.ScriptZone;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetDeviceState"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/SetDeviceState
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AlushinyrraHigherCity_DefaultEtude</term><description>41574c2d4b6d89e41b096094d0aed4f2</description></item>
    /// <item><term>CommandAction4</term><description>ec2d62d68fb7449797d6d5f3a9b06856</description></item>
    /// <item><term>SummonedCrusaderDrezenLeftHanded</term><description>e3862f8f01298f240b171e50f2d4302c</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder SetDeviceState(
        this ActionsBuilder builder,
        MapObjectEvaluator? device = null,
        IntEvaluator? state = null)
    {
      var element = ElementTool.Create<SetDeviceState>();
      builder.Validate(device);
      element.Device = device ?? element.Device;
      builder.Validate(state);
      element.State = state ?? element.State;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetDeviceTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/SetDeviceTrigger
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction</term><description>a1359088a0c30cd408411b966916d5e6</description></item>
    /// <item><term>CommandAction 3</term><description>b591c3c6e80edcb4da81380150310d86</description></item>
    /// <item><term>CommandAction 8</term><description>bc5f144452a93274f97ec6a8d38d7f90</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder SetDeviceTrigger(
        this ActionsBuilder builder,
        MapObjectEvaluator? device = null,
        string? trigger = null)
    {
      var element = ElementTool.Create<SetDeviceTrigger>();
      builder.Validate(device);
      element.Device = device ?? element.Device;
      element.Trigger = trigger ?? element.Trigger;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetDisableDevice"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/SetDisableDevice
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>MidnightFane_BarricadeDoorTrigger</term><description>bd5fcb433dd348e40bfbbf876642a969</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="overrideDC">
    /// <para>
    /// Tooltip: If 0, uses default DC set on map object.
    /// </para>
    /// </param>
    public static ActionsBuilder SetDisableDevice(
        this ActionsBuilder builder,
        MapObjectEvaluator? mapObject = null,
        int? overrideDC = null)
    {
      var element = ElementTool.Create<SetDisableDevice>();
      builder.Validate(mapObject);
      element.MapObject = mapObject ?? element.MapObject;
      element.OverrideDC = overrideDC ?? element.OverrideDC;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ShowMultiEntrance"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0013</term><description>d62518722ec02d94483c5687beaa6bb2</description></item>
    /// <item><term>EnterPointSelectionTransition</term><description>8321fb241c45c9f41865295ef403bc68</description></item>
    /// <item><term>PortalArkNexus_Actions</term><description>88c1e40065c32784bb4b7b2e97ed8ff7</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="map">
    /// <para>
    /// Blueprint of type BlueprintMultiEntrance. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder ShowMultiEntrance(
        this ActionsBuilder builder,
        Blueprint<BlueprintMultiEntranceReference>? map = null)
    {
      var element = ElementTool.Create<ShowMultiEntrance>();
      element.m_Map = map?.Reference ?? element.m_Map;
      if (element.m_Map is null)
      {
        element.m_Map = BlueprintTool.GetRef<BlueprintMultiEntranceReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SpotMapObject"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Angel_Sword_Trigger</term><description>2f6b1393c35fcf748b49fd9223ce59da</description></item>
    /// <item><term>CommandAction 1</term><description>66052721d8dc6364c9cbaf4f902815cb</description></item>
    /// <item><term>TrapTutorial</term><description>5e218b9b57c12224bb4238a5951e7b06</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder SpotMapObject(
        this ActionsBuilder builder,
        UnitEvaluator? spotter = null,
        MapObjectEvaluator? target = null)
    {
      var element = ElementTool.Create<SpotMapObject>();
      builder.Validate(spotter);
      element.Spotter = spotter ?? element.Spotter;
      builder.Validate(target);
      element.Target = target ?? element.Target;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SpotUnit"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction</term><description>d8bac273a7b60624ca120022e7a37755</description></item>
    /// <item><term>Cue_0005</term><description>905c3d254342cce4bb6d4337ce7baf59</description></item>
    /// <item><term>KenabresBurning_Default</term><description>ff99c02a1f792a545bc4eda7858cbaaf</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder SpotUnit(
        this ActionsBuilder builder,
        UnitEvaluator? spotter = null,
        UnitEvaluator? target = null)
    {
      var element = ElementTool.Create<SpotUnit>();
      builder.Validate(spotter);
      element.Spotter = spotter ?? element.Spotter;
      builder.Validate(target);
      element.Target = target ?? element.Target;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="TeleportParty"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/TeleportParty
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>2ALR_BlueprintAreaTransition</term><description>caa1a113bb2c18e4bb187348664d4c99</description></item>
    /// <item><term>Cue_0012</term><description>dc93ae9209903e041a10baff7d50da5f</description></item>
    /// <item><term>ZigguratNoMoreLich</term><description>ca82ea555e8408c4e8839cdd5079e099</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="exitPositon">
    /// <para>
    /// Blueprint of type BlueprintAreaEnterPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder TeleportParty(
        this ActionsBuilder builder,
        ActionsBuilder? afterTeleport = null,
        AutoSaveMode? autoSaveMode = null,
        Blueprint<BlueprintAreaEnterPointReference>? exitPositon = null,
        bool? forcePauseAfterTeleport = null)
    {
      var element = ElementTool.Create<TeleportParty>();
      element.AfterTeleport = afterTeleport?.Build() ?? element.AfterTeleport;
      if (element.AfterTeleport is null)
      {
        element.AfterTeleport = Utils.Constants.Empty.Actions;
      }
      element.AutoSaveMode = autoSaveMode ?? element.AutoSaveMode;
      element.m_exitPositon = exitPositon?.Reference ?? element.m_exitPositon;
      if (element.m_exitPositon is null)
      {
        element.m_exitPositon = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(null);
      }
      element.ForcePauseAfterTeleport = forcePauseAfterTeleport ?? element.ForcePauseAfterTeleport;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="TranslocatePlayer"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/TranslocatePlayer
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArenaFinalFight</term><description>131316c1965bfb54e97f6134de6698e1</description></item>
    /// <item><term>CommandAction</term><description>c12c145a97e8410498af1761c36a1bd0</description></item>
    /// <item><term>WinThirdFight_dialogue</term><description>2038c62fd9e036c4285deb60e2012e19</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="transolcatePosition">
    /// <para>
    /// Tooltip: Locator View
    /// </para>
    /// </param>
    public static ActionsBuilder TranslocatePlayer(
        this ActionsBuilder builder,
        bool? byFormationAndWithPets = null,
        bool? scrollCameraToPlayer = null,
        EntityReference? transolcatePosition = null)
    {
      var element = ElementTool.Create<TranslocatePlayer>();
      element.ByFormationAndWithPets = byFormationAndWithPets ?? element.ByFormationAndWithPets;
      element.ScrollCameraToPlayer = scrollCameraToPlayer ?? element.ScrollCameraToPlayer;
      builder.Validate(transolcatePosition);
      element.transolcatePosition = transolcatePosition ?? element.transolcatePosition;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="TranslocateUnit"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/TranslocateUnit
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonQ10_EndKTC</term><description>4caf982d4440ee9409b809f10b7796ff</description></item>
    /// <item><term>CommandAction 6</term><description>ab0dccf6562e4114037acdcf3809ed65</description></item>
    /// <item><term>ZigguratActive</term><description>6716edd224e0d4049a55030f4d01c8ed</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="translocatePosition">
    /// <para>
    /// Tooltip: Locator View
    /// </para>
    /// </param>
    public static ActionsBuilder TranslocateUnit(
        this ActionsBuilder builder,
        bool? copyRotation = null,
        FloatEvaluator? translocateOrientationEvaluator = null,
        EntityReference? translocatePosition = null,
        PositionEvaluator? translocatePositionEvaluator = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<TranslocateUnit>();
      element.m_CopyRotation = copyRotation ?? element.m_CopyRotation;
      builder.Validate(translocateOrientationEvaluator);
      element.translocateOrientationEvaluator = translocateOrientationEvaluator ?? element.translocateOrientationEvaluator;
      builder.Validate(translocatePosition);
      element.translocatePosition = translocatePosition ?? element.translocatePosition;
      builder.Validate(translocatePositionEvaluator);
      element.translocatePositionEvaluator = translocatePositionEvaluator ?? element.translocatePositionEvaluator;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="TrapCastSpell"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction</term><description>1247182d56f46e9439ae1d9a74085604</description></item>
    /// <item><term>CommandAction 2</term><description>e4974d4f80794f36bf209c979959e6c7</description></item>
    /// <item><term>TrappedChestGood5_OnDestructionActions</term><description>9a41a80c55a34003b3fa830e5e4a1c9c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="spell">
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
    /// <param name="targetPoint">
    /// <para>
    /// InfoBox: Required if Spell can target Point (like Fireball)
    /// </para>
    /// </param>
    /// <param name="triggeringUnit">
    /// <para>
    /// InfoBox: Required if Spell can not target Point (like Scorching ray)
    /// </para>
    /// </param>
    public static ActionsBuilder TrapCastSpell(
        this ActionsBuilder builder,
        PositionEvaluator? actorPosition = null,
        int? dC = null,
        bool? disableBattleLog = null,
        bool? overrideDC = null,
        bool? overrideSpellLevel = null,
        Blueprint<BlueprintAbilityReference>? spell = null,
        int? spellLevel = null,
        PositionEvaluator? targetPoint = null,
        MapObjectEvaluator? trapObject = null,
        UnitEvaluator? triggeringUnit = null)
    {
      var element = ElementTool.Create<TrapCastSpell>();
      builder.Validate(actorPosition);
      element.ActorPosition = actorPosition ?? element.ActorPosition;
      element.DC = dC ?? element.DC;
      element.DisableBattleLog = disableBattleLog ?? element.DisableBattleLog;
      element.OverrideDC = overrideDC ?? element.OverrideDC;
      element.OverrideSpellLevel = overrideSpellLevel ?? element.OverrideSpellLevel;
      element.m_Spell = spell?.Reference ?? element.m_Spell;
      if (element.m_Spell is null)
      {
        element.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      }
      element.SpellLevel = spellLevel ?? element.SpellLevel;
      builder.Validate(targetPoint);
      element.TargetPoint = targetPoint ?? element.TargetPoint;
      builder.Validate(trapObject);
      element.TrapObject = trapObject ?? element.TrapObject;
      builder.Validate(triggeringUnit);
      element.TriggeringUnit = triggeringUnit ?? element.TriggeringUnit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnlockLocation"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Actions/UnlockLocation
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>01_GoToCamp</term><description>10d044829fd19a54eb85cae569fc009f</description></item>
    /// <item><term>Cue_0023</term><description>70618d5c5a0dfbb4eb17031bba1972a5</description></item>
    /// <item><term>WenduagKTC_WenduagComeNeathholm</term><description>d6793bcea861d3b49857067532fcedc0</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="location">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder UnlockLocation(
        this ActionsBuilder builder,
        bool? fakeDescription = null,
        bool? hideInstead = null,
        Blueprint<BlueprintGlobalMapPoint.Reference>? location = null)
    {
      var element = ElementTool.Create<UnlockLocation>();
      element.FakeDescription = fakeDescription ?? element.FakeDescription;
      element.HideInstead = hideInstead ?? element.HideInstead;
      element.m_Location = location?.Reference ?? element.m_Location;
      if (element.m_Location is null)
      {
        element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnlockMapEdge"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>c1_c2_interchapter</term><description>843f796b6b8b79e41ab412887d9ae978</description></item>
    /// <item><term>KenabresMapEtude</term><description>68d8b3a6007a47aba2a4731dc0d0f67c</description></item>
    /// <item><term>WorldWoundGMReturn2KenabresTestPreset</term><description>bc2c980845879dd4fa97f97cb9dadb0b</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="edge">
    /// <para>
    /// Blueprint of type BlueprintGlobalMapEdge. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="openEdges">
    /// <para>
    /// Tooltip: Unlock points on edge for direct travel
    /// </para>
    /// </param>
    public static ActionsBuilder UnlockMapEdge(
        this ActionsBuilder builder,
        Blueprint<BlueprintGlobalMapEdge.Reference>? edge = null,
        bool? openEdges = null)
    {
      var element = ElementTool.Create<UnlockMapEdge>();
      element.m_Edge = edge?.Reference ?? element.m_Edge;
      if (element.m_Edge is null)
      {
        element.m_Edge = BlueprintTool.GetRef<BlueprintGlobalMapEdge.Reference>(null);
      }
      element.OpenEdges = openEdges ?? element.OpenEdges;
      return builder.Add(element);
    }
  }
}
