using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.EntitySystem.Stats;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="StatConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  
  public class StatConsiderationConfigurator : BaseConsiderationConfigurator<StatConsideration, StatConsiderationConfigurator>
  {
    private StatConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static StatConsiderationConfigurator For(string name)
    {
      return new StatConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static StatConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<StatConsideration>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="StatConsideration.Stat"/> (Auto Generated)
    /// </summary>
    
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
