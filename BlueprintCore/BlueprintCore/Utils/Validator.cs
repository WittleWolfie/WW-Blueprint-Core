using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Owlcat.QA.Validation;
using System.Collections.Generic;

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
  public static class Validator
  {
    /// <summary>Checks the object and returns a list of validation warnings</summary>
    /// 
    /// <remarks>
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
    /// </remarks>
    public static List<string> Check(object? obj)
    {
      List<string> errors = new();
      if (obj == null) { return errors; }

      var name = obj is Element element ? element.name : obj.GetType().ToString();
      ValidationContext context = new(name);
      Check(obj, context);

      if (obj is Element && string.IsNullOrEmpty(name))
      {
        errors.Add(
            $"Element name missing: {obj.GetType()}. Create using ElementTool.Create().");
      }
      else if (obj is BlueprintComponent component) { component.ApplyValidation(context, -1); }

      errors.AddRange(context.Errors);
      return errors;
    }

    private static void Check(object obj, ValidationContext context)
    {
      // TODO: Validate fields object fields w/ ValidatingFieldAttribute
      if (obj is IValidated validated)
      {
        validated.Validate(context, -1);
      }
      else if (obj is DealStatDamage damage)
      {
        // DealStatDamage implements Validate but not IValidated
        damage.Validate(context, -1);
      }
    }
  }
}