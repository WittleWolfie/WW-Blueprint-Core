using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.ElementsSystem;
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
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Tutorial
{
  /// <summary>
  /// Configurator for <see cref="BlueprintTutorial"/>.
  /// </summary>
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
    public static TutorialConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintTutorial>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.m_Picture"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetPicture(SpriteLink picture)
    {
      ValidateParam(picture);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Picture = picture;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.m_Video"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetVideo(VideoLink video)
    {
      ValidateParam(video);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Video = video;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.m_TitleText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetTitleText(LocalizedString titleText)
    {
      ValidateParam(titleText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_TitleText = titleText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.m_TriggerText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetTriggerText(LocalizedString triggerText)
    {
      ValidateParam(triggerText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_TriggerText = triggerText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.m_DescriptionText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetDescriptionText(LocalizedString descriptionText)
    {
      ValidateParam(descriptionText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DescriptionText = descriptionText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.m_SolutionFoundText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetSolutionFoundText(LocalizedString solutionFoundText)
    {
      ValidateParam(solutionFoundText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SolutionFoundText = solutionFoundText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.m_SolutionNotFoundText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetSolutionNotFoundText(LocalizedString solutionNotFoundText)
    {
      ValidateParam(solutionNotFoundText);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_SolutionNotFoundText = solutionNotFoundText ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.Tag"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetTag(TutorialTag tag)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Tag = tag;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.Priority"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetPriority(int priority)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Priority = priority;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.Limit"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetLimit(int limit)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Limit = limit;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.Frequency"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetFrequency(int frequency)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Frequency = frequency;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.SetCooldown"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetCooldown(bool setCooldown)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SetCooldown = setCooldown;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.IgnoreCooldown"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetIgnoreCooldown(bool ignoreCooldown)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IgnoreCooldown = ignoreCooldown;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.Windowed"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetWindowed(bool windowed)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Windowed = windowed;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.DisableAnalyticsTracking"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TutorialConfigurator SetDisableAnalyticsTracking(bool disableAnalyticsTracking)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.DisableAnalyticsTracking = disableAnalyticsTracking;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintTutorial.EncyclopediaReference"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="encyclopediaReference"><see cref="BlueprintEncyclopediaPage"/></param>
    [Generated]
    public TutorialConfigurator SetEncyclopediaReference(string encyclopediaReference)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.EncyclopediaReference = BlueprintTool.GetRef<BlueprintEncyclopediaPageReference>(encyclopediaReference);
          });
    }

    /// <summary>
    /// Adds <see cref="TutorialPage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialPage))]
    public TutorialConfigurator AddTutorialPage(
        SpriteLink picture,
        VideoLink video,
        LocalizedString titleText = null,
        LocalizedString triggerText = null,
        LocalizedString descriptionText = null,
        LocalizedString solutionFoundText = null,
        LocalizedString solutionNotFoundText = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(picture);
      ValidateParam(video);
      ValidateParam(titleText);
      ValidateParam(triggerText);
      ValidateParam(descriptionText);
      ValidateParam(solutionFoundText);
      ValidateParam(solutionNotFoundText);
    
      var component = new TutorialPage();
      component.m_Picture = picture;
      component.m_Video = video;
      component.m_TitleText = titleText ?? Constants.Empty.String;
      component.m_TriggerText = triggerText ?? Constants.Empty.String;
      component.m_DescriptionText = descriptionText ?? Constants.Empty.String;
      component.m_SolutionFoundText = solutionFoundText ?? Constants.Empty.String;
      component.m_SolutionNotFoundText = solutionNotFoundText ?? Constants.Empty.String;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerAbilityDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerAbilityDamage))]
    public TutorialConfigurator AddTutorialTriggerAbilityDamage(
        bool drain = default,
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerAbilityDamage();
      component.Drain = drain;
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerAffectedByAreaEffect"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerAffectedByAreaEffect))]
    public TutorialConfigurator AddTutorialTriggerAffectedByAreaEffect(
        SpellDescriptorWrapper spellDescriptors,
        bool needAllDescriptors = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerAffectedByAreaEffect();
      component.SpellDescriptors = spellDescriptors;
      component.NeedAllDescriptors = needAllDescriptors;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerArcaneSpellFailure"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerArcaneSpellFailure))]
    public TutorialConfigurator AddTutorialTriggerArcaneSpellFailure(
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerArcaneSpellFailure();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerAreaLoaded"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="area"><see cref="BlueprintArea"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerAreaLoaded))]
    public TutorialConfigurator AddTutorialTriggerAreaLoaded(
        string area = null,
        ConditionsBuilder condition = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerAreaLoaded();
      component.m_Area = BlueprintTool.GetRef<BlueprintAreaReference>(area);
      component.m_Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerArmorCheckPenalty"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerArmorCheckPenalty))]
    public TutorialConfigurator AddTutorialTriggerArmorCheckPenalty(
        float penaltyTriggerPercent = default,
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerArmorCheckPenalty();
      component.PenaltyTriggerPercent = penaltyTriggerPercent;
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerArmorDexBonusLimiter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerArmorDexBonusLimiter))]
    public TutorialConfigurator AddTutorialTriggerArmorDexBonusLimiter(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerArmorDexBonusLimiter();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerAttackFlatFootedTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerAttackFlatFootedTarget))]
    public TutorialConfigurator AddTutorialTriggerAttackFlatFootedTarget(
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerAttackFlatFootedTarget();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerAttackOfOpportunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerAttackOfOpportunity))]
    public TutorialConfigurator AddTutorialTriggerAttackOfOpportunity(
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerAttackOfOpportunity();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerBuffAttached"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buffs"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerBuffAttached))]
    public TutorialConfigurator AddTutorialTriggerBuffAttached(
        SpellDescriptorWrapper triggerDescriptors,
        bool needAllDescriptors = default,
        bool fromList = default,
        string[] buffs = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerBuffAttached();
      component.TriggerDescriptors = triggerDescriptors;
      component.NeedAllDescriptors = needAllDescriptors;
      component.FromList = fromList;
      component.Buffs = buffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerCanBuffAlly"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="triggerAreas"><see cref="BlueprintArea"/></param>
    /// <param name="ability"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerCanBuffAlly))]
    public TutorialConfigurator AddTutorialTriggerCanBuffAlly(
        string[] triggerAreas = null,
        string ability = null,
        bool checkTankStat = default,
        bool allowItemsWithSpell = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerCanBuffAlly();
      component.m_TriggerAreas = triggerAreas.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name)).ToArray();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      component.m_CheckTankStat = checkTankStat;
      component.m_AllowItemsWithSpell = allowItemsWithSpell;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerCanReadScrollByNPC"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="scrolls"><see cref="BlueprintItemEquipmentUsable"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerCanReadScrollByNPC))]
    public TutorialConfigurator AddTutorialTriggerCanReadScrollByNPC(
        string[] scrolls = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerCanReadScrollByNPC();
      component.m_Scrolls = scrolls.Select(name => BlueprintTool.GetRef<BlueprintItemEquipmentUsableReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerConditionImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerConditionImmunity))]
    public TutorialConfigurator AddTutorialTriggerConditionImmunity(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerConditionImmunity();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerCriticalHit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerCriticalHit))]
    public TutorialConfigurator AddTutorialTriggerCriticalHit(
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerCriticalHit();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerDamageAllyWithSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerDamageAllyWithSpell))]
    public TutorialConfigurator AddTutorialTriggerDamageAllyWithSpell(
        string[] spells = null,
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerDamageAllyWithSpell();
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerDamageFromWeapon"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerDamageFromWeapon))]
    public TutorialConfigurator AddTutorialTriggerDamageFromWeapon(
        TutorialContext savedContext,
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        bool allowFlatfootedTarget = default,
        bool allowACTouchAttack = default,
        bool showAfterCombat = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(savedContext);
    
      var component = new TutorialTriggerDamageFromWeapon();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      component.m_AllowFlatfootedTarget = allowFlatfootedTarget;
      component.m_AllowACTouchAttack = allowACTouchAttack;
      component.m_ShowAfterCombat = showAfterCombat;
      component.m_SavedContext = savedContext;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerDamageReduction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerDamageReduction))]
    public TutorialConfigurator AddTutorialTriggerDamageReduction(
        bool absoluteDR = default,
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerDamageReduction();
      component.AbsoluteDR = absoluteDR;
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerDeathDoor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerDeathDoor))]
    public TutorialConfigurator AddTutorialTriggerDeathDoor(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerDeathDoor();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerDialogMythicAnswer"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerDialogMythicAnswer))]
    public TutorialConfigurator AddTutorialTriggerDialogMythicAnswer(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerDialogMythicAnswer();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEmptySkillSlotOnRest"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerEmptySkillSlotOnRest))]
    public TutorialConfigurator AddTutorialTriggerEmptySkillSlotOnRest(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerEmptySkillSlotOnRest();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnemyHasAnyFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enemyFacts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerEnemyHasAnyFact))]
    public TutorialConfigurator AddTutorialTriggerEnemyHasAnyFact(
        string[] enemyFacts = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerEnemyHasAnyFact();
      component.m_EnemyFacts = enemyFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnemyHasBlindsight"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buffs"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerEnemyHasBlindsight))]
    public TutorialConfigurator AddTutorialTriggerEnemyHasBlindsight(
        UnitEntityData unit,
        Buff partyBuff,
        string[] buffs = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(unit);
      ValidateParam(partyBuff);
    
      var component = new TutorialTriggerEnemyHasBlindsight();
      component.m_Unit = unit;
      component.m_PartyBuff = partyBuff;
      component.m_Buffs = buffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnemyHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enemyFact"><see cref="BlueprintUnitFact"/></param>
    /// <param name="spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerEnemyHasFact))]
    public TutorialConfigurator AddTutorialTriggerEnemyHasFact(
        UnitEntityData unit,
        string enemyFact = null,
        string[] spells = null,
        bool allowItemsWithSpell = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(unit);
    
      var component = new TutorialTriggerEnemyHasFact();
      component.m_Unit = unit;
      component.m_EnemyFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(enemyFact);
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_AllowItemsWithSpell = allowItemsWithSpell;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnemyHasRegeneration"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerEnemyHasRegeneration))]
    public TutorialConfigurator AddTutorialTriggerEnemyHasRegeneration(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerEnemyHasRegeneration();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnemyHasVulnerability"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerEnemyHasVulnerability))]
    public TutorialConfigurator AddTutorialTriggerEnemyHasVulnerability(
        string descriptor,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerEnemyHasVulnerability();
      component.m_Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnergyDrain"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerEnergyDrain))]
    public TutorialConfigurator AddTutorialTriggerEnergyDrain(
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerEnergyDrain();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnergyImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerEnergyImmunity))]
    public TutorialConfigurator AddTutorialTriggerEnergyImmunity(
        bool fromSpell = default,
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerEnergyImmunity();
      component.FromSpell = fromSpell;
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnergyResistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerEnergyResistance))]
    public TutorialConfigurator AddTutorialTriggerEnergyResistance(
        bool fromSpell = default,
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerEnergyResistance();
      component.FromSpell = fromSpell;
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerExtraAttackAfterLevelUp"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerExtraAttackAfterLevelUp))]
    public TutorialConfigurator AddTutorialTriggerExtraAttackAfterLevelUp(
        UnitEntityData triggerUnit,
        int startPrimaryAttackCount = default,
        int startSecondaryAttackCount = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(triggerUnit);
    
      var component = new TutorialTriggerExtraAttackAfterLevelUp();
      component.m_TriggerUnit = triggerUnit;
      component.m_StartPrimaryAttackCount = startPrimaryAttackCount;
      component.m_StartSecondaryAttackCount = startSecondaryAttackCount;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerFormationChangedBadly"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerFormationChangedBadly))]
    public TutorialConfigurator AddTutorialTriggerFormationChangedBadly(
        bool partyWasChanged = default,
        int tanksCount = default,
        float minTankDistance = default,
        GameDifficultyOption maxGameDifficulty = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerFormationChangedBadly();
      component.m_PartyWasChanged = partyWasChanged;
      component.TanksCount = tanksCount;
      component.MinTankDistance = minTankDistance;
      component.MaxGameDifficulty = maxGameDifficulty;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerHaveBetterEquipment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerHaveBetterEquipment))]
    public TutorialConfigurator AddTutorialTriggerHaveBetterEquipment(
        int minGradeDiff = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerHaveBetterEquipment();
      component.MinGradeDiff = minGradeDiff;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerHealEnemyWithSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerHealEnemyWithSpell))]
    public TutorialConfigurator AddTutorialTriggerHealEnemyWithSpell(
        string[] spells = null,
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerHealEnemyWithSpell();
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerHealingScroll"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerHealingScroll))]
    public TutorialConfigurator AddTutorialTriggerHealingScroll(
        float unitLeftHealthPercent = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerHealingScroll();
      component.UnitLeftHealthPercent = unitLeftHealthPercent;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerItemIdentificationFailed"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerItemIdentificationFailed))]
    public TutorialConfigurator AddTutorialTriggerItemIdentificationFailed(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerItemIdentificationFailed();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerKingdomManagementOpened"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerKingdomManagementOpened))]
    public TutorialConfigurator AddTutorialTriggerKingdomManagementOpened(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerKingdomManagementOpened();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerKingdomTabSelected"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerKingdomTabSelected))]
    public TutorialConfigurator AddTutorialTriggerKingdomTabSelected(
        KingdomNavigationType type = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerKingdomTabSelected();
      component.m_Type = type;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerLowGroupHealth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerLowGroupHealth))]
    public TutorialConfigurator AddTutorialTriggerLowGroupHealth(
        float healSkillsLeftPercent = default,
        float averageGroupHealthPercent = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerLowGroupHealth();
      component.HealSkillsLeftPercent = healSkillsLeftPercent;
      component.AverageGroupHealthPercent = averageGroupHealthPercent;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerLowHitPoints"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerLowHitPoints))]
    public TutorialConfigurator AddTutorialTriggerLowHitPoints(
        float threshold = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerLowHitPoints();
      component.Threshold = threshold;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerMemorizeSpontaneousSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerMemorizeSpontaneousSpell))]
    public TutorialConfigurator AddTutorialTriggerMemorizeSpontaneousSpell(
        string characterClass = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerMemorizeSpontaneousSpell();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerMissingPreciseShot"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerMissingPreciseShot))]
    public TutorialConfigurator AddTutorialTriggerMissingPreciseShot(
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerMissingPreciseShot();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerMissingTwoWeaponFighting"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerMissingTwoWeaponFighting))]
    public TutorialConfigurator AddTutorialTriggerMissingTwoWeaponFighting(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerMissingTwoWeaponFighting();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerMountAnimal"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerMountAnimal))]
    public TutorialConfigurator AddTutorialTriggerMountAnimal(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerMountAnimal();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerMultipleUnitsCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerMultipleUnitsCondition))]
    public TutorialConfigurator AddTutorialTriggerMultipleUnitsCondition(
        UnitCondition triggerCondition = default,
        int minimumUnitsCount = default,
        bool allowOnGlobalMap = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerMultipleUnitsCondition();
      component.TriggerCondition = triggerCondition;
      component.MinimumUnitsCount = minimumUnitsCount;
      component.AllowOnGlobalMap = allowOnGlobalMap;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNewCrusaderArmy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerNewCrusaderArmy))]
    public TutorialConfigurator AddTutorialTriggerNewCrusaderArmy(
        int minimumNumberOfArmies = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerNewCrusaderArmy();
      component.m_MinimumNumberOfArmies = minimumNumberOfArmies;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNewItemWithEnchantment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantment"><see cref="BlueprintItemEnchantment"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerNewItemWithEnchantment))]
    public TutorialConfigurator AddTutorialTriggerNewItemWithEnchantment(
        string enchantment = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerNewItemWithEnchantment();
      component.m_Enchantment = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(enchantment);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNewNotLearnedScroll"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerNewNotLearnedScroll))]
    public TutorialConfigurator AddTutorialTriggerNewNotLearnedScroll(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerNewNotLearnedScroll();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNewRecipe"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerNewRecipe))]
    public TutorialConfigurator AddTutorialTriggerNewRecipe(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerNewRecipe();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNewRodItem"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerNewRodItem))]
    public TutorialConfigurator AddTutorialTriggerNewRodItem(
        Metamagic triggerMetamagic = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerNewRodItem();
      component.TriggerMetamagic = triggerMetamagic;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNewSpellWithoutRequiredMaterial"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerNewSpellWithoutRequiredMaterial))]
    public TutorialConfigurator AddTutorialTriggerNewSpellWithoutRequiredMaterial(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerNewSpellWithoutRequiredMaterial();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNewWand"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerNewWand))]
    public TutorialConfigurator AddTutorialTriggerNewWand(
        string[] spells = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerNewWand();
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNoAutocastSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="recommendedAbilities"><see cref="BlueprintAbility"/></param>
    /// <param name="companions"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerNoAutocastSpell))]
    public TutorialConfigurator AddTutorialTriggerNoAutocastSpell(
        string[] recommendedAbilities = null,
        string[] companions = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerNoAutocastSpell();
      component.m_RecommendedAbilities = recommendedAbilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_Companions = companions.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNonStackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerNonStackBonus))]
    public TutorialConfigurator AddTutorialTriggerNonStackBonus(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerNonStackBonus();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerOpenArmyRecruit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerOpenArmyRecruit))]
    public TutorialConfigurator AddTutorialTriggerOpenArmyRecruit(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerOpenArmyRecruit();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerOpenRestUI"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerOpenRestUI))]
    public TutorialConfigurator AddTutorialTriggerOpenRestUI(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerOpenRestUI();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerPartyEncumbrance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerPartyEncumbrance))]
    public TutorialConfigurator AddTutorialTriggerPartyEncumbrance(
        Encumbrance minTriggerEncumbrance = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerPartyEncumbrance();
      component.MinTriggerEncumbrance = minTriggerEncumbrance;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerSavingThrow"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerSavingThrow))]
    public TutorialConfigurator AddTutorialTriggerSavingThrow(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerSavingThrow();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerSkillCheck"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerSkillCheck))]
    public TutorialConfigurator AddTutorialTriggerSkillCheck(
        TutorialTriggerSkillCheck.ResultType triggerOnResult = default,
        bool skillRestriction = default,
        StatType skill = default,
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerSkillCheck();
      component.m_TriggerOnResult = triggerOnResult;
      component.SkillRestriction = skillRestriction;
      component.Skill = skill;
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerSneakAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerSneakAttack))]
    public TutorialConfigurator AddTutorialTriggerSneakAttack(
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerSneakAttack();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerSpellResistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerSpellResistance))]
    public TutorialConfigurator AddTutorialTriggerSpellResistance(
        SpellDescriptorWrapper descriptor,
        TutorialTriggerSpellResistance.Target triggerTarget = default,
        bool needAllDescriptors = default,
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerSpellResistance();
      component.TriggerTarget = triggerTarget;
      component.Descriptor = descriptor;
      component.NeedAllDescriptors = needAllDescriptors;
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerTacticalCombatEnd"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerTacticalCombatEnd))]
    public TutorialConfigurator AddTutorialTriggerTacticalCombatEnd(
        bool demonsWon = default,
        bool onlyGarrison = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerTacticalCombatEnd();
      component.m_DemonsWon = demonsWon;
      component.m_OnlyGarrison = onlyGarrison;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerTacticalCombatStart"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enemyUnits"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerTacticalCombatStart))]
    public TutorialConfigurator AddTutorialTriggerTacticalCombatStart(
        bool enemyShouldHaveLeader = default,
        bool specifyEnemyUnits = default,
        bool playerShouldHaveLeader = default,
        string[] enemyUnits = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerTacticalCombatStart();
      component.m_EnemyShouldHaveLeader = enemyShouldHaveLeader;
      component.m_SpecifyEnemyUnits = specifyEnemyUnits;
      component.m_PlayerShouldHaveLeader = playerShouldHaveLeader;
      component.m_EnemyUnits = enemyUnits.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerTargetRestriction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerTargetRestriction))]
    public TutorialConfigurator AddTutorialTriggerTargetRestriction(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerTargetRestriction();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerTouchAC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerTouchAC))]
    public TutorialConfigurator AddTutorialTriggerTouchAC(
        int touchACDifference = default,
        int missesInRow = default,
        DirectlyControllableUnitRequirement directlyControllableRequirement = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerTouchAC();
      component.TouchACDifference = touchACDifference;
      component.MissesInRow = missesInRow;
      component.m_DirectlyControllableRequirement = directlyControllableRequirement;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerTurnBaseModeActivated"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerTurnBaseModeActivated))]
    public TutorialConfigurator AddTutorialTriggerTurnBaseModeActivated(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerTurnBaseModeActivated();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerUIEvent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerUIEvent))]
    public TutorialConfigurator AddTutorialTriggerUIEvent(
        UIEventType uIEvent = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerUIEvent();
      component.UIEvent = uIEvent;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerUnitCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerUnitCondition))]
    public TutorialConfigurator AddTutorialTriggerUnitCondition(
        UnitCondition triggerCondition = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerUnitCondition();
      component.TriggerCondition = triggerCondition;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerUnitDeath"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerUnitDeath))]
    public TutorialConfigurator AddTutorialTriggerUnitDeath(
        bool isPet = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerUnitDeath();
      component.IsPet = isPet;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerUnitDiedWithoutBardPerformance"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="performances"><see cref="BlueprintActivatableAbility"/></param>
    [Generated]
    [Implements(typeof(TutorialTriggerUnitDiedWithoutBardPerformance))]
    public TutorialConfigurator AddTutorialTriggerUnitDiedWithoutBardPerformance(
        string[] performances = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerUnitDiedWithoutBardPerformance();
      component.m_Performances = performances.Select(name => BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerUnitEncumbrance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerUnitEncumbrance))]
    public TutorialConfigurator AddTutorialTriggerUnitEncumbrance(
        Encumbrance minTriggerEncumbrance = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerUnitEncumbrance();
      component.MinTriggerEncumbrance = minTriggerEncumbrance;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerUnitLostAlignmentFeature"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerUnitLostAlignmentFeature))]
    public TutorialConfigurator AddTutorialTriggerUnitLostAlignmentFeature(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerUnitLostAlignmentFeature();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerUnitWithSneakAttackJoinParty"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialTriggerUnitWithSneakAttackJoinParty))]
    public TutorialConfigurator AddTutorialTriggerUnitWithSneakAttackJoinParty(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialTriggerUnitWithSneakAttackJoinParty();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialSolverAllFromTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialSolverAllFromTrigger))]
    public TutorialConfigurator AddTutorialSolverAllFromTrigger(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialSolverAllFromTrigger();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialSolverBestWeaponAgainstTarget"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantments"><see cref="BlueprintWeaponEnchantment"/></param>
    [Generated]
    [Implements(typeof(TutorialSolverBestWeaponAgainstTarget))]
    public TutorialConfigurator AddTutorialSolverBestWeaponAgainstTarget(
        bool checkRegeneration = default,
        bool checkEnchantment = default,
        string[] enchantments = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialSolverBestWeaponAgainstTarget();
      component.CheckRegeneration = checkRegeneration;
      component.CheckEnchantment = checkEnchantment;
      component.m_Enchantments = enchantments.Select(name => BlueprintTool.GetRef<BlueprintWeaponEnchantmentReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialSolverItemFromTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialSolverItemFromTrigger))]
    public TutorialConfigurator AddTutorialSolverItemFromTrigger(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialSolverItemFromTrigger();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialSolverSpellFromList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(TutorialSolverSpellFromList))]
    public TutorialConfigurator AddTutorialSolverSpellFromList(
        string[] spells = null,
        bool allowItems = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialSolverSpellFromList();
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.AllowItems = allowItems;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialSolverSpellWithDamage"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ignoredSpells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(TutorialSolverSpellWithDamage))]
    public TutorialConfigurator AddTutorialSolverSpellWithDamage(
        SpellDescriptorWrapper spellDescriptor,
        bool checkRegeneration = default,
        bool checkVulnerability = default,
        AttackTypeFlag attackType = default,
        bool onlyAoE = default,
        bool useDescriptor = default,
        bool needAllDescriptors = default,
        string[] ignoredSpells = null,
        bool allowItems = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialSolverSpellWithDamage();
      component.CheckRegeneration = checkRegeneration;
      component.CheckVulnerability = checkVulnerability;
      component.AttackType = attackType;
      component.OnlyAoE = onlyAoE;
      component.UseDescriptor = useDescriptor;
      component.SpellDescriptor = spellDescriptor;
      component.NeedAllDescriptors = needAllDescriptors;
      component.IgnoredSpells = ignoredSpells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToList();
      component.AllowItems = allowItems;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialSolverSpellWithDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TutorialSolverSpellWithDescriptor))]
    public TutorialConfigurator AddTutorialSolverSpellWithDescriptor(
        SpellDescriptorWrapper spellDescriptors,
        bool needAllDescriptors = default,
        bool excludeOnlySelfTarget = default,
        bool allowItems = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TutorialSolverSpellWithDescriptor();
      component.SpellDescriptors = spellDescriptors;
      component.NeedAllDescriptors = needAllDescriptors;
      component.ExcludeOnlySelfTarget = excludeOnlySelfTarget;
      component.AllowItems = allowItems;
      component.m_Flags = flags;
      return AddComponent(component);
    }
  }
}
