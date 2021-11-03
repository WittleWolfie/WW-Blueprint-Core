using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using BlueprintCoreGen.Templates;

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

      List<Template> areaActionTemplates =
          TemplateProcessor.Templates.Where(t => t.Type == TemplateType.AreaAction).ToList();



      foreach (Template template in TemplateProcessor.Templates)
      {
        Console.WriteLine($"Template: {template.Type}");
        Console.WriteLine($"Imports:\n{template.GetImports()}");
        Console.WriteLine($"Methods:\n{template.GetAllMethods()}");
      }


    }
  }
}
