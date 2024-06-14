//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.Dungeon.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintDungeonDifficultyCurve"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDungeonDifficultyCurveConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintDungeonDifficultyCurve
    where TBuilder : BaseDungeonDifficultyCurveConfigurator<T, TBuilder>
  {
    protected BaseDungeonDifficultyCurveConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintDungeonDifficultyCurve>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Difficulty = copyFrom.m_Difficulty;
          bp.m_ChallengeRatings = copyFrom.m_ChallengeRatings;
          bp.m_IconLink = copyFrom.m_IconLink;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintDungeonDifficultyCurve>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Difficulty = copyFrom.m_Difficulty;
          bp.m_ChallengeRatings = copyFrom.m_ChallengeRatings;
          bp.m_IconLink = copyFrom.m_IconLink;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonDifficultyCurve.m_Difficulty"/>
    /// </summary>
    public TBuilder SetDifficulty(DungeonDifficulty difficulty)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Difficulty = difficulty;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonDifficultyCurve.m_ChallengeRatings"/>
    /// </summary>
    ///
    /// <param name="challengeRatings">
    /// <para>
    /// Tooltip: Index corresponds to the stage (island) index, value corresponds to CR.
    /// </para>
    /// </param>
    public TBuilder SetChallengeRatings(params DungeonCrRange[] challengeRatings)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(challengeRatings);
          bp.m_ChallengeRatings = challengeRatings;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonDifficultyCurve.m_ChallengeRatings"/>
    /// </summary>
    ///
    /// <param name="challengeRatings">
    /// <para>
    /// Tooltip: Index corresponds to the stage (island) index, value corresponds to CR.
    /// </para>
    /// </param>
    public TBuilder AddToChallengeRatings(params DungeonCrRange[] challengeRatings)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ChallengeRatings = bp.m_ChallengeRatings ?? new DungeonCrRange[0];
          bp.m_ChallengeRatings = CommonTool.Append(bp.m_ChallengeRatings, challengeRatings);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonDifficultyCurve.m_ChallengeRatings"/>
    /// </summary>
    ///
    /// <param name="challengeRatings">
    /// <para>
    /// Tooltip: Index corresponds to the stage (island) index, value corresponds to CR.
    /// </para>
    /// </param>
    public TBuilder RemoveFromChallengeRatings(params DungeonCrRange[] challengeRatings)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ChallengeRatings is null) { return; }
          bp.m_ChallengeRatings = bp.m_ChallengeRatings.Where(val => !challengeRatings.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonDifficultyCurve.m_ChallengeRatings"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromChallengeRatings(Func<DungeonCrRange, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ChallengeRatings is null) { return; }
          bp.m_ChallengeRatings = bp.m_ChallengeRatings.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonDifficultyCurve.m_ChallengeRatings"/>
    /// </summary>
    public TBuilder ClearChallengeRatings()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ChallengeRatings = new DungeonCrRange[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonDifficultyCurve.m_ChallengeRatings"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyChallengeRatings(Action<DungeonCrRange> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ChallengeRatings is null) { return; }
          bp.m_ChallengeRatings.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonDifficultyCurve.m_IconLink"/>
    /// </summary>
    ///
    /// <param name="iconLink">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder SetIconLink(AssetLink<SpriteLink> iconLink)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IconLink = iconLink?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonDifficultyCurve.m_IconLink"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIconLink(Action<SpriteLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_IconLink is null) { return; }
          action.Invoke(bp.m_IconLink);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_ChallengeRatings is null)
      {
        Blueprint.m_ChallengeRatings = new DungeonCrRange[0];
      }
    }
  }
}
