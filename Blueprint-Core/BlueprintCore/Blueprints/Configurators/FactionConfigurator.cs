using BlueprintCore.Utils;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>Configurator for <see cref="BlueprintFaction"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintFaction))]
  public class FactionConfigurator : BaseBlueprintConfigurator<BlueprintFaction, FactionConfigurator>
  {
     private FactionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static FactionConfigurator For(string name)
    {
      return new FactionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static FactionConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintFaction>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static FactionConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintFaction>(name, assetId);
      return For(name);
    }
  }
}
