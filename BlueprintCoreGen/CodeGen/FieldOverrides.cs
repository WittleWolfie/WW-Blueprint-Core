using Kingmaker.UnitLogic.FactLogic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCoreGen.CodeGen
{
  /// <summary>
  /// Contains hand-tuned overrides for generated methods.
  /// </summary>
  /// 
  /// I'm not sure this is actually better than the configurator templates. It's not faster because you can copy the
  /// auto-generated method to component templates and just manually tweak from there.
  public class FieldOverrides
  {
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
