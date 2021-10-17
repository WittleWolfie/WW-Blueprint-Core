using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Persistence.Versioning.PlayerUpgraderOnlyActions;
using Kingmaker.EntitySystem.Persistence.Versioning.UnitUpgraderOnlyActions;
using Kingmaker.EntitySystem.Persistence.Versioning.UpgraderOnlyActions;
using System.Linq;

namespace BlueprintCore.Actions.Builder.UpgraderEx
{
  /// <summary>
  /// Extension to <see cref="ActionListBuilder"/> for all UpgraderOnlyActions.
  /// </summary>
  /// <inheritdoc cref="ActionListBuilder"/>
  public static class ActionListBuilderUpgraderEx
  {
    //----- Kingmaker.EntitySystem.Persistence.Versioning.*UpgraderOnlyActions -----//

    /// <summary>
    /// Adds <see cref="Kingmaker.EntitySystem.Persistence.Versioning.PlayerUpgraderOnlyActions.AddFactIfEtudePlaying">AddFactIfEtudePlaying</see>
    /// </summary>
    /// 
    /// <param name="fact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact">BlueprintUnitFact</see></param>
    /// <param name="etude"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude">BlueprintEtude</see></param>
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

    /// <summary>
    /// Adds <see cref="Kingmaker.EntitySystem.Persistence.Versioning.PlayerUpgraderOnlyActions.FixKingdomSystemBuffsAndStats">FixKingdomSystemBuffsAndStats</see>
    /// </summary>
    public static ActionListBuilder FixKingdomSystemBuffsAndStats(
        this ActionListBuilder builder,
        float? statPerFinances = null,
        float? statPerMaterials = null,
        float? statPerFavors = null,
        float? expDiplomacyCoefficient = null,
        float? diplomacyBonusCoefficient = null)
    {
      var fix = ElementTool.Create<FixKingdomSystemBuffsAndStats>();
      fix.m_StatPerFinances = statPerFinances is null ? fix.m_StatPerFinances : statPerFinances.Value;
      fix.m_StatPerMaterials = statPerMaterials is null ? fix.m_StatPerMaterials : statPerMaterials.Value;
      fix.m_StatPerFavors = statPerFavors is null ? fix.m_StatPerFavors : statPerFavors.Value;
      fix.m_UnitExpDiplomacyCoefficient =
          expDiplomacyCoefficient is null ? fix.m_UnitExpDiplomacyCoefficient : expDiplomacyCoefficient.Value;
      fix.m_DiplomacyBonusCoefficient =
          diplomacyBonusCoefficient is null ? fix.m_DiplomacyBonusCoefficient : diplomacyBonusCoefficient.Value;
      return builder.Add(fix);
    }

    /// <summary>
    /// Adds <see cref="ReenterScriptzone"/>
    /// </summary>
    public static ActionListBuilder ReEnterScriptZone(this ActionListBuilder builder, EntityReference scriptZone)
    {
      var reEnter = ElementTool.Create<ReenterScriptzone>();
      reEnter.m_ScriptZone = scriptZone;
      return builder.Add(reEnter);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.EntitySystem.Persistence.Versioning.PlayerUpgraderOnlyActions.RefreshCrusadeLogistic">RefreshCrusadeLogistic</see>
    /// </summary>
    public static ActionListBuilder RefreshCrusadeLogistic(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<RefreshCrusadeLogistic>());
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.EntitySystem.Persistence.Versioning.PlayerUpgraderOnlyActions.RefreshSettingsPreset">RefreshSettingsPreset</see>
    /// </summary>
    public static ActionListBuilder RefreshSettingsPreset(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<RefreshSettingsPreset>());
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.EntitySystem.Persistence.Versioning.PlayerUpgraderOnlyActions.RemoveFact">RemoveFact</see>
    /// </summary>
    /// 
    /// <param name="fact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact">BlueprintUnitFact</see></param>
    /// <param name="ignoreFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact">BlueprintUnitFact</see>
    /// If the target has any of these facts, the fact will not be removed.
    /// </param>
    public static ActionListBuilder RemoveFact(
        this ActionListBuilder builder,
        string fact,
        params string[] ignoreFacts)
    {
      var removeFact = ElementTool.Create<RemoveFact>();
      removeFact.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(fact);
      removeFact.m_AdditionalExceptHasFacts =
          ignoreFacts.Select(ignore => BlueprintTool.GetRef<BlueprintUnitFactReference>(ignore)).ToArray();
      removeFact.m_ExceptHasFact = BlueprintReferenceBase.CreateTyped<BlueprintUnitFactReference>(null);
      return builder.Add(removeFact);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.EntitySystem.Persistence.Versioning.PlayerUpgraderOnlyActions.ResetMinDifficulty">ResetMinDifficulty</see>
    /// </summary>
    public static ActionListBuilder ResetMinDifficulty(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<ResetMinDifficulty>());
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.EntitySystem.Persistence.Versioning.UnitUpgraderOnlyActions.FixItemInInventory">FixItemInInventory</see>
    /// </summary>
    /// 
    /// <param name="addItem"><see cref="Kingmaker.Blueprints.Items.BlueprintItem">BlueprintItem</see></param>
    /// <param name="removeItem"><see cref="Kingmaker.Blueprints.Items.BlueprintItem">BlueprintItem</see></param>
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

    /// <summary>
    /// Adds <see cref="RecreateOnLoad"/>
    /// </summary>
    public static ActionListBuilder ReCreateOnLoad(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<RecreateOnLoad>());
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.EntitySystem.Persistence.Versioning.UnitUpgraderOnlyActions.SetAlignmentFromBlueprint">SetAlignmentFromBlueprint</see>
    /// </summary>
    public static ActionListBuilder SetAlignmentFromBlueprint(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<SetAlignmentFromBlueprint>());
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.EntitySystem.Persistence.Versioning.UnitUpgraderOnlyActions.SetHandsFromBlueprint">SetHandsFromBlueprint</see>
    /// </summary>
    public static ActionListBuilder SetHandsFromBlueprint(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<SetHandsFromBlueprint>());
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.EntitySystem.Persistence.Versioning.UpgraderOnlyActions.AddFeatureFromProgression">AddFeatureFromProgression</see>
    /// </summary>
    /// 
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
    /// <param name="progression"><see cref="Kingmaker.Blueprints.Classes.BlueprintProgression">BlueprintProgression</see></param>
    /// <param name="archetype"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype">BlueprintArchetype</see></param>
    /// <param name="selection"><see cref="Kingmaker.Blueprints.Classes.Selection.BlueprintFeatureSelection">BlueprintFeatureSelection</see></param>
    /// <param name="ignoreFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
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
      addFeature.m_Selection = BlueprintTool.GetRef<BlueprintFeatureSelectionReference>(selection);
      addFeature.m_ExceptHasFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(ignoreFeature);
      return builder.Add(addFeature);
    }

    /// <summary>
    /// Adds <see cref="RecheckEtude"/>
    /// </summary>
    /// 
    /// <param name="etude"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude">BlueprintEtude</see></param>
    public static ActionListBuilder ReCheckEtude(
        this ActionListBuilder builder, string etude, bool redoAfterTrigger = false)
    {
      var reCheck = ElementTool.Create<RecheckEtude>();
      reCheck.Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(etude);
      reCheck.m_RedoOnceTriggers = redoAfterTrigger;
      return builder.Add(reCheck);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.EntitySystem.Persistence.Versioning.UpgraderOnlyActions.RefreshAllArmyLeaders">RefreshAllArmyLeaders</see>
    /// </summary>
    public static ActionListBuilder RefreshAllArmyLeaders(this ActionListBuilder builder, bool playerOnly = false)
    {
      var refresh = ElementTool.Create<RefreshAllArmyLeaders>();
      refresh.m_OnlyPlayerLeaders = playerOnly;
      return builder.Add(refresh);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.EntitySystem.Persistence.Versioning.UpgraderOnlyActions.RemoveFeatureFromProgression">RemoveFeatureFromProgression</see>
    /// </summary>
    /// 
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
    /// <param name="progression"><see cref="Kingmaker.Blueprints.Classes.BlueprintProgression">BlueprintProgression</see></param>
    /// <param name="archetype"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype">BlueprintArchetype</see></param>
    /// <param name="ignoreFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
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

    /// <summary>
    /// Adds <see cref="Kingmaker.EntitySystem.Persistence.Versioning.UpgraderOnlyActions.ReplaceFeature">ReplaceFeature</see>
    /// </summary>
    /// 
    /// <param name="oldFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
    /// <param name="newFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
    /// <param name="progression"><see cref="Kingmaker.Blueprints.Classes.BlueprintProgression">BlueprintProgression</see></param>
    /// <param name="ignoreFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
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

    /// <summary>
    /// Adds <see cref="Kingmaker.EntitySystem.Persistence.Versioning.UpgraderOnlyActions.RestartTacticalCombat">RestartTacticalCombat</see>
    /// </summary>
    public static ActionListBuilder RestartTacticalCombat(this ActionListBuilder builder)
    {
      return builder.Add(ElementTool.Create<RestartTacticalCombat>());
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.EntitySystem.Persistence.Versioning.UpgraderOnlyActions.SetSharedVendorTable">SetSharedVendorTable</see>
    /// </summary>
    /// 
    /// <param name="table"><see cref="Kingmaker.Blueprints.Items.BlueprintSharedVendorTable">BlueprintSharedVendorTable</see></param>
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

    /// <summary>
    /// Adds <see cref="StartEtudeForced"/>
    /// </summary>
    /// 
    /// <param name="etude"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude">BlueprintEtude</see></param>
    public static ActionListBuilder ForceStartEtude(this ActionListBuilder builder, string etude)
    {
      var startEtude = ElementTool.Create<StartEtudeForced>();
      startEtude.Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(etude);
      return builder.Add(startEtude);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.EntitySystem.Persistence.Versioning.UpgraderOnlyActions.UnStartEtude">UnStartEtude</see>
    /// </summary>
    /// 
    /// <param name="etude"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude">BlueprintEtude</see></param>
    public static ActionListBuilder UnStartEtude(this ActionListBuilder builder, string etude)
    {
      var unStartEtude = ElementTool.Create<UnStartEtude>();
      unStartEtude.Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(etude);
      return builder.Add(unStartEtude);
    }
  }
}