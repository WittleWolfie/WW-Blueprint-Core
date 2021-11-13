using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Blueprints;
namespace BlueprintCore.Blueprints.Configurators.Armies.TacticalCombat
{
  /// <summary>Configurator for <see cref="BlueprintTacticalCombatRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintTacticalCombatRoot))]
  public class TacticalCombatRootConfigurator : BaseBlueprintConfigurator<BlueprintTacticalCombatRoot, TacticalCombatRootConfigurator>
  {
     private TacticalCombatRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TacticalCombatRootConfigurator For(string name)
    {
      return new TacticalCombatRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static TacticalCombatRootConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintTacticalCombatRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TacticalCombatRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintTacticalCombatRoot>(name, assetId);
      return For(name);
    }

  }
}
