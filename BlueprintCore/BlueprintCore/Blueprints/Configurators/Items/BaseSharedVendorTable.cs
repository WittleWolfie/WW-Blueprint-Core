//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.Loot;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;

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
    protected BaseSharedVendorTableConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }
  }
}
