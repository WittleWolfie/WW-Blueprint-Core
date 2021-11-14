using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Designers.Mechanics.Collections;

namespace BlueprintCore.Blueprints.Configurators.Designers.Mechanics.Collections
{
  /// <summary>Configurator for <see cref="BuffCollection"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BuffCollection))]
  public class BuffCollectionConfigurator : BaseBlueprintConfigurator<BuffCollection, BuffCollectionConfigurator>
  {
     private BuffCollectionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static BuffCollectionConfigurator For(string name)
    {
      return new BuffCollectionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static BuffCollectionConfigurator New(string name)
    {
      BlueprintTool.Create<BuffCollection>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static BuffCollectionConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BuffCollection>(name, assetId);
      return For(name);
    }
  }
}
