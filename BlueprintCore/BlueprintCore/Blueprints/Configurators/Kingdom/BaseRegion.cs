//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Artisans;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Localization;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintRegion"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseRegionConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintRegion
    where TBuilder : BaseRegionConfigurator<T, TBuilder>
  {
    protected BaseRegionConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRegion.m_Id"/>
    /// </summary>
    public TBuilder SetId(RegionId id)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Id = id;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRegion.m_Id"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyId(Action<RegionId> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_Id);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRegion.LocalizedName"/>
    /// </summary>
    public TBuilder SetLocalizedName(LocalizedString localizedName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LocalizedName = localizedName;
          if (bp.LocalizedName is null)
          {
            bp.LocalizedName = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRegion.LocalizedName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLocalizedName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LocalizedName is null) { return; }
          action.Invoke(bp.LocalizedName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRegion.ClaimedDescription"/>
    /// </summary>
    public TBuilder SetClaimedDescription(LocalizedString claimedDescription)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ClaimedDescription = claimedDescription;
          if (bp.ClaimedDescription is null)
          {
            bp.ClaimedDescription = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRegion.ClaimedDescription"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyClaimedDescription(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ClaimedDescription is null) { return; }
          action.Invoke(bp.ClaimedDescription);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRegion.m_Adjacent"/>
    /// </summary>
    ///
    /// <param name="adjacent">
    /// <para>
    /// Blueprint of type BlueprintRegion. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAdjacent(params Blueprint<BlueprintRegion, BlueprintRegionReference>[] adjacent)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Adjacent = adjacent.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintRegion.m_Adjacent"/>
    /// </summary>
    ///
    /// <param name="adjacent">
    /// <para>
    /// Blueprint of type BlueprintRegion. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToAdjacent(params Blueprint<BlueprintRegion, BlueprintRegionReference>[] adjacent)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Adjacent = bp.m_Adjacent ?? new();
          bp.m_Adjacent.AddRange(adjacent.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintRegion.m_Adjacent"/>
    /// </summary>
    ///
    /// <param name="adjacent">
    /// <para>
    /// Blueprint of type BlueprintRegion. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromAdjacent(params Blueprint<BlueprintRegion, BlueprintRegionReference>[] adjacent)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Adjacent is null) { return; }
          bp.m_Adjacent = bp.m_Adjacent.Where(val => !adjacent.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintRegion.m_Adjacent"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="adjacent">
    /// <para>
    /// Blueprint of type BlueprintRegion. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromAdjacent(Func<BlueprintRegionReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Adjacent is null) { return; }
          bp.m_Adjacent = bp.m_Adjacent.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintRegion.m_Adjacent"/>
    /// </summary>
    ///
    /// <param name="adjacent">
    /// <para>
    /// Blueprint of type BlueprintRegion. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearAdjacent()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Adjacent = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRegion.m_Adjacent"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="adjacent">
    /// <para>
    /// Blueprint of type BlueprintRegion. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyAdjacent(Action<BlueprintRegionReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Adjacent is null) { return; }
          bp.m_Adjacent.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRegion.m_ClaimEvent"/>
    /// </summary>
    ///
    /// <param name="claimEvent">
    /// <para>
    /// Blueprint of type BlueprintKingdomClaim. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetClaimEvent(Blueprint<BlueprintKingdomClaim, BlueprintKingdomClaimReference> claimEvent)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ClaimEvent = claimEvent?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRegion.m_ClaimEvent"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="claimEvent">
    /// <para>
    /// Blueprint of type BlueprintKingdomClaim. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyClaimEvent(Action<BlueprintKingdomClaimReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ClaimEvent is null) { return; }
          action.Invoke(bp.m_ClaimEvent);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRegion.StatsWhenClaimed"/>
    /// </summary>
    public TBuilder SetStatsWhenClaimed(KingdomStats.Changes statsWhenClaimed)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(statsWhenClaimed);
          bp.StatsWhenClaimed = statsWhenClaimed;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRegion.StatsWhenClaimed"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyStatsWhenClaimed(Action<KingdomStats.Changes> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.StatsWhenClaimed is null) { return; }
          action.Invoke(bp.StatsWhenClaimed);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRegion.UpgradeEvents"/>
    /// </summary>
    public TBuilder SetUpgradeEvents(params BlueprintRegion.UpgradeVariant[] upgradeEvents)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in upgradeEvents) { Validate(item); }
          bp.UpgradeEvents = upgradeEvents.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintRegion.UpgradeEvents"/>
    /// </summary>
    public TBuilder AddToUpgradeEvents(params BlueprintRegion.UpgradeVariant[] upgradeEvents)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UpgradeEvents = bp.UpgradeEvents ?? new();
          bp.UpgradeEvents.AddRange(upgradeEvents);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintRegion.UpgradeEvents"/>
    /// </summary>
    public TBuilder RemoveFromUpgradeEvents(params BlueprintRegion.UpgradeVariant[] upgradeEvents)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.UpgradeEvents is null) { return; }
          bp.UpgradeEvents = bp.UpgradeEvents.Where(val => !upgradeEvents.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintRegion.UpgradeEvents"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromUpgradeEvents(Func<BlueprintRegion.UpgradeVariant, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.UpgradeEvents is null) { return; }
          bp.UpgradeEvents = bp.UpgradeEvents.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintRegion.UpgradeEvents"/>
    /// </summary>
    public TBuilder ClearUpgradeEvents()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UpgradeEvents = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRegion.UpgradeEvents"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyUpgradeEvents(Action<BlueprintRegion.UpgradeVariant> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.UpgradeEvents is null) { return; }
          bp.UpgradeEvents.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRegion.Artisans"/>
    /// </summary>
    ///
    /// <param name="artisans">
    /// <para>
    /// Blueprint of type BlueprintKingdomArtisan. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetArtisans(params Blueprint<BlueprintKingdomArtisan, BlueprintKingdomArtisanReference>[] artisans)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Artisans = artisans.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintRegion.Artisans"/>
    /// </summary>
    ///
    /// <param name="artisans">
    /// <para>
    /// Blueprint of type BlueprintKingdomArtisan. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToArtisans(params Blueprint<BlueprintKingdomArtisan, BlueprintKingdomArtisanReference>[] artisans)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Artisans = bp.Artisans ?? new();
          bp.Artisans.AddRange(artisans.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintRegion.Artisans"/>
    /// </summary>
    ///
    /// <param name="artisans">
    /// <para>
    /// Blueprint of type BlueprintKingdomArtisan. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromArtisans(params Blueprint<BlueprintKingdomArtisan, BlueprintKingdomArtisanReference>[] artisans)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Artisans is null) { return; }
          bp.Artisans = bp.Artisans.Where(val => !artisans.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintRegion.Artisans"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="artisans">
    /// <para>
    /// Blueprint of type BlueprintKingdomArtisan. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromArtisans(Func<BlueprintKingdomArtisanReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Artisans is null) { return; }
          bp.Artisans = bp.Artisans.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintRegion.Artisans"/>
    /// </summary>
    ///
    /// <param name="artisans">
    /// <para>
    /// Blueprint of type BlueprintKingdomArtisan. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearArtisans()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Artisans = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRegion.Artisans"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="artisans">
    /// <para>
    /// Blueprint of type BlueprintKingdomArtisan. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyArtisans(Action<BlueprintKingdomArtisanReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Artisans is null) { return; }
          bp.Artisans.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRegion.CR"/>
    /// </summary>
    public TBuilder SetCR(int cR)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CR = cR;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRegion.CR"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCR(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.CR);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRegion.HardEncountersDisabled"/>
    /// </summary>
    public TBuilder SetHardEncountersDisabled(bool hardEncountersDisabled = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HardEncountersDisabled = hardEncountersDisabled;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRegion.HardEncountersDisabled"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHardEncountersDisabled(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.HardEncountersDisabled);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRegion.OverrideCorruption"/>
    /// </summary>
    public TBuilder SetOverrideCorruption(bool overrideCorruption = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OverrideCorruption = overrideCorruption;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRegion.OverrideCorruption"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOverrideCorruption(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.OverrideCorruption);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRegion.CorruptionGrowth"/>
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
    /// Modifies <see cref="BlueprintRegion.CorruptionGrowth"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCorruptionGrowth(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.CorruptionGrowth);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintRegion.m_GlobalMap"/>
    /// </summary>
    ///
    /// <param name="globalMap">
    /// <para>
    /// Blueprint of type BlueprintGlobalMap. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetGlobalMap(Blueprint<BlueprintGlobalMap, BlueprintGlobalMapReference> globalMap)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_GlobalMap = globalMap?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRegion.m_GlobalMap"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="globalMap">
    /// <para>
    /// Blueprint of type BlueprintGlobalMap. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyGlobalMap(Action<BlueprintGlobalMapReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_GlobalMap is null) { return; }
          action.Invoke(bp.m_GlobalMap);
        });
    }
  }
}
