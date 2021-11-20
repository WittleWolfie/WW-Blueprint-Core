using BlueprintCore.Blueprints.Configurators.AI.Considerations;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain.Considerations;

namespace BlueprintCore.Blueprints.Configurators.Armies.TacticalCombat.Brain.Considerations
{
  /// <summary>
  /// Configurator for <see cref="ArmyHealthConsideration"/>.
  /// </summary>
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
    public static ArmyHealthConsiderationConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<ArmyHealthConsideration>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="ArmyHealthConsideration.FullBorder"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyHealthConsiderationConfigurator SetFullBorder(float fullBorder)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FullBorder = fullBorder;
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyHealthConsideration.DeadBorder"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyHealthConsiderationConfigurator SetDeadBorder(float deadBorder)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DeadBorder = deadBorder;
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyHealthConsideration.FullScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyHealthConsiderationConfigurator SetFullScore(float fullScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FullScore = fullScore;
          });
    }

    /// <summary>
    /// Sets <see cref="ArmyHealthConsideration.DeadScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyHealthConsiderationConfigurator SetDeadScore(float deadScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DeadScore = deadScore;
          });
    }
  }
}
