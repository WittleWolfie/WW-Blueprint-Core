using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using BlueprintCore.Blueprints.Configurators.UnitLogic.Abilities;
using Kingmaker.Utility;

namespace BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities
{
  /// <summary>
  /// Configurator for <see cref="BlueprintAbility"/>.
  /// </summary>
  /// <inheritdoc/>
  public class AbilityConfigurator : BaseAbilityConfigurator<BlueprintAbility, AbilityConfigurator>
  {
    private AbilityConfigurator(Blueprint<BlueprintReference<BlueprintAbility>> blueprint) : base(blueprint) { }

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
    public static AbilityConfigurator For(Blueprint<BlueprintReference<BlueprintAbility>> blueprint)
    {
      return new AbilityConfigurator(blueprint);
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
    public static AbilityConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintAbility>(name, guid);
      return For(name);
    }

    /// <inheritdoc cref="BaseAbilityConfigurator{T, TBuilder}.SetCustomRange(Feet)"/>
    /// 
    /// <remarks>
    /// Sets <see cref="BlueprintAbility.Range"/> to AbilityRange.Custom.
    /// </remarks>
    public new AbilityConfigurator SetCustomRange(Feet rangeInFeet)
    {
      base.SetCustomRange(rangeInFeet);
      return OnConfigureInternal(bp => bp.Range = AbilityRange.Custom);
    }

    /// <summary>
    /// Convenience function to set all targeting behaviors:
    /// <see cref="BlueprintAbility.CanTargetPoint"/>,
    /// <see cref="BlueprintAbility.CanTargetEnemies"/>,
    /// <see cref="BlueprintAbility.CanTargetFriends"/>,
    /// and <see cref="BlueprintAbility.CanTargetSelf"/>
    /// </summary>
    public AbilityConfigurator AllowTargeting(
        bool? point = null, bool? enemies = null, bool? friends = null, bool? self = null)
    {
      OnConfigureInternal(
          blueprint =>
          {
            blueprint.CanTargetPoint = point ?? blueprint.CanTargetPoint;
            blueprint.CanTargetEnemies = enemies ?? blueprint.CanTargetEnemies;
            blueprint.CanTargetFriends = friends ?? blueprint.CanTargetFriends;
            blueprint.CanTargetSelf = self ?? blueprint.CanTargetSelf;
          });
      return this;
    }
  }
}
