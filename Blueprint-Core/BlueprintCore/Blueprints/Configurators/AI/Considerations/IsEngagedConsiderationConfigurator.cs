using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="IsEngagedConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(IsEngagedConsideration))]
  public class IsEngagedConsiderationConfigurator : BaseConsiderationConfigurator<IsEngagedConsideration, IsEngagedConsiderationConfigurator>
  {
     private IsEngagedConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static IsEngagedConsiderationConfigurator For(string name)
    {
      return new IsEngagedConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static IsEngagedConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<IsEngagedConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static IsEngagedConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<IsEngagedConsideration>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="IsEngagedConsideration.EngagedScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public IsEngagedConsiderationConfigurator SetEngagedScore(float value)
    {
      return OnConfigureInternal(bp => bp.EngagedScore = value);
    }

    /// <summary>
    /// Sets <see cref="IsEngagedConsideration.NotEngagedScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public IsEngagedConsiderationConfigurator SetNotEngagedScore(float value)
    {
      return OnConfigureInternal(bp => bp.NotEngagedScore = value);
    }
  }
}
