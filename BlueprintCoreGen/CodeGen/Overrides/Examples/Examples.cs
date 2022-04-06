using BlueprintCoreGen.CodeGen.Methods;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Mechanics.Actions;
using System;
using System.Collections.Generic;

namespace BlueprintCoreGen.CodeGen.Overrides.Examples
{
  /// <summary>
  /// Stores lists of example blueprints for each type. Used to generate method comments.
  /// </summary>
  public static class Examples
  {
    public static List<Blueprint> GetFor(Type type)
    {
      List<Blueprint> examples = new();
      if (type.IsSubclassOf(typeof(GameAction)))
      {
        ExampleGameActions.Examples.TryGetValue(type, out examples);
      }

      if (type.IsSubclassOf(typeof(Condition)))
      {
        ExampleConditions.Examples.TryGetValue(type, out examples);
      }

      if (type.IsSubclassOf(typeof(BlueprintComponent)))
      {
        ExampleBlueprintComponents.Examples.TryGetValue(type, out examples);
      }

      if (type.IsSubclassOf(typeof(BlueprintScriptableObject)))
      {
        ExampleBlueprintScriptableObjects.Examples.TryGetValue(type, out examples);
      }

      if (examples is null || examples.Count == 0)
      {
        ManualExamples.TryGetValue(type, out examples);
      }

      return examples ?? new();
    }

    private static readonly Dictionary<Type, List<Blueprint>> ManualExamples =
      new()
      {
        {
          typeof(ContextActionArmorEnchantPool),
          new() { new Blueprint("SacredArmorEnchantSwitchAbility", "66484ebb8d358db4692ef4445fa6ac35") }
        },

        {
          typeof(ContextActionShieldArmorEnchantPool),
          new() { new Blueprint("SacredArmorShieldEnchantSwitchAbility", "b0777d9974795a5489ff0efd735a4c2a") }
        },

        {
          typeof(ContextActionWeaponEnchantPool),
          new() { new Blueprint("SacredWeaponEnchantSwitchAbility", "cca63747a12b55f44ad56ef2d840d7f4") }
        },

        {
          typeof(ContextActionShieldWeaponEnchantPool),
          new() { new Blueprint("SacredWeaponShieldEnchantSwitchAbility", "a89fc47958b895948a6c613ec1b9da85") }
        }
      };
  }
}
