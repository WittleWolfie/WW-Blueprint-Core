using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueprintCoreGen.CodeGen
{
  /// <summary>
  /// A processed class template used to generate the output class file.
  /// </summary>
  public class Template
  {
    // Relative directory path for the output class
    public readonly string RelativePath;
    private readonly List<string> Imports = new() { "using BlueprintCore.Utils;" };
    private readonly StringBuilder ClassText = new();
    private readonly HashSet<Type> ImplementedTypes = new();

    public Template(string filePath)
    {
      RelativePath = filePath;
    }

    /// <summary>
    /// Adds an import to the output class.
    /// </summary>
    public void AddImport(string import) { Imports.Add(import); }

    /// <summary>
    /// Adds a line of text the output class.
    /// </summary>
    public void AddLine(string line) { ClassText.AppendLine(line); }

    /// <summary>
    /// Adds a generated method to the output class.
    /// </summary>
    public void AddMethod(Method method)
    {
      Imports.AddRange(method.GetImports());
      ClassText.AppendLine();
      ClassText.Append(method.GetText());
    }

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
      Imports.Sort();
      ClassText.Insert(0, string.Join('\n', Imports.Distinct()) + '\n');
      return ClassText.ToString();
    }

    /// <returns>
    /// List of types implemented in the output class.
    /// </returns>
    public List<Type> GetImplementedTypes() { return ImplementedTypes.ToList(); }
  }
}
