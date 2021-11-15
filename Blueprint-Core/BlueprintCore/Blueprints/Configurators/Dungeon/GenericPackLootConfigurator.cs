using BlueprintCore.Utils;
using Kingmaker.Dungeon.Blueprints;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>Configurator for <see cref="BlueprintGenericPackLoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintGenericPackLoot))]
  public class GenericPackLootConfigurator : BaseBlueprintConfigurator<BlueprintGenericPackLoot, GenericPackLootConfigurator>
  {
     private GenericPackLootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static GenericPackLootConfigurator For(string name)
    {
      return new GenericPackLootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static GenericPackLootConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintGenericPackLoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static GenericPackLootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintGenericPackLoot>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGenericPackLoot.Entries"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GenericPackLootConfigurator AddToEntries(params BlueprintGenericPackLoot.EntryType[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Entries = CommonTool.Append(bp.Entries, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintGenericPackLoot.Entries"/> (Auto Generated)
    /// </summary>
    [Generated]
    public GenericPackLootConfigurator RemoveFromEntries(params BlueprintGenericPackLoot.EntryType[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Entries = bp.Entries.Where(item => !values.Contains(item)).ToArray());
    }
  }
}
