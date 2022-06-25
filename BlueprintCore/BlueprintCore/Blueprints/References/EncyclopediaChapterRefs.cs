using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Encyclopedia;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintEncyclopediaChapter blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class EncyclopediaChapterRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintEncyclopediaChapter>> Basics = "93a70d1e4968f0145a3fb24b21d71aff";
    public static readonly Blueprint<BlueprintReference<BlueprintEncyclopediaChapter>> Character_Creation = "235f1ac1f7af35e4aa1e4843b34706ca";
    public static readonly Blueprint<BlueprintReference<BlueprintEncyclopediaChapter>> Combat_Rules = "fd6d5141456a7714fb2f049cd9d97bd6";
    public static readonly Blueprint<BlueprintReference<BlueprintEncyclopediaChapter>> Common_Terms = "046bbfd3aa02c3443bc7cc6324a78136";
    public static readonly Blueprint<BlueprintReference<BlueprintEncyclopediaChapter>> Equipment = "144b264b2bfe4952a40a0167c42b3cc5";
    public static readonly Blueprint<BlueprintReference<BlueprintEncyclopediaChapter>> Magic = "0c797e39821fd2b4d8c227f7144e216f";
    public static readonly Blueprint<BlueprintReference<BlueprintEncyclopediaChapter>> Tutorial = "354db6c4a6ae477d886f713e378b3cba";
    public static readonly Blueprint<BlueprintReference<BlueprintEncyclopediaChapter>> Tutorial_Crusade = "e3fb9d6db74c4516aa054ffd57895199";

    public static readonly List<Blueprint<BlueprintReference<BlueprintEncyclopediaChapter>>> All =
      new()
      {
          Basics,
          Character_Creation,
          Combat_Rules,
          Common_Terms,
          Equipment,
          Magic,
          Tutorial,
          Tutorial_Crusade,
      };
  }
}
