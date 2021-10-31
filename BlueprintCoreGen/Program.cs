using System;
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
        Console.WriteLine($"Template: {template.ClassName}");
        Console.WriteLine($"Imports:\n{template.GetImports()}");
        Console.WriteLine($"Methods:\n{template.GetAllMethods()}");
      }
    }
  }
}
