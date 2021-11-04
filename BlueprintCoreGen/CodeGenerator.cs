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
    public static string CreateMethod(Type type)
    {
      if (type.IsSubclassOf(typeof(GameAction)))
      {
        return CreateBuilderMethod("ActionsBuilder", type);
      }
      return "";
    }

    private static string CreateBuilderMethod(string builderType, Type type)
    {
      // Filter fields which are usually not required for instantiation.
      var fields = type.GetFields().Where(field => !field.Name.Contains("__BackingField"));
      StringBuilder method = new();

      method.AppendLine($"    /// <summary>");
      method.AppendLine($"    /// Adds <see cref=\"{type.Name}\"/>");
      method.AppendLine($"    /// </summary>");

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

      method.AppendLine($"    [Generated]");
      method.AppendLine($"    [Implements(typeof({type.Name}))]");
      declaration.ForEach(line => method.AppendLine(line));
      method.AppendLine(@"    {");
      body.ForEach(line => method.AppendLine(line));
      method.AppendLine(@"    }");

      return method.ToString();
    }
  }
}
