//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items;
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-250474</term><description>6b018edaeb5648b8a1cf4bc75bd81a9d</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="fact">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder AddFactIfEtudePlaying(
        this ActionsBuilder builder,
        Blueprint<BlueprintEtude, BlueprintEtudeReference> etude,
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference> fact,
        AddFactIfEtudePlaying.TargetType target)
    {
      var element = ElementTool.Create<AddFactIfEtudePlaying>();
      element.m_Etude = etude?.Reference;
      element.m_Fact = fact?.Reference;
      element.m_Target = target;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureFromProgression"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-167761</term><description>3d8d382f1c7042e2b9ffe1af00ce2c56</description></item>
    /// <item><term>PF-341704</term><description>e4782857b49f40fc903acef39d3f7424</description></item>
    /// <item><term>PF-382795</term><description>10ceeab987b44bdb848e172f0994b99a</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="progression">
    /// <para>
    /// Blueprint of type BlueprintProgression. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="archetype">
    /// <para>
    /// Blueprint of type BlueprintArchetype. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="exceptHasFeature">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="originalProgression">
    /// <para>
    /// Blueprint of type BlueprintProgression. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="selection">
    /// <para>
    /// Blueprint of type BlueprintFeatureSelection. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder AddFeatureFromProgression(
        this ActionsBuilder builder,
        Blueprint<BlueprintFeature, BlueprintFeatureReference> feature,
        int level,
        Blueprint<BlueprintProgression, BlueprintProgressionReference> progression,
        Blueprint<BlueprintArchetype, BlueprintArchetypeReference>? archetype = null,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? exceptHasFeature = null,
        Blueprint<BlueprintProgression, BlueprintProgressionReference>? originalProgression = null,
        bool? rankUpOnly = null,
        Blueprint<BlueprintFeatureSelection, BlueprintFeatureSelectionReference>? selection = null)
    {
      var element = ElementTool.Create<AddFeatureFromProgression>();
      element.m_Feature = feature?.Reference;
      element.m_Level = level;
      element.m_Progression = progression?.Reference;
      element.m_Archetype = archetype?.Reference ?? element.m_Archetype;
      if (element.m_Archetype is null)
      {
        element.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(null);
      }
      element.m_ExceptHasFeature = exceptHasFeature?.Reference ?? element.m_ExceptHasFeature;
      if (element.m_ExceptHasFeature is null)
      {
        element.m_ExceptHasFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      element.m_OriginalProgression = originalProgression?.Reference ?? element.m_OriginalProgression;
      if (element.m_OriginalProgression is null)
      {
        element.m_OriginalProgression = BlueprintTool.GetRef<BlueprintProgressionReference>(null);
      }
      element.m_RankUpOnly = rankUpOnly ?? element.m_RankUpOnly;
      element.m_Selection = selection?.Reference ?? element.m_Selection;
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
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-232797</term><description>8880aef0a10e454bbaf115db5698045d</description></item>
    /// <item><term>PF-347507</term><description>0a6c3a124c04409ca38e077272557c7a</description></item>
    /// <item><term>PF-410416_VendorMerge</term><description>32d2892e1a554f328fcb2ef8f2ed54c6</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder RecheckEtude(
        this ActionsBuilder builder,
        Blueprint<BlueprintEtude, BlueprintEtudeReference> etude,
        bool? redoOnceTriggers = null)
    {
      var element = ElementTool.Create<RecheckEtude>();
      element.Etude = etude?.Reference;
      element.m_RedoOnceTriggers = redoOnceTriggers ?? element.m_RedoOnceTriggers;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ReenterScriptzone"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-256463</term><description>e34b8e62a2504a5ca5b84c689ba2a799</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder ReenterScriptzone(
        this ActionsBuilder builder,
        EntityReference scriptZone)
    {
      var element = ElementTool.Create<ReenterScriptzone>();
      builder.Validate(scriptZone);
      element.m_ScriptZone = scriptZone;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveFact"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-220021_NegativeEnergyAffinityDhampir</term><description>8d6a65a9774e4cbbbbd71f6547139b1b</description></item>
    /// <item><term>PF-256029</term><description>21c80029f09f46c89ee4ec36d0deea37</description></item>
    /// <item><term>PF-402644</term><description>bc8586d9cda14137a66c82b601092132</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="fact">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="exceptHasFacts">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// <para>
    /// If the target has any of these facts then the fact is not removed.
    /// </para>
    /// </param>
    /// <param name="exceptHasFact">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder RemoveFact(
        this ActionsBuilder builder,
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference> fact,
        List<Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>>? exceptHasFacts = null,
        bool? excludeExCompanions = null)
    {
      var element = ElementTool.Create<RemoveFact>();
      element.m_Fact = fact?.Reference;
      element.m_AdditionalExceptHasFacts = exceptHasFacts?.Select(bp => bp.Reference)?.ToArray() ?? element.m_AdditionalExceptHasFacts;
      if (element.m_AdditionalExceptHasFacts is null)
      {
        element.m_AdditionalExceptHasFacts = new BlueprintUnitFactReference[0];
      }
      element.m_ExcludeExCompanions = excludeExCompanions ?? element.m_ExcludeExCompanions;
      element.m_ExceptHasFact = BlueprintReferenceBase.CreateTyped<BlueprintUnitFactReference>(null);
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RemoveFeatureFromProgression"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-111273</term><description>344ce9c06961426f95c109ce243d8c35</description></item>
    /// <item><term>PF-339343</term><description>adc22eb66c2f43798c9824ac05fb60f4</description></item>
    /// <item><term>PF-96002</term><description>eb741196d9ce49768ca5adac488f65ef</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="progression">
    /// <para>
    /// Blueprint of type BlueprintProgression. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="archetype">
    /// <para>
    /// Blueprint of type BlueprintArchetype. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="exceptHasFeature">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder RemoveFeatureFromProgression(
        this ActionsBuilder builder,
        Blueprint<BlueprintFeature, BlueprintFeatureReference> feature,
        int level,
        Blueprint<BlueprintProgression, BlueprintProgressionReference> progression,
        Blueprint<BlueprintArchetype, BlueprintArchetypeReference>? archetype = null,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? exceptHasFeature = null)
    {
      var element = ElementTool.Create<RemoveFeatureFromProgression>();
      element.m_Feature = feature?.Reference;
      element.m_Level = level;
      element.m_Progression = progression?.Reference;
      element.m_Archetype = archetype?.Reference ?? element.m_Archetype;
      if (element.m_Archetype is null)
      {
        element.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(null);
      }
      element.m_ExceptHasFeature = exceptHasFeature?.Reference ?? element.m_ExceptHasFeature;
      if (element.m_ExceptHasFeature is null)
      {
        element.m_ExceptHasFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ReplaceFeature"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-191269</term><description>90edf140bf514ebaa3fff74c4f576e4d</description></item>
    /// <item><term>PF-382275</term><description>50ad5ea849874e8abd47f0e5a088119c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="fromProgression">
    /// <para>
    /// Blueprint of type BlueprintProgression. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="replacement">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="toReplace">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="exceptHasFeature">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="targetPartyUnit">
    /// <para>
    /// InfoBox: Checks in Blueprint and OriginalBlueprint
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder ReplaceFeature(
        this ActionsBuilder builder,
        Blueprint<BlueprintProgression, BlueprintProgressionReference> fromProgression,
        Blueprint<BlueprintFeature, BlueprintFeatureReference> replacement,
        Blueprint<BlueprintFeature, BlueprintFeatureReference> toReplace,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? exceptHasFeature = null,
        Blueprint<BlueprintUnit, BlueprintUnitReference>? targetPartyUnit = null)
    {
      var element = ElementTool.Create<ReplaceFeature>();
      element.m_FromProgression = fromProgression?.Reference;
      element.m_Replacement = replacement?.Reference;
      element.m_ToReplace = toReplace?.Reference;
      element.m_ExceptHasFeature = exceptHasFeature?.Reference ?? element.m_ExceptHasFeature;
      if (element.m_ExceptHasFeature is null)
      {
        element.m_ExceptHasFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      element.m_TargetPartyUnit = targetPartyUnit?.Reference ?? element.m_TargetPartyUnit;
      if (element.m_TargetPartyUnit is null)
      {
        element.m_TargetPartyUnit = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="StartEtudeForced"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-222018</term><description>c9d5dee61d1b4587b99da9caa3e238df</description></item>
    /// <item><term>PF-302757</term><description>dfa8f27b512d479eb53c1cca12ee6ff2</description></item>
    /// <item><term>PF-371696</term><description>a0f733cee766493abdc9af254028d9ed</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder StartEtudeForced(
        this ActionsBuilder builder,
        Blueprint<BlueprintEtude, BlueprintEtudeReference> etude)
    {
      var element = ElementTool.Create<StartEtudeForced>();
      element.Etude = etude?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="UnStartEtude"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-215564</term><description>185be5e1ae964cee94428816eec0d210</description></item>
    /// <item><term>PF-302757</term><description>dfa8f27b512d479eb53c1cca12ee6ff2</description></item>
    /// <item><term>PF-382355</term><description>b7415799a01c43b7b1e1c5d7c908c590</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder UnStartEtude(
        this ActionsBuilder builder,
        Blueprint<BlueprintEtude, BlueprintEtudeReference> etude)
    {
      var element = ElementTool.Create<UnStartEtude>();
      element.Etude = etude?.Reference;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="FixItemInInventory"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>UpgradeUnitRobe2ST2DC</term><description>0da99f59dbfc45b49864819a5ad0c3ec</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="toAdd">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="toRemove">
    /// <para>
    /// InfoBox: If both ToRemove and ToAdd specified but ToRemove is missing in unit's inventory then ToAdd will be ignored
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder FixItemInInventory(
        this ActionsBuilder builder,
        Blueprint<BlueprintItem, BlueprintItemReference>? toAdd = null,
        Blueprint<BlueprintItem, BlueprintItemReference>? toRemove = null,
        bool? tryEquip = null)
    {
      var element = ElementTool.Create<FixItemInInventory>();
      element.m_ToAdd = toAdd?.Reference ?? element.m_ToAdd;
      if (element.m_ToAdd is null)
      {
        element.m_ToAdd = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      element.m_ToRemove = toRemove?.Reference ?? element.m_ToRemove;
      if (element.m_ToRemove is null)
      {
        element.m_ToRemove = BlueprintTool.GetRef<BlueprintItemReference>(null);
      }
      element.m_TryEquip = tryEquip ?? element.m_TryEquip;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="FixKingdomSystemBuffsAndStats"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-286829</term><description>df6f796cc0db48759597d141966b1716</description></item>
    /// </list>
    /// </remarks>
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
    /// Adds <see cref="RecreateOnLoad"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-229479-RecreateAreshkagalOnLoad</term><description>c048cb6cb12c4c578c312cf1ea5ebdce</description></item>
    /// <item><term>PF-296345-RecreateHalDragonOnLoad</term><description>aaf834dd2d2c4348a52de842606ecaad</description></item>
    /// <item><term>PF-340663-RecreateUnitOnLoad</term><description>0a013e4bab2b456fbd9a265fd32907b2</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder RecreateOnLoad(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<RecreateOnLoad>());
    }

    /// <summary>
    /// Adds <see cref="RefreshAllArmyLeaders"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-216784</term><description>2b453fa01f4b47e69abf6bf61352dff1</description></item>
    /// <item><term>PF-235722</term><description>c64fce5d41d74a468f908d33617c5a62</description></item>
    /// <item><term>PF-296174</term><description>6f556fe66d644f75bc4ec553dd580959</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder RefreshAllArmyLeaders(
        this ActionsBuilder builder,
        bool? onlyPlayerLeaders = null)
    {
      var element = ElementTool.Create<RefreshAllArmyLeaders>();
      element.m_OnlyPlayerLeaders = onlyPlayerLeaders ?? element.m_OnlyPlayerLeaders;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RefreshArmyLeadersBaseSkills"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-295767</term><description>37ded483ce8b44fca06c9ede0ac044d9</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder RefreshArmyLeadersBaseSkills(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<RefreshArmyLeadersBaseSkills>());
    }

    /// <summary>
    /// Adds <see cref="RefreshCrusadeLogistic"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-275768</term><description>635a86098ddd4e7a971e07c3b09fd57a</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder RefreshCrusadeLogistic(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<RefreshCrusadeLogistic>());
    }

    /// <summary>
    /// Adds <see cref="RefreshSettingsPreset"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-291798</term><description>3f4a0892916849f99a0364602d56e4db</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder RefreshSettingsPreset(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<RefreshSettingsPreset>());
    }

    /// <summary>
    /// Adds <see cref="RemoveBrokenSummon"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-359232-RemoveBrokenSummonOnLoad</term><description>2fc8c3f9bc904d8a82daa72d844dbed2</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder RemoveBrokenSummon(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<RemoveBrokenSummon>());
    }

    /// <summary>
    /// Adds <see cref="RemoveSpell"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-219559</term><description>5cb21961e7b54c509e3de48c222c43da</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="spell">
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="spellbook">
    /// <para>
    /// InfoBox: Remove from all spellbooks if not specified
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintSpellbook. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder RemoveSpell(
        this ActionsBuilder builder,
        Blueprint<BlueprintAbility, BlueprintAbilityReference>? spell = null,
        Blueprint<BlueprintSpellbook, BlueprintSpellbookReference>? spellbook = null)
    {
      var element = ElementTool.Create<RemoveSpell>();
      element.m_Spell = spell?.Reference ?? element.m_Spell;
      if (element.m_Spell is null)
      {
        element.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      }
      element.m_Spellbook = spellbook?.Reference ?? element.m_Spellbook;
      if (element.m_Spellbook is null)
      {
        element.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="ResetMinDifficulty"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-265405_achivmentRestart</term><description>09080d78bd5e42f0bd3a0affe4485ca7</description></item>
    /// <item><term>PF-293765_achivmentRestart2</term><description>fe8e03885dba4489a79dd893fd0f96a6</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder ResetMinDifficulty(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ResetMinDifficulty>());
    }

    /// <summary>
    /// Adds <see cref="RespawnNewUnit"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-358900</term><description>9d2858bae0fe4c8495075117927c15a5</description></item>
    /// <item><term>PF-367341</term><description>8db934a9b811435a8181905f351ea17c</description></item>
    /// <item><term>PF-397133</term><description>8da361c37b9b4cf3a476a2fe532adccf</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="spawner">
    /// <para>
    /// InfoBox: Don't call this action if you dont understand what it's for
    /// </para>
    /// </param>
    public static ActionsBuilder RespawnNewUnit(
        this ActionsBuilder builder,
        EntityReference? spawner = null)
    {
      var element = ElementTool.Create<RespawnNewUnit>();
      builder.Validate(spawner);
      element.Spawner = spawner ?? element.Spawner;
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="RestartTacticalCombat"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-205596</term><description>2cb629a2c52642f1aa534fe3e9d5e6c5</description></item>
    /// <item><term>PF-327220</term><description>47356581fce64c9d8e764fe71583e42e</description></item>
    /// <item><term>PF-396865</term><description>9a91b3e879264dc6a98365f4bf79ad61</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder RestartTacticalCombat(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<RestartTacticalCombat>());
    }

    /// <summary>
    /// Adds <see cref="RestoreClassFeature"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-217882</term><description>b8f8b5021f9c4189a73f29573f39b70b</description></item>
    /// <item><term>PF-324729_RestoreSneakAttack</term><description>f90026a880c64f55ad602929dc969d89</description></item>
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
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder RestoreClassFeature(
        this ActionsBuilder builder,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? feature = null)
    {
      var element = ElementTool.Create<RestoreClassFeature>();
      element.m_Feature = feature?.Reference ?? element.m_Feature;
      if (element.m_Feature is null)
      {
        element.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      return builder.Add(element);
    }

    /// <summary>
    /// Adds <see cref="SetHandsFromBlueprint"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>UpgradeUnitPrimarySecondaryWeapons</term><description>9bb96c963f0f47f48e51aabb6c8ac4ff</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder SetHandsFromBlueprint(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<SetHandsFromBlueprint>());
    }

    /// <summary>
    /// Adds <see cref="SetRaceFromBlueprint"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-365247-EvilArueshalae_Companion</term><description>083640c167934d068db623f75474afe3</description></item>
    /// <item><term>UpgradeUnitRace</term><description>bf93ee9fb7f34b17a9a25e50ada648e4</description></item>
    /// </list>
    /// </remarks>
    public static ActionsBuilder SetRaceFromBlueprint(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<SetRaceFromBlueprint>());
    }

    /// <summary>
    /// Adds <see cref="UpdateProgression"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>PF-342714</term><description>9628f4a2db9c4a04842e2c9eb1c2e7a6</description></item>
    /// <item><term>PF-350132</term><description>41516d0e02344c08b5eb7c0e7bd3bc63</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="progression">
    /// <para>
    /// Blueprint of type BlueprintProgression. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public static ActionsBuilder UpdateProgression(
        this ActionsBuilder builder,
        Blueprint<BlueprintProgression, BlueprintProgressionReference>? progression = null)
    {
      var element = ElementTool.Create<UpdateProgression>();
      element.m_Progression = progression?.Reference ?? element.m_Progression;
      if (element.m_Progression is null)
      {
        element.m_Progression = BlueprintTool.GetRef<BlueprintProgressionReference>(null);
      }
      return builder.Add(element);
    }
  }
}
