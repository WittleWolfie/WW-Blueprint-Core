using Kingmaker.Assets.UnitLogic.Mechanics.Actions;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Dungeon.Actions;
using Kingmaker.UnitLogic.Mechanics.Actions;
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

    public MethodOverride SetDefaultFields(params (string name, string value)[] defaultFields)
    {
      defaultFields.ToList().ForEach(
          field => FieldOverridesByName.Add(field.name, new DefaultFieldParam(field.value)));
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
    public bool ReplaceDefault = true;

    public List<MethodOverride> Methods = new();

    public MethodOverrideList(params MethodOverride[] methods)
    {
      Methods = methods.ToList();
    }
  }

  /// <summary>
  /// Contains hand-tuned overrides for builder methods.
  /// </summary>
  public class MethodOverrides
  {
    private static readonly string[] AddItemToPlayerRemarks =
      new[]
      {
        "<remarks>",
        "<list type=\"bullet\">",
        "<item>",
        "  <description>",
        "    If the item is a <see cref=\"BlueprintItemEquipmentHand\"/> use <see cref=\"GiveHandSlotItemToPlayer\"/>",
        "  </description>",
        "</item>",
        "<item>",
        "  <description>",
        "    If the item is a <see cref=\"BlueprintItemEquipment\"/> use <see cref=\"GiveEquipmentToPlayer\"/>",
        "  </description>",
        "</item>",
        "<item>",
        "  <description>",
        "    For any other items use <see cref=\"GiveItemToPlayer\"/>.",
        "  </description>",
        "</item>",
        "</list>",
        "</remarks>"
      };

    public static readonly Dictionary<Type, MethodOverrideList> BuilderMethods =
      new()
      {
        //**** ActionsBuilderAreaEx ****//

        // Kingmaker.Dungeons.Actions.ActionCreateImportedCompanion
        {
          typeof(ActionCreateImportedCompanion),
          new MethodOverrideList(new MethodOverride().RequireFields("Index"))
        },

        // Kingmaker.Designers.EventConditionActionSystem.Actions.AreaEntranceChange
        {
          typeof(AreaEntranceChange),
          new MethodOverrideList(new MethodOverride().RequireFields("m_Location", "m_NewEntrance"))
        },
        // Kingmaker.Designers.EventConditionActionSystem.Actions.ChangeCurrentAreaName
        {
          typeof(ChangeCurrentAreaName),
          new MethodOverrideList(
            new MethodOverride().RequireFields("NewName").IgnoreFields("RestoreDefault"),
            new MethodOverride()
              .UseName("ResetCurrentAreaName")
              .IgnoreFields("NewName")
              .SetConstantFields(("RestoreDefault", "true")))
        },
        // Kingmaker.Designers.EventConditionActionSystem.Actions.AddCampingEncounter
        {
          typeof(AddCampingEncounter),
          new MethodOverrideList(new MethodOverride().RequireFields("m_Encounter"))
        },
        // Kingmaker.Designers.EventConditionActionSystem.Actions.DestroyMapObject
        {
          typeof(DestroyMapObject),
          new MethodOverrideList(new MethodOverride().RequireFields("MapObject"))
        },

        //**** ActionsBuilderAVEx ****//

        // Kingmaker.Designers.EventConditionActionSystem.Actions.ChangeBookEventImage
        {
          typeof(ChangeBookEventImage),
          new MethodOverrideList(new MethodOverride().RequireFields("m_Image"))
        },
        // Kingmaker.Designers.EventConditionActionSystem.Actions.AddDialogNotification
        {
          typeof(AddDialogNotification),
          new MethodOverrideList(new MethodOverride().RequireFields("Text"))
        },

        // Kingmaker.UnitLogic.Mechanics.Actions.ContextActionRunAnimationClip
        {
          typeof(ContextActionRunAnimationClip),
          new MethodOverrideList(
            new MethodOverride().RequireFields("ClipWrapper").SetDefaultFields(("Mode", "ExecutionMode.Interrupted")))
        },
        // Kingmaker.UnitLogic.Mechanics.Actions.ContextActionShowBark
        {
          typeof(ContextActionShowBark),
          new MethodOverrideList(new MethodOverride().RequireFields("WhatToBark"))
        },
        // Kingmaker.UnitLogic.Mechanics.Actions.ContextActionSpawnFx
        {
          typeof(ContextActionSpawnFx),
          new MethodOverrideList(new MethodOverride().RequireFields("PrefabLink"))
        },

        // Kingmaker.Assets.UnitLogic.Mechanics.Actions.ContextActionPlaySound
        {
          typeof(ContextActionPlaySound),
          new MethodOverrideList(new MethodOverride().RequireFields("SoundName"))
        },

        //**** ActionsBuilderBasicEx ****//

        // Kingmaker.Designers.EventConditionActionSystem.Actions.AttachBuff
        {
          typeof(AttachBuff),
          new MethodOverrideList(new MethodOverride().RequireFields("m_Buff", "Target", "Duration"))
        },
        // Kingmaker.Designers.EventConditionActionSystem.Actions.CreaturesAround
        {
          typeof(CreaturesAround),
          new MethodOverrideList(
            new MethodOverride().UseName("OnCreaturesAround").RequireFields("Actions", "Radius", "Center"))
        },
        // Kingmaker.Designers.EventConditionActionSystem.Actions.AddFact
        {
          typeof(AddFact),
          new MethodOverrideList(new MethodOverride().RequireFields("m_Fact", "Unit"))
        },
        // Kingmaker.Designers.EventConditionActionSystem.Actions.AddFatigueHours
        {
          typeof(AddFatigueHours),
          new MethodOverrideList(new MethodOverride().RequireFields("Hours", "Unit"))
        },
        // Kingmaker.Designers.EventConditionActionSystem.Actions.ChangeAlignment
        {
          typeof(ChangeAlignment),
          new MethodOverrideList(new MethodOverride().RequireFields("Alignment"))
        },
        // Kingmaker.Designers.EventConditionActionSystem.Actions.ChangePlayerAlignment
        {
          typeof(ChangePlayerAlignment),
          new MethodOverrideList(new MethodOverride().RequireFields("TargetAlignment"))
        },
        // Kingmaker.Designers.EventConditionActionSystem.Actions.DamageParty
        {
          typeof(DamageParty),
          new MethodOverrideList(
            new MethodOverride()
              .RequireFields("Damage")
              .OverrideFields(
                ("DamageSource",
                  new FieldParamOverride
                  {
                    ExtraAssignmentFmtLines = new() { "{0}.NoSource = {1} is null;" }
                  })))
        },
        // Kingmaker.Designers.EventConditionActionSystem.Actions.DealDamage
        {
          typeof(DealDamage),
          new MethodOverrideList(
            new MethodOverride()
              .RequireFields("Target", "Damage")
              .OverrideFields(
                ("Source",
                  new FieldParamOverride
                  {
                    ExtraAssignmentFmtLines = new() { "{0}.NoSource = {1} is null;" }
                  })))
        },
        // Kingmaker.Designers.EventConditionActionSystem.Actions.DealStatDamage
        {
          typeof(DealStatDamage),
          new MethodOverrideList(
            new MethodOverride()
              .RequireFields("Target", "Stat", "DamageDice")
              .OverrideFields(
                ("Source",
                  new FieldParamOverride
                  {
                    ExtraAssignmentFmtLines = new() { "{0}.NoSource = {1} is null;" }
                  })))
        },
        // Kingmaker.Designers.EventConditionActionSystem.Actions.AddItemsToCollection
        {
          typeof(AddItemsToCollection),
          new MethodOverrideList(
            new MethodOverride()
              .UseName("AddItems")
              .OverrideFields(
                ("Loot", new RequiredFieldParam { ParamName = "items" }),
                ("ItemsCollection", new RequiredFieldParam { ParamName = "toCollection" })),
            new MethodOverride()
              .UseName("AddItemsFromBlueprint")
              .RequireFields("m_BlueprintLoot")
              .OverrideFields(("ItemsCollection", new RequiredFieldParam { ParamName = "toCollection" })))
        },

        // Kingmaker.Designers.EventConditionActionSystem.Actions.AddItemToPlayer
        {
          typeof(AddItemToPlayer),
          new MethodOverrideList(
            new MethodOverride()
              .UseName("GiveItemToPlayer")
              .AddRemarks(AddItemToPlayerRemarks)
              .IgnoreFields("Equip", "EquipOn", "ErrorIfDidNotEquip", "PreferredWeaponSet")
              .OverrideFields(
                ("m_ItemToGive",
                new RequiredFieldParam
                {
                  Imports = new() { typeof(BlueprintItemEquipmentHand), typeof(BlueprintItemEquipment) },
                  ExtraAssignmentFmtLines =
                    new()
                    {
                      "var bp = {1}.Instance;",
                      "if (bp is BlueprintItemEquipmentHand)",
                      "{{",
                      "  throw new InvalidOperationException(\"Item fits in hand slot. Use GiveHandSlotItemToPlayer.\");",
                      "}}",
                      "else if (bp is BlueprintItemEquipment)",
                      "{{",
                      "  throw new InvalidOperationException(\"Item is equipment. Use GiveEquipmentToPlayer.\");",
                      "}}",
                    }
                })),
            new MethodOverride()
              .UseName("GiveEquipmentToPlayer")
              .AddRemarks(AddItemToPlayerRemarks.ToArray())
              .IgnoreFields("PreferredWeaponSet")
              .OverrideFields(
                ("m_ItemToGive",
                new RequiredFieldParam
                {
                  Imports = new() { typeof(BlueprintItemEquipmentHand), typeof(BlueprintItemEquipment) },
                  ExtraAssignmentFmtLines =
                    new()
                    {
                      "var bp = {1}.Instance;",
                      "if (bp is BlueprintItemEquipmentHand)",
                      "{{",
                      "  throw new InvalidOperationException(\"Item fits in hand slot. Use GiveHandSlotItemToPlayer.\");",
                      "}}",
                      "else if (bp is not BlueprintItemEquipment)",
                      "{{",
                      "  throw new InvalidOperationException(\"Item is not equipment. Use GiveItemToPlayer.\");",
                      "}}",
                    }
                })),
            new MethodOverride()
              .UseName("GiveHandSlotItemToPlayer")
              .AddRemarks(AddItemToPlayerRemarks.ToArray())
              .OverrideFields(
                ("m_ItemToGive",
                new RequiredFieldParam
                {
                  Imports = new() { typeof(BlueprintItemEquipmentHand), typeof(BlueprintItemEquipment) },
                  ExtraAssignmentFmtLines =
                    new()
                    {
                      "var bp = {1}.Instance;",
                      "if (bp is not BlueprintItemEquipmentHand)",
                      "{{",
                      "  if (bp is BlueprintItemEquipment)",
                      "  {{",
                      "    throw new InvalidOperationException(\"Item does not fit in hand slot. Use GiveEquipmentToPlayer.\");",
                      "  }}",
                      "  else",
                      "  {{",
                      "    throw new InvalidOperationException(\"Item is not equipment. Use GiveItemToPlayer.\");",
                      "  }}",
                      "}}"
                    }
                })))
        },
        // Kingmaker.Designers.EventConditionActionSystem.Actions.AdvanceUnitLevel
        {
          typeof(AdvanceUnitLevel),
          new MethodOverrideList(new MethodOverride().RequireFields("Unit", "Level"))
        },
        // Kingmaker.Designers.EventConditionActionSystem.Actions.DestroyUnit
        {
          typeof(DestroyUnit),
          new MethodOverrideList(new MethodOverride().RequireFields("Target"))
        },
        // Kingmaker.Designers.EventConditionActionSystem.Actions.CombineToGroup
        {
          typeof(CombineToGroup),
          new MethodOverrideList(new MethodOverride().RequireFields("TargetUnit", "GroupHolder"))
        },
        // Kingmaker.Designers.EventConditionActionSystem.Actions.ClearUnitReturnPosition
        {
          typeof(ClearUnitReturnPosition),
          new MethodOverrideList(
            new MethodOverride().RequireFields("Unit"),
            new MethodOverride().UseName("ClearAllUnitReturnPosition").IgnoreFields("Unit"))
        },
        // Kingmaker.Designers.EventConditionActionSystem.Actions.AddUnitToSummonPool
        {
          typeof(AddUnitToSummonPool),
          new MethodOverrideList(new MethodOverride().RequireFields("m_SummonPool", "Unit"))
        },
        // Kingmaker.Designers.EventConditionActionSystem.Actions.DeleteUnitFromSummonPool
        {
          typeof(DeleteUnitFromSummonPool),
          new MethodOverrideList(new MethodOverride().RequireFields("m_SummonPool", "Unit"))
        },

        //**** ActionsBuilderContextEx ****//

        // Kingmaker.UnitLogic.Mechanics.Actions.ContextActionAddFeature
        {
          typeof(ContextActionAddFeature),
          new MethodOverrideList(new MethodOverride().RequireFields("m_PermanentFeature"))
        },
        // Kingmaker.UnitLogic.Mechanics.Actions.ContextActionAddLocustClone
        {
          typeof(ContextActionAddLocustClone),
          new MethodOverrideList(new MethodOverride().RequireFields("m_CloneFeature"))
        },
        // Kingmaker.UnitLogic.Mechanics.Actions.ContextActionApplyBuff
        {
          typeof(ContextActionApplyBuff),
          new MethodOverrideList(
            new MethodOverride()
              .UseName("ApplyBuffPermanent")
              .RequireFields("m_Buff")
              .IgnoreFields("DurationSeconds", "DurationValue")
              .SetConstantFields(("UseDurationSeconds", "false"), ("Permanent", "true")),
            new MethodOverride()
              .UseName("ApplyBuffWithDurationSeconds")
              .RequireFields("m_Buff", "DurationSeconds")
              .IgnoreFields("DurationValue")
              .SetConstantFields(("UseDurationSeconds", "true"), ("Permanent", "false")),
            new MethodOverride()
              .UseName("ApplyBuff")
              .RequireFields("m_Buff", "DurationValue")
              .IgnoreFields("DurationSeconds")
              .SetConstantFields(("UseDurationSeconds", "false"), ("Permanent", "false")))
        },

        //**** ActionsBuilderKingdomEx ****//

        // Kingmaker.Designers.EventConditionActionSystem.Actions.CreateArmy
        {
          typeof(CreateArmy),
          new MethodOverrideList(
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
                  })))
        },
      };
  }
}
