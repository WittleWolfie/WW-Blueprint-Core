//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Conditions.Builder;
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
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintDungeonIslandReward"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDungeonIslandRewardConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintDungeonIslandReward
    where TBuilder : BaseDungeonIslandRewardConfigurator<T, TBuilder>
  {
    protected BaseDungeonIslandRewardConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIslandReward.Name"/>
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
    /// Modifies <see cref="BlueprintDungeonIslandReward.Name"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintDungeonIslandReward.Description"/>
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
    /// Modifies <see cref="BlueprintDungeonIslandReward.Description"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintDungeonIslandReward.m_ImageLink"/>
    /// </summary>
    ///
    /// <param name="imageLink">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder SetImageLink(AssetLink<SpriteLink> imageLink)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ImageLink = imageLink?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonIslandReward.m_ImageLink"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyImageLink(Action<SpriteLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ImageLink is null) { return; }
          action.Invoke(bp.m_ImageLink);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIslandReward.Conditions"/>
    /// </summary>
    public TBuilder SetConditions(ConditionsBuilder conditions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Conditions = conditions?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonIslandReward.Conditions"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintDungeonIslandReward.ForceFirstIsland"/>
    /// </summary>
    public TBuilder SetForceFirstIsland(bool forceFirstIsland = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ForceFirstIsland = forceFirstIsland;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIslandReward.CustomRevealFx"/>
    /// </summary>
    ///
    /// <param name="customRevealFx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetCustomRevealFx(AssetLink<PrefabLink> customRevealFx)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CustomRevealFx = customRevealFx?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonIslandReward.CustomRevealFx"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCustomRevealFx(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CustomRevealFx is null) { return; }
          action.Invoke(bp.CustomRevealFx);
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
      if (Blueprint.Conditions is null)
      {
        Blueprint.Conditions = Utils.Constants.Empty.Conditions;
      }
      if (Blueprint.CustomRevealFx is null)
      {
        Blueprint.CustomRevealFx = Utils.Constants.Empty.PrefabLink;
      }
    }
  }
}
