using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.AreaEffects;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.Buffs;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Abilities
{
  /// <summary>Configurator for <see cref="BlueprintAbilityAreaEffect"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAbilityAreaEffect))]
  public class AbilityAreaEffectConfigurator
      : BaseBlueprintConfigurator<BlueprintAbilityAreaEffect, AbilityAreaEffectConfigurator>
  {
    private AbilityAreaEffectConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AbilityAreaEffectConfigurator For(string name) { return new AbilityAreaEffectConfigurator(name); }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AbilityAreaEffectConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintAbilityAreaEffect>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AbilityAreaEffectConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintAbilityAreaEffect>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbilityAreaEffect.m_TargetType"/>
    /// </summary>
    public AbilityAreaEffectConfigurator SetTargetType(BlueprintAbilityAreaEffect.TargetType type)
    {
      return OnConfigureInternal(blueprint => blueprint.m_TargetType = type);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbilityAreaEffect.SpellResistance"/>
    /// </summary>
    public AbilityAreaEffectConfigurator ApplySpellResistance(bool applySR = true)
    {
      return OnConfigureInternal(blueprint => blueprint.SpellResistance = applySR);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbilityAreaEffect.AffectEnemies"/>
    /// </summary>
    public AbilityAreaEffectConfigurator SetAffectEnemies(bool affectEnemies = true)
    {
      return OnConfigureInternal(blueprint => blueprint.AffectEnemies = affectEnemies);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbilityAreaEffect.AggroEnemies"/>
    /// </summary>
    public AbilityAreaEffectConfigurator SetAggroEnemies(bool aggro = false)
    {
      return OnConfigureInternal(blueprint => blueprint.AggroEnemies = aggro);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbilityAreaEffect.AffectDead"/>
    /// </summary>
    public AbilityAreaEffectConfigurator SetAffectDead(bool affectDead = true)
    {
      return OnConfigureInternal(blueprint => blueprint.AffectDead = affectDead);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbilityAreaEffect.IgnoreSleepingUnits"/>
    /// </summary>
    public AbilityAreaEffectConfigurator SetIgnoreSleepingUnits(bool ignore = true)
    {
      return OnConfigureInternal(blueprint => blueprint.IgnoreSleepingUnits = ignore);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbilityAreaEffect.Shape"/>
    /// </summary>
    public AbilityAreaEffectConfigurator SetShape(AreaEffectShape shape)
    {
      return OnConfigureInternal(blueprint => blueprint.Shape = shape);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbilityAreaEffect.Size"/>
    /// </summary>
    public AbilityAreaEffectConfigurator SetSize(int radiusInFeet)
    {
      return OnConfigureInternal(blueprint => blueprint.Size = new Feet(radiusInFeet));
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbilityAreaEffect.Fx"/>
    /// </summary>
    public AbilityAreaEffectConfigurator SetFx(PrefabLink prefab)
    {
      return OnConfigureInternal(blueprint => blueprint.Fx = prefab);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbilityAreaEffect.m_SizeInCells"/> and <see cref="BlueprintAbilityAreaEffect.CanBeUsedInTacticalCombat"/>
    /// </summary>
    /// 
    /// <remarks>Sets <see cref="BlueprintAbilityAreaEffect.CanBeUsedInTacticalCombat"/> to true.</remarks>
    /// <param name="sizeInCells">The game library states this can only be odd and will always be a cylinder.</param>
    public AbilityAreaEffectConfigurator SetSizeInTacticalCombat(int sizeInCells)
    {
      return OnConfigureInternal(
          blueprint =>
          {
            blueprint.m_SizeInCells = sizeInCells;
            blueprint.CanBeUsedInTacticalCombat = true;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAbilityAreaEffect.CanBeUsedInTacticalCombat"/>
    /// </summary>
    public AbilityAreaEffectConfigurator DisableInTacticalCombat()
    {
      return OnConfigureInternal(blueprint => blueprint.CanBeUsedInTacticalCombat = false);
    }


    /// <summary>
    /// Adds or modifies <see cref="SpellDescriptorComponent"/>
    /// </summary>
    [Implements(typeof(SpellDescriptorComponent))]
    public AbilityAreaEffectConfigurator AddSpellDescriptors(params SpellDescriptor[] descriptors)
    {
      foreach (SpellDescriptor descriptor in descriptors)
      {
        EnableSpellDescriptors |= (long)descriptor;
      }
      return Self;
    }

    /// <summary>
    /// Modifies <see cref="SpellDescriptorComponent"/>
    /// </summary>
    [Implements(typeof(SpellDescriptorComponent))]
    public AbilityAreaEffectConfigurator RemoveSpellDescriptors(params SpellDescriptor[] descriptors)
    {
      foreach (SpellDescriptor descriptor in descriptors)
      {
        DisableSpellDescriptors |= (long)descriptor;
      }
      return Self;
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.UnitLogic.Mechanics.Components.ContextRankConfig">ContextRankConfig</see>
    /// </summary>
    /// 
    /// <remarks>Use <see cref="Components.ContextRankConfigs">ContextRankConfigs</see> to create the config</remarks>
    [Implements(typeof(ContextRankConfig))]
    public AbilityAreaEffectConfigurator ContextRankConfig(ContextRankConfig rankConfig)
    {
      return AddComponent(rankConfig);
    }


    /// <summary>
    /// Adds <see cref="AreaEffectSpawnLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AreaEffectSpawnLogic))]
    public AbilityAreaEffectConfigurator AddAreaEffectSpawnLogic()
    {
      return AddComponent(new AreaEffectSpawnLogic());
    }

    /// <summary>
    /// Adds <see cref="UniqueAreaEffect"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Feature"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(UniqueAreaEffect))]
    public AbilityAreaEffectConfigurator AddUniqueAreaEffect(
        string m_Feature)
    {
      
      var component =  new UniqueAreaEffect();
      component.m_Feature = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_Feature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateAbilityParams"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CustomProperty"><see cref="BlueprintUnitProperty"/></param>
    [Generated]
    [Implements(typeof(ContextCalculateAbilityParams))]
    public AbilityAreaEffectConfigurator AddContextCalculateAbilityParams(
        bool UseKineticistMainStat,
        StatType StatType,
        bool StatTypeFromCustomProperty,
        string m_CustomProperty,
        bool ReplaceCasterLevel,
        ContextValue CasterLevel,
        bool ReplaceSpellLevel,
        ContextValue SpellLevel)
    {
      ValidateParam(UseKineticistMainStat);
      ValidateParam(StatType);
      ValidateParam(StatTypeFromCustomProperty);
      ValidateParam(ReplaceCasterLevel);
      ValidateParam(CasterLevel);
      ValidateParam(ReplaceSpellLevel);
      ValidateParam(SpellLevel);
      
      var component =  new ContextCalculateAbilityParams();
      component.UseKineticistMainStat = UseKineticistMainStat;
      component.StatType = StatType;
      component.StatTypeFromCustomProperty = StatTypeFromCustomProperty;
      component.m_CustomProperty = BlueprintTool.GetRef<BlueprintUnitPropertyReference>(m_CustomProperty);
      component.ReplaceCasterLevel = ReplaceCasterLevel;
      component.CasterLevel = CasterLevel;
      component.ReplaceSpellLevel = ReplaceSpellLevel;
      component.SpellLevel = SpellLevel;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateAbilityParamsBasedOnClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CharacterClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(ContextCalculateAbilityParamsBasedOnClass))]
    public AbilityAreaEffectConfigurator AddContextCalculateAbilityParamsBasedOnClass(
        bool UseKineticistMainStat,
        StatType StatType,
        string m_CharacterClass)
    {
      ValidateParam(UseKineticistMainStat);
      ValidateParam(StatType);
      
      var component =  new ContextCalculateAbilityParamsBasedOnClass();
      component.UseKineticistMainStat = UseKineticistMainStat;
      component.StatType = StatType;
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_CharacterClass);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateSharedValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextCalculateSharedValue))]
    public AbilityAreaEffectConfigurator AddContextCalculateSharedValue(
        AbilitySharedValue ValueType,
        ContextDiceValue Value,
        double Modifier)
    {
      ValidateParam(ValueType);
      ValidateParam(Value);
      ValidateParam(Modifier);
      
      var component =  new ContextCalculateSharedValue();
      component.ValueType = ValueType;
      component.Value = Value;
      component.Modifier = Modifier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextSetAbilityParams"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextSetAbilityParams))]
    public AbilityAreaEffectConfigurator AddContextSetAbilityParams(
        bool Add10ToDC,
        ContextValue DC,
        ContextValue CasterLevel,
        ContextValue Concentration,
        ContextValue SpellLevel)
    {
      ValidateParam(Add10ToDC);
      ValidateParam(DC);
      ValidateParam(CasterLevel);
      ValidateParam(Concentration);
      ValidateParam(SpellLevel);
      
      var component =  new ContextSetAbilityParams();
      component.Add10ToDC = Add10ToDC;
      component.DC = DC;
      component.CasterLevel = CasterLevel;
      component.Concentration = Concentration;
      component.SpellLevel = SpellLevel;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityDifficultyLimitDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityDifficultyLimitDC))]
    public AbilityAreaEffectConfigurator AddAbilityDifficultyLimitDC()
    {
      return AddComponent(new AbilityDifficultyLimitDC());
    }

    /// <summary>
    /// Adds <see cref="AbilityAreaEffectBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AbilityAreaEffectBuff))]
    public AbilityAreaEffectConfigurator AddAbilityAreaEffectBuff(
        ConditionsBuilder Condition,
        bool CheckConditionEveryRound,
        string m_Buff)
    {
      ValidateParam(CheckConditionEveryRound);
      
      var component =  new AbilityAreaEffectBuff();
      component.Condition = Condition.Build();
      component.CheckConditionEveryRound = CheckConditionEveryRound;
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityAreaEffectMovement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityAreaEffectMovement))]
    public AbilityAreaEffectConfigurator AddAbilityAreaEffectMovement(
        Feet DistancePerRound)
    {
      ValidateParam(DistancePerRound);
      
      var component =  new AbilityAreaEffectMovement();
      component.DistancePerRound = DistancePerRound;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityAreaEffectRunAction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityAreaEffectRunAction))]
    public AbilityAreaEffectConfigurator AddAbilityAreaEffectRunAction(
        ActionsBuilder UnitEnter,
        ActionsBuilder UnitExit,
        ActionsBuilder UnitMove,
        ActionsBuilder Round)
    {
      
      var component =  new AbilityAreaEffectRunAction();
      component.UnitEnter = UnitEnter.Build();
      component.UnitExit = UnitExit.Build();
      component.UnitMove = UnitMove.Build();
      component.Round = Round.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityAreaEffectSpecialBehaviour"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AbilityAreaEffectSpecialBehaviour))]
    public AbilityAreaEffectConfigurator AddAbilityAreaEffectSpecialBehaviour(
        SpecialBehaviour Behaviour,
        string m_Buff,
        Buff m_BuffFact,
        int m_Count)
    {
      ValidateParam(Behaviour);
      ValidateParam(m_BuffFact);
      ValidateParam(m_Count);
      
      var component =  new AbilityAreaEffectSpecialBehaviour();
      component.Behaviour = Behaviour;
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      component.m_BuffFact = m_BuffFact;
      component.m_Count = m_Count;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbillityAreaEffectRoundFX"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbillityAreaEffectRoundFX))]
    public AbilityAreaEffectConfigurator AddAbillityAreaEffectRoundFX(
        PrefabLink PrefabLink)
    {
      ValidateParam(PrefabLink);
      
      var component =  new AbillityAreaEffectRoundFX();
      component.PrefabLink = PrefabLink;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AreaEffectPit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_VisualSettings"><see cref="BlueprintAreaEffectPitVisualSettings"/></param>
    /// <param name="UnitOnEdgeBuff"><see cref="BlueprintBuff"/></param>
    /// <param name="m_EffectsImmunityFacts"><see cref="BlueprintUnitFact"/></param>
    /// <param name="m_EvadingImmunityFacts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AreaEffectPit))]
    public AbilityAreaEffectConfigurator AddAreaEffectPit(
        string m_VisualSettings,
        ContextValue ClimbDC,
        ActionsBuilder OnFallAction,
        ActionsBuilder EveryRoundAction,
        ActionsBuilder OnEndedActionForUnitsInside,
        string UnitOnEdgeBuff,
        Size MaxUnitSize,
        bool DisableClimb,
        string[] m_EffectsImmunityFacts,
        string[] m_EvadingImmunityFacts)
    {
      ValidateParam(ClimbDC);
      ValidateParam(MaxUnitSize);
      ValidateParam(DisableClimb);
      
      var component =  new AreaEffectPit();
      component.m_VisualSettings = BlueprintTool.GetRef<BlueprintAreaEffectPitVisualSettingsReference>(m_VisualSettings);
      component.ClimbDC = ClimbDC;
      component.OnFallAction = OnFallAction.Build();
      component.EveryRoundAction = EveryRoundAction.Build();
      component.OnEndedActionForUnitsInside = OnEndedActionForUnitsInside.Build();
      component.UnitOnEdgeBuff = BlueprintTool.GetRef<BlueprintBuffReference>(UnitOnEdgeBuff);
      component.MaxUnitSize = MaxUnitSize;
      component.DisableClimb = DisableClimb;
      component.m_EffectsImmunityFacts = m_EffectsImmunityFacts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      component.m_EvadingImmunityFacts = m_EvadingImmunityFacts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CustomAreaOnGrid"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CustomAreaOnGrid))]
    public AbilityAreaEffectConfigurator AddCustomAreaOnGrid(
        List<Vector2Int> AffectedCells,
        bool IgnoreObstaclesAndUnits,
        bool SpawnFxInEveryCell)
    {
      foreach (var item in AffectedCells)
      {
        ValidateParam(item);
      }
      ValidateParam(IgnoreObstaclesAndUnits);
      ValidateParam(SpawnFxInEveryCell);
      
      var component =  new CustomAreaOnGrid();
      component.AffectedCells = AffectedCells;
      component.IgnoreObstaclesAndUnits = IgnoreObstaclesAndUnits;
      component.SpawnFxInEveryCell = SpawnFxInEveryCell;
      return AddComponent(component);
    }  }
}
