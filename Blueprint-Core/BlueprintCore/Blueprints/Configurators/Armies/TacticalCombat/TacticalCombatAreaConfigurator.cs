using BlueprintCore.Blueprints.Configurators.Area;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Blueprints;
namespace BlueprintCore.Blueprints.Configurators.Armies.TacticalCombat
{
  /// <summary>Configurator for <see cref="BlueprintTacticalCombatArea"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintTacticalCombatArea))]
  public class TacticalCombatAreaConfigurator : BaseAreaConfigurator<BlueprintTacticalCombatArea, TacticalCombatAreaConfigurator>
  {
     private TacticalCombatAreaConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TacticalCombatAreaConfigurator For(string name)
    {
      return new TacticalCombatAreaConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static TacticalCombatAreaConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintTacticalCombatArea>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TacticalCombatAreaConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintTacticalCombatArea>(name, assetId);
      return For(name);
    }

  }
}
