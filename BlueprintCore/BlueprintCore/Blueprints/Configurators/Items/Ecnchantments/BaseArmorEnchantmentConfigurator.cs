//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Designers.Mechanics.EquipmentEnchants;
using Kingmaker.Designers.Mechanics.Facts;
using System;
using System.Collections.Generic;
using System.Linq;

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
    protected BaseArmorEnchantmentConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintArmorEnchantment>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    return Self;
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintArmorEnchantment>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    return Self;
    }

    /// <summary>
    /// Adds <see cref="ArmorEnhancementBonus"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmorEnhancementBonus1</term><description>a9ea95c5e02f9b7468447bc1010fe152</description></item>
    /// <item><term>HeavyShieldEnhancementRusty</term><description>5fbb3964ceb9492da80806de8205a491</description></item>
    /// <item><term>ShieldEnhancementBonus6</term><description>70c26c66adb96d74baec38fc8d20c139</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddArmorEnhancementBonus(
        int? enhancementValue = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new ArmorEnhancementBonus();
      component.EnhancementValue = enhancementValue ?? component.EnhancementValue;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PolymorphEnchantment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AnimalisticPerseveranceEnchantment</term><description>c7090597a05e40409426d2779f6f3c4b</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddPolymorphEnchantment(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new PolymorphEnchantment();
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>MithralArmorEnchant</term><description>7b95a819181574a4799d93939aa99aff</description></item>
    /// <item><term>TrailblazersArmorEnchantment</term><description>18a2cf7f9c3aac84681ee728197c6a2a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAdvanceArmorStats(
        int? arcaneSpellFailureShift = null,
        int? armorCheckPenaltyShift = null,
        int? maxDexBonusShift = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AdvanceArmorStats();
      component.ArcaneSpellFailureShift = arcaneSpellFailureShift ?? component.ArcaneSpellFailureShift;
      component.ArmorCheckPenaltyShift = armorCheckPenaltyShift ?? component.ArmorCheckPenaltyShift;
      component.MaxDexBonusShift = maxDexBonusShift ?? component.MaxDexBonusShift;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }
  }
}
