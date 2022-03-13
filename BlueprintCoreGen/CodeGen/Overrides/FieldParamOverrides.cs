using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Mechanics;
using System;
using System.Collections.Generic;

namespace BlueprintCoreGen.CodeGen.Override
{
  /// <summary>
  /// Manual overrides for FieldParameter. Imports adds to existing imports but other fields replace their counterpart
  /// when set.
  /// </summary>
  public class ParameterOverride
  {
    public bool Ignore = false;

    public bool SkipDeclaration = false;

    public bool? IsNullable;

    public List<Type> Imports = new();

    public string? ParamName;

    public string? TypeName;

    public List<string>? CommentFmt;

    public string? DefaultValue;

    public List<string>? ValidationFmt;

    public string? AssignmentRhsFmt;

    public string? AssignmentIfNullRhs;

    public List<string>? ExtraAssignmentFmtLines;
  }

  /// <summary>
  /// Overrides a field to skip the parameter declaration and requires an assignment statement to assign a constant
  /// values.
  /// </summary>
  public class ConstantParameter : ParameterOverride
  {
    public ConstantParameter(string constantValue) : base()
    {
      IsNullable = false;
      SkipDeclaration = true;
      AssignmentRhsFmt = constantValue;
      AssignmentIfNullRhs = "";
    }
  }

  public class DefaultParameter : ParameterOverride
  {
    public DefaultParameter(string defaultValue) : base()
    {
      IsNullable = false;
      DefaultValue = defaultValue;
    }
  }

  /// <summary>
  /// Overrides a field to make it required (no default value).
  /// </summary>
  public class RequiredParameter : ParameterOverride
  {
    public RequiredParameter() : base()
    {
      IsNullable = false;
      DefaultValue = "";
      AssignmentIfNullRhs = "";
    }
  }

  /// <summary>
  /// Overrides a field to make it ignored.
  /// </summary>
  public class IgnoredParameter : ParameterOverride
  {
    public IgnoredParameter() : base()
    {
      Ignore = true;
    }
  }

  /// <summary>
  /// Contains hand-tuned overrides for generated methods.
  /// </summary>
  public class FieldParamOverrides
  {
    /// <summary>
    /// Maps from a field type to a FieldParamOverride
    /// </summary>
    public static readonly Dictionary<Type, ParameterOverride> ByType =
      new()
      {
        // Kingmaker.ElementsSystem.ActionList
        {
          typeof(ActionList),
          new ParameterOverride
          {
            Imports = new() { typeof(ActionsBuilder), typeof(Constants) },
            TypeName = "ActionsBuilder",
            DefaultValue = "null",
            ValidationFmt = new(),
            AssignmentRhsFmt = "{0}.Build()",
            AssignmentIfNullRhs = "Constants.Empty.Actions"
          }
        },

        // Kingmaker.ElementsSystem.Conditions
        {
          typeof(ConditionsChecker),
          new ParameterOverride
          {
            Imports = new() { typeof(ConditionsBuilder), typeof(Constants) },
            TypeName = "ConditionsBuilder",
            DefaultValue = "null",
            ValidationFmt = new(),
            AssignmentRhsFmt = "{0}.Build()",
            AssignmentIfNullRhs = "Constants.Empty.Conditions"
          }
        },

        //**** Empty Fields

        // Kingmaker.UnitLogic.Mechanics.ContextDiceValue
        {
          typeof(ContextDiceValue),
          new ParameterOverride
          {
            Imports = new() { typeof(Constants) },
            ValidationFmt = new(),
            AssignmentIfNullRhs = "Constants.Empty.DiceValue"
          }
        },

        // Kingmaker.UnitLogic.Mechanics.ContextValue
        {
          typeof(ContextValue),
          new ParameterOverride
          {
            Imports = new() { typeof(ContextValues) },
            ValidationFmt = new(),
            AssignmentIfNullRhs = "ContextValues.Constant(0)"
          }
        },

        // Kingmaker.Localization.LocalizedString
        {
          typeof(LocalizedString),
          new ParameterOverride
          {
            Imports = new() { typeof(Constants) },
            ValidationFmt = new(),
            AssignmentIfNullRhs = "Constants.Empty.String"
          }
        },

        // Kingmaker.ResourceLinks.PrefabLink
        {
          typeof(PrefabLink),
          new ParameterOverride
          {
            Imports = new() { typeof(Constants) },
            ValidationFmt = new(),
            AssignmentIfNullRhs = "Constants.Empty.PrefabLink"
          }
        }

        //**** End Empty Fields
      };

    /// <summary>
    /// Maps from a source type to a map of FieldOverride by name. Use this for shared fields in a parent class. For
    /// fields in the type being constructed, use MethodOverride.
    /// </summary>
    public static readonly Dictionary<Type, Dictionary<string, ParameterOverride>> ByName =
      new()
      {
        // Kingmaker.ElementSystem.Condition
        {
          typeof(Condition),
          new()
          {
            {
              "Not",
              new ParameterOverride
              {
                IsNullable = false,
                ParamName = "negate",
                DefaultValue = "false"
              }
            }
          }
        },

        //**** Ignored Fields

        // Kingmaker.ElementsSystem.Element
        {
          typeof(Element),
          new()
          {
            {
              "name",
              new IgnoredParameter()
            }
          }
        },

        // Kingmaker.Blueprints.BlueprintComponent
        {
          typeof(BlueprintComponent),
          new()
          {
            {
              "m_Flags",
              new IgnoredParameter()
            },
            {
              "m_PrototypeLink",
              new IgnoredParameter()
            },
            {
              "name",
              new IgnoredParameter()
            },
          }
        },

        // Kingmaker.UnitLogic.Abilities.Components.Base.AbilityDeliverEffect
        {
          typeof(AbilityDeliverEffect),
          new()
          {
            {
              "m_HasIsAllyEffectRunConditions",
              new IgnoredParameter()
            }
          }
        },

        //**** End Ignored Fields
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
