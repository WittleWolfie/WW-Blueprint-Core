using BlueprintCore.Utils;
using Kingmaker.DLC;

namespace BlueprintCore.Blueprints.Configurators.DLC
{
  /// <summary>Configurator for <see cref="BlueprintDlc"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintDlc))]
  public class DlcConfigurator : BaseBlueprintConfigurator<BlueprintDlc, DlcConfigurator>
  {
     private DlcConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static DlcConfigurator For(string name)
    {
      return new DlcConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static DlcConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintDlc>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static DlcConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintDlc>(name, assetId);
      return For(name);
    }
  }
}
