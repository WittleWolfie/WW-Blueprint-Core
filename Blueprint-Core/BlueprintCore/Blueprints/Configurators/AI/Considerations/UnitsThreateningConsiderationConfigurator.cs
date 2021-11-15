using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="UnitsThreateningConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(UnitsThreateningConsideration))]
  public class UnitsThreateningConsiderationConfigurator : BaseConsiderationConfigurator<UnitsThreateningConsideration, UnitsThreateningConsiderationConfigurator>
  {
     private UnitsThreateningConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnitsThreateningConsiderationConfigurator For(string name)
    {
      return new UnitsThreateningConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static UnitsThreateningConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<UnitsThreateningConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnitsThreateningConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<UnitsThreateningConsideration>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="UnitsThreateningConsideration.MinCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsThreateningConsiderationConfigurator SetMinCount(int value)
    {
      return OnConfigureInternal(bp => bp.MinCount = value);
    }

    /// <summary>
    /// Sets <see cref="UnitsThreateningConsideration.MaxCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsThreateningConsiderationConfigurator SetMaxCount(int value)
    {
      return OnConfigureInternal(bp => bp.MaxCount = value);
    }

    /// <summary>
    /// Sets <see cref="UnitsThreateningConsideration.BelowMinScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsThreateningConsiderationConfigurator SetBelowMinScore(float value)
    {
      return OnConfigureInternal(bp => bp.BelowMinScore = value);
    }

    /// <summary>
    /// Sets <see cref="UnitsThreateningConsideration.MinScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsThreateningConsiderationConfigurator SetMinScore(float value)
    {
      return OnConfigureInternal(bp => bp.MinScore = value);
    }

    /// <summary>
    /// Sets <see cref="UnitsThreateningConsideration.MaxScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsThreateningConsiderationConfigurator SetMaxScore(float value)
    {
      return OnConfigureInternal(bp => bp.MaxScore = value);
    }

    /// <summary>
    /// Sets <see cref="UnitsThreateningConsideration.ExtraTargetScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsThreateningConsiderationConfigurator SetExtraTargetScore(float value)
    {
      return OnConfigureInternal(bp => bp.ExtraTargetScore = value);
    }
  }
}
