using BlueprintCore.Blueprints.Configurators.AI;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Armies.TacticalCombat.Brain
{
  /// <summary>Configurator for <see cref="BlueprintTacticalCombatBrain"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintTacticalCombatBrain))]
  public class TacticalCombatBrainConfigurator : BaseBrainConfigurator<BlueprintTacticalCombatBrain, TacticalCombatBrainConfigurator>
  {
     private TacticalCombatBrainConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TacticalCombatBrainConfigurator For(string name)
    {
      return new TacticalCombatBrainConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static TacticalCombatBrainConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintTacticalCombatBrain>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TacticalCombatBrainConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintTacticalCombatBrain>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTacticalCombatBrain.m_TacticalActions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintTacticalCombatAiAction"/></param>
    [Generated]
    public TacticalCombatBrainConfigurator AddToTacticalActions(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_TacticalActions = CommonTool.Append(bp.m_TacticalActions, values.Select(name => BlueprintTool.GetRef<BlueprintTacticalCombatAiActionReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTacticalCombatBrain.m_TacticalActions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintTacticalCombatAiAction"/></param>
    [Generated]
    public TacticalCombatBrainConfigurator RemoveFromTacticalActions(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintTacticalCombatAiActionReference>(name));
            bp.m_TacticalActions =
                bp.m_TacticalActions
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }
  }
}
