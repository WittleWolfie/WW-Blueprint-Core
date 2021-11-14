using BlueprintCore.Blueprints.Configurators.Items.Equipment;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.UnitLogic.Class.Kineticist;

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

    /// <summary>
    /// Adds <see cref="WeaponKineticBlade"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_ActivationAbility"><see cref="BlueprintAbility"/></param>
    /// <param name="m_Blast"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(WeaponKineticBlade))]
    public ItemWeaponConfigurator AddWeaponKineticBlade(
        string m_ActivationAbility,
        string m_Blast)
    {
      
      var component =  new WeaponKineticBlade();
      component.m_ActivationAbility = BlueprintTool.GetRef<BlueprintAbilityReference>(m_ActivationAbility);
      component.m_Blast = BlueprintTool.GetRef<BlueprintAbilityReference>(m_Blast);
      return AddComponent(component);
    }
  }
}
