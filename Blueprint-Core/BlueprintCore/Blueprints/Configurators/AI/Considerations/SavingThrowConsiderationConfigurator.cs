using BlueprintCore.Blueprints.Configurators.AI.Considerations;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

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
  }
}
