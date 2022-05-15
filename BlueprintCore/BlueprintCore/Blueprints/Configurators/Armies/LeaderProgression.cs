//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Armies;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>
  /// Configurator for <see cref="BlueprintLeaderProgression"/>.
  /// </summary>
  /// <inheritdoc/>
  public class LeaderProgressionConfigurator
    : BaseLeaderProgressionConfigurator<BlueprintLeaderProgression, LeaderProgressionConfigurator>
  {
    private LeaderProgressionConfigurator(Blueprint<BlueprintLeaderProgression, BlueprintReference<BlueprintLeaderProgression>> blueprint) : base(blueprint) { }

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
    public static LeaderProgressionConfigurator For(Blueprint<BlueprintLeaderProgression, BlueprintReference<BlueprintLeaderProgression>> blueprint)
    {
      return new LeaderProgressionConfigurator(blueprint);
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
    public static LeaderProgressionConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintLeaderProgression>(name, guid);
      return For(name);
    }

  }
}
