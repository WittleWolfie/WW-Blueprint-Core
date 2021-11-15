using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>Configurator for <see cref="BlueprintFaction"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintFaction))]
  public class FactionConfigurator : BaseBlueprintConfigurator<BlueprintFaction, FactionConfigurator>
  {
     private FactionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static FactionConfigurator For(string name)
    {
      return new FactionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static FactionConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintFaction>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static FactionConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintFaction>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFaction.m_AttackFactions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintFaction"/></param>
    [Generated]
    public FactionConfigurator AddToAttackFactions(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_AttackFactions = CommonTool.Append(bp.m_AttackFactions, values.Select(name => BlueprintTool.GetRef<BlueprintFactionReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFaction.m_AttackFactions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintFaction"/></param>
    [Generated]
    public FactionConfigurator RemoveFromAttackFactions(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintFactionReference>(name));
            bp.m_AttackFactions =
                bp.m_AttackFactions
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFaction.m_AllyFactions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintFaction"/></param>
    [Generated]
    public FactionConfigurator AddToAllyFactions(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_AllyFactions = CommonTool.Append(bp.m_AllyFactions, values.Select(name => BlueprintTool.GetRef<BlueprintFactionReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFaction.m_AllyFactions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintFaction"/></param>
    [Generated]
    public FactionConfigurator RemoveFromAllyFactions(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintFactionReference>(name));
            bp.m_AllyFactions =
                bp.m_AllyFactions
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintFaction.m_AllyFactionsBehaviour"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FactionConfigurator SetAllyFactionsBehaviour(BlueprintFaction.EAllyFactions value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_AllyFactionsBehaviour = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintFaction.Peaceful"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FactionConfigurator SetPeaceful(bool value)
    {
      return OnConfigureInternal(bp => bp.Peaceful = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintFaction.AlwaysEnemy"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FactionConfigurator SetAlwaysEnemy(bool value)
    {
      return OnConfigureInternal(bp => bp.AlwaysEnemy = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintFaction.EnemyForEveryone"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FactionConfigurator SetEnemyForEveryone(bool value)
    {
      return OnConfigureInternal(bp => bp.EnemyForEveryone = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintFaction.Neutral"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FactionConfigurator SetNeutral(bool value)
    {
      return OnConfigureInternal(bp => bp.Neutral = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintFaction.IsDirectlyControllable"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FactionConfigurator SetIsDirectlyControllable(bool value)
    {
      return OnConfigureInternal(bp => bp.IsDirectlyControllable = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintFaction.NeverJoinCombat"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FactionConfigurator SetNeverJoinCombat(bool value)
    {
      return OnConfigureInternal(bp => bp.NeverJoinCombat = value);
    }
  }
}
