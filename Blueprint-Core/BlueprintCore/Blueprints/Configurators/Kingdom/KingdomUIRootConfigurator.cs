using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Kingdom;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>Configurator for <see cref="KingdomUIRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(KingdomUIRoot))]
  public class KingdomUIRootConfigurator : BaseBlueprintConfigurator<KingdomUIRoot, KingdomUIRootConfigurator>
  {
     private KingdomUIRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingdomUIRootConfigurator For(string name)
    {
      return new KingdomUIRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static KingdomUIRootConfigurator New(string name)
    {
      BlueprintTool.Create<KingdomUIRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingdomUIRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<KingdomUIRoot>(name, assetId);
      return For(name);
    }
  }
}
