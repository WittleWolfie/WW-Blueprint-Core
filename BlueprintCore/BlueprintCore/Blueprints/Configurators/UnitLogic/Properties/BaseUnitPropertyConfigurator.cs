//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Assets.UnitLogic.Mechanics.Properties;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UI.Common;
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
    protected BaseUnitPropertyConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintUnitProperty>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.BaseValue = copyFrom.BaseValue;
          bp.OperationOnComponents = copyFrom.OperationOnComponents;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintUnitProperty>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.BaseValue = copyFrom.BaseValue;
          bp.OperationOnComponents = copyFrom.OperationOnComponents;
        });
    }

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
    /// Adds <see cref="CountCorpsesAroundPropertyGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DecaySpreaderProperty</term><description>3d9c37a06e8a4a6aa0dd5e2d80e207fe</description></item>
    /// <item><term>DLC3_SicknessIslandCorpseProperty</term><description>9fc25f8a627d4260ae2d95b3e5395b1f</description></item>
    /// <item><term>StewardsHelmetProperty</term><description>7276918a98694f84b80792c123cf15a0</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="onlyOfType">
    /// <para>
    /// Blueprint of type BlueprintUnitType. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddCountCorpsesAroundPropertyGetter(
        Blueprint<BlueprintUnitTypeReference>? onlyOfType = null,
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
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BaseAtackGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CoupDeGraceAgregatorProperty</term><description>bd9224781e76429b92f0e60b13c079cc</description></item>
    /// <item><term>FeintPropertyBAB</term><description>e7b2296d485e4c25b4c745d5a7fe42cb</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddBaseAtackGetter(
        PropertySettings? settings = null)
    {
      var component = new BaseAtackGetter();
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddComponent(component);
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddBaseAttackPropertyWithFeatureList(
        int? baseAttackDiv = null,
        int? baseAttackZero = null,
        int? baseValue = null,
        int? featureBonus = null,
        List<Blueprint<BlueprintFeatureReference>>? features = null,
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
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CurrentMeleeWeaponDamageStatGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CoupDeGraceAgregatorProperty</term><description>bd9224781e76429b92f0e60b13c079cc</description></item>
    /// <item><term>DLC3_SplintershredGreataxeProperty</term><description>4418e0e12e5747a69b84abb29fd77c55</description></item>
    /// <item><term>MainWeaponDamageStatBonusProperty</term><description>9955f9c72c350254daff5a029ee32712</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddCurrentMeleeWeaponDamageStatGetter(
        PropertySettings? settings = null)
    {
      var component = new CurrentMeleeWeaponDamageStatGetter();
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CurrentWeaponCriticalMultiplierGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CoupDeGraceAgregatorProperty</term><description>bd9224781e76429b92f0e60b13c079cc</description></item>
    /// <item><term>MainWeaponCriticalModifierProperty</term><description>6ac8613eca0083d438b48f9e1391f09b</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddCurrentWeaponCriticalMultiplierGetter(
        PropertySettings? settings = null)
    {
      var component = new CurrentWeaponCriticalMultiplierGetter();
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddComponent(component);
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
    public TBuilder AddKineticistBurnPropertyGetter(
        bool? multiplyOnClassLevel = null,
        bool? multyplyOnCharacterLevel = null,
        PropertySettings? settings = null)
    {
      var component = new KineticistBurnPropertyGetter();
      component.MultiplyOnClassLevel = multiplyOnClassLevel ?? component.MultiplyOnClassLevel;
      component.MultyplyOnCharacterLevel = multyplyOnCharacterLevel ?? component.MultyplyOnCharacterLevel;
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddComponent(component);
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
    public TBuilder AddKineticistMainStatBonusPropertyGetter(
        PropertySettings? settings = null)
    {
      var component = new KineticistMainStatBonusPropertyGetter();
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddComponent(component);
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
    /// <param name="requiredFact">
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
    public TBuilder AddStatBonusIfHasFactProperty(
        int? multiplier = null,
        Blueprint<BlueprintUnitFactReference>? requiredFact = null,
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
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityResourceGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>UnitPropertyDrunken</term><description>d9b65b07fbb4447d995900ffcf42d387</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="abilityResource">
    /// <para>
    /// Blueprint of type BlueprintAbilityResource. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddAbilityResourceGetter(
        Blueprint<BlueprintAbilityResourceReference>? abilityResource = null,
        PropertySettings? settings = null)
    {
      var component = new AbilityResourceGetter();
      component.m_AbilityResource = abilityResource?.Reference ?? component.m_AbilityResource;
      if (component.m_AbilityResource is null)
      {
        component.m_AbilityResource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(null);
      }
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddComponent(component);
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
    public TBuilder AddAnimalPetOwnerRankGetter(
        UnitProperty? property = null,
        PropertySettings? settings = null)
    {
      var component = new AnimalPetOwnerRankGetter();
      component.Property = property ?? component.Property;
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArcaneSpellFailureChanceGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_ArmorPenaltyProperty</term><description>c6814940fdc04fd0935f59b03067b874</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddArcaneSpellFailureChanceGetter(
        PropertySettings? settings = null)
    {
      var component = new ArcaneSpellFailureChanceGetter();
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AreaCrComplexGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_ArcaneIslandModCRGetterProperty</term><description>41152617447b495ab0ad515aa58e1a49</description></item>
    /// <item><term>DLC3_WildMagicDCTier1</term><description>11a3a4720f764ce6866236e4debe749c</description></item>
    /// <item><term>HeavyEffectAreaCRGetterDC9</term><description>6d7d0426bdf84a0c910200c52bd9787b</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddAreaCrComplexGetter(
        int? bonus = null,
        int? denominator = null,
        int? multiplier = null,
        PropertySettings? settings = null)
    {
      var component = new AreaCrComplexGetter();
      component.Bonus = bonus ?? component.Bonus;
      component.Denominator = denominator ?? component.Denominator;
      component.Multiplier = multiplier ?? component.Multiplier;
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddComponent(component);
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
    /// <item><term>WordOfGodDCProperty</term><description>bab0e9d8395145a18f983224e023ff93</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="archetype">
    /// <para>
    /// Tooltip: Archetype filter: if specified and the unit does not have it, return 0.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintArchetype. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
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
    public TBuilder AddClassLevelGetter(
        Blueprint<BlueprintArchetypeReference>? archetype = null,
        Blueprint<BlueprintCharacterClassReference>? clazz = null,
        PropertySettings? settings = null)
    {
      var component = new ClassLevelGetter();
      component.m_Archetype = archetype?.Reference ?? component.m_Archetype;
      if (component.m_Archetype is null)
      {
        component.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(null);
      }
      component.m_Class = clazz?.Reference ?? component.m_Class;
      if (component.m_Class is null)
      {
        component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(null);
      }
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CompanionsCountGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_DwarvenBlessingProperty</term><description>7a2e877faaf14b88b1af878ea3f77aac</description></item>
    /// <item><term>DLC3_GnomeBlessingProperty</term><description>28185df8d2494e1e9ad56c626f89883a</description></item>
    /// <item><term>DLC3_HitDieHPRegainUniqueProperty</term><description>fb85ae5e942b452daab608856ae42100</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="archetypesExclude">
    /// <para>
    /// Blueprint of type BlueprintArchetype. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="archetypesInclude">
    /// <para>
    /// Blueprint of type BlueprintArchetype. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="classesExclude">
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
    /// <param name="classesInclude">
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
    /// <param name="racesExclude">
    /// <para>
    /// Blueprint of type BlueprintRace. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="racesInclude">
    /// <para>
    /// Blueprint of type BlueprintRace. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddCompanionsCountGetter(
        List<Blueprint<BlueprintArchetypeReference>>? archetypesExclude = null,
        List<Blueprint<BlueprintArchetypeReference>>? archetypesInclude = null,
        bool? checkActive = null,
        bool? checkCompanionArchetype = null,
        bool? checkCompanionClass = null,
        bool? checkCompanionRace = null,
        bool? checkDetached = null,
        bool? checkEx = null,
        bool? checkRemote = null,
        List<Blueprint<BlueprintCharacterClassReference>>? classesExclude = null,
        List<Blueprint<BlueprintCharacterClassReference>>? classesInclude = null,
        CompanionsCountGetter.AliveAndDead? countAliveAndDead = null,
        bool? countUnique = null,
        List<Blueprint<BlueprintRaceReference>>? racesExclude = null,
        List<Blueprint<BlueprintRaceReference>>? racesInclude = null,
        PropertySettings? settings = null)
    {
      var component = new CompanionsCountGetter();
      component.m_ArchetypesExclude = archetypesExclude?.Select(bp => bp.Reference)?.ToArray() ?? component.m_ArchetypesExclude;
      if (component.m_ArchetypesExclude is null)
      {
        component.m_ArchetypesExclude = new BlueprintArchetypeReference[0];
      }
      component.m_ArchetypesInclude = archetypesInclude?.Select(bp => bp.Reference)?.ToArray() ?? component.m_ArchetypesInclude;
      if (component.m_ArchetypesInclude is null)
      {
        component.m_ArchetypesInclude = new BlueprintArchetypeReference[0];
      }
      component.CheckActive = checkActive ?? component.CheckActive;
      component.CheckCompanionArchetype = checkCompanionArchetype ?? component.CheckCompanionArchetype;
      component.CheckCompanionClass = checkCompanionClass ?? component.CheckCompanionClass;
      component.CheckCompanionRace = checkCompanionRace ?? component.CheckCompanionRace;
      component.CheckDetached = checkDetached ?? component.CheckDetached;
      component.CheckEx = checkEx ?? component.CheckEx;
      component.CheckRemote = checkRemote ?? component.CheckRemote;
      component.m_ClassesExclude = classesExclude?.Select(bp => bp.Reference)?.ToArray() ?? component.m_ClassesExclude;
      if (component.m_ClassesExclude is null)
      {
        component.m_ClassesExclude = new BlueprintCharacterClassReference[0];
      }
      component.m_ClassesInclude = classesInclude?.Select(bp => bp.Reference)?.ToArray() ?? component.m_ClassesInclude;
      if (component.m_ClassesInclude is null)
      {
        component.m_ClassesInclude = new BlueprintCharacterClassReference[0];
      }
      component.CountAliveAndDead = countAliveAndDead ?? component.CountAliveAndDead;
      component.CountUnique = countUnique ?? component.CountUnique;
      component.m_RacesExclude = racesExclude?.Select(bp => bp.Reference)?.ToArray() ?? component.m_RacesExclude;
      if (component.m_RacesExclude is null)
      {
        component.m_RacesExclude = new BlueprintRaceReference[0];
      }
      component.m_RacesInclude = racesInclude?.Select(bp => bp.Reference)?.ToArray() ?? component.m_RacesInclude;
      if (component.m_RacesInclude is null)
      {
        component.m_RacesInclude = new BlueprintRaceReference[0];
      }
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CustomPropertyGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ShifterWolverineLevelProperty</term><description>fddca642fd7d4b5fab836d9e27bd5b2d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="property">
    /// <para>
    /// Blueprint of type BlueprintUnitProperty. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddCustomPropertyGetter(
        Blueprint<BlueprintUnitPropertyReference>? property = null,
        PropertySettings? settings = null)
    {
      var component = new CustomPropertyGetter();
      component.m_Property = property?.Reference ?? component.m_Property;
      if (component.m_Property is null)
      {
        component.m_Property = BlueprintTool.GetRef<BlueprintUnitPropertyReference>(null);
      }
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FactRankGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AnimateDeadProperty</term><description>7797b8f47b0f44369abef797e472acf0</description></item>
    /// <item><term>ShadowEvocationProperty</term><description>a6500531899940c2803695f26f513caa</description></item>
    /// <item><term>WordOfGodDCProperty</term><description>bab0e9d8395145a18f983224e023ff93</description></item>
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
    public TBuilder AddFactRankGetter(
        Blueprint<BlueprintUnitFactReference>? fact = null,
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
      return AddComponent(component);
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
    /// <item><term>DLC3_SplintershredGreataxeProperty</term><description>4418e0e12e5747a69b84abb29fd77c55</description></item>
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
    /// <param name="rankMultiplier">
    /// <para>
    /// InfoBox: Multiplies Fact&amp;apos;s Rank before progression calculation.
    /// </para>
    /// </param>
    public TBuilder AddPropertyWithFactRankGetter(
        Blueprint<BlueprintUnitFactReference>? fact = null,
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
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShieldBonusGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>MountedShieldUnitProperty</term><description>7e0d8bc634c04863aa2b891e750ec8df</description></item>
    /// <item><term>ShieldbearerRankProperty</term><description>c76f055879394c2d9a342ab66dac9d97</description></item>
    /// <item><term>ShieldBucklerMythicProperty</term><description>030c88da16b34dcf8d03f2680ac648d0</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="addShieldBonus">
    /// <para>
    /// InfoBox: Помимо основного бонуса, добавить зачарование
    /// </para>
    /// </param>
    /// <param name="addShieldFocus">
    /// <para>
    /// InfoBox: Также добавить фокус. Не будет работать корректно, если баф накладывается одновременно с надеванием щита - фокус рассчитывается в тот же момент и возникает конфликт времени исполнения.
    /// </para>
    /// </param>
    /// <param name="armorTypes">
    /// <para>
    /// Blueprint of type BlueprintArmorType. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="useArmorTypeFilter">
    /// <para>
    /// InfoBox: Если источник AC это блюпринт BlueprintItemArmor, то проверить его поле Type
    /// </para>
    /// </param>
    /// <param name="useItemTypeFilter">
    /// <para>
    /// InfoBox: BlueprintItemShield не даёт AC напрямую, для этого используется вложенный BlueprintItemArmor
    /// </para>
    /// </param>
    public TBuilder AddShieldBonusGetter(
        bool? addShieldBonus = null,
        bool? addShieldFocus = null,
        List<Blueprint<BlueprintArmorTypeReference>>? armorTypes = null,
        ItemsFilter.ItemType[]? itemTypes = null,
        bool? onlyFromItems = null,
        PropertySettings? settings = null,
        bool? useArmorTypeFilter = null,
        bool? useItemTypeFilter = null)
    {
      var component = new ShieldBonusGetter();
      component.AddShieldBonus = addShieldBonus ?? component.AddShieldBonus;
      component.AddShieldFocus = addShieldFocus ?? component.AddShieldFocus;
      component.ArmorTypes = armorTypes?.Select(bp => bp.Reference)?.ToArray() ?? component.ArmorTypes;
      if (component.ArmorTypes is null)
      {
        component.ArmorTypes = new BlueprintArmorTypeReference[0];
      }
      component.ItemTypes = itemTypes ?? component.ItemTypes;
      if (component.ItemTypes is null)
      {
        component.ItemTypes = new ItemsFilter.ItemType[0];
      }
      component.OnlyFromItems = onlyFromItems ?? component.OnlyFromItems;
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      component.UseArmorTypeFilter = useArmorTypeFilter ?? component.UseArmorTypeFilter;
      component.UseItemTypeFilter = useItemTypeFilter ?? component.UseItemTypeFilter;
      return AddComponent(component);
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
    /// <item><term>ExplodingArrowsKineticProperty</term><description>b98f2e23c10f4194b7568905bafba22c</description></item>
    /// <item><term>TricksterUseMagicDeviceTier3CLProperty</term><description>d533bfb6b6304ea3a0f8ce9d159704e9</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddSimplePropertyGetter(
        UnitProperty? property = null,
        PropertySettings? settings = null)
    {
      var component = new SimplePropertyGetter();
      component.Property = property ?? component.Property;
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddComponent(component);
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
    public TBuilder AddSkillRankGetter(
        PropertySettings? settings = null,
        StatType? skill = null)
    {
      var component = new SkillRankGetter();
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      component.Skill = skill ?? component.Skill;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SkillValueGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcaneSpiritProperty</term><description>0d7001b2514044a1a86d553543083125</description></item>
    /// <item><term>FeintPropertyMobility</term><description>7a3e6ab651804ad6ad0c0853450d92da</description></item>
    /// <item><term>TricksterStealthTier3Property</term><description>5175cafadfc249ddb2f39fc447d6bda1</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddSkillValueGetter(
        PropertySettings? settings = null,
        StatType? skill = null)
    {
      var component = new SkillValueGetter();
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      component.Skill = skill ?? component.Skill;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellLevelGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_DivineBlessingProperty</term><description>7de101b6b93044798663c7c51f2ec099</description></item>
    /// <item><term>DLC3_MixedMagicBlessingProperty</term><description>0c1d12b632484cca84a2888d17628d84</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddSpellLevelGetter(
        bool? fromCastRule = null,
        PropertySettings? settings = null)
    {
      var component = new SpellLevelGetter();
      component.FromCastRule = fromCastRule ?? component.FromCastRule;
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="StatValueGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AttackOfOpportunityCountProperty</term><description>b7fffcd88699431c88302b15b15fe837</description></item>
    /// <item><term>PerfectFormConstitutionToCharismaProperty</term><description>8dc476d6b7f94d73960fd68a57a7485e</description></item>
    /// <item><term>WordOfGodDCProperty</term><description>bab0e9d8395145a18f983224e023ff93</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddStatValueGetter(
        PropertySettings? settings = null,
        StatType? stat = null,
        StatValueGetter.ReturnType? valueType = null)
    {
      var component = new StatValueGetter();
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      component.Stat = stat ?? component.Stat;
      component.ValueType = valueType ?? component.ValueType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SummClassLevelGetter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BloodlineSerpentineSerpentsFangPoisonDCProperty</term><description>0225cc7431cc4e7eae07cc227f00f925</description></item>
    /// <item><term>MantisZealotMantisSwarmDCProperty</term><description>1a5e61241e70401c85846bdd146351b7</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="archetypes">
    /// <para>
    /// Blueprint of type BlueprintArchetype. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
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
    public TBuilder AddSummClassLevelGetter(
        Blueprint<BlueprintArchetypeReference>? archetype = null,
        List<Blueprint<BlueprintArchetypeReference>>? archetypes = null,
        List<Blueprint<BlueprintCharacterClassReference>>? clazz = null,
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
      return AddComponent(component);
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddCastingAttributeGetter(
        bool? attributeBonus = null,
        Blueprint<BlueprintCharacterClassReference>? clazz = null,
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
      return AddComponent(component);
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
    /// <item><term>RitualBlessDurationProperty</term><description>76dfe71d24782ef438436349b2fea12e</description></item>
    /// <item><term>WeakeningTrapAttackReductionProperty</term><description>6d5c72e8c0334621b1e6b4098ccc4750</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddComplexPropertyGetter(
        int? bonus = null,
        int? denominator = null,
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
      return AddComponent(component);
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
    public TBuilder AddMaxAttributeBonusGetter(
        PropertySettings? settings = null)
    {
      var component = new MaxAttributeBonusGetter();
      Validate(settings);
      component.Settings = settings ?? component.Settings;
      return AddComponent(component);
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
    /// <item><term>DirgeOfDoomDCProperty</term><description>c0196f56a1b64f2882b26cfb8f17ad45</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddMaxCastingAttributeGetter(
        bool? attributeBonus = null,
        List<Blueprint<BlueprintCharacterClassReference>>? classes = null,
        StatType? defaultStat = null,
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
      return AddComponent(component);
    }
  }
}
