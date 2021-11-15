using BlueprintCore.Utils;
using Kingmaker.DialogSystem.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>Configurator for <see cref="BlueprintDialogExperienceModifierTable"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintDialogExperienceModifierTable))]
  public class DialogExperienceModifierTableConfigurator : BaseBlueprintConfigurator<BlueprintDialogExperienceModifierTable, DialogExperienceModifierTableConfigurator>
  {
     private DialogExperienceModifierTableConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static DialogExperienceModifierTableConfigurator For(string name)
    {
      return new DialogExperienceModifierTableConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static DialogExperienceModifierTableConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintDialogExperienceModifierTable>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static DialogExperienceModifierTableConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintDialogExperienceModifierTable>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDialogExperienceModifierTable.MultiplierLow"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DialogExperienceModifierTableConfigurator SetMultiplierLow(float value)
    {
      return OnConfigureInternal(bp => bp.MultiplierLow = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDialogExperienceModifierTable.MultiplierNormal"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DialogExperienceModifierTableConfigurator SetMultiplierNormal(float value)
    {
      return OnConfigureInternal(bp => bp.MultiplierNormal = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDialogExperienceModifierTable.MultiplierHigh"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DialogExperienceModifierTableConfigurator SetMultiplierHigh(float value)
    {
      return OnConfigureInternal(bp => bp.MultiplierHigh = value);
    }
  }
}
