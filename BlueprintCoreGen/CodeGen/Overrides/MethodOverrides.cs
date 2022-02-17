using Kingmaker.Designers.EventConditionActionSystem.Actions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCoreGen.CodeGen.Override
{
  /// <summary>
  /// Manual overrides for a method. 
  /// </summary>
  public class MethodOverride
  {
    public List<Type> Imports = new();

    public List<string> Remarks = new();

    public string? Name;

    public Dictionary<string, FieldParamOverride> FieldOverridesByName = new();

    public MethodOverride AddImports(params Type[] types)
    {
      Imports.AddRange(types);
      return this;
    }

    public MethodOverride AddRemarks(params string[] remarkLines)
    {
      Remarks.AddRange(remarkLines);
      return this;
    }

    public MethodOverride UseName(string methodName)
    {
      Name = methodName;
      return this;
    }

    public MethodOverride RequireFields(params string[] fieldNames)
    {
      fieldNames.ToList().ForEach(name => FieldOverridesByName.Add(name, new RequiredFieldParam()));
      return this;
    }

    public MethodOverride IgnoreFields(params string[] fieldNames)
    {
      fieldNames.ToList().ForEach(name => FieldOverridesByName.Add(name, new IgnoredFieldParam()));
      return this;
    }

    public MethodOverride SetConstantFields(params (string name, string value)[] constantFields)
    {
      constantFields.ToList().ForEach(
          field => FieldOverridesByName.Add(field.name, new ConstantFieldParam(field.value)));
      return this;
    }

    public MethodOverride OverrideFields(params (string name, FieldParamOverride overrideValue)[] overrideFields)
    {
      overrideFields.ToList().ForEach(field => FieldOverridesByName.Add(field.name, field.overrideValue));
      return this;
    }
  }

  /// <summary>
  /// List wrapper for MethodOverride. Enables splitting a method into multiple versions.
  /// </summary>
  public class MethodOverrideList
  {
    /// <summary>
    /// If true, the default generated method is skipped and only Methods are generated.
    /// </summary>
    public bool IgnoreDefault = false;

    public List<MethodOverride> Methods = new();
  }

  /// <summary>
  /// Contains hand-tuned overrides for builder methods.
  /// </summary>
  public class MethodOverrides
  {
    public static readonly Dictionary<Type, MethodOverrideList> BuilderMethods =
      new()
      {
        // Kingmaker.Designers.EventConditionActionSystem.Actions.CreateArmy
        {
          typeof(CreateArmy),
          new MethodOverrideList
          {
            IgnoreDefault = true,
            Methods =
              new()
              {
                new MethodOverride()
                  .UseName("CreateCrusaderArmy")
                  .RequireFields("Location")
                  .IgnoreFields(
                    "m_MoveTarget",
                    "m_TargetLocation",
                    "m_CompleteActions",
                    "m_DaysToDestination",
                    "WithLeader")
                  .SetConstantFields(("Faction", "ArmyFaction.Crusaders"))
                  .OverrideFields(
                    ("Preset", new RequiredFieldParam { ParamName = "army" }),
                    ("ArmyLeader",
                      new FieldParamOverride
                      {
                        ParamName = "leader",
                        ExtraAssignmentFmtLines = new() { "{0}.WithLeader = leader is not null;" }
                      })),
                new MethodOverride()
                  .UseName("CreateDemonArmy")
                  .RequireFields("Location")
                  .IgnoreFields(
                    "m_TargetLocation",
                    "m_DaysToDestination",
                    "m_ApplyRecruitIncrease",
                    "MovementPoints",
                    "WithLeader")
                  .SetConstantFields(
                    ("Faction", "ArmyFaction.Demons"))
                  .OverrideFields(
                    ("Preset", new RequiredFieldParam { ParamName = "army" }),
                    ("ArmyLeader",
                      new FieldParamOverride
                      {
                        ParamName = "leader",
                        ExtraAssignmentFmtLines = new() { "{0}.WithLeader = leader is not null;" }
                      }),
                    ("m_MoveTarget",
                      new FieldParamOverride
                      {
                        ParamName = "targetNearestEnemy",
                        TypeName = "bool",
                        DefaultValue = "false",
                        AssignmentRhsFmt = "{0} ? TravelLogicType.NearestEnemy : TravelLogicType.None;",
                        IsNullable = false
                      })),
                new MethodOverride()
                  .UseName("CreateDemonArmyTargetingLocation")
                  .RequireFields("m_TargetLocation")
                  .IgnoreFields(
                    "m_ArmySpeed",
                    "m_ApplyRecruitIncrease",
                    "MovementPoints",
                    "WithLeader")
                  .SetConstantFields(
                    ("Faction", "ArmyFaction.Demons"),
                    ("m_MoveTarget", "TravelLogicType.Location"))
                  .OverrideFields(
                    ("Preset", new RequiredFieldParam { ParamName = "army" }),
                    ("Location", new RequiredFieldParam { ParamName = "spawnLocation" }),
                    ("ArmyLeader",
                      new FieldParamOverride
                      {
                        ParamName = "leader",
                        ExtraAssignmentFmtLines = new() { "{0}.WithLeader = leader is not null;" }
                      })),
              }
          }
        }
      };
  }
}
