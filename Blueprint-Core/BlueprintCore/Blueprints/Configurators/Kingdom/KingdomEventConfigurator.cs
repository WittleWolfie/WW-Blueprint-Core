using BlueprintCore.Blueprints.Configurators.Kingdom;
using BlueprintCore.Utils;
using Kingmaker.Kingdom.Blueprints;
namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>Configurator for <see cref="BlueprintKingdomEvent"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintKingdomEvent))]
  public class KingdomEventConfigurator : BaseKingdomEventBaseConfigurator<BlueprintKingdomEvent, KingdomEventConfigurator>
  {
     private KingdomEventConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static KingdomEventConfigurator For(string name)
    {
      return new KingdomEventConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static KingdomEventConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintKingdomEvent>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static KingdomEventConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintKingdomEvent>(name, assetId);
      return For(name);
    }

  }
}
