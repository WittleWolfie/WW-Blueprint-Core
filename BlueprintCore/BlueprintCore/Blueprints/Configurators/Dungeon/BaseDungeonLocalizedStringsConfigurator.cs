//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.Localization;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintDungeonLocalizedStrings"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDungeonLocalizedStringsConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintDungeonLocalizedStrings
    where TBuilder : BaseDungeonLocalizedStringsConfigurator<T, TBuilder>
  {
    protected BaseDungeonLocalizedStringsConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonLocalizedStrings.StageNameParameterized"/>
    /// </summary>
    ///
    /// <param name="stageNameParameterized">
    /// <para>
    /// Tooltip: {text} will be with stage number
    /// </para>
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetStageNameParameterized(LocalString stageNameParameterized)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.StageNameParameterized = stageNameParameterized?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonLocalizedStrings.StageNameParameterized"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyStageNameParameterized(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.StageNameParameterized is null) { return; }
          action.Invoke(bp.StageNameParameterized);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonLocalizedStrings.LeaderboardRecordValues"/>
    /// </summary>
    public TBuilder SetLeaderboardRecordValues(params BlueprintDungeonLocalizedStrings.LeaderboardRecordValue[] leaderboardRecordValues)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(leaderboardRecordValues);
          bp.LeaderboardRecordValues = leaderboardRecordValues;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonLocalizedStrings.LeaderboardRecordValues"/>
    /// </summary>
    public TBuilder AddToLeaderboardRecordValues(params BlueprintDungeonLocalizedStrings.LeaderboardRecordValue[] leaderboardRecordValues)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LeaderboardRecordValues = bp.LeaderboardRecordValues ?? new BlueprintDungeonLocalizedStrings.LeaderboardRecordValue[0];
          bp.LeaderboardRecordValues = CommonTool.Append(bp.LeaderboardRecordValues, leaderboardRecordValues);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonLocalizedStrings.LeaderboardRecordValues"/>
    /// </summary>
    public TBuilder RemoveFromLeaderboardRecordValues(params BlueprintDungeonLocalizedStrings.LeaderboardRecordValue[] leaderboardRecordValues)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LeaderboardRecordValues is null) { return; }
          bp.LeaderboardRecordValues = bp.LeaderboardRecordValues.Where(val => !leaderboardRecordValues.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonLocalizedStrings.LeaderboardRecordValues"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromLeaderboardRecordValues(Func<BlueprintDungeonLocalizedStrings.LeaderboardRecordValue, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LeaderboardRecordValues is null) { return; }
          bp.LeaderboardRecordValues = bp.LeaderboardRecordValues.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonLocalizedStrings.LeaderboardRecordValues"/>
    /// </summary>
    public TBuilder ClearLeaderboardRecordValues()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LeaderboardRecordValues = new BlueprintDungeonLocalizedStrings.LeaderboardRecordValue[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonLocalizedStrings.LeaderboardRecordValues"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyLeaderboardRecordValues(Action<BlueprintDungeonLocalizedStrings.LeaderboardRecordValue> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LeaderboardRecordValues is null) { return; }
          bp.LeaderboardRecordValues.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonLocalizedStrings.LeaderboardCharacterValues"/>
    /// </summary>
    public TBuilder SetLeaderboardCharacterValues(params BlueprintDungeonLocalizedStrings.LeaderboardCharacterValue[] leaderboardCharacterValues)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(leaderboardCharacterValues);
          bp.LeaderboardCharacterValues = leaderboardCharacterValues;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonLocalizedStrings.LeaderboardCharacterValues"/>
    /// </summary>
    public TBuilder AddToLeaderboardCharacterValues(params BlueprintDungeonLocalizedStrings.LeaderboardCharacterValue[] leaderboardCharacterValues)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LeaderboardCharacterValues = bp.LeaderboardCharacterValues ?? new BlueprintDungeonLocalizedStrings.LeaderboardCharacterValue[0];
          bp.LeaderboardCharacterValues = CommonTool.Append(bp.LeaderboardCharacterValues, leaderboardCharacterValues);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonLocalizedStrings.LeaderboardCharacterValues"/>
    /// </summary>
    public TBuilder RemoveFromLeaderboardCharacterValues(params BlueprintDungeonLocalizedStrings.LeaderboardCharacterValue[] leaderboardCharacterValues)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LeaderboardCharacterValues is null) { return; }
          bp.LeaderboardCharacterValues = bp.LeaderboardCharacterValues.Where(val => !leaderboardCharacterValues.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonLocalizedStrings.LeaderboardCharacterValues"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromLeaderboardCharacterValues(Func<BlueprintDungeonLocalizedStrings.LeaderboardCharacterValue, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LeaderboardCharacterValues is null) { return; }
          bp.LeaderboardCharacterValues = bp.LeaderboardCharacterValues.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonLocalizedStrings.LeaderboardCharacterValues"/>
    /// </summary>
    public TBuilder ClearLeaderboardCharacterValues()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LeaderboardCharacterValues = new BlueprintDungeonLocalizedStrings.LeaderboardCharacterValue[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonLocalizedStrings.LeaderboardCharacterValues"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyLeaderboardCharacterValues(Action<BlueprintDungeonLocalizedStrings.LeaderboardCharacterValue> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LeaderboardCharacterValues is null) { return; }
          bp.LeaderboardCharacterValues.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.StageNameParameterized is null)
      {
        Blueprint.StageNameParameterized = Utils.Constants.Empty.String;
      }
      if (Blueprint.LeaderboardRecordValues is null)
      {
        Blueprint.LeaderboardRecordValues = new BlueprintDungeonLocalizedStrings.LeaderboardRecordValue[0];
      }
      if (Blueprint.LeaderboardCharacterValues is null)
      {
        Blueprint.LeaderboardCharacterValues = new BlueprintDungeonLocalizedStrings.LeaderboardCharacterValue[0];
      }
    }
  }
}
