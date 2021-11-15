using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Corruption;

namespace BlueprintCore.Blueprints.Configurators.Corruption
{
  /// <summary>Configurator for <see cref="BlueprintCorruptionRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCorruptionRoot))]
  public class CorruptionRootConfigurator : BaseBlueprintConfigurator<BlueprintCorruptionRoot, CorruptionRootConfigurator>
  {
     private CorruptionRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CorruptionRootConfigurator For(string name)
    {
      return new CorruptionRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CorruptionRootConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintCorruptionRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CorruptionRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintCorruptionRoot>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCorruptionRoot.m_Progression"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CorruptionRootConfigurator SetProgression(CorruptionProgression value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_Progression = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCorruptionRoot.m_DefaultCorruptionGrowth"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CorruptionRootConfigurator SetDefaultCorruptionGrowth(int value)
    {
      return OnConfigureInternal(bp => bp.m_DefaultCorruptionGrowth = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCorruptionRoot.m_DSSuccessCoefficient"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CorruptionRootConfigurator SetDSSuccessCoefficient(float value)
    {
      return OnConfigureInternal(bp => bp.m_DSSuccessCoefficient = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCorruptionRoot.m_DSCriticalFailCoefficient"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CorruptionRootConfigurator SetDSCriticalFailCoefficient(float value)
    {
      return OnConfigureInternal(bp => bp.m_DSCriticalFailCoefficient = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCorruptionRoot.m_GlobalMapBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintBuff"/></param>
    [Generated]
    public CorruptionRootConfigurator SetGlobalMapBuff(string value)
    {
      return OnConfigureInternal(bp => bp.m_GlobalMapBuff = BlueprintTool.GetRef<BlueprintBuffReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintCorruptionRoot.m_GlobalMapBuffDurationMinutes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CorruptionRootConfigurator SetGlobalMapBuffDurationMinutes(int value)
    {
      return OnConfigureInternal(bp => bp.m_GlobalMapBuffDurationMinutes = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCorruptionRoot.m_SpeedModifierDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CorruptionRootConfigurator SetSpeedModifierDC(int value)
    {
      return OnConfigureInternal(bp => bp.m_SpeedModifierDC = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCorruptionRoot.m_SpeedModifierDCIncrement"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CorruptionRootConfigurator SetSpeedModifierDCIncrement(int value)
    {
      return OnConfigureInternal(bp => bp.m_SpeedModifierDCIncrement = value);
    }
  }
}
