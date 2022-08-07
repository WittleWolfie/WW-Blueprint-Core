using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.CustomConfigurators.Classes
{
  /// <summary>
  /// Configurator for <see cref="BlueprintFeature"/>.
  /// </summary>
  /// <inheritdoc/>
  public class FeatureConfigurator
    : BaseFeatureConfigurator<BlueprintFeature, FeatureConfigurator>
  {
    private FeatureConfigurator(Blueprint<BlueprintReference<BlueprintFeature>> blueprint) : base(blueprint) { }

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
    public static FeatureConfigurator For(Blueprint<BlueprintReference<BlueprintFeature>> blueprint)
    {
      return new FeatureConfigurator(blueprint);
    }

    /// <summary>
    /// Creates a new blueprint and returns a new configurator to modify it.
    /// </summary>
    /// 
    /// <remarks>
    /// <example>
    /// Use <paramref name="groups"/> to specify which <c>BlueprintFeatureSelection</c> lists should contain the
    /// feature. In the following example the feature is included in
    /// <see cref="FeatureSelectionRefs.BasicFeatSelection"/> as well as any selection referencing <c>CombatFeat</c>
    /// e.g. <see cref="FeatureSelectionRefs.FighterFeatSelection"/>.
    /// 
    /// <code>
    /// FeatureConfigurator.New(CombatFeatName, CombatFeatGuid, FeatureGroup.Feat, FeatureGroup.CombatFeat)
    ///   .Configure();
    /// </code>
    /// </example>
    /// 
    /// <para>
    /// If FeatureGroup.Feat is specified then <see cref="BlueprintFeature.IsClassFeature"/> is set to true.
    /// </para>
    /// </remarks>
    /// 
    /// <param name="groups">
    /// When configured the feature is added to each <c>BlueprintFeatureSelection</c> with a matching <c>Group</c> or
    /// <c>Group2</c>.
    /// </param>
    public static FeatureConfigurator New(string name, string guid, params FeatureGroup[] groups)
    {
      BlueprintTool.Create<BlueprintFeature>(name, guid);
      var configurator = For(name).SetGroups(groups);
      if (groups.Contains(FeatureGroup.Feat))
      {
        configurator.SetIsClassFeature();
      }
      return configurator;
    }

    /// <summary>
    /// Use with <see cref="AddToRangerStyleFeats"/> to add to the appropriate ranger style feat selection. 
    /// </summary>
    /// 
    /// <remarks>
    /// The ending number indicates the level it becomes available. It is automatically added to higher level lists.
    /// e.g. <c>AddToRangerStyles(RangerStyle.Archery2)</c> adds the feature to RangerStyleArcherySelection2,
    /// RangerStyleArcherySelection6, and RangerStyleArcherySelection10.
    /// </remarks>
    public enum RangerStyle
    {
      Archery2,
      Archery6,
      Archery10,

      Menacing2,
      Menacing6,
      Menacing10,

      Shield2,
      Shield6,
      Shield10,

      TwoHanded2,
      TwoHanded6,
      TwoHanded10,

      TwoWeapon2,
      TwoWeapon6,
      TwoWeapon10,
    }

    /// <summary>
    /// Adds the feature to specified ranger styles. Note that you only need to specify the minimum level for each
    /// category.
    /// </summary>
    public FeatureConfigurator AddToRangerStyles(params RangerStyle[] styles)
    {
      foreach (var style in styles)
      {
        switch (style)
        {
          case RangerStyle.Archery10:
            AdditionalFeatureSelections.Add(FeatureSelectionRefs.RangerStyleArcherySelection10.Reference.Get());
            goto case RangerStyle.Archery6;
          case RangerStyle.Archery6:
            AdditionalFeatureSelections.Add(FeatureSelectionRefs.RangerStyleArcherySelection6.Reference.Get());
            goto case RangerStyle.Archery2;
          case RangerStyle.Archery2:
            AdditionalFeatureSelections.Add(FeatureSelectionRefs.RangerStyleArcherySelection2.Reference.Get());
            break;

          case RangerStyle.Menacing10:
            AdditionalFeatureSelections.Add(FeatureSelectionRefs.RangerStyleMenacingSelection10.Reference.Get());
            goto case RangerStyle.Menacing6;
          case RangerStyle.Menacing6:
            AdditionalFeatureSelections.Add(FeatureSelectionRefs.RangerStyleMenacingSelection6.Reference.Get());
            goto case RangerStyle.Menacing2;
          case RangerStyle.Menacing2:
            AdditionalFeatureSelections.Add(FeatureSelectionRefs.RangerStyleMenacingSelection2.Reference.Get());
            break;

          case RangerStyle.Shield10:
            AdditionalFeatureSelections.Add(FeatureSelectionRefs.RangerStyleShieldSelection10.Reference.Get());
            goto case RangerStyle.Shield6;
          case RangerStyle.Shield6:
            AdditionalFeatureSelections.Add(FeatureSelectionRefs.RangerStyleShieldSelection6.Reference.Get());
            goto case RangerStyle.Shield2;
          case RangerStyle.Shield2:
            AdditionalFeatureSelections.Add(FeatureSelectionRefs.RangerStyleShieldSelection2.Reference.Get());
            break;

          case RangerStyle.TwoHanded10:
            AdditionalFeatureSelections.Add(FeatureSelectionRefs.RangerStyleTwoHandedSelection10.Reference.Get());
            goto case RangerStyle.TwoHanded6;
          case RangerStyle.TwoHanded6:
            AdditionalFeatureSelections.Add(FeatureSelectionRefs.RangerStyleTwoHandedSelection6.Reference.Get());
            goto case RangerStyle.TwoHanded2;
          case RangerStyle.TwoHanded2:
            AdditionalFeatureSelections.Add(FeatureSelectionRefs.RangerStyleTwoHandedSelection2.Reference.Get());
            break;

          case RangerStyle.TwoWeapon10:
            AdditionalFeatureSelections.Add(FeatureSelectionRefs.RangerStyleTwoWeaponSelection10.Reference.Get());
            goto case RangerStyle.TwoWeapon6;
          case RangerStyle.TwoWeapon6:
            AdditionalFeatureSelections.Add(FeatureSelectionRefs.RangerStyleTwoWeaponSelection6.Reference.Get());
            goto case RangerStyle.TwoWeapon2;
          case RangerStyle.TwoWeapon2:
            AdditionalFeatureSelections.Add(FeatureSelectionRefs.RangerStyleTwoWeaponSelection2.Reference.Get());
            break;
        }
      }
      return this;
    }

    /// <summary>
    /// Adds the feature to the specified selections. 
    /// </summary>
    /// 
    /// <remarks>
    /// Most selections should be automatically populated based on the FeatureGroup values you specify in
    /// <see cref="New(string, string, FeatureGroup[])"/>.
    /// </remarks>
    public FeatureConfigurator AddToFeatureSelection(params Blueprint<BlueprintFeatureSelectionReference>[] selections)
    {
      foreach (var selection in selections)
      {
        AdditionalFeatureSelections.Add(selection.Reference.Get());
      }
      return this;
    }

    private static readonly HashSet<BlueprintFeatureSelection> AdditionalFeatureSelections = new();
    private static readonly IEnumerable<BlueprintFeatureSelection> FeatureSelections =
      FeatureSelectionRefs.All.Select(selectionRef => selectionRef.Reference.Get());
    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();

      foreach (var selection in FeatureSelections.Except(AdditionalFeatureSelections))
      {
        if (Blueprint.HasGroup(selection.Group) || Blueprint.HasGroup(selection.Group2))
        {
          FeatureSelectionConfigurator.For(selection).AddToAllFeatures(Blueprint).Configure();
        }
      }

      foreach (var selection in AdditionalFeatureSelections)
      {
        FeatureSelectionConfigurator.For(selection).AddToAllFeatures(Blueprint).Configure();
      }
    }
  }
}
