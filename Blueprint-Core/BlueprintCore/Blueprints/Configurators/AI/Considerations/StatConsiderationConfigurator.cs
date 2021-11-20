using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.EntitySystem.Stats;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>
  /// Configurator for <see cref="StatConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(StatConsideration))]
  public class StatConsiderationConfigurator : BaseConsiderationConfigurator<StatConsideration, StatConsiderationConfigurator>
  {
    private StatConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static StatConsiderationConfigurator For(string name)
    {
      return new StatConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static StatConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<StatConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static StatConsiderationConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<StatConsideration>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="StatConsideration.Stat"/> (Auto Generated)
    /// </summary>
    [Generated]
    public StatConsiderationConfigurator SetStat(StatType stat)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Stat = stat;
          });
    }

    /// <summary>
    /// Sets <see cref="StatConsideration.Value"/> (Auto Generated)
    /// </summary>
    [Generated]
    public StatConsiderationConfigurator SetValue(int value)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Value = value;
          });
    }

    /// <summary>
    /// Sets <see cref="StatConsideration.GreaterThanValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    public StatConsiderationConfigurator SetGreaterThanValue(float greaterThanValue)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.GreaterThanValue = greaterThanValue;
          });
    }

    /// <summary>
    /// Sets <see cref="StatConsideration.LesserThanValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    public StatConsiderationConfigurator SetLesserThanValue(float lesserThanValue)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.LesserThanValue = lesserThanValue;
          });
    }
  }
}
