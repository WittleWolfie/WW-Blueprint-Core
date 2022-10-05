using BlueprintCore.Utils;
using BlueprintCoreGen.CodeGen.Overrides.Examples;
using BlueprintCoreGen.CodeGen.Overrides.Ignored;
using BlueprintCoreGen.CodeGen.Params;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BlueprintCoreGen.CodeGen.Methods
{
  /// <summary>
  /// Represents a method for code generation.
  /// </summary>
  public interface IMethod
  {
    /// <summary>
    /// A list of types that need to be imported for the method.
    /// </summary>
    List<Type> GetImports();

    /// <summary>
    /// Returns the method implementation as lines of text.
    /// </summary>
    List<string> GetLines();
  }

  public static class MethodFactory
  {
    public static List<IMethod> CreateForNewConfigurator(Type blueprintType, string returnType)
    {
      var typeName = TypeTool.GetName(blueprintType);

      MethodImpl forBp = new();
      forBp.AddImport(typeof(BlueprintTool));
      forBp.AddCommentSummary("Returns a configurator to modify the specified blueprint.");
      forBp.AddRemarks(
        new()
        {
          "Use this to modify existing blueprints, such as blueprints from the base game.",
          "If you're using <see href=\"https://github.com/OwlcatOpenSource/WrathModificationTemplate\">WrathModificationTemplate</see> blueprints defined in JSON already exist."
        });

      forBp.AddLine($"public static {returnType} For(Blueprint<BlueprintReference<{typeName}>> blueprint)");
      forBp.AddLine($"{{");
      forBp.AddLine($"  return new {returnType}(blueprint);");
      forBp.AddLine($"}}");

      MethodImpl newBp = new();
      forBp.AddCommentSummary("Creates a new blueprint and returns a new configurator to modify it.");
      forBp.AddRemarks(
        new()
        {
          "After creating a blueprint with this method you can use either name or GUID to reference the blueprint in BlueprintCore API calls.",
          "An implicit cast converts the string to <see cref=\"Utils.Blueprint{TRef}\"/>, exposing the blueprint instance and its reference."
        });
       
      forBp.AddLine($"public static {returnType} New(string name, string guid)");
      forBp.AddLine($"{{");
      forBp.AddLine($"  BlueprintTool.Create<{typeName}>(name, guid);");
      forBp.AddLine($"  return For(name);");
      forBp.AddLine($"}}");

      return new() { forBp, newBp };
    }

    public static IMethod CreateCopyFrom(Type blueprintType, List<FieldMethod> fields, string returnType)
    {
      var method = new MethodImpl();
      var body =
        fields.Select(field => blueprintType.GetField(field.FieldName))
          .Where(field => !Ignored.ShouldIgnoreField(field, blueprintType))
          .Select(field => $"Blueprint.{field.Name} = blueprint.{field.Name};")
          .ToList();

      body.Add($"");
      body.Add($"var componentsToAdd = new List<BlueprintComponent>();");
      body.Add($"foreach (var type in componentTypes)");
      body.Add($"  componentsToAdd.AddRange(blueprint.Components.Where(c => c.GetType() == type));");
      body.Add($"Blueprint.Components = CommonTool.Append(Blueprint.Components, componentsToAdd.Distinct().ToArray());");

      method.AddLine($"public override {returnType} CopyFrom({TypeTool.GetName(blueprintType)} blueprint, params Type[] componentTypes)");
      method.AddLine($"{{");
      method.AddLine($"  base.CopyFrom(blueprint, componentTypes);");
      method.AddLine($"");
      AddOnConfigure(method, body, new() { });
      method.AddLine($"}}");

      return method;
    }

    public static IMethod CreateConfiguratorOnConfigureCompleted(Type blueprintType, List<FieldMethod> fields)
    {
      var method = new MethodImpl();
      var body =
        fields.Select(field => blueprintType.GetField(field.FieldName))
          .Select(fieldInfo => ParametersFactory.CreateForBlueprintField(blueprintType, fieldInfo!))
          .Where(parameter => parameter is not null && parameter.AssignmentIfNull.Any())
          .Cast<IBlueprintParameter>()
          .SelectMany(parameter => parameter.AssignmentIfNull)
          .ToList();

      if (!body.Any())
      {
        return method;
      }

      method.AddLine($"protected override void OnConfigureCompleted()");
      method.AddLine($"{{");
      method.AddLine($"  base.OnConfigureCompleted();");
      method.AddLine($"");
      body.ForEach(line => method.AddLine($"  {line}"));
      method.AddLine($"}}");

      return method;
    }

    private static readonly string OnConfigureObjName = "bp";
    private static readonly string BlueprintValidateFunction = "Validate";
    public static List<IMethod> CreateForField(
      Type blueprintType, FieldMethod fieldMethod, string returnType)
    {
      List<IMethod> methods = new();
      FieldInfo field = blueprintType.GetField(fieldMethod.FieldName)!;
      var useParamsForSet =
        TypeTool.IsBitFlag(field.FieldType) || TypeTool.GetEnumerableType(field.FieldType) is not null;


      IBlueprintParameter? parameter = ParametersFactory.CreateForBlueprintField(blueprintType, field);
      if (parameter is null)
      {
        // Ignored field
        return methods;
      }

      methods.Add(
        CreateFieldMethod(
          field,
          returnType,
          fieldMethod.Set,
          parameter,
          parameter.GetOperation(OnConfigureObjName, BlueprintValidateFunction),
          useParamsForSet ? parameter.ParamsDeclaration : parameter.Declaration,
          parameter.SetComment,
          "Set",
          fieldMethod.Remarks));

      var addOperation = parameter.GetAddOperation(OnConfigureObjName, BlueprintValidateFunction);
      if (addOperation.Any())
      {
        methods.Add(
          CreateFieldMethod(
            field,
            returnType,
            fieldMethod.AddTo,
            parameter,
            addOperation,
            parameter.ParamsDeclaration,
            parameter.AddComment,
            "AddTo",
            fieldMethod.Remarks));
      }

      var removeOperation = parameter.GetRemoveOperation(OnConfigureObjName);
      if (removeOperation.Any() && !fieldMethod.IgnoreRemoveFrom)
      {
        methods.Add(
          CreateFieldMethod(
            field,
            returnType,
            fieldMethod.RemoveFrom,
            parameter,
            removeOperation,
            parameter.ParamsDeclaration,
            parameter.RemoveComment,
            "RemoveFrom",
            fieldMethod.Remarks));
      }

      var removePredicateOperation = parameter.GetRemovePredicateOperation(OnConfigureObjName, "predicate");
      if (removePredicateOperation.Any())
      {
        methods.Add(
          CreateFieldMethod(
            field,
            returnType,
            fieldMethod.RemoveFromPredicate,
            parameter,
            removePredicateOperation,
            $"{GetPredicateTypeName(field.FieldType)} predicate",
            parameter.RemovePredicateComment,
            "RemoveFrom",
            fieldMethod.Remarks,
            useParamComment: false));
      }

      var clearOperation = parameter.GetClearOperation(OnConfigureObjName);
      if (clearOperation.Any())
      {
        methods.Add(
          CreateFieldMethod(
            field,
            returnType,
            fieldMethod.Clear,
            parameter,
            clearOperation,
            "",
            parameter.ClearComment,
            "Clear",
            fieldMethod.Remarks,
            useParamComment: false));
      }

      var modifyOperation = parameter.GetModifyOperation(OnConfigureObjName, "action");
      if (modifyOperation.Any())
      {
        methods.Add(
          CreateFieldMethod(
            field,
            returnType,
            fieldMethod.Modify,
            parameter,
            modifyOperation,
            $"{GetActionTypeName(field.FieldType)} action",
            parameter.ModifyComment,
            "Modify",
            fieldMethod.Remarks,
            useParamComment: false));
      }

      return methods;
    }

    private static string GetPredicateTypeName(Type type)
    {
      var enumerableType = TypeTool.GetEnumerableType(type);
      if (enumerableType is not null)
      {
        return $"Func<{TypeTool.GetName(enumerableType)}, bool>";
      }
      return $"Func<{TypeTool.GetName(type)}, bool>";
    }

    private static string GetActionTypeName(Type type)
    {
      var enumerableType = TypeTool.GetEnumerableType(type);
      if (enumerableType is not null)
      {
        return $"Action<{TypeTool.GetName(enumerableType)}>";
      }
      if (type.IsValueType && type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
      {
        return $"Action<{TypeTool.GetName(type.GetGenericArguments()[0])}?>";
      }
      return $"Action<{TypeTool.GetName(type)}>";
    }

    private static IMethod CreateFieldMethod(
      FieldInfo field,
      string returnType,
      MethodOverride methodOverride,
      IBlueprintParameter parameter,
      List<string> operation,
      string parameterDeclaration,
      string commentSummary,
      string methodPrefix,
      List<string> remarks,
      bool useParamComment = true)
    {
      var method = new MethodImpl();

      // Imports
      method.AddImport(field.FieldType);
      method.AddImport(typeof(Action));
      method.AddParameterImports(new() { parameter });
      method.AddTypeNameImports(methodOverride.Imports);

      // Comment summary
      method.AddCommentSummary(commentSummary);

      // Remarks
      method.AddRemarks(remarks);
      method.AddRemarks(methodOverride.Remarks);

      // Parameter comments
      if (useParamComment)
      {
        method.AddParameterComments(new() { parameter });
      }

      var methodName =
        string.IsNullOrEmpty(methodOverride.MethodName)
          ? GetFieldMethodName(methodPrefix, field.Name)
          : methodOverride.MethodName;

      // Obsolete Attr
      if (!string.IsNullOrEmpty(methodOverride.ObsoleteComment))
      {
        method.AddImport(typeof(ObsoleteAttribute));
        method.AddLine($"[Obsolete(\"{methodOverride.ObsoleteComment}\")]");
      }

      // Declaration
      method.AddLine($"public {returnType} {methodName}({parameterDeclaration})");
      method.AddLine($"{{");

      // Assignment & extra lines
      AddOnConfigure(method, operation, methodOverride.ExtraFmtLines);
      method.AddLine($"}}");

      return method;
    }

    public static List<IMethod> CreateForComponent(
      Type componentType, ConstructorMethod componentMethod, string returnType)
    {
      List<IMethod> methods = new();

      if (componentMethod.Replace)
      {
        methods.Add(CreateReplacementForComponent(componentType, componentMethod, returnType));
        return methods;
      }

      if (!componentMethod.Methods.Any())
      {
        methods.Add(CreateForComponent(componentType, componentMethod, returnType, componentMethod));
        return methods;
      }

      foreach (var methodOverride in componentMethod.Methods)
      {
        methods.Add(
          CreateForComponent(
            componentType, componentMethod, returnType, MethodOverride.Merge(componentMethod, methodOverride)));
      }
      return methods;
    }

    private static readonly ComponentMergeParameter ComponentMergeParam = new();
    private static readonly MergeParameter MergeParam = new();
    private static IMethod CreateForComponent(
      Type componentType, ConstructorMethod componentMethod, string returnType, MethodOverride methodOverride)
    {
      var method = new MethodImpl();
      var componentTypeName = TypeTool.GetName(componentType);
      var isUnique = componentType.GetCustomAttribute<AllowMultipleComponentsAttribute>() is null;
      var parameters =
        isUnique
          ? ParametersFactory.CreateForConstructor(componentType, methodOverride, ComponentMergeParam, MergeParam)
          : ParametersFactory.CreateForConstructor(componentType, methodOverride);

      // Imports
      method.AddImport(componentType);
      method.AddParameterImports(parameters);
      method.AddTypeNameImports(methodOverride.Imports);

      // Comment summary
      method.AddCommentSummary($"Adds <see cref=\"{componentTypeName}\"/>");

      // Remarks & Examples
      method.AddRemarks(componentType, methodOverride.Remarks);

      // Parameter comments
      method.AddParameterComments(parameters);

      // Obsolete Attr
      if (!string.IsNullOrEmpty(componentMethod.ObsoleteComment))
      {
        method.AddImport(typeof(ObsoleteAttribute));
        method.AddLine($"[Obsolete(\"{componentMethod.ObsoleteComment}\")]");
      }

      var methodName =
        string.IsNullOrEmpty(methodOverride.MethodName)
          ? GetComponentMethodName(componentTypeName)
          : methodOverride.MethodName;
      if (!parameters.Any())
      {
        method.AddLine($"public {returnType} {methodName}()");
        method.AddLine(@"{");
        if (isUnique)
        {
          method.AddLine($"  return AddUniqueComponent(new {componentTypeName}(), mergeBehavior, merge);");
        }
        else
        {
          method.AddLine($"  return AddComponent(new {componentTypeName}());");
        }
        method.AddLine(@"}");
        return method;
      }

      // Declarations
      var fieldsWithDeclarations = parameters.Where(field => !string.IsNullOrEmpty(field.Declaration));
      var useParams =
        fieldsWithDeclarations.Count() == 1 && !string.IsNullOrEmpty(fieldsWithDeclarations.First().ParamsDeclaration);
      if (useParams)
      {
        method.AddLine($"public {returnType} {methodName}({fieldsWithDeclarations.First().ParamsDeclaration})");
      }
      else if (!fieldsWithDeclarations.Any())
      {
        method.AddLine($"public {returnType} {methodName}()");
      }
      else
      {
        var declarations = fieldsWithDeclarations.Select(field => field.Declaration);
        method.AddLine($"public {returnType} {methodName}(");
        declarations.SkipLast(1).ToList().ForEach(declaration => method.AddLine($"    {declaration},"));
        method.AddLine($"    {declarations.Last()})");
      }
      method.AddLine(@"{");

      // Constructor
      if (string.IsNullOrEmpty(componentMethod.ConstructorRhs))
      {
        method.AddLine($"  var component = new {componentTypeName}();");
      }
      else
      {
        method.AddLine($"  var component = {componentMethod.ConstructorRhs};");
      }

      // Assignment
      if (useParams)
      {
        fieldsWithDeclarations.First().GetParamsOperation("component", "Validate")
          .Concat(
            parameters.Where(field => string.IsNullOrEmpty(field.Declaration))
              .SelectMany(field => field.GetOperation("component", "Validate"))
              .Where(line => !string.IsNullOrEmpty(line)))
          .ToList()
          .ForEach(line => method.AddLine($"  {line}"));
      }
      else
      {
        parameters.SelectMany(field => field.GetOperation("component", "Validate"))
          .Where(line => !string.IsNullOrEmpty(line))
          .ToList()
          .ForEach(line => method.AddLine($"  {line}"));
      }

      // Extra lines from override
      methodOverride.ExtraFmtLines.ForEach(line => method.AddLine($"  {string.Format(line, "component")}"));

      // Return
      if (isUnique)
      {
        method.AddLine($"  return AddUniqueComponent(component, mergeBehavior, merge);");
      }
      else
      {
        method.AddLine($"  return AddComponent(component);");
      }
      method.AddLine(@"}");

      return method;
    }

    private static IMethod CreateReplacementForComponent(
      Type componentType, ConstructorMethod componentMethod, string returnType)
    {
      var method = new MethodImpl();
      var componentTypeName = TypeTool.GetName(componentType);

      // Imports
      method.AddImport(componentType);

      // Comment summary
      method.AddCommentSummary($"Adds <see cref=\"{componentTypeName}\"/>");

      // Remarks & Examples
      method.AddRemarks(componentType, componentMethod.Remarks);

      var methodName =
        string.IsNullOrEmpty(componentMethod.MethodName)
          ? GetComponentMethodName(componentTypeName)
          : componentMethod.MethodName;
      method.AddLine($"public {returnType} {methodName}({componentTypeName} component)");
      method.AddLine(@"{");
        method.AddLine($"  return AddComponent(component);");
      method.AddLine(@"}");
      return method;
    }
    public static List<IMethod> CreateForBuilder(Type elementType, ConstructorMethod constructorMethod)
    {
      List<IMethod> methods = new();
      var builderType = elementType.IsSubclassOf(typeof(Condition)) ? "ConditionsBuilder" : "ActionsBuilder";

      if (!constructorMethod.Methods.Any())
      {
        methods.Add(CreateForBuilder(elementType, constructorMethod, builderType, constructorMethod));
        return methods;
      }

      foreach (var methodOverride in constructorMethod.Methods)
      {
        methods.Add(
          CreateForBuilder(
            elementType, constructorMethod, builderType, MethodOverride.Merge(constructorMethod, methodOverride)));
      }
      return methods;
    }

    private static IMethod CreateForBuilder(
      Type elementType, ConstructorMethod builderMethod, string builderType, MethodOverride methodOverride)
    {
      var method = new MethodImpl();
      var elementTypeName = TypeTool.GetName(elementType);
      var parameters = ParametersFactory.CreateForConstructor(elementType, methodOverride);

      // Imports
      method.AddImport(elementType);
      method.AddImport(typeof(ElementTool));
      method.AddParameterImports(parameters);
      method.AddTypeNameImports(methodOverride.Imports);

      // Comment summary
      method.AddCommentSummary($"Adds <see cref=\"{elementTypeName}\"/>");

      // Remarks & Examples
      method.AddRemarks(elementType, methodOverride.Remarks);

      // Parameter comments
      method.AddParameterComments(parameters);

      // Obsolete Attr
      if (!string.IsNullOrEmpty(builderMethod.ObsoleteComment))
      {
        method.AddImport(typeof(ObsoleteAttribute));
        method.AddLine($"[Obsolete(\"{builderMethod.ObsoleteComment}\")]");
      }

      var methodName =
        string.IsNullOrEmpty(methodOverride.MethodName)
          ? GetBuilderMethodName(elementTypeName)
          : methodOverride.MethodName;
      if (!parameters.Any())
      {
        method.AddLine($"public static {builderType} {methodName}(this {builderType} builder)");
        method.AddLine($"{{");
        method.AddLine($"  return builder.Add(ElementTool.Create<{elementTypeName}>());");
        method.AddLine($"}}");
        return method;
      }

      // Declarations
      var fieldsWithDeclarations = parameters.Where(field => !string.IsNullOrEmpty(field.Declaration));
      var useParams =
        fieldsWithDeclarations.Count() == 1 && !string.IsNullOrEmpty(fieldsWithDeclarations.First().ParamsDeclaration);
      if (useParams)
      {
        method.AddLine(
          $"public static {builderType} {methodName}(this {builderType} builder, {fieldsWithDeclarations.First().ParamsDeclaration})");
      }
      else if (!fieldsWithDeclarations.Any())
      {
        method.AddLine($"public static {builderType} {methodName}(this {builderType} builder)");
      }
      else
      {
        var declarations = fieldsWithDeclarations.Select(field => field.Declaration);
        method.AddLine($"public static {builderType} {methodName}(");
        method.AddLine($"    this {builderType} builder,");
        declarations.SkipLast(1).ToList().ForEach(declaration => method.AddLine($"    {declaration},"));
        method.AddLine($"    {declarations.Last()})");
      }
      method.AddLine($"{{");

      // Constructor
      if (string.IsNullOrEmpty(builderMethod.ConstructorRhs))
      {
        method.AddLine($"  var element = ElementTool.Create<{elementTypeName}>();");
      }
      else
      {
        method.AddLine($"  var element = {builderMethod.ConstructorRhs};");
      }

      // Assignment
      if (useParams)
      {
        fieldsWithDeclarations.First().GetParamsOperation("element", "builder.Validate")
          .Concat(
            parameters.Where(field => string.IsNullOrEmpty(field.Declaration))
              .SelectMany(field => field.GetOperation("element", "builder.Validate"))
              .Where(line => !string.IsNullOrEmpty(line)))
          .ToList()
          .ForEach(line => method.AddLine($"  {line}"));
      }
      else
      {
        parameters.SelectMany(field => field.GetOperation("element", "builder.Validate"))
          .Where(line => !string.IsNullOrEmpty(line))
          .ToList()
          .ForEach(line => method.AddLine($"  {line}"));
      }

      // Extra lines from override
      methodOverride.ExtraFmtLines.ForEach(line => method.AddLine($"  {string.Format(line, "element")}"));

      // Return
      method.AddLine($"  return builder.Add(element);");
      method.AddLine($"}}");

      return method;
    }

    private static string GetFieldMethodName(string prefix, string fieldName)
    {
      var paramName = new StringBuilder(ParametersFactory.GetParamName(fieldName));
      paramName[0] = char.ToUpper(paramName[0]);
      return $"{prefix}{paramName}";
    }

    /// <summary>
    /// Removes unnecessary method name prefixes, e.g. ActionGoDeeperIntoDungeon > GoDeeperIntoDungeon.
    /// </summary>
    private static readonly List<string> IgnoreMethodNamePrefixes =
      new() { "Action", "ContextAction", "Condition", "ContextCondition" };
    private static string GetBuilderMethodName(string elementTypeName)
    {
      var methodName = elementTypeName;
      foreach (var prefix in IgnoreMethodNamePrefixes)
      {
        if (methodName.StartsWith(prefix))
        {
          return methodName.Remove(0, prefix.Length);
        }
      }
      return methodName;
    }

    /// <summary>
    /// Prefixes the name w/ Add unless it's redundant
    /// </summary>
    private static string GetComponentMethodName(string componentTypeName)
    {
      if (componentTypeName.StartsWith("Add"))
      {
        return componentTypeName;
      }
      return $"Add{componentTypeName}";
    }

    private static void AddOnConfigure(MethodImpl method, List<string> onConfigure, List<string> extraFmtLines)
    {
      method.AddLine($"  return OnConfigureInternal(");
      method.AddLine($"    bp =>");
      method.AddLine($"    {{");
      onConfigure.ForEach(line => method.AddLine($"      {line}"));
      extraFmtLines.Select(line => string.Format(line, "bp"))
        .ToList()
        .ForEach(line => method.AddLine($"      {line}"));
      method.AddLine($"    }});");
    }

    private class MethodImpl : IMethod
    {
      private readonly List<Type> Imports = new();
      private readonly List<string> Lines = new();

      public List<Type> GetImports()
      {
        return Imports;
      }

      public List<string> GetLines()
      {
        return Lines;
      }

      public void AddImport(Type type)
      {
        Imports.Add(type);
      }

      public void AddLine(string line)
      {
        Lines.Add(line);
      }

      public void AddParameterImports(List<IParameter> parameters)
      {
        parameters.ForEach(param => param.Imports.ForEach(import => AddImport(import)));
      }

      public void AddTypeNameImports(List<string> typeNames)
      {
        typeNames.ForEach(import => AddImport(TypeTool.TypeByName(import)));
      }

      public void AddCommentSummary(string summary)
      {
        AddLine(@"/// <summary>");
        AddLine($"/// {summary}");
        AddLine(@"/// </summary>");
      }

      public void AddRemarks(Type constructedType, List<string> remarks)
      {
        var componentNameAttr = constructedType.GetCustomAttribute<ComponentNameAttribute>();
        var examples = Examples.GetFor(constructedType);
        if (!remarks.Any() && componentNameAttr is null && !examples.Any()) { return; }

        AddLine(@"///");
        AddLine(@"/// <remarks>");
        remarks.ForEach(paragraph => AddRemark(paragraph));

        if (componentNameAttr is not null)
        {
          AddLine(@"///");
          AddRemark($"ComponentName: {componentNameAttr.Name}");
        }

        if (examples.Any())
        {
          AddLine(@"///");
          AddLine($"/// <list type=\"bullet\">");
          AddLine(@"/// <listheader>Used by</listheader>");
          Examples.GetFor(constructedType).ForEach(
            example =>
              AddLine(
                $"/// <item><term>{example.BlueprintName}</term>" +
                $"<description>{example.BlueprintGuid}</description></item>"));
          AddLine($"/// </list>");
        }
        AddLine($"/// </remarks>");
      }

      public void AddRemarks(List<string> remarks)
      {
        if (!remarks.Any()) { return; }

        AddLine(@"/// <remarks>");
        remarks.ForEach(paragraph => AddRemark(paragraph));
        AddLine(@"/// </remarks>");
      }

      public void AddParameterComments(List<IParameter> parameters)
      {
        var paramComments =
          parameters.Where(field => !string.IsNullOrEmpty(field.Declaration))
            .Select(field => field.Comment)
            .Where(comment => comment is not null && comment.Any())
            .ToList();
        if (paramComments.Any())
        {
          AddLine(@"///");
          paramComments.ForEach(
              comment =>
              {
                comment.ForEach(line => AddLine($"/// {line}"));
              });
        }
      }

      private void AddRemark(string paragraph)
      {
        AddLine(@"/// <para>");
        AddLine($"/// {paragraph}");
        AddLine(@"/// </para>");
      }
    }
  }
}
