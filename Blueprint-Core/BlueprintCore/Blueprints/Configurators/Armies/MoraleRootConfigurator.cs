using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Armies.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>Configurator for <see cref="MoraleRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(MoraleRoot))]
  public class MoraleRootConfigurator : BaseBlueprintConfigurator<MoraleRoot, MoraleRootConfigurator>
  {
     private MoraleRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static MoraleRootConfigurator For(string name)
    {
      return new MoraleRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static MoraleRootConfigurator New(string name)
    {
      BlueprintTool.Create<MoraleRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static MoraleRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<MoraleRoot>(name, assetId);
      return For(name);
    }
  }
}
