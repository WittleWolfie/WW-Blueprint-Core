//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Flags;

namespace BlueprintCore.Blueprints.Configurators.Kingdom.Flags
{
  /// <summary>
  /// Configurator for <see cref="BlueprintKingdomMoraleFlag"/>.
  /// </summary>
  /// <inheritdoc/>
  public class KingdomMoraleFlagConfigurator
    : BaseKingdomMoraleFlagConfigurator<BlueprintKingdomMoraleFlag, KingdomMoraleFlagConfigurator>
  {
    private KingdomMoraleFlagConfigurator(Blueprint<BlueprintKingdomMoraleFlag, BlueprintReference<BlueprintKingdomMoraleFlag>> blueprint) : base(blueprint) { }

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
    public static KingdomMoraleFlagConfigurator For(Blueprint<BlueprintKingdomMoraleFlag, BlueprintReference<BlueprintKingdomMoraleFlag>> blueprint)
    {
      return new KingdomMoraleFlagConfigurator(blueprint);
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
    public static KingdomMoraleFlagConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintKingdomMoraleFlag>(name, guid);
      return For(name);
    }

  }
}
