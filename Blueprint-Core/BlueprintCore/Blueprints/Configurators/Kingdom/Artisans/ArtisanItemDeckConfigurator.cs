using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Kingdom.Artisans;

namespace BlueprintCore.Blueprints.Configurators.Kingdom.Artisans
{
  /// <summary>Configurator for <see cref="ArtisanItemDeck"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(ArtisanItemDeck))]
  public class ArtisanItemDeckConfigurator : BaseBlueprintConfigurator<ArtisanItemDeck, ArtisanItemDeckConfigurator>
  {
     private ArtisanItemDeckConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ArtisanItemDeckConfigurator For(string name)
    {
      return new ArtisanItemDeckConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ArtisanItemDeckConfigurator New(string name)
    {
      BlueprintTool.Create<ArtisanItemDeck>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ArtisanItemDeckConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<ArtisanItemDeck>(name, assetId);
      return For(name);
    }
  }
}
