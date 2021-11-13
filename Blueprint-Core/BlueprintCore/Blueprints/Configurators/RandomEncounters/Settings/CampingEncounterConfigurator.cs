using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.RandomEncounters.Settings;
namespace BlueprintCore.Blueprints.Configurators.RandomEncounters.Settings
{
  /// <summary>Configurator for <see cref="BlueprintCampingEncounter"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCampingEncounter))]
  public class CampingEncounterConfigurator : BaseBlueprintConfigurator<BlueprintCampingEncounter, CampingEncounterConfigurator>
  {
     private CampingEncounterConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CampingEncounterConfigurator For(string name)
    {
      return new CampingEncounterConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CampingEncounterConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintCampingEncounter>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CampingEncounterConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintCampingEncounter>(name, assetId);
      return For(name);
    }

  }
}
