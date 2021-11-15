using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Craft;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Craft
{
  /// <summary>Configurator for <see cref="CraftRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(CraftRoot))]
  public class CraftRootConfigurator : BaseBlueprintConfigurator<CraftRoot, CraftRootConfigurator>
  {
     private CraftRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CraftRootConfigurator For(string name)
    {
      return new CraftRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CraftRootConfigurator New(string name)
    {
      BlueprintTool.Create<CraftRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CraftRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<CraftRoot>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="CraftRoot.m_CraftCostMultiplyer"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CraftRootConfigurator SetCraftCostMultiplyer(int value)
    {
      return OnConfigureInternal(bp => bp.m_CraftCostMultiplyer = value);
    }

    /// <summary>
    /// Sets <see cref="CraftRoot.m_CostForCraftDay"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CraftRootConfigurator SetCostForCraftDay(int value)
    {
      return OnConfigureInternal(bp => bp.m_CostForCraftDay = value);
    }

    /// <summary>
    /// Sets <see cref="CraftRoot.m_BaseCraftedAbilityDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CraftRootConfigurator SetBaseCraftedAbilityDC(int value)
    {
      return OnConfigureInternal(bp => bp.m_BaseCraftedAbilityDC = value);
    }

    /// <summary>
    /// Sets <see cref="CraftRoot.m_BaseCraftDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CraftRootConfigurator SetBaseCraftDC(int value)
    {
      return OnConfigureInternal(bp => bp.m_BaseCraftDC = value);
    }

    /// <summary>
    /// Modifies <see cref="CraftRoot.m_PotionRequirements"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CraftRootConfigurator AddToPotionRequirements(params CraftRequirements[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_PotionRequirements = CommonTool.Append(bp.m_PotionRequirements, values));
    }

    /// <summary>
    /// Modifies <see cref="CraftRoot.m_PotionRequirements"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CraftRootConfigurator RemoveFromPotionRequirements(params CraftRequirements[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_PotionRequirements = bp.m_PotionRequirements.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="CraftRoot.m_ScrollsRequirements"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CraftRootConfigurator AddToScrollsRequirements(params CraftRequirements[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_ScrollsRequirements = CommonTool.Append(bp.m_ScrollsRequirements, values));
    }

    /// <summary>
    /// Modifies <see cref="CraftRoot.m_ScrollsRequirements"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CraftRootConfigurator RemoveFromScrollsRequirements(params CraftRequirements[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_ScrollsRequirements = bp.m_ScrollsRequirements.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="CraftRoot.m_PotionsItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintItemEquipmentUsable"/></param>
    [Generated]
    public CraftRootConfigurator AddToPotionsItems(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_PotionsItems.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintItemEquipmentUsableReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="CraftRoot.m_PotionsItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintItemEquipmentUsable"/></param>
    [Generated]
    public CraftRootConfigurator RemoveFromPotionsItems(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintItemEquipmentUsableReference>(name));
            bp.m_PotionsItems =
                bp.m_PotionsItems
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="CraftRoot.m_ScrollsItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintItemEquipmentUsable"/></param>
    [Generated]
    public CraftRootConfigurator AddToScrollsItems(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_ScrollsItems.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintItemEquipmentUsableReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="CraftRoot.m_ScrollsItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintItemEquipmentUsable"/></param>
    [Generated]
    public CraftRootConfigurator RemoveFromScrollsItems(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintItemEquipmentUsableReference>(name));
            bp.m_ScrollsItems =
                bp.m_ScrollsItems
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="CraftRoot.m_IngredientTable"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CraftRootConfigurator SetIngredientTable(IngredientTable value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_IngredientTable = value);
    }

    /// <summary>
    /// Sets <see cref="CraftRoot.m_CollectingRoot"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CraftRootConfigurator SetCollectingRoot(CollectIngredientRoot value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_CollectingRoot = value);
    }
  }
}
