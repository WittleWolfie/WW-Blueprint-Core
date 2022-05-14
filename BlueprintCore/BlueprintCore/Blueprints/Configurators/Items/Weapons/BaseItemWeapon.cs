//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.Items.Equipment;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Class.Kineticist;

namespace BlueprintCore.Blueprints.Configurators.Items.Weapons
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemWeapon"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseItemWeaponConfigurator<T, TBuilder>
    : BaseItemEquipmentHandConfigurator<T, TBuilder>
    where T : BlueprintItemWeapon
    where TBuilder : BaseItemWeaponConfigurator<T, TBuilder>
  {
    protected BaseItemWeaponConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Adds <see cref="WeaponKineticBlade"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AirKineticBladeWeapon</term><description>43ff67143efb86d4f894b10577329050</description></item>
    /// <item><term>IceKineticBladeWeapon</term><description>a1eee0a2735401546ba2b442e1a9d25d</description></item>
    /// <item><term>WaterKineticBladeWeapon</term><description>6a1bc011f6bbc7745876ce2692ecdfb5</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="activationAbility">
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="blast">
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddWeaponKineticBlade(
        Blueprint<BlueprintAbility, BlueprintAbilityReference>? activationAbility = null,
        Blueprint<BlueprintAbility, BlueprintAbilityReference>? blast = null)
    {
      var component = new WeaponKineticBlade();
      component.m_ActivationAbility = activationAbility?.Reference ?? component.m_ActivationAbility;
      if (component.m_ActivationAbility is null)
      {
        component.m_ActivationAbility = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      }
      component.m_Blast = blast?.Reference ?? component.m_Blast;
      if (component.m_Blast is null)
      {
        component.m_Blast = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      }
      return AddComponent(component);
    }
  }
}
