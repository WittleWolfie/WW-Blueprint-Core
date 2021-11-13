using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Kingdom.Blueprints;
namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>Configurator for <see cref="KingdomRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(KingdomRoot))]
  public class KingdomRootConfigurator : BaseBlueprintConfigurator<KingdomRoot, KingdomRootConfigurator>
  {
     private KingdomRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingdomRootConfigurator For(string name)
    {
      return new KingdomRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static KingdomRootConfigurator New(string name)
    {
      BlueprintTool.Create<KingdomRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingdomRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<KingdomRoot>(name, assetId);
      return For(name);
    }

  }
}
