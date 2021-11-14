using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintBrain"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintBrain))]
  public abstract class BaseBrainConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintBrain
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseBrainConfigurator(string name) : base(name) { }
  }

  /// <summary>Configurator for <see cref="BlueprintBrain"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintBrain))]
  public class BrainConfigurator : BaseBlueprintConfigurator<BlueprintBrain, BrainConfigurator>
  {
     private BrainConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static BrainConfigurator For(string name)
    {
      return new BrainConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static BrainConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintBrain>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static BrainConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintBrain>(name, assetId);
      return For(name);
    }
  }
}
