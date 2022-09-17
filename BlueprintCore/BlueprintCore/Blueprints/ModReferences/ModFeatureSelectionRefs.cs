using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.ModReferences
{
  internal class ModFeatureSelectionRefs
  {
    // **** Microscopic Content Expansion **** //
    public static readonly Blueprint<BlueprintFeatureSelectionReference> MonkCapstoneSelection = "adaa20fd-8c54-4c25-8768-053767609a1b";
    public static readonly Blueprint<BlueprintFeatureSelectionReference> MonkQMCapstoneSelection = "ca4d0a29-fc77-48e0-849c-f582676ca2d1";
    public static readonly Blueprint<BlueprintFeatureSelectionReference> MonkSenseiCapstoneSelection = "2c5d5af6-097d-4d0d-9db0-dc7db26bf746";
    public static readonly Blueprint<BlueprintFeatureSelectionReference> MonkSoheiCapstoneSelection = "dae67374-9ca8-4518-91fa-f0ca235d8f52";
    public static readonly Blueprint<BlueprintFeatureSelectionReference> MonkZenArcherCapstoneSelection = "1e8d098a-ebe7-4206-bc03-82c2821ce111";
    public static readonly Blueprint<BlueprintFeatureSelectionReference> AntipaladinCrueltySelection = "402fccae-3c21-47e7-8da4-ff9f6f061461";
    public static readonly Blueprint<BlueprintFeatureSelectionReference> AntipaladinFiendishBoonSelection = "4dd04135-8518-45d1-857b-6ac5faaf4332";
    public static readonly Blueprint<BlueprintFeatureSelectionReference> AntipaladinServantSelection = "03a4fe94-52e6-47dc-bddf-cc705875e52f";
    public static readonly Blueprint<BlueprintFeatureSelectionReference> IronTyrantBonusFeatSelection = "af08a081-2da5-46e3-b260-e3ae482a5540";
    public static readonly Blueprint<BlueprintFeatureSelectionReference> AntipaladinUnsanctionedKnowledgeSelection1 = "348564ad-3de2-4dc0-9c06-03523fdbd0a4";
    public static readonly Blueprint<BlueprintFeatureSelectionReference> AntipaladinUnsanctionedKnowledgeSelection2 = "e6aab5ca-5f5a-4678-8e53-102f35b3946a";
    public static readonly Blueprint<BlueprintFeatureSelectionReference> AntipaladinUnsanctionedKnowledgeSelection3 = "39e756e2-d76e-485b-928c-774fb654c320";
    public static readonly Blueprint<BlueprintFeatureSelectionReference> AntipaladinUnsanctionedKnowledgeSelection4 = "7a36edf7-0720-43d6-8cbe-ddeb0d13c6db";
    public static readonly Blueprint<BlueprintFeatureSelectionReference> TyrantDiabolicBoonSelection = "868f4200-e7e9-4aa7-8623-c42aec01a2be";
    // *************************************** //

    public static readonly List<Blueprint<BlueprintFeatureSelectionReference>> All =
      new()
      {
        // **** Microscopic Content Expansion **** //
        MonkCapstoneSelection,
        MonkQMCapstoneSelection,
        MonkSenseiCapstoneSelection,
        MonkSoheiCapstoneSelection,
        MonkZenArcherCapstoneSelection,
        AntipaladinCrueltySelection,
        AntipaladinFiendishBoonSelection,
        AntipaladinServantSelection,
        IronTyrantBonusFeatSelection,
        AntipaladinUnsanctionedKnowledgeSelection1,
        AntipaladinUnsanctionedKnowledgeSelection2,
        AntipaladinUnsanctionedKnowledgeSelection3,
        AntipaladinUnsanctionedKnowledgeSelection4,
        TyrantDiabolicBoonSelection,
        // *************************************** //


      };
  }
}
