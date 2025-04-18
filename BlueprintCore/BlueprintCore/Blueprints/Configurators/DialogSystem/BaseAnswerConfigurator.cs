//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.DialogSystem;
using BlueprintCore.Blueprints.CustomConfigurators;
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
using System.Collections.Generic;
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

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintAnswer>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.NextCue = copyFrom.NextCue;
          bp.Text = copyFrom.Text;
          bp.ShowOnce = copyFrom.ShowOnce;
          bp.ShowOnceCurrentDialog = copyFrom.ShowOnceCurrentDialog;
          bp.ShowCheck = copyFrom.ShowCheck;
          bp.Experience = copyFrom.Experience;
          bp.DebugMode = copyFrom.DebugMode;
          bp.CharacterSelection = copyFrom.CharacterSelection;
          bp.ShowConditions = copyFrom.ShowConditions;
          bp.SelectConditions = copyFrom.SelectConditions;
          bp.AddToHistory = copyFrom.AddToHistory;
          bp.OnSelect = copyFrom.OnSelect;
          bp.FakeChecks = copyFrom.FakeChecks;
          bp.AlignmentShift = copyFrom.AlignmentShift;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintAnswer>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.NextCue = copyFrom.NextCue;
          bp.Text = copyFrom.Text;
          bp.ShowOnce = copyFrom.ShowOnce;
          bp.ShowOnceCurrentDialog = copyFrom.ShowOnceCurrentDialog;
          bp.ShowCheck = copyFrom.ShowCheck;
          bp.Experience = copyFrom.Experience;
          bp.DebugMode = copyFrom.DebugMode;
          bp.CharacterSelection = copyFrom.CharacterSelection;
          bp.ShowConditions = copyFrom.ShowConditions;
          bp.SelectConditions = copyFrom.SelectConditions;
          bp.AddToHistory = copyFrom.AddToHistory;
          bp.OnSelect = copyFrom.OnSelect;
          bp.FakeChecks = copyFrom.FakeChecks;
          bp.AlignmentShift = copyFrom.AlignmentShift;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAnswer.NextCue"/>
    /// </summary>
    ///
    /// <param name="nextCue">
    /// Create using <see cref="Utils.Types.CueSelections" />
    /// </param>
    public TBuilder SetNextCue(CueSelection nextCue)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NextCue = nextCue;
          bp.RequireValidCue = true;
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
    /// Sets the value of <see cref="BlueprintAnswer.ShowCheck"/>
    /// </summary>
    public TBuilder SetShowCheck(ShowCheck showCheck)
    {
      return OnConfigureInternal(
        bp =>
        {
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
    /// Sets the value of <see cref="BlueprintAnswer.CharacterSelection"/>
    /// </summary>
    ///
    /// <param name="characterSelection">
    /// Create using <see cref="Utils.Types.CharacterSelections" />
    /// </param>
    public TBuilder SetCharacterSelection(CharacterSelection characterSelection)
    {
      return OnConfigureInternal(
        bp =>
        {
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
          bp.FakeChecks = bp.FakeChecks.Where(e => !predicate(e)).ToArray();
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

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.NextCue is null)
      {
        Blueprint.NextCue = Utils.Constants.Empty.CueSelection;
      }
      if (Blueprint.Text is null)
      {
        Blueprint.Text = Utils.Constants.Empty.String;
      }
      if (Blueprint.ShowCheck is null)
      {
        Blueprint.ShowCheck = Utils.Constants.Empty.ShowCheck;
      }
      if (Blueprint.CharacterSelection is null)
      {
        Blueprint.CharacterSelection = Utils.Constants.Empty.CharacterSelection;
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
