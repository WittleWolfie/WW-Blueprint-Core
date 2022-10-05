//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ResourceLinks;
using System;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="UnitAnimationActionSubstitution"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseUnitAnimationActionSubstitutionConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : UnitAnimationActionSubstitution
    where TBuilder : BaseUnitAnimationActionSubstitutionConfigurator<T, TBuilder>
  {
    protected BaseUnitAnimationActionSubstitutionConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<UnitAnimationActionSubstitution>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.ChangeFrom = copyFrom.ChangeFrom;
          bp.ChangeTo = copyFrom.ChangeTo;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitAnimationActionSubstitution.ChangeFrom"/>
    /// </summary>
    public TBuilder SetChangeFrom(UnitAnimationActionLink changeFrom)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(changeFrom);
          bp.ChangeFrom = changeFrom;
        });
    }

    /// <summary>
    /// Modifies <see cref="UnitAnimationActionSubstitution.ChangeFrom"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyChangeFrom(Action<UnitAnimationActionLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ChangeFrom is null) { return; }
          action.Invoke(bp.ChangeFrom);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="UnitAnimationActionSubstitution.ChangeTo"/>
    /// </summary>
    public TBuilder SetChangeTo(UnitAnimationActionLink changeTo)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(changeTo);
          bp.ChangeTo = changeTo;
        });
    }

    /// <summary>
    /// Modifies <see cref="UnitAnimationActionSubstitution.ChangeTo"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyChangeTo(Action<UnitAnimationActionLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ChangeTo is null) { return; }
          action.Invoke(bp.ChangeTo);
        });
    }
  }
}
