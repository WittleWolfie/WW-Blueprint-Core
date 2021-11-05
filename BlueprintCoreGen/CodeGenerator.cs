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
      method.Text.AppendLine($"{Tabs(2)}/// Adds <see cref=\"{type.Name}\"/>");
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
          method.Imports.Add(field.FieldType.Namespace);
          declaration.Add($"{Tabs(4)}{fieldType.Name} {field.Name},");

          fieldValidation.AddRange(GetBuilderFieldValidation(field.Name, fieldType));

          var blueprintType = GetBlueprintType(fieldType);
          if (blueprintType == null)
          {
            fieldAssignment.Add($"{Tabs(3)}element.{field.Name} = {field.Name};");
          }
          else
          { 
            // TODO: Complete implementation
            method.Imports.Add(blueprintType?.blueprint.Namespace);
            method.Imports.Add(blueprintType?.reference.Namespace);
            paramComments.Add(
                $"{Tabs(2)}/// <param name=\"{field.Name}\"><see cref=\"{blueprintType?.blueprint.Name}\"/></param>");

            fieldAssignment.Add($"{Tabs(3)}element.{field.Name} =");
            fieldAssignment.Add($"{Tabs(5)}{field.Name} is null");
            fieldAssignment.Add($"{Tabs(7)}? null");
            fieldAssignment.Add($"{Tabs(7)}: BlueprintTool.GetRef<>");
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
        body.Add($"{Tabs(3)}var element = ElementTool.Create<{type.Name}>());");
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
      Type enumerableType =
          type.GetInterfaces()
              .FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
              ?.GetGenericArguments()[0];
      if (enumerableType is not null && enumerableType.IsSubclassOf(typeof(object)) && enumerableType != typeof(string))
      {
        validation.Add($"{Tabs(3)}foreach (var item in {name})");
        validation.Add($"{Tabs(3)}{{");
        validation.Add($"{Tabs(4)}builder.Validate(item);");
        validation.Add($"{Tabs(3)}}}");
      }
      else if (type.IsSubclassOf(typeof(object)) && enumerableType != typeof(string))
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

    private static (Type blueprint, Type reference)? GetBlueprintType(Type type)
    {
      return null;
    }
  }

  /// <summary>
  /// Represents a generated method. Stores a list of imports needed and the method text, including comments.
  /// </summary>
  public class Method
  {
    public readonly List<string> Imports = new();
    public readonly StringBuilder Text = new();
  }
}
