//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using BlueprintCore.Utils.Types;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.AreaEffects;
using Kingmaker.UnitLogic.Buffs;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace BlueprintCore.Blueprints.Configurators.UnitLogic.Abilities
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAbilityAreaEffect"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAbilityAreaEffectConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintAbilityAreaEffect
    where TBuilder : BaseAbilityAreaEffectConfigurator<T, TBuilder>
  {
    protected BaseAbilityAreaEffectConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbilityAreaEffect.m_AllowNonContextActions"/>
    /// </summary>
    public TBuilder SetAllowNonContextActions(bool allowNonContextActions = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AllowNonContextActions = allowNonContextActions;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbilityAreaEffect.m_TargetType"/>
    /// </summary>
    public TBuilder SetTargetType(BlueprintAbilityAreaEffect.TargetType targetType)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TargetType = targetType;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbilityAreaEffect.m_Tags"/>
    /// </summary>
    ///
    /// <param name="tags">
    /// <para>
    /// Tooltip: Тэги имеют информационный характер для условной группировки эффектов.  DestroyableInCutscene - помечаются эффекты, которые необходимо удалять во время проигрывания катсцен и схожих событиях, так как они могут наносит урон игроку, вызывать визуальный шум и создавать прочие неудобства.
    /// </para>
    /// </param>
    public TBuilder SetTags(params AreaEffectTags[] tags)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Tags = tags.Aggregate((AreaEffectTags) 0, (f1, f2) => f1 | f2);
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintAbilityAreaEffect.m_Tags"/>
    /// </summary>
    ///
    /// <param name="tags">
    /// <para>
    /// Tooltip: Тэги имеют информационный характер для условной группировки эффектов.  DestroyableInCutscene - помечаются эффекты, которые необходимо удалять во время проигрывания катсцен и схожих событиях, так как они могут наносит урон игроку, вызывать визуальный шум и создавать прочие неудобства.
    /// </para>
    /// </param>
    public TBuilder AddToTags(params AreaEffectTags[] tags)
    {
      return OnConfigureInternal(
        bp =>
        {
          tags.ForEach(f => bp.m_Tags |= f);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAbilityAreaEffect.m_Tags"/>
    /// </summary>
    ///
    /// <param name="tags">
    /// <para>
    /// Tooltip: Тэги имеют информационный характер для условной группировки эффектов.  DestroyableInCutscene - помечаются эффекты, которые необходимо удалять во время проигрывания катсцен и схожих событиях, так как они могут наносит урон игроку, вызывать визуальный шум и создавать прочие неудобства.
    /// </para>
    /// </param>
    public TBuilder RemoveFromTags(params AreaEffectTags[] tags)
    {
      return OnConfigureInternal(
        bp =>
        {
          tags.ForEach(f => bp.m_Tags &= ~f);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbilityAreaEffect.SpellResistance"/>
    /// </summary>
    public TBuilder SetSpellResistance(bool spellResistance = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SpellResistance = spellResistance;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbilityAreaEffect.AffectEnemies"/>
    /// </summary>
    public TBuilder SetAffectEnemies(bool affectEnemies = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AffectEnemies = affectEnemies;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbilityAreaEffect.AggroEnemies"/>
    /// </summary>
    public TBuilder SetAggroEnemies(bool aggroEnemies = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AggroEnemies = aggroEnemies;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbilityAreaEffect.AffectDead"/>
    /// </summary>
    public TBuilder SetAffectDead(bool affectDead = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AffectDead = affectDead;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbilityAreaEffect.IgnoreSleepingUnits"/>
    /// </summary>
    public TBuilder SetIgnoreSleepingUnits(bool ignoreSleepingUnits = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IgnoreSleepingUnits = ignoreSleepingUnits;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbilityAreaEffect.Shape"/>
    /// </summary>
    public TBuilder SetShape(AreaEffectShape shape)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Shape = shape;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbilityAreaEffect.Size"/>
    /// </summary>
    public TBuilder SetSize(Feet size)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Size = size;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAbilityAreaEffect.Size"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySize(Action<Feet> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Size);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbilityAreaEffect.Fx"/>
    /// </summary>
    ///
    /// <param name="fx">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder SetFx(AssetLink<PrefabLink> fx)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Fx = fx?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAbilityAreaEffect.Fx"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFx(Action<PrefabLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Fx is null) { return; }
          action.Invoke(bp.Fx);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbilityAreaEffect.CanBeUsedInTacticalCombat"/>
    /// </summary>
    public TBuilder SetCanBeUsedInTacticalCombat(bool canBeUsedInTacticalCombat = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CanBeUsedInTacticalCombat = canBeUsedInTacticalCombat;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbilityAreaEffect.m_SizeInCells"/>
    /// </summary>
    ///
    /// <param name="sizeInCells">
    /// <para>
    /// InfoBox: For now, only Cylinder shapes and odd diameters can be used. 1 -&amp;gt; 1 cell, 3 -&amp;gt; 9 cells, ...
    /// </para>
    /// </param>
    public TBuilder SetSizeInCells(int sizeInCells)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SizeInCells = sizeInCells;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAbilityAreaEffect.m_TickRoundAfterSpawn"/>
    /// </summary>
    public TBuilder SetTickRoundAfterSpawn(bool tickRoundAfterSpawn = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TickRoundAfterSpawn = tickRoundAfterSpawn;
        });
    }

    /// <summary>
    /// Adds <see cref="ContextRankConfig"/>
    /// </summary>
    ///
    /// <remarks>
    /// <para>
    /// Use <see cref="Utils.Types.ContextRankConfigs"/> to create the ContextRankConfig component.
    /// </para>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>5_DeadStage_AcidBuff</term><description>96afbbab53c34c549a5313a1f7aed13b</description></item>
    /// <item><term>HellsSealVariantDevouringFlamesBuff</term><description>5617dbbb3890e2f4b96b47318c5c438b</description></item>
    /// <item><term>ZoneOfPredeterminationArea</term><description>1ff4dfed4f7eb504fa0447e93d1bcf64</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddContextRankConfig(ContextRankConfig component)
    {
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellDescriptorComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Abrikandilu_Frozen_Buff</term><description>b2df7031cdad480caddf962c894ca484</description></item>
    /// <item><term>HealingDomainBaseAbility</term><description>18f734e40dd7966438ab32086c3574e1</description></item>
    /// <item><term>ZachariusFearAuraBuff</term><description>4d9144b465bbefe4786cfe86c745ea4e</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddSpellDescriptorComponent(
        SpellDescriptorWrapper descriptor,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new SpellDescriptorComponent();
      component.Descriptor = descriptor;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ArmorWeightCoef"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PurifierCelestialArmorFeature</term><description>7dc8d7dede2704640956f7bc4102760a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddArmorWeightCoef(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        float? weightCoef = null)
    {
      var component = new ArmorWeightCoef();
      component.WeightCoef = weightCoef ?? component.WeightCoef;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="UniqueAreaEffect"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CloudBlizzardBlastArea</term><description>6ea87a0ff5df41c459d641326f9973d5</description></item>
    /// <item><term>WallChargedWaterBlastArea</term><description>724d174829a1c1949a4a7ba99cfb06a0</description></item>
    /// <item><term>WallWaterBlastArea</term><description>bb4ddd5e7d64a4a49ba71fe8275d1552</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="feature">
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
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddUniqueAreaEffect(
        Blueprint<BlueprintUnitFactReference>? feature = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new UniqueAreaEffect();
      component.m_Feature = feature?.Reference ?? component.m_Feature;
      if (component.m_Feature is null)
      {
        component.m_Feature = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateAbilityParams"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>1_FirstStage_AcidBuff</term><description>6afe27c9a2d64eb890673ff3649dacb3</description></item>
    /// <item><term>DeathsnatcherEnergyDrainFeature</term><description>e4c3976c40072a747b1a9ba2d8f166f2</description></item>
    /// <item><term>Yozz_Feature_AdditionalAttacks</term><description>bcf37abbb0b1485b83059600ed440881</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="customProperty">
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
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddContextCalculateAbilityParams(
        ContextValue? casterLevel = null,
        Blueprint<BlueprintUnitPropertyReference>? customProperty = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? replaceCasterLevel = null,
        bool? replaceSpellLevel = null,
        ContextValue? spellLevel = null,
        StatType? statType = null,
        bool? statTypeFromCustomProperty = null,
        bool? useKineticistMainStat = null)
    {
      var component = new ContextCalculateAbilityParams();
      component.CasterLevel = casterLevel ?? component.CasterLevel;
      if (component.CasterLevel is null)
      {
        component.CasterLevel = ContextValues.Constant(0);
      }
      component.m_CustomProperty = customProperty?.Reference ?? component.m_CustomProperty;
      if (component.m_CustomProperty is null)
      {
        component.m_CustomProperty = BlueprintTool.GetRef<BlueprintUnitPropertyReference>(null);
      }
      component.ReplaceCasterLevel = replaceCasterLevel ?? component.ReplaceCasterLevel;
      component.ReplaceSpellLevel = replaceSpellLevel ?? component.ReplaceSpellLevel;
      component.SpellLevel = spellLevel ?? component.SpellLevel;
      if (component.SpellLevel is null)
      {
        component.SpellLevel = ContextValues.Constant(0);
      }
      component.StatType = statType ?? component.StatType;
      component.StatTypeFromCustomProperty = statTypeFromCustomProperty ?? component.StatTypeFromCustomProperty;
      component.UseKineticistMainStat = useKineticistMainStat ?? component.UseKineticistMainStat;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateAbilityParamsBasedOnClass"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AirBlastAbility</term><description>31f668b12011e344aa542aa07ab6c8d9</description></item>
    /// <item><term>PlasmaBlastAbility</term><description>a5631955254ae5c4d9cc2d16870448a2</description></item>
    /// <item><term>XantirOnlySwarm_MidnightFaneInThePastFeature</term><description>5131c4b93f314bd4589edf612b4eb600</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="characterClass">
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
    public TBuilder AddContextCalculateAbilityParamsBasedOnClass(
        Blueprint<BlueprintCharacterClassReference>? characterClass = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        StatType? statType = null,
        bool? useKineticistMainStat = null)
    {
      var component = new ContextCalculateAbilityParamsBasedOnClass();
      component.m_CharacterClass = characterClass?.Reference ?? component.m_CharacterClass;
      if (component.m_CharacterClass is null)
      {
        component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(null);
      }
      component.StatType = statType ?? component.StatType;
      component.UseKineticistMainStat = useKineticistMainStat ?? component.UseKineticistMainStat;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateSharedValue"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbyssalCreatureAcidTemplate</term><description>6e6fda1c8a35069468e7398082cd30f5</description></item>
    /// <item><term>LeyLineGuardianConduitSurgeBuff</term><description>4770ff0074ebb6246ab1d09b9b261103</description></item>
    /// <item><term>WreckingBlowsEffectBuff</term><description>15dd42009de61334692b22fd7a576b79</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddContextCalculateSharedValue(
        double? modifier = null,
        ContextDiceValue? value = null,
        AbilitySharedValue? valueType = null)
    {
      var component = new ContextCalculateSharedValue();
      component.Modifier = modifier ?? component.Modifier;
      component.Value = value ?? component.Value;
      if (component.Value is null)
      {
        component.Value = Utils.Constants.Empty.DiceValue;
      }
      component.ValueType = valueType ?? component.ValueType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextSetAbilityParams"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbruptForceEnchantment</term><description>c31b3edcf2088a64e80133ebbd6374cb</description></item>
    /// <item><term>HellKnightOrderOfTheRackAbility</term><description>2714684e63581ed41b3b13b62d648621</description></item>
    /// <item><term>ZombieSlashingExplosion</term><description>f6b63adab8b645c8beb9cab170dac9d3</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="casterLevel">
    /// <para>
    /// InfoBox: If set to negative value, will be calculated by default mechanic. Positive or zero value will be set as is (plus bonuses)
    /// </para>
    /// </param>
    /// <param name="concentration">
    /// <para>
    /// InfoBox: If set to negative value, will be calculated by default mechanic. Positive or zero value will be set as is (plus bonuses)
    /// </para>
    /// </param>
    /// <param name="dC">
    /// <para>
    /// InfoBox: If set to negative value, will be calculated by default mechanic. Positive or zero value will be set as is (plus bonuses)
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="spellLevel">
    /// <para>
    /// InfoBox: If set to negative value, will be calculated by default mechanic. Positive or zero value will be set as is
    /// </para>
    /// </param>
    public TBuilder AddContextSetAbilityParams(
        bool? add10ToDC = null,
        ContextValue? casterLevel = null,
        ContextValue? concentration = null,
        ContextValue? dC = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        ContextValue? spellLevel = null)
    {
      var component = new ContextSetAbilityParams();
      component.Add10ToDC = add10ToDC ?? component.Add10ToDC;
      component.CasterLevel = casterLevel ?? component.CasterLevel;
      if (component.CasterLevel is null)
      {
        component.CasterLevel = ContextValues.Constant(0);
      }
      component.Concentration = concentration ?? component.Concentration;
      if (component.Concentration is null)
      {
        component.Concentration = ContextValues.Constant(0);
      }
      component.DC = dC ?? component.DC;
      if (component.DC is null)
      {
        component.DC = ContextValues.Constant(0);
      }
      component.SpellLevel = spellLevel ?? component.SpellLevel;
      if (component.SpellLevel is null)
      {
        component.SpellLevel = ContextValues.Constant(0);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityDifficultyLimitDC"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>StewardOfTheSkeinGazeBuff</term><description>4f18044ca197eb945b7d1b557dd9b447</description></item>
    /// <item><term>Weird</term><description>870af83be6572594d84d276d7fc583e0</description></item>
    /// <item><term>WildHunt_ScoutCrystalAbility</term><description>c470c62b38db74e4fb6b84b331beda30</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityDifficultyLimitDC(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityDifficultyLimitDC();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityAreaEffectBuff"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcidFogArea</term><description>f4dc3f53090627945b83f16ebf3146a6</description></item>
    /// <item><term>InspirationalLeaderArea</term><description>b62069a822cb9e841b1dec0b8cbc1670</description></item>
    /// <item><term>ZoneOfPredeterminationArea</term><description>1ff4dfed4f7eb504fa0447e93d1bcf64</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="buff">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
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
    public TBuilder AddAbilityAreaEffectBuff(
        Blueprint<BlueprintBuffReference>? buff = null,
        bool? checkConditionEveryRound = null,
        ConditionsBuilder? condition = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityAreaEffectBuff();
      component.m_Buff = buff?.Reference ?? component.m_Buff;
      if (component.m_Buff is null)
      {
        component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      component.CheckConditionEveryRound = checkConditionEveryRound ?? component.CheckConditionEveryRound;
      component.Condition = condition?.Build() ?? component.Condition;
      if (component.Condition is null)
      {
        component.Condition = Utils.Constants.Empty.Conditions;
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityAreaEffectMovement"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CloudkillArea</term><description>6df1ac314d4e6e9418e34470b79f90d8</description></item>
    /// <item><term>PlagueStormCackleFeverArea</term><description>6cae3c64989f3684bb078efcfa9021a1</description></item>
    /// <item><term>TsunamiArea</term><description>800daf41c11463742ad24efd71ab1916</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityAreaEffectMovement(
        Feet? distancePerRound = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityAreaEffectMovement();
      component.DistancePerRound = distancePerRound ?? component.DistancePerRound;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityAreaEffectRunAction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcidFogArea</term><description>f4dc3f53090627945b83f16ebf3146a6</description></item>
    /// <item><term>IncendiaryCloudArea</term><description>a892a67daaa08514cb62ad8dcab7bd90</description></item>
    /// <item><term>ZeorisDaggerRing_BetrayalArea</term><description>ccce3891532741ee91800c01b2304f53</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddAbilityAreaEffectRunAction(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        ActionsBuilder? round = null,
        ActionsBuilder? unitEnter = null,
        ActionsBuilder? unitExit = null,
        ActionsBuilder? unitMove = null)
    {
      var component = new AbilityAreaEffectRunAction();
      component.Round = round?.Build() ?? component.Round;
      if (component.Round is null)
      {
        component.Round = Utils.Constants.Empty.Actions;
      }
      component.UnitEnter = unitEnter?.Build() ?? component.UnitEnter;
      if (component.UnitEnter is null)
      {
        component.UnitEnter = Utils.Constants.Empty.Actions;
      }
      component.UnitExit = unitExit?.Build() ?? component.UnitExit;
      if (component.UnitExit is null)
      {
        component.UnitExit = Utils.Constants.Empty.Actions;
      }
      component.UnitMove = unitMove?.Build() ?? component.UnitMove;
      if (component.UnitMove is null)
      {
        component.UnitMove = Utils.Constants.Empty.Actions;
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbilityAreaEffectSpecialBehaviour"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DoombringingAura</term><description>9c1c22ea222df984388bc8b803033e10</description></item>
    /// <item><term>TreantAura</term><description>11e046f425592df4db61c31e1429db19</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="buff">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
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
    public TBuilder AddAbilityAreaEffectSpecialBehaviour(
        SpecialBehaviour? behaviour = null,
        Blueprint<BlueprintBuffReference>? buff = null,
        Buff? buffFact = null,
        int? count = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AbilityAreaEffectSpecialBehaviour();
      component.Behaviour = behaviour ?? component.Behaviour;
      component.m_Buff = buff?.Reference ?? component.m_Buff;
      if (component.m_Buff is null)
      {
        component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      Validate(buffFact);
      component.m_BuffFact = buffFact ?? component.m_BuffFact;
      component.m_Count = count ?? component.m_Count;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AbillityAreaEffectRoundFX"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>RuneOfJandelayArea</term><description>b2394fd9423c44a0a8bdb518b66e9266</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="prefabLink">
    /// You can pass in the animation using a PrefabLink or it's AssetId.
    /// </param>
    public TBuilder AddAbillityAreaEffectRoundFX(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        AssetLink<PrefabLink>? prefabLink = null)
    {
      var component = new AbillityAreaEffectRoundFX();
      component.PrefabLink = prefabLink?.Get() ?? component.PrefabLink;
      if (component.PrefabLink is null)
      {
        component.PrefabLink = Utils.Constants.Empty.PrefabLink;
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AreaEffectPit"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AcidPitArea</term><description>e122151e93e44e0488521aed9e51b617</description></item>
    /// <item><term>HungryPitArea</term><description>d086b1aeb367a5b43808d34c321955d1</description></item>
    /// <item><term>TricksterRecreationalPitArea</term><description>bf68ec704dc186549a7c6fbf22d3d661</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="effectsImmunityFacts">
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
    /// <param name="evadingImmunityFacts">
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
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="unitOnEdgeBuff">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="visualSettings">
    /// <para>
    /// Blueprint of type BlueprintAreaEffectPitVisualSettings. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddAreaEffectPit(
        ContextValue? climbDC = null,
        bool? disableClimb = null,
        List<Blueprint<BlueprintUnitFactReference>>? effectsImmunityFacts = null,
        List<Blueprint<BlueprintUnitFactReference>>? evadingImmunityFacts = null,
        ActionsBuilder? everyRoundAction = null,
        Size? maxUnitSize = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        ActionsBuilder? onEndedActionForUnitsInside = null,
        ActionsBuilder? onFallAction = null,
        Blueprint<BlueprintBuffReference>? unitOnEdgeBuff = null,
        Blueprint<BlueprintAreaEffectPitVisualSettingsReference>? visualSettings = null)
    {
      var component = new AreaEffectPit();
      component.ClimbDC = climbDC ?? component.ClimbDC;
      if (component.ClimbDC is null)
      {
        component.ClimbDC = ContextValues.Constant(0);
      }
      component.DisableClimb = disableClimb ?? component.DisableClimb;
      component.m_EffectsImmunityFacts = effectsImmunityFacts?.Select(bp => bp.Reference)?.ToArray() ?? component.m_EffectsImmunityFacts;
      if (component.m_EffectsImmunityFacts is null)
      {
        component.m_EffectsImmunityFacts = new BlueprintUnitFactReference[0];
      }
      component.m_EvadingImmunityFacts = evadingImmunityFacts?.Select(bp => bp.Reference)?.ToArray() ?? component.m_EvadingImmunityFacts;
      if (component.m_EvadingImmunityFacts is null)
      {
        component.m_EvadingImmunityFacts = new BlueprintUnitFactReference[0];
      }
      component.EveryRoundAction = everyRoundAction?.Build() ?? component.EveryRoundAction;
      if (component.EveryRoundAction is null)
      {
        component.EveryRoundAction = Utils.Constants.Empty.Actions;
      }
      component.MaxUnitSize = maxUnitSize ?? component.MaxUnitSize;
      component.OnEndedActionForUnitsInside = onEndedActionForUnitsInside?.Build() ?? component.OnEndedActionForUnitsInside;
      if (component.OnEndedActionForUnitsInside is null)
      {
        component.OnEndedActionForUnitsInside = Utils.Constants.Empty.Actions;
      }
      component.OnFallAction = onFallAction?.Build() ?? component.OnFallAction;
      if (component.OnFallAction is null)
      {
        component.OnFallAction = Utils.Constants.Empty.Actions;
      }
      component.UnitOnEdgeBuff = unitOnEdgeBuff?.Reference ?? component.UnitOnEdgeBuff;
      if (component.UnitOnEdgeBuff is null)
      {
        component.UnitOnEdgeBuff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      component.m_VisualSettings = visualSettings?.Reference ?? component.m_VisualSettings;
      if (component.m_VisualSettings is null)
      {
        component.m_VisualSettings = BlueprintTool.GetRef<BlueprintAreaEffectPitVisualSettingsReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="CustomAreaOnGrid"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmySummonGlabrezu</term><description>7453306a53e94766aad9fa716acaaada</description></item>
    /// <item><term>RangerExplosivesTrapAbility</term><description>8f684342b757e0f47adfb5edaaabc488</description></item>
    /// <item><term>RangerWeakeningTrapArea</term><description>f3c79a96342c37e4d9ec7cbe35dcbda0</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="affectedCells">
    /// <para>
    /// InfoBox: In relative coordinates where left-bottom cell is (0, 0)
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddCustomAreaOnGrid(
        List<Vector2Int>? affectedCells = null,
        bool? ignoreObstaclesAndUnits = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? spawnFxInEveryCell = null)
    {
      var component = new CustomAreaOnGrid();
      component.AffectedCells = affectedCells ?? component.AffectedCells;
      if (component.AffectedCells is null)
      {
        component.AffectedCells = new();
      }
      component.IgnoreObstaclesAndUnits = ignoreObstaclesAndUnits ?? component.IgnoreObstaclesAndUnits;
      component.SpawnFxInEveryCell = spawnFxInEveryCell ?? component.SpawnFxInEveryCell;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatCellsProviderLink"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyReachingStrikeActivatableAbility</term><description>6e8cad7fbb534154a0b3c83102e37323</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="abilityWithCellsProvider">
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
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTacticalCombatCellsProviderLink(
        Blueprint<BlueprintAbilityReference>? abilityWithCellsProvider = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TacticalCombatCellsProviderLink();
      component.m_AbilityWithCellsProvider = abilityWithCellsProvider?.Reference ?? component.m_AbilityWithCellsProvider;
      if (component.m_AbilityWithCellsProvider is null)
      {
        component.m_AbilityWithCellsProvider = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatResurrection"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmyChannelNegativeEnergyHealAbility</term><description>fe3524be49f748aa80f809778999bf59</description></item>
    /// <item><term>ArmyVampiricTouchOnHitNinjaPirates</term><description>540f87a0ae7d4caaa17596307b3586a6</description></item>
    /// <item><term>RitualJudgementDayAbility</term><description>814a31b50da1434aa9f8622b87157fda</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTacticalCombatResurrection(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TacticalCombatResurrection();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Fx is null)
      {
        Blueprint.Fx = Utils.Constants.Empty.PrefabLink;
      }
    }
  }
}
