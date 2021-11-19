using HarmonyLib;
using Kingmaker.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace BlueprintCoreGen.CodeGen
{
  public interface IClass
  {
    /// <summary>
    /// Relative directory for the output class
    /// </summary>
    string RelativePath { get; }

    /// <summary>
    /// Returns the full class text
    /// </summary>
    string GetText();

    /// <summary>
    /// Returns the types implemented in the class
    /// </summary>
    List<Type> GetImplementedTypes();
  }

  public interface IConfiguratorClass : IClass
  {
    /// <summary>
    /// Type of blueprint implemented in the configurator
    /// </summary>
    Type BlueprintType { get; }
  }

  /// <summary>
  /// Constructs class file text for builders and configurators.
  /// </summary>
  /// 
  /// <remarks>
  /// <para>
  /// Attributes are used in class templates to customize the output.
  /// </para>
  /// <list type="bullet">
  /// <listheader>Attributes</listheader>
  /// <item>
  ///   <term><see cref="ImplementsAttribute"/></term>
  ///   <description>
  ///   Use on methods that implement a game type such as a <see cref="Kingmaker.ElementsSystem.GameAction"/> or
  ///   <see cref="Kingmaker.ElementsSystem.Condition"/>. This is used to determine which types need automatically
  ///   generated methods. e.g. <c>[Implements(typeof(Conditional))]</c>
  ///   </description>
  /// </item>
  /// <item>
  ///   <term><see cref="ConfiguresAttribute"/></term>
  ///   <description>
  ///   Use on configurators that implement a blueprint type such as
  ///   <see cref="Kingmaker.Blueprints.Classes.BlueprintFeature"/>. This is used to determine which blueprint types
  ///   need automatically generated configurators. e.g. <c>[Configures(typeof(BlueprintFeature))]</c>
  ///   </description>
  /// </item>
  /// <item>
  ///   <term>Replace</term>
  ///   <description>
  ///   A simple tag instructing the processor to run <see cref="string.Replace(string, string?)"/> on the next line.
  ///   Implemented using a comment because attributes in C# cannot be applied to arbitrary lines of code. e.g.
  ///   <c>// [Replace("Original", "Replacement")]</c> would replace occurrences of the text Original on the next line
  ///   with Replacement.
  ///   </description>
  /// </item>
  /// <item>
  ///   <term>Generate</term>
  ///   <description>
  ///   Generate tags indicate where in the template to insert generated types.
  ///   e.g. <c>// [Generate(typeof(Conditional))]</c> is automatically replaced a method for the Conditional action.
  ///   </description>
  /// </item>
  /// <item>
  ///   <term>GenerateComponents</term>
  ///   <description>
  ///   GenerateComponents tags indicate where in the template to insert generated blueprint component methods.
  ///   e.g. <c>// [GenerateComponents]</c>
  ///   </description>
  /// </item>
  /// </list>
  /// </remarks>
  public class ClassFactory
  {
    private static readonly Regex Replace = new(@"^\s*// \[Replace\(""(.*)"", ""(.*)""\)\]", RegexOptions.Compiled);
    private static readonly Regex Import = new(@"^using [\w\.]+;", RegexOptions.Compiled);
    private static readonly Regex Namespace = new(@"^namespace [\w\.]+", RegexOptions.Compiled);
    private static readonly Regex Generate = new(@"^\s*// \[Generate\((.*)\)\]", RegexOptions.Compiled);
    private static readonly Regex MethodAttribute =
        new(@"^\s+\[Implements\(typeof\((\w+)\)\)\]", RegexOptions.Compiled);

    // For configurators
    private static readonly Regex Configures = new(@"^\s+\[Configures\(typeof\((\w+)\)\)\]", RegexOptions.Compiled);
    private static readonly Regex GenerateComponents = new(@"^\s*// \[GenerateComponents\]", RegexOptions.Compiled);
    private static readonly Regex ClassDecl = new(@"^\s+public class", RegexOptions.Compiled);
    private static readonly Regex AbstractClassDecl = new(@"^\s+public abstract class", RegexOptions.Compiled);

    public static IClass CreateFromBuilderTemplate(string file, string relativePath)
    {
      var builderClass = new ClassImpl(relativePath);

      string currentLine;
      (string Old, string New)? replacement = null;
      foreach (var line in File.ReadAllLines(file))
      {
        currentLine = line;
        if (Replace.IsMatch(currentLine))
        {
          Match match = Replace.Match(currentLine);
          replacement = (match.Groups[1].Value, match.Groups[2].Value);
          continue;
        }

        if (replacement != null)
        {
          currentLine = currentLine.Replace(replacement?.Old, replacement?.New);
          replacement = null;
        }

        if (Import.IsMatch(currentLine))
        {
          // Convert the namespace for BlueprintCore
          builderClass.AddImport(currentLine.Replace("BlueprintCoreGen", "BlueprintCore"));
          continue;
        }

        if (Namespace.IsMatch(currentLine))
        {
          // Convert the namespace for BlueprintCore
          builderClass.AddLine(currentLine.Replace("BlueprintCoreGen", "BlueprintCore"));
          continue;
        }
        if (Generate.IsMatch(currentLine))
        {
          var type = AccessTools.TypeByName(Generate.Match(currentLine).Groups[1].Value);
          AddMethod(builderClass, MethodFactory.CreateForBuilder(type));
          builderClass.AddImplementedType(type);
          continue;
        }

        if (MethodAttribute.IsMatch(currentLine))
        {
          builderClass.AddImplementedType(AccessTools.TypeByName(MethodAttribute.Match(currentLine).Groups[1].Value));
        }
        builderClass.AddLine(currentLine);
      }
      return builderClass;
    }

    public static IConfiguratorClass CreateFromConfiguratorTemplate(
        string file, string relativePath, Dictionary<Type, List<IMethod>> methodsByBlueprintType)
    {
      var configuratorClass = new ConfiguratorClass(relativePath);

      bool isAbstract = false;
      string currentLine;
      string className = null;
      (string Old, string New)? replacement = null;
      foreach (var line in File.ReadAllLines(file))
      {
        currentLine = line;
        if (Replace.IsMatch(currentLine))
        {
          Match match = Replace.Match(currentLine);
          replacement = (match.Groups[1].Value, match.Groups[2].Value);
          continue;
        }

        if (replacement != null)
        {
          currentLine = currentLine.Replace(replacement?.Old, replacement?.New);
          replacement = null;
        }

        if (Import.IsMatch(currentLine))
        {
          // Convert the namespace for BlueprintCore
          configuratorClass.AddImport(currentLine.Replace("BlueprintCoreGen", "BlueprintCore"));
          continue;
        }

        if (Namespace.IsMatch(currentLine))
        {
          // Convert the namespace for BlueprintCore
          configuratorClass.AddLine(currentLine.Replace("BlueprintCoreGen", "BlueprintCore"));
          continue;
        }

        if (Configures.IsMatch(currentLine))
        {
          configuratorClass.SetBlueprintType(AccessTools.TypeByName(Configures.Match(currentLine).Groups[1].Value));
          className = GetConfiguratorClassName(configuratorClass);
        }

        if (ClassDecl.IsMatch(currentLine))
        {
          isAbstract = false;
        }

        if (AbstractClassDecl.IsMatch(currentLine))
        {
          isAbstract = true;
        }

        if (GenerateComponents.IsMatch(currentLine))
        {
          if (configuratorClass.BlueprintType == null)
          {
            throw new InvalidOperationException("Cannot generate components before the Configures attribute.");
          }
          if (methodsByBlueprintType.ContainsKey(configuratorClass.BlueprintType))
          {
            methodsByBlueprintType[configuratorClass.BlueprintType].ForEach(
                method => AddMethod(configuratorClass, method, returnTypeOverride: isAbstract ? null : className));
          }
          continue;
        }

        configuratorClass.AddLine(currentLine);
      }
      return configuratorClass;
    }

    public static IConfiguratorClass CreateConfigurator(Type blueprintType, List<IMethod> methods, Type[] gameTypes)
    {
      var relativeNamespace = GetRelativeConfiguratorNamespace(blueprintType);
      var className = GetConfiguratorClassName(blueprintType);
      
      var configurator = new ConfiguratorClass(
          $"BlueprintConfigurators/{relativeNamespace.Replace('.', '/')}/{className}.cs");
      configurator.SetBlueprintType(blueprintType);
      configurator.AddImport(blueprintType);
      configurator.AddImport(
          $"using {GetConfiguratorNamespace(GetRelativeConfiguratorNamespace(blueprintType.BaseType))};");

      configurator.AddLine($"namespace {GetConfiguratorNamespace(relativeNamespace)}");
      configurator.AddLine($"{{");

      if (blueprintType.IsAbstract)
      {
        AddAbstractConfigurator(configurator, methods, className);
      }
      else if (gameTypes.ToList().Exists(t => t.IsSubclassOf(blueprintType)))
      {
        // Handles the case when a concrete blueprint inherits from another concrete blueprint. Configurators cannot
        // inherit from other concrete configurators, so create a base abstract class and a concrete implementation.
        AddAbstractConfigurator(configurator, methods, className);
        configurator.AddLine("");
        AddConfigurator(configurator, methods, className);
      }
      else
      {
        AddConfigurator(configurator, methods, className);
      }

      configurator.AddLine($"}}");
      return configurator;
    }

    private static void AddAbstractConfigurator(
        ConfiguratorClass configurator, List<IMethod> configuratorMethods, string className)
    {
      var blueprintTypeName = TypeTool.GetName(configurator.BlueprintType);
      AddClassSummary(
          configurator,
          $"Implements common fields and components for blueprints inheriting from <see cref=\"{blueprintTypeName}\"/>.");
      AddAttributes(configurator);
      configurator.AddLine($"  public abstract class Base{className}<T, TBuilder>");
      configurator.AddLine($"      : Base{GetConfiguratorClassName(configurator.BlueprintType.BaseType)}<T, TBuilder>");
      configurator.AddLine($"      where T : {blueprintTypeName}");
      configurator.AddLine($"      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>");
      configurator.AddLine($"  {{");
      configurator.AddLine($"    protected Base{className}(string name) : base(name) {{ }}");

      AddMethods(configurator, configuratorMethods, "TBuilder");
      
      configurator.AddLine($"  }}");
    }

    private static void AddConfigurator(
        ConfiguratorClass configurator, List<IMethod> configuratorMethods, string className)
    {
      var blueprintTypeName = TypeTool.GetName(configurator.BlueprintType);
      AddClassSummary(configurator, $"Configurator for <see cref=\"{blueprintTypeName}\"/>.");
      AddAttributes(configurator);
      configurator.AddLine(
          $"  public class {className} : Base{GetConfiguratorClassName(configurator.BlueprintType.BaseType)}<{blueprintTypeName}, {className}");
      configurator.AddLine($"  {{");
      configurator.AddLine($"    private {className}(string name) : base(name) {{ }}");

      configurator.AddLine($"");
      configurator.AddLine($"    /// <inheritdoc cref=\"Buffs.BuffConfigurator.For(string)\"/>");
      configurator.AddLine($"    public static {className} For(string name)");
      configurator.AddLine($"    {{");
      configurator.AddLine($"      return new {className}(name);");
      configurator.AddLine($"    }}");

      configurator.AddLine($"");
      configurator.AddLine($"    /// <inheritdoc cref=\"Buffs.BuffConfigurator.New(string)\"/>");
      configurator.AddLine($"    public static {className} New(string name)");
      configurator.AddLine($"    {{");
      configurator.AddLine($"      BlueprintTool.Create<{blueprintTypeName}>(name);");
      configurator.AddLine($"      return For(name);");
      configurator.AddLine($"    }}");

      configurator.AddLine($"");
      configurator.AddLine($"    /// <inheritdoc cref=\"Buffs.BuffConfigurator.New(string, string)\"/>");
      configurator.AddLine($"    public static {className} For(string name, string assetId)");
      configurator.AddLine($"    {{");
      configurator.AddLine($"      BlueprintTool.Create<{blueprintTypeName}>(name, assetId);");
      configurator.AddLine($"      return For(name);");
      configurator.AddLine($"    }}");

      AddMethods(configurator, configuratorMethods, className);
      
      configurator.AddLine($"  }}");
    }

    private static void AddMethods(ConfiguratorClass configurator, List<IMethod> configuratorMethods, string returnType)
    {
      var fields =
          configurator.BlueprintType.GetFields()
              .Where(field => field.DeclaringType == configurator.BlueprintType)
              .Select(field => FieldFactory.Create(field))
              .Where(field => field is not null)
              .ToList();
      fields.ForEach(
          field =>
          {
            MethodFactory.CreateForBlueprintField(configurator.BlueprintType, field, returnType)
                .ForEach(method => AddMethod(configurator, method));
          });

      configuratorMethods.ForEach(method => AddMethod(configurator, method, returnType));
    }

    private static void AddClassSummary(ConfiguratorClass configurator, string summary)
    {
      configurator.AddLine($"  /// <summary>");
      configurator.AddLine($"  /// {summary}");
      configurator.AddLine($"  /// </summary>");
      configurator.AddLine($"  /// <inheritdoc/>");
    }

    private static void AddAttributes(ConfiguratorClass configurator)
    {
      configurator.AddLine($"  [Configures(typeof({TypeTool.GetName(configurator.BlueprintType)}))]");
    }

    private static void AddMethod(ClassImpl basicClass, IMethod method, string returnTypeOverride = null)
    {
      method.GetImports().ForEach(import => basicClass.AddImport(import));

      basicClass.AddLine($"");
      method.GetText().ForEach(
          line =>
          {
            if (returnTypeOverride is null) { basicClass.AddLine($"    {line}"); }
            else { basicClass.AddLine($"    {line.Replace("TBuilder", returnTypeOverride)}"); }
          });
    }

    private static string GetConfiguratorClassName(IConfiguratorClass configurator)
    {
      return GetConfiguratorClassName(configurator.BlueprintType);
    }

    private static string GetConfiguratorClassName(Type blueprintType)
    {
      if (blueprintType == typeof(BlueprintScriptableObject))
      {
        return "BlueprintConfigurator";
      }
      return $"{TypeTool.GetName(blueprintType).Replace("Blueprint", "")}Configurator";
    }


    private static readonly List<string> IgnoredNamespacePackages = new() { "Kingmaker", "Blueprints" };
    private static string GetRelativeConfiguratorNamespace(Type type)
    {
      return string.Join('.', type.Namespace.Split('.').Where(pkg => !IgnoredNamespacePackages.Contains(pkg)));
    }

    private static string GetConfiguratorNamespace(string relativeNamespace)
    {
      if (string.IsNullOrEmpty(relativeNamespace))
      {
        return "BlueprintCore.Blueprints.Configurators";
      }
      return $"BlueprintCore.Blueprints.Configurators.{relativeNamespace}";
    }

    private class ClassImpl : IClass
    {
      public string RelativePath { get; private set; }

      private readonly StringBuilder Text = new();
      private readonly HashSet<Type> ImplementedTypes = new();

      private readonly HashSet<string> Imports = new() { "using BlueprintCore.Utils;" };

      public ClassImpl(string filePath)
      {
        RelativePath = filePath;
      }

      protected ClassImpl() { }

      public string GetText()
      {
        var sortedImports = Imports.ToList();
        sortedImports.Sort();
        Text.Insert(0, string.Join('\n', sortedImports) + "\n\n");

        return Text.ToString();
      }

      public List<Type> GetImplementedTypes()
      {
        return ImplementedTypes.ToList();
      }

      public void AddImport(string import)
      {
        Imports.Add(import);
      }

      public void AddImport(Type type)
      {
        // Skip type defined in the global namespace
        if (!string.IsNullOrEmpty(type.Namespace))
        {
          AddImport($"using {type.Namespace};");
        }
      }

      public void AddLine(string line)
      {
        Text.AppendLine(line);
      }

      public void AddImplementedType(Type type)
      {
        ImplementedTypes.Add(type);
      }
    }

    private class ConfiguratorClass : ClassImpl, IConfiguratorClass
    {
      public Type BlueprintType { get; private set; }

      public ConfiguratorClass(string filePath) : base(filePath) { }

      public void SetBlueprintType(Type type)
      {
        BlueprintType = type;
      }
    }
  }
}
