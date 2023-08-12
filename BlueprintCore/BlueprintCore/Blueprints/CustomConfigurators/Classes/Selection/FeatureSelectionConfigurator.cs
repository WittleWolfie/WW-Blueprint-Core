using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Utility;
using System.Collections.Generic;

namespace BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection
{
  /// <summary>
  /// Configurator for <see cref="BlueprintFeatureSelection"/>.
  /// </summary>
  /// <inheritdoc/>
  public class FeatureSelectionConfigurator
    : BaseFeatureSelectionConfigurator<BlueprintFeatureSelection, FeatureSelectionConfigurator>
  {
    private FeatureSelectionConfigurator(Blueprint<BlueprintReference<BlueprintFeatureSelection>> blueprint) : base(blueprint) { }

    private bool SkipSelections = false;
    private bool IsTeamworkFeat = false;

    private string CavalierBuffGuid = string.Empty;

    private string VanguardBuffGuid = string.Empty;
    private string VanguardAbilityGuid = string.Empty;

    private string PackRagerBuffGuid = string.Empty;
    private string PackRagerAreaGuid = string.Empty;
    private string PackRagerAreaBuffGuid = string.Empty;
    private string PackRagerToggleBuffGuid = string.Empty;
    private string PackRagerToggleGuid = string.Empty;

    /// <summary>
    /// Returns a configurator to modify the specified blueprint.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use this to modify existing blueprints, such as blueprints from the base game.
    /// </para>
    /// <para>
    /// If you're using <see href="https://github.com/OwlcatOpenSource/WrathModificationTemplate">WrathModificationTemplate</see> blueprints defined in JSON already exist.
    /// </para>
    /// </remarks>
    /// <param name="updateSelections">If true, automatically adds the blueprint to feature selections with a matching group. Defaults to false.</param>
    public static FeatureSelectionConfigurator For(
      Blueprint<BlueprintReference<BlueprintFeatureSelection>> blueprint,
      bool updateSelections = false)
    {
      var configurator = new FeatureSelectionConfigurator(blueprint);
      return updateSelections ? configurator : configurator.SkipAddToSelections();
    }

    /// <summary>
    /// Creates a new blueprint and returns a new configurator to modify it.
    /// </summary>
    /// <remarks>
    /// <para>
    /// After creating a blueprint with this method you can use either name or GUID to reference the blueprint in BlueprintCore API calls.
    /// </para>
    /// <para>
    /// An implicit cast converts the string to <see cref="Utils.Blueprint{TRef}"/>, exposing the blueprint instance and its reference.
    /// </para>
    /// 
    /// <para>
    /// If you specify FeatureGroups it will automatically set <c>IsClassFeature</c> to <c>true</c> unless you include
    /// a group related to race or background:
    /// <list type="bullet">
    ///  <item>FeatureGroup.Racial</item>
    ///  <item>FeatureGroup.Trait</item>
    ///  <item>FeatureGroup.CreatureType</item>
    ///  <item>FeatureGroup.AasimarHeritage</item>
    ///  <item>FeatureGroup.TieflingHeritage</item>
    ///  <item>FeatureGroup.BackgroundSelection</item>
    ///  <item>FeatureGroup.DhampirHeritage</item>
    ///  <item>FeatureGroup.OreadHeritage</item>
    ///  <item>FeatureGroup.KitsuneHeritage</item>
    ///  <item>FeatureGroup.HalfOrcHeritage</item>
    /// </list>
    /// You can override this by calling <see cref="BaseFeatureConfigurator{T, TBuilder}.SetIsClassFeature(bool)"/>.
    /// </para>
    /// </remarks>
    /// 
    /// <param name="groups">
    /// When configured the feature is added to each <c>BlueprintFeatureSelection</c> with a matching <c>Group</c> or
    /// <c>Group2</c>.
    /// </param>
    public static FeatureSelectionConfigurator New(string name, string guid, params FeatureGroup[] groups)
    {
      BlueprintTool.Create<BlueprintFeatureSelection>(name, guid);
      var configurator = For(name);
      if (groups.Any())
      {
        configurator.SetGroups(groups);
        if (FeatureConfigurator.IsClassFeature(groups))
          configurator.SetIsClassFeature();
      }
      return configurator;
    }

    /// <summary>
    /// Call this to skip the automatic processing of <c>FeatureGroup</c> to add this feature to selections. Useful if
    /// you are using <c>BlueprintFeatureSelection</c> for a feat so the selected option can have
    /// <c>FeatureGroup.Feat</c> but only show under the selection.
    /// </summary>
    public FeatureSelectionConfigurator SkipAddToSelections()
    {
      SkipSelections = true;
      return this;
    }

    /// <summary>
    /// Populates all the necessary blueprints to make sure the teamwork feat is shared appropriately by various class
    /// and archetype abilities.
    /// </summary>
    /// 
    /// <remarks>
    /// <para>
    /// **IMPORTANT**: This generates blueprints using these GUIDs. That means they are a save dependency just like any
    /// other blueprint you create. Once you start using these you cannot stop, or you'll at least need to create
    /// dummy blueprints in their place.
    /// </para>
    /// 
    /// <para>
    /// If you only set <c>FeatureGroup.TeamworkFeat</c> Monster Tactician, Tactical Leader, Hunter Tactics, Sacred
    /// Huntsmaster Tactics, and Battle Prowess are configured automatically. This function is required to update
    /// Raging Tactician, Cavalier Tactics, and Vanguard Tactician which all require additional blueprints.
    /// </para>
    /// 
    /// <para>
    /// All created blueprints will inherit the name, description, and icon from this feature.
    /// </para>
    /// </remarks>
    /// 
    /// <param name="cavalierBuffGuid">Used to generate a buff which applies the feat for Cavalier Tactician.</param>
    /// 
    /// <param name="vanguardBuffGuid">Used to generate a buff which applies the feat for Vanguard Tactician.</param>
    /// <param name="vanguardAbilityGuid">Used to generate an ability which applies the vanguard buff.</param>
    /// 
    /// <param name="packRagerBuffGuid">Used to generate a buff which applies the feat for Raging Tactician.</param>
    /// <param name="packRagerAreaGuid">Used to generate an area which applies the pack rager buff.</param>
    /// <param name="packRagerAreaBuffGuid">Used to generate a buff which creates the pack rager area.</param>
    /// <param name="packRagerToggleBuffGuid">Used to generate a buff which turns on the pack rager area buff.</param>
    /// <param name="packRagerToggleGuid">Used to generate an ability which toggles the pack rager toggle buff.</param>
    public FeatureSelectionConfigurator AddAsTeamworkFeat(
      string cavalierBuffGuid,

      string vanguardBuffGuid,
      string vanguardAbilityGuid,

      string packRagerBuffGuid,
      string packRagerAreaGuid,
      string packRagerAreaBuffGuid,
      string packRagerToggleBuffGuid,
      string packRagerToggleGuid)
    {
      IsTeamworkFeat = true;

      CavalierBuffGuid = cavalierBuffGuid;

      VanguardBuffGuid = vanguardBuffGuid;
      VanguardAbilityGuid = vanguardAbilityGuid;

      PackRagerBuffGuid = packRagerBuffGuid;
      PackRagerAreaGuid = packRagerAreaGuid;
      PackRagerAreaBuffGuid = packRagerAreaBuffGuid;
      PackRagerToggleBuffGuid = packRagerToggleBuffGuid;
      PackRagerToggleGuid = packRagerToggleGuid;
      return this;
    }

    /// <summary>
    /// Adds the feature to specified ranger styles. Note that you only need to specify the minimum level for each
    /// category.
    /// </summary>
    public FeatureSelectionConfigurator AddToRangerStyles(params RangerStyle[] styles)
    {
      foreach (var style in styles)
      {
        switch (style)
        {
          case RangerStyle.Archery10:
            AdditionalFeatureSelections.Add(
              FeatureSelectionRefs.RangerStyleArcherySelection10.Cast<BlueprintFeatureSelectionReference>().Reference);
            goto case RangerStyle.Archery6;
          case RangerStyle.Archery6:
            AdditionalFeatureSelections.Add(
              FeatureSelectionRefs.RangerStyleArcherySelection6.Cast<BlueprintFeatureSelectionReference>().Reference);
            goto case RangerStyle.Archery2;
          case RangerStyle.Archery2:
            AdditionalFeatureSelections.Add(
              FeatureSelectionRefs.RangerStyleArcherySelection2.Cast<BlueprintFeatureSelectionReference>().Reference);
            break;

          case RangerStyle.Menacing10:
            AdditionalFeatureSelections.Add(
              FeatureSelectionRefs.RangerStyleMenacingSelection10.Cast<BlueprintFeatureSelectionReference>().Reference);
            goto case RangerStyle.Menacing6;
          case RangerStyle.Menacing6:
            AdditionalFeatureSelections.Add(
              FeatureSelectionRefs.RangerStyleMenacingSelection6.Cast<BlueprintFeatureSelectionReference>().Reference);
            goto case RangerStyle.Menacing2;
          case RangerStyle.Menacing2:
            AdditionalFeatureSelections.Add(
              FeatureSelectionRefs.RangerStyleMenacingSelection2.Cast<BlueprintFeatureSelectionReference>().Reference);
            break;

          case RangerStyle.Shield10:
            AdditionalFeatureSelections.Add(
              FeatureSelectionRefs.RangerStyleShieldSelection10.Cast<BlueprintFeatureSelectionReference>().Reference);
            goto case RangerStyle.Shield6;
          case RangerStyle.Shield6:
            AdditionalFeatureSelections.Add(
              FeatureSelectionRefs.RangerStyleShieldSelection6.Cast<BlueprintFeatureSelectionReference>().Reference);
            goto case RangerStyle.Shield2;
          case RangerStyle.Shield2:
            AdditionalFeatureSelections.Add(
              FeatureSelectionRefs.RangerStyleShieldSelection2.Cast<BlueprintFeatureSelectionReference>().Reference);
            break;

          case RangerStyle.TwoHanded10:
            AdditionalFeatureSelections.Add(
              FeatureSelectionRefs.RangerStyleTwoHandedSelection10.Cast<BlueprintFeatureSelectionReference>().Reference);
            goto case RangerStyle.TwoHanded6;
          case RangerStyle.TwoHanded6:
            AdditionalFeatureSelections.Add(
              FeatureSelectionRefs.RangerStyleTwoHandedSelection6.Cast<BlueprintFeatureSelectionReference>().Reference);
            goto case RangerStyle.TwoHanded2;
          case RangerStyle.TwoHanded2:
            AdditionalFeatureSelections.Add(
              FeatureSelectionRefs.RangerStyleTwoHandedSelection2.Cast<BlueprintFeatureSelectionReference>().Reference);
            break;

          case RangerStyle.TwoWeapon10:
            AdditionalFeatureSelections.Add(
              FeatureSelectionRefs.RangerStyleTwoWeaponSelection10.Cast<BlueprintFeatureSelectionReference>().Reference);
            goto case RangerStyle.TwoWeapon6;
          case RangerStyle.TwoWeapon6:
            AdditionalFeatureSelections.Add(
              FeatureSelectionRefs.RangerStyleTwoWeaponSelection6.Cast<BlueprintFeatureSelectionReference>().Reference);
            goto case RangerStyle.TwoWeapon2;
          case RangerStyle.TwoWeapon2:
            AdditionalFeatureSelections.Add(
              FeatureSelectionRefs.RangerStyleTwoWeaponSelection2.Cast<BlueprintFeatureSelectionReference>().Reference);
            break;
        }
      }
      return this;
    }

    /// <summary>
    /// Adds the feature to the specified selections, if the selections exist.
    /// </summary>
    /// 
    /// <remarks>
    /// <para>
    /// Most selections should be automatically populated based on the FeatureGroup values you specify in
    /// <see cref="New(string, string, FeatureGroup[])"/>.
    /// </para>
    /// 
    /// <para>
    /// Note that if a selection you provide here does not exist, it will not fail. Use this to add your feature to
    /// selections from other mods without a dependency: call
    /// <see cref="RootConfigurator{T, TBuilder}.Configure(bool)"/> setting <c>delayed</c> to <c>true</c>. Then when
    /// you call <see cref="RootConfigurator{T, TBuilder}.ConfigureDelayedBlueprints"/> those selections should exist
    /// if the required mod is installed.
    /// </para>
    /// </remarks>
    public FeatureSelectionConfigurator AddToFeatureSelection(params Blueprint<BlueprintFeatureSelectionReference>[] selections)
    {
      foreach (var selection in selections)
      {
        AdditionalFeatureSelections.Add(selection.Reference);
      }
      return this;
    }

    private readonly HashSet<BlueprintFeatureSelectionReference> AdditionalFeatureSelections = new();
    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();

      if (SkipSelections || !Configured)
        return;

      FeatureConfigurator.PopulateSelections(
        Blueprint,
        AdditionalFeatureSelections,
        IsTeamworkFeat,
        cavalierBuffGuid: CavalierBuffGuid,
        vanguardBuffGuid: VanguardBuffGuid,
        vanguardAbilityGuid: VanguardAbilityGuid,
        packRagerBuffGuid: PackRagerBuffGuid,
        packRagerAreaGuid: PackRagerAreaGuid,
        packRagerAreaBuffGuid: PackRagerAreaBuffGuid,
        packRagerToggleBuffGuid: PackRagerToggleBuffGuid,
        packRagerToggleGuid: PackRagerToggleGuid);
    }
  }
}
