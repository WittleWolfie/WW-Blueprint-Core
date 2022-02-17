//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Persistence.Versioning.PlayerUpgraderOnlyActions;
using Kingmaker.EntitySystem.Persistence.Versioning.UnitUpgraderOnlyActions;
using Kingmaker.EntitySystem.Persistence.Versioning.UpgraderOnlyActions;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System.Collections.Generic;
using System.Linq;
namespace BlueprintCore.Actions.Builder.UpgraderEx
{
  /// <summary>
  /// Extension to <see cref="ActionsBuilder"/> for all UpgraderOnlyActions.
  /// </summary>
  /// <inheritdoc cref="ActionsBuilder"/>
  public static class ActionsBuilderUpgraderEx
{

    /// <summary>
    /// Adds <see cref="AddFactIfEtudePlaying"/>
    /// </summary>
    ///
    /// <param name="etude">
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="fact">
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder AddFactIfEtudePlaying(
        this ActionsBuilder builder,
        Blueprint<BlueprintEtude, BlueprintEtudeReference>? etude = null,
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>? fact = null,
        AddFactIfEtudePlaying.TargetType? target = null)
    {
      var element = ElementTool.Create<AddFactIfEtudePlaying>();
      element.m_Etude = etude.Reference ?? element.m_Etude;
      if (element.m_Etude is null)
      {
        element.m_Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(null);
      }
      element.m_Fact = fact.Reference ?? element.m_Fact;
      if (element.m_Fact is null)
      {
        element.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      element.m_Target = target ?? element.m_Target;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="FixKingdomSystemBuffsAndStats"/>
    /// </summary>
    public static ActionsBuilder FixKingdomSystemBuffsAndStats(
        this ActionsBuilder builder,
        float? diplomacyBonusCoefficient = null,
        float? statPerFavors = null,
        float? statPerFinances = null,
        float? statPerMaterials = null,
        float? unitExpDiplomacyCoefficient = null)
    {
      var element = ElementTool.Create<FixKingdomSystemBuffsAndStats>();
      element.m_DiplomacyBonusCoefficient = diplomacyBonusCoefficient ?? element.m_DiplomacyBonusCoefficient;
      element.m_StatPerFavors = statPerFavors ?? element.m_StatPerFavors;
      element.m_StatPerFinances = statPerFinances ?? element.m_StatPerFinances;
      element.m_StatPerMaterials = statPerMaterials ?? element.m_StatPerMaterials;
      element.m_UnitExpDiplomacyCoefficient = unitExpDiplomacyCoefficient ?? element.m_UnitExpDiplomacyCoefficient;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ReenterScriptzone"/>
    /// </summary>
    public static ActionsBuilder ReenterScriptzone(
        this ActionsBuilder builder,
        EntityReference? scriptZone = null)
    {
      var element = ElementTool.Create<ReenterScriptzone>();
      builder.Validate(scriptZone);
      element.m_ScriptZone = scriptZone ?? element.m_ScriptZone;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveFact"/>
    /// </summary>
    ///
    /// <param name="additionalExceptHasFacts">
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="exceptHasFact">
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="fact">
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RemoveFact(
        this ActionsBuilder builder,
        List<Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>>? additionalExceptHasFacts = null,
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>? exceptHasFact = null,
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>? fact = null)
    {
      var element = ElementTool.Create<RemoveFact>();
      element.m_AdditionalExceptHasFacts = additionalExceptHasFacts.Select(bp => bp.Reference).ToArray() ?? element.m_AdditionalExceptHasFacts;
      if (element.m_AdditionalExceptHasFacts is null)
      {
        element.m_AdditionalExceptHasFacts = new BlueprintUnitFactReference[0];
      }
      element.m_ExceptHasFact = exceptHasFact.Reference ?? element.m_ExceptHasFact;
      if (element.m_ExceptHasFact is null)
      {
        element.m_ExceptHasFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      element.m_Fact = fact.Reference ?? element.m_Fact;
      if (element.m_Fact is null)
      {
        element.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RefreshCrusadeLogistic"/>
    /// </summary>
    public static ActionsBuilder RefreshCrusadeLogistic(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<RefreshCrusadeLogistic>());
    }

    /// <summary>
    /// Adds <see cref="RefreshSettingsPreset"/>
    /// </summary>
    public static ActionsBuilder RefreshSettingsPreset(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<RefreshSettingsPreset>());
    }

    /// <summary>
    /// Adds <see cref="RemoveSpell"/>
    /// </summary>
    ///
    /// <param name="spell">
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="spellbook">
    /// Blueprint of type BlueprintSpellbook. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RemoveSpell(
        this ActionsBuilder builder,
        Blueprint<BlueprintAbility, BlueprintAbilityReference>? spell = null,
        Blueprint<BlueprintSpellbook, BlueprintSpellbookReference>? spellbook = null)
    {
      var element = ElementTool.Create<RemoveSpell>();
      element.m_Spell = spell.Reference ?? element.m_Spell;
      if (element.m_Spell is null)
      {
        element.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      }
      element.m_Spellbook = spellbook.Reference ?? element.m_Spellbook;
      if (element.m_Spellbook is null)
      {
        element.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ResetMinDifficulty"/>
    /// </summary>
    public static ActionsBuilder ResetMinDifficulty(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ResetMinDifficulty>());
    }

    /// <summary>
    /// Adds <see cref="RestoreClassFeature"/>
    /// </summary>
    ///
    /// <param name="feature">
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RestoreClassFeature(
        this ActionsBuilder builder,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? feature = null)
    {
      var element = ElementTool.Create<RestoreClassFeature>();
      element.m_Feature = feature.Reference ?? element.m_Feature;
      if (element.m_Feature is null)
      {
        element.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="FixItemInInventory"/>
    /// </summary>
    ///
    /// <param name="toAdd">
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="toRemove">
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder FixItemInInventory(
        this ActionsBuilder builder,
        Blueprint<BlueprintItem, BlueprintItemReference>? toAdd = null,
        Blueprint<BlueprintItem, BlueprintItemReference>? toRemove = null,
        bool? tryEquip = null)
    {
      var element = ElementTool.Create<FixItemInInventory>();
      element.m_ToAdd = toAdd.Reference ?? element.m_ToAdd;
      if (element.m_ToAdd is null)
      {
        element.m_ToAdd = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      element.m_ToRemove = toRemove.Reference ?? element.m_ToRemove;
      if (element.m_ToRemove is null)
      {
        element.m_ToRemove = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      element.m_TryEquip = tryEquip ?? element.m_TryEquip;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RecreateOnLoad"/>
    /// </summary>
    public static ActionsBuilder RecreateOnLoad(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<RecreateOnLoad>());
    }

    /// <summary>
    /// Adds <see cref="SetAlignmentFromBlueprint"/>
    /// </summary>
    public static ActionsBuilder SetAlignmentFromBlueprint(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<SetAlignmentFromBlueprint>());
    }

    /// <summary>
    /// Adds <see cref="SetHandsFromBlueprint"/>
    /// </summary>
    public static ActionsBuilder SetHandsFromBlueprint(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<SetHandsFromBlueprint>());
    }

    /// <summary>
    /// Adds <see cref="SetRaceFromBlueprint"/>
    /// </summary>
    public static ActionsBuilder SetRaceFromBlueprint(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<SetRaceFromBlueprint>());
    }

    /// <summary>
    /// Adds <see cref="AddFeatureFromProgression"/>
    /// </summary>
    ///
    /// <param name="archetype">
    /// Blueprint of type BlueprintArchetype. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="exceptHasFeature">
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="feature">
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="originalProgression">
    /// Blueprint of type BlueprintProgression. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="progression">
    /// Blueprint of type BlueprintProgression. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="selection">
    /// Blueprint of type BlueprintFeatureSelection. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder AddFeatureFromProgression(
        this ActionsBuilder builder,
        Blueprint<BlueprintArchetype, BlueprintArchetypeReference>? archetype = null,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? exceptHasFeature = null,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? feature = null,
        int? level = null,
        Blueprint<BlueprintProgression, BlueprintProgressionReference>? originalProgression = null,
        Blueprint<BlueprintProgression, BlueprintProgressionReference>? progression = null,
        bool? rankUpOnly = null,
        Blueprint<BlueprintFeatureSelection, BlueprintFeatureSelectionReference>? selection = null)
    {
      var element = ElementTool.Create<AddFeatureFromProgression>();
      element.m_Archetype = archetype.Reference ?? element.m_Archetype;
      if (element.m_Archetype is null)
      {
        element.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(null);
      }
      element.m_ExceptHasFeature = exceptHasFeature.Reference ?? element.m_ExceptHasFeature;
      if (element.m_ExceptHasFeature is null)
      {
        element.m_ExceptHasFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      element.m_Feature = feature.Reference ?? element.m_Feature;
      if (element.m_Feature is null)
      {
        element.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      element.m_Level = level ?? element.m_Level;
      element.m_OriginalProgression = originalProgression.Reference ?? element.m_OriginalProgression;
      if (element.m_OriginalProgression is null)
      {
        element.m_OriginalProgression = BlueprintTool.GetRef<BlueprintProgressionReference>(null);
      }
      element.m_Progression = progression.Reference ?? element.m_Progression;
      if (element.m_Progression is null)
      {
        element.m_Progression = BlueprintTool.GetRef<BlueprintProgressionReference>(null);
      }
      element.m_RankUpOnly = rankUpOnly ?? element.m_RankUpOnly;
      element.m_Selection = selection.Reference ?? element.m_Selection;
      if (element.m_Selection is null)
      {
        element.m_Selection = BlueprintTool.GetRef<BlueprintFeatureSelectionReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RecheckEtude"/>
    /// </summary>
    ///
    /// <param name="etude">
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RecheckEtude(
        this ActionsBuilder builder,
        Blueprint<BlueprintEtude, BlueprintEtudeReference>? etude = null,
        bool? redoOnceTriggers = null)
    {
      var element = ElementTool.Create<RecheckEtude>();
      element.Etude = etude.Reference ?? element.Etude;
      if (element.Etude is null)
      {
        element.Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(null);
      }
      element.m_RedoOnceTriggers = redoOnceTriggers ?? element.m_RedoOnceTriggers;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RefreshAllArmyLeaders"/>
    /// </summary>
    public static ActionsBuilder RefreshAllArmyLeaders(
        this ActionsBuilder builder,
        bool? onlyPlayerLeaders = null)
    {
      var element = ElementTool.Create<RefreshAllArmyLeaders>();
      element.m_OnlyPlayerLeaders = onlyPlayerLeaders ?? element.m_OnlyPlayerLeaders;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveFeatureFromProgression"/>
    /// </summary>
    ///
    /// <param name="archetype">
    /// Blueprint of type BlueprintArchetype. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="exceptHasFeature">
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="feature">
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="progression">
    /// Blueprint of type BlueprintProgression. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder RemoveFeatureFromProgression(
        this ActionsBuilder builder,
        Blueprint<BlueprintArchetype, BlueprintArchetypeReference>? archetype = null,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? exceptHasFeature = null,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? feature = null,
        int? level = null,
        Blueprint<BlueprintProgression, BlueprintProgressionReference>? progression = null)
    {
      var element = ElementTool.Create<RemoveFeatureFromProgression>();
      element.m_Archetype = archetype.Reference ?? element.m_Archetype;
      if (element.m_Archetype is null)
      {
        element.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(null);
      }
      element.m_ExceptHasFeature = exceptHasFeature.Reference ?? element.m_ExceptHasFeature;
      if (element.m_ExceptHasFeature is null)
      {
        element.m_ExceptHasFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      element.m_Feature = feature.Reference ?? element.m_Feature;
      if (element.m_Feature is null)
      {
        element.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      element.m_Level = level ?? element.m_Level;
      element.m_Progression = progression.Reference ?? element.m_Progression;
      if (element.m_Progression is null)
      {
        element.m_Progression = BlueprintTool.GetRef<BlueprintProgressionReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ReplaceFeature"/>
    /// </summary>
    ///
    /// <param name="exceptHasFeature">
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="fromProgression">
    /// Blueprint of type BlueprintProgression. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="replacement">
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="targetPartyUnit">
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    ///
    /// <param name="toReplace">
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder ReplaceFeature(
        this ActionsBuilder builder,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? exceptHasFeature = null,
        Blueprint<BlueprintProgression, BlueprintProgressionReference>? fromProgression = null,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? replacement = null,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? targetPartyUnit = null,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? toReplace = null)
    {
      var element = ElementTool.Create<ReplaceFeature>();
      element.m_ExceptHasFeature = exceptHasFeature.Reference ?? element.m_ExceptHasFeature;
      if (element.m_ExceptHasFeature is null)
      {
        element.m_ExceptHasFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      element.m_FromProgression = fromProgression.Reference ?? element.m_FromProgression;
      if (element.m_FromProgression is null)
      {
        element.m_FromProgression = BlueprintTool.GetRef<BlueprintProgressionReference>(null);
      }
      element.m_Replacement = replacement.Reference ?? element.m_Replacement;
      if (element.m_Replacement is null)
      {
        element.m_Replacement = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      element.m_TargetPartyUnit = targetPartyUnit.Reference ?? element.m_TargetPartyUnit;
      if (element.m_TargetPartyUnit is null)
      {
        element.m_TargetPartyUnit = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      element.m_ToReplace = toReplace.Reference ?? element.m_ToReplace;
      if (element.m_ToReplace is null)
      {
        element.m_ToReplace = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetSharedVendorTable"/>
    /// </summary>
    ///
    /// <param name="table">
    /// Blueprint of type BlueprintSharedVendorTable. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder SetSharedVendorTable(
        this ActionsBuilder builder,
        Blueprint<BlueprintSharedVendorTable, BlueprintSharedVendorTableReference>? table = null,
        UnitEvaluator? unit = null)
    {
      var element = ElementTool.Create<SetSharedVendorTable>();
      element.m_Table = table.Reference ?? element.m_Table;
      if (element.m_Table is null)
      {
        element.m_Table = BlueprintTool.GetRef<BlueprintSharedVendorTableReference>(null);
      }
      builder.Validate(unit);
      element.m_Unit = unit ?? element.m_Unit;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="StartEtudeForced"/>
    /// </summary>
    ///
    /// <param name="etude">
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder StartEtudeForced(
        this ActionsBuilder builder,
        Blueprint<BlueprintEtude, BlueprintEtudeReference>? etude = null)
    {
      var element = ElementTool.Create<StartEtudeForced>();
      element.Etude = etude.Reference ?? element.Etude;
      if (element.Etude is null)
      {
        element.Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnStartEtude"/>
    /// </summary>
    ///
    /// <param name="etude">
    /// Blueprint of type BlueprintEtude. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint">Blueprint</see> for more details.
    /// </param>
    public static ActionsBuilder UnStartEtude(
        this ActionsBuilder builder,
        Blueprint<BlueprintEtude, BlueprintEtudeReference>? etude = null)
    {
      var element = ElementTool.Create<UnStartEtude>();
      element.Etude = etude.Reference ?? element.Etude;
      if (element.Etude is null)
      {
        element.Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RestartTacticalCombat"/>
    /// </summary>
    public static ActionsBuilder RestartTacticalCombat(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<RestartTacticalCombat>());
    }
  }
}
