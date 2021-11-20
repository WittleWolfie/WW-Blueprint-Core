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
using Kingmaker.Blueprints.Items;
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
  /// <summary>
  /// Configurator for <see cref="BlueprintUnit"/>.
  /// </summary>
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
    public static UnitConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintUnit>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.m_Type"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="type"><see cref="BlueprintUnitType"/></param>
    [Generated]
    public UnitConfigurator SetType(string type)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Type = BlueprintTool.GetRef<BlueprintUnitTypeReference>(type);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.LocalizedName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetLocalizedName(SharedStringAsset localizedName)
    {
      ValidateParam(localizedName);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.LocalizedName = localizedName;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Gender"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetGender(Gender gender)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Gender = gender;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Size"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetSize(Size size)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Size = size;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.IsLeftHanded"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetIsLeftHanded(bool isLeftHanded)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsLeftHanded = isLeftHanded;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Color"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetColor(Color color)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Color = color;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.m_Race"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="race"><see cref="BlueprintRace"/></param>
    [Generated]
    public UnitConfigurator SetRace(string race)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Race = BlueprintTool.GetRef<BlueprintRaceReference>(race);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Alignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetAlignment(Alignment alignment)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Alignment = alignment;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.m_Portrait"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="portrait"><see cref="BlueprintPortrait"/></param>
    [Generated]
    public UnitConfigurator SetPortrait(string portrait)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Portrait = BlueprintTool.GetRef<BlueprintPortraitReference>(portrait);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Prefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetPrefab(UnitViewLink prefab)
    {
      ValidateParam(prefab);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Prefab = prefab;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.m_CustomizationPreset"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="customizationPreset"><see cref="UnitCustomizationPreset"/></param>
    [Generated]
    public UnitConfigurator SetCustomizationPreset(string customizationPreset)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CustomizationPreset = BlueprintTool.GetRef<UnitCustomizationPresetReference>(customizationPreset);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.m_RandomParameters"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="randomParameters"><see cref="RandomParameters"/></param>
    [Generated]
    public UnitConfigurator SetRandomParameters(string randomParameters)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_RandomParameters = BlueprintTool.GetRef<RandomParametersReference>(randomParameters);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Visual"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetVisual(UnitVisualParams visual)
    {
      ValidateParam(visual);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Visual = visual;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.m_Faction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="faction"><see cref="BlueprintFaction"/></param>
    [Generated]
    public UnitConfigurator SetFaction(string faction)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Faction = BlueprintTool.GetRef<BlueprintFactionReference>(faction);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.FactionOverrides"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetFactionOverrides(FactionOverrides factionOverrides)
    {
      ValidateParam(factionOverrides);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.FactionOverrides = factionOverrides;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.m_StartingInventory"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startingInventory"><see cref="BlueprintItem"/></param>
    [Generated]
    public UnitConfigurator SetStartingInventory(string[] startingInventory)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_StartingInventory = startingInventory.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintUnit.m_StartingInventory"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startingInventory"><see cref="BlueprintItem"/></param>
    [Generated]
    public UnitConfigurator AddToStartingInventory(params string[] startingInventory)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_StartingInventory = CommonTool.Append(bp.m_StartingInventory, startingInventory.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintUnit.m_StartingInventory"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startingInventory"><see cref="BlueprintItem"/></param>
    [Generated]
    public UnitConfigurator RemoveFromStartingInventory(params string[] startingInventory)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = startingInventory.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name));
            bp.m_StartingInventory =
                bp.m_StartingInventory
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.m_Brain"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="brain"><see cref="BlueprintBrain"/></param>
    [Generated]
    public UnitConfigurator SetBrain(string brain)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Brain = BlueprintTool.GetRef<BlueprintBrainReference>(brain);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.AlternativeBrains"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="alternativeBrains"><see cref="BlueprintBrain"/></param>
    [Generated]
    public UnitConfigurator SetAlternativeBrains(string[] alternativeBrains)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AlternativeBrains = alternativeBrains.Select(name => BlueprintTool.GetRef<BlueprintBrainReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintUnit.AlternativeBrains"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="alternativeBrains"><see cref="BlueprintBrain"/></param>
    [Generated]
    public UnitConfigurator AddToAlternativeBrains(params string[] alternativeBrains)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AlternativeBrains = CommonTool.Append(bp.AlternativeBrains, alternativeBrains.Select(name => BlueprintTool.GetRef<BlueprintBrainReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintUnit.AlternativeBrains"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="alternativeBrains"><see cref="BlueprintBrain"/></param>
    [Generated]
    public UnitConfigurator RemoveFromAlternativeBrains(params string[] alternativeBrains)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = alternativeBrains.Select(name => BlueprintTool.GetRef<BlueprintBrainReference>(name));
            bp.AlternativeBrains =
                bp.AlternativeBrains
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Body"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetBody(BlueprintUnit.UnitBody body)
    {
      ValidateParam(body);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Body = body;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Strength"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetStrength(int strength)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Strength = strength;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Dexterity"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetDexterity(int dexterity)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Dexterity = dexterity;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Constitution"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetConstitution(int constitution)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Constitution = constitution;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Intelligence"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetIntelligence(int intelligence)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Intelligence = intelligence;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Wisdom"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetWisdom(int wisdom)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Wisdom = wisdom;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Charisma"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetCharisma(int charisma)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Charisma = charisma;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Speed"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetSpeed(Feet speed)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Speed = speed;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.BaseAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetBaseAttackBonus(int baseAttackBonus)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.BaseAttackBonus = baseAttackBonus;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.Skills"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetSkills(BlueprintUnit.UnitSkills skills)
    {
      ValidateParam(skills);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Skills = skills;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.MaxHP"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetMaxHP(int maxHP)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MaxHP = maxHP;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.m_AdditionalTemplates"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="additionalTemplates"><see cref="BlueprintUnitTemplate"/></param>
    [Generated]
    public UnitConfigurator SetAdditionalTemplates(string[] additionalTemplates)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AdditionalTemplates = additionalTemplates.Select(name => BlueprintTool.GetRef<BlueprintUnitTemplateReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintUnit.m_AdditionalTemplates"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="additionalTemplates"><see cref="BlueprintUnitTemplate"/></param>
    [Generated]
    public UnitConfigurator AddToAdditionalTemplates(params string[] additionalTemplates)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AdditionalTemplates = CommonTool.Append(bp.m_AdditionalTemplates, additionalTemplates.Select(name => BlueprintTool.GetRef<BlueprintUnitTemplateReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintUnit.m_AdditionalTemplates"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="additionalTemplates"><see cref="BlueprintUnitTemplate"/></param>
    [Generated]
    public UnitConfigurator RemoveFromAdditionalTemplates(params string[] additionalTemplates)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = additionalTemplates.Select(name => BlueprintTool.GetRef<BlueprintUnitTemplateReference>(name));
            bp.m_AdditionalTemplates =
                bp.m_AdditionalTemplates
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.m_AddFacts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="addFacts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    public UnitConfigurator SetAddFacts(string[] addFacts)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AddFacts = addFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintUnit.m_AddFacts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="addFacts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    public UnitConfigurator AddToAddFacts(params string[] addFacts)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_AddFacts = CommonTool.Append(bp.m_AddFacts, addFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintUnit.m_AddFacts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="addFacts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    public UnitConfigurator RemoveFromAddFacts(params string[] addFacts)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = addFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name));
            bp.m_AddFacts =
                bp.m_AddFacts
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.IsCheater"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetIsCheater(bool isCheater)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsCheater = isCheater;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.IsFake"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetIsFake(bool isFake)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsFake = isFake;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintUnit.m_CachedTags"/> (Auto Generated)
    /// </summary>
    [Generated]
    public UnitConfigurator SetCachedTags(AddTags cachedTags)
    {
      ValidateParam(cachedTags);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_CachedTags = cachedTags;
          });
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
    /// Adds <see cref="Kingmaker.UnitLogic.FactLogic.AddFacts">AddFacts</see>
    /// </summary>
    /// 
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
    [Implements(typeof(AddFacts))]
    public UnitConfigurator AddFacts(
        string[] facts,
        int casterLevel = 0,
        bool hasDifficultyRequirements = false,
        bool invertDifficultyRequirements = false,
        GameDifficultyOption minDifficulty = GameDifficultyOption.Story)
    {
      var addFacts = new AddFacts
      {
        m_Facts =
            facts.Select(fact => BlueprintTool.GetRef<BlueprintUnitFactReference>(fact)).ToArray(),
        CasterLevel = casterLevel,
        HasDifficultyRequirements = hasDifficultyRequirements,
        InvertDifficultyRequirements = invertDifficultyRequirements,
        MinDifficulty = minDifficulty
      };
      return AddComponent(addFacts);
    }

    /// <summary>
    /// Adds <see cref="AddInitiatorSkillRollTrigger"/>
    /// </summary>
    [Implements(typeof(AddInitiatorSkillRollTrigger))]
    public UnitConfigurator OnSkillCheck(
        StatType skill, ActionsBuilder actions, bool onlySuccess = true)
    {
      var trigger = new AddInitiatorSkillRollTrigger
      {
        OnlySuccess = onlySuccess,
        Skill = skill,
        Action = actions.Build()
      };
      return AddComponent(trigger);
    }

    /// <summary>
    /// Adds <see cref="UnitUpgraderComponent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="upgraders"><see cref="BlueprintUnitUpgrader"/></param>
    [Generated]
    [Implements(typeof(UnitUpgraderComponent))]
    public UnitConfigurator AddUnitUpgraderComponent(
        string[] upgraders = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new UnitUpgraderComponent();
      component.m_Upgraders = upgraders.Select(name => BlueprintTool.GetRef<BlueprintUnitUpgrader.Reference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddGlobalMapSpellFeature"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spell"><see cref="BlueprintGlobalMagicSpell"/></param>
    [Generated]
    [Implements(typeof(AddGlobalMapSpellFeature))]
    public UnitConfigurator AddGlobalMapSpellFeature(
        string spell = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddGlobalMapSpellFeature();
      component.m_Spell = BlueprintTool.GetRef<BlueprintGlobalMagicSpell.Reference>(spell);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CorruptionProtection"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CorruptionProtection))]
    public UnitConfigurator AddCorruptionProtection(
        bool removeRankAfterRest = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CorruptionProtection();
      component.m_RemoveRankAfterRest = removeRankAfterRest;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="GlobalMapSpeedModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GlobalMapSpeedModifier))]
    public UnitConfigurator AddGlobalMapSpeedModifier(
        float speedModifier = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new GlobalMapSpeedModifier();
      component.SpeedModifier = speedModifier;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RestRoleBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RestRoleBonus))]
    public UnitConfigurator AddRestRoleBonus(
        ContextValue value,
        CampingRoleType roleType = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new RestRoleBonus();
      component.m_RoleType = roleType;
      component.m_Descriptor = descriptor;
      component.m_Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CampingSpecialAbility"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="campCutscene"><see cref="Cutscene"/></param>
    /// <param name="selfBuff"><see cref="BlueprintBuff"/></param>
    /// <param name="partyBuff"><see cref="BlueprintBuff"/></param>
    /// <param name="partyBuffDuringCamp"><see cref="BlueprintBuff"/></param>
    /// <param name="selfBuffOnRandomEncounter"><see cref="BlueprintBuff"/></param>
    /// <param name="partyBuffOnRandomEncounter"><see cref="BlueprintBuff"/></param>
    /// <param name="enemiesBuffOnRandomEncounter"><see cref="BlueprintBuff"/></param>
    /// <param name="dlcReward"><see cref="BlueprintDlcReward"/></param>
    [Generated]
    [Implements(typeof(CampingSpecialAbility))]
    public UnitConfigurator AddCampingSpecialAbility(
        LocalizedString name = null,
        LocalizedString description = null,
        CampPositionType campPositionType = default,
        string campCutscene = null,
        string selfBuff = null,
        string partyBuff = null,
        string partyBuffDuringCamp = null,
        string selfBuffOnRandomEncounter = null,
        string partyBuffOnRandomEncounter = null,
        string enemiesBuffOnRandomEncounter = null,
        int minEnemyRandomEncounterBuffs = default,
        int maxEnemyRandomEncounterBuffs = default,
        float randomEncounterBuffsChance = default,
        int extraRations = default,
        CampingSpecialCustomMechanics customMechanics = default,
        string dlcReward = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(name);
      ValidateParam(description);
    
      var component = new CampingSpecialAbility();
      component.Name = name ?? Constants.Empty.String;
      component.Description = description ?? Constants.Empty.String;
      component.CampPositionType = campPositionType;
      component.m_CampCutscene = BlueprintTool.GetRef<CutsceneReference>(campCutscene);
      component.m_SelfBuff = BlueprintTool.GetRef<BlueprintBuffReference>(selfBuff);
      component.m_PartyBuff = BlueprintTool.GetRef<BlueprintBuffReference>(partyBuff);
      component.m_PartyBuffDuringCamp = BlueprintTool.GetRef<BlueprintBuffReference>(partyBuffDuringCamp);
      component.m_SelfBuffOnRandomEncounter = BlueprintTool.GetRef<BlueprintBuffReference>(selfBuffOnRandomEncounter);
      component.m_PartyBuffOnRandomEncounter = BlueprintTool.GetRef<BlueprintBuffReference>(partyBuffOnRandomEncounter);
      component.m_EnemiesBuffOnRandomEncounter = BlueprintTool.GetRef<BlueprintBuffReference>(enemiesBuffOnRandomEncounter);
      component.MinEnemyRandomEncounterBuffs = minEnemyRandomEncounterBuffs;
      component.MaxEnemyRandomEncounterBuffs = maxEnemyRandomEncounterBuffs;
      component.RandomEncounterBuffsChance = randomEncounterBuffsChance;
      component.ExtraRations = extraRations;
      component.CustomMechanics = customMechanics;
      component.m_DlcReward = BlueprintTool.GetRef<BlueprintDlcRewardReference>(dlcReward);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OverrideAnimationRaceComponent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="blueprintRace"><see cref="BlueprintRace"/></param>
    [Generated]
    [Implements(typeof(OverrideAnimationRaceComponent))]
    public UnitConfigurator AddOverrideAnimationRaceComponent(
        string blueprintRace = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new OverrideAnimationRaceComponent();
      component.BlueprintRace = BlueprintTool.GetRef<BlueprintRaceReference>(blueprintRace);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DualCompanionComponent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="pairCompanion"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(DualCompanionComponent))]
    public UnitConfigurator AddDualCompanionComponent(
        string pairCompanion = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DualCompanionComponent();
      component.m_PairCompanion = BlueprintTool.GetRef<BlueprintUnitReference>(pairCompanion);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LockedCompanionComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LockedCompanionComponent))]
    public UnitConfigurator AddLockedCompanionComponent(
        BlueprintComponent.Flags flags = default)
    {
      var component = new LockedCompanionComponent();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UnitAggroFilter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitAggroFilter))]
    public UnitConfigurator AddUnitAggroFilter(
        ConditionsBuilder filterCondition = null,
        ActionsBuilder actionsOnAggro = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new UnitAggroFilter();
      component.FilterCondition = filterCondition?.Build() ?? Constants.Empty.Conditions;
      component.ActionsOnAggro = actionsOnAggro?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DisableAllFx"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DisableAllFx))]
    public UnitConfigurator AddDisableAllFx(
        BlueprintComponent.Flags flags = default)
    {
      var component = new DisableAllFx();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceUnitBlueprintForRespec"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="blueprint"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(ReplaceUnitBlueprintForRespec))]
    public UnitConfigurator AddReplaceUnitBlueprintForRespec(
        string blueprint = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReplaceUnitBlueprintForRespec();
      component.m_Blueprint = BlueprintTool.GetRef<BlueprintUnitReference>(blueprint);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceUnitPrefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ReplaceUnitPrefab))]
    public UnitConfigurator AddReplaceUnitPrefab(
        PrefabLink prefab = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(prefab);
    
      var component = new ReplaceUnitPrefab();
      component.m_Prefab = prefab ?? Constants.Empty.PrefabLink;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UnitIsStoryCompanion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitIsStoryCompanion))]
    public UnitConfigurator AddUnitIsStoryCompanion(
        BlueprintComponent.Flags flags = default)
    {
      var component = new UnitIsStoryCompanion();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PretendUnit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unit"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(PretendUnit))]
    public UnitConfigurator AddPretendUnit(
        string unit = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new PretendUnit();
      component.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(unit);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddClassLevels"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="archetypes"><see cref="BlueprintArchetype"/></param>
    /// <param name="selectSpells"><see cref="BlueprintAbility"/></param>
    /// <param name="memorizeSpells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddClassLevels))]
    public UnitConfigurator AddClassLevels(
        string characterClass = null,
        string[] archetypes = null,
        int levels = default,
        StatType raceStat = default,
        StatType levelsStat = default,
        StatType[] skills = null,
        string[] selectSpells = null,
        string[] memorizeSpells = null,
        SelectionEntry[] selections = null,
        bool doNotApplyAutomatically = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(selections);
    
      var component = new AddClassLevels();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_Archetypes = archetypes.Select(name => BlueprintTool.GetRef<BlueprintArchetypeReference>(name)).ToArray();
      component.Levels = levels;
      component.RaceStat = raceStat;
      component.LevelsStat = levelsStat;
      component.Skills = skills;
      component.m_SelectSpells = selectSpells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_MemorizeSpells = memorizeSpells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.Selections = selections;
      component.DoNotApplyAutomatically = doNotApplyAutomatically;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddClassLevelsToPets"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="blueprintPet"><see cref="BlueprintPet"/></param>
    [Generated]
    [Implements(typeof(AddClassLevelsToPets))]
    public UnitConfigurator AddClassLevelsToPets(
        string blueprintPet = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddClassLevelsToPets();
      component.m_BlueprintPet = BlueprintTool.GetRef<BlueprintPet.Reference>(blueprintPet);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ClassLevelLimit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ClassLevelLimit))]
    public UnitConfigurator AddClassLevelLimit(
        int levelLimit = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ClassLevelLimit();
      component.LevelLimit = levelLimit;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MythicLevelLimit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MythicLevelLimit))]
    public UnitConfigurator AddMythicLevelLimit(
        int levelLimit = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new MythicLevelLimit();
      component.LevelLimit = levelLimit;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SuppressSpellSchool"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SuppressSpellSchool))]
    public UnitConfigurator AddSuppressSpellSchool(
        SuppressSpellSchool.Logic componentLogic = default,
        SpellSchool[] school = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SuppressSpellSchool();
      component.m_ComponentLogic = componentLogic;
      component.m_School = school;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Experience"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Experience))]
    public UnitConfigurator AddExperience(
        IntEvaluator count,
        EncounterType encounter = default,
        int cR = default,
        float modifier = default,
        bool dummy = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(count);
    
      var component = new Experience();
      component.Encounter = encounter;
      component.CR = cR;
      component.Modifier = modifier;
      component.Count = count;
      component.Dummy = dummy;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PregenUnitComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PregenUnitComponent))]
    public UnitConfigurator AddPregenUnitComponent(
        LocalizedString pregenName = null,
        LocalizedString pregenDescription = null,
        LocalizedString pregenClass = null,
        LocalizedString pregenRole = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(pregenName);
      ValidateParam(pregenDescription);
      ValidateParam(pregenClass);
      ValidateParam(pregenRole);
    
      var component = new PregenUnitComponent();
      component.PregenName = pregenName ?? Constants.Empty.String;
      component.PregenDescription = pregenDescription ?? Constants.Empty.String;
      component.PregenClass = pregenClass ?? Constants.Empty.String;
      component.PregenRole = pregenRole ?? Constants.Empty.String;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AzataFavorableMagic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AzataFavorableMagic))]
    public UnitConfigurator AddAzataFavorableMagic(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AzataFavorableMagic();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DemonSocothbenothAspect"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DemonSocothbenothAspect))]
    public UnitConfigurator AddDemonSocothbenothAspect(
        BlueprintComponent.Flags flags = default)
    {
      var component = new DemonSocothbenothAspect();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ActionsOnClick"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ActionsOnClick))]
    public UnitConfigurator AddActionsOnClick(
        ActionsBuilder actions = null,
        float overrideDistance = default,
        ConditionsBuilder conditions = null,
        bool triggerOnApproach = default,
        bool triggerOnParty = default,
        float cooldown = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ActionsOnClick();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.m_OverrideDistance = overrideDistance;
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.TriggerOnApproach = triggerOnApproach;
      component.TriggerOnParty = triggerOnParty;
      component.Cooldown = cooldown;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BarkOnClick"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BarkOnClick))]
    public UnitConfigurator AddBarkOnClick(
        LocalizedString bark = null,
        bool showOnUser = default,
        float overrideDistance = default,
        ConditionsBuilder conditions = null,
        bool triggerOnApproach = default,
        bool triggerOnParty = default,
        float cooldown = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bark);
    
      var component = new BarkOnClick();
      component.Bark = bark ?? Constants.Empty.String;
      component.ShowOnUser = showOnUser;
      component.m_OverrideDistance = overrideDistance;
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.TriggerOnApproach = triggerOnApproach;
      component.TriggerOnParty = triggerOnParty;
      component.Cooldown = cooldown;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DialogOnClick"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="dialog"><see cref="BlueprintDialog"/></param>
    [Generated]
    [Implements(typeof(DialogOnClick))]
    public UnitConfigurator AddDialogOnClick(
        string dialog = null,
        ActionsBuilder noDialogActions = null,
        float overrideDistance = default,
        ConditionsBuilder conditions = null,
        bool triggerOnApproach = default,
        bool triggerOnParty = default,
        float cooldown = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DialogOnClick();
      component.m_Dialog = BlueprintTool.GetRef<BlueprintDialogReference>(dialog);
      component.NoDialogActions = noDialogActions?.Build() ?? Constants.Empty.Actions;
      component.m_OverrideDistance = overrideDistance;
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.TriggerOnApproach = triggerOnApproach;
      component.TriggerOnParty = triggerOnParty;
      component.Cooldown = cooldown;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityUsagesCountTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityUsagesCountTrigger))]
    public UnitConfigurator AddAbilityUsagesCountTrigger(
        ContextValue triggerCount,
        ActionsBuilder action = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(triggerCount);
    
      var component = new AbilityUsagesCountTrigger();
      component.m_TriggerCount = triggerCount;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AccomplishedSneakAttacker"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AccomplishedSneakAttacker))]
    public UnitConfigurator AddAccomplishedSneakAttacker(
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AccomplishedSneakAttacker();
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AcrobaticMovement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AcrobaticMovement))]
    public UnitConfigurator AddAcrobaticMovement(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AcrobaticMovement();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddACBonusWithDistanceToMasterCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddACBonusWithDistanceToMasterCondition))]
    public UnitConfigurator AddACBonusWithDistanceToMasterCondition(
        ContextValue value,
        Feet distance,
        ModifierDescriptor descriptor = default,
        CompareOperation.Type compareType = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new AddACBonusWithDistanceToMasterCondition();
      component.Value = value;
      component.Descriptor = descriptor;
      component.CompareType = compareType;
      component.Distance = distance;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAbilityResourceTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="resource"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    [Implements(typeof(AddAbilityResourceTrigger))]
    public UnitConfigurator AddAbilityResourceTrigger(
        string resource = null,
        ActionsBuilder action = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddAbilityResourceTrigger();
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(resource);
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAbilityToCharacterComponent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilities"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddAbilityToCharacterComponent))]
    public UnitConfigurator AddAbilityToCharacterComponent(
        string[] abilities = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddAbilityToCharacterComponent();
      component.m_Abilities = abilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAbilityUseTargetTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbooks"><see cref="BlueprintSpellbook"/></param>
    /// <param name="spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddAbilityUseTargetTrigger))]
    public UnitConfigurator AddAbilityUseTargetTrigger(
        SpellDescriptorWrapper spellDescriptor,
        ActionsBuilder action = null,
        bool afterCast = default,
        bool fromSpellbook = default,
        AbilityType type = default,
        bool toCaster = default,
        string[] spellbooks = null,
        bool spellList = default,
        string[] spells = null,
        bool checkDescriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddAbilityUseTargetTrigger();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.AfterCast = afterCast;
      component.FromSpellbook = fromSpellbook;
      component.Type = type;
      component.ToCaster = toCaster;
      component.m_Spellbooks = spellbooks.Select(name => BlueprintTool.GetRef<BlueprintSpellbookReference>(name)).ToArray();
      component.SpellList = spellList;
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.CheckDescriptor = checkDescriptor;
      component.SpellDescriptor = spellDescriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAbilityUseTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbooks"><see cref="BlueprintSpellbook"/></param>
    /// <param name="ability"><see cref="BlueprintAbility"/></param>
    /// <param name="abilities"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddAbilityUseTrigger))]
    public UnitConfigurator AddAbilityUseTrigger(
        SpellDescriptorWrapper spellDescriptor,
        ActionsBuilder action = null,
        bool actionsOnAllTargets = default,
        bool afterCast = default,
        bool actionsOnTarget = default,
        bool fromSpellbook = default,
        string[] spellbooks = null,
        bool forOneSpell = default,
        string ability = null,
        bool forMultipleSpells = default,
        string[] abilities = null,
        bool minSpellLevel = default,
        int minSpellLevelLimit = default,
        bool exactSpellLevel = default,
        int exactSpellLevelLimit = default,
        bool checkAbilityType = default,
        AbilityType type = default,
        bool checkDescriptor = default,
        bool checkRange = default,
        AbilityRange range = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddAbilityUseTrigger();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.ActionsOnAllTargets = actionsOnAllTargets;
      component.AfterCast = afterCast;
      component.ActionsOnTarget = actionsOnTarget;
      component.FromSpellbook = fromSpellbook;
      component.m_Spellbooks = spellbooks.Select(name => BlueprintTool.GetRef<BlueprintSpellbookReference>(name)).ToArray();
      component.ForOneSpell = forOneSpell;
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      component.ForMultipleSpells = forMultipleSpells;
      component.Abilities = abilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToList();
      component.MinSpellLevel = minSpellLevel;
      component.MinSpellLevelLimit = minSpellLevelLimit;
      component.ExactSpellLevel = exactSpellLevel;
      component.ExactSpellLevelLimit = exactSpellLevelLimit;
      component.CheckAbilityType = checkAbilityType;
      component.Type = type;
      component.CheckDescriptor = checkDescriptor;
      component.SpellDescriptor = spellDescriptor;
      component.CheckRange = checkRange;
      component.Range = range;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAdditionalLimb"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weapon"><see cref="BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(AddAdditionalLimb))]
    public UnitConfigurator AddAdditionalLimb(
        string weapon = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddAdditionalLimb();
      component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(weapon);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAmbushBehaviour"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddAmbushBehaviour))]
    public UnitConfigurator AddAmbushBehaviour(
        float joinCombatDisatnce = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddAmbushBehaviour();
      component.JoinCombatDisatnce = joinCombatDisatnce;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBackgroundArmorProficiency"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddBackgroundArmorProficiency))]
    public UnitConfigurator AddBackgroundArmorProficiency(
        ContextValue stackBonus,
        ArmorProficiencyGroup proficiency = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(stackBonus);
    
      var component = new AddBackgroundArmorProficiency();
      component.Proficiency = proficiency;
      component.StackBonus = stackBonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBackgroundClassSkill"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddBackgroundClassSkill))]
    public UnitConfigurator AddBackgroundClassSkill(
        StatType skill = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddBackgroundClassSkill();
      component.Skill = skill;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBackgroundWeaponProficiency"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddBackgroundWeaponProficiency))]
    public UnitConfigurator AddBackgroundWeaponProficiency(
        ContextValue stackBonus,
        WeaponCategory proficiency = default,
        ModifierDescriptor stackBonusType = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(stackBonus);
    
      var component = new AddBackgroundWeaponProficiency();
      component.Proficiency = proficiency;
      component.StackBonusType = stackBonusType;
      component.StackBonus = stackBonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBondProperty"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchant"><see cref="BlueprintItemEnchantment"/></param>
    [Generated]
    [Implements(typeof(AddBondProperty))]
    public UnitConfigurator AddBondProperty(
        EnchantPoolType enchantPool = default,
        string enchant = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddBondProperty();
      component.EnchantPool = enchantPool;
      component.m_Enchant = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(enchant);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBuffInBadWeather"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AddBuffInBadWeather))]
    public UnitConfigurator AddBuffInBadWeather(
        string buff = null,
        InclemencyType weather = default,
        bool whenCalmer = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddBuffInBadWeather();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.Weather = weather;
      component.WhenCalmer = whenCalmer;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBuffOnApplyingSpell"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddBuffOnApplyingSpell))]
    public UnitConfigurator AddBuffOnApplyingSpell(
        bool onEffectApplied = default,
        bool onResistSpell = default,
        AddBuffOnApplyingSpell.SpellConditionAndBuff[] buffs = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(buffs);
    
      var component = new AddBuffOnApplyingSpell();
      component.OnEffectApplied = onEffectApplied;
      component.OnResistSpell = onResistSpell;
      component.Buffs = buffs;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddClassSkill"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddClassSkill))]
    public UnitConfigurator AddClassSkill(
        StatType skill = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddClassSkill();
      component.Skill = skill;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddClusteredAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddClusteredAttack))]
    public UnitConfigurator AddClusteredAttack(
        AddClusteredAttack.Type attackType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddClusteredAttack();
      component.AttackType = attackType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddConcealment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddConcealment))]
    public UnitConfigurator AddConcealment(
        Feet distanceGreater,
        ConcealmentDescriptor descriptor = default,
        Concealment concealment = default,
        bool checkWeaponRangeType = default,
        WeaponRangeType rangeType = default,
        bool checkDistance = default,
        bool onlyForAttacks = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddConcealment();
      component.Descriptor = descriptor;
      component.Concealment = concealment;
      component.CheckWeaponRangeType = checkWeaponRangeType;
      component.RangeType = rangeType;
      component.CheckDistance = checkDistance;
      component.DistanceGreater = distanceGreater;
      component.OnlyForAttacks = onlyForAttacks;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddCondition))]
    public UnitConfigurator AddCondition(
        UnitCondition condition = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddCondition();
      component.Condition = condition;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddConditionImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddConditionImmunity))]
    public UnitConfigurator AddConditionImmunity(
        UnitCondition condition = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddConditionImmunity();
      component.Condition = condition;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddConditionTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddConditionTrigger))]
    public UnitConfigurator AddConditionTrigger(
        AddConditionTrigger.TriggerType triggerType = default,
        UnitCondition[] conditions = null,
        ActionsBuilder action = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddConditionTrigger();
      component.m_TriggerType = triggerType;
      component.Conditions = conditions;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddContextStatBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddContextStatBonus))]
    public UnitConfigurator AddContextStatBonus(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int multiplier = default,
        bool hasMinimal = default,
        int minimal = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new AddContextStatBonus();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Multiplier = multiplier;
      component.Value = value;
      component.HasMinimal = hasMinimal;
      component.Minimal = minimal;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCumulativeDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddCumulativeDamageBonus))]
    public UnitConfigurator AddCumulativeDamageBonus(
        bool onlyNaturalAttacks = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddCumulativeDamageBonus();
      component.OnlyNaturalAttacks = onlyNaturalAttacks;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCumulativeDamageBonusX3"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddCumulativeDamageBonusX3))]
    public UnitConfigurator AddCumulativeDamageBonusX3(
        bool onlyNaturalAttacks = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddCumulativeDamageBonusX3();
      component.OnlyNaturalAttacks = onlyNaturalAttacks;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddDamageResistanceEnergy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddDamageResistanceEnergy))]
    public UnitConfigurator AddDamageResistanceEnergy(
        ContextValue valueMultiplier,
        ContextValue value,
        ContextValue pool,
        DamageEnergyType type = default,
        bool useValueMultiplier = default,
        bool usePool = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(valueMultiplier);
      ValidateParam(value);
      ValidateParam(pool);
    
      var component = new AddDamageResistanceEnergy();
      component.Type = type;
      component.UseValueMultiplier = useValueMultiplier;
      component.ValueMultiplier = valueMultiplier;
      component.Value = value;
      component.UsePool = usePool;
      component.Pool = pool;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddDamageResistanceForce"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddDamageResistanceForce))]
    public UnitConfigurator AddDamageResistanceForce(
        ContextValue valueMultiplier,
        ContextValue value,
        ContextValue pool,
        DamageEnergyType type = default,
        bool useValueMultiplier = default,
        bool usePool = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(valueMultiplier);
      ValidateParam(value);
      ValidateParam(pool);
    
      var component = new AddDamageResistanceForce();
      component.Type = type;
      component.UseValueMultiplier = useValueMultiplier;
      component.ValueMultiplier = valueMultiplier;
      component.Value = value;
      component.UsePool = usePool;
      component.Pool = pool;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddDamageResistancePhysical"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="BlueprintWeaponType"/></param>
    /// <param name="checkedFactMythic"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddDamageResistancePhysical))]
    public UnitConfigurator AddDamageResistancePhysical(
        ContextValue value,
        ContextValue pool,
        bool or = default,
        bool bypassedByMaterial = default,
        PhysicalDamageMaterial material = default,
        bool bypassedByForm = default,
        PhysicalDamageForm form = default,
        bool bypassedByMagic = default,
        int minEnhancementBonus = default,
        bool bypassedByAlignment = default,
        DamageAlignment alignment = default,
        bool bypassedByReality = default,
        DamageRealityType reality = default,
        bool bypassedByWeaponType = default,
        string weaponType = null,
        bool bypassedByMeleeWeapon = default,
        bool bypassedByEpic = default,
        string checkedFactMythic = null,
        bool usePool = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
      ValidateParam(pool);
    
      var component = new AddDamageResistancePhysical();
      component.Or = or;
      component.BypassedByMaterial = bypassedByMaterial;
      component.Material = material;
      component.BypassedByForm = bypassedByForm;
      component.Form = form;
      component.BypassedByMagic = bypassedByMagic;
      component.MinEnhancementBonus = minEnhancementBonus;
      component.BypassedByAlignment = bypassedByAlignment;
      component.Alignment = alignment;
      component.BypassedByReality = bypassedByReality;
      component.Reality = reality;
      component.BypassedByWeaponType = bypassedByWeaponType;
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      component.BypassedByMeleeWeapon = bypassedByMeleeWeapon;
      component.BypassedByEpic = bypassedByEpic;
      component.m_CheckedFactMythic = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFactMythic);
      component.Value = value;
      component.UsePool = usePool;
      component.Pool = pool;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddDamageTypeVulnerability"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddDamageTypeVulnerability))]
    public UnitConfigurator AddDamageTypeVulnerability(
        bool physcicalForm = default,
        PhysicalDamageForm formType = default,
        bool physcicalAlignment = default,
        DamageAlignment damageAlignmentType = default,
        bool physcicalMaterial = default,
        PhysicalDamageMaterial materialType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddDamageTypeVulnerability();
      component.PhyscicalForm = physcicalForm;
      component.FormType = formType;
      component.PhyscicalAlignment = physcicalAlignment;
      component.DamageAlignmentType = damageAlignmentType;
      component.PhyscicalMaterial = physcicalMaterial;
      component.MaterialType = materialType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEnergyDamageDivisor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEnergyDamageDivisor))]
    public UnitConfigurator AddEnergyDamageDivisor(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddEnergyDamageDivisor();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEnergyDamageImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEnergyDamageImmunity))]
    public UnitConfigurator AddEnergyDamageImmunity(
        DamageEnergyType energyType = default,
        bool healOnDamage = default,
        AddEnergyDamageImmunity.HealingRate healRate = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddEnergyDamageImmunity();
      component.EnergyType = energyType;
      component.HealOnDamage = healOnDamage;
      component.m_HealRate = healRate;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEnergyImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEnergyImmunity))]
    public UnitConfigurator AddEnergyImmunity(
        DamageEnergyType type = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddEnergyImmunity();
      component.Type = type;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEnergyVulnerability"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEnergyVulnerability))]
    public UnitConfigurator AddEnergyVulnerability(
        DamageEnergyType type = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddEnergyVulnerability();
      component.Type = type;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEquipmentEntity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEquipmentEntity))]
    public UnitConfigurator AddEquipmentEntity(
        EquipmentEntityLink equipmentEntity,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(equipmentEntity);
    
      var component = new AddEquipmentEntity();
      component.EquipmentEntity = equipmentEntity;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFactsFromCaster"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
    /// <param name="selection"><see cref="BlueprintFeatureSelection"/></param>
    [Generated]
    [Implements(typeof(AddFactsFromCaster))]
    public UnitConfigurator AddFactsFromCaster(
        string[] facts = null,
        bool featureFromSelection = default,
        string selection = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddFactsFromCaster();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.FeatureFromSelection = featureFromSelection;
      component.m_Selection = BlueprintTool.GetRef<BlueprintFeatureSelectionReference>(selection);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFactsToMount"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddFactsToMount))]
    public UnitConfigurator AddFactsToMount(
        string[] facts = null,
        int casterLevel = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddFactsToMount();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.CasterLevel = casterLevel;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFallProneTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddFallProneTrigger))]
    public UnitConfigurator AddFallProneTrigger(
        ActionsBuilder action = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddFallProneTrigger();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFamiliar"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddFamiliar))]
    public UnitConfigurator AddFamiliar(
        FamiliarLink prefabLink,
        bool hideInCapital = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(prefabLink);
    
      var component = new AddFamiliar();
      component.PrefabLink = prefabLink;
      component.HideInCapital = hideInCapital;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddForceMove"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddForceMove))]
    public UnitConfigurator AddForceMove(
        ContextValue feetPerRound,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(feetPerRound);
    
      var component = new AddForceMove();
      component.FeetPerRound = feetPerRound;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFortification"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddFortification))]
    public UnitConfigurator AddFortification(
        ContextValue value,
        bool useContextValue = default,
        int bonus = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new AddFortification();
      component.UseContextValue = useContextValue;
      component.Bonus = bonus;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFortificationObsolete"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddFortificationObsolete))]
    public UnitConfigurator AddFortificationObsolete(
        int chance = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddFortificationObsolete();
      component.Chance = chance;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddGoldenDragonSkillBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddGoldenDragonSkillBonus))]
    public UnitConfigurator AddGoldenDragonSkillBonus(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddGoldenDragonSkillBonus();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddHealTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddHealTrigger))]
    public UnitConfigurator AddHealTrigger(
        ActionsBuilder action = null,
        ActionsBuilder healerAction = null,
        bool onHealDamage = default,
        bool onHealStatDamage = default,
        bool onHealEnergyDrain = default,
        bool allowZeroHealDamage = default,
        bool allowZeroHealStatDamage = default,
        bool allowZeroHealEnergyDrain = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddHealTrigger();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.HealerAction = healerAction?.Build() ?? Constants.Empty.Actions;
      component.OnHealDamage = onHealDamage;
      component.OnHealStatDamage = onHealStatDamage;
      component.OnHealEnergyDrain = onHealEnergyDrain;
      component.AllowZeroHealDamage = allowZeroHealDamage;
      component.AllowZeroHealStatDamage = allowZeroHealStatDamage;
      component.AllowZeroHealEnergyDrain = allowZeroHealEnergyDrain;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddIdentifyBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddIdentifyBonus))]
    public UnitConfigurator AddIdentifyBonus(
        ContextValue bonus,
        ContextValue spellBonus,
        bool allowUsingUntrainedSkill = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
      ValidateParam(spellBonus);
    
      var component = new AddIdentifyBonus();
      component.AllowUsingUntrainedSkill = allowUsingUntrainedSkill;
      component.Bonus = bonus;
      component.SpellBonus = spellBonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddImmortality"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddImmortality))]
    public UnitConfigurator AddImmortality(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddImmortality();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddImmunityFirebrand"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddImmunityFirebrand))]
    public UnitConfigurator AddImmunityFirebrand(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddImmunityFirebrand();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddImmunityToAbilityScoreDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddImmunityToAbilityScoreDamage))]
    public UnitConfigurator AddImmunityToAbilityScoreDamage(
        bool drain = default,
        StatType[] statTypes = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddImmunityToAbilityScoreDamage();
      component.Drain = drain;
      component.StatTypes = statTypes;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddImmunityToCriticalHits"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddImmunityToCriticalHits))]
    public UnitConfigurator AddImmunityToCriticalHits(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddImmunityToCriticalHits();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddImmunityToEnergyDrain"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddImmunityToEnergyDrain))]
    public UnitConfigurator AddImmunityToEnergyDrain(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddImmunityToEnergyDrain();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddImmunityToPrecisionDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddImmunityToPrecisionDamage))]
    public UnitConfigurator AddImmunityToPrecisionDamage(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddImmunityToPrecisionDamage();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddIncomingDamageWeaponProperty"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(AddIncomingDamageWeaponProperty))]
    public UnitConfigurator AddIncomingDamageWeaponProperty(
        bool addMagic = default,
        bool addMaterial = default,
        PhysicalDamageMaterial material = default,
        bool addForm = default,
        PhysicalDamageForm form = default,
        bool addAlignment = default,
        DamageAlignment alignment = default,
        bool addReality = default,
        DamageRealityType reality = default,
        bool checkWeaponType = default,
        string weaponType = null,
        bool checkRange = default,
        bool isRanged = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddIncomingDamageWeaponProperty();
      component.AddMagic = addMagic;
      component.AddMaterial = addMaterial;
      component.Material = material;
      component.AddForm = addForm;
      component.Form = form;
      component.AddAlignment = addAlignment;
      component.Alignment = alignment;
      component.AddReality = addReality;
      component.Reality = reality;
      component.CheckWeaponType = checkWeaponType;
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      component.CheckRange = checkRange;
      component.IsRanged = isRanged;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddIncorporealDamageDivisor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddIncorporealDamageDivisor))]
    public UnitConfigurator AddIncorporealDamageDivisor(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddIncorporealDamageDivisor();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddInitiatorHealTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddInitiatorHealTrigger))]
    public UnitConfigurator AddInitiatorHealTrigger(
        ActionsBuilder action = null,
        ActionsBuilder healerAction = null,
        bool onHealDamage = default,
        bool onHealStatDamage = default,
        bool onHealEnergyDrain = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddInitiatorHealTrigger();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.HealerAction = healerAction?.Build() ?? Constants.Empty.Actions;
      component.OnHealDamage = onHealDamage;
      component.OnHealStatDamage = onHealStatDamage;
      component.OnHealEnergyDrain = onHealEnergyDrain;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddItemCasterLevelBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddItemCasterLevelBonus))]
    public UnitConfigurator AddItemCasterLevelBonus(
        int bonus = default,
        UsableItemType itemType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddItemCasterLevelBonus();
      component.Bonus = bonus;
      component.ItemType = itemType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddKnownSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="spell"><see cref="BlueprintAbility"/></param>
    /// <param name="archetype"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(AddKnownSpell))]
    public UnitConfigurator AddKnownSpell(
        string characterClass = null,
        int spellLevel = default,
        string spell = null,
        string archetype = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddKnownSpell();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.SpellLevel = spellLevel;
      component.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(spell);
      component.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddLocustSwarmMechanicPart"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddLocustSwarmMechanicPart))]
    public UnitConfigurator AddLocustSwarmMechanicPart(
        int swarmStartStrength = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddLocustSwarmMechanicPart();
      component.m_SwarmStartStrength = swarmStartStrength;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddLoot"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="loot"><see cref="BlueprintUnitLoot"/></param>
    [Generated]
    [Implements(typeof(AddLoot))]
    public UnitConfigurator AddLoot(
        string loot = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddLoot();
      component.m_Loot = BlueprintTool.GetRef<BlueprintUnitLootReference>(loot);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddLootToVendorTable"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="loot"><see cref="BlueprintUnitLoot"/></param>
    [Generated]
    [Implements(typeof(AddLootToVendorTable))]
    public UnitConfigurator AddLootToVendorTable(
        string loot = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddLootToVendorTable();
      component.m_Loot = BlueprintTool.GetRef<BlueprintUnitLootReference>(loot);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddMagusMechanicPart"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddMagusMechanicPart))]
    public UnitConfigurator AddMagusMechanicPart(
        AddMagusMechanicPart.Feature feature = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddMagusMechanicPart();
      component.m_Feature = feature;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddMechanicsFeature"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddMechanicsFeature))]
    public UnitConfigurator AddMechanicsFeature(
        AddMechanicsFeature.MechanicsFeatureType feature = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddMechanicsFeature();
      component.m_Feature = feature;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddMetamagicFeat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddMetamagicFeat))]
    public UnitConfigurator AddMetamagicFeat(
        Metamagic metamagic = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddMetamagicFeat();
      component.Metamagic = metamagic;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddMythicEnemyHitPointsBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddMythicEnemyHitPointsBonus))]
    public UnitConfigurator AddMythicEnemyHitPointsBonus(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddMythicEnemyHitPointsBonus();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddNimbusDamageDivisor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddNimbusDamageDivisor))]
    public UnitConfigurator AddNimbusDamageDivisor(
        AddNimbusDamageDivisor.NimbusType type = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddNimbusDamageDivisor();
      component.m_Type = type;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddNocticulaBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddNocticulaBonus))]
    public UnitConfigurator AddNocticulaBonus(
        ContextValue highestStatBonus,
        ContextValue secondHighestStatBonus,
        ModifierDescriptor descriptor = default,
        StatType highestStat = default,
        StatType secondHighestStat = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(highestStatBonus);
      ValidateParam(secondHighestStatBonus);
    
      var component = new AddNocticulaBonus();
      component.Descriptor = descriptor;
      component.HighestStatBonus = highestStatBonus;
      component.m_HighestStat = highestStat;
      component.SecondHighestStatBonus = secondHighestStatBonus;
      component.m_SecondHighestStat = secondHighestStat;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddOffensiveActionTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddOffensiveActionTrigger))]
    public UnitConfigurator AddOffensiveActionTrigger(
        ActionsBuilder action = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddOffensiveActionTrigger();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddOppositionDescriptor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(AddOppositionDescriptor))]
    public UnitConfigurator AddOppositionDescriptor(
        SpellDescriptorWrapper descriptor,
        string characterClass = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddOppositionDescriptor();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddOppositionSchool"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(AddOppositionSchool))]
    public UnitConfigurator AddOppositionSchool(
        string characterClass = null,
        SpellSchool school = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddOppositionSchool();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.School = school;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddOutgoingDamageBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddOutgoingDamageBonus))]
    public UnitConfigurator AddOutgoingDamageBonus(
        DamageTypeDescription damageType,
        SpellDescriptorWrapper checkedDescriptor,
        DamageIncreaseCondition condition = default,
        DamageIncreaseReason reason = default,
        float originalDamageFactor = default,
        string checkedFact = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(damageType);
    
      var component = new AddOutgoingDamageBonus();
      component.DamageType = damageType;
      component.Condition = condition;
      component.Reason = reason;
      component.OriginalDamageFactor = originalDamageFactor;
      component.CheckedDescriptor = checkedDescriptor;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddOutgoingPhysicalDamageProperty"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="BlueprintWeaponType"/></param>
    /// <param name="unitFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddOutgoingPhysicalDamageProperty))]
    public UnitConfigurator AddOutgoingPhysicalDamageProperty(
        bool affectAnyPhysicalDamage = default,
        bool naturalAttacks = default,
        bool addMagic = default,
        bool addMaterial = default,
        PhysicalDamageMaterial material = default,
        bool addForm = default,
        PhysicalDamageForm form = default,
        bool addAlignment = default,
        DamageAlignment alignment = default,
        bool myAlignment = default,
        bool addReality = default,
        DamageRealityType reality = default,
        bool checkWeaponType = default,
        string weaponType = null,
        bool checkRange = default,
        bool isRanged = default,
        bool againstFactOwner = default,
        string unitFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddOutgoingPhysicalDamageProperty();
      component.AffectAnyPhysicalDamage = affectAnyPhysicalDamage;
      component.NaturalAttacks = naturalAttacks;
      component.AddMagic = addMagic;
      component.AddMaterial = addMaterial;
      component.Material = material;
      component.AddForm = addForm;
      component.Form = form;
      component.AddAlignment = addAlignment;
      component.Alignment = alignment;
      component.MyAlignment = myAlignment;
      component.AddReality = addReality;
      component.Reality = reality;
      component.CheckWeaponType = checkWeaponType;
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      component.CheckRange = checkRange;
      component.IsRanged = isRanged;
      component.AgainstFactOwner = againstFactOwner;
      component.m_UnitFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(unitFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddOverHealTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddOverHealTrigger))]
    public UnitConfigurator AddOverHealTrigger(
        ActionsBuilder actionOnTarget = null,
        AbilitySharedValue sharedValue = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddOverHealTrigger();
      component.ActionOnTarget = actionOnTarget?.Build() ?? Constants.Empty.Actions;
      component.SharedValue = sharedValue;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddParametrizedClassSkill"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddParametrizedClassSkill))]
    public UnitConfigurator AddParametrizedClassSkill(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddParametrizedClassSkill();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddParametrizedFeatures"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddParametrizedFeatures))]
    public UnitConfigurator AddParametrizedFeatures(
        AddParametrizedFeatures.FeatureData[] features = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(features);
    
      var component = new AddParametrizedFeatures();
      component.m_Features = features;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddParametrizedStatBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddParametrizedStatBonus))]
    public UnitConfigurator AddParametrizedStatBonus(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new AddParametrizedStatBonus();
      component.Value = value;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddPartyEncumbrance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddPartyEncumbrance))]
    public UnitConfigurator AddPartyEncumbrance(
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddPartyEncumbrance();
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddPet"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="pet"><see cref="BlueprintUnit"/></param>
    /// <param name="levelRank"><see cref="BlueprintFeature"/></param>
    /// <param name="upgradeFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddPet))]
    public UnitConfigurator AddPet(
        ContextValue levelContextValue,
        PetType type = default,
        PetProgressionType progressionType = default,
        string pet = null,
        bool useContextValueLevel = default,
        string levelRank = null,
        bool forceAutoLevelup = default,
        string upgradeFeature = null,
        bool destroyPetOnDeactivate = default,
        int upgradeLevel = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(levelContextValue);
    
      var component = new AddPet();
      component.Type = type;
      component.ProgressionType = progressionType;
      component.m_Pet = BlueprintTool.GetRef<BlueprintUnitReference>(pet);
      component.m_UseContextValueLevel = useContextValueLevel;
      component.m_LevelRank = BlueprintTool.GetRef<BlueprintFeatureReference>(levelRank);
      component.m_LevelContextValue = levelContextValue;
      component.m_ForceAutoLevelup = forceAutoLevelup;
      component.m_UpgradeFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(upgradeFeature);
      component.m_DestroyPetOnDeactivate = destroyPetOnDeactivate;
      component.UpgradeLevel = upgradeLevel;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddPhysicalImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddPhysicalImmunity))]
    public UnitConfigurator AddPhysicalImmunity(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddPhysicalImmunity();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddPostLoadActions"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddPostLoadActions))]
    public UnitConfigurator AddPostLoadActions(
        ActionsBuilder actions = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddPostLoadActions();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddProficiencies"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="raceRestriction"><see cref="BlueprintRace"/></param>
    [Generated]
    [Implements(typeof(AddProficiencies))]
    public UnitConfigurator AddProficiencies(
        string raceRestriction = null,
        ArmorProficiencyGroup[] armorProficiencies = null,
        WeaponCategory[] weaponProficiencies = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddProficiencies();
      component.m_RaceRestriction = BlueprintTool.GetRef<BlueprintRaceReference>(raceRestriction);
      component.ArmorProficiencies = armorProficiencies;
      component.WeaponProficiencies = weaponProficiencies;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddREVendorItem"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddREVendorItem))]
    public UnitConfigurator AddREVendorItem(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddREVendorItem();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddRestTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddRestTrigger))]
    public UnitConfigurator AddRestTrigger(
        ActionsBuilder action = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddRestTrigger();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddResurrectOnRest"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddResurrectOnRest))]
    public UnitConfigurator AddResurrectOnRest(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddResurrectOnRest();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddRunwayLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddRunwayLogic))]
    public UnitConfigurator AddRunwayLogic(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddRunwayLogic();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSecondaryAttacks"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weapon"><see cref="BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(AddSecondaryAttacks))]
    public UnitConfigurator AddSecondaryAttacks(
        string[] weapon = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddSecondaryAttacks();
      component.m_Weapon = weapon.Select(name => BlueprintTool.GetRef<BlueprintItemWeaponReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSharedVendor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Table"><see cref="BlueprintSharedVendorTable"/></param>
    [Generated]
    [Implements(typeof(AddSharedVendor))]
    public UnitConfigurator AddSharedVendor(
        string m_Table = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddSharedVendor();
      component.m_m_Table = BlueprintTool.GetRef<BlueprintSharedVendorTableReference>(m_Table);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSkillPointPerCharacterLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddSkillPointPerCharacterLevel))]
    public UnitConfigurator AddSkillPointPerCharacterLevel(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddSkillPointPerCharacterLevel();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpecialSpellList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="spellList"><see cref="BlueprintSpellList"/></param>
    /// <param name="archetype"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(AddSpecialSpellList))]
    public UnitConfigurator AddSpecialSpellList(
        string characterClass = null,
        string spellList = null,
        bool forArchetypeOnly = default,
        string archetype = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddSpecialSpellList();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(spellList);
      component.ForArchetypeOnly = forArchetypeOnly;
      component.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpecialSpellListForArchetype"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="spellList"><see cref="BlueprintSpellList"/></param>
    /// <param name="archetype"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(AddSpecialSpellListForArchetype))]
    public UnitConfigurator AddSpecialSpellListForArchetype(
        string characterClass = null,
        string spellList = null,
        string archetype = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddSpecialSpellListForArchetype();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(spellList);
      component.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellFailureChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddSpellFailureChance))]
    public UnitConfigurator AddSpellFailureChance(
        GameObject failFx,
        int chance = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(failFx);
    
      var component = new AddSpellFailureChance();
      component.Chance = chance;
      component.FailFx = failFx;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellImmunity"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="exceptions"><see cref="BlueprintAbility"/></param>
    /// <param name="casterIgnoreImmunityFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddSpellImmunity))]
    public UnitConfigurator AddSpellImmunity(
        SpellDescriptorWrapper spellDescriptor,
        SpellImmunityType type = default,
        string[] exceptions = null,
        string casterIgnoreImmunityFact = null,
        bool invertedDescriptors = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddSpellImmunity();
      component.Type = type;
      component.m_Exceptions = exceptions.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.SpellDescriptor = spellDescriptor;
      component.m_CasterIgnoreImmunityFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(casterIgnoreImmunityFact);
      component.InvertedDescriptors = invertedDescriptors;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellKnownTemporary"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="spell"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddSpellKnownTemporary))]
    public UnitConfigurator AddSpellKnownTemporary(
        string characterClass = null,
        string spell = null,
        int level = default,
        bool onlySpontaneous = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddSpellKnownTemporary();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(spell);
      component.Level = level;
      component.OnlySpontaneous = onlySpontaneous;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellLevelLimit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddSpellLevelLimit))]
    public UnitConfigurator AddSpellLevelLimit(
        int forMaxLevel9 = default,
        int forMaxLevel6 = default,
        int forMaxLevel4 = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddSpellLevelLimit();
      component.ForMaxLevel9 = forMaxLevel9;
      component.ForMaxLevel6 = forMaxLevel6;
      component.ForMaxLevel4 = forMaxLevel4;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellResistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddSpellResistance))]
    public UnitConfigurator AddSpellResistance(
        ContextValue value,
        bool addCR = default,
        bool allSpellResistancePenaltyDoNotUse = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new AddSpellResistance();
      component.AddCR = addCR;
      component.Value = value;
      component.AllSpellResistancePenaltyDoNotUse = allSpellResistancePenaltyDoNotUse;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellTypeFailureChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddSpellTypeFailureChance))]
    public UnitConfigurator AddSpellTypeFailureChance(
        GameObject failFx,
        int chance = default,
        bool arcane = default,
        bool divine = default,
        bool alchemist = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(failFx);
    
      var component = new AddSpellTypeFailureChance();
      component.Chance = chance;
      component.FailFx = failFx;
      component.Arcane = arcane;
      component.Divine = divine;
      component.Alchemist = alchemist;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStartingEquipment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="basicItems"><see cref="BlueprintItem"/></param>
    /// <param name="customCategoryDefaults"><see cref="BlueprintCategoryDefaults"/></param>
    /// <param name="restrictedByClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(AddStartingEquipment))]
    public UnitConfigurator AddStartingEquipment(
        string[] basicItems = null,
        WeaponCategory[] categoryItems = null,
        bool parametrizedCategory = default,
        string customCategoryDefaults = null,
        string[] restrictedByClass = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddStartingEquipment();
      component.m_BasicItems = basicItems.Select(name => BlueprintTool.GetRef<BlueprintItemReference>(name)).ToArray();
      component.CategoryItems = categoryItems;
      component.ParametrizedCategory = parametrizedCategory;
      component.m_CustomCategoryDefaults = BlueprintTool.GetRef<BlueprintCategoryDefaultsReference>(customCategoryDefaults);
      component.m_RestrictedByClass = restrictedByClass.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddStatBonus))]
    public UnitConfigurator AddStatBonus(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int value = default,
        bool scaleByBasicAttackBonus = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddStatBonus();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value;
      component.ScaleByBasicAttackBonus = scaleByBasicAttackBonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddStatModifier))]
    public UnitConfigurator AddStatModifier(
        ContextValue modifierPercents,
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        bool useBaseValue = default,
        bool updateIfStatChanged = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(modifierPercents);
    
      var component = new AddStatModifier();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.ModifierPercents = modifierPercents;
      component.UseBaseValue = useBaseValue;
      component.UpdateIfStatChanged = updateIfStatChanged;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddTags"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddTags))]
    public UnitConfigurator AddTags(
        bool useInRandomEncounter = default,
        bool useInDungeon = default,
        bool isRanged = default,
        bool isCaster = default,
        AddTags.DifficultyRequirement difficultyRequirement = default,
        UnitTag[] tags = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddTags();
      component.UseInRandomEncounter = useInRandomEncounter;
      component.UseInDungeon = useInDungeon;
      component.IsRanged = isRanged;
      component.IsCaster = isCaster;
      component.m_DifficultyRequirement = difficultyRequirement;
      component.Tags = tags;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddTemporaryFeat"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feat"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddTemporaryFeat))]
    public UnitConfigurator AddTemporaryFeat(
        string feat = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddTemporaryFeat();
      component.m_Feat = BlueprintTool.GetRef<BlueprintFeatureReference>(feat);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddTricksterAthleticBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddTricksterAthleticBonus))]
    public UnitConfigurator AddTricksterAthleticBonus(
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddTricksterAthleticBonus();
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddUnitScale"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddUnitScale))]
    public UnitConfigurator AddUnitScale(
        float scaleIncreaseCoefficient = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddUnitScale();
      component.ScaleIncreaseCoefficient = scaleIncreaseCoefficient;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddUnlimitedSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilities"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddUnlimitedSpell))]
    public UnitConfigurator AddUnlimitedSpell(
        string[] abilities = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddUnlimitedSpell();
      component.m_Abilities = abilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddVendorItems"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="loot"><see cref="BlueprintUnitLoot"/></param>
    [Generated]
    [Implements(typeof(AddVendorItems))]
    public UnitConfigurator AddVendorItems(
        string loot = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddVendorItems();
      component.m_Loot = BlueprintTool.GetRef<BlueprintUnitLootReference>(loot);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddWeaponEnhancementBonusToStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddWeaponEnhancementBonusToStat))]
    public UnitConfigurator AddWeaponEnhancementBonusToStat(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int multiplier = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddWeaponEnhancementBonusToStat();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Multiplier = multiplier;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AdditionalDamageOnSneakAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AdditionalDamageOnSneakAttack))]
    public UnitConfigurator AdditionalDamageOnSneakAttack(
        int value = default,
        bool onlyRanged = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AdditionalDamageOnSneakAttack();
      component.Value = value;
      component.OnlyRanged = onlyRanged;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AeonSavedStateFeature"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="rank"><see cref="BlueprintFeature"/></param>
    /// <param name="resource"><see cref="BlueprintAbilityResource"/></param>
    /// <param name="invulnerabilityBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AeonSavedStateFeature))]
    public UnitConfigurator AddAeonSavedStateFeature(
        string rank = null,
        string resource = null,
        PrefabLink disappearFx = null,
        PrefabLink appearFx = null,
        float delaySeconds = default,
        string invulnerabilityBuff = null,
        float invulnerabilitySeconds = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(disappearFx);
      ValidateParam(appearFx);
    
      var component = new AeonSavedStateFeature();
      component.m_Rank = BlueprintTool.GetRef<BlueprintFeatureReference>(rank);
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(resource);
      component.DisappearFx = disappearFx ?? Constants.Empty.PrefabLink;
      component.AppearFx = appearFx ?? Constants.Empty.PrefabLink;
      component.DelaySeconds = delaySeconds;
      component.m_InvulnerabilityBuff = BlueprintTool.GetRef<BlueprintBuffReference>(invulnerabilityBuff);
      component.InvulnerabilitySeconds = invulnerabilitySeconds;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AlchemistInfusionFeat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AlchemistInfusionFeat))]
    public UnitConfigurator AddAlchemistInfusionFeat(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AlchemistInfusionFeat();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AllowDyingCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AllowDyingCondition))]
    public UnitConfigurator AddAllowDyingCondition(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AllowDyingCondition();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ApplyClassProgression"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="clazz"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="selectSpells"><see cref="BlueprintAbility"/></param>
    /// <param name="memorizeSpells"><see cref="BlueprintAbility"/></param>
    /// <param name="features"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(ApplyClassProgression))]
    public UnitConfigurator AddApplyClassProgression(
        int level = default,
        string clazz = null,
        string[] selectSpells = null,
        string[] memorizeSpells = null,
        string[] features = null,
        ParameterizedFeatureEntry[] parameterizedFeatures = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(parameterizedFeatures);
    
      var component = new ApplyClassProgression();
      component.Level = level;
      component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      component.m_SelectSpells = selectSpells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_MemorizeSpells = memorizeSpells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_Features = features.Select(name => BlueprintTool.GetRef<BlueprintFeatureReference>(name)).ToArray();
      component.ParameterizedFeatures = parameterizedFeatures;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackStatReplacement"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponTypes"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(AttackStatReplacement))]
    public UnitConfigurator AddAttackStatReplacement(
        StatType replacementStat = default,
        WeaponSubCategory subCategory = default,
        bool checkWeaponTypes = default,
        string[] weaponTypes = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AttackStatReplacement();
      component.ReplacementStat = replacementStat;
      component.SubCategory = subCategory;
      component.CheckWeaponTypes = checkWeaponTypes;
      component.m_WeaponTypes = weaponTypes.Select(name => BlueprintTool.GetRef<BlueprintWeaponTypeReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AutoFailCastingDefensively"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AutoFailCastingDefensively))]
    public UnitConfigurator AddAutoFailCastingDefensively(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AutoFailCastingDefensively();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BookOfDreamsSummonUnitsCountLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BookOfDreamsSummonUnitsCountLogic))]
    public UnitConfigurator AddBookOfDreamsSummonUnitsCountLogic(
        BlueprintComponent.Flags flags = default)
    {
      var component = new BookOfDreamsSummonUnitsCountLogic();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffDescriptorImmunity"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ignoreFeature"><see cref="BlueprintUnitFact"/></param>
    /// <param name="factToCheck"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(BuffDescriptorImmunity))]
    public UnitConfigurator AddBuffDescriptorImmunity(
        SpellDescriptorWrapper descriptor,
        string ignoreFeature = null,
        bool checkFact = default,
        string factToCheck = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffDescriptorImmunity();
      component.Descriptor = descriptor;
      component.m_IgnoreFeature = BlueprintTool.GetRef<BlueprintUnitFactReference>(ignoreFeature);
      component.CheckFact = checkFact;
      component.m_FactToCheck = BlueprintTool.GetRef<BlueprintUnitFactReference>(factToCheck);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffEnchantAnyWeapon"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantmentBlueprint"><see cref="BlueprintItemEnchantment"/></param>
    [Generated]
    [Implements(typeof(BuffEnchantAnyWeapon))]
    public UnitConfigurator AddBuffEnchantAnyWeapon(
        string enchantmentBlueprint = null,
        EquipSlotBase.SlotType slot = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffEnchantAnyWeapon();
      component.m_EnchantmentBlueprint = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(enchantmentBlueprint);
      component.Slot = slot;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffEnchantSpecificWeaponWorn"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantmentBlueprint"><see cref="BlueprintItemEnchantment"/></param>
    /// <param name="weaponBlueprint"><see cref="BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(BuffEnchantSpecificWeaponWorn))]
    public UnitConfigurator AddBuffEnchantSpecificWeaponWorn(
        string enchantmentBlueprint = null,
        string weaponBlueprint = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffEnchantSpecificWeaponWorn();
      component.m_EnchantmentBlueprint = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(enchantmentBlueprint);
      component.m_WeaponBlueprint = BlueprintTool.GetRef<BlueprintItemWeaponReference>(weaponBlueprint);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffEnchantWornItem"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enchantmentBlueprint"><see cref="BlueprintItemEnchantment"/></param>
    [Generated]
    [Implements(typeof(BuffEnchantWornItem))]
    public UnitConfigurator AddBuffEnchantWornItem(
        string enchantmentBlueprint = null,
        bool allWeapons = default,
        EquipSlotBase.SlotType slot = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffEnchantWornItem();
      component.m_EnchantmentBlueprint = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(enchantmentBlueprint);
      component.AllWeapons = allWeapons;
      component.Slot = slot;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Bugurt"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Bugurt))]
    public UnitConfigurator AddBugurt(
        BlueprintComponent.Flags flags = default)
    {
      var component = new Bugurt();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeFaction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="faction"><see cref="BlueprintFaction"/></param>
    [Generated]
    [Implements(typeof(ChangeFaction))]
    public UnitConfigurator AddChangeFaction(
        ChangeFaction.ChangeType type = default,
        string faction = null,
        bool allowDirectControl = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ChangeFaction();
      component.m_Type = type;
      component.m_Faction = BlueprintTool.GetRef<BlueprintFactionReference>(faction);
      component.m_AllowDirectControl = allowDirectControl;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeImpatience"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeImpatience))]
    public UnitConfigurator AddChangeImpatience(
        int delta = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ChangeImpatience();
      component.Delta = delta;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeIncomingDamageType"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeIncomingDamageType))]
    public UnitConfigurator AddChangeIncomingDamageType(
        DamageTypeDescription type,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(type);
    
      var component = new ChangeIncomingDamageType();
      component.Type = type;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeOutgoingDamageType"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeOutgoingDamageType))]
    public UnitConfigurator AddChangeOutgoingDamageType(
        DamageTypeDescription type,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(type);
    
      var component = new ChangeOutgoingDamageType();
      component.Type = type;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeVendorPrices"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeVendorPrices))]
    public UnitConfigurator AddChangeVendorPrices(
        Dictionary<BlueprintItem,long> itemsToCosts,
        ChangeVendorPrices.Entry[] priceOverrides = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(priceOverrides);
      ValidateParam(itemsToCosts);
    
      var component = new ChangeVendorPrices();
      component.m_PriceOverrides = priceOverrides;
      component.m_ItemsToCosts = itemsToCosts;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CombatManeuverOnCriticalHit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CombatManeuverOnCriticalHit))]
    public UnitConfigurator AddCombatManeuverOnCriticalHit(
        CombatManeuver maneuver = default,
        ActionsBuilder onSuccess = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CombatManeuverOnCriticalHit();
      component.Maneuver = maneuver;
      component.OnSuccess = onSuccess?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CompanionImmortality"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CompanionImmortality))]
    public UnitConfigurator AddCompanionImmortality(
        GameObject disappearFx,
        float disappearDelay = default,
        ActionsBuilder actions = null,
        LocalizedString fakeDeathMessage = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(disappearFx);
      ValidateParam(fakeDeathMessage);
    
      var component = new CompanionImmortality();
      component.DisappearDelay = disappearDelay;
      component.DisappearFx = disappearFx;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.FakeDeathMessage = fakeDeathMessage ?? Constants.Empty.String;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CompleteDamageImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CompleteDamageImmunity))]
    public UnitConfigurator AddCompleteDamageImmunity(
        BlueprintComponent.Flags flags = default)
    {
      var component = new CompleteDamageImmunity();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ConduitSurge"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(ConduitSurge))]
    public UnitConfigurator AddConduitSurge(
        ContextValue value,
        string buff = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new ConduitSurge();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ConfusionRollTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ConfusionRollTrigger))]
    public UnitConfigurator AddConfusionRollTrigger(
        ConfusionState state = default,
        ActionsBuilder action = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ConfusionRollTrigger();
      component.m_State = state;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DeflectArrows"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DeflectArrows))]
    public UnitConfigurator AddDeflectArrows(
        DeflectArrows.RestrictionType restriction = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DeflectArrows();
      component.m_Restriction = restriction;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DisableAttackType"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DisableAttackType))]
    public UnitConfigurator AddDisableAttackType(
        AttackTypeFlag attackType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DisableAttackType();
      component.m_AttackType = attackType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DisableClassAdditionalVisualSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DisableClassAdditionalVisualSettings))]
    public UnitConfigurator AddDisableClassAdditionalVisualSettings(
        BlueprintComponent.Flags flags = default)
    {
      var component = new DisableClassAdditionalVisualSettings();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DisableDeathFXs"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DisableDeathFXs))]
    public UnitConfigurator AddDisableDeathFXs(
        BlueprintComponent.Flags flags = default)
    {
      var component = new DisableDeathFXs();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DisableEquipmentSlot"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DisableEquipmentSlot))]
    public UnitConfigurator AddDisableEquipmentSlot(
        DisableEquipmentSlot.SlotType slotType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DisableEquipmentSlot();
      component.m_SlotType = slotType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DropLootAndDestroyOnDeactivate"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DropLootAndDestroyOnDeactivate))]
    public UnitConfigurator AddDropLootAndDestroyOnDeactivate(
        IDisposable coroutine,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(coroutine);
    
      var component = new DropLootAndDestroyOnDeactivate();
      component.m_Coroutine = coroutine;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DuelistParry"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="cloakFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(DuelistParry))]
    public UnitConfigurator AddDuelistParry(
        string cloakFact = null,
        DuelistParry.TargetType target = default,
        ConditionsBuilder attackerCondition = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DuelistParry();
      component.m_CloakFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(cloakFact);
      component.m_Target = target;
      component.AttackerCondition = attackerCondition?.Build() ?? Constants.Empty.Conditions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DweomerLeapLogic"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(DweomerLeapLogic))]
    public UnitConfigurator AddDweomerLeapLogic(
        string ability = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DweomerLeapLogic();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EnhancePotion"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="classes"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="archetypes"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(EnhancePotion))]
    public UnitConfigurator AddEnhancePotion(
        string[] classes = null,
        string[] archetypes = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new EnhancePotion();
      component.m_Classes = classes.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name)).ToArray();
      component.m_Archetypes = archetypes.Select(name => BlueprintTool.GetRef<BlueprintArchetypeReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FastBombs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilities"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(FastBombs))]
    public UnitConfigurator AddFastBombs(
        string[] abilities = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new FastBombs();
      component.m_Abilities = abilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FavoredEnemy"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFacts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(FavoredEnemy))]
    public UnitConfigurator AddFavoredEnemy(
        string[] checkedFacts = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new FavoredEnemy();
      component.m_CheckedFacts = checkedFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FavoredTerrain"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(FavoredTerrain))]
    public UnitConfigurator AddFavoredTerrain(
        AreaSetting setting = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new FavoredTerrain();
      component.Setting = setting;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FavoredTerrainExpertise"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(FavoredTerrainExpertise))]
    public UnitConfigurator AddFavoredTerrainExpertise(
        AreaSetting setting = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new FavoredTerrainExpertise();
      component.Setting = setting;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ForbidRotation"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ForbidRotation))]
    public UnitConfigurator AddForbidRotation(
        BlueprintComponent.Flags flags = default)
    {
      var component = new ForbidRotation();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ForbidSpecificSpellsCast"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(ForbidSpecificSpellsCast))]
    public UnitConfigurator AddForbidSpecificSpellsCast(
        SpellDescriptorWrapper spellDescriptor,
        string[] spells = null,
        bool useSpellDescriptor = default,
        ActionsBuilder onForbiddenCastAttempt = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ForbidSpecificSpellsCast();
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.UseSpellDescriptor = useSpellDescriptor;
      component.SpellDescriptor = spellDescriptor;
      component.OnForbiddenCastAttempt = onForbiddenCastAttempt?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ForbidSpellCasting"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ignoreFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(ForbidSpellCasting))]
    public UnitConfigurator AddForbidSpellCasting(
        bool forbidMagicItems = default,
        string ignoreFeature = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ForbidSpellCasting();
      component.ForbidMagicItems = forbidMagicItems;
      component.m_IgnoreFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(ignoreFeature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ForbidSpellbook"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbook"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    [Implements(typeof(ForbidSpellbook))]
    public UnitConfigurator AddForbidSpellbook(
        string spellbook = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ForbidSpellbook();
      component.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(spellbook);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ForbidSpellbookOnAlignmentDeviation"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbooks"><see cref="BlueprintSpellbook"/></param>
    /// <param name="ignoreFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ForbidSpellbookOnAlignmentDeviation))]
    public UnitConfigurator AddForbidSpellbookOnAlignmentDeviation(
        string[] spellbooks = null,
        AlignmentMaskType alignment = default,
        string ignoreFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ForbidSpellbookOnAlignmentDeviation();
      component.m_Spellbooks = spellbooks.Select(name => BlueprintTool.GetRef<BlueprintSpellbookReference>(name)).ToArray();
      component.Alignment = alignment;
      component.m_IgnoreFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(ignoreFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ForbidSpellbookOnArmorEquip"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbooks"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    [Implements(typeof(ForbidSpellbookOnArmorEquip))]
    public UnitConfigurator AddForbidSpellbookOnArmorEquip(
        string[] spellbooks = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ForbidSpellbookOnArmorEquip();
      component.m_Spellbooks = spellbooks.Select(name => BlueprintTool.GetRef<BlueprintSpellbookReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FreeActionSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(FreeActionSpell))]
    public UnitConfigurator AddFreeActionSpell(
        string ability = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new FreeActionSpell();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="GentlePersuasionConditioning"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="punishmentBuff"><see cref="BlueprintBuff"/></param>
    /// <param name="rewardBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(GentlePersuasionConditioning))]
    public UnitConfigurator AddGentlePersuasionConditioning(
        string punishmentBuff = null,
        string rewardBuff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new GentlePersuasionConditioning();
      component.m_PunishmentBuff = BlueprintTool.GetRef<BlueprintBuffReference>(punishmentBuff);
      component.m_RewardBuff = BlueprintTool.GetRef<BlueprintBuffReference>(rewardBuff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="GhostCriticalAndPrecisionImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GhostCriticalAndPrecisionImmunity))]
    public UnitConfigurator AddGhostCriticalAndPrecisionImmunity(
        BlueprintComponent.Flags flags = default)
    {
      var component = new GhostCriticalAndPrecisionImmunity();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="GreaterCombatMeneuver"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GreaterCombatMeneuver))]
    public UnitConfigurator AddGreaterCombatMeneuver(
        CombatManeuver maneuver = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new GreaterCombatMeneuver();
      component.Maneuver = maneuver;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="HalveIncomingAreaDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HalveIncomingAreaDamage))]
    public UnitConfigurator AddHalveIncomingAreaDamage(
        BlueprintComponent.Flags flags = default)
    {
      var component = new HalveIncomingAreaDamage();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="HideFactsWhileEtudePlaying"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="etude"><see cref="BlueprintEtude"/></param>
    /// <param name="replaceRace"><see cref="BlueprintRace"/></param>
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(HideFactsWhileEtudePlaying))]
    public UnitConfigurator AddHideFactsWhileEtudePlaying(
        string etude = null,
        string replaceRace = null,
        string[] facts = null,
        HashSet<BlueprintUnitFact> cachedFacts = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(cachedFacts);
    
      var component = new HideFactsWhileEtudePlaying();
      component.m_Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(etude);
      component.m_ReplaceRace = BlueprintTool.GetRef<BlueprintRaceReference>(replaceRace);
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_CachedFacts = cachedFacts;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="HigherMythicsReplace"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HigherMythicsReplace))]
    public UnitConfigurator AddHigherMythicsReplace(
        BlueprintComponent.Flags flags = default)
    {
      var component = new HigherMythicsReplace();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreIncommingDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreIncommingDamage))]
    public UnitConfigurator AddIgnoreIncommingDamage(
        BlueprintComponent.Flags flags = default)
    {
      var component = new IgnoreIncommingDamage();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreSpellImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreSpellImmunity))]
    public UnitConfigurator AddIgnoreSpellImmunity(
        SpellDescriptorWrapper spellDescriptor,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IgnoreSpellImmunity();
      component.SpellDescriptor = spellDescriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncorporealACBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncorporealACBonus))]
    public UnitConfigurator AddIncorporealACBonus(
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncorporealACBonus();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseActivatableAbilityGroupSize"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseActivatableAbilityGroupSize))]
    public UnitConfigurator AddIncreaseActivatableAbilityGroupSize(
        ActivatableAbilityGroup group = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncreaseActivatableAbilityGroupSize();
      component.Group = group;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseResourceAmount"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="resource"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    [Implements(typeof(IncreaseResourceAmount))]
    public UnitConfigurator AddIncreaseResourceAmount(
        string resource = null,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncreaseResourceAmount();
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(resource);
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseResourceAmountBySharedValue"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="resource"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    [Implements(typeof(IncreaseResourceAmountBySharedValue))]
    public UnitConfigurator AddIncreaseResourceAmountBySharedValue(
        ContextValue value,
        string resource = null,
        bool decrease = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new IncreaseResourceAmountBySharedValue();
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(resource);
      component.Value = value;
      component.Decrease = decrease;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseResourcesByClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="resource"><see cref="BlueprintAbilityResource"/></param>
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="archetype"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(IncreaseResourcesByClass))]
    public UnitConfigurator AddIncreaseResourcesByClass(
        string resource = null,
        string characterClass = null,
        string archetype = null,
        StatType stat = default,
        int baseValue = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncreaseResourcesByClass();
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(resource);
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype);
      component.Stat = stat;
      component.BaseValue = baseValue;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="InitiatorDisarmTrapTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(InitiatorDisarmTrapTrigger))]
    public UnitConfigurator AddInitiatorDisarmTrapTrigger(
        ActionsBuilder onDisarmSuccess = null,
        ActionsBuilder onDisarmFail = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new InitiatorDisarmTrapTrigger();
      component.OnDisarmSuccess = onDisarmSuccess?.Build() ?? Constants.Empty.Actions;
      component.OnDisarmFail = onDisarmFail?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="InitiatorSavingThrowTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(InitiatorSavingThrowTrigger))]
    public UnitConfigurator AddInitiatorSavingThrowTrigger(
        ActionsBuilder onSuccessfulSave = null,
        ActionsBuilder onFailedSave = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new InitiatorSavingThrowTrigger();
      component.OnSuccessfulSave = onSuccessfulSave?.Build() ?? Constants.Empty.Actions;
      component.OnFailedSave = onFailedSave?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KeepAlliesAlive"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="walkingDeadBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(KeepAlliesAlive))]
    public UnitConfigurator AddKeepAlliesAlive(
        ContextValue maxAttacksCount,
        string walkingDeadBuff = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(maxAttacksCount);
    
      var component = new KeepAlliesAlive();
      component.m_MaxAttacksCount = maxAttacksCount;
      component.WalkingDeadBuff = BlueprintTool.GetRef<BlueprintBuffReference>(walkingDeadBuff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LearnSpellList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="spellList"><see cref="BlueprintSpellList"/></param>
    /// <param name="archetype"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(LearnSpellList))]
    public UnitConfigurator AddLearnSpellList(
        string characterClass = null,
        string spellList = null,
        string archetype = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new LearnSpellList();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(spellList);
      component.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LearnSpells"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(LearnSpells))]
    public UnitConfigurator AddLearnSpells(
        string characterClass = null,
        string[] spells = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new LearnSpells();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LimbsApartDismembermentRestricted"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LimbsApartDismembermentRestricted))]
    public UnitConfigurator AddLimbsApartDismembermentRestricted(
        BlueprintComponent.Flags flags = default)
    {
      var component = new LimbsApartDismembermentRestricted();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LockEquipmentSlot"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LockEquipmentSlot))]
    public UnitConfigurator AddLockEquipmentSlot(
        LockEquipmentSlot.SlotType slotType = default,
        bool deactivate = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new LockEquipmentSlot();
      component.m_SlotType = slotType;
      component.m_Deactivate = deactivate;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MarkPassive"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MarkPassive))]
    public UnitConfigurator AddMarkPassive(
        BlueprintComponent.Flags flags = default)
    {
      var component = new MarkPassive();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MayBanterOnRest"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MayBanterOnRest))]
    public UnitConfigurator AddMayBanterOnRest(
        BlueprintComponent.Flags flags = default)
    {
      var component = new MayBanterOnRest();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MountedShield"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MountedShield))]
    public UnitConfigurator AddMountedShield(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new MountedShield();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MovementDistanceTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MovementDistanceTrigger))]
    public UnitConfigurator AddMovementDistanceTrigger(
        ContextValue distanceInFeet,
        ActionsBuilder action = null,
        bool limitTiggerCountInOneRound = default,
        int tiggerCountMaximumInOneRound = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(distanceInFeet);
    
      var component = new MovementDistanceTrigger();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.DistanceInFeet = distanceInFeet;
      component.LimitTiggerCountInOneRound = limitTiggerCountInOneRound;
      component.TiggerCountMaximumInOneRound = tiggerCountMaximumInOneRound;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="NenioSpecialPolymorphWhileEtudePlaying"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="etude"><see cref="BlueprintEtude"/></param>
    /// <param name="standardPolymorphAbility"><see cref="BlueprintActivatableAbility"/></param>
    /// <param name="specialPolymorphBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(NenioSpecialPolymorphWhileEtudePlaying))]
    public UnitConfigurator AddNenioSpecialPolymorphWhileEtudePlaying(
        string etude = null,
        string standardPolymorphAbility = null,
        string specialPolymorphBuff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new NenioSpecialPolymorphWhileEtudePlaying();
      component.m_Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(etude);
      component.m_StandardPolymorphAbility = BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(standardPolymorphAbility);
      component.m_SpecialPolymorphBuff = BlueprintTool.GetRef<BlueprintBuffReference>(specialPolymorphBuff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OverrideVisionRange"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(OverrideVisionRange))]
    public UnitConfigurator AddOverrideVisionRange(
        int visionRangeInMeters = default,
        bool alsoInCombat = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new OverrideVisionRange();
      component.VisionRangeInMeters = visionRangeInMeters;
      component.AlsoInCombat = alsoInCombat;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PreventHealing"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PreventHealing))]
    public UnitConfigurator AddPreventHealing(
        BlueprintComponent.Flags flags = default)
    {
      var component = new PreventHealing();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PriorityTarget"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="priorityFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(PriorityTarget))]
    public UnitConfigurator AddPriorityTarget(
        string priorityFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new PriorityTarget();
      component.PriorityFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(priorityFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RaiseBAB"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RaiseBAB))]
    public UnitConfigurator AddRaiseBAB(
        ContextValue targetValue,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(targetValue);
    
      var component = new RaiseBAB();
      component.TargetValue = targetValue;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RaiseStatToMinimum"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RaiseStatToMinimum))]
    public UnitConfigurator AddRaiseStatToMinimum(
        ContextValue targetValue,
        StatType stat = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(targetValue);
    
      var component = new RaiseStatToMinimum();
      component.TargetValue = targetValue;
      component.Stat = stat;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RangedCleave"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RangedCleave))]
    public UnitConfigurator AddRangedCleave(
        Feet range,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RangedCleave();
      component.Range = range;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RedirectDamageToPet"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RedirectDamageToPet))]
    public UnitConfigurator AddRedirectDamageToPet(
        int percentRedirected = default,
        PetType petType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RedirectDamageToPet();
      component.m_PercentRedirected = percentRedirected;
      component.m_PetType = petType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RemoveBuffIfPartyNotInCombat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemoveBuffIfPartyNotInCombat))]
    public UnitConfigurator AddRemoveBuffIfPartyNotInCombat(
        BlueprintComponent.Flags flags = default)
    {
      var component = new RemoveBuffIfPartyNotInCombat();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceStatBaseAttribute"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ReplaceStatBaseAttribute))]
    public UnitConfigurator AddReplaceStatBaseAttribute(
        StatType targetStat = default,
        StatType baseAttributeReplacement = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReplaceStatBaseAttribute();
      component.TargetStat = targetStat;
      component.BaseAttributeReplacement = baseAttributeReplacement;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Revolt"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Revolt))]
    public UnitConfigurator AddRevolt(
        BlueprintComponent.Flags flags = default)
    {
      var component = new Revolt();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ScrollSpecialization"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="specializedClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(ScrollSpecialization))]
    public UnitConfigurator AddScrollSpecialization(
        string specializedClass = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ScrollSpecialization();
      component.m_SpecializedClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(specializedClass);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SetMagusFeatureActive"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetMagusFeatureActive))]
    public UnitConfigurator AddSetMagusFeatureActive(
        SetMagusFeatureActive.FeatureType feature = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SetMagusFeatureActive();
      component.m_Feature = feature;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SetRunBackLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetRunBackLogic))]
    public UnitConfigurator AddSetRunBackLogic(
        float triggerDistance = default,
        float runBackDistance = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SetRunBackLogic();
      component.TriggerDistance = triggerDistance;
      component.RunBackDistance = runBackDistance;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShroudOfWater"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="upgradeFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(ShroudOfWater))]
    public UnitConfigurator AddShroudOfWater(
        ContextValue baseValue,
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        string upgradeFeature = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(baseValue);
    
      var component = new ShroudOfWater();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.BaseValue = baseValue;
      component.m_UpgradeFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(upgradeFeature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpecificBuffImmunity"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(SpecificBuffImmunity))]
    public UnitConfigurator AddSpecificBuffImmunity(
        string buff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SpecificBuffImmunity();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellImmunityToSpellDescriptor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="casterIgnoreImmunityFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SpellImmunityToSpellDescriptor))]
    public UnitConfigurator AddSpellImmunityToSpellDescriptor(
        SpellDescriptorWrapper descriptor,
        string casterIgnoreImmunityFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SpellImmunityToSpellDescriptor();
      component.Descriptor = descriptor;
      component.m_CasterIgnoreImmunityFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(casterIgnoreImmunityFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellLinkEvocation"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpellLinkEvocation))]
    public UnitConfigurator AddSpellLinkEvocation(
        BlueprintComponent.Flags flags = default)
    {
      var component = new SpellLinkEvocation();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellResistanceAgainstAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpellResistanceAgainstAlignment))]
    public UnitConfigurator AddSpellResistanceAgainstAlignment(
        ContextValue value,
        AlignmentComponent alignment = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new SpellResistanceAgainstAlignment();
      component.Value = value;
      component.Alignment = alignment;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellResistanceAgainstSpellDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpellResistanceAgainstSpellDescriptor))]
    public UnitConfigurator AddSpellResistanceAgainstSpellDescriptor(
        ContextValue value,
        SpellDescriptorWrapper spellDescriptor,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new SpellResistanceAgainstSpellDescriptor();
      component.Value = value;
      component.SpellDescriptor = spellDescriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpontaneousSpellConversion"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="spellsByLevel"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(SpontaneousSpellConversion))]
    public UnitConfigurator AddSpontaneousSpellConversion(
        string characterClass = null,
        string[] spellsByLevel = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SpontaneousSpellConversion();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_SpellsByLevel = spellsByLevel.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SufferFromHealing"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SufferFromHealing))]
    public UnitConfigurator AddSufferFromHealing(
        DamageTypeDescription damageDescription,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(damageDescription);
    
      var component = new SufferFromHealing();
      component.DamageDescription = damageDescription;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SuppressBuffs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buffs"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(SuppressBuffs))]
    public UnitConfigurator AddSuppressBuffs(
        SpellDescriptorWrapper descriptor,
        string[] buffs = null,
        SpellSchool[] schools = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SuppressBuffs();
      component.m_Buffs = buffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray();
      component.Schools = schools;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SuppressDismember"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SuppressDismember))]
    public UnitConfigurator AddSuppressDismember(
        BlueprintComponent.Flags flags = default)
    {
      var component = new SuppressDismember();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SwarmAoeVulnerability"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SwarmAoeVulnerability))]
    public UnitConfigurator AddSwarmAoeVulnerability(
        BlueprintComponent.Flags flags = default)
    {
      var component = new SwarmAoeVulnerability();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SwarmDamageResistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SwarmDamageResistance))]
    public UnitConfigurator AddSwarmDamageResistance(
        bool diminutiveOrLower = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SwarmDamageResistance();
      component.DiminutiveOrLower = diminutiveOrLower;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TricksterParry"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TricksterParry))]
    public UnitConfigurator AddTricksterParry(
        TricksterParry.TargetType target = default,
        ConditionsBuilder attackerCondition = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TricksterParry();
      component.m_Target = target;
      component.AttackerCondition = attackerCondition?.Build() ?? Constants.Empty.Conditions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UnearthlyGrace"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnearthlyGrace))]
    public UnitConfigurator AddUnearthlyGrace(
        BlueprintComponent.Flags flags = default)
    {
      var component = new UnearthlyGrace();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UnfailingBeacon"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnfailingBeacon))]
    public UnitConfigurator AddUnfailingBeacon(
        BlueprintComponent.Flags flags = default)
    {
      var component = new UnfailingBeacon();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UnholyGrace"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnholyGrace))]
    public UnitConfigurator AddUnholyGrace(
        BlueprintComponent.Flags flags = default)
    {
      var component = new UnholyGrace();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UniqueBuff"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UniqueBuff))]
    public UnitConfigurator AddUniqueBuff(
        BlueprintComponent.Flags flags = default)
    {
      var component = new UniqueBuff();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UnitHealthGuard"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitHealthGuard))]
    public UnitConfigurator AddUnitHealthGuard(
        int healthPercent = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new UnitHealthGuard();
      component.HealthPercent = healthPercent;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Untargetable"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Untargetable))]
    public UnitConfigurator AddUntargetable(
        BlueprintComponent.Flags flags = default)
    {
      var component = new Untargetable();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTraining"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponTraining))]
    public UnitConfigurator AddWeaponTraining(
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponTraining();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTrainingAttackStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponTrainingAttackStatReplacement))]
    public UnitConfigurator AddWeaponTrainingAttackStatReplacement(
        StatType replacementStat = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponTrainingAttackStatReplacement();
      component.ReplacementStat = replacementStat;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PregenDollSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PregenDollSettings))]
    public UnitConfigurator AddPregenDollSettings(
        PregenDollSettings.Entry defaultValue,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(defaultValue);
    
      var component = new PregenDollSettings();
      component.Default = defaultValue;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistAcceptBurnTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddKineticistAcceptBurnTrigger))]
    public UnitConfigurator AddKineticistAcceptBurnTrigger(
        ActionsBuilder action = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddKineticistAcceptBurnTrigger();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistBlade"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="blade"><see cref="BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(AddKineticistBlade))]
    public UnitConfigurator AddKineticistBlade(
        string blade = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddKineticistBlade();
      component.m_Blade = BlueprintTool.GetRef<BlueprintItemWeaponReference>(blade);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistBurnModifier"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="appliableTo"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddKineticistBurnModifier))]
    public UnitConfigurator AddKineticistBurnModifier(
        ContextValue burnValue,
        KineticistBurnType burnType = default,
        int value = default,
        bool removeBuffOnAcceptBurn = default,
        bool useContextValue = default,
        string[] appliableTo = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(burnValue);
    
      var component = new AddKineticistBurnModifier();
      component.BurnType = burnType;
      component.Value = value;
      component.RemoveBuffOnAcceptBurn = removeBuffOnAcceptBurn;
      component.UseContextValue = useContextValue;
      component.BurnValue = burnValue;
      component.m_AppliableTo = appliableTo.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistBurnValueChangedTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddKineticistBurnValueChangedTrigger))]
    public UnitConfigurator AddKineticistBurnValueChangedTrigger(
        ActionsBuilder action = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddKineticistBurnValueChangedTrigger();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistElementalOverflow"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="firesFury"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddKineticistElementalOverflow))]
    public UnitConfigurator AddKineticistElementalOverflow(
        ContextValue bonus,
        bool ignoreBurn = default,
        bool elementalEngine = default,
        string firesFury = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new AddKineticistElementalOverflow();
      component.Bonus = bonus;
      component.IgnoreBurn = ignoreBurn;
      component.ElementalEngine = elementalEngine;
      component.m_FiresFury = BlueprintTool.GetRef<BlueprintUnitFactReference>(firesFury);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistPart"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="clazz"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="maxBurn"><see cref="BlueprintAbilityResource"/></param>
    /// <param name="maxBurnPerRound"><see cref="BlueprintAbilityResource"/></param>
    /// <param name="gatherPowerAbility"><see cref="BlueprintAbility"/></param>
    /// <param name="gatherPowerIncreaseFeature"><see cref="BlueprintFeature"/></param>
    /// <param name="gatherPowerBuff1"><see cref="BlueprintBuff"/></param>
    /// <param name="gatherPowerBuff2"><see cref="BlueprintBuff"/></param>
    /// <param name="gatherPowerBuff3"><see cref="BlueprintBuff"/></param>
    /// <param name="blasts"><see cref="BlueprintAbility"/></param>
    /// <param name="bladeActivatedBuff"><see cref="BlueprintBuff"/></param>
    /// <param name="canGatherPowerWithShieldBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AddKineticistPart))]
    public UnitConfigurator AddKineticistPart(
        string clazz = null,
        StatType mainStat = default,
        string maxBurn = null,
        string maxBurnPerRound = null,
        string gatherPowerAbility = null,
        string gatherPowerIncreaseFeature = null,
        string gatherPowerBuff1 = null,
        string gatherPowerBuff2 = null,
        string gatherPowerBuff3 = null,
        string[] blasts = null,
        string bladeActivatedBuff = null,
        string canGatherPowerWithShieldBuff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddKineticistPart();
      component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      component.MainStat = mainStat;
      component.m_MaxBurn = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(maxBurn);
      component.m_MaxBurnPerRound = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(maxBurnPerRound);
      component.m_GatherPowerAbility = BlueprintTool.GetRef<BlueprintAbilityReference>(gatherPowerAbility);
      component.m_GatherPowerIncreaseFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(gatherPowerIncreaseFeature);
      component.m_GatherPowerBuff1 = BlueprintTool.GetRef<BlueprintBuffReference>(gatherPowerBuff1);
      component.m_GatherPowerBuff2 = BlueprintTool.GetRef<BlueprintBuffReference>(gatherPowerBuff2);
      component.m_GatherPowerBuff3 = BlueprintTool.GetRef<BlueprintBuffReference>(gatherPowerBuff3);
      component.m_Blasts = blasts.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_BladeActivatedBuff = BlueprintTool.GetRef<BlueprintBuffReference>(bladeActivatedBuff);
      component.m_CanGatherPowerWithShieldBuff = BlueprintTool.GetRef<BlueprintBuffReference>(canGatherPowerWithShieldBuff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SetKineticistGatherPowerMode"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetKineticistGatherPowerMode))]
    public UnitConfigurator AddSetKineticistGatherPowerMode(
        KineticistGatherPowerMode mode = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SetKineticistGatherPowerMode();
      component.Mode = mode;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RestrictionCanGatherPower"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RestrictionCanGatherPower))]
    public UnitConfigurator AddRestrictionCanGatherPower(
        BlueprintComponent.Flags flags = default)
    {
      var component = new RestrictionCanGatherPower();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RestrictionCanUseKineticBlade"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RestrictionCanUseKineticBlade))]
    public UnitConfigurator AddRestrictionCanUseKineticBlade(
        BlueprintComponent.Flags flags = default)
    {
      var component = new RestrictionCanUseKineticBlade();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Polymorph"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="replaceUnitForInspection"><see cref="BlueprintUnit"/></param>
    /// <param name="portrait"><see cref="BlueprintPortrait"/></param>
    /// <param name="mainHand"><see cref="BlueprintItemWeapon"/></param>
    /// <param name="offHand"><see cref="BlueprintItemWeapon"/></param>
    /// <param name="additionalLimbs"><see cref="BlueprintItemWeapon"/></param>
    /// <param name="secondaryAdditionalLimbs"><see cref="BlueprintItemWeapon"/></param>
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(Polymorph))]
    public UnitConfigurator AddPolymorph(
        UnitViewLink prefab,
        UnitViewLink prefabFemale,
        Polymorph.VisualTransitionSettings enterTransition,
        Polymorph.VisualTransitionSettings exitTransition,
        PolymorphTransitionSettings transitionExternal,
        SpecialDollType specialDollType = default,
        string replaceUnitForInspection = null,
        string portrait = null,
        bool keepSlots = default,
        Size size = default,
        int strengthBonus = default,
        int dexterityBonus = default,
        int constitutionBonus = default,
        int naturalArmor = default,
        string mainHand = null,
        string offHand = null,
        string[] additionalLimbs = null,
        string[] secondaryAdditionalLimbs = null,
        string[] facts = null,
        bool silentCaster = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(prefab);
      ValidateParam(prefabFemale);
      ValidateParam(enterTransition);
      ValidateParam(exitTransition);
      ValidateParam(transitionExternal);
    
      var component = new Polymorph();
      component.m_Prefab = prefab;
      component.m_PrefabFemale = prefabFemale;
      component.m_SpecialDollType = specialDollType;
      component.m_ReplaceUnitForInspection = BlueprintTool.GetRef<BlueprintUnitReference>(replaceUnitForInspection);
      component.m_Portrait = BlueprintTool.GetRef<BlueprintPortraitReference>(portrait);
      component.m_KeepSlots = keepSlots;
      component.Size = size;
      component.StrengthBonus = strengthBonus;
      component.DexterityBonus = dexterityBonus;
      component.ConstitutionBonus = constitutionBonus;
      component.NaturalArmor = naturalArmor;
      component.m_MainHand = BlueprintTool.GetRef<BlueprintItemWeaponReference>(mainHand);
      component.m_OffHand = BlueprintTool.GetRef<BlueprintItemWeaponReference>(offHand);
      component.m_AdditionalLimbs = additionalLimbs.Select(name => BlueprintTool.GetRef<BlueprintItemWeaponReference>(name)).ToArray();
      component.m_SecondaryAdditionalLimbs = secondaryAdditionalLimbs.Select(name => BlueprintTool.GetRef<BlueprintItemWeaponReference>(name)).ToArray();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_EnterTransition = enterTransition;
      component.m_ExitTransition = exitTransition;
      component.m_TransitionExternal = transitionExternal;
      component.m_SilentCaster = silentCaster;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RemoveBuffOnLoad"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemoveBuffOnLoad))]
    public UnitConfigurator AddRemoveBuffOnLoad(
        bool onlyFromParty = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RemoveBuffOnLoad();
      component.OnlyFromParty = onlyFromParty;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RemoveBuffOnTurnOn"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemoveBuffOnTurnOn))]
    public UnitConfigurator AddRemoveBuffOnTurnOn(
        bool onlyFromParty = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RemoveBuffOnTurnOn();
      component.OnlyFromParty = onlyFromParty;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAreaEffect"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="areaEffect"><see cref="BlueprintAbilityAreaEffect"/></param>
    [Generated]
    [Implements(typeof(AddAreaEffect))]
    public UnitConfigurator AddAreaEffect(
        string areaEffect = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddAreaEffect();
      component.m_AreaEffect = BlueprintTool.GetRef<BlueprintAbilityAreaEffectReference>(areaEffect);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddAttackBonus))]
    public UnitConfigurator AddAttackBonus(
        int bonus = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddAttackBonus();
      component.Bonus = bonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCheatDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddCheatDamageBonus))]
    public UnitConfigurator AddCheatDamageBonus(
        int bonus = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddCheatDamageBonus();
      component.Bonus = bonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEffectContextFastHealing"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEffectContextFastHealing))]
    public UnitConfigurator AddEffectContextFastHealing(
        ContextValue bonus,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new AddEffectContextFastHealing();
      component.Bonus = bonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEffectProtectionFromElement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEffectProtectionFromElement))]
    public UnitConfigurator AddEffectProtectionFromElement(
        string element,
        int shieldCapacity = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddEffectProtectionFromElement();
      component.Element = element;
      component.ShieldCapacity = shieldCapacity;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEffectRegeneration"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEffectRegeneration))]
    public UnitConfigurator AddEffectRegeneration(
        int heal = default,
        bool unremovable = default,
        bool cancelByMagicWeapon = default,
        DamageEnergyType[] cancelDamageEnergyTypes = null,
        DamageAlignment[] cancelDamageAlignmentTypes = null,
        PhysicalDamageMaterial[] cancelDamageMaterials = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddEffectRegeneration();
      component.Heal = heal;
      component.Unremovable = unremovable;
      component.CancelByMagicWeapon = cancelByMagicWeapon;
      component.CancelDamageEnergyTypes = cancelDamageEnergyTypes;
      component.CancelDamageAlignmentTypes = cancelDamageAlignmentTypes;
      component.CancelDamageMaterials = cancelDamageMaterials;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddGenericStatBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddGenericStatBonus))]
    public UnitConfigurator AddGenericStatBonus(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddGenericStatBonus();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddMirrorImage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddMirrorImage))]
    public UnitConfigurator AddMirrorImage(
        ContextDiceValue count,
        int maxCount = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(count);
    
      var component = new AddMirrorImage();
      component.Count = count;
      component.MaxCount = maxCount;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeHitDie"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeHitDie))]
    public UnitConfigurator AddChangeHitDie(
        DiceType hitDie = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ChangeHitDie();
      component.m_HitDie = hitDie;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="NegativeLevelComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(NegativeLevelComponent))]
    public UnitConfigurator AddNegativeLevelComponent(
        BlueprintComponent.Flags flags = default)
    {
      var component = new NegativeLevelComponent();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RemoveBuffIfCasterIsMissing"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemoveBuffIfCasterIsMissing))]
    public UnitConfigurator AddRemoveBuffIfCasterIsMissing(
        bool removeOnCasterDeath = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RemoveBuffIfCasterIsMissing();
      component.RemoveOnCasterDeath = removeOnCasterDeath;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ResurrectionLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ResurrectionLogic))]
    public UnitConfigurator AddResurrectionLogic(
        GameObject firstFx,
        GameObject secondFx,
        float firstFxDelay = default,
        float secondFxDelay = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(firstFx);
      ValidateParam(secondFx);
    
      var component = new ResurrectionLogic();
      component.FirstFx = firstFx;
      component.FirstFxDelay = firstFxDelay;
      component.SecondFx = secondFx;
      component.SecondFxDelay = secondFxDelay;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SetBuffOnsetDelay"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SetBuffOnsetDelay))]
    public UnitConfigurator AddSetBuffOnsetDelay(
        ContextDurationValue delay,
        ActionsBuilder onStart = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(delay);
    
      var component = new SetBuffOnsetDelay();
      component.Delay = delay;
      component.OnStart = onStart?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpecialAnimationState"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpecialAnimationState))]
    public UnitConfigurator AddSpecialAnimationState(
        UnitAnimationActionBuffState animation,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(animation);
    
      var component = new SpecialAnimationState();
      component.Animation = animation;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SummonedUnitBuff"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SummonedUnitBuff))]
    public UnitConfigurator AddSummonedUnitBuff(
        BlueprintComponent.Flags flags = default)
    {
      var component = new SummonedUnitBuff();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponAttackTypeDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponAttackTypeDamageBonus))]
    public UnitConfigurator AddWeaponAttackTypeDamageBonus(
        ContextValue value,
        WeaponRangeType type = default,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new WeaponAttackTypeDamageBonus();
      component.Type = type;
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ActivatableAbilityResourceLogic"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="requiredResource"><see cref="BlueprintAbilityResource"/></param>
    /// <param name="freeBlueprint"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ActivatableAbilityResourceLogic))]
    public UnitConfigurator AddActivatableAbilityResourceLogic(
        ActivatableAbilityResourceLogic.ResourceSpendType spendType = default,
        string requiredResource = null,
        string freeBlueprint = null,
        WeaponCategory[] categories = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ActivatableAbilityResourceLogic();
      component.SpendType = spendType;
      component.m_RequiredResource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(requiredResource);
      component.m_FreeBlueprint = BlueprintTool.GetRef<BlueprintUnitFactReference>(freeBlueprint);
      component.Categories = categories;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ActivatableAbilityUnitCommand"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ActivatableAbilityUnitCommand))]
    public UnitConfigurator AddActivatableAbilityUnitCommand(
        UnitCommand.CommandType type = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ActivatableAbilityUnitCommand();
      component.Type = type;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddActivatableAbilityComponent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="activatableAbilities"><see cref="BlueprintActivatableAbility"/></param>
    [Generated]
    [Implements(typeof(AddActivatableAbilityComponent))]
    public UnitConfigurator AddActivatableAbilityComponent(
        string[] activatableAbilities = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddActivatableAbilityComponent();
      component.m_ActivatableAbilities = activatableAbilities.Select(name => BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DeactivateImmediatelyIfNoAttacksThisRound"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DeactivateImmediatelyIfNoAttacksThisRound))]
    public UnitConfigurator AddDeactivateImmediatelyIfNoAttacksThisRound(
        BlueprintComponent.Flags flags = default)
    {
      var component = new DeactivateImmediatelyIfNoAttacksThisRound();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RestrictionHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(RestrictionHasFact))]
    public UnitConfigurator AddRestrictionHasFact(
        string feature = null,
        bool not = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RestrictionHasFact();
      component.m_Feature = BlueprintTool.GetRef<BlueprintUnitFactReference>(feature);
      component.Not = not;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RestrictionHasUnitCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RestrictionHasUnitCondition))]
    public UnitConfigurator AddRestrictionHasUnitCondition(
        UnitCondition condition = default,
        bool invert = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RestrictionHasUnitCondition();
      component.Condition = condition;
      component.Invert = invert;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RestrictionKensaiWeapon"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="chosenWeaponBlueprint"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(RestrictionKensaiWeapon))]
    public UnitConfigurator AddRestrictionKensaiWeapon(
        string characterClass = null,
        string chosenWeaponBlueprint = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RestrictionKensaiWeapon();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(chosenWeaponBlueprint);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RestrictionRangedWeapon"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RestrictionRangedWeapon))]
    public UnitConfigurator AddRestrictionRangedWeapon(
        BlueprintComponent.Flags flags = default)
    {
      var component = new RestrictionRangedWeapon();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RestrictionUnitConditionUnlessFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(RestrictionUnitConditionUnlessFact))]
    public UnitConfigurator AddRestrictionUnitConditionUnlessFact(
        UnitCondition condition = default,
        string checkedFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RestrictionUnitConditionUnlessFact();
      component.Condition = condition;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RestrictionUnlockableFlag"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="neededFlag"><see cref="BlueprintUnlockableFlag"/></param>
    [Generated]
    [Implements(typeof(RestrictionUnlockableFlag))]
    public UnitConfigurator AddRestrictionUnlockableFlag(
        string neededFlag = null,
        bool invert = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RestrictionUnlockableFlag();
      component.m_NeededFlag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(neededFlag);
      component.Invert = invert;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddEnergyDamageTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddEnergyDamageTrigger))]
    public UnitConfigurator AddEnergyDamageTrigger(
        DamageEnergyType damageType = default,
        bool spellsOnly = default,
        ActionsBuilder actions = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddEnergyDamageTrigger();
      component.DamageType = damageType;
      component.SpellsOnly = spellsOnly;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddIncomingDamageTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddIncomingDamageTrigger))]
    public UnitConfigurator AddIncomingDamageTrigger(
        ContextValue targetValue,
        ActionsBuilder actions = null,
        bool triggerOnStatDamageOrEnergyDrain = default,
        bool ignoreDamageFromThisFact = default,
        bool reduceBelowZero = default,
        bool checkDamageDealt = default,
        CompareOperation.Type compareType = default,
        bool checkWeaponAttackType = default,
        AttackTypeFlag attackType = default,
        bool checkEnergyDamageType = default,
        DamageEnergyType energyType = default,
        bool checkDamagePhysicalTypeNot = default,
        PhysicalDamageForm damagePhysicalTypeNot = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(targetValue);
    
      var component = new AddIncomingDamageTrigger();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.TriggerOnStatDamageOrEnergyDrain = triggerOnStatDamageOrEnergyDrain;
      component.IgnoreDamageFromThisFact = ignoreDamageFromThisFact;
      component.ReduceBelowZero = reduceBelowZero;
      component.CheckDamageDealt = checkDamageDealt;
      component.CompareType = compareType;
      component.TargetValue = targetValue;
      component.CheckWeaponAttackType = checkWeaponAttackType;
      component.AttackType = attackType;
      component.CheckEnergyDamageType = checkEnergyDamageType;
      component.EnergyType = energyType;
      component.CheckDamagePhysicalTypeNot = checkDamagePhysicalTypeNot;
      component.DamagePhysicalTypeNot = damagePhysicalTypeNot;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddInitiatorPartySkillRollTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddInitiatorPartySkillRollTrigger))]
    public UnitConfigurator AddInitiatorPartySkillRollTrigger(
        bool onlySuccess = default,
        StatType skill = default,
        ActionsBuilder action = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddInitiatorPartySkillRollTrigger();
      component.OnlySuccess = onlySuccess;
      component.Skill = skill;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddInitiatorSavingThrowTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddInitiatorSavingThrowTrigger))]
    public UnitConfigurator AddInitiatorSavingThrowTrigger(
        bool onlyPass = default,
        bool onlyFail = default,
        ActionsBuilder action = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddInitiatorSavingThrowTrigger();
      component.OnlyPass = onlyPass;
      component.OnlyFail = onlyFail;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddKineticistInfusionDamageTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="BlueprintWeaponType"/></param>
    /// <param name="abilityList"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddKineticistInfusionDamageTrigger))]
    public UnitConfigurator AddKineticistInfusionDamageTrigger(
        SpellDescriptorWrapper spellDescriptorsList,
        TimeSpan lastFrameTime,
        ActionsBuilder actions = null,
        bool triggerOnStatDamageOrEnergyDrain = default,
        bool checkWeaponType = default,
        bool checkSpellDescriptor = default,
        bool checkSpellParent = default,
        bool triggerOnDirectDamage = default,
        string weaponType = null,
        string[] abilityList = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddKineticistInfusionDamageTrigger();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.TriggerOnStatDamageOrEnergyDrain = triggerOnStatDamageOrEnergyDrain;
      component.CheckWeaponType = checkWeaponType;
      component.CheckSpellDescriptor = checkSpellDescriptor;
      component.CheckSpellParent = checkSpellParent;
      component.TriggerOnDirectDamage = triggerOnDirectDamage;
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      component.m_AbilityList = abilityList.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.SpellDescriptorsList = spellDescriptorsList;
      component.m_LastFrameTime = lastFrameTime;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddOutgoingDamageTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="BlueprintWeaponType"/></param>
    /// <param name="abilityList"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddOutgoingDamageTrigger))]
    public UnitConfigurator AddOutgoingDamageTrigger(
        ContextValue targetValue,
        SpellDescriptorWrapper spellDescriptorsList,
        ActionsBuilder actions = null,
        bool triggerOnStatDamageOrEnergyDrain = default,
        bool checkWeaponType = default,
        bool checkAbilityType = default,
        AbilityType abilityType = default,
        bool checkSpellDescriptor = default,
        bool checkSpellParent = default,
        bool notZeroDamage = default,
        bool checkDamageDealt = default,
        CompareOperation.Type compareType = default,
        bool checkEnergyDamageType = default,
        DamageEnergyType energyType = default,
        bool applyToAreaEffectDamage = default,
        bool targetKilledByThisDamage = default,
        string weaponType = null,
        string[] abilityList = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(targetValue);
    
      var component = new AddOutgoingDamageTrigger();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.TriggerOnStatDamageOrEnergyDrain = triggerOnStatDamageOrEnergyDrain;
      component.CheckWeaponType = checkWeaponType;
      component.CheckAbilityType = checkAbilityType;
      component.m_AbilityType = abilityType;
      component.CheckSpellDescriptor = checkSpellDescriptor;
      component.CheckSpellParent = checkSpellParent;
      component.NotZeroDamage = notZeroDamage;
      component.CheckDamageDealt = checkDamageDealt;
      component.CompareType = compareType;
      component.TargetValue = targetValue;
      component.CheckEnergyDamageType = checkEnergyDamageType;
      component.EnergyType = energyType;
      component.ApplyToAreaEffectDamage = applyToAreaEffectDamage;
      component.TargetKilledByThisDamage = targetKilledByThisDamage;
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      component.m_AbilityList = abilityList.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.SpellDescriptorsList = spellDescriptorsList;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellDiceBonusTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddSpellDiceBonusTrigger))]
    public UnitConfigurator AddSpellDiceBonusTrigger(
        SpellDescriptorWrapper spellDescriptorsList,
        bool checkSpellDescriptor = default,
        ContextDiceValue[] diceValues = null,
        int[] diceBonuses = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(diceValues);
    
      var component = new AddSpellDiceBonusTrigger();
      component.CheckSpellDescriptor = checkSpellDescriptor;
      component.SpellDescriptorsList = spellDescriptorsList;
      component.DiceValues = diceValues;
      component.DiceBonuses = diceBonuses;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddTargetAttackWithWeaponTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddTargetAttackWithWeaponTrigger))]
    public UnitConfigurator AddTargetAttackWithWeaponTrigger(
        bool waitForAttackResolve = default,
        bool onlyHit = default,
        bool criticalHit = default,
        bool onlyOnFirstAttack = default,
        bool onAttackOfOpportunity = default,
        bool onlyMelee = default,
        bool onlyRanged = default,
        bool notReach = default,
        bool onlySneakAttack = default,
        bool notSneakAttack = default,
        bool checkCategory = default,
        bool doNotPassAttackRoll = default,
        bool not = default,
        WeaponCategory[] categories = null,
        ActionsBuilder actionsOnAttacker = null,
        ActionsBuilder actionOnSelf = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddTargetAttackWithWeaponTrigger();
      component.WaitForAttackResolve = waitForAttackResolve;
      component.OnlyHit = onlyHit;
      component.CriticalHit = criticalHit;
      component.OnlyOnFirstAttack = onlyOnFirstAttack;
      component.OnAttackOfOpportunity = onAttackOfOpportunity;
      component.OnlyMelee = onlyMelee;
      component.OnlyRanged = onlyRanged;
      component.NotReach = notReach;
      component.OnlySneakAttack = onlySneakAttack;
      component.NotSneakAttack = notSneakAttack;
      component.CheckCategory = checkCategory;
      component.DoNotPassAttackRoll = doNotPassAttackRoll;
      component.Not = not;
      component.Categories = categories;
      component.ActionsOnAttacker = actionsOnAttacker?.Build() ?? Constants.Empty.Actions;
      component.ActionOnSelf = actionOnSelf?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddTargetSavingThrowTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddTargetSavingThrowTrigger))]
    public UnitConfigurator AddTargetSavingThrowTrigger(
        bool onlyPass = default,
        bool onlyFail = default,
        ActionsBuilder action = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddTargetSavingThrowTrigger();
      component.OnlyPass = onlyPass;
      component.OnlyFail = onlyFail;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddTargetSpellResistanceCheckTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddTargetSpellResistanceCheckTrigger))]
    public UnitConfigurator AddTargetSpellResistanceCheckTrigger(
        bool onlyPass = default,
        bool onlyFail = default,
        ActionsBuilder action = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddTargetSpellResistanceCheckTrigger();
      component.OnlyPass = onlyPass;
      component.OnlyFail = onlyFail;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeSpellElementalDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeSpellElementalDamage))]
    public UnitConfigurator AddChangeSpellElementalDamage(
        DamageEnergyType element = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ChangeSpellElementalDamage();
      component.Element = element;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeSpellElementalDamageHalfUntyped"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeSpellElementalDamageHalfUntyped))]
    public UnitConfigurator AddChangeSpellElementalDamageHalfUntyped(
        DamageEnergyType element = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ChangeSpellElementalDamageHalfUntyped();
      component.Element = element;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DeathActions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="resource"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    [Implements(typeof(DeathActions))]
    public UnitConfigurator AddDeathActions(
        ActionsBuilder actions = null,
        bool checkResource = default,
        bool onlyOnParty = default,
        string resource = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DeathActions();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.CheckResource = checkResource;
      component.OnlyOnParty = onlyOnParty;
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(resource);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DeskariAspect"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DeskariAspect))]
    public UnitConfigurator AddDeskariAspect(
        BlueprintComponent.Flags flags = default)
    {
      var component = new DeskariAspect();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FlamewardenBurningRenewal"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="resource"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    [Implements(typeof(FlamewardenBurningRenewal))]
    public UnitConfigurator AddFlamewardenBurningRenewal(
        ActionsBuilder actions = null,
        string resource = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new FlamewardenBurningRenewal();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(resource);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="InitiatorRuleDealDamageTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(InitiatorRuleDealDamageTrigger))]
    public UnitConfigurator AddInitiatorRuleDealDamageTrigger(
        ActionsBuilder actionOnSource = null,
        AbilitySharedValue sharedValue = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new InitiatorRuleDealDamageTrigger();
      component.m_ActionOnSource = actionOnSource?.Build() ?? Constants.Empty.Actions;
      component.m_SharedValue = sharedValue;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="NonHumanoidCompanion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(NonHumanoidCompanion))]
    public UnitConfigurator AddNonHumanoidCompanion(
        BlueprintComponent.Flags flags = default)
    {
      var component = new NonHumanoidCompanion();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OutcomingDamageAndHealingModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(OutcomingDamageAndHealingModifier))]
    public UnitConfigurator AddOutcomingDamageAndHealingModifier(
        ContextValue modifierPercents,
        OutcomingDamageAndHealingModifier.ModifyingType type = default,
        OutcomingDamageAndHealingModifier.WeaponType damageWeaponType = default,
        bool overrideOtherModifierPercents = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(modifierPercents);
    
      var component = new OutcomingDamageAndHealingModifier();
      component.ModifierPercents = modifierPercents;
      component.Type = type;
      component.m_DamageWeaponType = damageWeaponType;
      component.m_OverrideOtherModifierPercents = overrideOtherModifierPercents;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SacredWeaponDamageOverride"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(SacredWeaponDamageOverride))]
    public UnitConfigurator AddSacredWeaponDamageOverride(
        DiceFormula formula,
        string feature = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SacredWeaponDamageOverride();
      component.Formula = formula;
      component.m_Feature = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(feature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SacredWeaponFavoriteDamageOverride"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="deaitySacredWeaponFeature"><see cref="BlueprintFeature"/></param>
    /// <param name="buff1d6"><see cref="BlueprintBuff"/></param>
    /// <param name="buff1d8"><see cref="BlueprintBuff"/></param>
    /// <param name="buff1d10"><see cref="BlueprintBuff"/></param>
    /// <param name="buff2d6"><see cref="BlueprintBuff"/></param>
    /// <param name="buff2d8"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(SacredWeaponFavoriteDamageOverride))]
    public UnitConfigurator AddSacredWeaponFavoriteDamageOverride(
        WeaponCategory category = default,
        string deaitySacredWeaponFeature = null,
        string buff1d6 = null,
        string buff1d8 = null,
        string buff1d10 = null,
        string buff2d6 = null,
        string buff2d8 = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SacredWeaponFavoriteDamageOverride();
      component.Category = category;
      component.m_DeaitySacredWeaponFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(deaitySacredWeaponFeature);
      component.m_Buff1d6 = BlueprintTool.GetRef<BlueprintBuffReference>(buff1d6);
      component.m_Buff1d8 = BlueprintTool.GetRef<BlueprintBuffReference>(buff1d8);
      component.m_Buff1d10 = BlueprintTool.GetRef<BlueprintBuffReference>(buff1d10);
      component.m_Buff2d6 = BlueprintTool.GetRef<BlueprintBuffReference>(buff2d6);
      component.m_Buff2d8 = BlueprintTool.GetRef<BlueprintBuffReference>(buff2d8);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponDamageOverride"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponTypes"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(WeaponDamageOverride))]
    public UnitConfigurator AddWeaponDamageOverride(
        DiceFormula formula,
        string[] weaponTypes = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponDamageOverride();
      component.Formula = formula;
      component.m_WeaponTypes = weaponTypes.Select(name => BlueprintTool.GetRef<BlueprintWeaponTypeReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FixUnitOnPostLoad_AddNewFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="newFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(FixUnitOnPostLoad_AddNewFact))]
    public UnitConfigurator AddFixUnitOnPostLoad_AddNewFact(
        string taskId,
        string comment,
        string newFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new FixUnitOnPostLoad_AddNewFact();
      component.m_NewFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(newFact);
      component.TaskId = taskId;
      component.Comment = comment;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReturnVendorTable"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="table"><see cref="BlueprintSharedVendorTable"/></param>
    [Generated]
    [Implements(typeof(ReturnVendorTable))]
    public UnitConfigurator AddReturnVendorTable(
        string taskId,
        string comment,
        string table = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReturnVendorTable();
      component.m_Table = BlueprintTool.GetRef<BlueprintSharedVendorTableReference>(table);
      component.TaskId = taskId;
      component.Comment = comment;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DublicateSpellComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DublicateSpellComponent))]
    public UnitConfigurator AddDublicateSpellComponent(
        int feetsRaiuds = default,
        DublicateSpellComponent.AOEType aOECheck = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DublicateSpellComponent();
      component.m_FeetsRaiuds = feetsRaiuds;
      component.m_AOECheck = aOECheck;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreAttacksOfOpportunityForSpellList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilities"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(IgnoreAttacksOfOpportunityForSpellList))]
    public UnitConfigurator AddIgnoreAttacksOfOpportunityForSpellList(
        SpellDescriptorWrapper spellDescriptor,
        string[] abilities = null,
        bool checkSchool = default,
        SpellSchool school = default,
        bool checkDescriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IgnoreAttacksOfOpportunityForSpellList();
      component.m_Abilities = abilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToList();
      component.CheckSchool = checkSchool;
      component.School = school;
      component.CheckDescriptor = checkDescriptor;
      component.SpellDescriptor = spellDescriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstTacticalOwner"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusAgainstTacticalOwner))]
    public UnitConfigurator AddAttackBonusAgainstTacticalOwner(
        TargetFilter targetFilter,
        ContextValue value,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(targetFilter);
      ValidateParam(value);
    
      var component = new AttackBonusAgainstTacticalOwner();
      component.m_TargetFilter = targetFilter;
      component.m_Value = value;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstTacticalTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusAgainstTacticalTarget))]
    public UnitConfigurator AddAttackBonusAgainstTacticalTarget(
        TargetFilter targetFilter,
        ContextValue value,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(targetFilter);
      ValidateParam(value);
    
      var component = new AttackBonusAgainstTacticalTarget();
      component.m_TargetFilter = targetFilter;
      component.m_Value = value;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstTacticalOwner"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageBonusAgainstTacticalOwner))]
    public UnitConfigurator AddDamageBonusAgainstTacticalOwner(
        TargetFilter targetFilter,
        ContextValue value,
        Kingmaker.UnitLogic.Mechanics.ValueType _valueType = default,
        int bonusPercentValue = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(targetFilter);
      ValidateParam(value);
    
      var component = new DamageBonusAgainstTacticalOwner();
      component.m_TargetFilter = targetFilter;
      component._valueType = _valueType;
      component.m_Value = value;
      component.m_BonusPercentValue = bonusPercentValue;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstTacticalTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageBonusAgainstTacticalTarget))]
    public UnitConfigurator AddDamageBonusAgainstTacticalTarget(
        TargetFilter targetFilter,
        ContextValue value,
        Kingmaker.UnitLogic.Mechanics.ValueType _valueType = default,
        int bonusPercentValue = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(targetFilter);
      ValidateParam(value);
    
      var component = new DamageBonusAgainstTacticalTarget();
      component.m_TargetFilter = targetFilter;
      component._valueType = _valueType;
      component.m_Value = value;
      component.m_BonusPercentValue = bonusPercentValue;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyAlternativeMovement"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="deliverAbility"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(ArmyAlternativeMovement))]
    public UnitConfigurator AddArmyAlternativeMovement(
        bool ignoreObstacles = default,
        string deliverAbility = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ArmyAlternativeMovement();
      component.m_IgnoreObstacles = ignoreObstacles;
      component.m_DeliverAbility = BlueprintTool.GetRef<BlueprintAbilityReference>(deliverAbility);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyChangeInitiative"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyChangeInitiative))]
    public UnitConfigurator AddArmyChangeInitiative(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new ArmyChangeInitiative();
      component.m_Descriptor = descriptor;
      component.m_Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyCriticalDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyCriticalDamage))]
    public UnitConfigurator AddArmyCriticalDamage(
        ContextValue chanceBase,
        ContextValue chanceMultiplier,
        float critBonus = default,
        float critMultiplier = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(chanceBase);
      ValidateParam(chanceMultiplier);
    
      var component = new ArmyCriticalDamage();
      component.m_ChanceBase = chanceBase;
      component.m_ChanceMultiplier = chanceMultiplier;
      component.m_CritBonus = critBonus;
      component.m_CritMultiplier = critMultiplier;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyForceMelee"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyForceMelee))]
    public UnitConfigurator AddArmyForceMelee(
        BlueprintComponent.Flags flags = default)
    {
      var component = new ArmyForceMelee();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyFullAttackEndTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyFullAttackEndTrigger))]
    public UnitConfigurator AddArmyFullAttackEndTrigger(
        bool shouldBeInitiator = default,
        bool checkAllAttacks = default,
        bool onlyHit = default,
        bool criticalHit = default,
        bool onlyMelee = default,
        bool onlyRanged = default,
        bool notReach = default,
        bool onlySneakAttack = default,
        bool notSneakAttack = default,
        bool checkCategory = default,
        bool not = default,
        WeaponCategory[] categories = null,
        ActionsBuilder actionsOnInitiator = null,
        ActionsBuilder actionOnTarget = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ArmyFullAttackEndTrigger();
      component.ShouldBeInitiator = shouldBeInitiator;
      component.CheckAllAttacks = checkAllAttacks;
      component.OnlyHit = onlyHit;
      component.CriticalHit = criticalHit;
      component.OnlyMelee = onlyMelee;
      component.OnlyRanged = onlyRanged;
      component.NotReach = notReach;
      component.OnlySneakAttack = onlySneakAttack;
      component.NotSneakAttack = notSneakAttack;
      component.CheckCategory = checkCategory;
      component.Not = not;
      component.Categories = categories;
      component.ActionsOnInitiator = actionsOnInitiator?.Build() ?? Constants.Empty.Actions;
      component.ActionOnTarget = actionOnTarget?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmySwitchWeaponSlotInMelee"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmySwitchWeaponSlotInMelee))]
    public UnitConfigurator AddArmySwitchWeaponSlotInMelee(
        int slotIndexForMelee = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ArmySwitchWeaponSlotInMelee();
      component.m_SlotIndexForMelee = slotIndexForMelee;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeLeaderSkillPowerOnAbilityUse"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeLeaderSkillPowerOnAbilityUse))]
    public UnitConfigurator AddChangeLeaderSkillPowerOnAbilityUse(
        SpellDescriptorWrapper spellDescriptor,
        bool checkDescriptor = default,
        int modifier = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ChangeLeaderSkillPowerOnAbilityUse();
      component.m_CheckDescriptor = checkDescriptor;
      component.m_SpellDescriptor = spellDescriptor;
      component.m_Modifier = modifier;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RandomLeaderSpellReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RandomLeaderSpellReplacement))]
    public UnitConfigurator AddRandomLeaderSpellReplacement(
        float chanceToReplace = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RandomLeaderSpellReplacement();
      component.m_ChanceToReplace = chanceToReplace;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceSquadAbilities"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="newAbilities"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(ReplaceSquadAbilities))]
    public UnitConfigurator AddReplaceSquadAbilities(
        string[] newAbilities = null,
        bool forOneTurn = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReplaceSquadAbilities();
      component.m_NewAbilities = newAbilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToList();
      component.m_ForOneTurn = forOneTurn;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RunActionOnTurnStart"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RunActionOnTurnStart))]
    public UnitConfigurator AddRunActionOnTurnStart(
        float chanceCoefficient = default,
        ActionsBuilder actions = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RunActionOnTurnStart();
      component.m_ChanceCoefficient = chanceCoefficient;
      component.m_Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalBattleEndTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalBattleEndTrigger))]
    public UnitConfigurator AddTacticalBattleEndTrigger(
        bool onlyOnVictory = default,
        ActionsBuilder onBattleEnd = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TacticalBattleEndTrigger();
      component.OnlyOnVictory = onlyOnVictory;
      component.m_OnBattleEnd = onBattleEnd?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCellReachTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalCellReachTrigger))]
    public UnitConfigurator AddTacticalCellReachTrigger(
        int x = default,
        int y = default,
        bool anyX = default,
        bool anyY = default,
        ActionsBuilder onReach = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TacticalCellReachTrigger();
      component.m_X = x;
      component.m_Y = y;
      component.m_AnyX = anyX;
      component.m_AnyY = anyY;
      component.m_OnReach = onReach?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatChangeFaction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalCombatChangeFaction))]
    public UnitConfigurator AddTacticalCombatChangeFaction(
        TacticalCombatChangeFaction.ChangeType type = default,
        ArmyFaction faction = default,
        bool allowDirectControl = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TacticalCombatChangeFaction();
      component.m_Type = type;
      component.m_Faction = faction;
      component.m_AllowDirectControl = allowDirectControl;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatConfusion"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="aiAttackNearestAction"><see cref="BlueprintTacticalCombatAiAction"/></param>
    [Generated]
    [Implements(typeof(TacticalCombatConfusion))]
    public UnitConfigurator AddTacticalCombatConfusion(
        string aiAttackNearestAction = null,
        ActionsBuilder harmSelfAction = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TacticalCombatConfusion();
      component.m_AiAttackNearestAction = BlueprintTool.GetRef<BlueprintTacticalCombatAiActionReference>(aiAttackNearestAction);
      component.m_HarmSelfAction = harmSelfAction?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatDefenseAbility"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalCombatDefenseAbility))]
    public UnitConfigurator AddTacticalCombatDefenseAbility(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TacticalCombatDefenseAbility();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatEndMovementTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalCombatEndMovementTrigger))]
    public UnitConfigurator AddTacticalCombatEndMovementTrigger(
        ActionsBuilder actions = null,
        bool allowOnlyMoveCommands = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TacticalCombatEndMovementTrigger();
      component.m_Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.m_AllowOnlyMoveCommands = allowOnlyMoveCommands;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatPercentDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalCombatPercentDamageBonus))]
    public UnitConfigurator AddTacticalCombatPercentDamageBonus(
        int bonusPercent = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TacticalCombatPercentDamageBonus();
      component.BonusPercent = bonusPercent;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatProvocation"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="aiAction"><see cref="BlueprintTacticalCombatAiAction"/></param>
    [Generated]
    [Implements(typeof(TacticalCombatProvocation))]
    public UnitConfigurator AddTacticalCombatProvocation(
        string aiAction = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TacticalCombatProvocation();
      component.m_AiAction = BlueprintTool.GetRef<BlueprintTacticalCombatAiActionReference>(aiAction);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatResurrection"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalCombatResurrection))]
    public UnitConfigurator AddTacticalCombatResurrection(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TacticalCombatResurrection();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatRider"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="mount"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(TacticalCombatRider))]
    public UnitConfigurator AddTacticalCombatRider(
        string mount = null,
        bool applyRiderScaleToHorse = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TacticalCombatRider();
      component.m_Mount = BlueprintTool.GetRef<BlueprintUnitReference>(mount);
      component.m_ApplyRiderScaleToHorse = applyRiderScaleToHorse;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalCombatRoundTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalCombatRoundTrigger))]
    public UnitConfigurator AddTacticalCombatRoundTrigger(
        ActionsBuilder newRoundActions = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TacticalCombatRoundTrigger();
      component.NewRoundActions = newRoundActions?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalMoraleChanceModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalMoraleChanceModifier))]
    public UnitConfigurator AddTacticalMoraleChanceModifier(
        ContextValue positiveMoraleChancePercentDelta,
        ContextValue negativeMoraleChancePercentDelta,
        bool changePositiveMorale = default,
        bool changeNegativeMorale = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(positiveMoraleChancePercentDelta);
      ValidateParam(negativeMoraleChancePercentDelta);
    
      var component = new TacticalMoraleChanceModifier();
      component.m_ChangePositiveMorale = changePositiveMorale;
      component.m_PositiveMoraleChancePercentDelta = positiveMoraleChancePercentDelta;
      component.m_ChangeNegativeMorale = changeNegativeMorale;
      component.m_NegativeMoraleChancePercentDelta = negativeMoraleChancePercentDelta;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalMoraleModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalMoraleModifier))]
    public UnitConfigurator AddTacticalMoraleModifier(
        TargetFilter targetFilter,
        TacticalMoraleModifier.FactionTarget factionTarget = default,
        int modValue = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(targetFilter);
    
      var component = new TacticalMoraleModifier();
      component.m_TargetFilter = targetFilter;
      component.m_FactionTarget = factionTarget;
      component.m_ModValue = modValue;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalSquadDeathTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="armyFactOnOwnerDeath"><see cref="BlueprintUnitFact"/></param>
    /// <param name="armyFactOnOthersDeath"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(TacticalSquadDeathTrigger))]
    public UnitConfigurator AddTacticalSquadDeathTrigger(
        string armyFactOnOwnerDeath = null,
        string armyFactOnOthersDeath = null,
        bool removeFactOnAnyDeath = default,
        ArmyFaction factDestinationFaction = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TacticalSquadDeathTrigger();
      component.m_ArmyFactOnOwnerDeath = BlueprintTool.GetRef<BlueprintUnitFactReference>(armyFactOnOwnerDeath);
      component.m_ArmyFactOnOthersDeath = BlueprintTool.GetRef<BlueprintUnitFactReference>(armyFactOnOthersDeath);
      component.m_RemoveFactOnAnyDeath = removeFactOnAnyDeath;
      component.m_FactDestinationFaction = factDestinationFaction;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyUnitComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyUnitComponent))]
    public UnitConfigurator AddArmyUnitComponent(
        Sprite icon,
        KingdomResourcesAmount recruitmentPrice,
        KingdomResourcesAmount supportPrice,
        LocalizedString description = null,
        bool isHaveMorale = default,
        int startMorale = default,
        int maxExtraActions = default,
        int mercenariesBaseGrowths = default,
        ArmyProperties properties = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(icon);
      ValidateParam(description);
    
      var component = new ArmyUnitComponent();
      component.Icon = icon;
      component.Description = description ?? Constants.Empty.String;
      component.IsHaveMorale = isHaveMorale;
      component.StartMorale = startMorale;
      component.MaxExtraActions = maxExtraActions;
      component.RecruitmentPrice = recruitmentPrice;
      component.SupportPrice = supportPrice;
      component.MercenariesBaseGrowths = mercenariesBaseGrowths;
      component.Properties = properties;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyUnitSpellPower"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyUnitSpellPower))]
    public UnitConfigurator AddArmyUnitSpellPower(
        int spellPower = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ArmyUnitSpellPower();
      component.m_SpellPower = spellPower;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyDamageAfterMovementBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyDamageAfterMovementBonus))]
    public UnitConfigurator AddArmyDamageAfterMovementBonus(
        float bonus = default,
        bool accumulateBonusPerCell = default,
        ActionsBuilder onDamageDeal = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ArmyDamageAfterMovementBonus();
      component.m_Bonus = bonus;
      component.m_AccumulateBonusPerCell = accumulateBonusPerCell;
      component.OnDamageDeal = onDamageDeal?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyStandingDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyStandingDamageBonus))]
    public UnitConfigurator AddArmyStandingDamageBonus(
        int bonus = default,
        ActionsBuilder onDamageDeal = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ArmyStandingDamageBonus();
      component.m_Bonus = bonus;
      component.OnDamageDeal = onDamageDeal?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffOnEntityCreated"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(BuffOnEntityCreated))]
    public UnitConfigurator AddBuffOnEntityCreated(
        string buff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffOnEntityCreated();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TargetingBlind"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TargetingBlind))]
    public UnitConfigurator AddTargetingBlind(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TargetingBlind();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstAttackOfOpportunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstAttackOfOpportunity))]
    public UnitConfigurator AddACBonusAgainstAttackOfOpportunity(
        ContextValue bonus,
        bool notAttackOfOpportunity = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new ACBonusAgainstAttackOfOpportunity();
      component.NotAttackOfOpportunity = notAttackOfOpportunity;
      component.Bonus = bonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstAttacks"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstAttacks))]
    public UnitConfigurator AddACBonusAgainstAttacks(
        ContextValue value,
        bool againstMeleeOnly = default,
        bool againstRangedOnly = default,
        bool onlySneakAttack = default,
        bool notTouch = default,
        bool isTouch = default,
        bool onlyAttacksOfOpportunity = default,
        int armorClassBonus = default,
        ModifierDescriptor descriptor = default,
        bool checkArmorCategory = default,
        ArmorProficiencyGroup[] notArmorCategory = null,
        bool noShield = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new ACBonusAgainstAttacks();
      component.AgainstMeleeOnly = againstMeleeOnly;
      component.AgainstRangedOnly = againstRangedOnly;
      component.OnlySneakAttack = onlySneakAttack;
      component.NotTouch = notTouch;
      component.IsTouch = isTouch;
      component.OnlyAttacksOfOpportunity = onlyAttacksOfOpportunity;
      component.Value = value;
      component.ArmorClassBonus = armorClassBonus;
      component.Descriptor = descriptor;
      component.CheckArmorCategory = checkArmorCategory;
      component.NotArmorCategory = notArmorCategory;
      component.NoShield = noShield;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstBuffOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(ACBonusAgainstBuffOwner))]
    public UnitConfigurator AddACBonusAgainstBuffOwner(
        string checkedBuff = null,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        bool checkAlignment = default,
        AlignmentComponent alignment = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ACBonusAgainstBuffOwner();
      component.m_CheckedBuff = BlueprintTool.GetRef<BlueprintBuffReference>(checkedBuff);
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.CheckAlignment = checkAlignment;
      component.Alignment = alignment;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ACBonusAgainstFactOwner))]
    public UnitConfigurator AddACBonusAgainstFactOwner(
        string checkedFact = null,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        AlignmentComponent alignment = default,
        bool noFact = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ACBonusAgainstFactOwner();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.Alignment = alignment;
      component.NoFact = noFact;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstFactOwnerMultiple"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ACBonusAgainstFactOwnerMultiple))]
    public UnitConfigurator AddACBonusAgainstFactOwnerMultiple(
        string[] facts = null,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        AlignmentComponent alignment = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ACBonusAgainstFactOwnerMultiple();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.Alignment = alignment;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstSize"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstSize))]
    public UnitConfigurator AddACBonusAgainstSize(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        Size size = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new ACBonusAgainstSize();
      component.Descriptor = descriptor;
      component.Value = value;
      component.Size = size;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstSpellsWithDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstSpellsWithDescriptor))]
    public UnitConfigurator AddACBonusAgainstSpellsWithDescriptor(
        SpellDescriptorWrapper spellDescriptor,
        int armorClassBonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ACBonusAgainstSpellsWithDescriptor();
      component.ArmorClassBonus = armorClassBonus;
      component.SpellDescriptor = spellDescriptor;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstWeaponCategory"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstWeaponCategory))]
    public UnitConfigurator AddACBonusAgainstWeaponCategory(
        int armorClassBonus = default,
        WeaponCategory category = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ACBonusAgainstWeaponCategory();
      component.ArmorClassBonus = armorClassBonus;
      component.Category = category;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstWeaponGroup"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstWeaponGroup))]
    public UnitConfigurator AddACBonusAgainstWeaponGroup(
        int armorClassBonus = default,
        WeaponFighterGroup fighterGroup = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ACBonusAgainstWeaponGroup();
      component.ArmorClassBonus = armorClassBonus;
      component.FighterGroup = fighterGroup;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstWeaponSubcategory"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstWeaponSubcategory))]
    public UnitConfigurator AddACBonusAgainstWeaponSubcategory(
        int armorClassBonus = default,
        WeaponSubCategory subCategory = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ACBonusAgainstWeaponSubcategory();
      component.ArmorClassBonus = armorClassBonus;
      component.SubCategory = subCategory;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstWeaponType"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="type"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(ACBonusAgainstWeaponType))]
    public UnitConfigurator AddACBonusAgainstWeaponType(
        int armorClassBonus = default,
        string type = null,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ACBonusAgainstWeaponType();
      component.ArmorClassBonus = armorClassBonus;
      component.m_Type = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(type);
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusUnlessFactMultiple"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ACBonusUnlessFactMultiple))]
    public UnitConfigurator AddACBonusUnlessFactMultiple(
        string[] facts = null,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        AlignmentComponent alignment = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ACBonusUnlessFactMultiple();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.Alignment = alignment;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACContextBonusAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ACContextBonusAgainstFactOwner))]
    public UnitConfigurator AddACContextBonusAgainstFactOwner(
        ContextValue bonus,
        string checkedFact = null,
        ModifierDescriptor descriptor = default,
        AlignmentComponent alignment = default,
        bool noFact = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new ACContextBonusAgainstFactOwner();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.Alignment = alignment;
      component.NoFact = noFact;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACContextBonusAgainstWeaponSubcategory"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACContextBonusAgainstWeaponSubcategory))]
    public UnitConfigurator AddACContextBonusAgainstWeaponSubcategory(
        ContextValue value,
        WeaponSubCategory subCategory = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new ACContextBonusAgainstWeaponSubcategory();
      component.Value = value;
      component.SubCategory = subCategory;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityFocusParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityFocusParametrized))]
    public UnitConfigurator AddAbilityFocusParametrized(
        bool spellsOnly = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AbilityFocusParametrized();
      component.SpellsOnly = spellsOnly;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityMythicParams"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilites"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AbilityMythicParams))]
    public UnitConfigurator AddAbilityMythicParams(
        string[] abilites = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AbilityMythicParams();
      component.m_Abilites = abilites.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityScoreCheckBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityScoreCheckBonus))]
    public UnitConfigurator AddAbilityScoreCheckBonus(
        ContextValue bonus,
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new AbilityScoreCheckBonus();
      component.Descriptor = descriptor;
      component.Bonus = bonus;
      component.Stat = stat;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ActionsOnBuffApply"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="gainedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ActionsOnBuffApply))]
    public UnitConfigurator AddActionsOnBuffApply(
        string gainedFact = null,
        ActionsBuilder actions = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ActionsOnBuffApply();
      component.m_GainedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(gainedFact);
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAbilityResources"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="resource"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    [Implements(typeof(AddAbilityResources))]
    public UnitConfigurator AddAbilityResources(
        bool useThisAsResource = default,
        string resource = null,
        int amount = default,
        bool restoreAmount = default,
        bool restoreOnLevelUp = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddAbilityResources();
      component.UseThisAsResource = useThisAsResource;
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(resource);
      component.Amount = amount;
      component.RestoreAmount = restoreAmount;
      component.RestoreOnLevelUp = restoreOnLevelUp;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBuffOnCombatStart"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AddBuffOnCombatStart))]
    public UnitConfigurator AddBuffOnCombatStart(
        bool checkParty = default,
        string feature = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddBuffOnCombatStart();
      component.CheckParty = checkParty;
      component.m_Feature = BlueprintTool.GetRef<BlueprintBuffReference>(feature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCalculatedWeapon"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddCalculatedWeapon))]
    public UnitConfigurator AddCalculatedWeapon(
        CalculatedWeapon weapon,
        bool scaleDamageByRank = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(weapon);
    
      var component = new AddCalculatedWeapon();
      component.Weapon = weapon;
      component.ScaleDamageByRank = scaleDamageByRank;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCasterLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddCasterLevel))]
    public UnitConfigurator AddCasterLevel(
        int bonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddCasterLevel();
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCasterLevelForAbility"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spell"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddCasterLevelForAbility))]
    public UnitConfigurator AddCasterLevelForAbility(
        string spell = null,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddCasterLevelForAbility();
      component.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(spell);
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddCasterLevelForSpellbook"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbooks"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    [Implements(typeof(AddCasterLevelForSpellbook))]
    public UnitConfigurator AddCasterLevelForSpellbook(
        int bonus = default,
        ModifierDescriptor descriptor = default,
        string[] spellbooks = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddCasterLevelForSpellbook();
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.m_Spellbooks = spellbooks.Select(name => BlueprintTool.GetRef<BlueprintSpellbookReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddClassLevelToSummonDuration"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(AddClassLevelToSummonDuration))]
    public UnitConfigurator AddClassLevelToSummonDuration(
        string characterClass = null,
        bool half = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddClassLevelToSummonDuration();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.Half = half;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFactIfArchetype"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="BlueprintUnitFact"/></param>
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="archetype"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(AddFactIfArchetype))]
    public UnitConfigurator AddFactIfArchetype(
        string feature = null,
        string characterClass = null,
        string archetype = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddFactIfArchetype();
      component.m_Feature = BlueprintTool.GetRef<BlueprintUnitFactReference>(feature);
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureIfHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    /// <param name="feature"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddFeatureIfHasFact))]
    public UnitConfigurator AddFeatureIfHasFact(
        string checkedFact = null,
        string feature = null,
        bool not = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddFeatureIfHasFact();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.m_Feature = BlueprintTool.GetRef<BlueprintUnitFactReference>(feature);
      component.Not = not;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureOnAlignment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddFeatureOnAlignment))]
    public UnitConfigurator AddFeatureOnAlignment(
        AlignmentComponent alignment = default,
        string[] facts = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddFeatureOnAlignment();
      component.Alignment = alignment;
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureOnApply"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddFeatureOnApply))]
    public UnitConfigurator AddFeatureOnApply(
        string feature = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddFeatureOnApply();
      component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureOnClassLevel"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="clazz"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="feature"><see cref="BlueprintFeature"/></param>
    /// <param name="additionalClasses"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="archetypes"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(AddFeatureOnClassLevel))]
    public UnitConfigurator AddFeatureOnClassLevel(
        string clazz = null,
        int level = default,
        string feature = null,
        bool beforeThisLevel = default,
        string[] additionalClasses = null,
        string[] archetypes = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddFeatureOnClassLevel();
      component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      component.Level = level;
      component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      component.BeforeThisLevel = beforeThisLevel;
      component.m_AdditionalClasses = additionalClasses.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name)).ToArray();
      component.m_Archetypes = archetypes.Select(name => BlueprintTool.GetRef<BlueprintArchetypeReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureOnSkill"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddFeatureOnSkill))]
    public UnitConfigurator AddFeatureOnSkill(
        StatType statType = default,
        int minimalStat = default,
        string[] facts = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddFeatureOnSkill();
      component.StatType = statType;
      component.MinimalStat = minimalStat;
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddFeatureParametrized))]
    public UnitConfigurator AddFeatureParametrized(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddFeatureParametrized();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureToNPC"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddFeatureToNPC))]
    public UnitConfigurator AddFeatureToNPC(
        bool checkParty = default,
        string feature = null,
        bool checkSummoned = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddFeatureToNPC();
      component.CheckParty = checkParty;
      component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      component.CheckSummoned = checkSummoned;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureToPet"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddFeatureToPet))]
    public UnitConfigurator AddFeatureToPet(
        PetType petType = default,
        string feature = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddFeatureToPet();
      component.m_PetType = petType;
      component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureToPetParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddFeatureToPetParametrized))]
    public UnitConfigurator AddFeatureToPetParametrized(
        PetType petType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddFeatureToPetParametrized();
      component.PetType = petType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellListAsAbilities"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="resourcePerSpellLevel"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    [Implements(typeof(AddSpellListAsAbilities))]
    public UnitConfigurator AddSpellListAsAbilities(
        string[] resourcePerSpellLevel = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddSpellListAsAbilities();
      component.m_ResourcePerSpellLevel = resourcePerSpellLevel.Select(name => BlueprintTool.GetRef<BlueprintAbilityResourceReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellbook"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbook"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    [Implements(typeof(AddSpellbook))]
    public UnitConfigurator AddSpellbook(
        ContextValue casterLevel,
        string spellbook = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(casterLevel);
    
      var component = new AddSpellbook();
      component.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(spellbook);
      component.m_CasterLevel = casterLevel;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellbookFeature"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbook"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    [Implements(typeof(AddSpellbookFeature))]
    public UnitConfigurator AddSpellbookFeature(
        string spellbook = null,
        int casterLevel = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddSpellbookFeature();
      component.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(spellbook);
      component.CasterLevel = casterLevel;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellbookLevel"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbook"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    [Implements(typeof(AddSpellbookLevel))]
    public UnitConfigurator AddSpellbookLevel(
        string spellbook = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddSpellbookLevel();
      component.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(spellbook);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellsPerDay"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddSpellsPerDay))]
    public UnitConfigurator AddSpellsPerDay(
        int amount = default,
        int[] levels = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddSpellsPerDay();
      component.Amount = amount;
      component.Levels = levels;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddWearinessHours"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddWearinessHours))]
    public UnitConfigurator AddWearinessHours(
        int hours = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddWearinessHours();
      component.Hours = hours;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AdditionalDamageOnHit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weapon"><see cref="BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(AdditionalDamageOnHit))]
    public UnitConfigurator AdditionalDamageOnHit(
        DiceFormula energyDamageDice,
        DamageEnergyType element = default,
        bool specificWeapon = default,
        string weapon = null,
        bool onlyNaturalAndUnarmed = default,
        bool onlyMelee = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AdditionalDamageOnHit();
      component.EnergyDamageDice = energyDamageDice;
      component.Element = element;
      component.SpecificWeapon = specificWeapon;
      component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(weapon);
      component.OnlyNaturalAndUnarmed = onlyNaturalAndUnarmed;
      component.OnlyMelee = onlyMelee;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AdditionalSneakDamageOnHit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AdditionalSneakDamageOnHit))]
    public UnitConfigurator AdditionalSneakDamageOnHit(
        DiceFormula physicalDamageDice,
        AdditionalSneakDamageOnHit.WeaponType weapon = default,
        bool onlyNoDexToAC = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AdditionalSneakDamageOnHit();
      component.m_Weapon = weapon;
      component.PhysicalDamageDice = physicalDamageDice;
      component.OnlyNoDexToAC = onlyNoDexToAC;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AllSpellsParamsOverride"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AllSpellsParamsOverride))]
    public UnitConfigurator AddAllSpellsParamsOverride(
        ContextValue casterLevel,
        ContextValue dC,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(casterLevel);
      ValidateParam(dC);
    
      var component = new AllSpellsParamsOverride();
      component.CasterLevel = casterLevel;
      component.DC = dC;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AlliedSpellcaster"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="alliedSpellcasterFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AlliedSpellcaster))]
    public UnitConfigurator AddAlliedSpellcaster(
        string alliedSpellcasterFact = null,
        int radius = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AlliedSpellcaster();
      component.m_AlliedSpellcasterFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(alliedSpellcasterFact);
      component.Radius = radius;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AngelSwordAdditionalDamageAndHeal"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="maximizeFact"><see cref="BlueprintUnitFact"/></param>
    /// <param name="cloakFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AngelSwordAdditionalDamageAndHeal))]
    public UnitConfigurator AddAngelSwordAdditionalDamageAndHeal(
        string maximizeFact = null,
        string cloakFact = null,
        PrefabLink healingPrefab = null,
        PrefabLink damagePrefab = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(healingPrefab);
      ValidateParam(damagePrefab);
    
      var component = new AngelSwordAdditionalDamageAndHeal();
      component.m_MaximizeFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(maximizeFact);
      component.m_CloakFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(cloakFact);
      component.HealingPrefab = healingPrefab ?? Constants.Empty.PrefabLink;
      component.DamagePrefab = damagePrefab ?? Constants.Empty.PrefabLink;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AngelSwordAntiDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AngelSwordAntiDescriptor))]
    public UnitConfigurator AddAngelSwordAntiDescriptor(
        SpellDescriptorWrapper checkedDescriptor,
        bool healStatDamageAndDrain = default,
        bool healEnergyDrain = default,
        EnergyDrainHealType temporaryNegativeLevelsHeal = default,
        EnergyDrainHealType permanentNegativeLevelsHeal = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AngelSwordAntiDescriptor();
      component.CheckedDescriptor = checkedDescriptor;
      component.HealStatDamageAndDrain = healStatDamageAndDrain;
      component.HealEnergyDrain = healEnergyDrain;
      component.TemporaryNegativeLevelsHeal = temporaryNegativeLevelsHeal;
      component.PermanentNegativeLevelsHeal = permanentNegativeLevelsHeal;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AnyWeaponDamageStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AnyWeaponDamageStatReplacement))]
    public UnitConfigurator AddAnyWeaponDamageStatReplacement(
        StatType stat = default,
        bool onlyMelee = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AnyWeaponDamageStatReplacement();
      component.Stat = stat;
      component.OnlyMelee = onlyMelee;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArcaneArmorProficiency"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArcaneArmorProficiency))]
    public UnitConfigurator AddArcaneArmorProficiency(
        ArmorProficiencyGroup[] armor = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ArcaneArmorProficiency();
      component.Armor = armor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArcaneBloodlineArcana"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArcaneBloodlineArcana))]
    public UnitConfigurator AddArcaneBloodlineArcana(
        BlueprintComponent.Flags flags = default)
    {
      var component = new ArcaneBloodlineArcana();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArcaneSpellFailureIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArcaneSpellFailureIncrease))]
    public UnitConfigurator AddArcaneSpellFailureIncrease(
        int bonus = default,
        bool toShield = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ArcaneSpellFailureIncrease();
      component.Bonus = bonus;
      component.ToShield = toShield;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmorCheckPenaltyIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmorCheckPenaltyIncrease))]
    public UnitConfigurator AddArmorCheckPenaltyIncrease(
        ContextValue bonus,
        int bonesPerRank = default,
        bool checkCategory = default,
        ArmorProficiencyGroup category = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new ArmorCheckPenaltyIncrease();
      component.Bonus = bonus;
      component.BonesPerRank = bonesPerRank;
      component.CheckCategory = checkCategory;
      component.Category = category;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmorClassBonusAgainstAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmorClassBonusAgainstAlignment))]
    public UnitConfigurator AddArmorClassBonusAgainstAlignment(
        ContextValue bonus,
        AlignmentComponent alignment = default,
        ModifierDescriptor descriptor = default,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new ArmorClassBonusAgainstAlignment();
      component.alignment = alignment;
      component.Descriptor = descriptor;
      component.Value = value;
      component.Bonus = bonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmorSpeedPenaltyRemoval"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmorSpeedPenaltyRemoval))]
    public UnitConfigurator AddArmorSpeedPenaltyRemoval(
        BlueprintComponent.Flags flags = default)
    {
      var component = new ArmorSpeedPenaltyRemoval();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AscendantElement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AscendantElement))]
    public UnitConfigurator AddAscendantElement(
        DamageEnergyType element = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AscendantElement();
      component.Element = element;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusAgainstAlignment))]
    public UnitConfigurator AddAttackBonusAgainstAlignment(
        ContextValue bonus,
        AlignmentComponent alignment = default,
        bool onlyMelee = default,
        int damageBonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new AttackBonusAgainstAlignment();
      component.Alignment = alignment;
      component.OnlyMelee = onlyMelee;
      component.DamageBonus = damageBonus;
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstArmyProperty"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusAgainstArmyProperty))]
    public UnitConfigurator AddAttackBonusAgainstArmyProperty(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        ArmyProperties armyProperties = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new AttackBonusAgainstArmyProperty();
      component.Descriptor = descriptor;
      component.Value = value;
      component.ArmyProperties = armyProperties;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AttackBonusAgainstFactOwner))]
    public UnitConfigurator AddAttackBonusAgainstFactOwner(
        ContextValue bonus,
        string checkedFact = null,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        bool not = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new AttackBonusAgainstFactOwner();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.AttackBonus = attackBonus;
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.Not = not;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstFriendly"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusAgainstFriendly))]
    public UnitConfigurator AddAttackBonusAgainstFriendly(
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AttackBonusAgainstFriendly();
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstSize"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="targetFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AttackBonusAgainstSize))]
    public UnitConfigurator AddAttackBonusAgainstSize(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        Size size = default,
        bool onlyForRanged = default,
        bool onlyForMelee = default,
        bool sizeMoreThan = default,
        bool checkTargetFact = default,
        string targetFact = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new AttackBonusAgainstSize();
      component.Descriptor = descriptor;
      component.Value = value;
      component.Size = size;
      component.OnlyForRanged = onlyForRanged;
      component.OnlyForMelee = onlyForMelee;
      component.SizeMoreThan = sizeMoreThan;
      component.CheckTargetFact = checkTargetFact;
      component.m_TargetFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(targetFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusConditional"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusConditional))]
    public UnitConfigurator AddAttackBonusConditional(
        ContextValue bonus,
        bool checkWielder = default,
        ModifierDescriptor descriptor = default,
        ConditionsBuilder conditions = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new AttackBonusConditional();
      component.CheckWielder = checkWielder;
      component.Descriptor = descriptor;
      component.Bonus = bonus;
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackDiceBonusOnce"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackDiceBonusOnce))]
    public UnitConfigurator AddAttackDiceBonusOnce(
        int bonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AttackDiceBonusOnce();
      component.bonus = bonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackOfOpportunityAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackOfOpportunityAttackBonus))]
    public UnitConfigurator AddAttackOfOpportunityAttackBonus(
        ContextValue bonus,
        bool notAttackOfOpportunity = default,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new AttackOfOpportunityAttackBonus();
      component.NotAttackOfOpportunity = notAttackOfOpportunity;
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.Bonus = bonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackOfOpportunityAttackBonusAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AttackOfOpportunityAttackBonusAgainstFactOwner))]
    public UnitConfigurator AddAttackOfOpportunityAttackBonusAgainstFactOwner(
        ContextValue bonus,
        string checkedFact = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new AttackOfOpportunityAttackBonusAgainstFactOwner();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.Bonus = bonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackOfOpportunityCriticalConfirmationBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackOfOpportunityCriticalConfirmationBonus))]
    public UnitConfigurator AddAttackOfOpportunityCriticalConfirmationBonus(
        ContextValue bonus,
        bool checkWeaponRangeType = default,
        WeaponRangeType type = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new AttackOfOpportunityCriticalConfirmationBonus();
      component.Bonus = bonus;
      component.CheckWeaponRangeType = checkWeaponRangeType;
      component.Type = type;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackOfOpportunityDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackOfOpportunityDamageBonus))]
    public UnitConfigurator AddAttackOfOpportunityDamageBonus(
        ContextValue damageBonus,
        bool checkWeaponRangeType = default,
        WeaponRangeType weaponType = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(damageBonus);
    
      var component = new AttackOfOpportunityDamageBonus();
      component.DamageBonus = damageBonus;
      component.CheckWeaponRangeType = checkWeaponRangeType;
      component.WeaponType = weaponType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackTypeAttackBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="requiredFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AttackTypeAttackBonus))]
    public UnitConfigurator AddAttackTypeAttackBonus(
        ContextValue value,
        WeaponRangeType type = default,
        bool allTypesExcept = default,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        bool checkFact = default,
        string requiredFact = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new AttackTypeAttackBonus();
      component.Type = type;
      component.AllTypesExcept = allTypesExcept;
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.Value = value;
      component.CheckFact = checkFact;
      component.m_RequiredFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(requiredFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackTypeChange"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackTypeChange))]
    public UnitConfigurator AddAttackTypeChange(
        bool needsWeapon = default,
        bool changeAllTypes = default,
        AttackType originalType = default,
        AttackType newType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AttackTypeChange();
      component.NeedsWeapon = needsWeapon;
      component.ChangeAllTypes = changeAllTypes;
      component.OriginalType = originalType;
      component.NewType = newType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackTypeCriticalMultiplierIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackTypeCriticalMultiplierIncrease))]
    public UnitConfigurator AddAttackTypeCriticalMultiplierIncrease(
        WeaponRangeType type = default,
        int additionalMultiplier = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AttackTypeCriticalMultiplierIncrease();
      component.Type = type;
      component.AdditionalMultiplier = additionalMultiplier;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AuraFeatureComponent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AuraFeatureComponent))]
    public UnitConfigurator AddAuraFeatureComponent(
        string buff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AuraFeatureComponent();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AutoConfirmCritAgainstFlanked"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AutoConfirmCritAgainstFlanked))]
    public UnitConfigurator AddAutoConfirmCritAgainstFlanked(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AutoConfirmCritAgainstFlanked();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AutoDetectStealth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AutoDetectStealth))]
    public UnitConfigurator AddAutoDetectStealth(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AutoDetectStealth();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AutoMetamagic"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilities"><see cref="BlueprintAbility"/></param>
    /// <param name="spellbook"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    [Implements(typeof(AutoMetamagic))]
    public UnitConfigurator AddAutoMetamagic(
        SpellDescriptorWrapper descriptor,
        AutoMetamagic.AllowedType allowedAbilities = default,
        Metamagic metamagic = default,
        string[] abilities = null,
        bool once = default,
        int maxSpellLevel = default,
        SpellSchool school = default,
        bool checkSpellbook = default,
        string spellbook = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AutoMetamagic();
      component.m_AllowedAbilities = allowedAbilities;
      component.Metamagic = metamagic;
      component.Abilities = abilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToList();
      component.Descriptor = descriptor;
      component.Once = once;
      component.MaxSpellLevel = maxSpellLevel;
      component.School = school;
      component.CheckSpellbook = checkSpellbook;
      component.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(spellbook);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BackToBack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="backToBackFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(BackToBack))]
    public UnitConfigurator AddBackToBack(
        string backToBackFact = null,
        int radius = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BackToBack();
      component.m_BackToBackFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(backToBackFact);
      component.Radius = radius;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BackToBackBetter"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="backToBackBetterFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(BackToBackBetter))]
    public UnitConfigurator AddBackToBackBetter(
        string backToBackBetterFact = null,
        int radius = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BackToBackBetter();
      component.m_BackToBackBetterFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(backToBackBetterFact);
      component.Radius = radius;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BindAbilitiesToClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilites"><see cref="BlueprintAbility"/></param>
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="additionalClasses"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="archetypes"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(BindAbilitiesToClass))]
    public UnitConfigurator AddBindAbilitiesToClass(
        string[] abilites = null,
        bool cantrip = default,
        string characterClass = null,
        StatType stat = default,
        string[] additionalClasses = null,
        string[] archetypes = null,
        int levelStep = default,
        bool odd = default,
        bool fullCasterChecks = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BindAbilitiesToClass();
      component.m_Abilites = abilites.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.Cantrip = cantrip;
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.Stat = stat;
      component.m_AdditionalClasses = additionalClasses.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name)).ToArray();
      component.m_Archetypes = archetypes.Select(name => BlueprintTool.GetRef<BlueprintArchetypeReference>(name)).ToArray();
      component.LevelStep = levelStep;
      component.Odd = odd;
      component.FullCasterChecks = fullCasterChecks;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BindAbilitiesToHighest"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilities"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(BindAbilitiesToHighest))]
    public UnitConfigurator AddBindAbilitiesToHighest(
        string[] abilities = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BindAbilitiesToHighest();
      component.m_Abilities = abilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BlindnessACCompensation"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BlindnessACCompensation))]
    public UnitConfigurator AddBlindnessACCompensation(
        BlueprintComponent.Flags flags = default)
    {
      var component = new BlindnessACCompensation();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Blindsense"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="exceptionFacts"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(Blindsense))]
    public UnitConfigurator AddBlindsense(
        Feet range,
        bool blindsight = default,
        bool hasExceptions = default,
        string[] exceptionFacts = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new Blindsense();
      component.Range = range;
      component.Blindsight = blindsight;
      component.HasExceptions = hasExceptions;
      component.m_ExceptionFacts = exceptionFacts.Select(name => BlueprintTool.GetRef<BlueprintFeatureReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BodyguardACBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(BodyguardACBonus))]
    public UnitConfigurator AddBodyguardACBonus(
        ContextValue value,
        string checkBuff = null,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new BodyguardACBonus();
      component.m_CheckBuff = BlueprintTool.GetRef<BlueprintBuffReference>(checkBuff);
      component.Descriptor = descriptor;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffExtraEffects"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedBuff"><see cref="BlueprintBuff"/></param>
    /// <param name="extraEffectBuff"><see cref="BlueprintBuff"/></param>
    /// <param name="exceptionFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(BuffExtraEffects))]
    public UnitConfigurator AddBuffExtraEffects(
        string checkedBuff = null,
        string extraEffectBuff = null,
        string exceptionFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffExtraEffects();
      component.m_CheckedBuff = BlueprintTool.GetRef<BlueprintBuffReference>(checkedBuff);
      component.m_ExtraEffectBuff = BlueprintTool.GetRef<BlueprintBuffReference>(extraEffectBuff);
      component.m_ExceptionFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(exceptionFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffSubstitutionOnApply"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="gainedFact"><see cref="BlueprintBuff"/></param>
    /// <param name="substituteBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(BuffSubstitutionOnApply))]
    public UnitConfigurator AddBuffSubstitutionOnApply(
        SpellDescriptorWrapper spellDescriptor,
        string gainedFact = null,
        string substituteBuff = null,
        bool checkDescriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffSubstitutionOnApply();
      component.m_GainedFact = BlueprintTool.GetRef<BlueprintBuffReference>(gainedFact);
      component.m_SubstituteBuff = BlueprintTool.GetRef<BlueprintBuffReference>(substituteBuff);
      component.CheckDescriptor = checkDescriptor;
      component.SpellDescriptor = spellDescriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CMBBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(CMBBonus))]
    public UnitConfigurator AddCMBBonus(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        bool checkFact = default,
        string checkedFact = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new CMBBonus();
      component.Descriptor = descriptor;
      component.Value = value;
      component.CheckFact = checkFact;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CMBBonusAgainstSize"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(CMBBonusAgainstSize))]
    public UnitConfigurator AddCMBBonusAgainstSize(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        Size size = default,
        bool checkFact = default,
        string checkedFact = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new CMBBonusAgainstSize();
      component.Descriptor = descriptor;
      component.Value = value;
      component.Size = size;
      component.CheckFact = checkFact;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CMBBonusForManeuver"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(CMBBonusForManeuver))]
    public UnitConfigurator AddCMBBonusForManeuver(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        bool checkFact = default,
        string checkedFact = null,
        CombatManeuver[] maneuvers = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new CMBBonusForManeuver();
      component.Descriptor = descriptor;
      component.Value = value;
      component.CheckFact = checkFact;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.Maneuvers = maneuvers;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CMDBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(CMDBonus))]
    public UnitConfigurator AddCMDBonus(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        bool checkFact = default,
        string checkedFact = null,
        bool onCaster = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new CMDBonus();
      component.Descriptor = descriptor;
      component.Value = value;
      component.CheckFact = checkFact;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.OnCaster = onCaster;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CMDBonusAgainstManeuvers"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CMDBonusAgainstManeuvers))]
    public UnitConfigurator AddCMDBonusAgainstManeuvers(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        CombatManeuver[] maneuvers = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new CMDBonusAgainstManeuvers();
      component.Descriptor = descriptor;
      component.Value = value;
      component.Maneuvers = maneuvers;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CMDBonusAgainstSize"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(CMDBonusAgainstSize))]
    public UnitConfigurator AddCMDBonusAgainstSize(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        Size size = default,
        bool checkFact = default,
        string checkedFact = null,
        bool onCaster = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new CMDBonusAgainstSize();
      component.Descriptor = descriptor;
      component.Value = value;
      component.Size = size;
      component.CheckFact = checkFact;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.OnCaster = onCaster;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CannyDefense"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="chosenWeaponBlueprint"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(CannyDefense))]
    public UnitConfigurator AddCannyDefense(
        string characterClass = null,
        bool requiresKensai = default,
        string chosenWeaponBlueprint = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CannyDefense();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.RequiresKensai = requiresKensai;
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(chosenWeaponBlueprint);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CavalierMountedMastery"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CavalierMountedMastery))]
    public UnitConfigurator AddCavalierMountedMastery(
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CavalierMountedMastery();
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CavalierRetribution"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(CavalierRetribution))]
    public UnitConfigurator AddCavalierRetribution(
        string buff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CavalierRetribution();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CavalierStandAgainstDarkness"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(CavalierStandAgainstDarkness))]
    public UnitConfigurator AddCavalierStandAgainstDarkness(
        string checkedFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CavalierStandAgainstDarkness();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CavalierStealGlory"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CavalierStealGlory))]
    public UnitConfigurator AddCavalierStealGlory(
        BlueprintComponent.Flags flags = default)
    {
      var component = new CavalierStealGlory();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChargeAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChargeAttackBonus))]
    public UnitConfigurator AddChargeAttackBonus(
        ContextValue bonus,
        bool checkWielder = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new ChargeAttackBonus();
      component.CheckWielder = checkWielder;
      component.Descriptor = descriptor;
      component.Bonus = bonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChargeImprovedCritical"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChargeImprovedCritical))]
    public UnitConfigurator AddChargeImprovedCritical(
        BlueprintComponent.Flags flags = default)
    {
      var component = new ChargeImprovedCritical();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ClassLevelsForPrerequisites"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="fakeClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="actualClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(ClassLevelsForPrerequisites))]
    public UnitConfigurator AddClassLevelsForPrerequisites(
        string fakeClass = null,
        string actualClass = null,
        double modifier = default,
        int summand = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ClassLevelsForPrerequisites();
      component.m_FakeClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(fakeClass);
      component.m_ActualClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(actualClass);
      component.Modifier = modifier;
      component.Summand = summand;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CombatAgainstMeTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CombatAgainstMeTrigger))]
    public UnitConfigurator AddCombatAgainstMeTrigger(
        ActionsBuilder combatStartActions = null,
        ActionsBuilder combatEndActions = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CombatAgainstMeTrigger();
      component.CombatStartActions = combatStartActions?.Build() ?? Constants.Empty.Actions;
      component.CombatEndActions = combatEndActions?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CombatStateTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CombatStateTrigger))]
    public UnitConfigurator AddCombatStateTrigger(
        ActionsBuilder combatStartActions = null,
        ActionsBuilder combatEndActions = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CombatStateTrigger();
      component.CombatStartActions = combatStartActions?.Build() ?? Constants.Empty.Actions;
      component.CombatEndActions = combatEndActions?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CompanionBoon"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="rankFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(CompanionBoon))]
    public UnitConfigurator AddCompanionBoon(
        string rankFeature = null,
        int bonus = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CompanionBoon();
      component.m_RankFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(rankFeature);
      component.Bonus = bonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ConcentrationBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="requiredFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ConcentrationBonus))]
    public UnitConfigurator AddConcentrationBonus(
        ContextValue value,
        bool checkFact = default,
        string requiredFact = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new ConcentrationBonus();
      component.Value = value;
      component.CheckFact = checkFact;
      component.m_RequiredFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(requiredFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ConcentrationBonusOnArmorType"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ConcentrationBonusOnArmorType))]
    public UnitConfigurator AddConcentrationBonusOnArmorType(
        ContextValue value,
        ArmorProficiencyGroup armorCategory = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new ConcentrationBonusOnArmorType();
      component.Value = value;
      component.ArmorCategory = armorCategory;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ConstructHealth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ConstructHealth))]
    public UnitConfigurator AddConstructHealth(
        BlueprintComponent.Flags flags = default)
    {
      var component = new ConstructHealth();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextRendFeature"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextRendFeature))]
    public UnitConfigurator AddContextRendFeature(
        ContextDiceValue value,
        DamageTypeDescription rendType,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
      ValidateParam(rendType);
    
      var component = new ContextRendFeature();
      component.Value = value;
      component.RendType = rendType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CoordinatedDefense"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="coordinatedDefenseFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(CoordinatedDefense))]
    public UnitConfigurator AddCoordinatedDefense(
        string coordinatedDefenseFact = null,
        int radius = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CoordinatedDefense();
      component.m_CoordinatedDefenseFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(coordinatedDefenseFact);
      component.Radius = radius;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CoordinatedManeuvers"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="coordinatedManeuversFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(CoordinatedManeuvers))]
    public UnitConfigurator AddCoordinatedManeuvers(
        string coordinatedManeuversFact = null,
        int radius = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CoordinatedManeuvers();
      component.m_CoordinatedManeuversFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(coordinatedManeuversFact);
      component.Radius = radius;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CraftBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CraftBonus))]
    public UnitConfigurator AddCraftBonus(
        ContextValue value,
        UsableItemType bonusFor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new CraftBonus();
      component.m_BonusFor = bonusFor;
      component.m_Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CriticalConfirmationACBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CriticalConfirmationACBonus))]
    public UnitConfigurator AddCriticalConfirmationACBonus(
        ContextValue value,
        int bonus = default,
        bool onlyPositiveValue = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new CriticalConfirmationACBonus();
      component.Value = value;
      component.Bonus = bonus;
      component.OnlyPositiveValue = onlyPositiveValue;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CriticalConfirmationACBonusAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(CriticalConfirmationACBonusAgainstFactOwner))]
    public UnitConfigurator AddCriticalConfirmationACBonusAgainstFactOwner(
        ContextValue value,
        string checkedFact = null,
        int bonus = default,
        bool onlyPositiveValue = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new CriticalConfirmationACBonusAgainstFactOwner();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.Value = value;
      component.Bonus = bonus;
      component.OnlyPositiveValue = onlyPositiveValue;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CriticalConfirmationACBonusInHeavyArmor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CriticalConfirmationACBonusInHeavyArmor))]
    public UnitConfigurator AddCriticalConfirmationACBonusInHeavyArmor(
        int bonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CriticalConfirmationACBonusInHeavyArmor();
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CriticalConfirmationBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CriticalConfirmationBonus))]
    public UnitConfigurator AddCriticalConfirmationBonus(
        ContextValue value,
        int bonus = default,
        bool onlyPositiveValue = default,
        bool checkWeaponRangeType = default,
        WeaponRangeType type = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new CriticalConfirmationBonus();
      component.Value = value;
      component.Bonus = bonus;
      component.OnlyPositiveValue = onlyPositiveValue;
      component.CheckWeaponRangeType = checkWeaponRangeType;
      component.Type = type;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DRWithPool"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(DRWithPool))]
    public UnitConfigurator AddDRWithPool(
        int drPoolPerRank = default,
        int reduction = default,
        int maxPool = default,
        string buff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DRWithPool();
      component.m_drPoolPerRank = drPoolPerRank;
      component.m_reduction = reduction;
      component.m_maxPool = maxPool;
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageBonusAgainstAlignment))]
    public UnitConfigurator AddDamageBonusAgainstAlignment(
        ContextValue bonus,
        AlignmentComponent alignment = default,
        bool onlyMelee = default,
        int damageBonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new DamageBonusAgainstAlignment();
      component.Alignment = alignment;
      component.OnlyMelee = onlyMelee;
      component.DamageBonus = damageBonus;
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(DamageBonusAgainstFactOwner))]
    public UnitConfigurator AddDamageBonusAgainstFactOwner(
        ContextValue bonus,
        string checkedFact = null,
        int damageBonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new DamageBonusAgainstFactOwner();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.DamageBonus = damageBonus;
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstSize"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(DamageBonusAgainstSize))]
    public UnitConfigurator AddDamageBonusAgainstSize(
        ContextValue damageValue,
        Size size = default,
        bool biggerOrEqualSize = default,
        bool onlyForMelee = default,
        ModifierDescriptor descriptor = default,
        string checkedFact = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(damageValue);
    
      var component = new DamageBonusAgainstSize();
      component.DamageValue = damageValue;
      component.size = size;
      component.BiggerOrEqualSize = biggerOrEqualSize;
      component.OnlyForMelee = onlyForMelee;
      component.Descriptor = descriptor;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusOrderOfCockatrice"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(DamageBonusOrderOfCockatrice))]
    public UnitConfigurator AddDamageBonusOrderOfCockatrice(
        ContextValue bonus,
        string checkedFact = null,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new DamageBonusOrderOfCockatrice();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageGrace"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageGrace))]
    public UnitConfigurator AddDamageGrace(
        BlueprintComponent.Flags flags = default)
    {
      var component = new DamageGrace();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageReductionAgainstFactOwner"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(DamageReductionAgainstFactOwner))]
    public UnitConfigurator AddDamageReductionAgainstFactOwner(
        string checkedFact = null,
        int reduction = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DamageReductionAgainstFactOwner();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.Reduction = reduction;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageReductionAgainstRangedWeapons"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="type"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(DamageReductionAgainstRangedWeapons))]
    public UnitConfigurator AddDamageReductionAgainstRangedWeapons(
        string type = null,
        int reductionTrue = default,
        int reductionFalse = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DamageReductionAgainstRangedWeapons();
      component.m_Type = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(type);
      component.ReductionTrue = reductionTrue;
      component.ReductionFalse = reductionFalse;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageReductionAgainstSpells"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(DamageReductionAgainstSpells))]
    public UnitConfigurator AddDamageReductionAgainstSpells(
        string[] spells = null,
        int reduction = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DamageReductionAgainstSpells();
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.Reduction = reduction;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageReductionBelowZero"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageReductionBelowZero))]
    public UnitConfigurator AddDamageReductionBelowZero(
        int reduction = default,
        bool epicBypass = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DamageReductionBelowZero();
      component.Reduction = reduction;
      component.EpicBypass = epicBypass;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DeathOnLevelStacks"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DeathOnLevelStacks))]
    public UnitConfigurator AddDeathOnLevelStacks(
        BlueprintComponent.Flags flags = default)
    {
      var component = new DeathOnLevelStacks();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DefaultSourceBone"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DefaultSourceBone))]
    public UnitConfigurator AddDefaultSourceBone(
        BlueprintComponent.Flags flags = default)
    {
      var component = new DefaultSourceBone();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DefensiveCombatTraining"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DefensiveCombatTraining))]
    public UnitConfigurator AddDefensiveCombatTraining(
        bool mythic = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DefensiveCombatTraining();
      component.Mythic = mythic;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DerivativeStatBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DerivativeStatBonus))]
    public UnitConfigurator AddDerivativeStatBonus(
        StatType baseStat = default,
        StatType derivativeStat = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DerivativeStatBonus();
      component.BaseStat = baseStat;
      component.DerivativeStat = derivativeStat;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DetachBuffOnNearMiss"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DetachBuffOnNearMiss))]
    public UnitConfigurator AddDetachBuffOnNearMiss(
        bool meleeOnly = default,
        bool rangedOnly = default,
        int hitAndArmorDifference = default,
        ActionsBuilder action = null,
        bool onAttacker = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DetachBuffOnNearMiss();
      component.MeleeOnly = meleeOnly;
      component.RangedOnly = rangedOnly;
      component.HitAndArmorDifference = hitAndArmorDifference;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.OnAttacker = onAttacker;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DiceDamageBonusOnSpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(DiceDamageBonusOnSpell))]
    public UnitConfigurator AddDiceDamageBonusOnSpell(
        ContextValue value,
        string[] spells = null,
        bool useContextBonus = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new DiceDamageBonusOnSpell();
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.UseContextBonus = useContextBonus;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DisableIntelligence"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DisableIntelligence))]
    public UnitConfigurator AddDisableIntelligence(
        BlueprintComponent.Flags flags = default)
    {
      var component = new DisableIntelligence();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DisableRegenerationOnCriticalHit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DisableRegenerationOnCriticalHit))]
    public UnitConfigurator AddDisableRegenerationOnCriticalHit(
        BlueprintComponent.Flags flags = default)
    {
      var component = new DisableRegenerationOnCriticalHit();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DispelBonusOnDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DispelBonusOnDescriptor))]
    public UnitConfigurator AddDispelBonusOnDescriptor(
        SpellDescriptorWrapper descriptor,
        int bonus = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DispelBonusOnDescriptor();
      component.Descriptor = descriptor;
      component.Bonus = bonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DispelCasterLevelCheckBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DispelCasterLevelCheckBonus))]
    public UnitConfigurator AddDispelCasterLevelCheckBonus(
        ContextValue value,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new DispelCasterLevelCheckBonus();
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DistanceAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DistanceAttackBonus))]
    public UnitConfigurator AddDistanceAttackBonus(
        Feet range,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DistanceAttackBonus();
      component.Range = range;
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DistanceDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DistanceDamageBonus))]
    public UnitConfigurator AddDistanceDamageBonus(
        Feet range,
        int damageBonus = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DistanceDamageBonus();
      component.Range = range;
      component.DamageBonus = damageBonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DoNotBenefitFromConcealment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DoNotBenefitFromConcealment))]
    public UnitConfigurator AddDoNotBenefitFromConcealment(
        BlueprintComponent.Flags flags = default)
    {
      var component = new DoNotBenefitFromConcealment();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DraconicBloodlineArcana"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DraconicBloodlineArcana))]
    public UnitConfigurator AddDraconicBloodlineArcana(
        SpellDescriptorWrapper spellDescriptor,
        ContextValue value,
        bool spellsOnly = default,
        bool useContextBonus = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new DraconicBloodlineArcana();
      component.SpellDescriptor = spellDescriptor;
      component.SpellsOnly = spellsOnly;
      component.UseContextBonus = useContextBonus;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DuelistPreciseStrike"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="duelist"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="cloakDuelistFact"><see cref="BlueprintBuff"/></param>
    /// <param name="cloakNonDuelistFact"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(DuelistPreciseStrike))]
    public UnitConfigurator AddDuelistPreciseStrike(
        string duelist = null,
        string cloakDuelistFact = null,
        string cloakNonDuelistFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DuelistPreciseStrike();
      component.m_Duelist = BlueprintTool.GetRef<BlueprintCharacterClassReference>(duelist);
      component.m_CloakDuelistFact = BlueprintTool.GetRef<BlueprintBuffReference>(cloakDuelistFact);
      component.m_CloakNonDuelistFact = BlueprintTool.GetRef<BlueprintBuffReference>(cloakNonDuelistFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DungeonClassRestrictedBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(DungeonClassRestrictedBuff))]
    public UnitConfigurator AddDungeonClassRestrictedBuff(
        string buff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DungeonClassRestrictedBuff();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EnduringSpells"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="greater"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(EnduringSpells))]
    public UnitConfigurator AddEnduringSpells(
        string greater = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new EnduringSpells();
      component.m_Greater = BlueprintTool.GetRef<BlueprintUnitFactReference>(greater);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Evasion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Evasion))]
    public UnitConfigurator AddEvasion(
        SavingThrowType savingThrow = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new Evasion();
      component.SavingThrow = savingThrow;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EvasionAgainstDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EvasionAgainstDescriptor))]
    public UnitConfigurator AddEvasionAgainstDescriptor(
        SpellDescriptorWrapper spellDescriptor,
        SavingThrowType savingThrow = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new EvasionAgainstDescriptor();
      component.SpellDescriptor = spellDescriptor;
      component.SavingThrow = savingThrow;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EvasionWithTowerShield"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EvasionWithTowerShield))]
    public UnitConfigurator AddEvasionWithTowerShield(
        bool improved = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new EvasionWithTowerShield();
      component.Improved = improved;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ExpandedArsenalMagicSchools"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ExpandedArsenalMagicSchools))]
    public UnitConfigurator AddExpandedArsenalMagicSchools(
        BlueprintComponent.Flags flags = default)
    {
      var component = new ExpandedArsenalMagicSchools();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FactSinglify"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="oldFacts"><see cref="BlueprintUnitFact"/></param>
    /// <param name="newFacts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(FactSinglify))]
    public UnitConfigurator AddFactSinglify(
        string[] oldFacts = null,
        string[] newFacts = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new FactSinglify();
      component.m_OldFacts = oldFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_NewFacts = newFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FactsChangeTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFacts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(FactsChangeTrigger))]
    public UnitConfigurator AddFactsChangeTrigger(
        string[] checkedFacts = null,
        ActionsBuilder onFactGainedActions = null,
        ActionsBuilder onFactLostActions = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new FactsChangeTrigger();
      component.m_CheckedFacts = checkedFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.OnFactGainedActions = onFactGainedActions?.Build() ?? Constants.Empty.Actions;
      component.OnFactLostActions = onFactLostActions?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FlankedAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(FlankedAttackBonus))]
    public UnitConfigurator AddFlankedAttackBonus(
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new FlankedAttackBonus();
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FlatFootedIgnore"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(FlatFootedIgnore))]
    public UnitConfigurator AddFlatFootedIgnore(
        FlatFootedIgnoreType type = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new FlatFootedIgnore();
      component.Type = type;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FullSpeedInStealth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(FullSpeedInStealth))]
    public UnitConfigurator AddFullSpeedInStealth(
        BlueprintComponent.Flags flags = default)
    {
      var component = new FullSpeedInStealth();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FullWeaponMasterySkeletonParametrized"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="focus"><see cref="BlueprintParametrizedFeature"/></param>
    /// <param name="specialization"><see cref="BlueprintParametrizedFeature"/></param>
    /// <param name="greaterFocus"><see cref="BlueprintParametrizedFeature"/></param>
    /// <param name="greaterSpecialization"><see cref="BlueprintParametrizedFeature"/></param>
    /// <param name="improvedCritical"><see cref="BlueprintParametrizedFeature"/></param>
    /// <param name="weaponMastery"><see cref="BlueprintParametrizedFeature"/></param>
    /// <param name="greaterFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(FullWeaponMasterySkeletonParametrized))]
    public UnitConfigurator AddFullWeaponMasterySkeletonParametrized(
        string focus = null,
        string specialization = null,
        string greaterFocus = null,
        string greaterSpecialization = null,
        string improvedCritical = null,
        string weaponMastery = null,
        string greaterFeature = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new FullWeaponMasterySkeletonParametrized();
      component.m_Focus = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(focus);
      component.m_Specialization = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(specialization);
      component.m_GreaterFocus = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(greaterFocus);
      component.m_GreaterSpecialization = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(greaterSpecialization);
      component.m_ImprovedCritical = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(improvedCritical);
      component.m_WeaponMastery = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(weaponMastery);
      component.m_GreaterFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(greaterFeature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Hardy"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="steelSoul"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(Hardy))]
    public UnitConfigurator AddHardy(
        string steelSoul = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new Hardy();
      component.m_SteelSoul = BlueprintTool.GetRef<BlueprintFeatureReference>(steelSoul);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="HarmoniousMage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HarmoniousMage))]
    public UnitConfigurator AddHarmoniousMage(
        BlueprintComponent.Flags flags = default)
    {
      var component = new HarmoniousMage();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreConcealment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreConcealment))]
    public UnitConfigurator AddIgnoreConcealment(
        BlueprintComponent.Flags flags = default)
    {
      var component = new IgnoreConcealment();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreCritImmunity"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(IgnoreCritImmunity))]
    public UnitConfigurator AddIgnoreCritImmunity(
        bool checkFact = default,
        string checkedFact = null,
        bool not = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IgnoreCritImmunity();
      component.CheckFact = checkFact;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(checkedFact);
      component.Not = not;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreDamageReductionOnCriticalHit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreDamageReductionOnCriticalHit))]
    public UnitConfigurator AddIgnoreDamageReductionOnCriticalHit(
        BlueprintComponent.Flags flags = default)
    {
      var component = new IgnoreDamageReductionOnCriticalHit();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreDamageReductionOnTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreDamageReductionOnTarget))]
    public UnitConfigurator AddIgnoreDamageReductionOnTarget(
        bool checkTargetAlignment = default,
        AlignmentComponent alignment = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IgnoreDamageReductionOnTarget();
      component.CheckTargetAlignment = checkTargetAlignment;
      component.Alignment = alignment;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnorePartialConcealmentOnRangedAttacks"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnorePartialConcealmentOnRangedAttacks))]
    public UnitConfigurator AddIgnorePartialConcealmentOnRangedAttacks(
        BlueprintComponent.Flags flags = default)
    {
      var component = new IgnorePartialConcealmentOnRangedAttacks();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreSpellResistanceForSpells"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilityList"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(IgnoreSpellResistanceForSpells))]
    public UnitConfigurator AddIgnoreSpellResistanceForSpells(
        string[] abilityList = null,
        bool allSpells = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IgnoreSpellResistanceForSpells();
      component.m_AbilityList = abilityList.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.AllSpells = allSpells;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ImpromptuSneakAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ImpromptuSneakAttack))]
    public UnitConfigurator AddImpromptuSneakAttack(
        BlueprintComponent.Flags flags = default)
    {
      var component = new ImpromptuSneakAttack();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ImprovedCriticalEdgeParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ImprovedCriticalEdgeParametrized))]
    public UnitConfigurator AddImprovedCriticalEdgeParametrized(
        BlueprintComponent.Flags flags = default)
    {
      var component = new ImprovedCriticalEdgeParametrized();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ImprovedCriticalMythicParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ImprovedCriticalMythicParametrized))]
    public UnitConfigurator AddImprovedCriticalMythicParametrized(
        BlueprintComponent.Flags flags = default)
    {
      var component = new ImprovedCriticalMythicParametrized();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ImprovedCriticalParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ImprovedCriticalParametrized))]
    public UnitConfigurator AddImprovedCriticalParametrized(
        BlueprintComponent.Flags flags = default)
    {
      var component = new ImprovedCriticalParametrized();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ImprovedEvasion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ImprovedEvasion))]
    public UnitConfigurator AddImprovedEvasion(
        SavingThrowType savingThrow = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ImprovedEvasion();
      component.SavingThrow = savingThrow;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="InHarmsWay"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkBuff"><see cref="BlueprintBuff"/></param>
    /// <param name="cooldownBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(InHarmsWay))]
    public UnitConfigurator AddInHarmsWay(
        string checkBuff = null,
        string cooldownBuff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new InHarmsWay();
      component.m_CheckBuff = BlueprintTool.GetRef<BlueprintBuffReference>(checkBuff);
      component.m_CooldownBuff = BlueprintTool.GetRef<BlueprintBuffReference>(cooldownBuff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseAllSpellsDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseAllSpellsDC))]
    public UnitConfigurator AddIncreaseAllSpellsDC(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        bool spellsOnly = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new IncreaseAllSpellsDC();
      component.Value = value;
      component.Descriptor = descriptor;
      component.SpellsOnly = spellsOnly;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseCasterLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseCasterLevel))]
    public UnitConfigurator AddIncreaseCasterLevel(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new IncreaseCasterLevel();
      component.Value = value;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseCastersSavingThrowTypeDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseCastersSavingThrowTypeDC))]
    public UnitConfigurator AddIncreaseCastersSavingThrowTypeDC(
        SavingThrowType type = default,
        int bonusDC = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncreaseCastersSavingThrowTypeDC();
      component.Type = type;
      component.BonusDC = bonusDC;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseFeatRankByGroup"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseFeatRankByGroup))]
    public UnitConfigurator AddIncreaseFeatRankByGroup(
        FeatureGroup group = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncreaseFeatRankByGroup();
      component.Group = group;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellContextDescriptorDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseSpellContextDescriptorDC))]
    public UnitConfigurator AddIncreaseSpellContextDescriptorDC(
        SpellDescriptorWrapper descriptor,
        ContextValue value,
        ModifierDescriptor modifierDescriptor = default,
        bool spellsOnly = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new IncreaseSpellContextDescriptorDC();
      component.Descriptor = descriptor;
      component.Value = value;
      component.ModifierDescriptor = modifierDescriptor;
      component.SpellsOnly = spellsOnly;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellDC"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spell"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(IncreaseSpellDC))]
    public UnitConfigurator AddIncreaseSpellDC(
        ContextValue value,
        string spell = null,
        bool halfMythicRank = default,
        bool useContextBonus = default,
        int bonusDC = default,
        ModifierDescriptor descriptor = default,
        bool spellsOnly = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new IncreaseSpellDC();
      component.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(spell);
      component.HalfMythicRank = halfMythicRank;
      component.UseContextBonus = useContextBonus;
      component.Value = value;
      component.BonusDC = bonusDC;
      component.Descriptor = descriptor;
      component.SpellsOnly = spellsOnly;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellDescriptorCasterLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseSpellDescriptorCasterLevel))]
    public UnitConfigurator AddIncreaseSpellDescriptorCasterLevel(
        SpellDescriptorWrapper descriptor,
        int bonusCasterLevel = default,
        ModifierDescriptor modifierDescriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncreaseSpellDescriptorCasterLevel();
      component.Descriptor = descriptor;
      component.BonusCasterLevel = bonusCasterLevel;
      component.ModifierDescriptor = modifierDescriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellDescriptorDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseSpellDescriptorDC))]
    public UnitConfigurator AddIncreaseSpellDescriptorDC(
        SpellDescriptorWrapper descriptor,
        int bonusDC = default,
        ModifierDescriptor modifierDescriptor = default,
        bool spellsOnly = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncreaseSpellDescriptorDC();
      component.Descriptor = descriptor;
      component.BonusDC = bonusDC;
      component.ModifierDescriptor = modifierDescriptor;
      component.SpellsOnly = spellsOnly;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellSchoolCasterLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseSpellSchoolCasterLevel))]
    public UnitConfigurator AddIncreaseSpellSchoolCasterLevel(
        SpellSchool school = default,
        int bonusLevel = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncreaseSpellSchoolCasterLevel();
      component.School = school;
      component.BonusLevel = bonusLevel;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellSchoolDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseSpellSchoolDC))]
    public UnitConfigurator AddIncreaseSpellSchoolDC(
        SpellSchool school = default,
        int bonusDC = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncreaseSpellSchoolDC();
      component.School = school;
      component.BonusDC = bonusDC;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellSchoolDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IncreaseSpellSchoolDamage))]
    public UnitConfigurator AddIncreaseSpellSchoolDamage(
        ContextValue damageBonus,
        SpellSchool school = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(damageBonus);
    
      var component = new IncreaseSpellSchoolDamage();
      component.School = school;
      component.DamageBonus = damageBonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellSpellbookDC"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbooks"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    [Implements(typeof(IncreaseSpellSpellbookDC))]
    public UnitConfigurator AddIncreaseSpellSpellbookDC(
        string[] spellbooks = null,
        int bonusDC = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncreaseSpellSpellbookDC();
      component.m_Spellbooks = spellbooks.Select(name => BlueprintTool.GetRef<BlueprintSpellbookReference>(name)).ToArray();
      component.BonusDC = bonusDC;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IndomitableMount"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="cooldownBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(IndomitableMount))]
    public UnitConfigurator AddIndomitableMount(
        string cooldownBuff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IndomitableMount();
      component.m_CooldownBuff = BlueprintTool.GetRef<BlueprintBuffReference>(cooldownBuff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="InitiatorCritAutoconfirm"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(InitiatorCritAutoconfirm))]
    public UnitConfigurator AddInitiatorCritAutoconfirm(
        BlueprintComponent.Flags flags = default)
    {
      var component = new InitiatorCritAutoconfirm();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KensaiChosenWeapon"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="focus"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(KensaiChosenWeapon))]
    public UnitConfigurator AddKensaiChosenWeapon(
        string focus = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new KensaiChosenWeapon();
      component.m_Focus = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(focus);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KensaiCriticalPerfection"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="magusBlueprint"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="chosenWeaponBlueprint"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(KensaiCriticalPerfection))]
    public UnitConfigurator AddKensaiCriticalPerfection(
        string magusBlueprint = null,
        string chosenWeaponBlueprint = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new KensaiCriticalPerfection();
      component.m_MagusBlueprint = BlueprintTool.GetRef<BlueprintCharacterClassReference>(magusBlueprint);
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(chosenWeaponBlueprint);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KensaiIaijutsuFocus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="magusBlueprint"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="chosenWeaponBlueprint"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(KensaiIaijutsuFocus))]
    public UnitConfigurator AddKensaiIaijutsuFocus(
        string magusBlueprint = null,
        string chosenWeaponBlueprint = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new KensaiIaijutsuFocus();
      component.m_MagusBlueprint = BlueprintTool.GetRef<BlueprintCharacterClassReference>(magusBlueprint);
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(chosenWeaponBlueprint);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KensaiPerfectStrike"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="magusBlueprint"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="chosenWeaponBlueprint"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(KensaiPerfectStrike))]
    public UnitConfigurator AddKensaiPerfectStrike(
        string magusBlueprint = null,
        string chosenWeaponBlueprint = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new KensaiPerfectStrike();
      component.m_MagusBlueprint = BlueprintTool.GetRef<BlueprintCharacterClassReference>(magusBlueprint);
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(chosenWeaponBlueprint);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KensaiPowerfulCrit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="magusBlueprint"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="chosenWeaponBlueprint"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(KensaiPowerfulCrit))]
    public UnitConfigurator AddKensaiPowerfulCrit(
        string magusBlueprint = null,
        string chosenWeaponBlueprint = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new KensaiPowerfulCrit();
      component.m_MagusBlueprint = BlueprintTool.GetRef<BlueprintCharacterClassReference>(magusBlueprint);
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(chosenWeaponBlueprint);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KensaiWeaponMastery"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="magusBlueprint"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="chosenWeaponBlueprint"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(KensaiWeaponMastery))]
    public UnitConfigurator AddKensaiWeaponMastery(
        string magusBlueprint = null,
        string chosenWeaponBlueprint = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new KensaiWeaponMastery();
      component.m_MagusBlueprint = BlueprintTool.GetRef<BlueprintCharacterClassReference>(magusBlueprint);
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(chosenWeaponBlueprint);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LearnSpellParametrized"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellcasterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="spellList"><see cref="BlueprintSpellList"/></param>
    [Generated]
    [Implements(typeof(LearnSpellParametrized))]
    public UnitConfigurator AddLearnSpellParametrized(
        string spellcasterClass = null,
        string spellList = null,
        bool specificSpellLevel = default,
        int spellLevelPenalty = default,
        int spellLevel = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new LearnSpellParametrized();
      component.m_SpellcasterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(spellcasterClass);
      component.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(spellList);
      component.SpecificSpellLevel = specificSpellLevel;
      component.SpellLevelPenalty = spellLevelPenalty;
      component.SpellLevel = spellLevel;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MadDogPackTactics"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MadDogPackTactics))]
    public UnitConfigurator AddMadDogPackTactics(
        BlueprintComponent.Flags flags = default)
    {
      var component = new MadDogPackTactics();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ManeuverBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ManeuverBonus))]
    public UnitConfigurator AddManeuverBonus(
        CombatManeuver type = default,
        bool mythic = default,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ManeuverBonus();
      component.Type = type;
      component.Mythic = mythic;
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ManeuverBonusFromStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ManeuverBonusFromStat))]
    public UnitConfigurator AddManeuverBonusFromStat(
        CombatManeuver type = default,
        StatType stat = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ManeuverBonusFromStat();
      component.Type = type;
      component.Stat = stat;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ManeuverDefenceBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ManeuverDefenceBonus))]
    public UnitConfigurator AddManeuverDefenceBonus(
        CombatManeuver type = default,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ManeuverDefenceBonus();
      component.Type = type;
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ManeuverImmunity"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ManeuverImmunity))]
    public UnitConfigurator AddManeuverImmunity(
        CombatManeuver type = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ManeuverImmunity();
      component.Type = type;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ManeuverIncreaseDuration"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ManeuverIncreaseDuration))]
    public UnitConfigurator AddManeuverIncreaseDuration(
        CombatManeuver type = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ManeuverIncreaseDuration();
      component.Type = type;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ManeuverOnAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ManeuverOnAttack))]
    public UnitConfigurator AddManeuverOnAttack(
        WeaponCategory category = default,
        CombatManeuver maneuver = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ManeuverOnAttack();
      component.Category = category;
      component.Maneuver = maneuver;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ManeuverProvokeAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ManeuverProvokeAttack))]
    public UnitConfigurator AddManeuverProvokeAttack(
        CombatManeuver maneuverType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ManeuverProvokeAttack();
      component.ManeuverType = maneuverType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ManeuverTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ManeuverTrigger))]
    public UnitConfigurator AddManeuverTrigger(
        CombatManeuver maneuverType = default,
        bool onlySuccess = default,
        ActionsBuilder action = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ManeuverTrigger();
      component.ManeuverType = maneuverType;
      component.OnlySuccess = onlySuccess;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MaxDexBonusIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MaxDexBonusIncrease))]
    public UnitConfigurator AddMaxDexBonusIncrease(
        int bonus = default,
        int bonesPerRank = default,
        bool checkCategory = default,
        ArmorProficiencyGroup category = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new MaxDexBonusIncrease();
      component.Bonus = bonus;
      component.BonesPerRank = bonesPerRank;
      component.CheckCategory = checkCategory;
      component.Category = category;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MeleeWeaponSizeChange"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MeleeWeaponSizeChange))]
    public UnitConfigurator AddMeleeWeaponSizeChange(
        int sizeCategoryChange = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new MeleeWeaponSizeChange();
      component.SizeCategoryChange = sizeCategoryChange;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MetamagicOnNextSpell"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MetamagicOnNextSpell))]
    public UnitConfigurator AddMetamagicOnNextSpell(
        Metamagic metamagic = default,
        bool doNotRemove = default,
        bool sourcerousReflex = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new MetamagicOnNextSpell();
      component.Metamagic = metamagic;
      component.DoNotRemove = doNotRemove;
      component.SourcerousReflex = sourcerousReflex;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MetamagicRodMechanics"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="rodAbility"><see cref="BlueprintActivatableAbility"/></param>
    /// <param name="abilitiesWhiteList"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(MetamagicRodMechanics))]
    public UnitConfigurator AddMetamagicRodMechanics(
        Metamagic metamagic = default,
        int maxSpellLevel = default,
        string rodAbility = null,
        string[] abilitiesWhiteList = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new MetamagicRodMechanics();
      component.Metamagic = metamagic;
      component.MaxSpellLevel = maxSpellLevel;
      component.m_RodAbility = BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(rodAbility);
      component.m_AbilitiesWhiteList = abilitiesWhiteList.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MobCaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MobCaster))]
    public UnitConfigurator AddMobCaster(
        BlueprintComponent.Flags flags = default)
    {
      var component = new MobCaster();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ModifyD20"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="tandemTripFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(ModifyD20))]
    public UnitConfigurator AddModifyD20(
        ContextValue bonus,
        ContextValue chance,
        SpellDescriptorWrapper spellDescriptor,
        ContextValue value,
        RuleType rule = default,
        RuleDispelMagic.CheckType dispellMagicCheckType = default,
        bool replace = default,
        int rollsAmount = default,
        bool takeBest = default,
        int roll = default,
        bool addBonus = default,
        ModifierDescriptor bonusDescriptor = default,
        bool withChance = default,
        bool rerollOnlyIfFailed = default,
        bool dispellOnRerollFinished = default,
        bool dispellOn20 = default,
        bool againstAlignment = default,
        AlignmentComponent alignment = default,
        bool targetAlignment = default,
        bool specificSkill = default,
        StatType[] skill = null,
        ModifyD20.InnerSavingThrowType savingThrowType = default,
        bool specificDescriptor = default,
        bool addSavingThrowBonus = default,
        ModifierDescriptor modifierDescriptor = default,
        bool tandemTrip = default,
        string tandemTripFeature = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
      ValidateParam(chance);
      ValidateParam(value);
    
      var component = new ModifyD20();
      component.Rule = rule;
      component.DispellMagicCheckType = dispellMagicCheckType;
      component.Replace = replace;
      component.RollsAmount = rollsAmount;
      component.TakeBest = takeBest;
      component.Roll = roll;
      component.AddBonus = addBonus;
      component.Bonus = bonus;
      component.BonusDescriptor = bonusDescriptor;
      component.WithChance = withChance;
      component.Chance = chance;
      component.RerollOnlyIfFailed = rerollOnlyIfFailed;
      component.DispellOnRerollFinished = dispellOnRerollFinished;
      component.DispellOn20 = dispellOn20;
      component.AgainstAlignment = againstAlignment;
      component.Alignment = alignment;
      component.TargetAlignment = targetAlignment;
      component.SpecificSkill = specificSkill;
      component.Skill = skill;
      component.m_SavingThrowType = savingThrowType;
      component.SpecificDescriptor = specificDescriptor;
      component.SpellDescriptor = spellDescriptor;
      component.AddSavingThrowBonus = addSavingThrowBonus;
      component.ModifierDescriptor = modifierDescriptor;
      component.Value = value;
      component.TandemTrip = tandemTrip;
      component.m_TandemTripFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(tandemTripFeature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MonkReplaceAbilityDC"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="BlueprintAbility"/></param>
    /// <param name="scaledFist"><see cref="BlueprintArchetype"/></param>
    /// <param name="monk"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(MonkReplaceAbilityDC))]
    public UnitConfigurator AddMonkReplaceAbilityDC(
        string ability = null,
        string scaledFist = null,
        string monk = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new MonkReplaceAbilityDC();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      component.m_ScaledFist = BlueprintTool.GetRef<BlueprintArchetypeReference>(scaledFist);
      component.m_Monk = BlueprintTool.GetRef<BlueprintCharacterClassReference>(monk);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MountedCombat"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="cooldownBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(MountedCombat))]
    public UnitConfigurator AddMountedCombat(
        string cooldownBuff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new MountedCombat();
      component.m_CooldownBuff = BlueprintTool.GetRef<BlueprintBuffReference>(cooldownBuff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MythicUnarmedStrike"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MythicUnarmedStrike))]
    public UnitConfigurator AddMythicUnarmedStrike(
        BlueprintComponent.Flags flags = default)
    {
      var component = new MythicUnarmedStrike();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="NeutralToFaction"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="faction"><see cref="BlueprintFaction"/></param>
    [Generated]
    [Implements(typeof(NeutralToFaction))]
    public UnitConfigurator AddNeutralToFaction(
        string faction = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new NeutralToFaction();
      component.m_Faction = BlueprintTool.GetRef<BlueprintFactionReference>(faction);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="NewRoundTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(NewRoundTrigger))]
    public UnitConfigurator AddNewRoundTrigger(
        ActionsBuilder newRoundActions = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new NewRoundTrigger();
      component.NewRoundActions = newRoundActions?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OnSpawnBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ifHaveFact"><see cref="BlueprintFeature"/></param>
    /// <param name="ifSummonHaveFact"><see cref="BlueprintFeature"/></param>
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(OnSpawnBuff))]
    public UnitConfigurator AddOnSpawnBuff(
        SpellDescriptorWrapper spellDescriptor,
        Rounds duration,
        string ifHaveFact = null,
        bool checkSummonedUnitFact = default,
        string ifSummonHaveFact = null,
        bool checkSummonedUnitAlignment = default,
        AlignmentComponent summonedAlignment = default,
        string buff = null,
        bool checkDescriptor = default,
        bool isInfinity = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new OnSpawnBuff();
      component.m_IfHaveFact = BlueprintTool.GetRef<BlueprintFeatureReference>(ifHaveFact);
      component.CheckSummonedUnitFact = checkSummonedUnitFact;
      component.m_IfSummonHaveFact = BlueprintTool.GetRef<BlueprintFeatureReference>(ifSummonHaveFact);
      component.CheckSummonedUnitAlignment = checkSummonedUnitAlignment;
      component.SummonedAlignment = summonedAlignment;
      component.m_buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.CheckDescriptor = checkDescriptor;
      component.SpellDescriptor = spellDescriptor;
      component.IsInfinity = isInfinity;
      component.duration = duration;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Opportunist"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Opportunist))]
    public UnitConfigurator AddOpportunist(
        BlueprintComponent.Flags flags = default)
    {
      var component = new Opportunist();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OutflankAttackBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="outflankFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(OutflankAttackBonus))]
    public UnitConfigurator AddOutflankAttackBonus(
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        string outflankFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new OutflankAttackBonus();
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.m_OutflankFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(outflankFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OutflankDamageBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="outflankFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(OutflankDamageBonus))]
    public UnitConfigurator AddOutflankDamageBonus(
        int damageBonus = default,
        int increasedDamageBonus = default,
        string outflankFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new OutflankDamageBonus();
      component.DamageBonus = damageBonus;
      component.IncreasedDamageBonus = increasedDamageBonus;
      component.m_OutflankFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(outflankFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OutflankProvokeAttack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="outflankFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(OutflankProvokeAttack))]
    public UnitConfigurator AddOutflankProvokeAttack(
        string outflankFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new OutflankProvokeAttack();
      component.m_OutflankFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(outflankFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PartialDRIgnore"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PartialDRIgnore))]
    public UnitConfigurator AddPartialDRIgnore(
        int reductionReduction = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new PartialDRIgnore();
      component.ReductionReduction = reductionReduction;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PenetratingStrike"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PenetratingStrike))]
    public UnitConfigurator AddPenetratingStrike(
        int reductionReduction = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new PenetratingStrike();
      component.ReductionReduction = reductionReduction;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PetManeuverProvokeAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PetManeuverProvokeAttack))]
    public UnitConfigurator AddPetManeuverProvokeAttack(
        CombatManeuver[] maneuver = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new PetManeuverProvokeAttack();
      component.Maneuver = maneuver;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PointBlankMaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PointBlankMaster))]
    public UnitConfigurator AddPointBlankMaster(
        WeaponCategory category = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new PointBlankMaster();
      component.Category = category;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PointBlankMasterParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PointBlankMasterParametrized))]
    public UnitConfigurator AddPointBlankMasterParametrized(
        BlueprintComponent.Flags flags = default)
    {
      var component = new PointBlankMasterParametrized();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PowerAttackWatcher"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="powerAttackBlueprint"><see cref="BlueprintActivatableAbility"/></param>
    [Generated]
    [Implements(typeof(PowerAttackWatcher))]
    public UnitConfigurator AddPowerAttackWatcher(
        string powerAttackBlueprint = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new PowerAttackWatcher();
      component.m_PowerAttackBlueprint = BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(powerAttackBlueprint);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PreciseShot"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PreciseShot))]
    public UnitConfigurator AddPreciseShot(
        BlueprintComponent.Flags flags = default)
    {
      var component = new PreciseShot();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PreciseShotDivineHunterTarget"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(PreciseShotDivineHunterTarget))]
    public UnitConfigurator AddPreciseShotDivineHunterTarget(
        string buff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new PreciseShotDivineHunterTarget();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PreciseStrike"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="preciseStrikeFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(PreciseStrike))]
    public UnitConfigurator AddPreciseStrike(
        DamageDescription damage,
        string preciseStrikeFact = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(damage);
    
      var component = new PreciseStrike();
      component.Damage = damage;
      component.m_PreciseStrikeFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(preciseStrikeFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RangedWeaponSizeChange"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponTypes"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(RangedWeaponSizeChange))]
    public UnitConfigurator AddRangedWeaponSizeChange(
        int sizeCategoryChange = default,
        string[] weaponTypes = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RangedWeaponSizeChange();
      component.SizeCategoryChange = sizeCategoryChange;
      component.WeaponTypes = weaponTypes.Select(name => BlueprintTool.GetRef<BlueprintWeaponTypeReference>(name)).ToList();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecalculateConcealment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecalculateConcealment))]
    public UnitConfigurator AddRecalculateConcealment(
        bool ignorePartial = default,
        bool treatTotalAsPartial = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RecalculateConcealment();
      component.IgnorePartial = ignorePartial;
      component.TreatTotalAsPartial = treatTotalAsPartial;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecalculateOnFactsChange"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFacts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(RecalculateOnFactsChange))]
    public UnitConfigurator AddRecalculateOnFactsChange(
        string[] checkedFacts = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RecalculateOnFactsChange();
      component.m_CheckedFacts = checkedFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecalculateOnLocustSwarmChange"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecalculateOnLocustSwarmChange))]
    public UnitConfigurator AddRecalculateOnLocustSwarmChange(
        BlueprintComponent.Flags flags = default)
    {
      var component = new RecalculateOnLocustSwarmChange();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecalculateOnStatChange"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecalculateOnStatChange))]
    public UnitConfigurator AddRecalculateOnStatChange(
        bool useKineticistMainStat = default,
        StatType stat = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RecalculateOnStatChange();
      component.UseKineticistMainStat = useKineticistMainStat;
      component.Stat = stat;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendedClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="favoriteClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(RecommendedClass))]
    public UnitConfigurator AddRecommendedClass(
        string favoriteClass = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RecommendedClass();
      component.m_FavoriteClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(favoriteClass);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RemoveAfterCast"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="abilities"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(RemoveAfterCast))]
    public UnitConfigurator AddRemoveAfterCast(
        string[] abilities = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RemoveAfterCast();
      component.Abilities = abilities.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToList();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RemoveBuffOnAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemoveBuffOnAttack))]
    public UnitConfigurator AddRemoveBuffOnAttack(
        BlueprintComponent.Flags flags = default)
    {
      var component = new RemoveBuffOnAttack();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RemoveFeatureOnApply"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(RemoveFeatureOnApply))]
    public UnitConfigurator AddRemoveFeatureOnApply(
        string feature = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RemoveFeatureOnApply();
      component.m_Feature = BlueprintTool.GetRef<BlueprintUnitFactReference>(feature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RendFeature"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RendFeature))]
    public UnitConfigurator AddRendFeature(
        DiceFormula rendDamage,
        DamageTypeDescription rendType,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(rendType);
    
      var component = new RendFeature();
      component.RendDamage = rendDamage;
      component.RendType = rendType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceAbilitiesStat"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(ReplaceAbilitiesStat))]
    public UnitConfigurator AddReplaceAbilitiesStat(
        string[] ability = null,
        StatType stat = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReplaceAbilitiesStat();
      component.m_Ability = ability.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.Stat = stat;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceAbilityDC"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(ReplaceAbilityDC))]
    public UnitConfigurator AddReplaceAbilityDC(
        string ability = null,
        StatType stat = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReplaceAbilityDC();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      component.Stat = stat;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceAbilityParamsWithContext"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(ReplaceAbilityParamsWithContext))]
    public UnitConfigurator AddReplaceAbilityParamsWithContext(
        string ability = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReplaceAbilityParamsWithContext();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceCMDDexterityStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ReplaceCMDDexterityStat))]
    public UnitConfigurator AddReplaceCMDDexterityStat(
        StatType newStat = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReplaceCMDDexterityStat();
      component.NewStat = newStat;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceCastSource"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ReplaceCastSource))]
    public UnitConfigurator AddReplaceCastSource(
        CastSource castSource = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReplaceCastSource();
      component.CastSource = castSource;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceCasterLevelOfAbility"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spell"><see cref="BlueprintAbility"/></param>
    /// <param name="clazz"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="additionalClasses"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="archetypes"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(ReplaceCasterLevelOfAbility))]
    public UnitConfigurator AddReplaceCasterLevelOfAbility(
        string spell = null,
        string clazz = null,
        string[] additionalClasses = null,
        string[] archetypes = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReplaceCasterLevelOfAbility();
      component.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(spell);
      component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      component.m_AdditionalClasses = additionalClasses.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name)).ToArray();
      component.m_Archetypes = archetypes.Select(name => BlueprintTool.GetRef<BlueprintArchetypeReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceCasterLevelOfFeature"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="BlueprintFeature"/></param>
    /// <param name="clazz"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(ReplaceCasterLevelOfFeature))]
    public UnitConfigurator AddReplaceCasterLevelOfFeature(
        string feature = null,
        string clazz = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReplaceCasterLevelOfFeature();
      component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceCombatManeuverStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ReplaceCombatManeuverStat))]
    public UnitConfigurator AddReplaceCombatManeuverStat(
        StatType statType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReplaceCombatManeuverStat();
      component.StatType = statType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceSingleCombatManeuverStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ReplaceSingleCombatManeuverStat))]
    public UnitConfigurator AddReplaceSingleCombatManeuverStat(
        CombatManeuver type = default,
        StatType statType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReplaceSingleCombatManeuverStat();
      component.Type = type;
      component.StatType = statType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceSourceBone"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ReplaceSourceBone))]
    public UnitConfigurator AddReplaceSourceBone(
        string sourceBone,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReplaceSourceBone();
      component.SourceBone = sourceBone;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceStatForPrerequisites"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(ReplaceStatForPrerequisites))]
    public UnitConfigurator AddReplaceStatForPrerequisites(
        StatType oldStat = default,
        ReplaceStatForPrerequisites.StatReplacementPolicy policy = default,
        StatType newStat = default,
        string characterClass = null,
        int specificNumber = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReplaceStatForPrerequisites();
      component.OldStat = oldStat;
      component.Policy = policy;
      component.NewStat = newStat;
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.SpecificNumber = specificNumber;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RerollConcealment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RerollConcealment))]
    public UnitConfigurator AddRerollConcealment(
        BlueprintComponent.Flags flags = default)
    {
      var component = new RerollConcealment();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RideAnimalCompanion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RideAnimalCompanion))]
    public UnitConfigurator AddRideAnimalCompanion(
        BlueprintComponent.Flags flags = default)
    {
      var component = new RideAnimalCompanion();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SaturationAuraComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SaturationAuraComponent))]
    public UnitConfigurator AddSaturationAuraComponent(
        SaturationAuraType saturationAuraType = default,
        float radius = default,
        float distanceToCamera = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SaturationAuraComponent();
      component.m_SaturationAuraType = saturationAuraType;
      component.m_Radius = radius;
      component.m_DistanceToCamera = distanceToCamera;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavesFixedRecalculateThievery"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavesFixedRecalculateThievery))]
    public UnitConfigurator AddSavesFixedRecalculateThievery(
        BlueprintComponent.Flags flags = default)
    {
      var component = new SavesFixedRecalculateThievery();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavesFixerFactReplacer"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="oldFacts"><see cref="BlueprintUnitFact"/></param>
    /// <param name="newFacts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SavesFixerFactReplacer))]
    public UnitConfigurator AddSavesFixerFactReplacer(
        string[] oldFacts = null,
        string[] newFacts = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SavesFixerFactReplacer();
      component.m_OldFacts = oldFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_NewFacts = newFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavesFixerParamSpellSchool"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavesFixerParamSpellSchool))]
    public UnitConfigurator AddSavesFixerParamSpellSchool(
        BlueprintComponent.Flags flags = default)
    {
      var component = new SavesFixerParamSpellSchool();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavesFixerRecalculate"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavesFixerRecalculate))]
    public UnitConfigurator AddSavesFixerRecalculate(
        int version = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SavesFixerRecalculate();
      component.Version = version;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavesFixerReplaceInProgression"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="oldFeature"><see cref="BlueprintFeature"/></param>
    /// <param name="newFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(SavesFixerReplaceInProgression))]
    public UnitConfigurator AddSavesFixerReplaceInProgression(
        string oldFeature = null,
        string newFeature = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SavesFixerReplaceInProgression();
      component.m_OldFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(oldFeature);
      component.m_NewFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(newFeature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingSlash"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavingSlash))]
    public UnitConfigurator AddSavingSlash(
        ContextValue value,
        bool useContextValue = default,
        int bonus = default,
        WeaponCategory weapon = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new SavingSlash();
      component.UseContextValue = useContextValue;
      component.Bonus = bonus;
      component.Value = value;
      component.Weapon = weapon;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstAbilityType"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstAbilityType))]
    public UnitConfigurator AddSavingThrowBonusAgainstAbilityType(
        ContextValue bonus,
        AbilityType abilityType = default,
        ModifierDescriptor modifierDescriptor = default,
        int value = default,
        bool onlyPositiveValue = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new SavingThrowBonusAgainstAbilityType();
      component.AbilityType = abilityType;
      component.ModifierDescriptor = modifierDescriptor;
      component.Value = value;
      component.Bonus = bonus;
      component.OnlyPositiveValue = onlyPositiveValue;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstAlignment))]
    public UnitConfigurator AddSavingThrowBonusAgainstAlignment(
        ContextValue bonus,
        AlignmentComponent alignment = default,
        ModifierDescriptor descriptor = default,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new SavingThrowBonusAgainstAlignment();
      component.Alignment = alignment;
      component.Descriptor = descriptor;
      component.Value = value;
      component.Bonus = bonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstAlignmentDifference"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstAlignmentDifference))]
    public UnitConfigurator AddSavingThrowBonusAgainstAlignmentDifference(
        ModifierDescriptor descriptor = default,
        int value = default,
        int alignmentDifference = default,
        SavingThrowType savingThrow = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SavingThrowBonusAgainstAlignmentDifference();
      component.Descriptor = descriptor;
      component.Value = value;
      component.AlignmentDifference = alignmentDifference;
      component.SavingThrow = savingThrow;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstAllies"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="disablingFeature"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstAllies))]
    public UnitConfigurator AddSavingThrowBonusAgainstAllies(
        ContextValue bonus,
        ModifierDescriptor modifierDescriptor = default,
        int value = default,
        bool onlyPositiveValue = default,
        string disablingFeature = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new SavingThrowBonusAgainstAllies();
      component.ModifierDescriptor = modifierDescriptor;
      component.Value = value;
      component.Bonus = bonus;
      component.OnlyPositiveValue = onlyPositiveValue;
      component.m_DisablingFeature = BlueprintTool.GetRef<BlueprintUnitFactReference>(disablingFeature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstDescriptor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="disablingFeature"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstDescriptor))]
    public UnitConfigurator AddSavingThrowBonusAgainstDescriptor(
        SpellDescriptorWrapper spellDescriptor,
        ContextValue bonus,
        ModifierDescriptor modifierDescriptor = default,
        int value = default,
        bool onlyPositiveValue = default,
        string disablingFeature = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new SavingThrowBonusAgainstDescriptor();
      component.SpellDescriptor = spellDescriptor;
      component.ModifierDescriptor = modifierDescriptor;
      component.Value = value;
      component.Bonus = bonus;
      component.OnlyPositiveValue = onlyPositiveValue;
      component.m_DisablingFeature = BlueprintTool.GetRef<BlueprintUnitFactReference>(disablingFeature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstFact))]
    public UnitConfigurator AddSavingThrowBonusAgainstFact(
        string checkedFact = null,
        ModifierDescriptor descriptor = default,
        int value = default,
        AlignmentComponent alignment = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SavingThrowBonusAgainstFact();
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintFeatureReference>(checkedFact);
      component.Descriptor = descriptor;
      component.Value = value;
      component.Alignment = alignment;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstFactMultiple"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstFactMultiple))]
    public UnitConfigurator AddSavingThrowBonusAgainstFactMultiple(
        string[] facts = null,
        ModifierDescriptor descriptor = default,
        int value = default,
        AlignmentComponent alignment = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SavingThrowBonusAgainstFactMultiple();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.Descriptor = descriptor;
      component.Value = value;
      component.Alignment = alignment;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstSchool"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstSchool))]
    public UnitConfigurator AddSavingThrowBonusAgainstSchool(
        SpellSchool school = default,
        ModifierDescriptor modifierDescriptor = default,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SavingThrowBonusAgainstSchool();
      component.School = school;
      component.ModifierDescriptor = modifierDescriptor;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstSchoolAbilityValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstSchoolAbilityValue))]
    public UnitConfigurator AddSavingThrowBonusAgainstSchoolAbilityValue(
        ContextValue bonus,
        SpellSchool school = default,
        ModifierDescriptor modifierDescriptor = default,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new SavingThrowBonusAgainstSchoolAbilityValue();
      component.School = school;
      component.ModifierDescriptor = modifierDescriptor;
      component.Value = value;
      component.Bonus = bonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstSpecificSpells"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spells"><see cref="BlueprintAbility"/></param>
    /// <param name="bypassFeatures"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstSpecificSpells))]
    public UnitConfigurator AddSavingThrowBonusAgainstSpecificSpells(
        string[] spells = null,
        ModifierDescriptor modifierDescriptor = default,
        int value = default,
        string[] bypassFeatures = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SavingThrowBonusAgainstSpecificSpells();
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.ModifierDescriptor = modifierDescriptor;
      component.Value = value;
      component.m_BypassFeatures = bypassFeatures.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusAgainstSpellType"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavingThrowBonusAgainstSpellType))]
    public UnitConfigurator AddSavingThrowBonusAgainstSpellType(
        ContextValue bonus,
        bool againstArcaneSpells = default,
        ModifierDescriptor modifierDescriptor = default,
        int value = default,
        bool onlyPositiveValue = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new SavingThrowBonusAgainstSpellType();
      component.AgainstArcaneSpells = againstArcaneSpells;
      component.ModifierDescriptor = modifierDescriptor;
      component.Value = value;
      component.Bonus = bonus;
      component.OnlyPositiveValue = onlyPositiveValue;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowBonusUnlessFactMultiple"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="facts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SavingThrowBonusUnlessFactMultiple))]
    public UnitConfigurator AddSavingThrowBonusUnlessFactMultiple(
        string[] facts = null,
        ModifierDescriptor descriptor = default,
        AlignmentComponent alignment = default,
        SavingThrowType type = default,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SavingThrowBonusUnlessFactMultiple();
      component.m_Facts = facts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.Descriptor = descriptor;
      component.Alignment = alignment;
      component.Type = type;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavingThrowContextBonusAgainstDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavingThrowContextBonusAgainstDescriptor))]
    public UnitConfigurator AddSavingThrowContextBonusAgainstDescriptor(
        SpellDescriptorWrapper spellDescriptor,
        ContextValue value,
        ModifierDescriptor modifierDescriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new SavingThrowContextBonusAgainstDescriptor();
      component.SpellDescriptor = spellDescriptor;
      component.ModifierDescriptor = modifierDescriptor;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SchoolMasteryParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SchoolMasteryParametrized))]
    public UnitConfigurator AddSchoolMasteryParametrized(
        BlueprintComponent.Flags flags = default)
    {
      var component = new SchoolMasteryParametrized();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShakeItOff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="shakeItOffFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ShakeItOff))]
    public UnitConfigurator AddShakeItOff(
        string shakeItOffFact = null,
        int radius = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ShakeItOff();
      component.m_ShakeItOffFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(shakeItOffFact);
      component.Radius = radius;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShareBuffsWithPet"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buffs"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(ShareBuffsWithPet))]
    public UnitConfigurator AddShareBuffsWithPet(
        PetType type = default,
        string[] buffs = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ShareBuffsWithPet();
      component.Type = type;
      component.m_Buffs = buffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShareFavoredEnemies"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ShareFavoredEnemies))]
    public UnitConfigurator AddShareFavoredEnemies(
        bool half = default,
        bool toPet = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ShareFavoredEnemies();
      component.Half = half;
      component.ToPet = toPet;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShareFeaturesWithPet"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="features"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(ShareFeaturesWithPet))]
    public UnitConfigurator AddShareFeaturesWithPet(
        PetType type = default,
        string[] features = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ShareFeaturesWithPet();
      component.Type = type;
      component.m_Features = features.Select(name => BlueprintTool.GetRef<BlueprintFeatureReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShatterConfidence"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="confoundingDuelistFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(ShatterConfidence))]
    public UnitConfigurator AddShatterConfidence(
        string confoundingDuelistFeature = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ShatterConfidence();
      component.m_ConfoundingDuelistFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(confoundingDuelistFeature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShieldWall"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="shieldWallFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ShieldWall))]
    public UnitConfigurator AddShieldWall(
        string shieldWallFact = null,
        int radius = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ShieldWall();
      component.m_ShieldWallFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(shieldWallFact);
      component.Radius = radius;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShieldedCaster"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="shieldedCasterFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(ShieldedCaster))]
    public UnitConfigurator AddShieldedCaster(
        string shieldedCasterFact = null,
        int radius = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ShieldedCaster();
      component.m_ShieldedCasterFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(shieldedCasterFact);
      component.Radius = radius;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SiezeTheMoment"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="siezeTheMomentFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SiezeTheMoment))]
    public UnitConfigurator AddSiezeTheMoment(
        string siezeTheMomentFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SiezeTheMoment();
      component.m_SiezeTheMomentFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(siezeTheMomentFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpecificSpellDamageBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spell"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(SpecificSpellDamageBonus))]
    public UnitConfigurator AddSpecificSpellDamageBonus(
        string[] spell = null,
        int bonus = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SpecificSpellDamageBonus();
      component.m_Spell = spell.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.Bonus = bonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellFixedCL"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(SpellFixedCL))]
    public UnitConfigurator AddSpellFixedCL(
        string ability = null,
        int cL = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SpellFixedCL();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      component.CL = cL;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellFixedDC"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(SpellFixedDC))]
    public UnitConfigurator AddSpellFixedDC(
        string ability = null,
        int dC = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SpellFixedDC();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      component.DC = dC;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellFocusParametrized"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="mythicFocus"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SpellFocusParametrized))]
    public UnitConfigurator AddSpellFocusParametrized(
        int bonusDC = default,
        ModifierDescriptor descriptor = default,
        string mythicFocus = null,
        bool spellsOnly = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SpellFocusParametrized();
      component.BonusDC = bonusDC;
      component.Descriptor = descriptor;
      component.m_MythicFocus = BlueprintTool.GetRef<BlueprintUnitFactReference>(mythicFocus);
      component.SpellsOnly = spellsOnly;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellLevelByClassLevel"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="BlueprintAbility"/></param>
    /// <param name="clazz"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(SpellLevelByClassLevel))]
    public UnitConfigurator AddSpellLevelByClassLevel(
        string ability = null,
        string clazz = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SpellLevelByClassLevel();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellLevelByRank"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="ability"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(SpellLevelByRank))]
    public UnitConfigurator AddSpellLevelByRank(
        string ability = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SpellLevelByRank();
      component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(ability);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellPenetrationBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="requiredFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SpellPenetrationBonus))]
    public UnitConfigurator AddSpellPenetrationBonus(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        bool checkFact = default,
        string requiredFact = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new SpellPenetrationBonus();
      component.Value = value;
      component.Descriptor = descriptor;
      component.CheckFact = checkFact;
      component.m_RequiredFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(requiredFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellPenetrationMythicBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="greater"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SpellPenetrationMythicBonus))]
    public UnitConfigurator AddSpellPenetrationMythicBonus(
        string greater = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SpellPenetrationMythicBonus();
      component.m_Greater = BlueprintTool.GetRef<BlueprintUnitFactReference>(greater);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellSpecializationParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpellSpecializationParametrized))]
    public UnitConfigurator AddSpellSpecializationParametrized(
        BlueprintComponent.Flags flags = default)
    {
      var component = new SpellSpecializationParametrized();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpendChargesOnSpellCast"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spell"><see cref="BlueprintAbility"/></param>
    /// <param name="spendSpellCharges"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(SpendChargesOnSpellCast))]
    public UnitConfigurator AddSpendChargesOnSpellCast(
        string spell = null,
        string spendSpellCharges = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SpendChargesOnSpellCast();
      component.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(spell);
      component.m_SpendSpellCharges = BlueprintTool.GetRef<BlueprintAbilityReference>(spendSpellCharges);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SurpriseSpells"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SurpriseSpells))]
    public UnitConfigurator AddSurpriseSpells(
        BlueprintComponent.Flags flags = default)
    {
      var component = new SurpriseSpells();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Take10ForSuccess"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(Take10ForSuccess))]
    public UnitConfigurator AddTake10ForSuccess(
        StatType skill = default,
        bool anyType = default,
        UsableItemType magicDeviceType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new Take10ForSuccess();
      component.Skill = skill;
      component.AnyType = anyType;
      component.MagicDeviceType = magicDeviceType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TargetChangedDuringRound"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TargetChangedDuringRound))]
    public UnitConfigurator AddTargetChangedDuringRound(
        ActionsBuilder actions = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TargetChangedDuringRound();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TargetCritAutoconfirm"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TargetCritAutoconfirm))]
    public UnitConfigurator AddTargetCritAutoconfirm(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TargetCritAutoconfirm();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TargetCritAutoconfirmFromCaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TargetCritAutoconfirmFromCaster))]
    public UnitConfigurator AddTargetCritAutoconfirmFromCaster(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TargetCritAutoconfirmFromCaster();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TellingBlow"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    /// <param name="immunityFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(TellingBlow))]
    public UnitConfigurator AddTellingBlow(
        int reductionReduction = default,
        string buff = null,
        string immunityFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TellingBlow();
      component.ReductionReduction = reductionReduction;
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.m_ImmunityFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(immunityFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ToughnessLogic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ToughnessLogic))]
    public UnitConfigurator AddToughnessLogic(
        bool checkMythicLevel = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ToughnessLogic();
      component.CheckMythicLevel = checkMythicLevel;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TransferDescriptorBonusToSavingThrow"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TransferDescriptorBonusToSavingThrow))]
    public UnitConfigurator AddTransferDescriptorBonusToSavingThrow(
        ModifierDescriptor descriptor = default,
        int maxBonus = default,
        bool checkArmorCategory = default,
        ArmorProficiencyGroup category = default,
        SavingThrowType type = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TransferDescriptorBonusToSavingThrow();
      component.Descriptor = descriptor;
      component.MaxBonus = maxBonus;
      component.CheckArmorCategory = checkArmorCategory;
      component.Category = category;
      component.Type = type;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TransferDescriptorBonusToTouchAC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TransferDescriptorBonusToTouchAC))]
    public UnitConfigurator AddTransferDescriptorBonusToTouchAC(
        ModifierDescriptor descriptor = default,
        int maxBonus = default,
        bool checkArmorCategory = default,
        ArmorProficiencyGroup category = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TransferDescriptorBonusToTouchAC();
      component.Descriptor = descriptor;
      component.MaxBonus = maxBonus;
      component.CheckArmorCategory = checkArmorCategory;
      component.Category = category;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TrapPerceptionBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TrapPerceptionBonus))]
    public UnitConfigurator AddTrapPerceptionBonus(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new TrapPerceptionBonus();
      component.Descriptor = descriptor;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TricksterArcanaAdditionalEnchantments"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="commonEnchantments"><see cref="BlueprintItemEnchantment"/></param>
    /// <param name="weaponEnchantments"><see cref="BlueprintWeaponEnchantment"/></param>
    /// <param name="armorEnchantments"><see cref="BlueprintArmorEnchantment"/></param>
    [Generated]
    [Implements(typeof(TricksterArcanaAdditionalEnchantments))]
    public UnitConfigurator AddTricksterArcanaAdditionalEnchantments(
        string[] commonEnchantments = null,
        string[] weaponEnchantments = null,
        string[] armorEnchantments = null,
        bool onlyWeaponsShieldsAndArmor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TricksterArcanaAdditionalEnchantments();
      component.CommonEnchantments = commonEnchantments.Select(name => BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(name)).ToArray();
      component.WeaponEnchantments = weaponEnchantments.Select(name => BlueprintTool.GetRef<BlueprintWeaponEnchantmentReference>(name)).ToArray();
      component.ArmorEnchantments = armorEnchantments.Select(name => BlueprintTool.GetRef<BlueprintArmorEnchantmentReference>(name)).ToArray();
      component.OnlyWeaponsShieldsAndArmor = onlyWeaponsShieldsAndArmor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TricksterArcanaBetterEnhancements"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="enhancementEnchantments"><see cref="BlueprintItemEnchantment"/></param>
    /// <param name="bestEnchantments"><see cref="BlueprintItemEnchantment"/></param>
    [Generated]
    [Implements(typeof(TricksterArcanaBetterEnhancements))]
    public UnitConfigurator AddTricksterArcanaBetterEnhancements(
        string[] enhancementEnchantments = null,
        string[] bestEnchantments = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TricksterArcanaBetterEnhancements();
      component.EnhancementEnchantments = enhancementEnchantments.Select(name => BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(name)).ToArray();
      component.BestEnchantments = bestEnchantments.Select(name => BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(name)).ToList();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TricksterKnowledgeWorldD20"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TricksterKnowledgeWorldD20))]
    public UnitConfigurator AddTricksterKnowledgeWorldD20(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TricksterKnowledgeWorldD20();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TricksterKnowledgeWorldSkillBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TricksterKnowledgeWorldSkillBonus))]
    public UnitConfigurator AddTricksterKnowledgeWorldSkillBonus(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TricksterKnowledgeWorldSkillBonus();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TricksterLoreNatureRestTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="tier1Buffs"><see cref="BlueprintBuff"/></param>
    /// <param name="tier2Buffs"><see cref="BlueprintBuff"/></param>
    /// <param name="tier3Buffs"><see cref="BlueprintBuff"/></param>
    /// <param name="tier2Feature"><see cref="BlueprintFeature"/></param>
    /// <param name="tier3Feature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(TricksterLoreNatureRestTrigger))]
    public UnitConfigurator AddTricksterLoreNatureRestTrigger(
        string[] tier1Buffs = null,
        string[] tier2Buffs = null,
        string[] tier3Buffs = null,
        string tier2Feature = null,
        string tier3Feature = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TricksterLoreNatureRestTrigger();
      component.Tier1Buffs = tier1Buffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray();
      component.Tier2Buffs = tier2Buffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray();
      component.Tier3Buffs = tier3Buffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray();
      component.m_Tier2Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(tier2Feature);
      component.m_Tier3Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(tier3Feature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TwoWeaponDefense"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TwoWeaponDefense))]
    public UnitConfigurator AddTwoWeaponDefense(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TwoWeaponDefense();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TwoWeaponFightingAttackPenalty"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="mythicBlueprint"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(TwoWeaponFightingAttackPenalty))]
    public UnitConfigurator AddTwoWeaponFightingAttackPenalty(
        string mythicBlueprint = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TwoWeaponFightingAttackPenalty();
      component.m_MythicBlueprint = BlueprintTool.GetRef<BlueprintFeatureReference>(mythicBlueprint);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TwoWeaponFightingAttacks"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TwoWeaponFightingAttacks))]
    public UnitConfigurator AddTwoWeaponFightingAttacks(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TwoWeaponFightingAttacks();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TwoWeaponFightingDamagePenalty"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TwoWeaponFightingDamagePenalty))]
    public UnitConfigurator AddTwoWeaponFightingDamagePenalty(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TwoWeaponFightingDamagePenalty();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UndeadHealth"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UndeadHealth))]
    public UnitConfigurator AddUndeadHealth(
        BlueprintComponent.Flags flags = default)
    {
      var component = new UndeadHealth();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UnitDeathTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitDeathTrigger))]
    public UnitConfigurator AddUnitDeathTrigger(
        ContextValue radiusInMeters,
        UnitDeathTrigger.FactionType faction = default,
        ActionsBuilder actions = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(radiusInMeters);
    
      var component = new UnitDeathTrigger();
      component.RadiusInMeters = radiusInMeters;
      component.Faction = faction;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UnwillingShield"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="masterAbility"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(UnwillingShield))]
    public UnitConfigurator AddUnwillingShield(
        string masterAbility = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new UnwillingShield();
      component.m_MasterAbility = BlueprintTool.GetRef<BlueprintAbilityReference>(masterAbility);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UnwillingShieldTarget"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="masterAbility"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(UnwillingShieldTarget))]
    public UnitConfigurator AddUnwillingShieldTarget(
        string masterAbility = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new UnwillingShieldTarget();
      component.m_MasterAbility = BlueprintTool.GetRef<BlueprintAbilityReference>(masterAbility);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="VolleyFireAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(VolleyFireAttackBonus))]
    public UnitConfigurator AddVolleyFireAttackBonus(
        BlueprintComponent.Flags flags = default)
    {
      var component = new VolleyFireAttackBonus();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponCategoryAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponCategoryAttackBonus))]
    public UnitConfigurator AddWeaponCategoryAttackBonus(
        WeaponCategory category = default,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponCategoryAttackBonus();
      component.Category = category;
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponFocus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(WeaponFocus))]
    public UnitConfigurator AddWeaponFocus(
        string weaponType = null,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponFocus();
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponFocusParametrized"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="mythicFocus"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(WeaponFocusParametrized))]
    public UnitConfigurator AddWeaponFocusParametrized(
        string mythicFocus = null,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponFocusParametrized();
      component.m_MythicFocus = BlueprintTool.GetRef<BlueprintUnitFactReference>(mythicFocus);
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponGroupAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponGroupAttackBonus))]
    public UnitConfigurator AddWeaponGroupAttackBonus(
        ContextValue contextMultiplier,
        WeaponFighterGroup weaponGroup = default,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        bool multiplyByContext = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(contextMultiplier);
    
      var component = new WeaponGroupAttackBonus();
      component.WeaponGroup = weaponGroup;
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.multiplyByContext = multiplyByContext;
      component.contextMultiplier = contextMultiplier;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponGroupDamageBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponGroupDamageBonus))]
    public UnitConfigurator AddWeaponGroupDamageBonus(
        ContextValue additionalValue,
        WeaponFighterGroup weaponGroup = default,
        int damageBonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(additionalValue);
    
      var component = new WeaponGroupDamageBonus();
      component.WeaponGroup = weaponGroup;
      component.DamageBonus = damageBonus;
      component.AdditionalValue = additionalValue;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponGroupEnchant"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponGroupEnchant))]
    public UnitConfigurator AddWeaponGroupEnchant(
        WeaponFighterGroup weaponGroup = default,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponGroupEnchant();
      component.WeaponGroup = weaponGroup;
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponMasteryParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponMasteryParametrized))]
    public UnitConfigurator AddWeaponMasteryParametrized(
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponMasteryParametrized();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponMultipleCategoriesAttackBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponMultipleCategoriesAttackBonus))]
    public UnitConfigurator AddWeaponMultipleCategoriesAttackBonus(
        WeaponCategory[] categories = null,
        int attackBonus = default,
        bool exceptForCategories = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponMultipleCategoriesAttackBonus();
      component.Categories = categories;
      component.AttackBonus = attackBonus;
      component.ExceptForCategories = exceptForCategories;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponParametersAttackBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="fightersFinesse"><see cref="BlueprintFeature"/></param>
    /// <param name="multiplierFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(WeaponParametersAttackBonus))]
    public UnitConfigurator AddWeaponParametersAttackBonus(
        bool onlyFinessable = default,
        bool canBeUsedWithFightersFinesse = default,
        string fightersFinesse = null,
        bool ranged = default,
        bool onlyTwoHanded = default,
        int attackBonus = default,
        ModifierDescriptor descriptor = default,
        bool scaleByBasicAttackBonus = default,
        bool onlyForFullAttack = default,
        string multiplierFact = null,
        int multiplier = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponParametersAttackBonus();
      component.OnlyFinessable = onlyFinessable;
      component.CanBeUsedWithFightersFinesse = canBeUsedWithFightersFinesse;
      component.m_FightersFinesse = BlueprintTool.GetRef<BlueprintFeatureReference>(fightersFinesse);
      component.Ranged = ranged;
      component.OnlyTwoHanded = onlyTwoHanded;
      component.AttackBonus = attackBonus;
      component.Descriptor = descriptor;
      component.ScaleByBasicAttackBonus = scaleByBasicAttackBonus;
      component.OnlyForFullAttack = onlyForFullAttack;
      component.m_MultiplierFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(multiplierFact);
      component.Multiplier = multiplier;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponParametersCriticalEdgeIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponParametersCriticalEdgeIncrease))]
    public UnitConfigurator AddWeaponParametersCriticalEdgeIncrease(
        bool light = default,
        bool ranged = default,
        bool twoHanded = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponParametersCriticalEdgeIncrease();
      component.Light = light;
      component.Ranged = ranged;
      component.TwoHanded = twoHanded;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponParametersCriticalMultiplierIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponParametersCriticalMultiplierIncrease))]
    public UnitConfigurator AddWeaponParametersCriticalMultiplierIncrease(
        bool light = default,
        bool ranged = default,
        bool twoHanded = default,
        int additionalMultiplier = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponParametersCriticalMultiplierIncrease();
      component.Light = light;
      component.Ranged = ranged;
      component.TwoHanded = twoHanded;
      component.AdditionalMultiplier = additionalMultiplier;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponParametersDamageBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="fightersFinesse"><see cref="BlueprintFeature"/></param>
    /// <param name="greaterPowerAttackBlueprint"><see cref="BlueprintFeature"/></param>
    /// <param name="mythicBlueprint"><see cref="BlueprintFeature"/></param>
    /// <param name="weaponBlueprint"><see cref="BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(WeaponParametersDamageBonus))]
    public UnitConfigurator AddWeaponParametersDamageBonus(
        bool onlyFinessable = default,
        bool canBeUsedWithFightersFinesse = default,
        string fightersFinesse = null,
        bool ranged = default,
        bool onlyTwoHanded = default,
        int damageBonus = default,
        bool scaleByBasicAttackBonus = default,
        bool powerAttackScaling = default,
        bool dualWielding = default,
        bool onlyToOffHandBonus = default,
        bool onlySpecificItemBlueprint = default,
        string greaterPowerAttackBlueprint = null,
        string mythicBlueprint = null,
        string weaponBlueprint = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponParametersDamageBonus();
      component.OnlyFinessable = onlyFinessable;
      component.CanBeUsedWithFightersFinesse = canBeUsedWithFightersFinesse;
      component.m_FightersFinesse = BlueprintTool.GetRef<BlueprintFeatureReference>(fightersFinesse);
      component.Ranged = ranged;
      component.OnlyTwoHanded = onlyTwoHanded;
      component.DamageBonus = damageBonus;
      component.ScaleByBasicAttackBonus = scaleByBasicAttackBonus;
      component.PowerAttackScaling = powerAttackScaling;
      component.DualWielding = dualWielding;
      component.OnlyToOffHandBonus = onlyToOffHandBonus;
      component.OnlySpecificItemBlueprint = onlySpecificItemBlueprint;
      component.m_GreaterPowerAttackBlueprint = BlueprintTool.GetRef<BlueprintFeatureReference>(greaterPowerAttackBlueprint);
      component.m_MythicBlueprint = BlueprintTool.GetRef<BlueprintFeatureReference>(mythicBlueprint);
      component.m_WeaponBlueprint = BlueprintTool.GetRef<BlueprintItemWeaponReference>(weaponBlueprint);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponSizeChange"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponSizeChange))]
    public UnitConfigurator AddWeaponSizeChange(
        int sizeCategoryChange = default,
        bool checkWeaponCategory = default,
        WeaponCategory category = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponSizeChange();
      component.SizeCategoryChange = sizeCategoryChange;
      component.CheckWeaponCategory = checkWeaponCategory;
      component.Category = category;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponSpecializationParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponSpecializationParametrized))]
    public UnitConfigurator AddWeaponSpecializationParametrized(
        bool mythic = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponSpecializationParametrized();
      component.Mythic = mythic;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTypeCriticalEdgeIncrease"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(WeaponTypeCriticalEdgeIncrease))]
    public UnitConfigurator AddWeaponTypeCriticalEdgeIncrease(
        string weaponType = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponTypeCriticalEdgeIncrease();
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTypeCriticalEdgeIncreaseStackable"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponTypeCriticalEdgeIncreaseStackable))]
    public UnitConfigurator AddWeaponTypeCriticalEdgeIncreaseStackable(
        bool anyCategory = default,
        WeaponCategory category = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponTypeCriticalEdgeIncreaseStackable();
      component.AnyCategory = anyCategory;
      component.Category = category;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTypeCriticalMultiplierIncrease"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(WeaponTypeCriticalMultiplierIncrease))]
    public UnitConfigurator AddWeaponTypeCriticalMultiplierIncrease(
        string weaponType = null,
        int additionalMultiplier = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponTypeCriticalMultiplierIncrease();
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      component.AdditionalMultiplier = additionalMultiplier;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTypeDamageBonus"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(WeaponTypeDamageBonus))]
    public UnitConfigurator AddWeaponTypeDamageBonus(
        string weaponType = null,
        int damageBonus = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponTypeDamageBonus();
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      component.DamageBonus = damageBonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTypeDamageStatReplacement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponTypeDamageStatReplacement))]
    public UnitConfigurator AddWeaponTypeDamageStatReplacement(
        StatType stat = default,
        WeaponCategory category = default,
        bool onlyOneHanded = default,
        bool twoHandedBonus = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponTypeDamageStatReplacement();
      component.Stat = stat;
      component.Category = category;
      component.OnlyOneHanded = onlyOneHanded;
      component.TwoHandedBonus = twoHandedBonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ImpatienceCalmingPart"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="impatience"><see cref="BlueprintBuff"/></param>
    /// <param name="targetedImpatience"><see cref="BlueprintBuff"/></param>
    /// <param name="patience"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(ImpatienceCalmingPart))]
    public UnitConfigurator AddImpatienceCalmingPart(
        string impatience = null,
        string targetedImpatience = null,
        string patience = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ImpatienceCalmingPart();
      component.m_Impatience = BlueprintTool.GetRef<BlueprintBuffReference>(impatience);
      component.m_TargetedImpatience = BlueprintTool.GetRef<BlueprintBuffReference>(targetedImpatience);
      component.m_Patience = BlueprintTool.GetRef<BlueprintBuffReference>(patience);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ImpatienceWatcherTickingResolve"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="impatience"><see cref="BlueprintBuff"/></param>
    /// <param name="targetedImpatience"><see cref="BlueprintBuff"/></param>
    /// <param name="patience"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(ImpatienceWatcherTickingResolve))]
    public UnitConfigurator AddImpatienceWatcherTickingResolve(
        string impatience = null,
        string targetedImpatience = null,
        string patience = null,
        int[] resolveChances = null,
        int[] resolveChancesForLowInt = null,
        int[] resolveChancesForHighInt = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ImpatienceWatcherTickingResolve();
      component.m_Impatience = BlueprintTool.GetRef<BlueprintBuffReference>(impatience);
      component.m_TargetedImpatience = BlueprintTool.GetRef<BlueprintBuffReference>(targetedImpatience);
      component.m_Patience = BlueprintTool.GetRef<BlueprintBuffReference>(patience);
      component.ResolveChances = resolveChances;
      component.ResolveChancesForLowInt = resolveChancesForLowInt;
      component.ResolveChancesForHighInt = resolveChancesForHighInt;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstCaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstCaster))]
    public UnitConfigurator AddACBonusAgainstCaster(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new ACBonusAgainstCaster();
      component.Value = value;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ACBonusAgainstTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ACBonusAgainstTarget))]
    public UnitConfigurator AddACBonusAgainstTarget(
        ContextValue value,
        bool checkCaster = default,
        bool checkCasterFriend = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new ACBonusAgainstTarget();
      component.Value = value;
      component.CheckCaster = checkCaster;
      component.CheckCasterFriend = checkCasterFriend;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddAdditionalLimbIfHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weapon"><see cref="BlueprintItemWeapon"/></param>
    /// <param name="checkedFact"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(AddAdditionalLimbIfHasFact))]
    public UnitConfigurator AddAdditionalLimbIfHasFact(
        string weapon = null,
        string checkedFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddAdditionalLimbIfHasFact();
      component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(weapon);
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintFeatureReference>(checkedFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusAbilityValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddStatBonusAbilityValue))]
    public UnitConfigurator AddStatBonusAbilityValue(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new AddStatBonusAbilityValue();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusIfHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFacts"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddStatBonusIfHasFact))]
    public UnitConfigurator AddStatBonusIfHasFact(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        bool invertCondition = default,
        bool requireAllFacts = default,
        string[] checkedFacts = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new AddStatBonusIfHasFact();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value;
      component.InvertCondition = invertCondition;
      component.RequireAllFacts = requireAllFacts;
      component.m_CheckedFacts = checkedFacts.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusIfHasSkill"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddStatBonusIfHasSkill))]
    public UnitConfigurator AddStatBonusIfHasSkill(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int valueTrue = default,
        int valueFalse = default,
        StatType checkedSkill = default,
        int skillValue = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddStatBonusIfHasSkill();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.ValueTrue = valueTrue;
      component.ValueFalse = valueFalse;
      component.CheckedSkill = checkedSkill;
      component.SkillValue = skillValue;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddStatBonusScaled"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddStatBonusScaled))]
    public UnitConfigurator AddStatBonusScaled(
        BuffScaling scaling,
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(scaling);
    
      var component = new AddStatBonusScaled();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value;
      component.Scaling = scaling;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="Afterbuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="afterBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(Afterbuff))]
    public UnitConfigurator AddAfterbuff(
        string afterBuff = null,
        int durationMultiplier = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new Afterbuff();
      component.m_AfterBuff = BlueprintTool.GetRef<BlueprintBuffReference>(afterBuff);
      component.DurationMultiplier = durationMultiplier;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AfterbuffIfHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="featureToCheck"><see cref="BlueprintFeature"/></param>
    /// <param name="afterBuffFalse"><see cref="BlueprintBuff"/></param>
    /// <param name="afterBuffTrue"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AfterbuffIfHasFact))]
    public UnitConfigurator AddAfterbuffIfHasFact(
        string featureToCheck = null,
        string afterBuffFalse = null,
        string afterBuffTrue = null,
        int durationMultiplier = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AfterbuffIfHasFact();
      component.m_FeatureToCheck = BlueprintTool.GetRef<BlueprintFeatureReference>(featureToCheck);
      component.m_AfterBuffFalse = BlueprintTool.GetRef<BlueprintBuffReference>(afterBuffFalse);
      component.m_AfterBuffTrue = BlueprintTool.GetRef<BlueprintBuffReference>(afterBuffTrue);
      component.DurationMultiplier = durationMultiplier;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ApplyBuffOnHit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(ApplyBuffOnHit))]
    public UnitConfigurator AddApplyBuffOnHit(
        Rounds time,
        string buff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ApplyBuffOnHit();
      component.m_buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.time = time;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmagsBladeEnrage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmagsBladeEnrage))]
    public UnitConfigurator AddArmagsBladeEnrage(
        BlueprintComponent.Flags flags = default)
    {
      var component = new ArmagsBladeEnrage();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmorFocus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmorFocus))]
    public UnitConfigurator AddArmorFocus(
        ArmorProficiencyGroup armorCategory = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ArmorFocus();
      component.ArmorCategory = armorCategory;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstCaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusAgainstCaster))]
    public UnitConfigurator AddAttackBonusAgainstCaster(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new AttackBonusAgainstCaster();
      component.Value = value;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AttackBonusAgainstTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AttackBonusAgainstTarget))]
    public UnitConfigurator AddAttackBonusAgainstTarget(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        bool checkCaster = default,
        bool checkCasterFriend = default,
        bool checkRangeType = default,
        WeaponRangeType rangeType = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new AttackBonusAgainstTarget();
      component.Value = value;
      component.Descriptor = descriptor;
      component.CheckCaster = checkCaster;
      component.CheckCasterFriend = checkCasterFriend;
      component.CheckRangeType = checkRangeType;
      component.RangeType = rangeType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffAbilityRollsBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffAbilityRollsBonus))]
    public UnitConfigurator AddBuffAbilityRollsBonus(
        ContextValue multiplier,
        int value = default,
        ModifierDescriptor descriptor = default,
        bool affectAllStats = default,
        bool onlyHighesStats = default,
        StatType stat = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(multiplier);
    
      var component = new BuffAbilityRollsBonus();
      component.Value = value;
      component.Descriptor = descriptor;
      component.AffectAllStats = affectAllStats;
      component.OnlyHighesStats = onlyHighesStats;
      component.Multiplier = multiplier;
      component.Stat = stat;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffAllSavesBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffAllSavesBonus))]
    public UnitConfigurator AddBuffAllSavesBonus(
        ModifierDescriptor descriptor = default,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffAllSavesBonus();
      component.Descriptor = descriptor;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffAllSkillsBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffAllSkillsBonus))]
    public UnitConfigurator AddBuffAllSkillsBonus(
        ContextValue multiplier,
        ModifierDescriptor descriptor = default,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(multiplier);
    
      var component = new BuffAllSkillsBonus();
      component.Descriptor = descriptor;
      component.Value = value;
      component.Multiplier = multiplier;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffAllSkillsBonusAbilityValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffAllSkillsBonusAbilityValue))]
    public UnitConfigurator AddBuffAllSkillsBonusAbilityValue(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new BuffAllSkillsBonusAbilityValue();
      component.Descriptor = descriptor;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffAllSkillsBonusRankDependent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffAllSkillsBonusRankDependent))]
    public UnitConfigurator AddBuffAllSkillsBonusRankDependent(
        ModifierDescriptor descriptor = default,
        int value = default,
        int minimalRank = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffAllSkillsBonusRankDependent();
      component.Descriptor = descriptor;
      component.Value = value;
      component.MinimalRank = minimalRank;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffDamageEachRound"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffDamageEachRound))]
    public UnitConfigurator AddBuffDamageEachRound(
        DiceFormula energyDamageDice,
        int baseRounds = default,
        float additionalRoundsPerCasterLevel = default,
        DamageEnergyType element = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffDamageEachRound();
      component.baseRounds = baseRounds;
      component.AdditionalRoundsPerCasterLevel = additionalRoundsPerCasterLevel;
      component.EnergyDamageDice = energyDamageDice;
      component.Element = element;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffExtraAttack"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffExtraAttack))]
    public UnitConfigurator AddBuffExtraAttack(
        int number = default,
        bool haste = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffExtraAttack();
      component.Number = number;
      component.Haste = haste;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffExtraAttackWeaponSpecific"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffExtraAttackWeaponSpecific))]
    public UnitConfigurator AddBuffExtraAttackWeaponSpecific(
        WeaponRangeType rangeType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffExtraAttackWeaponSpecific();
      component.RangeType = rangeType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffIncomingDamageIncrease"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffIncomingDamageIncrease))]
    public UnitConfigurator AddBuffIncomingDamageIncrease(
        ContextValue value,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new BuffIncomingDamageIncrease();
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffInvisibility"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffInvisibility))]
    public UnitConfigurator AddBuffInvisibility(
        ContextValue chance,
        bool notDispellAfterOffensiveAction = default,
        int stealthBonus = default,
        bool dispelWithAChance = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(chance);
    
      var component = new BuffInvisibility();
      component.NotDispellAfterOffensiveAction = notDispellAfterOffensiveAction;
      component.m_StealthBonus = stealthBonus;
      component.DispelWithAChance = dispelWithAChance;
      component.Chance = chance;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffMiraculousHealing"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffMiraculousHealing))]
    public UnitConfigurator AddBuffMiraculousHealing(
        float empowerMiraculousModifier = default,
        float savedModifier = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffMiraculousHealing();
      component.EmpowerMiraculousModifier = empowerMiraculousModifier;
      component.m_SavedModifier = savedModifier;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffMovementSpeed"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffMovementSpeed))]
    public UnitConfigurator AddBuffMovementSpeed(
        ContextValue contextBonus,
        ModifierDescriptor descriptor = default,
        int value = default,
        bool cappedOnMultiplier = default,
        float multiplierCap = default,
        bool cappedMinimum = default,
        int minimumCap = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(contextBonus);
    
      var component = new BuffMovementSpeed();
      component.Descriptor = descriptor;
      component.Value = value;
      component.ContextBonus = contextBonus;
      component.CappedOnMultiplier = cappedOnMultiplier;
      component.MultiplierCap = multiplierCap;
      component.CappedMinimum = cappedMinimum;
      component.MinimumCap = minimumCap;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffOnArmor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(BuffOnArmor))]
    public UnitConfigurator AddBuffOnArmor(
        string buff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffOnArmor();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffOnHealthTickingTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="triggeredBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(BuffOnHealthTickingTrigger))]
    public UnitConfigurator AddBuffOnHealthTickingTrigger(
        string triggeredBuff = null,
        float healthPercent = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffOnHealthTickingTrigger();
      component.m_TriggeredBuff = BlueprintTool.GetRef<BlueprintBuffReference>(triggeredBuff);
      component.HealthPercent = healthPercent;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffOnLightOrNoArmor"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(BuffOnLightOrNoArmor))]
    public UnitConfigurator AddBuffOnLightOrNoArmor(
        string buff = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffOnLightOrNoArmor();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffParticleEffectPlay"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffParticleEffectPlay))]
    public UnitConfigurator AddBuffParticleEffectPlay(
        bool playOnActivate = default,
        PrefabLink activateFx = null,
        bool playOnDeactivate = default,
        PrefabLink deactivateFx = null,
        bool playEachRound = default,
        PrefabLink eachRoundFx = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(activateFx);
      ValidateParam(deactivateFx);
      ValidateParam(eachRoundFx);
    
      var component = new BuffParticleEffectPlay();
      component.PlayOnActivate = playOnActivate;
      component.ActivateFx = activateFx ?? Constants.Empty.PrefabLink;
      component.PlayOnDeactivate = playOnDeactivate;
      component.DeactivateFx = deactivateFx ?? Constants.Empty.PrefabLink;
      component.PlayEachRound = playEachRound;
      component.EachRoundFx = eachRoundFx ?? Constants.Empty.PrefabLink;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffPerceptionBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffPerceptionBonus))]
    public UnitConfigurator AddBuffPerceptionBonus(
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffPerceptionBonus();
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffPoisonStatDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffPoisonStatDamage))]
    public UnitConfigurator AddBuffPoisonStatDamage(
        DiceFormula value,
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int bonus = default,
        int ticks = default,
        int succesfullSaves = default,
        SavingThrowType saveType = default,
        bool noEffectOnFirstTick = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffPoisonStatDamage();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value;
      component.Bonus = bonus;
      component.Ticks = ticks;
      component.SuccesfullSaves = succesfullSaves;
      component.SaveType = saveType;
      component.NoEffectOnFirstTick = noEffectOnFirstTick;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffPoisonStatDamageContext"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffPoisonStatDamageContext))]
    public UnitConfigurator AddBuffPoisonStatDamageContext(
        ContextDiceValue value,
        ContextValue bonus,
        ContextValue ticks,
        ContextValue succesfullSaves,
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        SavingThrowType saveType = default,
        bool noEffectOnFirstTick = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
      ValidateParam(bonus);
      ValidateParam(ticks);
      ValidateParam(succesfullSaves);
    
      var component = new BuffPoisonStatDamageContext();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value;
      component.Bonus = bonus;
      component.Ticks = ticks;
      component.SuccesfullSaves = succesfullSaves;
      component.SaveType = saveType;
      component.NoEffectOnFirstTick = noEffectOnFirstTick;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffSaveEachRound"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffSaveEachRound))]
    public UnitConfigurator AddBuffSaveEachRound(
        SavingThrowType saveType = default,
        int saveDC = default,
        int increaseDC = default,
        ActionsBuilder actionsOnPass = null,
        ActionsBuilder actionsOnFail = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffSaveEachRound();
      component.SaveType = saveType;
      component.SaveDC = saveDC;
      component.IncreaseDC = increaseDC;
      component.ActionsOnPass = actionsOnPass?.Build() ?? Constants.Empty.Actions;
      component.ActionsOnFail = actionsOnFail?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffSaveOrDieEachRound"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffSaveOrDieEachRound))]
    public UnitConfigurator AddBuffSaveOrDieEachRound(
        GameObject effectOnDeath,
        UnitCondition condition = default,
        SavingThrowType saveType = default,
        int saveDC = default,
        int increaseDC = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(effectOnDeath);
    
      var component = new BuffSaveOrDieEachRound();
      component.Condition = condition;
      component.SaveType = saveType;
      component.SaveDC = saveDC;
      component.IncreaseDC = increaseDC;
      component.EffectOnDeath = effectOnDeath;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffSkillBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffSkillBonus))]
    public UnitConfigurator AddBuffSkillBonus(
        StatType stat = default,
        ModifierDescriptor descriptor = default,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffSkillBonus();
      component.Stat = stat;
      component.Descriptor = descriptor;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffSkillLoreNatureBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffSkillLoreNatureBonus))]
    public UnitConfigurator AddBuffSkillLoreNatureBonus(
        ModifierDescriptor descriptor = default,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffSkillLoreNatureBonus();
      component.Descriptor = descriptor;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffSkillStealthBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffSkillStealthBonus))]
    public UnitConfigurator AddBuffSkillStealthBonus(
        ModifierDescriptor descriptor = default,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffSkillStealthBonus();
      component.Descriptor = descriptor;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffStatPenaltyDice"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffStatPenaltyDice))]
    public UnitConfigurator AddBuffStatPenaltyDice(
        DiceFormula value,
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int bonus = default,
        SavingThrowType saveType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffStatPenaltyDice();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Value = value;
      component.Bonus = bonus;
      component.SaveType = saveType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffStatusCondition"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffStatusCondition))]
    public UnitConfigurator AddBuffStatusCondition(
        bool saveEachRound = default,
        UnitCondition condition = default,
        SavingThrowType saveType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffStatusCondition();
      component.SaveEachRound = saveEachRound;
      component.Condition = condition;
      component.SaveType = saveType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffStrengthSkillsBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BuffStrengthSkillsBonus))]
    public UnitConfigurator AddBuffStrengthSkillsBonus(
        BuffScaling scaling,
        ModifierDescriptor descriptor = default,
        int value = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(scaling);
    
      var component = new BuffStrengthSkillsBonus();
      component.Descriptor = descriptor;
      component.Value = value;
      component.Scaling = scaling;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BurstBarrier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BurstBarrier))]
    public UnitConfigurator AddBurstBarrier(
        BlueprintComponent.Flags flags = default)
    {
      var component = new BurstBarrier();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CannyDefensePermanent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="chosenWeaponBlueprint"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(CannyDefensePermanent))]
    public UnitConfigurator AddCannyDefensePermanent(
        string characterClass = null,
        bool requiresKensai = default,
        string chosenWeaponBlueprint = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new CannyDefensePermanent();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.RequiresKensai = requiresKensai;
      component.m_ChosenWeaponBlueprint = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(chosenWeaponBlueprint);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ChangeUnitSize"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ChangeUnitSize))]
    public UnitConfigurator AddChangeUnitSize(
        ChangeUnitSize.ChangeType type = default,
        int sizeDelta = default,
        Size size = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ChangeUnitSize();
      component.m_Type = type;
      component.SizeDelta = sizeDelta;
      component.Size = size;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusAgainstTarget"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageBonusAgainstTarget))]
    public UnitConfigurator AddDamageBonusAgainstTarget(
        ContextValue value,
        bool checkCaster = default,
        bool checkCasterFriend = default,
        bool applyToSpellDamage = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new DamageBonusAgainstTarget();
      component.Value = value;
      component.CheckCaster = checkCaster;
      component.CheckCasterFriend = checkCasterFriend;
      component.ApplyToSpellDamage = applyToSpellDamage;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageBonusConditional"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageBonusConditional))]
    public UnitConfigurator AddDamageBonusConditional(
        ContextValue bonus,
        bool checkWielder = default,
        bool onlyWeaponDamage = default,
        ModifierDescriptor descriptor = default,
        ConditionsBuilder conditions = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new DamageBonusConditional();
      component.CheckWielder = checkWielder;
      component.OnlyWeaponDamage = onlyWeaponDamage;
      component.Descriptor = descriptor;
      component.Bonus = bonus;
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageOnRemove"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageOnRemove))]
    public UnitConfigurator AddDamageOnRemove(
        DiceFormula damage,
        DamageEnergyType energyType = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DamageOnRemove();
      component.Damage = damage;
      component.EnergyType = energyType;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageOverTime"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageOverTime))]
    public UnitConfigurator AddDamageOverTime(
        DiceFormula damage,
        DamageEnergyType energyType = default,
        bool instantStartTick = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DamageOverTime();
      component.Damage = damage;
      component.EnergyType = energyType;
      component.InstantStartTick = instantStartTick;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageWithDescriptorRecievedTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageWithDescriptorRecievedTrigger))]
    public UnitConfigurator AddDamageWithDescriptorRecievedTrigger(
        SpellDescriptorWrapper descriptor,
        DamageEnergyType energyType = default,
        ActionsBuilder actions = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DamageWithDescriptorRecievedTrigger();
      component.Descriptor = descriptor;
      component.EnergyType = energyType;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DevilReflectAbility"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DevilReflectAbility))]
    public UnitConfigurator AddDevilReflectAbility(
        SpellSchool[] reflectSchools = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DevilReflectAbility();
      component.m_ReflectSchools = reflectSchools;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DifficultyStatAdvancement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DifficultyStatAdvancement))]
    public UnitConfigurator AddDifficultyStatAdvancement(
        int basicStatBonus = default,
        int derivativeStatBonus = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new DifficultyStatAdvancement();
      component.BasicStatBonus = basicStatBonus;
      component.DerivativeStatBonus = derivativeStatBonus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EchoesOfStoneTerrainBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EchoesOfStoneTerrainBonus))]
    public UnitConfigurator AddEchoesOfStoneTerrainBonus(
        AreaSetting setting = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new EchoesOfStoneTerrainBonus();
      component.Setting = setting;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EmptyHandWeaponOverride"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weapon"><see cref="BlueprintItemWeapon"/></param>
    [Generated]
    [Implements(typeof(EmptyHandWeaponOverride))]
    public UnitConfigurator AddEmptyHandWeaponOverride(
        string weapon = null,
        bool isPermanent = default,
        bool isMonkUnarmedStrike = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new EmptyHandWeaponOverride();
      component.m_Weapon = BlueprintTool.GetRef<BlueprintItemWeaponReference>(weapon);
      component.IsPermanent = isPermanent;
      component.IsMonkUnarmedStrike = isMonkUnarmedStrike;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EqualForce"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EqualForce))]
    public UnitConfigurator AddEqualForce(
        BlueprintComponent.Flags flags = default)
    {
      var component = new EqualForce();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="GreaterSnapShotBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GreaterSnapShotBonus))]
    public UnitConfigurator AddGreaterSnapShotBonus(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new GreaterSnapShotBonus();
      component.Value = value;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="HasArmorFeatureUnlock"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="newFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(HasArmorFeatureUnlock))]
    public UnitConfigurator AddHasArmorFeatureUnlock(
        string newFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new HasArmorFeatureUnlock();
      component.m_NewFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(newFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="HealOverTime"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HealOverTime))]
    public UnitConfigurator AddHealOverTime(
        int heal = default,
        bool instantStartTick = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new HealOverTime();
      component.Heal = heal;
      component.InstantStartTick = instantStartTick;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="HealOverTimeIfHasFact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedFact"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(HealOverTimeIfHasFact))]
    public UnitConfigurator AddHealOverTimeIfHasFact(
        BuffScaling scaling,
        int heal = default,
        bool instantStartTick = default,
        string checkedFact = null,
        bool scale = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(scaling);
    
      var component = new HealOverTimeIfHasFact();
      component.Heal = heal;
      component.InstantStartTick = instantStartTick;
      component.m_CheckedFact = BlueprintTool.GetRef<BlueprintFeatureReference>(checkedFact);
      component.Scale = scale;
      component.Scaling = scaling;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IgnoreTargetDR"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IgnoreTargetDR))]
    public UnitConfigurator AddIgnoreTargetDR(
        bool checkCaster = default,
        bool checkCasterFriend = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IgnoreTargetDR();
      component.CheckCaster = checkCaster;
      component.CheckCasterFriend = checkCasterFriend;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IncreaseSpellDamageByClassLevel"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spells"><see cref="BlueprintAbility"/></param>
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="additionalClasses"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="archetypes"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(IncreaseSpellDamageByClassLevel))]
    public UnitConfigurator AddIncreaseSpellDamageByClassLevel(
        string[] spells = null,
        string characterClass = null,
        string[] additionalClasses = null,
        string[] archetypes = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IncreaseSpellDamageByClassLevel();
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_AdditionalClasses = additionalClasses.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name)).ToArray();
      component.m_Archetypes = archetypes.Select(name => BlueprintTool.GetRef<BlueprintArchetypeReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IntenseSpells"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="wizard"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(IntenseSpells))]
    public UnitConfigurator AddIntenseSpells(
        string wizard = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new IntenseSpells();
      component.m_Wizard = BlueprintTool.GetRef<BlueprintCharacterClassReference>(wizard);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LiquidateTowerShieldPenalty"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LiquidateTowerShieldPenalty))]
    public UnitConfigurator AddLiquidateTowerShieldPenalty(
        BlueprintComponent.Flags flags = default)
    {
      var component = new LiquidateTowerShieldPenalty();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MakeUnitFollowUnit"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MakeUnitFollowUnit))]
    public UnitConfigurator AddMakeUnitFollowUnit(
        UnitEvaluator leader,
        bool alwaysRun = default,
        bool canBeSlowerThanLeader = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(leader);
    
      var component = new MakeUnitFollowUnit();
      component.AlwaysRun = alwaysRun;
      component.CanBeSlowerThanLeader = canBeSlowerThanLeader;
      component.Leader = leader;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ModifySpell"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(ModifySpell))]
    public UnitConfigurator AddModifySpell(
        SpellModificationType modificationType = default,
        string[] spells = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ModifySpell();
      component.ModificationType = modificationType;
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MonkNoArmorAndMonkWeaponFeatureUnlock"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="newFact"><see cref="BlueprintUnitFact"/></param>
    /// <param name="bowWeaponTypes"><see cref="BlueprintWeaponType"/></param>
    /// <param name="rapidshotBuff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(MonkNoArmorAndMonkWeaponFeatureUnlock))]
    public UnitConfigurator AddMonkNoArmorAndMonkWeaponFeatureUnlock(
        string newFact = null,
        bool isZenArcher = default,
        string[] bowWeaponTypes = null,
        string rapidshotBuff = null,
        bool isSohei = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new MonkNoArmorAndMonkWeaponFeatureUnlock();
      component.m_NewFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(newFact);
      component.IsZenArcher = isZenArcher;
      component.m_BowWeaponTypes = bowWeaponTypes.Select(name => BlueprintTool.GetRef<BlueprintWeaponTypeReference>(name)).ToArray();
      component.m_RapidshotBuff = BlueprintTool.GetRef<BlueprintBuffReference>(rapidshotBuff);
      component.IsSohei = isSohei;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MonkNoArmorFeatureUnlock"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="newFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(MonkNoArmorFeatureUnlock))]
    public UnitConfigurator AddMonkNoArmorFeatureUnlock(
        string newFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new MonkNoArmorFeatureUnlock();
      component.m_NewFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(newFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MysticTheurgeCombinedSpells"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MysticTheurgeCombinedSpells))]
    public UnitConfigurator AddMysticTheurgeCombinedSpells(
        int spellLevel = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new MysticTheurgeCombinedSpells();
      component.SpellLevel = spellLevel;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MysticTheurgeSpellbook"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="mysticTheurge"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(MysticTheurgeSpellbook))]
    public UnitConfigurator AddMysticTheurgeSpellbook(
        string characterClass = null,
        string mysticTheurge = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new MysticTheurgeSpellbook();
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_MysticTheurge = BlueprintTool.GetRef<BlueprintCharacterClassReference>(mysticTheurge);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OverrideLocoMotion"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(OverrideLocoMotion))]
    public UnitConfigurator AddOverrideLocoMotion(
        UnitAnimationActionLocoMotion locoMotion,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(locoMotion);
    
      var component = new OverrideLocoMotion();
      component.LocoMotion = locoMotion;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PowerfulCharge"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PowerfulCharge))]
    public UnitConfigurator AddPowerfulCharge(
        ContextValue value,
        bool useContextBonus = default,
        int additionalDiceRolls = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new PowerfulCharge();
      component.UseContextBonus = useContextBonus;
      component.Value = value;
      component.AdditionalDiceRolls = additionalDiceRolls;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ProtectionFromEnergy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ProtectionFromEnergy))]
    public UnitConfigurator AddProtectionFromEnergy(
        ContextValue valueMultiplier,
        ContextValue value,
        ContextValue pool,
        DamageEnergyType type = default,
        bool useValueMultiplier = default,
        bool usePool = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(valueMultiplier);
      ValidateParam(value);
      ValidateParam(pool);
    
      var component = new ProtectionFromEnergy();
      component.Type = type;
      component.UseValueMultiplier = useValueMultiplier;
      component.ValueMultiplier = valueMultiplier;
      component.Value = value;
      component.UsePool = usePool;
      component.Pool = pool;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PummelingCharge"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PummelingCharge))]
    public UnitConfigurator AddPummelingCharge(
        WeaponCategory unarmedCategory = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new PummelingCharge();
      component.UnarmedCategory = unarmedCategory;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReduceDamageReduction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ReduceDamageReduction))]
    public UnitConfigurator AddReduceDamageReduction(
        ContextValue value,
        int multiplier = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new ReduceDamageReduction();
      component.Multiplier = multiplier;
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RemovedByHeal"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RemovedByHeal))]
    public UnitConfigurator AddRemovedByHeal(
        BlueprintComponent.Flags flags = default)
    {
      var component = new RemovedByHeal();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ReplaceAsksList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="asks"><see cref="BlueprintUnitAsksList"/></param>
    [Generated]
    [Implements(typeof(ReplaceAsksList))]
    public UnitConfigurator AddReplaceAsksList(
        string asks = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ReplaceAsksList();
      component.m_Asks = BlueprintTool.GetRef<BlueprintUnitAsksListReference>(asks);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ResistEnergy"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ResistEnergy))]
    public UnitConfigurator AddResistEnergy(
        ContextValue valueMultiplier,
        ContextValue value,
        ContextValue pool,
        DamageEnergyType type = default,
        bool useValueMultiplier = default,
        bool usePool = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(valueMultiplier);
      ValidateParam(value);
      ValidateParam(pool);
    
      var component = new ResistEnergy();
      component.Type = type;
      component.UseValueMultiplier = useValueMultiplier;
      component.ValueMultiplier = valueMultiplier;
      component.Value = value;
      component.UsePool = usePool;
      component.Pool = pool;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ResistEnergyContext"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ResistEnergyContext))]
    public UnitConfigurator AddResistEnergyContext(
        ContextValue valueMultiplier,
        ContextValue value,
        ContextValue pool,
        DamageEnergyType type = default,
        bool useValueMultiplier = default,
        bool usePool = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(valueMultiplier);
      ValidateParam(value);
      ValidateParam(pool);
    
      var component = new ResistEnergyContext();
      component.Type = type;
      component.UseValueMultiplier = useValueMultiplier;
      component.ValueMultiplier = valueMultiplier;
      component.Value = value;
      component.UsePool = usePool;
      component.Pool = pool;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SaveSuccessIfBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SaveSuccessIfBonus))]
    public UnitConfigurator AddSaveSuccessIfBonus(
        ContextValue value,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new SaveSuccessIfBonus();
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShieldFocus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ShieldFocus))]
    public UnitConfigurator AddShieldFocus(
        BlueprintComponent.Flags flags = default)
    {
      var component = new ShieldFocus();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SkillSuccessIfBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SkillSuccessIfBonus))]
    public UnitConfigurator AddSkillSuccessIfBonus(
        ContextValue value,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new SkillSuccessIfBonus();
      component.Value = value;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpeedBonusInArmorCategory"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpeedBonusInArmorCategory))]
    public UnitConfigurator AddSpeedBonusInArmorCategory(
        ArmorProficiencyGroup[] category = null,
        int bonus = default,
        ModifierDescriptor descriptor = default,
        bool noArmor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SpeedBonusInArmorCategory();
      component.Category = category;
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      component.NoArmor = noArmor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="StatBonusWeaponRestriction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(StatBonusWeaponRestriction))]
    public UnitConfigurator AddStatBonusWeaponRestriction(
        StatType stat = default,
        int value = default,
        ModifierDescriptor descriptor = default,
        bool checkCategory = default,
        WeaponCategory category = default,
        bool oneHandedOnly = default,
        bool duelistWeapon = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new StatBonusWeaponRestriction();
      component.Stat = stat;
      component.Value = value;
      component.Descriptor = descriptor;
      component.CheckCategory = checkCategory;
      component.Category = category;
      component.OneHandedOnly = oneHandedOnly;
      component.DuelistWeapon = duelistWeapon;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="StonyStepTerrainBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(StonyStepTerrainBonus))]
    public UnitConfigurator AddStonyStepTerrainBonus(
        AreaSetting setting = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new StonyStepTerrainBonus();
      component.Setting = setting;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TemporaryHitPointsConstitutionBased"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TemporaryHitPointsConstitutionBased))]
    public UnitConfigurator AddTemporaryHitPointsConstitutionBased(
        ContextValue value,
        int bonusMultiplier = default,
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new TemporaryHitPointsConstitutionBased();
      component.Value = value;
      component.BonusMultiplier = bonusMultiplier;
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TemporaryHitPointsEqualCasterLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TemporaryHitPointsEqualCasterLevel))]
    public UnitConfigurator AddTemporaryHitPointsEqualCasterLevel(
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new TemporaryHitPointsEqualCasterLevel();
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TemporaryHitPointsFromAbilityValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TemporaryHitPointsFromAbilityValue))]
    public UnitConfigurator AddTemporaryHitPointsFromAbilityValue(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        bool removeWhenHitPointsEnd = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new TemporaryHitPointsFromAbilityValue();
      component.Descriptor = descriptor;
      component.Value = value;
      component.RemoveWhenHitPointsEnd = removeWhenHitPointsEnd;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TemporaryHitPointsPerLevel"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="limitlessRageBlueprint"><see cref="BlueprintUnitFact"/></param>
    /// <param name="limitlessRageResource"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    [Implements(typeof(TemporaryHitPointsPerLevel))]
    public UnitConfigurator AddTemporaryHitPointsPerLevel(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        int hitPointsPerLevel = default,
        bool removeWhenHitPointsEnd = default,
        bool limitlessRage = default,
        string limitlessRageBlueprint = null,
        string limitlessRageResource = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new TemporaryHitPointsPerLevel();
      component.Descriptor = descriptor;
      component.HitPointsPerLevel = hitPointsPerLevel;
      component.Value = value;
      component.RemoveWhenHitPointsEnd = removeWhenHitPointsEnd;
      component.LimitlessRage = limitlessRage;
      component.m_LimitlessRageBlueprint = BlueprintTool.GetRef<BlueprintUnitFactReference>(limitlessRageBlueprint);
      component.m_LimitlessRageResource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(limitlessRageResource);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TemporaryHitPointsRandom"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TemporaryHitPointsRandom))]
    public UnitConfigurator AddTemporaryHitPointsRandom(
        DiceFormula dice,
        ContextValue bonus,
        ModifierDescriptor descriptor = default,
        bool scaleBonusByCasterLevel = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(bonus);
    
      var component = new TemporaryHitPointsRandom();
      component.Descriptor = descriptor;
      component.Dice = dice;
      component.Bonus = bonus;
      component.ScaleBonusByCasterLevel = scaleBonusByCasterLevel;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TowerShieldSpecialistTotalCover"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TowerShieldSpecialistTotalCover))]
    public UnitConfigurator AddTowerShieldSpecialistTotalCover(
        BlueprintComponent.Flags flags = default)
    {
      var component = new TowerShieldSpecialistTotalCover();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponTrainingBonuses"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponTrainingBonuses))]
    public UnitConfigurator AddWeaponTrainingBonuses(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new WeaponTrainingBonuses();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WizardAbjurationResistance"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="wizard"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(WizardAbjurationResistance))]
    public UnitConfigurator AddWizardAbjurationResistance(
        ContextValue valueMultiplier,
        ContextValue value,
        ContextValue pool,
        string wizard = null,
        DamageEnergyType type = default,
        bool useValueMultiplier = default,
        bool usePool = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(valueMultiplier);
      ValidateParam(value);
      ValidateParam(pool);
    
      var component = new WizardAbjurationResistance();
      component.m_Wizard = BlueprintTool.GetRef<BlueprintCharacterClassReference>(wizard);
      component.Type = type;
      component.UseValueMultiplier = useValueMultiplier;
      component.ValueMultiplier = valueMultiplier;
      component.Value = value;
      component.UsePool = usePool;
      component.Pool = pool;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WizardEnergyAbsorption"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="resource"><see cref="BlueprintAbilityResource"/></param>
    [Generated]
    [Implements(typeof(WizardEnergyAbsorption))]
    public UnitConfigurator AddWizardEnergyAbsorption(
        ContextValue valueMultiplier,
        ContextValue value,
        ContextValue pool,
        string resource = null,
        DamageEnergyType type = default,
        bool useValueMultiplier = default,
        bool usePool = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(valueMultiplier);
      ValidateParam(value);
      ValidateParam(pool);
    
      var component = new WizardEnergyAbsorption();
      component.m_Resource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(resource);
      component.Type = type;
      component.UseValueMultiplier = useValueMultiplier;
      component.ValueMultiplier = valueMultiplier;
      component.Value = value;
      component.UsePool = usePool;
      component.Pool = pool;
      component.m_Flags = flags;
      return AddComponent(component);
    }
  }
}
