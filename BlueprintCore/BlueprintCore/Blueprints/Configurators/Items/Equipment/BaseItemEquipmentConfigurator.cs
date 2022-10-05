//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Components;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.Utility;
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
    protected BaseItemEquipmentConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintItemEquipment>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.CR = copyFrom.CR;
          bp.m_Ability = copyFrom.m_Ability;
          bp.m_ActivatableAbility = copyFrom.m_ActivatableAbility;
          bp.SpendCharges = copyFrom.SpendCharges;
          bp.Charges = copyFrom.Charges;
          bp.RestoreChargesOnRest = copyFrom.RestoreChargesOnRest;
          bp.CasterLevel = copyFrom.CasterLevel;
          bp.SpellLevel = copyFrom.SpellLevel;
          bp.DC = copyFrom.DC;
          bp.HideAbilityInfo = copyFrom.HideAbilityInfo;
          bp.IsNonRemovable = copyFrom.IsNonRemovable;
          bp.m_EquipmentEntity = copyFrom.m_EquipmentEntity;
          bp.m_EquipmentEntityAlternatives = copyFrom.m_EquipmentEntityAlternatives;
          bp.m_ForcedRampColorPresetIndex = copyFrom.m_ForcedRampColorPresetIndex;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemEquipment.CR"/>
    /// </summary>
    public TBuilder SetCR(int cR)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CR = cR;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemEquipment.m_Ability"/>
    /// </summary>
    ///
    /// <param name="ability">
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAbility(Blueprint<BlueprintAbilityReference> ability)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Ability = ability?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItemEquipment.m_Ability"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAbility(Action<BlueprintAbilityReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Ability is null) { return; }
          action.Invoke(bp.m_Ability);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemEquipment.m_ActivatableAbility"/>
    /// </summary>
    ///
    /// <param name="activatableAbility">
    /// <para>
    /// Blueprint of type BlueprintActivatableAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetActivatableAbility(Blueprint<BlueprintActivatableAbilityReference> activatableAbility)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ActivatableAbility = activatableAbility?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItemEquipment.m_ActivatableAbility"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyActivatableAbility(Action<BlueprintActivatableAbilityReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ActivatableAbility is null) { return; }
          action.Invoke(bp.m_ActivatableAbility);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemEquipment.SpendCharges"/>
    /// </summary>
    public TBuilder SetSpendCharges(bool spendCharges = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SpendCharges = spendCharges;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemEquipment.Charges"/>
    /// </summary>
    public TBuilder SetCharges(int charges)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Charges = charges;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemEquipment.RestoreChargesOnRest"/>
    /// </summary>
    public TBuilder SetRestoreChargesOnRest(bool restoreChargesOnRest = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RestoreChargesOnRest = restoreChargesOnRest;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemEquipment.CasterLevel"/>
    /// </summary>
    public TBuilder SetCasterLevel(int casterLevel)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CasterLevel = casterLevel;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemEquipment.SpellLevel"/>
    /// </summary>
    public TBuilder SetSpellLevel(int spellLevel)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SpellLevel = spellLevel;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemEquipment.DC"/>
    /// </summary>
    public TBuilder SetDC(int dC)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DC = dC;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemEquipment.HideAbilityInfo"/>
    /// </summary>
    public TBuilder SetHideAbilityInfo(bool hideAbilityInfo = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HideAbilityInfo = hideAbilityInfo;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemEquipment.IsNonRemovable"/>
    /// </summary>
    public TBuilder SetIsNonRemovable(bool isNonRemovable = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsNonRemovable = isNonRemovable;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemEquipment.m_EquipmentEntity"/>
    /// </summary>
    ///
    /// <param name="equipmentEntity">
    /// <para>
    /// Blueprint of type KingmakerEquipmentEntity. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetEquipmentEntity(Blueprint<KingmakerEquipmentEntityReference> equipmentEntity)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_EquipmentEntity = equipmentEntity?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItemEquipment.m_EquipmentEntity"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyEquipmentEntity(Action<KingmakerEquipmentEntityReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_EquipmentEntity is null) { return; }
          action.Invoke(bp.m_EquipmentEntity);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemEquipment.m_EquipmentEntityAlternatives"/>
    /// </summary>
    ///
    /// <param name="equipmentEntityAlternatives">
    /// <para>
    /// Blueprint of type KingmakerEquipmentEntity. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetEquipmentEntityAlternatives(params Blueprint<KingmakerEquipmentEntityReference>[] equipmentEntityAlternatives)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_EquipmentEntityAlternatives = equipmentEntityAlternatives.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintItemEquipment.m_EquipmentEntityAlternatives"/>
    /// </summary>
    ///
    /// <param name="equipmentEntityAlternatives">
    /// <para>
    /// Blueprint of type KingmakerEquipmentEntity. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToEquipmentEntityAlternatives(params Blueprint<KingmakerEquipmentEntityReference>[] equipmentEntityAlternatives)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_EquipmentEntityAlternatives = bp.m_EquipmentEntityAlternatives ?? new KingmakerEquipmentEntityReference[0];
          bp.m_EquipmentEntityAlternatives = CommonTool.Append(bp.m_EquipmentEntityAlternatives, equipmentEntityAlternatives.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintItemEquipment.m_EquipmentEntityAlternatives"/>
    /// </summary>
    ///
    /// <param name="equipmentEntityAlternatives">
    /// <para>
    /// Blueprint of type KingmakerEquipmentEntity. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromEquipmentEntityAlternatives(params Blueprint<KingmakerEquipmentEntityReference>[] equipmentEntityAlternatives)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_EquipmentEntityAlternatives is null) { return; }
          bp.m_EquipmentEntityAlternatives = bp.m_EquipmentEntityAlternatives.Where(val => !equipmentEntityAlternatives.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintItemEquipment.m_EquipmentEntityAlternatives"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromEquipmentEntityAlternatives(Func<KingmakerEquipmentEntityReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_EquipmentEntityAlternatives is null) { return; }
          bp.m_EquipmentEntityAlternatives = bp.m_EquipmentEntityAlternatives.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintItemEquipment.m_EquipmentEntityAlternatives"/>
    /// </summary>
    public TBuilder ClearEquipmentEntityAlternatives()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_EquipmentEntityAlternatives = new KingmakerEquipmentEntityReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItemEquipment.m_EquipmentEntityAlternatives"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyEquipmentEntityAlternatives(Action<KingmakerEquipmentEntityReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_EquipmentEntityAlternatives is null) { return; }
          bp.m_EquipmentEntityAlternatives.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemEquipment.m_ForcedRampColorPresetIndex"/>
    /// </summary>
    public TBuilder SetForcedRampColorPresetIndex(int forcedRampColorPresetIndex)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ForcedRampColorPresetIndex = forcedRampColorPresetIndex;
        });
    }

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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddFactToEquipmentWielder(
        Blueprint<BlueprintUnitFactReference>? fact = null)
    {
      var component = new AddFactToEquipmentWielder();
      component.m_Fact = fact?.Reference ?? component.m_Fact;
      if (component.m_Fact is null)
      {
        component.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      return AddComponent(component);
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
    public TBuilder AddEquipmentRestrictionAlignment(params AlignmentMaskType[] alignment)
    {
      var component = new EquipmentRestrictionAlignment();
      component.Alignment = alignment.Aggregate((AlignmentMaskType) 0, (f1, f2) => f1 | f2);
      return AddComponent(component);
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
    public TBuilder AddEquipmentRestrictionCannotEquip()
    {
      return AddComponent(new EquipmentRestrictionCannotEquip());
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
    /// <item><term>HalfplateStandartPlus2</term><description>ce0076c7408f10741950cec394767b75</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddEquipmentRestrictionClass(
        Blueprint<BlueprintCharacterClassReference>? clazz = null,
        bool? not = null)
    {
      var component = new EquipmentRestrictionClass();
      component.m_Class = clazz?.Reference ?? component.m_Class;
      if (component.m_Class is null)
      {
        component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(null);
      }
      component.Not = not ?? component.Not;
      return AddComponent(component);
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
    /// <item><term>UltimatePredatorsGauntletsItem</term><description>c8ad87f3fc49ccd43a5560acb271e968</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddEquipmentRestrictionHasAnyClassFromList(
        List<Blueprint<BlueprintCharacterClassReference>>? classes = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? not = null)
    {
      var component = new EquipmentRestrictionHasAnyClassFromList();
      component.m_Classes = classes?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Classes;
      if (component.m_Classes is null)
      {
        component.m_Classes = new BlueprintCharacterClassReference[0];
      }
      component.Not = not ?? component.Not;
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// <item><term>TokenOfHonor</term><description>905ec00744cd4627b0e00f187e215d4b</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddEquipmentRestrictionMainPlayer(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new EquipmentRestrictionMainPlayer();
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    public TBuilder AddEquipmentRestrictionStat(
        int? minValue = null,
        StatType? stat = null)
    {
      var component = new EquipmentRestrictionStat();
      component.MinValue = minValue ?? component.MinValue;
      component.Stat = stat ?? component.Stat;
      return AddComponent(component);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Ability is null)
      {
        Blueprint.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      }
      if (Blueprint.m_ActivatableAbility is null)
      {
        Blueprint.m_ActivatableAbility = BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(null);
      }
      if (Blueprint.m_EquipmentEntity is null)
      {
        Blueprint.m_EquipmentEntity = BlueprintTool.GetRef<KingmakerEquipmentEntityReference>(null);
      }
      if (Blueprint.m_EquipmentEntityAlternatives is null)
      {
        Blueprint.m_EquipmentEntityAlternatives = new KingmakerEquipmentEntityReference[0];
      }
    }
  }
}
