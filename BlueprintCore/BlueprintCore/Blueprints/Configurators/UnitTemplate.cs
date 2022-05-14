//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Configurator for <see cref="BlueprintUnitTemplate"/>.
  /// </summary>
  /// <inheritdoc/>
  public class UnitTemplateConfigurator
    : BaseUnitTemplateConfigurator<BlueprintUnitTemplate, UnitTemplateConfigurator>
  {
    private UnitTemplateConfigurator(Blueprint<BlueprintUnitTemplate, BlueprintReference<BlueprintUnitTemplate>> blueprint) : base(blueprint) { }

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
    public static UnitTemplateConfigurator For(Blueprint<BlueprintUnitTemplate, BlueprintReference<BlueprintUnitTemplate>> blueprint)
    {
      return new UnitTemplateConfigurator(blueprint);
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
    public static UnitTemplateConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintUnitTemplate>(name, guid);
      return For(name);
    }

  }
}
