//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;

namespace BlueprintCore.Blueprints.Configurators.Root
{
  /// <summary>
  /// Configurator for <see cref="FormationsRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public class FormationsRootConfigurator
    : BaseFormationsRootConfigurator<FormationsRoot, FormationsRootConfigurator>
  {
    private FormationsRootConfigurator(Blueprint<BlueprintReference<FormationsRoot>> blueprint) : base(blueprint) { }

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
    public static FormationsRootConfigurator For(Blueprint<BlueprintReference<FormationsRoot>> blueprint)
    {
      return new FormationsRootConfigurator(blueprint);
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
    public static FormationsRootConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<FormationsRoot>(name, guid);
      return For(name);
    }

  }
}
