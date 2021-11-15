using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem;
using Kingmaker.DialogSystem.Blueprints;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>Configurator for <see cref="BlueprintSequenceExit"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintSequenceExit))]
  public class SequenceExitConfigurator : BaseBlueprintConfigurator<BlueprintSequenceExit, SequenceExitConfigurator>
  {
     private SequenceExitConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SequenceExitConfigurator For(string name)
    {
      return new SequenceExitConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static SequenceExitConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintSequenceExit>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SequenceExitConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintSequenceExit>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSequenceExit.Answers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAnswerBase"/></param>
    [Generated]
    public SequenceExitConfigurator AddToAnswers(params string[] values)
    {
      return OnConfigureInternal(bp => bp.Answers.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintAnswerBaseReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSequenceExit.Answers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAnswerBase"/></param>
    [Generated]
    public SequenceExitConfigurator RemoveFromAnswers(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintAnswerBaseReference>(name));
            bp.Answers =
                bp.Answers
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintSequenceExit.Continue"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SequenceExitConfigurator SetContinue(CueSelection value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Continue = value);
    }
  }
}
