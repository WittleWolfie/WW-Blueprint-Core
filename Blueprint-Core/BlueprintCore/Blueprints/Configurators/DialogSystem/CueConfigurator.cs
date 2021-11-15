using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Alignments;
using System.Linq;

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

    /// <summary>
    /// Sets <see cref="BlueprintCue.Text"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CueConfigurator SetText(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Text = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCue.Experience"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CueConfigurator SetExperience(DialogExperience value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Experience = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCue.Speaker"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CueConfigurator SetSpeaker(DialogSpeaker value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Speaker = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCue.TurnSpeaker"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CueConfigurator SetTurnSpeaker(bool value)
    {
      return OnConfigureInternal(bp => bp.TurnSpeaker = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCue.Animation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CueConfigurator SetAnimation(DialogAnimation value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Animation = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCue.m_Listener"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintUnit"/></param>
    [Generated]
    public CueConfigurator SetListener(string value)
    {
      return OnConfigureInternal(bp => bp.m_Listener = BlueprintTool.GetRef<BlueprintUnitReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintCue.OnShow"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CueConfigurator SetOnShow(ActionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.OnShow = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintCue.OnStop"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CueConfigurator SetOnStop(ActionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.OnStop = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintCue.AlignmentShift"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CueConfigurator SetAlignmentShift(AlignmentShift value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.AlignmentShift = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCue.Answers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAnswerBase"/></param>
    [Generated]
    public CueConfigurator AddToAnswers(params string[] values)
    {
      return OnConfigureInternal(bp => bp.Answers.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintAnswerBaseReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCue.Answers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAnswerBase"/></param>
    [Generated]
    public CueConfigurator RemoveFromAnswers(params string[] values)
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
    /// Sets <see cref="BlueprintCue.Continue"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CueConfigurator SetContinue(CueSelection value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Continue = value);
    }
  }
}
