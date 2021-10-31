using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueprintCoreGen.Templates
{
  [AttributeUsage(AttributeTargets.Method)]
  public class ImplementsAttribute : Attribute
  {
    private Type Type;

    public ImplementsAttribute(Type type) { Type = type; }
  }
}
