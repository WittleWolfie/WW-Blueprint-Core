using BlueprintCore.Utils;
using Kingmaker.Corruption;

namespace BlueprintCore.Blueprints.Configurators.Corruption
{
  /// <summary>Configurator for <see cref="BlueprintCorruptionRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCorruptionRoot))]
  public class CorruptionRootConfigurator : BaseBlueprintConfigurator<BlueprintCorruptionRoot, CorruptionRootConfigurator>
  {
     private CorruptionRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CorruptionRootConfigurator For(string name)
    {
      return new CorruptionRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CorruptionRootConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintCorruptionRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CorruptionRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintCorruptionRoot>(name, assetId);
      return For(name);
    }
  }
}
