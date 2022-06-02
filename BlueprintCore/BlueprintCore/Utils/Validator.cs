using BlueprintCore.Utils.Validation;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Owlcat.QA.Validation;
using System.Collections;
using System.Linq;
using System.Text;

#nullable enable
namespace BlueprintCore.Utils
{
  /// <summary>
  /// Validates the configuration of objects.
  /// </summary>
  /// 
  /// <remarks>
  /// Any API implemented in BlueprintCore calls this for all relevant object types. If you instantiate objects outside
  /// of BlueprintCore you can call <see cref="Check"/> to get validation warnings.
  /// </remarks>
  public class Validator
  {
    private readonly ValidationContext Context;
    private readonly string Name;
    private readonly string TypeName;

    /// <summary>
    /// Creates a Validator for an object. The name and type name are used to generate the error string.
    /// </summary>
    public Validator(string name, string typeName)
    {
      Context = new(name);
      Name = name;
      TypeName = typeName;
    }

    /// <summary>Validates the given object</summary>
    /// 
    /// <remarks>
    /// <para>
    /// Uses a combination of Wrath validation logic and custom logic validating that implicit object constraints are
    /// met. The exact validation run varies by type.
    /// <list type="bullet">
    /// <item>
    ///   <term><see cref="Element"/> types</term>
    ///   <description>Verifies that <see cref="Element.name"/> is set.</description>
    /// </item>
    /// <item>
    ///   <term><see cref="BlueprintComponent"/> types</term>
    ///   <description><see cref="BlueprintComponent.ApplyValidation(ValidationContext)"/></description>
    /// </item>
    /// <item>
    ///   <term><see cref="IValidated"/> types</term>
    ///   <description><see cref="IValidated.Validate"/></description>
    /// </item>
    /// </list>
    /// There are some special cases as well, such as <see cref="DealStatDamage"/>.
    /// </para>
    /// 
    /// <para>
    /// Note that you can call this method multiple time for a given Validator instance. All of the errors will be
    /// bundled into a single error string. This is useful when constructing a several related objects. For example,
    /// a single BlueprintConfigurator instance stores a single Validator which is used to validate all of its fields,
    /// components, actions, and conditions.
    /// </para>
    /// </remarks>
    public void Check(object? obj)
    {
      if (obj == null) { return; }

      if (obj is IEnumerable enumerable)
      {
        foreach (var item in enumerable)
        {
          Check(item);
        }
        return;
      }

      if (obj is IValidated validated)
      {
        validated.Validate(Context, /* parentIndex= */ 0);
      }

      AttributeValidator.Check(obj, Context);
      
      if (obj is Element element)
      {
        ElementValidator.Check(element, Context);
      }
      else if (obj is BlueprintComponent component)
      {
        ComponentValidator.Check(component, Context);
      }
      else if (obj is BlueprintScriptableObject blueprint)
      {
        BlueprintValidator.Check(blueprint, Context);
      }
    }

    public bool HasErrors()
    {
      return Context.HasErrors;
    }

    /// <summary>
    /// Returns a string listing each validation error on a separate line, or an empty string if there are no errors.
    /// </summary>
    public string GetErrorString()
    {
      if (!HasErrors()) { return ""; }
      StringBuilder errors = new();
      errors.AppendLine($"{Name} ({TypeName}) failed validation:");
      Context.Errors.ToList().ForEach(error => errors.AppendLine($"  * {error}"));
      return errors.ToString();
    }
  }
}