//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintDungeonCampaign"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDungeonCampaignConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintDungeonCampaign
    where TBuilder : BaseDungeonCampaignConfigurator<T, TBuilder>
  {
    protected BaseDungeonCampaignConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonCampaign.m_IsShowMap"/>
    /// </summary>
    public TBuilder SetIsShowMap(bool isShowMap = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IsShowMap = isShowMap;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonCampaign.Expeditions"/>
    /// </summary>
    public TBuilder SetExpeditions(params BlueprintDungeonCampaign.HardcodedExpedition[] expeditions)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(expeditions);
          bp.Expeditions = expeditions;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonCampaign.Expeditions"/>
    /// </summary>
    public TBuilder AddToExpeditions(params BlueprintDungeonCampaign.HardcodedExpedition[] expeditions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Expeditions = bp.Expeditions ?? new BlueprintDungeonCampaign.HardcodedExpedition[0];
          bp.Expeditions = CommonTool.Append(bp.Expeditions, expeditions);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonCampaign.Expeditions"/>
    /// </summary>
    public TBuilder RemoveFromExpeditions(params BlueprintDungeonCampaign.HardcodedExpedition[] expeditions)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Expeditions is null) { return; }
          bp.Expeditions = bp.Expeditions.Where(val => !expeditions.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonCampaign.Expeditions"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromExpeditions(Func<BlueprintDungeonCampaign.HardcodedExpedition, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Expeditions is null) { return; }
          bp.Expeditions = bp.Expeditions.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonCampaign.Expeditions"/>
    /// </summary>
    public TBuilder ClearExpeditions()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Expeditions = new BlueprintDungeonCampaign.HardcodedExpedition[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonCampaign.Expeditions"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyExpeditions(Action<BlueprintDungeonCampaign.HardcodedExpedition> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Expeditions is null) { return; }
          bp.Expeditions.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Expeditions is null)
      {
        Blueprint.Expeditions = new BlueprintDungeonCampaign.HardcodedExpedition[0];
      }
    }
  }
}
