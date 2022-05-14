//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Configurator for <see cref="BlueprintTrap"/>.
  /// </summary>
  /// <inheritdoc/>
  public class TrapConfigurator
    : BaseTrapConfigurator<BlueprintTrap, TrapConfigurator>
  {
    private TrapConfigurator(Blueprint<BlueprintTrap, BlueprintReference<BlueprintTrap>> blueprint) : base(blueprint) { }

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
    public static TrapConfigurator For(Blueprint<BlueprintTrap, BlueprintReference<BlueprintTrap>> blueprint)
    {
      return new TrapConfigurator(blueprint);
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
    public static TrapConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintTrap>(name, guid);
      return For(name);
    }

  }
}
