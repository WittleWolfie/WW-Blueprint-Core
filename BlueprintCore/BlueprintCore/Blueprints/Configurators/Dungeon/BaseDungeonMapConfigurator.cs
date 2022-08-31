//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using System;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintDungeonMap"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDungeonMapConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintDungeonMap
    where TBuilder : BaseDungeonMapConfigurator<T, TBuilder>
  {
    protected BaseDungeonMapConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonMap.Name"/>
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
    /// Modifies <see cref="BlueprintDungeonMap.Name"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintDungeonMap.Description"/>
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
    /// Modifies <see cref="BlueprintDungeonMap.Description"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintDungeonMap.ShouldAddDecorations"/>
    /// </summary>
    public TBuilder SetShouldAddDecorations(bool shouldAddDecorations = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ShouldAddDecorations = shouldAddDecorations;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonMap.OverrideMapStartIslandPawnPosition"/>
    /// </summary>
    public TBuilder SetOverrideMapStartIslandPawnPosition(bool overrideMapStartIslandPawnPosition = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OverrideMapStartIslandPawnPosition = overrideMapStartIslandPawnPosition;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonMap.MapStartIslandPawnPosition"/>
    /// </summary>
    ///
    /// <param name="mapStartIslandPawnPosition">
    /// <para>
    /// Tooltip: Pawn start position. 0 is for the topmost position, 1 is for bottommost position.
    /// </para>
    /// </param>
    public TBuilder SetMapStartIslandPawnPosition(Vector2 mapStartIslandPawnPosition)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MapStartIslandPawnPosition = mapStartIslandPawnPosition;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonMap.MapStartIslandPawnPosition"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMapStartIslandPawnPosition(Action<Vector2> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MapStartIslandPawnPosition);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonMap.OverrideMapFinalIslandPawnPosition"/>
    /// </summary>
    public TBuilder SetOverrideMapFinalIslandPawnPosition(bool overrideMapFinalIslandPawnPosition = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OverrideMapFinalIslandPawnPosition = overrideMapFinalIslandPawnPosition;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonMap.MapFinalIslandPawnPosition"/>
    /// </summary>
    ///
    /// <param name="mapFinalIslandPawnPosition">
    /// <para>
    /// Tooltip: Pawn end position. 0 is for the topmost position, 1 is for bottommost position.
    /// </para>
    /// </param>
    public TBuilder SetMapFinalIslandPawnPosition(Vector2 mapFinalIslandPawnPosition)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MapFinalIslandPawnPosition = mapFinalIslandPawnPosition;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonMap.MapFinalIslandPawnPosition"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMapFinalIslandPawnPosition(Action<Vector2> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MapFinalIslandPawnPosition);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonMap.m_ArrowsLink"/>
    /// </summary>
    ///
    /// <param name="arrowsLink">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder SetArrowsLink(AssetLink<SpriteLink> arrowsLink)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ArrowsLink = arrowsLink?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonMap.m_ArrowsLink"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyArrowsLink(Action<SpriteLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ArrowsLink is null) { return; }
          action.Invoke(bp.m_ArrowsLink);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonMap.Layout"/>
    /// </summary>
    public TBuilder SetLayout(DungeonMapLayout layout)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(layout);
          bp.Layout = layout;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonMap.Layout"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLayout(Action<DungeonMapLayout> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Layout is null) { return; }
          action.Invoke(bp.Layout);
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
    }
  }
}
