//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;
using System;

namespace BlueprintCore.Blueprints.Configurators.Root
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="CutscenesRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCutscenesRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : CutscenesRoot
    where TBuilder : BaseCutscenesRootConfigurator<T, TBuilder>
  {
    protected BaseCutscenesRootConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<CutscenesRoot>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_FadeScreenOnSkip = copyFrom.m_FadeScreenOnSkip;
          bp.m_TimeScaleOnSkip = copyFrom.m_TimeScaleOnSkip;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="CutscenesRoot.m_FadeScreenOnSkip"/>
    /// </summary>
    public TBuilder SetFadeScreenOnSkip(bool fadeScreenOnSkip = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_FadeScreenOnSkip = fadeScreenOnSkip;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="CutscenesRoot.m_TimeScaleOnSkip"/>
    /// </summary>
    public TBuilder SetTimeScaleOnSkip(float timeScaleOnSkip)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TimeScaleOnSkip = timeScaleOnSkip;
        });
    }
  }
}
