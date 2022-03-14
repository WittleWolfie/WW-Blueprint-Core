using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Persistence.Versioning.PlayerUpgraderOnlyActions;
using Kingmaker.EntitySystem.Persistence.Versioning.UpgraderOnlyActions;
using System.Linq;

namespace BlueprintCoreGen.Actions.Builder.UpgraderEx
{
  /// <summary>
  /// Extension to <see cref="ActionsBuilder"/> for all UpgraderOnlyActions.
  /// </summary>
  /// <inheritdoc cref="ActionsBuilder"/>
  public static class ActionsBuilderUpgraderEx
  {
    //----- Kingmaker.EntitySystem.Persistence.Versioning.*UpgraderOnlyActions -----//

    /// <summary>
    /// Adds <see cref="Kingmaker.EntitySystem.Persistence.Versioning.PlayerUpgraderOnlyActions.AddFactIfEtudePlaying">AddFactIfEtudePlaying</see>
    /// </summary>
    /// 
    /// <param name="fact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact">BlueprintUnitFact</see></param>
    /// <param name="etude"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude">BlueprintEtude</see></param>
    [Implements(typeof(AddFactIfEtudePlaying))]
    public static ActionsBuilder AddFactIfEtudePlaying(
        this ActionsBuilder builder,
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
    /// Adds <see cref="ReenterScriptzone"/>
    /// </summary>
    [Implements(typeof(ReenterScriptzone))]
    public static ActionsBuilder ReEnterScriptZone(this ActionsBuilder builder, EntityReference scriptZone)
    {
      var reEnter = ElementTool.Create<ReenterScriptzone>();
      reEnter.m_ScriptZone = scriptZone;
      return builder.Add(reEnter);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.EntitySystem.Persistence.Versioning.PlayerUpgraderOnlyActions.RemoveFact">RemoveFact</see>
    /// </summary>
    /// 
    /// <param name="fact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact">BlueprintUnitFact</see></param>
    /// <param name="ignoreFacts"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact">BlueprintUnitFact</see>
    /// If the target has any of these facts, the fact will not be removed.
    /// </param>
    [Implements(typeof(RemoveFact))]
    public static ActionsBuilder RemoveFact(
        this ActionsBuilder builder,
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
    /// Adds <see cref="Kingmaker.EntitySystem.Persistence.Versioning.UpgraderOnlyActions.AddFeatureFromProgression">AddFeatureFromProgression</see>
    /// </summary>
    /// 
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
    /// <param name="progression"><see cref="Kingmaker.Blueprints.Classes.BlueprintProgression">BlueprintProgression</see></param>
    /// <param name="archetype"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype">BlueprintArchetype</see></param>
    /// <param name="selection"><see cref="Kingmaker.Blueprints.Classes.Selection.BlueprintFeatureSelection">BlueprintFeatureSelection</see></param>
    /// <param name="ignoreFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
    [Implements(typeof(AddFeatureFromProgression))]
    public static ActionsBuilder AddFeatureFromProgression(
        this ActionsBuilder builder,
        string feature,
        string progression,
        int level,
        string? archetype = null,
        string? selection = null,
        string? ignoreFeature = null)
    {
      var addFeature = ElementTool.Create<AddFeatureFromProgression>();
      addFeature.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      addFeature.m_Progression = BlueprintTool.GetRef<BlueprintProgressionReference>(progression);
      addFeature.m_Level = level;
      addFeature.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype!);
      addFeature.m_Selection = BlueprintTool.GetRef<BlueprintFeatureSelectionReference>(selection!);
      addFeature.m_ExceptHasFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(ignoreFeature!);
      return builder.Add(addFeature);
    }

    /// <summary>
    /// Adds <see cref="RecheckEtude"/>
    /// </summary>
    /// 
    /// <param name="etude"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude">BlueprintEtude</see></param>
    [Implements(typeof(RecheckEtude))]
    public static ActionsBuilder ReCheckEtude(
        this ActionsBuilder builder, string etude, bool redoAfterTrigger = false)
    {
      var reCheck = ElementTool.Create<RecheckEtude>();
      reCheck.Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(etude);
      reCheck.m_RedoOnceTriggers = redoAfterTrigger;
      return builder.Add(reCheck);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.EntitySystem.Persistence.Versioning.UpgraderOnlyActions.RemoveFeatureFromProgression">RemoveFeatureFromProgression</see>
    /// </summary>
    /// 
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
    /// <param name="progression"><see cref="Kingmaker.Blueprints.Classes.BlueprintProgression">BlueprintProgression</see></param>
    /// <param name="archetype"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype">BlueprintArchetype</see></param>
    /// <param name="ignoreFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
    [Implements(typeof(RemoveFeatureFromProgression))]
    public static ActionsBuilder RemoveFeatureFromProgression(
        this ActionsBuilder builder,
        string feature,
        string progression,
        int level,
        string? archetype = null,
        string? ignoreFeature = null)
    {
      var removeFeature = ElementTool.Create<RemoveFeatureFromProgression>();
      removeFeature.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      removeFeature.m_Progression =
          BlueprintTool.GetRef<BlueprintProgressionReference>(progression);
      removeFeature.m_Level = level;
      removeFeature.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype!);
      removeFeature.m_ExceptHasFeature =
          BlueprintTool.GetRef<BlueprintFeatureReference>(ignoreFeature!);
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
    [Implements(typeof(ReplaceFeature))]
    public static ActionsBuilder ReplaceFeature(
        this ActionsBuilder builder,
        string oldFeature,
        string newFeature,
        string progression,
        string? ignoreFeature = null)
    {
      var replaceFeature = ElementTool.Create<ReplaceFeature>();
      replaceFeature.m_ToReplace = BlueprintTool.GetRef<BlueprintFeatureReference>(oldFeature);
      replaceFeature.m_Replacement = BlueprintTool.GetRef<BlueprintFeatureReference>(newFeature);
      replaceFeature.m_FromProgression =
          BlueprintTool.GetRef<BlueprintProgressionReference>(progression);
      replaceFeature.m_ExceptHasFeature =
          BlueprintTool.GetRef<BlueprintFeatureReference>(ignoreFeature!);
      return builder.Add(replaceFeature);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.EntitySystem.Persistence.Versioning.UpgraderOnlyActions.SetSharedVendorTable">SetSharedVendorTable</see>
    /// </summary>
    /// 
    /// <param name="table"><see cref="Kingmaker.Blueprints.Items.BlueprintSharedVendorTable">BlueprintSharedVendorTable</see></param>
    [Implements(typeof(SetSharedVendorTable))]
    public static ActionsBuilder SetSharedVendorTable(
        this ActionsBuilder builder, string table, UnitEvaluator unit)
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
    [Implements(typeof(StartEtudeForced))]
    public static ActionsBuilder ForceStartEtude(this ActionsBuilder builder, string etude)
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
    [Implements(typeof(UnStartEtude))]
    public static ActionsBuilder UnStartEtude(this ActionsBuilder builder, string etude)
    {
      var unStartEtude = ElementTool.Create<UnStartEtude>();
      unStartEtude.Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(etude);
      return builder.Add(unStartEtude);
    }

    //----- Auto Generated -----//
    // [Generate(Kingmaker.EntitySystem.Persistence.Versioning.UnitUpgraderOnlyActions.SetRaceFromBlueprint)]
    // [Generate(Kingmaker.EntitySystem.Persistence.Versioning.UpgraderOnlyActions.RefreshArmyLeadersBaseSkills)]
    // [Generate(Kingmaker.EntitySystem.Persistence.Versioning.UpgraderOnlyActions.RespawnNewUnit)]
    // [Generate(Kingmaker.EntitySystem.Persistence.Versioning.PlayerUpgraderOnlyActions.RemoveSpell)]
    // [Generate(Kingmaker.EntitySystem.Persistence.Versioning.PlayerUpgraderOnlyActions.RestoreClassFeature)]
    // [Generate(Kingmaker.EntitySystem.Persistence.Versioning.PlayerUpgraderOnlyActions.UpdateProgression)]
  }
}