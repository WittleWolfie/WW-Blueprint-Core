using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Armies;

namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>Configurator for <see cref="BlueprintLeaderProgression"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintLeaderProgression))]
  public class LeaderProgressionConfigurator : BaseBlueprintConfigurator<BlueprintLeaderProgression, LeaderProgressionConfigurator>
  {
     private LeaderProgressionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static LeaderProgressionConfigurator For(string name)
    {
      return new LeaderProgressionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static LeaderProgressionConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintLeaderProgression>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static LeaderProgressionConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintLeaderProgression>(name, assetId);
      return For(name);
    }
  }
}
