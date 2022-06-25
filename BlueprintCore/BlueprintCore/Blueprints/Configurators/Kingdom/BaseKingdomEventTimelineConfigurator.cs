//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintKingdomEventTimeline"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseKingdomEventTimelineConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintKingdomEventTimeline
    where TBuilder : BaseKingdomEventTimelineConfigurator<T, TBuilder>
  {
    protected BaseKingdomEventTimelineConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomEventTimeline.Entries"/>
    /// </summary>
    public TBuilder SetEntries(BlueprintKingdomEventTimeline.EntryList entries)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(entries);
          bp.Entries = entries;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomEventTimeline.Entries"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyEntries(Action<BlueprintKingdomEventTimeline.EntryList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Entries is null) { return; }
          action.Invoke(bp.Entries);
        });
    }
  }
}
