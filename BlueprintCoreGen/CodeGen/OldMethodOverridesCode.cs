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

//        //**** ActionsBuilderBasicEx ****//

//        // Kingmaker.Designers.EventConditionActionSystem.Actions.AttachBuff
//        {
//          typeof(AttachBuff),
//          new MethodOverrideList(new MethodOverride().RequireFields("m_Buff", "Target", "Duration"))
//        },
//        // Kingmaker.Designers.EventConditionActionSystem.Actions.CreaturesAround
//        {
//          typeof(CreaturesAround),
//          new MethodOverrideList(
//            new MethodOverride().UseName("OnCreaturesAround").RequireFields("Actions", "Radius", "Center"))
//        },
//        // Kingmaker.Designers.EventConditionActionSystem.Actions.AddFact
//        {
//          typeof(AddFact),
//          new MethodOverrideList(new MethodOverride().RequireFields("m_Fact", "Unit"))
//        },
//        // Kingmaker.Designers.EventConditionActionSystem.Actions.AddFatigueHours
//        {
//          typeof(AddFatigueHours),
//          new MethodOverrideList(new MethodOverride().RequireFields("Hours", "Unit"))
//        },
//        // Kingmaker.Designers.EventConditionActionSystem.Actions.ChangeAlignment
//        {
//          typeof(ChangeAlignment),
//          new MethodOverrideList(new MethodOverride().RequireFields("Alignment"))
//        },
//        // Kingmaker.Designers.EventConditionActionSystem.Actions.ChangePlayerAlignment
//        {
//          typeof(ChangePlayerAlignment),
//          new MethodOverrideList(new MethodOverride().RequireFields("TargetAlignment"))
//        },
//        // Kingmaker.Designers.EventConditionActionSystem.Actions.DamageParty
//        {
//          typeof(DamageParty),
//          new MethodOverrideList(
//            new MethodOverride()
//              .RequireFields("Damage")
//              .OverrideFields(
//                ("DamageSource",
//                  new ParameterOverride
//                  {
//                    ExtraAssignmentFmtLines = new() { "{0}.NoSource = {1} is null;" }
//                  })))
//        },
//        // Kingmaker.Designers.EventConditionActionSystem.Actions.DealDamage
//        {
//          typeof(DealDamage),
//          new MethodOverrideList(
//            new MethodOverride()
//              .RequireFields("Target", "Damage")
//              .OverrideFields(
//                ("Source",
//                  new ParameterOverride
//                  {
//                    ExtraAssignmentFmtLines = new() { "{0}.NoSource = {1} is null;" }
//                  })))
//        },
//        // Kingmaker.Designers.EventConditionActionSystem.Actions.DealStatDamage
//        {
//          typeof(DealStatDamage),
//          new MethodOverrideList(
//            new MethodOverride()
//              .RequireFields("Target", "Stat", "DamageDice")
//              .OverrideFields(
//                ("Source",
//                  new ParameterOverride
//                  {
//                    ExtraAssignmentFmtLines = new() { "{0}.NoSource = {1} is null;" }
//                  })))
//        },
//        // Kingmaker.Designers.EventConditionActionSystem.Actions.AddItemsToCollection
//        {
//          typeof(AddItemsToCollection),
//          new MethodOverrideList(
//            new MethodOverride()
//              .UseName("AddItems")
//              .OverrideFields(
//                ("Loot", new RequiredParameter { ParamName = "items" }),
//                ("ItemsCollection", new RequiredParameter { ParamName = "toCollection" })),
//            new MethodOverride()
//              .UseName("AddItemsFromBlueprint")
//              .RequireFields("m_BlueprintLoot")
//              .OverrideFields(("ItemsCollection", new RequiredParameter { ParamName = "toCollection" })))
//        },

//        // Kingmaker.Designers.EventConditionActionSystem.Actions.AddItemToPlayer
//        {
//          typeof(AddItemToPlayer),
//          new MethodOverrideList(
//            new MethodOverride()
//              .UseName("GiveItemToPlayer")
//              .WithRemarks(AddItemToPlayerRemarks)
//              .IgnoreFields("Equip", "EquipOn", "ErrorIfDidNotEquip", "PreferredWeaponSet")
//              .OverrideFields(
//                ("m_ItemToGive",
//                new RequiredParameter
//                {
//                  Imports = new() { typeof(BlueprintItemEquipmentHand), typeof(BlueprintItemEquipment) },
//                  ExtraAssignmentFmtLines =
//                    new()
//                    {
//                      "var bp = {1}.Instance;",
//                      "if (bp is BlueprintItemEquipmentHand)",
//                      "{{",
//                      "  throw new InvalidOperationException(\"Item fits in hand slot. Use GiveHandSlotItemToPlayer.\");",
//                      "}}",
//                      "else if (bp is BlueprintItemEquipment)",
//                      "{{",
//                      "  throw new InvalidOperationException(\"Item is equipment. Use GiveEquipmentToPlayer.\");",
//                      "}}",
//                    }
//                })),
//            new MethodOverride()
//              .UseName("GiveEquipmentToPlayer")
//              .WithRemarks(AddItemToPlayerRemarks)
//              .IgnoreFields("PreferredWeaponSet")
//              .OverrideFields(
//                ("m_ItemToGive",
//                new RequiredParameter
//                {
//                  Imports = new() { typeof(BlueprintItemEquipmentHand), typeof(BlueprintItemEquipment) },
//                  ExtraAssignmentFmtLines =
//                    new()
//                    {
//                      "var bp = {1}.Instance;",
//                      "if (bp is BlueprintItemEquipmentHand)",
//                      "{{",
//                      "  throw new InvalidOperationException(\"Item fits in hand slot. Use GiveHandSlotItemToPlayer.\");",
//                      "}}",
//                      "else if (bp is not BlueprintItemEquipment)",
//                      "{{",
//                      "  throw new InvalidOperationException(\"Item is not equipment. Use GiveItemToPlayer.\");",
//                      "}}",
//                    }
//                })),
//            new MethodOverride()
//              .UseName("GiveHandSlotItemToPlayer")
//              .WithRemarks(AddItemToPlayerRemarks)
//              .OverrideFields(
//                ("m_ItemToGive",
//                new RequiredParameter
//                {
//                  Imports = new() { typeof(BlueprintItemEquipmentHand), typeof(BlueprintItemEquipment) },
//                  ExtraAssignmentFmtLines =
//                    new()
//                    {
//                      "var bp = {1}.Instance;",
//                      "if (bp is not BlueprintItemEquipmentHand)",
//                      "{{",
//                      "  if (bp is BlueprintItemEquipment)",
//                      "  {{",
//                      "    throw new InvalidOperationException(\"Item does not fit in hand slot. Use GiveEquipmentToPlayer.\");",
//                      "  }}",
//                      "  else",
//                      "  {{",
//                      "    throw new InvalidOperationException(\"Item is not equipment. Use GiveItemToPlayer.\");",
//                      "  }}",
//                      "}}"
//                    }
//                })))
//        },
//        // Kingmaker.Designers.EventConditionActionSystem.Actions.AdvanceUnitLevel
//        {
//          typeof(AdvanceUnitLevel),
//          new MethodOverrideList(new MethodOverride().RequireFields("Unit", "Level"))
//        },
//        // Kingmaker.Designers.EventConditionActionSystem.Actions.DestroyUnit
//        {
//          typeof(DestroyUnit),
//          new MethodOverrideList(new MethodOverride().RequireFields("Target"))
//        },
//        // Kingmaker.Designers.EventConditionActionSystem.Actions.CombineToGroup
//        {
//          typeof(CombineToGroup),
//          new MethodOverrideList(new MethodOverride().RequireFields("TargetUnit", "GroupHolder"))
//        },
//        // Kingmaker.Designers.EventConditionActionSystem.Actions.ClearUnitReturnPosition
//        {
//          typeof(ClearUnitReturnPosition),
//          new MethodOverrideList(
//            new MethodOverride().RequireFields("Unit"),
//            new MethodOverride().UseName("ClearAllUnitReturnPosition").IgnoreFields("Unit"))
//        },
//        // Kingmaker.Designers.EventConditionActionSystem.Actions.AddUnitToSummonPool
//        {
//          typeof(AddUnitToSummonPool),
//          new MethodOverrideList(new MethodOverride().RequireFields("m_SummonPool", "Unit"))
//        },
//        // Kingmaker.Designers.EventConditionActionSystem.Actions.DeleteUnitFromSummonPool
//        {
//          typeof(DeleteUnitFromSummonPool),
//          new MethodOverrideList(new MethodOverride().RequireFields("m_SummonPool", "Unit"))
//        },

//        //**** ActionsBuilderContextEx ****//

//        // Kingmaker.UnitLogic.Mechanics.Actions.ContextActionAddFeature
//        {
//          typeof(ContextActionAddFeature),
//          new MethodOverrideList(new MethodOverride().RequireFields("m_PermanentFeature"))
//        },
//        // Kingmaker.UnitLogic.Mechanics.Actions.ContextActionAddLocustClone
//        {
//          typeof(ContextActionAddLocustClone),
//          new MethodOverrideList(new MethodOverride().RequireFields("m_CloneFeature"))
//        },
//        // Kingmaker.UnitLogic.Mechanics.Actions.ContextActionApplyBuff
//        {
//          typeof(ContextActionApplyBuff),
//          new MethodOverrideList(
//            new MethodOverride()
//              .UseName("ApplyBuffPermanent")
//              .RequireFields("m_Buff")
//              .IgnoreFields("DurationSeconds", "DurationValue")
//              .SetConstantFields(("UseDurationSeconds", "false"), ("Permanent", "true")),
//            new MethodOverride()
//              .UseName("ApplyBuffWithDurationSeconds")
//              .RequireFields("m_Buff", "DurationSeconds")
//              .IgnoreFields("DurationValue")
//              .SetConstantFields(("UseDurationSeconds", "true"), ("Permanent", "false")),
//            new MethodOverride()
//              .UseName("ApplyBuff")
//              .RequireFields("m_Buff", "DurationValue")
//              .IgnoreFields("DurationSeconds")
//              .SetConstantFields(("UseDurationSeconds", "false"), ("Permanent", "false")))
//        },
//        // Kingmaker.UnitLogic.Mechanics.Actions.ContextActionArmorEnchantPool
//        {
//          typeof(ContextActionArmorEnchantPool),
//          new MethodOverrideList(
//            new MethodOverride()
//              .WithRemarks(
//                new Remarks()
//                  .AddParagraph(
//                    "The caster's armor is enchanted based on its available enhancement bonus.",
//                    "e.g. If the armor can be enchanted to +4 and has a +1 enchantment, enchantmentPlus3 is applied.")
//                  .AddExample("SacredArmorEnchantSwitchAbility", "66484ebb8d358db4692ef4445fa6ac35"))
//              .RequireFields("EnchantPool", "DurationValue")
//              // Overridden by the manual extra parameter definitions
//              .IgnoreFields("m_DefaultEnchantments")
//              // Used for the default enchantment parameters
//              .AddImports(
//                typeof(BlueprintTool),
//                typeof(BlueprintItemEnchantment),
//                typeof(BlueprintItemEnchantmentReference),
//                typeof(ItemEnchantments))
//              .AddExtraParameters(
//                // +1 Armor Bonus
//                new ExtraParameter(
//                    "enchantmentPlus1",
//                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
//                    defaultValue: "null")
//                  .WithCommentFmt(
//                    GetBlueprintCommentFmtWithDefault(
//                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryArmorEnhancementBonus1"))
//                  .SetOperationFmt("{0}.m_DefaultEnchantments[0] = enchantmentPlus1?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus1.Reference;"),
//                // +2 Armor Bonus
//                new ExtraParameter(
//                    "enchantmentPlus2",
//                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
//                    defaultValue: "null")
//                  .WithCommentFmt(
//                    GetBlueprintCommentFmtWithDefault(
//                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryArmorEnhancementBonus2"))
//                  .SetOperationFmt("{0}.m_DefaultEnchantments[1] = enchantmentPlus2?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus2.Reference;"),
//                // +3 Armor Bonus
//                new ExtraParameter(
//                    "enchantmentPlus3",
//                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
//                    defaultValue: "null")
//                  .WithCommentFmt(
//                    GetBlueprintCommentFmtWithDefault(
//                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryArmorEnhancementBonus3"))
//                  .SetOperationFmt("{0}.m_DefaultEnchantments[2] = enchantmentPlus3?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus3.Reference;"),
//                // +4 Armor Bonus
//                new ExtraParameter(
//                    "enchantmentPlus4",
//                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
//                    defaultValue: "null")
//                  .WithCommentFmt(
//                    GetBlueprintCommentFmtWithDefault(
//                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryArmorEnhancementBonus4"))
//                  .SetOperationFmt("{0}.m_DefaultEnchantments[3] = enchantmentPlus4?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus4.Reference;"),
//                // +5 Armor Bonus
//                new ExtraParameter(
//                    "enchantmentPlus5",
//                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
//                    defaultValue: "null")
//                  .WithCommentFmt(
//                    GetBlueprintCommentFmtWithDefault(
//                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryArmorEnhancementBonus5"))
//                  .SetOperationFmt("{0}.m_DefaultEnchantments[4] = enchantmentPlus5?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus5.Reference;")))
//        },
//        // Kingmaker.UnitLogic.Mechanics.Actions.ContextActionShieldArmorEnchantPool
//        {
//          typeof(ContextActionShieldArmorEnchantPool),
//          new MethodOverrideList(
//            new MethodOverride()
//              .WithRemarks(
//                new Remarks()
//                  .AddParagraph(
//                    "The caster's shield is enchanted based on its available enhancement bonus.",
//                    "e.g. If the shield can be enchanted to +4 and has a +1 enchantment, enchantmentPlus3 is applied.")
//                  .AddExample("SacredArmorShieldEnchantSwitchAbility", "b0777d9974795a5489ff0efd735a4c2a"))
//              .RequireFields("EnchantPool", "DurationValue")
//              // Overridden by the manual extra parameter definitions
//              .IgnoreFields("m_DefaultEnchantments")
//              // Used for the default enchantment parameters
//              .AddImports(
//                typeof(BlueprintTool),
//                typeof(BlueprintItemEnchantment),
//                typeof(BlueprintItemEnchantmentReference),
//                typeof(ItemEnchantments))
//              .AddExtraParameters(
//                // +1 Armor Bonus
//                new ExtraParameter(
//                    "enchantmentPlus1",
//                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
//                    defaultValue: "null")
//                  .WithCommentFmt(
//                    GetBlueprintCommentFmtWithDefault(
//                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryArmorEnhancementBonus1"))
//                  .SetOperationFmt("{0}.m_DefaultEnchantments[0] = enchantmentPlus1?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus1.Reference;"),
//                // +2 Armor Bonus
//                new ExtraParameter(
//                    "enchantmentPlus2",
//                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
//                    defaultValue: "null")
//                  .WithCommentFmt(
//                    GetBlueprintCommentFmtWithDefault(
//                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryArmorEnhancementBonus2"))
//                  .SetOperationFmt("{0}.m_DefaultEnchantments[1] = enchantmentPlus2?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus2.Reference;"),
//                // +3 Armor Bonus
//                new ExtraParameter(
//                    "enchantmentPlus3",
//                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
//                    defaultValue: "null")
//                  .WithCommentFmt(
//                    GetBlueprintCommentFmtWithDefault(
//                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryArmorEnhancementBonus3"))
//                  .SetOperationFmt("{0}.m_DefaultEnchantments[2] = enchantmentPlus3?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus3.Reference;"),
//                // +4 Armor Bonus
//                new ExtraParameter(
//                    "enchantmentPlus4",
//                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
//                    defaultValue: "null")
//                  .WithCommentFmt(
//                    GetBlueprintCommentFmtWithDefault(
//                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryArmorEnhancementBonus4"))
//                  .SetOperationFmt("{0}.m_DefaultEnchantments[3] = enchantmentPlus4?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus4.Reference;"),
//                // +5 Armor Bonus
//                new ExtraParameter(
//                    "enchantmentPlus5",
//                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
//                    defaultValue: "null")
//                  .WithCommentFmt(
//                    GetBlueprintCommentFmtWithDefault(
//                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryArmorEnhancementBonus5"))
//                  .SetOperationFmt("{0}.m_DefaultEnchantments[4] = enchantmentPlus5?.Reference ?? ItemEnchantments.TemporaryArmorEnhancementBonus5.Reference;")))
//        },
//        // Kingmaker.UnitLogic.Mechanics.Actions.ContextActionWeaponEnchantPool
//        {
//          typeof(ContextActionWeaponEnchantPool),
//          new MethodOverrideList(
//            new MethodOverride()
//              .WithRemarks(
//                new Remarks()
//                  .AddParagraph(
//                    "The caster's weapon is enchanted based on its available enhancement bonus.",
//                    "e.g. If the weapon can be enchanted to +4 and has a +1 enchantment, enchantmentPlus3 is applied.")
//                  .AddExample("SacredWeaponEnchantSwitchAbility", "cca63747a12b55f44ad56ef2d840d7f4"))
//              .RequireFields("EnchantPool", "DurationValue")
//              // Overridden by the manual extra parameter definitions
//              .IgnoreFields("m_DefaultEnchantments")
//              // Used for the default enchantment parameters
//              .AddImports(
//                typeof(BlueprintTool),
//                typeof(BlueprintItemEnchantment),
//                typeof(BlueprintItemEnchantmentReference),
//                typeof(ItemEnchantments))
//              .AddExtraParameters(
//                // +1 Bonus
//                new ExtraParameter(
//                    "enchantmentPlus1",
//                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
//                    defaultValue: "null")
//                  .WithCommentFmt(
//                    GetBlueprintCommentFmtWithDefault(
//                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryEnhancementBonus1"))
//                  .SetOperationFmt("{0}.m_DefaultEnchantments[0] = enchantmentPlus1?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus1.Reference;"),
//                // +2 Bonus
//                new ExtraParameter(
//                    "enchantmentPlus2",
//                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
//                    defaultValue: "null")
//                  .WithCommentFmt(
//                    GetBlueprintCommentFmtWithDefault(
//                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryEnhancementBonus1"))
//                  .SetOperationFmt("{0}.m_DefaultEnchantments[1] = enchantmentPlus2?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus2.Reference;"),
//                // +3 Bonus
//                new ExtraParameter(
//                    "enchantmentPlus3",
//                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
//                    defaultValue: "null")
//                  .WithCommentFmt(
//                    GetBlueprintCommentFmtWithDefault(
//                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryEnhancementBonus3"))
//                  .SetOperationFmt("{0}.m_DefaultEnchantments[2] = enchantmentPlus3?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus3.Reference;"),
//                // +4 Bonus
//                new ExtraParameter(
//                    "enchantmentPlus4",
//                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
//                    defaultValue: "null")
//                  .WithCommentFmt(
//                    GetBlueprintCommentFmtWithDefault(
//                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryEnhancementBonus4"))
//                  .SetOperationFmt("{0}.m_DefaultEnchantments[3] = enchantmentPlus4?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus4.Reference;"),
//                // +5 Bonus
//                new ExtraParameter(
//                    "enchantmentPlus5",
//                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
//                    defaultValue: "null")
//                  .WithCommentFmt(
//                    GetBlueprintCommentFmtWithDefault(
//                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryEnhancementBonus5"))
//                  .SetOperationFmt("{0}.m_DefaultEnchantments[4] = enchantmentPlus5?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus5.Reference;")))
//        },
//        // Kingmaker.UnitLogic.Mechanics.Actions.ContextActionShieldWeaponEnchantPool
//        {
//          typeof(ContextActionShieldWeaponEnchantPool),
//          new MethodOverrideList(
//            new MethodOverride()
//              .WithRemarks(
//                new Remarks()
//                  .AddParagraph(
//                    "The caster's shield is enchanted based on its available enhancement bonus.",
//                    "e.g. If the shield can be enchanted to +4 and has a +1 enchantment, enchantmentPlus3 is applied.")
//                  .AddExample("SacredWeaponShieldEnchantSwitchAbility", "a89fc47958b895948a6c613ec1b9da85"))
//              .RequireFields("EnchantPool", "DurationValue")
//              // Overridden by the manual extra parameter definitions
//              .IgnoreFields("m_DefaultEnchantments")
//              // Used for the default enchantment parameters
//              .AddImports(
//                typeof(BlueprintTool),
//                typeof(BlueprintItemEnchantment),
//                typeof(BlueprintItemEnchantmentReference),
//                typeof(ItemEnchantments))
//              .AddExtraParameters(
//                // +1 Bonus
//                new ExtraParameter(
//                    "enchantmentPlus1",
//                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
//                    defaultValue: "null")
//                  .WithCommentFmt(
//                    GetBlueprintCommentFmtWithDefault(
//                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryEnhancementBonus1"))
//                  .SetOperationFmt("{0}.m_DefaultEnchantments[0] = enchantmentPlus1?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus1.Reference;"),
//                // +2 Bonus
//                new ExtraParameter(
//                    "enchantmentPlus2",
//                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
//                    defaultValue: "null")
//                  .WithCommentFmt(
//                    GetBlueprintCommentFmtWithDefault(
//                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryEnhancementBonus1"))
//                  .SetOperationFmt("{0}.m_DefaultEnchantments[1] = enchantmentPlus2?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus2.Reference;"),
//                // +3 Bonus
//                new ExtraParameter(
//                    "enchantmentPlus3",
//                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
//                    defaultValue: "null")
//                  .WithCommentFmt(
//                    GetBlueprintCommentFmtWithDefault(
//                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryEnhancementBonus3"))
//                  .SetOperationFmt("{0}.m_DefaultEnchantments[2] = enchantmentPlus3?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus3.Reference;"),
//                // +4 Bonus
//                new ExtraParameter(
//                    "enchantmentPlus4",
//                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
//                    defaultValue: "null")
//                  .WithCommentFmt(
//                    GetBlueprintCommentFmtWithDefault(
//                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryEnhancementBonus4"))
//                  .SetOperationFmt("{0}.m_DefaultEnchantments[3] = enchantmentPlus4?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus4.Reference;"),
//                // +5 Bonus
//                new ExtraParameter(
//                    "enchantmentPlus5",
//                    "Blueprint<BlueprintItemEnchantment, BlueprintItemEnchantmentReference>",
//                    defaultValue: "null")
//                  .WithCommentFmt(
//                    GetBlueprintCommentFmtWithDefault(
//                      typeof(BlueprintItemEnchantment), "Defaults to TemporaryEnhancementBonus5"))
//                  .SetOperationFmt("{0}.m_DefaultEnchantments[4] = enchantmentPlus5?.Reference ?? ItemEnchantments.TemporaryEnhancementBonus5.Reference;")))
//        },
//        // Kingmaker.UnitLogic.Mechanics.Actions.ContextActionAttackWithWeapon
//        {
//          typeof(ContextActionAttackWithWeapon),
//          new MethodOverrideList(new MethodOverride().RequireFields("m_Stat", "m_WeaponRef"))
//        },
//        // Kingmaker.UnitLogic.Mechanics.Actions.ContextActionBreathOfLife
//        {
//          typeof(ContextActionBreathOfLife),
//          new MethodOverrideList(new MethodOverride().RequireFields("Value"))
//        },
//        // Kingmaker.UnitLogic.Mechanics.Actions.ContextActionBreathOfMoney
//        {
//          typeof(ContextActionBreathOfMoney),
//          new MethodOverrideList(new MethodOverride().RequireFields("MinCoins", "MaxCoins"))
//        },
//        // Kingmaker.UnitLogic.Mechanics.Actions.ContextActionCastSpell
//        {
//          typeof(ContextActionCastSpell),
//          new MethodOverrideList(
//            new MethodOverride()
//              .RequireFields("m_Spell")
//              .IgnoreFields("OverrideDC", "OverrideSpellLevel")
//              .OverrideFields(
//                ("DC",
//                  new ParameterOverride
//                  {
//                    ParamName = "overrideDC",
//                    CommentFmt = new() { "Overrides the default spell DC" },
//                    ExtraAssignmentFmtLines = new() { "{0}.OverrideDC = overrideDC is not null;" }
//                  }),
//                ("SpellLevel",
//                  new ParameterOverride
//                  {
//                    ParamName = "overrideSpellLevel",
//                    CommentFmt = new() { "Overrides the default spell level" },
//                    ExtraAssignmentFmtLines = new() { "{0}.OverrideSpellLevel = overrideSpellLevel is not null;" }
//                  })))
//        },

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
