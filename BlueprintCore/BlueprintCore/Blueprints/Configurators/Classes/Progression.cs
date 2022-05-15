//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Configurator for <see cref="BlueprintProgression"/>.
  /// </summary>
  /// <inheritdoc/>
  public class ProgressionConfigurator
    : BaseProgressionConfigurator<BlueprintProgression, ProgressionConfigurator>
  {
    private ProgressionConfigurator(Blueprint<BlueprintProgression, BlueprintReference<BlueprintProgression>> blueprint) : base(blueprint) { }

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
    public static ProgressionConfigurator For(Blueprint<BlueprintProgression, BlueprintReference<BlueprintProgression>> blueprint)
    {
      return new ProgressionConfigurator(blueprint);
    }
    /// <summary>
    /// Creates a new blueprint and returns a new configurator to modify it.
    /// </summary>
    /// <remarks>
    /// <para>
    /// After creating a blueprint with this method you can use either name or GUID to reference the blueprint in BlueprintCore API calls.
    /// </para>
    /// <para>
    /// An implicit cast converts the string to <see cref="Utils.Blueprint{T, TRef}"/>, exposing the blueprint instance and its reference.
    /// </para>
    /// </remarks>
    public static ProgressionConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintProgression>(name, guid);
      return For(name);
    }

  }
}
