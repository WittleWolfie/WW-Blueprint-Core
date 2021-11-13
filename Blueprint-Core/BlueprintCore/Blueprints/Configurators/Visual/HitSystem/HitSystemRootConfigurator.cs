using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Visual.HitSystem;
namespace BlueprintCore.Blueprints.Configurators.Visual.HitSystem
{
  /// <summary>Configurator for <see cref="HitSystemRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(HitSystemRoot))]
  public class HitSystemRootConfigurator : BaseBlueprintConfigurator<HitSystemRoot, HitSystemRootConfigurator>
  {
     private HitSystemRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static HitSystemRootConfigurator For(string name)
    {
      return new HitSystemRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static HitSystemRootConfigurator New(string name)
    {
      BlueprintTool.Create<HitSystemRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static HitSystemRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<HitSystemRoot>(name, assetId);
      return For(name);
    }

  }
}
