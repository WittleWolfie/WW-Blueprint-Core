using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.QA.Clockwork;
namespace BlueprintCore.Blueprints.Configurators.QA.Clockwork
{
  /// <summary>Configurator for <see cref="BlueprintClockworkScenarioPart"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintClockworkScenarioPart))]
  public class ClockworkScenarioPartConfigurator : BaseBlueprintConfigurator<BlueprintClockworkScenarioPart, ClockworkScenarioPartConfigurator>
  {
     private ClockworkScenarioPartConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ClockworkScenarioPartConfigurator For(string name)
    {
      return new ClockworkScenarioPartConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ClockworkScenarioPartConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintClockworkScenarioPart>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ClockworkScenarioPartConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintClockworkScenarioPart>(name, assetId);
      return For(name);
    }

  }
}
