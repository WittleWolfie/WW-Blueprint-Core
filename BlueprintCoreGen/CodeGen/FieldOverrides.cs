using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCoreGen.CodeGen
{
  /// <summary>
  /// Manual overrides for INewField.
  /// </summary>
  public class FieldOverride
  {
    public string? TypeName;

    public string? ParamName;

    public string? Comment;

    public string? DefaultValue;

    public List<string>? ValidationFmt;

    public List<string>? AssignmentFmt;

    public List<Type> Imports = new();
  }


  /// <summary>
  /// Contains hand-tuned overrides for generated methods.
  /// </summary>
  /// 
  /// I'm not sure this is actually better than the configurator templates. It's not faster because you can copy the
  /// auto-generated method to component templates and just manually tweak from there.
  public class FieldOverrides
  {
    private class DefaultEmptyFieldOverride : FieldOverride
    {
      public DefaultEmptyFieldOverride(string emptyConstant)
      {
        DefaultValue = "null";
        AssignmentFmt = new() { "{0}.{1} = {2} ?? " + emptyConstant + ";" };

        Imports.Add(typeof(Constants));
        Imports.Add(typeof(ContextValues));
      }
    }

    private class BuilderFieldOverride :FieldOverride
    {
      public BuilderFieldOverride(string builderTypeName)
      {
        TypeName = $"{builderTypeName}?";
        DefaultValue = "null";
        AssignmentFmt = new() { "{0}.{1} = {2}?.Build() ?? Constants.Empty." + builderTypeName + ";" };
        ValidationFmt = new();

        Imports.Add(typeof(ActionsBuilder));
        Imports.Add(typeof(ConditionsBuilder));
      }
    }

    /// <summary>
    /// Maps from a source type to a map of FieldOverride by name
    /// </summary>
    public static readonly Dictionary<Type, Dictionary<string, FieldOverride>> ByName =
      new()
      {
        // Kingmaker.ElementSystem.Condition
        {
          typeof(Condition),
          new()
          {
            {
              "Not",
              new()
              {
                TypeName = "bool",
                ParamName = "negate",
                DefaultValue = "false",
                ValidationFmt = new(),
                AssignmentFmt = new() { "{0}.Not = negate;" },
              }
            }
          }
        }
      };

    /// <summary>
    /// Maps from a field type to a FieldOverride
    /// </summary>
    public static readonly Dictionary<Type, FieldOverride> ByType =
      new()
      {
        // Kingmaker.ElementsSystem.ActionList
        {
          typeof(ActionList),
          new BuilderFieldOverride("ActionsBuilder")
        },

        // Kingmaker.ElementsSystem.Conditions
        {
          typeof(ConditionsChecker),
          new BuilderFieldOverride("ConditionsBuilder")
        },

        //**** Empty Fields

        // Kingmaker.UnitLogic.Mechanics.ContextDiceValue
        {
          typeof(ContextDiceValue),
          new DefaultEmptyFieldOverride("Constants.Empty.DiceValue")
        },

        // Kingmaker.UnitLogic.Mechanics.ContextValue
        {
          typeof(ContextValue),
          new DefaultEmptyFieldOverride("ContextValues.Constant(0)")
        },

        // Kingmaker.Localization.LocalizedString
        {
          typeof(LocalizedString),
          new DefaultEmptyFieldOverride("Constants.Empty.String")
        },

        // Kingmaker.ResourceLinks.PrefabLink
        {
          typeof(PrefabLink),
          new DefaultEmptyFieldOverride("Constants.Empty.PrefabLink")
        }

        //**** End Empty Fields
      };

    /// <summary>
    /// Returns a field with manual overrides applied.
    /// </summary>
    public static IField GetFor(IField field, Type sourceType)
    {
      if (FieldToCustomField.ContainsKey(sourceType) && FieldToCustomField[sourceType].ContainsKey(field.Name))
      {
        return new CustomField(field, FieldToCustomField[sourceType][field.Name]);
      }
      return field;
    }

    private static readonly Dictionary<Type, Dictionary<string, Override>> FieldToCustomField =
        new()
        {
          {
            typeof(AddContextStatBonus),
            new()
            {
              { "Stat", new Override().WithDefaultValue(null) },
              { "Value", new Override().WithDefaultValue(null) },
              { "Multiplier", new Override().WithDefaultValue("1") },
              {
                "Minimal",
                new Override()
                    .WithParamName("minimal")
                    .WithDefaultValue("null")
                    .WithTypeName("int?")
                    .WithAssignment(new() { "{0}.Minimal = minimal ?? 0;" })
              },
              {
                "HasMinimal",
                new Override()
                    .WithParamName(null)
                    .WithAssignment(new() { "{0}.HasMinimal = minimal is not null;" })
              }
            }
          }
        };

    private class CustomField : IField
    {
      private readonly IField Field;
      private readonly Override FieldOverride;

      public string Name => Field.Name;
      public string TypeName => GetTypeName();
      private string GetTypeName()
      {
        if (FieldOverride.HasTypeName)
        {
          return FieldOverride.TypeName;
        }
        return Field.TypeName;
      }

      public string ParamName => GetParamName();
      private string GetParamName()
      {
        if (FieldOverride.HasParamName)
        {
          return FieldOverride.ParamName;
        }
        return Field.ParamName;
      }

      public string MethodName => Field.MethodName;

      public string Comment => Field.Comment;

      public string DefaultValue => GetDefaultValue();
      private string GetDefaultValue()
      {
        if (FieldOverride.HasDefaultValue)
        {
          return FieldOverride.DefaultValue;
        }
        return Field.DefaultValue;
      }

      public bool ShouldValidate => Field.ShouldValidate;

      public HashSet<Type> Imports => Field.Imports;

      public List<string> GetAssignment(string objectName)
      {
        if (FieldOverride.Assignment is null)
        {
          return Field.GetAssignment(objectName);
        }
        return FieldOverride.Assignment.Select(line => string.Format(line, objectName)).ToList();
      }

      public CustomField(IField field, Override fieldOverride)
      {
        Field = field;
        FieldOverride = fieldOverride;
      }
    }

    // Defines which fields can be overriden.
    private class Override
    {
      public string TypeName { get; private set; }
      public bool HasTypeName { get; private set; }

      public string ParamName { get; private set; }
      public bool HasParamName { get; private set; }

      public string DefaultValue { get; private set; }
      public bool HasDefaultValue { get; private set; }

      public List<string> Assignment { get; private set; }

      public Override WithTypeName(string typeName)
      {
        HasTypeName = true;
        TypeName = typeName;
        return this;
      }

      public Override WithParamName(string paramName)
      {
        HasParamName = true;
        ParamName = paramName;
        return this;
      }

      public Override WithDefaultValue(string defaultValue)
      {
        HasDefaultValue = true;
        DefaultValue = defaultValue;
        return this;
      }

      public Override WithAssignment(List<string> assignment)
      {
        Assignment = assignment;
        return this;
      }
    }
  }
}
