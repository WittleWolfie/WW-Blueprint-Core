using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem.Blueprints;
using System.Linq;

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

    /// <summary>
    /// Modifies <see cref="BlueprintCueSequence.Cues"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintCueBase"/></param>
    [Generated]
    public CueSequenceConfigurator AddToCues(params string[] values)
    {
      return OnConfigureInternal(bp => bp.Cues.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintCueBaseReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCueSequence.Cues"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintCueBase"/></param>
    [Generated]
    public CueSequenceConfigurator RemoveFromCues(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintCueBaseReference>(name));
            bp.Cues =
                bp.Cues
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCueSequence.m_Exit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintSequenceExit"/></param>
    [Generated]
    public CueSequenceConfigurator SetExit(string value)
    {
      return OnConfigureInternal(bp => bp.m_Exit = BlueprintTool.GetRef<BlueprintSequenceExitReference>(value));
    }
  }
}
