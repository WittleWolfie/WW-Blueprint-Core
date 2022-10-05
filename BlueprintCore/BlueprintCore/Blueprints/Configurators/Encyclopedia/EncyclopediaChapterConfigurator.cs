//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Encyclopedia;
using System;

namespace BlueprintCore.Blueprints.Configurators.Encyclopedia
{
  /// <summary>
  /// Configurator for <see cref="BlueprintEncyclopediaChapter"/>.
  /// </summary>
  /// <inheritdoc/>
  public class EncyclopediaChapterConfigurator
    : BaseEncyclopediaChapterConfigurator<BlueprintEncyclopediaChapter, EncyclopediaChapterConfigurator>
  {
    private EncyclopediaChapterConfigurator(Blueprint<BlueprintReference<BlueprintEncyclopediaChapter>> blueprint) : base(blueprint) { }

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
    public static EncyclopediaChapterConfigurator For(Blueprint<BlueprintReference<BlueprintEncyclopediaChapter>> blueprint)
    {
      return new EncyclopediaChapterConfigurator(blueprint);
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
    /// </remarks>
    public static EncyclopediaChapterConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintEncyclopediaChapter>(name, guid);
      return For(name);
    }


    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public EncyclopediaChapterConfigurator CopyFrom(
      Blueprint<BlueprintReference<BlueprintEncyclopediaChapter>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    return Self;
    }
  }
}
