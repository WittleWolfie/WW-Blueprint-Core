using BlueprintCore.Blueprints.Configurators.AI;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>Configurator for <see cref="BlueprintAiRandomMove"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAiRandomMove))]
  public class AiRandomMoveConfigurator : BaseAiActionConfigurator<BlueprintAiRandomMove, AiRandomMoveConfigurator>
  {
     private AiRandomMoveConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AiRandomMoveConfigurator For(string name)
    {
      return new AiRandomMoveConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AiRandomMoveConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintAiRandomMove>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AiRandomMoveConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintAiRandomMove>(name, assetId);
      return For(name);
    }

  }
}