using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Craft;

namespace BlueprintCore.Blueprints.Configurators.Craft
{
  /// <summary>Configurator for <see cref="CraftRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(CraftRoot))]
  public class CraftRootConfigurator : BaseBlueprintConfigurator<CraftRoot, CraftRootConfigurator>
  {
     private CraftRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CraftRootConfigurator For(string name)
    {
      return new CraftRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CraftRootConfigurator New(string name)
    {
      BlueprintTool.Create<CraftRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CraftRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<CraftRoot>(name, assetId);
      return For(name);
    }
  }
}
