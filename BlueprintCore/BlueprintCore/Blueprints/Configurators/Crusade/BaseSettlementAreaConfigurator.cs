//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.Area;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Crusade;
using System;

namespace BlueprintCore.Blueprints.Configurators.Crusade
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="SettlementBlueprintArea"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseSettlementAreaConfigurator<T, TBuilder>
    : BaseAreaConfigurator<T, TBuilder>
    where T : SettlementBlueprintArea
    where TBuilder : BaseSettlementAreaConfigurator<T, TBuilder>
  {
    protected BaseSettlementAreaConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<SettlementBlueprintArea>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    return Self;
    }
  }
}
