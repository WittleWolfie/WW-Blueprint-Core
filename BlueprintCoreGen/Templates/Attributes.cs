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

  public enum TemplateType
  {
    Unknown,

    // Blueprint types
    Blueprint,
    BlueprintComponent,

    // Action types
    Action,
    AreaAction,
    AVAction,
    BasicAction,
    ContextAction,
    KingdomAction,
    MiscAction,
    NewAction,
    StoryAction,
    UpgraderAction,

    // Condition types
    Condition,
    AreaCondition,
    BasicCondition,
    ContextCondition,
    KingdomCondition,
    NewCondition,
    StoryCondition
  }

  [AttributeUsage(AttributeTargets.Class)]
  public class Template : Attribute
  {
    private TemplateType Type;

    public Template(TemplateType type) { Type = type; }
  }
}
