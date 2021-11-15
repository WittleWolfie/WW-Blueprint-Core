using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="UnitsAroundConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(UnitsAroundConsideration))]
  public abstract class BaseUnitsAroundConsiderationConfigurator<T, TBuilder>
      : BaseConsiderationConfigurator<T, TBuilder>
      where T : UnitsAroundConsideration
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseUnitsAroundConsiderationConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.Filter"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetFilter(Kingmaker.AI.Blueprints.TargetType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Filter = value);
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.MinCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetMinCount(int value)
    {
      return OnConfigureInternal(bp => bp.MinCount = value);
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.MaxCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetMaxCount(int value)
    {
      return OnConfigureInternal(bp => bp.MaxCount = value);
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.IncludeUnconscious"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetIncludeUnconscious(bool value)
    {
      return OnConfigureInternal(bp => bp.IncludeUnconscious = value);
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.BelowMinScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetBelowMinScore(float value)
    {
      return OnConfigureInternal(bp => bp.BelowMinScore = value);
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.MinScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetMinScore(float value)
    {
      return OnConfigureInternal(bp => bp.MinScore = value);
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.MaxScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetMaxScore(float value)
    {
      return OnConfigureInternal(bp => bp.MaxScore = value);
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.ExtraTargetScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetExtraTargetScore(float value)
    {
      return OnConfigureInternal(bp => bp.ExtraTargetScore = value);
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.UseAbilityShape"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetUseAbilityShape(bool value)
    {
      return OnConfigureInternal(bp => bp.UseAbilityShape = value);
    }
  }

  /// <summary>Configurator for <see cref="UnitsAroundConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(UnitsAroundConsideration))]
  public class UnitsAroundConsiderationConfigurator : BaseConsiderationConfigurator<UnitsAroundConsideration, UnitsAroundConsiderationConfigurator>
  {
     private UnitsAroundConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnitsAroundConsiderationConfigurator For(string name)
    {
      return new UnitsAroundConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static UnitsAroundConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<UnitsAroundConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnitsAroundConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<UnitsAroundConsideration>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.Filter"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsAroundConsiderationConfigurator SetFilter(Kingmaker.AI.Blueprints.TargetType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Filter = value);
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.MinCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsAroundConsiderationConfigurator SetMinCount(int value)
    {
      return OnConfigureInternal(bp => bp.MinCount = value);
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.MaxCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsAroundConsiderationConfigurator SetMaxCount(int value)
    {
      return OnConfigureInternal(bp => bp.MaxCount = value);
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.IncludeUnconscious"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsAroundConsiderationConfigurator SetIncludeUnconscious(bool value)
    {
      return OnConfigureInternal(bp => bp.IncludeUnconscious = value);
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.BelowMinScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsAroundConsiderationConfigurator SetBelowMinScore(float value)
    {
      return OnConfigureInternal(bp => bp.BelowMinScore = value);
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.MinScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsAroundConsiderationConfigurator SetMinScore(float value)
    {
      return OnConfigureInternal(bp => bp.MinScore = value);
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.MaxScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsAroundConsiderationConfigurator SetMaxScore(float value)
    {
      return OnConfigureInternal(bp => bp.MaxScore = value);
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.ExtraTargetScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsAroundConsiderationConfigurator SetExtraTargetScore(float value)
    {
      return OnConfigureInternal(bp => bp.ExtraTargetScore = value);
    }

    /// <summary>
    /// Sets <see cref="UnitsAroundConsideration.UseAbilityShape"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitsAroundConsiderationConfigurator SetUseAbilityShape(bool value)
    {
      return OnConfigureInternal(bp => bp.UseAbilityShape = value);
    }
  }
}
