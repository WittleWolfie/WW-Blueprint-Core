using BlueprintCore.Blueprints.Configurators.Classes.Spells;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.CustomConfigurators.Classes.Spells
{
  /// <summary>
  /// Configurator for <see cref="BlueprintSpellList"/>.
  /// </summary>
  /// <inheritdoc/>
  public class SpellListConfigurator
    : BaseSpellListConfigurator<BlueprintSpellList, SpellListConfigurator>
  {
    private SpellListConfigurator(Blueprint<BlueprintReference<BlueprintSpellList>> blueprint) : base(blueprint) { }

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
    public static SpellListConfigurator For(Blueprint<BlueprintReference<BlueprintSpellList>> blueprint)
    {
      return new SpellListConfigurator(blueprint);
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
    public static SpellListConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintSpellList>(name, guid);
      return For(name);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();

      foreach (var spells in Blueprint.SpellsByLevel)
        spells.m_SpellsFiltered?.Clear();
    }
  }
}
