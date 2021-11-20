using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>
  /// Configurator for <see cref="LineOfSightConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(LineOfSightConsideration))]
  public class LineOfSightConsiderationConfigurator : BaseConsiderationConfigurator<LineOfSightConsideration, LineOfSightConsiderationConfigurator>
  {
    private LineOfSightConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static LineOfSightConsiderationConfigurator For(string name)
    {
      return new LineOfSightConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static LineOfSightConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<LineOfSightConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static LineOfSightConsiderationConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<LineOfSightConsideration>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="LineOfSightConsideration.HasNoLosScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LineOfSightConsiderationConfigurator SetHasNoLosScore(float hasNoLosScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HasNoLosScore = hasNoLosScore;
          });
    }

    /// <summary>
    /// Sets <see cref="LineOfSightConsideration.HasLosScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LineOfSightConsiderationConfigurator SetHasLosScore(float hasLosScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HasLosScore = hasLosScore;
          });
    }
  }
}
