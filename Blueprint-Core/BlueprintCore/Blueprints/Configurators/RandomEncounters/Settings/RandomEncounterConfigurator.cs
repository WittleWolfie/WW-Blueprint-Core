using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.RandomEncounters.Settings;

namespace BlueprintCore.Blueprints.Configurators.RandomEncounters.Settings
{
  /// <summary>Configurator for <see cref="BlueprintRandomEncounter"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintRandomEncounter))]
  public class RandomEncounterConfigurator : BaseBlueprintConfigurator<BlueprintRandomEncounter, RandomEncounterConfigurator>
  {
     private RandomEncounterConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static RandomEncounterConfigurator For(string name)
    {
      return new RandomEncounterConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static RandomEncounterConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintRandomEncounter>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static RandomEncounterConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintRandomEncounter>(name, assetId);
      return For(name);
    }
  }
}
