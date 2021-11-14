using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Designers.Mechanics.Facts;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>Configurator for <see cref="BlueprintProjectile"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintProjectile))]
  public class ProjectileConfigurator : BaseBlueprintConfigurator<BlueprintProjectile, ProjectileConfigurator>
  {
     private ProjectileConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ProjectileConfigurator For(string name)
    {
      return new ProjectileConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ProjectileConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintProjectile>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ProjectileConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintProjectile>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Adds <see cref="CannotSneakAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CannotSneakAttack))]
    public ProjectileConfigurator AddCannotSneakAttack()
    {
      return AddComponent(new CannotSneakAttack());
    }
  }
}
