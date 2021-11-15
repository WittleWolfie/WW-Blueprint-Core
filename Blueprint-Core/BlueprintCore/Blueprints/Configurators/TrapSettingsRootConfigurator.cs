using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>Configurator for <see cref="BlueprintTrapSettingsRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintTrapSettingsRoot))]
  public class TrapSettingsRootConfigurator : BaseBlueprintConfigurator<BlueprintTrapSettingsRoot, TrapSettingsRootConfigurator>
  {
     private TrapSettingsRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TrapSettingsRootConfigurator For(string name)
    {
      return new TrapSettingsRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static TrapSettingsRootConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintTrapSettingsRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TrapSettingsRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintTrapSettingsRoot>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrapSettingsRoot.m_DefaultPerceptionRadius"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapSettingsRootConfigurator SetDefaultPerceptionRadius(float value)
    {
      return OnConfigureInternal(bp => bp.m_DefaultPerceptionRadius = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrapSettingsRoot.m_DisableDCMargin"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapSettingsRootConfigurator SetDisableDCMargin(int value)
    {
      return OnConfigureInternal(bp => bp.m_DisableDCMargin = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTrapSettingsRoot.m_Settings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintTrapSettings"/></param>
    [Generated]
    public TrapSettingsRootConfigurator AddToSettings(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Settings = CommonTool.Append(bp.m_Settings, values.Select(name => BlueprintTool.GetRef<BlueprintTrapSettingsReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTrapSettingsRoot.m_Settings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintTrapSettings"/></param>
    [Generated]
    public TrapSettingsRootConfigurator RemoveFromSettings(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintTrapSettingsReference>(name));
            bp.m_Settings =
                bp.m_Settings
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrapSettingsRoot.EasyDisableDCDelta"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapSettingsRootConfigurator SetEasyDisableDCDelta(int value)
    {
      return OnConfigureInternal(bp => bp.EasyDisableDCDelta = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTrapSettingsRoot.HardDisableDCDelta"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TrapSettingsRootConfigurator SetHardDisableDCDelta(int value)
    {
      return OnConfigureInternal(bp => bp.HardDisableDCDelta = value);
    }
  }
}
