//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.Loot;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

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

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintSharedVendorTable>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.AutoIdentifyAllItems = copyFrom.AutoIdentifyAllItems;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintSharedVendorTable>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.AutoIdentifyAllItems = copyFrom.AutoIdentifyAllItems;
        });
    }

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
  }
}
