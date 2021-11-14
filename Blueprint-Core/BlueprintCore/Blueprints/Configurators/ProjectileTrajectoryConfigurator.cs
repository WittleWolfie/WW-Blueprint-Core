using BlueprintCore.Utils;
using Kingmaker.Blueprints;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>Configurator for <see cref="BlueprintProjectileTrajectory"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintProjectileTrajectory))]
  public class ProjectileTrajectoryConfigurator : BaseBlueprintConfigurator<BlueprintProjectileTrajectory, ProjectileTrajectoryConfigurator>
  {
     private ProjectileTrajectoryConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ProjectileTrajectoryConfigurator For(string name)
    {
      return new ProjectileTrajectoryConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ProjectileTrajectoryConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintProjectileTrajectory>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ProjectileTrajectoryConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintProjectileTrajectory>(name, assetId);
      return For(name);
    }
  }
}
