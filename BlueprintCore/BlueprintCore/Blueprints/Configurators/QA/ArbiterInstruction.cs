using BlueprintCore.Utils;
using Kingmaker.AreaLogic;
using Kingmaker.Blueprints;
using Kingmaker.QA.Arbiter;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.QA
{
  /// <summary>
  /// Configurator for <see cref="BlueprintArbiterInstruction"/>.
  /// </summary>
  /// <inheritdoc/>
  
  public class ArbiterInstructionConfigurator : BaseBlueprintConfigurator<BlueprintArbiterInstruction, ArbiterInstructionConfigurator>
  {
    private ArbiterInstructionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ArbiterInstructionConfigurator For(string name)
    {
      return new ArbiterInstructionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ArbiterInstructionConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintArbiterInstruction>(name, guid);
      return For(name);
    }
  }
}
