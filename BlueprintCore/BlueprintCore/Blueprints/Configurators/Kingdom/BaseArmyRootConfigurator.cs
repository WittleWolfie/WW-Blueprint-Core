//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.RuleSystem;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="ArmyRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseArmyRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : ArmyRoot
    where TBuilder : BaseArmyRootConfigurator<T, TBuilder>
  {
    protected BaseArmyRootConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="ArmyRoot.m_TravelingArmiesByChapter"/>
    /// </summary>
    public TBuilder SetTravelingArmiesByChapter(params ArmyRoot.ChapterSpawnInfo[] travelingArmiesByChapter)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(travelingArmiesByChapter);
          bp.m_TravelingArmiesByChapter = travelingArmiesByChapter;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="ArmyRoot.m_TravelingArmiesByChapter"/>
    /// </summary>
    public TBuilder AddToTravelingArmiesByChapter(params ArmyRoot.ChapterSpawnInfo[] travelingArmiesByChapter)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TravelingArmiesByChapter = bp.m_TravelingArmiesByChapter ?? new ArmyRoot.ChapterSpawnInfo[0];
          bp.m_TravelingArmiesByChapter = CommonTool.Append(bp.m_TravelingArmiesByChapter, travelingArmiesByChapter);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="ArmyRoot.m_TravelingArmiesByChapter"/>
    /// </summary>
    public TBuilder RemoveFromTravelingArmiesByChapter(params ArmyRoot.ChapterSpawnInfo[] travelingArmiesByChapter)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TravelingArmiesByChapter is null) { return; }
          bp.m_TravelingArmiesByChapter = bp.m_TravelingArmiesByChapter.Where(val => !travelingArmiesByChapter.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="ArmyRoot.m_TravelingArmiesByChapter"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromTravelingArmiesByChapter(Func<ArmyRoot.ChapterSpawnInfo, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TravelingArmiesByChapter is null) { return; }
          bp.m_TravelingArmiesByChapter = bp.m_TravelingArmiesByChapter.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="ArmyRoot.m_TravelingArmiesByChapter"/>
    /// </summary>
    public TBuilder ClearTravelingArmiesByChapter()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TravelingArmiesByChapter = new ArmyRoot.ChapterSpawnInfo[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="ArmyRoot.m_TravelingArmiesByChapter"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyTravelingArmiesByChapter(Action<ArmyRoot.ChapterSpawnInfo> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TravelingArmiesByChapter is null) { return; }
          bp.m_TravelingArmiesByChapter.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyRoot.m_MaxTravelingArmiesOnMap"/>
    /// </summary>
    public TBuilder SetMaxTravelingArmiesOnMap(int maxTravelingArmiesOnMap)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MaxTravelingArmiesOnMap = maxTravelingArmiesOnMap;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyRoot.ResourceIcon"/>
    /// </summary>
    public TBuilder SetResourceIcon(ArmyRoot.ResourceIcons resourceIcon)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(resourceIcon);
          bp.ResourceIcon = resourceIcon;
        });
    }

    /// <summary>
    /// Modifies <see cref="ArmyRoot.ResourceIcon"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyResourceIcon(Action<ArmyRoot.ResourceIcons> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ResourceIcon is null) { return; }
          action.Invoke(bp.ResourceIcon);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyRoot.m_NobilitySettlementsProgression"/>
    /// </summary>
    ///
    /// <param name="nobilitySettlementsProgression">
    /// <para>
    /// Blueprint of type BlueprintStatProgression. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetNobilitySettlementsProgression(Blueprint<BlueprintStatProgressionReference> nobilitySettlementsProgression)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_NobilitySettlementsProgression = nobilitySettlementsProgression?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="ArmyRoot.m_NobilitySettlementsProgression"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNobilitySettlementsProgression(Action<BlueprintStatProgressionReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_NobilitySettlementsProgression is null) { return; }
          action.Invoke(bp.m_NobilitySettlementsProgression);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyRoot.m_NobilityBuildingsProgression"/>
    /// </summary>
    ///
    /// <param name="nobilityBuildingsProgression">
    /// <para>
    /// Blueprint of type BlueprintStatProgression. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetNobilityBuildingsProgression(Blueprint<BlueprintStatProgressionReference> nobilityBuildingsProgression)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_NobilityBuildingsProgression = nobilityBuildingsProgression?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="ArmyRoot.m_NobilityBuildingsProgression"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNobilityBuildingsProgression(Action<BlueprintStatProgressionReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_NobilityBuildingsProgression is null) { return; }
          action.Invoke(bp.m_NobilityBuildingsProgression);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyRoot.m_NobilityIncomeProgression"/>
    /// </summary>
    ///
    /// <param name="nobilityIncomeProgression">
    /// <para>
    /// Blueprint of type BlueprintStatProgression. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetNobilityIncomeProgression(Blueprint<BlueprintStatProgressionReference> nobilityIncomeProgression)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_NobilityIncomeProgression = nobilityIncomeProgression?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="ArmyRoot.m_NobilityIncomeProgression"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNobilityIncomeProgression(Action<BlueprintStatProgressionReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_NobilityIncomeProgression is null) { return; }
          action.Invoke(bp.m_NobilityIncomeProgression);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyRoot.m_NobilityArmyStrengthProgression"/>
    /// </summary>
    ///
    /// <param name="nobilityArmyStrengthProgression">
    /// <para>
    /// Blueprint of type BlueprintStatProgression. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetNobilityArmyStrengthProgression(Blueprint<BlueprintStatProgressionReference> nobilityArmyStrengthProgression)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_NobilityArmyStrengthProgression = nobilityArmyStrengthProgression?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="ArmyRoot.m_NobilityArmyStrengthProgression"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNobilityArmyStrengthProgression(Action<BlueprintStatProgressionReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_NobilityArmyStrengthProgression is null) { return; }
          action.Invoke(bp.m_NobilityArmyStrengthProgression);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyRoot.m_RoyalCourtLeadersProgression"/>
    /// </summary>
    ///
    /// <param name="royalCourtLeadersProgression">
    /// <para>
    /// Blueprint of type BlueprintStatProgression. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetRoyalCourtLeadersProgression(Blueprint<BlueprintStatProgressionReference> royalCourtLeadersProgression)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_RoyalCourtLeadersProgression = royalCourtLeadersProgression?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="ArmyRoot.m_RoyalCourtLeadersProgression"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRoyalCourtLeadersProgression(Action<BlueprintStatProgressionReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_RoyalCourtLeadersProgression is null) { return; }
          action.Invoke(bp.m_RoyalCourtLeadersProgression);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyRoot.m_RoyalCourtRanksProgression"/>
    /// </summary>
    ///
    /// <param name="royalCourtRanksProgression">
    /// <para>
    /// Blueprint of type BlueprintStatProgression. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetRoyalCourtRanksProgression(Blueprint<BlueprintStatProgressionReference> royalCourtRanksProgression)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_RoyalCourtRanksProgression = royalCourtRanksProgression?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="ArmyRoot.m_RoyalCourtRanksProgression"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRoyalCourtRanksProgression(Action<BlueprintStatProgressionReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_RoyalCourtRanksProgression is null) { return; }
          action.Invoke(bp.m_RoyalCourtRanksProgression);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyRoot.m_RoyalCourtMissionProgressionChapter2"/>
    /// </summary>
    ///
    /// <param name="royalCourtMissionProgressionChapter2">
    /// <para>
    /// Blueprint of type BlueprintStatProgression. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetRoyalCourtMissionProgressionChapter2(Blueprint<BlueprintStatProgressionReference> royalCourtMissionProgressionChapter2)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_RoyalCourtMissionProgressionChapter2 = royalCourtMissionProgressionChapter2?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="ArmyRoot.m_RoyalCourtMissionProgressionChapter2"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRoyalCourtMissionProgressionChapter2(Action<BlueprintStatProgressionReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_RoyalCourtMissionProgressionChapter2 is null) { return; }
          action.Invoke(bp.m_RoyalCourtMissionProgressionChapter2);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyRoot.m_RoyalCourtMissionProgressionChapter3"/>
    /// </summary>
    ///
    /// <param name="royalCourtMissionProgressionChapter3">
    /// <para>
    /// Blueprint of type BlueprintStatProgression. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetRoyalCourtMissionProgressionChapter3(Blueprint<BlueprintStatProgressionReference> royalCourtMissionProgressionChapter3)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_RoyalCourtMissionProgressionChapter3 = royalCourtMissionProgressionChapter3?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="ArmyRoot.m_RoyalCourtMissionProgressionChapter3"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRoyalCourtMissionProgressionChapter3(Action<BlueprintStatProgressionReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_RoyalCourtMissionProgressionChapter3 is null) { return; }
          action.Invoke(bp.m_RoyalCourtMissionProgressionChapter3);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyRoot.m_NobilityPresetReward"/>
    /// </summary>
    ///
    /// <param name="nobilityPresetReward">
    /// <para>
    /// Blueprint of type BlueprintArmyPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetNobilityPresetReward(Blueprint<BlueprintArmyPresetReference> nobilityPresetReward)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_NobilityPresetReward = nobilityPresetReward?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="ArmyRoot.m_NobilityPresetReward"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNobilityPresetReward(Action<BlueprintArmyPresetReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_NobilityPresetReward is null) { return; }
          action.Invoke(bp.m_NobilityPresetReward);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyRoot.m_SummonArmiesMap"/>
    /// </summary>
    ///
    /// <param name="summonArmiesMap">
    /// <para>
    /// Blueprint of type BlueprintGlobalMap. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetSummonArmiesMap(Blueprint<BlueprintGlobalMapReference> summonArmiesMap)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SummonArmiesMap = summonArmiesMap?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="ArmyRoot.m_SummonArmiesMap"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySummonArmiesMap(Action<BlueprintGlobalMapReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SummonArmiesMap is null) { return; }
          action.Invoke(bp.m_SummonArmiesMap);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyRoot.m_MercenaryFreeRerollsStart"/>
    /// </summary>
    public TBuilder SetMercenaryFreeRerollsStart(int mercenaryFreeRerollsStart)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MercenaryFreeRerollsStart = mercenaryFreeRerollsStart;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyRoot.m_MercenaryStartSlots"/>
    /// </summary>
    public TBuilder SetMercenaryStartSlots(int mercenaryStartSlots)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MercenaryStartSlots = mercenaryStartSlots;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyRoot.m_RerollStartPrice"/>
    /// </summary>
    public TBuilder SetRerollStartPrice(KingdomResourcesAmount rerollStartPrice)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_RerollStartPrice = rerollStartPrice;
        });
    }

    /// <summary>
    /// Modifies <see cref="ArmyRoot.m_RerollStartPrice"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRerollStartPrice(Action<KingdomResourcesAmount> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_RerollStartPrice);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyRoot.m_MercenaryDefaultCountFormula"/>
    /// </summary>
    public TBuilder SetMercenaryDefaultCountFormula(DiceFormula mercenaryDefaultCountFormula)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MercenaryDefaultCountFormula = mercenaryDefaultCountFormula;
        });
    }

    /// <summary>
    /// Modifies <see cref="ArmyRoot.m_MercenaryDefaultCountFormula"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMercenaryDefaultCountFormula(Action<DiceFormula> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_MercenaryDefaultCountFormula);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyRoot.m_MercenaryDefaultCountBonus"/>
    /// </summary>
    public TBuilder SetMercenaryDefaultCountBonus(int mercenaryDefaultCountBonus)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MercenaryDefaultCountBonus = mercenaryDefaultCountBonus;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyRoot.m_MercenaryDefaultCountDivider"/>
    /// </summary>
    ///
    /// <param name="mercenaryDefaultCountDivider">
    /// <para>
    /// InfoBox: Growth Formula: slot size = MercenariesBaseGrowths * (MercenaryDefaultCountBonus + MercenaryDefaultCountFormula / MercenaryDefaultCountDivider)
    /// </para>
    /// </param>
    public TBuilder SetMercenaryDefaultCountDivider(float mercenaryDefaultCountDivider)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MercenaryDefaultCountDivider = mercenaryDefaultCountDivider;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyRoot.m_OverpricedMercenaryCountMultiplier"/>
    /// </summary>
    public TBuilder SetOverpricedMercenaryCountMultiplier(float overpricedMercenaryCountMultiplier)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_OverpricedMercenaryCountMultiplier = overpricedMercenaryCountMultiplier;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyRoot.m_OverpricedMercenaryPriceMultiplier"/>
    /// </summary>
    public TBuilder SetOverpricedMercenaryPriceMultiplier(float overpricedMercenaryPriceMultiplier)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_OverpricedMercenaryPriceMultiplier = overpricedMercenaryPriceMultiplier;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyRoot.m_MercenaryPriceMoraleModifierCoefficient"/>
    /// </summary>
    ///
    /// <param name="mercenaryPriceMoraleModifierCoefficient">
    /// <para>
    /// InfoBox: ResultCost = ResultCost * (1 + (MercenaryFormulaMoraleCap - Min(CurrentMorale + MoraleMaxValue, MercenaryFormulaMoraleCap)) / MercenaryPriceMoraleModifierCoefficient)
    /// </para>
    /// </param>
    public TBuilder SetMercenaryPriceMoraleModifierCoefficient(float mercenaryPriceMoraleModifierCoefficient)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MercenaryPriceMoraleModifierCoefficient = mercenaryPriceMoraleModifierCoefficient;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyRoot.m_MercenaryFormulaMoraleCap"/>
    /// </summary>
    public TBuilder SetMercenaryFormulaMoraleCap(int mercenaryFormulaMoraleCap)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MercenaryFormulaMoraleCap = mercenaryFormulaMoraleCap;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyRoot.m_ExperienceFinancesCoef"/>
    /// </summary>
    ///
    /// <param name="experienceFinancesCoef">
    /// <para>
    /// InfoBox: Experience and value formula: finances * ExperienceFinancesCoef + materials * ExperienceMaterialsCoef + favors * ExperienceFavorsCoef
    /// </para>
    /// </param>
    public TBuilder SetExperienceFinancesCoef(float experienceFinancesCoef)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ExperienceFinancesCoef = experienceFinancesCoef;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyRoot.m_ExperienceMaterialsCoef"/>
    /// </summary>
    public TBuilder SetExperienceMaterialsCoef(float experienceMaterialsCoef)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ExperienceMaterialsCoef = experienceMaterialsCoef;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyRoot.m_ExperienceFavorsCoef"/>
    /// </summary>
    public TBuilder SetExperienceFavorsCoef(float experienceFavorsCoef)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ExperienceFavorsCoef = experienceFavorsCoef;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyRoot.m_ArmyDangerBonus"/>
    /// </summary>
    ///
    /// <param name="armyDangerBonus">
    /// <para>
    /// InfoBox: Danger rating = ((Army squads experience) + ArmyDangerBonus) *  ArmyDangerMultiplier
    /// </para>
    /// </param>
    public TBuilder SetArmyDangerBonus(int armyDangerBonus)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ArmyDangerBonus = armyDangerBonus;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyRoot.m_ArmyDangerMultiplier"/>
    /// </summary>
    public TBuilder SetArmyDangerMultiplier(float armyDangerMultiplier)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ArmyDangerMultiplier = armyDangerMultiplier;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmyRoot.m_ArmyStrings"/>
    /// </summary>
    public TBuilder SetArmyStrings(ArmyStrings armyStrings)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(armyStrings);
          bp.m_ArmyStrings = armyStrings;
        });
    }

    /// <summary>
    /// Modifies <see cref="ArmyRoot.m_ArmyStrings"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyArmyStrings(Action<ArmyStrings> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ArmyStrings is null) { return; }
          action.Invoke(bp.m_ArmyStrings);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_TravelingArmiesByChapter is null)
      {
        Blueprint.m_TravelingArmiesByChapter = new ArmyRoot.ChapterSpawnInfo[0];
      }
      if (Blueprint.m_NobilitySettlementsProgression is null)
      {
        Blueprint.m_NobilitySettlementsProgression = BlueprintTool.GetRef<BlueprintStatProgressionReference>(null);
      }
      if (Blueprint.m_NobilityBuildingsProgression is null)
      {
        Blueprint.m_NobilityBuildingsProgression = BlueprintTool.GetRef<BlueprintStatProgressionReference>(null);
      }
      if (Blueprint.m_NobilityIncomeProgression is null)
      {
        Blueprint.m_NobilityIncomeProgression = BlueprintTool.GetRef<BlueprintStatProgressionReference>(null);
      }
      if (Blueprint.m_NobilityArmyStrengthProgression is null)
      {
        Blueprint.m_NobilityArmyStrengthProgression = BlueprintTool.GetRef<BlueprintStatProgressionReference>(null);
      }
      if (Blueprint.m_RoyalCourtLeadersProgression is null)
      {
        Blueprint.m_RoyalCourtLeadersProgression = BlueprintTool.GetRef<BlueprintStatProgressionReference>(null);
      }
      if (Blueprint.m_RoyalCourtRanksProgression is null)
      {
        Blueprint.m_RoyalCourtRanksProgression = BlueprintTool.GetRef<BlueprintStatProgressionReference>(null);
      }
      if (Blueprint.m_RoyalCourtMissionProgressionChapter2 is null)
      {
        Blueprint.m_RoyalCourtMissionProgressionChapter2 = BlueprintTool.GetRef<BlueprintStatProgressionReference>(null);
      }
      if (Blueprint.m_RoyalCourtMissionProgressionChapter3 is null)
      {
        Blueprint.m_RoyalCourtMissionProgressionChapter3 = BlueprintTool.GetRef<BlueprintStatProgressionReference>(null);
      }
      if (Blueprint.m_NobilityPresetReward is null)
      {
        Blueprint.m_NobilityPresetReward = BlueprintTool.GetRef<BlueprintArmyPresetReference>(null);
      }
      if (Blueprint.m_SummonArmiesMap is null)
      {
        Blueprint.m_SummonArmiesMap = BlueprintTool.GetRef<BlueprintGlobalMapReference>(null);
      }
    }
  }
}
