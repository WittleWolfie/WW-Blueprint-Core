using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Visual.LightSelector;

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
  }
}
