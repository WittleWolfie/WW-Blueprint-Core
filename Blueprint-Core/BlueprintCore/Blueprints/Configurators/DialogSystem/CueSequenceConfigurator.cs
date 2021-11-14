using BlueprintCore.Blueprints.Configurators.DialogSystem;
using BlueprintCore.Utils;
using Kingmaker.DialogSystem.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>Configurator for <see cref="BlueprintCueSequence"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCueSequence))]
  public class CueSequenceConfigurator : BaseCueBaseConfigurator<BlueprintCueSequence, CueSequenceConfigurator>
  {
     private CueSequenceConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CueSequenceConfigurator For(string name)
    {
      return new CueSequenceConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CueSequenceConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintCueSequence>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CueSequenceConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintCueSequence>(name, assetId);
      return For(name);
    }
  }
}
