using BlueprintCore.Blueprints.Configurators.Area;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Area;
namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>Configurator for <see cref="BlueprintTrap"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintTrap))]
  public class TrapConfigurator : BaseMapObjectConfigurator<BlueprintTrap, TrapConfigurator>
  {
     private TrapConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TrapConfigurator For(string name)
    {
      return new TrapConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static TrapConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintTrap>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TrapConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintTrap>(name, assetId);
      return For(name);
    }

  }
}
