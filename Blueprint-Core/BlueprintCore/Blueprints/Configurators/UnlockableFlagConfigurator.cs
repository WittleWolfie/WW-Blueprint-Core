using BlueprintCore.Utils;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Configurator for <see cref="BlueprintUnlockableFlag"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUnlockableFlag))]
  public class UnlockableFlagConfigurator : BaseBlueprintConfigurator<BlueprintUnlockableFlag, UnlockableFlagConfigurator>
  {
    private UnlockableFlagConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnlockableFlagConfigurator For(string name)
    {
      return new UnlockableFlagConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static UnlockableFlagConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintUnlockableFlag>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnlockableFlagConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintUnlockableFlag>(name, assetId);
      return For(name);
    }
  }
}
