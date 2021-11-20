using BlueprintCore.Blueprints.Configurators.Loot;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items;

namespace BlueprintCore.Blueprints.Configurators.Items
{
  /// <summary>
  /// Configurator for <see cref="BlueprintSharedVendorTable"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintSharedVendorTable))]
  public class SharedVendorTableConfigurator : BaseUnitLootConfigurator<BlueprintSharedVendorTable, SharedVendorTableConfigurator>
  {
    private SharedVendorTableConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SharedVendorTableConfigurator For(string name)
    {
      return new SharedVendorTableConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static SharedVendorTableConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintSharedVendorTable>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SharedVendorTableConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintSharedVendorTable>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSharedVendorTable.AutoIdentifyAllItems"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SharedVendorTableConfigurator SetAutoIdentifyAllItems(bool autoIdentifyAllItems)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AutoIdentifyAllItems = autoIdentifyAllItems;
          });
    }
  }
}
