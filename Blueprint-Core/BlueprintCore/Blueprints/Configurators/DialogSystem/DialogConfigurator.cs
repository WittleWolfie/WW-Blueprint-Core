using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.DialogSystem.Blueprints;

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
  }
}
