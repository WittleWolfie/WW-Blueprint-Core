using BlueprintCore.Utils;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Dungeon.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Loot
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintUnitLoot"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUnitLoot))]
  public abstract class BaseUnitLootConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintUnitLoot
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseUnitLootConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintUnitLoot.m_Dummy"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetDummy(BlueprintUnitLoot.Dummy value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_Dummy = value);
    }

    /// <summary>
    /// Adds <see cref="DungeonVendorItemsComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DungeonVendorItemsComponent))]
    public TBuilder AddDungeonVendorItemsComponent(
        bool BigTable,
        int MinCR,
        int Count)
    {
      
      var component =  new DungeonVendorItemsComponent();
      component.BigTable = BigTable;
      component.MinCR = MinCR;
      component.Count = Count;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LootItemsPackFixed"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LootItemsPackFixed))]
    public TBuilder AddLootItemsPackFixed(
        LootItem m_Item,
        int m_Count)
    {
      ValidateParam(m_Item);
      
      var component =  new LootItemsPackFixed();
      component.m_Item = m_Item;
      component.m_Count = m_Count;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LootItemsPackVariable"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LootItemsPackVariable))]
    public TBuilder AddLootItemsPackVariable(
        LootItem m_Item,
        int m_CountFrom,
        int m_CountTo)
    {
      ValidateParam(m_Item);
      
      var component =  new LootItemsPackVariable();
      component.m_Item = m_Item;
      component.m_CountFrom = m_CountFrom;
      component.m_CountTo = m_CountTo;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LootRandomItem"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LootRandomItem))]
    public TBuilder AddLootRandomItem(
        LootItemAndWeight[] m_Items)
    {
      foreach (var item in m_Items)
      {
        ValidateParam(item);
      }
      
      var component =  new LootRandomItem();
      component.m_Items = m_Items;
      return AddComponent(component);
    }
  }

  /// <summary>Configurator for <see cref="BlueprintUnitLoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUnitLoot))]
  public class UnitLootConfigurator : BaseBlueprintConfigurator<BlueprintUnitLoot, UnitLootConfigurator>
  {
     private UnitLootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnitLootConfigurator For(string name)
    {
      return new UnitLootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static UnitLootConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintUnitLoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnitLootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintUnitLoot>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnitLoot.m_Dummy"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitLootConfigurator SetDummy(BlueprintUnitLoot.Dummy value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_Dummy = value);
    }

    /// <summary>
    /// Adds <see cref="DungeonVendorItemsComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DungeonVendorItemsComponent))]
    public UnitLootConfigurator AddDungeonVendorItemsComponent(
        bool BigTable,
        int MinCR,
        int Count)
    {
      
      var component =  new DungeonVendorItemsComponent();
      component.BigTable = BigTable;
      component.MinCR = MinCR;
      component.Count = Count;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LootItemsPackFixed"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LootItemsPackFixed))]
    public UnitLootConfigurator AddLootItemsPackFixed(
        LootItem m_Item,
        int m_Count)
    {
      ValidateParam(m_Item);
      
      var component =  new LootItemsPackFixed();
      component.m_Item = m_Item;
      component.m_Count = m_Count;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LootItemsPackVariable"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LootItemsPackVariable))]
    public UnitLootConfigurator AddLootItemsPackVariable(
        LootItem m_Item,
        int m_CountFrom,
        int m_CountTo)
    {
      ValidateParam(m_Item);
      
      var component =  new LootItemsPackVariable();
      component.m_Item = m_Item;
      component.m_CountFrom = m_CountFrom;
      component.m_CountTo = m_CountTo;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LootRandomItem"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LootRandomItem))]
    public UnitLootConfigurator AddLootRandomItem(
        LootItemAndWeight[] m_Items)
    {
      foreach (var item in m_Items)
      {
        ValidateParam(item);
      }
      
      var component =  new LootRandomItem();
      component.m_Items = m_Items;
      return AddComponent(component);
    }
  }
}
