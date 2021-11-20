using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain;

namespace BlueprintCore.Blueprints.Configurators.Armies.TacticalCombat.Brain
{
  /// <summary>
  /// Configurator for <see cref="BlueprintTacticalCombatAiAttack"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintTacticalCombatAiAttack))]
  public class TacticalCombatAiAttackConfigurator : BaseTacticalCombatAiActionConfigurator<BlueprintTacticalCombatAiAttack, TacticalCombatAiAttackConfigurator>
  {
    private TacticalCombatAiAttackConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TacticalCombatAiAttackConfigurator For(string name)
    {
      return new TacticalCombatAiAttackConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static TacticalCombatAiAttackConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintTacticalCombatAiAttack>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TacticalCombatAiAttackConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintTacticalCombatAiAttack>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatAiAttack.CanAttackAllies"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatAiAttackConfigurator SetCanAttackAllies(bool canAttackAllies)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CanAttackAllies = canAttackAllies;
          });
    }
  }
}
