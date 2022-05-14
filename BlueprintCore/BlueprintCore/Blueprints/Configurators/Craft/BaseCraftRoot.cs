//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Craft;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Craft
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="CraftRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCraftRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : CraftRoot
    where TBuilder : BaseCraftRootConfigurator<T, TBuilder>
  {
    protected BaseCraftRootConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="CraftRoot.m_CraftCostMultiplyer"/>
    /// </summary>
    public TBuilder SetCraftCostMultiplyer(int craftCostMultiplyer)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CraftCostMultiplyer = craftCostMultiplyer;
        });
    }

    /// <summary>
    /// Modifies <see cref="CraftRoot.m_CraftCostMultiplyer"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCraftCostMultiplyer(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_CraftCostMultiplyer);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="CraftRoot.m_CostForCraftDay"/>
    /// </summary>
    public TBuilder SetCostForCraftDay(int costForCraftDay)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CostForCraftDay = costForCraftDay;
        });
    }

    /// <summary>
    /// Modifies <see cref="CraftRoot.m_CostForCraftDay"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCostForCraftDay(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_CostForCraftDay);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="CraftRoot.m_BaseCraftedAbilityDC"/>
    /// </summary>
    public TBuilder SetBaseCraftedAbilityDC(int baseCraftedAbilityDC)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BaseCraftedAbilityDC = baseCraftedAbilityDC;
        });
    }

    /// <summary>
    /// Modifies <see cref="CraftRoot.m_BaseCraftedAbilityDC"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBaseCraftedAbilityDC(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_BaseCraftedAbilityDC);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="CraftRoot.m_BaseCraftDC"/>
    /// </summary>
    public TBuilder SetBaseCraftDC(int baseCraftDC)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BaseCraftDC = baseCraftDC;
        });
    }

    /// <summary>
    /// Modifies <see cref="CraftRoot.m_BaseCraftDC"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBaseCraftDC(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_BaseCraftDC);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="CraftRoot.m_PotionRequirements"/>
    /// </summary>
    public TBuilder SetPotionRequirements(CraftRequirements[] potionRequirements)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in potionRequirements) { Validate(item); }
          bp.m_PotionRequirements = potionRequirements;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="CraftRoot.m_PotionRequirements"/>
    /// </summary>
    public TBuilder AddToPotionRequirements(params CraftRequirements[] potionRequirements)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_PotionRequirements = bp.m_PotionRequirements ?? new CraftRequirements[0];
          bp.m_PotionRequirements = CommonTool.Append(bp.m_PotionRequirements, potionRequirements);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="CraftRoot.m_PotionRequirements"/>
    /// </summary>
    public TBuilder RemoveFromPotionRequirements(params CraftRequirements[] potionRequirements)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_PotionRequirements is null) { return; }
          bp.m_PotionRequirements = bp.m_PotionRequirements.Where(val => !potionRequirements.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="CraftRoot.m_PotionRequirements"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromPotionRequirements(Func<CraftRequirements, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_PotionRequirements is null) { return; }
          bp.m_PotionRequirements = bp.m_PotionRequirements.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="CraftRoot.m_PotionRequirements"/>
    /// </summary>
    public TBuilder ClearPotionRequirements()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_PotionRequirements = new CraftRequirements[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="CraftRoot.m_PotionRequirements"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyPotionRequirements(Action<CraftRequirements> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_PotionRequirements is null) { return; }
          bp.m_PotionRequirements.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="CraftRoot.m_ScrollsRequirements"/>
    /// </summary>
    public TBuilder SetScrollsRequirements(CraftRequirements[] scrollsRequirements)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in scrollsRequirements) { Validate(item); }
          bp.m_ScrollsRequirements = scrollsRequirements;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="CraftRoot.m_ScrollsRequirements"/>
    /// </summary>
    public TBuilder AddToScrollsRequirements(params CraftRequirements[] scrollsRequirements)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ScrollsRequirements = bp.m_ScrollsRequirements ?? new CraftRequirements[0];
          bp.m_ScrollsRequirements = CommonTool.Append(bp.m_ScrollsRequirements, scrollsRequirements);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="CraftRoot.m_ScrollsRequirements"/>
    /// </summary>
    public TBuilder RemoveFromScrollsRequirements(params CraftRequirements[] scrollsRequirements)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ScrollsRequirements is null) { return; }
          bp.m_ScrollsRequirements = bp.m_ScrollsRequirements.Where(val => !scrollsRequirements.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="CraftRoot.m_ScrollsRequirements"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromScrollsRequirements(Func<CraftRequirements, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ScrollsRequirements is null) { return; }
          bp.m_ScrollsRequirements = bp.m_ScrollsRequirements.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="CraftRoot.m_ScrollsRequirements"/>
    /// </summary>
    public TBuilder ClearScrollsRequirements()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ScrollsRequirements = new CraftRequirements[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="CraftRoot.m_ScrollsRequirements"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyScrollsRequirements(Action<CraftRequirements> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ScrollsRequirements is null) { return; }
          bp.m_ScrollsRequirements.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="CraftRoot.m_PotionsItems"/>
    /// </summary>
    ///
    /// <param name="potionsItems">
    /// <para>
    /// Blueprint of type BlueprintItemEquipmentUsable. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetPotionsItems(List<Blueprint<BlueprintItemEquipmentUsable, BlueprintItemEquipmentUsableReference>> potionsItems)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_PotionsItems = potionsItems?.Select(bp => bp.Reference)?.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="CraftRoot.m_PotionsItems"/>
    /// </summary>
    ///
    /// <param name="potionsItems">
    /// <para>
    /// Blueprint of type BlueprintItemEquipmentUsable. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToPotionsItems(params Blueprint<BlueprintItemEquipmentUsable, BlueprintItemEquipmentUsableReference>[] potionsItems)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_PotionsItems = bp.m_PotionsItems ?? new();
          bp.m_PotionsItems.AddRange(potionsItems.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="CraftRoot.m_PotionsItems"/>
    /// </summary>
    ///
    /// <param name="potionsItems">
    /// <para>
    /// Blueprint of type BlueprintItemEquipmentUsable. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromPotionsItems(params Blueprint<BlueprintItemEquipmentUsable, BlueprintItemEquipmentUsableReference>[] potionsItems)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_PotionsItems is null) { return; }
          bp.m_PotionsItems = bp.m_PotionsItems.Where(val => !potionsItems.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="CraftRoot.m_PotionsItems"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="potionsItems">
    /// <para>
    /// Blueprint of type BlueprintItemEquipmentUsable. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromPotionsItems(Func<BlueprintItemEquipmentUsableReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_PotionsItems is null) { return; }
          bp.m_PotionsItems = bp.m_PotionsItems.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="CraftRoot.m_PotionsItems"/>
    /// </summary>
    ///
    /// <param name="potionsItems">
    /// <para>
    /// Blueprint of type BlueprintItemEquipmentUsable. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearPotionsItems()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_PotionsItems = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="CraftRoot.m_PotionsItems"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="potionsItems">
    /// <para>
    /// Blueprint of type BlueprintItemEquipmentUsable. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyPotionsItems(Action<BlueprintItemEquipmentUsableReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_PotionsItems is null) { return; }
          bp.m_PotionsItems.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="CraftRoot.m_ScrollsItems"/>
    /// </summary>
    ///
    /// <param name="scrollsItems">
    /// <para>
    /// Blueprint of type BlueprintItemEquipmentUsable. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetScrollsItems(List<Blueprint<BlueprintItemEquipmentUsable, BlueprintItemEquipmentUsableReference>> scrollsItems)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ScrollsItems = scrollsItems?.Select(bp => bp.Reference)?.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="CraftRoot.m_ScrollsItems"/>
    /// </summary>
    ///
    /// <param name="scrollsItems">
    /// <para>
    /// Blueprint of type BlueprintItemEquipmentUsable. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToScrollsItems(params Blueprint<BlueprintItemEquipmentUsable, BlueprintItemEquipmentUsableReference>[] scrollsItems)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ScrollsItems = bp.m_ScrollsItems ?? new();
          bp.m_ScrollsItems.AddRange(scrollsItems.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="CraftRoot.m_ScrollsItems"/>
    /// </summary>
    ///
    /// <param name="scrollsItems">
    /// <para>
    /// Blueprint of type BlueprintItemEquipmentUsable. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromScrollsItems(params Blueprint<BlueprintItemEquipmentUsable, BlueprintItemEquipmentUsableReference>[] scrollsItems)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ScrollsItems is null) { return; }
          bp.m_ScrollsItems = bp.m_ScrollsItems.Where(val => !scrollsItems.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="CraftRoot.m_ScrollsItems"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="scrollsItems">
    /// <para>
    /// Blueprint of type BlueprintItemEquipmentUsable. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromScrollsItems(Func<BlueprintItemEquipmentUsableReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ScrollsItems is null) { return; }
          bp.m_ScrollsItems = bp.m_ScrollsItems.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="CraftRoot.m_ScrollsItems"/>
    /// </summary>
    ///
    /// <param name="scrollsItems">
    /// <para>
    /// Blueprint of type BlueprintItemEquipmentUsable. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearScrollsItems()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ScrollsItems = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="CraftRoot.m_ScrollsItems"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="scrollsItems">
    /// <para>
    /// Blueprint of type BlueprintItemEquipmentUsable. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyScrollsItems(Action<BlueprintItemEquipmentUsableReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ScrollsItems is null) { return; }
          bp.m_ScrollsItems.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="CraftRoot.m_IngredientTable"/>
    /// </summary>
    public TBuilder SetIngredientTable(IngredientTable ingredientTable)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(ingredientTable);
          bp.m_IngredientTable = ingredientTable;
        });
    }

    /// <summary>
    /// Modifies <see cref="CraftRoot.m_IngredientTable"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIngredientTable(Action<IngredientTable> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_IngredientTable is null) { return; }
          action.Invoke(bp.m_IngredientTable);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="CraftRoot.m_CollectingRoot"/>
    /// </summary>
    public TBuilder SetCollectingRoot(CollectIngredientRoot collectingRoot)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(collectingRoot);
          bp.m_CollectingRoot = collectingRoot;
        });
    }

    /// <summary>
    /// Modifies <see cref="CraftRoot.m_CollectingRoot"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCollectingRoot(Action<CollectIngredientRoot> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CollectingRoot is null) { return; }
          action.Invoke(bp.m_CollectingRoot);
        });
    }
  }
}
