using BlueprintCore.Utils;
using Kingmaker.Globalmap.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Globalmap
{
  /// <summary>Configurator for <see cref="BlueprintMultiEntrance"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintMultiEntrance))]
  public class MultiEntranceConfigurator : BaseBlueprintConfigurator<BlueprintMultiEntrance, MultiEntranceConfigurator>
  {
     private MultiEntranceConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static MultiEntranceConfigurator For(string name)
    {
      return new MultiEntranceConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static MultiEntranceConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintMultiEntrance>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static MultiEntranceConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintMultiEntrance>(name, assetId);
      return For(name);
    }
  }
}
