using BlueprintCoreGen.CodeGen.Params;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BlueprintCoreGen.CodeGen.Methods
{
  /// <summary>
  /// Represents a blueprint. Used to populate example usage comments.
  /// </summary>
  public class Blueprint
  {
    [JsonProperty]
    public string BlueprintName { get; private set; } = string.Empty;

    [JsonProperty]
    public string BlueprintGuid { get; private set; } = string.Empty;

    public Blueprint(string name, string guid)
    {
      BlueprintName = name;
      BlueprintGuid = guid;
    }
  }

  /// <summary>
  /// Base class for overriding a method's behavior.
  /// </summary>
  /// 
  /// <remarks>
  /// It is generally not advisable to add a field to multiple overrides, e.g. RequiredFields and CustomFields.
  /// </remarks>
  public abstract class BaseMethodOverride
  {
    /// <summary>
    /// Sets the name of the method, if specified.
    /// </summary>
    [JsonProperty]
    public string MethodName { get; private set; } = string.Empty;

    /// <summary>
    /// Remarks added to the method's comments. Uses XML Doc syntax. Each entry is a new paragraph.
    /// </summary>
    public List<string> Remarks { get; } = new();

    /// <summary>
    /// A list of types to import (by name).
    /// </summary>
    public List<string> Imports { get; } = new();

    /// <summary>
    /// List of fields (by name) required as method parameters.
    /// </summary>
    public List<string> RequiredFields { get; } = new();

    /// <summary>
    /// List of fields (by name) ignored as method parameters.
    /// </summary>
    public List<string> IgnoredFields { get; } = new();

    /// <summary>
    /// List of fields (by name) and their default method parameter values.
    /// </summary>
    public List<DefaultField> DefaultFields { get; } = new();

    /// <summary>
    /// List of fields (by name) and their constant values.
    /// </summary>
    public List<ConstantField> ConstantFields { get; } = new();

    /// <summary>
    /// List of fields (by name) to customize.
    /// </summary>
    public List<CustomField> CustomFields { get; } = new();

    /// <summary>
    /// Extra parameters that don't map to a field.
    /// </summary>
    public List<ExtraParameter> ExtraParams { get; } = new();

    /// <summary>
    /// Extra lines where {0} is the object name
    /// </summary>
    public List<string> ExtraFmtLines { get; } = new();

    /// <summary>
    /// Returns ExtraParams as a list of IParameterInternal objects.
    /// </summary>
    public List<IParameterInternal> GetExtraParams()
    {
      return ExtraParams.Select(extraParam => extraParam as IParameterInternal).ToList();
    }

    /// <summary>
    /// Applies field parameter overrides to the specified field, if any are present.
    /// </summary>
    public void ApplyTo(FieldInfo info, FieldParameter param)
    {
      if (IgnoredFields.Contains(info.Name))
      {
        param.MakeIgnored();
        return;
      }

      if (RequiredFields.Contains(info.Name))
      {
        param.MakeRequired();
        return;
      }

      var defaultField = DefaultFields.Where(field => info.Name.Equals(field.FieldName)).FirstOrDefault();
      if (defaultField is not null)
      {
        defaultField.ApplyTo(param);
        return;
      }

      var constantField = ConstantFields.Where(field => info.Name.Equals(field.FieldName)).FirstOrDefault();
      if (constantField is not null)
      {
        constantField.ApplyTo(param);
        return;
      }

      var customField = CustomFields.Where(field => info.Name.Equals(field.FieldName)).FirstOrDefault();
      if (customField is not null)
      {
        customField.ApplyTo(param);
        return;
      }
    }

    /// <summary>
    /// Returns a new merged copy of the provided overrides. 
    /// </summary>
    /// 
    /// <remarks>
    /// <list type="bullet">
    /// <item><term>MethodName</term><description>Taken from overrideMethod</description></item>
    /// <item><term>Remarks</term><description>Concatenated</description></item>
    /// <item><term>Imports</term><description>Concatenated</description></item>
    /// <item><term>RequiredFields</term><description>Concatenated</description></item>
    /// <item><term>IgnoredFields</term><description>Concatenated</description></item>
    /// <item><term>DefaultFields</term><description>Concatenated</description></item>
    /// <item><term>ConstantFields</term><description>Concatenated</description></item>
    /// <item><term>CustomFields</term><description>Concatenated</description></item>
    /// <item><term>ExtraParams</term><description>Concatenated</description></item>
    /// </list>
    /// </remarks>
    public static MethodOverride Merge(MethodOverride baseMethod, MethodOverride overrideMethod)
    {
      MethodOverride result = new();
      result.MethodName = overrideMethod.MethodName;
      result.Remarks.AddRange(baseMethod.Remarks.Concat(overrideMethod.Remarks));
      result.Imports.AddRange(baseMethod.Imports.Concat(overrideMethod.Imports));
      result.RequiredFields.AddRange(baseMethod.RequiredFields.Concat(overrideMethod.RequiredFields));
      result.IgnoredFields.AddRange(baseMethod.IgnoredFields.Concat(overrideMethod.IgnoredFields));
      result.DefaultFields.AddRange(baseMethod.DefaultFields.Concat(overrideMethod.DefaultFields));
      result.ConstantFields.AddRange(baseMethod.ConstantFields.Concat(overrideMethod.ConstantFields));
      result.CustomFields.AddRange(baseMethod.CustomFields.Concat(overrideMethod.CustomFields));
      result.ExtraParams.AddRange(baseMethod.ExtraParams.Concat(overrideMethod.ExtraParams));
      result.ExtraFmtLines.AddRange(baseMethod.ExtraFmtLines.Concat(overrideMethod.ExtraFmtLines));
      return result;
    }
  }

  /// <summary>
  /// Concrete implementation of basic overrides. Ensures type safety for usages such as TypeBuilder.Methods where an
  /// implementation of the base class is desired.
  /// </summary>
  public class MethodOverride : BaseMethodOverride { } 

  /// <summary>
  /// Represents a game type constructor method. e.g. AddAction(), AddCondition(), AddComponent()
  /// </summary>
  public class ConstructorMethod : MethodOverride
  {
    /// <summary>
    /// TypeName represented by this object. If there is a type name conflict this must be fully qualified.
    /// </summary>
    [JsonProperty]
    public string TypeName { get; private set; } = string.Empty;

    /// <summary>
    /// Custom constructor. Used when there is no default constructor.
    /// </summary>
    [JsonProperty]
    public string ConstructorRhs { get; private set; } = string.Empty;

    /// <summary>
    /// A list of Builder method overrides. 
    /// </summary>
    /// 
    /// <remarks>
    /// <para>
    /// For each MethodOverride in the list a method is generated by merging this object (baseMethod) with the provided
    /// method (overrideMethod). See <see cref="BaseMethodOverride.Merge(MethodOverride, MethodOverride)"/> for a
    /// breakdown of how merging works.
    /// </para>
    /// 
    /// <para>
    /// As a general rule, you should not specify any field twice as the effect may be unexpected.
    /// </para>
    /// </remarks>
    [JsonProperty]
    public List<MethodOverride> Methods { get; private set; } = new();

    public ConstructorMethod(string typeName)
    {
      TypeName = typeName;
    }
  }

  /// <summary>
  /// Represents a method for a field in a blueprint configurator. e.g. SetValue(), AddToValue(), RemoveFromValue()
  /// </summary>
  public class FieldMethod : MethodOverride
  {
    [JsonProperty]
    public List<MethodOverride> Methods { get; private set; } = new();
  }
}
