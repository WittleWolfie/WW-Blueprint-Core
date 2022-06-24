//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Cutscenes;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Utility;
using System;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.AreaLogic.Cutscenes
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="Gate"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseGateConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : Gate
    where TBuilder : BaseGateConfigurator<T, TBuilder>
  {
    protected BaseGateConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="Gate.Color"/>
    /// </summary>
    public TBuilder SetColor(Color color)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Color = color;
        });
    }

    /// <summary>
    /// Modifies <see cref="Gate.Color"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyColor(Action<Color> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Color);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="Gate.m_Tracks"/>
    /// </summary>
    public TBuilder SetTracks(params Track[] tracks)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(tracks);
          bp.m_Tracks = tracks.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="Gate.m_Tracks"/>
    /// </summary>
    public TBuilder AddToTracks(params Track[] tracks)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Tracks = bp.m_Tracks ?? new();
          bp.m_Tracks.AddRange(tracks);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="Gate.m_Tracks"/>
    /// </summary>
    public TBuilder RemoveFromTracks(params Track[] tracks)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Tracks is null) { return; }
          bp.m_Tracks = bp.m_Tracks.Where(val => !tracks.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="Gate.m_Tracks"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromTracks(Func<Track, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Tracks is null) { return; }
          bp.m_Tracks = bp.m_Tracks.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="Gate.m_Tracks"/>
    /// </summary>
    public TBuilder ClearTracks()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Tracks = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="Gate.m_Tracks"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyTracks(Action<Track> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Tracks is null) { return; }
          bp.m_Tracks.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="Gate.m_Op"/>
    /// </summary>
    public TBuilder SetOp(Operation op)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Op = op;
        });
    }

    /// <summary>
    /// Modifies <see cref="Gate.m_Op"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOp(Action<Operation> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_Op);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="Gate.m_ActivationMode"/>
    /// </summary>
    public TBuilder SetActivationMode(Gate.ActivationModeType activationMode)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ActivationMode = activationMode;
        });
    }

    /// <summary>
    /// Modifies <see cref="Gate.m_ActivationMode"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyActivationMode(Action<Gate.ActivationModeType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_ActivationMode);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="Gate.WhenTrackIsSkipped"/>
    /// </summary>
    public TBuilder SetWhenTrackIsSkipped(Gate.SkipTracksModeType whenTrackIsSkipped)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.WhenTrackIsSkipped = whenTrackIsSkipped;
        });
    }

    /// <summary>
    /// Modifies <see cref="Gate.WhenTrackIsSkipped"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyWhenTrackIsSkipped(Action<Gate.SkipTracksModeType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.WhenTrackIsSkipped);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="Gate.PauseForOneFrame"/>
    /// </summary>
    ///
    /// <param name="pauseForOneFrame">
    /// <para>
    /// Tooltip: Стартовать трэки гейта с задержкой в 1 кадр, как раньше (см. https://confluence.owlcat.local/pages/viewpage.action?pageId=24971382)
    /// </para>
    /// </param>
    public TBuilder SetPauseForOneFrame(bool pauseForOneFrame = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.PauseForOneFrame = pauseForOneFrame;
        });
    }

    /// <summary>
    /// Modifies <see cref="Gate.PauseForOneFrame"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPauseForOneFrame(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.PauseForOneFrame);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Tracks is null)
      {
        Blueprint.m_Tracks = new();
      }
    }
  }
}
