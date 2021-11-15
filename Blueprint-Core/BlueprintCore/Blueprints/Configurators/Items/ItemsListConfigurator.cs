using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Items
{
  /// <summary>Configurator for <see cref="BlueprintItemsList"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemsList))]
  public class ItemsListConfigurator : BaseBlueprintConfigurator<BlueprintItemsList, ItemsListConfigurator>
  {
     private ItemsListConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemsListConfigurator For(string name)
    {
      return new ItemsListConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ItemsListConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintItemsList>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemsListConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintItemsList>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItemsList.m_Items"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintItem"/></param>
    [Generated]
    public ItemsListConfigurator AddToItems(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Items = CommonTool.Append(bp.m_Items, values.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItemsList.m_Items"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintItem"/></param>
    [Generated]
    public ItemsListConfigurator RemoveFromItems(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name));
            bp.m_Items =
                bp.m_Items
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }
  }
}
