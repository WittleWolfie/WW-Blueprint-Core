//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Armors;

namespace BlueprintCore.Blueprints.Configurators.Items.Armors
{
  /// <summary>
  /// Configurator for <see cref="BlueprintShieldType"/>.
  /// </summary>
  /// <inheritdoc/>
  public class ShieldTypeConfigurator
    : BaseShieldTypeConfigurator<BlueprintShieldType, ShieldTypeConfigurator>
  {
    private ShieldTypeConfigurator(Blueprint<BlueprintShieldType, BlueprintReference<BlueprintShieldType>> blueprint) : base(blueprint) { }

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
    public static ShieldTypeConfigurator For(Blueprint<BlueprintShieldType, BlueprintReference<BlueprintShieldType>> blueprint)
    {
      return new ShieldTypeConfigurator(blueprint);
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
    public static ShieldTypeConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintShieldType>(name, guid);
      return For(name);
    }

  }
}
