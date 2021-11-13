using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.UnitLogic.Mechanics.Properties;
namespace BlueprintCore.Blueprints.Configurators.UnitLogic.Mechanics.Properties
{
  /// <summary>Configurator for <see cref="BlueprintUnitProperty"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUnitProperty))]
  public class UnitPropertyConfigurator : BaseBlueprintConfigurator<BlueprintUnitProperty, UnitPropertyConfigurator>
  {
     private UnitPropertyConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnitPropertyConfigurator For(string name)
    {
      return new UnitPropertyConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static UnitPropertyConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintUnitProperty>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnitPropertyConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintUnitProperty>(name, assetId);
      return For(name);
    }

  }
}
