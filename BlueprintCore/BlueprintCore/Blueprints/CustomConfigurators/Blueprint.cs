using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.CustomConfigurators
{
  /// <summary>
  /// Configurator for <see cref="BlueprintScriptableObject"/>.
  /// </summary>
  /// <inheritdoc/>
  public class BlueprintConfigurator<T>
    : BaseBlueprintConfigurator<T, BlueprintConfigurator<T>>
    where T : BlueprintScriptableObject, new()
  {
    private BlueprintConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

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
    public static BlueprintConfigurator<T> For(Blueprint<T, BlueprintReference<T>> blueprint)
    {
      return new BlueprintConfigurator<T>(blueprint);
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
    public static BlueprintConfigurator<T> New(string name, string guid)
    {
      BlueprintTool.Create<T>(name, guid);
      return For(name);
    }

  }
}
