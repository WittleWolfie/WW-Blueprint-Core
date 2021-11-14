using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.DialogSystem.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>Configurator for <see cref="BlueprintSequenceExit"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintSequenceExit))]
  public class SequenceExitConfigurator : BaseBlueprintConfigurator<BlueprintSequenceExit, SequenceExitConfigurator>
  {
     private SequenceExitConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SequenceExitConfigurator For(string name)
    {
      return new SequenceExitConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static SequenceExitConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintSequenceExit>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SequenceExitConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintSequenceExit>(name, assetId);
      return For(name);
    }
  }
}
