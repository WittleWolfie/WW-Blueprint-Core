using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain;

namespace BlueprintCore.Blueprints.Configurators.Armies.TacticalCombat.Brain
{
  /// <summary>
  /// Configurator for <see cref="BlueprintTacticalCombatAiPostponeTurn"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintTacticalCombatAiPostponeTurn))]
  public class TacticalCombatAiPostponeTurnConfigurator : BaseTacticalCombatAiActionConfigurator<BlueprintTacticalCombatAiPostponeTurn, TacticalCombatAiPostponeTurnConfigurator>
  {
    private TacticalCombatAiPostponeTurnConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TacticalCombatAiPostponeTurnConfigurator For(string name)
    {
      return new TacticalCombatAiPostponeTurnConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static TacticalCombatAiPostponeTurnConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintTacticalCombatAiPostponeTurn>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TacticalCombatAiPostponeTurnConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintTacticalCombatAiPostponeTurn>(name, assetId);
      return For(name);
    }
  }
}
