using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Alignments;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>Configurator for <see cref="BlueprintAnswer"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAnswer))]
  public class AnswerConfigurator : BaseAnswerBaseConfigurator<BlueprintAnswer, AnswerConfigurator>
  {
     private AnswerConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AnswerConfigurator For(string name)
    {
      return new AnswerConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AnswerConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintAnswer>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AnswerConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintAnswer>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswer.Text"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AnswerConfigurator SetText(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Text = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswer.NextCue"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AnswerConfigurator SetNextCue(CueSelection value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.NextCue = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswer.ShowOnce"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AnswerConfigurator SetShowOnce(bool value)
    {
      return OnConfigureInternal(bp => bp.ShowOnce = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswer.ShowOnceCurrentDialog"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AnswerConfigurator SetShowOnceCurrentDialog(bool value)
    {
      return OnConfigureInternal(bp => bp.ShowOnceCurrentDialog = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswer.ShowCheck"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AnswerConfigurator SetShowCheck(ShowCheck value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ShowCheck = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswer.Experience"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AnswerConfigurator SetExperience(DialogExperience value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Experience = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswer.DebugMode"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AnswerConfigurator SetDebugMode(bool value)
    {
      return OnConfigureInternal(bp => bp.DebugMode = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswer.CharacterSelection"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AnswerConfigurator SetCharacterSelection(CharacterSelection value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.CharacterSelection = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswer.ShowConditions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AnswerConfigurator SetShowConditions(ConditionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.ShowConditions = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswer.SelectConditions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AnswerConfigurator SetSelectConditions(ConditionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.SelectConditions = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswer.RequireValidCue"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AnswerConfigurator SetRequireValidCue(bool value)
    {
      return OnConfigureInternal(bp => bp.RequireValidCue = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswer.AddToHistory"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AnswerConfigurator SetAddToHistory(bool value)
    {
      return OnConfigureInternal(bp => bp.AddToHistory = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswer.OnSelect"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AnswerConfigurator SetOnSelect(ActionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.OnSelect = value.Build());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAnswer.FakeChecks"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AnswerConfigurator AddToFakeChecks(params CheckData[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.FakeChecks = CommonTool.Append(bp.FakeChecks, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAnswer.FakeChecks"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AnswerConfigurator RemoveFromFakeChecks(params CheckData[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.FakeChecks = bp.FakeChecks.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="BlueprintAnswer.AlignmentShift"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AnswerConfigurator SetAlignmentShift(AlignmentShift value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.AlignmentShift = value);
    }

    /// <summary>
    /// Adds <see cref="ActingCompanion"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Companion"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(ActingCompanion))]
    public AnswerConfigurator AddActingCompanion(
        string m_Companion)
    {
      
      var component =  new ActingCompanion();
      component.m_Companion = BlueprintTool.GetRef<BlueprintUnitReference>(m_Companion);
      return AddComponent(component);
    }
  }
}
