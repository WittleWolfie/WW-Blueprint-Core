using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Kingdom.Blueprints;
namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>Configurator for <see cref="BlueprintKingdomBuff"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintKingdomBuff))]
  public class KingdomBuffConfigurator : BaseFactConfigurator<BlueprintKingdomBuff, KingdomBuffConfigurator>
  {
     private KingdomBuffConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingdomBuffConfigurator For(string name)
    {
      return new KingdomBuffConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static KingdomBuffConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintKingdomBuff>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingdomBuffConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintKingdomBuff>(name, assetId);
      return For(name);
    }

  }
}
