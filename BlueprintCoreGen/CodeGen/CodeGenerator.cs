using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BlueprintCoreGen.CodeGen
{
  public static class CodeGenerator
  {
    private enum BuilderType
    {
      ActionsBuilder,
      ConditionsBuilder
    }

    public static ConfiguratorTemplate CreateConfiguratorClass(
        Type blueprintType, List<MethodTemplate> componentMethods)
    {
      return new("");
    }

    public static List<MethodTemplate> CreateFieldMethod(FieldInfo field)
    {
      return new();
    }

    public static MethodTemplate CreateMethod(Type type)
    {
      if (type.IsSubclassOf(typeof(GameAction)))
      {
        return CreateBuilderMethod(BuilderType.ActionsBuilder, type);
      }
      if (type.IsSubclassOf(typeof(Condition)))
      {
        return CreateBuilderMethod(BuilderType.ConditionsBuilder, type);
      }
      if (type.IsSubclassOf(typeof(BlueprintComponent)))
      {
        return CreateBlueprintComponentMethod(type);
      }
      throw new InvalidOperationException("Unsupported type: " + type.Name);
    }

    private static MethodTemplate CreateBuilderMethod(BuilderType builderType, Type type)
    {
      // Filter fields which are usually not required for instantiation.
      var fields =
          type.GetFields()
              .Where(
                  field => !field.Name.Contains("__BackingField")
                  && field.Name != "name")
              .Select(
                  field =>
                  {
                    if (builderType == BuilderType.ConditionsBuilder && field.Name == "Not")
                    {
                      return new NegateConditionField();
                    }
                    return FieldProcessor.Process(field);
                  })
              .ToList();

      MethodTemplate method = new(2);
      method.AddImport(type);
      method.AddCommentSummary($"Adds <see cref=\"{type.Name}\"/> (Auto Generated)");
      method.AddAttribute($"[Generated]");
      method.AddAttribute($"[Implements(typeof({type.Name}))]");

      if (fields.Any())
      {
        method.AddDeclaration($"public static {builderType} Add{type.Name}(");
        method.AddParamDeclaration($"this {builderType} builder");

        List<IField> optionalFields = new();
        foreach (var field in fields)
        {
          if (field.IsOptional())
          {
            optionalFields.Add(field);
          }
          else
          {
            method.AddField(field);
          }
        }
        optionalFields.ForEach(field => method.AddField(field));
        method.CloseDeclaration();

        method.AddBodyLine("");
        method.AddBodyLine($"var element = ElementTool.Create<{type.Name}>();");
        foreach (var field in fields)
        {
          method.AddBodyLine($"element.{field.GetAssignment()}");
        }
        method.AddBodyLine($"return builder.Add(element);");
      }
      else if (builderType == BuilderType.ConditionsBuilder)
      {
        method.AddDeclaration(
            $"public static {builderType} Add{type.Name}(this {builderType} builder, bool negate = false)");
        method.AddBodyLine($"");
        method.AddBodyLine($"return builder.Add(ElementTool.Create<{type.Name}>());");
      }
      else
      {
        method.AddDeclaration($"public static {builderType} Add{type.Name}(this {builderType} builder)");
        method.AddBodyLine($"return builder.Add(ElementTool.Create<{type.Name}>());");
      }

      return method;
    }

    private static MethodTemplate CreateBlueprintComponentMethod(Type type)
    {
      // Filter fields which are usually not required for instantiation.
      var fields =
          type.GetFields()
              .Where(
                  field => !field.Name.Contains("__BackingField")
                  && field.Name != "name"
                  && field.Name != "m_Flags"
                  && field.Name != "m_PrototypeLink")
              .Select(field => FieldProcessor.Process(field))
              .ToList();

      MethodTemplate method = new(2);
      method.AddImport(type);
      method.AddCommentSummary($"Adds <see cref=\"{type.Name}\"/> (Auto Generated)");
      method.AddAttribute($"[Generated]");
      method.AddAttribute($"[Implements(typeof({type.Name}))]");

      // TODO: Handle unique components
      // TODO: Handle concrete classes
      if (fields.Any())
      {
        method.AddDeclaration($"public TBuilder Add{type.Name}(");

        List<IField> optionalFields = new();
        foreach (var field in fields)
        {
          if (field.IsOptional())
          {
            optionalFields.Add(field);
          }
          else
          {
            // TODO: Add Validation support to blueprint configurators
            method.AddField(field);
          }
        }
        optionalFields.ForEach(field => method.AddField(field));
        method.CloseDeclaration();

        method.AddBodyLine("");
        method.AddBodyLine($"var component =  new {type.Name}();");
        foreach (var field in fields)
        {
          method.AddBodyLine($"component.{field.GetAssignment()}");
        }
        method.AddBodyLine($"return AddComponent(component);");
      }
      else
      {
        method.AddDeclaration($"public TBuilder Add{type.Name}()");
        method.AddBodyLine($"return AddComponent(new {type.Name}());");
      }

      return method;
    }

    private static void AddField(this MethodTemplate method, IField field)
    {
      field.GetImports().ForEach(import => method.AddImport(import));

      method.AddComment(field.GetParamComment());
      method.AddParamDeclaration(field.GetParamDeclaration());

      field.GetValidation().ForEach(line => method.AddBodyLine($"{line}"));
    }
  }
}
