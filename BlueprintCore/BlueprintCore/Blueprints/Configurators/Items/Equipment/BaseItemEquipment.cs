//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Components;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Alignments;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemEquipment"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseItemEquipmentConfigurator<T, TBuilder>
    : BaseItemConfigurator<T, TBuilder>
    where T : BlueprintItemEquipment
    where TBuilder : BaseItemEquipmentConfigurator<T, TBuilder>
  {
    protected BaseItemEquipmentConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Adds <see cref="AddFactToEquipmentWielder"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Artifact_SoulsCloakItem</term><description>d53d1c60393cfc84c970c8029de75ad1</description></item>
    /// <item><term>QuestElectriItem</term><description>ba3f8571c77a1e8468312e769c1c4b66</description></item>
    /// <item><term>TrailblazerHelmetItem</term><description>51eb5bdbb42b0ef4f84b45dddfc67f08</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="fact">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddFactToEquipmentWielder(
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>? fact = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new AddFactToEquipmentWielder();
      component.m_Fact = fact?.Reference ?? component.m_Fact;
      if (component.m_Fact is null)
      {
        component.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="EquipmentRestrictionAlignment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AnarchicGreataxe</term><description>ac2e11e971aa3144daa7686949136a48</description></item>
    /// <item><term>MayasCharmItem</term><description>5719bea74c11d8d4eb66fac430435f04</description></item>
    /// <item><term>WhiteWindsCloakItem</term><description>262b8ece36ba43f44bd407e82c079028</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddEquipmentRestrictionAlignment(
        AlignmentMaskType? alignment = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new EquipmentRestrictionAlignment();
      component.Alignment = alignment ?? component.Alignment;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="EquipmentRestrictionCannotEquip"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SimpleEnergyBlasterBracerItem</term><description>fe2acd72f8e79884f8b693b1e020a20c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddEquipmentRestrictionCannotEquip(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge)
    {
      var component = new EquipmentRestrictionCannotEquip();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="EquipmentRestrictionClass"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AdamantineBanded</term><description>ed04d2a914a93e046aadee8cc3109f65</description></item>
    /// <item><term>HaramakiOfScholarshipItem</term><description>9842680d61bc48e4b0b9b54a064d9155</description></item>
    /// <item><term>WelcomeRespiteItem</term><description>55d88efb08e2eea4c9d214cd4c54e87c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="clazz">
    /// <para>
    /// Blueprint of type BlueprintCharacterClass. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddEquipmentRestrictionClass(
        Blueprint<BlueprintCharacterClass, BlueprintCharacterClassReference>? clazz = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        bool? not = null)
    {
      var component = new EquipmentRestrictionClass();
      component.m_Class = clazz?.Reference ?? component.m_Class;
      if (component.m_Class is null)
      {
        component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(null);
      }
      component.Not = not ?? component.Not;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="EquipmentRestrictionHasAnyClassFromList"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Artifact_SpikedGauntletItem</term><description>3230a07e17594084f88e770480277de2</description></item>
    /// <item><term>HideBardingStandard</term><description>4a0838d1c48a9cc459b287e6a04f17f9</description></item>
    /// <item><term>SolidChainsItem</term><description>f55ccf3a9af55524d9f8d3bc1b2060ff</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="classes">
    /// <para>
    /// Blueprint of type BlueprintCharacterClass. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddEquipmentRestrictionHasAnyClassFromList(
        List<Blueprint<BlueprintCharacterClass, BlueprintCharacterClassReference>>? classes = null,
        bool? not = null)
    {
      var component = new EquipmentRestrictionHasAnyClassFromList();
      component.m_Classes = classes?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Classes;
      if (component.m_Classes is null)
      {
        component.m_Classes = new BlueprintCharacterClassReference[0];
      }
      component.Not = not ?? component.Not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EquipmentRestrictionMainPlayer"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DoublingAnnoyanceItem</term><description>63c9d4fc0810432aa6d85111d345aa84</description></item>
    /// <item><term>MaskOfNothingItem</term><description>8344b46a6e404227b72d129073383a6c</description></item>
    /// <item><term>RingOfProtection1_Prologue</term><description>80bb1c22e06b57c4ba9557e0ed2996c0</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEquipmentRestrictionMainPlayer()
    {
      return AddComponent(new EquipmentRestrictionMainPlayer());
    }

    /// <summary>
    /// Adds <see cref="EquipmentRestrictionStat"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>WarpaintedSkullItem</term><description>5d343648bb8887d42b24cbadfeb36991</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddEquipmentRestrictionStat(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        int? minValue = null,
        StatType? stat = null)
    {
      var component = new EquipmentRestrictionStat();
      component.MinValue = minValue ?? component.MinValue;
      component.Stat = stat ?? component.Stat;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }
  }
}
