//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Assets.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Conditions;

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
    /// <param name="area">
    /// Blueprint of type BlueprintArea. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder AreaVisited(
        this ConditionsBuilder builder,
        Blueprint<BlueprintArea, BlueprintAreaReference>? area = null,
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
    public static ConditionsBuilder ContextConditionDungeonStage(
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
    /// <param name="area">
    /// Blueprint of type BlueprintArea. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder CurrentAreaIs(
        this ConditionsBuilder builder,
        Blueprint<BlueprintArea, BlueprintAreaReference>? area = null,
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
    /// Adds <see cref="InCapital"/>
    /// </summary>
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
    /// <param name="location">
    /// Blueprint of type BlueprintGlobalMapPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder LocationRevealed(
        this ConditionsBuilder builder,
        Blueprint<BlueprintGlobalMapPoint, BlueprintGlobalMapPoint.Reference>? location = null,
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
    /// <param name="areaPart">
    /// Blueprint of type BlueprintAreaPart. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </param>
    public static ConditionsBuilder UnitIsInAreaPart(
        this ConditionsBuilder builder,
        Blueprint<BlueprintAreaPart, BlueprintAreaPartReference>? areaPart = null,
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
