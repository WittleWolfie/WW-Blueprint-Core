using Owlcat.QA.Validation;
using System.Linq;

namespace BlueprintCore.BlueprintCore.Validation
{
  /// <summary>
  /// Validates the provided object meets the constraints defined by Owlcat's attributes.
  /// </summary>
  internal static class AttributeValidator
  {
    public static void Check(object obj, ValidationContext context)
    {
      foreach (var field in obj.GetType().GetFields())
      {
        foreach (
          var validationAttr 
            in field.GetCustomAttributes(typeof(ValidatingFieldAttribute), false).Cast<ValidatingFieldAttribute>())
        {
          validationAttr.ValidateField(obj, field, context, /* parentIndex= */ 0);

          // Some of Owlcat's attributes are either not implemented or are stripped in release. Manual implementations
          // below.
          if (validationAttr is ValidateNotNullAttribute)
          {
            if (field.GetValue(obj) is null)
            {
              context.AddError("{0} is null in {1}", field.Name, obj.GetType().Name);
            }
            continue;
          }
          
          if (validationAttr is ValidateIsPrefabAttribute)
          {
            if (field.GetValue(obj) as UnityEngine.Object == null)
            {
              context.AddError("{0} is not a prefab in {1}", field.Name, obj.GetType().Name);
            }
            continue;
          }

          if (validationAttr is ValidatePositiveNumberAttribute)
          {
            if (field.GetValue(obj) as int? <= 0)
            {
              context.AddError("{0} is not positive in {1}", field.Name, obj.GetType().Name);
            }
            continue;
          }

          if (validationAttr is ValidatePositiveOrZeroNumberAttribute)
          {
            if (field.GetValue(obj) as int? < 0)
            {
              context.AddError("{0} is not positive or zero in {1}", field.Name, obj.GetType().Name);
            }
          }
        }
      }
    }
  }
}
