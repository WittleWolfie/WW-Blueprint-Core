using BlueprintCore.Blueprints.Configurators.Area;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Enums;
using Kingmaker.RandomEncounters.Settings;
namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintArea"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArea))]
  public abstract class BaseAreaConfigurator<T, TBuilder>
      : BaseAreaPartConfigurator<T, TBuilder>
      where T : BlueprintArea
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseAreaConfigurator(string name) : base(name) { }



    /// <summary>
    /// Adds <see cref="CombatRandomEncounterAreaSettings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_DefaultEnterPoint"><see cref="BlueprintAreaEnterPoint"/></param>
    /// <param name="m_GoodAvoidanceEnterPoint"><see cref="BlueprintAreaEnterPoint"/></param>
    [Generated]
    [Implements(typeof(CombatRandomEncounterAreaSettings))]
    public TBuilder AddCombatRandomEncounterAreaSettings(
        string m_DefaultEnterPoint,
        string m_GoodAvoidanceEnterPoint,
        GlobalMapZone[] AllowedNaturalSettings,
        CombatRandomEncounterAreaSettings.Formation[] Formations)
    {
      foreach (var item in AllowedNaturalSettings)
      {
        ValidateParam(item);
      }
      foreach (var item in Formations)
      {
        ValidateParam(item);
      }
      
      var component =  new CombatRandomEncounterAreaSettings();
      component.m_DefaultEnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(m_DefaultEnterPoint);
      component.m_GoodAvoidanceEnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(m_GoodAvoidanceEnterPoint);
      component.AllowedNaturalSettings = AllowedNaturalSettings;
      component.Formations = Formations;
      return AddComponent(component);
    }  }

  /// <summary>Configurator for <see cref="BlueprintArea"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArea))]
  public class AreaConfigurator : BaseAreaPartConfigurator<BlueprintArea, AreaConfigurator>
  {
     private AreaConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AreaConfigurator For(string name)
    {
      return new AreaConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AreaConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintArea>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AreaConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintArea>(name, assetId);
      return For(name);
    }



    /// <summary>
    /// Adds <see cref="CombatRandomEncounterAreaSettings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_DefaultEnterPoint"><see cref="BlueprintAreaEnterPoint"/></param>
    /// <param name="m_GoodAvoidanceEnterPoint"><see cref="BlueprintAreaEnterPoint"/></param>
    [Generated]
    [Implements(typeof(CombatRandomEncounterAreaSettings))]
    public AreaConfigurator AddCombatRandomEncounterAreaSettings(
        string m_DefaultEnterPoint,
        string m_GoodAvoidanceEnterPoint,
        GlobalMapZone[] AllowedNaturalSettings,
        CombatRandomEncounterAreaSettings.Formation[] Formations)
    {
      foreach (var item in AllowedNaturalSettings)
      {
        ValidateParam(item);
      }
      foreach (var item in Formations)
      {
        ValidateParam(item);
      }
      
      var component =  new CombatRandomEncounterAreaSettings();
      component.m_DefaultEnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(m_DefaultEnterPoint);
      component.m_GoodAvoidanceEnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(m_GoodAvoidanceEnterPoint);
      component.AllowedNaturalSettings = AllowedNaturalSettings;
      component.Formations = Formations;
      return AddComponent(component);
    }  }
}
