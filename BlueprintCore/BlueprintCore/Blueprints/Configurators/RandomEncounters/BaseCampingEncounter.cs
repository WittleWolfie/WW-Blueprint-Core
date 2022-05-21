//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.RandomEncounters.Settings;
using System;

namespace BlueprintCore.Blueprints.Configurators.RandomEncounters
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCampingEncounter"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCampingEncounterConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintCampingEncounter
    where TBuilder : BaseCampingEncounterConfigurator<T, TBuilder>
  {
    protected BaseCampingEncounterConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCampingEncounter.Chance"/>
    /// </summary>
    public TBuilder SetChance(int chance)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Chance = chance;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCampingEncounter.Chance"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyChance(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Chance);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCampingEncounter.Conditions"/>
    /// </summary>
    public TBuilder SetConditions(ConditionsBuilder conditions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Conditions = conditions?.Build();
          if (bp.Conditions is null)
          {
            bp.Conditions = Utils.Constants.Empty.Conditions;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCampingEncounter.Conditions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyConditions(Action<ConditionsChecker> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Conditions is null) { return; }
          action.Invoke(bp.Conditions);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCampingEncounter.EncounterActions"/>
    /// </summary>
    public TBuilder SetEncounterActions(ActionsBuilder encounterActions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.EncounterActions = encounterActions?.Build();
          if (bp.EncounterActions is null)
          {
            bp.EncounterActions = Utils.Constants.Empty.Actions;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCampingEncounter.EncounterActions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyEncounterActions(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.EncounterActions is null) { return; }
          action.Invoke(bp.EncounterActions);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCampingEncounter.InterruptsRest"/>
    /// </summary>
    ///
    /// <param name="interruptsRest">
    /// <para>
    /// InfoBox: Rest will be interrupted during sleep phase. None rest effects will be applied
    /// </para>
    /// </param>
    public TBuilder SetInterruptsRest(bool interruptsRest = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.InterruptsRest = interruptsRest;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCampingEncounter.InterruptsRest"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyInterruptsRest(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.InterruptsRest);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCampingEncounter.PartyTired"/>
    /// </summary>
    ///
    /// <param name="partyTired">
    /// <para>
    /// InfoBox: Party wont get natural healing and wont recover spell slots
    /// </para>
    /// </param>
    public TBuilder SetPartyTired(bool partyTired = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.PartyTired = partyTired;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCampingEncounter.PartyTired"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPartyTired(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.PartyTired);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCampingEncounter.MainCharacterTired"/>
    /// </summary>
    ///
    /// <param name="mainCharacterTired">
    /// <para>
    /// InfoBox: MainCharacter wont get natural healing and wont recover spell slots
    /// </para>
    /// </param>
    public TBuilder SetMainCharacterTired(bool mainCharacterTired = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MainCharacterTired = mainCharacterTired;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCampingEncounter.MainCharacterTired"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMainCharacterTired(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MainCharacterTired);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCampingEncounter.NotOnGlobalMap"/>
    /// </summary>
    public TBuilder SetNotOnGlobalMap(bool notOnGlobalMap = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NotOnGlobalMap = notOnGlobalMap;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCampingEncounter.NotOnGlobalMap"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNotOnGlobalMap(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.NotOnGlobalMap);
        });
    }
  }
}
