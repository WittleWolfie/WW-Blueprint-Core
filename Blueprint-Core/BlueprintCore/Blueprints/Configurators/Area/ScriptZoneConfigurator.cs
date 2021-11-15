using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Area;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>Configurator for <see cref="BlueprintScriptZone"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintScriptZone))]
  public class ScriptZoneConfigurator : BaseMapObjectConfigurator<BlueprintScriptZone, ScriptZoneConfigurator>
  {
     private ScriptZoneConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ScriptZoneConfigurator For(string name)
    {
      return new ScriptZoneConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ScriptZoneConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintScriptZone>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ScriptZoneConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintScriptZone>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintScriptZone.TriggerConditions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ScriptZoneConfigurator SetTriggerConditions(ConditionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.TriggerConditions = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintScriptZone.EnterActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ScriptZoneConfigurator SetEnterActions(ActionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.EnterActions = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintScriptZone.ExitActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ScriptZoneConfigurator SetExitActions(ActionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.ExitActions = value.Build());
    }
  }
}
