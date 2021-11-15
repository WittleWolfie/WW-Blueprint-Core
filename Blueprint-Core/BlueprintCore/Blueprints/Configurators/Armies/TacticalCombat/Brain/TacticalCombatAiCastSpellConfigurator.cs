using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Armies.TacticalCombat.Brain
{
  /// <summary>Configurator for <see cref="BlueprintTacticalCombatAiCastSpell"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintTacticalCombatAiCastSpell))]
  public class TacticalCombatAiCastSpellConfigurator : BaseTacticalCombatAiActionConfigurator<BlueprintTacticalCombatAiCastSpell, TacticalCombatAiCastSpellConfigurator>
  {
     private TacticalCombatAiCastSpellConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TacticalCombatAiCastSpellConfigurator For(string name)
    {
      return new TacticalCombatAiCastSpellConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static TacticalCombatAiCastSpellConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintTacticalCombatAiCastSpell>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TacticalCombatAiCastSpellConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintTacticalCombatAiCastSpell>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatAiCastSpell.m_Ability"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintAbility"/></param>
    [Generated]
    public TacticalCombatAiCastSpellConfigurator SetAbility(string value)
    {
      return OnConfigureInternal(bp => bp.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatAiCastSpell.m_ForceTargetSelf"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatAiCastSpellConfigurator SetForceTargetSelf(bool value)
    {
      return OnConfigureInternal(bp => bp.m_ForceTargetSelf = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTacticalCombatAiCastSpell.m_ForceTargetEnemy"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TacticalCombatAiCastSpellConfigurator SetForceTargetEnemy(bool value)
    {
      return OnConfigureInternal(bp => bp.m_ForceTargetEnemy = value);
    }
  }
}
