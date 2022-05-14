//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.DialogSystem.Blueprints;
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
    protected BaseRandomEncounterConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

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
    /// Modifies <see cref="BlueprintRandomEncounter.ExcludeFromREList"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyExcludeFromREList(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ExcludeFromREList);
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
    /// Modifies <see cref="BlueprintRandomEncounter.IsPeaceful"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIsPeaceful(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.IsPeaceful);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRandomEncounter.Name"/>
    /// </summary>
    public TBuilder SetName(LocalizedString name)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Name = name;
          if (bp.Name is null)
          {
            bp.Name = Utils.Constants.Empty.String;
          }
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
    public TBuilder SetDescription(LocalizedString description)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Description = description;
          if (bp.Description is null)
          {
            bp.Description = Utils.Constants.Empty.String;
          }
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
    /// Modifies <see cref="BlueprintRandomEncounter.AvoidType"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAvoidType(Action<EncounterAvoidType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.AvoidType);
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
    /// Modifies <see cref="BlueprintRandomEncounter.AvoidDC"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="avoidDC">
    /// <para>
    /// InfoBox: Skill check Stealth
    /// </para>
    /// </param>
    public TBuilder ModifyAvoidDC(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.AvoidDC);
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
    /// Modifies <see cref="BlueprintRandomEncounter.EncountersLimit"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyEncountersLimit(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.EncountersLimit);
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
          if (bp.Conditions is null)
          {
            bp.Conditions = Utils.Constants.Empty.Conditions;
          }
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
    /// Modifies <see cref="BlueprintRandomEncounter.Type"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyType(Action<EncounterType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Type);
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
    /// Modifies <see cref="BlueprintRandomEncounter.DisableAutoSave"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDisableAutoSave(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.DisableAutoSave);
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
          if (bp.OnEnter is null)
          {
            bp.OnEnter = Utils.Constants.Empty.Actions;
          }
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
    /// Modifies <see cref="BlueprintRandomEncounter.CanBeCampingEncounter"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCanBeCampingEncounter(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.CanBeCampingEncounter);
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAreaEntrance(Blueprint<BlueprintAreaEnterPoint, BlueprintAreaEnterPointReference> areaEntrance)
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
    ///
    /// <param name="areaEntrance">
    /// <para>
    /// Blueprint of type BlueprintAreaEnterPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetBookEvent(Blueprint<BlueprintDialog, BlueprintDialogReference> bookEvent)
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
    ///
    /// <param name="bookEvent">
    /// <para>
    /// Blueprint of type BlueprintDialog. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyBookEvent(Action<BlueprintDialogReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BookEvent is null) { return; }
          action.Invoke(bp.m_BookEvent);
        });
    }
  }
}
