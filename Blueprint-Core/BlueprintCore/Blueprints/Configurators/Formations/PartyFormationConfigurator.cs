using BlueprintCore.Utils;
using Kingmaker.Formations;

namespace BlueprintCore.Blueprints.Configurators.Formations
{
  /// <summary>Configurator for <see cref="BlueprintPartyFormation"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintPartyFormation))]
  public class PartyFormationConfigurator : BaseBlueprintConfigurator<BlueprintPartyFormation, PartyFormationConfigurator>
  {
     private PartyFormationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static PartyFormationConfigurator For(string name)
    {
      return new PartyFormationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static PartyFormationConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintPartyFormation>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static PartyFormationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintPartyFormation>(name, assetId);
      return For(name);
    }
  }
}
