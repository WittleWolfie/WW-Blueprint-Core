using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.Classes.Experience;
using Kingmaker.ElementsSystem;
using Kingmaker.Visual.Animation.Kingmaker;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>Configurator for <see cref="BlueprintTrap"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintTrap))]
  public class TrapConfigurator : BaseMapObjectConfigurator<BlueprintTrap, TrapConfigurator>
  {
     private TrapConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TrapConfigurator For(string name)
    {
      return new TrapConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static TrapConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintTrap>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TrapConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintTrap>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrap.PerceptionDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapConfigurator SetPerceptionDC(int value)
    {
      return OnConfigureInternal(bp => bp.PerceptionDC = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrap.PerceptionRadius"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapConfigurator SetPerceptionRadius(float value)
    {
      return OnConfigureInternal(bp => bp.PerceptionRadius = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrap.DisableDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapConfigurator SetDisableDC(int value)
    {
      return OnConfigureInternal(bp => bp.DisableDC = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrap.DisableTriggerMargin"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapConfigurator SetDisableTriggerMargin(int value)
    {
      return OnConfigureInternal(bp => bp.DisableTriggerMargin = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrap.IsHiddenWhenInactive"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapConfigurator SetIsHiddenWhenInactive(bool value)
    {
      return OnConfigureInternal(bp => bp.IsHiddenWhenInactive = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrap.AllowedForRandomEncounters"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapConfigurator SetAllowedForRandomEncounters(bool value)
    {
      return OnConfigureInternal(bp => bp.AllowedForRandomEncounters = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrap.DisarmAnimation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapConfigurator SetDisarmAnimation(UnitAnimationInteractionType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.DisarmAnimation = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrap.m_Actor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintUnit"/></param>
    [Generated]
    public TrapConfigurator SetActor(string value)
    {
      return OnConfigureInternal(bp => bp.m_Actor = BlueprintTool.GetRef<BlueprintUnitReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrap.TriggerConditions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapConfigurator SetTriggerConditions(ConditionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.TriggerConditions = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrap.DisableConditions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapConfigurator SetDisableConditions(ConditionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.DisableConditions = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrap.TrapActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapConfigurator SetTrapActions(ActionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.TrapActions = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrap.DisableActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapConfigurator SetDisableActions(ActionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.DisableActions = value.Build());
    }

    /// <summary>
    /// Adds <see cref="Experience"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Experience))]
    public TrapConfigurator AddExperience(
        EncounterType Encounter,
        int CR,
        float Modifier,
        IntEvaluator Count,
        bool Dummy)
    {
      ValidateParam(Encounter);
      ValidateParam(Count);
      
      var component =  new Experience();
      component.Encounter = Encounter;
      component.CR = CR;
      component.Modifier = Modifier;
      component.Count = Count;
      component.Dummy = Dummy;
      return AddComponent(component);
    }
  }
}
