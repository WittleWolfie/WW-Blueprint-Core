using BlueprintCore.Utils;
using Kingmaker.Blueprints.Root;

namespace BlueprintCore.Blueprints.Configurators.Root
{
  /// <summary>
  /// Configurator for <see cref="CutscenesRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(CutscenesRoot))]
  public class CutscenesRootConfigurator : BaseBlueprintConfigurator<CutscenesRoot, CutscenesRootConfigurator>
  {
    private CutscenesRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CutscenesRootConfigurator For(string name)
    {
      return new CutscenesRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CutscenesRootConfigurator New(string name)
    {
      BlueprintTool.Create<CutscenesRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CutscenesRootConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<CutscenesRoot>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="CutscenesRoot.m_FadeScreenOnSkip"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CutscenesRootConfigurator SetFadeScreenOnSkip(bool fadeScreenOnSkip)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_FadeScreenOnSkip = fadeScreenOnSkip;
          });
    }

    /// <summary>
    /// Sets <see cref="CutscenesRoot.m_TimeScaleOnSkip"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CutscenesRootConfigurator SetTimeScaleOnSkip(float timeScaleOnSkip)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_TimeScaleOnSkip = timeScaleOnSkip;
          });
    }
  }
}
