//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Configurator for <see cref="BlueprintRomanceCounter"/>.
  /// </summary>
  /// <inheritdoc/>
  public class RomanceCounterConfigurator
    : BaseRomanceCounterConfigurator<BlueprintRomanceCounter, RomanceCounterConfigurator>
  {
    private RomanceCounterConfigurator(Blueprint<BlueprintRomanceCounter, BlueprintReference<BlueprintRomanceCounter>> blueprint) : base(blueprint) { }

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
    public static RomanceCounterConfigurator For(Blueprint<BlueprintRomanceCounter, BlueprintReference<BlueprintRomanceCounter>> blueprint)
    {
      return new RomanceCounterConfigurator(blueprint);
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
    public static RomanceCounterConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintRomanceCounter>(name, guid);
      return For(name);
    }

  }
}
