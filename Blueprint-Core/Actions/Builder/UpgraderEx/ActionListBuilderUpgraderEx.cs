using System.Linq;
using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Persistence.Versioning.PlayerUpgraderOnlyActions;
using Kingmaker.EntitySystem.Persistence.Versioning.UnitUpgraderOnlyActions;
using Kingmaker.EntitySystem.Persistence.Versioning.UpgraderOnlyActions;

namespace BlueprintCore.Actions.Builder.UpgraderEx
{
  /** Extension to ActionListBuilder for all UpgraderOnlyActions/ */
  public static class ActionListBuilderUpgraderEx
  {
    //----- Kingmaker.EntitySystem.Persistence.Versioning.*UpgraderOnlyActions -----//

    /**
     * AddFactIfEtudePlaying
     *
     * @param fact BlueprintUnitFact
     * @param etude BlueprintEtude
     */
    public static ActionListBuilder AddFactIfEtudePlaying(
        this ActionListBuilder builder,
        AddFactIfEtudePlaying.TargetType target,
        string fact,
        string etude)
    {
      var addFact = ElementTool.Create<AddFactIfEtudePlaying>();
      addFact.m_Target = target;
      addFact.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(fact);
      addFact.m_Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(etude);
      return builder.Add(addFact);
    }

    /** FixKingdomSystemBuffsAndStats */
    public static ActionListBuilder FixKingdomSystemBuffsAndStats(
        this ActionListBuilder builder,
        float? statPerFinances = null,
        float? statPerMaterials = null,
        float? statPerFavors = null,
        float? expDiplomacyCoefficient = null,
        float? diplomacyBonusCoefficient = null)
    {
      var fix = ElementTool.Create<FixKingdomSystemBuffsAndStats>();
      fix.m_StatPerFinances =
          statPerFinances is null ? fix.m_StatPerFinances : statPerFinances.Value;
      fix.m_StatPerMaterials =
          statPerMaterials is null ? fix.m_StatPerMaterials : statPerMaterials.Value;
      fix.m_StatPerFavors =
          statPerFavors is null ? fix.m_StatPerFavors : statPerFavors.Value;
      fix.m_UnitExpDiplomacyCoefficient =
          expDiplomacyCoefficient is null
              ? fix.m_UnitExpDiplomacyCoefficient
              : expDiplomacyCoefficient.Value;
      fix.m_DiplomacyBonusCoefficient =
          diplomacyBonusCoefficient is null
              ? fix.m_DiplomacyBonusCoefficient
              : diplomacyBonusCoefficient.Value;
      return builder.Add(fix);
    }

    /** ReenterScriptzone */
    public static ActionListBuilder ReEnterScriptZone(
        this ActionListBuilder builder, EntityReference scriptZone)
    {
      var reEnter = ElementTool.Create<ReenterScriptzone>();
      reEnter.m_ScriptZone = scriptZone;
      return builder.Add(reEnter);
    }

    /** RefreshCrusadeLogistic */
    public static ActionListBuilder RefreshCrusadeLogistic(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<RefreshCrusadeLogistic>());
    }

    /** RefreshSettingsPreset */
    public static ActionListBuilder RefreshSettingsPreset(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<RefreshSettingsPreset>());
    }

    /**
     * PlayerUpgraderOnlyActions.RemoveFact
     *
     * @param fact BlueprintUnitFact
     * @param ignoreFacts BlueprintUnitFact If the target has any of these facts, fact is not
     *   removed.
     */
    public static ActionListBuilder RemoveFact(
        this ActionListBuilder builder,
        string fact,
        params string[] ignoreFacts)
    {
      var removeFact = ElementTool.Create<RemoveFact>();
      removeFact.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(fact);
      removeFact.m_AdditionalExceptHasFacts =
          ignoreFacts
              .Select(ignore => BlueprintTool.GetRef<BlueprintUnitFactReference>(ignore))
              .ToArray();
      removeFact.m_ExceptHasFact =
          BlueprintReferenceBase.CreateTyped<BlueprintUnitFactReference>(null);
      return builder.Add(removeFact);
    }

    /** ResetMinDifficulty */
    public static ActionListBuilder ResetMinDifficulty(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ResetMinDifficulty>());
    }

    /**
     * FixItemInInventory
     *
     * @param addItem BlueprintItem
     * @param removeItem BlueprintItem
     */
    public static ActionListBuilder FixItemInInventory(
        this ActionListBuilder builder,
        string addItem = null,
        string removeItem = null,
        bool equipItem = false)
    {
      var fix = ElementTool.Create<FixItemInInventory>();
      fix.m_ToAdd = BlueprintTool.GetRef<BlueprintItemReference>(addItem);
      fix.m_ToRemove = BlueprintTool.GetRef<BlueprintItemReference>(removeItem);
      fix.m_TryEquip = equipItem;
      return builder.Add(fix);
    }

    /** RecreateOnLoad */
    public static ActionListBuilder ReCreateOnLoad(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<RecreateOnLoad>());
    }

    /** SetAlignmentFromBlueprint */
    public static ActionListBuilder SetAlignmentFromBlueprint(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<SetAlignmentFromBlueprint>());
    }

    /** SetHandsFromBlueprint */
    public static ActionListBuilder SetHandsFromBlueprint(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<SetHandsFromBlueprint>());
    }

    /**
     * AddFeatureFromProgression
     *
     * @param feature BlueprintFeature
     * @param progression BlueprintProgression
     * @param archetype BlueprintArchetype
     * @param selection BlueprintFeatureSelection
     * @param ignoreFeature BlueprintFeature
     */
    public static ActionListBuilder AddFeatureFromProgression(
        this ActionListBuilder builder,
        string feature,
        string progression,
        int level,
        string archetype = null,
        string selection = null,
        string ignoreFeature = null)
    {
      var addFeature = ElementTool.Create<AddFeatureFromProgression>();
      addFeature.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      addFeature.m_Progression = BlueprintTool.GetRef<BlueprintProgressionReference>(progression);
      addFeature.m_Level = level;
      addFeature.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype);
      addFeature.m_Selection =
          BlueprintTool.GetRef<BlueprintFeatureSelectionReference>(selection);
      addFeature.m_ExceptHasFeature =
          BlueprintTool.GetRef<BlueprintFeatureReference>(ignoreFeature);
      return builder.Add(addFeature);
    }

    /**
     * RecheckEtude
     *
     * @param etude BlueprintEtude
     */
    public static ActionListBuilder ReCheckEtude(
        this ActionListBuilder builder, string etude, bool redoAfterTrigger = false)
    {
      var reCheck = ElementTool.Create<RecheckEtude>();
      reCheck.Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(etude);
      reCheck.m_RedoOnceTriggers = redoAfterTrigger;
      return builder.Add(reCheck);
    }

    /** RefreshAllArmyLeaders */
    public static ActionListBuilder RefreshAllArmyLeaders(
        this ActionListBuilder builder, bool playerOnly = false)
    {
      var refresh = ElementTool.Create<RefreshAllArmyLeaders>();
      refresh.m_OnlyPlayerLeaders = playerOnly;
      return builder.Add(refresh);
    }

    /**
     * RemoveFeatureFromProgression
     *
     * @param feature BlueprintFeature
     * @param progression BlueprintProgression
     * @param archetype BlueprintArchetype
     * @param ignoreFeature BlueprintFeature
     */
    public static ActionListBuilder RemoveFeatureFromProgression(
        this ActionListBuilder builder,
        string feature,
        string progression,
        int level,
        string archetype = null,
        string ignoreFeature = null)
    {
      var removeFeature = ElementTool.Create<RemoveFeatureFromProgression>();
      removeFeature.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      removeFeature.m_Progression =
          BlueprintTool.GetRef<BlueprintProgressionReference>(progression);
      removeFeature.m_Level = level;
      removeFeature.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype);
      removeFeature.m_ExceptHasFeature =
          BlueprintTool.GetRef<BlueprintFeatureReference>(ignoreFeature);
      return builder.Add(removeFeature);
    }

    /**
     * ReplaceFeature
     *
     * @param oldFeature BlueprintFeature
     * @param newFeature BlueprintFeature
     * @param progression BlueprintProgression
     * @param ignoreFeature BlueprintFeature
     */
    public static ActionListBuilder ReplaceFeature(
        this ActionListBuilder builder,
        string oldFeature,
        string newFeature,
        string progression,
        string ignoreFeature = null)
    {
      var replaceFeature = ElementTool.Create<ReplaceFeature>();
      replaceFeature.m_ToReplace = BlueprintTool.GetRef<BlueprintFeatureReference>(oldFeature);
      replaceFeature.m_Replacement = BlueprintTool.GetRef<BlueprintFeatureReference>(newFeature);
      replaceFeature.m_FromProgression =
          BlueprintTool.GetRef<BlueprintProgressionReference>(progression);
      replaceFeature.m_ExceptHasFeature =
          BlueprintTool.GetRef<BlueprintFeatureReference>(ignoreFeature);
      return builder.Add(replaceFeature);
    }

    /** RestartTacticalCombat */
    public static ActionListBuilder RestartTacticalCombat(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<RestartTacticalCombat>());
    }

    /**
     * SetSharedVendorTable
     * 
     * @param table BlueprintSharedVendorTable
     */
    public static ActionListBuilder SetSharedVendorTable(
        this ActionListBuilder builder, string table, UnitEvaluator unit)
    {
      builder.Validate(unit);

      var setVendorTable = new SetSharedVendorTable(unit);
      ElementTool.Init(setVendorTable);
      setVendorTable.m_Table = BlueprintTool.GetRef<BlueprintSharedVendorTableReference>(table);
      setVendorTable.m_Unit = unit;
      return builder.Add(setVendorTable);
    }

    /**
     * StartEtudeForced
     *
     * @param etude BlueprintEtude
     */
    public static ActionListBuilder ForceStartEtude(this ActionListBuilder builder, string etude)
    {
      var startEtude = ElementTool.Create<StartEtudeForced>();
      startEtude.Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(etude);
      return builder.Add(startEtude);
    }

    /**
     * UnStartEtude
     *
     * @param etude BlueprintEtude
     */
    public static ActionListBuilder UnStartEtude(this ActionListBuilder builder, string etude)
    {
      var unStartEtude = ElementTool.Create<UnStartEtude>();
      unStartEtude.Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(etude);
      return builder.Add(unStartEtude);
    }
  }
}