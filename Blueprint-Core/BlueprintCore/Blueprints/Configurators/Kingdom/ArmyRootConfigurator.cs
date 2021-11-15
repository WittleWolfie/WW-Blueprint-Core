using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.RuleSystem;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>Configurator for <see cref="ArmyRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(ArmyRoot))]
  public class ArmyRootConfigurator : BaseBlueprintConfigurator<ArmyRoot, ArmyRootConfigurator>
  {
     private ArmyRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ArmyRootConfigurator For(string name)
    {
      return new ArmyRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ArmyRootConfigurator New(string name)
    {
      BlueprintTool.Create<ArmyRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ArmyRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<ArmyRoot>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="ArmyRoot.m_TravelingArmiesByChapter"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator AddToTravelingArmiesByChapter(params ArmyRoot.ChapterSpawnInfo[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_TravelingArmiesByChapter = CommonTool.Append(bp.m_TravelingArmiesByChapter, values));
    }

    /// <summary>
    /// Modifies <see cref="ArmyRoot.m_TravelingArmiesByChapter"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator RemoveFromTravelingArmiesByChapter(params ArmyRoot.ChapterSpawnInfo[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_TravelingArmiesByChapter = bp.m_TravelingArmiesByChapter.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_MaxTravelingArmiesOnMap"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetMaxTravelingArmiesOnMap(int value)
    {
      return OnConfigureInternal(bp => bp.m_MaxTravelingArmiesOnMap = value);
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.ResourceIcon"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetResourceIcon(ArmyRoot.ResourceIcons value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ResourceIcon = value);
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_NobilitySettlementsProgression"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintStatProgression"/></param>
    [Generated]
    public ArmyRootConfigurator SetNobilitySettlementsProgression(string value)
    {
      return OnConfigureInternal(bp => bp.m_NobilitySettlementsProgression = BlueprintTool.GetRef<BlueprintStatProgressionReference>(value));
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_NobilityBuildingsProgression"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintStatProgression"/></param>
    [Generated]
    public ArmyRootConfigurator SetNobilityBuildingsProgression(string value)
    {
      return OnConfigureInternal(bp => bp.m_NobilityBuildingsProgression = BlueprintTool.GetRef<BlueprintStatProgressionReference>(value));
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_NobilityIncomeProgression"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintStatProgression"/></param>
    [Generated]
    public ArmyRootConfigurator SetNobilityIncomeProgression(string value)
    {
      return OnConfigureInternal(bp => bp.m_NobilityIncomeProgression = BlueprintTool.GetRef<BlueprintStatProgressionReference>(value));
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_NobilityArmyStrengthProgression"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintStatProgression"/></param>
    [Generated]
    public ArmyRootConfigurator SetNobilityArmyStrengthProgression(string value)
    {
      return OnConfigureInternal(bp => bp.m_NobilityArmyStrengthProgression = BlueprintTool.GetRef<BlueprintStatProgressionReference>(value));
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_RoyalCourtLeadersProgression"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintStatProgression"/></param>
    [Generated]
    public ArmyRootConfigurator SetRoyalCourtLeadersProgression(string value)
    {
      return OnConfigureInternal(bp => bp.m_RoyalCourtLeadersProgression = BlueprintTool.GetRef<BlueprintStatProgressionReference>(value));
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_RoyalCourtRanksProgression"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintStatProgression"/></param>
    [Generated]
    public ArmyRootConfigurator SetRoyalCourtRanksProgression(string value)
    {
      return OnConfigureInternal(bp => bp.m_RoyalCourtRanksProgression = BlueprintTool.GetRef<BlueprintStatProgressionReference>(value));
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_RoyalCourtMissionProgressionChapter2"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintStatProgression"/></param>
    [Generated]
    public ArmyRootConfigurator SetRoyalCourtMissionProgressionChapter2(string value)
    {
      return OnConfigureInternal(bp => bp.m_RoyalCourtMissionProgressionChapter2 = BlueprintTool.GetRef<BlueprintStatProgressionReference>(value));
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_RoyalCourtMissionProgressionChapter3"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintStatProgression"/></param>
    [Generated]
    public ArmyRootConfigurator SetRoyalCourtMissionProgressionChapter3(string value)
    {
      return OnConfigureInternal(bp => bp.m_RoyalCourtMissionProgressionChapter3 = BlueprintTool.GetRef<BlueprintStatProgressionReference>(value));
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_NobilityPresetReward"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintArmyPreset"/></param>
    [Generated]
    public ArmyRootConfigurator SetNobilityPresetReward(string value)
    {
      return OnConfigureInternal(bp => bp.m_NobilityPresetReward = BlueprintTool.GetRef<BlueprintArmyPresetReference>(value));
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_SummonArmiesMap"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintGlobalMap"/></param>
    [Generated]
    public ArmyRootConfigurator SetSummonArmiesMap(string value)
    {
      return OnConfigureInternal(bp => bp.m_SummonArmiesMap = BlueprintTool.GetRef<BlueprintGlobalMapReference>(value));
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_MercenaryFreeRerollsStart"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetMercenaryFreeRerollsStart(int value)
    {
      return OnConfigureInternal(bp => bp.m_MercenaryFreeRerollsStart = value);
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_MercenaryStartSlots"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetMercenaryStartSlots(int value)
    {
      return OnConfigureInternal(bp => bp.m_MercenaryStartSlots = value);
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_RerollStartPrice"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetRerollStartPrice(KingdomResourcesAmount value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_RerollStartPrice = value);
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_MercenaryDefaultCountFormula"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetMercenaryDefaultCountFormula(DiceFormula value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_MercenaryDefaultCountFormula = value);
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_MercenaryDefaultCountBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetMercenaryDefaultCountBonus(int value)
    {
      return OnConfigureInternal(bp => bp.m_MercenaryDefaultCountBonus = value);
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_MercenaryDefaultCountDivider"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetMercenaryDefaultCountDivider(float value)
    {
      return OnConfigureInternal(bp => bp.m_MercenaryDefaultCountDivider = value);
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_OverpricedMercenaryCountMultiplier"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetOverpricedMercenaryCountMultiplier(float value)
    {
      return OnConfigureInternal(bp => bp.m_OverpricedMercenaryCountMultiplier = value);
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_OverpricedMercenaryPriceMultiplier"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetOverpricedMercenaryPriceMultiplier(float value)
    {
      return OnConfigureInternal(bp => bp.m_OverpricedMercenaryPriceMultiplier = value);
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_MercenaryPriceMoraleModifierCoefficient"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetMercenaryPriceMoraleModifierCoefficient(float value)
    {
      return OnConfigureInternal(bp => bp.m_MercenaryPriceMoraleModifierCoefficient = value);
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_MercenaryFormulaMoraleCap"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetMercenaryFormulaMoraleCap(int value)
    {
      return OnConfigureInternal(bp => bp.m_MercenaryFormulaMoraleCap = value);
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_ExperienceFinancesCoef"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetExperienceFinancesCoef(float value)
    {
      return OnConfigureInternal(bp => bp.m_ExperienceFinancesCoef = value);
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_ExperienceMaterialsCoef"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetExperienceMaterialsCoef(float value)
    {
      return OnConfigureInternal(bp => bp.m_ExperienceMaterialsCoef = value);
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_ExperienceFavorsCoef"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetExperienceFavorsCoef(float value)
    {
      return OnConfigureInternal(bp => bp.m_ExperienceFavorsCoef = value);
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_ArmyDangerBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetArmyDangerBonus(int value)
    {
      return OnConfigureInternal(bp => bp.m_ArmyDangerBonus = value);
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_ArmyDangerMultiplier"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetArmyDangerMultiplier(float value)
    {
      return OnConfigureInternal(bp => bp.m_ArmyDangerMultiplier = value);
    }

    /// <summary>
    /// Sets <see cref="ArmyRoot.m_ArmyStrings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyRootConfigurator SetArmyStrings(ArmyStrings value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_ArmyStrings = value);
    }
  }
}
