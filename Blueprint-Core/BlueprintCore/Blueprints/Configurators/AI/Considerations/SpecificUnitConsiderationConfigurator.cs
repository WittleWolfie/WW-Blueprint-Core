using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="SpecificUnitBlueprintConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(SpecificUnitBlueprintConsideration))]
  public class SpecificUnitConsiderationConfigurator : BaseConsiderationConfigurator<SpecificUnitBlueprintConsideration, SpecificUnitConsiderationConfigurator>
  {
     private SpecificUnitConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SpecificUnitConsiderationConfigurator For(string name)
    {
      return new SpecificUnitConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static SpecificUnitConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<SpecificUnitBlueprintConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SpecificUnitConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<SpecificUnitBlueprintConsideration>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="SpecificUnitBlueprintConsideration.m_Unit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintUnit"/></param>
    [Generated]
    public SpecificUnitConsiderationConfigurator SetUnit(string value)
    {
      return OnConfigureInternal(bp => bp.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(value));
    }

    /// <summary>
    /// Sets <see cref="SpecificUnitBlueprintConsideration.CorrectUnitScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpecificUnitConsiderationConfigurator SetCorrectUnitScore(float value)
    {
      return OnConfigureInternal(bp => bp.CorrectUnitScore = value);
    }

    /// <summary>
    /// Sets <see cref="SpecificUnitBlueprintConsideration.IncorrectUnitScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpecificUnitConsiderationConfigurator SetIncorrectUnitScore(float value)
    {
      return OnConfigureInternal(bp => bp.IncorrectUnitScore = value);
    }
  }
}
