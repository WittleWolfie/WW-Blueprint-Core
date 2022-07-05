//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Designers.Mechanics.Prerequisites;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintArchetype"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseArchetypeConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintArchetype
    where TBuilder : BaseArchetypeConfigurator<T, TBuilder>
  {
    protected BaseArchetypeConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArchetype.LocalizedName"/>
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
    /// Modifies <see cref="BlueprintArchetype.LocalizedName"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintArchetype.LocalizedDescription"/>
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
    /// Modifies <see cref="BlueprintArchetype.LocalizedDescription"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintArchetype.LocalizedDescriptionShort"/>
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
    /// Modifies <see cref="BlueprintArchetype.LocalizedDescriptionShort"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintArchetype.m_Icon"/>
    /// </summary>
    public TBuilder SetIcon(Sprite icon)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(icon);
          bp.m_Icon = icon;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArchetype.m_Icon"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintArchetype.m_ReplaceSpellbook"/>
    /// </summary>
    ///
    /// <param name="replaceSpellbook">
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
    public TBuilder SetReplaceSpellbook(Blueprint<BlueprintSpellbookReference> replaceSpellbook)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ReplaceSpellbook = replaceSpellbook?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArchetype.m_ReplaceSpellbook"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyReplaceSpellbook(Action<BlueprintSpellbookReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ReplaceSpellbook is null) { return; }
          action.Invoke(bp.m_ReplaceSpellbook);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArchetype.RemoveSpellbook"/>
    /// </summary>
    public TBuilder SetRemoveSpellbook(bool removeSpellbook = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RemoveSpellbook = removeSpellbook;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArchetype.BuildChanging"/>
    /// </summary>
    public TBuilder SetBuildChanging(bool buildChanging = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.BuildChanging = buildChanging;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArchetype.AddFeatures"/>
    /// </summary>
    public TBuilder SetAddFeatures(params LevelEntry[] addFeatures)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(addFeatures);
          bp.AddFeatures = addFeatures;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintArchetype.AddFeatures"/>
    /// </summary>
    public TBuilder AddToAddFeatures(params LevelEntry[] addFeatures)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AddFeatures = bp.AddFeatures ?? new LevelEntry[0];
          bp.AddFeatures = CommonTool.Append(bp.AddFeatures, addFeatures);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintArchetype.AddFeatures"/>
    /// </summary>
    public TBuilder RemoveFromAddFeatures(params LevelEntry[] addFeatures)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.AddFeatures is null) { return; }
          bp.AddFeatures = bp.AddFeatures.Where(val => !addFeatures.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintArchetype.AddFeatures"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromAddFeatures(Func<LevelEntry, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.AddFeatures is null) { return; }
          bp.AddFeatures = bp.AddFeatures.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintArchetype.AddFeatures"/>
    /// </summary>
    public TBuilder ClearAddFeatures()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AddFeatures = new LevelEntry[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArchetype.AddFeatures"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyAddFeatures(Action<LevelEntry> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.AddFeatures is null) { return; }
          bp.AddFeatures.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArchetype.RemoveFeatures"/>
    /// </summary>
    public TBuilder SetRemoveFeatures(params LevelEntry[] removeFeatures)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(removeFeatures);
          bp.RemoveFeatures = removeFeatures;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintArchetype.RemoveFeatures"/>
    /// </summary>
    public TBuilder AddToRemoveFeatures(params LevelEntry[] removeFeatures)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RemoveFeatures = bp.RemoveFeatures ?? new LevelEntry[0];
          bp.RemoveFeatures = CommonTool.Append(bp.RemoveFeatures, removeFeatures);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintArchetype.RemoveFeatures"/>
    /// </summary>
    public TBuilder RemoveFromRemoveFeatures(params LevelEntry[] removeFeatures)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RemoveFeatures is null) { return; }
          bp.RemoveFeatures = bp.RemoveFeatures.Where(val => !removeFeatures.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintArchetype.RemoveFeatures"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromRemoveFeatures(Func<LevelEntry, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RemoveFeatures is null) { return; }
          bp.RemoveFeatures = bp.RemoveFeatures.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintArchetype.RemoveFeatures"/>
    /// </summary>
    public TBuilder ClearRemoveFeatures()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RemoveFeatures = new LevelEntry[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArchetype.RemoveFeatures"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyRemoveFeatures(Action<LevelEntry> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RemoveFeatures is null) { return; }
          bp.RemoveFeatures.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArchetype.ReplaceStartingEquipment"/>
    /// </summary>
    public TBuilder SetReplaceStartingEquipment(bool replaceStartingEquipment = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ReplaceStartingEquipment = replaceStartingEquipment;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArchetype.StartingGold"/>
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
    /// Sets the value of <see cref="BlueprintArchetype.m_StartingItems"/>
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
    /// Adds to the contents of <see cref="BlueprintArchetype.m_StartingItems"/>
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
    /// Removes elements from <see cref="BlueprintArchetype.m_StartingItems"/>
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
    /// Removes elements from <see cref="BlueprintArchetype.m_StartingItems"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromStartingItems(Func<BlueprintItemReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_StartingItems is null) { return; }
          bp.m_StartingItems = bp.m_StartingItems.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintArchetype.m_StartingItems"/>
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
    /// Modifies <see cref="BlueprintArchetype.m_StartingItems"/> by invoking the provided action on each element.
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
    /// Sets the value of <see cref="BlueprintArchetype.ReplaceClassSkills"/>
    /// </summary>
    public TBuilder SetReplaceClassSkills(bool replaceClassSkills = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ReplaceClassSkills = replaceClassSkills;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArchetype.ClassSkills"/>
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
    /// Adds to the contents of <see cref="BlueprintArchetype.ClassSkills"/>
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
    /// Removes elements from <see cref="BlueprintArchetype.ClassSkills"/>
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
    /// Removes elements from <see cref="BlueprintArchetype.ClassSkills"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromClassSkills(Func<StatType, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ClassSkills is null) { return; }
          bp.ClassSkills = bp.ClassSkills.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintArchetype.ClassSkills"/>
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
    /// Modifies <see cref="BlueprintArchetype.ClassSkills"/> by invoking the provided action on each element.
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
    /// Sets the value of <see cref="BlueprintArchetype.ChangeCasterType"/>
    /// </summary>
    public TBuilder SetChangeCasterType(bool changeCasterType = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ChangeCasterType = changeCasterType;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArchetype.IsDivineCaster"/>
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
    /// Sets the value of <see cref="BlueprintArchetype.IsArcaneCaster"/>
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
    /// Sets the value of <see cref="BlueprintArchetype.AddSkillPoints"/>
    /// </summary>
    public TBuilder SetAddSkillPoints(int addSkillPoints)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AddSkillPoints = addSkillPoints;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArchetype.OverrideAttributeRecommendations"/>
    /// </summary>
    public TBuilder SetOverrideAttributeRecommendations(bool overrideAttributeRecommendations = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OverrideAttributeRecommendations = overrideAttributeRecommendations;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArchetype.RecommendedAttributes"/>
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
    /// Adds to the contents of <see cref="BlueprintArchetype.RecommendedAttributes"/>
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
    /// Removes elements from <see cref="BlueprintArchetype.RecommendedAttributes"/>
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
    /// Removes elements from <see cref="BlueprintArchetype.RecommendedAttributes"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromRecommendedAttributes(Func<StatType, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RecommendedAttributes is null) { return; }
          bp.RecommendedAttributes = bp.RecommendedAttributes.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintArchetype.RecommendedAttributes"/>
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
    /// Modifies <see cref="BlueprintArchetype.RecommendedAttributes"/> by invoking the provided action on each element.
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
    /// Sets the value of <see cref="BlueprintArchetype.NotRecommendedAttributes"/>
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
    /// Adds to the contents of <see cref="BlueprintArchetype.NotRecommendedAttributes"/>
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
    /// Removes elements from <see cref="BlueprintArchetype.NotRecommendedAttributes"/>
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
    /// Removes elements from <see cref="BlueprintArchetype.NotRecommendedAttributes"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromNotRecommendedAttributes(Func<StatType, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.NotRecommendedAttributes is null) { return; }
          bp.NotRecommendedAttributes = bp.NotRecommendedAttributes.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintArchetype.NotRecommendedAttributes"/>
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
    /// Modifies <see cref="BlueprintArchetype.NotRecommendedAttributes"/> by invoking the provided action on each element.
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
    /// Sets the value of <see cref="BlueprintArchetype.m_SignatureAbilities"/>
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
    /// Adds to the contents of <see cref="BlueprintArchetype.m_SignatureAbilities"/>
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
    /// Removes elements from <see cref="BlueprintArchetype.m_SignatureAbilities"/>
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
    /// Removes elements from <see cref="BlueprintArchetype.m_SignatureAbilities"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromSignatureAbilities(Func<BlueprintFeatureReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SignatureAbilities is null) { return; }
          bp.m_SignatureAbilities = bp.m_SignatureAbilities.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintArchetype.m_SignatureAbilities"/>
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
    /// Modifies <see cref="BlueprintArchetype.m_SignatureAbilities"/> by invoking the provided action on each element.
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
    /// Sets the value of <see cref="BlueprintArchetype.m_BaseAttackBonus"/>
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
    /// Modifies <see cref="BlueprintArchetype.m_BaseAttackBonus"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintArchetype.m_FortitudeSave"/>
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
    /// Modifies <see cref="BlueprintArchetype.m_FortitudeSave"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintArchetype.m_ReflexSave"/>
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
    /// Modifies <see cref="BlueprintArchetype.m_ReflexSave"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintArchetype.m_WillSave"/>
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
    /// Modifies <see cref="BlueprintArchetype.m_WillSave"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintArchetype.m_ParentClass"/>
    /// </summary>
    public TBuilder SetParentClass(BlueprintCharacterClass parentClass)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(parentClass);
          bp.m_ParentClass = parentClass;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArchetype.m_ParentClass"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyParentClass(Action<BlueprintCharacterClass> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ParentClass is null) { return; }
          action.Invoke(bp.m_ParentClass);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArchetype.m_Difficulty"/>
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
    /// Adds <see cref="PrerequisiteAlignment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbadarFeature</term><description>6122dacf418611540a3c91e67197ee4e</description></item>
    /// <item><term>GozrehFeature</term><description>4af983eec2d821b40a3065eb5e8c3a72</description></item>
    /// <item><term>ZonKuthonFeature</term><description>f7eed400baa66a744ad361d4df0e6f1b</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddPrerequisiteAlignment(
        AlignmentMaskType alignment,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new PrerequisiteAlignment();
      component.Alignment = alignment;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
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
    /// <item><term>HellknightSigniferSwordSaint</term><description>7f7acf3e53b7b6240a93c634b2c02926</description></item>
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
    public TBuilder AddPrerequisiteArchetypeLevel(
        Blueprint<BlueprintArchetypeReference> archetype,
        Blueprint<BlueprintCharacterClassReference> characterClass,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        int? level = null)
    {
      var component = new PrerequisiteArchetypeLevel();
      component.m_Archetype = archetype?.Reference;
      component.m_CharacterClass = characterClass?.Reference;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
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
    /// </list>
    /// </remarks>
    ///
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
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new PrerequisiteCasterType();
      component.IsArcane = isArcane;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
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
    public TBuilder AddPrerequisiteCasterTypeSpellLevel(
        bool isArcane,
        bool onlySpontaneous,
        int requiredSpellLevel,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null)
    {
      var component = new PrerequisiteCasterTypeSpellLevel();
      component.IsArcane = isArcane;
      component.OnlySpontaneous = onlySpontaneous;
      component.RequiredSpellLevel = requiredSpellLevel;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
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
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new PrerequisiteCharacterLevel();
      component.Level = level;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
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
    /// <item><term>OracleRevelationSoulSiphon</term><description>226c053a75fd7c34cab1b493f5847787</description></item>
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
    public TBuilder AddPrerequisiteClassLevel(
        Blueprint<BlueprintCharacterClassReference> characterClass,
        int level,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? not = null)
    {
      var component = new PrerequisiteClassLevel();
      component.m_CharacterClass = characterClass?.Reference;
      component.Level = level;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
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
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        int? requiredSpellLevel = null)
    {
      var component = new PrerequisiteClassSpellLevel();
      component.m_CharacterClass = characterClass?.Reference;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
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
    /// <param name="uIText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder AddPrerequisiteEtude(
        Blueprint<BlueprintEtudeReference> etude,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? notPlaying = null,
        LocalString? uIText = null)
    {
      var component = new PrerequisiteEtude();
      component.Etude = etude?.Reference;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
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
    /// <item><term>MagicalTail8</term><description>df186ef345849d149bdbf4ddb45aee35</description></item>
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
    public TBuilder AddPrerequisiteFeature(
        Blueprint<BlueprintFeatureReference> feature,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null)
    {
      var component = new PrerequisiteFeature();
      component.m_Feature = feature?.Reference;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
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
    public TBuilder AddPrerequisiteFeaturesFromList(
        List<Blueprint<BlueprintFeatureReference>> features,
        int? amount = null,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null)
    {
      var component = new PrerequisiteFeaturesFromList();
      component.m_Features = features?.Select(bp => bp.Reference)?.ToArray();
      component.Amount = amount ?? component.Amount;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
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
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new PrerequisiteMythicLevel();
      component.Level = level;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
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
    /// <item><term>BloodlineSerpentineSpellLevel7</term><description>7b442d746153bad49b855226b9e0b64e</description></item>
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
    public TBuilder AddPrerequisiteNoArchetype(
        Blueprint<BlueprintArchetypeReference> archetype,
        Blueprint<BlueprintCharacterClassReference> characterClass,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null)
    {
      var component = new PrerequisiteNoArchetype();
      component.m_Archetype = archetype?.Reference;
      component.m_CharacterClass = characterClass?.Reference;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
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
    /// <item><term>AeonMythicClass</term><description>15a85e67b7d69554cab9ed5830d0268e</description></item>
    /// <item><term>GozrehFeature</term><description>4af983eec2d821b40a3065eb5e8c3a72</description></item>
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
    public TBuilder AddPrerequisiteNoClassLevel(
        Blueprint<BlueprintCharacterClassReference> characterClass,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null)
    {
      var component = new PrerequisiteNoClassLevel();
      component.m_CharacterClass = characterClass?.Reference;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
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
    /// <item><term>AccomplishedSneakAttacker</term><description>9f0187869dc23744292c0e5bb364464e</description></item>
    /// <item><term>HealingDomainProgressionSecondary</term><description>599fb0d60358c354d8c5c4304a73e19a</description></item>
    /// <item><term>WolfScarredFaceCurseNoPenaltyProgression</term><description>b6c775555bade694e8b8c7e82c7a71fb</description></item>
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
    public TBuilder AddPrerequisiteNoFeature(
        Blueprint<BlueprintFeatureReference> feature,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null)
    {
      var component = new PrerequisiteNoFeature();
      component.m_Feature = feature?.Reference;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
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
    /// <item><term>LightArmorProficiency</term><description>6d3728d4e9c9898458fe5e9532951132</description></item>
    /// <item><term>UrgroshProficiency</term><description>d24f7545b1aa3b34e8216f8cb3140563</description></item>
    /// </list>
    /// </remarks>
    ///
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
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new PrerequisiteNotProficient();
      component.ArmorProficiencies = armorProficiencies;
      component.WeaponProficiencies = weaponProficiencies;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
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
    public TBuilder AddPrerequisiteParametrizedSpellFeature(
        Blueprint<BlueprintFeatureReference> feature,
        Blueprint<BlueprintAbilityReference> spell,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null)
    {
      var component = new PrerequisiteParametrizedFeature();
      component.m_Feature = feature?.Reference;
      component.m_Spell = spell?.Reference;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
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
    public TBuilder AddPrerequisiteParametrizedWeaponFeature(
        Blueprint<BlueprintFeatureReference> feature,
        WeaponCategory weaponCategory,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null)
    {
      var component = new PrerequisiteParametrizedFeature();
      component.m_Feature = feature?.Reference;
      component.WeaponCategory = weaponCategory;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
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
    public TBuilder AddPrerequisiteParametrizedSpellSchoolFeature(
        Blueprint<BlueprintFeatureReference> feature,
        SpellSchool spellSchool,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null)
    {
      var component = new PrerequisiteParametrizedFeature();
      component.m_Feature = feature?.Reference;
      component.SpellSchool = spellSchool;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
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
    public TBuilder AddPrerequisiteParametrizedWeaponSubcategory(
        Blueprint<BlueprintFeatureReference> feature,
        WeaponSubCategory subCategory,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null)
    {
      var component = new PrerequisiteParametrizedWeaponSubcategory();
      component.m_Feature = feature?.Reference;
      component.SubCategory = subCategory;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
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
    public TBuilder AddPrerequisiteIsPet(
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? not = null)
    {
      var component = new PrerequisiteIsPet();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
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
    public TBuilder AddPrerequisitePlayerHasFeature(
        Blueprint<BlueprintFeatureReference> feature,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null)
    {
      var component = new PrerequisitePlayerHasFeature();
      component.m_Feature = feature?.Reference;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
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
    /// <item><term>HellknightClass</term><description>ed246f1680e667b47b7427d51e651059</description></item>
    /// <item><term>SwordlordClass</term><description>90e4d7da3ccd1a8478411e07e91d5750</description></item>
    /// </list>
    /// </remarks>
    ///
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
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new PrerequisiteProficiency();
      component.ArmorProficiencies = armorProficiencies;
      component.WeaponProficiencies = weaponProficiencies;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
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
    /// <item><term>ImprovedCriticalKukri</term><description>45482376f0d543a4d9ba1aa6b78c9c0a</description></item>
    /// <item><term>WinterWitchClass</term><description>eb24ca44debf6714aabe1af1fd905a07</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddPrerequisiteStatValue(
        StatType stat,
        int value,
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null)
    {
      var component = new PrerequisiteStatValue();
      component.Stat = stat;
      component.Value = value;
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
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
    /// Adds <see cref="PrerequisiteCondition"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AeonMythicClass</term><description>15a85e67b7d69554cab9ed5830d0268e</description></item>
    /// <item><term>GoldenDragonClass</term><description>daf1235b6217787499c14e4e32142523</description></item>
    /// <item><term>SwarmThatWalksClass</term><description>5295b8e13c2303f4c88bdb3d7760a757</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="uIText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder AddPrerequisiteCondition(
        bool? checkInProgression = null,
        Condition? condition = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        LocalString? uIText = null)
    {
      var component = new PrerequisiteCondition();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      Validate(condition);
      component.Condition = condition ?? component.Condition;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
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
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new PrerequisiteMainCharacter();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Companion = companion ?? component.Companion;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
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
    /// <item><term>AnimalCompanionFeatureLeopard</term><description>2ee2ba60850dd064e8b98bf5c2c946ba</description></item>
    /// <item><term>MythicalBeastMaster</term><description>89096871a6fdadd43ad31f5046696727</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddPrerequisitePet(
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        bool? noCompanion = null,
        PetType? type = null)
    {
      var component = new PrerequisitePet();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
      component.NoCompanion = noCompanion ?? component.NoCompanion;
      component.Type = type ?? component.Type;
      return AddComponent(component);
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
    public TBuilder AddPrerequisiteFullStatValue(
        bool? checkInProgression = null,
        Prerequisite.GroupType? group = null,
        bool? hideInUI = null,
        StatType? stat = null,
        int? value = null)
    {
      var component = new PrerequisiteFullStatValue();
      component.CheckInProgression = checkInProgression ?? component.CheckInProgression;
      component.Group = group ?? component.Group;
      component.HideInUI = hideInUI ?? component.HideInUI;
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
      if (Blueprint.m_ReplaceSpellbook is null)
      {
        Blueprint.m_ReplaceSpellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(null);
      }
      if (Blueprint.AddFeatures is null)
      {
        Blueprint.AddFeatures = new LevelEntry[0];
      }
      if (Blueprint.RemoveFeatures is null)
      {
        Blueprint.RemoveFeatures = new LevelEntry[0];
      }
      if (Blueprint.m_StartingItems is null)
      {
        Blueprint.m_StartingItems = new BlueprintItemReference[0];
      }
      if (Blueprint.ClassSkills is null)
      {
        Blueprint.ClassSkills = new StatType[0];
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
    }
  }
}
