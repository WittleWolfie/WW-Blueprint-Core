//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using System;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintDungeonTier"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDungeonTierConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintDungeonTier
    where TBuilder : BaseDungeonTierConfigurator<T, TBuilder>
  {
    protected BaseDungeonTierConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonTier.Name"/>
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
    /// Modifies <see cref="BlueprintDungeonTier.Name"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintDungeonTier.StageFirst"/>
    /// </summary>
    public TBuilder SetStageFirst(int stageFirst)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.StageFirst = stageFirst;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonTier.StageLast"/>
    /// </summary>
    public TBuilder SetStageLast(int stageLast)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.StageLast = stageLast;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonTier.ModificatorsCount"/>
    /// </summary>
    public TBuilder SetModificatorsCount(int modificatorsCount)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ModificatorsCount = modificatorsCount;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonTier.GoldMultiplier"/>
    /// </summary>
    public TBuilder SetGoldMultiplier(double goldMultiplier)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.GoldMultiplier = goldMultiplier;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonTier.CorruptionGrowth"/>
    /// </summary>
    public TBuilder SetCorruptionGrowth(int corruptionGrowth)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CorruptionGrowth = corruptionGrowth;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonTier.m_MapBackgroundLink"/>
    /// </summary>
    ///
    /// <param name="mapBackgroundLink">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder SetMapBackgroundLink(AssetLink<SpriteLink> mapBackgroundLink)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MapBackgroundLink = mapBackgroundLink?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonTier.m_MapBackgroundLink"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMapBackgroundLink(Action<SpriteLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_MapBackgroundLink is null) { return; }
          action.Invoke(bp.m_MapBackgroundLink);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonTier.m_MapFrameLink"/>
    /// </summary>
    ///
    /// <param name="mapFrameLink">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder SetMapFrameLink(AssetLink<SpriteLink> mapFrameLink)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MapFrameLink = mapFrameLink?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonTier.m_MapFrameLink"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMapFrameLink(Action<SpriteLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_MapFrameLink is null) { return; }
          action.Invoke(bp.m_MapFrameLink);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonTier.m_MapForegroundLink"/>
    /// </summary>
    ///
    /// <param name="mapForegroundLink">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder SetMapForegroundLink(AssetLink<SpriteLink> mapForegroundLink)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MapForegroundLink = mapForegroundLink?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonTier.m_MapForegroundLink"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMapForegroundLink(Action<SpriteLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_MapForegroundLink is null) { return; }
          action.Invoke(bp.m_MapForegroundLink);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonTier.OnReach"/>
    /// </summary>
    ///
    /// <param name="onReach">
    /// <para>
    /// Tooltip: Actions to run when the tier is reached for the first time in the playthrough.
    /// </para>
    /// </param>
    public TBuilder SetOnReach(ActionsBuilder onReach)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OnReach = onReach?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonTier.OnReach"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOnReach(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OnReach is null) { return; }
          action.Invoke(bp.OnReach);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonTier.OnStart"/>
    /// </summary>
    ///
    /// <param name="onStart">
    /// <para>
    /// Tooltip: Actions to run when the tier is reached for the first time by the character. Won&amp;apos;t run if the OnReach runs.
    /// </para>
    /// </param>
    public TBuilder SetOnStart(ActionsBuilder onStart)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OnStart = onStart?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonTier.OnStart"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOnStart(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OnStart is null) { return; }
          action.Invoke(bp.OnStart);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonTier.OnFinish"/>
    /// </summary>
    ///
    /// <param name="onFinish">
    /// <para>
    /// Tooltip: Actions to run when the tier is reached for the first time by the character.
    /// </para>
    /// </param>
    public TBuilder SetOnFinish(ActionsBuilder onFinish)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OnFinish = onFinish?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonTier.OnFinish"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOnFinish(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OnFinish is null) { return; }
          action.Invoke(bp.OnFinish);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Name is null)
      {
        Blueprint.Name = Utils.Constants.Empty.String;
      }
      if (Blueprint.OnReach is null)
      {
        Blueprint.OnReach = Utils.Constants.Empty.Actions;
      }
      if (Blueprint.OnStart is null)
      {
        Blueprint.OnStart = Utils.Constants.Empty.Actions;
      }
      if (Blueprint.OnFinish is null)
      {
        Blueprint.OnFinish = Utils.Constants.Empty.Actions;
      }
    }
  }
}
