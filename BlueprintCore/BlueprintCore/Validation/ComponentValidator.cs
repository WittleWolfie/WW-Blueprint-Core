using Kingmaker.Blueprints;
using Owlcat.QA.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueprintCore.BlueprintCore.Validation
{
  /// <summary>
  /// Validates blueprint component objects
  /// </summary>
  internal class ComponentValidator
  {
    public static void Check(BlueprintComponent component, ValidationContext context)
    {
      component.ApplyValidation(context, /* parentIndex= */ 0);
    }
  }
}
