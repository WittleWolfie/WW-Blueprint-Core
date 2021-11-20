using BlueprintCore.Utils;
using Kingmaker.Kingdom.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Configurator for <see cref="BlueprintKingdomUpgrade"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintKingdomUpgrade))]
  public class KingdomUpgradeConfigurator : BaseKingdomProjectConfigurator<BlueprintKingdomUpgrade, KingdomUpgradeConfigurator>
  {
    private KingdomUpgradeConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingdomUpgradeConfigurator For(string name)
    {
      return new KingdomUpgradeConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static KingdomUpgradeConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintKingdomUpgrade>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingdomUpgradeConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintKingdomUpgrade>(name, assetId);
      return For(name);
    }
  }
}
