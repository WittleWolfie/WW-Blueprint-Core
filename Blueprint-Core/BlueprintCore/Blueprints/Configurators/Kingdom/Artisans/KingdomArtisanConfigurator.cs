using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Artisans;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Kingdom.Artisans
{
  /// <summary>Configurator for <see cref="BlueprintKingdomArtisan"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintKingdomArtisan))]
  public class KingdomArtisanConfigurator : BaseBlueprintConfigurator<BlueprintKingdomArtisan, KingdomArtisanConfigurator>
  {
     private KingdomArtisanConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingdomArtisanConfigurator For(string name)
    {
      return new KingdomArtisanConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static KingdomArtisanConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintKingdomArtisan>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingdomArtisanConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintKingdomArtisan>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomArtisan.m_ShopBlueprint"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintSettlementBuilding"/></param>
    [Generated]
    public KingdomArtisanConfigurator SetShopBlueprint(string value)
    {
      return OnConfigureInternal(bp => bp.m_ShopBlueprint = BlueprintTool.GetRef<BlueprintSettlementBuildingReference>(value));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomArtisan.ItemDecks"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="ArtisanItemDeck"/></param>
    [Generated]
    public KingdomArtisanConfigurator AddToItemDecks(params string[] values)
    {
      return OnConfigureInternal(bp => bp.ItemDecks.AddRange(values.Select(name => BlueprintTool.GetRef<ArtisanItemDeckReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomArtisan.ItemDecks"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="ArtisanItemDeck"/></param>
    [Generated]
    public KingdomArtisanConfigurator RemoveFromItemDecks(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<ArtisanItemDeckReference>(name));
            bp.ItemDecks =
                bp.ItemDecks
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomArtisan.Tiers"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomArtisanConfigurator AddToTiers(params BlueprintKingdomArtisan.TierData[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Tiers = CommonTool.Append(bp.Tiers, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomArtisan.Tiers"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomArtisanConfigurator RemoveFromTiers(params BlueprintKingdomArtisan.TierData[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Tiers = bp.Tiers.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomArtisan.m_Masterpiece"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintItem"/></param>
    [Generated]
    public KingdomArtisanConfigurator SetMasterpiece(string value)
    {
      return OnConfigureInternal(bp => bp.m_Masterpiece = BlueprintTool.GetRef<BlueprintItemReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomArtisan.MasterpieceUnlock"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomArtisanConfigurator SetMasterpieceUnlock(ConditionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.MasterpieceUnlock = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomArtisan.m_HelpProject"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintKingdomProject"/></param>
    [Generated]
    public KingdomArtisanConfigurator SetHelpProject(string value)
    {
      return OnConfigureInternal(bp => bp.m_HelpProject = BlueprintTool.GetRef<BlueprintKingdomProjectReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomArtisan.OnProductionStarted"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomArtisanConfigurator SetOnProductionStarted(ActionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.OnProductionStarted = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomArtisan.OnGiftReady"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomArtisanConfigurator SetOnGiftReady(ActionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.OnGiftReady = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomArtisan.OnGiftCollected"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomArtisanConfigurator SetOnGiftCollected(ActionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.OnGiftCollected = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintKingdomArtisan.CanCollectGift"/> (Auto Generated)
    /// </summary>
    [Generated]
    public KingdomArtisanConfigurator SetCanCollectGift(ConditionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.CanCollectGift = value.Build());
    }
  }
}
