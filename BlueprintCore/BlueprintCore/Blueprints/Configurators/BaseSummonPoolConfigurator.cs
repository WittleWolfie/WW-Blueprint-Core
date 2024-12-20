//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintSummonPool"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseSummonPoolConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintSummonPool
    where TBuilder : BaseSummonPoolConfigurator<T, TBuilder>
  {
    protected BaseSummonPoolConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintSummonPool>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Limit = copyFrom.Limit;
          bp.DoNotRemoveDeadUnits = copyFrom.DoNotRemoveDeadUnits;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintSummonPool>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Limit = copyFrom.Limit;
          bp.DoNotRemoveDeadUnits = copyFrom.DoNotRemoveDeadUnits;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSummonPool.Limit"/>
    /// </summary>
    public TBuilder SetLimit(int limit)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Limit = limit;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSummonPool.DoNotRemoveDeadUnits"/>
    /// </summary>
    public TBuilder SetDoNotRemoveDeadUnits(bool doNotRemoveDeadUnits = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DoNotRemoveDeadUnits = doNotRemoveDeadUnits;
        });
    }
  }
}
