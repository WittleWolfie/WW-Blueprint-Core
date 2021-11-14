using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Armies;
using Kingmaker.Armies.Components;
using Kingmaker.Armies.TacticalCombat.Brain;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.Armies.TacticalCombat.LeaderSkills;
using Kingmaker.Armies.TacticalCombat.LeaderSkills.UnitBuffComponents;
using Kingmaker.Assets.Armies.TacticalCombat.Components;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.CharGen;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Experience;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Blueprints.Root.Fx;
using Kingmaker.Controllers.Rest;
using Kingmaker.Controllers.Rest.Special;
using Kingmaker.Controllers.Rest.State;
using Kingmaker.Corruption;
using Kingmaker.Crusade.GlobalMagic;
using Kingmaker.Crusade.GlobalMagic.Actions;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Designers.Mechanics.Facts.Behavior;
using Kingmaker.Designers.TempMapCode.Ambush;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Persistence.Versioning;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.Kingdom;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.Settings;
using Kingmaker.UI.GenericSlot;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.AreaEffects;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.ActivatableAbilities.Restrictions;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.Buffs;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.Class.Kineticist;
using Kingmaker.UnitLogic.Class.Kineticist.ActivatableAbility;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Interaction;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Components.Fixers;
using Kingmaker.UnitLogic.Parts;
using Kingmaker.Utility;
using Kingmaker.View.MapObjects;
using Kingmaker.Visual;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using Owlcat.Runtime.Visual.Effects.WeatherSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>Configurator for <see cref="BlueprintUnit"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUnit))]
  public class UnitConfigurator : BaseUnitFactConfigurator<BlueprintUnit, UnitConfigurator>
  {
     private UnitConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnitConfigurator For(string name)
    {
      return new UnitConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static UnitConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintUnit>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnitConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintUnit>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Adds <see cref="AddEffectFastHealing"/>
    /// </summary>
    [Implements(typeof(AddEffectFastHealing))]
    public UnitConfigurator FastHealing(int baseValue, ContextValue bonusValue = null)
    {
      var fastHealing = new AddEffectFastHealing
      {
        Heal = baseValue,
        Bonus = bonusValue ?? 0
      };
      return AddComponent(fastHealing);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.Mechanics.Buffs.BuffSleeping">BuffSleeping</see>
    /// </summary>
    [Implements(typeof(BuffSleeping))]
    public UnitConfigurator BuffSleeping(
        int? wakeupPerceptionDC = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent> merge = null)
    {
      var sleeping = new BuffSleeping();
      if (wakeupPerceptionDC is not null) { sleeping.WakeupPerceptionDC = wakeupPerceptionDC.Value; }
      return AddUniqueComponent(sleeping, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="UnitUpgraderComponent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Upgraders"><see cref="BlueprintUnitUpgrader"/></param>
    [Generated]
    [Implements(typeof(UnitUpgraderComponent))]
    public UnitConfigurator AddUnitUpgraderComponent(
        string[] m_Upgraders)
    {
      
      var component =  new UnitUpgraderComponent();
      component.m_Upgraders = m_Upgraders.Select(bp => BlueprintTool.GetRef<BlueprintUnitUpgrader.Reference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddGlobalMapSpellFeature"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spell"><see cref="BlueprintGlobalMagicSpell"/></param>
    [Generated]
    [Implements(typeof(AddGlobalMapSpellFeature))]
    public UnitConfigurator AddAddGlobalMapSpellFeature(
        string m_Spell)
    {
      
      var component =  new AddGlobalMapSpellFeature();
      component.m_Spell = BlueprintTool.GetRef<BlueprintGlobalMagicSpell.Reference>(m_Spell);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CorruptionProtection"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CorruptionProtection))]
    public UnitConfigurator AddCorruptionProtection(
        bool m_RemoveRankAfterRest)
    {
      
      var component =  new CorruptionProtection();
      component.m_RemoveRankAfterRest = m_RemoveRankAfterRest;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="GlobalMapSpeedModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GlobalMapSpeedModifier))]
    public UnitConfigurator AddGlobalMapSpeedModifier(
        float SpeedModifier)
    {
      
      var component =  new GlobalMapSpeedModifier();
      component.SpeedModifier = SpeedModifier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RestRoleBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RestRoleBonus))]
    public UnitConfigurator AddRestRoleBonus(
        CampingRoleType m_RoleType,
        ModifierDescriptor m_Descriptor,
        ContextValue m_Value)
    {
      ValidateParam(m_RoleType);
      ValidateParam(m_Descriptor);
      ValidateParam(m_Value);
      
      var component =  new RestRoleBonus();
      component.m_RoleType = m_RoleType;
      component.m_Descriptor = m_Descriptor;
      component.m_Value = m_Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CampingSpecialAbility"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CampCutscene"><see cref="Cutscene"/></param>
    /// <param name="m_SelfBuff"><see cref="BlueprintBuff"/></param>
    /// <param name="m_PartyBuff"><see cref="BlueprintBuff"/></param>
    /// <param name="m_PartyBuffDuringCamp"><see cref="BlueprintBuff"/></param>
    /// <param name="m_SelfBuffOnRandomEncounter"><see cref="BlueprintBuff"/></param>
    /// <param name="m_PartyBuffOnRandomEncounter"><see cref="BlueprintBuff"/></param>
    /// <param name="m_EnemiesBuffOnRandomEncounter"><see cref="BlueprintBuff"/></param>
    /// <param name="m_DlcReward"><see cref="BlueprintDlcReward"/></param>
    [Generated]
    [Implements(typeof(CampingSpecialAbility))]
    public UnitConfigurator AddCampingSpecialAbility(
        LocalizedString Name,
        LocalizedString Description,
        CampPositionType CampPositionType,
        string m_CampCutscene,
        string m_SelfBuff,
        string m_PartyBuff,
        string m_PartyBuffDuringCamp,
        string m_SelfBuffOnRandomEncounter,
        string m_PartyBuffOnRandomEncounter,
        string m_EnemiesBuffOnRandomEncounter,
        int MinEnemyRandomEncounterBuffs,
        int MaxEnemyRandomEncounterBuffs,
        float RandomEncounterBuffsChance,
        int ExtraRations,
        CampingSpecialCustomMechanics CustomMechanics,
        string m_DlcReward)
    {
      ValidateParam(Name);
      ValidateParam(Description);
      ValidateParam(CampPositionType);
      ValidateParam(CustomMechanics);
      
      var component =  new CampingSpecialAbility();
      component.Name = Name;
      component.Description = Description;
      component.CampPositionType = CampPositionType;
      component.m_CampCutscene = BlueprintTool.GetRef<CutsceneReference>(m_CampCutscene);
      component.m_SelfBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_SelfBuff);
      component.m_PartyBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_PartyBuff);
      component.m_PartyBuffDuringCamp = BlueprintTool.GetRef<BlueprintBuffReference>(m_PartyBuffDuringCamp);
      component.m_SelfBuffOnRandomEncounter = BlueprintTool.GetRef<BlueprintBuffReference>(m_SelfBuffOnRandomEncounter);
      component.m_PartyBuffOnRandomEncounter = BlueprintTool.GetRef<BlueprintBuffReference>(m_PartyBuffOnRandomEncounter);
      component.m_EnemiesBuffOnRandomEncounter = BlueprintTool.GetRef<BlueprintBuffReference>(m_EnemiesBuffOnRandomEncounter);
      component.MinEnemyRandomEncounterBuffs = MinEnemyRandomEncounterBuffs;
      component.MaxEnemyRandomEncounterBuffs = MaxEnemyRandomEncounterBuffs;
      component.RandomEncounterBuffsChance = RandomEncounterBuffsChance;
      component.ExtraRations = ExtraRations;
      component.CustomMechanics = CustomMechanics;
      component.m_DlcReward = BlueprintTool.GetRef<BlueprintDlcRewardReference>(m_DlcReward);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OverrideAnimationRaceComponent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="BlueprintRace"><see cref="BlueprintRace"/></param>
    [Generated]
    [Implements(typeof(OverrideAnimationRaceComponent))]
    public UnitConfigurator AddOverrideAnimationRaceComponent(
        string BlueprintRace)
    {
      
      var component =  new OverrideAnimationRaceComponent();
      component.BlueprintRace = BlueprintTool.GetRef<BlueprintRaceReference>(BlueprintRace);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DualCompanionComponent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_PairCompanion"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(DualCompanionComponent))]
    public UnitConfigurator AddDualCompanionComponent(
        string m_PairCompanion)
    {
      
      var component =  new DualCompanionComponent();
      component.m_PairCompanion = BlueprintTool.GetRef<BlueprintUnitReference>(m_PairCompanion);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LockedCompanionComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LockedCompanionComponent))]
    public UnitConfigurator AddLockedCompanionComponent()
    {
      return AddComponent(new LockedCompanionComponent());
    }

    /// <summary>
    /// Adds <see cref="UnitAggroFilter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitAggroFilter))]
    public UnitConfigurator AddUnitAggroFilter(
        ConditionsBuilder FilterCondition,
        ActionsBuilder ActionsOnAggro)
    {
      
      var component =  new UnitAggroFilter();
      component.FilterCondition = FilterCondition.Build();
      component.ActionsOnAggro = ActionsOnAggro.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DisableAllFx"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DisableAllFx))]
    public UnitConfigurator AddDisableAllFx()
    {
      return AddComponent(new DisableAllFx());
    }

    /// <summary>
    /// Adds <see cref="ReplaceUnitBlueprintForRespec"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Blueprint"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(ReplaceUnitBlueprintForRespec))]
    public UnitConfigurator AddReplaceUnitBlueprintForRespec(
        string m_Blueprint)
    {
      
      var component =  new ReplaceUnitBlueprintForRespec();
      component.m_Blueprint = BlueprintTool.GetRef<BlueprintUnitReference>(m_Blueprint);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceUnitPrefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ReplaceUnitPrefab))]
    public UnitConfigurator AddReplaceUnitPrefab(
        PrefabLink m_Prefab)
    {
      ValidateParam(m_Prefab);
      
      var component =  new ReplaceUnitPrefab();
      component.m_Prefab = m_Prefab;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UnitIsStoryCompanion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitIsStoryCompanion))]
    public UnitConfigurator AddUnitIsStoryCompanion()
    {
      return AddComponent(new UnitIsStoryCompanion());
    }

    /// <summary>
    /// Adds <see cref="PretendUnit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Unit"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(PretendUnit))]
    public UnitConfigurator AddPretendUnit(
        string m_Unit)
    {
      
      var component =  new PretendUnit();
      component.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(m_Unit);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddClassLevels"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CharacterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_Archetypes"><see cref="BlueprintArchetype"/></param>
    /// <param name="m_SelectSpells"><see cref="BlueprintAbility"/></param>
    /// <param name="m_MemorizeSpells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddClassLevels))]
    public UnitConfigurator AddAddClassLevels(
        string m_CharacterClass,
        string[] m_Archetypes,
        int Levels,
        StatType RaceStat,
        StatType LevelsStat,
        StatType[] Skills,
        string[] m_SelectSpells,
        string[] m_MemorizeSpells,
        SelectionEntry[] Selections,
        bool DoNotApplyAutomatically)
    {
      ValidateParam(RaceStat);
      ValidateParam(LevelsStat);
      foreach (var item in Skills)
      {
        ValidateParam(item);
      }
      foreach (var item in Selections)
      {
        ValidateParam(item);
      }
      
      var component =  new AddClassLevels();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_CharacterClass);
      component.m_Archetypes = m_Archetypes.Select(bp => BlueprintTool.GetRef<BlueprintArchetypeReference>(bp)).ToArray();
      component.Levels = Levels;
      component.RaceStat = RaceStat;
      component.LevelsStat = LevelsStat;
      component.Skills = Skills;
      component.m_SelectSpells = m_SelectSpells.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      component.m_MemorizeSpells = m_MemorizeSpells.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      component.Selections = Selections;
      component.DoNotApplyAutomatically = DoNotApplyAutomatically;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ClassLevelLimit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ClassLevelLimit))]
    public UnitConfigurator AddClassLevelLimit(
        int LevelLimit)
    {
      
      var component =  new ClassLevelLimit();
      component.LevelLimit = LevelLimit;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MythicLevelLimit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MythicLevelLimit))]
    public UnitConfigurator AddMythicLevelLimit(
        int LevelLimit)
    {
      
      var component =  new MythicLevelLimit();
      component.LevelLimit = LevelLimit;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SuppressSpellSchool"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SuppressSpellSchool))]
    public UnitConfigurator AddSuppressSpellSchool(
        SuppressSpellSchool.Logic m_ComponentLogic,
        SpellSchool[] m_School)
    {
      ValidateParam(m_ComponentLogic);
      foreach (var item in m_School)
      {
        ValidateParam(item);
      }
      
      var component =  new SuppressSpellSchool();
      component.m_ComponentLogic = m_ComponentLogic;
      component.m_School = m_School;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Experience"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Experience))]
    public UnitConfigurator AddExperience(
        EncounterType Encounter,
        int CR,
        float Modifier,
        IntEvaluator Count,
        bool Dummy)
    {
      ValidateParam(Encounter);
      ValidateParam(Count);
      
      var component =  new Experience();
      component.Encounter = Encounter;
      component.CR = CR;
      component.Modifier = Modifier;
      component.Count = Count;
      component.Dummy = Dummy;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PregenUnitComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PregenUnitComponent))]
    public UnitConfigurator AddPregenUnitComponent(
        LocalizedString PregenName,
        LocalizedString PregenDescription,
        LocalizedString PregenClass,
        LocalizedString PregenRole)
    {
      ValidateParam(PregenName);
      ValidateParam(PregenDescription);
      ValidateParam(PregenClass);
      ValidateParam(PregenRole);
      
      var component =  new PregenUnitComponent();
      component.PregenName = PregenName;
      component.PregenDescription = PregenDescription;
      component.PregenClass = PregenClass;
      component.PregenRole = PregenRole;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AzataFavorableMagic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AzataFavorableMagic))]
    public UnitConfigurator AddAzataFavorableMagic()
    {
      return AddComponent(new AzataFavorableMagic());
    }

    /// <summary>
    /// Adds <see cref="DemonSocothbenothAspect"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DemonSocothbenothAspect))]
    public UnitConfigurator AddDemonSocothbenothAspect()
    {
      return AddComponent(new DemonSocothbenothAspect());
    }

    /// <summary>
    /// Adds <see cref="ActionsOnClick"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ActionsOnClick))]
    public UnitConfigurator AddActionsOnClick(
        ActionsBuilder Actions,
        float m_OverrideDistance,
        ConditionsBuilder Conditions,
        bool TriggerOnApproach,
        bool TriggerOnParty,
        float Cooldown)
    {
      
      var component =  new ActionsOnClick();
      component.Actions = Actions.Build();
      component.m_OverrideDistance = m_OverrideDistance;
      component.Conditions = Conditions.Build();
      component.TriggerOnApproach = TriggerOnApproach;
      component.TriggerOnParty = TriggerOnParty;
      component.Cooldown = Cooldown;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BarkOnClick"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BarkOnClick))]
    public UnitConfigurator AddBarkOnClick(
        LocalizedString Bark,
        bool ShowOnUser,
        float m_OverrideDistance,
        ConditionsBuilder Conditions,
        bool TriggerOnApproach,
        bool TriggerOnParty,
        float Cooldown)
    {
      ValidateParam(Bark);
      
      var component =  new BarkOnClick();
      component.Bark = Bark;
      component.ShowOnUser = ShowOnUser;
      component.m_OverrideDistance = m_OverrideDistance;
      component.Conditions = Conditions.Build();
      component.TriggerOnApproach = TriggerOnApproach;
      component.TriggerOnParty = TriggerOnParty;
      component.Cooldown = Cooldown;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DialogOnClick"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Dialog"><see cref="BlueprintDialog"/></param>
    [Generated]
    [Implements(typeof(DialogOnClick))]
    public UnitConfigurator AddDialogOnClick(
        string m_Dialog,
        ActionsBuilder NoDialogActions,
        float m_OverrideDistance,
        ConditionsBuilder Conditions,
        bool TriggerOnApproach,
        bool TriggerOnParty,
        float Cooldown)
    {
      
      var component =  new DialogOnClick();
      component.m_Dialog = BlueprintTool.GetRef<BlueprintDialogReference>(m_Dialog);
      component.NoDialogActions = NoDialogActions.Build();
      component.m_OverrideDistance = m_OverrideDistance;
      component.Conditions = Conditions.Build();
      component.TriggerOnApproach = TriggerOnApproach;
      component.TriggerOnParty = TriggerOnParty;
      component.Cooldown = Cooldown;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityUsagesCountTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityUsagesCountTrigger))]
    public UnitConfigurator AddAbilityUsagesCountTrigger(
        ContextValue m_TriggerCount,
        ActionsBuilder Action)
    {
      ValidateParam(m_TriggerCount);
      
      var component =  new AbilityUsagesCountTrigger();
      component.m_TriggerCount = m_TriggerCount;
      component.Action = Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AccomplishedSneakAttacker"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AccomplishedSneakAttacker))]
    public UnitConfigurator AddAccomplishedSneakAttacker(
        int Value)
    {
      
      var component =  new AccomplishedSneakAttacker();
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AcrobaticMovement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AcrobaticMovement))]
    public UnitConfigurator AddAcrobaticMovement()
    {
      return AddComponent(new AcrobaticMovement());
    }

    /// <summary>
    /// Adds <see cref="AddACBonusWithDistanceToMasterCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddACBonusWithDistanceToMasterCondition))]
    public UnitConfigurator AddAddACBonusWithDistanceToMasterCondition(
        ContextValue Value,
        ModifierDescriptor Descriptor,
        CompareOperation.Type CompareType,
        Feet Distance)
    {
      ValidateParam(Value);
      ValidateParam(Descriptor);
      ValidateParam(CompareType);
      ValidateParam(Distance);
      
      var component =  new AddACBonusWithDistanceToMasterCondition();
      component.Value = Value;
      component.Descriptor = Descriptor;
      component.CompareType = CompareType;
      component.Distance = Distance;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAbilityResourceTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Resource"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    [Implements(typeof(AddAbilityResourceTrigger))]
    public UnitConfigurator AddAddAbilityResourceTrigger(
        string m_Resource,
        ActionsBuilder Action)
    {
      
      var component =  new AddAbilityResourceTrigger();
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(m_Resource);
      component.Action = Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAbilityToCharacterComponent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Abilities"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddAbilityToCharacterComponent))]
    public UnitConfigurator AddAddAbilityToCharacterComponent(
        string[] m_Abilities)
    {
      
      var component =  new AddAbilityToCharacterComponent();
      component.m_Abilities = m_Abilities.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAbilityUseTargetTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spellbooks"><see cref="BlueprintSpellbook"/></param>
    /// <param name="m_Spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddAbilityUseTargetTrigger))]
    public UnitConfigurator AddAddAbilityUseTargetTrigger(
        ActionsBuilder Action,
        bool AfterCast,
        bool FromSpellbook,
        AbilityType Type,
        bool ToCaster,
        string[] m_Spellbooks,
        bool SpellList,
        string[] m_Spells,
        bool CheckDescriptor,
        SpellDescriptorWrapper SpellDescriptor)
    {
      ValidateParam(Type);
      ValidateParam(SpellDescriptor);
      
      var component =  new AddAbilityUseTargetTrigger();
      component.Action = Action.Build();
      component.AfterCast = AfterCast;
      component.FromSpellbook = FromSpellbook;
      component.Type = Type;
      component.ToCaster = ToCaster;
      component.m_Spellbooks = m_Spellbooks.Select(bp => BlueprintTool.GetRef<BlueprintSpellbookReference>(bp)).ToArray();
      component.SpellList = SpellList;
      component.m_Spells = m_Spells.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      component.CheckDescriptor = CheckDescriptor;
      component.SpellDescriptor = SpellDescriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAbilityUseTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spellbooks"><see cref="BlueprintSpellbook"/></param>
    /// <param name="m_Ability"><see cref="BlueprintAbility"/></param>
    /// <param name="Abilities"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddAbilityUseTrigger))]
    public UnitConfigurator AddAddAbilityUseTrigger(
        ActionsBuilder Action,
        bool ActionsOnAllTargets,
        bool AfterCast,
        bool ActionsOnTarget,
        bool FromSpellbook,
        string[] m_Spellbooks,
        bool ForOneSpell,
        string m_Ability,
        bool ForMultipleSpells,
        string[] Abilities,
        bool MinSpellLevel,
        int MinSpellLevelLimit,
        bool ExactSpellLevel,
        int ExactSpellLevelLimit,
        bool CheckAbilityType,
        AbilityType Type,
        bool CheckDescriptor,
        SpellDescriptorWrapper SpellDescriptor,
        bool CheckRange,
        AbilityRange Range)
    {
      ValidateParam(Type);
      ValidateParam(SpellDescriptor);
      ValidateParam(Range);
      
      var component =  new AddAbilityUseTrigger();
      component.Action = Action.Build();
      component.ActionsOnAllTargets = ActionsOnAllTargets;
      component.AfterCast = AfterCast;
      component.ActionsOnTarget = ActionsOnTarget;
      component.FromSpellbook = FromSpellbook;
      component.m_Spellbooks = m_Spellbooks.Select(bp => BlueprintTool.GetRef<BlueprintSpellbookReference>(bp)).ToArray();
      component.ForOneSpell = ForOneSpell;
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(m_Ability);
      component.ForMultipleSpells = ForMultipleSpells;
      component.Abilities = Abilities.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToList();
      component.MinSpellLevel = MinSpellLevel;
      component.MinSpellLevelLimit = MinSpellLevelLimit;
      component.ExactSpellLevel = ExactSpellLevel;
      component.ExactSpellLevelLimit = ExactSpellLevelLimit;
      component.CheckAbilityType = CheckAbilityType;
      component.Type = Type;
      component.CheckDescriptor = CheckDescriptor;
      component.SpellDescriptor = SpellDescriptor;
      component.CheckRange = CheckRange;
      component.Range = Range;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAdditionalLimb"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Weapon"><see cref="BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(AddAdditionalLimb))]
    public UnitConfigurator AddAddAdditionalLimb(
        string m_Weapon)
    {
      
      var component =  new AddAdditionalLimb();
      component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(m_Weapon);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAmbushBehaviour"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddAmbushBehaviour))]
    public UnitConfigurator AddAddAmbushBehaviour(
        float JoinCombatDisatnce)
    {
      
      var component =  new AddAmbushBehaviour();
      component.JoinCombatDisatnce = JoinCombatDisatnce;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBackgroundArmorProficiency"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddBackgroundArmorProficiency))]
    public UnitConfigurator AddAddBackgroundArmorProficiency(
        ArmorProficiencyGroup Proficiency,
        ContextValue StackBonus)
    {
      ValidateParam(Proficiency);
      ValidateParam(StackBonus);
      
      var component =  new AddBackgroundArmorProficiency();
      component.Proficiency = Proficiency;
      component.StackBonus = StackBonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBackgroundClassSkill"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddBackgroundClassSkill))]
    public UnitConfigurator AddAddBackgroundClassSkill(
        StatType Skill)
    {
      ValidateParam(Skill);
      
      var component =  new AddBackgroundClassSkill();
      component.Skill = Skill;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBackgroundWeaponProficiency"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddBackgroundWeaponProficiency))]
    public UnitConfigurator AddAddBackgroundWeaponProficiency(
        WeaponCategory Proficiency,
        ModifierDescriptor StackBonusType,
        ContextValue StackBonus)
    {
      ValidateParam(Proficiency);
      ValidateParam(StackBonusType);
      ValidateParam(StackBonus);
      
      var component =  new AddBackgroundWeaponProficiency();
      component.Proficiency = Proficiency;
      component.StackBonusType = StackBonusType;
      component.StackBonus = StackBonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBondProperty"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Enchant"><see cref="BlueprintItemEnchantment"/></param>
    [Generated]
    [Implements(typeof(AddBondProperty))]
    public UnitConfigurator AddAddBondProperty(
        EnchantPoolType EnchantPool,
        string m_Enchant)
    {
      ValidateParam(EnchantPool);
      
      var component =  new AddBondProperty();
      component.EnchantPool = EnchantPool;
      component.m_Enchant = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(m_Enchant);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBuffInBadWeather"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AddBuffInBadWeather))]
    public UnitConfigurator AddAddBuffInBadWeather(
        string m_Buff,
        InclemencyType Weather,
        bool WhenCalmer)
    {
      ValidateParam(Weather);
      
      var component =  new AddBuffInBadWeather();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      component.Weather = Weather;
      component.WhenCalmer = WhenCalmer;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBuffOnApplyingSpell"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddBuffOnApplyingSpell))]
    public UnitConfigurator AddAddBuffOnApplyingSpell(
        bool OnEffectApplied,
        bool OnResistSpell,
        AddBuffOnApplyingSpell.SpellConditionAndBuff[] Buffs)
    {
      foreach (var item in Buffs)
      {
        ValidateParam(item);
      }
      
      var component =  new AddBuffOnApplyingSpell();
      component.OnEffectApplied = OnEffectApplied;
      component.OnResistSpell = OnResistSpell;
      component.Buffs = Buffs;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddClassSkill"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddClassSkill))]
    public UnitConfigurator AddAddClassSkill(
        StatType Skill)
    {
      ValidateParam(Skill);
      
      var component =  new AddClassSkill();
      component.Skill = Skill;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddClusteredAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddClusteredAttack))]
    public UnitConfigurator AddAddClusteredAttack(
        AddClusteredAttack.Type AttackType)
    {
      ValidateParam(AttackType);
      
      var component =  new AddClusteredAttack();
      component.AttackType = AttackType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddConcealment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddConcealment))]
    public UnitConfigurator AddAddConcealment(
        ConcealmentDescriptor Descriptor,
        Concealment Concealment,
        bool CheckWeaponRangeType,
        WeaponRangeType RangeType,
        bool CheckDistance,
        Feet DistanceGreater,
        bool OnlyForAttacks)
    {
      ValidateParam(Descriptor);
      ValidateParam(Concealment);
      ValidateParam(RangeType);
      ValidateParam(DistanceGreater);
      
      var component =  new AddConcealment();
      component.Descriptor = Descriptor;
      component.Concealment = Concealment;
      component.CheckWeaponRangeType = CheckWeaponRangeType;
      component.RangeType = RangeType;
      component.CheckDistance = CheckDistance;
      component.DistanceGreater = DistanceGreater;
      component.OnlyForAttacks = OnlyForAttacks;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddCondition))]
    public UnitConfigurator AddAddCondition(
        UnitCondition Condition)
    {
      ValidateParam(Condition);
      
      var component =  new AddCondition();
      component.Condition = Condition;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddConditionImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddConditionImmunity))]
    public UnitConfigurator AddAddConditionImmunity(
        UnitCondition Condition)
    {
      ValidateParam(Condition);
      
      var component =  new AddConditionImmunity();
      component.Condition = Condition;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddConditionTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddConditionTrigger))]
    public UnitConfigurator AddAddConditionTrigger(
        AddConditionTrigger.TriggerType m_TriggerType,
        UnitCondition[] Conditions,
        ActionsBuilder Action)
    {
      ValidateParam(m_TriggerType);
      foreach (var item in Conditions)
      {
        ValidateParam(item);
      }
      
      var component =  new AddConditionTrigger();
      component.m_TriggerType = m_TriggerType;
      component.Conditions = Conditions;
      component.Action = Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddContextStatBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddContextStatBonus))]
    public UnitConfigurator AddAddContextStatBonus(
        ModifierDescriptor Descriptor,
        StatType Stat,
        int Multiplier,
        ContextValue Value,
        bool HasMinimal,
        int Minimal)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      ValidateParam(Value);
      
      var component =  new AddContextStatBonus();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.Multiplier = Multiplier;
      component.Value = Value;
      component.HasMinimal = HasMinimal;
      component.Minimal = Minimal;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCumulativeDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddCumulativeDamageBonus))]
    public UnitConfigurator AddAddCumulativeDamageBonus(
        bool OnlyNaturalAttacks)
    {
      
      var component =  new AddCumulativeDamageBonus();
      component.OnlyNaturalAttacks = OnlyNaturalAttacks;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCumulativeDamageBonusX3"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddCumulativeDamageBonusX3))]
    public UnitConfigurator AddAddCumulativeDamageBonusX3(
        bool OnlyNaturalAttacks)
    {
      
      var component =  new AddCumulativeDamageBonusX3();
      component.OnlyNaturalAttacks = OnlyNaturalAttacks;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddDamageResistanceEnergy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddDamageResistanceEnergy))]
    public UnitConfigurator AddAddDamageResistanceEnergy(
        DamageEnergyType Type,
        bool UseValueMultiplier,
        ContextValue ValueMultiplier,
        ContextValue Value,
        bool UsePool,
        ContextValue Pool)
    {
      ValidateParam(Type);
      ValidateParam(ValueMultiplier);
      ValidateParam(Value);
      ValidateParam(Pool);
      
      var component =  new AddDamageResistanceEnergy();
      component.Type = Type;
      component.UseValueMultiplier = UseValueMultiplier;
      component.ValueMultiplier = ValueMultiplier;
      component.Value = Value;
      component.UsePool = UsePool;
      component.Pool = Pool;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddDamageResistanceForce"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddDamageResistanceForce))]
    public UnitConfigurator AddAddDamageResistanceForce(
        DamageEnergyType Type,
        bool UseValueMultiplier,
        ContextValue ValueMultiplier,
        ContextValue Value,
        bool UsePool,
        ContextValue Pool)
    {
      ValidateParam(Type);
      ValidateParam(ValueMultiplier);
      ValidateParam(Value);
      ValidateParam(Pool);
      
      var component =  new AddDamageResistanceForce();
      component.Type = Type;
      component.UseValueMultiplier = UseValueMultiplier;
      component.ValueMultiplier = ValueMultiplier;
      component.Value = Value;
      component.UsePool = UsePool;
      component.Pool = Pool;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddDamageResistancePhysical"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_WeaponType"><see cref="BlueprintWeaponType"/></param>
    /// <param name="m_CheckedFactMythic"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddDamageResistancePhysical))]
    public UnitConfigurator AddAddDamageResistancePhysical(
        bool Or,
        bool BypassedByMaterial,
        PhysicalDamageMaterial Material,
        bool BypassedByForm,
        PhysicalDamageForm Form,
        bool BypassedByMagic,
        int MinEnhancementBonus,
        bool BypassedByAlignment,
        DamageAlignment Alignment,
        bool BypassedByReality,
        DamageRealityType Reality,
        bool BypassedByWeaponType,
        string m_WeaponType,
        bool BypassedByMeleeWeapon,
        bool BypassedByEpic,
        string m_CheckedFactMythic,
        ContextValue Value,
        bool UsePool,
        ContextValue Pool)
    {
      ValidateParam(Material);
      ValidateParam(Form);
      ValidateParam(Alignment);
      ValidateParam(Reality);
      ValidateParam(Value);
      ValidateParam(Pool);
      
      var component =  new AddDamageResistancePhysical();
      component.Or = Or;
      component.BypassedByMaterial = BypassedByMaterial;
      component.Material = Material;
      component.BypassedByForm = BypassedByForm;
      component.Form = Form;
      component.BypassedByMagic = BypassedByMagic;
      component.MinEnhancementBonus = MinEnhancementBonus;
      component.BypassedByAlignment = BypassedByAlignment;
      component.Alignment = Alignment;
      component.BypassedByReality = BypassedByReality;
      component.Reality = Reality;
      component.BypassedByWeaponType = BypassedByWeaponType;
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(m_WeaponType);
      component.BypassedByMeleeWeapon = BypassedByMeleeWeapon;
      component.BypassedByEpic = BypassedByEpic;
      component.m_CheckedFactMythic = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_CheckedFactMythic);
      component.Value = Value;
      component.UsePool = UsePool;
      component.Pool = Pool;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddDamageTypeVulnerability"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddDamageTypeVulnerability))]
    public UnitConfigurator AddAddDamageTypeVulnerability(
        bool PhyscicalForm,
        PhysicalDamageForm FormType,
        bool PhyscicalAlignment,
        DamageAlignment DamageAlignmentType,
        bool PhyscicalMaterial,
        PhysicalDamageMaterial MaterialType)
    {
      ValidateParam(FormType);
      ValidateParam(DamageAlignmentType);
      ValidateParam(MaterialType);
      
      var component =  new AddDamageTypeVulnerability();
      component.PhyscicalForm = PhyscicalForm;
      component.FormType = FormType;
      component.PhyscicalAlignment = PhyscicalAlignment;
      component.DamageAlignmentType = DamageAlignmentType;
      component.PhyscicalMaterial = PhyscicalMaterial;
      component.MaterialType = MaterialType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEnergyDamageDivisor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEnergyDamageDivisor))]
    public UnitConfigurator AddAddEnergyDamageDivisor()
    {
      return AddComponent(new AddEnergyDamageDivisor());
    }

    /// <summary>
    /// Adds <see cref="AddEnergyDamageImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEnergyDamageImmunity))]
    public UnitConfigurator AddAddEnergyDamageImmunity(
        DamageEnergyType EnergyType,
        bool HealOnDamage,
        AddEnergyDamageImmunity.HealingRate m_HealRate)
    {
      ValidateParam(EnergyType);
      ValidateParam(m_HealRate);
      
      var component =  new AddEnergyDamageImmunity();
      component.EnergyType = EnergyType;
      component.HealOnDamage = HealOnDamage;
      component.m_HealRate = m_HealRate;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEnergyImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEnergyImmunity))]
    public UnitConfigurator AddAddEnergyImmunity(
        DamageEnergyType Type)
    {
      ValidateParam(Type);
      
      var component =  new AddEnergyImmunity();
      component.Type = Type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEnergyVulnerability"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEnergyVulnerability))]
    public UnitConfigurator AddAddEnergyVulnerability(
        DamageEnergyType Type)
    {
      ValidateParam(Type);
      
      var component =  new AddEnergyVulnerability();
      component.Type = Type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEquipmentEntity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEquipmentEntity))]
    public UnitConfigurator AddAddEquipmentEntity(
        EquipmentEntityLink EquipmentEntity)
    {
      ValidateParam(EquipmentEntity);
      
      var component =  new AddEquipmentEntity();
      component.EquipmentEntity = EquipmentEntity;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFacts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Facts"><see cref="BlueprintUnitFact"/></param>
    /// <param name="Dummy"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(AddFacts))]
    public UnitConfigurator AddAddFacts(
        string[] m_Facts,
        string Dummy,
        int CasterLevel,
        bool DoNotRestoreMissingFacts,
        bool HasDifficultyRequirements,
        bool InvertDifficultyRequirements,
        GameDifficultyOption MinDifficulty)
    {
      ValidateParam(MinDifficulty);
      
      var component =  new AddFacts();
      component.m_Facts = m_Facts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      component.Dummy = BlueprintTool.GetRef<BlueprintUnitReference>(Dummy);
      component.CasterLevel = CasterLevel;
      component.DoNotRestoreMissingFacts = DoNotRestoreMissingFacts;
      component.HasDifficultyRequirements = HasDifficultyRequirements;
      component.InvertDifficultyRequirements = InvertDifficultyRequirements;
      component.MinDifficulty = MinDifficulty;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFactsFromCaster"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Facts"><see cref="BlueprintUnitFact"/></param>
    /// <param name="m_Selection"><see cref="BlueprintFeatureSelection"/></param>
    [Generated]
    [Implements(typeof(AddFactsFromCaster))]
    public UnitConfigurator AddAddFactsFromCaster(
        string[] m_Facts,
        bool FeatureFromSelection,
        string m_Selection)
    {
      
      var component =  new AddFactsFromCaster();
      component.m_Facts = m_Facts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      component.FeatureFromSelection = FeatureFromSelection;
      component.m_Selection = BlueprintTool.GetRef<BlueprintFeatureSelectionReference>(m_Selection);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFactsToMount"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddFactsToMount))]
    public UnitConfigurator AddAddFactsToMount(
        string[] m_Facts,
        int CasterLevel)
    {
      
      var component =  new AddFactsToMount();
      component.m_Facts = m_Facts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      component.CasterLevel = CasterLevel;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFallProneTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddFallProneTrigger))]
    public UnitConfigurator AddAddFallProneTrigger(
        ActionsBuilder Action)
    {
      
      var component =  new AddFallProneTrigger();
      component.Action = Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFamiliar"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddFamiliar))]
    public UnitConfigurator AddAddFamiliar(
        FamiliarLink PrefabLink,
        bool HideInCapital)
    {
      ValidateParam(PrefabLink);
      
      var component =  new AddFamiliar();
      component.PrefabLink = PrefabLink;
      component.HideInCapital = HideInCapital;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddForceMove"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddForceMove))]
    public UnitConfigurator AddAddForceMove(
        ContextValue FeetPerRound)
    {
      ValidateParam(FeetPerRound);
      
      var component =  new AddForceMove();
      component.FeetPerRound = FeetPerRound;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFortification"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddFortification))]
    public UnitConfigurator AddAddFortification(
        bool UseContextValue,
        int Bonus,
        ContextValue Value)
    {
      ValidateParam(Value);
      
      var component =  new AddFortification();
      component.UseContextValue = UseContextValue;
      component.Bonus = Bonus;
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFortificationObsolete"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddFortificationObsolete))]
    public UnitConfigurator AddAddFortificationObsolete(
        int Chance)
    {
      
      var component =  new AddFortificationObsolete();
      component.Chance = Chance;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddGoldenDragonSkillBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddGoldenDragonSkillBonus))]
    public UnitConfigurator AddAddGoldenDragonSkillBonus(
        ModifierDescriptor Descriptor,
        StatType Stat)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      
      var component =  new AddGoldenDragonSkillBonus();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddHealTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddHealTrigger))]
    public UnitConfigurator AddAddHealTrigger(
        ActionsBuilder Action,
        ActionsBuilder HealerAction,
        bool OnHealDamage,
        bool OnHealStatDamage,
        bool OnHealEnergyDrain,
        bool AllowZeroHealDamage,
        bool AllowZeroHealStatDamage,
        bool AllowZeroHealEnergyDrain)
    {
      
      var component =  new AddHealTrigger();
      component.Action = Action.Build();
      component.HealerAction = HealerAction.Build();
      component.OnHealDamage = OnHealDamage;
      component.OnHealStatDamage = OnHealStatDamage;
      component.OnHealEnergyDrain = OnHealEnergyDrain;
      component.AllowZeroHealDamage = AllowZeroHealDamage;
      component.AllowZeroHealStatDamage = AllowZeroHealStatDamage;
      component.AllowZeroHealEnergyDrain = AllowZeroHealEnergyDrain;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddIdentifyBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddIdentifyBonus))]
    public UnitConfigurator AddAddIdentifyBonus(
        bool AllowUsingUntrainedSkill,
        ContextValue Bonus,
        ContextValue SpellBonus)
    {
      ValidateParam(Bonus);
      ValidateParam(SpellBonus);
      
      var component =  new AddIdentifyBonus();
      component.AllowUsingUntrainedSkill = AllowUsingUntrainedSkill;
      component.Bonus = Bonus;
      component.SpellBonus = SpellBonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddImmortality"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddImmortality))]
    public UnitConfigurator AddAddImmortality()
    {
      return AddComponent(new AddImmortality());
    }

    /// <summary>
    /// Adds <see cref="AddImmunityFirebrand"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddImmunityFirebrand))]
    public UnitConfigurator AddAddImmunityFirebrand()
    {
      return AddComponent(new AddImmunityFirebrand());
    }

    /// <summary>
    /// Adds <see cref="AddImmunityToAbilityScoreDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddImmunityToAbilityScoreDamage))]
    public UnitConfigurator AddAddImmunityToAbilityScoreDamage(
        bool Drain,
        StatType[] StatTypes)
    {
      foreach (var item in StatTypes)
      {
        ValidateParam(item);
      }
      
      var component =  new AddImmunityToAbilityScoreDamage();
      component.Drain = Drain;
      component.StatTypes = StatTypes;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddImmunityToCriticalHits"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddImmunityToCriticalHits))]
    public UnitConfigurator AddAddImmunityToCriticalHits()
    {
      return AddComponent(new AddImmunityToCriticalHits());
    }

    /// <summary>
    /// Adds <see cref="AddImmunityToEnergyDrain"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddImmunityToEnergyDrain))]
    public UnitConfigurator AddAddImmunityToEnergyDrain()
    {
      return AddComponent(new AddImmunityToEnergyDrain());
    }

    /// <summary>
    /// Adds <see cref="AddImmunityToPrecisionDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddImmunityToPrecisionDamage))]
    public UnitConfigurator AddAddImmunityToPrecisionDamage()
    {
      return AddComponent(new AddImmunityToPrecisionDamage());
    }

    /// <summary>
    /// Adds <see cref="AddIncomingDamageWeaponProperty"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_WeaponType"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(AddIncomingDamageWeaponProperty))]
    public UnitConfigurator AddAddIncomingDamageWeaponProperty(
        bool AddMagic,
        bool AddMaterial,
        PhysicalDamageMaterial Material,
        bool AddForm,
        PhysicalDamageForm Form,
        bool AddAlignment,
        DamageAlignment Alignment,
        bool AddReality,
        DamageRealityType Reality,
        bool CheckWeaponType,
        string m_WeaponType,
        bool CheckRange,
        bool IsRanged)
    {
      ValidateParam(Material);
      ValidateParam(Form);
      ValidateParam(Alignment);
      ValidateParam(Reality);
      
      var component =  new AddIncomingDamageWeaponProperty();
      component.AddMagic = AddMagic;
      component.AddMaterial = AddMaterial;
      component.Material = Material;
      component.AddForm = AddForm;
      component.Form = Form;
      component.AddAlignment = AddAlignment;
      component.Alignment = Alignment;
      component.AddReality = AddReality;
      component.Reality = Reality;
      component.CheckWeaponType = CheckWeaponType;
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(m_WeaponType);
      component.CheckRange = CheckRange;
      component.IsRanged = IsRanged;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddIncorporealDamageDivisor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddIncorporealDamageDivisor))]
    public UnitConfigurator AddAddIncorporealDamageDivisor()
    {
      return AddComponent(new AddIncorporealDamageDivisor());
    }

    /// <summary>
    /// Adds <see cref="AddInitiatorHealTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddInitiatorHealTrigger))]
    public UnitConfigurator AddAddInitiatorHealTrigger(
        ActionsBuilder Action,
        ActionsBuilder HealerAction,
        bool OnHealDamage,
        bool OnHealStatDamage,
        bool OnHealEnergyDrain)
    {
      
      var component =  new AddInitiatorHealTrigger();
      component.Action = Action.Build();
      component.HealerAction = HealerAction.Build();
      component.OnHealDamage = OnHealDamage;
      component.OnHealStatDamage = OnHealStatDamage;
      component.OnHealEnergyDrain = OnHealEnergyDrain;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddItemCasterLevelBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddItemCasterLevelBonus))]
    public UnitConfigurator AddAddItemCasterLevelBonus(
        int Bonus,
        UsableItemType ItemType)
    {
      ValidateParam(ItemType);
      
      var component =  new AddItemCasterLevelBonus();
      component.Bonus = Bonus;
      component.ItemType = ItemType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddKnownSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CharacterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_Spell"><see cref="BlueprintAbility"/></param>
    /// <param name="m_Archetype"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(AddKnownSpell))]
    public UnitConfigurator AddAddKnownSpell(
        string m_CharacterClass,
        int SpellLevel,
        string m_Spell,
        string m_Archetype)
    {
      
      var component =  new AddKnownSpell();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_CharacterClass);
      component.SpellLevel = SpellLevel;
      component.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(m_Spell);
      component.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(m_Archetype);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddLocustSwarmMechanicPart"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddLocustSwarmMechanicPart))]
    public UnitConfigurator AddAddLocustSwarmMechanicPart(
        int m_SwarmStartStrength)
    {
      
      var component =  new AddLocustSwarmMechanicPart();
      component.m_SwarmStartStrength = m_SwarmStartStrength;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddLoot"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Loot"><see cref="BlueprintUnitLoot"/></param>
    [Generated]
    [Implements(typeof(AddLoot))]
    public UnitConfigurator AddAddLoot(
        string m_Loot)
    {
      
      var component =  new AddLoot();
      component.m_Loot = BlueprintTool.GetRef<BlueprintUnitLootReference>(m_Loot);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddLootToVendorTable"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Loot"><see cref="BlueprintUnitLoot"/></param>
    [Generated]
    [Implements(typeof(AddLootToVendorTable))]
    public UnitConfigurator AddAddLootToVendorTable(
        string m_Loot)
    {
      
      var component =  new AddLootToVendorTable();
      component.m_Loot = BlueprintTool.GetRef<BlueprintUnitLootReference>(m_Loot);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddMagusMechanicPart"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddMagusMechanicPart))]
    public UnitConfigurator AddAddMagusMechanicPart(
        AddMagusMechanicPart.Feature m_Feature)
    {
      ValidateParam(m_Feature);
      
      var component =  new AddMagusMechanicPart();
      component.m_Feature = m_Feature;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddMechanicsFeature"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddMechanicsFeature))]
    public UnitConfigurator AddAddMechanicsFeature(
        AddMechanicsFeature.MechanicsFeatureType m_Feature)
    {
      ValidateParam(m_Feature);
      
      var component =  new AddMechanicsFeature();
      component.m_Feature = m_Feature;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddMetamagicFeat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddMetamagicFeat))]
    public UnitConfigurator AddAddMetamagicFeat(
        Metamagic Metamagic)
    {
      ValidateParam(Metamagic);
      
      var component =  new AddMetamagicFeat();
      component.Metamagic = Metamagic;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddMythicEnemyHitPointsBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddMythicEnemyHitPointsBonus))]
    public UnitConfigurator AddAddMythicEnemyHitPointsBonus()
    {
      return AddComponent(new AddMythicEnemyHitPointsBonus());
    }

    /// <summary>
    /// Adds <see cref="AddNimbusDamageDivisor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddNimbusDamageDivisor))]
    public UnitConfigurator AddAddNimbusDamageDivisor(
        AddNimbusDamageDivisor.NimbusType m_Type)
    {
      ValidateParam(m_Type);
      
      var component =  new AddNimbusDamageDivisor();
      component.m_Type = m_Type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddNocticulaBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddNocticulaBonus))]
    public UnitConfigurator AddAddNocticulaBonus(
        ModifierDescriptor Descriptor,
        ContextValue HighestStatBonus,
        StatType m_HighestStat,
        ContextValue SecondHighestStatBonus,
        StatType m_SecondHighestStat)
    {
      ValidateParam(Descriptor);
      ValidateParam(HighestStatBonus);
      ValidateParam(m_HighestStat);
      ValidateParam(SecondHighestStatBonus);
      ValidateParam(m_SecondHighestStat);
      
      var component =  new AddNocticulaBonus();
      component.Descriptor = Descriptor;
      component.HighestStatBonus = HighestStatBonus;
      component.m_HighestStat = m_HighestStat;
      component.SecondHighestStatBonus = SecondHighestStatBonus;
      component.m_SecondHighestStat = m_SecondHighestStat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddOffensiveActionTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddOffensiveActionTrigger))]
    public UnitConfigurator AddAddOffensiveActionTrigger(
        ActionsBuilder Action)
    {
      
      var component =  new AddOffensiveActionTrigger();
      component.Action = Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddOppositionDescriptor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CharacterClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(AddOppositionDescriptor))]
    public UnitConfigurator AddAddOppositionDescriptor(
        string m_CharacterClass,
        SpellDescriptorWrapper m_Descriptor)
    {
      ValidateParam(m_Descriptor);
      
      var component =  new AddOppositionDescriptor();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_CharacterClass);
      component.m_Descriptor = m_Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddOppositionSchool"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CharacterClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(AddOppositionSchool))]
    public UnitConfigurator AddAddOppositionSchool(
        string m_CharacterClass,
        SpellSchool School)
    {
      ValidateParam(School);
      
      var component =  new AddOppositionSchool();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_CharacterClass);
      component.School = School;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddOutgoingDamageBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddOutgoingDamageBonus))]
    public UnitConfigurator AddAddOutgoingDamageBonus(
        DamageTypeDescription DamageType,
        DamageIncreaseCondition Condition,
        DamageIncreaseReason Reason,
        float OriginalDamageFactor,
        SpellDescriptorWrapper CheckedDescriptor,
        string m_CheckedFact)
    {
      ValidateParam(DamageType);
      ValidateParam(Condition);
      ValidateParam(Reason);
      ValidateParam(CheckedDescriptor);
      
      var component =  new AddOutgoingDamageBonus();
      component.DamageType = DamageType;
      component.Condition = Condition;
      component.Reason = Reason;
      component.OriginalDamageFactor = OriginalDamageFactor;
      component.CheckedDescriptor = CheckedDescriptor;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_CheckedFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddOutgoingPhysicalDamageProperty"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_WeaponType"><see cref="BlueprintWeaponType"/></param>
    /// <param name="m_UnitFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddOutgoingPhysicalDamageProperty))]
    public UnitConfigurator AddAddOutgoingPhysicalDamageProperty(
        bool AffectAnyPhysicalDamage,
        bool NaturalAttacks,
        bool AddMagic,
        bool AddMaterial,
        PhysicalDamageMaterial Material,
        bool AddForm,
        PhysicalDamageForm Form,
        bool AddAlignment,
        DamageAlignment Alignment,
        bool MyAlignment,
        bool AddReality,
        DamageRealityType Reality,
        bool CheckWeaponType,
        string m_WeaponType,
        bool CheckRange,
        bool IsRanged,
        bool AgainstFactOwner,
        string m_UnitFact)
    {
      ValidateParam(Material);
      ValidateParam(Form);
      ValidateParam(Alignment);
      ValidateParam(Reality);
      
      var component =  new AddOutgoingPhysicalDamageProperty();
      component.AffectAnyPhysicalDamage = AffectAnyPhysicalDamage;
      component.NaturalAttacks = NaturalAttacks;
      component.AddMagic = AddMagic;
      component.AddMaterial = AddMaterial;
      component.Material = Material;
      component.AddForm = AddForm;
      component.Form = Form;
      component.AddAlignment = AddAlignment;
      component.Alignment = Alignment;
      component.MyAlignment = MyAlignment;
      component.AddReality = AddReality;
      component.Reality = Reality;
      component.CheckWeaponType = CheckWeaponType;
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(m_WeaponType);
      component.CheckRange = CheckRange;
      component.IsRanged = IsRanged;
      component.AgainstFactOwner = AgainstFactOwner;
      component.m_UnitFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_UnitFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddOverHealTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddOverHealTrigger))]
    public UnitConfigurator AddAddOverHealTrigger(
        ActionsBuilder ActionOnTarget,
        AbilitySharedValue SharedValue)
    {
      ValidateParam(SharedValue);
      
      var component =  new AddOverHealTrigger();
      component.ActionOnTarget = ActionOnTarget.Build();
      component.SharedValue = SharedValue;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddParametrizedClassSkill"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddParametrizedClassSkill))]
    public UnitConfigurator AddAddParametrizedClassSkill()
    {
      return AddComponent(new AddParametrizedClassSkill());
    }

    /// <summary>
    /// Adds <see cref="AddParametrizedFeatures"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddParametrizedFeatures))]
    public UnitConfigurator AddAddParametrizedFeatures(
        AddParametrizedFeatures.FeatureData[] m_Features)
    {
      foreach (var item in m_Features)
      {
        ValidateParam(item);
      }
      
      var component =  new AddParametrizedFeatures();
      component.m_Features = m_Features;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddParametrizedStatBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddParametrizedStatBonus))]
    public UnitConfigurator AddAddParametrizedStatBonus(
        ContextValue Value,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Value);
      ValidateParam(Descriptor);
      
      var component =  new AddParametrizedStatBonus();
      component.Value = Value;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddPartyEncumbrance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddPartyEncumbrance))]
    public UnitConfigurator AddAddPartyEncumbrance(
        int Value)
    {
      
      var component =  new AddPartyEncumbrance();
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddPet"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Pet"><see cref="BlueprintUnit"/></param>
    /// <param name="m_LevelRank"><see cref="BlueprintFeature"/></param>
    /// <param name="m_UpgradeFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddPet))]
    public UnitConfigurator AddAddPet(
        PetType Type,
        PetProgressionType ProgressionType,
        string m_Pet,
        bool m_UseContextValueLevel,
        string m_LevelRank,
        ContextValue m_LevelContextValue,
        bool m_ForceAutoLevelup,
        string m_UpgradeFeature,
        bool m_DestroyPetOnDeactivate,
        int UpgradeLevel)
    {
      ValidateParam(Type);
      ValidateParam(ProgressionType);
      ValidateParam(m_LevelContextValue);
      
      var component =  new AddPet();
      component.Type = Type;
      component.ProgressionType = ProgressionType;
      component.m_Pet = BlueprintTool.GetRef<BlueprintUnitReference>(m_Pet);
      component.m_UseContextValueLevel = m_UseContextValueLevel;
      component.m_LevelRank = BlueprintTool.GetRef<BlueprintFeatureReference>(m_LevelRank);
      component.m_LevelContextValue = m_LevelContextValue;
      component.m_ForceAutoLevelup = m_ForceAutoLevelup;
      component.m_UpgradeFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(m_UpgradeFeature);
      component.m_DestroyPetOnDeactivate = m_DestroyPetOnDeactivate;
      component.UpgradeLevel = UpgradeLevel;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddPhysicalImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddPhysicalImmunity))]
    public UnitConfigurator AddAddPhysicalImmunity()
    {
      return AddComponent(new AddPhysicalImmunity());
    }

    /// <summary>
    /// Adds <see cref="AddPostLoadActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddPostLoadActions))]
    public UnitConfigurator AddAddPostLoadActions(
        ActionsBuilder Actions)
    {
      
      var component =  new AddPostLoadActions();
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddProficiencies"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_RaceRestriction"><see cref="BlueprintRace"/></param>
    [Generated]
    [Implements(typeof(AddProficiencies))]
    public UnitConfigurator AddAddProficiencies(
        string m_RaceRestriction,
        ArmorProficiencyGroup[] ArmorProficiencies,
        WeaponCategory[] WeaponProficiencies)
    {
      foreach (var item in ArmorProficiencies)
      {
        ValidateParam(item);
      }
      foreach (var item in WeaponProficiencies)
      {
        ValidateParam(item);
      }
      
      var component =  new AddProficiencies();
      component.m_RaceRestriction = BlueprintTool.GetRef<BlueprintRaceReference>(m_RaceRestriction);
      component.ArmorProficiencies = ArmorProficiencies;
      component.WeaponProficiencies = WeaponProficiencies;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddREVendorItem"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddREVendorItem))]
    public UnitConfigurator AddAddREVendorItem()
    {
      return AddComponent(new AddREVendorItem());
    }

    /// <summary>
    /// Adds <see cref="AddRestTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddRestTrigger))]
    public UnitConfigurator AddAddRestTrigger(
        ActionsBuilder Action)
    {
      
      var component =  new AddRestTrigger();
      component.Action = Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddResurrectOnRest"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddResurrectOnRest))]
    public UnitConfigurator AddAddResurrectOnRest()
    {
      return AddComponent(new AddResurrectOnRest());
    }

    /// <summary>
    /// Adds <see cref="AddRunwayLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddRunwayLogic))]
    public UnitConfigurator AddAddRunwayLogic()
    {
      return AddComponent(new AddRunwayLogic());
    }

    /// <summary>
    /// Adds <see cref="AddSecondaryAttacks"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Weapon"><see cref="BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(AddSecondaryAttacks))]
    public UnitConfigurator AddAddSecondaryAttacks(
        string[] m_Weapon)
    {
      
      var component =  new AddSecondaryAttacks();
      component.m_Weapon = m_Weapon.Select(bp => BlueprintTool.GetRef<BlueprintItemWeaponReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSharedVendor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_m_Table"><see cref="BlueprintSharedVendorTable"/></param>
    [Generated]
    [Implements(typeof(AddSharedVendor))]
    public UnitConfigurator AddAddSharedVendor(
        string m_m_Table)
    {
      
      var component =  new AddSharedVendor();
      component.m_m_Table = BlueprintTool.GetRef<BlueprintSharedVendorTableReference>(m_m_Table);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSkillPointPerCharacterLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddSkillPointPerCharacterLevel))]
    public UnitConfigurator AddAddSkillPointPerCharacterLevel()
    {
      return AddComponent(new AddSkillPointPerCharacterLevel());
    }

    /// <summary>
    /// Adds <see cref="AddSpecialSpellList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CharacterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_SpellList"><see cref="BlueprintSpellList"/></param>
    /// <param name="m_Archetype"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(AddSpecialSpellList))]
    public UnitConfigurator AddAddSpecialSpellList(
        string m_CharacterClass,
        string m_SpellList,
        bool ForArchetypeOnly,
        string m_Archetype)
    {
      
      var component =  new AddSpecialSpellList();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_CharacterClass);
      component.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(m_SpellList);
      component.ForArchetypeOnly = ForArchetypeOnly;
      component.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(m_Archetype);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpecialSpellListForArchetype"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CharacterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_SpellList"><see cref="BlueprintSpellList"/></param>
    /// <param name="m_Archetype"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(AddSpecialSpellListForArchetype))]
    public UnitConfigurator AddAddSpecialSpellListForArchetype(
        string m_CharacterClass,
        string m_SpellList,
        string m_Archetype)
    {
      
      var component =  new AddSpecialSpellListForArchetype();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_CharacterClass);
      component.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(m_SpellList);
      component.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(m_Archetype);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellFailureChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddSpellFailureChance))]
    public UnitConfigurator AddAddSpellFailureChance(
        int Chance,
        GameObject FailFx)
    {
      ValidateParam(FailFx);
      
      var component =  new AddSpellFailureChance();
      component.Chance = Chance;
      component.FailFx = FailFx;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellImmunity"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Exceptions"><see cref="BlueprintAbility"/></param>
    /// <param name="m_CasterIgnoreImmunityFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddSpellImmunity))]
    public UnitConfigurator AddAddSpellImmunity(
        SpellImmunityType Type,
        string[] m_Exceptions,
        SpellDescriptorWrapper SpellDescriptor,
        string m_CasterIgnoreImmunityFact,
        bool InvertedDescriptors)
    {
      ValidateParam(Type);
      ValidateParam(SpellDescriptor);
      
      var component =  new AddSpellImmunity();
      component.Type = Type;
      component.m_Exceptions = m_Exceptions.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      component.SpellDescriptor = SpellDescriptor;
      component.m_CasterIgnoreImmunityFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_CasterIgnoreImmunityFact);
      component.InvertedDescriptors = InvertedDescriptors;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellKnownTemporary"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CharacterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_Spell"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddSpellKnownTemporary))]
    public UnitConfigurator AddAddSpellKnownTemporary(
        string m_CharacterClass,
        string m_Spell,
        int Level,
        bool OnlySpontaneous)
    {
      
      var component =  new AddSpellKnownTemporary();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_CharacterClass);
      component.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(m_Spell);
      component.Level = Level;
      component.OnlySpontaneous = OnlySpontaneous;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellLevelLimit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddSpellLevelLimit))]
    public UnitConfigurator AddAddSpellLevelLimit(
        int ForMaxLevel9,
        int ForMaxLevel6,
        int ForMaxLevel4)
    {
      
      var component =  new AddSpellLevelLimit();
      component.ForMaxLevel9 = ForMaxLevel9;
      component.ForMaxLevel6 = ForMaxLevel6;
      component.ForMaxLevel4 = ForMaxLevel4;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellResistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddSpellResistance))]
    public UnitConfigurator AddAddSpellResistance(
        bool AddCR,
        ContextValue Value,
        bool AllSpellResistancePenaltyDoNotUse)
    {
      ValidateParam(Value);
      
      var component =  new AddSpellResistance();
      component.AddCR = AddCR;
      component.Value = Value;
      component.AllSpellResistancePenaltyDoNotUse = AllSpellResistancePenaltyDoNotUse;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellTypeFailureChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddSpellTypeFailureChance))]
    public UnitConfigurator AddAddSpellTypeFailureChance(
        int Chance,
        GameObject FailFx,
        bool Arcane,
        bool Divine,
        bool Alchemist)
    {
      ValidateParam(FailFx);
      
      var component =  new AddSpellTypeFailureChance();
      component.Chance = Chance;
      component.FailFx = FailFx;
      component.Arcane = Arcane;
      component.Divine = Divine;
      component.Alchemist = Alchemist;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStartingEquipment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_BasicItems"><see cref="BlueprintItem"/></param>
    /// <param name="m_CustomCategoryDefaults"><see cref="BlueprintCategoryDefaults"/></param>
    /// <param name="m_RestrictedByClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(AddStartingEquipment))]
    public UnitConfigurator AddAddStartingEquipment(
        string[] m_BasicItems,
        WeaponCategory[] CategoryItems,
        bool ParametrizedCategory,
        string m_CustomCategoryDefaults,
        string[] m_RestrictedByClass)
    {
      foreach (var item in CategoryItems)
      {
        ValidateParam(item);
      }
      
      var component =  new AddStartingEquipment();
      component.m_BasicItems = m_BasicItems.Select(bp => BlueprintTool.GetRef<BlueprintItemReference>(bp)).ToArray();
      component.CategoryItems = CategoryItems;
      component.ParametrizedCategory = ParametrizedCategory;
      component.m_CustomCategoryDefaults = BlueprintTool.GetRef<BlueprintCategoryDefaultsReference>(m_CustomCategoryDefaults);
      component.m_RestrictedByClass = m_RestrictedByClass.Select(bp => BlueprintTool.GetRef<BlueprintCharacterClassReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddStatBonus))]
    public UnitConfigurator AddAddStatBonus(
        ModifierDescriptor Descriptor,
        StatType Stat,
        int Value,
        bool ScaleByBasicAttackBonus)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      
      var component =  new AddStatBonus();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.Value = Value;
      component.ScaleByBasicAttackBonus = ScaleByBasicAttackBonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddStatModifier))]
    public UnitConfigurator AddAddStatModifier(
        ModifierDescriptor Descriptor,
        StatType Stat,
        ContextValue ModifierPercents,
        bool UseBaseValue,
        bool UpdateIfStatChanged)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      ValidateParam(ModifierPercents);
      
      var component =  new AddStatModifier();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.ModifierPercents = ModifierPercents;
      component.UseBaseValue = UseBaseValue;
      component.UpdateIfStatChanged = UpdateIfStatChanged;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddTags"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddTags))]
    public UnitConfigurator AddAddTags(
        bool UseInRandomEncounter,
        bool UseInDungeon,
        bool IsRanged,
        bool IsCaster,
        AddTags.DifficultyRequirement m_DifficultyRequirement,
        UnitTag[] Tags)
    {
      ValidateParam(m_DifficultyRequirement);
      foreach (var item in Tags)
      {
        ValidateParam(item);
      }
      
      var component =  new AddTags();
      component.UseInRandomEncounter = UseInRandomEncounter;
      component.UseInDungeon = UseInDungeon;
      component.IsRanged = IsRanged;
      component.IsCaster = IsCaster;
      component.m_DifficultyRequirement = m_DifficultyRequirement;
      component.Tags = Tags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddTemporaryFeat"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Feat"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddTemporaryFeat))]
    public UnitConfigurator AddAddTemporaryFeat(
        string m_Feat)
    {
      
      var component =  new AddTemporaryFeat();
      component.m_Feat = BlueprintTool.GetRef<BlueprintFeatureReference>(m_Feat);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddTricksterAthleticBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddTricksterAthleticBonus))]
    public UnitConfigurator AddAddTricksterAthleticBonus(
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Descriptor);
      
      var component =  new AddTricksterAthleticBonus();
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddUnitScale"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddUnitScale))]
    public UnitConfigurator AddAddUnitScale(
        float ScaleIncreaseCoefficient)
    {
      
      var component =  new AddUnitScale();
      component.ScaleIncreaseCoefficient = ScaleIncreaseCoefficient;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddUnlimitedSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Abilities"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddUnlimitedSpell))]
    public UnitConfigurator AddAddUnlimitedSpell(
        string[] m_Abilities)
    {
      
      var component =  new AddUnlimitedSpell();
      component.m_Abilities = m_Abilities.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddVendorItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Loot"><see cref="BlueprintUnitLoot"/></param>
    [Generated]
    [Implements(typeof(AddVendorItems))]
    public UnitConfigurator AddAddVendorItems(
        string m_Loot)
    {
      
      var component =  new AddVendorItems();
      component.m_Loot = BlueprintTool.GetRef<BlueprintUnitLootReference>(m_Loot);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddWeaponEnhancementBonusToStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddWeaponEnhancementBonusToStat))]
    public UnitConfigurator AddAddWeaponEnhancementBonusToStat(
        ModifierDescriptor Descriptor,
        StatType Stat,
        int Multiplier)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      
      var component =  new AddWeaponEnhancementBonusToStat();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.Multiplier = Multiplier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AdditionalDamageOnSneakAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AdditionalDamageOnSneakAttack))]
    public UnitConfigurator AddAdditionalDamageOnSneakAttack(
        int Value,
        bool OnlyRanged)
    {
      
      var component =  new AdditionalDamageOnSneakAttack();
      component.Value = Value;
      component.OnlyRanged = OnlyRanged;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AeonSavedStateFeature"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Rank"><see cref="BlueprintFeature"/></param>
    /// <param name="m_Resource"><see cref="BlueprintAbilityResource"/></param>
    /// <param name="m_InvulnerabilityBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AeonSavedStateFeature))]
    public UnitConfigurator AddAeonSavedStateFeature(
        string m_Rank,
        string m_Resource,
        PrefabLink DisappearFx,
        PrefabLink AppearFx,
        float DelaySeconds,
        string m_InvulnerabilityBuff,
        float InvulnerabilitySeconds)
    {
      ValidateParam(DisappearFx);
      ValidateParam(AppearFx);
      
      var component =  new AeonSavedStateFeature();
      component.m_Rank = BlueprintTool.GetRef<BlueprintFeatureReference>(m_Rank);
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(m_Resource);
      component.DisappearFx = DisappearFx;
      component.AppearFx = AppearFx;
      component.DelaySeconds = DelaySeconds;
      component.m_InvulnerabilityBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_InvulnerabilityBuff);
      component.InvulnerabilitySeconds = InvulnerabilitySeconds;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AlchemistInfusionFeat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AlchemistInfusionFeat))]
    public UnitConfigurator AddAlchemistInfusionFeat()
    {
      return AddComponent(new AlchemistInfusionFeat());
    }

    /// <summary>
    /// Adds <see cref="AllowDyingCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AllowDyingCondition))]
    public UnitConfigurator AddAllowDyingCondition()
    {
      return AddComponent(new AllowDyingCondition());
    }

    /// <summary>
    /// Adds <see cref="ApplyClassProgression"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Class"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_SelectSpells"><see cref="BlueprintAbility"/></param>
    /// <param name="m_MemorizeSpells"><see cref="BlueprintAbility"/></param>
    /// <param name="m_Features"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(ApplyClassProgression))]
    public UnitConfigurator AddApplyClassProgression(
        int Level,
        string m_Class,
        string[] m_SelectSpells,
        string[] m_MemorizeSpells,
        string[] m_Features,
        ParameterizedFeatureEntry[] ParameterizedFeatures)
    {
      foreach (var item in ParameterizedFeatures)
      {
        ValidateParam(item);
      }
      
      var component =  new ApplyClassProgression();
      component.Level = Level;
      component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_Class);
      component.m_SelectSpells = m_SelectSpells.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      component.m_MemorizeSpells = m_MemorizeSpells.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      component.m_Features = m_Features.Select(bp => BlueprintTool.GetRef<BlueprintFeatureReference>(bp)).ToArray();
      component.ParameterizedFeatures = ParameterizedFeatures;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackStatReplacement"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_WeaponTypes"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(AttackStatReplacement))]
    public UnitConfigurator AddAttackStatReplacement(
        StatType ReplacementStat,
        WeaponSubCategory SubCategory,
        bool CheckWeaponTypes,
        string[] m_WeaponTypes)
    {
      ValidateParam(ReplacementStat);
      ValidateParam(SubCategory);
      
      var component =  new AttackStatReplacement();
      component.ReplacementStat = ReplacementStat;
      component.SubCategory = SubCategory;
      component.CheckWeaponTypes = CheckWeaponTypes;
      component.m_WeaponTypes = m_WeaponTypes.Select(bp => BlueprintTool.GetRef<BlueprintWeaponTypeReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AutoFailCastingDefensively"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AutoFailCastingDefensively))]
    public UnitConfigurator AddAutoFailCastingDefensively()
    {
      return AddComponent(new AutoFailCastingDefensively());
    }

    /// <summary>
    /// Adds <see cref="BookOfDreamsSummonUnitsCountLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BookOfDreamsSummonUnitsCountLogic))]
    public UnitConfigurator AddBookOfDreamsSummonUnitsCountLogic()
    {
      return AddComponent(new BookOfDreamsSummonUnitsCountLogic());
    }

    /// <summary>
    /// Adds <see cref="BuffDescriptorImmunity"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_IgnoreFeature"><see cref="BlueprintUnitFact"/></param>
    /// <param name="m_FactToCheck"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(BuffDescriptorImmunity))]
    public UnitConfigurator AddBuffDescriptorImmunity(
        SpellDescriptorWrapper Descriptor,
        string m_IgnoreFeature,
        bool CheckFact,
        string m_FactToCheck)
    {
      ValidateParam(Descriptor);
      
      var component =  new BuffDescriptorImmunity();
      component.Descriptor = Descriptor;
      component.m_IgnoreFeature = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_IgnoreFeature);
      component.CheckFact = CheckFact;
      component.m_FactToCheck = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_FactToCheck);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffEnchantAnyWeapon"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_EnchantmentBlueprint"><see cref="BlueprintItemEnchantment"/></param>
    [Generated]
    [Implements(typeof(BuffEnchantAnyWeapon))]
    public UnitConfigurator AddBuffEnchantAnyWeapon(
        string m_EnchantmentBlueprint,
        EquipSlotBase.SlotType Slot)
    {
      ValidateParam(Slot);
      
      var component =  new BuffEnchantAnyWeapon();
      component.m_EnchantmentBlueprint = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(m_EnchantmentBlueprint);
      component.Slot = Slot;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffEnchantSpecificWeaponWorn"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_EnchantmentBlueprint"><see cref="BlueprintItemEnchantment"/></param>
    /// <param name="m_WeaponBlueprint"><see cref="BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(BuffEnchantSpecificWeaponWorn))]
    public UnitConfigurator AddBuffEnchantSpecificWeaponWorn(
        string m_EnchantmentBlueprint,
        string m_WeaponBlueprint)
    {
      
      var component =  new BuffEnchantSpecificWeaponWorn();
      component.m_EnchantmentBlueprint = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(m_EnchantmentBlueprint);
      component.m_WeaponBlueprint = BlueprintTool.GetRef<BlueprintItemWeaponReference>(m_WeaponBlueprint);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffEnchantWornItem"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_EnchantmentBlueprint"><see cref="BlueprintItemEnchantment"/></param>
    [Generated]
    [Implements(typeof(BuffEnchantWornItem))]
    public UnitConfigurator AddBuffEnchantWornItem(
        string m_EnchantmentBlueprint,
        bool AllWeapons,
        EquipSlotBase.SlotType Slot)
    {
      ValidateParam(Slot);
      
      var component =  new BuffEnchantWornItem();
      component.m_EnchantmentBlueprint = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(m_EnchantmentBlueprint);
      component.AllWeapons = AllWeapons;
      component.Slot = Slot;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Bugurt"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Bugurt))]
    public UnitConfigurator AddBugurt()
    {
      return AddComponent(new Bugurt());
    }

    /// <summary>
    /// Adds <see cref="ChangeFaction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Faction"><see cref="BlueprintFaction"/></param>
    [Generated]
    [Implements(typeof(ChangeFaction))]
    public UnitConfigurator AddChangeFaction(
        ChangeFaction.ChangeType m_Type,
        string m_Faction,
        bool m_AllowDirectControl)
    {
      ValidateParam(m_Type);
      
      var component =  new ChangeFaction();
      component.m_Type = m_Type;
      component.m_Faction = BlueprintTool.GetRef<BlueprintFactionReference>(m_Faction);
      component.m_AllowDirectControl = m_AllowDirectControl;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeImpatience"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeImpatience))]
    public UnitConfigurator AddChangeImpatience(
        int Delta)
    {
      
      var component =  new ChangeImpatience();
      component.Delta = Delta;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeIncomingDamageType"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeIncomingDamageType))]
    public UnitConfigurator AddChangeIncomingDamageType(
        DamageTypeDescription Type)
    {
      ValidateParam(Type);
      
      var component =  new ChangeIncomingDamageType();
      component.Type = Type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeOutgoingDamageType"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeOutgoingDamageType))]
    public UnitConfigurator AddChangeOutgoingDamageType(
        DamageTypeDescription Type)
    {
      ValidateParam(Type);
      
      var component =  new ChangeOutgoingDamageType();
      component.Type = Type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CombatManeuverOnCriticalHit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CombatManeuverOnCriticalHit))]
    public UnitConfigurator AddCombatManeuverOnCriticalHit(
        CombatManeuver Maneuver,
        ActionsBuilder OnSuccess)
    {
      ValidateParam(Maneuver);
      
      var component =  new CombatManeuverOnCriticalHit();
      component.Maneuver = Maneuver;
      component.OnSuccess = OnSuccess.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CompanionImmortality"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CompanionImmortality))]
    public UnitConfigurator AddCompanionImmortality(
        float DisappearDelay,
        GameObject DisappearFx,
        ActionsBuilder Actions,
        LocalizedString FakeDeathMessage)
    {
      ValidateParam(DisappearFx);
      ValidateParam(FakeDeathMessage);
      
      var component =  new CompanionImmortality();
      component.DisappearDelay = DisappearDelay;
      component.DisappearFx = DisappearFx;
      component.Actions = Actions.Build();
      component.FakeDeathMessage = FakeDeathMessage;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CompleteDamageImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CompleteDamageImmunity))]
    public UnitConfigurator AddCompleteDamageImmunity()
    {
      return AddComponent(new CompleteDamageImmunity());
    }

    /// <summary>
    /// Adds <see cref="ConduitSurge"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(ConduitSurge))]
    public UnitConfigurator AddConduitSurge(
        string m_Buff,
        ContextValue Value)
    {
      ValidateParam(Value);
      
      var component =  new ConduitSurge();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ConfusionRollTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ConfusionRollTrigger))]
    public UnitConfigurator AddConfusionRollTrigger(
        ConfusionState m_State,
        ActionsBuilder Action)
    {
      ValidateParam(m_State);
      
      var component =  new ConfusionRollTrigger();
      component.m_State = m_State;
      component.Action = Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DeflectArrows"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DeflectArrows))]
    public UnitConfigurator AddDeflectArrows(
        DeflectArrows.RestrictionType m_Restriction)
    {
      ValidateParam(m_Restriction);
      
      var component =  new DeflectArrows();
      component.m_Restriction = m_Restriction;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DisableAttackType"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DisableAttackType))]
    public UnitConfigurator AddDisableAttackType(
        AttackTypeFlag m_AttackType)
    {
      ValidateParam(m_AttackType);
      
      var component =  new DisableAttackType();
      component.m_AttackType = m_AttackType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DisableClassAdditionalVisualSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DisableClassAdditionalVisualSettings))]
    public UnitConfigurator AddDisableClassAdditionalVisualSettings()
    {
      return AddComponent(new DisableClassAdditionalVisualSettings());
    }

    /// <summary>
    /// Adds <see cref="DisableDeathFXs"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DisableDeathFXs))]
    public UnitConfigurator AddDisableDeathFXs()
    {
      return AddComponent(new DisableDeathFXs());
    }

    /// <summary>
    /// Adds <see cref="DisableEquipmentSlot"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DisableEquipmentSlot))]
    public UnitConfigurator AddDisableEquipmentSlot(
        DisableEquipmentSlot.SlotType m_SlotType)
    {
      ValidateParam(m_SlotType);
      
      var component =  new DisableEquipmentSlot();
      component.m_SlotType = m_SlotType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DropLootAndDestroyOnDeactivate"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DropLootAndDestroyOnDeactivate))]
    public UnitConfigurator AddDropLootAndDestroyOnDeactivate(
        IDisposable m_Coroutine)
    {
      ValidateParam(m_Coroutine);
      
      var component =  new DropLootAndDestroyOnDeactivate();
      component.m_Coroutine = m_Coroutine;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DuelistParry"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CloakFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(DuelistParry))]
    public UnitConfigurator AddDuelistParry(
        string m_CloakFact,
        DuelistParry.TargetType m_Target,
        ConditionsBuilder AttackerCondition)
    {
      ValidateParam(m_Target);
      
      var component =  new DuelistParry();
      component.m_CloakFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_CloakFact);
      component.m_Target = m_Target;
      component.AttackerCondition = AttackerCondition.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DweomerLeapLogic"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Ability"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(DweomerLeapLogic))]
    public UnitConfigurator AddDweomerLeapLogic(
        string m_Ability)
    {
      
      var component =  new DweomerLeapLogic();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(m_Ability);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EnhancePotion"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Classes"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_Archetypes"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(EnhancePotion))]
    public UnitConfigurator AddEnhancePotion(
        string[] m_Classes,
        string[] m_Archetypes)
    {
      
      var component =  new EnhancePotion();
      component.m_Classes = m_Classes.Select(bp => BlueprintTool.GetRef<BlueprintCharacterClassReference>(bp)).ToArray();
      component.m_Archetypes = m_Archetypes.Select(bp => BlueprintTool.GetRef<BlueprintArchetypeReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FastBombs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Abilities"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(FastBombs))]
    public UnitConfigurator AddFastBombs(
        string[] m_Abilities)
    {
      
      var component =  new FastBombs();
      component.m_Abilities = m_Abilities.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FavoredEnemy"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFacts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(FavoredEnemy))]
    public UnitConfigurator AddFavoredEnemy(
        string[] m_CheckedFacts)
    {
      
      var component =  new FavoredEnemy();
      component.m_CheckedFacts = m_CheckedFacts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FavoredTerrain"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(FavoredTerrain))]
    public UnitConfigurator AddFavoredTerrain(
        AreaSetting Setting)
    {
      ValidateParam(Setting);
      
      var component =  new FavoredTerrain();
      component.Setting = Setting;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FavoredTerrainExpertise"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(FavoredTerrainExpertise))]
    public UnitConfigurator AddFavoredTerrainExpertise(
        AreaSetting Setting)
    {
      ValidateParam(Setting);
      
      var component =  new FavoredTerrainExpertise();
      component.Setting = Setting;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ForbidRotation"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ForbidRotation))]
    public UnitConfigurator AddForbidRotation()
    {
      return AddComponent(new ForbidRotation());
    }

    /// <summary>
    /// Adds <see cref="ForbidSpecificSpellsCast"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(ForbidSpecificSpellsCast))]
    public UnitConfigurator AddForbidSpecificSpellsCast(
        string[] m_Spells,
        bool UseSpellDescriptor,
        SpellDescriptorWrapper SpellDescriptor,
        ActionsBuilder OnForbiddenCastAttempt)
    {
      ValidateParam(SpellDescriptor);
      
      var component =  new ForbidSpecificSpellsCast();
      component.m_Spells = m_Spells.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      component.UseSpellDescriptor = UseSpellDescriptor;
      component.SpellDescriptor = SpellDescriptor;
      component.OnForbiddenCastAttempt = OnForbiddenCastAttempt.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ForbidSpellCasting"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_IgnoreFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(ForbidSpellCasting))]
    public UnitConfigurator AddForbidSpellCasting(
        bool ForbidMagicItems,
        string m_IgnoreFeature)
    {
      
      var component =  new ForbidSpellCasting();
      component.ForbidMagicItems = ForbidMagicItems;
      component.m_IgnoreFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(m_IgnoreFeature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ForbidSpellbook"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spellbook"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    [Implements(typeof(ForbidSpellbook))]
    public UnitConfigurator AddForbidSpellbook(
        string m_Spellbook)
    {
      
      var component =  new ForbidSpellbook();
      component.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(m_Spellbook);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ForbidSpellbookOnAlignmentDeviation"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spellbooks"><see cref="BlueprintSpellbook"/></param>
    /// <param name="m_IgnoreFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ForbidSpellbookOnAlignmentDeviation))]
    public UnitConfigurator AddForbidSpellbookOnAlignmentDeviation(
        string[] m_Spellbooks,
        AlignmentMaskType Alignment,
        string m_IgnoreFact)
    {
      ValidateParam(Alignment);
      
      var component =  new ForbidSpellbookOnAlignmentDeviation();
      component.m_Spellbooks = m_Spellbooks.Select(bp => BlueprintTool.GetRef<BlueprintSpellbookReference>(bp)).ToArray();
      component.Alignment = Alignment;
      component.m_IgnoreFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_IgnoreFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ForbidSpellbookOnArmorEquip"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spellbooks"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    [Implements(typeof(ForbidSpellbookOnArmorEquip))]
    public UnitConfigurator AddForbidSpellbookOnArmorEquip(
        string[] m_Spellbooks)
    {
      
      var component =  new ForbidSpellbookOnArmorEquip();
      component.m_Spellbooks = m_Spellbooks.Select(bp => BlueprintTool.GetRef<BlueprintSpellbookReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FreeActionSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Ability"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(FreeActionSpell))]
    public UnitConfigurator AddFreeActionSpell(
        string m_Ability)
    {
      
      var component =  new FreeActionSpell();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(m_Ability);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="GentlePersuasionConditioning"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_PunishmentBuff"><see cref="BlueprintBuff"/></param>
    /// <param name="m_RewardBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(GentlePersuasionConditioning))]
    public UnitConfigurator AddGentlePersuasionConditioning(
        string m_PunishmentBuff,
        string m_RewardBuff)
    {
      
      var component =  new GentlePersuasionConditioning();
      component.m_PunishmentBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_PunishmentBuff);
      component.m_RewardBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_RewardBuff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="GhostCriticalAndPrecisionImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GhostCriticalAndPrecisionImmunity))]
    public UnitConfigurator AddGhostCriticalAndPrecisionImmunity()
    {
      return AddComponent(new GhostCriticalAndPrecisionImmunity());
    }

    /// <summary>
    /// Adds <see cref="GreaterCombatMeneuver"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GreaterCombatMeneuver))]
    public UnitConfigurator AddGreaterCombatMeneuver(
        CombatManeuver Maneuver)
    {
      ValidateParam(Maneuver);
      
      var component =  new GreaterCombatMeneuver();
      component.Maneuver = Maneuver;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="HalveIncomingAreaDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HalveIncomingAreaDamage))]
    public UnitConfigurator AddHalveIncomingAreaDamage()
    {
      return AddComponent(new HalveIncomingAreaDamage());
    }

    /// <summary>
    /// Adds <see cref="HideFactsWhileEtudePlaying"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Etude"><see cref="BlueprintEtude"/></param>
    /// <param name="m_ReplaceRace"><see cref="BlueprintRace"/></param>
    /// <param name="m_Facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(HideFactsWhileEtudePlaying))]
    public UnitConfigurator AddHideFactsWhileEtudePlaying(
        string m_Etude,
        string m_ReplaceRace,
        string[] m_Facts,
        HashSet<BlueprintUnitFact> m_CachedFacts)
    {
      foreach (var item in m_CachedFacts)
      {
        ValidateParam(item);
      }
      
      var component =  new HideFactsWhileEtudePlaying();
      component.m_Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(m_Etude);
      component.m_ReplaceRace = BlueprintTool.GetRef<BlueprintRaceReference>(m_ReplaceRace);
      component.m_Facts = m_Facts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      component.m_CachedFacts = m_CachedFacts;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="HigherMythicsReplace"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HigherMythicsReplace))]
    public UnitConfigurator AddHigherMythicsReplace()
    {
      return AddComponent(new HigherMythicsReplace());
    }

    /// <summary>
    /// Adds <see cref="IgnoreIncommingDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreIncommingDamage))]
    public UnitConfigurator AddIgnoreIncommingDamage()
    {
      return AddComponent(new IgnoreIncommingDamage());
    }

    /// <summary>
    /// Adds <see cref="IgnoreSpellImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreSpellImmunity))]
    public UnitConfigurator AddIgnoreSpellImmunity(
        SpellDescriptorWrapper SpellDescriptor)
    {
      ValidateParam(SpellDescriptor);
      
      var component =  new IgnoreSpellImmunity();
      component.SpellDescriptor = SpellDescriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncorporealACBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncorporealACBonus))]
    public UnitConfigurator AddIncorporealACBonus()
    {
      return AddComponent(new IncorporealACBonus());
    }

    /// <summary>
    /// Adds <see cref="IncreaseActivatableAbilityGroupSize"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseActivatableAbilityGroupSize))]
    public UnitConfigurator AddIncreaseActivatableAbilityGroupSize(
        ActivatableAbilityGroup Group)
    {
      ValidateParam(Group);
      
      var component =  new IncreaseActivatableAbilityGroupSize();
      component.Group = Group;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseResourceAmount"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Resource"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    [Implements(typeof(IncreaseResourceAmount))]
    public UnitConfigurator AddIncreaseResourceAmount(
        string m_Resource,
        int Value)
    {
      
      var component =  new IncreaseResourceAmount();
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(m_Resource);
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseResourceAmountBySharedValue"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Resource"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    [Implements(typeof(IncreaseResourceAmountBySharedValue))]
    public UnitConfigurator AddIncreaseResourceAmountBySharedValue(
        string m_Resource,
        ContextValue Value,
        bool Decrease)
    {
      ValidateParam(Value);
      
      var component =  new IncreaseResourceAmountBySharedValue();
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(m_Resource);
      component.Value = Value;
      component.Decrease = Decrease;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseResourcesByClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Resource"><see cref="BlueprintAbilityResource"/></param>
    /// <param name="m_CharacterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_Archetype"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(IncreaseResourcesByClass))]
    public UnitConfigurator AddIncreaseResourcesByClass(
        string m_Resource,
        string m_CharacterClass,
        string m_Archetype,
        StatType Stat,
        int BaseValue)
    {
      ValidateParam(Stat);
      
      var component =  new IncreaseResourcesByClass();
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(m_Resource);
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_CharacterClass);
      component.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(m_Archetype);
      component.Stat = Stat;
      component.BaseValue = BaseValue;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="InitiatorDisarmTrapTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(InitiatorDisarmTrapTrigger))]
    public UnitConfigurator AddInitiatorDisarmTrapTrigger(
        ActionsBuilder OnDisarmSuccess,
        ActionsBuilder OnDisarmFail)
    {
      
      var component =  new InitiatorDisarmTrapTrigger();
      component.OnDisarmSuccess = OnDisarmSuccess.Build();
      component.OnDisarmFail = OnDisarmFail.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="InitiatorSavingThrowTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(InitiatorSavingThrowTrigger))]
    public UnitConfigurator AddInitiatorSavingThrowTrigger(
        ActionsBuilder OnSuccessfulSave,
        ActionsBuilder OnFailedSave)
    {
      
      var component =  new InitiatorSavingThrowTrigger();
      component.OnSuccessfulSave = OnSuccessfulSave.Build();
      component.OnFailedSave = OnFailedSave.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KeepAlliesAlive"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="WalkingDeadBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(KeepAlliesAlive))]
    public UnitConfigurator AddKeepAlliesAlive(
        ContextValue m_MaxAttacksCount,
        string WalkingDeadBuff)
    {
      ValidateParam(m_MaxAttacksCount);
      
      var component =  new KeepAlliesAlive();
      component.m_MaxAttacksCount = m_MaxAttacksCount;
      component.WalkingDeadBuff = BlueprintTool.GetRef<BlueprintBuffReference>(WalkingDeadBuff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LearnSpellList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CharacterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_SpellList"><see cref="BlueprintSpellList"/></param>
    /// <param name="m_Archetype"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(LearnSpellList))]
    public UnitConfigurator AddLearnSpellList(
        string m_CharacterClass,
        string m_SpellList,
        string m_Archetype)
    {
      
      var component =  new LearnSpellList();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_CharacterClass);
      component.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(m_SpellList);
      component.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(m_Archetype);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LearnSpells"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CharacterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_Spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(LearnSpells))]
    public UnitConfigurator AddLearnSpells(
        string m_CharacterClass,
        string[] m_Spells)
    {
      
      var component =  new LearnSpells();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_CharacterClass);
      component.m_Spells = m_Spells.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LimbsApartDismembermentRestricted"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LimbsApartDismembermentRestricted))]
    public UnitConfigurator AddLimbsApartDismembermentRestricted()
    {
      return AddComponent(new LimbsApartDismembermentRestricted());
    }

    /// <summary>
    /// Adds <see cref="LockEquipmentSlot"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LockEquipmentSlot))]
    public UnitConfigurator AddLockEquipmentSlot(
        LockEquipmentSlot.SlotType m_SlotType,
        bool m_Deactivate)
    {
      ValidateParam(m_SlotType);
      
      var component =  new LockEquipmentSlot();
      component.m_SlotType = m_SlotType;
      component.m_Deactivate = m_Deactivate;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MarkPassive"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MarkPassive))]
    public UnitConfigurator AddMarkPassive()
    {
      return AddComponent(new MarkPassive());
    }

    /// <summary>
    /// Adds <see cref="MayBanterOnRest"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MayBanterOnRest))]
    public UnitConfigurator AddMayBanterOnRest()
    {
      return AddComponent(new MayBanterOnRest());
    }

    /// <summary>
    /// Adds <see cref="MountedShield"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MountedShield))]
    public UnitConfigurator AddMountedShield(
        ModifierDescriptor Descriptor,
        StatType Stat)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      
      var component =  new MountedShield();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MovementDistanceTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MovementDistanceTrigger))]
    public UnitConfigurator AddMovementDistanceTrigger(
        ActionsBuilder Action,
        ContextValue DistanceInFeet,
        bool LimitTiggerCountInOneRound,
        int TiggerCountMaximumInOneRound)
    {
      ValidateParam(DistanceInFeet);
      
      var component =  new MovementDistanceTrigger();
      component.Action = Action.Build();
      component.DistanceInFeet = DistanceInFeet;
      component.LimitTiggerCountInOneRound = LimitTiggerCountInOneRound;
      component.TiggerCountMaximumInOneRound = TiggerCountMaximumInOneRound;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="NenioSpecialPolymorphWhileEtudePlaying"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Etude"><see cref="BlueprintEtude"/></param>
    /// <param name="m_StandardPolymorphAbility"><see cref="BlueprintActivatableAbility"/></param>
    /// <param name="m_SpecialPolymorphBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(NenioSpecialPolymorphWhileEtudePlaying))]
    public UnitConfigurator AddNenioSpecialPolymorphWhileEtudePlaying(
        string m_Etude,
        string m_StandardPolymorphAbility,
        string m_SpecialPolymorphBuff)
    {
      
      var component =  new NenioSpecialPolymorphWhileEtudePlaying();
      component.m_Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(m_Etude);
      component.m_StandardPolymorphAbility = BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(m_StandardPolymorphAbility);
      component.m_SpecialPolymorphBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_SpecialPolymorphBuff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OverrideVisionRange"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(OverrideVisionRange))]
    public UnitConfigurator AddOverrideVisionRange(
        int VisionRangeInMeters,
        bool AlsoInCombat)
    {
      
      var component =  new OverrideVisionRange();
      component.VisionRangeInMeters = VisionRangeInMeters;
      component.AlsoInCombat = AlsoInCombat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PreventHealing"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PreventHealing))]
    public UnitConfigurator AddPreventHealing()
    {
      return AddComponent(new PreventHealing());
    }

    /// <summary>
    /// Adds <see cref="PriorityTarget"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="PriorityFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(PriorityTarget))]
    public UnitConfigurator AddPriorityTarget(
        string PriorityFact)
    {
      
      var component =  new PriorityTarget();
      component.PriorityFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(PriorityFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RaiseBAB"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RaiseBAB))]
    public UnitConfigurator AddRaiseBAB(
        ContextValue TargetValue)
    {
      ValidateParam(TargetValue);
      
      var component =  new RaiseBAB();
      component.TargetValue = TargetValue;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RaiseStatToMinimum"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RaiseStatToMinimum))]
    public UnitConfigurator AddRaiseStatToMinimum(
        ContextValue TargetValue,
        StatType Stat)
    {
      ValidateParam(TargetValue);
      ValidateParam(Stat);
      
      var component =  new RaiseStatToMinimum();
      component.TargetValue = TargetValue;
      component.Stat = Stat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RangedCleave"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RangedCleave))]
    public UnitConfigurator AddRangedCleave(
        Feet Range)
    {
      ValidateParam(Range);
      
      var component =  new RangedCleave();
      component.Range = Range;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RedirectDamageToPet"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RedirectDamageToPet))]
    public UnitConfigurator AddRedirectDamageToPet(
        int m_PercentRedirected,
        PetType m_PetType)
    {
      ValidateParam(m_PetType);
      
      var component =  new RedirectDamageToPet();
      component.m_PercentRedirected = m_PercentRedirected;
      component.m_PetType = m_PetType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RemoveBuffIfPartyNotInCombat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemoveBuffIfPartyNotInCombat))]
    public UnitConfigurator AddRemoveBuffIfPartyNotInCombat()
    {
      return AddComponent(new RemoveBuffIfPartyNotInCombat());
    }

    /// <summary>
    /// Adds <see cref="ReplaceStatBaseAttribute"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ReplaceStatBaseAttribute))]
    public UnitConfigurator AddReplaceStatBaseAttribute(
        StatType TargetStat,
        StatType BaseAttributeReplacement)
    {
      ValidateParam(TargetStat);
      ValidateParam(BaseAttributeReplacement);
      
      var component =  new ReplaceStatBaseAttribute();
      component.TargetStat = TargetStat;
      component.BaseAttributeReplacement = BaseAttributeReplacement;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Revolt"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Revolt))]
    public UnitConfigurator AddRevolt()
    {
      return AddComponent(new Revolt());
    }

    /// <summary>
    /// Adds <see cref="ScrollSpecialization"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_SpecializedClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(ScrollSpecialization))]
    public UnitConfigurator AddScrollSpecialization(
        string m_SpecializedClass)
    {
      
      var component =  new ScrollSpecialization();
      component.m_SpecializedClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_SpecializedClass);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SetMagusFeatureActive"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetMagusFeatureActive))]
    public UnitConfigurator AddSetMagusFeatureActive(
        SetMagusFeatureActive.FeatureType m_Feature)
    {
      ValidateParam(m_Feature);
      
      var component =  new SetMagusFeatureActive();
      component.m_Feature = m_Feature;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SetRunBackLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetRunBackLogic))]
    public UnitConfigurator AddSetRunBackLogic(
        float TriggerDistance,
        float RunBackDistance)
    {
      
      var component =  new SetRunBackLogic();
      component.TriggerDistance = TriggerDistance;
      component.RunBackDistance = RunBackDistance;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShroudOfWater"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_UpgradeFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(ShroudOfWater))]
    public UnitConfigurator AddShroudOfWater(
        ModifierDescriptor Descriptor,
        StatType Stat,
        ContextValue BaseValue,
        string m_UpgradeFeature)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      ValidateParam(BaseValue);
      
      var component =  new ShroudOfWater();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.BaseValue = BaseValue;
      component.m_UpgradeFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(m_UpgradeFeature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpecificBuffImmunity"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(SpecificBuffImmunity))]
    public UnitConfigurator AddSpecificBuffImmunity(
        string m_Buff)
    {
      
      var component =  new SpecificBuffImmunity();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellImmunityToSpellDescriptor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CasterIgnoreImmunityFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SpellImmunityToSpellDescriptor))]
    public UnitConfigurator AddSpellImmunityToSpellDescriptor(
        SpellDescriptorWrapper Descriptor,
        string m_CasterIgnoreImmunityFact)
    {
      ValidateParam(Descriptor);
      
      var component =  new SpellImmunityToSpellDescriptor();
      component.Descriptor = Descriptor;
      component.m_CasterIgnoreImmunityFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_CasterIgnoreImmunityFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellLinkEvocation"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpellLinkEvocation))]
    public UnitConfigurator AddSpellLinkEvocation()
    {
      return AddComponent(new SpellLinkEvocation());
    }

    /// <summary>
    /// Adds <see cref="SpellResistanceAgainstAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpellResistanceAgainstAlignment))]
    public UnitConfigurator AddSpellResistanceAgainstAlignment(
        ContextValue Value,
        AlignmentComponent Alignment)
    {
      ValidateParam(Value);
      ValidateParam(Alignment);
      
      var component =  new SpellResistanceAgainstAlignment();
      component.Value = Value;
      component.Alignment = Alignment;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellResistanceAgainstSpellDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpellResistanceAgainstSpellDescriptor))]
    public UnitConfigurator AddSpellResistanceAgainstSpellDescriptor(
        ContextValue Value,
        SpellDescriptorWrapper SpellDescriptor)
    {
      ValidateParam(Value);
      ValidateParam(SpellDescriptor);
      
      var component =  new SpellResistanceAgainstSpellDescriptor();
      component.Value = Value;
      component.SpellDescriptor = SpellDescriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpontaneousSpellConversion"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CharacterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_SpellsByLevel"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(SpontaneousSpellConversion))]
    public UnitConfigurator AddSpontaneousSpellConversion(
        string m_CharacterClass,
        string[] m_SpellsByLevel)
    {
      
      var component =  new SpontaneousSpellConversion();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_CharacterClass);
      component.m_SpellsByLevel = m_SpellsByLevel.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SufferFromHealing"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SufferFromHealing))]
    public UnitConfigurator AddSufferFromHealing(
        DamageTypeDescription DamageDescription)
    {
      ValidateParam(DamageDescription);
      
      var component =  new SufferFromHealing();
      component.DamageDescription = DamageDescription;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SuppressBuffs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buffs"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(SuppressBuffs))]
    public UnitConfigurator AddSuppressBuffs(
        string[] m_Buffs,
        SpellSchool[] Schools,
        SpellDescriptorWrapper Descriptor)
    {
      foreach (var item in Schools)
      {
        ValidateParam(item);
      }
      ValidateParam(Descriptor);
      
      var component =  new SuppressBuffs();
      component.m_Buffs = m_Buffs.Select(bp => BlueprintTool.GetRef<BlueprintBuffReference>(bp)).ToArray();
      component.Schools = Schools;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SwarmAoeVulnerability"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SwarmAoeVulnerability))]
    public UnitConfigurator AddSwarmAoeVulnerability()
    {
      return AddComponent(new SwarmAoeVulnerability());
    }

    /// <summary>
    /// Adds <see cref="SwarmDamageResistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SwarmDamageResistance))]
    public UnitConfigurator AddSwarmDamageResistance(
        bool DiminutiveOrLower)
    {
      
      var component =  new SwarmDamageResistance();
      component.DiminutiveOrLower = DiminutiveOrLower;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TricksterParry"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TricksterParry))]
    public UnitConfigurator AddTricksterParry(
        TricksterParry.TargetType m_Target,
        ConditionsBuilder AttackerCondition)
    {
      ValidateParam(m_Target);
      
      var component =  new TricksterParry();
      component.m_Target = m_Target;
      component.AttackerCondition = AttackerCondition.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UnearthlyGrace"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnearthlyGrace))]
    public UnitConfigurator AddUnearthlyGrace()
    {
      return AddComponent(new UnearthlyGrace());
    }

    /// <summary>
    /// Adds <see cref="UnfailingBeacon"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnfailingBeacon))]
    public UnitConfigurator AddUnfailingBeacon()
    {
      return AddComponent(new UnfailingBeacon());
    }

    /// <summary>
    /// Adds <see cref="UnholyGrace"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnholyGrace))]
    public UnitConfigurator AddUnholyGrace()
    {
      return AddComponent(new UnholyGrace());
    }

    /// <summary>
    /// Adds <see cref="UniqueBuff"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UniqueBuff))]
    public UnitConfigurator AddUniqueBuff()
    {
      return AddComponent(new UniqueBuff());
    }

    /// <summary>
    /// Adds <see cref="UnitHealthGuard"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitHealthGuard))]
    public UnitConfigurator AddUnitHealthGuard(
        int HealthPercent)
    {
      
      var component =  new UnitHealthGuard();
      component.HealthPercent = HealthPercent;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Untargetable"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Untargetable))]
    public UnitConfigurator AddUntargetable()
    {
      return AddComponent(new Untargetable());
    }

    /// <summary>
    /// Adds <see cref="WeaponTraining"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponTraining))]
    public UnitConfigurator AddWeaponTraining()
    {
      return AddComponent(new WeaponTraining());
    }

    /// <summary>
    /// Adds <see cref="WeaponTrainingAttackStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponTrainingAttackStatReplacement))]
    public UnitConfigurator AddWeaponTrainingAttackStatReplacement(
        StatType ReplacementStat)
    {
      ValidateParam(ReplacementStat);
      
      var component =  new WeaponTrainingAttackStatReplacement();
      component.ReplacementStat = ReplacementStat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PregenDollSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PregenDollSettings))]
    public UnitConfigurator AddPregenDollSettings(
        PregenDollSettings.Entry Default)
    {
      ValidateParam(Default);
      
      var component =  new PregenDollSettings();
      component.Default = Default;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistAcceptBurnTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddKineticistAcceptBurnTrigger))]
    public UnitConfigurator AddAddKineticistAcceptBurnTrigger(
        ActionsBuilder Action)
    {
      
      var component =  new AddKineticistAcceptBurnTrigger();
      component.Action = Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistBlade"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Blade"><see cref="BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(AddKineticistBlade))]
    public UnitConfigurator AddAddKineticistBlade(
        string m_Blade)
    {
      
      var component =  new AddKineticistBlade();
      component.m_Blade = BlueprintTool.GetRef<BlueprintItemWeaponReference>(m_Blade);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistBurnModifier"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_AppliableTo"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddKineticistBurnModifier))]
    public UnitConfigurator AddAddKineticistBurnModifier(
        KineticistBurnType BurnType,
        int Value,
        bool RemoveBuffOnAcceptBurn,
        bool UseContextValue,
        ContextValue BurnValue,
        string[] m_AppliableTo)
    {
      ValidateParam(BurnType);
      ValidateParam(BurnValue);
      
      var component =  new AddKineticistBurnModifier();
      component.BurnType = BurnType;
      component.Value = Value;
      component.RemoveBuffOnAcceptBurn = RemoveBuffOnAcceptBurn;
      component.UseContextValue = UseContextValue;
      component.BurnValue = BurnValue;
      component.m_AppliableTo = m_AppliableTo.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistBurnValueChangedTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddKineticistBurnValueChangedTrigger))]
    public UnitConfigurator AddAddKineticistBurnValueChangedTrigger(
        ActionsBuilder Action)
    {
      
      var component =  new AddKineticistBurnValueChangedTrigger();
      component.Action = Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistElementalOverflow"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_FiresFury"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddKineticistElementalOverflow))]
    public UnitConfigurator AddAddKineticistElementalOverflow(
        ContextValue Bonus,
        bool IgnoreBurn,
        bool ElementalEngine,
        string m_FiresFury)
    {
      ValidateParam(Bonus);
      
      var component =  new AddKineticistElementalOverflow();
      component.Bonus = Bonus;
      component.IgnoreBurn = IgnoreBurn;
      component.ElementalEngine = ElementalEngine;
      component.m_FiresFury = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_FiresFury);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistPart"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Class"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_MaxBurn"><see cref="BlueprintAbilityResource"/></param>
    /// <param name="m_MaxBurnPerRound"><see cref="BlueprintAbilityResource"/></param>
    /// <param name="m_GatherPowerAbility"><see cref="BlueprintAbility"/></param>
    /// <param name="m_GatherPowerIncreaseFeature"><see cref="BlueprintFeature"/></param>
    /// <param name="m_GatherPowerBuff1"><see cref="BlueprintBuff"/></param>
    /// <param name="m_GatherPowerBuff2"><see cref="BlueprintBuff"/></param>
    /// <param name="m_GatherPowerBuff3"><see cref="BlueprintBuff"/></param>
    /// <param name="m_Blasts"><see cref="BlueprintAbility"/></param>
    /// <param name="m_BladeActivatedBuff"><see cref="BlueprintBuff"/></param>
    /// <param name="m_CanGatherPowerWithShieldBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AddKineticistPart))]
    public UnitConfigurator AddAddKineticistPart(
        string m_Class,
        StatType MainStat,
        string m_MaxBurn,
        string m_MaxBurnPerRound,
        string m_GatherPowerAbility,
        string m_GatherPowerIncreaseFeature,
        string m_GatherPowerBuff1,
        string m_GatherPowerBuff2,
        string m_GatherPowerBuff3,
        string[] m_Blasts,
        string m_BladeActivatedBuff,
        string m_CanGatherPowerWithShieldBuff)
    {
      ValidateParam(MainStat);
      
      var component =  new AddKineticistPart();
      component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_Class);
      component.MainStat = MainStat;
      component.m_MaxBurn = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(m_MaxBurn);
      component.m_MaxBurnPerRound = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(m_MaxBurnPerRound);
      component.m_GatherPowerAbility = BlueprintTool.GetRef<BlueprintAbilityReference>(m_GatherPowerAbility);
      component.m_GatherPowerIncreaseFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(m_GatherPowerIncreaseFeature);
      component.m_GatherPowerBuff1 = BlueprintTool.GetRef<BlueprintBuffReference>(m_GatherPowerBuff1);
      component.m_GatherPowerBuff2 = BlueprintTool.GetRef<BlueprintBuffReference>(m_GatherPowerBuff2);
      component.m_GatherPowerBuff3 = BlueprintTool.GetRef<BlueprintBuffReference>(m_GatherPowerBuff3);
      component.m_Blasts = m_Blasts.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      component.m_BladeActivatedBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_BladeActivatedBuff);
      component.m_CanGatherPowerWithShieldBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_CanGatherPowerWithShieldBuff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SetKineticistGatherPowerMode"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetKineticistGatherPowerMode))]
    public UnitConfigurator AddSetKineticistGatherPowerMode(
        KineticistGatherPowerMode Mode)
    {
      ValidateParam(Mode);
      
      var component =  new SetKineticistGatherPowerMode();
      component.Mode = Mode;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RestrictionCanGatherPower"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RestrictionCanGatherPower))]
    public UnitConfigurator AddRestrictionCanGatherPower()
    {
      return AddComponent(new RestrictionCanGatherPower());
    }

    /// <summary>
    /// Adds <see cref="RestrictionCanUseKineticBlade"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RestrictionCanUseKineticBlade))]
    public UnitConfigurator AddRestrictionCanUseKineticBlade()
    {
      return AddComponent(new RestrictionCanUseKineticBlade());
    }

    /// <summary>
    /// Adds <see cref="Polymorph"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_ReplaceUnitForInspection"><see cref="BlueprintUnit"/></param>
    /// <param name="m_Portrait"><see cref="BlueprintPortrait"/></param>
    /// <param name="m_MainHand"><see cref="BlueprintItemWeapon"/></param>
    /// <param name="m_OffHand"><see cref="BlueprintItemWeapon"/></param>
    /// <param name="m_AdditionalLimbs"><see cref="BlueprintItemWeapon"/></param>
    /// <param name="m_SecondaryAdditionalLimbs"><see cref="BlueprintItemWeapon"/></param>
    /// <param name="m_Facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(Polymorph))]
    public UnitConfigurator AddPolymorph(
        UnitViewLink m_Prefab,
        UnitViewLink m_PrefabFemale,
        SpecialDollType m_SpecialDollType,
        string m_ReplaceUnitForInspection,
        string m_Portrait,
        bool m_KeepSlots,
        Size Size,
        int StrengthBonus,
        int DexterityBonus,
        int ConstitutionBonus,
        int NaturalArmor,
        string m_MainHand,
        string m_OffHand,
        string[] m_AdditionalLimbs,
        string[] m_SecondaryAdditionalLimbs,
        string[] m_Facts,
        Polymorph.VisualTransitionSettings m_EnterTransition,
        Polymorph.VisualTransitionSettings m_ExitTransition,
        PolymorphTransitionSettings m_TransitionExternal,
        bool m_SilentCaster)
    {
      ValidateParam(m_Prefab);
      ValidateParam(m_PrefabFemale);
      ValidateParam(m_SpecialDollType);
      ValidateParam(Size);
      ValidateParam(m_EnterTransition);
      ValidateParam(m_ExitTransition);
      ValidateParam(m_TransitionExternal);
      
      var component =  new Polymorph();
      component.m_Prefab = m_Prefab;
      component.m_PrefabFemale = m_PrefabFemale;
      component.m_SpecialDollType = m_SpecialDollType;
      component.m_ReplaceUnitForInspection = BlueprintTool.GetRef<BlueprintUnitReference>(m_ReplaceUnitForInspection);
      component.m_Portrait = BlueprintTool.GetRef<BlueprintPortraitReference>(m_Portrait);
      component.m_KeepSlots = m_KeepSlots;
      component.Size = Size;
      component.StrengthBonus = StrengthBonus;
      component.DexterityBonus = DexterityBonus;
      component.ConstitutionBonus = ConstitutionBonus;
      component.NaturalArmor = NaturalArmor;
      component.m_MainHand = BlueprintTool.GetRef<BlueprintItemWeaponReference>(m_MainHand);
      component.m_OffHand = BlueprintTool.GetRef<BlueprintItemWeaponReference>(m_OffHand);
      component.m_AdditionalLimbs = m_AdditionalLimbs.Select(bp => BlueprintTool.GetRef<BlueprintItemWeaponReference>(bp)).ToArray();
      component.m_SecondaryAdditionalLimbs = m_SecondaryAdditionalLimbs.Select(bp => BlueprintTool.GetRef<BlueprintItemWeaponReference>(bp)).ToArray();
      component.m_Facts = m_Facts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      component.m_EnterTransition = m_EnterTransition;
      component.m_ExitTransition = m_ExitTransition;
      component.m_TransitionExternal = m_TransitionExternal;
      component.m_SilentCaster = m_SilentCaster;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RemoveBuffOnLoad"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemoveBuffOnLoad))]
    public UnitConfigurator AddRemoveBuffOnLoad(
        bool OnlyFromParty)
    {
      
      var component =  new RemoveBuffOnLoad();
      component.OnlyFromParty = OnlyFromParty;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RemoveBuffOnTurnOn"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemoveBuffOnTurnOn))]
    public UnitConfigurator AddRemoveBuffOnTurnOn(
        bool OnlyFromParty)
    {
      
      var component =  new RemoveBuffOnTurnOn();
      component.OnlyFromParty = OnlyFromParty;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAreaEffect"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_AreaEffect"><see cref="BlueprintAbilityAreaEffect"/></param>
    [Generated]
    [Implements(typeof(AddAreaEffect))]
    public UnitConfigurator AddAddAreaEffect(
        string m_AreaEffect)
    {
      
      var component =  new AddAreaEffect();
      component.m_AreaEffect = BlueprintTool.GetRef<BlueprintAbilityAreaEffectReference>(m_AreaEffect);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddAttackBonus))]
    public UnitConfigurator AddAddAttackBonus(
        int Bonus)
    {
      
      var component =  new AddAttackBonus();
      component.Bonus = Bonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCheatDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddCheatDamageBonus))]
    public UnitConfigurator AddAddCheatDamageBonus(
        int Bonus)
    {
      
      var component =  new AddCheatDamageBonus();
      component.Bonus = Bonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEffectContextFastHealing"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEffectContextFastHealing))]
    public UnitConfigurator AddAddEffectContextFastHealing(
        ContextValue Bonus)
    {
      ValidateParam(Bonus);
      
      var component =  new AddEffectContextFastHealing();
      component.Bonus = Bonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEffectProtectionFromElement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEffectProtectionFromElement))]
    public UnitConfigurator AddAddEffectProtectionFromElement(
        string Element,
        int ShieldCapacity)
    {
      
      var component =  new AddEffectProtectionFromElement();
      component.Element = Element;
      component.ShieldCapacity = ShieldCapacity;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEffectRegeneration"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEffectRegeneration))]
    public UnitConfigurator AddAddEffectRegeneration(
        int Heal,
        bool Unremovable,
        bool CancelByMagicWeapon,
        DamageEnergyType[] CancelDamageEnergyTypes,
        DamageAlignment[] CancelDamageAlignmentTypes,
        PhysicalDamageMaterial[] CancelDamageMaterials)
    {
      foreach (var item in CancelDamageEnergyTypes)
      {
        ValidateParam(item);
      }
      foreach (var item in CancelDamageAlignmentTypes)
      {
        ValidateParam(item);
      }
      foreach (var item in CancelDamageMaterials)
      {
        ValidateParam(item);
      }
      
      var component =  new AddEffectRegeneration();
      component.Heal = Heal;
      component.Unremovable = Unremovable;
      component.CancelByMagicWeapon = CancelByMagicWeapon;
      component.CancelDamageEnergyTypes = CancelDamageEnergyTypes;
      component.CancelDamageAlignmentTypes = CancelDamageAlignmentTypes;
      component.CancelDamageMaterials = CancelDamageMaterials;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddGenericStatBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddGenericStatBonus))]
    public UnitConfigurator AddAddGenericStatBonus(
        ModifierDescriptor Descriptor,
        StatType Stat,
        int Value)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      
      var component =  new AddGenericStatBonus();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddMirrorImage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddMirrorImage))]
    public UnitConfigurator AddAddMirrorImage(
        ContextDiceValue Count,
        int MaxCount)
    {
      ValidateParam(Count);
      
      var component =  new AddMirrorImage();
      component.Count = Count;
      component.MaxCount = MaxCount;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeHitDie"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeHitDie))]
    public UnitConfigurator AddChangeHitDie(
        DiceType m_HitDie)
    {
      ValidateParam(m_HitDie);
      
      var component =  new ChangeHitDie();
      component.m_HitDie = m_HitDie;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="NegativeLevelComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(NegativeLevelComponent))]
    public UnitConfigurator AddNegativeLevelComponent()
    {
      return AddComponent(new NegativeLevelComponent());
    }

    /// <summary>
    /// Adds <see cref="RemoveBuffIfCasterIsMissing"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemoveBuffIfCasterIsMissing))]
    public UnitConfigurator AddRemoveBuffIfCasterIsMissing(
        bool RemoveOnCasterDeath)
    {
      
      var component =  new RemoveBuffIfCasterIsMissing();
      component.RemoveOnCasterDeath = RemoveOnCasterDeath;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ResurrectionLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ResurrectionLogic))]
    public UnitConfigurator AddResurrectionLogic(
        GameObject FirstFx,
        float FirstFxDelay,
        GameObject SecondFx,
        float SecondFxDelay)
    {
      ValidateParam(FirstFx);
      ValidateParam(SecondFx);
      
      var component =  new ResurrectionLogic();
      component.FirstFx = FirstFx;
      component.FirstFxDelay = FirstFxDelay;
      component.SecondFx = SecondFx;
      component.SecondFxDelay = SecondFxDelay;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SetBuffOnsetDelay"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetBuffOnsetDelay))]
    public UnitConfigurator AddSetBuffOnsetDelay(
        ContextDurationValue Delay,
        ActionsBuilder OnStart)
    {
      ValidateParam(Delay);
      
      var component =  new SetBuffOnsetDelay();
      component.Delay = Delay;
      component.OnStart = OnStart.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpecialAnimationState"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpecialAnimationState))]
    public UnitConfigurator AddSpecialAnimationState(
        UnitAnimationActionBuffState Animation)
    {
      ValidateParam(Animation);
      
      var component =  new SpecialAnimationState();
      component.Animation = Animation;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SummonedUnitBuff"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SummonedUnitBuff))]
    public UnitConfigurator AddSummonedUnitBuff()
    {
      return AddComponent(new SummonedUnitBuff());
    }

    /// <summary>
    /// Adds <see cref="WeaponAttackTypeDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponAttackTypeDamageBonus))]
    public UnitConfigurator AddWeaponAttackTypeDamageBonus(
        WeaponRangeType Type,
        int AttackBonus,
        ModifierDescriptor Descriptor,
        ContextValue Value)
    {
      ValidateParam(Type);
      ValidateParam(Descriptor);
      ValidateParam(Value);
      
      var component =  new WeaponAttackTypeDamageBonus();
      component.Type = Type;
      component.AttackBonus = AttackBonus;
      component.Descriptor = Descriptor;
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ActivatableAbilityResourceLogic"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_RequiredResource"><see cref="BlueprintAbilityResource"/></param>
    /// <param name="m_FreeBlueprint"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ActivatableAbilityResourceLogic))]
    public UnitConfigurator AddActivatableAbilityResourceLogic(
        ActivatableAbilityResourceLogic.ResourceSpendType SpendType,
        string m_RequiredResource,
        string m_FreeBlueprint,
        WeaponCategory[] Categories)
    {
      ValidateParam(SpendType);
      foreach (var item in Categories)
      {
        ValidateParam(item);
      }
      
      var component =  new ActivatableAbilityResourceLogic();
      component.SpendType = SpendType;
      component.m_RequiredResource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(m_RequiredResource);
      component.m_FreeBlueprint = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_FreeBlueprint);
      component.Categories = Categories;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ActivatableAbilityUnitCommand"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ActivatableAbilityUnitCommand))]
    public UnitConfigurator AddActivatableAbilityUnitCommand(
        UnitCommand.CommandType Type)
    {
      ValidateParam(Type);
      
      var component =  new ActivatableAbilityUnitCommand();
      component.Type = Type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddActivatableAbilityComponent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_ActivatableAbilities"><see cref="BlueprintActivatableAbility"/></param>
    [Generated]
    [Implements(typeof(AddActivatableAbilityComponent))]
    public UnitConfigurator AddAddActivatableAbilityComponent(
        string[] m_ActivatableAbilities)
    {
      
      var component =  new AddActivatableAbilityComponent();
      component.m_ActivatableAbilities = m_ActivatableAbilities.Select(bp => BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DeactivateImmediatelyIfNoAttacksThisRound"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DeactivateImmediatelyIfNoAttacksThisRound))]
    public UnitConfigurator AddDeactivateImmediatelyIfNoAttacksThisRound()
    {
      return AddComponent(new DeactivateImmediatelyIfNoAttacksThisRound());
    }

    /// <summary>
    /// Adds <see cref="RestrictionHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Feature"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(RestrictionHasFact))]
    public UnitConfigurator AddRestrictionHasFact(
        string m_Feature,
        bool Not)
    {
      
      var component =  new RestrictionHasFact();
      component.m_Feature = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_Feature);
      component.Not = Not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RestrictionHasUnitCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RestrictionHasUnitCondition))]
    public UnitConfigurator AddRestrictionHasUnitCondition(
        UnitCondition Condition,
        bool Invert)
    {
      ValidateParam(Condition);
      
      var component =  new RestrictionHasUnitCondition();
      component.Condition = Condition;
      component.Invert = Invert;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RestrictionKensaiWeapon"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CharacterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_ChosenWeaponBlueprint"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(RestrictionKensaiWeapon))]
    public UnitConfigurator AddRestrictionKensaiWeapon(
        string m_CharacterClass,
        string m_ChosenWeaponBlueprint)
    {
      
      var component =  new RestrictionKensaiWeapon();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_CharacterClass);
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(m_ChosenWeaponBlueprint);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RestrictionRangedWeapon"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RestrictionRangedWeapon))]
    public UnitConfigurator AddRestrictionRangedWeapon()
    {
      return AddComponent(new RestrictionRangedWeapon());
    }

    /// <summary>
    /// Adds <see cref="RestrictionUnitConditionUnlessFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(RestrictionUnitConditionUnlessFact))]
    public UnitConfigurator AddRestrictionUnitConditionUnlessFact(
        UnitCondition Condition,
        string m_CheckedFact)
    {
      ValidateParam(Condition);
      
      var component =  new RestrictionUnitConditionUnlessFact();
      component.Condition = Condition;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_CheckedFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RestrictionUnlockableFlag"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_NeededFlag"><see cref="BlueprintUnlockableFlag"/></param>
    [Generated]
    [Implements(typeof(RestrictionUnlockableFlag))]
    public UnitConfigurator AddRestrictionUnlockableFlag(
        string m_NeededFlag,
        bool Invert)
    {
      
      var component =  new RestrictionUnlockableFlag();
      component.m_NeededFlag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(m_NeededFlag);
      component.Invert = Invert;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEnergyDamageTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEnergyDamageTrigger))]
    public UnitConfigurator AddAddEnergyDamageTrigger(
        DamageEnergyType DamageType,
        bool SpellsOnly,
        ActionsBuilder Actions)
    {
      ValidateParam(DamageType);
      
      var component =  new AddEnergyDamageTrigger();
      component.DamageType = DamageType;
      component.SpellsOnly = SpellsOnly;
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddIncomingDamageTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddIncomingDamageTrigger))]
    public UnitConfigurator AddAddIncomingDamageTrigger(
        ActionsBuilder Actions,
        bool TriggerOnStatDamageOrEnergyDrain,
        bool IgnoreDamageFromThisFact,
        bool ReduceBelowZero,
        bool CheckDamageDealt,
        CompareOperation.Type CompareType,
        ContextValue TargetValue,
        bool CheckWeaponAttackType,
        AttackTypeFlag AttackType,
        bool CheckEnergyDamageType,
        DamageEnergyType EnergyType,
        bool CheckDamagePhysicalTypeNot,
        PhysicalDamageForm DamagePhysicalTypeNot)
    {
      ValidateParam(CompareType);
      ValidateParam(TargetValue);
      ValidateParam(AttackType);
      ValidateParam(EnergyType);
      ValidateParam(DamagePhysicalTypeNot);
      
      var component =  new AddIncomingDamageTrigger();
      component.Actions = Actions.Build();
      component.TriggerOnStatDamageOrEnergyDrain = TriggerOnStatDamageOrEnergyDrain;
      component.IgnoreDamageFromThisFact = IgnoreDamageFromThisFact;
      component.ReduceBelowZero = ReduceBelowZero;
      component.CheckDamageDealt = CheckDamageDealt;
      component.CompareType = CompareType;
      component.TargetValue = TargetValue;
      component.CheckWeaponAttackType = CheckWeaponAttackType;
      component.AttackType = AttackType;
      component.CheckEnergyDamageType = CheckEnergyDamageType;
      component.EnergyType = EnergyType;
      component.CheckDamagePhysicalTypeNot = CheckDamagePhysicalTypeNot;
      component.DamagePhysicalTypeNot = DamagePhysicalTypeNot;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddInitiatorPartySkillRollTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddInitiatorPartySkillRollTrigger))]
    public UnitConfigurator AddAddInitiatorPartySkillRollTrigger(
        bool OnlySuccess,
        StatType Skill,
        ActionsBuilder Action)
    {
      ValidateParam(Skill);
      
      var component =  new AddInitiatorPartySkillRollTrigger();
      component.OnlySuccess = OnlySuccess;
      component.Skill = Skill;
      component.Action = Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddInitiatorSavingThrowTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddInitiatorSavingThrowTrigger))]
    public UnitConfigurator AddAddInitiatorSavingThrowTrigger(
        bool OnlyPass,
        bool OnlyFail,
        ActionsBuilder Action)
    {
      
      var component =  new AddInitiatorSavingThrowTrigger();
      component.OnlyPass = OnlyPass;
      component.OnlyFail = OnlyFail;
      component.Action = Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddInitiatorSkillRollTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddInitiatorSkillRollTrigger))]
    public UnitConfigurator AddAddInitiatorSkillRollTrigger(
        bool OnlySuccess,
        StatType Skill,
        ActionsBuilder Action)
    {
      ValidateParam(Skill);
      
      var component =  new AddInitiatorSkillRollTrigger();
      component.OnlySuccess = OnlySuccess;
      component.Skill = Skill;
      component.Action = Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistInfusionDamageTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_WeaponType"><see cref="BlueprintWeaponType"/></param>
    /// <param name="m_AbilityList"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddKineticistInfusionDamageTrigger))]
    public UnitConfigurator AddAddKineticistInfusionDamageTrigger(
        ActionsBuilder Actions,
        bool TriggerOnStatDamageOrEnergyDrain,
        bool CheckWeaponType,
        bool CheckSpellDescriptor,
        bool CheckSpellParent,
        bool TriggerOnDirectDamage,
        string m_WeaponType,
        string[] m_AbilityList,
        SpellDescriptorWrapper SpellDescriptorsList,
        TimeSpan m_LastFrameTime)
    {
      ValidateParam(SpellDescriptorsList);
      ValidateParam(m_LastFrameTime);
      
      var component =  new AddKineticistInfusionDamageTrigger();
      component.Actions = Actions.Build();
      component.TriggerOnStatDamageOrEnergyDrain = TriggerOnStatDamageOrEnergyDrain;
      component.CheckWeaponType = CheckWeaponType;
      component.CheckSpellDescriptor = CheckSpellDescriptor;
      component.CheckSpellParent = CheckSpellParent;
      component.TriggerOnDirectDamage = TriggerOnDirectDamage;
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(m_WeaponType);
      component.m_AbilityList = m_AbilityList.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      component.SpellDescriptorsList = SpellDescriptorsList;
      component.m_LastFrameTime = m_LastFrameTime;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddOutgoingDamageTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_WeaponType"><see cref="BlueprintWeaponType"/></param>
    /// <param name="m_AbilityList"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddOutgoingDamageTrigger))]
    public UnitConfigurator AddAddOutgoingDamageTrigger(
        ActionsBuilder Actions,
        bool TriggerOnStatDamageOrEnergyDrain,
        bool CheckWeaponType,
        bool CheckAbilityType,
        AbilityType m_AbilityType,
        bool CheckSpellDescriptor,
        bool CheckSpellParent,
        bool NotZeroDamage,
        bool CheckDamageDealt,
        CompareOperation.Type CompareType,
        ContextValue TargetValue,
        bool CheckEnergyDamageType,
        DamageEnergyType EnergyType,
        bool ApplyToAreaEffectDamage,
        bool TargetKilledByThisDamage,
        string m_WeaponType,
        string[] m_AbilityList,
        SpellDescriptorWrapper SpellDescriptorsList)
    {
      ValidateParam(m_AbilityType);
      ValidateParam(CompareType);
      ValidateParam(TargetValue);
      ValidateParam(EnergyType);
      ValidateParam(SpellDescriptorsList);
      
      var component =  new AddOutgoingDamageTrigger();
      component.Actions = Actions.Build();
      component.TriggerOnStatDamageOrEnergyDrain = TriggerOnStatDamageOrEnergyDrain;
      component.CheckWeaponType = CheckWeaponType;
      component.CheckAbilityType = CheckAbilityType;
      component.m_AbilityType = m_AbilityType;
      component.CheckSpellDescriptor = CheckSpellDescriptor;
      component.CheckSpellParent = CheckSpellParent;
      component.NotZeroDamage = NotZeroDamage;
      component.CheckDamageDealt = CheckDamageDealt;
      component.CompareType = CompareType;
      component.TargetValue = TargetValue;
      component.CheckEnergyDamageType = CheckEnergyDamageType;
      component.EnergyType = EnergyType;
      component.ApplyToAreaEffectDamage = ApplyToAreaEffectDamage;
      component.TargetKilledByThisDamage = TargetKilledByThisDamage;
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(m_WeaponType);
      component.m_AbilityList = m_AbilityList.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      component.SpellDescriptorsList = SpellDescriptorsList;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellDiceBonusTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddSpellDiceBonusTrigger))]
    public UnitConfigurator AddAddSpellDiceBonusTrigger(
        bool CheckSpellDescriptor,
        SpellDescriptorWrapper SpellDescriptorsList,
        ContextDiceValue[] DiceValues,
        int[] DiceBonuses)
    {
      ValidateParam(SpellDescriptorsList);
      foreach (var item in DiceValues)
      {
        ValidateParam(item);
      }
      
      var component =  new AddSpellDiceBonusTrigger();
      component.CheckSpellDescriptor = CheckSpellDescriptor;
      component.SpellDescriptorsList = SpellDescriptorsList;
      component.DiceValues = DiceValues;
      component.DiceBonuses = DiceBonuses;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddTargetAttackWithWeaponTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddTargetAttackWithWeaponTrigger))]
    public UnitConfigurator AddAddTargetAttackWithWeaponTrigger(
        bool WaitForAttackResolve,
        bool OnlyHit,
        bool CriticalHit,
        bool OnlyOnFirstAttack,
        bool OnAttackOfOpportunity,
        bool OnlyMelee,
        bool OnlyRanged,
        bool NotReach,
        bool OnlySneakAttack,
        bool NotSneakAttack,
        bool CheckCategory,
        bool DoNotPassAttackRoll,
        bool Not,
        WeaponCategory[] Categories,
        ActionsBuilder ActionsOnAttacker,
        ActionsBuilder ActionOnSelf)
    {
      foreach (var item in Categories)
      {
        ValidateParam(item);
      }
      
      var component =  new AddTargetAttackWithWeaponTrigger();
      component.WaitForAttackResolve = WaitForAttackResolve;
      component.OnlyHit = OnlyHit;
      component.CriticalHit = CriticalHit;
      component.OnlyOnFirstAttack = OnlyOnFirstAttack;
      component.OnAttackOfOpportunity = OnAttackOfOpportunity;
      component.OnlyMelee = OnlyMelee;
      component.OnlyRanged = OnlyRanged;
      component.NotReach = NotReach;
      component.OnlySneakAttack = OnlySneakAttack;
      component.NotSneakAttack = NotSneakAttack;
      component.CheckCategory = CheckCategory;
      component.DoNotPassAttackRoll = DoNotPassAttackRoll;
      component.Not = Not;
      component.Categories = Categories;
      component.ActionsOnAttacker = ActionsOnAttacker.Build();
      component.ActionOnSelf = ActionOnSelf.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddTargetSavingThrowTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddTargetSavingThrowTrigger))]
    public UnitConfigurator AddAddTargetSavingThrowTrigger(
        bool OnlyPass,
        bool OnlyFail,
        ActionsBuilder Action)
    {
      
      var component =  new AddTargetSavingThrowTrigger();
      component.OnlyPass = OnlyPass;
      component.OnlyFail = OnlyFail;
      component.Action = Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddTargetSpellResistanceCheckTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddTargetSpellResistanceCheckTrigger))]
    public UnitConfigurator AddAddTargetSpellResistanceCheckTrigger(
        bool OnlyPass,
        bool OnlyFail,
        ActionsBuilder Action)
    {
      
      var component =  new AddTargetSpellResistanceCheckTrigger();
      component.OnlyPass = OnlyPass;
      component.OnlyFail = OnlyFail;
      component.Action = Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeSpellElementalDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeSpellElementalDamage))]
    public UnitConfigurator AddChangeSpellElementalDamage(
        DamageEnergyType Element)
    {
      ValidateParam(Element);
      
      var component =  new ChangeSpellElementalDamage();
      component.Element = Element;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeSpellElementalDamageHalfUntyped"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeSpellElementalDamageHalfUntyped))]
    public UnitConfigurator AddChangeSpellElementalDamageHalfUntyped(
        DamageEnergyType Element)
    {
      ValidateParam(Element);
      
      var component =  new ChangeSpellElementalDamageHalfUntyped();
      component.Element = Element;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DeathActions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Resource"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    [Implements(typeof(DeathActions))]
    public UnitConfigurator AddDeathActions(
        ActionsBuilder Actions,
        bool CheckResource,
        bool OnlyOnParty,
        string m_Resource)
    {
      
      var component =  new DeathActions();
      component.Actions = Actions.Build();
      component.CheckResource = CheckResource;
      component.OnlyOnParty = OnlyOnParty;
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(m_Resource);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DeskariAspect"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DeskariAspect))]
    public UnitConfigurator AddDeskariAspect()
    {
      return AddComponent(new DeskariAspect());
    }

    /// <summary>
    /// Adds <see cref="FlamewardenBurningRenewal"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Resource"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    [Implements(typeof(FlamewardenBurningRenewal))]
    public UnitConfigurator AddFlamewardenBurningRenewal(
        ActionsBuilder Actions,
        string m_Resource)
    {
      
      var component =  new FlamewardenBurningRenewal();
      component.Actions = Actions.Build();
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(m_Resource);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="InitiatorRuleDealDamageTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(InitiatorRuleDealDamageTrigger))]
    public UnitConfigurator AddInitiatorRuleDealDamageTrigger(
        ActionsBuilder m_ActionOnSource,
        AbilitySharedValue m_SharedValue)
    {
      ValidateParam(m_SharedValue);
      
      var component =  new InitiatorRuleDealDamageTrigger();
      component.m_ActionOnSource = m_ActionOnSource.Build();
      component.m_SharedValue = m_SharedValue;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="NonHumanoidCompanion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(NonHumanoidCompanion))]
    public UnitConfigurator AddNonHumanoidCompanion()
    {
      return AddComponent(new NonHumanoidCompanion());
    }

    /// <summary>
    /// Adds <see cref="OutcomingDamageAndHealingModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(OutcomingDamageAndHealingModifier))]
    public UnitConfigurator AddOutcomingDamageAndHealingModifier(
        ContextValue ModifierPercents,
        OutcomingDamageAndHealingModifier.ModifyingType Type,
        OutcomingDamageAndHealingModifier.WeaponType m_DamageWeaponType,
        bool m_OverrideOtherModifierPercents)
    {
      ValidateParam(ModifierPercents);
      ValidateParam(Type);
      ValidateParam(m_DamageWeaponType);
      
      var component =  new OutcomingDamageAndHealingModifier();
      component.ModifierPercents = ModifierPercents;
      component.Type = Type;
      component.m_DamageWeaponType = m_DamageWeaponType;
      component.m_OverrideOtherModifierPercents = m_OverrideOtherModifierPercents;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SacredWeaponDamageOverride"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Feature"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(SacredWeaponDamageOverride))]
    public UnitConfigurator AddSacredWeaponDamageOverride(
        DiceFormula Formula,
        string m_Feature)
    {
      ValidateParam(Formula);
      
      var component =  new SacredWeaponDamageOverride();
      component.Formula = Formula;
      component.m_Feature = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(m_Feature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SacredWeaponFavoriteDamageOverride"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_DeaitySacredWeaponFeature"><see cref="BlueprintFeature"/></param>
    /// <param name="m_Buff1d6"><see cref="BlueprintBuff"/></param>
    /// <param name="m_Buff1d8"><see cref="BlueprintBuff"/></param>
    /// <param name="m_Buff1d10"><see cref="BlueprintBuff"/></param>
    /// <param name="m_Buff2d6"><see cref="BlueprintBuff"/></param>
    /// <param name="m_Buff2d8"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(SacredWeaponFavoriteDamageOverride))]
    public UnitConfigurator AddSacredWeaponFavoriteDamageOverride(
        WeaponCategory Category,
        string m_DeaitySacredWeaponFeature,
        string m_Buff1d6,
        string m_Buff1d8,
        string m_Buff1d10,
        string m_Buff2d6,
        string m_Buff2d8)
    {
      ValidateParam(Category);
      
      var component =  new SacredWeaponFavoriteDamageOverride();
      component.Category = Category;
      component.m_DeaitySacredWeaponFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(m_DeaitySacredWeaponFeature);
      component.m_Buff1d6 = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff1d6);
      component.m_Buff1d8 = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff1d8);
      component.m_Buff1d10 = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff1d10);
      component.m_Buff2d6 = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff2d6);
      component.m_Buff2d8 = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff2d8);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponDamageOverride"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_WeaponTypes"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(WeaponDamageOverride))]
    public UnitConfigurator AddWeaponDamageOverride(
        DiceFormula Formula,
        string[] m_WeaponTypes)
    {
      ValidateParam(Formula);
      
      var component =  new WeaponDamageOverride();
      component.Formula = Formula;
      component.m_WeaponTypes = m_WeaponTypes.Select(bp => BlueprintTool.GetRef<BlueprintWeaponTypeReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FixUnitOnPostLoad_AddNewFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_NewFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(FixUnitOnPostLoad_AddNewFact))]
    public UnitConfigurator AddFixUnitOnPostLoad_AddNewFact(
        string m_NewFact,
        string TaskId,
        string Comment)
    {
      
      var component =  new FixUnitOnPostLoad_AddNewFact();
      component.m_NewFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_NewFact);
      component.TaskId = TaskId;
      component.Comment = Comment;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReturnVendorTable"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Table"><see cref="BlueprintSharedVendorTable"/></param>
    [Generated]
    [Implements(typeof(ReturnVendorTable))]
    public UnitConfigurator AddReturnVendorTable(
        string m_Table,
        string TaskId,
        string Comment)
    {
      
      var component =  new ReturnVendorTable();
      component.m_Table = BlueprintTool.GetRef<BlueprintSharedVendorTableReference>(m_Table);
      component.TaskId = TaskId;
      component.Comment = Comment;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DublicateSpellComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DublicateSpellComponent))]
    public UnitConfigurator AddDublicateSpellComponent(
        int m_FeetsRaiuds,
        DublicateSpellComponent.AOEType m_AOECheck)
    {
      ValidateParam(m_AOECheck);
      
      var component =  new DublicateSpellComponent();
      component.m_FeetsRaiuds = m_FeetsRaiuds;
      component.m_AOECheck = m_AOECheck;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreAttacksOfOpportunityForSpellList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Abilities"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(IgnoreAttacksOfOpportunityForSpellList))]
    public UnitConfigurator AddIgnoreAttacksOfOpportunityForSpellList(
        string[] m_Abilities,
        bool CheckSchool,
        SpellSchool School,
        bool CheckDescriptor,
        SpellDescriptorWrapper SpellDescriptor)
    {
      ValidateParam(School);
      ValidateParam(SpellDescriptor);
      
      var component =  new IgnoreAttacksOfOpportunityForSpellList();
      component.m_Abilities = m_Abilities.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToList();
      component.CheckSchool = CheckSchool;
      component.School = School;
      component.CheckDescriptor = CheckDescriptor;
      component.SpellDescriptor = SpellDescriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstTacticalOwner"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusAgainstTacticalOwner))]
    public UnitConfigurator AddAttackBonusAgainstTacticalOwner(
        TargetFilter m_TargetFilter,
        ContextValue m_Value,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(m_TargetFilter);
      ValidateParam(m_Value);
      ValidateParam(Descriptor);
      
      var component =  new AttackBonusAgainstTacticalOwner();
      component.m_TargetFilter = m_TargetFilter;
      component.m_Value = m_Value;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstTacticalTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusAgainstTacticalTarget))]
    public UnitConfigurator AddAttackBonusAgainstTacticalTarget(
        TargetFilter m_TargetFilter,
        ContextValue m_Value,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(m_TargetFilter);
      ValidateParam(m_Value);
      ValidateParam(Descriptor);
      
      var component =  new AttackBonusAgainstTacticalTarget();
      component.m_TargetFilter = m_TargetFilter;
      component.m_Value = m_Value;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstTacticalOwner"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageBonusAgainstTacticalOwner))]
    public UnitConfigurator AddDamageBonusAgainstTacticalOwner(
        TargetFilter m_TargetFilter,
        Kingmaker.UnitLogic.Mechanics.ValueType _valueType,
        ContextValue m_Value,
        int m_BonusPercentValue)
    {
      ValidateParam(m_TargetFilter);
      ValidateParam(_valueType);
      ValidateParam(m_Value);
      
      var component =  new DamageBonusAgainstTacticalOwner();
      component.m_TargetFilter = m_TargetFilter;
      component._valueType = _valueType;
      component.m_Value = m_Value;
      component.m_BonusPercentValue = m_BonusPercentValue;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstTacticalTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageBonusAgainstTacticalTarget))]
    public UnitConfigurator AddDamageBonusAgainstTacticalTarget(
        TargetFilter m_TargetFilter,
        Kingmaker.UnitLogic.Mechanics.ValueType _valueType,
        ContextValue m_Value,
        int m_BonusPercentValue)
    {
      ValidateParam(m_TargetFilter);
      ValidateParam(_valueType);
      ValidateParam(m_Value);
      
      var component =  new DamageBonusAgainstTacticalTarget();
      component.m_TargetFilter = m_TargetFilter;
      component._valueType = _valueType;
      component.m_Value = m_Value;
      component.m_BonusPercentValue = m_BonusPercentValue;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyAlternativeMovement"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_DeliverAbility"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(ArmyAlternativeMovement))]
    public UnitConfigurator AddArmyAlternativeMovement(
        bool m_IgnoreObstacles,
        string m_DeliverAbility)
    {
      
      var component =  new ArmyAlternativeMovement();
      component.m_IgnoreObstacles = m_IgnoreObstacles;
      component.m_DeliverAbility = BlueprintTool.GetRef<BlueprintAbilityReference>(m_DeliverAbility);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyChangeInitiative"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyChangeInitiative))]
    public UnitConfigurator AddArmyChangeInitiative(
        ModifierDescriptor m_Descriptor,
        ContextValue m_Value)
    {
      ValidateParam(m_Descriptor);
      ValidateParam(m_Value);
      
      var component =  new ArmyChangeInitiative();
      component.m_Descriptor = m_Descriptor;
      component.m_Value = m_Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyCriticalDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyCriticalDamage))]
    public UnitConfigurator AddArmyCriticalDamage(
        ContextValue m_ChanceBase,
        ContextValue m_ChanceMultiplier,
        float m_CritBonus,
        float m_CritMultiplier)
    {
      ValidateParam(m_ChanceBase);
      ValidateParam(m_ChanceMultiplier);
      
      var component =  new ArmyCriticalDamage();
      component.m_ChanceBase = m_ChanceBase;
      component.m_ChanceMultiplier = m_ChanceMultiplier;
      component.m_CritBonus = m_CritBonus;
      component.m_CritMultiplier = m_CritMultiplier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyForceMelee"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyForceMelee))]
    public UnitConfigurator AddArmyForceMelee()
    {
      return AddComponent(new ArmyForceMelee());
    }

    /// <summary>
    /// Adds <see cref="ArmyFullAttackEndTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyFullAttackEndTrigger))]
    public UnitConfigurator AddArmyFullAttackEndTrigger(
        bool ShouldBeInitiator,
        bool CheckAllAttacks,
        bool OnlyHit,
        bool CriticalHit,
        bool OnlyMelee,
        bool OnlyRanged,
        bool NotReach,
        bool OnlySneakAttack,
        bool NotSneakAttack,
        bool CheckCategory,
        bool Not,
        WeaponCategory[] Categories,
        ActionsBuilder ActionsOnInitiator,
        ActionsBuilder ActionOnTarget)
    {
      foreach (var item in Categories)
      {
        ValidateParam(item);
      }
      
      var component =  new ArmyFullAttackEndTrigger();
      component.ShouldBeInitiator = ShouldBeInitiator;
      component.CheckAllAttacks = CheckAllAttacks;
      component.OnlyHit = OnlyHit;
      component.CriticalHit = CriticalHit;
      component.OnlyMelee = OnlyMelee;
      component.OnlyRanged = OnlyRanged;
      component.NotReach = NotReach;
      component.OnlySneakAttack = OnlySneakAttack;
      component.NotSneakAttack = NotSneakAttack;
      component.CheckCategory = CheckCategory;
      component.Not = Not;
      component.Categories = Categories;
      component.ActionsOnInitiator = ActionsOnInitiator.Build();
      component.ActionOnTarget = ActionOnTarget.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmySwitchWeaponSlotInMelee"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmySwitchWeaponSlotInMelee))]
    public UnitConfigurator AddArmySwitchWeaponSlotInMelee(
        int m_SlotIndexForMelee)
    {
      
      var component =  new ArmySwitchWeaponSlotInMelee();
      component.m_SlotIndexForMelee = m_SlotIndexForMelee;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeLeaderSkillPowerOnAbilityUse"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeLeaderSkillPowerOnAbilityUse))]
    public UnitConfigurator AddChangeLeaderSkillPowerOnAbilityUse(
        bool m_CheckDescriptor,
        SpellDescriptorWrapper m_SpellDescriptor,
        int m_Modifier)
    {
      ValidateParam(m_SpellDescriptor);
      
      var component =  new ChangeLeaderSkillPowerOnAbilityUse();
      component.m_CheckDescriptor = m_CheckDescriptor;
      component.m_SpellDescriptor = m_SpellDescriptor;
      component.m_Modifier = m_Modifier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RandomLeaderSpellReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RandomLeaderSpellReplacement))]
    public UnitConfigurator AddRandomLeaderSpellReplacement(
        float m_ChanceToReplace)
    {
      
      var component =  new RandomLeaderSpellReplacement();
      component.m_ChanceToReplace = m_ChanceToReplace;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceSquadAbilities"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_NewAbilities"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(ReplaceSquadAbilities))]
    public UnitConfigurator AddReplaceSquadAbilities(
        string[] m_NewAbilities,
        bool m_ForOneTurn)
    {
      
      var component =  new ReplaceSquadAbilities();
      component.m_NewAbilities = m_NewAbilities.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToList();
      component.m_ForOneTurn = m_ForOneTurn;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RunActionOnTurnStart"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RunActionOnTurnStart))]
    public UnitConfigurator AddRunActionOnTurnStart(
        float m_ChanceCoefficient,
        ActionsBuilder m_Actions)
    {
      
      var component =  new RunActionOnTurnStart();
      component.m_ChanceCoefficient = m_ChanceCoefficient;
      component.m_Actions = m_Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalBattleEndTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalBattleEndTrigger))]
    public UnitConfigurator AddTacticalBattleEndTrigger(
        bool OnlyOnVictory,
        ActionsBuilder m_OnBattleEnd)
    {
      
      var component =  new TacticalBattleEndTrigger();
      component.OnlyOnVictory = OnlyOnVictory;
      component.m_OnBattleEnd = m_OnBattleEnd.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCellReachTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalCellReachTrigger))]
    public UnitConfigurator AddTacticalCellReachTrigger(
        int m_X,
        int m_Y,
        bool m_AnyX,
        bool m_AnyY,
        ActionsBuilder m_OnReach)
    {
      
      var component =  new TacticalCellReachTrigger();
      component.m_X = m_X;
      component.m_Y = m_Y;
      component.m_AnyX = m_AnyX;
      component.m_AnyY = m_AnyY;
      component.m_OnReach = m_OnReach.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatChangeFaction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalCombatChangeFaction))]
    public UnitConfigurator AddTacticalCombatChangeFaction(
        TacticalCombatChangeFaction.ChangeType m_Type,
        ArmyFaction m_Faction,
        bool m_AllowDirectControl)
    {
      ValidateParam(m_Type);
      ValidateParam(m_Faction);
      
      var component =  new TacticalCombatChangeFaction();
      component.m_Type = m_Type;
      component.m_Faction = m_Faction;
      component.m_AllowDirectControl = m_AllowDirectControl;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatConfusion"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_AiAttackNearestAction"><see cref="BlueprintTacticalCombatAiAction"/></param>
    [Generated]
    [Implements(typeof(TacticalCombatConfusion))]
    public UnitConfigurator AddTacticalCombatConfusion(
        string m_AiAttackNearestAction,
        ActionsBuilder m_HarmSelfAction)
    {
      
      var component =  new TacticalCombatConfusion();
      component.m_AiAttackNearestAction = BlueprintTool.GetRef<BlueprintTacticalCombatAiActionReference>(m_AiAttackNearestAction);
      component.m_HarmSelfAction = m_HarmSelfAction.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatDefenseAbility"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalCombatDefenseAbility))]
    public UnitConfigurator AddTacticalCombatDefenseAbility()
    {
      return AddComponent(new TacticalCombatDefenseAbility());
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatEndMovementTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalCombatEndMovementTrigger))]
    public UnitConfigurator AddTacticalCombatEndMovementTrigger(
        ActionsBuilder m_Actions,
        bool m_AllowOnlyMoveCommands)
    {
      
      var component =  new TacticalCombatEndMovementTrigger();
      component.m_Actions = m_Actions.Build();
      component.m_AllowOnlyMoveCommands = m_AllowOnlyMoveCommands;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatPercentDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalCombatPercentDamageBonus))]
    public UnitConfigurator AddTacticalCombatPercentDamageBonus(
        int BonusPercent)
    {
      
      var component =  new TacticalCombatPercentDamageBonus();
      component.BonusPercent = BonusPercent;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatProvocation"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_AiAction"><see cref="BlueprintTacticalCombatAiAction"/></param>
    [Generated]
    [Implements(typeof(TacticalCombatProvocation))]
    public UnitConfigurator AddTacticalCombatProvocation(
        string m_AiAction)
    {
      
      var component =  new TacticalCombatProvocation();
      component.m_AiAction = BlueprintTool.GetRef<BlueprintTacticalCombatAiActionReference>(m_AiAction);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatResurrection"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalCombatResurrection))]
    public UnitConfigurator AddTacticalCombatResurrection()
    {
      return AddComponent(new TacticalCombatResurrection());
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatRider"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Mount"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(TacticalCombatRider))]
    public UnitConfigurator AddTacticalCombatRider(
        string m_Mount,
        bool m_ApplyRiderScaleToHorse)
    {
      
      var component =  new TacticalCombatRider();
      component.m_Mount = BlueprintTool.GetRef<BlueprintUnitReference>(m_Mount);
      component.m_ApplyRiderScaleToHorse = m_ApplyRiderScaleToHorse;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatRoundTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalCombatRoundTrigger))]
    public UnitConfigurator AddTacticalCombatRoundTrigger(
        ActionsBuilder NewRoundActions)
    {
      
      var component =  new TacticalCombatRoundTrigger();
      component.NewRoundActions = NewRoundActions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalMoraleChanceModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalMoraleChanceModifier))]
    public UnitConfigurator AddTacticalMoraleChanceModifier(
        bool m_ChangePositiveMorale,
        ContextValue m_PositiveMoraleChancePercentDelta,
        bool m_ChangeNegativeMorale,
        ContextValue m_NegativeMoraleChancePercentDelta)
    {
      ValidateParam(m_PositiveMoraleChancePercentDelta);
      ValidateParam(m_NegativeMoraleChancePercentDelta);
      
      var component =  new TacticalMoraleChanceModifier();
      component.m_ChangePositiveMorale = m_ChangePositiveMorale;
      component.m_PositiveMoraleChancePercentDelta = m_PositiveMoraleChancePercentDelta;
      component.m_ChangeNegativeMorale = m_ChangeNegativeMorale;
      component.m_NegativeMoraleChancePercentDelta = m_NegativeMoraleChancePercentDelta;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalMoraleModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalMoraleModifier))]
    public UnitConfigurator AddTacticalMoraleModifier(
        TargetFilter m_TargetFilter,
        TacticalMoraleModifier.FactionTarget m_FactionTarget,
        int m_ModValue)
    {
      ValidateParam(m_TargetFilter);
      ValidateParam(m_FactionTarget);
      
      var component =  new TacticalMoraleModifier();
      component.m_TargetFilter = m_TargetFilter;
      component.m_FactionTarget = m_FactionTarget;
      component.m_ModValue = m_ModValue;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalSquadDeathTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_ArmyFactOnOwnerDeath"><see cref="BlueprintUnitFact"/></param>
    /// <param name="m_ArmyFactOnOthersDeath"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(TacticalSquadDeathTrigger))]
    public UnitConfigurator AddTacticalSquadDeathTrigger(
        string m_ArmyFactOnOwnerDeath,
        string m_ArmyFactOnOthersDeath,
        bool m_RemoveFactOnAnyDeath,
        ArmyFaction m_FactDestinationFaction)
    {
      ValidateParam(m_FactDestinationFaction);
      
      var component =  new TacticalSquadDeathTrigger();
      component.m_ArmyFactOnOwnerDeath = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_ArmyFactOnOwnerDeath);
      component.m_ArmyFactOnOthersDeath = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_ArmyFactOnOthersDeath);
      component.m_RemoveFactOnAnyDeath = m_RemoveFactOnAnyDeath;
      component.m_FactDestinationFaction = m_FactDestinationFaction;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyUnitComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyUnitComponent))]
    public UnitConfigurator AddArmyUnitComponent(
        Sprite Icon,
        LocalizedString Description,
        bool IsHaveMorale,
        int StartMorale,
        int MaxExtraActions,
        KingdomResourcesAmount RecruitmentPrice,
        KingdomResourcesAmount SupportPrice,
        int MercenariesBaseGrowths,
        ArmyProperties Properties)
    {
      ValidateParam(Icon);
      ValidateParam(Description);
      ValidateParam(RecruitmentPrice);
      ValidateParam(SupportPrice);
      ValidateParam(Properties);
      
      var component =  new ArmyUnitComponent();
      component.Icon = Icon;
      component.Description = Description;
      component.IsHaveMorale = IsHaveMorale;
      component.StartMorale = StartMorale;
      component.MaxExtraActions = MaxExtraActions;
      component.RecruitmentPrice = RecruitmentPrice;
      component.SupportPrice = SupportPrice;
      component.MercenariesBaseGrowths = MercenariesBaseGrowths;
      component.Properties = Properties;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyUnitSpellPower"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyUnitSpellPower))]
    public UnitConfigurator AddArmyUnitSpellPower(
        int m_SpellPower)
    {
      
      var component =  new ArmyUnitSpellPower();
      component.m_SpellPower = m_SpellPower;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyDamageAfterMovementBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyDamageAfterMovementBonus))]
    public UnitConfigurator AddArmyDamageAfterMovementBonus(
        float m_Bonus,
        bool m_AccumulateBonusPerCell,
        ActionsBuilder OnDamageDeal)
    {
      
      var component =  new ArmyDamageAfterMovementBonus();
      component.m_Bonus = m_Bonus;
      component.m_AccumulateBonusPerCell = m_AccumulateBonusPerCell;
      component.OnDamageDeal = OnDamageDeal.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyStandingDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyStandingDamageBonus))]
    public UnitConfigurator AddArmyStandingDamageBonus(
        int m_Bonus,
        ActionsBuilder OnDamageDeal)
    {
      
      var component =  new ArmyStandingDamageBonus();
      component.m_Bonus = m_Bonus;
      component.OnDamageDeal = OnDamageDeal.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffOnEntityCreated"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(BuffOnEntityCreated))]
    public UnitConfigurator AddBuffOnEntityCreated(
        string m_Buff)
    {
      
      var component =  new BuffOnEntityCreated();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TargetingBlind"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TargetingBlind))]
    public UnitConfigurator AddTargetingBlind()
    {
      return AddComponent(new TargetingBlind());
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstAttackOfOpportunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstAttackOfOpportunity))]
    public UnitConfigurator AddACBonusAgainstAttackOfOpportunity(
        bool NotAttackOfOpportunity,
        ContextValue Bonus)
    {
      ValidateParam(Bonus);
      
      var component =  new ACBonusAgainstAttackOfOpportunity();
      component.NotAttackOfOpportunity = NotAttackOfOpportunity;
      component.Bonus = Bonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstAttacks"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstAttacks))]
    public UnitConfigurator AddACBonusAgainstAttacks(
        bool AgainstMeleeOnly,
        bool AgainstRangedOnly,
        bool OnlySneakAttack,
        bool NotTouch,
        bool IsTouch,
        bool OnlyAttacksOfOpportunity,
        ContextValue Value,
        int ArmorClassBonus,
        ModifierDescriptor Descriptor,
        bool CheckArmorCategory,
        ArmorProficiencyGroup[] NotArmorCategory,
        bool NoShield)
    {
      ValidateParam(Value);
      ValidateParam(Descriptor);
      foreach (var item in NotArmorCategory)
      {
        ValidateParam(item);
      }
      
      var component =  new ACBonusAgainstAttacks();
      component.AgainstMeleeOnly = AgainstMeleeOnly;
      component.AgainstRangedOnly = AgainstRangedOnly;
      component.OnlySneakAttack = OnlySneakAttack;
      component.NotTouch = NotTouch;
      component.IsTouch = IsTouch;
      component.OnlyAttacksOfOpportunity = OnlyAttacksOfOpportunity;
      component.Value = Value;
      component.ArmorClassBonus = ArmorClassBonus;
      component.Descriptor = Descriptor;
      component.CheckArmorCategory = CheckArmorCategory;
      component.NotArmorCategory = NotArmorCategory;
      component.NoShield = NoShield;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstBuffOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(ACBonusAgainstBuffOwner))]
    public UnitConfigurator AddACBonusAgainstBuffOwner(
        string m_CheckedBuff,
        int Bonus,
        ModifierDescriptor Descriptor,
        bool CheckAlignment,
        AlignmentComponent Alignment)
    {
      ValidateParam(Descriptor);
      ValidateParam(Alignment);
      
      var component =  new ACBonusAgainstBuffOwner();
      component.m_CheckedBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_CheckedBuff);
      component.Bonus = Bonus;
      component.Descriptor = Descriptor;
      component.CheckAlignment = CheckAlignment;
      component.Alignment = Alignment;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ACBonusAgainstFactOwner))]
    public UnitConfigurator AddACBonusAgainstFactOwner(
        string m_CheckedFact,
        int Bonus,
        ModifierDescriptor Descriptor,
        AlignmentComponent Alignment,
        bool NoFact)
    {
      ValidateParam(Descriptor);
      ValidateParam(Alignment);
      
      var component =  new ACBonusAgainstFactOwner();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_CheckedFact);
      component.Bonus = Bonus;
      component.Descriptor = Descriptor;
      component.Alignment = Alignment;
      component.NoFact = NoFact;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstFactOwnerMultiple"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ACBonusAgainstFactOwnerMultiple))]
    public UnitConfigurator AddACBonusAgainstFactOwnerMultiple(
        string[] m_Facts,
        int Bonus,
        ModifierDescriptor Descriptor,
        AlignmentComponent Alignment)
    {
      ValidateParam(Descriptor);
      ValidateParam(Alignment);
      
      var component =  new ACBonusAgainstFactOwnerMultiple();
      component.m_Facts = m_Facts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      component.Bonus = Bonus;
      component.Descriptor = Descriptor;
      component.Alignment = Alignment;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstSize"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstSize))]
    public UnitConfigurator AddACBonusAgainstSize(
        ModifierDescriptor Descriptor,
        ContextValue Value,
        Size Size)
    {
      ValidateParam(Descriptor);
      ValidateParam(Value);
      ValidateParam(Size);
      
      var component =  new ACBonusAgainstSize();
      component.Descriptor = Descriptor;
      component.Value = Value;
      component.Size = Size;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstSpellsWithDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstSpellsWithDescriptor))]
    public UnitConfigurator AddACBonusAgainstSpellsWithDescriptor(
        int ArmorClassBonus,
        SpellDescriptorWrapper SpellDescriptor,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(SpellDescriptor);
      ValidateParam(Descriptor);
      
      var component =  new ACBonusAgainstSpellsWithDescriptor();
      component.ArmorClassBonus = ArmorClassBonus;
      component.SpellDescriptor = SpellDescriptor;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstWeaponCategory"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstWeaponCategory))]
    public UnitConfigurator AddACBonusAgainstWeaponCategory(
        int ArmorClassBonus,
        WeaponCategory Category,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Category);
      ValidateParam(Descriptor);
      
      var component =  new ACBonusAgainstWeaponCategory();
      component.ArmorClassBonus = ArmorClassBonus;
      component.Category = Category;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstWeaponGroup"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstWeaponGroup))]
    public UnitConfigurator AddACBonusAgainstWeaponGroup(
        int ArmorClassBonus,
        WeaponFighterGroup FighterGroup,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(FighterGroup);
      ValidateParam(Descriptor);
      
      var component =  new ACBonusAgainstWeaponGroup();
      component.ArmorClassBonus = ArmorClassBonus;
      component.FighterGroup = FighterGroup;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstWeaponSubcategory"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstWeaponSubcategory))]
    public UnitConfigurator AddACBonusAgainstWeaponSubcategory(
        int ArmorClassBonus,
        WeaponSubCategory SubCategory,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(SubCategory);
      ValidateParam(Descriptor);
      
      var component =  new ACBonusAgainstWeaponSubcategory();
      component.ArmorClassBonus = ArmorClassBonus;
      component.SubCategory = SubCategory;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstWeaponType"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Type"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(ACBonusAgainstWeaponType))]
    public UnitConfigurator AddACBonusAgainstWeaponType(
        int ArmorClassBonus,
        string m_Type,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Descriptor);
      
      var component =  new ACBonusAgainstWeaponType();
      component.ArmorClassBonus = ArmorClassBonus;
      component.m_Type = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(m_Type);
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusUnlessFactMultiple"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ACBonusUnlessFactMultiple))]
    public UnitConfigurator AddACBonusUnlessFactMultiple(
        string[] m_Facts,
        int Bonus,
        ModifierDescriptor Descriptor,
        AlignmentComponent Alignment)
    {
      ValidateParam(Descriptor);
      ValidateParam(Alignment);
      
      var component =  new ACBonusUnlessFactMultiple();
      component.m_Facts = m_Facts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      component.Bonus = Bonus;
      component.Descriptor = Descriptor;
      component.Alignment = Alignment;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACContextBonusAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ACContextBonusAgainstFactOwner))]
    public UnitConfigurator AddACContextBonusAgainstFactOwner(
        string m_CheckedFact,
        ContextValue Bonus,
        ModifierDescriptor Descriptor,
        AlignmentComponent Alignment,
        bool NoFact)
    {
      ValidateParam(Bonus);
      ValidateParam(Descriptor);
      ValidateParam(Alignment);
      
      var component =  new ACContextBonusAgainstFactOwner();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_CheckedFact);
      component.Bonus = Bonus;
      component.Descriptor = Descriptor;
      component.Alignment = Alignment;
      component.NoFact = NoFact;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACContextBonusAgainstWeaponSubcategory"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACContextBonusAgainstWeaponSubcategory))]
    public UnitConfigurator AddACContextBonusAgainstWeaponSubcategory(
        ContextValue Value,
        WeaponSubCategory SubCategory,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Value);
      ValidateParam(SubCategory);
      ValidateParam(Descriptor);
      
      var component =  new ACContextBonusAgainstWeaponSubcategory();
      component.Value = Value;
      component.SubCategory = SubCategory;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityFocusParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityFocusParametrized))]
    public UnitConfigurator AddAbilityFocusParametrized(
        bool SpellsOnly)
    {
      
      var component =  new AbilityFocusParametrized();
      component.SpellsOnly = SpellsOnly;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityMythicParams"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Abilites"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AbilityMythicParams))]
    public UnitConfigurator AddAbilityMythicParams(
        string[] m_Abilites)
    {
      
      var component =  new AbilityMythicParams();
      component.m_Abilites = m_Abilites.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityScoreCheckBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityScoreCheckBonus))]
    public UnitConfigurator AddAbilityScoreCheckBonus(
        ModifierDescriptor Descriptor,
        ContextValue Bonus,
        StatType Stat)
    {
      ValidateParam(Descriptor);
      ValidateParam(Bonus);
      ValidateParam(Stat);
      
      var component =  new AbilityScoreCheckBonus();
      component.Descriptor = Descriptor;
      component.Bonus = Bonus;
      component.Stat = Stat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ActionsOnBuffApply"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_GainedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ActionsOnBuffApply))]
    public UnitConfigurator AddActionsOnBuffApply(
        string m_GainedFact,
        ActionsBuilder Actions)
    {
      
      var component =  new ActionsOnBuffApply();
      component.m_GainedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_GainedFact);
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAbilityResources"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Resource"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    [Implements(typeof(AddAbilityResources))]
    public UnitConfigurator AddAddAbilityResources(
        bool UseThisAsResource,
        string m_Resource,
        int Amount,
        bool RestoreAmount,
        bool RestoreOnLevelUp)
    {
      
      var component =  new AddAbilityResources();
      component.UseThisAsResource = UseThisAsResource;
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(m_Resource);
      component.Amount = Amount;
      component.RestoreAmount = RestoreAmount;
      component.RestoreOnLevelUp = RestoreOnLevelUp;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBuffOnCombatStart"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Feature"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AddBuffOnCombatStart))]
    public UnitConfigurator AddAddBuffOnCombatStart(
        bool CheckParty,
        string m_Feature)
    {
      
      var component =  new AddBuffOnCombatStart();
      component.CheckParty = CheckParty;
      component.m_Feature = BlueprintTool.GetRef<BlueprintBuffReference>(m_Feature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCalculatedWeapon"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddCalculatedWeapon))]
    public UnitConfigurator AddAddCalculatedWeapon(
        CalculatedWeapon Weapon,
        bool ScaleDamageByRank)
    {
      ValidateParam(Weapon);
      
      var component =  new AddCalculatedWeapon();
      component.Weapon = Weapon;
      component.ScaleDamageByRank = ScaleDamageByRank;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCasterLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddCasterLevel))]
    public UnitConfigurator AddAddCasterLevel(
        int Bonus,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Descriptor);
      
      var component =  new AddCasterLevel();
      component.Bonus = Bonus;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCasterLevelForAbility"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spell"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddCasterLevelForAbility))]
    public UnitConfigurator AddAddCasterLevelForAbility(
        string m_Spell,
        int Bonus,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Descriptor);
      
      var component =  new AddCasterLevelForAbility();
      component.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(m_Spell);
      component.Bonus = Bonus;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCasterLevelForSpellbook"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spellbooks"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    [Implements(typeof(AddCasterLevelForSpellbook))]
    public UnitConfigurator AddAddCasterLevelForSpellbook(
        int Bonus,
        ModifierDescriptor Descriptor,
        string[] m_Spellbooks)
    {
      ValidateParam(Descriptor);
      
      var component =  new AddCasterLevelForSpellbook();
      component.Bonus = Bonus;
      component.Descriptor = Descriptor;
      component.m_Spellbooks = m_Spellbooks.Select(bp => BlueprintTool.GetRef<BlueprintSpellbookReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddClassLevelToSummonDuration"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CharacterClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(AddClassLevelToSummonDuration))]
    public UnitConfigurator AddAddClassLevelToSummonDuration(
        string m_CharacterClass,
        bool Half)
    {
      
      var component =  new AddClassLevelToSummonDuration();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_CharacterClass);
      component.Half = Half;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFactIfArchetype"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Feature"><see cref="BlueprintUnitFact"/></param>
    /// <param name="m_CharacterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_Archetype"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(AddFactIfArchetype))]
    public UnitConfigurator AddAddFactIfArchetype(
        string m_Feature,
        string m_CharacterClass,
        string m_Archetype)
    {
      
      var component =  new AddFactIfArchetype();
      component.m_Feature = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_Feature);
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_CharacterClass);
      component.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(m_Archetype);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureIfHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFact"><see cref="BlueprintUnitFact"/></param>
    /// <param name="m_Feature"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddFeatureIfHasFact))]
    public UnitConfigurator AddAddFeatureIfHasFact(
        string m_CheckedFact,
        string m_Feature,
        bool Not)
    {
      
      var component =  new AddFeatureIfHasFact();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_CheckedFact);
      component.m_Feature = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_Feature);
      component.Not = Not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureOnAlignment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddFeatureOnAlignment))]
    public UnitConfigurator AddAddFeatureOnAlignment(
        AlignmentComponent Alignment,
        string[] m_Facts)
    {
      ValidateParam(Alignment);
      
      var component =  new AddFeatureOnAlignment();
      component.Alignment = Alignment;
      component.m_Facts = m_Facts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureOnApply"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Feature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddFeatureOnApply))]
    public UnitConfigurator AddAddFeatureOnApply(
        string m_Feature)
    {
      
      var component =  new AddFeatureOnApply();
      component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(m_Feature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureOnClassLevel"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Class"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_Feature"><see cref="BlueprintFeature"/></param>
    /// <param name="m_AdditionalClasses"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_Archetypes"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(AddFeatureOnClassLevel))]
    public UnitConfigurator AddAddFeatureOnClassLevel(
        string m_Class,
        int Level,
        string m_Feature,
        bool BeforeThisLevel,
        string[] m_AdditionalClasses,
        string[] m_Archetypes)
    {
      
      var component =  new AddFeatureOnClassLevel();
      component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_Class);
      component.Level = Level;
      component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(m_Feature);
      component.BeforeThisLevel = BeforeThisLevel;
      component.m_AdditionalClasses = m_AdditionalClasses.Select(bp => BlueprintTool.GetRef<BlueprintCharacterClassReference>(bp)).ToArray();
      component.m_Archetypes = m_Archetypes.Select(bp => BlueprintTool.GetRef<BlueprintArchetypeReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureOnSkill"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddFeatureOnSkill))]
    public UnitConfigurator AddAddFeatureOnSkill(
        StatType StatType,
        int MinimalStat,
        string[] m_Facts)
    {
      ValidateParam(StatType);
      
      var component =  new AddFeatureOnSkill();
      component.StatType = StatType;
      component.MinimalStat = MinimalStat;
      component.m_Facts = m_Facts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddFeatureParametrized))]
    public UnitConfigurator AddAddFeatureParametrized()
    {
      return AddComponent(new AddFeatureParametrized());
    }

    /// <summary>
    /// Adds <see cref="AddFeatureToNPC"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Feature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddFeatureToNPC))]
    public UnitConfigurator AddAddFeatureToNPC(
        bool CheckParty,
        string m_Feature,
        bool CheckSummoned)
    {
      
      var component =  new AddFeatureToNPC();
      component.CheckParty = CheckParty;
      component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(m_Feature);
      component.CheckSummoned = CheckSummoned;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureToPet"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Feature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddFeatureToPet))]
    public UnitConfigurator AddAddFeatureToPet(
        PetType m_PetType,
        string m_Feature)
    {
      ValidateParam(m_PetType);
      
      var component =  new AddFeatureToPet();
      component.m_PetType = m_PetType;
      component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(m_Feature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureToPetParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddFeatureToPetParametrized))]
    public UnitConfigurator AddAddFeatureToPetParametrized(
        PetType PetType)
    {
      ValidateParam(PetType);
      
      var component =  new AddFeatureToPetParametrized();
      component.PetType = PetType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellListAsAbilities"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_ResourcePerSpellLevel"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    [Implements(typeof(AddSpellListAsAbilities))]
    public UnitConfigurator AddAddSpellListAsAbilities(
        string[] m_ResourcePerSpellLevel)
    {
      
      var component =  new AddSpellListAsAbilities();
      component.m_ResourcePerSpellLevel = m_ResourcePerSpellLevel.Select(bp => BlueprintTool.GetRef<BlueprintAbilityResourceReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellbook"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spellbook"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    [Implements(typeof(AddSpellbook))]
    public UnitConfigurator AddAddSpellbook(
        string m_Spellbook,
        ContextValue m_CasterLevel)
    {
      ValidateParam(m_CasterLevel);
      
      var component =  new AddSpellbook();
      component.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(m_Spellbook);
      component.m_CasterLevel = m_CasterLevel;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellbookFeature"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spellbook"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    [Implements(typeof(AddSpellbookFeature))]
    public UnitConfigurator AddAddSpellbookFeature(
        string m_Spellbook,
        int CasterLevel)
    {
      
      var component =  new AddSpellbookFeature();
      component.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(m_Spellbook);
      component.CasterLevel = CasterLevel;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellbookLevel"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spellbook"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    [Implements(typeof(AddSpellbookLevel))]
    public UnitConfigurator AddAddSpellbookLevel(
        string m_Spellbook)
    {
      
      var component =  new AddSpellbookLevel();
      component.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(m_Spellbook);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellsPerDay"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddSpellsPerDay))]
    public UnitConfigurator AddAddSpellsPerDay(
        int Amount,
        int[] Levels)
    {
      
      var component =  new AddSpellsPerDay();
      component.Amount = Amount;
      component.Levels = Levels;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddWearinessHours"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddWearinessHours))]
    public UnitConfigurator AddAddWearinessHours(
        int Hours)
    {
      
      var component =  new AddWearinessHours();
      component.Hours = Hours;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AdditionalDamageOnHit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Weapon"><see cref="BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(AdditionalDamageOnHit))]
    public UnitConfigurator AddAdditionalDamageOnHit(
        DiceFormula EnergyDamageDice,
        DamageEnergyType Element,
        bool SpecificWeapon,
        string m_Weapon,
        bool OnlyNaturalAndUnarmed,
        bool OnlyMelee)
    {
      ValidateParam(EnergyDamageDice);
      ValidateParam(Element);
      
      var component =  new AdditionalDamageOnHit();
      component.EnergyDamageDice = EnergyDamageDice;
      component.Element = Element;
      component.SpecificWeapon = SpecificWeapon;
      component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(m_Weapon);
      component.OnlyNaturalAndUnarmed = OnlyNaturalAndUnarmed;
      component.OnlyMelee = OnlyMelee;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AdditionalSneakDamageOnHit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AdditionalSneakDamageOnHit))]
    public UnitConfigurator AddAdditionalSneakDamageOnHit(
        AdditionalSneakDamageOnHit.WeaponType m_Weapon,
        DiceFormula PhysicalDamageDice,
        bool OnlyNoDexToAC)
    {
      ValidateParam(m_Weapon);
      ValidateParam(PhysicalDamageDice);
      
      var component =  new AdditionalSneakDamageOnHit();
      component.m_Weapon = m_Weapon;
      component.PhysicalDamageDice = PhysicalDamageDice;
      component.OnlyNoDexToAC = OnlyNoDexToAC;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AllSpellsParamsOverride"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AllSpellsParamsOverride))]
    public UnitConfigurator AddAllSpellsParamsOverride(
        ContextValue CasterLevel,
        ContextValue DC)
    {
      ValidateParam(CasterLevel);
      ValidateParam(DC);
      
      var component =  new AllSpellsParamsOverride();
      component.CasterLevel = CasterLevel;
      component.DC = DC;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AlliedSpellcaster"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_AlliedSpellcasterFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AlliedSpellcaster))]
    public UnitConfigurator AddAlliedSpellcaster(
        string m_AlliedSpellcasterFact,
        int Radius)
    {
      
      var component =  new AlliedSpellcaster();
      component.m_AlliedSpellcasterFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_AlliedSpellcasterFact);
      component.Radius = Radius;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AngelSwordAdditionalDamageAndHeal"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_MaximizeFact"><see cref="BlueprintUnitFact"/></param>
    /// <param name="m_CloakFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AngelSwordAdditionalDamageAndHeal))]
    public UnitConfigurator AddAngelSwordAdditionalDamageAndHeal(
        string m_MaximizeFact,
        string m_CloakFact,
        PrefabLink HealingPrefab,
        PrefabLink DamagePrefab)
    {
      ValidateParam(HealingPrefab);
      ValidateParam(DamagePrefab);
      
      var component =  new AngelSwordAdditionalDamageAndHeal();
      component.m_MaximizeFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_MaximizeFact);
      component.m_CloakFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_CloakFact);
      component.HealingPrefab = HealingPrefab;
      component.DamagePrefab = DamagePrefab;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AngelSwordAntiDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AngelSwordAntiDescriptor))]
    public UnitConfigurator AddAngelSwordAntiDescriptor(
        SpellDescriptorWrapper CheckedDescriptor,
        bool HealStatDamageAndDrain,
        bool HealEnergyDrain,
        EnergyDrainHealType TemporaryNegativeLevelsHeal,
        EnergyDrainHealType PermanentNegativeLevelsHeal)
    {
      ValidateParam(CheckedDescriptor);
      ValidateParam(TemporaryNegativeLevelsHeal);
      ValidateParam(PermanentNegativeLevelsHeal);
      
      var component =  new AngelSwordAntiDescriptor();
      component.CheckedDescriptor = CheckedDescriptor;
      component.HealStatDamageAndDrain = HealStatDamageAndDrain;
      component.HealEnergyDrain = HealEnergyDrain;
      component.TemporaryNegativeLevelsHeal = TemporaryNegativeLevelsHeal;
      component.PermanentNegativeLevelsHeal = PermanentNegativeLevelsHeal;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AnyWeaponDamageStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AnyWeaponDamageStatReplacement))]
    public UnitConfigurator AddAnyWeaponDamageStatReplacement(
        StatType Stat,
        bool OnlyMelee)
    {
      ValidateParam(Stat);
      
      var component =  new AnyWeaponDamageStatReplacement();
      component.Stat = Stat;
      component.OnlyMelee = OnlyMelee;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArcaneArmorProficiency"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArcaneArmorProficiency))]
    public UnitConfigurator AddArcaneArmorProficiency(
        ArmorProficiencyGroup[] Armor)
    {
      foreach (var item in Armor)
      {
        ValidateParam(item);
      }
      
      var component =  new ArcaneArmorProficiency();
      component.Armor = Armor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArcaneBloodlineArcana"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArcaneBloodlineArcana))]
    public UnitConfigurator AddArcaneBloodlineArcana()
    {
      return AddComponent(new ArcaneBloodlineArcana());
    }

    /// <summary>
    /// Adds <see cref="ArcaneSpellFailureIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArcaneSpellFailureIncrease))]
    public UnitConfigurator AddArcaneSpellFailureIncrease(
        int Bonus,
        bool ToShield)
    {
      
      var component =  new ArcaneSpellFailureIncrease();
      component.Bonus = Bonus;
      component.ToShield = ToShield;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmorCheckPenaltyIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmorCheckPenaltyIncrease))]
    public UnitConfigurator AddArmorCheckPenaltyIncrease(
        ContextValue Bonus,
        int BonesPerRank,
        bool CheckCategory,
        ArmorProficiencyGroup Category)
    {
      ValidateParam(Bonus);
      ValidateParam(Category);
      
      var component =  new ArmorCheckPenaltyIncrease();
      component.Bonus = Bonus;
      component.BonesPerRank = BonesPerRank;
      component.CheckCategory = CheckCategory;
      component.Category = Category;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmorClassBonusAgainstAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmorClassBonusAgainstAlignment))]
    public UnitConfigurator AddArmorClassBonusAgainstAlignment(
        AlignmentComponent alignment,
        ModifierDescriptor Descriptor,
        int Value,
        ContextValue Bonus)
    {
      ValidateParam(alignment);
      ValidateParam(Descriptor);
      ValidateParam(Bonus);
      
      var component =  new ArmorClassBonusAgainstAlignment();
      component.alignment = alignment;
      component.Descriptor = Descriptor;
      component.Value = Value;
      component.Bonus = Bonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmorSpeedPenaltyRemoval"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmorSpeedPenaltyRemoval))]
    public UnitConfigurator AddArmorSpeedPenaltyRemoval()
    {
      return AddComponent(new ArmorSpeedPenaltyRemoval());
    }

    /// <summary>
    /// Adds <see cref="AscendantElement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AscendantElement))]
    public UnitConfigurator AddAscendantElement(
        DamageEnergyType Element)
    {
      ValidateParam(Element);
      
      var component =  new AscendantElement();
      component.Element = Element;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusAgainstAlignment))]
    public UnitConfigurator AddAttackBonusAgainstAlignment(
        AlignmentComponent Alignment,
        bool OnlyMelee,
        int DamageBonus,
        ContextValue Bonus,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Alignment);
      ValidateParam(Bonus);
      ValidateParam(Descriptor);
      
      var component =  new AttackBonusAgainstAlignment();
      component.Alignment = Alignment;
      component.OnlyMelee = OnlyMelee;
      component.DamageBonus = DamageBonus;
      component.Bonus = Bonus;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstArmyProperty"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusAgainstArmyProperty))]
    public UnitConfigurator AddAttackBonusAgainstArmyProperty(
        ModifierDescriptor Descriptor,
        ContextValue Value,
        ArmyProperties ArmyProperties)
    {
      ValidateParam(Descriptor);
      ValidateParam(Value);
      ValidateParam(ArmyProperties);
      
      var component =  new AttackBonusAgainstArmyProperty();
      component.Descriptor = Descriptor;
      component.Value = Value;
      component.ArmyProperties = ArmyProperties;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AttackBonusAgainstFactOwner))]
    public UnitConfigurator AddAttackBonusAgainstFactOwner(
        string m_CheckedFact,
        int AttackBonus,
        ContextValue Bonus,
        ModifierDescriptor Descriptor,
        bool Not)
    {
      ValidateParam(Bonus);
      ValidateParam(Descriptor);
      
      var component =  new AttackBonusAgainstFactOwner();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_CheckedFact);
      component.AttackBonus = AttackBonus;
      component.Bonus = Bonus;
      component.Descriptor = Descriptor;
      component.Not = Not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstFriendly"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusAgainstFriendly))]
    public UnitConfigurator AddAttackBonusAgainstFriendly(
        int AttackBonus,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Descriptor);
      
      var component =  new AttackBonusAgainstFriendly();
      component.AttackBonus = AttackBonus;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstSize"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_TargetFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AttackBonusAgainstSize))]
    public UnitConfigurator AddAttackBonusAgainstSize(
        ModifierDescriptor Descriptor,
        ContextValue Value,
        Size Size,
        bool OnlyForRanged,
        bool OnlyForMelee,
        bool SizeMoreThan,
        bool CheckTargetFact,
        string m_TargetFact)
    {
      ValidateParam(Descriptor);
      ValidateParam(Value);
      ValidateParam(Size);
      
      var component =  new AttackBonusAgainstSize();
      component.Descriptor = Descriptor;
      component.Value = Value;
      component.Size = Size;
      component.OnlyForRanged = OnlyForRanged;
      component.OnlyForMelee = OnlyForMelee;
      component.SizeMoreThan = SizeMoreThan;
      component.CheckTargetFact = CheckTargetFact;
      component.m_TargetFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_TargetFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusConditional"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusConditional))]
    public UnitConfigurator AddAttackBonusConditional(
        bool CheckWielder,
        ModifierDescriptor Descriptor,
        ContextValue Bonus,
        ConditionsBuilder Conditions)
    {
      ValidateParam(Descriptor);
      ValidateParam(Bonus);
      
      var component =  new AttackBonusConditional();
      component.CheckWielder = CheckWielder;
      component.Descriptor = Descriptor;
      component.Bonus = Bonus;
      component.Conditions = Conditions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackDiceBonusOnce"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackDiceBonusOnce))]
    public UnitConfigurator AddAttackDiceBonusOnce(
        int bonus,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Descriptor);
      
      var component =  new AttackDiceBonusOnce();
      component.bonus = bonus;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackOfOpportunityAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackOfOpportunityAttackBonus))]
    public UnitConfigurator AddAttackOfOpportunityAttackBonus(
        bool NotAttackOfOpportunity,
        int AttackBonus,
        ModifierDescriptor Descriptor,
        ContextValue Bonus)
    {
      ValidateParam(Descriptor);
      ValidateParam(Bonus);
      
      var component =  new AttackOfOpportunityAttackBonus();
      component.NotAttackOfOpportunity = NotAttackOfOpportunity;
      component.AttackBonus = AttackBonus;
      component.Descriptor = Descriptor;
      component.Bonus = Bonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackOfOpportunityAttackBonusAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AttackOfOpportunityAttackBonusAgainstFactOwner))]
    public UnitConfigurator AddAttackOfOpportunityAttackBonusAgainstFactOwner(
        string m_CheckedFact,
        ContextValue Bonus)
    {
      ValidateParam(Bonus);
      
      var component =  new AttackOfOpportunityAttackBonusAgainstFactOwner();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_CheckedFact);
      component.Bonus = Bonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackOfOpportunityCriticalConfirmationBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackOfOpportunityCriticalConfirmationBonus))]
    public UnitConfigurator AddAttackOfOpportunityCriticalConfirmationBonus(
        ContextValue Bonus,
        bool CheckWeaponRangeType,
        WeaponRangeType Type)
    {
      ValidateParam(Bonus);
      ValidateParam(Type);
      
      var component =  new AttackOfOpportunityCriticalConfirmationBonus();
      component.Bonus = Bonus;
      component.CheckWeaponRangeType = CheckWeaponRangeType;
      component.Type = Type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackOfOpportunityDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackOfOpportunityDamageBonus))]
    public UnitConfigurator AddAttackOfOpportunityDamageBonus(
        ContextValue DamageBonus,
        bool CheckWeaponRangeType,
        WeaponRangeType WeaponType)
    {
      ValidateParam(DamageBonus);
      ValidateParam(WeaponType);
      
      var component =  new AttackOfOpportunityDamageBonus();
      component.DamageBonus = DamageBonus;
      component.CheckWeaponRangeType = CheckWeaponRangeType;
      component.WeaponType = WeaponType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackTypeAttackBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_RequiredFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AttackTypeAttackBonus))]
    public UnitConfigurator AddAttackTypeAttackBonus(
        WeaponRangeType Type,
        bool AllTypesExcept,
        int AttackBonus,
        ModifierDescriptor Descriptor,
        ContextValue Value,
        bool CheckFact,
        string m_RequiredFact)
    {
      ValidateParam(Type);
      ValidateParam(Descriptor);
      ValidateParam(Value);
      
      var component =  new AttackTypeAttackBonus();
      component.Type = Type;
      component.AllTypesExcept = AllTypesExcept;
      component.AttackBonus = AttackBonus;
      component.Descriptor = Descriptor;
      component.Value = Value;
      component.CheckFact = CheckFact;
      component.m_RequiredFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_RequiredFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackTypeChange"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackTypeChange))]
    public UnitConfigurator AddAttackTypeChange(
        bool NeedsWeapon,
        bool ChangeAllTypes,
        AttackType OriginalType,
        AttackType NewType)
    {
      ValidateParam(OriginalType);
      ValidateParam(NewType);
      
      var component =  new AttackTypeChange();
      component.NeedsWeapon = NeedsWeapon;
      component.ChangeAllTypes = ChangeAllTypes;
      component.OriginalType = OriginalType;
      component.NewType = NewType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackTypeCriticalMultiplierIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackTypeCriticalMultiplierIncrease))]
    public UnitConfigurator AddAttackTypeCriticalMultiplierIncrease(
        WeaponRangeType Type,
        int AdditionalMultiplier)
    {
      ValidateParam(Type);
      
      var component =  new AttackTypeCriticalMultiplierIncrease();
      component.Type = Type;
      component.AdditionalMultiplier = AdditionalMultiplier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AuraFeatureComponent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AuraFeatureComponent))]
    public UnitConfigurator AddAuraFeatureComponent(
        string m_Buff)
    {
      
      var component =  new AuraFeatureComponent();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AutoConfirmCritAgainstFlanked"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AutoConfirmCritAgainstFlanked))]
    public UnitConfigurator AddAutoConfirmCritAgainstFlanked()
    {
      return AddComponent(new AutoConfirmCritAgainstFlanked());
    }

    /// <summary>
    /// Adds <see cref="AutoDetectStealth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AutoDetectStealth))]
    public UnitConfigurator AddAutoDetectStealth()
    {
      return AddComponent(new AutoDetectStealth());
    }

    /// <summary>
    /// Adds <see cref="AutoMetamagic"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="Abilities"><see cref="BlueprintAbility"/></param>
    /// <param name="m_Spellbook"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    [Implements(typeof(AutoMetamagic))]
    public UnitConfigurator AddAutoMetamagic(
        AutoMetamagic.AllowedType m_AllowedAbilities,
        Metamagic Metamagic,
        string[] Abilities,
        SpellDescriptorWrapper Descriptor,
        bool Once,
        int MaxSpellLevel,
        SpellSchool School,
        bool CheckSpellbook,
        string m_Spellbook)
    {
      ValidateParam(m_AllowedAbilities);
      ValidateParam(Metamagic);
      ValidateParam(Descriptor);
      ValidateParam(School);
      
      var component =  new AutoMetamagic();
      component.m_AllowedAbilities = m_AllowedAbilities;
      component.Metamagic = Metamagic;
      component.Abilities = Abilities.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToList();
      component.Descriptor = Descriptor;
      component.Once = Once;
      component.MaxSpellLevel = MaxSpellLevel;
      component.School = School;
      component.CheckSpellbook = CheckSpellbook;
      component.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(m_Spellbook);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BackToBack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_BackToBackFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(BackToBack))]
    public UnitConfigurator AddBackToBack(
        string m_BackToBackFact,
        int Radius)
    {
      
      var component =  new BackToBack();
      component.m_BackToBackFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_BackToBackFact);
      component.Radius = Radius;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BackToBackBetter"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_BackToBackBetterFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(BackToBackBetter))]
    public UnitConfigurator AddBackToBackBetter(
        string m_BackToBackBetterFact,
        int Radius)
    {
      
      var component =  new BackToBackBetter();
      component.m_BackToBackBetterFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_BackToBackBetterFact);
      component.Radius = Radius;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BindAbilitiesToClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Abilites"><see cref="BlueprintAbility"/></param>
    /// <param name="m_CharacterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_AdditionalClasses"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_Archetypes"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(BindAbilitiesToClass))]
    public UnitConfigurator AddBindAbilitiesToClass(
        string[] m_Abilites,
        bool Cantrip,
        string m_CharacterClass,
        StatType Stat,
        string[] m_AdditionalClasses,
        string[] m_Archetypes,
        int LevelStep,
        bool Odd,
        bool FullCasterChecks)
    {
      ValidateParam(Stat);
      
      var component =  new BindAbilitiesToClass();
      component.m_Abilites = m_Abilites.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      component.Cantrip = Cantrip;
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_CharacterClass);
      component.Stat = Stat;
      component.m_AdditionalClasses = m_AdditionalClasses.Select(bp => BlueprintTool.GetRef<BlueprintCharacterClassReference>(bp)).ToArray();
      component.m_Archetypes = m_Archetypes.Select(bp => BlueprintTool.GetRef<BlueprintArchetypeReference>(bp)).ToArray();
      component.LevelStep = LevelStep;
      component.Odd = Odd;
      component.FullCasterChecks = FullCasterChecks;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BindAbilitiesToHighest"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Abilities"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(BindAbilitiesToHighest))]
    public UnitConfigurator AddBindAbilitiesToHighest(
        string[] m_Abilities)
    {
      
      var component =  new BindAbilitiesToHighest();
      component.m_Abilities = m_Abilities.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BlindnessACCompensation"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BlindnessACCompensation))]
    public UnitConfigurator AddBlindnessACCompensation()
    {
      return AddComponent(new BlindnessACCompensation());
    }

    /// <summary>
    /// Adds <see cref="Blindsense"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_ExceptionFacts"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(Blindsense))]
    public UnitConfigurator AddBlindsense(
        Feet Range,
        bool Blindsight,
        bool HasExceptions,
        string[] m_ExceptionFacts)
    {
      ValidateParam(Range);
      
      var component =  new Blindsense();
      component.Range = Range;
      component.Blindsight = Blindsight;
      component.HasExceptions = HasExceptions;
      component.m_ExceptionFacts = m_ExceptionFacts.Select(bp => BlueprintTool.GetRef<BlueprintFeatureReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BodyguardACBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(BodyguardACBonus))]
    public UnitConfigurator AddBodyguardACBonus(
        string m_CheckBuff,
        ModifierDescriptor Descriptor,
        ContextValue Value)
    {
      ValidateParam(Descriptor);
      ValidateParam(Value);
      
      var component =  new BodyguardACBonus();
      component.m_CheckBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_CheckBuff);
      component.Descriptor = Descriptor;
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffExtraEffects"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedBuff"><see cref="BlueprintBuff"/></param>
    /// <param name="m_ExtraEffectBuff"><see cref="BlueprintBuff"/></param>
    /// <param name="m_ExceptionFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(BuffExtraEffects))]
    public UnitConfigurator AddBuffExtraEffects(
        string m_CheckedBuff,
        string m_ExtraEffectBuff,
        string m_ExceptionFact)
    {
      
      var component =  new BuffExtraEffects();
      component.m_CheckedBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_CheckedBuff);
      component.m_ExtraEffectBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_ExtraEffectBuff);
      component.m_ExceptionFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_ExceptionFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffSubstitutionOnApply"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_GainedFact"><see cref="BlueprintBuff"/></param>
    /// <param name="m_SubstituteBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(BuffSubstitutionOnApply))]
    public UnitConfigurator AddBuffSubstitutionOnApply(
        string m_GainedFact,
        string m_SubstituteBuff,
        bool CheckDescriptor,
        SpellDescriptorWrapper SpellDescriptor)
    {
      ValidateParam(SpellDescriptor);
      
      var component =  new BuffSubstitutionOnApply();
      component.m_GainedFact = BlueprintTool.GetRef<BlueprintBuffReference>(m_GainedFact);
      component.m_SubstituteBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_SubstituteBuff);
      component.CheckDescriptor = CheckDescriptor;
      component.SpellDescriptor = SpellDescriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CMBBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(CMBBonus))]
    public UnitConfigurator AddCMBBonus(
        ModifierDescriptor Descriptor,
        ContextValue Value,
        bool CheckFact,
        string m_CheckedFact)
    {
      ValidateParam(Descriptor);
      ValidateParam(Value);
      
      var component =  new CMBBonus();
      component.Descriptor = Descriptor;
      component.Value = Value;
      component.CheckFact = CheckFact;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_CheckedFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CMBBonusAgainstSize"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(CMBBonusAgainstSize))]
    public UnitConfigurator AddCMBBonusAgainstSize(
        ModifierDescriptor Descriptor,
        ContextValue Value,
        Size Size,
        bool CheckFact,
        string m_CheckedFact)
    {
      ValidateParam(Descriptor);
      ValidateParam(Value);
      ValidateParam(Size);
      
      var component =  new CMBBonusAgainstSize();
      component.Descriptor = Descriptor;
      component.Value = Value;
      component.Size = Size;
      component.CheckFact = CheckFact;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_CheckedFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CMBBonusForManeuver"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(CMBBonusForManeuver))]
    public UnitConfigurator AddCMBBonusForManeuver(
        ModifierDescriptor Descriptor,
        ContextValue Value,
        bool CheckFact,
        string m_CheckedFact,
        CombatManeuver[] Maneuvers)
    {
      ValidateParam(Descriptor);
      ValidateParam(Value);
      foreach (var item in Maneuvers)
      {
        ValidateParam(item);
      }
      
      var component =  new CMBBonusForManeuver();
      component.Descriptor = Descriptor;
      component.Value = Value;
      component.CheckFact = CheckFact;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_CheckedFact);
      component.Maneuvers = Maneuvers;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CMDBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(CMDBonus))]
    public UnitConfigurator AddCMDBonus(
        ModifierDescriptor Descriptor,
        ContextValue Value,
        bool CheckFact,
        string m_CheckedFact,
        bool OnCaster)
    {
      ValidateParam(Descriptor);
      ValidateParam(Value);
      
      var component =  new CMDBonus();
      component.Descriptor = Descriptor;
      component.Value = Value;
      component.CheckFact = CheckFact;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_CheckedFact);
      component.OnCaster = OnCaster;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CMDBonusAgainstManeuvers"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CMDBonusAgainstManeuvers))]
    public UnitConfigurator AddCMDBonusAgainstManeuvers(
        ModifierDescriptor Descriptor,
        ContextValue Value,
        CombatManeuver[] Maneuvers)
    {
      ValidateParam(Descriptor);
      ValidateParam(Value);
      foreach (var item in Maneuvers)
      {
        ValidateParam(item);
      }
      
      var component =  new CMDBonusAgainstManeuvers();
      component.Descriptor = Descriptor;
      component.Value = Value;
      component.Maneuvers = Maneuvers;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CMDBonusAgainstSize"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(CMDBonusAgainstSize))]
    public UnitConfigurator AddCMDBonusAgainstSize(
        ModifierDescriptor Descriptor,
        ContextValue Value,
        Size Size,
        bool CheckFact,
        string m_CheckedFact,
        bool OnCaster)
    {
      ValidateParam(Descriptor);
      ValidateParam(Value);
      ValidateParam(Size);
      
      var component =  new CMDBonusAgainstSize();
      component.Descriptor = Descriptor;
      component.Value = Value;
      component.Size = Size;
      component.CheckFact = CheckFact;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_CheckedFact);
      component.OnCaster = OnCaster;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CannyDefense"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CharacterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_ChosenWeaponBlueprint"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(CannyDefense))]
    public UnitConfigurator AddCannyDefense(
        string m_CharacterClass,
        bool RequiresKensai,
        string m_ChosenWeaponBlueprint)
    {
      
      var component =  new CannyDefense();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_CharacterClass);
      component.RequiresKensai = RequiresKensai;
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(m_ChosenWeaponBlueprint);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CavalierMountedMastery"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CavalierMountedMastery))]
    public UnitConfigurator AddCavalierMountedMastery(
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Descriptor);
      
      var component =  new CavalierMountedMastery();
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CavalierRetribution"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(CavalierRetribution))]
    public UnitConfigurator AddCavalierRetribution(
        string m_Buff)
    {
      
      var component =  new CavalierRetribution();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CavalierStandAgainstDarkness"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(CavalierStandAgainstDarkness))]
    public UnitConfigurator AddCavalierStandAgainstDarkness(
        string m_CheckedFact)
    {
      
      var component =  new CavalierStandAgainstDarkness();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_CheckedFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CavalierStealGlory"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CavalierStealGlory))]
    public UnitConfigurator AddCavalierStealGlory()
    {
      return AddComponent(new CavalierStealGlory());
    }

    /// <summary>
    /// Adds <see cref="ChargeAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChargeAttackBonus))]
    public UnitConfigurator AddChargeAttackBonus(
        bool CheckWielder,
        ModifierDescriptor Descriptor,
        ContextValue Bonus)
    {
      ValidateParam(Descriptor);
      ValidateParam(Bonus);
      
      var component =  new ChargeAttackBonus();
      component.CheckWielder = CheckWielder;
      component.Descriptor = Descriptor;
      component.Bonus = Bonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChargeImprovedCritical"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChargeImprovedCritical))]
    public UnitConfigurator AddChargeImprovedCritical()
    {
      return AddComponent(new ChargeImprovedCritical());
    }

    /// <summary>
    /// Adds <see cref="ClassLevelsForPrerequisites"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_FakeClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_ActualClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(ClassLevelsForPrerequisites))]
    public UnitConfigurator AddClassLevelsForPrerequisites(
        string m_FakeClass,
        string m_ActualClass,
        double Modifier,
        int Summand)
    {
      
      var component =  new ClassLevelsForPrerequisites();
      component.m_FakeClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_FakeClass);
      component.m_ActualClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_ActualClass);
      component.Modifier = Modifier;
      component.Summand = Summand;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CombatAgainstMeTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CombatAgainstMeTrigger))]
    public UnitConfigurator AddCombatAgainstMeTrigger(
        ActionsBuilder CombatStartActions,
        ActionsBuilder CombatEndActions)
    {
      
      var component =  new CombatAgainstMeTrigger();
      component.CombatStartActions = CombatStartActions.Build();
      component.CombatEndActions = CombatEndActions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CombatStateTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CombatStateTrigger))]
    public UnitConfigurator AddCombatStateTrigger(
        ActionsBuilder CombatStartActions,
        ActionsBuilder CombatEndActions)
    {
      
      var component =  new CombatStateTrigger();
      component.CombatStartActions = CombatStartActions.Build();
      component.CombatEndActions = CombatEndActions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CompanionBoon"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_RankFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(CompanionBoon))]
    public UnitConfigurator AddCompanionBoon(
        string m_RankFeature,
        int Bonus)
    {
      
      var component =  new CompanionBoon();
      component.m_RankFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(m_RankFeature);
      component.Bonus = Bonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ConcentrationBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_RequiredFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ConcentrationBonus))]
    public UnitConfigurator AddConcentrationBonus(
        ContextValue Value,
        bool CheckFact,
        string m_RequiredFact)
    {
      ValidateParam(Value);
      
      var component =  new ConcentrationBonus();
      component.Value = Value;
      component.CheckFact = CheckFact;
      component.m_RequiredFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_RequiredFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ConcentrationBonusOnArmorType"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ConcentrationBonusOnArmorType))]
    public UnitConfigurator AddConcentrationBonusOnArmorType(
        ContextValue Value,
        ArmorProficiencyGroup ArmorCategory)
    {
      ValidateParam(Value);
      ValidateParam(ArmorCategory);
      
      var component =  new ConcentrationBonusOnArmorType();
      component.Value = Value;
      component.ArmorCategory = ArmorCategory;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ConstructHealth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ConstructHealth))]
    public UnitConfigurator AddConstructHealth()
    {
      return AddComponent(new ConstructHealth());
    }

    /// <summary>
    /// Adds <see cref="ContextRendFeature"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextRendFeature))]
    public UnitConfigurator AddContextRendFeature(
        ContextDiceValue Value,
        DamageTypeDescription RendType)
    {
      ValidateParam(Value);
      ValidateParam(RendType);
      
      var component =  new ContextRendFeature();
      component.Value = Value;
      component.RendType = RendType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CoordinatedDefense"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CoordinatedDefenseFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(CoordinatedDefense))]
    public UnitConfigurator AddCoordinatedDefense(
        string m_CoordinatedDefenseFact,
        int Radius)
    {
      
      var component =  new CoordinatedDefense();
      component.m_CoordinatedDefenseFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_CoordinatedDefenseFact);
      component.Radius = Radius;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CoordinatedManeuvers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CoordinatedManeuversFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(CoordinatedManeuvers))]
    public UnitConfigurator AddCoordinatedManeuvers(
        string m_CoordinatedManeuversFact,
        int Radius)
    {
      
      var component =  new CoordinatedManeuvers();
      component.m_CoordinatedManeuversFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_CoordinatedManeuversFact);
      component.Radius = Radius;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CraftBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CraftBonus))]
    public UnitConfigurator AddCraftBonus(
        UsableItemType m_BonusFor,
        ContextValue m_Value)
    {
      ValidateParam(m_BonusFor);
      ValidateParam(m_Value);
      
      var component =  new CraftBonus();
      component.m_BonusFor = m_BonusFor;
      component.m_Value = m_Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CriticalConfirmationACBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CriticalConfirmationACBonus))]
    public UnitConfigurator AddCriticalConfirmationACBonus(
        ContextValue Value,
        int Bonus,
        bool OnlyPositiveValue,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Value);
      ValidateParam(Descriptor);
      
      var component =  new CriticalConfirmationACBonus();
      component.Value = Value;
      component.Bonus = Bonus;
      component.OnlyPositiveValue = OnlyPositiveValue;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CriticalConfirmationACBonusAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(CriticalConfirmationACBonusAgainstFactOwner))]
    public UnitConfigurator AddCriticalConfirmationACBonusAgainstFactOwner(
        string m_CheckedFact,
        ContextValue Value,
        int Bonus,
        bool OnlyPositiveValue,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Value);
      ValidateParam(Descriptor);
      
      var component =  new CriticalConfirmationACBonusAgainstFactOwner();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_CheckedFact);
      component.Value = Value;
      component.Bonus = Bonus;
      component.OnlyPositiveValue = OnlyPositiveValue;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CriticalConfirmationACBonusInHeavyArmor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CriticalConfirmationACBonusInHeavyArmor))]
    public UnitConfigurator AddCriticalConfirmationACBonusInHeavyArmor(
        int Bonus,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Descriptor);
      
      var component =  new CriticalConfirmationACBonusInHeavyArmor();
      component.Bonus = Bonus;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CriticalConfirmationBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CriticalConfirmationBonus))]
    public UnitConfigurator AddCriticalConfirmationBonus(
        ContextValue Value,
        int Bonus,
        bool OnlyPositiveValue,
        bool CheckWeaponRangeType,
        WeaponRangeType Type)
    {
      ValidateParam(Value);
      ValidateParam(Type);
      
      var component =  new CriticalConfirmationBonus();
      component.Value = Value;
      component.Bonus = Bonus;
      component.OnlyPositiveValue = OnlyPositiveValue;
      component.CheckWeaponRangeType = CheckWeaponRangeType;
      component.Type = Type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DRWithPool"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(DRWithPool))]
    public UnitConfigurator AddDRWithPool(
        int m_drPoolPerRank,
        int m_reduction,
        int m_maxPool,
        string m_Buff)
    {
      
      var component =  new DRWithPool();
      component.m_drPoolPerRank = m_drPoolPerRank;
      component.m_reduction = m_reduction;
      component.m_maxPool = m_maxPool;
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageBonusAgainstAlignment))]
    public UnitConfigurator AddDamageBonusAgainstAlignment(
        AlignmentComponent Alignment,
        bool OnlyMelee,
        int DamageBonus,
        ContextValue Bonus,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Alignment);
      ValidateParam(Bonus);
      ValidateParam(Descriptor);
      
      var component =  new DamageBonusAgainstAlignment();
      component.Alignment = Alignment;
      component.OnlyMelee = OnlyMelee;
      component.DamageBonus = DamageBonus;
      component.Bonus = Bonus;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(DamageBonusAgainstFactOwner))]
    public UnitConfigurator AddDamageBonusAgainstFactOwner(
        string m_CheckedFact,
        int DamageBonus,
        ContextValue Bonus,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Bonus);
      ValidateParam(Descriptor);
      
      var component =  new DamageBonusAgainstFactOwner();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_CheckedFact);
      component.DamageBonus = DamageBonus;
      component.Bonus = Bonus;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstSize"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(DamageBonusAgainstSize))]
    public UnitConfigurator AddDamageBonusAgainstSize(
        ContextValue DamageValue,
        Size size,
        bool BiggerOrEqualSize,
        bool OnlyForMelee,
        ModifierDescriptor Descriptor,
        string m_CheckedFact)
    {
      ValidateParam(DamageValue);
      ValidateParam(size);
      ValidateParam(Descriptor);
      
      var component =  new DamageBonusAgainstSize();
      component.DamageValue = DamageValue;
      component.size = size;
      component.BiggerOrEqualSize = BiggerOrEqualSize;
      component.OnlyForMelee = OnlyForMelee;
      component.Descriptor = Descriptor;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_CheckedFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusOrderOfCockatrice"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(DamageBonusOrderOfCockatrice))]
    public UnitConfigurator AddDamageBonusOrderOfCockatrice(
        string m_CheckedFact,
        ContextValue Bonus,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Bonus);
      ValidateParam(Descriptor);
      
      var component =  new DamageBonusOrderOfCockatrice();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_CheckedFact);
      component.Bonus = Bonus;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageGrace"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageGrace))]
    public UnitConfigurator AddDamageGrace()
    {
      return AddComponent(new DamageGrace());
    }

    /// <summary>
    /// Adds <see cref="DamageReductionAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(DamageReductionAgainstFactOwner))]
    public UnitConfigurator AddDamageReductionAgainstFactOwner(
        string m_CheckedFact,
        int Reduction)
    {
      
      var component =  new DamageReductionAgainstFactOwner();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_CheckedFact);
      component.Reduction = Reduction;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageReductionAgainstRangedWeapons"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Type"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(DamageReductionAgainstRangedWeapons))]
    public UnitConfigurator AddDamageReductionAgainstRangedWeapons(
        string m_Type,
        int ReductionTrue,
        int ReductionFalse)
    {
      
      var component =  new DamageReductionAgainstRangedWeapons();
      component.m_Type = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(m_Type);
      component.ReductionTrue = ReductionTrue;
      component.ReductionFalse = ReductionFalse;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageReductionAgainstSpells"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(DamageReductionAgainstSpells))]
    public UnitConfigurator AddDamageReductionAgainstSpells(
        string[] m_Spells,
        int Reduction)
    {
      
      var component =  new DamageReductionAgainstSpells();
      component.m_Spells = m_Spells.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      component.Reduction = Reduction;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageReductionBelowZero"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageReductionBelowZero))]
    public UnitConfigurator AddDamageReductionBelowZero(
        int Reduction,
        bool EpicBypass)
    {
      
      var component =  new DamageReductionBelowZero();
      component.Reduction = Reduction;
      component.EpicBypass = EpicBypass;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DeathOnLevelStacks"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DeathOnLevelStacks))]
    public UnitConfigurator AddDeathOnLevelStacks()
    {
      return AddComponent(new DeathOnLevelStacks());
    }

    /// <summary>
    /// Adds <see cref="DefaultSourceBone"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DefaultSourceBone))]
    public UnitConfigurator AddDefaultSourceBone()
    {
      return AddComponent(new DefaultSourceBone());
    }

    /// <summary>
    /// Adds <see cref="DefensiveCombatTraining"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DefensiveCombatTraining))]
    public UnitConfigurator AddDefensiveCombatTraining(
        bool Mythic)
    {
      
      var component =  new DefensiveCombatTraining();
      component.Mythic = Mythic;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DerivativeStatBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DerivativeStatBonus))]
    public UnitConfigurator AddDerivativeStatBonus(
        StatType BaseStat,
        StatType DerivativeStat,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(BaseStat);
      ValidateParam(DerivativeStat);
      ValidateParam(Descriptor);
      
      var component =  new DerivativeStatBonus();
      component.BaseStat = BaseStat;
      component.DerivativeStat = DerivativeStat;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DetachBuffOnNearMiss"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DetachBuffOnNearMiss))]
    public UnitConfigurator AddDetachBuffOnNearMiss(
        bool MeleeOnly,
        bool RangedOnly,
        int HitAndArmorDifference,
        ActionsBuilder Action,
        bool OnAttacker)
    {
      
      var component =  new DetachBuffOnNearMiss();
      component.MeleeOnly = MeleeOnly;
      component.RangedOnly = RangedOnly;
      component.HitAndArmorDifference = HitAndArmorDifference;
      component.Action = Action.Build();
      component.OnAttacker = OnAttacker;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DiceDamageBonusOnSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(DiceDamageBonusOnSpell))]
    public UnitConfigurator AddDiceDamageBonusOnSpell(
        string[] m_Spells,
        bool UseContextBonus,
        ContextValue Value)
    {
      ValidateParam(Value);
      
      var component =  new DiceDamageBonusOnSpell();
      component.m_Spells = m_Spells.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      component.UseContextBonus = UseContextBonus;
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DisableIntelligence"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DisableIntelligence))]
    public UnitConfigurator AddDisableIntelligence()
    {
      return AddComponent(new DisableIntelligence());
    }

    /// <summary>
    /// Adds <see cref="DisableRegenerationOnCriticalHit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DisableRegenerationOnCriticalHit))]
    public UnitConfigurator AddDisableRegenerationOnCriticalHit()
    {
      return AddComponent(new DisableRegenerationOnCriticalHit());
    }

    /// <summary>
    /// Adds <see cref="DispelBonusOnDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DispelBonusOnDescriptor))]
    public UnitConfigurator AddDispelBonusOnDescriptor(
        SpellDescriptorWrapper Descriptor,
        int Bonus)
    {
      ValidateParam(Descriptor);
      
      var component =  new DispelBonusOnDescriptor();
      component.Descriptor = Descriptor;
      component.Bonus = Bonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DispelCasterLevelCheckBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DispelCasterLevelCheckBonus))]
    public UnitConfigurator AddDispelCasterLevelCheckBonus(
        ContextValue Value)
    {
      ValidateParam(Value);
      
      var component =  new DispelCasterLevelCheckBonus();
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DistanceAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DistanceAttackBonus))]
    public UnitConfigurator AddDistanceAttackBonus(
        Feet Range,
        int AttackBonus,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Range);
      ValidateParam(Descriptor);
      
      var component =  new DistanceAttackBonus();
      component.Range = Range;
      component.AttackBonus = AttackBonus;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DistanceDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DistanceDamageBonus))]
    public UnitConfigurator AddDistanceDamageBonus(
        Feet Range,
        int DamageBonus)
    {
      ValidateParam(Range);
      
      var component =  new DistanceDamageBonus();
      component.Range = Range;
      component.DamageBonus = DamageBonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DoNotBenefitFromConcealment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DoNotBenefitFromConcealment))]
    public UnitConfigurator AddDoNotBenefitFromConcealment()
    {
      return AddComponent(new DoNotBenefitFromConcealment());
    }

    /// <summary>
    /// Adds <see cref="DraconicBloodlineArcana"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DraconicBloodlineArcana))]
    public UnitConfigurator AddDraconicBloodlineArcana(
        SpellDescriptorWrapper SpellDescriptor,
        bool SpellsOnly,
        bool UseContextBonus,
        ContextValue Value)
    {
      ValidateParam(SpellDescriptor);
      ValidateParam(Value);
      
      var component =  new DraconicBloodlineArcana();
      component.SpellDescriptor = SpellDescriptor;
      component.SpellsOnly = SpellsOnly;
      component.UseContextBonus = UseContextBonus;
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DuelistPreciseStrike"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Duelist"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_CloakDuelistFact"><see cref="BlueprintBuff"/></param>
    /// <param name="m_CloakNonDuelistFact"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(DuelistPreciseStrike))]
    public UnitConfigurator AddDuelistPreciseStrike(
        string m_Duelist,
        string m_CloakDuelistFact,
        string m_CloakNonDuelistFact)
    {
      
      var component =  new DuelistPreciseStrike();
      component.m_Duelist = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_Duelist);
      component.m_CloakDuelistFact = BlueprintTool.GetRef<BlueprintBuffReference>(m_CloakDuelistFact);
      component.m_CloakNonDuelistFact = BlueprintTool.GetRef<BlueprintBuffReference>(m_CloakNonDuelistFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DungeonClassRestrictedBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(DungeonClassRestrictedBuff))]
    public UnitConfigurator AddDungeonClassRestrictedBuff(
        string m_Buff)
    {
      
      var component =  new DungeonClassRestrictedBuff();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EnduringSpells"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Greater"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(EnduringSpells))]
    public UnitConfigurator AddEnduringSpells(
        string m_Greater)
    {
      
      var component =  new EnduringSpells();
      component.m_Greater = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_Greater);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Evasion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Evasion))]
    public UnitConfigurator AddEvasion(
        SavingThrowType SavingThrow)
    {
      ValidateParam(SavingThrow);
      
      var component =  new Evasion();
      component.SavingThrow = SavingThrow;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EvasionAgainstDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EvasionAgainstDescriptor))]
    public UnitConfigurator AddEvasionAgainstDescriptor(
        SpellDescriptorWrapper SpellDescriptor,
        SavingThrowType SavingThrow)
    {
      ValidateParam(SpellDescriptor);
      ValidateParam(SavingThrow);
      
      var component =  new EvasionAgainstDescriptor();
      component.SpellDescriptor = SpellDescriptor;
      component.SavingThrow = SavingThrow;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EvasionWithTowerShield"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EvasionWithTowerShield))]
    public UnitConfigurator AddEvasionWithTowerShield(
        bool Improved)
    {
      
      var component =  new EvasionWithTowerShield();
      component.Improved = Improved;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ExpandedArsenalMagicSchools"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ExpandedArsenalMagicSchools))]
    public UnitConfigurator AddExpandedArsenalMagicSchools()
    {
      return AddComponent(new ExpandedArsenalMagicSchools());
    }

    /// <summary>
    /// Adds <see cref="FactSinglify"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_OldFacts"><see cref="BlueprintUnitFact"/></param>
    /// <param name="m_NewFacts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(FactSinglify))]
    public UnitConfigurator AddFactSinglify(
        string[] m_OldFacts,
        string[] m_NewFacts)
    {
      
      var component =  new FactSinglify();
      component.m_OldFacts = m_OldFacts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      component.m_NewFacts = m_NewFacts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FactsChangeTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFacts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(FactsChangeTrigger))]
    public UnitConfigurator AddFactsChangeTrigger(
        string[] m_CheckedFacts,
        ActionsBuilder OnFactGainedActions,
        ActionsBuilder OnFactLostActions)
    {
      
      var component =  new FactsChangeTrigger();
      component.m_CheckedFacts = m_CheckedFacts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      component.OnFactGainedActions = OnFactGainedActions.Build();
      component.OnFactLostActions = OnFactLostActions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FlankedAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(FlankedAttackBonus))]
    public UnitConfigurator AddFlankedAttackBonus(
        int AttackBonus,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Descriptor);
      
      var component =  new FlankedAttackBonus();
      component.AttackBonus = AttackBonus;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FlatFootedIgnore"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(FlatFootedIgnore))]
    public UnitConfigurator AddFlatFootedIgnore(
        FlatFootedIgnoreType Type)
    {
      ValidateParam(Type);
      
      var component =  new FlatFootedIgnore();
      component.Type = Type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FullSpeedInStealth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(FullSpeedInStealth))]
    public UnitConfigurator AddFullSpeedInStealth()
    {
      return AddComponent(new FullSpeedInStealth());
    }

    /// <summary>
    /// Adds <see cref="FullWeaponMasterySkeletonParametrized"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Focus"><see cref="BlueprintParametrizedFeature"/></param>
    /// <param name="m_Specialization"><see cref="BlueprintParametrizedFeature"/></param>
    /// <param name="m_GreaterFocus"><see cref="BlueprintParametrizedFeature"/></param>
    /// <param name="m_GreaterSpecialization"><see cref="BlueprintParametrizedFeature"/></param>
    /// <param name="m_ImprovedCritical"><see cref="BlueprintParametrizedFeature"/></param>
    /// <param name="m_WeaponMastery"><see cref="BlueprintParametrizedFeature"/></param>
    /// <param name="m_GreaterFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(FullWeaponMasterySkeletonParametrized))]
    public UnitConfigurator AddFullWeaponMasterySkeletonParametrized(
        string m_Focus,
        string m_Specialization,
        string m_GreaterFocus,
        string m_GreaterSpecialization,
        string m_ImprovedCritical,
        string m_WeaponMastery,
        string m_GreaterFeature)
    {
      
      var component =  new FullWeaponMasterySkeletonParametrized();
      component.m_Focus = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(m_Focus);
      component.m_Specialization = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(m_Specialization);
      component.m_GreaterFocus = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(m_GreaterFocus);
      component.m_GreaterSpecialization = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(m_GreaterSpecialization);
      component.m_ImprovedCritical = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(m_ImprovedCritical);
      component.m_WeaponMastery = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(m_WeaponMastery);
      component.m_GreaterFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(m_GreaterFeature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Hardy"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_SteelSoul"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(Hardy))]
    public UnitConfigurator AddHardy(
        string m_SteelSoul)
    {
      
      var component =  new Hardy();
      component.m_SteelSoul = BlueprintTool.GetRef<BlueprintFeatureReference>(m_SteelSoul);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="HarmoniousMage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HarmoniousMage))]
    public UnitConfigurator AddHarmoniousMage()
    {
      return AddComponent(new HarmoniousMage());
    }

    /// <summary>
    /// Adds <see cref="IgnoreConcealment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreConcealment))]
    public UnitConfigurator AddIgnoreConcealment()
    {
      return AddComponent(new IgnoreConcealment());
    }

    /// <summary>
    /// Adds <see cref="IgnoreCritImmunity"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(IgnoreCritImmunity))]
    public UnitConfigurator AddIgnoreCritImmunity(
        bool CheckFact,
        string m_CheckedFact,
        bool Not)
    {
      
      var component =  new IgnoreCritImmunity();
      component.CheckFact = CheckFact;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_CheckedFact);
      component.Not = Not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreDamageReductionOnCriticalHit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreDamageReductionOnCriticalHit))]
    public UnitConfigurator AddIgnoreDamageReductionOnCriticalHit()
    {
      return AddComponent(new IgnoreDamageReductionOnCriticalHit());
    }

    /// <summary>
    /// Adds <see cref="IgnoreDamageReductionOnTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreDamageReductionOnTarget))]
    public UnitConfigurator AddIgnoreDamageReductionOnTarget(
        bool CheckTargetAlignment,
        AlignmentComponent Alignment)
    {
      ValidateParam(Alignment);
      
      var component =  new IgnoreDamageReductionOnTarget();
      component.CheckTargetAlignment = CheckTargetAlignment;
      component.Alignment = Alignment;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnorePartialConcealmentOnRangedAttacks"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnorePartialConcealmentOnRangedAttacks))]
    public UnitConfigurator AddIgnorePartialConcealmentOnRangedAttacks()
    {
      return AddComponent(new IgnorePartialConcealmentOnRangedAttacks());
    }

    /// <summary>
    /// Adds <see cref="IgnoreSpellResistanceForSpells"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_AbilityList"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(IgnoreSpellResistanceForSpells))]
    public UnitConfigurator AddIgnoreSpellResistanceForSpells(
        string[] m_AbilityList,
        bool AllSpells)
    {
      
      var component =  new IgnoreSpellResistanceForSpells();
      component.m_AbilityList = m_AbilityList.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      component.AllSpells = AllSpells;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ImpromptuSneakAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ImpromptuSneakAttack))]
    public UnitConfigurator AddImpromptuSneakAttack()
    {
      return AddComponent(new ImpromptuSneakAttack());
    }

    /// <summary>
    /// Adds <see cref="ImprovedCriticalEdgeParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ImprovedCriticalEdgeParametrized))]
    public UnitConfigurator AddImprovedCriticalEdgeParametrized()
    {
      return AddComponent(new ImprovedCriticalEdgeParametrized());
    }

    /// <summary>
    /// Adds <see cref="ImprovedCriticalMythicParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ImprovedCriticalMythicParametrized))]
    public UnitConfigurator AddImprovedCriticalMythicParametrized()
    {
      return AddComponent(new ImprovedCriticalMythicParametrized());
    }

    /// <summary>
    /// Adds <see cref="ImprovedCriticalParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ImprovedCriticalParametrized))]
    public UnitConfigurator AddImprovedCriticalParametrized()
    {
      return AddComponent(new ImprovedCriticalParametrized());
    }

    /// <summary>
    /// Adds <see cref="ImprovedEvasion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ImprovedEvasion))]
    public UnitConfigurator AddImprovedEvasion(
        SavingThrowType SavingThrow)
    {
      ValidateParam(SavingThrow);
      
      var component =  new ImprovedEvasion();
      component.SavingThrow = SavingThrow;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="InHarmsWay"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckBuff"><see cref="BlueprintBuff"/></param>
    /// <param name="m_CooldownBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(InHarmsWay))]
    public UnitConfigurator AddInHarmsWay(
        string m_CheckBuff,
        string m_CooldownBuff)
    {
      
      var component =  new InHarmsWay();
      component.m_CheckBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_CheckBuff);
      component.m_CooldownBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_CooldownBuff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseAllSpellsDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseAllSpellsDC))]
    public UnitConfigurator AddIncreaseAllSpellsDC(
        ContextValue Value,
        ModifierDescriptor Descriptor,
        bool SpellsOnly)
    {
      ValidateParam(Value);
      ValidateParam(Descriptor);
      
      var component =  new IncreaseAllSpellsDC();
      component.Value = Value;
      component.Descriptor = Descriptor;
      component.SpellsOnly = SpellsOnly;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseCasterLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseCasterLevel))]
    public UnitConfigurator AddIncreaseCasterLevel(
        ContextValue Value,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Value);
      ValidateParam(Descriptor);
      
      var component =  new IncreaseCasterLevel();
      component.Value = Value;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseCastersSavingThrowTypeDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseCastersSavingThrowTypeDC))]
    public UnitConfigurator AddIncreaseCastersSavingThrowTypeDC(
        SavingThrowType Type,
        int BonusDC)
    {
      ValidateParam(Type);
      
      var component =  new IncreaseCastersSavingThrowTypeDC();
      component.Type = Type;
      component.BonusDC = BonusDC;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseFeatRankByGroup"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseFeatRankByGroup))]
    public UnitConfigurator AddIncreaseFeatRankByGroup(
        FeatureGroup Group)
    {
      ValidateParam(Group);
      
      var component =  new IncreaseFeatRankByGroup();
      component.Group = Group;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellContextDescriptorDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseSpellContextDescriptorDC))]
    public UnitConfigurator AddIncreaseSpellContextDescriptorDC(
        SpellDescriptorWrapper Descriptor,
        ContextValue Value,
        ModifierDescriptor ModifierDescriptor,
        bool SpellsOnly)
    {
      ValidateParam(Descriptor);
      ValidateParam(Value);
      ValidateParam(ModifierDescriptor);
      
      var component =  new IncreaseSpellContextDescriptorDC();
      component.Descriptor = Descriptor;
      component.Value = Value;
      component.ModifierDescriptor = ModifierDescriptor;
      component.SpellsOnly = SpellsOnly;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellDC"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spell"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(IncreaseSpellDC))]
    public UnitConfigurator AddIncreaseSpellDC(
        string m_Spell,
        bool HalfMythicRank,
        bool UseContextBonus,
        ContextValue Value,
        int BonusDC,
        ModifierDescriptor Descriptor,
        bool SpellsOnly)
    {
      ValidateParam(Value);
      ValidateParam(Descriptor);
      
      var component =  new IncreaseSpellDC();
      component.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(m_Spell);
      component.HalfMythicRank = HalfMythicRank;
      component.UseContextBonus = UseContextBonus;
      component.Value = Value;
      component.BonusDC = BonusDC;
      component.Descriptor = Descriptor;
      component.SpellsOnly = SpellsOnly;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellDescriptorCasterLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseSpellDescriptorCasterLevel))]
    public UnitConfigurator AddIncreaseSpellDescriptorCasterLevel(
        SpellDescriptorWrapper Descriptor,
        int BonusCasterLevel,
        ModifierDescriptor ModifierDescriptor)
    {
      ValidateParam(Descriptor);
      ValidateParam(ModifierDescriptor);
      
      var component =  new IncreaseSpellDescriptorCasterLevel();
      component.Descriptor = Descriptor;
      component.BonusCasterLevel = BonusCasterLevel;
      component.ModifierDescriptor = ModifierDescriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellDescriptorDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseSpellDescriptorDC))]
    public UnitConfigurator AddIncreaseSpellDescriptorDC(
        SpellDescriptorWrapper Descriptor,
        int BonusDC,
        ModifierDescriptor ModifierDescriptor,
        bool SpellsOnly)
    {
      ValidateParam(Descriptor);
      ValidateParam(ModifierDescriptor);
      
      var component =  new IncreaseSpellDescriptorDC();
      component.Descriptor = Descriptor;
      component.BonusDC = BonusDC;
      component.ModifierDescriptor = ModifierDescriptor;
      component.SpellsOnly = SpellsOnly;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellSchoolCasterLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseSpellSchoolCasterLevel))]
    public UnitConfigurator AddIncreaseSpellSchoolCasterLevel(
        SpellSchool School,
        int BonusLevel,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(School);
      ValidateParam(Descriptor);
      
      var component =  new IncreaseSpellSchoolCasterLevel();
      component.School = School;
      component.BonusLevel = BonusLevel;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellSchoolDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseSpellSchoolDC))]
    public UnitConfigurator AddIncreaseSpellSchoolDC(
        SpellSchool School,
        int BonusDC,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(School);
      ValidateParam(Descriptor);
      
      var component =  new IncreaseSpellSchoolDC();
      component.School = School;
      component.BonusDC = BonusDC;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellSchoolDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseSpellSchoolDamage))]
    public UnitConfigurator AddIncreaseSpellSchoolDamage(
        SpellSchool School,
        ContextValue DamageBonus)
    {
      ValidateParam(School);
      ValidateParam(DamageBonus);
      
      var component =  new IncreaseSpellSchoolDamage();
      component.School = School;
      component.DamageBonus = DamageBonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellSpellbookDC"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spellbooks"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    [Implements(typeof(IncreaseSpellSpellbookDC))]
    public UnitConfigurator AddIncreaseSpellSpellbookDC(
        string[] m_Spellbooks,
        int BonusDC,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Descriptor);
      
      var component =  new IncreaseSpellSpellbookDC();
      component.m_Spellbooks = m_Spellbooks.Select(bp => BlueprintTool.GetRef<BlueprintSpellbookReference>(bp)).ToArray();
      component.BonusDC = BonusDC;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IndomitableMount"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CooldownBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(IndomitableMount))]
    public UnitConfigurator AddIndomitableMount(
        string m_CooldownBuff)
    {
      
      var component =  new IndomitableMount();
      component.m_CooldownBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_CooldownBuff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="InitiatorCritAutoconfirm"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(InitiatorCritAutoconfirm))]
    public UnitConfigurator AddInitiatorCritAutoconfirm()
    {
      return AddComponent(new InitiatorCritAutoconfirm());
    }

    /// <summary>
    /// Adds <see cref="KensaiChosenWeapon"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Focus"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(KensaiChosenWeapon))]
    public UnitConfigurator AddKensaiChosenWeapon(
        string m_Focus)
    {
      
      var component =  new KensaiChosenWeapon();
      component.m_Focus = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(m_Focus);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KensaiCriticalPerfection"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_MagusBlueprint"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_ChosenWeaponBlueprint"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(KensaiCriticalPerfection))]
    public UnitConfigurator AddKensaiCriticalPerfection(
        string m_MagusBlueprint,
        string m_ChosenWeaponBlueprint)
    {
      
      var component =  new KensaiCriticalPerfection();
      component.m_MagusBlueprint = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_MagusBlueprint);
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(m_ChosenWeaponBlueprint);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KensaiIaijutsuFocus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_MagusBlueprint"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_ChosenWeaponBlueprint"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(KensaiIaijutsuFocus))]
    public UnitConfigurator AddKensaiIaijutsuFocus(
        string m_MagusBlueprint,
        string m_ChosenWeaponBlueprint)
    {
      
      var component =  new KensaiIaijutsuFocus();
      component.m_MagusBlueprint = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_MagusBlueprint);
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(m_ChosenWeaponBlueprint);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KensaiPerfectStrike"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_MagusBlueprint"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_ChosenWeaponBlueprint"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(KensaiPerfectStrike))]
    public UnitConfigurator AddKensaiPerfectStrike(
        string m_MagusBlueprint,
        string m_ChosenWeaponBlueprint)
    {
      
      var component =  new KensaiPerfectStrike();
      component.m_MagusBlueprint = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_MagusBlueprint);
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(m_ChosenWeaponBlueprint);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KensaiPowerfulCrit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_MagusBlueprint"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_ChosenWeaponBlueprint"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(KensaiPowerfulCrit))]
    public UnitConfigurator AddKensaiPowerfulCrit(
        string m_MagusBlueprint,
        string m_ChosenWeaponBlueprint)
    {
      
      var component =  new KensaiPowerfulCrit();
      component.m_MagusBlueprint = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_MagusBlueprint);
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(m_ChosenWeaponBlueprint);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KensaiWeaponMastery"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_MagusBlueprint"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_ChosenWeaponBlueprint"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(KensaiWeaponMastery))]
    public UnitConfigurator AddKensaiWeaponMastery(
        string m_MagusBlueprint,
        string m_ChosenWeaponBlueprint)
    {
      
      var component =  new KensaiWeaponMastery();
      component.m_MagusBlueprint = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_MagusBlueprint);
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(m_ChosenWeaponBlueprint);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LearnSpellParametrized"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_SpellcasterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_SpellList"><see cref="BlueprintSpellList"/></param>
    [Generated]
    [Implements(typeof(LearnSpellParametrized))]
    public UnitConfigurator AddLearnSpellParametrized(
        string m_SpellcasterClass,
        string m_SpellList,
        bool SpecificSpellLevel,
        int SpellLevelPenalty,
        int SpellLevel)
    {
      
      var component =  new LearnSpellParametrized();
      component.m_SpellcasterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_SpellcasterClass);
      component.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(m_SpellList);
      component.SpecificSpellLevel = SpecificSpellLevel;
      component.SpellLevelPenalty = SpellLevelPenalty;
      component.SpellLevel = SpellLevel;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MadDogPackTactics"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MadDogPackTactics))]
    public UnitConfigurator AddMadDogPackTactics()
    {
      return AddComponent(new MadDogPackTactics());
    }

    /// <summary>
    /// Adds <see cref="ManeuverBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ManeuverBonus))]
    public UnitConfigurator AddManeuverBonus(
        CombatManeuver Type,
        bool Mythic,
        int Bonus,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Type);
      ValidateParam(Descriptor);
      
      var component =  new ManeuverBonus();
      component.Type = Type;
      component.Mythic = Mythic;
      component.Bonus = Bonus;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ManeuverBonusFromStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ManeuverBonusFromStat))]
    public UnitConfigurator AddManeuverBonusFromStat(
        CombatManeuver Type,
        StatType Stat,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Type);
      ValidateParam(Stat);
      ValidateParam(Descriptor);
      
      var component =  new ManeuverBonusFromStat();
      component.Type = Type;
      component.Stat = Stat;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ManeuverDefenceBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ManeuverDefenceBonus))]
    public UnitConfigurator AddManeuverDefenceBonus(
        CombatManeuver Type,
        int Bonus,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Type);
      ValidateParam(Descriptor);
      
      var component =  new ManeuverDefenceBonus();
      component.Type = Type;
      component.Bonus = Bonus;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ManeuverImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ManeuverImmunity))]
    public UnitConfigurator AddManeuverImmunity(
        CombatManeuver Type)
    {
      ValidateParam(Type);
      
      var component =  new ManeuverImmunity();
      component.Type = Type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ManeuverIncreaseDuration"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ManeuverIncreaseDuration))]
    public UnitConfigurator AddManeuverIncreaseDuration(
        CombatManeuver Type)
    {
      ValidateParam(Type);
      
      var component =  new ManeuverIncreaseDuration();
      component.Type = Type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ManeuverOnAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ManeuverOnAttack))]
    public UnitConfigurator AddManeuverOnAttack(
        WeaponCategory Category,
        CombatManeuver Maneuver)
    {
      ValidateParam(Category);
      ValidateParam(Maneuver);
      
      var component =  new ManeuverOnAttack();
      component.Category = Category;
      component.Maneuver = Maneuver;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ManeuverProvokeAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ManeuverProvokeAttack))]
    public UnitConfigurator AddManeuverProvokeAttack(
        CombatManeuver ManeuverType)
    {
      ValidateParam(ManeuverType);
      
      var component =  new ManeuverProvokeAttack();
      component.ManeuverType = ManeuverType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ManeuverTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ManeuverTrigger))]
    public UnitConfigurator AddManeuverTrigger(
        CombatManeuver ManeuverType,
        bool OnlySuccess,
        ActionsBuilder Action)
    {
      ValidateParam(ManeuverType);
      
      var component =  new ManeuverTrigger();
      component.ManeuverType = ManeuverType;
      component.OnlySuccess = OnlySuccess;
      component.Action = Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MaxDexBonusIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MaxDexBonusIncrease))]
    public UnitConfigurator AddMaxDexBonusIncrease(
        int Bonus,
        int BonesPerRank,
        bool CheckCategory,
        ArmorProficiencyGroup Category)
    {
      ValidateParam(Category);
      
      var component =  new MaxDexBonusIncrease();
      component.Bonus = Bonus;
      component.BonesPerRank = BonesPerRank;
      component.CheckCategory = CheckCategory;
      component.Category = Category;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MeleeWeaponSizeChange"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MeleeWeaponSizeChange))]
    public UnitConfigurator AddMeleeWeaponSizeChange(
        int SizeCategoryChange)
    {
      
      var component =  new MeleeWeaponSizeChange();
      component.SizeCategoryChange = SizeCategoryChange;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MetamagicOnNextSpell"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MetamagicOnNextSpell))]
    public UnitConfigurator AddMetamagicOnNextSpell(
        Metamagic Metamagic,
        bool DoNotRemove,
        bool SourcerousReflex)
    {
      ValidateParam(Metamagic);
      
      var component =  new MetamagicOnNextSpell();
      component.Metamagic = Metamagic;
      component.DoNotRemove = DoNotRemove;
      component.SourcerousReflex = SourcerousReflex;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MetamagicRodMechanics"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_RodAbility"><see cref="BlueprintActivatableAbility"/></param>
    /// <param name="m_AbilitiesWhiteList"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(MetamagicRodMechanics))]
    public UnitConfigurator AddMetamagicRodMechanics(
        Metamagic Metamagic,
        int MaxSpellLevel,
        string m_RodAbility,
        string[] m_AbilitiesWhiteList)
    {
      ValidateParam(Metamagic);
      
      var component =  new MetamagicRodMechanics();
      component.Metamagic = Metamagic;
      component.MaxSpellLevel = MaxSpellLevel;
      component.m_RodAbility = BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(m_RodAbility);
      component.m_AbilitiesWhiteList = m_AbilitiesWhiteList.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MobCaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MobCaster))]
    public UnitConfigurator AddMobCaster()
    {
      return AddComponent(new MobCaster());
    }

    /// <summary>
    /// Adds <see cref="ModifyD20"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_TandemTripFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(ModifyD20))]
    public UnitConfigurator AddModifyD20(
        RuleType Rule,
        RuleDispelMagic.CheckType DispellMagicCheckType,
        bool Replace,
        int RollsAmount,
        bool TakeBest,
        int Roll,
        bool AddBonus,
        ContextValue Bonus,
        ModifierDescriptor BonusDescriptor,
        bool WithChance,
        ContextValue Chance,
        bool RerollOnlyIfFailed,
        bool DispellOnRerollFinished,
        bool DispellOn20,
        bool AgainstAlignment,
        AlignmentComponent Alignment,
        bool TargetAlignment,
        bool SpecificSkill,
        StatType[] Skill,
        ModifyD20.InnerSavingThrowType m_SavingThrowType,
        bool SpecificDescriptor,
        SpellDescriptorWrapper SpellDescriptor,
        bool AddSavingThrowBonus,
        ModifierDescriptor ModifierDescriptor,
        ContextValue Value,
        bool TandemTrip,
        string m_TandemTripFeature)
    {
      ValidateParam(Rule);
      ValidateParam(DispellMagicCheckType);
      ValidateParam(Bonus);
      ValidateParam(BonusDescriptor);
      ValidateParam(Chance);
      ValidateParam(Alignment);
      foreach (var item in Skill)
      {
        ValidateParam(item);
      }
      ValidateParam(m_SavingThrowType);
      ValidateParam(SpellDescriptor);
      ValidateParam(ModifierDescriptor);
      ValidateParam(Value);
      
      var component =  new ModifyD20();
      component.Rule = Rule;
      component.DispellMagicCheckType = DispellMagicCheckType;
      component.Replace = Replace;
      component.RollsAmount = RollsAmount;
      component.TakeBest = TakeBest;
      component.Roll = Roll;
      component.AddBonus = AddBonus;
      component.Bonus = Bonus;
      component.BonusDescriptor = BonusDescriptor;
      component.WithChance = WithChance;
      component.Chance = Chance;
      component.RerollOnlyIfFailed = RerollOnlyIfFailed;
      component.DispellOnRerollFinished = DispellOnRerollFinished;
      component.DispellOn20 = DispellOn20;
      component.AgainstAlignment = AgainstAlignment;
      component.Alignment = Alignment;
      component.TargetAlignment = TargetAlignment;
      component.SpecificSkill = SpecificSkill;
      component.Skill = Skill;
      component.m_SavingThrowType = m_SavingThrowType;
      component.SpecificDescriptor = SpecificDescriptor;
      component.SpellDescriptor = SpellDescriptor;
      component.AddSavingThrowBonus = AddSavingThrowBonus;
      component.ModifierDescriptor = ModifierDescriptor;
      component.Value = Value;
      component.TandemTrip = TandemTrip;
      component.m_TandemTripFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(m_TandemTripFeature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MonkReplaceAbilityDC"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Ability"><see cref="BlueprintAbility"/></param>
    /// <param name="m_ScaledFist"><see cref="BlueprintArchetype"/></param>
    /// <param name="m_Monk"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(MonkReplaceAbilityDC))]
    public UnitConfigurator AddMonkReplaceAbilityDC(
        string m_Ability,
        string m_ScaledFist,
        string m_Monk)
    {
      
      var component =  new MonkReplaceAbilityDC();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(m_Ability);
      component.m_ScaledFist = BlueprintTool.GetRef<BlueprintArchetypeReference>(m_ScaledFist);
      component.m_Monk = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_Monk);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MountedCombat"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CooldownBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(MountedCombat))]
    public UnitConfigurator AddMountedCombat(
        string m_CooldownBuff)
    {
      
      var component =  new MountedCombat();
      component.m_CooldownBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_CooldownBuff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MythicUnarmedStrike"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MythicUnarmedStrike))]
    public UnitConfigurator AddMythicUnarmedStrike()
    {
      return AddComponent(new MythicUnarmedStrike());
    }

    /// <summary>
    /// Adds <see cref="NeutralToFaction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Faction"><see cref="BlueprintFaction"/></param>
    [Generated]
    [Implements(typeof(NeutralToFaction))]
    public UnitConfigurator AddNeutralToFaction(
        string m_Faction)
    {
      
      var component =  new NeutralToFaction();
      component.m_Faction = BlueprintTool.GetRef<BlueprintFactionReference>(m_Faction);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="NewRoundTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(NewRoundTrigger))]
    public UnitConfigurator AddNewRoundTrigger(
        ActionsBuilder NewRoundActions)
    {
      
      var component =  new NewRoundTrigger();
      component.NewRoundActions = NewRoundActions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OnSpawnBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_IfHaveFact"><see cref="BlueprintFeature"/></param>
    /// <param name="m_IfSummonHaveFact"><see cref="BlueprintFeature"/></param>
    /// <param name="m_buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(OnSpawnBuff))]
    public UnitConfigurator AddOnSpawnBuff(
        string m_IfHaveFact,
        bool CheckSummonedUnitFact,
        string m_IfSummonHaveFact,
        bool CheckSummonedUnitAlignment,
        AlignmentComponent SummonedAlignment,
        string m_buff,
        bool CheckDescriptor,
        SpellDescriptorWrapper SpellDescriptor,
        bool IsInfinity,
        Rounds duration)
    {
      ValidateParam(SummonedAlignment);
      ValidateParam(SpellDescriptor);
      ValidateParam(duration);
      
      var component =  new OnSpawnBuff();
      component.m_IfHaveFact = BlueprintTool.GetRef<BlueprintFeatureReference>(m_IfHaveFact);
      component.CheckSummonedUnitFact = CheckSummonedUnitFact;
      component.m_IfSummonHaveFact = BlueprintTool.GetRef<BlueprintFeatureReference>(m_IfSummonHaveFact);
      component.CheckSummonedUnitAlignment = CheckSummonedUnitAlignment;
      component.SummonedAlignment = SummonedAlignment;
      component.m_buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_buff);
      component.CheckDescriptor = CheckDescriptor;
      component.SpellDescriptor = SpellDescriptor;
      component.IsInfinity = IsInfinity;
      component.duration = duration;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Opportunist"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Opportunist))]
    public UnitConfigurator AddOpportunist()
    {
      return AddComponent(new Opportunist());
    }

    /// <summary>
    /// Adds <see cref="OutflankAttackBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_OutflankFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(OutflankAttackBonus))]
    public UnitConfigurator AddOutflankAttackBonus(
        int AttackBonus,
        ModifierDescriptor Descriptor,
        string m_OutflankFact)
    {
      ValidateParam(Descriptor);
      
      var component =  new OutflankAttackBonus();
      component.AttackBonus = AttackBonus;
      component.Descriptor = Descriptor;
      component.m_OutflankFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_OutflankFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OutflankDamageBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_OutflankFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(OutflankDamageBonus))]
    public UnitConfigurator AddOutflankDamageBonus(
        int DamageBonus,
        int IncreasedDamageBonus,
        string m_OutflankFact)
    {
      
      var component =  new OutflankDamageBonus();
      component.DamageBonus = DamageBonus;
      component.IncreasedDamageBonus = IncreasedDamageBonus;
      component.m_OutflankFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_OutflankFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OutflankProvokeAttack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_OutflankFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(OutflankProvokeAttack))]
    public UnitConfigurator AddOutflankProvokeAttack(
        string m_OutflankFact)
    {
      
      var component =  new OutflankProvokeAttack();
      component.m_OutflankFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_OutflankFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PartialDRIgnore"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PartialDRIgnore))]
    public UnitConfigurator AddPartialDRIgnore(
        int ReductionReduction)
    {
      
      var component =  new PartialDRIgnore();
      component.ReductionReduction = ReductionReduction;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PenetratingStrike"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PenetratingStrike))]
    public UnitConfigurator AddPenetratingStrike(
        int ReductionReduction)
    {
      
      var component =  new PenetratingStrike();
      component.ReductionReduction = ReductionReduction;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PetManeuverProvokeAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PetManeuverProvokeAttack))]
    public UnitConfigurator AddPetManeuverProvokeAttack(
        CombatManeuver[] Maneuver)
    {
      foreach (var item in Maneuver)
      {
        ValidateParam(item);
      }
      
      var component =  new PetManeuverProvokeAttack();
      component.Maneuver = Maneuver;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PointBlankMaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PointBlankMaster))]
    public UnitConfigurator AddPointBlankMaster(
        WeaponCategory Category)
    {
      ValidateParam(Category);
      
      var component =  new PointBlankMaster();
      component.Category = Category;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PointBlankMasterParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PointBlankMasterParametrized))]
    public UnitConfigurator AddPointBlankMasterParametrized()
    {
      return AddComponent(new PointBlankMasterParametrized());
    }

    /// <summary>
    /// Adds <see cref="PowerAttackWatcher"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_PowerAttackBlueprint"><see cref="BlueprintActivatableAbility"/></param>
    [Generated]
    [Implements(typeof(PowerAttackWatcher))]
    public UnitConfigurator AddPowerAttackWatcher(
        string m_PowerAttackBlueprint)
    {
      
      var component =  new PowerAttackWatcher();
      component.m_PowerAttackBlueprint = BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(m_PowerAttackBlueprint);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PreciseShot"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PreciseShot))]
    public UnitConfigurator AddPreciseShot()
    {
      return AddComponent(new PreciseShot());
    }

    /// <summary>
    /// Adds <see cref="PreciseShotDivineHunterTarget"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(PreciseShotDivineHunterTarget))]
    public UnitConfigurator AddPreciseShotDivineHunterTarget(
        string m_Buff)
    {
      
      var component =  new PreciseShotDivineHunterTarget();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PreciseStrike"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_PreciseStrikeFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(PreciseStrike))]
    public UnitConfigurator AddPreciseStrike(
        DamageDescription Damage,
        string m_PreciseStrikeFact)
    {
      ValidateParam(Damage);
      
      var component =  new PreciseStrike();
      component.Damage = Damage;
      component.m_PreciseStrikeFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_PreciseStrikeFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RangedWeaponSizeChange"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="WeaponTypes"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(RangedWeaponSizeChange))]
    public UnitConfigurator AddRangedWeaponSizeChange(
        int SizeCategoryChange,
        string[] WeaponTypes)
    {
      
      var component =  new RangedWeaponSizeChange();
      component.SizeCategoryChange = SizeCategoryChange;
      component.WeaponTypes = WeaponTypes.Select(bp => BlueprintTool.GetRef<BlueprintWeaponTypeReference>(bp)).ToList();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecalculateConcealment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecalculateConcealment))]
    public UnitConfigurator AddRecalculateConcealment(
        bool IgnorePartial,
        bool TreatTotalAsPartial)
    {
      
      var component =  new RecalculateConcealment();
      component.IgnorePartial = IgnorePartial;
      component.TreatTotalAsPartial = TreatTotalAsPartial;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecalculateOnFactsChange"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFacts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(RecalculateOnFactsChange))]
    public UnitConfigurator AddRecalculateOnFactsChange(
        string[] m_CheckedFacts)
    {
      
      var component =  new RecalculateOnFactsChange();
      component.m_CheckedFacts = m_CheckedFacts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecalculateOnLocustSwarmChange"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecalculateOnLocustSwarmChange))]
    public UnitConfigurator AddRecalculateOnLocustSwarmChange()
    {
      return AddComponent(new RecalculateOnLocustSwarmChange());
    }

    /// <summary>
    /// Adds <see cref="RecalculateOnStatChange"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecalculateOnStatChange))]
    public UnitConfigurator AddRecalculateOnStatChange(
        bool UseKineticistMainStat,
        StatType Stat)
    {
      ValidateParam(Stat);
      
      var component =  new RecalculateOnStatChange();
      component.UseKineticistMainStat = UseKineticistMainStat;
      component.Stat = Stat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendedClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_FavoriteClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(RecommendedClass))]
    public UnitConfigurator AddRecommendedClass(
        string m_FavoriteClass)
    {
      
      var component =  new RecommendedClass();
      component.m_FavoriteClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_FavoriteClass);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RemoveAfterCast"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="Abilities"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(RemoveAfterCast))]
    public UnitConfigurator AddRemoveAfterCast(
        string[] Abilities)
    {
      
      var component =  new RemoveAfterCast();
      component.Abilities = Abilities.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToList();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RemoveBuffOnAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemoveBuffOnAttack))]
    public UnitConfigurator AddRemoveBuffOnAttack()
    {
      return AddComponent(new RemoveBuffOnAttack());
    }

    /// <summary>
    /// Adds <see cref="RemoveFeatureOnApply"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Feature"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(RemoveFeatureOnApply))]
    public UnitConfigurator AddRemoveFeatureOnApply(
        string m_Feature)
    {
      
      var component =  new RemoveFeatureOnApply();
      component.m_Feature = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_Feature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RendFeature"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RendFeature))]
    public UnitConfigurator AddRendFeature(
        DiceFormula RendDamage,
        DamageTypeDescription RendType)
    {
      ValidateParam(RendDamage);
      ValidateParam(RendType);
      
      var component =  new RendFeature();
      component.RendDamage = RendDamage;
      component.RendType = RendType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceAbilitiesStat"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Ability"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(ReplaceAbilitiesStat))]
    public UnitConfigurator AddReplaceAbilitiesStat(
        string[] m_Ability,
        StatType Stat)
    {
      ValidateParam(Stat);
      
      var component =  new ReplaceAbilitiesStat();
      component.m_Ability = m_Ability.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      component.Stat = Stat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceAbilityDC"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Ability"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(ReplaceAbilityDC))]
    public UnitConfigurator AddReplaceAbilityDC(
        string m_Ability,
        StatType Stat)
    {
      ValidateParam(Stat);
      
      var component =  new ReplaceAbilityDC();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(m_Ability);
      component.Stat = Stat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceAbilityParamsWithContext"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Ability"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(ReplaceAbilityParamsWithContext))]
    public UnitConfigurator AddReplaceAbilityParamsWithContext(
        string m_Ability)
    {
      
      var component =  new ReplaceAbilityParamsWithContext();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(m_Ability);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceCMDDexterityStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ReplaceCMDDexterityStat))]
    public UnitConfigurator AddReplaceCMDDexterityStat(
        StatType NewStat)
    {
      ValidateParam(NewStat);
      
      var component =  new ReplaceCMDDexterityStat();
      component.NewStat = NewStat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceCastSource"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ReplaceCastSource))]
    public UnitConfigurator AddReplaceCastSource(
        CastSource CastSource)
    {
      ValidateParam(CastSource);
      
      var component =  new ReplaceCastSource();
      component.CastSource = CastSource;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceCasterLevelOfAbility"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spell"><see cref="BlueprintAbility"/></param>
    /// <param name="m_Class"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_AdditionalClasses"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_Archetypes"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(ReplaceCasterLevelOfAbility))]
    public UnitConfigurator AddReplaceCasterLevelOfAbility(
        string m_Spell,
        string m_Class,
        string[] m_AdditionalClasses,
        string[] m_Archetypes)
    {
      
      var component =  new ReplaceCasterLevelOfAbility();
      component.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(m_Spell);
      component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_Class);
      component.m_AdditionalClasses = m_AdditionalClasses.Select(bp => BlueprintTool.GetRef<BlueprintCharacterClassReference>(bp)).ToArray();
      component.m_Archetypes = m_Archetypes.Select(bp => BlueprintTool.GetRef<BlueprintArchetypeReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceCasterLevelOfFeature"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Feature"><see cref="BlueprintFeature"/></param>
    /// <param name="m_Class"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(ReplaceCasterLevelOfFeature))]
    public UnitConfigurator AddReplaceCasterLevelOfFeature(
        string m_Feature,
        string m_Class)
    {
      
      var component =  new ReplaceCasterLevelOfFeature();
      component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(m_Feature);
      component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_Class);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceCombatManeuverStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ReplaceCombatManeuverStat))]
    public UnitConfigurator AddReplaceCombatManeuverStat(
        StatType StatType)
    {
      ValidateParam(StatType);
      
      var component =  new ReplaceCombatManeuverStat();
      component.StatType = StatType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceSingleCombatManeuverStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ReplaceSingleCombatManeuverStat))]
    public UnitConfigurator AddReplaceSingleCombatManeuverStat(
        CombatManeuver Type,
        StatType StatType)
    {
      ValidateParam(Type);
      ValidateParam(StatType);
      
      var component =  new ReplaceSingleCombatManeuverStat();
      component.Type = Type;
      component.StatType = StatType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceSourceBone"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ReplaceSourceBone))]
    public UnitConfigurator AddReplaceSourceBone(
        string SourceBone)
    {
      
      var component =  new ReplaceSourceBone();
      component.SourceBone = SourceBone;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceStatForPrerequisites"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CharacterClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(ReplaceStatForPrerequisites))]
    public UnitConfigurator AddReplaceStatForPrerequisites(
        StatType OldStat,
        ReplaceStatForPrerequisites.StatReplacementPolicy Policy,
        StatType NewStat,
        string m_CharacterClass,
        int SpecificNumber)
    {
      ValidateParam(OldStat);
      ValidateParam(Policy);
      ValidateParam(NewStat);
      
      var component =  new ReplaceStatForPrerequisites();
      component.OldStat = OldStat;
      component.Policy = Policy;
      component.NewStat = NewStat;
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_CharacterClass);
      component.SpecificNumber = SpecificNumber;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RerollConcealment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RerollConcealment))]
    public UnitConfigurator AddRerollConcealment()
    {
      return AddComponent(new RerollConcealment());
    }

    /// <summary>
    /// Adds <see cref="RideAnimalCompanion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RideAnimalCompanion))]
    public UnitConfigurator AddRideAnimalCompanion()
    {
      return AddComponent(new RideAnimalCompanion());
    }

    /// <summary>
    /// Adds <see cref="SaturationAuraComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SaturationAuraComponent))]
    public UnitConfigurator AddSaturationAuraComponent(
        SaturationAuraType m_SaturationAuraType,
        float m_Radius,
        float m_DistanceToCamera)
    {
      ValidateParam(m_SaturationAuraType);
      
      var component =  new SaturationAuraComponent();
      component.m_SaturationAuraType = m_SaturationAuraType;
      component.m_Radius = m_Radius;
      component.m_DistanceToCamera = m_DistanceToCamera;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavesFixedRecalculateThievery"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavesFixedRecalculateThievery))]
    public UnitConfigurator AddSavesFixedRecalculateThievery()
    {
      return AddComponent(new SavesFixedRecalculateThievery());
    }

    /// <summary>
    /// Adds <see cref="SavesFixerFactReplacer"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_OldFacts"><see cref="BlueprintUnitFact"/></param>
    /// <param name="m_NewFacts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SavesFixerFactReplacer))]
    public UnitConfigurator AddSavesFixerFactReplacer(
        string[] m_OldFacts,
        string[] m_NewFacts)
    {
      
      var component =  new SavesFixerFactReplacer();
      component.m_OldFacts = m_OldFacts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      component.m_NewFacts = m_NewFacts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavesFixerParamSpellSchool"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavesFixerParamSpellSchool))]
    public UnitConfigurator AddSavesFixerParamSpellSchool()
    {
      return AddComponent(new SavesFixerParamSpellSchool());
    }

    /// <summary>
    /// Adds <see cref="SavesFixerRecalculate"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavesFixerRecalculate))]
    public UnitConfigurator AddSavesFixerRecalculate(
        int Version)
    {
      
      var component =  new SavesFixerRecalculate();
      component.Version = Version;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavesFixerReplaceInProgression"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_OldFeature"><see cref="BlueprintFeature"/></param>
    /// <param name="m_NewFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(SavesFixerReplaceInProgression))]
    public UnitConfigurator AddSavesFixerReplaceInProgression(
        string m_OldFeature,
        string m_NewFeature)
    {
      
      var component =  new SavesFixerReplaceInProgression();
      component.m_OldFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(m_OldFeature);
      component.m_NewFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(m_NewFeature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingSlash"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavingSlash))]
    public UnitConfigurator AddSavingSlash(
        bool UseContextValue,
        int Bonus,
        ContextValue Value,
        WeaponCategory Weapon)
    {
      ValidateParam(Value);
      ValidateParam(Weapon);
      
      var component =  new SavingSlash();
      component.UseContextValue = UseContextValue;
      component.Bonus = Bonus;
      component.Value = Value;
      component.Weapon = Weapon;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstAbilityType"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstAbilityType))]
    public UnitConfigurator AddSavingThrowBonusAgainstAbilityType(
        AbilityType AbilityType,
        ModifierDescriptor ModifierDescriptor,
        int Value,
        ContextValue Bonus,
        bool OnlyPositiveValue)
    {
      ValidateParam(AbilityType);
      ValidateParam(ModifierDescriptor);
      ValidateParam(Bonus);
      
      var component =  new SavingThrowBonusAgainstAbilityType();
      component.AbilityType = AbilityType;
      component.ModifierDescriptor = ModifierDescriptor;
      component.Value = Value;
      component.Bonus = Bonus;
      component.OnlyPositiveValue = OnlyPositiveValue;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstAlignment))]
    public UnitConfigurator AddSavingThrowBonusAgainstAlignment(
        AlignmentComponent Alignment,
        ModifierDescriptor Descriptor,
        int Value,
        ContextValue Bonus)
    {
      ValidateParam(Alignment);
      ValidateParam(Descriptor);
      ValidateParam(Bonus);
      
      var component =  new SavingThrowBonusAgainstAlignment();
      component.Alignment = Alignment;
      component.Descriptor = Descriptor;
      component.Value = Value;
      component.Bonus = Bonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstAlignmentDifference"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstAlignmentDifference))]
    public UnitConfigurator AddSavingThrowBonusAgainstAlignmentDifference(
        ModifierDescriptor Descriptor,
        int Value,
        int AlignmentDifference,
        SavingThrowType SavingThrow)
    {
      ValidateParam(Descriptor);
      ValidateParam(SavingThrow);
      
      var component =  new SavingThrowBonusAgainstAlignmentDifference();
      component.Descriptor = Descriptor;
      component.Value = Value;
      component.AlignmentDifference = AlignmentDifference;
      component.SavingThrow = SavingThrow;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstAllies"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_DisablingFeature"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstAllies))]
    public UnitConfigurator AddSavingThrowBonusAgainstAllies(
        ModifierDescriptor ModifierDescriptor,
        int Value,
        ContextValue Bonus,
        bool OnlyPositiveValue,
        string m_DisablingFeature)
    {
      ValidateParam(ModifierDescriptor);
      ValidateParam(Bonus);
      
      var component =  new SavingThrowBonusAgainstAllies();
      component.ModifierDescriptor = ModifierDescriptor;
      component.Value = Value;
      component.Bonus = Bonus;
      component.OnlyPositiveValue = OnlyPositiveValue;
      component.m_DisablingFeature = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_DisablingFeature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstDescriptor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_DisablingFeature"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstDescriptor))]
    public UnitConfigurator AddSavingThrowBonusAgainstDescriptor(
        SpellDescriptorWrapper SpellDescriptor,
        ModifierDescriptor ModifierDescriptor,
        int Value,
        ContextValue Bonus,
        bool OnlyPositiveValue,
        string m_DisablingFeature)
    {
      ValidateParam(SpellDescriptor);
      ValidateParam(ModifierDescriptor);
      ValidateParam(Bonus);
      
      var component =  new SavingThrowBonusAgainstDescriptor();
      component.SpellDescriptor = SpellDescriptor;
      component.ModifierDescriptor = ModifierDescriptor;
      component.Value = Value;
      component.Bonus = Bonus;
      component.OnlyPositiveValue = OnlyPositiveValue;
      component.m_DisablingFeature = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_DisablingFeature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFact"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstFact))]
    public UnitConfigurator AddSavingThrowBonusAgainstFact(
        string m_CheckedFact,
        ModifierDescriptor Descriptor,
        int Value,
        AlignmentComponent Alignment)
    {
      ValidateParam(Descriptor);
      ValidateParam(Alignment);
      
      var component =  new SavingThrowBonusAgainstFact();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintFeatureReference>(m_CheckedFact);
      component.Descriptor = Descriptor;
      component.Value = Value;
      component.Alignment = Alignment;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstFactMultiple"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstFactMultiple))]
    public UnitConfigurator AddSavingThrowBonusAgainstFactMultiple(
        string[] m_Facts,
        ModifierDescriptor Descriptor,
        int Value,
        AlignmentComponent Alignment)
    {
      ValidateParam(Descriptor);
      ValidateParam(Alignment);
      
      var component =  new SavingThrowBonusAgainstFactMultiple();
      component.m_Facts = m_Facts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      component.Descriptor = Descriptor;
      component.Value = Value;
      component.Alignment = Alignment;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstSchool"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstSchool))]
    public UnitConfigurator AddSavingThrowBonusAgainstSchool(
        SpellSchool School,
        ModifierDescriptor ModifierDescriptor,
        int Value)
    {
      ValidateParam(School);
      ValidateParam(ModifierDescriptor);
      
      var component =  new SavingThrowBonusAgainstSchool();
      component.School = School;
      component.ModifierDescriptor = ModifierDescriptor;
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstSchoolAbilityValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstSchoolAbilityValue))]
    public UnitConfigurator AddSavingThrowBonusAgainstSchoolAbilityValue(
        SpellSchool School,
        ModifierDescriptor ModifierDescriptor,
        int Value,
        ContextValue Bonus)
    {
      ValidateParam(School);
      ValidateParam(ModifierDescriptor);
      ValidateParam(Bonus);
      
      var component =  new SavingThrowBonusAgainstSchoolAbilityValue();
      component.School = School;
      component.ModifierDescriptor = ModifierDescriptor;
      component.Value = Value;
      component.Bonus = Bonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstSpecificSpells"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spells"><see cref="BlueprintAbility"/></param>
    /// <param name="m_BypassFeatures"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstSpecificSpells))]
    public UnitConfigurator AddSavingThrowBonusAgainstSpecificSpells(
        string[] m_Spells,
        ModifierDescriptor ModifierDescriptor,
        int Value,
        string[] m_BypassFeatures)
    {
      ValidateParam(ModifierDescriptor);
      
      var component =  new SavingThrowBonusAgainstSpecificSpells();
      component.m_Spells = m_Spells.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      component.ModifierDescriptor = ModifierDescriptor;
      component.Value = Value;
      component.m_BypassFeatures = m_BypassFeatures.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstSpellType"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstSpellType))]
    public UnitConfigurator AddSavingThrowBonusAgainstSpellType(
        bool AgainstArcaneSpells,
        ModifierDescriptor ModifierDescriptor,
        int Value,
        ContextValue Bonus,
        bool OnlyPositiveValue)
    {
      ValidateParam(ModifierDescriptor);
      ValidateParam(Bonus);
      
      var component =  new SavingThrowBonusAgainstSpellType();
      component.AgainstArcaneSpells = AgainstArcaneSpells;
      component.ModifierDescriptor = ModifierDescriptor;
      component.Value = Value;
      component.Bonus = Bonus;
      component.OnlyPositiveValue = OnlyPositiveValue;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusUnlessFactMultiple"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SavingThrowBonusUnlessFactMultiple))]
    public UnitConfigurator AddSavingThrowBonusUnlessFactMultiple(
        string[] m_Facts,
        ModifierDescriptor Descriptor,
        AlignmentComponent Alignment,
        SavingThrowType Type,
        int Value)
    {
      ValidateParam(Descriptor);
      ValidateParam(Alignment);
      ValidateParam(Type);
      
      var component =  new SavingThrowBonusUnlessFactMultiple();
      component.m_Facts = m_Facts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      component.Descriptor = Descriptor;
      component.Alignment = Alignment;
      component.Type = Type;
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowContextBonusAgainstDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavingThrowContextBonusAgainstDescriptor))]
    public UnitConfigurator AddSavingThrowContextBonusAgainstDescriptor(
        SpellDescriptorWrapper SpellDescriptor,
        ModifierDescriptor ModifierDescriptor,
        ContextValue Value)
    {
      ValidateParam(SpellDescriptor);
      ValidateParam(ModifierDescriptor);
      ValidateParam(Value);
      
      var component =  new SavingThrowContextBonusAgainstDescriptor();
      component.SpellDescriptor = SpellDescriptor;
      component.ModifierDescriptor = ModifierDescriptor;
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SchoolMasteryParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SchoolMasteryParametrized))]
    public UnitConfigurator AddSchoolMasteryParametrized()
    {
      return AddComponent(new SchoolMasteryParametrized());
    }

    /// <summary>
    /// Adds <see cref="ShakeItOff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_ShakeItOffFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ShakeItOff))]
    public UnitConfigurator AddShakeItOff(
        string m_ShakeItOffFact,
        int Radius)
    {
      
      var component =  new ShakeItOff();
      component.m_ShakeItOffFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_ShakeItOffFact);
      component.Radius = Radius;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShareBuffsWithPet"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buffs"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(ShareBuffsWithPet))]
    public UnitConfigurator AddShareBuffsWithPet(
        PetType Type,
        string[] m_Buffs)
    {
      ValidateParam(Type);
      
      var component =  new ShareBuffsWithPet();
      component.Type = Type;
      component.m_Buffs = m_Buffs.Select(bp => BlueprintTool.GetRef<BlueprintBuffReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShareFavoredEnemies"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ShareFavoredEnemies))]
    public UnitConfigurator AddShareFavoredEnemies(
        bool Half,
        bool ToPet)
    {
      
      var component =  new ShareFavoredEnemies();
      component.Half = Half;
      component.ToPet = ToPet;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShareFeaturesWithPet"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Features"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(ShareFeaturesWithPet))]
    public UnitConfigurator AddShareFeaturesWithPet(
        PetType Type,
        string[] m_Features)
    {
      ValidateParam(Type);
      
      var component =  new ShareFeaturesWithPet();
      component.Type = Type;
      component.m_Features = m_Features.Select(bp => BlueprintTool.GetRef<BlueprintFeatureReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShatterConfidence"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_ConfoundingDuelistFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(ShatterConfidence))]
    public UnitConfigurator AddShatterConfidence(
        string m_ConfoundingDuelistFeature)
    {
      
      var component =  new ShatterConfidence();
      component.m_ConfoundingDuelistFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(m_ConfoundingDuelistFeature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShieldWall"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_ShieldWallFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ShieldWall))]
    public UnitConfigurator AddShieldWall(
        string m_ShieldWallFact,
        int Radius)
    {
      
      var component =  new ShieldWall();
      component.m_ShieldWallFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_ShieldWallFact);
      component.Radius = Radius;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShieldedCaster"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_ShieldedCasterFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ShieldedCaster))]
    public UnitConfigurator AddShieldedCaster(
        string m_ShieldedCasterFact,
        int Radius)
    {
      
      var component =  new ShieldedCaster();
      component.m_ShieldedCasterFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_ShieldedCasterFact);
      component.Radius = Radius;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SiezeTheMoment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_SiezeTheMomentFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SiezeTheMoment))]
    public UnitConfigurator AddSiezeTheMoment(
        string m_SiezeTheMomentFact)
    {
      
      var component =  new SiezeTheMoment();
      component.m_SiezeTheMomentFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_SiezeTheMomentFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpecificSpellDamageBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spell"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(SpecificSpellDamageBonus))]
    public UnitConfigurator AddSpecificSpellDamageBonus(
        string[] m_Spell,
        int Bonus)
    {
      
      var component =  new SpecificSpellDamageBonus();
      component.m_Spell = m_Spell.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      component.Bonus = Bonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellFixedCL"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Ability"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(SpellFixedCL))]
    public UnitConfigurator AddSpellFixedCL(
        string m_Ability,
        int CL)
    {
      
      var component =  new SpellFixedCL();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(m_Ability);
      component.CL = CL;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellFixedDC"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Ability"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(SpellFixedDC))]
    public UnitConfigurator AddSpellFixedDC(
        string m_Ability,
        int DC)
    {
      
      var component =  new SpellFixedDC();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(m_Ability);
      component.DC = DC;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellFocusParametrized"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_MythicFocus"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SpellFocusParametrized))]
    public UnitConfigurator AddSpellFocusParametrized(
        int BonusDC,
        ModifierDescriptor Descriptor,
        string m_MythicFocus,
        bool SpellsOnly)
    {
      ValidateParam(Descriptor);
      
      var component =  new SpellFocusParametrized();
      component.BonusDC = BonusDC;
      component.Descriptor = Descriptor;
      component.m_MythicFocus = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_MythicFocus);
      component.SpellsOnly = SpellsOnly;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellLevelByClassLevel"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Ability"><see cref="BlueprintAbility"/></param>
    /// <param name="m_Class"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(SpellLevelByClassLevel))]
    public UnitConfigurator AddSpellLevelByClassLevel(
        string m_Ability,
        string m_Class)
    {
      
      var component =  new SpellLevelByClassLevel();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(m_Ability);
      component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_Class);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellLevelByRank"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Ability"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(SpellLevelByRank))]
    public UnitConfigurator AddSpellLevelByRank(
        string m_Ability)
    {
      
      var component =  new SpellLevelByRank();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(m_Ability);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellPenetrationBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_RequiredFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SpellPenetrationBonus))]
    public UnitConfigurator AddSpellPenetrationBonus(
        ContextValue Value,
        ModifierDescriptor Descriptor,
        bool CheckFact,
        string m_RequiredFact)
    {
      ValidateParam(Value);
      ValidateParam(Descriptor);
      
      var component =  new SpellPenetrationBonus();
      component.Value = Value;
      component.Descriptor = Descriptor;
      component.CheckFact = CheckFact;
      component.m_RequiredFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_RequiredFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellPenetrationMythicBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Greater"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SpellPenetrationMythicBonus))]
    public UnitConfigurator AddSpellPenetrationMythicBonus(
        string m_Greater)
    {
      
      var component =  new SpellPenetrationMythicBonus();
      component.m_Greater = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_Greater);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellSpecializationParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpellSpecializationParametrized))]
    public UnitConfigurator AddSpellSpecializationParametrized()
    {
      return AddComponent(new SpellSpecializationParametrized());
    }

    /// <summary>
    /// Adds <see cref="SpendChargesOnSpellCast"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spell"><see cref="BlueprintAbility"/></param>
    /// <param name="m_SpendSpellCharges"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(SpendChargesOnSpellCast))]
    public UnitConfigurator AddSpendChargesOnSpellCast(
        string m_Spell,
        string m_SpendSpellCharges)
    {
      
      var component =  new SpendChargesOnSpellCast();
      component.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(m_Spell);
      component.m_SpendSpellCharges = BlueprintTool.GetRef<BlueprintAbilityReference>(m_SpendSpellCharges);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SurpriseSpells"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SurpriseSpells))]
    public UnitConfigurator AddSurpriseSpells()
    {
      return AddComponent(new SurpriseSpells());
    }

    /// <summary>
    /// Adds <see cref="Take10ForSuccess"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Take10ForSuccess))]
    public UnitConfigurator AddTake10ForSuccess(
        StatType Skill,
        bool AnyType,
        UsableItemType MagicDeviceType)
    {
      ValidateParam(Skill);
      ValidateParam(MagicDeviceType);
      
      var component =  new Take10ForSuccess();
      component.Skill = Skill;
      component.AnyType = AnyType;
      component.MagicDeviceType = MagicDeviceType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TargetChangedDuringRound"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TargetChangedDuringRound))]
    public UnitConfigurator AddTargetChangedDuringRound(
        ActionsBuilder Actions)
    {
      
      var component =  new TargetChangedDuringRound();
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TargetCritAutoconfirm"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TargetCritAutoconfirm))]
    public UnitConfigurator AddTargetCritAutoconfirm()
    {
      return AddComponent(new TargetCritAutoconfirm());
    }

    /// <summary>
    /// Adds <see cref="TargetCritAutoconfirmFromCaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TargetCritAutoconfirmFromCaster))]
    public UnitConfigurator AddTargetCritAutoconfirmFromCaster()
    {
      return AddComponent(new TargetCritAutoconfirmFromCaster());
    }

    /// <summary>
    /// Adds <see cref="TellingBlow"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    /// <param name="m_ImmunityFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(TellingBlow))]
    public UnitConfigurator AddTellingBlow(
        int ReductionReduction,
        string m_Buff,
        string m_ImmunityFact)
    {
      
      var component =  new TellingBlow();
      component.ReductionReduction = ReductionReduction;
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      component.m_ImmunityFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_ImmunityFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ToughnessLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ToughnessLogic))]
    public UnitConfigurator AddToughnessLogic(
        bool CheckMythicLevel)
    {
      
      var component =  new ToughnessLogic();
      component.CheckMythicLevel = CheckMythicLevel;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TransferDescriptorBonusToSavingThrow"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TransferDescriptorBonusToSavingThrow))]
    public UnitConfigurator AddTransferDescriptorBonusToSavingThrow(
        ModifierDescriptor Descriptor,
        int MaxBonus,
        bool CheckArmorCategory,
        ArmorProficiencyGroup Category,
        SavingThrowType Type)
    {
      ValidateParam(Descriptor);
      ValidateParam(Category);
      ValidateParam(Type);
      
      var component =  new TransferDescriptorBonusToSavingThrow();
      component.Descriptor = Descriptor;
      component.MaxBonus = MaxBonus;
      component.CheckArmorCategory = CheckArmorCategory;
      component.Category = Category;
      component.Type = Type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TransferDescriptorBonusToTouchAC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TransferDescriptorBonusToTouchAC))]
    public UnitConfigurator AddTransferDescriptorBonusToTouchAC(
        ModifierDescriptor Descriptor,
        int MaxBonus,
        bool CheckArmorCategory,
        ArmorProficiencyGroup Category)
    {
      ValidateParam(Descriptor);
      ValidateParam(Category);
      
      var component =  new TransferDescriptorBonusToTouchAC();
      component.Descriptor = Descriptor;
      component.MaxBonus = MaxBonus;
      component.CheckArmorCategory = CheckArmorCategory;
      component.Category = Category;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TrapPerceptionBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TrapPerceptionBonus))]
    public UnitConfigurator AddTrapPerceptionBonus(
        ModifierDescriptor Descriptor,
        ContextValue Value)
    {
      ValidateParam(Descriptor);
      ValidateParam(Value);
      
      var component =  new TrapPerceptionBonus();
      component.Descriptor = Descriptor;
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TricksterArcanaAdditionalEnchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="CommonEnchantments"><see cref="BlueprintItemEnchantment"/></param>
    /// <param name="WeaponEnchantments"><see cref="BlueprintWeaponEnchantment"/></param>
    /// <param name="ArmorEnchantments"><see cref="BlueprintArmorEnchantment"/></param>
    [Generated]
    [Implements(typeof(TricksterArcanaAdditionalEnchantments))]
    public UnitConfigurator AddTricksterArcanaAdditionalEnchantments(
        string[] CommonEnchantments,
        string[] WeaponEnchantments,
        string[] ArmorEnchantments,
        bool OnlyWeaponsShieldsAndArmor)
    {
      
      var component =  new TricksterArcanaAdditionalEnchantments();
      component.CommonEnchantments = CommonEnchantments.Select(bp => BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(bp)).ToArray();
      component.WeaponEnchantments = WeaponEnchantments.Select(bp => BlueprintTool.GetRef<BlueprintWeaponEnchantmentReference>(bp)).ToArray();
      component.ArmorEnchantments = ArmorEnchantments.Select(bp => BlueprintTool.GetRef<BlueprintArmorEnchantmentReference>(bp)).ToArray();
      component.OnlyWeaponsShieldsAndArmor = OnlyWeaponsShieldsAndArmor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TricksterArcanaBetterEnhancements"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="EnhancementEnchantments"><see cref="BlueprintItemEnchantment"/></param>
    /// <param name="BestEnchantments"><see cref="BlueprintItemEnchantment"/></param>
    [Generated]
    [Implements(typeof(TricksterArcanaBetterEnhancements))]
    public UnitConfigurator AddTricksterArcanaBetterEnhancements(
        string[] EnhancementEnchantments,
        string[] BestEnchantments)
    {
      
      var component =  new TricksterArcanaBetterEnhancements();
      component.EnhancementEnchantments = EnhancementEnchantments.Select(bp => BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(bp)).ToArray();
      component.BestEnchantments = BestEnchantments.Select(bp => BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(bp)).ToList();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TricksterKnowledgeWorldD20"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TricksterKnowledgeWorldD20))]
    public UnitConfigurator AddTricksterKnowledgeWorldD20()
    {
      return AddComponent(new TricksterKnowledgeWorldD20());
    }

    /// <summary>
    /// Adds <see cref="TricksterKnowledgeWorldSkillBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TricksterKnowledgeWorldSkillBonus))]
    public UnitConfigurator AddTricksterKnowledgeWorldSkillBonus()
    {
      return AddComponent(new TricksterKnowledgeWorldSkillBonus());
    }

    /// <summary>
    /// Adds <see cref="TricksterLoreNatureRestTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="Tier1Buffs"><see cref="BlueprintBuff"/></param>
    /// <param name="Tier2Buffs"><see cref="BlueprintBuff"/></param>
    /// <param name="Tier3Buffs"><see cref="BlueprintBuff"/></param>
    /// <param name="m_Tier2Feature"><see cref="BlueprintFeature"/></param>
    /// <param name="m_Tier3Feature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(TricksterLoreNatureRestTrigger))]
    public UnitConfigurator AddTricksterLoreNatureRestTrigger(
        string[] Tier1Buffs,
        string[] Tier2Buffs,
        string[] Tier3Buffs,
        string m_Tier2Feature,
        string m_Tier3Feature)
    {
      
      var component =  new TricksterLoreNatureRestTrigger();
      component.Tier1Buffs = Tier1Buffs.Select(bp => BlueprintTool.GetRef<BlueprintBuffReference>(bp)).ToArray();
      component.Tier2Buffs = Tier2Buffs.Select(bp => BlueprintTool.GetRef<BlueprintBuffReference>(bp)).ToArray();
      component.Tier3Buffs = Tier3Buffs.Select(bp => BlueprintTool.GetRef<BlueprintBuffReference>(bp)).ToArray();
      component.m_Tier2Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(m_Tier2Feature);
      component.m_Tier3Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(m_Tier3Feature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TwoWeaponDefense"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TwoWeaponDefense))]
    public UnitConfigurator AddTwoWeaponDefense()
    {
      return AddComponent(new TwoWeaponDefense());
    }

    /// <summary>
    /// Adds <see cref="TwoWeaponFightingAttackPenalty"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_MythicBlueprint"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(TwoWeaponFightingAttackPenalty))]
    public UnitConfigurator AddTwoWeaponFightingAttackPenalty(
        string m_MythicBlueprint)
    {
      
      var component =  new TwoWeaponFightingAttackPenalty();
      component.m_MythicBlueprint = BlueprintTool.GetRef<BlueprintFeatureReference>(m_MythicBlueprint);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TwoWeaponFightingAttacks"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TwoWeaponFightingAttacks))]
    public UnitConfigurator AddTwoWeaponFightingAttacks()
    {
      return AddComponent(new TwoWeaponFightingAttacks());
    }

    /// <summary>
    /// Adds <see cref="TwoWeaponFightingDamagePenalty"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TwoWeaponFightingDamagePenalty))]
    public UnitConfigurator AddTwoWeaponFightingDamagePenalty()
    {
      return AddComponent(new TwoWeaponFightingDamagePenalty());
    }

    /// <summary>
    /// Adds <see cref="UndeadHealth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UndeadHealth))]
    public UnitConfigurator AddUndeadHealth()
    {
      return AddComponent(new UndeadHealth());
    }

    /// <summary>
    /// Adds <see cref="UnitDeathTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitDeathTrigger))]
    public UnitConfigurator AddUnitDeathTrigger(
        ContextValue RadiusInMeters,
        UnitDeathTrigger.FactionType Faction,
        ActionsBuilder Actions)
    {
      ValidateParam(RadiusInMeters);
      ValidateParam(Faction);
      
      var component =  new UnitDeathTrigger();
      component.RadiusInMeters = RadiusInMeters;
      component.Faction = Faction;
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UnwillingShield"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_MasterAbility"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(UnwillingShield))]
    public UnitConfigurator AddUnwillingShield(
        string m_MasterAbility)
    {
      
      var component =  new UnwillingShield();
      component.m_MasterAbility = BlueprintTool.GetRef<BlueprintAbilityReference>(m_MasterAbility);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UnwillingShieldTarget"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_MasterAbility"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(UnwillingShieldTarget))]
    public UnitConfigurator AddUnwillingShieldTarget(
        string m_MasterAbility)
    {
      
      var component =  new UnwillingShieldTarget();
      component.m_MasterAbility = BlueprintTool.GetRef<BlueprintAbilityReference>(m_MasterAbility);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="VolleyFireAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(VolleyFireAttackBonus))]
    public UnitConfigurator AddVolleyFireAttackBonus()
    {
      return AddComponent(new VolleyFireAttackBonus());
    }

    /// <summary>
    /// Adds <see cref="WeaponCategoryAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponCategoryAttackBonus))]
    public UnitConfigurator AddWeaponCategoryAttackBonus(
        WeaponCategory Category,
        int AttackBonus,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Category);
      ValidateParam(Descriptor);
      
      var component =  new WeaponCategoryAttackBonus();
      component.Category = Category;
      component.AttackBonus = AttackBonus;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponFocus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_WeaponType"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(WeaponFocus))]
    public UnitConfigurator AddWeaponFocus(
        string m_WeaponType,
        int AttackBonus,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Descriptor);
      
      var component =  new WeaponFocus();
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(m_WeaponType);
      component.AttackBonus = AttackBonus;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponFocusParametrized"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_MythicFocus"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(WeaponFocusParametrized))]
    public UnitConfigurator AddWeaponFocusParametrized(
        string m_MythicFocus,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Descriptor);
      
      var component =  new WeaponFocusParametrized();
      component.m_MythicFocus = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_MythicFocus);
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponGroupAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponGroupAttackBonus))]
    public UnitConfigurator AddWeaponGroupAttackBonus(
        WeaponFighterGroup WeaponGroup,
        int AttackBonus,
        ModifierDescriptor Descriptor,
        bool multiplyByContext,
        ContextValue contextMultiplier)
    {
      ValidateParam(WeaponGroup);
      ValidateParam(Descriptor);
      ValidateParam(contextMultiplier);
      
      var component =  new WeaponGroupAttackBonus();
      component.WeaponGroup = WeaponGroup;
      component.AttackBonus = AttackBonus;
      component.Descriptor = Descriptor;
      component.multiplyByContext = multiplyByContext;
      component.contextMultiplier = contextMultiplier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponGroupDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponGroupDamageBonus))]
    public UnitConfigurator AddWeaponGroupDamageBonus(
        WeaponFighterGroup WeaponGroup,
        int DamageBonus,
        ContextValue AdditionalValue,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(WeaponGroup);
      ValidateParam(AdditionalValue);
      ValidateParam(Descriptor);
      
      var component =  new WeaponGroupDamageBonus();
      component.WeaponGroup = WeaponGroup;
      component.DamageBonus = DamageBonus;
      component.AdditionalValue = AdditionalValue;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponGroupEnchant"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponGroupEnchant))]
    public UnitConfigurator AddWeaponGroupEnchant(
        WeaponFighterGroup WeaponGroup,
        int Bonus,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(WeaponGroup);
      ValidateParam(Descriptor);
      
      var component =  new WeaponGroupEnchant();
      component.WeaponGroup = WeaponGroup;
      component.Bonus = Bonus;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponMasteryParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponMasteryParametrized))]
    public UnitConfigurator AddWeaponMasteryParametrized()
    {
      return AddComponent(new WeaponMasteryParametrized());
    }

    /// <summary>
    /// Adds <see cref="WeaponMultipleCategoriesAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponMultipleCategoriesAttackBonus))]
    public UnitConfigurator AddWeaponMultipleCategoriesAttackBonus(
        WeaponCategory[] Categories,
        int AttackBonus,
        bool ExceptForCategories,
        ModifierDescriptor Descriptor)
    {
      foreach (var item in Categories)
      {
        ValidateParam(item);
      }
      ValidateParam(Descriptor);
      
      var component =  new WeaponMultipleCategoriesAttackBonus();
      component.Categories = Categories;
      component.AttackBonus = AttackBonus;
      component.ExceptForCategories = ExceptForCategories;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponParametersAttackBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_FightersFinesse"><see cref="BlueprintFeature"/></param>
    /// <param name="m_MultiplierFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(WeaponParametersAttackBonus))]
    public UnitConfigurator AddWeaponParametersAttackBonus(
        bool OnlyFinessable,
        bool CanBeUsedWithFightersFinesse,
        string m_FightersFinesse,
        bool Ranged,
        bool OnlyTwoHanded,
        int AttackBonus,
        ModifierDescriptor Descriptor,
        bool ScaleByBasicAttackBonus,
        bool OnlyForFullAttack,
        string m_MultiplierFact,
        int Multiplier)
    {
      ValidateParam(Descriptor);
      
      var component =  new WeaponParametersAttackBonus();
      component.OnlyFinessable = OnlyFinessable;
      component.CanBeUsedWithFightersFinesse = CanBeUsedWithFightersFinesse;
      component.m_FightersFinesse = BlueprintTool.GetRef<BlueprintFeatureReference>(m_FightersFinesse);
      component.Ranged = Ranged;
      component.OnlyTwoHanded = OnlyTwoHanded;
      component.AttackBonus = AttackBonus;
      component.Descriptor = Descriptor;
      component.ScaleByBasicAttackBonus = ScaleByBasicAttackBonus;
      component.OnlyForFullAttack = OnlyForFullAttack;
      component.m_MultiplierFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_MultiplierFact);
      component.Multiplier = Multiplier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponParametersCriticalEdgeIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponParametersCriticalEdgeIncrease))]
    public UnitConfigurator AddWeaponParametersCriticalEdgeIncrease(
        bool Light,
        bool Ranged,
        bool TwoHanded)
    {
      
      var component =  new WeaponParametersCriticalEdgeIncrease();
      component.Light = Light;
      component.Ranged = Ranged;
      component.TwoHanded = TwoHanded;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponParametersCriticalMultiplierIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponParametersCriticalMultiplierIncrease))]
    public UnitConfigurator AddWeaponParametersCriticalMultiplierIncrease(
        bool Light,
        bool Ranged,
        bool TwoHanded,
        int AdditionalMultiplier)
    {
      
      var component =  new WeaponParametersCriticalMultiplierIncrease();
      component.Light = Light;
      component.Ranged = Ranged;
      component.TwoHanded = TwoHanded;
      component.AdditionalMultiplier = AdditionalMultiplier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponParametersDamageBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_FightersFinesse"><see cref="BlueprintFeature"/></param>
    /// <param name="m_GreaterPowerAttackBlueprint"><see cref="BlueprintFeature"/></param>
    /// <param name="m_MythicBlueprint"><see cref="BlueprintFeature"/></param>
    /// <param name="m_WeaponBlueprint"><see cref="BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(WeaponParametersDamageBonus))]
    public UnitConfigurator AddWeaponParametersDamageBonus(
        bool OnlyFinessable,
        bool CanBeUsedWithFightersFinesse,
        string m_FightersFinesse,
        bool Ranged,
        bool OnlyTwoHanded,
        int DamageBonus,
        bool ScaleByBasicAttackBonus,
        bool PowerAttackScaling,
        bool DualWielding,
        bool OnlyToOffHandBonus,
        bool OnlySpecificItemBlueprint,
        string m_GreaterPowerAttackBlueprint,
        string m_MythicBlueprint,
        string m_WeaponBlueprint)
    {
      
      var component =  new WeaponParametersDamageBonus();
      component.OnlyFinessable = OnlyFinessable;
      component.CanBeUsedWithFightersFinesse = CanBeUsedWithFightersFinesse;
      component.m_FightersFinesse = BlueprintTool.GetRef<BlueprintFeatureReference>(m_FightersFinesse);
      component.Ranged = Ranged;
      component.OnlyTwoHanded = OnlyTwoHanded;
      component.DamageBonus = DamageBonus;
      component.ScaleByBasicAttackBonus = ScaleByBasicAttackBonus;
      component.PowerAttackScaling = PowerAttackScaling;
      component.DualWielding = DualWielding;
      component.OnlyToOffHandBonus = OnlyToOffHandBonus;
      component.OnlySpecificItemBlueprint = OnlySpecificItemBlueprint;
      component.m_GreaterPowerAttackBlueprint = BlueprintTool.GetRef<BlueprintFeatureReference>(m_GreaterPowerAttackBlueprint);
      component.m_MythicBlueprint = BlueprintTool.GetRef<BlueprintFeatureReference>(m_MythicBlueprint);
      component.m_WeaponBlueprint = BlueprintTool.GetRef<BlueprintItemWeaponReference>(m_WeaponBlueprint);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponSizeChange"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponSizeChange))]
    public UnitConfigurator AddWeaponSizeChange(
        int SizeCategoryChange,
        bool CheckWeaponCategory,
        WeaponCategory Category)
    {
      ValidateParam(Category);
      
      var component =  new WeaponSizeChange();
      component.SizeCategoryChange = SizeCategoryChange;
      component.CheckWeaponCategory = CheckWeaponCategory;
      component.Category = Category;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponSpecializationParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponSpecializationParametrized))]
    public UnitConfigurator AddWeaponSpecializationParametrized(
        bool Mythic)
    {
      
      var component =  new WeaponSpecializationParametrized();
      component.Mythic = Mythic;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTypeCriticalEdgeIncrease"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_WeaponType"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(WeaponTypeCriticalEdgeIncrease))]
    public UnitConfigurator AddWeaponTypeCriticalEdgeIncrease(
        string m_WeaponType)
    {
      
      var component =  new WeaponTypeCriticalEdgeIncrease();
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(m_WeaponType);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTypeCriticalEdgeIncreaseStackable"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponTypeCriticalEdgeIncreaseStackable))]
    public UnitConfigurator AddWeaponTypeCriticalEdgeIncreaseStackable(
        bool AnyCategory,
        WeaponCategory Category)
    {
      ValidateParam(Category);
      
      var component =  new WeaponTypeCriticalEdgeIncreaseStackable();
      component.AnyCategory = AnyCategory;
      component.Category = Category;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTypeCriticalMultiplierIncrease"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_WeaponType"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(WeaponTypeCriticalMultiplierIncrease))]
    public UnitConfigurator AddWeaponTypeCriticalMultiplierIncrease(
        string m_WeaponType,
        int AdditionalMultiplier)
    {
      
      var component =  new WeaponTypeCriticalMultiplierIncrease();
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(m_WeaponType);
      component.AdditionalMultiplier = AdditionalMultiplier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTypeDamageBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_WeaponType"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(WeaponTypeDamageBonus))]
    public UnitConfigurator AddWeaponTypeDamageBonus(
        string m_WeaponType,
        int DamageBonus)
    {
      
      var component =  new WeaponTypeDamageBonus();
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(m_WeaponType);
      component.DamageBonus = DamageBonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTypeDamageStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponTypeDamageStatReplacement))]
    public UnitConfigurator AddWeaponTypeDamageStatReplacement(
        StatType Stat,
        WeaponCategory Category,
        bool OnlyOneHanded,
        bool TwoHandedBonus)
    {
      ValidateParam(Stat);
      ValidateParam(Category);
      
      var component =  new WeaponTypeDamageStatReplacement();
      component.Stat = Stat;
      component.Category = Category;
      component.OnlyOneHanded = OnlyOneHanded;
      component.TwoHandedBonus = TwoHandedBonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ImpatienceCalmingPart"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Impatience"><see cref="BlueprintBuff"/></param>
    /// <param name="m_TargetedImpatience"><see cref="BlueprintBuff"/></param>
    /// <param name="m_Patience"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(ImpatienceCalmingPart))]
    public UnitConfigurator AddImpatienceCalmingPart(
        string m_Impatience,
        string m_TargetedImpatience,
        string m_Patience)
    {
      
      var component =  new ImpatienceCalmingPart();
      component.m_Impatience = BlueprintTool.GetRef<BlueprintBuffReference>(m_Impatience);
      component.m_TargetedImpatience = BlueprintTool.GetRef<BlueprintBuffReference>(m_TargetedImpatience);
      component.m_Patience = BlueprintTool.GetRef<BlueprintBuffReference>(m_Patience);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ImpatienceWatcherTickingResolve"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Impatience"><see cref="BlueprintBuff"/></param>
    /// <param name="m_TargetedImpatience"><see cref="BlueprintBuff"/></param>
    /// <param name="m_Patience"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(ImpatienceWatcherTickingResolve))]
    public UnitConfigurator AddImpatienceWatcherTickingResolve(
        string m_Impatience,
        string m_TargetedImpatience,
        string m_Patience,
        int[] ResolveChances,
        int[] ResolveChancesForLowInt,
        int[] ResolveChancesForHighInt)
    {
      
      var component =  new ImpatienceWatcherTickingResolve();
      component.m_Impatience = BlueprintTool.GetRef<BlueprintBuffReference>(m_Impatience);
      component.m_TargetedImpatience = BlueprintTool.GetRef<BlueprintBuffReference>(m_TargetedImpatience);
      component.m_Patience = BlueprintTool.GetRef<BlueprintBuffReference>(m_Patience);
      component.ResolveChances = ResolveChances;
      component.ResolveChancesForLowInt = ResolveChancesForLowInt;
      component.ResolveChancesForHighInt = ResolveChancesForHighInt;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstCaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstCaster))]
    public UnitConfigurator AddACBonusAgainstCaster(
        ContextValue Value,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Value);
      ValidateParam(Descriptor);
      
      var component =  new ACBonusAgainstCaster();
      component.Value = Value;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstTarget))]
    public UnitConfigurator AddACBonusAgainstTarget(
        ContextValue Value,
        bool CheckCaster,
        bool CheckCasterFriend,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Value);
      ValidateParam(Descriptor);
      
      var component =  new ACBonusAgainstTarget();
      component.Value = Value;
      component.CheckCaster = CheckCaster;
      component.CheckCasterFriend = CheckCasterFriend;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAdditionalLimbIfHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Weapon"><see cref="BlueprintItemWeapon"/></param>
    /// <param name="m_CheckedFact"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddAdditionalLimbIfHasFact))]
    public UnitConfigurator AddAddAdditionalLimbIfHasFact(
        string m_Weapon,
        string m_CheckedFact)
    {
      
      var component =  new AddAdditionalLimbIfHasFact();
      component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(m_Weapon);
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintFeatureReference>(m_CheckedFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusAbilityValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddStatBonusAbilityValue))]
    public UnitConfigurator AddAddStatBonusAbilityValue(
        ModifierDescriptor Descriptor,
        StatType Stat,
        ContextValue Value)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      ValidateParam(Value);
      
      var component =  new AddStatBonusAbilityValue();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusIfHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFacts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddStatBonusIfHasFact))]
    public UnitConfigurator AddAddStatBonusIfHasFact(
        ModifierDescriptor Descriptor,
        StatType Stat,
        ContextValue Value,
        bool InvertCondition,
        bool RequireAllFacts,
        string[] m_CheckedFacts)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      ValidateParam(Value);
      
      var component =  new AddStatBonusIfHasFact();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.Value = Value;
      component.InvertCondition = InvertCondition;
      component.RequireAllFacts = RequireAllFacts;
      component.m_CheckedFacts = m_CheckedFacts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusIfHasSkill"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddStatBonusIfHasSkill))]
    public UnitConfigurator AddAddStatBonusIfHasSkill(
        ModifierDescriptor Descriptor,
        StatType Stat,
        int ValueTrue,
        int ValueFalse,
        StatType CheckedSkill,
        int SkillValue)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      ValidateParam(CheckedSkill);
      
      var component =  new AddStatBonusIfHasSkill();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.ValueTrue = ValueTrue;
      component.ValueFalse = ValueFalse;
      component.CheckedSkill = CheckedSkill;
      component.SkillValue = SkillValue;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusScaled"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddStatBonusScaled))]
    public UnitConfigurator AddAddStatBonusScaled(
        ModifierDescriptor Descriptor,
        StatType Stat,
        int Value,
        BuffScaling Scaling)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      ValidateParam(Scaling);
      
      var component =  new AddStatBonusScaled();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.Value = Value;
      component.Scaling = Scaling;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Afterbuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_AfterBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(Afterbuff))]
    public UnitConfigurator AddAfterbuff(
        string m_AfterBuff,
        int DurationMultiplier)
    {
      
      var component =  new Afterbuff();
      component.m_AfterBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_AfterBuff);
      component.DurationMultiplier = DurationMultiplier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AfterbuffIfHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_FeatureToCheck"><see cref="BlueprintFeature"/></param>
    /// <param name="m_AfterBuffFalse"><see cref="BlueprintBuff"/></param>
    /// <param name="m_AfterBuffTrue"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AfterbuffIfHasFact))]
    public UnitConfigurator AddAfterbuffIfHasFact(
        string m_FeatureToCheck,
        string m_AfterBuffFalse,
        string m_AfterBuffTrue,
        int DurationMultiplier)
    {
      
      var component =  new AfterbuffIfHasFact();
      component.m_FeatureToCheck = BlueprintTool.GetRef<BlueprintFeatureReference>(m_FeatureToCheck);
      component.m_AfterBuffFalse = BlueprintTool.GetRef<BlueprintBuffReference>(m_AfterBuffFalse);
      component.m_AfterBuffTrue = BlueprintTool.GetRef<BlueprintBuffReference>(m_AfterBuffTrue);
      component.DurationMultiplier = DurationMultiplier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ApplyBuffOnHit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(ApplyBuffOnHit))]
    public UnitConfigurator AddApplyBuffOnHit(
        string m_buff,
        Rounds time)
    {
      ValidateParam(time);
      
      var component =  new ApplyBuffOnHit();
      component.m_buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_buff);
      component.time = time;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmagsBladeEnrage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmagsBladeEnrage))]
    public UnitConfigurator AddArmagsBladeEnrage()
    {
      return AddComponent(new ArmagsBladeEnrage());
    }

    /// <summary>
    /// Adds <see cref="ArmorFocus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmorFocus))]
    public UnitConfigurator AddArmorFocus(
        ArmorProficiencyGroup ArmorCategory)
    {
      ValidateParam(ArmorCategory);
      
      var component =  new ArmorFocus();
      component.ArmorCategory = ArmorCategory;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstCaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusAgainstCaster))]
    public UnitConfigurator AddAttackBonusAgainstCaster(
        ContextValue Value,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Value);
      ValidateParam(Descriptor);
      
      var component =  new AttackBonusAgainstCaster();
      component.Value = Value;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusAgainstTarget))]
    public UnitConfigurator AddAttackBonusAgainstTarget(
        ContextValue Value,
        ModifierDescriptor Descriptor,
        bool CheckCaster,
        bool CheckCasterFriend,
        bool CheckRangeType,
        WeaponRangeType RangeType)
    {
      ValidateParam(Value);
      ValidateParam(Descriptor);
      ValidateParam(RangeType);
      
      var component =  new AttackBonusAgainstTarget();
      component.Value = Value;
      component.Descriptor = Descriptor;
      component.CheckCaster = CheckCaster;
      component.CheckCasterFriend = CheckCasterFriend;
      component.CheckRangeType = CheckRangeType;
      component.RangeType = RangeType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffAbilityRollsBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffAbilityRollsBonus))]
    public UnitConfigurator AddBuffAbilityRollsBonus(
        int Value,
        ModifierDescriptor Descriptor,
        bool AffectAllStats,
        bool OnlyHighesStats,
        ContextValue Multiplier,
        StatType Stat)
    {
      ValidateParam(Descriptor);
      ValidateParam(Multiplier);
      ValidateParam(Stat);
      
      var component =  new BuffAbilityRollsBonus();
      component.Value = Value;
      component.Descriptor = Descriptor;
      component.AffectAllStats = AffectAllStats;
      component.OnlyHighesStats = OnlyHighesStats;
      component.Multiplier = Multiplier;
      component.Stat = Stat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffAllSavesBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffAllSavesBonus))]
    public UnitConfigurator AddBuffAllSavesBonus(
        ModifierDescriptor Descriptor,
        int Value)
    {
      ValidateParam(Descriptor);
      
      var component =  new BuffAllSavesBonus();
      component.Descriptor = Descriptor;
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffAllSkillsBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffAllSkillsBonus))]
    public UnitConfigurator AddBuffAllSkillsBonus(
        ModifierDescriptor Descriptor,
        int Value,
        ContextValue Multiplier)
    {
      ValidateParam(Descriptor);
      ValidateParam(Multiplier);
      
      var component =  new BuffAllSkillsBonus();
      component.Descriptor = Descriptor;
      component.Value = Value;
      component.Multiplier = Multiplier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffAllSkillsBonusAbilityValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffAllSkillsBonusAbilityValue))]
    public UnitConfigurator AddBuffAllSkillsBonusAbilityValue(
        ModifierDescriptor Descriptor,
        ContextValue Value)
    {
      ValidateParam(Descriptor);
      ValidateParam(Value);
      
      var component =  new BuffAllSkillsBonusAbilityValue();
      component.Descriptor = Descriptor;
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffAllSkillsBonusRankDependent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffAllSkillsBonusRankDependent))]
    public UnitConfigurator AddBuffAllSkillsBonusRankDependent(
        ModifierDescriptor Descriptor,
        int Value,
        int MinimalRank)
    {
      ValidateParam(Descriptor);
      
      var component =  new BuffAllSkillsBonusRankDependent();
      component.Descriptor = Descriptor;
      component.Value = Value;
      component.MinimalRank = MinimalRank;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffDamageEachRound"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffDamageEachRound))]
    public UnitConfigurator AddBuffDamageEachRound(
        int baseRounds,
        float AdditionalRoundsPerCasterLevel,
        DiceFormula EnergyDamageDice,
        DamageEnergyType Element)
    {
      ValidateParam(EnergyDamageDice);
      ValidateParam(Element);
      
      var component =  new BuffDamageEachRound();
      component.baseRounds = baseRounds;
      component.AdditionalRoundsPerCasterLevel = AdditionalRoundsPerCasterLevel;
      component.EnergyDamageDice = EnergyDamageDice;
      component.Element = Element;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffExtraAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffExtraAttack))]
    public UnitConfigurator AddBuffExtraAttack(
        int Number,
        bool Haste)
    {
      
      var component =  new BuffExtraAttack();
      component.Number = Number;
      component.Haste = Haste;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffExtraAttackWeaponSpecific"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffExtraAttackWeaponSpecific))]
    public UnitConfigurator AddBuffExtraAttackWeaponSpecific(
        WeaponRangeType RangeType)
    {
      ValidateParam(RangeType);
      
      var component =  new BuffExtraAttackWeaponSpecific();
      component.RangeType = RangeType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffIncomingDamageIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffIncomingDamageIncrease))]
    public UnitConfigurator AddBuffIncomingDamageIncrease(
        ContextValue Value)
    {
      ValidateParam(Value);
      
      var component =  new BuffIncomingDamageIncrease();
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffInvisibility"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffInvisibility))]
    public UnitConfigurator AddBuffInvisibility(
        bool NotDispellAfterOffensiveAction,
        int m_StealthBonus,
        bool DispelWithAChance,
        ContextValue Chance)
    {
      ValidateParam(Chance);
      
      var component =  new BuffInvisibility();
      component.NotDispellAfterOffensiveAction = NotDispellAfterOffensiveAction;
      component.m_StealthBonus = m_StealthBonus;
      component.DispelWithAChance = DispelWithAChance;
      component.Chance = Chance;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffMiraculousHealing"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffMiraculousHealing))]
    public UnitConfigurator AddBuffMiraculousHealing(
        float EmpowerMiraculousModifier,
        float m_SavedModifier)
    {
      
      var component =  new BuffMiraculousHealing();
      component.EmpowerMiraculousModifier = EmpowerMiraculousModifier;
      component.m_SavedModifier = m_SavedModifier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffMovementSpeed"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffMovementSpeed))]
    public UnitConfigurator AddBuffMovementSpeed(
        ModifierDescriptor Descriptor,
        int Value,
        ContextValue ContextBonus,
        bool CappedOnMultiplier,
        float MultiplierCap,
        bool CappedMinimum,
        int MinimumCap)
    {
      ValidateParam(Descriptor);
      ValidateParam(ContextBonus);
      
      var component =  new BuffMovementSpeed();
      component.Descriptor = Descriptor;
      component.Value = Value;
      component.ContextBonus = ContextBonus;
      component.CappedOnMultiplier = CappedOnMultiplier;
      component.MultiplierCap = MultiplierCap;
      component.CappedMinimum = CappedMinimum;
      component.MinimumCap = MinimumCap;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffOnArmor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(BuffOnArmor))]
    public UnitConfigurator AddBuffOnArmor(
        string m_Buff)
    {
      
      var component =  new BuffOnArmor();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffOnHealthTickingTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_TriggeredBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(BuffOnHealthTickingTrigger))]
    public UnitConfigurator AddBuffOnHealthTickingTrigger(
        string m_TriggeredBuff,
        float HealthPercent)
    {
      
      var component =  new BuffOnHealthTickingTrigger();
      component.m_TriggeredBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_TriggeredBuff);
      component.HealthPercent = HealthPercent;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffOnLightOrNoArmor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(BuffOnLightOrNoArmor))]
    public UnitConfigurator AddBuffOnLightOrNoArmor(
        string m_Buff)
    {
      
      var component =  new BuffOnLightOrNoArmor();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffParticleEffectPlay"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffParticleEffectPlay))]
    public UnitConfigurator AddBuffParticleEffectPlay(
        bool PlayOnActivate,
        PrefabLink ActivateFx,
        bool PlayOnDeactivate,
        PrefabLink DeactivateFx,
        bool PlayEachRound,
        PrefabLink EachRoundFx)
    {
      ValidateParam(ActivateFx);
      ValidateParam(DeactivateFx);
      ValidateParam(EachRoundFx);
      
      var component =  new BuffParticleEffectPlay();
      component.PlayOnActivate = PlayOnActivate;
      component.ActivateFx = ActivateFx;
      component.PlayOnDeactivate = PlayOnDeactivate;
      component.DeactivateFx = DeactivateFx;
      component.PlayEachRound = PlayEachRound;
      component.EachRoundFx = EachRoundFx;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffPerceptionBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffPerceptionBonus))]
    public UnitConfigurator AddBuffPerceptionBonus(
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Descriptor);
      
      var component =  new BuffPerceptionBonus();
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffPoisonStatDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffPoisonStatDamage))]
    public UnitConfigurator AddBuffPoisonStatDamage(
        ModifierDescriptor Descriptor,
        StatType Stat,
        DiceFormula Value,
        int Bonus,
        int Ticks,
        int SuccesfullSaves,
        SavingThrowType SaveType,
        bool NoEffectOnFirstTick)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      ValidateParam(Value);
      ValidateParam(SaveType);
      
      var component =  new BuffPoisonStatDamage();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.Value = Value;
      component.Bonus = Bonus;
      component.Ticks = Ticks;
      component.SuccesfullSaves = SuccesfullSaves;
      component.SaveType = SaveType;
      component.NoEffectOnFirstTick = NoEffectOnFirstTick;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffPoisonStatDamageContext"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffPoisonStatDamageContext))]
    public UnitConfigurator AddBuffPoisonStatDamageContext(
        ModifierDescriptor Descriptor,
        StatType Stat,
        ContextDiceValue Value,
        ContextValue Bonus,
        ContextValue Ticks,
        ContextValue SuccesfullSaves,
        SavingThrowType SaveType,
        bool NoEffectOnFirstTick)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      ValidateParam(Value);
      ValidateParam(Bonus);
      ValidateParam(Ticks);
      ValidateParam(SuccesfullSaves);
      ValidateParam(SaveType);
      
      var component =  new BuffPoisonStatDamageContext();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.Value = Value;
      component.Bonus = Bonus;
      component.Ticks = Ticks;
      component.SuccesfullSaves = SuccesfullSaves;
      component.SaveType = SaveType;
      component.NoEffectOnFirstTick = NoEffectOnFirstTick;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffSaveEachRound"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffSaveEachRound))]
    public UnitConfigurator AddBuffSaveEachRound(
        SavingThrowType SaveType,
        int SaveDC,
        int IncreaseDC,
        ActionsBuilder ActionsOnPass,
        ActionsBuilder ActionsOnFail)
    {
      ValidateParam(SaveType);
      
      var component =  new BuffSaveEachRound();
      component.SaveType = SaveType;
      component.SaveDC = SaveDC;
      component.IncreaseDC = IncreaseDC;
      component.ActionsOnPass = ActionsOnPass.Build();
      component.ActionsOnFail = ActionsOnFail.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffSaveOrDieEachRound"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffSaveOrDieEachRound))]
    public UnitConfigurator AddBuffSaveOrDieEachRound(
        UnitCondition Condition,
        SavingThrowType SaveType,
        int SaveDC,
        int IncreaseDC,
        GameObject EffectOnDeath)
    {
      ValidateParam(Condition);
      ValidateParam(SaveType);
      ValidateParam(EffectOnDeath);
      
      var component =  new BuffSaveOrDieEachRound();
      component.Condition = Condition;
      component.SaveType = SaveType;
      component.SaveDC = SaveDC;
      component.IncreaseDC = IncreaseDC;
      component.EffectOnDeath = EffectOnDeath;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffSkillBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffSkillBonus))]
    public UnitConfigurator AddBuffSkillBonus(
        StatType Stat,
        ModifierDescriptor Descriptor,
        int Value)
    {
      ValidateParam(Stat);
      ValidateParam(Descriptor);
      
      var component =  new BuffSkillBonus();
      component.Stat = Stat;
      component.Descriptor = Descriptor;
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffSkillLoreNatureBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffSkillLoreNatureBonus))]
    public UnitConfigurator AddBuffSkillLoreNatureBonus(
        ModifierDescriptor Descriptor,
        int Value)
    {
      ValidateParam(Descriptor);
      
      var component =  new BuffSkillLoreNatureBonus();
      component.Descriptor = Descriptor;
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffSkillStealthBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffSkillStealthBonus))]
    public UnitConfigurator AddBuffSkillStealthBonus(
        ModifierDescriptor Descriptor,
        int Value)
    {
      ValidateParam(Descriptor);
      
      var component =  new BuffSkillStealthBonus();
      component.Descriptor = Descriptor;
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffStatPenaltyDice"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffStatPenaltyDice))]
    public UnitConfigurator AddBuffStatPenaltyDice(
        ModifierDescriptor Descriptor,
        StatType Stat,
        DiceFormula Value,
        int Bonus,
        SavingThrowType SaveType)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      ValidateParam(Value);
      ValidateParam(SaveType);
      
      var component =  new BuffStatPenaltyDice();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.Value = Value;
      component.Bonus = Bonus;
      component.SaveType = SaveType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffStatusCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffStatusCondition))]
    public UnitConfigurator AddBuffStatusCondition(
        bool SaveEachRound,
        UnitCondition Condition,
        SavingThrowType SaveType)
    {
      ValidateParam(Condition);
      ValidateParam(SaveType);
      
      var component =  new BuffStatusCondition();
      component.SaveEachRound = SaveEachRound;
      component.Condition = Condition;
      component.SaveType = SaveType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffStrengthSkillsBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffStrengthSkillsBonus))]
    public UnitConfigurator AddBuffStrengthSkillsBonus(
        ModifierDescriptor Descriptor,
        int Value,
        BuffScaling Scaling)
    {
      ValidateParam(Descriptor);
      ValidateParam(Scaling);
      
      var component =  new BuffStrengthSkillsBonus();
      component.Descriptor = Descriptor;
      component.Value = Value;
      component.Scaling = Scaling;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BurstBarrier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BurstBarrier))]
    public UnitConfigurator AddBurstBarrier()
    {
      return AddComponent(new BurstBarrier());
    }

    /// <summary>
    /// Adds <see cref="CannyDefensePermanent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CharacterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_ChosenWeaponBlueprint"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(CannyDefensePermanent))]
    public UnitConfigurator AddCannyDefensePermanent(
        string m_CharacterClass,
        bool RequiresKensai,
        string m_ChosenWeaponBlueprint)
    {
      
      var component =  new CannyDefensePermanent();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_CharacterClass);
      component.RequiresKensai = RequiresKensai;
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(m_ChosenWeaponBlueprint);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeUnitSize"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeUnitSize))]
    public UnitConfigurator AddChangeUnitSize(
        ChangeUnitSize.ChangeType m_Type,
        int SizeDelta,
        Size Size)
    {
      ValidateParam(m_Type);
      ValidateParam(Size);
      
      var component =  new ChangeUnitSize();
      component.m_Type = m_Type;
      component.SizeDelta = SizeDelta;
      component.Size = Size;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageBonusAgainstTarget))]
    public UnitConfigurator AddDamageBonusAgainstTarget(
        ContextValue Value,
        bool CheckCaster,
        bool CheckCasterFriend,
        bool ApplyToSpellDamage)
    {
      ValidateParam(Value);
      
      var component =  new DamageBonusAgainstTarget();
      component.Value = Value;
      component.CheckCaster = CheckCaster;
      component.CheckCasterFriend = CheckCasterFriend;
      component.ApplyToSpellDamage = ApplyToSpellDamage;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusConditional"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageBonusConditional))]
    public UnitConfigurator AddDamageBonusConditional(
        bool CheckWielder,
        bool OnlyWeaponDamage,
        ModifierDescriptor Descriptor,
        ContextValue Bonus,
        ConditionsBuilder Conditions)
    {
      ValidateParam(Descriptor);
      ValidateParam(Bonus);
      
      var component =  new DamageBonusConditional();
      component.CheckWielder = CheckWielder;
      component.OnlyWeaponDamage = OnlyWeaponDamage;
      component.Descriptor = Descriptor;
      component.Bonus = Bonus;
      component.Conditions = Conditions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageOnRemove"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageOnRemove))]
    public UnitConfigurator AddDamageOnRemove(
        DiceFormula Damage,
        DamageEnergyType EnergyType)
    {
      ValidateParam(Damage);
      ValidateParam(EnergyType);
      
      var component =  new DamageOnRemove();
      component.Damage = Damage;
      component.EnergyType = EnergyType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageOverTime"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageOverTime))]
    public UnitConfigurator AddDamageOverTime(
        DiceFormula Damage,
        DamageEnergyType EnergyType,
        bool InstantStartTick)
    {
      ValidateParam(Damage);
      ValidateParam(EnergyType);
      
      var component =  new DamageOverTime();
      component.Damage = Damage;
      component.EnergyType = EnergyType;
      component.InstantStartTick = InstantStartTick;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageWithDescriptorRecievedTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageWithDescriptorRecievedTrigger))]
    public UnitConfigurator AddDamageWithDescriptorRecievedTrigger(
        SpellDescriptorWrapper Descriptor,
        DamageEnergyType EnergyType,
        ActionsBuilder Actions)
    {
      ValidateParam(Descriptor);
      ValidateParam(EnergyType);
      
      var component =  new DamageWithDescriptorRecievedTrigger();
      component.Descriptor = Descriptor;
      component.EnergyType = EnergyType;
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DevilReflectAbility"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DevilReflectAbility))]
    public UnitConfigurator AddDevilReflectAbility(
        SpellSchool[] m_ReflectSchools)
    {
      foreach (var item in m_ReflectSchools)
      {
        ValidateParam(item);
      }
      
      var component =  new DevilReflectAbility();
      component.m_ReflectSchools = m_ReflectSchools;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DifficultyStatAdvancement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DifficultyStatAdvancement))]
    public UnitConfigurator AddDifficultyStatAdvancement(
        int BasicStatBonus,
        int DerivativeStatBonus)
    {
      
      var component =  new DifficultyStatAdvancement();
      component.BasicStatBonus = BasicStatBonus;
      component.DerivativeStatBonus = DerivativeStatBonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EchoesOfStoneTerrainBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EchoesOfStoneTerrainBonus))]
    public UnitConfigurator AddEchoesOfStoneTerrainBonus(
        AreaSetting Setting)
    {
      ValidateParam(Setting);
      
      var component =  new EchoesOfStoneTerrainBonus();
      component.Setting = Setting;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EmptyHandWeaponOverride"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Weapon"><see cref="BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(EmptyHandWeaponOverride))]
    public UnitConfigurator AddEmptyHandWeaponOverride(
        string m_Weapon,
        bool IsPermanent,
        bool IsMonkUnarmedStrike)
    {
      
      var component =  new EmptyHandWeaponOverride();
      component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(m_Weapon);
      component.IsPermanent = IsPermanent;
      component.IsMonkUnarmedStrike = IsMonkUnarmedStrike;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EqualForce"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EqualForce))]
    public UnitConfigurator AddEqualForce()
    {
      return AddComponent(new EqualForce());
    }

    /// <summary>
    /// Adds <see cref="GreaterSnapShotBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GreaterSnapShotBonus))]
    public UnitConfigurator AddGreaterSnapShotBonus(
        ContextValue Value,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Value);
      ValidateParam(Descriptor);
      
      var component =  new GreaterSnapShotBonus();
      component.Value = Value;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="HasArmorFeatureUnlock"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_NewFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(HasArmorFeatureUnlock))]
    public UnitConfigurator AddHasArmorFeatureUnlock(
        string m_NewFact)
    {
      
      var component =  new HasArmorFeatureUnlock();
      component.m_NewFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_NewFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="HealOverTime"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HealOverTime))]
    public UnitConfigurator AddHealOverTime(
        int Heal,
        bool InstantStartTick)
    {
      
      var component =  new HealOverTime();
      component.Heal = Heal;
      component.InstantStartTick = InstantStartTick;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="HealOverTimeIfHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedFact"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(HealOverTimeIfHasFact))]
    public UnitConfigurator AddHealOverTimeIfHasFact(
        int Heal,
        bool InstantStartTick,
        string m_CheckedFact,
        bool Scale,
        BuffScaling Scaling)
    {
      ValidateParam(Scaling);
      
      var component =  new HealOverTimeIfHasFact();
      component.Heal = Heal;
      component.InstantStartTick = InstantStartTick;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintFeatureReference>(m_CheckedFact);
      component.Scale = Scale;
      component.Scaling = Scaling;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreTargetDR"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreTargetDR))]
    public UnitConfigurator AddIgnoreTargetDR(
        bool CheckCaster,
        bool CheckCasterFriend)
    {
      
      var component =  new IgnoreTargetDR();
      component.CheckCaster = CheckCaster;
      component.CheckCasterFriend = CheckCasterFriend;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellDamageByClassLevel"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spells"><see cref="BlueprintAbility"/></param>
    /// <param name="m_CharacterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_AdditionalClasses"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_Archetypes"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(IncreaseSpellDamageByClassLevel))]
    public UnitConfigurator AddIncreaseSpellDamageByClassLevel(
        string[] m_Spells,
        string m_CharacterClass,
        string[] m_AdditionalClasses,
        string[] m_Archetypes)
    {
      
      var component =  new IncreaseSpellDamageByClassLevel();
      component.m_Spells = m_Spells.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_CharacterClass);
      component.m_AdditionalClasses = m_AdditionalClasses.Select(bp => BlueprintTool.GetRef<BlueprintCharacterClassReference>(bp)).ToArray();
      component.m_Archetypes = m_Archetypes.Select(bp => BlueprintTool.GetRef<BlueprintArchetypeReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IntenseSpells"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Wizard"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(IntenseSpells))]
    public UnitConfigurator AddIntenseSpells(
        string m_Wizard)
    {
      
      var component =  new IntenseSpells();
      component.m_Wizard = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_Wizard);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LiquidateTowerShieldPenalty"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LiquidateTowerShieldPenalty))]
    public UnitConfigurator AddLiquidateTowerShieldPenalty()
    {
      return AddComponent(new LiquidateTowerShieldPenalty());
    }

    /// <summary>
    /// Adds <see cref="MakeUnitFollowUnit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MakeUnitFollowUnit))]
    public UnitConfigurator AddMakeUnitFollowUnit(
        bool AlwaysRun,
        bool CanBeSlowerThanLeader,
        UnitEvaluator Leader)
    {
      ValidateParam(Leader);
      
      var component =  new MakeUnitFollowUnit();
      component.AlwaysRun = AlwaysRun;
      component.CanBeSlowerThanLeader = CanBeSlowerThanLeader;
      component.Leader = Leader;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ModifySpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(ModifySpell))]
    public UnitConfigurator AddModifySpell(
        SpellModificationType ModificationType,
        string[] m_Spells)
    {
      ValidateParam(ModificationType);
      
      var component =  new ModifySpell();
      component.ModificationType = ModificationType;
      component.m_Spells = m_Spells.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MonkNoArmorAndMonkWeaponFeatureUnlock"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_NewFact"><see cref="BlueprintUnitFact"/></param>
    /// <param name="m_BowWeaponTypes"><see cref="BlueprintWeaponType"/></param>
    /// <param name="m_RapidshotBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(MonkNoArmorAndMonkWeaponFeatureUnlock))]
    public UnitConfigurator AddMonkNoArmorAndMonkWeaponFeatureUnlock(
        string m_NewFact,
        bool IsZenArcher,
        string[] m_BowWeaponTypes,
        string m_RapidshotBuff,
        bool IsSohei)
    {
      
      var component =  new MonkNoArmorAndMonkWeaponFeatureUnlock();
      component.m_NewFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_NewFact);
      component.IsZenArcher = IsZenArcher;
      component.m_BowWeaponTypes = m_BowWeaponTypes.Select(bp => BlueprintTool.GetRef<BlueprintWeaponTypeReference>(bp)).ToArray();
      component.m_RapidshotBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_RapidshotBuff);
      component.IsSohei = IsSohei;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MonkNoArmorFeatureUnlock"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_NewFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(MonkNoArmorFeatureUnlock))]
    public UnitConfigurator AddMonkNoArmorFeatureUnlock(
        string m_NewFact)
    {
      
      var component =  new MonkNoArmorFeatureUnlock();
      component.m_NewFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_NewFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MysticTheurgeCombinedSpells"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MysticTheurgeCombinedSpells))]
    public UnitConfigurator AddMysticTheurgeCombinedSpells(
        int SpellLevel)
    {
      
      var component =  new MysticTheurgeCombinedSpells();
      component.SpellLevel = SpellLevel;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MysticTheurgeSpellbook"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CharacterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_MysticTheurge"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(MysticTheurgeSpellbook))]
    public UnitConfigurator AddMysticTheurgeSpellbook(
        string m_CharacterClass,
        string m_MysticTheurge)
    {
      
      var component =  new MysticTheurgeSpellbook();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_CharacterClass);
      component.m_MysticTheurge = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_MysticTheurge);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OverrideLocoMotion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(OverrideLocoMotion))]
    public UnitConfigurator AddOverrideLocoMotion(
        UnitAnimationActionLocoMotion LocoMotion)
    {
      ValidateParam(LocoMotion);
      
      var component =  new OverrideLocoMotion();
      component.LocoMotion = LocoMotion;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PowerfulCharge"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PowerfulCharge))]
    public UnitConfigurator AddPowerfulCharge(
        bool UseContextBonus,
        ContextValue Value,
        int AdditionalDiceRolls)
    {
      ValidateParam(Value);
      
      var component =  new PowerfulCharge();
      component.UseContextBonus = UseContextBonus;
      component.Value = Value;
      component.AdditionalDiceRolls = AdditionalDiceRolls;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ProtectionFromEnergy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ProtectionFromEnergy))]
    public UnitConfigurator AddProtectionFromEnergy(
        DamageEnergyType Type,
        bool UseValueMultiplier,
        ContextValue ValueMultiplier,
        ContextValue Value,
        bool UsePool,
        ContextValue Pool)
    {
      ValidateParam(Type);
      ValidateParam(ValueMultiplier);
      ValidateParam(Value);
      ValidateParam(Pool);
      
      var component =  new ProtectionFromEnergy();
      component.Type = Type;
      component.UseValueMultiplier = UseValueMultiplier;
      component.ValueMultiplier = ValueMultiplier;
      component.Value = Value;
      component.UsePool = UsePool;
      component.Pool = Pool;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PummelingCharge"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PummelingCharge))]
    public UnitConfigurator AddPummelingCharge(
        WeaponCategory UnarmedCategory)
    {
      ValidateParam(UnarmedCategory);
      
      var component =  new PummelingCharge();
      component.UnarmedCategory = UnarmedCategory;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReduceDamageReduction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ReduceDamageReduction))]
    public UnitConfigurator AddReduceDamageReduction(
        int Multiplier,
        ContextValue Value)
    {
      ValidateParam(Value);
      
      var component =  new ReduceDamageReduction();
      component.Multiplier = Multiplier;
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RemovedByHeal"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemovedByHeal))]
    public UnitConfigurator AddRemovedByHeal()
    {
      return AddComponent(new RemovedByHeal());
    }

    /// <summary>
    /// Adds <see cref="ReplaceAsksList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Asks"><see cref="BlueprintUnitAsksList"/></param>
    [Generated]
    [Implements(typeof(ReplaceAsksList))]
    public UnitConfigurator AddReplaceAsksList(
        string m_Asks)
    {
      
      var component =  new ReplaceAsksList();
      component.m_Asks = BlueprintTool.GetRef<BlueprintUnitAsksListReference>(m_Asks);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ResistEnergy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ResistEnergy))]
    public UnitConfigurator AddResistEnergy(
        DamageEnergyType Type,
        bool UseValueMultiplier,
        ContextValue ValueMultiplier,
        ContextValue Value,
        bool UsePool,
        ContextValue Pool)
    {
      ValidateParam(Type);
      ValidateParam(ValueMultiplier);
      ValidateParam(Value);
      ValidateParam(Pool);
      
      var component =  new ResistEnergy();
      component.Type = Type;
      component.UseValueMultiplier = UseValueMultiplier;
      component.ValueMultiplier = ValueMultiplier;
      component.Value = Value;
      component.UsePool = UsePool;
      component.Pool = Pool;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ResistEnergyContext"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ResistEnergyContext))]
    public UnitConfigurator AddResistEnergyContext(
        DamageEnergyType Type,
        bool UseValueMultiplier,
        ContextValue ValueMultiplier,
        ContextValue Value,
        bool UsePool,
        ContextValue Pool)
    {
      ValidateParam(Type);
      ValidateParam(ValueMultiplier);
      ValidateParam(Value);
      ValidateParam(Pool);
      
      var component =  new ResistEnergyContext();
      component.Type = Type;
      component.UseValueMultiplier = UseValueMultiplier;
      component.ValueMultiplier = ValueMultiplier;
      component.Value = Value;
      component.UsePool = UsePool;
      component.Pool = Pool;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SaveSuccessIfBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SaveSuccessIfBonus))]
    public UnitConfigurator AddSaveSuccessIfBonus(
        ContextValue Value)
    {
      ValidateParam(Value);
      
      var component =  new SaveSuccessIfBonus();
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShieldFocus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ShieldFocus))]
    public UnitConfigurator AddShieldFocus()
    {
      return AddComponent(new ShieldFocus());
    }

    /// <summary>
    /// Adds <see cref="SkillSuccessIfBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SkillSuccessIfBonus))]
    public UnitConfigurator AddSkillSuccessIfBonus(
        ContextValue Value)
    {
      ValidateParam(Value);
      
      var component =  new SkillSuccessIfBonus();
      component.Value = Value;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpeedBonusInArmorCategory"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpeedBonusInArmorCategory))]
    public UnitConfigurator AddSpeedBonusInArmorCategory(
        ArmorProficiencyGroup[] Category,
        int Bonus,
        ModifierDescriptor Descriptor,
        bool NoArmor)
    {
      foreach (var item in Category)
      {
        ValidateParam(item);
      }
      ValidateParam(Descriptor);
      
      var component =  new SpeedBonusInArmorCategory();
      component.Category = Category;
      component.Bonus = Bonus;
      component.Descriptor = Descriptor;
      component.NoArmor = NoArmor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="StatBonusWeaponRestriction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(StatBonusWeaponRestriction))]
    public UnitConfigurator AddStatBonusWeaponRestriction(
        StatType Stat,
        int Value,
        ModifierDescriptor Descriptor,
        bool CheckCategory,
        WeaponCategory Category,
        bool OneHandedOnly,
        bool DuelistWeapon)
    {
      ValidateParam(Stat);
      ValidateParam(Descriptor);
      ValidateParam(Category);
      
      var component =  new StatBonusWeaponRestriction();
      component.Stat = Stat;
      component.Value = Value;
      component.Descriptor = Descriptor;
      component.CheckCategory = CheckCategory;
      component.Category = Category;
      component.OneHandedOnly = OneHandedOnly;
      component.DuelistWeapon = DuelistWeapon;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="StonyStepTerrainBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(StonyStepTerrainBonus))]
    public UnitConfigurator AddStonyStepTerrainBonus(
        AreaSetting Setting)
    {
      ValidateParam(Setting);
      
      var component =  new StonyStepTerrainBonus();
      component.Setting = Setting;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TemporaryHitPointsConstitutionBased"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TemporaryHitPointsConstitutionBased))]
    public UnitConfigurator AddTemporaryHitPointsConstitutionBased(
        ContextValue Value,
        int BonusMultiplier,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Value);
      ValidateParam(Descriptor);
      
      var component =  new TemporaryHitPointsConstitutionBased();
      component.Value = Value;
      component.BonusMultiplier = BonusMultiplier;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TemporaryHitPointsEqualCasterLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TemporaryHitPointsEqualCasterLevel))]
    public UnitConfigurator AddTemporaryHitPointsEqualCasterLevel(
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Descriptor);
      
      var component =  new TemporaryHitPointsEqualCasterLevel();
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TemporaryHitPointsFromAbilityValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TemporaryHitPointsFromAbilityValue))]
    public UnitConfigurator AddTemporaryHitPointsFromAbilityValue(
        ModifierDescriptor Descriptor,
        ContextValue Value,
        bool RemoveWhenHitPointsEnd)
    {
      ValidateParam(Descriptor);
      ValidateParam(Value);
      
      var component =  new TemporaryHitPointsFromAbilityValue();
      component.Descriptor = Descriptor;
      component.Value = Value;
      component.RemoveWhenHitPointsEnd = RemoveWhenHitPointsEnd;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TemporaryHitPointsPerLevel"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_LimitlessRageBlueprint"><see cref="BlueprintUnitFact"/></param>
    /// <param name="m_LimitlessRageResource"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    [Implements(typeof(TemporaryHitPointsPerLevel))]
    public UnitConfigurator AddTemporaryHitPointsPerLevel(
        ModifierDescriptor Descriptor,
        int HitPointsPerLevel,
        ContextValue Value,
        bool RemoveWhenHitPointsEnd,
        bool LimitlessRage,
        string m_LimitlessRageBlueprint,
        string m_LimitlessRageResource)
    {
      ValidateParam(Descriptor);
      ValidateParam(Value);
      
      var component =  new TemporaryHitPointsPerLevel();
      component.Descriptor = Descriptor;
      component.HitPointsPerLevel = HitPointsPerLevel;
      component.Value = Value;
      component.RemoveWhenHitPointsEnd = RemoveWhenHitPointsEnd;
      component.LimitlessRage = LimitlessRage;
      component.m_LimitlessRageBlueprint = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_LimitlessRageBlueprint);
      component.m_LimitlessRageResource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(m_LimitlessRageResource);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TemporaryHitPointsRandom"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TemporaryHitPointsRandom))]
    public UnitConfigurator AddTemporaryHitPointsRandom(
        ModifierDescriptor Descriptor,
        DiceFormula Dice,
        ContextValue Bonus,
        bool ScaleBonusByCasterLevel)
    {
      ValidateParam(Descriptor);
      ValidateParam(Dice);
      ValidateParam(Bonus);
      
      var component =  new TemporaryHitPointsRandom();
      component.Descriptor = Descriptor;
      component.Dice = Dice;
      component.Bonus = Bonus;
      component.ScaleBonusByCasterLevel = ScaleBonusByCasterLevel;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TowerShieldSpecialistTotalCover"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TowerShieldSpecialistTotalCover))]
    public UnitConfigurator AddTowerShieldSpecialistTotalCover()
    {
      return AddComponent(new TowerShieldSpecialistTotalCover());
    }

    /// <summary>
    /// Adds <see cref="WeaponTrainingBonuses"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponTrainingBonuses))]
    public UnitConfigurator AddWeaponTrainingBonuses(
        ModifierDescriptor Descriptor,
        StatType Stat)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      
      var component =  new WeaponTrainingBonuses();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WizardAbjurationResistance"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Wizard"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(WizardAbjurationResistance))]
    public UnitConfigurator AddWizardAbjurationResistance(
        string m_Wizard,
        DamageEnergyType Type,
        bool UseValueMultiplier,
        ContextValue ValueMultiplier,
        ContextValue Value,
        bool UsePool,
        ContextValue Pool)
    {
      ValidateParam(Type);
      ValidateParam(ValueMultiplier);
      ValidateParam(Value);
      ValidateParam(Pool);
      
      var component =  new WizardAbjurationResistance();
      component.m_Wizard = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_Wizard);
      component.Type = Type;
      component.UseValueMultiplier = UseValueMultiplier;
      component.ValueMultiplier = ValueMultiplier;
      component.Value = Value;
      component.UsePool = UsePool;
      component.Pool = Pool;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WizardEnergyAbsorption"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Resource"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    [Implements(typeof(WizardEnergyAbsorption))]
    public UnitConfigurator AddWizardEnergyAbsorption(
        string m_Resource,
        DamageEnergyType Type,
        bool UseValueMultiplier,
        ContextValue ValueMultiplier,
        ContextValue Value,
        bool UsePool,
        ContextValue Pool)
    {
      ValidateParam(Type);
      ValidateParam(ValueMultiplier);
      ValidateParam(Value);
      ValidateParam(Pool);
      
      var component =  new WizardEnergyAbsorption();
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(m_Resource);
      component.Type = Type;
      component.UseValueMultiplier = UseValueMultiplier;
      component.ValueMultiplier = ValueMultiplier;
      component.Value = Value;
      component.UsePool = UsePool;
      component.Pool = Pool;
      return AddComponent(component);
    }
  }
}
