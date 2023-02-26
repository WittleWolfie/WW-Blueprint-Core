using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Persistence.Versioning;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.References
{
  /// <summary>
  /// Constant references to BlueprintUnitUpgrader blueprints
  /// </summary>
  ///
  /// <remarks>
  /// <p>The <c>All</c> field is a list with a reference to all blueprints.</p>
  /// <p>If you need a different reference type you can cast using <see cref="Blueprint{TRef}.Cast{T}"/></p>.
  /// </remarks>
  public static class UnitUpgraderRefs
  {
    public static readonly Blueprint<BlueprintReference<BlueprintUnitUpgrader>> AnimalCompanionMamonthUpgrader = "273450b33ade4cfdb052ca7f7da6bf34";
    public static readonly Blueprint<BlueprintReference<BlueprintUnitUpgrader>> PF_229479_RecreateAreshkagalOnLoad = "c048cb6cb12c4c578c312cf1ea5ebdce";
    public static readonly Blueprint<BlueprintReference<BlueprintUnitUpgrader>> PF_232061_RecreateUnitOnLoad = "7110698b88404d1180b63c167b5e583b";
    public static readonly Blueprint<BlueprintReference<BlueprintUnitUpgrader>> PF_273507_CohhDungeonRecreateUnitOnLoad = "30145387552d480bb44ec2e304e6dab4";
    public static readonly Blueprint<BlueprintReference<BlueprintUnitUpgrader>> PF_296210_RecreateSvendackOnLoad = "43a66ab394654e77b0a84be68af28179";
    public static readonly Blueprint<BlueprintReference<BlueprintUnitUpgrader>> PF_296345_RecreateHalDragonOnLoad = "aaf834dd2d2c4348a52de842606ecaad";
    public static readonly Blueprint<BlueprintReference<BlueprintUnitUpgrader>> PF_307745_RecreateUnitOnLoad = "9c4967eaf0e740b49ad19bdd9f6ac337";
    public static readonly Blueprint<BlueprintReference<BlueprintUnitUpgrader>> PF_339174_Aivu = "ab62d5469073449eaaa74f405d35bfc7";
    public static readonly Blueprint<BlueprintReference<BlueprintUnitUpgrader>> PF_340663_RecreateUnitOnLoad = "0a013e4bab2b456fbd9a265fd32907b2";
    public static readonly Blueprint<BlueprintReference<BlueprintUnitUpgrader>> PF_359232_RemoveBrokenSummonOnLoad = "2fc8c3f9bc904d8a82daa72d844dbed2";
    public static readonly Blueprint<BlueprintReference<BlueprintUnitUpgrader>> PF_365247_EvilArueshalae_Companion = "083640c167934d068db623f75474afe3";
    public static readonly Blueprint<BlueprintReference<BlueprintUnitUpgrader>> PF_383428_EyeOfTruthItem = "f448eb85a25743fb8ec43b17cc1aaf7c";
    public static readonly Blueprint<BlueprintReference<BlueprintUnitUpgrader>> PF_418068_RecreateVissariyRatimus = "761fd2604960453da5cbbd10e39d1abd";
    public static readonly Blueprint<BlueprintReference<BlueprintUnitUpgrader>> UpgradeUnitAlignment = "2a9ba91131b249fdb7b7c3dd93a57a1a";
    public static readonly Blueprint<BlueprintReference<BlueprintUnitUpgrader>> UpgradeUnitPrimarySecondaryWeapons = "9bb96c963f0f47f48e51aabb6c8ac4ff";
    public static readonly Blueprint<BlueprintReference<BlueprintUnitUpgrader>> UpgradeUnitRace = "bf93ee9fb7f34b17a9a25e50ada648e4";
    public static readonly Blueprint<BlueprintReference<BlueprintUnitUpgrader>> UpgradeUnitRobe2ST2DC = "0da99f59dbfc45b49864819a5ad0c3ec";

    public static readonly List<Blueprint<BlueprintReference<BlueprintUnitUpgrader>>> All =
      new()
      {
          AnimalCompanionMamonthUpgrader,
          PF_229479_RecreateAreshkagalOnLoad,
          PF_232061_RecreateUnitOnLoad,
          PF_273507_CohhDungeonRecreateUnitOnLoad,
          PF_296210_RecreateSvendackOnLoad,
          PF_296345_RecreateHalDragonOnLoad,
          PF_307745_RecreateUnitOnLoad,
          PF_339174_Aivu,
          PF_340663_RecreateUnitOnLoad,
          PF_359232_RemoveBrokenSummonOnLoad,
          PF_365247_EvilArueshalae_Companion,
          PF_383428_EyeOfTruthItem,
          PF_418068_RecreateVissariyRatimus,
          UpgradeUnitAlignment,
          UpgradeUnitPrimarySecondaryWeapons,
          UpgradeUnitRace,
          UpgradeUnitRobe2ST2DC,
      };
  }
}
