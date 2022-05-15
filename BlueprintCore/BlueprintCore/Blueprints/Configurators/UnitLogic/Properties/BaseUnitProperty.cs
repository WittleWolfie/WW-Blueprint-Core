//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Assets.UnitLogic.Mechanics.Properties;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Class.Kineticist.Properties;
using Kingmaker.UnitLogic.Mechanics.Properties;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.UnitLogic.Properties
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintUnitProperty"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseUnitPropertyConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintUnitProperty
    where TBuilder : BaseUnitPropertyConfigurator<T, TBuilder>
  {
    protected BaseUnitPropertyConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnitProperty.BaseValue"/>
    /// </summary>
    public TBuilder SetBaseValue(int baseValue)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.BaseValue = baseValue;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnitProperty.BaseValue"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBaseValue(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.BaseValue);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnitProperty.OperationOnComponents"/>
    /// </summary>
    ///
    /// <param name="operationOnComponents">
    /// <para>
    /// InfoBox: Unit Property value is result for aggregating all getter components with given operation. Make sure that BaseValue for Multiply operation is not equals to 0
    /// </para>
    /// </param>
    public TBuilder SetOperationOnComponents(BlueprintUnitProperty.MathOperation operationOnComponents)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OperationOnComponents = operationOnComponents;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnitProperty.OperationOnComponents"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="operationOnComponents">
    /// <para>
    /// InfoBox: Unit Property value is result for aggregating all getter components with given operation. Make sure that BaseValue for Multiply operation is not equals to 0
    /// </para>
    /// </param>
    public TBuilder ModifyOperationOnComponents(Action<BlueprintUnitProperty.MathOperation> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.OperationOnComponents);
        });
    }

    /// <summary>
    /// Adds <see cref="CountCorpsesAroundPropertyGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DecaySpreaderProperty</term><description>3d9c37a06e8a4a6aa0dd5e2d80e207fe</description></item>
    /// <item><term>StewardsHelmetProperty</term><description>7276918a98694f84b80792c123cf15a0</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="onlyOfType">
    /// <para>
    /// Blueprint of type BlueprintUnitType. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddCountCorpsesAroundPropertyGetter(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        Blueprint<BlueprintUnitType, BlueprintUnitTypeReference>? onlyOfType = null,
        Feet? radius = null,
        PropertySettings? settings = null)
    {
      var component = new CountCorpsesAroundPropertyGetter();
      component.m_OnlyOfType = onlyOfType?.Reference ?? component.m_OnlyOfType;
      if (component.m_OnlyOfType is null)
      {
        component.m_OnlyOfType = BlueprintTool.GetRef<BlueprintUnitTypeReference>(null);
      }
      component.m_Radius = radius ?? component.m_Radius;
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="BaseAttackPropertyWithFeatureList"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CombatExpertiseAttackPenaltyProperty</term><description>8a63b06d20838954e97eb444f805ec89</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="features">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddBaseAttackPropertyWithFeatureList(
        int? baseAttackDiv = null,
        int? baseAttackZero = null,
        int? baseValue = null,
        int? featureBonus = null,
        List<Blueprint<BlueprintFeature, BlueprintFeatureReference>>? features = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        PropertySettings? settings = null)
    {
      var component = new BaseAttackPropertyWithFeatureList();
      component.BaseAttackDiv = baseAttackDiv ?? component.BaseAttackDiv;
      component.BaseAttackZero = baseAttackZero ?? component.BaseAttackZero;
      component.BaseValue = baseValue ?? component.BaseValue;
      component.FeatureBonus = featureBonus ?? component.FeatureBonus;
      component.m_Features = features?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Features;
      if (component.m_Features is null)
      {
        component.m_Features = new BlueprintFeatureReference[0];
      }
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="CurrentMeleeWeaponDamageStatGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>MainWeaponDamageStatBonusProperty</term><description>9955f9c72c350254daff5a029ee32712</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddCurrentMeleeWeaponDamageStatGetter(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        PropertySettings? settings = null)
    {
      var component = new CurrentMeleeWeaponDamageStatGetter();
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="CurrentWeaponCriticalMultiplierGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>MainWeaponCriticalModifierProperty</term><description>6ac8613eca0083d438b48f9e1391f09b</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddCurrentWeaponCriticalMultiplierGetter(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        PropertySettings? settings = null)
    {
      var component = new CurrentWeaponCriticalMultiplierGetter();
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="FightingDefensivelyACBonusProperty"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FightingDefensivelyACBonusProperty</term><description>fdf1a37b3173b4c41a6062515f754202</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="duelingFeatures">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="features">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddFightingDefensivelyACBonusProperty(
        List<Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>>? duelingFeatures = null,
        List<Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>>? features = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        PropertySettings? settings = null)
    {
      var component = new FightingDefensivelyACBonusProperty();
      component.m_DuelingFeatures = duelingFeatures?.Select(bp => bp.Reference)?.ToArray() ?? component.m_DuelingFeatures;
      if (component.m_DuelingFeatures is null)
      {
        component.m_DuelingFeatures = new BlueprintUnitFactReference[0];
      }
      component.m_Features = features?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Features;
      if (component.m_Features is null)
      {
        component.m_Features = new BlueprintUnitFactReference[0];
      }
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="FightingDefensivelyAttackPenaltyProperty"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FightingDefensivelyAttackPenaltyProperty</term><description>21a3e92a7b0f37d4e8581f7992864f30</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="duelingFeatures">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="features">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="halfBuff">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddFightingDefensivelyAttackPenaltyProperty(
        List<Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>>? duelingFeatures = null,
        List<Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>>? features = null,
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>? halfBuff = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        PropertySettings? settings = null)
    {
      var component = new FightingDefensivelyAttackPenaltyProperty();
      component.m_DuelingFeatures = duelingFeatures?.Select(bp => bp.Reference)?.ToArray() ?? component.m_DuelingFeatures;
      if (component.m_DuelingFeatures is null)
      {
        component.m_DuelingFeatures = new BlueprintUnitFactReference[0];
      }
      component.m_Features = features?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Features;
      if (component.m_Features is null)
      {
        component.m_Features = new BlueprintUnitFactReference[0];
      }
      component.m_HalfBuff = halfBuff?.Reference ?? component.m_HalfBuff;
      if (component.m_HalfBuff is null)
      {
        component.m_HalfBuff = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="KineticistBurnPropertyGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BurnNumberProperty</term><description>02c5943c77717974cb7fa1b7c0dc51f8</description></item>
    /// <item><term>KineticNonLethalDamageProperty</term><description>ac8b7875fff5c0643ac499d404947fff</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddKineticistBurnPropertyGetter(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        bool? multiplyOnClassLevel = null,
        bool? multyplyOnCharacterLevel = null,
        PropertySettings? settings = null)
    {
      var component = new KineticistBurnPropertyGetter();
      component.MultiplyOnClassLevel = multiplyOnClassLevel ?? component.MultiplyOnClassLevel;
      component.MultyplyOnCharacterLevel = multyplyOnCharacterLevel ?? component.MultyplyOnCharacterLevel;
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="KineticistMainStatBonusPropertyGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>KineticistMainStatProperty</term><description>f897845bbbc008d4f9c1c4a03e22357a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddKineticistMainStatBonusPropertyGetter(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        PropertySettings? settings = null)
    {
      var component = new KineticistMainStatBonusPropertyGetter();
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="StatBonusIfHasFactProperty"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>MythicChannelProperty</term><description>152e61de154108d489ff34b98066c25c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="requiredFact">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddStatBonusIfHasFactProperty(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        int? multiplier = null,
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>? requiredFact = null,
        PropertySettings? settings = null,
        StatType? stat = null)
    {
      var component = new StatBonusIfHasFactProperty();
      component.Multiplier = multiplier ?? component.Multiplier;
      component.m_RequiredFact = requiredFact?.Reference ?? component.m_RequiredFact;
      if (component.m_RequiredFact is null)
      {
        component.m_RequiredFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      component.Stat = stat ?? component.Stat;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AnimalPetOwnerRankGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SelfRelianceUnitProperty</term><description>0b7db8db78f2a884491c53a3fd9ba63a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAnimalPetOwnerRankGetter(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        UnitProperty? property = null,
        PropertySettings? settings = null)
    {
      var component = new AnimalPetOwnerRankGetter();
      component.Property = property ?? component.Property;
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AreaCrComplexGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_RageConfusionIslandDC</term><description>31f09fa9a9ea4d5887e06735dbe3701c</description></item>
    /// <item><term>HeavyEffectAreaCRGetterDamage</term><description>ae5d48090284494ea680860d10658204</description></item>
    /// <item><term>HeavyEffectAreaCRGetterDC9</term><description>6d7d0426bdf84a0c910200c52bd9787b</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAreaCrComplexGetter(
        int? bonus = null,
        int? denominator = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        int? multiplier = null,
        PropertySettings? settings = null)
    {
      var component = new AreaCrComplexGetter();
      component.Bonus = bonus ?? component.Bonus;
      component.Denominator = denominator ?? component.Denominator;
      component.Multiplier = multiplier ?? component.Multiplier;
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ClassLevelGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AssassinCreatePoisonAbilityProperty</term><description>0482fffc039d46fc86a86bda03e00f1a</description></item>
    /// <item><term>HellKnightOrderOfTheRackDCProperty</term><description>41f1001fac3d4464ad243e9abab51783</description></item>
    /// <item><term>ScaledFistACBonusProperty2</term><description>d71c095e672c4abfb068aa402899b3ec</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddClassLevelGetter(
        Blueprint<BlueprintCharacterClass, BlueprintCharacterClassReference>? clazz = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        PropertySettings? settings = null)
    {
      var component = new ClassLevelGetter();
      component.m_Class = clazz?.Reference ?? component.m_Class;
      if (component.m_Class is null)
      {
        component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(null);
      }
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="FactRankGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BearerOfSorrowProperty</term><description>5f462b3f7c405f24fac73c3e46e8c326</description></item>
    /// <item><term>TricksterLoreReligionKnowledgeDomainBaseProperty</term><description>7e78f0b1c281488090e66551c980dc5b</description></item>
    /// <item><term>TricksterLoreReligionWeatherDomainProperty</term><description>7747294b95e64edbb23e1ec5aca774e1</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddFactRankGetter(
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>? fact = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        PropertySettings? settings = null)
    {
      var component = new FactRankGetter();
      component.m_Fact = fact?.Reference ?? component.m_Fact;
      if (component.m_Fact is null)
      {
        component.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PropertyWithFactRankGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BrimorakAspectEffectProperty</term><description>d6a524d190f04a7ca3f920d2f96fa21b</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="rankMultiplier">
    /// <para>
    /// InfoBox: Multiplies Fact's Rank before progression calculation.
    /// </para>
    /// </param>
    public TBuilder AddPropertyWithFactRankGetter(
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>? fact = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        UnitProperty? property = null,
        int? rankMultiplier = null,
        PropertySettings? settings = null)
    {
      var component = new PropertyWithFactRankGetter();
      component.m_Fact = fact?.Reference ?? component.m_Fact;
      if (component.m_Fact is null)
      {
        component.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      component.m_Property = property ?? component.m_Property;
      component.m_RankMultiplier = rankMultiplier ?? component.m_RankMultiplier;
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ShieldBonusGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ShieldbearerRankProperty</term><description>c76f055879394c2d9a342ab66dac9d97</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddShieldBonusGetter(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        PropertySettings? settings = null)
    {
      var component = new ShieldBonusGetter();
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="SimplePropertyGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonAreaEffectsGazeProperty</term><description>f363c368c37546c3a4793b348963dc28</description></item>
    /// <item><term>PerfectFormCharismaToWisdomProperty</term><description>cb21d3aa6b4d4d9dbc5a17745645067d</description></item>
    /// <item><term>TricksterUseMagicDeviceTier3CLProperty</term><description>d533bfb6b6304ea3a0f8ce9d159704e9</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddSimplePropertyGetter(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        UnitProperty? property = null,
        PropertySettings? settings = null)
    {
      var component = new SimplePropertyGetter();
      component.Property = property ?? component.Property;
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="SkillRankGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BootsOfStampedeProperty</term><description>d6aa267ef9be46b49b5b6ea7e3982f67</description></item>
    /// <item><term>KillingPaceProperty</term><description>0233436119e84172bbbc0e9c555834dc</description></item>
    /// <item><term>TricksterTrickeryDCProperty</term><description>6c3a2c49afc84e0799be876c2193764b</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddSkillRankGetter(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        PropertySettings? settings = null,
        StatType? skill = null)
    {
      var component = new SkillRankGetter();
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      component.Skill = skill ?? component.Skill;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="SkillValueGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>TricksterStealthTier3Property</term><description>5175cafadfc249ddb2f39fc447d6bda1</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddSkillValueGetter(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        PropertySettings? settings = null,
        StatType? skill = null)
    {
      var component = new SkillValueGetter();
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      component.Skill = skill ?? component.Skill;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="SpellLevelGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_WildMagicDCTier1</term><description>11a3a4720f764ce6866236e4debe749c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddSpellLevelGetter(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        PropertySettings? settings = null)
    {
      var component = new SpellLevelGetter();
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="SummClassLevelGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DestructiveDispelProperty</term><description>13e4f1dd08954723b173335a54b48746</description></item>
    /// <item><term>WitchHexCasterLevelProperty</term><description>2d2243f4f3654512bdda92e80ef65b6d</description></item>
    /// <item><term>WitchHexSpellLevelProperty</term><description>75efe8b64a3a4cd09dda28cef156cfb5</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="archetype">
    /// <para>
    /// Blueprint of type BlueprintArchetype. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="archetypes">
    /// <para>
    /// Blueprint of type BlueprintArchetype. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="clazz">
    /// <para>
    /// Blueprint of type BlueprintCharacterClass. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddSummClassLevelGetter(
        Blueprint<BlueprintArchetype, BlueprintArchetypeReference>? archetype = null,
        List<Blueprint<BlueprintArchetype, BlueprintArchetypeReference>>? archetypes = null,
        List<Blueprint<BlueprintCharacterClass, BlueprintCharacterClassReference>>? clazz = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        PropertySettings? settings = null)
    {
      var component = new SummClassLevelGetter();
      component.Archetype = archetype?.Reference ?? component.Archetype;
      if (component.Archetype is null)
      {
        component.Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(null);
      }
      component.m_Archetypes = archetypes?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Archetypes;
      if (component.m_Archetypes is null)
      {
        component.m_Archetypes = new BlueprintArchetypeReference[0];
      }
      component.m_Class = clazz?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Class;
      if (component.m_Class is null)
      {
        component.m_Class = new BlueprintCharacterClassReference[0];
      }
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="CastingAttributeGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>RangerCastingStatProperty</term><description>2951aa1c8acc9e445968d667562901e5</description></item>
    /// <item><term>SylvanTricksterCastingStatProperty</term><description>86690c37305b7c34ab038200e773ed07</description></item>
    /// <item><term>WitchCastingStatProperty</term><description>f47851a7b8c3e6b46b57aa7e06052589</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddCastingAttributeGetter(
        bool? attributeBonus = null,
        Blueprint<BlueprintCharacterClass, BlueprintCharacterClassReference>? clazz = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        PropertySettings? settings = null)
    {
      var component = new CastingAttributeGetter();
      component.AttributeBonus = attributeBonus ?? component.AttributeBonus;
      component.m_Class = clazz?.Reference ?? component.m_Class;
      if (component.m_Class is null)
      {
        component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(null);
      }
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ComplexPropertyGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Angel4WardFromWeaknessProperty</term><description>077e52a62381442099143b51d9838d42</description></item>
    /// <item><term>RitualCauseFearMoraleProperty</term><description>f2e735840531c9e4dba5569dd673cc87</description></item>
    /// <item><term>WeakeningTrapAttackReductionProperty</term><description>6d5c72e8c0334621b1e6b4098ccc4750</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddComplexPropertyGetter(
        int? bonus = null,
        int? denominator = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        int? multiplier = null,
        UnitProperty? property = null,
        PropertySettings? settings = null)
    {
      var component = new ComplexPropertyGetter();
      component.Bonus = bonus ?? component.Bonus;
      component.Denominator = denominator ?? component.Denominator;
      component.Multiplier = multiplier ?? component.Multiplier;
      component.Property = property ?? component.Property;
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="MaxAttributeBonusGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonGazeDCProperty</term><description>4358468cba854a6db8f60909dacf8203</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddMaxAttributeBonusGetter(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        PropertySettings? settings = null)
    {
      var component = new MaxAttributeBonusGetter();
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="MaxCastingAttributeGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DestructiveDispelProperty</term><description>13e4f1dd08954723b173335a54b48746</description></item>
    /// <item><term>WitchHexDCProperty</term><description>bdc230ce338f427ba74de65597b0d57a</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddMaxCastingAttributeGetter(
        bool? attributeBonus = null,
        List<Blueprint<BlueprintCharacterClass, BlueprintCharacterClassReference>>? classes = null,
        StatType? defaultStat = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
        PropertySettings? settings = null)
    {
      var component = new MaxCastingAttributeGetter();
      component.AttributeBonus = attributeBonus ?? component.AttributeBonus;
      component.m_Classes = classes?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Classes;
      if (component.m_Classes is null)
      {
        component.m_Classes = new BlueprintCharacterClassReference[0];
      }
      component.DefaultStat = defaultStat ?? component.DefaultStat;
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }
  }
}
