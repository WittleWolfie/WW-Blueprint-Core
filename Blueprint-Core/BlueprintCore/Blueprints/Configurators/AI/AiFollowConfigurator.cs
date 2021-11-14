using BlueprintCore.Blueprints.Configurators.AI;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>Configurator for <see cref="BlueprintAiFollow"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAiFollow))]
  public class AiFollowConfigurator : BaseAiActionConfigurator<BlueprintAiFollow, AiFollowConfigurator>
  {
     private AiFollowConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AiFollowConfigurator For(string name)
    {
      return new AiFollowConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AiFollowConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintAiFollow>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AiFollowConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintAiFollow>(name, assetId);
      return For(name);
    }
  }
}
