using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Visual.Sound;
namespace BlueprintCore.Blueprints.Configurators.Visual.Sound
{
  /// <summary>Configurator for <see cref="BlueprintUnitAsksList"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUnitAsksList))]
  public class UnitAsksListConfigurator : BaseBlueprintConfigurator<BlueprintUnitAsksList, UnitAsksListConfigurator>
  {
     private UnitAsksListConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnitAsksListConfigurator For(string name)
    {
      return new UnitAsksListConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static UnitAsksListConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintUnitAsksList>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnitAsksListConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintUnitAsksList>(name, assetId);
      return For(name);
    }

  }
}
