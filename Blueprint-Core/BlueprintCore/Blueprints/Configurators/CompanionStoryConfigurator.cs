using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>Configurator for <see cref="BlueprintCompanionStory"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCompanionStory))]
  public class CompanionStoryConfigurator : BaseBlueprintConfigurator<BlueprintCompanionStory, CompanionStoryConfigurator>
  {
     private CompanionStoryConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CompanionStoryConfigurator For(string name)
    {
      return new CompanionStoryConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CompanionStoryConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintCompanionStory>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CompanionStoryConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintCompanionStory>(name, assetId);
      return For(name);
    }
  }
}
