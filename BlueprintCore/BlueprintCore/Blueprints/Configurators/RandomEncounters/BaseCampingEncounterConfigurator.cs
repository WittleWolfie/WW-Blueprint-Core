//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.RandomEncounters.Settings;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

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
    protected BaseCampingEncounterConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintCampingEncounter>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Chance = copyFrom.Chance;
          bp.Conditions = copyFrom.Conditions;
          bp.EncounterActions = copyFrom.EncounterActions;
          bp.InterruptsRest = copyFrom.InterruptsRest;
          bp.PartyTired = copyFrom.PartyTired;
          bp.MainCharacterTired = copyFrom.MainCharacterTired;
          bp.NotOnGlobalMap = copyFrom.NotOnGlobalMap;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintCampingEncounter>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Chance = copyFrom.Chance;
          bp.Conditions = copyFrom.Conditions;
          bp.EncounterActions = copyFrom.EncounterActions;
          bp.InterruptsRest = copyFrom.InterruptsRest;
          bp.PartyTired = copyFrom.PartyTired;
          bp.MainCharacterTired = copyFrom.MainCharacterTired;
          bp.NotOnGlobalMap = copyFrom.NotOnGlobalMap;
        });
    }

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
    /// Sets the value of <see cref="BlueprintCampingEncounter.Conditions"/>
    /// </summary>
    public TBuilder SetConditions(ConditionsBuilder conditions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Conditions = conditions?.Build();
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

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Conditions is null)
      {
        Blueprint.Conditions = Utils.Constants.Empty.Conditions;
      }
      if (Blueprint.EncounterActions is null)
      {
        Blueprint.EncounterActions = Utils.Constants.Empty.Actions;
      }
    }
  }
}
