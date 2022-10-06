//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Dungeon.Blueprints;
using System;

namespace BlueprintCore.Blueprints.Configurators.Loot
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintUnitLoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseUnitLootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintUnitLoot
    where TBuilder : BaseUnitLootConfigurator<T, TBuilder>
  {
    protected BaseUnitLootConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintUnitLoot>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Dummy = copyFrom.m_Dummy;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintUnitLoot>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Dummy = copyFrom.m_Dummy;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnitLoot.m_Dummy"/>
    /// </summary>
    public TBuilder SetDummy(BlueprintUnitLoot.Dummy dummy)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(dummy);
          bp.m_Dummy = dummy;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnitLoot.m_Dummy"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDummy(Action<BlueprintUnitLoot.Dummy> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Dummy is null) { return; }
          action.Invoke(bp.m_Dummy);
        });
    }

    /// <summary>
    /// Adds <see cref="DungeonVendorItemsComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>RogueLike_DragonVendorTable</term><description>08e090bb2038e3d47be56d8752d5dcaf</description></item>
    /// <item><term>RogueLike_NPCVendorTable</term><description>a6bae621a7bd96b4fb3c1511cd2f9fac</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddDungeonVendorItemsComponent(
        bool? bigTable = null,
        int? count = null,
        int? minCR = null)
    {
      var component = new DungeonVendorItemsComponent();
      component.BigTable = bigTable ?? component.BigTable;
      component.Count = count ?? component.Count;
      component.MinCR = minCR ?? component.MinCR;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LootItemsPackFixed"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Aminas_Chapter5VendorTable</term><description>8b2dae3f8da96f640995594f6bcf7a29</description></item>
    /// <item><term>DLC3_VendorTableShields</term><description>f0164e4ab9ef4a4da8d86a0c0e0bc45f</description></item>
    /// <item><term>WyvernMeatLoot</term><description>abe034c3a49a1854496fa6fe1f439114</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddLootItemsPackFixed(
        int? count = null,
        LootItem? item = null)
    {
      var component = new LootItemsPackFixed();
      component.m_Count = count ?? component.m_Count;
      Validate(item);
      component.m_Item = item ?? component.m_Item;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LootItemsPackFixedAndNotInPlayerInitialInventory"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BlacksmithWeapon_DLC1VendorTable</term><description>7d73798a7e624afa8340916c7461cf12</description></item>
    /// <item><term>HilorArmor_DLC1VendorTable</term><description>84fb4303222b413eb42daeb8d98a30dd</description></item>
    /// <item><term>Tailor_DLC1VendorTable1</term><description>301b28b1b3924e55989c41288048e4d2</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddLootItemsPackFixedAndNotInPlayerInitialInventory(
        int? count = null,
        LootItem? item = null)
    {
      var component = new LootItemsPackFixedAndNotInPlayerInitialInventory();
      component.m_Count = count ?? component.m_Count;
      Validate(item);
      component.m_Item = item ?? component.m_Item;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LootItemsPackVariable"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Coins10</term><description>182247c9a4bfb9244b86cdc80b7d61da</description></item>
    /// <item><term>Coins30</term><description>3ea3fbb492dbc374f8390b1eabd47f89</description></item>
    /// <item><term>HydraEyeLoot</term><description>66496a2143a9bce468d3fffce09f3587</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddLootItemsPackVariable(
        int? countFrom = null,
        int? countTo = null,
        LootItem? item = null)
    {
      var component = new LootItemsPackVariable();
      component.m_CountFrom = countFrom ?? component.m_CountFrom;
      component.m_CountTo = countTo ?? component.m_CountTo;
      Validate(item);
      component.m_Item = item ?? component.m_Item;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LootRandomItem"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CultistsLootClericScrolls1</term><description>668d29eefe4b614459ef48abad5efeb0</description></item>
    /// <item><term>JewelryCR6</term><description>c8d223433f2dbfc4080569ea7f4792db</description></item>
    /// <item><term>TrashLootStandardWeaponsAndArmor</term><description>6414d0eccbb66364bb1ef9f57599fc5c</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddLootRandomItem(params LootItemAndWeight[] items)
    {
      var component = new LootRandomItem();
      Validate(items);
      component.m_Items = items;
      if (component.m_Items is null)
      {
        component.m_Items = new LootItemAndWeight[0];
      }
      return AddComponent(component);
    }
  }
}
