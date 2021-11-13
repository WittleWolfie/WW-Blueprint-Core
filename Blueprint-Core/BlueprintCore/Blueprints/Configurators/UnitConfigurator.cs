using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>Configurator for <see cref="BlueprintUnit"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUnit))]
  public class UnitConfigurator : BaseUnitFactConfigurator<BlueprintUnit, UnitConfigurator>
  {
     private UnitConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnitConfigurator For(string name)
    {
      return new UnitConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static UnitConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintUnit>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnitConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintUnit>(name, assetId);
      return For(name);
    }

  }
}
