//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.AI;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="ArmorTypeConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseArmorTypeConsiderationConfigurator<T, TBuilder>
    : BaseConsiderationConfigurator<T, TBuilder>
    where T : ArmorTypeConsideration
    where TBuilder : BaseArmorTypeConsiderationConfigurator<T, TBuilder>
  {
    protected BaseArmorTypeConsiderationConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<ArmorTypeConsideration>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.LightArmorScore = copyFrom.LightArmorScore;
          bp.HeavyArmorScore = copyFrom.HeavyArmorScore;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<ArmorTypeConsideration>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.LightArmorScore = copyFrom.LightArmorScore;
          bp.HeavyArmorScore = copyFrom.HeavyArmorScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmorTypeConsideration.LightArmorScore"/>
    /// </summary>
    ///
    /// <param name="lightArmorScore">
    /// <para>
    /// Tooltip: Light or no armor
    /// </para>
    /// </param>
    public TBuilder SetLightArmorScore(float lightArmorScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LightArmorScore = lightArmorScore;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="ArmorTypeConsideration.HeavyArmorScore"/>
    /// </summary>
    ///
    /// <param name="heavyArmorScore">
    /// <para>
    /// Tooltip: Heavy or medium armor
    /// </para>
    /// </param>
    public TBuilder SetHeavyArmorScore(float heavyArmorScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HeavyArmorScore = heavyArmorScore;
        });
    }
  }
}
