using System;
using System.Collections.Generic;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;

namespace BlueprintCore.Utils
{
  static class ExtensionMethods
  {
    public static T[] AppendToArray<T>(this T[] array, params T[] values)
    {
      if (values == null) { return array; }
      var len = array.Length;
      var result = new T[len + values.Length];
      Array.Copy(array, result, len);
      Array.Copy(values, 0, result, len, values.Length);
      return result;
    }

    public static void AddIsPrerequisiteFor(this BlueprintFeature feature, BlueprintFeature other)
    {
      if (feature.IsPrerequisiteFor == null)
      {
        feature.IsPrerequisiteFor = new List<BlueprintFeatureReference>();
      }
      feature.IsPrerequisiteFor.Add(other.ToReference<BlueprintFeatureReference>());
    }
  }
}