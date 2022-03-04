using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Assets.UnitLogic.Mechanics.Actions;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Dungeon.Actions;
using Kingmaker.UnitLogic.Mechanics.Actions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCoreGen.CodeGen.Override
{
  public class Field
  {
    /// <summary>
    /// Name of the field.
    /// </summary>
    public string FieldName { get; }
  }

  /// <summary>
  /// Represents a field with a specific default value.
  /// </summary>
  public class DefaultField : Field
  {
    /// <summary>
    /// The default value of the field.
    /// </summary>
    public string Value { get; }
  }

  /// <summary>
  /// Represents a field with a constant value.
  /// </summary>
  public class ConstantField : Field
  {
    /// <summary>
    /// The constant value of the field.
    /// </summary>
    public string Value { get; }
  }

  public class CustomField : Field
  {
    /// <summary>
    /// Indicates whether the field is required when building the action.
    /// </summary>
    public bool Required { get; }

    /// <summary>
    /// Name of the field when provided as a function parameter.
    /// </summary>
    public string ParamName { get; }

    /// <summary>
    /// Additional lines of code added after assigning the field's value.
    /// </summary>
    public List<string> ExtraAssignmentFmtLines { get; } = new();
  }

  /// <summary>
  /// Represents an "Action" game type.
  /// </summary>
  public class Action
  {
    /// <summary>
    /// All action builder methods are grouped into extension classes. This determines which class contains the
    /// methods for building the action.
    /// </summary>
    public enum ExtensionType
    {
      Area,
      AV,
      Basic,
      Context,
      Kingdom,
      Misc,
      New,
      Story,
      Upgrader
    }

    /// <summary>
    /// The type name of the action. If there is a type name conflict this must be fully qualified.
    /// </summary>
    public string TypeName { get; }

    /// <summary>
    /// Indicates which extension class contains builder methods for the action.
    /// </summary>
    public ExtensionType Extension { get; }

    /// <summary>
    /// Remarks added to the method's comments. Uses XML Doc syntax. Each entry is a new line.
    /// </summary>
    public List<string> Remarks { get; }

    /// <summary>
    /// A list of types to import (by name).
    /// </summary>
    public List<string> Imports { get; } = new();

    /// <summary>
    /// List of fields (by name) required when building the action.
    /// </summary>
    public List<string> RequiredFields { get; } = new();

    /// <summary>
    /// List of fields (by name) ignored when building the action.
    /// </summary>
    public List<string> IgnoredFields { get; } = new();

    /// <summary>
    /// List of fields (by name) and their default values.
    /// </summary>
    public List<DefaultField> DefaultFields { get; } = new();

    /// <summary>
    /// List of fields (by name) and their constant values.
    /// </summary>
    public List<ConstantField> ConstantFields { get; } = new();

    /// <summary>
    /// List of fields (by name) to customize.
    /// </summary>
    public List<CustomField> CustomFields { get; } = new();

    public List<Method>? Methods { get; }
  }

  public class Method
  {
    public List<string> Imports { get; } = new();

    public List<string> Comments { get; } = new();

    public List<Blueprint> Examples { get; } = new();

    public string Name { get; }

    public List<string> RequiredFields { get; } = new();

    public List<string> IgnoredFields { get; } = new();

    public List<FieldParameter> FieldParameters { get; }

    public List<Parameter> Parameters { get; }
  }

  public class Parameter
  {
    public List<string> Imports { get; } = new();

    public string ParamName { get; }

    public List<string> Comments { get; }

    public string DefaultValue { get; }

    public List<string> OperationFmt { get; }
  }

  public class FieldParameter : Parameter
  {
    public string Name { get; }

    public List<string> AssignmentFmt { get; }
  }

  public struct Blueprint
  {
    public string Name { get; }

    public string Guid { get; }
  }

  /// <summary>
  /// Represents an extra parameter applied to a method as an override.
  /// </summary>
  public class ExtraParameter : IParameterInternal
  {
    public bool SkipDeclaration => false;

    public List<Type> Imports => new();

    public List<string> Comment { get; } = new();

    public bool Required => string.IsNullOrEmpty(DefaultValue);

    public string Declaration => Required ? $"{Type} {ParamName}" : $"{Type}? {ParamName} = {DefaultValue}";

    public string ParamName { get; private set; }

    private readonly string? DefaultValue;
    private readonly string Type;

    /// <summary>
    /// Operation format string where {0} is the object name and {1} is the parameter name, and {2} is the
    /// validation function.
    /// </summary>
    private List<string> OperationFmt = new();

    public List<string> GetOperation(string objectName, string validateFunction)
    {
      return OperationFmt.Select(line => string.Format(line, objectName, ParamName, validateFunction)).ToList();
    }

    public ExtraParameter(string paramName, string type, string? defaultValue = null)
    {
      ParamName = paramName;
      Type = type;
      DefaultValue = defaultValue;
    }

    /// <summary>
    /// Adds comment format lines where {0} is the parameter name.
    /// </summary>
    public ExtraParameter WithCommentFmt(params string[] linesFmt)
    {
      Comment.AddRange(
        linesFmt.Prepend("<param name=\"{0}\">").Append("</param>").Select(line => string.Format(line, ParamName)));
      return this;
    }

    public ExtraParameter SetOperationFmt(params string[] lines)
    {
      OperationFmt = lines.ToList();
      return this;
    }
  }

  /// <summary>
  /// Helper class to build method remarks.
  /// </summary>
  public class Remarks
  {
    private List<List<string>> Paragraphs = new();
    private List<(string blueprintName, string blueprintGuid)> Examples = new();

    public Remarks AddParagraph(params string[] lines)
    {
      Paragraphs.Add(lines.ToList());
      return this;
    }

    public Remarks AddExample(string blueprintName, string blueprintGuid)
    {
      Examples.Add((blueprintName, blueprintGuid));
      return this;
    }

    public List<string> ToList()
    {
      List<string> result = new() { "<remarks>" };
      Paragraphs.ForEach(
        paragraph =>
        {
          result.Add("<para>");
          paragraph.ForEach(line => result.Add(line));
          result.Add("</para>");
          result.Add("");
        });

      if (Examples.Any())
      {
        result.Add("<list type=\"bullet\">");
        result.Add("<listheader>");
        result.Add("  <term>Example Blueprints:</term>");
        result.Add("</listheader>");
        Examples.ForEach(
          example =>
          {
            result.Add("<item>");
            result.Add($"  <description>{example.blueprintName} - {example.blueprintGuid}</description>");
            result.Add("</item>");
          });
        result.Add("</list>");
      }
      result.Add("</remarks>");
      return result;
    }
  }

  /// <summary>
  /// Manual overrides for a method. 
  /// </summary>
  public class MethodOverride
  {
    public List<Type> Imports = new();

    public List<string> Remarks = new();

    public string? Name;

    public Dictionary<string, FieldParamOverride> FieldOverridesByName = new();

    public List<ExtraParameter> ExtraParameters = new();

    public MethodOverride AddImports(params Type[] types)
    {
      Imports.AddRange(types);
      return this;
    }

    public MethodOverride WithRemarks(Remarks remarks)
    {
      Remarks = remarks.ToList();
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

    public MethodOverride AddExtraParameters(params ExtraParameter[] extraParameters)
    {
      ExtraParameters.AddRange(extraParameters);
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
    private static readonly Remarks AddItemToPlayerRemarks =
      new Remarks()
        .AddParagraph(
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
        "</list>");

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
              .WithRemarks(AddItemToPlayerRemarks)
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
              .WithRemarks(AddItemToPlayerRemarks)
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
              .WithRemarks(AddItemToPlayerRemarks)
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
        // Kingmaker.UnitLogic.Mechanics.Actions.ContextActionArmorEnchantPool
        {
          typeof(ContextActionArmorEnchantPool),
          new MethodOverrideList(
            new MethodOverride()
              .WithRemarks(
                new Remarks()
                  .AddParagraph(
                    "The caster's armor is enchanted based on its available enhancement bonus.",
                    "e.g. If the armor can be enchanted to +4 and has a +1 enchantment, enchantmentPlus3 is applied.")
                  .AddExample("SacredArmorEnchantSwitchAbility", "66484ebb8d358db4692ef4445fa6ac35"))
              .RequireFields("EnchantPool", "DurationValue")
              // Overridden by the manual extra parameter definitions
              .IgnoreFields("m_DefaultEnchantments")
              // Used for the default enchantment parameters
              .AddImports(
                typeof(BlueprintTool),
                typeof(BlueprintItemEnchantment),
                typeof(BlueprintItemEnchantmentReference),
                typeof(ItemEnchantments))
              .AddExtraParameters(
                // +1 Armor Bonus
                new ExtraParameter(
                    "enchantmentPlus1",
                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
                    defaultValue: "null")
                  .WithCommentFmt(
                    GetBlueprintCommentFmtWithDefault(
                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryArmorEnhancementBonus1"))
                  .SetOperationFmt("{0}.m_DefaultEnchantments[0] = enchantmentPlus1?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus1.Reference;"),
                // +2 Armor Bonus
                new ExtraParameter(
                    "enchantmentPlus2",
                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
                    defaultValue: "null")
                  .WithCommentFmt(
                    GetBlueprintCommentFmtWithDefault(
                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryArmorEnhancementBonus2"))
                  .SetOperationFmt("{0}.m_DefaultEnchantments[1] = enchantmentPlus2?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus2.Reference;"),
                // +3 Armor Bonus
                new ExtraParameter(
                    "enchantmentPlus3",
                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
                    defaultValue: "null")
                  .WithCommentFmt(
                    GetBlueprintCommentFmtWithDefault(
                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryArmorEnhancementBonus3"))
                  .SetOperationFmt("{0}.m_DefaultEnchantments[2] = enchantmentPlus3?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus3.Reference;"),
                // +4 Armor Bonus
                new ExtraParameter(
                    "enchantmentPlus4",
                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
                    defaultValue: "null")
                  .WithCommentFmt(
                    GetBlueprintCommentFmtWithDefault(
                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryArmorEnhancementBonus4"))
                  .SetOperationFmt("{0}.m_DefaultEnchantments[3] = enchantmentPlus4?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus4.Reference;"),
                // +5 Armor Bonus
                new ExtraParameter(
                    "enchantmentPlus5",
                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
                    defaultValue: "null")
                  .WithCommentFmt(
                    GetBlueprintCommentFmtWithDefault(
                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryArmorEnhancementBonus5"))
                  .SetOperationFmt("{0}.m_DefaultEnchantments[4] = enchantmentPlus5?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus5.Reference;")))
        },
        // Kingmaker.UnitLogic.Mechanics.Actions.ContextActionShieldArmorEnchantPool
        {
          typeof(ContextActionShieldArmorEnchantPool),
          new MethodOverrideList(
            new MethodOverride()
              .WithRemarks(
                new Remarks()
                  .AddParagraph(
                    "The caster's shield is enchanted based on its available enhancement bonus.",
                    "e.g. If the shield can be enchanted to +4 and has a +1 enchantment, enchantmentPlus3 is applied.")
                  .AddExample("SacredArmorShieldEnchantSwitchAbility", "b0777d9974795a5489ff0efd735a4c2a"))
              .RequireFields("EnchantPool", "DurationValue")
              // Overridden by the manual extra parameter definitions
              .IgnoreFields("m_DefaultEnchantments")
              // Used for the default enchantment parameters
              .AddImports(
                typeof(BlueprintTool),
                typeof(BlueprintItemEnchantment),
                typeof(BlueprintItemEnchantmentReference),
                typeof(ItemEnchantments))
              .AddExtraParameters(
                // +1 Armor Bonus
                new ExtraParameter(
                    "enchantmentPlus1",
                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
                    defaultValue: "null")
                  .WithCommentFmt(
                    GetBlueprintCommentFmtWithDefault(
                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryArmorEnhancementBonus1"))
                  .SetOperationFmt("{0}.m_DefaultEnchantments[0] = enchantmentPlus1?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus1.Reference;"),
                // +2 Armor Bonus
                new ExtraParameter(
                    "enchantmentPlus2",
                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
                    defaultValue: "null")
                  .WithCommentFmt(
                    GetBlueprintCommentFmtWithDefault(
                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryArmorEnhancementBonus2"))
                  .SetOperationFmt("{0}.m_DefaultEnchantments[1] = enchantmentPlus2?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus2.Reference;"),
                // +3 Armor Bonus
                new ExtraParameter(
                    "enchantmentPlus3",
                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
                    defaultValue: "null")
                  .WithCommentFmt(
                    GetBlueprintCommentFmtWithDefault(
                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryArmorEnhancementBonus3"))
                  .SetOperationFmt("{0}.m_DefaultEnchantments[2] = enchantmentPlus3?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus3.Reference;"),
                // +4 Armor Bonus
                new ExtraParameter(
                    "enchantmentPlus4",
                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
                    defaultValue: "null")
                  .WithCommentFmt(
                    GetBlueprintCommentFmtWithDefault(
                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryArmorEnhancementBonus4"))
                  .SetOperationFmt("{0}.m_DefaultEnchantments[3] = enchantmentPlus4?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus4.Reference;"),
                // +5 Armor Bonus
                new ExtraParameter(
                    "enchantmentPlus5",
                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
                    defaultValue: "null")
                  .WithCommentFmt(
                    GetBlueprintCommentFmtWithDefault(
                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryArmorEnhancementBonus5"))
                  .SetOperationFmt("{0}.m_DefaultEnchantments[4] = enchantmentPlus5?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus5.Reference;")))
        },
        // Kingmaker.UnitLogic.Mechanics.Actions.ContextActionWeaponEnchantPool
        {
          typeof(ContextActionWeaponEnchantPool),
          new MethodOverrideList(
            new MethodOverride()
              .WithRemarks(
                new Remarks()
                  .AddParagraph(
                    "The caster's weapon is enchanted based on its available enhancement bonus.",
                    "e.g. If the weapon can be enchanted to +4 and has a +1 enchantment, enchantmentPlus3 is applied.")
                  .AddExample("SacredWeaponEnchantSwitchAbility", "cca63747a12b55f44ad56ef2d840d7f4"))
              .RequireFields("EnchantPool", "DurationValue")
              // Overridden by the manual extra parameter definitions
              .IgnoreFields("m_DefaultEnchantments")
              // Used for the default enchantment parameters
              .AddImports(
                typeof(BlueprintTool),
                typeof(BlueprintItemEnchantment),
                typeof(BlueprintItemEnchantmentReference),
                typeof(ItemEnchantments))
              .AddExtraParameters(
                // +1 Bonus
                new ExtraParameter(
                    "enchantmentPlus1",
                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
                    defaultValue: "null")
                  .WithCommentFmt(
                    GetBlueprintCommentFmtWithDefault(
                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryEnhancementBonus1"))
                  .SetOperationFmt("{0}.m_DefaultEnchantments[0] = enchantmentPlus1?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus1.Reference;"),
                // +2 Bonus
                new ExtraParameter(
                    "enchantmentPlus2",
                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
                    defaultValue: "null")
                  .WithCommentFmt(
                    GetBlueprintCommentFmtWithDefault(
                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryEnhancementBonus1"))
                  .SetOperationFmt("{0}.m_DefaultEnchantments[1] = enchantmentPlus2?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus2.Reference;"),
                // +3 Bonus
                new ExtraParameter(
                    "enchantmentPlus3",
                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
                    defaultValue: "null")
                  .WithCommentFmt(
                    GetBlueprintCommentFmtWithDefault(
                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryEnhancementBonus3"))
                  .SetOperationFmt("{0}.m_DefaultEnchantments[2] = enchantmentPlus3?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus3.Reference;"),
                // +4 Bonus
                new ExtraParameter(
                    "enchantmentPlus4",
                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
                    defaultValue: "null")
                  .WithCommentFmt(
                    GetBlueprintCommentFmtWithDefault(
                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryEnhancementBonus4"))
                  .SetOperationFmt("{0}.m_DefaultEnchantments[3] = enchantmentPlus4?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus4.Reference;"),
                // +5 Bonus
                new ExtraParameter(
                    "enchantmentPlus5",
                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
                    defaultValue: "null")
                  .WithCommentFmt(
                    GetBlueprintCommentFmtWithDefault(
                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryEnhancementBonus5"))
                  .SetOperationFmt("{0}.m_DefaultEnchantments[4] = enchantmentPlus5?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus5.Reference;")))
        },
        // Kingmaker.UnitLogic.Mechanics.Actions.ContextActionShieldWeaponEnchantPool
        {
          typeof(ContextActionShieldWeaponEnchantPool),
          new MethodOverrideList(
            new MethodOverride()
              .WithRemarks(
                new Remarks()
                  .AddParagraph(
                    "The caster's shield is enchanted based on its available enhancement bonus.",
                    "e.g. If the shield can be enchanted to +4 and has a +1 enchantment, enchantmentPlus3 is applied.")
                  .AddExample("SacredWeaponShieldEnchantSwitchAbility", "a89fc47958b895948a6c613ec1b9da85"))
              .RequireFields("EnchantPool", "DurationValue")
              // Overridden by the manual extra parameter definitions
              .IgnoreFields("m_DefaultEnchantments")
              // Used for the default enchantment parameters
              .AddImports(
                typeof(BlueprintTool),
                typeof(BlueprintItemEnchantment),
                typeof(BlueprintItemEnchantmentReference),
                typeof(ItemEnchantments))
              .AddExtraParameters(
                // +1 Bonus
                new ExtraParameter(
                    "enchantmentPlus1",
                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
                    defaultValue: "null")
                  .WithCommentFmt(
                    GetBlueprintCommentFmtWithDefault(
                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryEnhancementBonus1"))
                  .SetOperationFmt("{0}.m_DefaultEnchantments[0] = enchantmentPlus1?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus1.Reference;"),
                // +2 Bonus
                new ExtraParameter(
                    "enchantmentPlus2",
                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
                    defaultValue: "null")
                  .WithCommentFmt(
                    GetBlueprintCommentFmtWithDefault(
                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryEnhancementBonus1"))
                  .SetOperationFmt("{0}.m_DefaultEnchantments[1] = enchantmentPlus2?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus2.Reference;"),
                // +3 Bonus
                new ExtraParameter(
                    "enchantmentPlus3",
                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
                    defaultValue: "null")
                  .WithCommentFmt(
                    GetBlueprintCommentFmtWithDefault(
                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryEnhancementBonus3"))
                  .SetOperationFmt("{0}.m_DefaultEnchantments[2] = enchantmentPlus3?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus3.Reference;"),
                // +4 Bonus
                new ExtraParameter(
                    "enchantmentPlus4",
                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
                    defaultValue: "null")
                  .WithCommentFmt(
                    GetBlueprintCommentFmtWithDefault(
                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryEnhancementBonus4"))
                  .SetOperationFmt("{0}.m_DefaultEnchantments[3] = enchantmentPlus4?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus4.Reference;"),
                // +5 Bonus
                new ExtraParameter(
                    "enchantmentPlus5",
                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
                    defaultValue: "null")
                  .WithCommentFmt(
                    GetBlueprintCommentFmtWithDefault(
                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryEnhancementBonus5"))
                  .SetOperationFmt("{0}.m_DefaultEnchantments[4] = enchantmentPlus5?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus5.Reference;")))
        },
        // Kingmaker.UnitLogic.Mechanics.Actions.ContextActionAttackWithWeapon
        {
          typeof(ContextActionAttackWithWeapon),
          new MethodOverrideList(new MethodOverride().RequireFields("m_Stat", "m_WeaponRef"))
        },
        // Kingmaker.UnitLogic.Mechanics.Actions.ContextActionBreathOfLife
        {
          typeof(ContextActionBreathOfLife),
          new MethodOverrideList(new MethodOverride().RequireFields("Value"))
        },
        // Kingmaker.UnitLogic.Mechanics.Actions.ContextActionBreathOfMoney
        {
          typeof(ContextActionBreathOfMoney),
          new MethodOverrideList(new MethodOverride().RequireFields("MinCoins", "MaxCoins"))
        },
        // Kingmaker.UnitLogic.Mechanics.Actions.ContextActionCastSpell
        {
          typeof(ContextActionCastSpell),
          new MethodOverrideList(
            new MethodOverride()
              .RequireFields("m_Spell")
              .IgnoreFields("OverrideDC", "OverrideSpellLevel")
              .OverrideFields(
                ("DC",
                  new FieldParamOverride
                  {
                    ParamName = "overrideDC",
                    CommentFmt = new() { "Overrides the default spell DC" },
                    ExtraAssignmentFmtLines = new() { "{0}.OverrideDC = overrideDC is not null;" }
                  }),
                ("SpellLevel",
                  new FieldParamOverride
                  {
                    ParamName = "overrideSpellLevel",
                    CommentFmt = new() { "Overrides the default spell level" },
                    ExtraAssignmentFmtLines = new() { "{0}.OverrideSpellLevel = overrideSpellLevel is not null;" }
                  })))
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

    private static string[] GetBlueprintCommentFmtWithDefault(Type blueprintType, string defaultComment)
    {
      return ParametersFactory.GetBlueprintCommentFmt(blueprintType).Append("").Append(defaultComment).ToArray();
    }
  }
}
