using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Controllers.Rest.Cooking;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintCookingRecipe blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class CookingRecipeRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintCookingRecipe>> AcornPieRecipe = "fe4c7fac8007fdc4698ff6c0d56e78ca";
    public static readonly Blueprint<BlueprintReference<BlueprintCookingRecipe>> BlazingParfaitRecipe = "00208bad7bf11584e984868c1cb058dc";
    public static readonly Blueprint<BlueprintReference<BlueprintCookingRecipe>> CheeseCrostataRecipe = "876eb975c4da09943a3508b6738bd042";
    public static readonly Blueprint<BlueprintReference<BlueprintCookingRecipe>> ClearingMindTeaRecipe = "4e16f6b62b084dde9edb5c0396629270";
    public static readonly Blueprint<BlueprintReference<BlueprintCookingRecipe>> ConflagrantTacoRecipe = "286a134f31538ee409befc8af4d48f87";
    public static readonly Blueprint<BlueprintReference<BlueprintCookingRecipe>> CremeSoupWithaSnoutRecipe = "fa519e96f6c86384a8701ccfdc74c66a";
    public static readonly Blueprint<BlueprintReference<BlueprintCookingRecipe>> CursePilaffRecipe = "2a90bf62e8f07f54bbdca0b925eebe44";
    public static readonly Blueprint<BlueprintReference<BlueprintCookingRecipe>> DefaultRecipe = "bb22451633451b842a5dd692851be27e";
    public static readonly Blueprint<BlueprintReference<BlueprintCookingRecipe>> DemonSlayerSoupRecipe = "f58df7e3cb1b7f84095926c44e6321d6";
    public static readonly Blueprint<BlueprintReference<BlueprintCookingRecipe>> DLC2_SpicyPastryRecipe = "a2143ca289c3493c8c32a25bd3ee0637";
    public static readonly Blueprint<BlueprintReference<BlueprintCookingRecipe>> FishOnaStickRecipe = "0eea67c01740861419c52c92696c3bc4";
    public static readonly Blueprint<BlueprintReference<BlueprintCookingRecipe>> FreshJogurtRecipe = "0432eab8a2df43149673a7d43afe6956";
    public static readonly Blueprint<BlueprintReference<BlueprintCookingRecipe>> GlowingCroissantRecipe = "deb7f1dcf1440044e96ca22197c9df73";
    public static readonly Blueprint<BlueprintReference<BlueprintCookingRecipe>> GodspeedSaladRecipe = "4d80045a70ccefa4a968293461e7d6f7";
    public static readonly Blueprint<BlueprintReference<BlueprintCookingRecipe>> LuckyHandSandwitchRecipe = "69bbe64572a9e4a4b943dcb7c25db7e5";
    public static readonly Blueprint<BlueprintReference<BlueprintCookingRecipe>> MidnightSoupRecipe = "d573917e32b6fa640abeb2807f73c8ec";
    public static readonly Blueprint<BlueprintReference<BlueprintCookingRecipe>> MonsterCasseroleRecipe = "a4aa3487b7f33d54995ff76c7b37f2cb";
    public static readonly Blueprint<BlueprintReference<BlueprintCookingRecipe>> MossPottageRecipe = "52c031b5da663a248a5325b27c10d92f";
    public static readonly Blueprint<BlueprintReference<BlueprintCookingRecipe>> MulledWineRecipe = "81238fbe49a8a03448b1c51c67be0569";
    public static readonly Blueprint<BlueprintReference<BlueprintCookingRecipe>> OnionSoupRecipe = "c7c4bef0711206b4f84fa89cef33d9d5";
    public static readonly Blueprint<BlueprintReference<BlueprintCookingRecipe>> ScreamingOmeletRecipe = "2a2e2616eb49cbf43a57029872931a4c";
    public static readonly Blueprint<BlueprintReference<BlueprintCookingRecipe>> SeasonedWingsAndThighsRecipe = "ccb3a2898f95aac4080cb998e321f9b1";
    public static readonly Blueprint<BlueprintReference<BlueprintCookingRecipe>> SkullberryPieRecipe = "b9ec9f2751297694cad93582690df397";
    public static readonly Blueprint<BlueprintReference<BlueprintCookingRecipe>> SourGutsBrothRecipe = "0498fd2af3d0f514e9d1cd2275739aca";
    public static readonly Blueprint<BlueprintReference<BlueprintCookingRecipe>> SpicyPastryRecipe = "197af78f957512844b1dfc9d1cf5d172";
    public static readonly Blueprint<BlueprintReference<BlueprintCookingRecipe>> Test_Bebilith_Blueprint_Cooking_Recipe = "293bc27a21f5e7a47b064898863aae78";

    public static readonly List<Blueprint<BlueprintReference<BlueprintCookingRecipe>>> All =
      new()
      {
          AcornPieRecipe,
          BlazingParfaitRecipe,
          CheeseCrostataRecipe,
          ClearingMindTeaRecipe,
          ConflagrantTacoRecipe,
          CremeSoupWithaSnoutRecipe,
          CursePilaffRecipe,
          DefaultRecipe,
          DemonSlayerSoupRecipe,
          DLC2_SpicyPastryRecipe,
          FishOnaStickRecipe,
          FreshJogurtRecipe,
          GlowingCroissantRecipe,
          GodspeedSaladRecipe,
          LuckyHandSandwitchRecipe,
          MidnightSoupRecipe,
          MonsterCasseroleRecipe,
          MossPottageRecipe,
          MulledWineRecipe,
          OnionSoupRecipe,
          ScreamingOmeletRecipe,
          SeasonedWingsAndThighsRecipe,
          SkullberryPieRecipe,
          SourGutsBrothRecipe,
          SpicyPastryRecipe,
          Test_Bebilith_Blueprint_Cooking_Recipe,
      };
  }
}
