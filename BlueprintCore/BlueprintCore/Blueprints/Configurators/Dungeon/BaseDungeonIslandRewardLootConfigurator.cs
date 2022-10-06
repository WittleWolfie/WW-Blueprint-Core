//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintDungeonIslandRewardLoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDungeonIslandRewardLootConfigurator<T, TBuilder>
    : BaseDungeonIslandRewardConfigurator<T, TBuilder>
    where T : BlueprintDungeonIslandRewardLoot
    where TBuilder : BaseDungeonIslandRewardLootConfigurator<T, TBuilder>
  {
    protected BaseDungeonIslandRewardLootConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintDungeonIslandRewardLoot>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Container = copyFrom.m_Container;
          bp.Count = copyFrom.Count;
          bp.PriceMultiplierMin = copyFrom.PriceMultiplierMin;
          bp.PriceMultiplierMax = copyFrom.PriceMultiplierMax;
          bp.DoNotGiveDuplicates = copyFrom.DoNotGiveDuplicates;
          bp.RespectAreaCR = copyFrom.RespectAreaCR;
          bp.m_Items = copyFrom.m_Items;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintDungeonIslandRewardLoot>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Container = copyFrom.m_Container;
          bp.Count = copyFrom.Count;
          bp.PriceMultiplierMin = copyFrom.PriceMultiplierMin;
          bp.PriceMultiplierMax = copyFrom.PriceMultiplierMax;
          bp.DoNotGiveDuplicates = copyFrom.DoNotGiveDuplicates;
          bp.RespectAreaCR = copyFrom.RespectAreaCR;
          bp.m_Items = copyFrom.m_Items;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIslandRewardLoot.m_Container"/>
    /// </summary>
    ///
    /// <param name="container">
    /// <para>
    /// Blueprint of type BlueprintDynamicMapObject. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetContainer(Blueprint<BlueprintDynamicMapObjectReference> container)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Container = container?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonIslandRewardLoot.m_Container"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyContainer(Action<BlueprintDynamicMapObjectReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Container is null) { return; }
          action.Invoke(bp.m_Container);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIslandRewardLoot.Count"/>
    /// </summary>
    public TBuilder SetCount(int count)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Count = count;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIslandRewardLoot.PriceMultiplierMin"/>
    /// </summary>
    ///
    /// <param name="priceMultiplierMin">
    /// <para>
    /// Tooltip: Lowest price multiplier of a single item. Base price is the price of a whole chest for current area CR.
    /// </para>
    /// </param>
    public TBuilder SetPriceMultiplierMin(float priceMultiplierMin)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.PriceMultiplierMin = priceMultiplierMin;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIslandRewardLoot.PriceMultiplierMax"/>
    /// </summary>
    ///
    /// <param name="priceMultiplierMax">
    /// <para>
    /// Tooltip: Highest price multiplier of a single item. Base price is the price of a whole chest for current area CR.
    /// </para>
    /// </param>
    public TBuilder SetPriceMultiplierMax(float priceMultiplierMax)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.PriceMultiplierMax = priceMultiplierMax;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIslandRewardLoot.DoNotGiveDuplicates"/>
    /// </summary>
    public TBuilder SetDoNotGiveDuplicates(bool doNotGiveDuplicates = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotGiveDuplicates = doNotGiveDuplicates;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIslandRewardLoot.RespectAreaCR"/>
    /// </summary>
    public TBuilder SetRespectAreaCR(bool respectAreaCR = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RespectAreaCR = respectAreaCR;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonIslandRewardLoot.m_Items"/>
    /// </summary>
    ///
    /// <param name="items">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetItems(params Blueprint<BlueprintItemReference>[] items)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Items = items.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonIslandRewardLoot.m_Items"/>
    /// </summary>
    ///
    /// <param name="items">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToItems(params Blueprint<BlueprintItemReference>[] items)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Items = bp.m_Items ?? new BlueprintItemReference[0];
          bp.m_Items = CommonTool.Append(bp.m_Items, items.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonIslandRewardLoot.m_Items"/>
    /// </summary>
    ///
    /// <param name="items">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromItems(params Blueprint<BlueprintItemReference>[] items)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Items is null) { return; }
          bp.m_Items = bp.m_Items.Where(val => !items.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonIslandRewardLoot.m_Items"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromItems(Func<BlueprintItemReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Items is null) { return; }
          bp.m_Items = bp.m_Items.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonIslandRewardLoot.m_Items"/>
    /// </summary>
    public TBuilder ClearItems()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Items = new BlueprintItemReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonIslandRewardLoot.m_Items"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyItems(Action<BlueprintItemReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Items is null) { return; }
          bp.m_Items.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Container is null)
      {
        Blueprint.m_Container = BlueprintTool.GetRef<BlueprintDynamicMapObjectReference>(null);
      }
      if (Blueprint.m_Items is null)
      {
        Blueprint.m_Items = new BlueprintItemReference[0];
      }
    }
  }
}
