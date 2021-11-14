using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Root.Fx;

namespace BlueprintCore.Blueprints.Configurators.Root.Fx
{
  /// <summary>Configurator for <see cref="CastsGroup"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(CastsGroup))]
  public class CastsGroupConfigurator : BaseBlueprintConfigurator<CastsGroup, CastsGroupConfigurator>
  {
     private CastsGroupConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CastsGroupConfigurator For(string name)
    {
      return new CastsGroupConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CastsGroupConfigurator New(string name)
    {
      BlueprintTool.Create<CastsGroup>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CastsGroupConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<CastsGroup>(name, assetId);
      return For(name);
    }
  }
}
