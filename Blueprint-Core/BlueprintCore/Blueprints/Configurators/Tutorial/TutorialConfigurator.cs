using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using Kingmaker.PubSubSystem;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.Settings;
using Kingmaker.Tutorial;
using Kingmaker.Tutorial.Solvers;
using Kingmaker.Tutorial.Triggers;
using Kingmaker.UI.Kingdom;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Buffs;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Tutorial
{
  /// <summary>Configurator for <see cref="BlueprintTutorial"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintTutorial))]
  public class TutorialConfigurator : BaseFactConfigurator<BlueprintTutorial, TutorialConfigurator>
  {
     private TutorialConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TutorialConfigurator For(string name)
    {
      return new TutorialConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static TutorialConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintTutorial>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TutorialConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintTutorial>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Adds <see cref="TutorialPage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialPage))]
    public TutorialConfigurator AddTutorialPage(
        SpriteLink m_Picture,
        VideoLink m_Video,
        LocalizedString m_TitleText,
        LocalizedString m_TriggerText,
        LocalizedString m_DescriptionText,
        LocalizedString m_SolutionFoundText,
        LocalizedString m_SolutionNotFoundText)
    {
      ValidateParam(m_Picture);
      ValidateParam(m_Video);
      ValidateParam(m_TitleText);
      ValidateParam(m_TriggerText);
      ValidateParam(m_DescriptionText);
      ValidateParam(m_SolutionFoundText);
      ValidateParam(m_SolutionNotFoundText);
      
      var component =  new TutorialPage();
      component.m_Picture = m_Picture;
      component.m_Video = m_Video;
      component.m_TitleText = m_TitleText;
      component.m_TriggerText = m_TriggerText;
      component.m_DescriptionText = m_DescriptionText;
      component.m_SolutionFoundText = m_SolutionFoundText;
      component.m_SolutionNotFoundText = m_SolutionNotFoundText;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerAbilityDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerAbilityDamage))]
    public TutorialConfigurator AddTutorialTriggerAbilityDamage(
        bool Drain,
        DirectlyControllableUnitRequirement m_DirectlyControllableRequirement)
    {
      ValidateParam(m_DirectlyControllableRequirement);
      
      var component =  new TutorialTriggerAbilityDamage();
      component.Drain = Drain;
      component.m_DirectlyControllableRequirement = m_DirectlyControllableRequirement;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerAffectedByAreaEffect"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerAffectedByAreaEffect))]
    public TutorialConfigurator AddTutorialTriggerAffectedByAreaEffect(
        SpellDescriptorWrapper SpellDescriptors,
        bool NeedAllDescriptors)
    {
      ValidateParam(SpellDescriptors);
      
      var component =  new TutorialTriggerAffectedByAreaEffect();
      component.SpellDescriptors = SpellDescriptors;
      component.NeedAllDescriptors = NeedAllDescriptors;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerArcaneSpellFailure"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerArcaneSpellFailure))]
    public TutorialConfigurator AddTutorialTriggerArcaneSpellFailure(
        DirectlyControllableUnitRequirement m_DirectlyControllableRequirement)
    {
      ValidateParam(m_DirectlyControllableRequirement);
      
      var component =  new TutorialTriggerArcaneSpellFailure();
      component.m_DirectlyControllableRequirement = m_DirectlyControllableRequirement;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerAreaLoaded"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Area"><see cref="BlueprintArea"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerAreaLoaded))]
    public TutorialConfigurator AddTutorialTriggerAreaLoaded(
        string m_Area,
        ConditionsBuilder m_Condition)
    {
      
      var component =  new TutorialTriggerAreaLoaded();
      component.m_Area = BlueprintTool.GetRef<BlueprintAreaReference>(m_Area);
      component.m_Condition = m_Condition.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerArmorCheckPenalty"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerArmorCheckPenalty))]
    public TutorialConfigurator AddTutorialTriggerArmorCheckPenalty(
        float PenaltyTriggerPercent,
        DirectlyControllableUnitRequirement m_DirectlyControllableRequirement)
    {
      ValidateParam(m_DirectlyControllableRequirement);
      
      var component =  new TutorialTriggerArmorCheckPenalty();
      component.PenaltyTriggerPercent = PenaltyTriggerPercent;
      component.m_DirectlyControllableRequirement = m_DirectlyControllableRequirement;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerArmorDexBonusLimiter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerArmorDexBonusLimiter))]
    public TutorialConfigurator AddTutorialTriggerArmorDexBonusLimiter()
    {
      return AddComponent(new TutorialTriggerArmorDexBonusLimiter());
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerAttackFlatFootedTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerAttackFlatFootedTarget))]
    public TutorialConfigurator AddTutorialTriggerAttackFlatFootedTarget(
        DirectlyControllableUnitRequirement m_DirectlyControllableRequirement)
    {
      ValidateParam(m_DirectlyControllableRequirement);
      
      var component =  new TutorialTriggerAttackFlatFootedTarget();
      component.m_DirectlyControllableRequirement = m_DirectlyControllableRequirement;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerAttackOfOpportunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerAttackOfOpportunity))]
    public TutorialConfigurator AddTutorialTriggerAttackOfOpportunity(
        DirectlyControllableUnitRequirement m_DirectlyControllableRequirement)
    {
      ValidateParam(m_DirectlyControllableRequirement);
      
      var component =  new TutorialTriggerAttackOfOpportunity();
      component.m_DirectlyControllableRequirement = m_DirectlyControllableRequirement;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerBuffAttached"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="Buffs"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerBuffAttached))]
    public TutorialConfigurator AddTutorialTriggerBuffAttached(
        SpellDescriptorWrapper TriggerDescriptors,
        bool NeedAllDescriptors,
        bool FromList,
        string[] Buffs)
    {
      ValidateParam(TriggerDescriptors);
      
      var component =  new TutorialTriggerBuffAttached();
      component.TriggerDescriptors = TriggerDescriptors;
      component.NeedAllDescriptors = NeedAllDescriptors;
      component.FromList = FromList;
      component.Buffs = Buffs.Select(bp => BlueprintTool.GetRef<BlueprintBuffReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerCanBuffAlly"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_TriggerAreas"><see cref="BlueprintArea"/></param>
    /// <param name="m_Ability"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerCanBuffAlly))]
    public TutorialConfigurator AddTutorialTriggerCanBuffAlly(
        string[] m_TriggerAreas,
        string m_Ability,
        bool m_CheckTankStat,
        bool m_AllowItemsWithSpell)
    {
      
      var component =  new TutorialTriggerCanBuffAlly();
      component.m_TriggerAreas = m_TriggerAreas.Select(bp => BlueprintTool.GetRef<BlueprintAreaReference>(bp)).ToArray();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(m_Ability);
      component.m_CheckTankStat = m_CheckTankStat;
      component.m_AllowItemsWithSpell = m_AllowItemsWithSpell;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerCanReadScrollByNPC"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Scrolls"><see cref="BlueprintItemEquipmentUsable"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerCanReadScrollByNPC))]
    public TutorialConfigurator AddTutorialTriggerCanReadScrollByNPC(
        string[] m_Scrolls)
    {
      
      var component =  new TutorialTriggerCanReadScrollByNPC();
      component.m_Scrolls = m_Scrolls.Select(bp => BlueprintTool.GetRef<BlueprintItemEquipmentUsableReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerConditionImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerConditionImmunity))]
    public TutorialConfigurator AddTutorialTriggerConditionImmunity()
    {
      return AddComponent(new TutorialTriggerConditionImmunity());
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerCriticalHit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerCriticalHit))]
    public TutorialConfigurator AddTutorialTriggerCriticalHit(
        DirectlyControllableUnitRequirement m_DirectlyControllableRequirement)
    {
      ValidateParam(m_DirectlyControllableRequirement);
      
      var component =  new TutorialTriggerCriticalHit();
      component.m_DirectlyControllableRequirement = m_DirectlyControllableRequirement;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerDamageAllyWithSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerDamageAllyWithSpell))]
    public TutorialConfigurator AddTutorialTriggerDamageAllyWithSpell(
        string[] m_Spells,
        DirectlyControllableUnitRequirement m_DirectlyControllableRequirement)
    {
      ValidateParam(m_DirectlyControllableRequirement);
      
      var component =  new TutorialTriggerDamageAllyWithSpell();
      component.m_Spells = m_Spells.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      component.m_DirectlyControllableRequirement = m_DirectlyControllableRequirement;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerDamageFromWeapon"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerDamageFromWeapon))]
    public TutorialConfigurator AddTutorialTriggerDamageFromWeapon(
        DirectlyControllableUnitRequirement m_DirectlyControllableRequirement,
        bool m_AllowFlatfootedTarget,
        bool m_AllowACTouchAttack,
        bool m_ShowAfterCombat,
        TutorialContext m_SavedContext)
    {
      ValidateParam(m_DirectlyControllableRequirement);
      ValidateParam(m_SavedContext);
      
      var component =  new TutorialTriggerDamageFromWeapon();
      component.m_DirectlyControllableRequirement = m_DirectlyControllableRequirement;
      component.m_AllowFlatfootedTarget = m_AllowFlatfootedTarget;
      component.m_AllowACTouchAttack = m_AllowACTouchAttack;
      component.m_ShowAfterCombat = m_ShowAfterCombat;
      component.m_SavedContext = m_SavedContext;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerDamageReduction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerDamageReduction))]
    public TutorialConfigurator AddTutorialTriggerDamageReduction(
        bool AbsoluteDR,
        DirectlyControllableUnitRequirement m_DirectlyControllableRequirement)
    {
      ValidateParam(m_DirectlyControllableRequirement);
      
      var component =  new TutorialTriggerDamageReduction();
      component.AbsoluteDR = AbsoluteDR;
      component.m_DirectlyControllableRequirement = m_DirectlyControllableRequirement;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerDeathDoor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerDeathDoor))]
    public TutorialConfigurator AddTutorialTriggerDeathDoor()
    {
      return AddComponent(new TutorialTriggerDeathDoor());
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerDialogMythicAnswer"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerDialogMythicAnswer))]
    public TutorialConfigurator AddTutorialTriggerDialogMythicAnswer()
    {
      return AddComponent(new TutorialTriggerDialogMythicAnswer());
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEmptySkillSlotOnRest"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerEmptySkillSlotOnRest))]
    public TutorialConfigurator AddTutorialTriggerEmptySkillSlotOnRest()
    {
      return AddComponent(new TutorialTriggerEmptySkillSlotOnRest());
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnemyHasAnyFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_EnemyFacts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerEnemyHasAnyFact))]
    public TutorialConfigurator AddTutorialTriggerEnemyHasAnyFact(
        string[] m_EnemyFacts)
    {
      
      var component =  new TutorialTriggerEnemyHasAnyFact();
      component.m_EnemyFacts = m_EnemyFacts.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnemyHasBlindsight"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buffs"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerEnemyHasBlindsight))]
    public TutorialConfigurator AddTutorialTriggerEnemyHasBlindsight(
        UnitEntityData m_Unit,
        Buff m_PartyBuff,
        string[] m_Buffs)
    {
      ValidateParam(m_Unit);
      ValidateParam(m_PartyBuff);
      
      var component =  new TutorialTriggerEnemyHasBlindsight();
      component.m_Unit = m_Unit;
      component.m_PartyBuff = m_PartyBuff;
      component.m_Buffs = m_Buffs.Select(bp => BlueprintTool.GetRef<BlueprintBuffReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnemyHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_EnemyFact"><see cref="BlueprintUnitFact"/></param>
    /// <param name="m_Spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerEnemyHasFact))]
    public TutorialConfigurator AddTutorialTriggerEnemyHasFact(
        UnitEntityData m_Unit,
        string m_EnemyFact,
        string[] m_Spells,
        bool m_AllowItemsWithSpell)
    {
      ValidateParam(m_Unit);
      
      var component =  new TutorialTriggerEnemyHasFact();
      component.m_Unit = m_Unit;
      component.m_EnemyFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_EnemyFact);
      component.m_Spells = m_Spells.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      component.m_AllowItemsWithSpell = m_AllowItemsWithSpell;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnemyHasRegeneration"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerEnemyHasRegeneration))]
    public TutorialConfigurator AddTutorialTriggerEnemyHasRegeneration()
    {
      return AddComponent(new TutorialTriggerEnemyHasRegeneration());
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnemyHasVulnerability"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerEnemyHasVulnerability))]
    public TutorialConfigurator AddTutorialTriggerEnemyHasVulnerability(
        string m_Descriptor)
    {
      
      var component =  new TutorialTriggerEnemyHasVulnerability();
      component.m_Descriptor = m_Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnergyDrain"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerEnergyDrain))]
    public TutorialConfigurator AddTutorialTriggerEnergyDrain(
        DirectlyControllableUnitRequirement m_DirectlyControllableRequirement)
    {
      ValidateParam(m_DirectlyControllableRequirement);
      
      var component =  new TutorialTriggerEnergyDrain();
      component.m_DirectlyControllableRequirement = m_DirectlyControllableRequirement;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnergyImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerEnergyImmunity))]
    public TutorialConfigurator AddTutorialTriggerEnergyImmunity(
        bool FromSpell,
        DirectlyControllableUnitRequirement m_DirectlyControllableRequirement)
    {
      ValidateParam(m_DirectlyControllableRequirement);
      
      var component =  new TutorialTriggerEnergyImmunity();
      component.FromSpell = FromSpell;
      component.m_DirectlyControllableRequirement = m_DirectlyControllableRequirement;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnergyResistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerEnergyResistance))]
    public TutorialConfigurator AddTutorialTriggerEnergyResistance(
        bool FromSpell,
        DirectlyControllableUnitRequirement m_DirectlyControllableRequirement)
    {
      ValidateParam(m_DirectlyControllableRequirement);
      
      var component =  new TutorialTriggerEnergyResistance();
      component.FromSpell = FromSpell;
      component.m_DirectlyControllableRequirement = m_DirectlyControllableRequirement;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerExtraAttackAfterLevelUp"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerExtraAttackAfterLevelUp))]
    public TutorialConfigurator AddTutorialTriggerExtraAttackAfterLevelUp(
        UnitEntityData m_TriggerUnit,
        int m_StartPrimaryAttackCount,
        int m_StartSecondaryAttackCount)
    {
      ValidateParam(m_TriggerUnit);
      
      var component =  new TutorialTriggerExtraAttackAfterLevelUp();
      component.m_TriggerUnit = m_TriggerUnit;
      component.m_StartPrimaryAttackCount = m_StartPrimaryAttackCount;
      component.m_StartSecondaryAttackCount = m_StartSecondaryAttackCount;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerFormationChangedBadly"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerFormationChangedBadly))]
    public TutorialConfigurator AddTutorialTriggerFormationChangedBadly(
        bool m_PartyWasChanged,
        int TanksCount,
        float MinTankDistance,
        GameDifficultyOption MaxGameDifficulty)
    {
      ValidateParam(MaxGameDifficulty);
      
      var component =  new TutorialTriggerFormationChangedBadly();
      component.m_PartyWasChanged = m_PartyWasChanged;
      component.TanksCount = TanksCount;
      component.MinTankDistance = MinTankDistance;
      component.MaxGameDifficulty = MaxGameDifficulty;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerHaveBetterEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerHaveBetterEquipment))]
    public TutorialConfigurator AddTutorialTriggerHaveBetterEquipment(
        int MinGradeDiff)
    {
      
      var component =  new TutorialTriggerHaveBetterEquipment();
      component.MinGradeDiff = MinGradeDiff;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerHealEnemyWithSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerHealEnemyWithSpell))]
    public TutorialConfigurator AddTutorialTriggerHealEnemyWithSpell(
        string[] m_Spells,
        DirectlyControllableUnitRequirement m_DirectlyControllableRequirement)
    {
      ValidateParam(m_DirectlyControllableRequirement);
      
      var component =  new TutorialTriggerHealEnemyWithSpell();
      component.m_Spells = m_Spells.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      component.m_DirectlyControllableRequirement = m_DirectlyControllableRequirement;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerHealingScroll"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerHealingScroll))]
    public TutorialConfigurator AddTutorialTriggerHealingScroll(
        float UnitLeftHealthPercent)
    {
      
      var component =  new TutorialTriggerHealingScroll();
      component.UnitLeftHealthPercent = UnitLeftHealthPercent;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerItemIdentificationFailed"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerItemIdentificationFailed))]
    public TutorialConfigurator AddTutorialTriggerItemIdentificationFailed()
    {
      return AddComponent(new TutorialTriggerItemIdentificationFailed());
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerKingdomManagementOpened"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerKingdomManagementOpened))]
    public TutorialConfigurator AddTutorialTriggerKingdomManagementOpened()
    {
      return AddComponent(new TutorialTriggerKingdomManagementOpened());
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerKingdomTabSelected"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerKingdomTabSelected))]
    public TutorialConfigurator AddTutorialTriggerKingdomTabSelected(
        KingdomNavigationType m_Type)
    {
      ValidateParam(m_Type);
      
      var component =  new TutorialTriggerKingdomTabSelected();
      component.m_Type = m_Type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerLowGroupHealth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerLowGroupHealth))]
    public TutorialConfigurator AddTutorialTriggerLowGroupHealth(
        float HealSkillsLeftPercent,
        float AverageGroupHealthPercent)
    {
      
      var component =  new TutorialTriggerLowGroupHealth();
      component.HealSkillsLeftPercent = HealSkillsLeftPercent;
      component.AverageGroupHealthPercent = AverageGroupHealthPercent;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerLowHitPoints"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerLowHitPoints))]
    public TutorialConfigurator AddTutorialTriggerLowHitPoints(
        float Threshold)
    {
      
      var component =  new TutorialTriggerLowHitPoints();
      component.Threshold = Threshold;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerMemorizeSpontaneousSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CharacterClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerMemorizeSpontaneousSpell))]
    public TutorialConfigurator AddTutorialTriggerMemorizeSpontaneousSpell(
        string m_CharacterClass)
    {
      
      var component =  new TutorialTriggerMemorizeSpontaneousSpell();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_CharacterClass);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerMissingPreciseShot"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerMissingPreciseShot))]
    public TutorialConfigurator AddTutorialTriggerMissingPreciseShot(
        DirectlyControllableUnitRequirement m_DirectlyControllableRequirement)
    {
      ValidateParam(m_DirectlyControllableRequirement);
      
      var component =  new TutorialTriggerMissingPreciseShot();
      component.m_DirectlyControllableRequirement = m_DirectlyControllableRequirement;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerMissingTwoWeaponFighting"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerMissingTwoWeaponFighting))]
    public TutorialConfigurator AddTutorialTriggerMissingTwoWeaponFighting()
    {
      return AddComponent(new TutorialTriggerMissingTwoWeaponFighting());
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerMountAnimal"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerMountAnimal))]
    public TutorialConfigurator AddTutorialTriggerMountAnimal()
    {
      return AddComponent(new TutorialTriggerMountAnimal());
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerMultipleUnitsCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerMultipleUnitsCondition))]
    public TutorialConfigurator AddTutorialTriggerMultipleUnitsCondition(
        UnitCondition TriggerCondition,
        int MinimumUnitsCount,
        bool AllowOnGlobalMap)
    {
      ValidateParam(TriggerCondition);
      
      var component =  new TutorialTriggerMultipleUnitsCondition();
      component.TriggerCondition = TriggerCondition;
      component.MinimumUnitsCount = MinimumUnitsCount;
      component.AllowOnGlobalMap = AllowOnGlobalMap;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNewCrusaderArmy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerNewCrusaderArmy))]
    public TutorialConfigurator AddTutorialTriggerNewCrusaderArmy(
        int m_MinimumNumberOfArmies)
    {
      
      var component =  new TutorialTriggerNewCrusaderArmy();
      component.m_MinimumNumberOfArmies = m_MinimumNumberOfArmies;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNewItemWithEnchantment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Enchantment"><see cref="BlueprintItemEnchantment"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerNewItemWithEnchantment))]
    public TutorialConfigurator AddTutorialTriggerNewItemWithEnchantment(
        string m_Enchantment)
    {
      
      var component =  new TutorialTriggerNewItemWithEnchantment();
      component.m_Enchantment = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(m_Enchantment);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNewNotLearnedScroll"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerNewNotLearnedScroll))]
    public TutorialConfigurator AddTutorialTriggerNewNotLearnedScroll()
    {
      return AddComponent(new TutorialTriggerNewNotLearnedScroll());
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNewRecipe"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerNewRecipe))]
    public TutorialConfigurator AddTutorialTriggerNewRecipe()
    {
      return AddComponent(new TutorialTriggerNewRecipe());
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNewRodItem"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerNewRodItem))]
    public TutorialConfigurator AddTutorialTriggerNewRodItem(
        Metamagic TriggerMetamagic)
    {
      ValidateParam(TriggerMetamagic);
      
      var component =  new TutorialTriggerNewRodItem();
      component.TriggerMetamagic = TriggerMetamagic;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNewSpellWithoutRequiredMaterial"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerNewSpellWithoutRequiredMaterial))]
    public TutorialConfigurator AddTutorialTriggerNewSpellWithoutRequiredMaterial()
    {
      return AddComponent(new TutorialTriggerNewSpellWithoutRequiredMaterial());
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNewWand"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerNewWand))]
    public TutorialConfigurator AddTutorialTriggerNewWand(
        string[] m_Spells)
    {
      
      var component =  new TutorialTriggerNewWand();
      component.m_Spells = m_Spells.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNoAutocastSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_RecommendedAbilities"><see cref="BlueprintAbility"/></param>
    /// <param name="m_Companions"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerNoAutocastSpell))]
    public TutorialConfigurator AddTutorialTriggerNoAutocastSpell(
        string[] m_RecommendedAbilities,
        string[] m_Companions)
    {
      
      var component =  new TutorialTriggerNoAutocastSpell();
      component.m_RecommendedAbilities = m_RecommendedAbilities.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      component.m_Companions = m_Companions.Select(bp => BlueprintTool.GetRef<BlueprintUnitReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNonStackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerNonStackBonus))]
    public TutorialConfigurator AddTutorialTriggerNonStackBonus()
    {
      return AddComponent(new TutorialTriggerNonStackBonus());
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerOpenArmyRecruit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerOpenArmyRecruit))]
    public TutorialConfigurator AddTutorialTriggerOpenArmyRecruit()
    {
      return AddComponent(new TutorialTriggerOpenArmyRecruit());
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerOpenRestUI"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerOpenRestUI))]
    public TutorialConfigurator AddTutorialTriggerOpenRestUI()
    {
      return AddComponent(new TutorialTriggerOpenRestUI());
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerPartyEncumbrance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerPartyEncumbrance))]
    public TutorialConfigurator AddTutorialTriggerPartyEncumbrance(
        Encumbrance MinTriggerEncumbrance)
    {
      ValidateParam(MinTriggerEncumbrance);
      
      var component =  new TutorialTriggerPartyEncumbrance();
      component.MinTriggerEncumbrance = MinTriggerEncumbrance;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerSavingThrow"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerSavingThrow))]
    public TutorialConfigurator AddTutorialTriggerSavingThrow()
    {
      return AddComponent(new TutorialTriggerSavingThrow());
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerSkillCheck"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerSkillCheck))]
    public TutorialConfigurator AddTutorialTriggerSkillCheck(
        TutorialTriggerSkillCheck.ResultType m_TriggerOnResult,
        bool SkillRestriction,
        StatType Skill,
        DirectlyControllableUnitRequirement m_DirectlyControllableRequirement)
    {
      ValidateParam(m_TriggerOnResult);
      ValidateParam(Skill);
      ValidateParam(m_DirectlyControllableRequirement);
      
      var component =  new TutorialTriggerSkillCheck();
      component.m_TriggerOnResult = m_TriggerOnResult;
      component.SkillRestriction = SkillRestriction;
      component.Skill = Skill;
      component.m_DirectlyControllableRequirement = m_DirectlyControllableRequirement;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerSneakAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerSneakAttack))]
    public TutorialConfigurator AddTutorialTriggerSneakAttack(
        DirectlyControllableUnitRequirement m_DirectlyControllableRequirement)
    {
      ValidateParam(m_DirectlyControllableRequirement);
      
      var component =  new TutorialTriggerSneakAttack();
      component.m_DirectlyControllableRequirement = m_DirectlyControllableRequirement;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerSpellResistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerSpellResistance))]
    public TutorialConfigurator AddTutorialTriggerSpellResistance(
        TutorialTriggerSpellResistance.Target TriggerTarget,
        SpellDescriptorWrapper Descriptor,
        bool NeedAllDescriptors,
        DirectlyControllableUnitRequirement m_DirectlyControllableRequirement)
    {
      ValidateParam(TriggerTarget);
      ValidateParam(Descriptor);
      ValidateParam(m_DirectlyControllableRequirement);
      
      var component =  new TutorialTriggerSpellResistance();
      component.TriggerTarget = TriggerTarget;
      component.Descriptor = Descriptor;
      component.NeedAllDescriptors = NeedAllDescriptors;
      component.m_DirectlyControllableRequirement = m_DirectlyControllableRequirement;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerTacticalCombatEnd"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerTacticalCombatEnd))]
    public TutorialConfigurator AddTutorialTriggerTacticalCombatEnd(
        bool m_DemonsWon,
        bool m_OnlyGarrison)
    {
      
      var component =  new TutorialTriggerTacticalCombatEnd();
      component.m_DemonsWon = m_DemonsWon;
      component.m_OnlyGarrison = m_OnlyGarrison;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerTacticalCombatStart"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_EnemyUnits"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerTacticalCombatStart))]
    public TutorialConfigurator AddTutorialTriggerTacticalCombatStart(
        bool m_EnemyShouldHaveLeader,
        bool m_SpecifyEnemyUnits,
        bool m_PlayerShouldHaveLeader,
        string[] m_EnemyUnits)
    {
      
      var component =  new TutorialTriggerTacticalCombatStart();
      component.m_EnemyShouldHaveLeader = m_EnemyShouldHaveLeader;
      component.m_SpecifyEnemyUnits = m_SpecifyEnemyUnits;
      component.m_PlayerShouldHaveLeader = m_PlayerShouldHaveLeader;
      component.m_EnemyUnits = m_EnemyUnits.Select(bp => BlueprintTool.GetRef<BlueprintUnitReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerTargetRestriction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerTargetRestriction))]
    public TutorialConfigurator AddTutorialTriggerTargetRestriction()
    {
      return AddComponent(new TutorialTriggerTargetRestriction());
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerTouchAC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerTouchAC))]
    public TutorialConfigurator AddTutorialTriggerTouchAC(
        int TouchACDifference,
        int MissesInRow,
        DirectlyControllableUnitRequirement m_DirectlyControllableRequirement)
    {
      ValidateParam(m_DirectlyControllableRequirement);
      
      var component =  new TutorialTriggerTouchAC();
      component.TouchACDifference = TouchACDifference;
      component.MissesInRow = MissesInRow;
      component.m_DirectlyControllableRequirement = m_DirectlyControllableRequirement;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerTurnBaseModeActivated"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerTurnBaseModeActivated))]
    public TutorialConfigurator AddTutorialTriggerTurnBaseModeActivated()
    {
      return AddComponent(new TutorialTriggerTurnBaseModeActivated());
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerUIEvent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerUIEvent))]
    public TutorialConfigurator AddTutorialTriggerUIEvent(
        UIEventType UIEvent)
    {
      ValidateParam(UIEvent);
      
      var component =  new TutorialTriggerUIEvent();
      component.UIEvent = UIEvent;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerUnitCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerUnitCondition))]
    public TutorialConfigurator AddTutorialTriggerUnitCondition(
        UnitCondition TriggerCondition)
    {
      ValidateParam(TriggerCondition);
      
      var component =  new TutorialTriggerUnitCondition();
      component.TriggerCondition = TriggerCondition;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerUnitDeath"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerUnitDeath))]
    public TutorialConfigurator AddTutorialTriggerUnitDeath(
        bool IsPet)
    {
      
      var component =  new TutorialTriggerUnitDeath();
      component.IsPet = IsPet;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerUnitDiedWithoutBardPerformance"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Performances"><see cref="BlueprintActivatableAbility"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerUnitDiedWithoutBardPerformance))]
    public TutorialConfigurator AddTutorialTriggerUnitDiedWithoutBardPerformance(
        string[] m_Performances)
    {
      
      var component =  new TutorialTriggerUnitDiedWithoutBardPerformance();
      component.m_Performances = m_Performances.Select(bp => BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerUnitEncumbrance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerUnitEncumbrance))]
    public TutorialConfigurator AddTutorialTriggerUnitEncumbrance(
        Encumbrance MinTriggerEncumbrance)
    {
      ValidateParam(MinTriggerEncumbrance);
      
      var component =  new TutorialTriggerUnitEncumbrance();
      component.MinTriggerEncumbrance = MinTriggerEncumbrance;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerUnitLostAlignmentFeature"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerUnitLostAlignmentFeature))]
    public TutorialConfigurator AddTutorialTriggerUnitLostAlignmentFeature()
    {
      return AddComponent(new TutorialTriggerUnitLostAlignmentFeature());
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerUnitWithSneakAttackJoinParty"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerUnitWithSneakAttackJoinParty))]
    public TutorialConfigurator AddTutorialTriggerUnitWithSneakAttackJoinParty()
    {
      return AddComponent(new TutorialTriggerUnitWithSneakAttackJoinParty());
    }

    /// <summary>
    /// Adds <see cref="TutorialSolverAllFromTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialSolverAllFromTrigger))]
    public TutorialConfigurator AddTutorialSolverAllFromTrigger()
    {
      return AddComponent(new TutorialSolverAllFromTrigger());
    }

    /// <summary>
    /// Adds <see cref="TutorialSolverBestWeaponAgainstTarget"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Enchantments"><see cref="BlueprintWeaponEnchantment"/></param>
    [Generated]
    [Implements(typeof(TutorialSolverBestWeaponAgainstTarget))]
    public TutorialConfigurator AddTutorialSolverBestWeaponAgainstTarget(
        bool CheckRegeneration,
        bool CheckEnchantment,
        string[] m_Enchantments)
    {
      
      var component =  new TutorialSolverBestWeaponAgainstTarget();
      component.CheckRegeneration = CheckRegeneration;
      component.CheckEnchantment = CheckEnchantment;
      component.m_Enchantments = m_Enchantments.Select(bp => BlueprintTool.GetRef<BlueprintWeaponEnchantmentReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialSolverItemFromTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialSolverItemFromTrigger))]
    public TutorialConfigurator AddTutorialSolverItemFromTrigger()
    {
      return AddComponent(new TutorialSolverItemFromTrigger());
    }

    /// <summary>
    /// Adds <see cref="TutorialSolverSpellFromList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(TutorialSolverSpellFromList))]
    public TutorialConfigurator AddTutorialSolverSpellFromList(
        string[] m_Spells,
        bool AllowItems)
    {
      
      var component =  new TutorialSolverSpellFromList();
      component.m_Spells = m_Spells.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      component.AllowItems = AllowItems;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialSolverSpellWithDamage"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="IgnoredSpells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(TutorialSolverSpellWithDamage))]
    public TutorialConfigurator AddTutorialSolverSpellWithDamage(
        bool CheckRegeneration,
        bool CheckVulnerability,
        AttackTypeFlag AttackType,
        bool OnlyAoE,
        bool UseDescriptor,
        SpellDescriptorWrapper SpellDescriptor,
        bool NeedAllDescriptors,
        string[] IgnoredSpells,
        bool AllowItems)
    {
      ValidateParam(AttackType);
      ValidateParam(SpellDescriptor);
      
      var component =  new TutorialSolverSpellWithDamage();
      component.CheckRegeneration = CheckRegeneration;
      component.CheckVulnerability = CheckVulnerability;
      component.AttackType = AttackType;
      component.OnlyAoE = OnlyAoE;
      component.UseDescriptor = UseDescriptor;
      component.SpellDescriptor = SpellDescriptor;
      component.NeedAllDescriptors = NeedAllDescriptors;
      component.IgnoredSpells = IgnoredSpells.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToList();
      component.AllowItems = AllowItems;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialSolverSpellWithDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialSolverSpellWithDescriptor))]
    public TutorialConfigurator AddTutorialSolverSpellWithDescriptor(
        SpellDescriptorWrapper SpellDescriptors,
        bool NeedAllDescriptors,
        bool ExcludeOnlySelfTarget,
        bool AllowItems)
    {
      ValidateParam(SpellDescriptors);
      
      var component =  new TutorialSolverSpellWithDescriptor();
      component.SpellDescriptors = SpellDescriptors;
      component.NeedAllDescriptors = NeedAllDescriptors;
      component.ExcludeOnlySelfTarget = ExcludeOnlySelfTarget;
      component.AllowItems = AllowItems;
      return AddComponent(component);
    }
  }
}
