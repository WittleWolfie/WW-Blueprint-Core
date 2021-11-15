using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.DialogSystem;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.ElementsSystem;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>Configurator for <see cref="BlueprintDialog"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintDialog))]
  public class DialogConfigurator : BaseBlueprintConfigurator<BlueprintDialog, DialogConfigurator>
  {
     private DialogConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static DialogConfigurator For(string name)
    {
      return new DialogConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static DialogConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintDialog>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static DialogConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintDialog>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDialog.FirstCue"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DialogConfigurator SetFirstCue(CueSelection value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.FirstCue = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDialog.StartPosition"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DialogConfigurator SetStartPosition(PositionEvaluator value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.StartPosition = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDialog.Conditions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DialogConfigurator SetConditions(ConditionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.Conditions = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintDialog.StartActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DialogConfigurator SetStartActions(ActionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.StartActions = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintDialog.FinishActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DialogConfigurator SetFinishActions(ActionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.FinishActions = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintDialog.ReplaceActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DialogConfigurator SetReplaceActions(ActionsBuilder value)
    {
      return OnConfigureInternal(bp => bp.ReplaceActions = value.Build());
    }

    /// <summary>
    /// Sets <see cref="BlueprintDialog.TurnPlayer"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DialogConfigurator SetTurnPlayer(bool value)
    {
      return OnConfigureInternal(bp => bp.TurnPlayer = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDialog.TurnFirstSpeaker"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DialogConfigurator SetTurnFirstSpeaker(bool value)
    {
      return OnConfigureInternal(bp => bp.TurnFirstSpeaker = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDialog.IsLockCameraRotationButtons"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DialogConfigurator SetIsLockCameraRotationButtons(bool value)
    {
      return OnConfigureInternal(bp => bp.IsLockCameraRotationButtons = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDialog.Type"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DialogConfigurator SetType(DialogType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Type = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDialog.m_OverrideAreaCR"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DialogConfigurator SetOverrideAreaCR(IntEvaluator value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_OverrideAreaCR = value);
    }
  }
}
