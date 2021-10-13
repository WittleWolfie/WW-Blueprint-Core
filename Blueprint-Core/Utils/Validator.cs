using System.Collections.Generic;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Validation;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;

namespace BlueprintCore.Utils
{
  /**
   * For APIs already implemented in BlueprintCore, this should already be called for any relevant
   * objects.
   *
   * If you're instantiating objects outside of BlueprintCore you can call Check() to get
   * a list of a validation warnings.
   */
  public static class Validator
  {
    private static readonly ValidationContext Context = new();

    /**
     * Runs Owlcat's validation and some on the object. Each entry in the returned list is its own
     * validation error.
     *
     * All Objects: ValidationContext#ValidateFieldAttributes()
     * Elements: Verifies there is a name.
     * BlueprintComponents: BlueprintComponent#ApplyValidation()
     * IValidated: IValidated#Validate()
     */
    public static List<string> Check(object obj)
    {
      if (obj == null) { }
      List<string> errors = new();

      var name = obj is Element ? (obj as Element).name : obj.GetType().ToString();
      Check(obj, name);

      if (obj is Element && string.IsNullOrEmpty(name))
      {
        errors.Add(
            $"Element name missing: {obj.GetType()}. Create using ElementTool.Create().");
      }
      else if (obj is BlueprintComponent) { (obj as BlueprintComponent).ApplyValidation(Context); }

      errors.AddRange(Context.Errors);
      Context.Clear();
      return errors;
    }

    private static void Check(object obj, string name)
    {
      Context.ValidateFieldAttributes(obj, name);

      if (obj is IValidated)
      {
        (obj as IValidated).Validate(Context, name ?? obj.GetType().ToString());
      }
      else if (obj is DealStatDamage)
      {
        // DealStatDamage implements Validate but not IValidated
        (obj as DealStatDamage).Validate(Context, name ?? obj.GetType().ToString());
      }
    }
  }
}