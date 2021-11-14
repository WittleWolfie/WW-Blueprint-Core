using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Root;

namespace BlueprintCore.Blueprints.Configurators.Root
{
  /// <summary>Configurator for <see cref="CutscenesRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(CutscenesRoot))]
  public class CutscenesRootConfigurator : BaseBlueprintConfigurator<CutscenesRoot, CutscenesRootConfigurator>
  {
     private CutscenesRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CutscenesRootConfigurator For(string name)
    {
      return new CutscenesRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CutscenesRootConfigurator New(string name)
    {
      BlueprintTool.Create<CutscenesRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CutscenesRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<CutscenesRoot>(name, assetId);
      return For(name);
    }
  }
}
