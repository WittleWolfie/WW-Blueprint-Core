//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Designers.Mechanics.Facts;

namespace BlueprintCore.Blueprints.Configurators.Items.Ecnchantments
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintArmorEnchantment"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseArmorEnchantmentConfigurator<T, TBuilder>
    : BaseEquipmentEnchantmentConfigurator<T, TBuilder>
    where T : BlueprintArmorEnchantment
    where TBuilder : BaseArmorEnchantmentConfigurator<T, TBuilder>
  {
    protected BaseArmorEnchantmentConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Adds <see cref="ArmorEnhancementBonus"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmorEnhancementBonus1</term><description>a9ea95c5e02f9b7468447bc1010fe152</description></item>
    /// <item><term>ShieldEnhancementBonus3</term><description>ac2e3a582b5faa74aab66e0a31c935a9</description></item>
    /// <item><term>TemporaryArmorEnhancementBonus5</term><description>15d7d6cbbf56bd744b37bbf9225ea83b</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddArmorEnhancementBonus(
        int? enhancementValue = null)
    {
      var component = new ArmorEnhancementBonus();
      component.EnhancementValue = enhancementValue ?? component.EnhancementValue;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AdvanceArmorStats"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AdamantineArmorHeavyEnchant</term><description>933456ff83c454146a8bf434e39b1f93</description></item>
    /// <item><term>SecondSkinEnchantment</term><description>49a9c68feb14a9a4aa07dc716ad68315</description></item>
    /// <item><term>TrailblazersArmorEnchantment</term><description>18a2cf7f9c3aac84681ee728197c6a2a</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddAdvanceArmorStats(
        int? arcaneSpellFailureShift = null,
        int? armorCheckPenaltyShift = null,
        int? maxDexBonusShift = null)
    {
      var component = new AdvanceArmorStats();
      component.ArcaneSpellFailureShift = arcaneSpellFailureShift ?? component.ArcaneSpellFailureShift;
      component.ArmorCheckPenaltyShift = armorCheckPenaltyShift ?? component.ArmorCheckPenaltyShift;
      component.MaxDexBonusShift = maxDexBonusShift ?? component.MaxDexBonusShift;
      return AddComponent(component);
    }
  }
}
