using BlueprintCore.Utils;
using Kingmaker.Globalmap.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Globalmap
{
  /// <summary>Configurator for <see cref="BlueprintMultiEntranceEntry"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintMultiEntranceEntry))]
  public class MultiEntranceEntryConfigurator : BaseBlueprintConfigurator<BlueprintMultiEntranceEntry, MultiEntranceEntryConfigurator>
  {
     private MultiEntranceEntryConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static MultiEntranceEntryConfigurator For(string name)
    {
      return new MultiEntranceEntryConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static MultiEntranceEntryConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintMultiEntranceEntry>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static MultiEntranceEntryConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintMultiEntranceEntry>(name, assetId);
      return For(name);
    }
  }
}
