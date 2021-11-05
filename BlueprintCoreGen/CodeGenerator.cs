using Kingmaker.ElementsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueprintCoreGen
{
  public static class CodeGenerator
  {
    // TODO: Need to generate unit test!
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
      var fields = type.GetFields().Where(field => !field.Name.Contains("__BackingField"));
      Method method = new();
      method.Imports.Add(GetImport(type));

      method.Text.AppendLine($"    /// <summary>");
      method.Text.AppendLine($"    /// Adds <see cref=\"{type.Name}\"/>");
      method.Text.AppendLine($"    /// </summary>");

      List<string> declaration = new();
      List<string> body = new();
      if (fields.Count() > 1)
      {
        // TODO: Implement
      }
      else // Only field is Element.name so no parameters required
      {
        declaration.Add(
            $"    public static {builderType} Add{type.Name}(this {builderType} builder)");
        body.Add(
            $"      return builder.Add(ElementTool.Create<{type.Name}>());");
      }

      method.Text.AppendLine($"    [Generated]");
      method.Text.AppendLine($"    [Implements(typeof({type.Name}))]");
      declaration.ForEach(line => method.Text.AppendLine(line));
      method.Text.AppendLine(@"    {");
      body.ForEach(line => method.Text.AppendLine(line));
      method.Text.AppendLine(@"    }");

      return method;
    }

    private static string GetImport(Type type)
    {
      return $"using {type.Namespace};";
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
