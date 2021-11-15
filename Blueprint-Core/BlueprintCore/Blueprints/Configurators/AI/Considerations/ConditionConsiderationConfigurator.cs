using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.UnitLogic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="ConditionConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(ConditionConsideration))]
  public class ConditionConsiderationConfigurator : BaseConsiderationConfigurator<ConditionConsideration, ConditionConsiderationConfigurator>
  {
     private ConditionConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ConditionConsiderationConfigurator For(string name)
    {
      return new ConditionConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ConditionConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<ConditionConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ConditionConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<ConditionConsideration>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="ConditionConsideration.Conditions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ConditionConsiderationConfigurator AddToConditions(params UnitCondition[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Conditions = CommonTool.Append(bp.Conditions, values));
    }

    /// <summary>
    /// Modifies <see cref="ConditionConsideration.Conditions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ConditionConsiderationConfigurator RemoveFromConditions(params UnitCondition[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Conditions = bp.Conditions.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="ConditionConsideration.HasCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ConditionConsiderationConfigurator SetHasCondition(float value)
    {
      return OnConfigureInternal(bp => bp.HasCondition = value);
    }

    /// <summary>
    /// Sets <see cref="ConditionConsideration.NoCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ConditionConsiderationConfigurator SetNoCondition(float value)
    {
      return OnConfigureInternal(bp => bp.NoCondition = value);
    }
  }
}
