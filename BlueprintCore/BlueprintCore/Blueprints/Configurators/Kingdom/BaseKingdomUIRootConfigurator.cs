//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.UI.Kingdom;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="KingdomUIRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseKingdomUIRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : KingdomUIRoot
    where TBuilder : BaseKingdomUIRootConfigurator<T, TBuilder>
  {
    protected BaseKingdomUIRootConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="KingdomUIRoot.DefaultOpportunityMapMarker"/>
    /// </summary>
    public TBuilder SetDefaultOpportunityMapMarker(KingdomUIEventMapMarker defaultOpportunityMapMarker)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(defaultOpportunityMapMarker);
          bp.DefaultOpportunityMapMarker = defaultOpportunityMapMarker;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomUIRoot.DefaultOpportunityMapMarker"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDefaultOpportunityMapMarker(Action<KingdomUIEventMapMarker> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DefaultOpportunityMapMarker is null) { return; }
          action.Invoke(bp.DefaultOpportunityMapMarker);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomUIRoot.DefaultProblemMapMarker"/>
    /// </summary>
    public TBuilder SetDefaultProblemMapMarker(KingdomUIEventMapMarker defaultProblemMapMarker)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(defaultProblemMapMarker);
          bp.DefaultProblemMapMarker = defaultProblemMapMarker;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomUIRoot.DefaultProblemMapMarker"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDefaultProblemMapMarker(Action<KingdomUIEventMapMarker> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DefaultProblemMapMarker is null) { return; }
          action.Invoke(bp.DefaultProblemMapMarker);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomUIRoot.Stats"/>
    /// </summary>
    public TBuilder SetStats(params KingdomUIRoot.KingdomStatElement[] stats)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(stats);
          bp.Stats = stats.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="KingdomUIRoot.Stats"/>
    /// </summary>
    public TBuilder AddToStats(params KingdomUIRoot.KingdomStatElement[] stats)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Stats = bp.Stats ?? new();
          bp.Stats.AddRange(stats);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomUIRoot.Stats"/>
    /// </summary>
    public TBuilder RemoveFromStats(params KingdomUIRoot.KingdomStatElement[] stats)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Stats is null) { return; }
          bp.Stats = bp.Stats.Where(val => !stats.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomUIRoot.Stats"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromStats(Func<KingdomUIRoot.KingdomStatElement, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Stats is null) { return; }
          bp.Stats = bp.Stats.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="KingdomUIRoot.Stats"/>
    /// </summary>
    public TBuilder ClearStats()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Stats = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomUIRoot.Stats"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyStats(Action<KingdomUIRoot.KingdomStatElement> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Stats is null) { return; }
          bp.Stats.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomUIRoot.Resources"/>
    /// </summary>
    public TBuilder SetResources(params KingdomUIRoot.KingdomResourceElement[] resources)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(resources);
          bp.Resources = resources.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="KingdomUIRoot.Resources"/>
    /// </summary>
    public TBuilder AddToResources(params KingdomUIRoot.KingdomResourceElement[] resources)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Resources = bp.Resources ?? new();
          bp.Resources.AddRange(resources);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomUIRoot.Resources"/>
    /// </summary>
    public TBuilder RemoveFromResources(params KingdomUIRoot.KingdomResourceElement[] resources)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Resources is null) { return; }
          bp.Resources = bp.Resources.Where(val => !resources.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomUIRoot.Resources"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromResources(Func<KingdomUIRoot.KingdomResourceElement, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Resources is null) { return; }
          bp.Resources = bp.Resources.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="KingdomUIRoot.Resources"/>
    /// </summary>
    public TBuilder ClearResources()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Resources = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomUIRoot.Resources"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyResources(Action<KingdomUIRoot.KingdomResourceElement> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Resources is null) { return; }
          bp.Resources.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomUIRoot.RavenTexts"/>
    /// </summary>
    public TBuilder SetRavenTexts(KingdomUIRoot.KingdomRavenText ravenTexts)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(ravenTexts);
          bp.RavenTexts = ravenTexts;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomUIRoot.RavenTexts"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRavenTexts(Action<KingdomUIRoot.KingdomRavenText> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RavenTexts is null) { return; }
          action.Invoke(bp.RavenTexts);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomUIRoot.LeaderDescriptions"/>
    /// </summary>
    public TBuilder SetLeaderDescriptions(params KingdomUIRoot.KingdomLeaderDescription[] leaderDescriptions)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(leaderDescriptions);
          bp.LeaderDescriptions = leaderDescriptions.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="KingdomUIRoot.LeaderDescriptions"/>
    /// </summary>
    public TBuilder AddToLeaderDescriptions(params KingdomUIRoot.KingdomLeaderDescription[] leaderDescriptions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LeaderDescriptions = bp.LeaderDescriptions ?? new();
          bp.LeaderDescriptions.AddRange(leaderDescriptions);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomUIRoot.LeaderDescriptions"/>
    /// </summary>
    public TBuilder RemoveFromLeaderDescriptions(params KingdomUIRoot.KingdomLeaderDescription[] leaderDescriptions)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LeaderDescriptions is null) { return; }
          bp.LeaderDescriptions = bp.LeaderDescriptions.Where(val => !leaderDescriptions.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomUIRoot.LeaderDescriptions"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromLeaderDescriptions(Func<KingdomUIRoot.KingdomLeaderDescription, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LeaderDescriptions is null) { return; }
          bp.LeaderDescriptions = bp.LeaderDescriptions.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="KingdomUIRoot.LeaderDescriptions"/>
    /// </summary>
    public TBuilder ClearLeaderDescriptions()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LeaderDescriptions = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomUIRoot.LeaderDescriptions"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyLeaderDescriptions(Action<KingdomUIRoot.KingdomLeaderDescription> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LeaderDescriptions is null) { return; }
          bp.LeaderDescriptions.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomUIRoot.Texts"/>
    /// </summary>
    public TBuilder SetTexts(KingdomUIRoot.KingdomUITexts texts)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(texts);
          bp.Texts = texts;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomUIRoot.Texts"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTexts(Action<KingdomUIRoot.KingdomUITexts> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Texts is null) { return; }
          action.Invoke(bp.Texts);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomUIRoot.EventResultMarginDescriptions"/>
    /// </summary>
    public TBuilder SetEventResultMarginDescriptions(params KingdomUIRoot.EventResultMarginDescription[] eventResultMarginDescriptions)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(eventResultMarginDescriptions);
          bp.EventResultMarginDescriptions = eventResultMarginDescriptions.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="KingdomUIRoot.EventResultMarginDescriptions"/>
    /// </summary>
    public TBuilder AddToEventResultMarginDescriptions(params KingdomUIRoot.EventResultMarginDescription[] eventResultMarginDescriptions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.EventResultMarginDescriptions = bp.EventResultMarginDescriptions ?? new();
          bp.EventResultMarginDescriptions.AddRange(eventResultMarginDescriptions);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomUIRoot.EventResultMarginDescriptions"/>
    /// </summary>
    public TBuilder RemoveFromEventResultMarginDescriptions(params KingdomUIRoot.EventResultMarginDescription[] eventResultMarginDescriptions)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.EventResultMarginDescriptions is null) { return; }
          bp.EventResultMarginDescriptions = bp.EventResultMarginDescriptions.Where(val => !eventResultMarginDescriptions.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomUIRoot.EventResultMarginDescriptions"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromEventResultMarginDescriptions(Func<KingdomUIRoot.EventResultMarginDescription, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.EventResultMarginDescriptions is null) { return; }
          bp.EventResultMarginDescriptions = bp.EventResultMarginDescriptions.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="KingdomUIRoot.EventResultMarginDescriptions"/>
    /// </summary>
    public TBuilder ClearEventResultMarginDescriptions()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.EventResultMarginDescriptions = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomUIRoot.EventResultMarginDescriptions"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyEventResultMarginDescriptions(Action<KingdomUIRoot.EventResultMarginDescription> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.EventResultMarginDescriptions is null) { return; }
          bp.EventResultMarginDescriptions.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomUIRoot.Settlement"/>
    /// </summary>
    public TBuilder SetSettlement(KingdomUIRoot.SettlementRoot settlement)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(settlement);
          bp.Settlement = settlement;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomUIRoot.Settlement"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySettlement(Action<KingdomUIRoot.SettlementRoot> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Settlement is null) { return; }
          action.Invoke(bp.Settlement);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomUIRoot.Tooltip"/>
    /// </summary>
    public TBuilder SetTooltip(KingdomUIRoot.KingdomUITooltip tooltip)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(tooltip);
          bp.Tooltip = tooltip;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomUIRoot.Tooltip"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTooltip(Action<KingdomUIRoot.KingdomUITooltip> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Tooltip is null) { return; }
          action.Invoke(bp.Tooltip);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomUIRoot.Motto"/>
    /// </summary>
    public TBuilder SetMotto(KingdomUIRoot.KingdomMotto motto)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(motto);
          bp.Motto = motto;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomUIRoot.Motto"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMotto(Action<KingdomUIRoot.KingdomMotto> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Motto is null) { return; }
          action.Invoke(bp.Motto);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomUIRoot.KingdomStatusChangeReasons"/>
    /// </summary>
    public TBuilder SetKingdomStatusChangeReasons(params KingdomUIRoot.KingdomStatusChangeReasonEntity[] kingdomStatusChangeReasons)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(kingdomStatusChangeReasons);
          bp.KingdomStatusChangeReasons = kingdomStatusChangeReasons.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="KingdomUIRoot.KingdomStatusChangeReasons"/>
    /// </summary>
    public TBuilder AddToKingdomStatusChangeReasons(params KingdomUIRoot.KingdomStatusChangeReasonEntity[] kingdomStatusChangeReasons)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.KingdomStatusChangeReasons = bp.KingdomStatusChangeReasons ?? new();
          bp.KingdomStatusChangeReasons.AddRange(kingdomStatusChangeReasons);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomUIRoot.KingdomStatusChangeReasons"/>
    /// </summary>
    public TBuilder RemoveFromKingdomStatusChangeReasons(params KingdomUIRoot.KingdomStatusChangeReasonEntity[] kingdomStatusChangeReasons)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.KingdomStatusChangeReasons is null) { return; }
          bp.KingdomStatusChangeReasons = bp.KingdomStatusChangeReasons.Where(val => !kingdomStatusChangeReasons.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomUIRoot.KingdomStatusChangeReasons"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromKingdomStatusChangeReasons(Func<KingdomUIRoot.KingdomStatusChangeReasonEntity, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.KingdomStatusChangeReasons is null) { return; }
          bp.KingdomStatusChangeReasons = bp.KingdomStatusChangeReasons.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="KingdomUIRoot.KingdomStatusChangeReasons"/>
    /// </summary>
    public TBuilder ClearKingdomStatusChangeReasons()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.KingdomStatusChangeReasons = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomUIRoot.KingdomStatusChangeReasons"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyKingdomStatusChangeReasons(Action<KingdomUIRoot.KingdomStatusChangeReasonEntity> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.KingdomStatusChangeReasons is null) { return; }
          bp.KingdomStatusChangeReasons.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomUIRoot.KingdomHistoryEntitisCount"/>
    /// </summary>
    public TBuilder SetKingdomHistoryEntitisCount(int kingdomHistoryEntitisCount)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.KingdomHistoryEntitisCount = kingdomHistoryEntitisCount;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomUIRoot.KingdomHistoryEntitisCount"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyKingdomHistoryEntitisCount(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.KingdomHistoryEntitisCount);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomUIRoot.ExResourceStateTypeStrings"/>
    /// </summary>
    public TBuilder SetExResourceStateTypeStrings(KingdomUIRoot.ResourceStateTypeStrings exResourceStateTypeStrings)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(exResourceStateTypeStrings);
          bp.ExResourceStateTypeStrings = exResourceStateTypeStrings;
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomUIRoot.ExResourceStateTypeStrings"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyExResourceStateTypeStrings(Action<KingdomUIRoot.ResourceStateTypeStrings> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ExResourceStateTypeStrings is null) { return; }
          action.Invoke(bp.ExResourceStateTypeStrings);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="KingdomUIRoot.KingdomStautsDesriptions"/>
    /// </summary>
    public TBuilder SetKingdomStautsDesriptions(params KingdomUIRoot.KingdomStatusDescription[] kingdomStautsDesriptions)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(kingdomStautsDesriptions);
          bp.KingdomStautsDesriptions = kingdomStautsDesriptions.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="KingdomUIRoot.KingdomStautsDesriptions"/>
    /// </summary>
    public TBuilder AddToKingdomStautsDesriptions(params KingdomUIRoot.KingdomStatusDescription[] kingdomStautsDesriptions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.KingdomStautsDesriptions = bp.KingdomStautsDesriptions ?? new();
          bp.KingdomStautsDesriptions.AddRange(kingdomStautsDesriptions);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomUIRoot.KingdomStautsDesriptions"/>
    /// </summary>
    public TBuilder RemoveFromKingdomStautsDesriptions(params KingdomUIRoot.KingdomStatusDescription[] kingdomStautsDesriptions)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.KingdomStautsDesriptions is null) { return; }
          bp.KingdomStautsDesriptions = bp.KingdomStautsDesriptions.Where(val => !kingdomStautsDesriptions.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="KingdomUIRoot.KingdomStautsDesriptions"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromKingdomStautsDesriptions(Func<KingdomUIRoot.KingdomStatusDescription, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.KingdomStautsDesriptions is null) { return; }
          bp.KingdomStautsDesriptions = bp.KingdomStautsDesriptions.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="KingdomUIRoot.KingdomStautsDesriptions"/>
    /// </summary>
    public TBuilder ClearKingdomStautsDesriptions()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.KingdomStautsDesriptions = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="KingdomUIRoot.KingdomStautsDesriptions"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyKingdomStautsDesriptions(Action<KingdomUIRoot.KingdomStatusDescription> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.KingdomStautsDesriptions is null) { return; }
          bp.KingdomStautsDesriptions.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Stats is null)
      {
        Blueprint.Stats = new();
      }
      if (Blueprint.Resources is null)
      {
        Blueprint.Resources = new();
      }
      if (Blueprint.LeaderDescriptions is null)
      {
        Blueprint.LeaderDescriptions = new();
      }
      if (Blueprint.EventResultMarginDescriptions is null)
      {
        Blueprint.EventResultMarginDescriptions = new();
      }
      if (Blueprint.KingdomStatusChangeReasons is null)
      {
        Blueprint.KingdomStatusChangeReasons = new();
      }
      if (Blueprint.KingdomStautsDesriptions is null)
      {
        Blueprint.KingdomStautsDesriptions = new();
      }
    }
  }
}
