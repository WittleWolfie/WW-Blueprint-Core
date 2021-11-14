using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>Configurator for <see cref="BlueprintRace"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintRace))]
  public class RaceConfigurator : BaseFeatureConfigurator<BlueprintRace, RaceConfigurator>
  {
     private RaceConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static RaceConfigurator For(string name)
    {
      return new RaceConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static RaceConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintRace>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static RaceConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintRace>(name, assetId);
      return For(name);
    }
  }
}
