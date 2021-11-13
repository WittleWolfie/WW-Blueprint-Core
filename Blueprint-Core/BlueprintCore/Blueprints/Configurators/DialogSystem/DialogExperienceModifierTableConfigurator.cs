using BlueprintCore.Blueprints.Configurators;
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

  }
}
