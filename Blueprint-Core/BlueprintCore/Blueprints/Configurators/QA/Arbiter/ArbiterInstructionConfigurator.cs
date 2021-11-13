using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.QA.Arbiter;
namespace BlueprintCore.Blueprints.Configurators.QA.Arbiter
{
  /// <summary>Configurator for <see cref="BlueprintArbiterInstruction"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArbiterInstruction))]
  public class ArbiterInstructionConfigurator : BaseBlueprintConfigurator<BlueprintArbiterInstruction, ArbiterInstructionConfigurator>
  {
     private ArbiterInstructionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ArbiterInstructionConfigurator For(string name)
    {
      return new ArbiterInstructionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ArbiterInstructionConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintArbiterInstruction>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ArbiterInstructionConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintArbiterInstruction>(name, assetId);
      return For(name);
    }

  }
}
