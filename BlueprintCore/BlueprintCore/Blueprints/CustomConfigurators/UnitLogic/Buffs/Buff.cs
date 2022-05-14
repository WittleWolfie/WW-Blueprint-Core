using BlueprintCore.Blueprints.Configurators.UnitLogic.Buffs;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;

namespace BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs
{
  /// <summary>
  /// Configurator for <see cref="BlueprintBuff"/>.
  /// </summary>
  /// <inheritdoc/>
  public class BuffConfigurator : BaseBuffConfigurator<BlueprintBuff, BuffConfigurator>
  {
    private BuffConfigurator(Blueprint<BlueprintBuff, BlueprintReference<BlueprintBuff>> blueprint) : base(blueprint) { }

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
    public static BuffConfigurator For(Blueprint<BlueprintBuff, BlueprintReference<BlueprintBuff>> blueprint)
    {
      return new BuffConfigurator(blueprint);
    }

    /// <summary>
    /// Creates a new blueprint and returns a new configurator to modify it.
    /// </summary>
    /// <remarks>
    /// <para>
    /// After creating a blueprint with this method you can use either name or GUID to reference the blueprint in BlueprintCore API calls.
    /// </para>
    /// <para>
    /// An implicit cast converts the string to <see cref="Blueprint{T, TRef}"/>, exposing the blueprint instance and its reference.
    /// </para>
    /// </remarks>
    public static BuffConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintBuff>(name, guid);
      return For(name);
    }

    /// <inheritdoc cref="BaseBuffConfigurator{T, TBuilder}.SetRanks(int)"/>
    public new BuffConfigurator SetRanks(int ranks)
    {
      base.SetRanks(ranks);
      return OnConfigureInternal(bp => bp.Stacking = StackingType.Rank);
    }
  }
}