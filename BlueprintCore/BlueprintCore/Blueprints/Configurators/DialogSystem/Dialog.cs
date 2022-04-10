using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.DialogSystem;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.ElementsSystem;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Configurator for <see cref="BlueprintDialog"/>.
  /// </summary>
  /// <inheritdoc/>
  
  public class DialogConfigurator : BaseBlueprintConfigurator<BlueprintDialog, DialogConfigurator>
  {
    private DialogConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static DialogConfigurator For(string name)
    {
      return new DialogConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static DialogConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintDialog>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDialog.FirstCue"/> (Auto Generated)
    /// </summary>
    
    public DialogConfigurator SetFirstCue(CueSelection firstCue)
    {
      ValidateParam(firstCue);

      return OnConfigureInternal(
          bp =>
          {
            bp.FirstCue = firstCue;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDialog.StartPosition"/> (Auto Generated)
    /// </summary>
    
    public DialogConfigurator SetStartPosition(PositionEvaluator startPosition)
    {
      ValidateParam(startPosition);

      return OnConfigureInternal(
          bp =>
          {
            bp.StartPosition = startPosition;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDialog.Conditions"/> (Auto Generated)
    /// </summary>
    
    public DialogConfigurator SetConditions(ConditionsBuilder? conditions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDialog.StartActions"/> (Auto Generated)
    /// </summary>
    
    public DialogConfigurator SetStartActions(ActionsBuilder? startActions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.StartActions = startActions?.Build() ?? Constants.Empty.Actions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDialog.FinishActions"/> (Auto Generated)
    /// </summary>
    
    public DialogConfigurator SetFinishActions(ActionsBuilder? finishActions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FinishActions = finishActions?.Build() ?? Constants.Empty.Actions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDialog.ReplaceActions"/> (Auto Generated)
    /// </summary>
    
    public DialogConfigurator SetReplaceActions(ActionsBuilder? replaceActions)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ReplaceActions = replaceActions?.Build() ?? Constants.Empty.Actions;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDialog.TurnPlayer"/> (Auto Generated)
    /// </summary>
    
    public DialogConfigurator SetTurnPlayer(bool turnPlayer)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TurnPlayer = turnPlayer;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDialog.TurnFirstSpeaker"/> (Auto Generated)
    /// </summary>
    
    public DialogConfigurator SetTurnFirstSpeaker(bool turnFirstSpeaker)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TurnFirstSpeaker = turnFirstSpeaker;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDialog.IsLockCameraRotationButtons"/> (Auto Generated)
    /// </summary>
    
    public DialogConfigurator SetIsLockCameraRotationButtons(bool isLockCameraRotationButtons)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsLockCameraRotationButtons = isLockCameraRotationButtons;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDialog.Type"/> (Auto Generated)
    /// </summary>
    
    public DialogConfigurator SetType(DialogType type)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Type = type;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintDialog.m_OverrideAreaCR"/> (Auto Generated)
    /// </summary>
    
    public DialogConfigurator SetOverrideAreaCR(IntEvaluator overrideAreaCR)
    {
      ValidateParam(overrideAreaCR);

      return OnConfigureInternal(
          bp =>
          {
            bp.m_OverrideAreaCR = overrideAreaCR;
          });
    }
  }
}
