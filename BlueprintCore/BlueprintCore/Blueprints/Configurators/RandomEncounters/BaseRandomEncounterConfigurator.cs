//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Globalmap.View;
using Kingmaker.Localization;
using Kingmaker.RandomEncounters.Settings;
using System;

namespace BlueprintCore.Blueprints.Configurators.RandomEncounters
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintRandomEncounter"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseRandomEncounterConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintRandomEncounter
    where TBuilder : BaseRandomEncounterConfigurator<T, TBuilder>
  {
    protected BaseRandomEncounterConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRandomEncounter.ExcludeFromREList"/>
    /// </summary>
    public TBuilder SetExcludeFromREList(bool excludeFromREList = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ExcludeFromREList = excludeFromREList;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRandomEncounter.IsPeaceful"/>
    /// </summary>
    public TBuilder SetIsPeaceful(bool isPeaceful = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsPeaceful = isPeaceful;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRandomEncounter.Name"/>
    /// </summary>
    ///
    /// <param name="name">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetName(LocalString name)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Name = name?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRandomEncounter.Name"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Name is null) { return; }
          action.Invoke(bp.Name);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRandomEncounter.Description"/>
    /// </summary>
    ///
    /// <param name="description">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetDescription(LocalString description)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Description = description?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRandomEncounter.Description"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDescription(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Description is null) { return; }
          action.Invoke(bp.Description);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRandomEncounter.AvoidType"/>
    /// </summary>
    public TBuilder SetAvoidType(EncounterAvoidType avoidType)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AvoidType = avoidType;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRandomEncounter.AvoidDC"/>
    /// </summary>
    ///
    /// <param name="avoidDC">
    /// <para>
    /// InfoBox: Skill check Stealth
    /// </para>
    /// </param>
    public TBuilder SetAvoidDC(int avoidDC)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AvoidDC = avoidDC;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRandomEncounter.EncountersLimit"/>
    /// </summary>
    public TBuilder SetEncountersLimit(int encountersLimit)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.EncountersLimit = encountersLimit;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRandomEncounter.Conditions"/>
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
    /// Modifies <see cref="BlueprintRandomEncounter.Conditions"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintRandomEncounter.PawnPrefab"/>
    /// </summary>
    public TBuilder SetPawnPrefab(GlobalMapRandomEncounterPawn pawnPrefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(pawnPrefab);
          bp.PawnPrefab = pawnPrefab;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRandomEncounter.PawnPrefab"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPawnPrefab(Action<GlobalMapRandomEncounterPawn> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.PawnPrefab is null) { return; }
          action.Invoke(bp.PawnPrefab);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRandomEncounter.Type"/>
    /// </summary>
    public TBuilder SetType(EncounterType type)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Type = type;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRandomEncounter.DisableAutoSave"/>
    /// </summary>
    public TBuilder SetDisableAutoSave(bool disableAutoSave = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DisableAutoSave = disableAutoSave;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRandomEncounter.OnEnter"/>
    /// </summary>
    public TBuilder SetOnEnter(ActionsBuilder onEnter)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OnEnter = onEnter?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRandomEncounter.OnEnter"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOnEnter(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OnEnter is null) { return; }
          action.Invoke(bp.OnEnter);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRandomEncounter.CanBeCampingEncounter"/>
    /// </summary>
    public TBuilder SetCanBeCampingEncounter(bool canBeCampingEncounter = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CanBeCampingEncounter = canBeCampingEncounter;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRandomEncounter.m_AreaEntrance"/>
    /// </summary>
    ///
    /// <param name="areaEntrance">
    /// <para>
    /// Blueprint of type BlueprintAreaEnterPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAreaEntrance(Blueprint<BlueprintAreaEnterPointReference> areaEntrance)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AreaEntrance = areaEntrance?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRandomEncounter.m_AreaEntrance"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAreaEntrance(Action<BlueprintAreaEnterPointReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AreaEntrance is null) { return; }
          action.Invoke(bp.m_AreaEntrance);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRandomEncounter.m_BookEvent"/>
    /// </summary>
    ///
    /// <param name="bookEvent">
    /// <para>
    /// Blueprint of type BlueprintDialog. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetBookEvent(Blueprint<BlueprintDialogReference> bookEvent)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BookEvent = bookEvent?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRandomEncounter.m_BookEvent"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBookEvent(Action<BlueprintDialogReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BookEvent is null) { return; }
          action.Invoke(bp.m_BookEvent);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Name is null)
      {
        Blueprint.Name = Utils.Constants.Empty.String;
      }
      if (Blueprint.Description is null)
      {
        Blueprint.Description = Utils.Constants.Empty.String;
      }
      if (Blueprint.Conditions is null)
      {
        Blueprint.Conditions = Utils.Constants.Empty.Conditions;
      }
      if (Blueprint.OnEnter is null)
      {
        Blueprint.OnEnter = Utils.Constants.Empty.Actions;
      }
      if (Blueprint.m_AreaEntrance is null)
      {
        Blueprint.m_AreaEntrance = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(null);
      }
      if (Blueprint.m_BookEvent is null)
      {
        Blueprint.m_BookEvent = BlueprintTool.GetRef<BlueprintDialogReference>(null);
      }
    }
  }
}
