using System;
using System.IO;
using System.Reflection;

namespace BlueprintCoreGen
{
  class Program
  {
    static void Main(string[] args)
    {
      // Since the code doesn't reference assemblies, force load them for reflection
      Assembly.Load("Assembly-CSharp");
      Assembly.Load("Blueprint-Core");

      TemplateProcessor.Run();

      foreach (Template template in TemplateProcessor.Templates)
      {
        File.WriteAllText($"{template.ClassName}.cs", template.GetClassText());
        Console.WriteLine($"Created: {template.ClassName}");
        Console.WriteLine($"Types:\n{string.Join('\n', template.GetImplementedTypes())}");
      }
    }
  }
}
