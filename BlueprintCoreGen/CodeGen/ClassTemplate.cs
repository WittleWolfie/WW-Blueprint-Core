using Kingmaker.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueprintCoreGen.CodeGen
{
  /// <summary>
  /// A processed class template used to generate the output class file.
  /// </summary>
  public class ClassTemplate
  {
    // Relative directory path for the output class
    public readonly string RelativePath;
    private readonly HashSet<string> Imports = new() { "using BlueprintCore.Utils;" };
    private readonly StringBuilder ClassText = new();
    private readonly HashSet<Type> ImplementedTypes = new();

    public ClassTemplate(string filePath)
    {
      RelativePath = filePath;
    }

    protected ClassTemplate() { }

    /// <summary>
    /// Adds an import to the output class.
    /// </summary>
    public void AddImport(string import) { Imports.Add(import);}

    /// <summary>
    /// Adds an import to the output class.
    /// </summary>
    public void AddImport(Type type) { Imports.Add($"using {type.Namespace};"); }

    /// <summary>
    /// Adds a line of text the output class.
    /// </summary>
    public void AddLine(string line) { ClassText.AppendLine(line); }

    /// <summary>
    /// Adds a generated method to the output class.
    /// </summary>
    public void AddMethod(IMethod method)
    {
      method.GetImports().ForEach(import => Imports.Add(import));
      ClassText.AppendLine();
      ClassText.Append(method.GetText());
    }

    protected void Append(string text) { ClassText.Append(text);  }

    /// <summary>
    /// Adds a type implemented in the output class.
    /// </summary>
    public void AddType(Type type)
    {
      if (!ImplementedTypes.Contains(type)) { ImplementedTypes.Add(type); }
    }

    /// <returns>
    /// Text representation of the output class. Only call once.
    /// </returns>
    public string GetClassText()
    {
      var sortedImports = Imports.ToList();
      sortedImports.Sort();
      ClassText.Insert(0, string.Join('\n', sortedImports) + '\n');
      return ClassText.ToString();
    }

    /// <returns>
    /// List of types implemented in the output class.
    /// </returns>
    public List<Type> GetImplementedTypes() { return ImplementedTypes.ToList(); }
  }

  public class ConfiguratorTemplate : ClassTemplate
  {
    private Type _blueprintType;
    public Type BlueprintType
    {
      get => _blueprintType;
      set
      {
        _blueprintType = value;
        AddImport(_blueprintType);
        if (_blueprintType != typeof(BlueprintScriptableObject))
        {
          AddImport($"using {GetNamespace(GetRelativeNamespace(_blueprintType.BaseType))};");
        }
      }
    }

    public ConfiguratorTemplate(string relativePath) : base(relativePath) { }

    public void AddConfiguratorMethod(IMethod method, bool isAbstract)
    {
      method.GetImports().ForEach(import => AddImport(import));
      AddLine("");
      Append(isAbstract ? method.GetText() : method.GetText().Replace("TBuilder", GetClassName(BlueprintType)));
    }

    public void AddDeclaration(bool isAbstract)
    {
      var className = GetClassName(BlueprintType);
      if (isAbstract)
      {
        AddLine($"  /// <summary>");
        AddLine($"  /// Implements common fields and components for blueprints inheriting from <see cref=\"{BlueprintType.Name}\"/>.");
        AddLine($"  /// </summary>");
        AddLine($"  /// <inheritdoc/>");
        AddLine($"  [Configures(typeof({CodeGenerator.GetTypeName(BlueprintType)}))]");
        AddLine($"  public abstract class Base{className}<T, TBuilder>");
        AddLine($"      : Base{GetClassName(BlueprintType.BaseType)}<T, TBuilder>");
        AddLine($"      where T : {CodeGenerator.GetTypeName(BlueprintType)}");
        AddLine($"      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>");
        AddLine(@"  {");
        AddLine($"     protected Base{className}(string name) : base(name) {{ }}");
      }
      else
      {
        AddLine($"  /// <summary>Configurator for <see cref=\"{BlueprintType.Name}\"/>.</summary>");
        AddLine($"  /// <inheritdoc/>");
        AddLine($"  [Configures(typeof({CodeGenerator.GetTypeName(BlueprintType)}))]");
        AddLine($"  public class {className} : Base{GetClassName(BlueprintType.BaseType)}<{CodeGenerator.GetTypeName(BlueprintType)}, {className}>");
        AddLine(@"  {");
        AddLine($"     private {className}(string name) : base(name) {{ }}");
        AddLine("");
        AddStaticConstructor(className, ConstructorType.For);
        AddLine("");
        AddStaticConstructor(className, ConstructorType.New);
        AddLine("");
        AddStaticConstructor(className, ConstructorType.NewAssetId);
      }
    }

    public void EndClass()
    {
      AddLine(@"  }");
    }

    private enum ConstructorType
    {
      For,
      New,
      NewAssetId
    }

    private void AddStaticConstructor(string className, ConstructorType type)
    {
      switch (type)
      {
        case ConstructorType.For:
          AddLine($"    /// <inheritdoc cref=\"Buffs.BuffConfigurator.For(string)\"/>");
          AddLine($"    public static {GetClassName(BlueprintType)} For(string name)");
          AddLine(@"    {");
          AddLine($"      return new {className}(name);");
          AddLine(@"    }");
          break;
        case ConstructorType.New:
          AddLine($"    /// <inheritdoc cref=\"Buffs.BuffConfigurator.New(string)\"/>");
          AddLine($"    public static {GetClassName(BlueprintType)} New(string name)");
          AddLine(@"    {");
          AddLine($"      BlueprintTool.Create<{CodeGenerator.GetTypeName(BlueprintType)}>(name);");
          AddLine($"      return For(name);");
          AddLine(@"    }");
          break;
        case ConstructorType.NewAssetId:
          AddLine($"    /// <inheritdoc cref=\"Buffs.BuffConfigurator.New(string, string)\"/>");
          AddLine($"    public static {GetClassName(BlueprintType)} New(string name, string assetId)");
          AddLine(@"    {");
          AddLine($"      BlueprintTool.Create<{CodeGenerator.GetTypeName(BlueprintType)}>(name, assetId);");
          AddLine($"      return For(name);");
          AddLine(@"    }");
          break;
      }
    }

    private static readonly List<string> IgnoredNamespacePackages = new() { "Kingmaker", "Blueprints" };

    public static string GetRelativeNamespace(Type type)
    {
      return string.Join('.', type.Namespace.Split('.').Where(pkg => !IgnoredNamespacePackages.Contains(pkg)));
    }

    public static string GetNamespace(string relativeNamespace)
    {
      if (string.IsNullOrEmpty(relativeNamespace))
      {
        return "BlueprintCore.Blueprints.Configurators";
      }
      return $"BlueprintCore.Blueprints.Configurators.{relativeNamespace}";
    }

    public static string GetClassName(Type type)
    {
      if (type == typeof(BlueprintScriptableObject))
      {
        return "BlueprintConfigurator";
      }
      return $"{CodeGenerator.GetTypeName(type).Replace("Blueprint", "")}Configurator";
    }
  }
}
