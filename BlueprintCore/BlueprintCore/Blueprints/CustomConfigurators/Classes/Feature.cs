using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;

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
    /// <para>
    /// After creating a blueprint with this method you can use either name or GUID to reference the blueprint in BlueprintCore API calls.
    /// </para>
    /// 
    /// <para>
    /// An implicit cast converts the string to <see cref="Utils.Blueprint{TRef}"/>, exposing the blueprint instance and its reference.
    /// </para>
    /// </remarks>
    /// 
    /// <param name="groups">
    /// A list of FeatureGroups. Each group provided adds the feature to the appropriate BlueprintFeatureSelections.
    /// For a full list of selections see TODO.
    /// </param>
    public static FeatureConfigurator New(string name, string guid, params FeatureGroup[] groups)
    {
      BlueprintTool.Create<BlueprintFeature>(name, guid);
      return For(name).SetGroups(groups);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    }
  }
}
