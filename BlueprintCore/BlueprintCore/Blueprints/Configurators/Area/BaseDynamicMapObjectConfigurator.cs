//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using System;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintDynamicMapObject"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDynamicMapObjectConfigurator<T, TBuilder>
    : BaseMapObjectConfigurator<T, TBuilder>
    where T : BlueprintDynamicMapObject
    where TBuilder : BaseDynamicMapObjectConfigurator<T, TBuilder>
  {
    protected BaseDynamicMapObjectConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintDynamicMapObject>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    return Self;
    }
  }
}
