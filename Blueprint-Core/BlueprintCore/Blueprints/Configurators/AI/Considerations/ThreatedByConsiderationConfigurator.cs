using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="ThreatedByConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(ThreatedByConsideration))]
  public class ThreatedByConsiderationConfigurator : BaseConsiderationConfigurator<ThreatedByConsideration, ThreatedByConsiderationConfigurator>
  {
     private ThreatedByConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ThreatedByConsiderationConfigurator For(string name)
    {
      return new ThreatedByConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ThreatedByConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<ThreatedByConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ThreatedByConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<ThreatedByConsideration>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="ThreatedByConsideration.MinCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ThreatedByConsiderationConfigurator SetMinCount(int value)
    {
      return OnConfigureInternal(bp => bp.MinCount = value);
    }

    /// <summary>
    /// Sets <see cref="ThreatedByConsideration.MaxCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ThreatedByConsiderationConfigurator SetMaxCount(int value)
    {
      return OnConfigureInternal(bp => bp.MaxCount = value);
    }

    /// <summary>
    /// Sets <see cref="ThreatedByConsideration.BelowMinScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ThreatedByConsiderationConfigurator SetBelowMinScore(float value)
    {
      return OnConfigureInternal(bp => bp.BelowMinScore = value);
    }

    /// <summary>
    /// Sets <see cref="ThreatedByConsideration.MinScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ThreatedByConsiderationConfigurator SetMinScore(float value)
    {
      return OnConfigureInternal(bp => bp.MinScore = value);
    }

    /// <summary>
    /// Sets <see cref="ThreatedByConsideration.MaxScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ThreatedByConsiderationConfigurator SetMaxScore(float value)
    {
      return OnConfigureInternal(bp => bp.MaxScore = value);
    }

    /// <summary>
    /// Sets <see cref="ThreatedByConsideration.ExtraTargetScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ThreatedByConsiderationConfigurator SetExtraTargetScore(float value)
    {
      return OnConfigureInternal(bp => bp.ExtraTargetScore = value);
    }
  }
}
