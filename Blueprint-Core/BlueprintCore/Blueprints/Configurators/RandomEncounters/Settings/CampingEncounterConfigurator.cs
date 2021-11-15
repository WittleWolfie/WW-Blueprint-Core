using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.RandomEncounters.Settings;

namespace BlueprintCore.Blueprints.Configurators.RandomEncounters.Settings
{
  /// <summary>Configurator for <see cref="BlueprintCampingEncounter"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCampingEncounter))]
  public class CampingEncounterConfigurator : BaseBlueprintConfigurator<BlueprintCampingEncounter, CampingEncounterConfigurator>
  {
     private CampingEncounterConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CampingEncounterConfigurator For(string name)
    {
      return new CampingEncounterConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CampingEncounterConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintCampingEncounter>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CampingEncounterConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintCampingEncounter>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCampingEncounter.Chance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CampingEncounterConfigurator SetChance(int value)
    {
      return OnConfigureInternal(bp => bp.Chance = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCampingEncounter.Conditions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CampingEncounterConfigurator SetConditions(ConditionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.Conditions = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintCampingEncounter.EncounterActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CampingEncounterConfigurator SetEncounterActions(ActionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.EncounterActions = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintCampingEncounter.InterruptsRest"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CampingEncounterConfigurator SetInterruptsRest(bool value)
    {
      return OnConfigureInternal(bp => bp.InterruptsRest = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCampingEncounter.PartyTired"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CampingEncounterConfigurator SetPartyTired(bool value)
    {
      return OnConfigureInternal(bp => bp.PartyTired = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCampingEncounter.MainCharacterTired"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CampingEncounterConfigurator SetMainCharacterTired(bool value)
    {
      return OnConfigureInternal(bp => bp.MainCharacterTired = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCampingEncounter.NotOnGlobalMap"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CampingEncounterConfigurator SetNotOnGlobalMap(bool value)
    {
      return OnConfigureInternal(bp => bp.NotOnGlobalMap = value);
    }
  }
}
