//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Configurator for <see cref="BlueprintClassAdditionalVisualSettings"/>.
  /// </summary>
  /// <inheritdoc/>
  public class ClassAdditionalVisualSettingsConfigurator
    : BaseClassAdditionalVisualSettingsConfigurator<BlueprintClassAdditionalVisualSettings, ClassAdditionalVisualSettingsConfigurator>
  {
    private ClassAdditionalVisualSettingsConfigurator(Blueprint<BlueprintClassAdditionalVisualSettings, BlueprintReference<BlueprintClassAdditionalVisualSettings>> blueprint) : base(blueprint) { }

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
    public static ClassAdditionalVisualSettingsConfigurator For(Blueprint<BlueprintClassAdditionalVisualSettings, BlueprintReference<BlueprintClassAdditionalVisualSettings>> blueprint)
    {
      return new ClassAdditionalVisualSettingsConfigurator(blueprint);
    }
    /// <summary>
    /// Creates a new blueprint and returns a new configurator to modify it.
    /// </summary>
    /// <remarks>
    /// <para>
    /// After creating a blueprint with this method you can use either name or GUID to reference the blueprint in BlueprintCore API calls.
    /// </para>
    /// <para>
    /// An implicit cast converts the string to <see cref="Blueprint<,>"/>, exposing the blueprint instance and its reference.
    /// </para>
    /// </remarks>
    public static ClassAdditionalVisualSettingsConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintClassAdditionalVisualSettings>(name, guid);
      return For(name);
    }

  }
}
