using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueprintCoreGen.CodeGen.Override
{
  /// <summary>
  /// Manual overrides for a method. 
  /// </summary>
  public class SingleMethodOverride
  {
    public List<Type> Imports = new();

    public List<string> Remarks = new();

    public string? Name;

    public Dictionary<string, FieldParamOverride> FieldOverridesByName = new();
  }

  /// <summary>
  /// Wrapper around SingleMethodOverride to enable splitting a method into multiple methods.
  /// </summary>
  public class MethodOverride
  {
    /// <summary>
    /// If true, the default generated method is skipped and only Methods are generated.
    /// </summary>
    public bool IgnoreDefault = false;

    public List<SingleMethodOverride> Methods = new();
  }

  /// <summary>
  /// Contains hand-tuned overrides for builder methods.
  /// </summary>
  public class BuilderMethodOverrides
  {
    public static readonly Dictionary<Type, MethodOverride> MethodOverrides =
      new()
      {

      };
  }
}
