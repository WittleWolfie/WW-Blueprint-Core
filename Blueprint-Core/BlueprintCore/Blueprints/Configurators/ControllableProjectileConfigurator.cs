using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>Configurator for <see cref="BlueprintControllableProjectile"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintControllableProjectile))]
  public class ControllableProjectileConfigurator : BaseBlueprintConfigurator<BlueprintControllableProjectile, ControllableProjectileConfigurator>
  {
     private ControllableProjectileConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ControllableProjectileConfigurator For(string name)
    {
      return new ControllableProjectileConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ControllableProjectileConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintControllableProjectile>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ControllableProjectileConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintControllableProjectile>(name, assetId);
      return For(name);
    }
  }
}
