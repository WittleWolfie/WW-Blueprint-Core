//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Cutscenes;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.NamedParameters;
using Kingmaker.ElementsSystem;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.AreaLogic.Cutscenes
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="Cutscene"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCutsceneConfigurator<T, TBuilder>
    : BaseGateConfigurator<T, TBuilder>
    where T : Cutscene
    where TBuilder : BaseCutsceneConfigurator<T, TBuilder>
  {
    protected BaseCutsceneConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="Cutscene.Priority"/>
    /// </summary>
    public TBuilder SetPriority(CutscenePriority priority)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Priority = priority;
        });
    }

    /// <summary>
    /// Modifies <see cref="Cutscene.Priority"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPriority(Action<CutscenePriority> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Priority);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="Cutscene.NonSkippable"/>
    /// </summary>
    public TBuilder SetNonSkippable(bool nonSkippable = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NonSkippable = nonSkippable;
        });
    }

    /// <summary>
    /// Modifies <see cref="Cutscene.NonSkippable"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNonSkippable(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.NonSkippable);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="Cutscene.ForbidDialogs"/>
    /// </summary>
    ///
    /// <param name="forbidDialogs">
    /// <para>
    /// Tooltip: If set, units moved by this cutscene cannot start a dialog
    /// </para>
    /// </param>
    public TBuilder SetForbidDialogs(bool forbidDialogs = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ForbidDialogs = forbidDialogs;
        });
    }

    /// <summary>
    /// Modifies <see cref="Cutscene.ForbidDialogs"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="forbidDialogs">
    /// <para>
    /// Tooltip: If set, units moved by this cutscene cannot start a dialog
    /// </para>
    /// </param>
    public TBuilder ModifyForbidDialogs(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ForbidDialogs);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="Cutscene.ForbidRandomIdles"/>
    /// </summary>
    ///
    /// <param name="forbidRandomIdles">
    /// <para>
    /// Tooltip: If set, units moved by this cutscene never play idle variants
    /// </para>
    /// </param>
    public TBuilder SetForbidRandomIdles(bool forbidRandomIdles = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ForbidRandomIdles = forbidRandomIdles;
        });
    }

    /// <summary>
    /// Modifies <see cref="Cutscene.ForbidRandomIdles"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="forbidRandomIdles">
    /// <para>
    /// Tooltip: If set, units moved by this cutscene never play idle variants
    /// </para>
    /// </param>
    public TBuilder ModifyForbidRandomIdles(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ForbidRandomIdles);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="Cutscene.IsBackground"/>
    /// </summary>
    ///
    /// <param name="isBackground">
    /// <para>
    /// Tooltip: If set, the cutscene auto-pauses when there's a dialog, rest, or exclusive cutscene playing
    /// </para>
    /// </param>
    public TBuilder SetIsBackground(bool isBackground = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsBackground = isBackground;
        });
    }

    /// <summary>
    /// Modifies <see cref="Cutscene.IsBackground"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="isBackground">
    /// <para>
    /// Tooltip: If set, the cutscene auto-pauses when there's a dialog, rest, or exclusive cutscene playing
    /// </para>
    /// </param>
    public TBuilder ModifyIsBackground(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.IsBackground);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="Cutscene.Sleepless"/>
    /// </summary>
    ///
    /// <param name="sleepless">
    /// <para>
    /// Tooltip: If not set, cutscene is paused when all anchors are in fog of war or away enough from party
    /// </para>
    /// </param>
    public TBuilder SetSleepless(bool sleepless = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Sleepless = sleepless;
        });
    }

    /// <summary>
    /// Modifies <see cref="Cutscene.Sleepless"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="sleepless">
    /// <para>
    /// Tooltip: If not set, cutscene is paused when all anchors are in fog of war or away enough from party
    /// </para>
    /// </param>
    public TBuilder ModifySleepless(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Sleepless);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="Cutscene.AllowCopies"/>
    /// </summary>
    ///
    /// <param name="allowCopies">
    /// <para>
    /// Tooltip: If set, exact copies of this cutscene (with the same parameters) can play at the same time. You probably do not need to set this.
    /// </para>
    /// </param>
    public TBuilder SetAllowCopies(bool allowCopies = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AllowCopies = allowCopies;
        });
    }

    /// <summary>
    /// Modifies <see cref="Cutscene.AllowCopies"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="allowCopies">
    /// <para>
    /// Tooltip: If set, exact copies of this cutscene (with the same parameters) can play at the same time. You probably do not need to set this.
    /// </para>
    /// </param>
    public TBuilder ModifyAllowCopies(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.AllowCopies);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="Cutscene.AwakeRange"/>
    /// </summary>
    public TBuilder SetAwakeRange(float awakeRange)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AwakeRange = awakeRange;
        });
    }

    /// <summary>
    /// Modifies <see cref="Cutscene.AwakeRange"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAwakeRange(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.AwakeRange);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="Cutscene.Anchors"/>
    /// </summary>
    public TBuilder SetAnchors(EntityReference[] anchors)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in anchors) { Validate(item); }
          bp.Anchors = anchors;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="Cutscene.Anchors"/>
    /// </summary>
    public TBuilder AddToAnchors(params EntityReference[] anchors)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Anchors = bp.Anchors ?? new EntityReference[0];
          bp.Anchors = CommonTool.Append(bp.Anchors, anchors);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="Cutscene.Anchors"/>
    /// </summary>
    public TBuilder RemoveFromAnchors(params EntityReference[] anchors)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Anchors is null) { return; }
          bp.Anchors = bp.Anchors.Where(val => !anchors.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="Cutscene.Anchors"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromAnchors(Func<EntityReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Anchors is null) { return; }
          bp.Anchors = bp.Anchors.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="Cutscene.Anchors"/>
    /// </summary>
    public TBuilder ClearAnchors()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Anchors = new EntityReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="Cutscene.Anchors"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyAnchors(Action<EntityReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Anchors is null) { return; }
          bp.Anchors.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="Cutscene.MarkedUnitHandling"/>
    /// </summary>
    ///
    /// <param name="markedUnitHandling">
    /// <para>
    /// Tooltip: How to react when a unit marked by this cutscene is in combat or marked by a higher priority cutscene
    /// </para>
    /// </param>
    public TBuilder SetMarkedUnitHandling(Cutscene.MarkedUnitHandlingType markedUnitHandling)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MarkedUnitHandling = markedUnitHandling;
        });
    }

    /// <summary>
    /// Modifies <see cref="Cutscene.MarkedUnitHandling"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="markedUnitHandling">
    /// <para>
    /// Tooltip: How to react when a unit marked by this cutscene is in combat or marked by a higher priority cutscene
    /// </para>
    /// </param>
    public TBuilder ModifyMarkedUnitHandling(Action<Cutscene.MarkedUnitHandlingType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MarkedUnitHandling);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="Cutscene.DefaultParameters"/>
    /// </summary>
    public TBuilder SetDefaultParameters(ParametrizedContextSetter defaultParameters)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(defaultParameters);
          bp.DefaultParameters = defaultParameters;
        });
    }

    /// <summary>
    /// Modifies <see cref="Cutscene.DefaultParameters"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDefaultParameters(Action<ParametrizedContextSetter> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DefaultParameters is null) { return; }
          action.Invoke(bp.DefaultParameters);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="Cutscene.OnStopped"/>
    /// </summary>
    public TBuilder SetOnStopped(ActionsBuilder onStopped)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OnStopped = onStopped?.Build();
          if (bp.OnStopped is null)
          {
            bp.OnStopped = Utils.Constants.Empty.Actions;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="Cutscene.OnStopped"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOnStopped(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OnStopped is null) { return; }
          action.Invoke(bp.OnStopped);
        });
    }

    /// <summary>
    /// Adds <see cref="StopCutsceneWhenExitingArea"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>RestCutscene</term><description>e45b17a590873794ebf427e00f5462fa</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddStopCutsceneWhenExitingArea()
    {
      return AddComponent(new StopCutsceneWhenExitingArea());
    }
  }
}