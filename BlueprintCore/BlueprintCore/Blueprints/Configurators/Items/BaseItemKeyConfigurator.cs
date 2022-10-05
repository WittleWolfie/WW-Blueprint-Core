//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using System;

namespace BlueprintCore.Blueprints.Configurators.Items
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemKey"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseItemKeyConfigurator<T, TBuilder>
    : BaseItemConfigurator<T, TBuilder>
    where T : BlueprintItemKey
    where TBuilder : BaseItemKeyConfigurator<T, TBuilder>
  {
    protected BaseItemKeyConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintItemKey>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    return Self;
    }
  }
}
