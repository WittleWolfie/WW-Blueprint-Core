using Kingmaker.Blueprints;
using System.Collections.Generic;

namespace BlueprintCore.Utils
{
  /// <summary>Extension methods for types inheriting from <see cref="BlueprintScriptableObject"/></summary>
  public static class BlueprintExtensions
  {
    /// <summary>Returns the first <see cref="BlueprintComponent"/> with the same type as the specified component.</summary>
    public static BlueprintComponent GetComponentMatchingType(this BlueprintScriptableObject obj, BlueprintComponent component)
    {
      foreach (BlueprintComponent current in obj.ComponentsArray)
      {
        if (current.GetType() == component.GetType()) { return current; }
      }
      return null!;
    }

    /// <summary> Adds all provided components to the blueprint. </summary>
    public static void AddComponents(this BlueprintScriptableObject obj, params BlueprintComponent[] components)
    {
      if (components == null) { return; }
      obj.SetComponents(CommonTool.Append(components, obj.Components));
    }

    /// <summary>Sets the blueprint's components to the provided list.</summary>
    /// 
    /// <remarks>
    /// <para>
    /// Modified from <see href="https://github.com/Vek17/WrathMods-TabletopTweaks">TabletopTweaks ExtensionMethods</see>.
    /// </para>
    /// 
    /// <para>
    /// This is the preferred way to update a blueprint's components; it ensures that each component has a unique name.
    /// This is important for proper serialization behavior.
    /// </para>
    /// </remarks>
    public static void SetComponents(this BlueprintScriptableObject obj, params BlueprintComponent[] components)
    {
      // Fix names of components. Generally this doesn't matter, but if they have serialization
      // state, then their name needs to be unique.
      var names = new HashSet<string>();
      foreach (var c in components)
      {
        if (string.IsNullOrEmpty(c.name)) { c.name = $"${c.GetType().Name}"; }
        if (!names.Add(c.name))
        {
          string name;
          for (int i = 0; !names.Add(name = $"{c.name}${i}"); i++) ;
          c.name = name;
        }
      }
      obj.Components = components;
    }
  }
}
