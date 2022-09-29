//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Configurator for <see cref="BlueprintPhotoModeRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public class PhotoModeRootConfigurator
    : BasePhotoModeRootConfigurator<BlueprintPhotoModeRoot, PhotoModeRootConfigurator>
  {
    private PhotoModeRootConfigurator(Blueprint<BlueprintReference<BlueprintPhotoModeRoot>> blueprint) : base(blueprint) { }

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
    public static PhotoModeRootConfigurator For(Blueprint<BlueprintReference<BlueprintPhotoModeRoot>> blueprint)
    {
      return new PhotoModeRootConfigurator(blueprint);
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
    public static PhotoModeRootConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintPhotoModeRoot>(name, guid);
      return For(name);
    }

  }
}
