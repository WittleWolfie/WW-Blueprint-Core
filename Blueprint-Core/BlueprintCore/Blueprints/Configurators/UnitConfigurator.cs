using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Armies.Components;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.Armies.TacticalCombat.LeaderSkills;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.CharGen;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Experience;
using Kingmaker.Controllers.Rest.Special;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Persistence.Versioning;
using Kingmaker.Enums;
using Kingmaker.Kingdom;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Interaction;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Components.Fixers;
using Kingmaker.View.MapObjects;
using System;
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
    /// Adds <see cref="UnitIsStoryCompanion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitIsStoryCompanion))]
    public UnitConfigurator AddUnitIsStoryCompanion()
    {
      return AddComponent(new UnitIsStoryCompanion());
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
    /// Adds <see cref="NonHumanoidCompanion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(NonHumanoidCompanion))]
    public UnitConfigurator AddNonHumanoidCompanion()
    {
      return AddComponent(new NonHumanoidCompanion());
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
        String TaskId,
        String Comment)
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
        String TaskId,
        String Comment)
    {
      
      var component =  new ReturnVendorTable();
      component.m_Table = BlueprintTool.GetRef<BlueprintSharedVendorTableReference>(m_Table);
      component.TaskId = TaskId;
      component.Comment = Comment;
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
  }
}
