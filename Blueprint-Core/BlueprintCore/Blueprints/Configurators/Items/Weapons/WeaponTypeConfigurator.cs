using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Weapons;

namespace BlueprintCore.Blueprints.Configurators.Items.Weapons
{
  /// <summary>Configurator for <see cref="BlueprintWeaponType"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintWeaponType))]
  public class WeaponTypeConfigurator : BaseBlueprintConfigurator<BlueprintWeaponType, WeaponTypeConfigurator>
  {
     private WeaponTypeConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static WeaponTypeConfigurator For(string name)
    {
      return new WeaponTypeConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static WeaponTypeConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintWeaponType>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static WeaponTypeConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintWeaponType>(name, assetId);
      return For(name);
    }
  }
}
