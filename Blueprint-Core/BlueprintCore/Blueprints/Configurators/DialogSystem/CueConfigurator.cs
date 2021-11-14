using BlueprintCore.Blueprints.Configurators.DialogSystem;
using BlueprintCore.Utils;
using Kingmaker.DialogSystem.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>Configurator for <see cref="BlueprintCue"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCue))]
  public class CueConfigurator : BaseCueBaseConfigurator<BlueprintCue, CueConfigurator>
  {
     private CueConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CueConfigurator For(string name)
    {
      return new CueConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CueConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintCue>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CueConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintCue>(name, assetId);
      return For(name);
    }
  }
}
