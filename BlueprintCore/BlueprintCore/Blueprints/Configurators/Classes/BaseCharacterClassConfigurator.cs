//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Designers.Mechanics.Prerequisites;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.Utility;
using Kingmaker.Visual.CharacterSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCharacterClass"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCharacterClassConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintCharacterClass
    where TBuilder : BaseCharacterClassConfigurator<T, TBuilder>
  {
    protected BaseCharacterClassConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintCharacterClass>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.LocalizedName = copyFrom.LocalizedName;
          bp.LocalizedDescription = copyFrom.LocalizedDescription;
          bp.LocalizedDescriptionShort = copyFrom.LocalizedDescriptionShort;
          bp.m_Icon = copyFrom.m_Icon;
          bp.SkillPoints = copyFrom.SkillPoints;
          bp.HitDie = copyFrom.HitDie;
          bp.HideIfRestricted = copyFrom.HideIfRestricted;
          bp.HideInUI = copyFrom.HideInUI;
          bp.PrestigeClass = copyFrom.PrestigeClass;
          bp.IsMythic = copyFrom.IsMythic;
          bp.DontAddCasterLevels = copyFrom.DontAddCasterLevels;
          bp.m_IsHigherMythic = copyFrom.m_IsHigherMythic;
          bp.m_BaseAttackBonus = copyFrom.m_BaseAttackBonus;
          bp.m_FortitudeSave = copyFrom.m_FortitudeSave;
          bp.m_ReflexSave = copyFrom.m_ReflexSave;
          bp.m_WillSave = copyFrom.m_WillSave;
          bp.m_Progression = copyFrom.m_Progression;
          bp.m_Spellbook = copyFrom.m_Spellbook;
          bp.ClassSkills = copyFrom.ClassSkills;
          bp.IsDivineCaster = copyFrom.IsDivineCaster;
          bp.IsArcaneCaster = copyFrom.IsArcaneCaster;
          bp.m_Archetypes = copyFrom.m_Archetypes;
          bp.StartingGold = copyFrom.StartingGold;
          bp.m_StartingItems = copyFrom.m_StartingItems;
          bp.PrimaryColor = copyFrom.PrimaryColor;
          bp.SecondaryColor = copyFrom.SecondaryColor;
          bp.m_EquipmentEntities = copyFrom.m_EquipmentEntities;
          bp.MaleEquipmentEntities = copyFrom.MaleEquipmentEntities;
          bp.FemaleEquipmentEntities = copyFrom.FemaleEquipmentEntities;
          bp.m_Difficulty = copyFrom.m_Difficulty;
          bp.RecommendedAttributes = copyFrom.RecommendedAttributes;
          bp.NotRecommendedAttributes = copyFrom.NotRecommendedAttributes;
          bp.m_SignatureAbilities = copyFrom.m_SignatureAbilities;
          bp.m_DefaultBuild = copyFrom.m_DefaultBuild;
          bp.m_AdditionalVisualSettings = copyFrom.m_AdditionalVisualSettings;
          bp.VisualSettingsPriority = copyFrom.VisualSettingsPriority;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintCharacterClass>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.LocalizedName = copyFrom.LocalizedName;
          bp.LocalizedDescription = copyFrom.LocalizedDescription;
          bp.LocalizedDescriptionShort = copyFrom.LocalizedDescriptionShort;
          bp.m_Icon = copyFrom.m_Icon;
          bp.SkillPoints = copyFrom.SkillPoints;
          bp.HitDie = copyFrom.HitDie;
          bp.HideIfRestricted = copyFrom.HideIfRestricted;
          bp.HideInUI = copyFrom.HideInUI;
          bp.PrestigeClass = copyFrom.PrestigeClass;
          bp.IsMythic = copyFrom.IsMythic;
          bp.DontAddCasterLevels = copyFrom.DontAddCasterLevels;
          bp.m_IsHigherMythic = copyFrom.m_IsHigherMythic;
          bp.m_BaseAttackBonus = copyFrom.m_BaseAttackBonus;
          bp.m_FortitudeSave = copyFrom.m_FortitudeSave;
          bp.m_ReflexSave = copyFrom.m_ReflexSave;
          bp.m_WillSave = copyFrom.m_WillSave;
          bp.m_Progression = copyFrom.m_Progression;
          bp.m_Spellbook = copyFrom.m_Spellbook;
          bp.ClassSkills = copyFrom.ClassSkills;
          bp.IsDivineCaster = copyFrom.IsDivineCaster;
          bp.IsArcaneCaster = copyFrom.IsArcaneCaster;
          bp.m_Archetypes = copyFrom.m_Archetypes;
          bp.StartingGold = copyFrom.StartingGold;
          bp.m_StartingItems = copyFrom.m_StartingItems;
          bp.PrimaryColor = copyFrom.PrimaryColor;
          bp.SecondaryColor = copyFrom.SecondaryColor;
          bp.m_EquipmentEntities = copyFrom.m_EquipmentEntities;
          bp.MaleEquipmentEntities = copyFrom.MaleEquipmentEntities;
          bp.FemaleEquipmentEntities = copyFrom.FemaleEquipmentEntities;
          bp.m_Difficulty = copyFrom.m_Difficulty;
          bp.RecommendedAttributes = copyFrom.RecommendedAttributes;
          bp.NotRecommendedAttributes = copyFrom.NotRecommendedAttributes;
          bp.m_SignatureAbilities = copyFrom.m_SignatureAbilities;
          bp.m_DefaultBuild = copyFrom.m_DefaultBuild;
          bp.m_AdditionalVisualSettings = copyFrom.m_AdditionalVisualSettings;
          bp.VisualSettingsPriority = copyFrom.VisualSettingsPriority;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.LocalizedName"/>
    /// </summary>
    ///
    /// <param name="localizedName">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetLocalizedName(LocalString localizedName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LocalizedName = localizedName?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCharacterClass.LocalizedName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLocalizedName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LocalizedName is null) { return; }
          action.Invoke(bp.LocalizedName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.LocalizedDescription"/>
    /// </summary>
    ///
    /// <param name="localizedDescription">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetLocalizedDescription(LocalString localizedDescription)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LocalizedDescription = localizedDescription?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCharacterClass.LocalizedDescription"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLocalizedDescription(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LocalizedDescription is null) { return; }
          action.Invoke(bp.LocalizedDescription);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.LocalizedDescriptionShort"/>
    /// </summary>
    ///
    /// <param name="localizedDescriptionShort">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetLocalizedDescriptionShort(LocalString localizedDescriptionShort)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LocalizedDescriptionShort = localizedDescriptionShort?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCharacterClass.LocalizedDescriptionShort"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLocalizedDescriptionShort(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LocalizedDescriptionShort is null) { return; }
          action.Invoke(bp.LocalizedDescriptionShort);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.m_Icon"/>
    /// </summary>
    ///
    /// <param name="icon">
    /// You can pass in the animation using a Sprite or it's AssetId.
    /// </param>
    public TBuilder SetIcon(Asset<Sprite> icon)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Icon = icon?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCharacterClass.m_Icon"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIcon(Action<Sprite> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Icon is null) { return; }
          action.Invoke(bp.m_Icon);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.SkillPoints"/>
    /// </summary>
    public TBuilder SetSkillPoints(int skillPoints)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SkillPoints = skillPoints;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.HitDie"/>
    /// </summary>
    public TBuilder SetHitDie(DiceType hitDie)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HitDie = hitDie;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.HideIfRestricted"/>
    /// </summary>
    public TBuilder SetHideIfRestricted(bool hideIfRestricted = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HideIfRestricted = hideIfRestricted;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.HideInUI"/>
    /// </summary>
    public TBuilder SetHideInUI(bool hideInUI = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HideInUI = hideInUI;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.PrestigeClass"/>
    /// </summary>
    public TBuilder SetPrestigeClass(bool prestigeClass = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.PrestigeClass = prestigeClass;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.IsMythic"/>
    /// </summary>
    public TBuilder SetIsMythic(bool isMythic = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsMythic = isMythic;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.DontAddCasterLevels"/>
    /// </summary>
    public TBuilder SetDontAddCasterLevels(bool dontAddCasterLevels = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DontAddCasterLevels = dontAddCasterLevels;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.m_IsHigherMythic"/>
    /// </summary>
    ///
    /// <param name="isHigherMythic">
    /// <para>
    /// InfoBox: If true: replace previous mythic levels for Mythic Starting Class when receive first level of this
    /// </para>
    /// </param>
    public TBuilder SetIsHigherMythic(bool isHigherMythic = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IsHigherMythic = isHigherMythic;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.m_BaseAttackBonus"/>
    /// </summary>
    ///
    /// <param name="baseAttackBonus">
    /// <para>
    /// Blueprint of type BlueprintStatProgression. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetBaseAttackBonus(Blueprint<BlueprintStatProgressionReference> baseAttackBonus)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BaseAttackBonus = baseAttackBonus?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCharacterClass.m_BaseAttackBonus"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBaseAttackBonus(Action<BlueprintStatProgressionReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BaseAttackBonus is null) { return; }
          action.Invoke(bp.m_BaseAttackBonus);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.m_FortitudeSave"/>
    /// </summary>
    ///
    /// <param name="fortitudeSave">
    /// <para>
    /// Blueprint of type BlueprintStatProgression. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetFortitudeSave(Blueprint<BlueprintStatProgressionReference> fortitudeSave)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_FortitudeSave = fortitudeSave?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCharacterClass.m_FortitudeSave"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFortitudeSave(Action<BlueprintStatProgressionReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_FortitudeSave is null) { return; }
          action.Invoke(bp.m_FortitudeSave);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.m_ReflexSave"/>
    /// </summary>
    ///
    /// <param name="reflexSave">
    /// <para>
    /// Blueprint of type BlueprintStatProgression. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetReflexSave(Blueprint<BlueprintStatProgressionReference> reflexSave)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ReflexSave = reflexSave?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCharacterClass.m_ReflexSave"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyReflexSave(Action<BlueprintStatProgressionReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ReflexSave is null) { return; }
          action.Invoke(bp.m_ReflexSave);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.m_WillSave"/>
    /// </summary>
    ///
    /// <param name="willSave">
    /// <para>
    /// Blueprint of type BlueprintStatProgression. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetWillSave(Blueprint<BlueprintStatProgressionReference> willSave)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_WillSave = willSave?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCharacterClass.m_WillSave"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyWillSave(Action<BlueprintStatProgressionReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_WillSave is null) { return; }
          action.Invoke(bp.m_WillSave);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.m_Progression"/>
    /// </summary>
    ///
    /// <param name="progression">
    /// <para>
    /// Blueprint of type BlueprintProgression. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetProgression(Blueprint<BlueprintProgressionReference> progression)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Progression = progression?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCharacterClass.m_Progression"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyProgression(Action<BlueprintProgressionReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Progression is null) { return; }
          action.Invoke(bp.m_Progression);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.m_Spellbook"/>
    /// </summary>
    ///
    /// <param name="spellbook">
    /// <para>
    /// Blueprint of type BlueprintSpellbook. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetSpellbook(Blueprint<BlueprintSpellbookReference> spellbook)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Spellbook = spellbook?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCharacterClass.m_Spellbook"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySpellbook(Action<BlueprintSpellbookReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Spellbook is null) { return; }
          action.Invoke(bp.m_Spellbook);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.ClassSkills"/>
    /// </summary>
    public TBuilder SetClassSkills(params StatType[] classSkills)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ClassSkills = classSkills;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintCharacterClass.ClassSkills"/>
    /// </summary>
    public TBuilder AddToClassSkills(params StatType[] classSkills)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ClassSkills = bp.ClassSkills ?? new StatType[0];
          bp.ClassSkills = CommonTool.Append(bp.ClassSkills, classSkills);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCharacterClass.ClassSkills"/>
    /// </summary>
    public TBuilder RemoveFromClassSkills(params StatType[] classSkills)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ClassSkills is null) { return; }
          bp.ClassSkills = bp.ClassSkills.Where(val => !classSkills.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCharacterClass.ClassSkills"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromClassSkills(Func<StatType, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ClassSkills is null) { return; }
          bp.ClassSkills = bp.ClassSkills.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintCharacterClass.ClassSkills"/>
    /// </summary>
    public TBuilder ClearClassSkills()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ClassSkills = new StatType[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCharacterClass.ClassSkills"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyClassSkills(Action<StatType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ClassSkills is null) { return; }
          bp.ClassSkills.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.IsDivineCaster"/>
    /// </summary>
    ///
    /// <param name="isDivineCaster">
    /// <para>
    /// Tooltip: Used to determine whether spell-like abilities granted by this class are considered divine or arcane (default). Also for prerequisites.
    /// </para>
    /// </param>
    public TBuilder SetIsDivineCaster(bool isDivineCaster = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsDivineCaster = isDivineCaster;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.IsArcaneCaster"/>
    /// </summary>
    ///
    /// <param name="isArcaneCaster">
    /// <para>
    /// Tooltip: Used for prerequisites.
    /// </para>
    /// </param>
    public TBuilder SetIsArcaneCaster(bool isArcaneCaster = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsArcaneCaster = isArcaneCaster;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.m_Archetypes"/>
    /// </summary>
    ///
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
    public TBuilder SetArchetypes(params Blueprint<BlueprintArchetypeReference>[] archetypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Archetypes = archetypes.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintCharacterClass.m_Archetypes"/>
    /// </summary>
    ///
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
    public TBuilder AddToArchetypes(params Blueprint<BlueprintArchetypeReference>[] archetypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Archetypes = bp.m_Archetypes ?? new BlueprintArchetypeReference[0];
          bp.m_Archetypes = CommonTool.Append(bp.m_Archetypes, archetypes.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCharacterClass.m_Archetypes"/>
    /// </summary>
    ///
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
    public TBuilder RemoveFromArchetypes(params Blueprint<BlueprintArchetypeReference>[] archetypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Archetypes is null) { return; }
          bp.m_Archetypes = bp.m_Archetypes.Where(val => !archetypes.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCharacterClass.m_Archetypes"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromArchetypes(Func<BlueprintArchetypeReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Archetypes is null) { return; }
          bp.m_Archetypes = bp.m_Archetypes.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintCharacterClass.m_Archetypes"/>
    /// </summary>
    public TBuilder ClearArchetypes()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Archetypes = new BlueprintArchetypeReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCharacterClass.m_Archetypes"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyArchetypes(Action<BlueprintArchetypeReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Archetypes is null) { return; }
          bp.m_Archetypes.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.StartingGold"/>
    /// </summary>
    public TBuilder SetStartingGold(int startingGold)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.StartingGold = startingGold;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.m_StartingItems"/>
    /// </summary>
    ///
    /// <param name="startingItems">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetStartingItems(params Blueprint<BlueprintItemReference>[] startingItems)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_StartingItems = startingItems.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintCharacterClass.m_StartingItems"/>
    /// </summary>
    ///
    /// <param name="startingItems">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToStartingItems(params Blueprint<BlueprintItemReference>[] startingItems)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_StartingItems = bp.m_StartingItems ?? new BlueprintItemReference[0];
          bp.m_StartingItems = CommonTool.Append(bp.m_StartingItems, startingItems.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCharacterClass.m_StartingItems"/>
    /// </summary>
    ///
    /// <param name="startingItems">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromStartingItems(params Blueprint<BlueprintItemReference>[] startingItems)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_StartingItems is null) { return; }
          bp.m_StartingItems = bp.m_StartingItems.Where(val => !startingItems.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCharacterClass.m_StartingItems"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromStartingItems(Func<BlueprintItemReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_StartingItems is null) { return; }
          bp.m_StartingItems = bp.m_StartingItems.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintCharacterClass.m_StartingItems"/>
    /// </summary>
    public TBuilder ClearStartingItems()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_StartingItems = new BlueprintItemReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCharacterClass.m_StartingItems"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyStartingItems(Action<BlueprintItemReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_StartingItems is null) { return; }
          bp.m_StartingItems.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.PrimaryColor"/>
    /// </summary>
    public TBuilder SetPrimaryColor(int primaryColor)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.PrimaryColor = primaryColor;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.SecondaryColor"/>
    /// </summary>
    public TBuilder SetSecondaryColor(int secondaryColor)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SecondaryColor = secondaryColor;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.m_EquipmentEntities"/>
    /// </summary>
    ///
    /// <param name="equipmentEntities">
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
    public TBuilder SetEquipmentEntities(params Blueprint<KingmakerEquipmentEntityReference>[] equipmentEntities)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_EquipmentEntities = equipmentEntities.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintCharacterClass.m_EquipmentEntities"/>
    /// </summary>
    ///
    /// <param name="equipmentEntities">
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
    public TBuilder AddToEquipmentEntities(params Blueprint<KingmakerEquipmentEntityReference>[] equipmentEntities)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_EquipmentEntities = bp.m_EquipmentEntities ?? new KingmakerEquipmentEntityReference[0];
          bp.m_EquipmentEntities = CommonTool.Append(bp.m_EquipmentEntities, equipmentEntities.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCharacterClass.m_EquipmentEntities"/>
    /// </summary>
    ///
    /// <param name="equipmentEntities">
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
    public TBuilder RemoveFromEquipmentEntities(params Blueprint<KingmakerEquipmentEntityReference>[] equipmentEntities)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_EquipmentEntities is null) { return; }
          bp.m_EquipmentEntities = bp.m_EquipmentEntities.Where(val => !equipmentEntities.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCharacterClass.m_EquipmentEntities"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromEquipmentEntities(Func<KingmakerEquipmentEntityReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_EquipmentEntities is null) { return; }
          bp.m_EquipmentEntities = bp.m_EquipmentEntities.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintCharacterClass.m_EquipmentEntities"/>
    /// </summary>
    public TBuilder ClearEquipmentEntities()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_EquipmentEntities = new KingmakerEquipmentEntityReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCharacterClass.m_EquipmentEntities"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyEquipmentEntities(Action<KingmakerEquipmentEntityReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_EquipmentEntities is null) { return; }
          bp.m_EquipmentEntities.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.MaleEquipmentEntities"/>
    /// </summary>
    ///
    /// <param name="maleEquipmentEntities">
    /// You can pass in the animation using an EquipmentEntityLink or it's AssetId.
    /// </param>
    public TBuilder SetMaleEquipmentEntities(params AssetLink<EquipmentEntityLink>[] maleEquipmentEntities)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MaleEquipmentEntities = maleEquipmentEntities?.Select(entry => entry?.Get())?.ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintCharacterClass.MaleEquipmentEntities"/>
    /// </summary>
    ///
    /// <param name="maleEquipmentEntities">
    /// You can pass in the animation using an EquipmentEntityLink or it's AssetId.
    /// </param>
    public TBuilder AddToMaleEquipmentEntities(params AssetLink<EquipmentEntityLink>[] maleEquipmentEntities)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MaleEquipmentEntities = bp.MaleEquipmentEntities ?? new EquipmentEntityLink[0];
          bp.MaleEquipmentEntities = CommonTool.Append(bp.MaleEquipmentEntities, maleEquipmentEntities?.Select(entry => entry?.Get()).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCharacterClass.MaleEquipmentEntities"/>
    /// </summary>
    ///
    /// <param name="maleEquipmentEntities">
    /// You can pass in the animation using an EquipmentEntityLink or it's AssetId.
    /// </param>
    public TBuilder RemoveFromMaleEquipmentEntities(params AssetLink<EquipmentEntityLink>[] maleEquipmentEntities)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.MaleEquipmentEntities is null) { return; }
          var convertedParams = maleEquipmentEntities.Select(entry => entry?.Get());
          bp.MaleEquipmentEntities = bp.MaleEquipmentEntities.Where(val => !convertedParams.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCharacterClass.MaleEquipmentEntities"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromMaleEquipmentEntities(Func<EquipmentEntityLink, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.MaleEquipmentEntities is null) { return; }
          bp.MaleEquipmentEntities = bp.MaleEquipmentEntities.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintCharacterClass.MaleEquipmentEntities"/>
    /// </summary>
    public TBuilder ClearMaleEquipmentEntities()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MaleEquipmentEntities = new EquipmentEntityLink[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCharacterClass.MaleEquipmentEntities"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyMaleEquipmentEntities(Action<EquipmentEntityLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.MaleEquipmentEntities is null) { return; }
          bp.MaleEquipmentEntities.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.FemaleEquipmentEntities"/>
    /// </summary>
    ///
    /// <param name="femaleEquipmentEntities">
    /// You can pass in the animation using an EquipmentEntityLink or it's AssetId.
    /// </param>
    public TBuilder SetFemaleEquipmentEntities(params AssetLink<EquipmentEntityLink>[] femaleEquipmentEntities)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FemaleEquipmentEntities = femaleEquipmentEntities?.Select(entry => entry?.Get())?.ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintCharacterClass.FemaleEquipmentEntities"/>
    /// </summary>
    ///
    /// <param name="femaleEquipmentEntities">
    /// You can pass in the animation using an EquipmentEntityLink or it's AssetId.
    /// </param>
    public TBuilder AddToFemaleEquipmentEntities(params AssetLink<EquipmentEntityLink>[] femaleEquipmentEntities)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FemaleEquipmentEntities = bp.FemaleEquipmentEntities ?? new EquipmentEntityLink[0];
          bp.FemaleEquipmentEntities = CommonTool.Append(bp.FemaleEquipmentEntities, femaleEquipmentEntities?.Select(entry => entry?.Get()).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCharacterClass.FemaleEquipmentEntities"/>
    /// </summary>
    ///
    /// <param name="femaleEquipmentEntities">
    /// You can pass in the animation using an EquipmentEntityLink or it's AssetId.
    /// </param>
    public TBuilder RemoveFromFemaleEquipmentEntities(params AssetLink<EquipmentEntityLink>[] femaleEquipmentEntities)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FemaleEquipmentEntities is null) { return; }
          var convertedParams = femaleEquipmentEntities.Select(entry => entry?.Get());
          bp.FemaleEquipmentEntities = bp.FemaleEquipmentEntities.Where(val => !convertedParams.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCharacterClass.FemaleEquipmentEntities"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromFemaleEquipmentEntities(Func<EquipmentEntityLink, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FemaleEquipmentEntities is null) { return; }
          bp.FemaleEquipmentEntities = bp.FemaleEquipmentEntities.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintCharacterClass.FemaleEquipmentEntities"/>
    /// </summary>
    public TBuilder ClearFemaleEquipmentEntities()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FemaleEquipmentEntities = new EquipmentEntityLink[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCharacterClass.FemaleEquipmentEntities"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyFemaleEquipmentEntities(Action<EquipmentEntityLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FemaleEquipmentEntities is null) { return; }
          bp.FemaleEquipmentEntities.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.m_Difficulty"/>
    /// </summary>
    public TBuilder SetDifficulty(int difficulty)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Difficulty = difficulty;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.RecommendedAttributes"/>
    /// </summary>
    public TBuilder SetRecommendedAttributes(params StatType[] recommendedAttributes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RecommendedAttributes = recommendedAttributes;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintCharacterClass.RecommendedAttributes"/>
    /// </summary>
    public TBuilder AddToRecommendedAttributes(params StatType[] recommendedAttributes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RecommendedAttributes = bp.RecommendedAttributes ?? new StatType[0];
          bp.RecommendedAttributes = CommonTool.Append(bp.RecommendedAttributes, recommendedAttributes);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCharacterClass.RecommendedAttributes"/>
    /// </summary>
    public TBuilder RemoveFromRecommendedAttributes(params StatType[] recommendedAttributes)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RecommendedAttributes is null) { return; }
          bp.RecommendedAttributes = bp.RecommendedAttributes.Where(val => !recommendedAttributes.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCharacterClass.RecommendedAttributes"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromRecommendedAttributes(Func<StatType, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RecommendedAttributes is null) { return; }
          bp.RecommendedAttributes = bp.RecommendedAttributes.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintCharacterClass.RecommendedAttributes"/>
    /// </summary>
    public TBuilder ClearRecommendedAttributes()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RecommendedAttributes = new StatType[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCharacterClass.RecommendedAttributes"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyRecommendedAttributes(Action<StatType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RecommendedAttributes is null) { return; }
          bp.RecommendedAttributes.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.NotRecommendedAttributes"/>
    /// </summary>
    public TBuilder SetNotRecommendedAttributes(params StatType[] notRecommendedAttributes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NotRecommendedAttributes = notRecommendedAttributes;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintCharacterClass.NotRecommendedAttributes"/>
    /// </summary>
    public TBuilder AddToNotRecommendedAttributes(params StatType[] notRecommendedAttributes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NotRecommendedAttributes = bp.NotRecommendedAttributes ?? new StatType[0];
          bp.NotRecommendedAttributes = CommonTool.Append(bp.NotRecommendedAttributes, notRecommendedAttributes);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCharacterClass.NotRecommendedAttributes"/>
    /// </summary>
    public TBuilder RemoveFromNotRecommendedAttributes(params StatType[] notRecommendedAttributes)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.NotRecommendedAttributes is null) { return; }
          bp.NotRecommendedAttributes = bp.NotRecommendedAttributes.Where(val => !notRecommendedAttributes.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCharacterClass.NotRecommendedAttributes"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromNotRecommendedAttributes(Func<StatType, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.NotRecommendedAttributes is null) { return; }
          bp.NotRecommendedAttributes = bp.NotRecommendedAttributes.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintCharacterClass.NotRecommendedAttributes"/>
    /// </summary>
    public TBuilder ClearNotRecommendedAttributes()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NotRecommendedAttributes = new StatType[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCharacterClass.NotRecommendedAttributes"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyNotRecommendedAttributes(Action<StatType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.NotRecommendedAttributes is null) { return; }
          bp.NotRecommendedAttributes.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.m_SignatureAbilities"/>
    /// </summary>
    ///
    /// <param name="signatureAbilities">
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
    public TBuilder SetSignatureAbilities(params Blueprint<BlueprintFeatureReference>[] signatureAbilities)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SignatureAbilities = signatureAbilities.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintCharacterClass.m_SignatureAbilities"/>
    /// </summary>
    ///
    /// <param name="signatureAbilities">
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
    public TBuilder AddToSignatureAbilities(params Blueprint<BlueprintFeatureReference>[] signatureAbilities)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SignatureAbilities = bp.m_SignatureAbilities ?? new BlueprintFeatureReference[0];
          bp.m_SignatureAbilities = CommonTool.Append(bp.m_SignatureAbilities, signatureAbilities.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCharacterClass.m_SignatureAbilities"/>
    /// </summary>
    ///
    /// <param name="signatureAbilities">
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
    public TBuilder RemoveFromSignatureAbilities(params Blueprint<BlueprintFeatureReference>[] signatureAbilities)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SignatureAbilities is null) { return; }
          bp.m_SignatureAbilities = bp.m_SignatureAbilities.Where(val => !signatureAbilities.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCharacterClass.m_SignatureAbilities"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromSignatureAbilities(Func<BlueprintFeatureReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SignatureAbilities is null) { return; }
          bp.m_SignatureAbilities = bp.m_SignatureAbilities.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintCharacterClass.m_SignatureAbilities"/>
    /// </summary>
    public TBuilder ClearSignatureAbilities()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SignatureAbilities = new BlueprintFeatureReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCharacterClass.m_SignatureAbilities"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifySignatureAbilities(Action<BlueprintFeatureReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SignatureAbilities is null) { return; }
          bp.m_SignatureAbilities.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.m_DefaultBuild"/>
    /// </summary>
    ///
    /// <param name="defaultBuild">
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
    public TBuilder SetDefaultBuild(Blueprint<BlueprintUnitFactReference> defaultBuild)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DefaultBuild = defaultBuild?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCharacterClass.m_DefaultBuild"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDefaultBuild(Action<BlueprintUnitFactReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DefaultBuild is null) { return; }
          action.Invoke(bp.m_DefaultBuild);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.m_AdditionalVisualSettings"/>
    /// </summary>
    ///
    /// <param name="additionalVisualSettings">
    /// <para>
    /// Blueprint of type BlueprintClassAdditionalVisualSettingsProgression. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAdditionalVisualSettings(Blueprint<BlueprintClassAdditionalVisualSettingsProgression.Reference> additionalVisualSettings)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AdditionalVisualSettings = additionalVisualSettings?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCharacterClass.m_AdditionalVisualSettings"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAdditionalVisualSettings(Action<BlueprintClassAdditionalVisualSettingsProgression.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AdditionalVisualSettings is null) { return; }
          action.Invoke(bp.m_AdditionalVisualSettings);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCharacterClass.VisualSettingsPriority"/>
    /// </summary>
    public TBuilder SetVisualSettingsPriority(int visualSettingsPriority)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.VisualSettingsPriority = visualSettingsPriority;
        });
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteAlignment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbadarFeature</term><description>6122dacf418611540a3c91e67197ee4e</description></item>
    /// <item><term>GoodDomainProgressionSecondary</term><description>efc4219c7894afc438180737adc0b7ac</description></item>
    /// <item><term>ZonKuthonFeature</term><description>f7eed400baa66a744ad361d4df0e6f1b</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="archetypeAlignment">
    /// <para>
    /// InfoBox: PF-485644 - ограничение мировоззрения для архетипа всегда заменяет ограничение класса.
    /// </para>
    /// </param>
    /// <param name="ingorePrerequisiteCheck">
    /// <para>
    /// InfoBox: PF-470784 - игнорируем проверку на доступность во время создания персонажа.
    /// </para>
    /// </param>
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddPrerequisiteAlignment(
        AlignmentMaskType alignment,
        bool? archetypeAlignment = null,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? ingorePrerequisiteCheck = null,
        bool? isFeatureSelectionWhiteList = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new PrerequisiteAlignment();
      component.Alignment = alignment;
      component.ArchetypeAlignment = archetypeAlignment ?? component.ArchetypeAlignment;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IngorePrerequisiteCheck = ingorePrerequisiteCheck ?? component.IngorePrerequisiteCheck;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteArchetypeLevel"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcaneTricksterArcanistEldritchFont</term><description>a732797826db0b54ea123d91b4cdaad5</description></item>
    /// <item><term>LoremasterArcanistMagicDeceiver</term><description>d20206c5e91942399e76eb366c026ca9</description></item>
    /// <item><term>WreckingBlowsFeature</term><description>5bccc86dd1f187a4a99f092dc054c755</description></item>
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
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteArchetypeLevel(
        Blueprint<BlueprintArchetypeReference> archetype,
        Blueprint<BlueprintCharacterClassReference> characterClass,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        int? level = null)
    {
      var component = new PrerequisiteArchetypeLevel();
      component.m_Archetype = archetype?.Reference;
      component.m_CharacterClass = characterClass?.Reference;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      component.Level = level ?? component.Level;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteCasterType"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcaneStrikeFeature</term><description>0ab2f21a922feee4dab116238e3150b4</description></item>
    /// <item><term>SuperiorityOfCold</term><description>803d7327658b441286d15b3fa6a49963</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddPrerequisiteCasterType(
        bool isArcane,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new PrerequisiteCasterType();
      component.IsArcane = isArcane;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteCasterTypeSpellLevel"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcaneTricksterClass</term><description>9c935a076d4fe4d4999fd48d853e3cf3</description></item>
    /// <item><term>LoremasterClass</term><description>4a7c05adfbaf05446a6bf664d28fb103</description></item>
    /// <item><term>WinterWitchClass</term><description>eb24ca44debf6714aabe1af1fd905a07</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="isArcane">
    /// <para>
    /// InfoBox: Mythic &amp; Alchemist Spellbooks don&amp;apos;t cound
    /// </para>
    /// </param>
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteCasterTypeSpellLevel(
        bool isArcane,
        bool onlySpontaneous,
        int requiredSpellLevel,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null)
    {
      var component = new PrerequisiteCasterTypeSpellLevel();
      component.IsArcane = isArcane;
      component.OnlySpontaneous = onlySpontaneous;
      component.RequiredSpellLevel = requiredSpellLevel;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteCharacterLevel"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BlindingStrike</term><description>fd01c15d9e74cd247b1fdbd6eb4d4713</description></item>
    /// <item><term>FeatureWingsAngel</term><description>d9bd0fde6deb2e44a93268f2dfb3e169</description></item>
    /// <item><term>MurmursOfEarth</term><description>94be54cd152d1c94396754de7bf0105f</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddPrerequisiteCharacterLevel(
        int level,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new PrerequisiteCharacterLevel();
      component.Level = level;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteClassLevel"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AdvancedWeaponTraining1</term><description>3aa4cbdd4af5ba54888b0dc7f07f80c4</description></item>
    /// <item><term>MythicStartingClass</term><description>247aa787806d5da4f89cfc3dff0b217f</description></item>
    /// <item><term>WreckingBlowsFeature</term><description>5bccc86dd1f187a4a99f092dc054c755</description></item>
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
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteClassLevel(
        Blueprint<BlueprintCharacterClassReference> characterClass,
        int level,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        bool? not = null)
    {
      var component = new PrerequisiteClassLevel();
      component.m_CharacterClass = characterClass?.Reference;
      component.Level = level;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      component.Not = not ?? component.Not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteClassSpellLevel"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArcaneTricksterArcanist</term><description>7cab956d45dc51c4ea9e71bba366a250</description></item>
    /// <item><term>HellknightSigniferThassilonianIllusion</term><description>444211da5e9592f41a4334825eb7ea2c</description></item>
    /// <item><term>WinterWitchWitchLeyLineGuardian</term><description>56adf819599827f4695395924a060996</description></item>
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
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddPrerequisiteClassSpellLevel(
        Blueprint<BlueprintCharacterClassReference> characterClass,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        int? requiredSpellLevel = null)
    {
      var component = new PrerequisiteClassSpellLevel();
      component.m_CharacterClass = characterClass?.Reference;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      component.RequiredSpellLevel = requiredSpellLevel ?? component.RequiredSpellLevel;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteEtude"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonMythicClass</term><description>15a85e67b7d69554cab9ed5830d0268e</description></item>
    /// <item><term>FakeLegendClass</term><description>b82f1fbd191e1f2498266ca41f05027f</description></item>
    /// <item><term>TricksterMythicClass</term><description>8df873a8c6e48294abdb78c45834aa0a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="etude">
    /// <para>
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    /// <param name="uIText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder AddPrerequisiteEtude(
        Blueprint<BlueprintEtudeReference> etude,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        bool? notPlaying = null,
        LocalString? uIText = null)
    {
      var component = new PrerequisiteEtude();
      component.Etude = etude?.Reference;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      component.NotPlaying = notPlaying ?? component.NotPlaying;
      component.UIText = uIText?.LocalizedString ?? component.UIText;
      if (component.UIText is null)
      {
        component.UIText = Utils.Constants.Empty.String;
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteFeature"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbundantArcanePool</term><description>8acebba92ada26043873cae5b92cef7b</description></item>
    /// <item><term>MasterOfAllArchetype</term><description>bd4e70bfb89a452b876713d61b9b8eb2</description></item>
    /// <item><term>WreckingBlowsFeature</term><description>5bccc86dd1f187a4a99f092dc054c755</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="feature">
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
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteFeature(
        Blueprint<BlueprintFeatureReference> feature,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null)
    {
      var component = new PrerequisiteFeature();
      component.m_Feature = feature?.Reference;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteFeaturesFromList"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AerialAdaptationFeature</term><description>c8719b3c5c0d4694cb13abcc3b7e893b</description></item>
    /// <item><term>LoremasterWizardSecretShaman</term><description>291b1cabaa3405c4991c892204546bcb</description></item>
    /// <item><term>WinterWitchWitchHexSelection</term><description>b921af3627142bd4d9cf3aefb5e2610a</description></item>
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
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteFeaturesFromList(
        List<Blueprint<BlueprintFeatureReference>> features,
        int? amount = null,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        bool? restrictIfNot = null)
    {
      var component = new PrerequisiteFeaturesFromList();
      component.m_Features = features?.Select(bp => bp.Reference)?.ToArray();
      component.Amount = amount ?? component.Amount;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      component.m_RestrictIfNot = restrictIfNot ?? component.m_RestrictIfNot;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteMythicLevel"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DevilMythicClass</term><description>211f49705f478b3468db6daa802452a2</description></item>
    /// <item><term>GoldenDragonClass</term><description>daf1235b6217787499c14e4e32142523</description></item>
    /// <item><term>SwarmThatWalksClass</term><description>5295b8e13c2303f4c88bdb3d7760a757</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddPrerequisiteMythicLevel(
        int level,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new PrerequisiteMythicLevel();
      component.Level = level;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteNoArchetype"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbadarFeature</term><description>6122dacf418611540a3c91e67197ee4e</description></item>
    /// <item><term>BloodragerCelestialFeatSelectionGreenrager</term><description>0c96650e80e712f439c2a4da8a4272d9</description></item>
    /// <item><term>ZonKuthonFeature</term><description>f7eed400baa66a744ad361d4df0e6f1b</description></item>
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
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteNoArchetype(
        Blueprint<BlueprintArchetypeReference> archetype,
        Blueprint<BlueprintCharacterClassReference> characterClass,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null)
    {
      var component = new PrerequisiteNoArchetype();
      component.m_Archetype = archetype?.Reference;
      component.m_CharacterClass = characterClass?.Reference;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteNoClassLevel"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AchaekekFeature</term><description>a3189d5b7c4d4d91beaa8bfffac3e38e</description></item>
    /// <item><term>GreenFaithCameliaFeature</term><description>ca763809e01f4247a3639965364c26cb</description></item>
    /// <item><term>ZonKuthonFeature</term><description>f7eed400baa66a744ad361d4df0e6f1b</description></item>
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
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteNoClassLevel(
        Blueprint<BlueprintCharacterClassReference> characterClass,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null)
    {
      var component = new PrerequisiteNoClassLevel();
      component.m_CharacterClass = characterClass?.Reference;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteNoFeature"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbadarFeature</term><description>6122dacf418611540a3c91e67197ee4e</description></item>
    /// <item><term>LiberationDomainProgression</term><description>df2f14ced8710664ba7db914880c4a02</description></item>
    /// <item><term>ZonKuthonFeature</term><description>f7eed400baa66a744ad361d4df0e6f1b</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="feature">
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
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteNoFeature(
        Blueprint<BlueprintFeatureReference> feature,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null)
    {
      var component = new PrerequisiteNoFeature();
      component.m_Feature = feature?.Reference;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteNotProficient"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BastardSwordProficiency</term><description>57299a78b2256604dadf1ab9a42e2873</description></item>
    /// <item><term>LightBardingProficiency</term><description>c62ba548b1a34b94b9802925b35737c2</description></item>
    /// <item><term>UrgroshProficiency</term><description>d24f7545b1aa3b34e8216f8cb3140563</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddPrerequisiteNotProficient(
        ArmorProficiencyGroup[] armorProficiencies,
        WeaponCategory[] weaponProficiencies,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new PrerequisiteNotProficient();
      component.ArmorProficiencies = armorProficiencies;
      component.WeaponProficiencies = weaponProficiencies;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteParametrizedFeature"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AugmentSummoning</term><description>38155ca9e4055bb48a89240a2055dcc3</description></item>
    /// <item><term>DuelingMastery</term><description>c3a66c1bbd2fb65498b130802d5f183a</description></item>
    /// <item><term>SwordlordClass</term><description>90e4d7da3ccd1a8478411e07e91d5750</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="feature">
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
    /// <param name="spell">
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
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteParametrizedSpellFeature(
        Blueprint<BlueprintFeatureReference> feature,
        Blueprint<BlueprintAbilityReference> spell,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null)
    {
      var component = new PrerequisiteParametrizedFeature();
      component.m_Feature = feature?.Reference;
      component.m_Spell = spell?.Reference;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      component.ParameterType = FeatureParameterType.LearnSpell;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteParametrizedFeature"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AugmentSummoning</term><description>38155ca9e4055bb48a89240a2055dcc3</description></item>
    /// <item><term>DuelingMastery</term><description>c3a66c1bbd2fb65498b130802d5f183a</description></item>
    /// <item><term>SwordlordClass</term><description>90e4d7da3ccd1a8478411e07e91d5750</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="feature">
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
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteParametrizedWeaponFeature(
        Blueprint<BlueprintFeatureReference> feature,
        WeaponCategory weaponCategory,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null)
    {
      var component = new PrerequisiteParametrizedFeature();
      component.m_Feature = feature?.Reference;
      component.WeaponCategory = weaponCategory;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      component.ParameterType = FeatureParameterType.WeaponCategory;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteParametrizedFeature"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AugmentSummoning</term><description>38155ca9e4055bb48a89240a2055dcc3</description></item>
    /// <item><term>DuelingMastery</term><description>c3a66c1bbd2fb65498b130802d5f183a</description></item>
    /// <item><term>SwordlordClass</term><description>90e4d7da3ccd1a8478411e07e91d5750</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="feature">
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
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteParametrizedSpellSchoolFeature(
        Blueprint<BlueprintFeatureReference> feature,
        SpellSchool spellSchool,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null)
    {
      var component = new PrerequisiteParametrizedFeature();
      component.m_Feature = feature?.Reference;
      component.SpellSchool = spellSchool;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      component.ParameterType = FeatureParameterType.SpellSchool;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteParametrizedWeaponSubcategory"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FencingGrace</term><description>47b352ea0f73c354aba777945760b441</description></item>
    /// <item><term>PointBlankMaster</term><description>05a3b543b0a0a0346a5061e90f293f0b</description></item>
    /// <item><term>SlashingGrace</term><description>697d64669eb2c0543abb9c9b07998a38</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="feature">
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
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteParametrizedWeaponSubcategory(
        Blueprint<BlueprintFeatureReference> feature,
        WeaponSubCategory subCategory,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null)
    {
      var component = new PrerequisiteParametrizedWeaponSubcategory();
      component.m_Feature = feature?.Reference;
      component.SubCategory = subCategory;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteIsPet"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AlchemistClass</term><description>0937bec61c0dabc468428f496580c721</description></item>
    /// <item><term>InquisitorClass</term><description>f1a70d9e1b0b41e49874e1fa9052a1ce</description></item>
    /// <item><term>WizardClass</term><description>ba34257984f4c41408ce1dc2004e342e</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteIsPet(
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        bool? not = null)
    {
      var component = new PrerequisiteIsPet();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      component.Not = not ?? component.Not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisitePlayerHasFeature"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CompletelyNormalSpellFeat</term><description>094b6278f7b570f42aeaa98379f07cf2</description></item>
    /// <item><term>TricksterImprovedImprovedImprovedCritical</term><description>006a966007802a0478c9e21007207aac</description></item>
    /// <item><term>TricksterStatFocusFeatSelection</term><description>0d1d80bd3820a78488412581da3ad9c7</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="feature">
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
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisitePlayerHasFeature(
        Blueprint<BlueprintFeatureReference> feature,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null)
    {
      var component = new PrerequisitePlayerHasFeature();
      component.m_Feature = feature?.Reference;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteProficiency"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ArmorFocusHeavy</term><description>c27e6d2b0d33d42439f512c6d9a6a601</description></item>
    /// <item><term>FinesseTrainingPunchingDagger</term><description>a591ea5d2af6a9c4eac84ddeac0e204e</description></item>
    /// <item><term>SwordlordClass</term><description>90e4d7da3ccd1a8478411e07e91d5750</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddPrerequisiteProficiency(
        ArmorProficiencyGroup[] armorProficiencies,
        WeaponCategory[] weaponProficiencies,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new PrerequisiteProficiency();
      component.ArmorProficiencies = armorProficiencies;
      component.WeaponProficiencies = weaponProficiencies;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteStatValue"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AlliedSpellcaster</term><description>9093ceeefe9b84746a5993d619d7c86f</description></item>
    /// <item><term>ImprovedCriticalHeavyCrossbow</term><description>19558bb038d2b3a4eaf4f0800d011bda</description></item>
    /// <item><term>WinterWitchClass</term><description>eb24ca44debf6714aabe1af1fd905a07</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteStatValue(
        StatType stat,
        int value,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null)
    {
      var component = new PrerequisiteStatValue();
      component.Stat = stat;
      component.Value = value;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DeityDependencyClass"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ClericClass</term><description>67819271767a9dd4fbfd4ae700befea0</description></item>
    /// <item><term>InquisitorClass</term><description>f1a70d9e1b0b41e49874e1fa9052a1ce</description></item>
    /// <item><term>WarpriestClass</term><description>30b5e47d47a0e37438cc5a80c96cfb99</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddDeityDependencyClass(
        bool? isDeityDependencyClass = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new DeityDependencyClass();
      component.IsDeityDependencyClass = isDeityDependencyClass ?? component.IsDeityDependencyClass;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="HideClassIfPrerequisitesRequiredComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FakeLegendClass</term><description>b82f1fbd191e1f2498266ca41f05027f</description></item>
    /// <item><term>MythicCompanionClass</term><description>530b6a79cb691c24ba99e1577b4beb6d</description></item>
    /// <item><term>MythicStartingClass</term><description>247aa787806d5da4f89cfc3dff0b217f</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddHideClassIfPrerequisitesRequiredComponent(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new HideClassIfPrerequisitesRequiredComponent();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="MythicClassArtComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonMythicClass</term><description>15a85e67b7d69554cab9ed5830d0268e</description></item>
    /// <item><term>LegendClass</term><description>3d420403f3e7340499931324640efe96</description></item>
    /// <item><term>TricksterMythicClass</term><description>8df873a8c6e48294abdb78c45834aa0a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="abilityFrame">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    /// <param name="commonFrame">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    /// <param name="commonFrameDecor">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    /// <param name="emblem">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="portraitFrame">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    /// <param name="portraits">
    /// <para>
    /// Blueprint of type BlueprintPortrait. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="selectorFrame">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    /// <param name="selectorPortrait">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    /// <param name="selectorPortraitLineart">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder AddMythicClassArtComponent(
        AssetLink<SpriteLink>? abilityFrame = null,
        AssetLink<SpriteLink>? commonFrame = null,
        AssetLink<SpriteLink>? commonFrameDecor = null,
        AssetLink<SpriteLink>? emblem = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        AssetLink<SpriteLink>? portraitFrame = null,
        List<Blueprint<BlueprintPortraitReference>>? portraits = null,
        AssetLink<SpriteLink>? selectorFrame = null,
        AssetLink<SpriteLink>? selectorPortrait = null,
        AssetLink<SpriteLink>? selectorPortraitLineart = null)
    {
      var component = new MythicClassArtComponent();
      component.m_AbilityFrame = abilityFrame?.Get() ?? component.m_AbilityFrame;
      component.m_CommonFrame = commonFrame?.Get() ?? component.m_CommonFrame;
      component.m_CommonFrameDecor = commonFrameDecor?.Get() ?? component.m_CommonFrameDecor;
      component.m_Emblem = emblem?.Get() ?? component.m_Emblem;
      component.m_PortraitFrame = portraitFrame?.Get() ?? component.m_PortraitFrame;
      component.m_Portraits = portraits?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Portraits;
      if (component.m_Portraits is null)
      {
        component.m_Portraits = new BlueprintPortraitReference[0];
      }
      component.m_SelectorFrame = selectorFrame?.Get() ?? component.m_SelectorFrame;
      component.m_SelectorPortrait = selectorPortrait?.Get() ?? component.m_SelectorPortrait;
      component.m_SelectorPortraitLineart = selectorPortraitLineart?.Get() ?? component.m_SelectorPortraitLineart;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="MythicClassLockComponent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonMythicClass</term><description>15a85e67b7d69554cab9ed5830d0268e</description></item>
    /// <item><term>FakeLegendClass</term><description>b82f1fbd191e1f2498266ca41f05027f</description></item>
    /// <item><term>TricksterMythicClass</term><description>8df873a8c6e48294abdb78c45834aa0a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddMythicClassLockComponent(
        Mythic[]? locks = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new MythicClassLockComponent();
      component.Locks = locks ?? component.Locks;
      if (component.Locks is null)
      {
        component.Locks = new Mythic[0];
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="SkipClassPhaseIfSelected"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>MythicShardsClass</term><description>53cb5892d19e4c4586c9dd4d6337d943</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddSkipClassPhaseIfSelected(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new SkipClassPhaseIfSelected();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="SkipLevelsForSpellProgression"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DragonDiscipleClass</term><description>72051275b1dbb2d42ba9118237794f7c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddSkipLevelsForSpellProgression(
        int[]? levels = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new SkipLevelsForSpellProgression();
      component.Levels = levels ?? component.Levels;
      if (component.Levels is null)
      {
        component.Levels = new int[0];
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteCondition"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonMythicClass</term><description>15a85e67b7d69554cab9ed5830d0268e</description></item>
    /// <item><term>CrossbloodedSecondaryBloodlineDraconicSilverProgression</term><description>076d1648e1341f841a222de5b89ba215</description></item>
    /// <item><term>SylvanSorcererArchetype</term><description>711d5024ecc75f346b9cda609c3a1f83</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    /// <param name="uIText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder AddPrerequisiteCondition(
        bool? checkInProgression = null,
        Condition? condition = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        LocalString? uIText = null)
    {
      var component = new PrerequisiteCondition();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      Validate(condition);
      component.Condition = condition ?? component.Condition;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      component.UIText = uIText?.LocalizedString ?? component.UIText;
      if (component.UIText is null)
      {
        component.UIText = Utils.Constants.Empty.String;
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteMainCharacter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonMythicClass</term><description>15a85e67b7d69554cab9ed5830d0268e</description></item>
    /// <item><term>GoldenDragonClass</term><description>daf1235b6217787499c14e4e32142523</description></item>
    /// <item><term>TricksterMythicClass</term><description>8df873a8c6e48294abdb78c45834aa0a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddPrerequisiteMainCharacter(
        bool? checkInProgression = null,
        bool? companion = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new PrerequisiteMainCharacter();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Companion = companion ?? component.Companion;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisitePet"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AnimalCompanionEmptyCompanion</term><description>472091361cf118049a2b4339c4ea836a</description></item>
    /// <item><term>AnimalCompanionFeatureSmilodon</term><description>126712ef923ab204983d6f107629c895</description></item>
    /// <item><term>UnholyBeast</term><description>2101bf9664ce4012b8011da12b4797e5</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisitePet(
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        bool? noCompanion = null,
        PetType? type = null)
    {
      var component = new PrerequisitePet();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      component.NoCompanion = noCompanion ?? component.NoCompanion;
      component.Type = type ?? component.Type;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteAnySpellsInSpellbook"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SpellSpecialization1</term><description>e69a85f633ae8ca4398abeb6fa11b1fe</description></item>
    /// <item><term>SpellSpecialization19</term><description>09a6ff29f55dad544b9949702f2ed2c8</description></item>
    /// <item><term>SpellSpecializationFirst</term><description>f327a765a4353d04f872482ef3e48c35</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="shouldHaveSpellText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    /// <param name="spellSpecializationFeat">
    /// <para>
    /// Blueprint of type BlueprintParametrizedFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteAnySpellsInSpellbook(
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        LocalString? shouldHaveSpellText = null,
        Blueprint<BlueprintParametrizedFeatureReference>? spellSpecializationFeat = null)
    {
      var component = new PrerequisiteAnySpellsInSpellbook();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      component.m_ShouldHaveSpellText = shouldHaveSpellText?.LocalizedString ?? component.m_ShouldHaveSpellText;
      if (component.m_ShouldHaveSpellText is null)
      {
        component.m_ShouldHaveSpellText = Utils.Constants.Empty.String;
      }
      component.m_SpellSpecializationFeat = spellSpecializationFeat?.Reference ?? component.m_SpellSpecializationFeat;
      if (component.m_SpellSpecializationFeat is null)
      {
        component.m_SpellSpecializationFeat = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteFullStatValue"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AccomplishedSneakAttacker</term><description>9f0187869dc23744292c0e5bb364464e</description></item>
    /// <item><term>SnapShot</term><description>7115a6c08bd101247b70d72a4ff99453</description></item>
    /// <item><term>VulpinePounce</term><description>cd258f1bce80ef54580f6b236c82608c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="isFeatureSelectionWhiteList">
    /// <para>
    /// InfoBox: If checked and BlueprintFeatureSelection &amp;apos;ExceptWhiteListed&amp;apos; checked, &amp;apos;Ignore Prerequisites&amp;apos; will be ignored
    /// </para>
    /// </param>
    public TBuilder AddPrerequisiteFullStatValue(
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? isFeatureSelectionWhiteList = null,
        StatType? stat = null,
        int? value = null)
    {
      var component = new PrerequisiteFullStatValue();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.IsFeatureSelectionWhiteList = isFeatureSelectionWhiteList ?? component.IsFeatureSelectionWhiteList;
      component.Stat = stat ?? component.Stat;
      component.Value = value ?? component.Value;
      return AddComponent(component);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.LocalizedName is null)
      {
        Blueprint.LocalizedName = Utils.Constants.Empty.String;
      }
      if (Blueprint.LocalizedDescription is null)
      {
        Blueprint.LocalizedDescription = Utils.Constants.Empty.String;
      }
      if (Blueprint.LocalizedDescriptionShort is null)
      {
        Blueprint.LocalizedDescriptionShort = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_BaseAttackBonus is null)
      {
        Blueprint.m_BaseAttackBonus = BlueprintTool.GetRef<BlueprintStatProgressionReference>(null);
      }
      if (Blueprint.m_FortitudeSave is null)
      {
        Blueprint.m_FortitudeSave = BlueprintTool.GetRef<BlueprintStatProgressionReference>(null);
      }
      if (Blueprint.m_ReflexSave is null)
      {
        Blueprint.m_ReflexSave = BlueprintTool.GetRef<BlueprintStatProgressionReference>(null);
      }
      if (Blueprint.m_WillSave is null)
      {
        Blueprint.m_WillSave = BlueprintTool.GetRef<BlueprintStatProgressionReference>(null);
      }
      if (Blueprint.m_Progression is null)
      {
        Blueprint.m_Progression = BlueprintTool.GetRef<BlueprintProgressionReference>(null);
      }
      if (Blueprint.m_Spellbook is null)
      {
        Blueprint.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(null);
      }
      if (Blueprint.ClassSkills is null)
      {
        Blueprint.ClassSkills = new StatType[0];
      }
      if (Blueprint.m_Archetypes is null)
      {
        Blueprint.m_Archetypes = new BlueprintArchetypeReference[0];
      }
      if (Blueprint.m_StartingItems is null)
      {
        Blueprint.m_StartingItems = new BlueprintItemReference[0];
      }
      if (Blueprint.m_EquipmentEntities is null)
      {
        Blueprint.m_EquipmentEntities = new KingmakerEquipmentEntityReference[0];
      }
      if (Blueprint.MaleEquipmentEntities is null)
      {
        Blueprint.MaleEquipmentEntities = new EquipmentEntityLink[0];
      }
      if (Blueprint.FemaleEquipmentEntities is null)
      {
        Blueprint.FemaleEquipmentEntities = new EquipmentEntityLink[0];
      }
      if (Blueprint.RecommendedAttributes is null)
      {
        Blueprint.RecommendedAttributes = new StatType[0];
      }
      if (Blueprint.NotRecommendedAttributes is null)
      {
        Blueprint.NotRecommendedAttributes = new StatType[0];
      }
      if (Blueprint.m_SignatureAbilities is null)
      {
        Blueprint.m_SignatureAbilities = new BlueprintFeatureReference[0];
      }
      if (Blueprint.m_DefaultBuild is null)
      {
        Blueprint.m_DefaultBuild = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      if (Blueprint.m_AdditionalVisualSettings is null)
      {
        Blueprint.m_AdditionalVisualSettings = BlueprintTool.GetRef<BlueprintClassAdditionalVisualSettingsProgression.Reference>(null);
      }
    }
  }
}
