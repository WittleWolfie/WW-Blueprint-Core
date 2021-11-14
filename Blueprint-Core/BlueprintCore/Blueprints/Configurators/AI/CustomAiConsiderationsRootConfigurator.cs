using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>Configurator for <see cref="CustomAiConsiderationsRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(CustomAiConsiderationsRoot))]
  public class CustomAiConsiderationsRootConfigurator : BaseBlueprintConfigurator<CustomAiConsiderationsRoot, CustomAiConsiderationsRootConfigurator>
  {
     private CustomAiConsiderationsRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CustomAiConsiderationsRootConfigurator For(string name)
    {
      return new CustomAiConsiderationsRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CustomAiConsiderationsRootConfigurator New(string name)
    {
      BlueprintTool.Create<CustomAiConsiderationsRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CustomAiConsiderationsRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<CustomAiConsiderationsRoot>(name, assetId);
      return For(name);
    }
  }
}
