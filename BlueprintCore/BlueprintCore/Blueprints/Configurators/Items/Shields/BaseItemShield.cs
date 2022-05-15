//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.Items.Equipment;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Shields;
using Kingmaker.Blueprints.Items.Weapons;
using System;

namespace BlueprintCore.Blueprints.Configurators.Items.Shields
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemShield"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseItemShieldConfigurator<T, TBuilder>
    : BaseItemEquipmentHandConfigurator<T, TBuilder>
    where T : BlueprintItemShield
    where TBuilder : BaseItemShieldConfigurator<T, TBuilder>
  {
    protected BaseItemShieldConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemShield.m_WeaponComponent"/>
    /// </summary>
    ///
    /// <param name="weaponComponent">
    /// <para>
    /// Blueprint of type BlueprintItemWeapon. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetWeaponComponent(Blueprint<BlueprintItemWeapon, BlueprintItemWeaponReference> weaponComponent)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_WeaponComponent = weaponComponent?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItemShield.m_WeaponComponent"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="weaponComponent">
    /// <para>
    /// Blueprint of type BlueprintItemWeapon. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyWeaponComponent(Action<BlueprintItemWeaponReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_WeaponComponent is null) { return; }
          action.Invoke(bp.m_WeaponComponent);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemShield.m_ArmorComponent"/>
    /// </summary>
    ///
    /// <param name="armorComponent">
    /// <para>
    /// Blueprint of type BlueprintItemArmor. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetArmorComponent(Blueprint<BlueprintItemArmor, BlueprintItemArmorReference> armorComponent)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ArmorComponent = armorComponent?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItemShield.m_ArmorComponent"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="armorComponent">
    /// <para>
    /// Blueprint of type BlueprintItemArmor. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyArmorComponent(Action<BlueprintItemArmorReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ArmorComponent is null) { return; }
          action.Invoke(bp.m_ArmorComponent);
        });
    }
  }
}
