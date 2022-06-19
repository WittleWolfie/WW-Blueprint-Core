//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAnswer"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAnswerConfigurator<T, TBuilder>
    : BaseAnswerBaseConfigurator<T, TBuilder>
    where T : BlueprintAnswer
    where TBuilder : BaseAnswerConfigurator<T, TBuilder>
  {
    protected BaseAnswerConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAnswer.Text"/>
    /// </summary>
    ///
    /// <param name="text">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetText(LocalString text)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Text = text?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAnswer.Text"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyText(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Text is null) { return; }
          action.Invoke(bp.Text);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAnswer.NextCue"/>
    /// </summary>
    public TBuilder SetNextCue(CueSelection nextCue)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(nextCue);
          bp.NextCue = nextCue;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAnswer.NextCue"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyNextCue(Action<CueSelection> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.NextCue is null) { return; }
          action.Invoke(bp.NextCue);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAnswer.ShowOnce"/>
    /// </summary>
    public TBuilder SetShowOnce(bool showOnce = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ShowOnce = showOnce;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAnswer.ShowOnce"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyShowOnce(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ShowOnce);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAnswer.ShowOnceCurrentDialog"/>
    /// </summary>
    public TBuilder SetShowOnceCurrentDialog(bool showOnceCurrentDialog = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ShowOnceCurrentDialog = showOnceCurrentDialog;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAnswer.ShowOnceCurrentDialog"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyShowOnceCurrentDialog(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ShowOnceCurrentDialog);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAnswer.ShowCheck"/>
    /// </summary>
    public TBuilder SetShowCheck(ShowCheck showCheck)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(showCheck);
          bp.ShowCheck = showCheck;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAnswer.ShowCheck"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyShowCheck(Action<ShowCheck> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ShowCheck is null) { return; }
          action.Invoke(bp.ShowCheck);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAnswer.Experience"/>
    /// </summary>
    public TBuilder SetExperience(DialogExperience experience)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Experience = experience;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAnswer.Experience"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyExperience(Action<DialogExperience> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Experience);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAnswer.DebugMode"/>
    /// </summary>
    public TBuilder SetDebugMode(bool debugMode = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DebugMode = debugMode;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAnswer.DebugMode"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDebugMode(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.DebugMode);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAnswer.CharacterSelection"/>
    /// </summary>
    public TBuilder SetCharacterSelection(CharacterSelection characterSelection)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(characterSelection);
          bp.CharacterSelection = characterSelection;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAnswer.CharacterSelection"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCharacterSelection(Action<CharacterSelection> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CharacterSelection is null) { return; }
          action.Invoke(bp.CharacterSelection);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAnswer.ShowConditions"/>
    /// </summary>
    public TBuilder SetShowConditions(ConditionsBuilder showConditions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ShowConditions = showConditions?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAnswer.ShowConditions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyShowConditions(Action<ConditionsChecker> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ShowConditions is null) { return; }
          action.Invoke(bp.ShowConditions);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAnswer.SelectConditions"/>
    /// </summary>
    public TBuilder SetSelectConditions(ConditionsBuilder selectConditions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SelectConditions = selectConditions?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAnswer.SelectConditions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySelectConditions(Action<ConditionsChecker> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SelectConditions is null) { return; }
          action.Invoke(bp.SelectConditions);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAnswer.RequireValidCue"/>
    /// </summary>
    ///
    /// <param name="requireValidCue">
    /// <para>
    /// Tooltip: Show this answer only if it is followed by a valid cue.
    /// </para>
    /// </param>
    public TBuilder SetRequireValidCue(bool requireValidCue = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RequireValidCue = requireValidCue;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAnswer.RequireValidCue"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRequireValidCue(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.RequireValidCue);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAnswer.AddToHistory"/>
    /// </summary>
    public TBuilder SetAddToHistory(bool addToHistory = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AddToHistory = addToHistory;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAnswer.AddToHistory"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAddToHistory(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.AddToHistory);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAnswer.OnSelect"/>
    /// </summary>
    public TBuilder SetOnSelect(ActionsBuilder onSelect)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OnSelect = onSelect?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAnswer.OnSelect"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOnSelect(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OnSelect is null) { return; }
          action.Invoke(bp.OnSelect);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAnswer.FakeChecks"/>
    /// </summary>
    ///
    /// <param name="fakeChecks">
    /// <para>
    /// Tooltip: Show this check on answer in dialog interface. Instead of check calculated from BlueprintCheck node.
    /// </para>
    /// </param>
    public TBuilder SetFakeChecks(params CheckData[] fakeChecks)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(fakeChecks);
          bp.FakeChecks = fakeChecks;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintAnswer.FakeChecks"/>
    /// </summary>
    ///
    /// <param name="fakeChecks">
    /// <para>
    /// Tooltip: Show this check on answer in dialog interface. Instead of check calculated from BlueprintCheck node.
    /// </para>
    /// </param>
    public TBuilder AddToFakeChecks(params CheckData[] fakeChecks)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FakeChecks = bp.FakeChecks ?? new CheckData[0];
          bp.FakeChecks = CommonTool.Append(bp.FakeChecks, fakeChecks);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAnswer.FakeChecks"/>
    /// </summary>
    ///
    /// <param name="fakeChecks">
    /// <para>
    /// Tooltip: Show this check on answer in dialog interface. Instead of check calculated from BlueprintCheck node.
    /// </para>
    /// </param>
    public TBuilder RemoveFromFakeChecks(params CheckData[] fakeChecks)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FakeChecks is null) { return; }
          bp.FakeChecks = bp.FakeChecks.Where(val => !fakeChecks.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAnswer.FakeChecks"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromFakeChecks(Func<CheckData, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FakeChecks is null) { return; }
          bp.FakeChecks = bp.FakeChecks.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintAnswer.FakeChecks"/>
    /// </summary>
    public TBuilder ClearFakeChecks()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FakeChecks = new CheckData[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAnswer.FakeChecks"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyFakeChecks(Action<CheckData> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FakeChecks is null) { return; }
          bp.FakeChecks.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAnswer.AlignmentShift"/>
    /// </summary>
    public TBuilder SetAlignmentShift(AlignmentShift alignmentShift)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(alignmentShift);
          bp.AlignmentShift = alignmentShift;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAnswer.AlignmentShift"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAlignmentShift(Action<AlignmentShift> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.AlignmentShift is null) { return; }
          action.Invoke(bp.AlignmentShift);
        });
    }

    protected override void SetDefaults()
    {
      base.SetDefaults();
    
      if (Blueprint.Text is null)
      {
        Blueprint.Text = Utils.Constants.Empty.String;
      }
      if (Blueprint.ShowConditions is null)
      {
        Blueprint.ShowConditions = Utils.Constants.Empty.Conditions;
      }
      if (Blueprint.SelectConditions is null)
      {
        Blueprint.SelectConditions = Utils.Constants.Empty.Conditions;
      }
      if (Blueprint.OnSelect is null)
      {
        Blueprint.OnSelect = Utils.Constants.Empty.Actions;
      }
      if (Blueprint.FakeChecks is null)
      {
        Blueprint.FakeChecks = new CheckData[0];
      }
    }
  }
}
