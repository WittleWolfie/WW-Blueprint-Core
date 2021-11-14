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

    // TODO: Fix FeatureBaseConfigurator/FeatureConfigurator
    public static ConfiguratorTemplate CreateConfiguratorClass(
        Type blueprintType, List<IMethod> componentMethods, Type[] gameTypes)
    {
      var relativeNamespace = ConfiguratorTemplate.GetRelativeNamespace(blueprintType);

      var template = new ConfiguratorTemplate(
          $"BlueprintConfigurators/{relativeNamespace.Replace('.', '/')}/{ConfiguratorTemplate.GetClassName(blueprintType)}.cs")
      {
        BlueprintType = blueprintType
      };

      template.AddLine(""); // Line between import & namespace
      template.AddLine($"namespace {ConfiguratorTemplate.GetNamespace(relativeNamespace)}");
      template.AddLine(@"{");

      if (blueprintType.IsAbstract)
      {
        AddConfiguratorClass(template, componentMethods, isAbstract: true);
      }
      else if (gameTypes.ToList().Exists(t => t.IsSubclassOf(blueprintType)))
      {
        AddConfiguratorClass(template, componentMethods, isAbstract: true);
        template.AddLine("");
        AddConfiguratorClass(template, componentMethods);
      }
      else
      {
        AddConfiguratorClass(template, componentMethods);
      }

      template.AddLine(@"}");
      return template;
    }

    private static void AddConfiguratorClass(
      ConfiguratorTemplate template, List<IMethod> componentMethods, bool isAbstract = false)
    {
      template.AddDeclaration(isAbstract);

      // TODO: Field methods

      foreach (var method in componentMethods)
      {
        template.AddConfiguratorMethod(method, isAbstract);
      }

      template.EndClass();
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
      throw new InvalidOperationException("Unsupported type: " + GetTypeName(type));
    }

    private static readonly Dictionary<Type, string> TypeNameOverrides =
        new()
        {
          { typeof(Kingmaker.UnitLogic.Mechanics.ValueType), "Kingmaker.UnitLogic.Mechanics.ValueType" },
          { typeof(Kingmaker.UnitLogic.Abilities.Components.TargetType), "Kingmaker.UnitLogic.Abilities.Components.TargetType" },
          { typeof(Kingmaker.AI.Blueprints.TargetType), "Kingmaker.AI.Blueprints.TargetType" },
        };
    
    /// <summary>
    /// Recursive function which generates the correct type name for generic types.
    /// </summary>
    public static string GetTypeName(Type type)
    {
      if (TypeNameOverrides.ContainsKey(type)) { return TypeNameOverrides[type]; }
      if (type.HasElementType && type.BaseType == typeof(Array))
      {
        return $"{GetTypeName(type.GetElementType())}[]";
      }
      if (!type.IsGenericType)
      {
        var name = GetConvertedTypeName(type);
        return type.DeclaringType is null ? name : $"{GetSimpleTypeName(type.DeclaringType)}.{name}";
      }
      string typeName = GetSimpleTypeName(type.GetGenericTypeDefinition());
      typeName = typeName.Substring(0, typeName.IndexOf('`'));
      string typeArguments =
          string.Join(",", type.GetGenericArguments().Select(typeArg => GetTypeName(typeArg)).ToArray());
      return typeName + "<" + typeArguments + ">";
    }

    private static string GetSimpleTypeName(Type type)
    {
      if (string.IsNullOrEmpty(type.Namespace))
      {
        return $"global::{type.Name}";
      }
      return type.Name;
    }

    private static readonly Dictionary<string, string> ClassToPrimitive =
        new()
        {
          { "Boolean", "bool" },
          { "Byte", "byte" },
          { "SByte", "sbyte" },
          { "Int16", "short" },
          { "UInt16", "ushort" },
          { "Int32", "int" },
          { "UInt32", "uint" },
          { "Int64", "long" },
          { "UInt64", "ulong" },
          { "Char", "char" },
          { "Double", "double" },
          { "Single", "float" },
          { "String", "string" }
        };

    private static string GetConvertedTypeName(Type type)
    {
      if (ClassToPrimitive.ContainsKey(type.Name))
      {
        return ClassToPrimitive[type.Name];
      }
      return GetSimpleTypeName(type);
    }

    private static MethodTemplate CreateBuilderMethod(BuilderType builderType, Type type)
    {
      // Filter fields which are usually not required for instantiation.
      var fields =
          type.GetFields()
              .Where(field => !ShouldSkipField(field))
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
      method.AddAttribute($"[Implements(typeof({GetTypeName(type)}))]");

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
            method.AddField(field, GetBuilderValidation);
          }
        }
        optionalFields.ForEach(field => method.AddField(field, GetBuilderValidation));
        method.CloseDeclaration();

        method.AddBodyLine("");
        method.AddBodyLine($"var element = ElementTool.Create<{GetTypeName(type)}>();");
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
        method.AddBodyLine($"return builder.Add(ElementTool.Create<{GetTypeName(type)}>());");
      }
      else
      {
        method.AddDeclaration($"public static {builderType} Add{type.Name}(this {builderType} builder)");
        method.AddBodyLine($"return builder.Add(ElementTool.Create<{GetTypeName(type)}>());");
      }

      return method;
    }

    private static string GetBuilderValidation(string varName)
    {
      return $"builder.Validate({varName});";
    }

    private static MethodTemplate CreateBlueprintComponentMethod(Type type)
    {
      // Filter fields which are usually not required for instantiation.
      var fields =
          type.GetFields()
              .Where(field => !ShouldSkipField(field) && field.Name != "m_Flags" && field.Name != "m_PrototypeLink")
              .Select(field => FieldProcessor.Process(field))
              .ToList();

      MethodTemplate method = new(2);
      method.AddImport(type);
      method.AddCommentSummary($"Adds <see cref=\"{type.Name}\"/> (Auto Generated)");
      method.AddAttribute($"[Generated]");
      method.AddAttribute($"[Implements(typeof({GetTypeName(type)}))]");

      // TODO: Handle unique components
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
            method.AddField(field, GetConfiguratorValidation);
          }
        }
        optionalFields.ForEach(field => method.AddField(field, GetConfiguratorValidation));
        method.CloseDeclaration();

        method.AddBodyLine("");
        method.AddBodyLine($"var component =  new {GetTypeName(type)}();");
        foreach (var field in fields)
        {
          method.AddBodyLine($"component.{field.GetAssignment()}");
        }
        method.AddBodyLine($"return AddComponent(component);");
      }
      else
      {
        method.AddDeclaration($"public TBuilder Add{GetTypeName(type)}()");
        method.AddBodyLine($"return AddComponent(new {GetTypeName(type)}());");
      }

      return method;
    }

    private static bool ShouldSkipField(FieldInfo field)
    {
      return field.Name.Contains("__BackingField")
          || field.Name == "name"
          || field.Name == "m_HasIsAllyEffectRunConditions" // Self-configuring field for AbilityDeliverProjectile
          // Skip constant, static, and read-only
          || field.IsLiteral
          || field.IsStatic
          || field.IsInitOnly;
    }

    private static string GetConfiguratorValidation(string varName)
    {
      return $"ValidateParam({varName});";
    }

    private static void AddField(
        this MethodTemplate method, IField field, IField.GetValidationCall validationMethodProcessor)
    {
      field.GetImports().ForEach(import => method.AddImport(import));

      method.AddComment(field.GetParamComment());
      method.AddParamDeclaration(field.GetParamDeclaration());

      field.GetValidation(validationMethodProcessor).ForEach(line => method.AddBodyLine($"{line}"));
    }
  }
}
