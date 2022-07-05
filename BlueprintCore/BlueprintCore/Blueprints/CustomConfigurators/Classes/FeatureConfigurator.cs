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

    private static readonly IEnumerable<BlueprintFeatureSelection> FeatureSelections =
      FeatureSelectionRefs.All.Select(selectionRef => selectionRef.Reference.Get());
    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();

      foreach (var selection in FeatureSelections)
      {
        if (Blueprint.HasGroup(selection.Group) || Blueprint.HasGroup(selection.Group2))
        {
          FeatureSelectionConfigurator.For(selection).AddToAllFeatures(Blueprint).Configure();
        }
      }
    }
  }
}
