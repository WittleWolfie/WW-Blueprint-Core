using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Kingdom.Flags;
namespace BlueprintCore.Blueprints.Configurators.Kingdom.Flags
{
  /// <summary>Configurator for <see cref="BlueprintKingdomMoraleFlag"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintKingdomMoraleFlag))]
  public class KingdomMoraleFlagConfigurator : BaseFactConfigurator<BlueprintKingdomMoraleFlag, KingdomMoraleFlagConfigurator>
  {
     private KingdomMoraleFlagConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingdomMoraleFlagConfigurator For(string name)
    {
      return new KingdomMoraleFlagConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static KingdomMoraleFlagConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintKingdomMoraleFlag>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingdomMoraleFlagConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintKingdomMoraleFlag>(name, assetId);
      return For(name);
    }

  }
}
