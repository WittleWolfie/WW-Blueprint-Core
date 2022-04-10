using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Cutscenes;
using Kingmaker.ElementsSystem;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable enable
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
    protected BaseGateConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="Gate.Color"/> (Auto Generated)
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
    /// Sets <see cref="Gate.m_Tracks"/> (Auto Generated)
    /// </summary>
    
    public TBuilder SetTracks(List<Track>? tracks)
    {
      ValidateParam(tracks);

      return OnConfigureInternal(
          bp =>
          {
            bp.m_Tracks = tracks;
          });
    }

    /// <summary>
    /// Adds to <see cref="Gate.m_Tracks"/> (Auto Generated)
    /// </summary>
    
    public TBuilder AddToTracks(params Track[] tracks)
    {
      ValidateParam(tracks);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Tracks.AddRange(tracks.ToList() ?? new List<Track>());
          });
    }

    /// <summary>
    /// Removes from <see cref="Gate.m_Tracks"/> (Auto Generated)
    /// </summary>
    
    public TBuilder RemoveFromTracks(params Track[] tracks)
    {
      ValidateParam(tracks);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Tracks = bp.m_Tracks.Where(item => !tracks.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="Gate.m_Op"/> (Auto Generated)
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
    /// Sets <see cref="Gate.m_ActivationMode"/> (Auto Generated)
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
    /// Sets <see cref="Gate.WhenTrackIsSkipped"/> (Auto Generated)
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
    /// Sets <see cref="Gate.PauseForOneFrame"/> (Auto Generated)
    /// </summary>
    
    public TBuilder SetPauseForOneFrame(bool pauseForOneFrame)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.PauseForOneFrame = pauseForOneFrame;
          });
    }
  }

  /// <summary>
  /// Configurator for <see cref="Gate"/>.
  /// </summary>
  /// <inheritdoc/>
  
  public class GateConfigurator : BaseBlueprintConfigurator<Gate, GateConfigurator>
  {
    private GateConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static GateConfigurator For(string name)
    {
      return new GateConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static GateConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<Gate>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="Gate.Color"/> (Auto Generated)
    /// </summary>
    
    public GateConfigurator SetColor(Color color)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Color = color;
          });
    }

    /// <summary>
    /// Sets <see cref="Gate.m_Tracks"/> (Auto Generated)
    /// </summary>
    
    public GateConfigurator SetTracks(List<Track>? tracks)
    {
      ValidateParam(tracks);

      return OnConfigureInternal(
          bp =>
          {
            bp.m_Tracks = tracks;
          });
    }

    /// <summary>
    /// Adds to <see cref="Gate.m_Tracks"/> (Auto Generated)
    /// </summary>
    
    public GateConfigurator AddToTracks(params Track[] tracks)
    {
      ValidateParam(tracks);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Tracks.AddRange(tracks.ToList() ?? new List<Track>());
          });
    }

    /// <summary>
    /// Removes from <see cref="Gate.m_Tracks"/> (Auto Generated)
    /// </summary>
    
    public GateConfigurator RemoveFromTracks(params Track[] tracks)
    {
      ValidateParam(tracks);
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Tracks = bp.m_Tracks.Where(item => !tracks.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="Gate.m_Op"/> (Auto Generated)
    /// </summary>
    
    public GateConfigurator SetOp(Operation op)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Op = op;
          });
    }

    /// <summary>
    /// Sets <see cref="Gate.m_ActivationMode"/> (Auto Generated)
    /// </summary>
    
    public GateConfigurator SetActivationMode(Gate.ActivationModeType activationMode)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_ActivationMode = activationMode;
          });
    }

    /// <summary>
    /// Sets <see cref="Gate.WhenTrackIsSkipped"/> (Auto Generated)
    /// </summary>
    
    public GateConfigurator SetWhenTrackIsSkipped(Gate.SkipTracksModeType whenTrackIsSkipped)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.WhenTrackIsSkipped = whenTrackIsSkipped;
          });
    }

    /// <summary>
    /// Sets <see cref="Gate.PauseForOneFrame"/> (Auto Generated)
    /// </summary>
    
    public GateConfigurator SetPauseForOneFrame(bool pauseForOneFrame)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.PauseForOneFrame = pauseForOneFrame;
          });
    }
  }
}
