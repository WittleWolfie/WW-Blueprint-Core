using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.QA.Clockwork;
namespace BlueprintCore.Blueprints.Configurators.QA.Clockwork
{
  /// <summary>Configurator for <see cref="BlueprintClockworkScenario"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintClockworkScenario))]
  public class ClockworkScenarioConfigurator : BaseBlueprintConfigurator<BlueprintClockworkScenario, ClockworkScenarioConfigurator>
  {
     private ClockworkScenarioConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ClockworkScenarioConfigurator For(string name)
    {
      return new ClockworkScenarioConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ClockworkScenarioConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintClockworkScenario>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ClockworkScenarioConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintClockworkScenario>(name, assetId);
      return For(name);
    }

  }
}
