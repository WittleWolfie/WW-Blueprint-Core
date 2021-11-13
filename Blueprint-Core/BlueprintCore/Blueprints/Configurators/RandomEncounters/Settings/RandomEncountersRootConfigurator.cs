using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.RandomEncounters.Settings;
namespace BlueprintCore.Blueprints.Configurators.RandomEncounters.Settings
{
  /// <summary>Configurator for <see cref="RandomEncountersRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(RandomEncountersRoot))]
  public class RandomEncountersRootConfigurator : BaseBlueprintConfigurator<RandomEncountersRoot, RandomEncountersRootConfigurator>
  {
     private RandomEncountersRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static RandomEncountersRootConfigurator For(string name)
    {
      return new RandomEncountersRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static RandomEncountersRootConfigurator New(string name)
    {
      BlueprintTool.Create<RandomEncountersRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static RandomEncountersRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<RandomEncountersRoot>(name, assetId);
      return For(name);
    }

  }
}
