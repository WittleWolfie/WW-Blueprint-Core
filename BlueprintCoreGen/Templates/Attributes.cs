using System;

namespace BlueprintCoreGen.Templates
{
  /// <summary>
  /// Identifies which game type is constructed by the method.
  /// </summary>
  [AttributeUsage(AttributeTargets.Method)]
  public class ImplementsAttribute : Attribute
  {
#pragma warning disable IDE0060 // Remove unused parameter
    public ImplementsAttribute(Type type) { }
#pragma warning restore IDE0060 // Remove unused parameter
  }
}
