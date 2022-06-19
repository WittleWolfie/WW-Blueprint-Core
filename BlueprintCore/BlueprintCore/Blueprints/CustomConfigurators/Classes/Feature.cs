//using BlueprintCore.Blueprints.Configurators.Classes;
//using BlueprintCore.Utils;
//using Kingmaker.Blueprints;
//using Kingmaker.Blueprints.Classes;
//using System.Collections.Generic;

//namespace BlueprintCore.Blueprints.CustomConfigurators.Classes
//{
//  /// <summary>
//  /// Configurator for <see cref="BlueprintFeature"/>.
//  /// </summary>
//  /// <inheritdoc/>
//  public class FeatureConfigurator
//    : BaseFeatureConfigurator<BlueprintFeature, FeatureConfigurator>
//  {
//    private FeatureConfigurator(Blueprint<BlueprintReference<BlueprintFeature>> blueprint) : base(blueprint) { }

//    /// <summary>
//    /// Returns a configurator to modify the specified blueprint.
//    /// </summary>
//    /// <remarks>
//    /// <para>
//    /// Use this to modify existing blueprints, such as blueprints from the base game.
//    /// </para>
//    /// <para>
//    /// If you're using <see href="https://github.com/OwlcatOpenSource/WrathModificationTemplate">WrathModificationTemplate</see> blueprints defined in JSON already exist.
//    /// </para>
//    /// </remarks>
//    public static FeatureConfigurator For(Blueprint<BlueprintReference<BlueprintFeature>> blueprint)
//    {
//      return new FeatureConfigurator(blueprint);
//    }

//    /// <summary>
//    /// Creates a new blueprint and returns a new configurator to modify it.
//    /// </summary>
//    /// 
//    /// <remarks>
//    /// <para>
//    /// After creating a blueprint with this method you can use either name or GUID to reference the blueprint in BlueprintCore API calls.
//    /// </para>
//    /// 
//    /// <para>
//    /// An implicit cast converts the string to <see cref="Utils.Blueprint{TRef}"/>, exposing the blueprint instance and its reference.
//    /// </para>
//    /// </remarks>
//    public static FeatureConfigurator New(string name, string guid)
//    {
//      BlueprintTool.Create<BlueprintFeature>(name, guid);
//      return For(name);
//    }

//    /// <summary>
//    /// Creates a new feat blueprint and returns a new configurator to modify it.
//    /// </summary>
//    /// 
//    /// <remarks>
//    /// <para>
//    /// When <c>Configure()</c> is called this blueprint will be added to 
//    /// </para>
//    /// </remarks>
//    public static FeatureConfigurator NewFeat(string name, string guid)
//    {
//      BlueprintTool.Create<BlueprintFeature>(name, guid);
//      var configurator = For(name);
//      configurator.FeatureTypes.Add(FeatureType.Feat);
//      return configurator;
//    }

//    // TODO: What's the API supposed to look like?

//    // FeatureConfigurator.NewFeat().AddTo(Selections.RogueTalents, Selections.MetamagicFeats)??

//    // Alternatively it seems like I could just define my own associations between FeatureGroup values and Selections.
//    // That way everything could be based on Groups.
//    //
//    // The AddTo() function is probably a good idea anyways.

//    private enum FeatureType
//    {
//      Feat,
//      MetamagicFeat,
//      RogueTalent,
//      ArcanistExploit,
//      MagusArcana,
//      MythicAbility,
//      MythicFeat,
//    }
//    private List<FeatureType> FeatureTypes = new();
//  }
//}
