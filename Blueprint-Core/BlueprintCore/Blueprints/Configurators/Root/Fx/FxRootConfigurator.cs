using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Root.Fx;

namespace BlueprintCore.Blueprints.Configurators.Root.Fx
{
  /// <summary>Configurator for <see cref="FxRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(FxRoot))]
  public class FxRootConfigurator : BaseBlueprintConfigurator<FxRoot, FxRootConfigurator>
  {
     private FxRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static FxRootConfigurator For(string name)
    {
      return new FxRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static FxRootConfigurator New(string name)
    {
      BlueprintTool.Create<FxRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static FxRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<FxRoot>(name, assetId);
      return For(name);
    }
  }
}
