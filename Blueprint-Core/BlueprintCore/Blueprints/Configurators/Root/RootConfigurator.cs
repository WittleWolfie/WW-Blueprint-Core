using BlueprintCore.Utils;
using Kingmaker.Blueprints.Root;

namespace BlueprintCore.Blueprints.Configurators.Root
{
  /// <summary>Configurator for <see cref="BlueprintRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintRoot))]
  public class RootConfigurator : BaseBlueprintConfigurator<BlueprintRoot, RootConfigurator>
  {
     private RootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static RootConfigurator For(string name)
    {
      return new RootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static RootConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static RootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintRoot>(name, assetId);
      return For(name);
    }
  }
}
