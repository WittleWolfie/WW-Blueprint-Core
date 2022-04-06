using BlueprintCoreGen.CodeGen.Methods;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Mechanics.Actions;
using System;
using System.Collections.Generic;

namespace BlueprintCoreGen.CodeGen.Overrides.Examples
{
  /// <summary>
  /// Generates lists of example blueprints for each type. Used to generate method comments.
  /// </summary>
  public static class Examples
  {
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

    public static List<Blueprint> GetFor(Type type)
    {
      List<Blueprint> examples = new();

      if (ManualExamples.ContainsKey(type))
      {
        examples.AddRange(ManualExamples[type]);
      }

      if (type.IsSubclassOf(typeof(GameAction)) && ExampleGameActions.Examples.ContainsKey(type))
      {
        examples.AddRange(ExampleGameActions.Examples[type]);
      }

      if (type.IsSubclassOf(typeof(Condition)) && ExampleConditions.Examples.ContainsKey(type))
      {
        examples.AddRange(ExampleConditions.Examples[type]);
      }

      if (type.IsSubclassOf(typeof(BlueprintComponent)) && ExampleBlueprintComponents.Examples.ContainsKey(type))
      {
        examples.AddRange(ExampleBlueprintComponents.Examples[type]);
      }

      if (type.IsSubclassOf(typeof(BlueprintScriptableObject))
        && ExampleBlueprintScriptableObjects.Examples.ContainsKey(type))
      {
        examples.AddRange(ExampleBlueprintScriptableObjects.Examples[type]);
      }

      return examples;
    }
  }
}
