using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BlueprintCoreGen
{
  public static class CodeGenerator
  {
    public static Method CreateMethod(Type type)
    {
      if (type.IsSubclassOf(typeof(GameAction)))
      {
        return CreateBuilderMethod("ActionsBuilder", type);
      }
      return new();
    }

    private static Method CreateBuilderMethod(string builderType, Type type)
    {
      // Filter fields which are usually not required for instantiation.
      var fields = type.GetFields().Where(field => !field.Name.Contains("__BackingField") && field.Name != "name");
      Method method = new();
      method.Imports.Add(GetImport(type));

      method.Text.AppendLine($"{Tabs(2)}/// <summary>");
      method.Text.AppendLine($"{Tabs(2)}/// Adds <see cref=\"{type.Name}\"/> (Auto Generated)");
      method.Text.AppendLine($"{Tabs(2)}/// </summary>");

      List<string> declaration = new();
      List<string> body = new();
      if (fields.Any())
      {
        declaration.Add($"{Tabs(2)}public static {builderType} Add{type.Name}(");
        declaration.Add($"{Tabs(4)}this {builderType} builder,");

        List<string> paramComments = new() { $"{Tabs(2)}///" };
        List<string> fieldValidation = new();
        List<string> fieldAssignment = new();
        foreach(FieldInfo field in fields)
        {
          var fieldType = field.FieldType;
          method.AddImport(fieldType);

          var typeName =
              fieldType.DeclaringType is null ? fieldType.Name : $"{fieldType.DeclaringType.Name}.{fieldType.Name}";

          fieldValidation.AddRange(GetBuilderFieldValidation(field.Name, fieldType));

          var blueprintType = GetBlueprintType(fieldType);
          if (blueprintType == null)
          {
            if (fieldType == typeof(ActionList))
            {
              method.AddImport(typeof(ActionsBuilder));

              declaration.Add($"{Tabs(4)}ActionsBuilder {field.Name},");
              fieldAssignment.Add($"{Tabs(3)}element.{field.Name} = {field.Name}.Build();");
            }
            else if (fieldType == typeof(ConditionsChecker))
            {
              method.AddImport(typeof(ConditionsBuilder));

              declaration.Add($"{Tabs(4)}ConditionsBuilder {field.Name},");
              fieldAssignment.Add($"{Tabs(3)}element.{field.Name} = {field.Name}.Build();");
            }
            else
            {
              declaration.Add($"{Tabs(4)}{typeName} {field.Name},");
              fieldAssignment.Add($"{Tabs(3)}element.{field.Name} = {field.Name};");
            }
          }
          else
          { 
            method.AddImport(blueprintType?.blueprint);
            method.AddImport(blueprintType?.reference);
            paramComments.Add(
                $"{Tabs(2)}/// <param name=\"{field.Name}\"><see cref=\"{blueprintType?.blueprint.Name}\"/></param>");

            var refTypeName =
                blueprintType?.reference.DeclaringType is null
                    ? blueprintType?.reference.Name
                    : $"{blueprintType?.reference.DeclaringType.Name}.{blueprintType?.reference.Name}";
            if (blueprintType.Value.isList)
            {
              // Using Linq so make sure it's imported
              method.AddImport(typeof(Enumerable));

              declaration.Add($"{Tabs(4)}string[] {field.Name},");

              fieldAssignment.Add($"{Tabs(3)}element.{field.Name} =");
              fieldAssignment.Add($"{Tabs(5)}{field.Name}.Select(bp => BlueprintTool.GetRef<{refTypeName}>(bp)).ToList();");
            }
            else
            {
              declaration.Add($"{Tabs(4)}string {field.Name},");

              fieldAssignment.Add($"{Tabs(3)}element.{field.Name} =");
              fieldAssignment.Add($"{Tabs(5)}BlueprintTool.GetRef<{refTypeName}>({field.Name});");
            }
          }
        }

        if (paramComments.Count > 1)
        {
          paramComments.ForEach(line => method.Text.AppendLine(line));
        }

        // Close out the declaration
        var lastParameter = declaration.Last();
        declaration.Remove(lastParameter);
        declaration.Add(lastParameter.Replace(',', ')'));

        body.AddRange(fieldValidation);
        body.Add($"{Tabs(3)}var element = ElementTool.Create<{type.Name}>();");
        body.AddRange(fieldAssignment);
        body.Add($"{Tabs(3)}return builder.Add(element);");
      }
      else
      {
        declaration.Add($"{Tabs(2)}public static {builderType} Add{type.Name}(this {builderType} builder)");
        body.Add($"{Tabs(3)}return builder.Add(ElementTool.Create<{type.Name}>());");
      }

      method.Text.AppendLine($"{Tabs(2)}[Generated]");
      method.Text.AppendLine($"{Tabs(2)}[Implements(typeof({type.Name}))]");
      declaration.ForEach(line => method.Text.AppendLine(line));
      method.Text.AppendLine($"{Tabs(2)}{{");
      body.ForEach(line => method.Text.AppendLine(line));
      method.Text.AppendLine($"{Tabs(2)}}}");

      return method;
    }

    private static List<string> GetBuilderFieldValidation(string name, Type type)
    {
      List<string> validation = new();
      Type enumerableType = GetEnumerableType(type);
      if (
          enumerableType is not null
          && enumerableType.IsSubclassOf(typeof(object))
          && !enumerableType.IsSubclassOf(typeof(BlueprintReferenceBase))
          && enumerableType != typeof(string))
      {
        validation.Add($"{Tabs(3)}foreach (var item in {name})");
        validation.Add($"{Tabs(3)}{{");
        validation.Add($"{Tabs(4)}builder.Validate(item);");
        validation.Add($"{Tabs(3)}}}");
      }
      else if (
          enumerableType is null
          && type.IsSubclassOf(typeof(object))
          && !type.IsSubclassOf(typeof(BlueprintReferenceBase))
          && type != typeof(string))
      {
        validation.Add($"{Tabs(3)}builder.Validate({name});");
      }
      return validation;
    }

    private static string GetImport(Type type)
    {
      return $"using {type.Namespace};";
    }

    private static string Tabs(int count)
    {
      return new string(' ', 2*count);
    }

    private static (Type blueprint, Type reference, bool isList)? GetBlueprintType(Type type)
    {
      Type enumerableType = GetEnumerableType(type);
      if (enumerableType != null && enumerableType.IsSubclassOf(typeof(BlueprintReferenceBase)))
      {
        return (GetBlueprintTypeFromReferenceType(enumerableType), enumerableType, true);
      }
      else if (type.IsSubclassOf(typeof(BlueprintReferenceBase)))
      {
        return (GetBlueprintTypeFromReferenceType(type), type, false);
      }
      return null;
    }

    private static Type GetBlueprintTypeFromReferenceType(Type type)
    {
      var refType = type;
      while (!(refType.IsGenericType && refType.GetGenericTypeDefinition() == typeof(BlueprintReference<>)))
      {
        refType = refType.BaseType;
      }
      return refType.GenericTypeArguments[0];
    }

    private static Type GetEnumerableType(Type type)
    {
      return type.GetInterfaces()
          .FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
          ?.GetGenericArguments()[0];
    }
  }

  /// <summary>
  /// Represents a generated method. Stores a list of imports needed and the method text, including comments.
  /// </summary>
  public class Method
  {
    public readonly List<string> Imports = new();
    public readonly StringBuilder Text = new();

    public void AddImport(Type type)
    {
      Imports.Add($"using {type.Namespace};");
    }
  }
}
