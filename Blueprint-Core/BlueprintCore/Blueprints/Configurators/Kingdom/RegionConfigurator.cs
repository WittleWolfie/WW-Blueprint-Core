using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Localization;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>Configurator for <see cref="BlueprintRegion"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintRegion))]
  public class RegionConfigurator : BaseBlueprintConfigurator<BlueprintRegion, RegionConfigurator>
  {
     private RegionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static RegionConfigurator For(string name)
    {
      return new RegionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static RegionConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintRegion>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static RegionConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintRegion>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRegion.m_Id"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RegionConfigurator SetId(RegionId value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_Id = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRegion.LocalizedName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RegionConfigurator SetLocalizedName(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.LocalizedName = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRegion.ClaimedDescription"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RegionConfigurator SetClaimedDescription(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ClaimedDescription = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRegion.m_Adjacent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintRegion"/></param>
    [Generated]
    public RegionConfigurator AddToAdjacent(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Adjacent.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintRegionReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRegion.m_Adjacent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintRegion"/></param>
    [Generated]
    public RegionConfigurator RemoveFromAdjacent(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintRegionReference>(name));
            bp.m_Adjacent =
                bp.m_Adjacent
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRegion.m_ClaimEvent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintKingdomClaim"/></param>
    [Generated]
    public RegionConfigurator SetClaimEvent(string value)
    {
      return OnConfigureInternal(bp => bp.m_ClaimEvent = BlueprintTool.GetRef<BlueprintKingdomClaimReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintRegion.StatsWhenClaimed"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RegionConfigurator SetStatsWhenClaimed(KingdomStats.Changes value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.StatsWhenClaimed = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRegion.UpgradeEvents"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RegionConfigurator AddToUpgradeEvents(params BlueprintRegion.UpgradeVariant[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.UpgradeEvents.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRegion.UpgradeEvents"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RegionConfigurator RemoveFromUpgradeEvents(params BlueprintRegion.UpgradeVariant[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.UpgradeEvents = bp.UpgradeEvents.Where(item => !values.Contains(item)).ToList());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRegion.Artisans"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintKingdomArtisan"/></param>
    [Generated]
    public RegionConfigurator AddToArtisans(params string[] values)
    {
      return OnConfigureInternal(bp => bp.Artisans.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintKingdomArtisanReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintRegion.Artisans"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintKingdomArtisan"/></param>
    [Generated]
    public RegionConfigurator RemoveFromArtisans(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintKingdomArtisanReference>(name));
            bp.Artisans =
                bp.Artisans
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintRegion.CR"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RegionConfigurator SetCR(int value)
    {
      return OnConfigureInternal(bp => bp.CR = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRegion.HardEncountersDisabled"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RegionConfigurator SetHardEncountersDisabled(bool value)
    {
      return OnConfigureInternal(bp => bp.HardEncountersDisabled = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRegion.OverrideCorruption"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RegionConfigurator SetOverrideCorruption(bool value)
    {
      return OnConfigureInternal(bp => bp.OverrideCorruption = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRegion.CorruptionGrowth"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RegionConfigurator SetCorruptionGrowth(int value)
    {
      return OnConfigureInternal(bp => bp.CorruptionGrowth = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintRegion.m_GlobalMap"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintGlobalMap"/></param>
    [Generated]
    public RegionConfigurator SetGlobalMap(string value)
    {
      return OnConfigureInternal(bp => bp.m_GlobalMap = BlueprintTool.GetRef<BlueprintGlobalMapReference>(value));
    }
  }
}
