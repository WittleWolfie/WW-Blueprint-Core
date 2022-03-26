//using BlueprintCore.Blueprints;
//using BlueprintCore.Utils;
//using BlueprintCoreGen.CodeGen.Methods;
//using BlueprintCoreGen.CodeGen.Params;
//using Kingmaker.Assets.UnitLogic.Mechanics.Actions;
//using Kingmaker.Blueprints.Items.Ecnchantments;
//using Kingmaker.Blueprints;
//using Kingmaker.Designers.EventConditionActionSystem.Actions;
//using Kingmaker.Dungeon.Actions;
//using Kingmaker.UnitLogic.Mechanics.Actions;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace BlueprintCoreGen.CodeGen
//{

//  /// <summary>
//  /// Helper class to build method remarks.
//  /// </summary>
//  public class Remarks
//  {
//    private List<List<string>> Paragraphs = new();
//    private List<(string blueprintName, string blueprintGuid)> Examples = new();

//    public Remarks AddParagraph(params string[] lines)
//    {
//      Paragraphs.Add(lines.ToList());
//      return this;
//    }

//    public Remarks AddExample(string blueprintName, string blueprintGuid)
//    {
//      Examples.Add((blueprintName, blueprintGuid));
//      return this;
//    }

//    public List<string> ToList()
//    {
//      List<string> result = new() { "<remarks>" };
//      Paragraphs.ForEach(
//        paragraph =>
//        {
//          result.Add("<para>");
//          paragraph.ForEach(line => result.Add(line));
//          result.Add("</para>");
//          result.Add("");
//        });

//      if (Examples.Any())
//      {
//        result.Add("<list type=\"bullet\">");
//        result.Add("<listheader>");
//        result.Add("  <term>Example Blueprints:</term>");
//        result.Add("</listheader>");
//        Examples.ForEach(
//          example =>
//          {
//            result.Add("<item>");
//            result.Add($"  <description>{example.blueprintName} - {example.blueprintGuid}</description>");
//            result.Add("</item>");
//          });
//        result.Add("</list>");
//      }
//      result.Add("</remarks>");
//      return result;
//    }
//  }

//  /// <summary>
//  /// List wrapper for MethodOverride. Enables splitting a method into multiple versions.
//  /// </summary>
//  public class MethodOverrideList
//  {
//    /// <summary>
//    /// If true, the default generated method is skipped and only Methods are generated.
//    /// </summary>
//    public bool ReplaceDefault = true;

//    public List<MethodOverride> Methods = new();

//    public MethodOverrideList(params MethodOverride[] methods)
//    {
//      Methods = methods.ToList();
//    }
//  }

//  /// <summary>
//  /// Contains hand-tuned overrides for builder methods.
//  /// </summary>
//  public class MethodOverrides
//  {
//    private static readonly Remarks AddItemToPlayerRemarks =
//      new Remarks()
//        .AddParagraph(
//        "<list type=\"bullet\">",
//        "<item>",
//        "  <description>",
//        "    If the item is a <see cref=\"BlueprintItemEquipmentHand\"/> use <see cref=\"GiveHandSlotItemToPlayer\"/>",
//        "  </description>",
//        "</item>",
//        "<item>",
//        "  <description>",
//        "    If the item is a <see cref=\"BlueprintItemEquipment\"/> use <see cref=\"GiveEquipmentToPlayer\"/>",
//        "  </description>",
//        "</item>",
//        "<item>",
//        "  <description>",
//        "    For any other items use <see cref=\"GiveItemToPlayer\"/>.",
//        "  </description>",
//        "</item>",
//        "</list>");

//    public static readonly Dictionary<Type, MethodOverrideList> BuilderMethods =
//      new()
//      {

//        //**** ActionsBuilderKingdomEx ****//

//        // Kingmaker.Designers.EventConditionActionSystem.Actions.CreateArmy
//        {
//          typeof(CreateArmy),
//          new MethodOverrideList(
//            new MethodOverride()
//              .UseName("CreateCrusaderArmy")
//              .RequireFields("Location")
//              .IgnoreFields(
//                "m_MoveTarget",
//                "m_TargetLocation",
//                "m_CompleteActions",
//                "m_DaysToDestination",
//                "WithLeader")
//              .SetConstantFields(("Faction", "ArmyFaction.Crusaders"))
//              .OverrideFields(
//                ("Preset", new RequiredParameter { ParamName = "army" }),
//                ("ArmyLeader",
//                  new ParameterOverride
//                  {
//                    ParamName = "leader",
//                    ExtraAssignmentFmtLines = new() { "{0}.WithLeader = leader is not null;" }
//                  })),
//            new MethodOverride()
//              .UseName("CreateDemonArmy")
//              .RequireFields("Location")
//              .IgnoreFields(
//                "m_TargetLocation",
//                "m_DaysToDestination",
//                "m_ApplyRecruitIncrease",
//                "MovementPoints",
//                "WithLeader")
//              .SetConstantFields(
//                ("Faction", "ArmyFaction.Demons"))
//              .OverrideFields(
//                ("Preset", new RequiredParameter { ParamName = "army" }),
//                ("ArmyLeader",
//                  new ParameterOverride
//                  {
//                    ParamName = "leader",
//                    ExtraAssignmentFmtLines = new() { "{0}.WithLeader = leader is not null;" }
//                  }),
//                ("m_MoveTarget",
//                  new ParameterOverride
//                  {
//                    ParamName = "targetNearestEnemy",
//                    TypeName = "bool",
//                    DefaultValue = "false",
//                    AssignmentRhsFmt = "{0} ? TravelLogicType.NearestEnemy : TravelLogicType.None;",
//                    IsNullable = false
//                  })),
//            new MethodOverride()
//              .UseName("CreateDemonArmyTargetingLocation")
//              .RequireFields("m_TargetLocation")
//              .IgnoreFields(
//                "m_ArmySpeed",
//                "m_ApplyRecruitIncrease",
//                "MovementPoints",
//                "WithLeader")
//              .SetConstantFields(
//                ("Faction", "ArmyFaction.Demons"),
//                ("m_MoveTarget", "TravelLogicType.Location"))
//              .OverrideFields(
//                ("Preset", new RequiredParameter { ParamName = "army" }),
//                ("Location", new RequiredParameter { ParamName = "spawnLocation" }),
//                ("ArmyLeader",
//                  new ParameterOverride
//                  {
//                    ParamName = "leader",
//                    ExtraAssignmentFmtLines = new() { "{0}.WithLeader = leader is not null;" }
//                  })))
//        },
//      };

//    private static string[] GetBlueprintCommentFmtWithDefault(Type blueprintType, string defaultComment)
//    {
//      return ParametersFactory.GetBlueprintCommentFmt(blueprintType).Append("").Append(defaultComment).ToArray();
//    }
//  }
//}
