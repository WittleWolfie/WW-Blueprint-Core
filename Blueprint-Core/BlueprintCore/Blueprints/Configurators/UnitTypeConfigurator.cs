using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>Configurator for <see cref="BlueprintUnitType"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUnitType))]
  public class UnitTypeConfigurator : BaseBlueprintConfigurator<BlueprintUnitType, UnitTypeConfigurator>
  {
     private UnitTypeConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnitTypeConfigurator For(string name)
    {
      return new UnitTypeConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static UnitTypeConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintUnitType>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnitTypeConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintUnitType>(name, assetId);
      return For(name);
    }
  }
}
