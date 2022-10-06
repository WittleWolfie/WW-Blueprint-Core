//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Weapons;
using System;

namespace BlueprintCore.Blueprints.Configurators.Items.Armors
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintShieldType"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseShieldTypeConfigurator<T, TBuilder>
    : BaseArmorTypeConfigurator<T, TBuilder>
    where T : BlueprintShieldType
    where TBuilder : BaseShieldTypeConfigurator<T, TBuilder>
  {
    protected BaseShieldTypeConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintShieldType>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_HandVisualParameters = copyFrom.m_HandVisualParameters;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintShieldType>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_HandVisualParameters = copyFrom.m_HandVisualParameters;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintShieldType.m_HandVisualParameters"/>
    /// </summary>
    public TBuilder SetHandVisualParameters(WeaponVisualParameters handVisualParameters)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(handVisualParameters);
          bp.m_HandVisualParameters = handVisualParameters;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintShieldType.m_HandVisualParameters"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHandVisualParameters(Action<WeaponVisualParameters> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_HandVisualParameters is null) { return; }
          action.Invoke(bp.m_HandVisualParameters);
        });
    }
  }
}
