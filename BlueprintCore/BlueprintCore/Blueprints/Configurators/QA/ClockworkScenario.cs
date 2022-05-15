//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.QA.Clockwork;

namespace BlueprintCore.Blueprints.Configurators.QA
{
  /// <summary>
  /// Configurator for <see cref="BlueprintClockworkScenario"/>.
  /// </summary>
  /// <inheritdoc/>
  public class ClockworkScenarioConfigurator
    : BaseClockworkScenarioConfigurator<BlueprintClockworkScenario, ClockworkScenarioConfigurator>
  {
    private ClockworkScenarioConfigurator(Blueprint<BlueprintClockworkScenario, BlueprintReference<BlueprintClockworkScenario>> blueprint) : base(blueprint) { }

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
    public static ClockworkScenarioConfigurator For(Blueprint<BlueprintClockworkScenario, BlueprintReference<BlueprintClockworkScenario>> blueprint)
    {
      return new ClockworkScenarioConfigurator(blueprint);
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
    public static ClockworkScenarioConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintClockworkScenario>(name, guid);
      return For(name);
    }

  }
}
