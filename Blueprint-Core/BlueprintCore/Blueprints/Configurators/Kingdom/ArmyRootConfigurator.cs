using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Kingdom.Blueprints;
namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>Configurator for <see cref="ArmyRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(ArmyRoot))]
  public class ArmyRootConfigurator : BaseBlueprintConfigurator<ArmyRoot, ArmyRootConfigurator>
  {
     private ArmyRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ArmyRootConfigurator For(string name)
    {
      return new ArmyRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ArmyRootConfigurator New(string name)
    {
      BlueprintTool.Create<ArmyRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ArmyRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<ArmyRoot>(name, assetId);
      return For(name);
    }

  }
}
