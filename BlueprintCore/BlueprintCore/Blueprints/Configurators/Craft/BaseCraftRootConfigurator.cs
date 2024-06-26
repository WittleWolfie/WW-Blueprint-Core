//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
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
    protected BaseCraftRootConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<CraftRoot>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_CraftCostMultiplyer = copyFrom.m_CraftCostMultiplyer;
          bp.m_CostForCraftDay = copyFrom.m_CostForCraftDay;
          bp.m_BaseCraftedAbilityDC = copyFrom.m_BaseCraftedAbilityDC;
          bp.m_BaseCraftDC = copyFrom.m_BaseCraftDC;
          bp.m_PotionRequirements = copyFrom.m_PotionRequirements;
          bp.m_ScrollsRequirements = copyFrom.m_ScrollsRequirements;
          bp.m_PotionsItems = copyFrom.m_PotionsItems;
          bp.m_ScrollsItems = copyFrom.m_ScrollsItems;
          bp.m_IngredientTable = copyFrom.m_IngredientTable;
          bp.m_CollectingRoot = copyFrom.m_CollectingRoot;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<CraftRoot>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_CraftCostMultiplyer = copyFrom.m_CraftCostMultiplyer;
          bp.m_CostForCraftDay = copyFrom.m_CostForCraftDay;
          bp.m_BaseCraftedAbilityDC = copyFrom.m_BaseCraftedAbilityDC;
          bp.m_BaseCraftDC = copyFrom.m_BaseCraftDC;
          bp.m_PotionRequirements = copyFrom.m_PotionRequirements;
          bp.m_ScrollsRequirements = copyFrom.m_ScrollsRequirements;
          bp.m_PotionsItems = copyFrom.m_PotionsItems;
          bp.m_ScrollsItems = copyFrom.m_ScrollsItems;
          bp.m_IngredientTable = copyFrom.m_IngredientTable;
          bp.m_CollectingRoot = copyFrom.m_CollectingRoot;
        });
    }

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
    /// Sets the value of <see cref="CraftRoot.m_PotionRequirements"/>
    /// </summary>
    public TBuilder SetPotionRequirements(params CraftRequirements[] potionRequirements)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(potionRequirements);
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
          bp.m_PotionRequirements = bp.m_PotionRequirements.Where(e => !predicate(e)).ToArray();
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
    public TBuilder SetScrollsRequirements(params CraftRequirements[] scrollsRequirements)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(scrollsRequirements);
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
          bp.m_ScrollsRequirements = bp.m_ScrollsRequirements.Where(e => !predicate(e)).ToArray();
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetPotionsItems(params Blueprint<BlueprintItemEquipmentUsableReference>[] potionsItems)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_PotionsItems = potionsItems.Select(bp => bp.Reference).ToList();
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToPotionsItems(params Blueprint<BlueprintItemEquipmentUsableReference>[] potionsItems)
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromPotionsItems(params Blueprint<BlueprintItemEquipmentUsableReference>[] potionsItems)
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
    public TBuilder RemoveFromPotionsItems(Func<BlueprintItemEquipmentUsableReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_PotionsItems is null) { return; }
          bp.m_PotionsItems = bp.m_PotionsItems.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="CraftRoot.m_PotionsItems"/>
    /// </summary>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetScrollsItems(params Blueprint<BlueprintItemEquipmentUsableReference>[] scrollsItems)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ScrollsItems = scrollsItems.Select(bp => bp.Reference).ToList();
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToScrollsItems(params Blueprint<BlueprintItemEquipmentUsableReference>[] scrollsItems)
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromScrollsItems(params Blueprint<BlueprintItemEquipmentUsableReference>[] scrollsItems)
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
    public TBuilder RemoveFromScrollsItems(Func<BlueprintItemEquipmentUsableReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ScrollsItems is null) { return; }
          bp.m_ScrollsItems = bp.m_ScrollsItems.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="CraftRoot.m_ScrollsItems"/>
    /// </summary>
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

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_PotionRequirements is null)
      {
        Blueprint.m_PotionRequirements = new CraftRequirements[0];
      }
      if (Blueprint.m_ScrollsRequirements is null)
      {
        Blueprint.m_ScrollsRequirements = new CraftRequirements[0];
      }
      if (Blueprint.m_PotionsItems is null)
      {
        Blueprint.m_PotionsItems = new();
      }
      if (Blueprint.m_ScrollsItems is null)
      {
        Blueprint.m_ScrollsItems = new();
      }
    }
  }
}
