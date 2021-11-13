using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Interaction;
namespace BlueprintCore.Blueprints.Configurators.Interaction
{
  /// <summary>Configurator for <see cref="BlueprintInteractionRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintInteractionRoot))]
  public class InteractionRootConfigurator : BaseBlueprintConfigurator<BlueprintInteractionRoot, InteractionRootConfigurator>
  {
     private InteractionRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static InteractionRootConfigurator For(string name)
    {
      return new InteractionRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static InteractionRootConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintInteractionRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static InteractionRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintInteractionRoot>(name, assetId);
      return For(name);
    }

  }
}
