using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>Configurator for <see cref="BlueprintRomanceCounter"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintRomanceCounter))]
  public class RomanceCounterConfigurator : BaseBlueprintConfigurator<BlueprintRomanceCounter, RomanceCounterConfigurator>
  {
     private RomanceCounterConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static RomanceCounterConfigurator For(string name)
    {
      return new RomanceCounterConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static RomanceCounterConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintRomanceCounter>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static RomanceCounterConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintRomanceCounter>(name, assetId);
      return For(name);
    }
  }
}
