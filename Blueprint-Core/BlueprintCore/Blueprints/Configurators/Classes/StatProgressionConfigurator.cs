using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>Configurator for <see cref="BlueprintStatProgression"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintStatProgression))]
  public class StatProgressionConfigurator : BaseBlueprintConfigurator<BlueprintStatProgression, StatProgressionConfigurator>
  {
     private StatProgressionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static StatProgressionConfigurator For(string name)
    {
      return new StatProgressionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static StatProgressionConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintStatProgression>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static StatProgressionConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintStatProgression>(name, assetId);
      return For(name);
    }
  }
}
