//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.AreaLogic.Cutscenes;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Cutscenes;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.NamedParameters;
using Kingmaker.ElementsSystem;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
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
    protected BaseCutsceneConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<Cutscene>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Priority = copyFrom.Priority;
          bp.NonSkippable = copyFrom.NonSkippable;
          bp.NonSkippingFrames = copyFrom.NonSkippingFrames;
          bp.ForbidDialogs = copyFrom.ForbidDialogs;
          bp.ForbidRandomIdles = copyFrom.ForbidRandomIdles;
          bp.IsBackground = copyFrom.IsBackground;
          bp.Sleepless = copyFrom.Sleepless;
          bp.AllowCopies = copyFrom.AllowCopies;
          bp.AwakeRange = copyFrom.AwakeRange;
          bp.Anchors = copyFrom.Anchors;
          bp.MarkedUnitHandling = copyFrom.MarkedUnitHandling;
          bp.DefaultParameters = copyFrom.DefaultParameters;
          bp.OnStopped = copyFrom.OnStopped;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<Cutscene>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Priority = copyFrom.Priority;
          bp.NonSkippable = copyFrom.NonSkippable;
          bp.NonSkippingFrames = copyFrom.NonSkippingFrames;
          bp.ForbidDialogs = copyFrom.ForbidDialogs;
          bp.ForbidRandomIdles = copyFrom.ForbidRandomIdles;
          bp.IsBackground = copyFrom.IsBackground;
          bp.Sleepless = copyFrom.Sleepless;
          bp.AllowCopies = copyFrom.AllowCopies;
          bp.AwakeRange = copyFrom.AwakeRange;
          bp.Anchors = copyFrom.Anchors;
          bp.MarkedUnitHandling = copyFrom.MarkedUnitHandling;
          bp.DefaultParameters = copyFrom.DefaultParameters;
          bp.OnStopped = copyFrom.OnStopped;
        });
    }

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
    /// Sets the value of <see cref="Cutscene.NonSkippable"/>
    /// </summary>
    ///
    /// <param name="nonSkippable">
    /// <para>
    /// Tooltip: If not set, сan&amp;apos;t be skipped
    /// </para>
    /// </param>
    public TBuilder SetNonSkippable(bool nonSkippable = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NonSkippable = nonSkippable;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="Cutscene.NonSkippingFrames"/>
    /// </summary>
    ///
    /// <param name="nonSkippingFrames">
    /// <para>
    /// Tooltip: If not set, cutscene can skip frames for the mean of optimization
    /// </para>
    /// </param>
    public TBuilder SetNonSkippingFrames(bool nonSkippingFrames = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NonSkippingFrames = nonSkippingFrames;
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
    /// Sets the value of <see cref="Cutscene.IsBackground"/>
    /// </summary>
    ///
    /// <param name="isBackground">
    /// <para>
    /// Tooltip: If set, the cutscene auto-pauses when there&amp;apos;s a dialog, rest, or exclusive cutscene playing
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
    /// Sets the value of <see cref="Cutscene.Anchors"/>
    /// </summary>
    public TBuilder SetAnchors(params EntityReference[] anchors)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(anchors);
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
          bp.Anchors = bp.Anchors.Where(e => !predicate(e)).ToArray();
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
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddStopCutsceneWhenExitingArea(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new StopCutsceneWhenExitingArea();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Anchors is null)
      {
        Blueprint.Anchors = new EntityReference[0];
      }
      if (Blueprint.OnStopped is null)
      {
        Blueprint.OnStopped = Utils.Constants.Empty.Actions;
      }
    }
  }
}
