//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Capital;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Corruption;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Persistence;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Localization;
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
    /// <item><term>LannRomance</term><description>d9baf40d38ceaf248bd5306f0e344bdb</description></item>
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
    public static ActionsBuilder ChangeCurrentAreaName(
        this ActionsBuilder builder,
        LocalizedString newName)
    {
      var element = ElementTool.Create<ChangeCurrentAreaName>();
      element.NewName = newName;
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
    public static ActionsBuilder AskPlayerForLocationName(
        this ActionsBuilder builder,
        LocalizedString? defaultValue = null,
        LocalizedString? hint = null,
        Blueprint<BlueprintGlobalMapPoint.Reference>? location = null,
        bool? obligatory = null,
        LocalizedString? title = null)
    {
      var element = ElementTool.Create<AskPlayerForLocationName>();
      element.Default = defaultValue ?? element.Default;
      if (element.Default is null)
      {
        element.Default = Utils.Constants.Empty.String;
      }
      element.Hint = hint ?? element.Hint;
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
      element.Title = title ?? element.Title;
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
    /// Adds <see cref="EndAreaEffects"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CommandAction</term><description>c2fba818bb632aa4bb5908337b9f5b51</description></item>
    /// <item><term>CommandAction</term><description>afb33d70ca6047b78f1b76db9c9088bc</description></item>
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
    /// <item><term>Fane_MutafenLab_Mechanic</term><description>48eecf216b5111f4291e30beabae19b2</description></item>
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
    /// <item><term>Alushinyrra_MediumCity_MainAndWesternIsland_SecondStateEnter</term><description>8529d7038f594bbc879dd1c33b8d4389</description></item>
    /// <item><term>CommandAction</term><description>ef51fbbe5cb604747a7edff9112e9583</description></item>
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
    /// <item><term>DrezenCapital_DefaultMechanic</term><description>30862a76dd4a11049be42d3de26159fb</description></item>
    /// <item><term>WarCamp_DefaultPeaceful_Outdoor</term><description>27d07416c620e0e48865bd88d74cbb82</description></item>
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
    /// <item><term>Cue_0123</term><description>3034d21124a9d5a43969b119cada65c5</description></item>
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
    /// <item><term>PlayerDreamSummons1</term><description>12ed8664358d9ba49b2a246bef5865c1</description></item>
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
    /// <item><term>CommandAction7</term><description>57586b2b26d743879e46ebfc310d4d6e</description></item>
    /// <item><term>WoundWormLair_Event_Mechanics</term><description>fa1e44ec4639c4242b745b9b7c72cc03</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder ScriptZoneActivate(
        this ActionsBuilder builder,
        EntityReference? scriptZone = null)
    {
      var element = ElementTool.Create<ScriptZoneActivate>();
      builder.Validate(scriptZone);
      element.ScriptZone = scriptZone ?? element.ScriptZone;
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
    /// <item><term>DHDefended_Mechanic</term><description>d9042ef7dd8941d8b71b2e4f66684f03</description></item>
    /// <item><term>WP_1_ScriptZone</term><description>0613d54edb72463e8bcada03f359bf91</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder ScriptZoneDeactivate(
        this ActionsBuilder builder,
        EntityReference? scriptZone = null)
    {
      var element = ElementTool.Create<ScriptZoneDeactivate>();
      builder.Validate(scriptZone);
      element.ScriptZone = scriptZone ?? element.ScriptZone;
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
    /// <item><term>CommandAction2</term><description>263060b2c1934de6b0ff59da6e4a2ed8</description></item>
    /// <item><term>Oil_Debuff</term><description>4c83baec3825401ebaf66f501013f5e1</description></item>
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
    /// <item><term>Cue_0011</term><description>ea7edba7b4f85564095f06aac7325006</description></item>
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
    /// <item><term>CommandAction 6</term><description>eb0ed044c6d7c8b4a9f8e986b48decb4</description></item>
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
    /// <item><term>Cue_0026</term><description>aa27c300479f5be4d9475a3c1ed851f2</description></item>
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
