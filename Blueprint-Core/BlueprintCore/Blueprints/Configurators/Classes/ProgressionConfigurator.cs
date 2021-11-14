using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>Configurator for <see cref="BlueprintProgression"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintProgression))]
  public class ProgressionConfigurator : BaseFeatureConfigurator<BlueprintProgression, ProgressionConfigurator>
  {
     private ProgressionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ProgressionConfigurator For(string name)
    {
      return new ProgressionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ProgressionConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintProgression>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ProgressionConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintProgression>(name, assetId);
      return For(name);
    }
  }
}
