//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Assets.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Conditions.Builder.AreaEx
{
  /// <summary>
  /// Extension to <see cref="ConditionsBuilder"/> for conditions involving the game map, dungeons, or locations. See also <see cref="KingdomEx.ConditionsBuilderKingdomEx">KingdomEx</see>.
  /// </summary>
  /// <inheritdoc cref="ConditionsBuilder"/>
  public static class ConditionsBuilderAreaEx
  {

    /// <summary>
    /// Adds <see cref="AreaVisited"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0007</term><description>4df71c9b1ab9d174eaf66587e483dc61</description></item>
    /// <item><term>PF-424113</term><description>fe7866961dd849eabea8c01ae5c0e9a9</description></item>
    /// <item><term>YellowPuzzleMechanic</term><description>7e0ebe7249b75724a836537405e988bb</description></item>
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
    public static ConditionsBuilder AreaVisited(
        this ConditionsBuilder builder,
        Blueprint<BlueprintAreaReference>? area = null,
        bool negate = false)
    {
      var element = ElementTool.Create<AreaVisited>();
      element.m_Area = area?.Reference ?? element.m_Area;
      if (element.m_Area is null)
      {
        element.m_Area = BlueprintTool.GetRef<BlueprintAreaReference>(null);
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionDungeonStage"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_BoonsTutorial</term><description>656933737f3d4ee4b8be54a54df48d3f</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder DungeonStage(
        this ConditionsBuilder builder,
        int? maxLevel = null,
        int? minLevel = null,
        bool negate = false)
    {
      var element = ElementTool.Create<ContextConditionDungeonStage>();
      element.MaxLevel = maxLevel ?? element.MaxLevel;
      element.MinLevel = minLevel ?? element.MinLevel;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="CurrentAreaIs"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonEyeEnemyVisualBuff</term><description>9815f77129674e8e886de2d458ecdf49</description></item>
    /// <item><term>Cue_53</term><description>51afcdfbe2584ed6a196361bd8cae8fb</description></item>
    /// <item><term>WoljifQ</term><description>d79f05dbd35b468fa16312f30d61a5e1</description></item>
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
    public static ConditionsBuilder CurrentAreaIs(
        this ConditionsBuilder builder,
        Blueprint<BlueprintAreaReference>? area = null,
        bool negate = false)
    {
      var element = ElementTool.Create<CurrentAreaIs>();
      element.m_Area = area?.Reference ?? element.m_Area;
      if (element.m_Area is null)
      {
        element.m_Area = BlueprintTool.GetRef<BlueprintAreaReference>(null);
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DungeonIsBoon"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CheckBoonFlags</term><description>87a65a30a6f5424b86fed226dbc2d101</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="boon">
    /// <para>
    /// Blueprint of type BlueprintDungeonBoon. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder DungeonIsBoon(
        this ConditionsBuilder builder,
        Blueprint<Kingmaker.Dungeon.Blueprints.BlueprintDungeonBoonReference>? boon = null,
        bool negate = false)
    {
      var element = ElementTool.Create<DungeonIsBoon>();
      element.m_Boon = boon?.Reference ?? element.m_Boon;
      if (element.m_Boon is null)
      {
        element.m_Boon = BlueprintTool.GetRef<Kingmaker.Dungeon.Blueprints.BlueprintDungeonBoonReference>(null);
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DungeonIsTier"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Blessing_Interaction</term><description>ff4a347df77e4cad971249c25d9a1589</description></item>
    /// <item><term>DLC3_WildMagic_Spells_Tier3</term><description>9966b4a4042745aca41d79420dc0d271</description></item>
    /// <item><term>RewardTrader_Tier3</term><description>b92e487220524c0f945a36436994d2f8</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="tier">
    /// <para>
    /// Blueprint of type BlueprintDungeonTier. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder DungeonIsTier(
        this ConditionsBuilder builder,
        bool negate = false,
        Blueprint<BlueprintDungeonTierReference>? tier = null)
    {
      var element = ElementTool.Create<DungeonIsTier>();
      element.Not = negate;
      element.m_Tier = tier?.Reference ?? element.m_Tier;
      if (element.m_Tier is null)
      {
        element.m_Tier = BlueprintTool.GetRef<BlueprintDungeonTierReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="DungeonIsTierReached"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>RewardLoot_BesmaraBoss</term><description>bc8bf25e3038475e9a2cc9cfddfc1ee6</description></item>
    /// <item><term>RewardLoot_ConsumablePotion_Tier1_close</term><description>f96a1f37fcd6427d81c85cf0cd7ba92b</description></item>
    /// <item><term>RewardObject_LegacyExp_close</term><description>36158ab6a3f54e75bdbb462453871efa</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="tier">
    /// <para>
    /// Blueprint of type BlueprintDungeonTier. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder DungeonIsTierReached(
        this ConditionsBuilder builder,
        bool negate = false,
        Blueprint<BlueprintDungeonTierReference>? tier = null)
    {
      var element = ElementTool.Create<DungeonIsTierReached>();
      element.Not = negate;
      element.m_Tier = tier?.Reference ?? element.m_Tier;
      if (element.m_Tier is null)
      {
        element.m_Tier = BlueprintTool.GetRef<BlueprintDungeonTierReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="InCapital"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Test_Bebilith Blueprint Camping Encounter</term><description>f2f8355d4bc8aa34195eeb2f5cf66645</description></item>
    /// <item><term>TriceratopsStatuetteCorrectBuff</term><description>4366d9550c8345da8bedece00a19b7a8</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder InCapital(
        this ConditionsBuilder builder,
        bool negate = false)
    {
      var element = ElementTool.Create<InCapital>();
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsLootEmpty"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CavesShortcutUnlocked</term><description>d1f433e953409144d914f15597db6e34</description></item>
    /// <item><term>Green_Slot_1_2_IsNotEmpty</term><description>d44ba5b7fee49e64684ce203920e5c08</description></item>
    /// <item><term>Slot_3_3_IsNotEmpty</term><description>85c097fd43ebd3940b6ea98b57e6f35e</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder IsLootEmpty(
        this ConditionsBuilder builder,
        bool? evaluateMapObject = null,
        EntityReference? lootObject = null,
        MapObjectEvaluator? mapObject = null,
        bool negate = false)
    {
      var element = ElementTool.Create<IsLootEmpty>();
      element.EvaluateMapObject = evaluateMapObject ?? element.EvaluateMapObject;
      builder.Validate(lootObject);
      element.LootObject = lootObject ?? element.LootObject;
      builder.Validate(mapObject);
      element.MapObject = mapObject ?? element.MapObject;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsPartyInNaturalSetting"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SE_IngerMaggor</term><description>40ad6b04835d4c26b4fe62bb267a6143</description></item>
    /// <item><term>SE_RenownExplorer</term><description>b7204ae38aa346f3a584982fd8486ac2</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder IsPartyInNaturalSetting(
        this ConditionsBuilder builder,
        bool negate = false,
        GlobalMapZone? setting = null)
    {
      var element = ElementTool.Create<IsPartyInNaturalSetting>();
      element.Not = negate;
      element.Setting = setting ?? element.Setting;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="LocationRevealed"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-257814</term><description>49a5027d61ec4ab7886acfb6e1daddea</description></item>
    /// <item><term>RegillNotInParty_KickedOut</term><description>2b2cfaa1727070c43b10729920112730</description></item>
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
    public static ConditionsBuilder LocationRevealed(
        this ConditionsBuilder builder,
        Blueprint<BlueprintGlobalMapPoint.Reference>? location = null,
        bool negate = false)
    {
      var element = ElementTool.Create<LocationRevealed>();
      element.m_Location = location?.Reference ?? element.m_Location;
      if (element.m_Location is null)
      {
        element.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(null);
      }
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MapObjectDestroyed"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Graveyard_BushesInCheck</term><description>7d19a4d9deda414194a450b343eac99f</description></item>
    /// <item><term>Graveyard_BushesOutCheck</term><description>2f61e729c22a4a59a810466e9db43a6e</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder MapObjectDestroyed(
        this ConditionsBuilder builder,
        MapObjectEvaluator? mapObject = null,
        bool negate = false)
    {
      var element = ElementTool.Create<MapObjectDestroyed>();
      builder.Validate(mapObject);
      element.MapObject = mapObject ?? element.MapObject;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="MapObjectRevealed"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>chap0</term><description>95c4212a36594186b509e87d00d2d480</description></item>
    /// <item><term>TheiflingRevealDoor3</term><description>9a143d61a83c0fd4ea52262ed924ff72</description></item>
    /// <item><term>Thieflings01_TrapReveal5</term><description>799191689150bff488597bddf7f86c35</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder MapObjectRevealed(
        this ConditionsBuilder builder,
        MapObjectEvaluator? mapObject = null,
        bool negate = false)
    {
      var element = ElementTool.Create<MapObjectRevealed>();
      builder.Validate(mapObject);
      element.MapObject = mapObject ?? element.MapObject;
      element.Not = negate;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="PartyInScriptZone"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_9</term><description>0b7d208f5f234f9791097f5aa1d5b8d5</description></item>
    /// <item><term>CommandUnitCastSpell2</term><description>33608356b8364cafa4c9305443372913</description></item>
    /// <item><term>WatchPoint_SZWall_FoW</term><description>0f1fdc5a42ea41a4b87da4021e89dabd</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder PartyInScriptZone(
        this ConditionsBuilder builder,
        PartyInScriptZone.CheckType? check = null,
        bool negate = false,
        EntityReference? scriptZone = null)
    {
      var element = ElementTool.Create<PartyInScriptZone>();
      element.m_Check = check ?? element.m_Check;
      element.Not = negate;
      builder.Validate(scriptZone);
      element.m_ScriptZone = scriptZone ?? element.m_ScriptZone;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitInScriptZone"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Condition/UnitInScriptZone
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0002</term><description>d38052d00f394118945e8861f00574f5</description></item>
    /// <item><term>DLC1_IZ_Irabeth_startDialog</term><description>5bc8820627af4f2080c6e19d4ab8c223</description></item>
    /// <item><term>TrueLootHideZone9</term><description>168ca19a2ced8d448a9944c2f0f01d72</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder UnitInScriptZone(
        this ConditionsBuilder builder,
        bool negate = false,
        MapObjectEvaluator? scriptZone = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<UnitInScriptZone>();
      element.Not = negate;
      builder.Validate(scriptZone);
      element.ScriptZone = scriptZone ?? element.ScriptZone;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitIsInAreaPart"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Answer_0010</term><description>8bbacd42e94344f8a0267b59dfbb4b8b</description></item>
    /// <item><term>Cue_0016</term><description>2cec7e312adf465989d916ac69358412</description></item>
    /// <item><term>Venduag_Q2_interlude_spawnConditions</term><description>7d2e7755a041e0241ad6babe959f8454</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="areaPart">
    /// <para>
    /// Blueprint of type BlueprintAreaPart. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ConditionsBuilder UnitIsInAreaPart(
        this ConditionsBuilder builder,
        Blueprint<BlueprintAreaPartReference>? areaPart = null,
        bool negate = false,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<UnitIsInAreaPart>();
      element.m_AreaPart = areaPart?.Reference ?? element.m_AreaPart;
      if (element.m_AreaPart is null)
      {
        element.m_AreaPart = BlueprintTool.GetRef<BlueprintAreaPartReference>(null);
      }
      element.Not = negate;
      builder.Validate(unit);
      element.Unit = unit ?? element.Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnitIsInFogOfWar"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <para>
    /// ComponentName: Condition/UnitIsInFogOfWar
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PeacefullUnitsInCombatState</term><description>dff0fbdbd83672e429df0dc14b0db79e</description></item>
    /// </list>
    /// </remarks>
    public static ConditionsBuilder UnitIsInFogOfWar(
        this ConditionsBuilder builder,
        bool negate = false,
        UnitEvaluator? target = null)
    {
      var element = ElementTool.Create<UnitIsInFogOfWar>();
      element.Not = negate;
      builder.Validate(target);
      element.Target = target ?? element.Target;
      return builder.Add(element);
    }
  }
}
