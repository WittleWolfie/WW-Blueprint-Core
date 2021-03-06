//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;

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
