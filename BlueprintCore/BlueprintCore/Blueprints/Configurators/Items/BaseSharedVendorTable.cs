//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.Loot;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using System;

namespace BlueprintCore.Blueprints.Configurators.Items
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintSharedVendorTable"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseSharedVendorTableConfigurator<T, TBuilder>
    : BaseUnitLootConfigurator<T, TBuilder>
    where T : BlueprintSharedVendorTable
    where TBuilder : BaseSharedVendorTableConfigurator<T, TBuilder>
  {
    protected BaseSharedVendorTableConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSharedVendorTable.AutoIdentifyAllItems"/>
    /// </summary>
    public TBuilder SetAutoIdentifyAllItems(bool autoIdentifyAllItems = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AutoIdentifyAllItems = autoIdentifyAllItems;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSharedVendorTable.AutoIdentifyAllItems"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAutoIdentifyAllItems(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.AutoIdentifyAllItems);
        });
    }
  }
}
