//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.ElementsSystem;
using System;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintDialog"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDialogConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintDialog
    where TBuilder : BaseDialogConfigurator<T, TBuilder>
  {
    protected BaseDialogConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDialog.FirstCue"/>
    /// </summary>
    public TBuilder SetFirstCue(CueSelection firstCue)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(firstCue);
          bp.FirstCue = firstCue;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDialog.FirstCue"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFirstCue(Action<CueSelection> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FirstCue is null) { return; }
          action.Invoke(bp.FirstCue);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDialog.StartPosition"/>
    /// </summary>
    public TBuilder SetStartPosition(PositionEvaluator startPosition)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(startPosition);
          bp.StartPosition = startPosition;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDialog.StartPosition"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyStartPosition(Action<PositionEvaluator> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.StartPosition is null) { return; }
          action.Invoke(bp.StartPosition);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDialog.Conditions"/>
    /// </summary>
    public TBuilder SetConditions(ConditionsBuilder conditions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Conditions = conditions?.Build();
          if (bp.Conditions is null)
          {
            bp.Conditions = Utils.Constants.Empty.Conditions;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDialog.Conditions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyConditions(Action<ConditionsChecker> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Conditions is null) { return; }
          action.Invoke(bp.Conditions);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDialog.StartActions"/>
    /// </summary>
    public TBuilder SetStartActions(ActionsBuilder startActions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.StartActions = startActions?.Build();
          if (bp.StartActions is null)
          {
            bp.StartActions = Utils.Constants.Empty.Actions;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDialog.StartActions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyStartActions(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.StartActions is null) { return; }
          action.Invoke(bp.StartActions);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDialog.FinishActions"/>
    /// </summary>
    public TBuilder SetFinishActions(ActionsBuilder finishActions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FinishActions = finishActions?.Build();
          if (bp.FinishActions is null)
          {
            bp.FinishActions = Utils.Constants.Empty.Actions;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDialog.FinishActions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFinishActions(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FinishActions is null) { return; }
          action.Invoke(bp.FinishActions);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDialog.ReplaceActions"/>
    /// </summary>
    public TBuilder SetReplaceActions(ActionsBuilder replaceActions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ReplaceActions = replaceActions?.Build();
          if (bp.ReplaceActions is null)
          {
            bp.ReplaceActions = Utils.Constants.Empty.Actions;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDialog.ReplaceActions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyReplaceActions(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ReplaceActions is null) { return; }
          action.Invoke(bp.ReplaceActions);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDialog.TurnPlayer"/>
    /// </summary>
    public TBuilder SetTurnPlayer(bool turnPlayer = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.TurnPlayer = turnPlayer;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDialog.TurnPlayer"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTurnPlayer(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.TurnPlayer);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDialog.TurnFirstSpeaker"/>
    /// </summary>
    public TBuilder SetTurnFirstSpeaker(bool turnFirstSpeaker = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.TurnFirstSpeaker = turnFirstSpeaker;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDialog.TurnFirstSpeaker"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTurnFirstSpeaker(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.TurnFirstSpeaker);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDialog.IsLockCameraRotationButtons"/>
    /// </summary>
    ///
    /// <param name="isLockCameraRotationButtons">
    /// <para>
    /// Tooltip: ��������� �������� ������ ������� �� ����� �������
    /// </para>
    /// </param>
    public TBuilder SetIsLockCameraRotationButtons(bool isLockCameraRotationButtons = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsLockCameraRotationButtons = isLockCameraRotationButtons;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDialog.IsLockCameraRotationButtons"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="isLockCameraRotationButtons">
    /// <para>
    /// Tooltip: ��������� �������� ������ ������� �� ����� �������
    /// </para>
    /// </param>
    public TBuilder ModifyIsLockCameraRotationButtons(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.IsLockCameraRotationButtons);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDialog.Type"/>
    /// </summary>
    public TBuilder SetType(DialogType type)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Type = type;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDialog.Type"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyType(Action<DialogType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Type);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDialog.m_OverrideAreaCR"/>
    /// </summary>
    ///
    /// <param name="overrideAreaCR">
    /// <para>
    /// Tooltip: Override zone CR
    /// </para>
    /// </param>
    public TBuilder SetOverrideAreaCR(IntEvaluator overrideAreaCR)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(overrideAreaCR);
          bp.m_OverrideAreaCR = overrideAreaCR;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDialog.m_OverrideAreaCR"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="overrideAreaCR">
    /// <para>
    /// Tooltip: Override zone CR
    /// </para>
    /// </param>
    public TBuilder ModifyOverrideAreaCR(Action<IntEvaluator> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_OverrideAreaCR is null) { return; }
          action.Invoke(bp.m_OverrideAreaCR);
        });
    }
  }
}