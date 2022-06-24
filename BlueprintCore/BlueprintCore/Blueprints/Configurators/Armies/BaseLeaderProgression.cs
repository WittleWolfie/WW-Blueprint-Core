//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Armies;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintLeaderProgression"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseLeaderProgressionConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintLeaderProgression
    where TBuilder : BaseLeaderProgressionConfigurator<T, TBuilder>
  {
    protected BaseLeaderProgressionConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintLeaderProgression.m_ProgressionType"/>
    /// </summary>
    public TBuilder SetProgressionType(LeaderProgressionType progressionType)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ProgressionType = progressionType;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintLeaderProgression.m_ProgressionType"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyProgressionType(Action<LeaderProgressionType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_ProgressionType);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintLeaderProgression.m_ProgressionName"/>
    /// </summary>
    ///
    /// <param name="progressionName">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetProgressionName(LocalString progressionName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ProgressionName = progressionName?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintLeaderProgression.m_ProgressionName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyProgressionName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ProgressionName is null) { return; }
          action.Invoke(bp.m_ProgressionName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintLeaderProgression.m_Levels"/>
    /// </summary>
    public TBuilder SetLevels(params LeaderLevel[] levels)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(levels);
          bp.m_Levels = levels;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintLeaderProgression.m_Levels"/>
    /// </summary>
    public TBuilder AddToLevels(params LeaderLevel[] levels)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Levels = bp.m_Levels ?? new LeaderLevel[0];
          bp.m_Levels = CommonTool.Append(bp.m_Levels, levels);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintLeaderProgression.m_Levels"/>
    /// </summary>
    public TBuilder RemoveFromLevels(params LeaderLevel[] levels)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Levels is null) { return; }
          bp.m_Levels = bp.m_Levels.Where(val => !levels.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintLeaderProgression.m_Levels"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromLevels(Func<LeaderLevel, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Levels is null) { return; }
          bp.m_Levels = bp.m_Levels.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintLeaderProgression.m_Levels"/>
    /// </summary>
    public TBuilder ClearLevels()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Levels = new LeaderLevel[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintLeaderProgression.m_Levels"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyLevels(Action<LeaderLevel> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Levels is null) { return; }
          bp.m_Levels.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_ProgressionName is null)
      {
        Blueprint.m_ProgressionName = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_Levels is null)
      {
        Blueprint.m_Levels = new LeaderLevel[0];
      }
    }
  }
}
