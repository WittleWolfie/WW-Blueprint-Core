using BlueprintCore.Blueprints.Configurators.Items.Equipment;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Weapons;
namespace BlueprintCore.Blueprints.Configurators.Items.Weapons
{
  /// <summary>Configurator for <see cref="BlueprintItemWeapon"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemWeapon))]
  public class ItemWeaponConfigurator : BaseItemEquipmentHandConfigurator<BlueprintItemWeapon, ItemWeaponConfigurator>
  {
     private ItemWeaponConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ItemWeaponConfigurator For(string name)
    {
      return new ItemWeaponConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ItemWeaponConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintItemWeapon>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ItemWeaponConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintItemWeapon>(name, assetId);
      return For(name);
    }

  }
}
