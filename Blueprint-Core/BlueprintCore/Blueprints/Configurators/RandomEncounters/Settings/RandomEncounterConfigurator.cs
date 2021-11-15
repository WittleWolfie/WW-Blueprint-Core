using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Globalmap.View;
using Kingmaker.Localization;
using Kingmaker.RandomEncounters.Settings;

namespace BlueprintCore.Blueprints.Configurators.RandomEncounters.Settings
{
  /// <summary>Configurator for <see cref="BlueprintRandomEncounter"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintRandomEncounter))]
  public class RandomEncounterConfigurator : BaseBlueprintConfigurator<BlueprintRandomEncounter, RandomEncounterConfigurator>
  {
     private RandomEncounterConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static RandomEncounterConfigurator For(string name)
    {
      return new RandomEncounterConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static RandomEncounterConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintRandomEncounter>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static RandomEncounterConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintRandomEncounter>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.ExcludeFromREList"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncounterConfigurator SetExcludeFromREList(bool value)
    {
      return OnConfigureInternal(bp => bp.ExcludeFromREList = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.IsPeaceful"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncounterConfigurator SetIsPeaceful(bool value)
    {
      return OnConfigureInternal(bp => bp.IsPeaceful = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.Name"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncounterConfigurator SetName(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Name = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.Description"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncounterConfigurator SetDescription(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Description = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.AvoidType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncounterConfigurator SetAvoidType(EncounterAvoidType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.AvoidType = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.AvoidDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncounterConfigurator SetAvoidDC(int value)
    {
      return OnConfigureInternal(bp => bp.AvoidDC = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.EncountersLimit"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncounterConfigurator SetEncountersLimit(int value)
    {
      return OnConfigureInternal(bp => bp.EncountersLimit = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.Conditions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncounterConfigurator SetConditions(ConditionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.Conditions = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.PawnPrefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncounterConfigurator SetPawnPrefab(GlobalMapRandomEncounterPawn value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.PawnPrefab = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.Type"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncounterConfigurator SetType(EncounterType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Type = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.DisableAutoSave"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncounterConfigurator SetDisableAutoSave(bool value)
    {
      return OnConfigureInternal(bp => bp.DisableAutoSave = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.OnEnter"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncounterConfigurator SetOnEnter(ActionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.OnEnter = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.CanBeCampingEncounter"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncounterConfigurator SetCanBeCampingEncounter(bool value)
    {
      return OnConfigureInternal(bp => bp.CanBeCampingEncounter = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.m_AreaEntrance"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintAreaEnterPoint"/></param>
    [Generated]
    public RandomEncounterConfigurator SetAreaEntrance(string value)
    {
      return OnConfigureInternal(bp => bp.m_AreaEntrance = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintRandomEncounter.m_BookEvent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintDialog"/></param>
    [Generated]
    public RandomEncounterConfigurator SetBookEvent(string value)
    {
      return OnConfigureInternal(bp => bp.m_BookEvent = BlueprintTool.GetRef<BlueprintDialogReference>(value));
    }
  }
}
