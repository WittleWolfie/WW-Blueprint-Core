using BlueprintCoreGen.CodeGen.Methods;
using Kingmaker.UnitLogic.Mechanics.Actions;
using System;
using System.Collections.Generic;

namespace BlueprintCoreGen.CodeGen.Overrides
{
  /// <summary>
  /// Stores lists of example blueprints for each type. Used to generate method comments.
  /// </summary>
  public static class Examples
  {
    public static readonly Dictionary<Type, HashSet<Blueprint>> BuilderExamples =
      new()
      {
        // ** Manually selected examples **//

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
        },

        // ********************************//


      };
  }
}
