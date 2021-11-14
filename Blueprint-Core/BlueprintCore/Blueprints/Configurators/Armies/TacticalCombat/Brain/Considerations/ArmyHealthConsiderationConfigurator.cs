using BlueprintCore.Blueprints.Configurators.AI.Considerations;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain.Considerations;

namespace BlueprintCore.Blueprints.Configurators.Armies.TacticalCombat.Brain.Considerations
{
  /// <summary>Configurator for <see cref="ArmyHealthConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(ArmyHealthConsideration))]
  public class ArmyHealthConsiderationConfigurator : BaseConsiderationConfigurator<ArmyHealthConsideration, ArmyHealthConsiderationConfigurator>
  {
     private ArmyHealthConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ArmyHealthConsiderationConfigurator For(string name)
    {
      return new ArmyHealthConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ArmyHealthConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<ArmyHealthConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ArmyHealthConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<ArmyHealthConsideration>(name, assetId);
      return For(name);
    }
  }
}
