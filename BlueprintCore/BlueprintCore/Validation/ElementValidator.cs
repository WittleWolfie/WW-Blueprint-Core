using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Owlcat.QA.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueprintCore.BlueprintCore.Validation
{
  /// <summary>
  /// Validates element objects
  /// </summary>
  internal class ElementValidator
  {
    public static void Check(Element element, ValidationContext context)
    {
      if (string.IsNullOrEmpty(element.name))
      {
        context.AddError("{0} is missing a name. Create it using ElementTool.Create().", element.GetType().Name);
      }

      if (element is DealStatDamage damage)
      {
        // DealStatDamage is unique in that it has a validate function but doesn't implement IValidated, so this
        // ensures validate is called.
        damage.Validate(context, /* parentIndex= */ 0);
      }
    }
  }
}
