using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="HealthConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(HealthConsideration))]
  public class HealthConsiderationConfigurator : BaseConsiderationConfigurator<HealthConsideration, HealthConsiderationConfigurator>
  {
     private HealthConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static HealthConsiderationConfigurator For(string name)
    {
      return new HealthConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static HealthConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<HealthConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static HealthConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<HealthConsideration>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="HealthConsideration.FullBorder"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HealthConsiderationConfigurator SetFullBorder(int value)
    {
      return OnConfigureInternal(bp => bp.FullBorder = value);
    }

    /// <summary>
    /// Sets <see cref="HealthConsideration.DeadBorder"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HealthConsiderationConfigurator SetDeadBorder(int value)
    {
      return OnConfigureInternal(bp => bp.DeadBorder = value);
    }

    /// <summary>
    /// Sets <see cref="HealthConsideration.AboveFullScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HealthConsiderationConfigurator SetAboveFullScore(float value)
    {
      return OnConfigureInternal(bp => bp.AboveFullScore = value);
    }

    /// <summary>
    /// Sets <see cref="HealthConsideration.BelowDeadScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HealthConsiderationConfigurator SetBelowDeadScore(float value)
    {
      return OnConfigureInternal(bp => bp.BelowDeadScore = value);
    }

    /// <summary>
    /// Sets <see cref="HealthConsideration.FullScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HealthConsiderationConfigurator SetFullScore(float value)
    {
      return OnConfigureInternal(bp => bp.FullScore = value);
    }

    /// <summary>
    /// Sets <see cref="HealthConsideration.DeadScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HealthConsiderationConfigurator SetDeadScore(float value)
    {
      return OnConfigureInternal(bp => bp.DeadScore = value);
    }
  }
}
