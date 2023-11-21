using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.AI.Blueprints.Considerations;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to LocatorsConsideration blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class LocatorsConsiderationRefs
  {
    public static readonly Blueprint<BlueprintReference<LocatorsConsideration>> DLC5_SithhudLocatorConsideration = "2de6c0add6414344a790b9704b6ffc3d";
    public static readonly Blueprint<BlueprintReference<LocatorsConsideration>> Overseer_Consideration_Locators = "a8f9a277c2914a72ad87398bfc923d70";
    public static readonly Blueprint<BlueprintReference<LocatorsConsideration>> Sithhud_Consideration_Locator_Bite_Center = "2afb2640058e4157a8a92681ec4e966e";
    public static readonly Blueprint<BlueprintReference<LocatorsConsideration>> Sithhud_Consideration_Locator_Bite_Center_Double = "0aa3cf890e04482d9d9def7fbc53bdd0";
    public static readonly Blueprint<BlueprintReference<LocatorsConsideration>> Sithhud_Consideration_Locator_Bite_Left = "1125442002024e1da97cff55484ad55c";
    public static readonly Blueprint<BlueprintReference<LocatorsConsideration>> Sithhud_Consideration_Locator_Bite_Left_Double = "2bee0b868e3b4673b097374233f1f7a9";
    public static readonly Blueprint<BlueprintReference<LocatorsConsideration>> Sithhud_Consideration_Locator_Bite_Right = "11f17346e50e40e6bc5ef7f4437c60ad";
    public static readonly Blueprint<BlueprintReference<LocatorsConsideration>> Sithhud_Consideration_Locator_Bite_Right_Double = "170fd6d9b2e0400bbaec432fa9fa0e55";
    public static readonly Blueprint<BlueprintReference<LocatorsConsideration>> Sithhud_Consideration_Locator_Breath_Center = "fd7099e0d395403abb3947c8f8222540";
    public static readonly Blueprint<BlueprintReference<LocatorsConsideration>> Sithhud_Consideration_Locator_Breath_Center_Inhale = "67893d3be42d460ba2c3d6567a68a658";
    public static readonly Blueprint<BlueprintReference<LocatorsConsideration>> Sithhud_Consideration_Locator_Breath_Left = "6af6b4797abc457190ddc789d3e92463";
    public static readonly Blueprint<BlueprintReference<LocatorsConsideration>> Sithhud_Consideration_Locator_Breath_Right = "ec2fa3fcb47342d98af20ccca5ee1344";

    public static readonly List<Blueprint<BlueprintReference<LocatorsConsideration>>> All =
      new()
      {
          DLC5_SithhudLocatorConsideration,
          Overseer_Consideration_Locators,
          Sithhud_Consideration_Locator_Bite_Center,
          Sithhud_Consideration_Locator_Bite_Center_Double,
          Sithhud_Consideration_Locator_Bite_Left,
          Sithhud_Consideration_Locator_Bite_Left_Double,
          Sithhud_Consideration_Locator_Bite_Right,
          Sithhud_Consideration_Locator_Bite_Right_Double,
          Sithhud_Consideration_Locator_Breath_Center,
          Sithhud_Consideration_Locator_Breath_Center_Inhale,
          Sithhud_Consideration_Locator_Breath_Left,
          Sithhud_Consideration_Locator_Breath_Right,
      };
  }
}
