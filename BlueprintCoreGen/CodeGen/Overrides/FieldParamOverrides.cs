using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Mechanics;
using System;
using System.Collections.Generic;

namespace BlueprintCoreGen.CodeGen.Overrides
{
  /// <summary>
  /// Manual overrides for FieldParameter. Imports adds to existing imports but other fields replace their counterpart
  /// when set.
  /// </summary>
  public class FieldParamOverride
  {
    public List<Type> Imports = new();

    public string? ParamName;

    public string? TypeName;

    public List<string>? CommentFmt;

    public string? DefaultValue;

    public List<string>? ValidationFmt;

    public List<string>? AssignmentFmt;

    public List<string>? AssignmentFmtIfNull;
  }

  /// <summary>
  /// Contains hand-tuned overrides for generated methods.
  /// </summary>
  public class FieldParamOverrides
  {
    /// <summary>
    /// Maps from a field type to a FieldParamOverride
    /// </summary>
    public static readonly Dictionary<Type, FieldParamOverride> ByType =
      new()
      {
        // Kingmaker.ElementsSystem.ActionList
        {
          typeof(ActionList),
          new FieldParamOverride
          {
            Imports = new() { typeof(ActionsBuilder), typeof(Constants) },
            TypeName = "ActionsBuilder?",
            DefaultValue = "null",
            ValidationFmt = new(),
            AssignmentFmt = new() { "{0}.{1} = {2}.Build();" },
            AssignmentFmtIfNull = new() { "{0}.{1} = Constants.Empty.Actions;" }
          }
        },

        // Kingmaker.ElementsSystem.Conditions
        {
          typeof(ConditionsChecker),
          new FieldParamOverride
          {
            Imports = new() { typeof(ConditionsBuilder), typeof(Constants) },
            TypeName = "ConditionsBuilder?",
            DefaultValue = "null",
            ValidationFmt = new(),
            AssignmentFmt = new() { "{0}.{1} = {2}.Build();" },
            AssignmentFmtIfNull = new() { "{0}.{1} = Constants.Empty.Conditions;" }
          }
        },

        //**** Empty Fields

        // Kingmaker.UnitLogic.Mechanics.ContextDiceValue
        {
          typeof(ContextDiceValue),
          new FieldParamOverride
          {
            Imports = new() { typeof(Constants) },
            ValidationFmt = new(),
            AssignmentFmtIfNull = new() { "{0}.{1} = Constants.Empty.DiceValue;" }
          }
        },

        // Kingmaker.UnitLogic.Mechanics.ContextValue
        {
          typeof(ContextValue),
          new FieldParamOverride
          {
            Imports = new() { typeof(ContextValues) },
            ValidationFmt = new(),
            AssignmentFmtIfNull = new() { "{0}.{1} = ContextValues.Constant(0);" }
          }
        },

        // Kingmaker.Localization.LocalizedString
        {
          typeof(LocalizedString),
          new FieldParamOverride
          {
            Imports = new() { typeof(Constants) },
            ValidationFmt = new(),
            AssignmentFmtIfNull = new() { "{0}.{1} = Constants.Empty.String;" }
          }
        },

        // Kingmaker.ResourceLinks.PrefabLink
        {
          typeof(PrefabLink),
          new FieldParamOverride
          {
            Imports = new() { typeof(Constants) },
            ValidationFmt = new(),
            AssignmentFmtIfNull = new() { "{0}.{1} = Constants.Empty.PrefabLink;" }
          }
        }

        //**** End Empty Fields
      };

    /// <summary>
    /// Maps from a source type to a map of FieldOverride by name
    /// </summary>
    public static readonly Dictionary<Type, Dictionary<string, FieldParamOverride>> ByName =
      new()
      {
        // Kingmaker.ElementSystem.Condition
        {
          typeof(Condition),
          new()
          {
            {
              "Not",
              new FieldParamOverride
              {
                TypeName = "bool",
                ParamName = "negate",
                DefaultValue = "false",
                AssignmentFmt = new() { "{0}.Not = negate;" },
                AssignmentFmtIfNull = new()
              }
            }
          }
        }
      };

    ///// <summary>
    ///// Returns a field with manual overrides applied.
    ///// </summary>
    //public static IField GetFor(IField field, Type sourceType)
    //{
    //  if (FieldToCustomField.ContainsKey(sourceType) && FieldToCustomField[sourceType].ContainsKey(field.Name))
    //  {
    //    return new CustomField(field, FieldToCustomField[sourceType][field.Name]);
    //  }
    //  return field;
    //}

    //private static readonly Dictionary<Type, Dictionary<string, Override>> FieldToCustomField =
    //    new()
    //    {
    //      {
    //        typeof(AddContextStatBonus),
    //        new()
    //        {
    //          { "Stat", new Override().WithDefaultValue(null) },
    //          { "Value", new Override().WithDefaultValue(null) },
    //          { "Multiplier", new Override().WithDefaultValue("1") },
    //          {
    //            "Minimal",
    //            new Override()
    //                .WithParamName("minimal")
    //                .WithDefaultValue("null")
    //                .WithTypeName("int?")
    //                .WithAssignment(new() { "{0}.Minimal = minimal ?? 0;" })
    //          },
    //          {
    //            "HasMinimal",
    //            new Override()
    //                .WithParamName(null)
    //                .WithAssignment(new() { "{0}.HasMinimal = minimal is not null;" })
    //          }
    //        }
    //      }
    //    };
  }
}
