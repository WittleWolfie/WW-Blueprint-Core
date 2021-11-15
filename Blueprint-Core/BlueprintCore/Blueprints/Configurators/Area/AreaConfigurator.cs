using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Enums;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.AI;
using Kingmaker.Kingdom.Buffs;
using Kingmaker.Localization;
using Kingmaker.RandomEncounters.Settings;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintArea"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArea))]
  public abstract class BaseAreaConfigurator<T, TBuilder>
      : BaseAreaPartConfigurator<T, TBuilder>
      where T : BlueprintArea
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseAreaConfigurator(string name) : base(name) { }

    /// <summary>
    /// Modifies <see cref="BlueprintArea.m_Parts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAreaPart"/></param>
    [Generated]
    public TBuilder AddToParts(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Parts.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintAreaPartReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArea.m_Parts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAreaPart"/></param>
    [Generated]
    public TBuilder RemoveFromParts(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintAreaPartReference>(name));
            bp.m_Parts =
                bp.m_Parts
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.IsGlobalMap"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetIsGlobalMap(bool value)
    {
      return OnConfigureInternal(bp => bp.IsGlobalMap = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CameraScrollMultiplier"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCameraScrollMultiplier(float value)
    {
      return OnConfigureInternal(bp => bp.CameraScrollMultiplier = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.SetDefaultCameraRotation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetSetDefaultCameraRotation(bool value)
    {
      return OnConfigureInternal(bp => bp.SetDefaultCameraRotation = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CameraRotation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCameraRotation(float value)
    {
      return OnConfigureInternal(bp => bp.CameraRotation = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CampingSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCampingSettings(CampingSettings value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.CampingSettings = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.RandomEncounterSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetRandomEncounterSettings(RandomEncounterSettings value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.RandomEncounterSettings = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.Designer"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetDesigner(BlueprintArea.Designers value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Designer = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.ArtSetting"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetArtSetting(BlueprintArea.SettingType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ArtSetting = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.AreaName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetAreaName(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.AreaName = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.ExcludeFromSave"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetExcludeFromSave(bool value)
    {
      return OnConfigureInternal(bp => bp.ExcludeFromSave = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.PS4ChunkId"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetPS4ChunkId(PS4ChunkId value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.PS4ChunkId = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArea.LoadingScreenSprites"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder AddToLoadingScreenSprites(params Sprite[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.LoadingScreenSprites.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArea.LoadingScreenSprites"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder RemoveFromLoadingScreenSprites(params Sprite[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.LoadingScreenSprites = bp.LoadingScreenSprites.Where(item => !values.Contains(item)).ToList());
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.m_DefaultPreset"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintAreaPreset"/></param>
    [Generated]
    public TBuilder SetDefaultPreset(string value)
    {
      return OnConfigureInternal(bp => bp.m_DefaultPreset = BlueprintTool.GetRef<BlueprintAreaPresetReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CR"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCR(int value)
    {
      return OnConfigureInternal(bp => bp.CR = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.OverrideCorruption"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetOverrideCorruption(bool value)
    {
      return OnConfigureInternal(bp => bp.OverrideCorruption = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CorruptionGrowth"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCorruptionGrowth(int value)
    {
      return OnConfigureInternal(bp => bp.CorruptionGrowth = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.LootSetting"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetLootSetting(LootSetting value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.LootSetting = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArea.m_HotAreas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintArea"/></param>
    [Generated]
    public TBuilder AddToHotAreas(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_HotAreas = CommonTool.Append(bp.m_HotAreas, values.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArea.m_HotAreas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintArea"/></param>
    [Generated]
    public TBuilder RemoveFromHotAreas(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name));
            bp.m_HotAreas =
                bp.m_HotAreas
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Adds <see cref="CombatRandomEncounterAreaSettings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_DefaultEnterPoint"><see cref="BlueprintAreaEnterPoint"/></param>
    /// <param name="m_GoodAvoidanceEnterPoint"><see cref="BlueprintAreaEnterPoint"/></param>
    [Generated]
    [Implements(typeof(CombatRandomEncounterAreaSettings))]
    public TBuilder AddCombatRandomEncounterAreaSettings(
        string m_DefaultEnterPoint,
        string m_GoodAvoidanceEnterPoint,
        GlobalMapZone[] AllowedNaturalSettings,
        CombatRandomEncounterAreaSettings.Formation[] Formations)
    {
      foreach (var item in AllowedNaturalSettings)
      {
        ValidateParam(item);
      }
      foreach (var item in Formations)
      {
        ValidateParam(item);
      }
      
      var component =  new CombatRandomEncounterAreaSettings();
      component.m_DefaultEnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(m_DefaultEnterPoint);
      component.m_GoodAvoidanceEnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(m_GoodAvoidanceEnterPoint);
      component.AllowedNaturalSettings = AllowedNaturalSettings;
      component.Formations = Formations;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AreaSettlementLink"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="SettlementRef"><see cref="BlueprintSettlement"/></param>
    [Generated]
    [Implements(typeof(AreaSettlementLink))]
    public TBuilder AddAreaSettlementLink(
        string SettlementRef)
    {
      
      var component =  new AreaSettlementLink();
      component.SettlementRef = BlueprintTool.GetRef<BlueprintSettlement.Reference>(SettlementRef);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OverrideCampingAction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(OverrideCampingAction))]
    public TBuilder AddOverrideCampingAction(
        ActionsBuilder OnRestActions,
        bool SkipRest)
    {
      
      var component =  new OverrideCampingAction();
      component.OnRestActions = OnRestActions.Build();
      component.SkipRest = SkipRest;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BirthdayTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BirthdayTrigger))]
    public TBuilder AddBirthdayTrigger(
        ConditionsBuilder Condition,
        ActionsBuilder Actions)
    {
      
      var component =  new BirthdayTrigger();
      component.Condition = Condition.Build();
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EveryDayTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EveryDayTrigger))]
    public TBuilder AddEveryDayTrigger(
        ConditionsBuilder Condition,
        ActionsBuilder Actions,
        int SkipDays)
    {
      
      var component =  new EveryDayTrigger();
      component.Condition = Condition.Build();
      component.Actions = Actions.Build();
      component.SkipDays = SkipDays;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EveryWeekTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EveryWeekTrigger))]
    public TBuilder AddEveryWeekTrigger(
        ConditionsBuilder Condition,
        ActionsBuilder Actions,
        int SkipWeeks)
    {
      
      var component =  new EveryWeekTrigger();
      component.Condition = Condition.Build();
      component.Actions = Actions.Build();
      component.SkipWeeks = SkipWeeks;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SettlementAISettings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_AIBuildListVillage"><see cref="SettlementBuildList"/></param>
    /// <param name="m_AIBuildListTown"><see cref="SettlementBuildList"/></param>
    /// <param name="m_AIBuildListCity"><see cref="SettlementBuildList"/></param>
    [Generated]
    [Implements(typeof(SettlementAISettings))]
    public TBuilder AddSettlementAISettings(
        string m_AIBuildListVillage,
        string m_AIBuildListTown,
        string m_AIBuildListCity)
    {
      
      var component =  new SettlementAISettings();
      component.m_AIBuildListVillage = BlueprintTool.GetRef<SettlementBuildListReference>(m_AIBuildListVillage);
      component.m_AIBuildListTown = BlueprintTool.GetRef<SettlementBuildListReference>(m_AIBuildListTown);
      component.m_AIBuildListCity = BlueprintTool.GetRef<SettlementBuildListReference>(m_AIBuildListCity);
      return AddComponent(component);
    }
  }

  /// <summary>Configurator for <see cref="BlueprintArea"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArea))]
  public class AreaConfigurator : BaseAreaPartConfigurator<BlueprintArea, AreaConfigurator>
  {
     private AreaConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AreaConfigurator For(string name)
    {
      return new AreaConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AreaConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintArea>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AreaConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintArea>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArea.m_Parts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAreaPart"/></param>
    [Generated]
    public AreaConfigurator AddToParts(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Parts.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintAreaPartReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArea.m_Parts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAreaPart"/></param>
    [Generated]
    public AreaConfigurator RemoveFromParts(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintAreaPartReference>(name));
            bp.m_Parts =
                bp.m_Parts
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.IsGlobalMap"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetIsGlobalMap(bool value)
    {
      return OnConfigureInternal(bp => bp.IsGlobalMap = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CameraScrollMultiplier"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetCameraScrollMultiplier(float value)
    {
      return OnConfigureInternal(bp => bp.CameraScrollMultiplier = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.SetDefaultCameraRotation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetSetDefaultCameraRotation(bool value)
    {
      return OnConfigureInternal(bp => bp.SetDefaultCameraRotation = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CameraRotation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetCameraRotation(float value)
    {
      return OnConfigureInternal(bp => bp.CameraRotation = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CampingSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetCampingSettings(CampingSettings value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.CampingSettings = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.RandomEncounterSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetRandomEncounterSettings(RandomEncounterSettings value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.RandomEncounterSettings = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.Designer"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetDesigner(BlueprintArea.Designers value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Designer = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.ArtSetting"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetArtSetting(BlueprintArea.SettingType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.ArtSetting = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.AreaName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetAreaName(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.AreaName = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.ExcludeFromSave"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetExcludeFromSave(bool value)
    {
      return OnConfigureInternal(bp => bp.ExcludeFromSave = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.PS4ChunkId"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetPS4ChunkId(PS4ChunkId value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.PS4ChunkId = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArea.LoadingScreenSprites"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator AddToLoadingScreenSprites(params Sprite[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.LoadingScreenSprites.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArea.LoadingScreenSprites"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator RemoveFromLoadingScreenSprites(params Sprite[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.LoadingScreenSprites = bp.LoadingScreenSprites.Where(item => !values.Contains(item)).ToList());
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.m_DefaultPreset"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintAreaPreset"/></param>
    [Generated]
    public AreaConfigurator SetDefaultPreset(string value)
    {
      return OnConfigureInternal(bp => bp.m_DefaultPreset = BlueprintTool.GetRef<BlueprintAreaPresetReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CR"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetCR(int value)
    {
      return OnConfigureInternal(bp => bp.CR = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.OverrideCorruption"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetOverrideCorruption(bool value)
    {
      return OnConfigureInternal(bp => bp.OverrideCorruption = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CorruptionGrowth"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetCorruptionGrowth(int value)
    {
      return OnConfigureInternal(bp => bp.CorruptionGrowth = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.LootSetting"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AreaConfigurator SetLootSetting(LootSetting value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.LootSetting = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArea.m_HotAreas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintArea"/></param>
    [Generated]
    public AreaConfigurator AddToHotAreas(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_HotAreas = CommonTool.Append(bp.m_HotAreas, values.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArea.m_HotAreas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintArea"/></param>
    [Generated]
    public AreaConfigurator RemoveFromHotAreas(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name));
            bp.m_HotAreas =
                bp.m_HotAreas
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Adds <see cref="CombatRandomEncounterAreaSettings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_DefaultEnterPoint"><see cref="BlueprintAreaEnterPoint"/></param>
    /// <param name="m_GoodAvoidanceEnterPoint"><see cref="BlueprintAreaEnterPoint"/></param>
    [Generated]
    [Implements(typeof(CombatRandomEncounterAreaSettings))]
    public AreaConfigurator AddCombatRandomEncounterAreaSettings(
        string m_DefaultEnterPoint,
        string m_GoodAvoidanceEnterPoint,
        GlobalMapZone[] AllowedNaturalSettings,
        CombatRandomEncounterAreaSettings.Formation[] Formations)
    {
      foreach (var item in AllowedNaturalSettings)
      {
        ValidateParam(item);
      }
      foreach (var item in Formations)
      {
        ValidateParam(item);
      }
      
      var component =  new CombatRandomEncounterAreaSettings();
      component.m_DefaultEnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(m_DefaultEnterPoint);
      component.m_GoodAvoidanceEnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(m_GoodAvoidanceEnterPoint);
      component.AllowedNaturalSettings = AllowedNaturalSettings;
      component.Formations = Formations;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AreaSettlementLink"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="SettlementRef"><see cref="BlueprintSettlement"/></param>
    [Generated]
    [Implements(typeof(AreaSettlementLink))]
    public AreaConfigurator AddAreaSettlementLink(
        string SettlementRef)
    {
      
      var component =  new AreaSettlementLink();
      component.SettlementRef = BlueprintTool.GetRef<BlueprintSettlement.Reference>(SettlementRef);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OverrideCampingAction"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(OverrideCampingAction))]
    public AreaConfigurator AddOverrideCampingAction(
        ActionsBuilder OnRestActions,
        bool SkipRest)
    {
      
      var component =  new OverrideCampingAction();
      component.OnRestActions = OnRestActions.Build();
      component.SkipRest = SkipRest;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BirthdayTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BirthdayTrigger))]
    public AreaConfigurator AddBirthdayTrigger(
        ConditionsBuilder Condition,
        ActionsBuilder Actions)
    {
      
      var component =  new BirthdayTrigger();
      component.Condition = Condition.Build();
      component.Actions = Actions.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EveryDayTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EveryDayTrigger))]
    public AreaConfigurator AddEveryDayTrigger(
        ConditionsBuilder Condition,
        ActionsBuilder Actions,
        int SkipDays)
    {
      
      var component =  new EveryDayTrigger();
      component.Condition = Condition.Build();
      component.Actions = Actions.Build();
      component.SkipDays = SkipDays;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EveryWeekTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EveryWeekTrigger))]
    public AreaConfigurator AddEveryWeekTrigger(
        ConditionsBuilder Condition,
        ActionsBuilder Actions,
        int SkipWeeks)
    {
      
      var component =  new EveryWeekTrigger();
      component.Condition = Condition.Build();
      component.Actions = Actions.Build();
      component.SkipWeeks = SkipWeeks;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SettlementAISettings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_AIBuildListVillage"><see cref="SettlementBuildList"/></param>
    /// <param name="m_AIBuildListTown"><see cref="SettlementBuildList"/></param>
    /// <param name="m_AIBuildListCity"><see cref="SettlementBuildList"/></param>
    [Generated]
    [Implements(typeof(SettlementAISettings))]
    public AreaConfigurator AddSettlementAISettings(
        string m_AIBuildListVillage,
        string m_AIBuildListTown,
        string m_AIBuildListCity)
    {
      
      var component =  new SettlementAISettings();
      component.m_AIBuildListVillage = BlueprintTool.GetRef<SettlementBuildListReference>(m_AIBuildListVillage);
      component.m_AIBuildListTown = BlueprintTool.GetRef<SettlementBuildListReference>(m_AIBuildListTown);
      component.m_AIBuildListCity = BlueprintTool.GetRef<SettlementBuildListReference>(m_AIBuildListCity);
      return AddComponent(component);
    }
  }
}
