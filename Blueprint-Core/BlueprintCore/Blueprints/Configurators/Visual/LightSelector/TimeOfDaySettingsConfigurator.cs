using BlueprintCore.Utils;
using Kingmaker.Visual.LightSelector;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Visual.LightSelector
{
  /// <summary>Configurator for <see cref="BlueprintTimeOfDaySettings"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintTimeOfDaySettings))]
  public class TimeOfDaySettingsConfigurator : BaseBlueprintConfigurator<BlueprintTimeOfDaySettings, TimeOfDaySettingsConfigurator>
  {
     private TimeOfDaySettingsConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TimeOfDaySettingsConfigurator For(string name)
    {
      return new TimeOfDaySettingsConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static TimeOfDaySettingsConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintTimeOfDaySettings>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TimeOfDaySettingsConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintTimeOfDaySettings>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTimeOfDaySettings.Morning"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TimeOfDaySettingsConfigurator SetMorning(GameObject value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Morning = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTimeOfDaySettings.Day"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TimeOfDaySettingsConfigurator SetDay(GameObject value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Day = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTimeOfDaySettings.Evening"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TimeOfDaySettingsConfigurator SetEvening(GameObject value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Evening = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTimeOfDaySettings.Night"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TimeOfDaySettingsConfigurator SetNight(GameObject value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Night = value);
    }
  }
}
