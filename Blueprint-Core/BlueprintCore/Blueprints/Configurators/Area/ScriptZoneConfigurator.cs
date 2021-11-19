using BlueprintCore.Blueprints.Configurators.Area;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Area;
using Kingmaker.ElementsSystem;
namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Configurator for <see cref="BlueprintScriptZone"/>.
  /// </summary>
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
    public static ScriptZoneConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintScriptZone>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintScriptZone.TriggerConditions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ScriptZoneConfigurator SetTriggerConditions(ConditionsBuilder triggerConditions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TriggerConditions = triggerConditions?.Build() ?? Constants.Empty.Conditions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintScriptZone.EnterActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ScriptZoneConfigurator SetEnterActions(ActionList enterActions)
    {
      ValidateParam(enterActions);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.EnterActions = enterActions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintScriptZone.ExitActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ScriptZoneConfigurator SetExitActions(ActionList exitActions)
    {
      ValidateParam(exitActions);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.ExitActions = exitActions;
          });
    }
  }
}
