//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Enums;
using Kingmaker.RandomEncounters.Settings;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAreaEnterPoint"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAreaEnterPointConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintAreaEnterPoint
    where TBuilder : BaseAreaEnterPointConfigurator<T, TBuilder>
  {
    protected BaseAreaEnterPointConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Adds <see cref="AllowOnZoneSettings"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Trader_Desert</term><description>fbe119150585526469ae85a3aff8094d</description></item>
    /// <item><term>Trader_Karelia</term><description>70e1898c5d62e2b47bba99330f447660</description></item>
    /// <item><term>Trader_Winter</term><description>ac97038913a452d4789e11f4c3eedc66</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddAllowOnZoneSettings(
        GlobalMapZone[]? allowedNaturalSettings = null)
    {
      var component = new AllowOnZoneSettings();
      component.m_AllowedNaturalSettings = allowedNaturalSettings ?? component.m_AllowedNaturalSettings;
      if (component.m_AllowedNaturalSettings is null)
      {
        component.m_AllowedNaturalSettings = new GlobalMapZone[0];
      }
      return AddComponent(component);
    }
  }
}
