using BlueprintCore.Blueprints.Configurators.Armies.TacticalCombat.Brain;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain;
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

  }
}
