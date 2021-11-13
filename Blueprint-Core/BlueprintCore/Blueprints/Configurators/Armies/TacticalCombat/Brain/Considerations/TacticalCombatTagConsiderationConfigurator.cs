using BlueprintCore.Blueprints.Configurators.AI.Considerations;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain.Considerations;
namespace BlueprintCore.Blueprints.Configurators.Armies.TacticalCombat.Brain.Considerations
{
  /// <summary>Configurator for <see cref="TacticalCombatTagConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(TacticalCombatTagConsideration))]
  public class TacticalCombatTagConsiderationConfigurator : BaseConsiderationConfigurator<TacticalCombatTagConsideration, TacticalCombatTagConsiderationConfigurator>
  {
     private TacticalCombatTagConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TacticalCombatTagConsiderationConfigurator For(string name)
    {
      return new TacticalCombatTagConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static TacticalCombatTagConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<TacticalCombatTagConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TacticalCombatTagConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<TacticalCombatTagConsideration>(name, assetId);
      return For(name);
    }

  }
}
