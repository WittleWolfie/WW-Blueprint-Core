using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.EntitySystem.Stats;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="SavingThrowConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(SavingThrowConsideration))]
  public class SavingThrowConsiderationConfigurator : BaseConsiderationConfigurator<SavingThrowConsideration, SavingThrowConsiderationConfigurator>
  {
     private SavingThrowConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SavingThrowConsiderationConfigurator For(string name)
    {
      return new SavingThrowConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static SavingThrowConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<SavingThrowConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SavingThrowConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<SavingThrowConsideration>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="SavingThrowConsideration.SaveType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SavingThrowConsiderationConfigurator SetSaveType(SavingThrowType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.SaveType = value);
    }

    /// <summary>
    /// Sets <see cref="SavingThrowConsideration.LowScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SavingThrowConsiderationConfigurator SetLowScore(float value)
    {
      return OnConfigureInternal(bp => bp.LowScore = value);
    }

    /// <summary>
    /// Sets <see cref="SavingThrowConsideration.HighScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SavingThrowConsiderationConfigurator SetHighScore(float value)
    {
      return OnConfigureInternal(bp => bp.HighScore = value);
    }
  }
}
