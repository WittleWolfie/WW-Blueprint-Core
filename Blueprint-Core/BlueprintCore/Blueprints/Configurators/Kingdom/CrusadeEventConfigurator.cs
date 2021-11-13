using BlueprintCore.Blueprints.Configurators.Kingdom;
using BlueprintCore.Utils;
using Kingmaker.Kingdom.Blueprints;
namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>Configurator for <see cref="BlueprintCrusadeEvent"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCrusadeEvent))]
  public class CrusadeEventConfigurator : BaseKingdomEventBaseConfigurator<BlueprintCrusadeEvent, CrusadeEventConfigurator>
  {
     private CrusadeEventConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CrusadeEventConfigurator For(string name)
    {
      return new CrusadeEventConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CrusadeEventConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintCrusadeEvent>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CrusadeEventConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintCrusadeEvent>(name, assetId);
      return For(name);
    }

  }
}
