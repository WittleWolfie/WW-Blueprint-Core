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
using Kingmaker.RandomEncounters;
using Kingmaker.RandomEncounters.Settings;
using Kingmaker.ResourceLinks;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Area
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintArea"/>.
  /// </summary>
  /// <inheritdoc/>
  
  public abstract class BaseAreaConfigurator<T, TBuilder>
      : BaseAreaPartConfigurator<T, TBuilder>
      where T : BlueprintArea
      where TBuilder : BaseAreaConfigurator<T, TBuilder>
  {
    protected BaseAreaConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintArea.m_Parts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="parts"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaPart"/></param>
    
    public TBuilder SetParts(string[]? parts)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Parts = parts.Select(name => BlueprintTool.GetRef<BlueprintAreaPartReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintArea.m_Parts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="parts"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaPart"/></param>
    
    public TBuilder AddToParts(params string[] parts)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Parts.AddRange(parts.Select(name => BlueprintTool.GetRef<BlueprintAreaPartReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintArea.m_Parts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="parts"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaPart"/></param>
    
    public TBuilder RemoveFromParts(params string[] parts)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = parts.Select(name => BlueprintTool.GetRef<BlueprintAreaPartReference>(name));
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
    
    public TBuilder SetIsGlobalMap(bool isGlobalMap)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsGlobalMap = isGlobalMap;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CameraScrollMultiplier"/> (Auto Generated)
    /// </summary>
    
    public TBuilder SetCameraScrollMultiplier(float cameraScrollMultiplier)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CameraScrollMultiplier = cameraScrollMultiplier;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.SetDefaultCameraRotation"/> (Auto Generated)
    /// </summary>
    
    public TBuilder SetDefaultCameraRotation(bool setDefaultCameraRotation)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SetDefaultCameraRotation = setDefaultCameraRotation;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CameraRotation"/> (Auto Generated)
    /// </summary>
    
    public TBuilder SetCameraRotation(float cameraRotation)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CameraRotation = cameraRotation;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CampingSettings"/> (Auto Generated)
    /// </summary>
    
    public TBuilder SetCampingSettings(CampingSettings campingSettings)
    {
      ValidateParam(campingSettings);

      return OnConfigureInternal(
          bp =>
          {
            bp.CampingSettings = campingSettings;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.RandomEncounterSettings"/> (Auto Generated)
    /// </summary>
    
    public TBuilder SetRandomEncounterSettings(RandomEncounterSettings randomEncounterSettings)
    {
      ValidateParam(randomEncounterSettings);

      return OnConfigureInternal(
          bp =>
          {
            bp.RandomEncounterSettings = randomEncounterSettings;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.Designer"/> (Auto Generated)
    /// </summary>
    
    public TBuilder SetDesigner(BlueprintArea.Designers designer)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Designer = designer;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.ArtSetting"/> (Auto Generated)
    /// </summary>
    
    public TBuilder SetArtSetting(BlueprintArea.SettingType artSetting)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ArtSetting = artSetting;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.AreaName"/> (Auto Generated)
    /// </summary>
    
    public TBuilder SetAreaName(LocalizedString? areaName)
    {
      ValidateParam(areaName);

      return OnConfigureInternal(
          bp =>
          {
            bp.AreaName = areaName ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.ExcludeFromSave"/> (Auto Generated)
    /// </summary>
    
    public TBuilder SetExcludeFromSave(bool excludeFromSave)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ExcludeFromSave = excludeFromSave;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.PS4ChunkId"/> (Auto Generated)
    /// </summary>
    
    public TBuilder SetPS4ChunkId(PS4ChunkId pS4ChunkId)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.PS4ChunkId = pS4ChunkId;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.LoadingScreenSprites"/> (Auto Generated)
    /// </summary>
    
    public TBuilder SetLoadingScreenSprites(List<SpriteLink>? loadingScreenSprites)
    {
      ValidateParam(loadingScreenSprites);

      return OnConfigureInternal(
          bp =>
          {
            bp.LoadingScreenSprites = loadingScreenSprites;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintArea.LoadingScreenSprites"/> (Auto Generated)
    /// </summary>
    
    public TBuilder AddToLoadingScreenSprites(params SpriteLink[] loadingScreenSprites)
    {
      ValidateParam(loadingScreenSprites);
      return OnConfigureInternal(
          bp =>
          {
            bp.LoadingScreenSprites.AddRange(loadingScreenSprites.ToList() ?? new List<SpriteLink>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintArea.LoadingScreenSprites"/> (Auto Generated)
    /// </summary>
    
    public TBuilder RemoveFromLoadingScreenSprites(params SpriteLink[] loadingScreenSprites)
    {
      ValidateParam(loadingScreenSprites);
      return OnConfigureInternal(
          bp =>
          {
            bp.LoadingScreenSprites = bp.LoadingScreenSprites.Where(item => !loadingScreenSprites.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.m_DefaultPreset"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="defaultPreset"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaPreset"/></param>
    
    public TBuilder SetDefaultPreset(string? defaultPreset)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DefaultPreset = BlueprintTool.GetRef<BlueprintAreaPresetReference>(defaultPreset);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CR"/> (Auto Generated)
    /// </summary>
    
    public TBuilder SetCR(int cR)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CR = cR;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.OverrideCorruption"/> (Auto Generated)
    /// </summary>
    
    public TBuilder SetOverrideCorruption(bool overrideCorruption)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OverrideCorruption = overrideCorruption;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CorruptionGrowth"/> (Auto Generated)
    /// </summary>
    
    public TBuilder SetCorruptionGrowth(int corruptionGrowth)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CorruptionGrowth = corruptionGrowth;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.LootSetting"/> (Auto Generated)
    /// </summary>
    
    public TBuilder SetLootSetting(LootSetting lootSetting)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.LootSetting = lootSetting;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.m_HotAreas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="hotAreas"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    
    public TBuilder SetHotAreas(string[]? hotAreas)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_HotAreas = hotAreas.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintArea.m_HotAreas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="hotAreas"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    
    public TBuilder AddToHotAreas(params string[] hotAreas)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_HotAreas = CommonTool.Append(bp.m_HotAreas, hotAreas.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintArea.m_HotAreas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="hotAreas"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    
    public TBuilder RemoveFromHotAreas(params string[] hotAreas)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = hotAreas.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name));
            bp.m_HotAreas =
                bp.m_HotAreas
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Adds <see cref="CampingEncounterIncreaseDifficulty"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddCampingEncounterIncreaseDifficulty(
        float increaseChance = default,
        int increaseDifficulty = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new CampingEncounterIncreaseDifficulty();
      component.m_IncreaseChance = increaseChance;
      component.m_IncreaseDifficulty = increaseDifficulty;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="CombatRandomEncounterAreaSettings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="defaultEnterPoint"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaEnterPoint"/></param>
    /// <param name="goodAvoidanceEnterPoint"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaEnterPoint"/></param>
    
    
    public TBuilder AddCombatRandomEncounterAreaSettings(
        string? defaultEnterPoint = null,
        string? goodAvoidanceEnterPoint = null,
        GlobalMapZone[]? allowedNaturalSettings = null,
        CombatRandomEncounterAreaSettings.Formation[]? formations = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(formations);

      var component = new CombatRandomEncounterAreaSettings();
      component.m_DefaultEnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(defaultEnterPoint);
      component.m_GoodAvoidanceEnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(goodAvoidanceEnterPoint);
      component.AllowedNaturalSettings = allowedNaturalSettings;
      component.Formations = formations;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AreaSettlementLink"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="settlementRef"><see cref="Kingmaker.Kingdom.BlueprintSettlement"/></param>
    
    
    public TBuilder AddAreaSettlementLink(
        string? settlementRef = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AreaSettlementLink();
      component.SettlementRef = BlueprintTool.GetRef<BlueprintSettlement.Reference>(settlementRef);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="OverrideCampingAction"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddOverrideCampingAction(
        ActionsBuilder? onRestActions = null,
        bool skipRest = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new OverrideCampingAction();
      component.OnRestActions = onRestActions?.Build() ?? Constants.Empty.Actions;
      component.SkipRest = skipRest;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BirthdayTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddBirthdayTrigger(
        ConditionsBuilder? condition = null,
        ActionsBuilder? actions = null)
    {
      var component = new BirthdayTrigger();
      component.Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EveryDayTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddEveryDayTrigger(
        ConditionsBuilder? condition = null,
        ActionsBuilder? actions = null,
        int skipDays = default)
    {
      var component = new EveryDayTrigger();
      component.Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.SkipDays = skipDays;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EveryWeekTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public TBuilder AddEveryWeekTrigger(
        ConditionsBuilder? condition = null,
        ActionsBuilder? actions = null,
        int skipWeeks = default)
    {
      var component = new EveryWeekTrigger();
      component.Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.SkipWeeks = skipWeeks;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SettlementAISettings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="aIBuildListVillage"><see cref="Kingmaker.Kingdom.AI.SettlementBuildList"/></param>
    /// <param name="aIBuildListTown"><see cref="Kingmaker.Kingdom.AI.SettlementBuildList"/></param>
    /// <param name="aIBuildListCity"><see cref="Kingmaker.Kingdom.AI.SettlementBuildList"/></param>
    
    
    public TBuilder AddSettlementAISettings(
        string? aIBuildListVillage = null,
        string? aIBuildListTown = null,
        string? aIBuildListCity = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SettlementAISettings();
      component.m_AIBuildListVillage = BlueprintTool.GetRef<SettlementBuildListReference>(aIBuildListVillage);
      component.m_AIBuildListTown = BlueprintTool.GetRef<SettlementBuildListReference>(aIBuildListTown);
      component.m_AIBuildListCity = BlueprintTool.GetRef<SettlementBuildListReference>(aIBuildListCity);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }

  /// <summary>
  /// Configurator for <see cref="BlueprintArea"/>.
  /// </summary>
  /// <inheritdoc/>
  
  public class AreaConfigurator : BaseAreaPartConfigurator<BlueprintArea, AreaConfigurator>
  {
    private AreaConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AreaConfigurator For(string name)
    {
      return new AreaConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AreaConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintArea>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.m_Parts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="parts"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaPart"/></param>
    
    public AreaConfigurator SetParts(string[]? parts)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Parts = parts.Select(name => BlueprintTool.GetRef<BlueprintAreaPartReference>(name)).ToList();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintArea.m_Parts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="parts"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaPart"/></param>
    
    public AreaConfigurator AddToParts(params string[] parts)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Parts.AddRange(parts.Select(name => BlueprintTool.GetRef<BlueprintAreaPartReference>(name)));
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintArea.m_Parts"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="parts"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaPart"/></param>
    
    public AreaConfigurator RemoveFromParts(params string[] parts)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = parts.Select(name => BlueprintTool.GetRef<BlueprintAreaPartReference>(name));
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
    
    public AreaConfigurator SetIsGlobalMap(bool isGlobalMap)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsGlobalMap = isGlobalMap;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CameraScrollMultiplier"/> (Auto Generated)
    /// </summary>
    
    public AreaConfigurator SetCameraScrollMultiplier(float cameraScrollMultiplier)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CameraScrollMultiplier = cameraScrollMultiplier;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.SetDefaultCameraRotation"/> (Auto Generated)
    /// </summary>
    
    public AreaConfigurator SetDefaultCameraRotation(bool setDefaultCameraRotation)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.SetDefaultCameraRotation = setDefaultCameraRotation;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CameraRotation"/> (Auto Generated)
    /// </summary>
    
    public AreaConfigurator SetCameraRotation(float cameraRotation)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CameraRotation = cameraRotation;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CampingSettings"/> (Auto Generated)
    /// </summary>
    
    public AreaConfigurator SetCampingSettings(CampingSettings campingSettings)
    {
      ValidateParam(campingSettings);

      return OnConfigureInternal(
          bp =>
          {
            bp.CampingSettings = campingSettings;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.RandomEncounterSettings"/> (Auto Generated)
    /// </summary>
    
    public AreaConfigurator SetRandomEncounterSettings(RandomEncounterSettings randomEncounterSettings)
    {
      ValidateParam(randomEncounterSettings);

      return OnConfigureInternal(
          bp =>
          {
            bp.RandomEncounterSettings = randomEncounterSettings;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.Designer"/> (Auto Generated)
    /// </summary>
    
    public AreaConfigurator SetDesigner(BlueprintArea.Designers designer)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Designer = designer;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.ArtSetting"/> (Auto Generated)
    /// </summary>
    
    public AreaConfigurator SetArtSetting(BlueprintArea.SettingType artSetting)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ArtSetting = artSetting;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.AreaName"/> (Auto Generated)
    /// </summary>
    
    public AreaConfigurator SetAreaName(LocalizedString? areaName)
    {
      ValidateParam(areaName);

      return OnConfigureInternal(
          bp =>
          {
            bp.AreaName = areaName ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.ExcludeFromSave"/> (Auto Generated)
    /// </summary>
    
    public AreaConfigurator SetExcludeFromSave(bool excludeFromSave)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ExcludeFromSave = excludeFromSave;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.PS4ChunkId"/> (Auto Generated)
    /// </summary>
    
    public AreaConfigurator SetPS4ChunkId(PS4ChunkId pS4ChunkId)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.PS4ChunkId = pS4ChunkId;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.LoadingScreenSprites"/> (Auto Generated)
    /// </summary>
    
    public AreaConfigurator SetLoadingScreenSprites(List<SpriteLink>? loadingScreenSprites)
    {
      ValidateParam(loadingScreenSprites);

      return OnConfigureInternal(
          bp =>
          {
            bp.LoadingScreenSprites = loadingScreenSprites;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintArea.LoadingScreenSprites"/> (Auto Generated)
    /// </summary>
    
    public AreaConfigurator AddToLoadingScreenSprites(params SpriteLink[] loadingScreenSprites)
    {
      ValidateParam(loadingScreenSprites);
      return OnConfigureInternal(
          bp =>
          {
            bp.LoadingScreenSprites.AddRange(loadingScreenSprites.ToList() ?? new List<SpriteLink>());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintArea.LoadingScreenSprites"/> (Auto Generated)
    /// </summary>
    
    public AreaConfigurator RemoveFromLoadingScreenSprites(params SpriteLink[] loadingScreenSprites)
    {
      ValidateParam(loadingScreenSprites);
      return OnConfigureInternal(
          bp =>
          {
            bp.LoadingScreenSprites = bp.LoadingScreenSprites.Where(item => !loadingScreenSprites.Contains(item)).ToList();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.m_DefaultPreset"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="defaultPreset"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaPreset"/></param>
    
    public AreaConfigurator SetDefaultPreset(string? defaultPreset)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DefaultPreset = BlueprintTool.GetRef<BlueprintAreaPresetReference>(defaultPreset);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CR"/> (Auto Generated)
    /// </summary>
    
    public AreaConfigurator SetCR(int cR)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CR = cR;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.OverrideCorruption"/> (Auto Generated)
    /// </summary>
    
    public AreaConfigurator SetOverrideCorruption(bool overrideCorruption)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OverrideCorruption = overrideCorruption;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.CorruptionGrowth"/> (Auto Generated)
    /// </summary>
    
    public AreaConfigurator SetCorruptionGrowth(int corruptionGrowth)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CorruptionGrowth = corruptionGrowth;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.LootSetting"/> (Auto Generated)
    /// </summary>
    
    public AreaConfigurator SetLootSetting(LootSetting lootSetting)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.LootSetting = lootSetting;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintArea.m_HotAreas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="hotAreas"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    
    public AreaConfigurator SetHotAreas(string[]? hotAreas)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_HotAreas = hotAreas.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintArea.m_HotAreas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="hotAreas"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    
    public AreaConfigurator AddToHotAreas(params string[] hotAreas)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_HotAreas = CommonTool.Append(bp.m_HotAreas, hotAreas.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintArea.m_HotAreas"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="hotAreas"><see cref="Kingmaker.Blueprints.Area.BlueprintArea"/></param>
    
    public AreaConfigurator RemoveFromHotAreas(params string[] hotAreas)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = hotAreas.Select(name => BlueprintTool.GetRef<BlueprintAreaReference>(name));
            bp.m_HotAreas =
                bp.m_HotAreas
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Adds <see cref="CampingEncounterIncreaseDifficulty"/> (Auto Generated)
    /// </summary>
    
    
    public AreaConfigurator AddCampingEncounterIncreaseDifficulty(
        float increaseChance = default,
        int increaseDifficulty = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new CampingEncounterIncreaseDifficulty();
      component.m_IncreaseChance = increaseChance;
      component.m_IncreaseDifficulty = increaseDifficulty;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="CombatRandomEncounterAreaSettings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="defaultEnterPoint"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaEnterPoint"/></param>
    /// <param name="goodAvoidanceEnterPoint"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaEnterPoint"/></param>
    
    
    public AreaConfigurator AddCombatRandomEncounterAreaSettings(
        string? defaultEnterPoint = null,
        string? goodAvoidanceEnterPoint = null,
        GlobalMapZone[]? allowedNaturalSettings = null,
        CombatRandomEncounterAreaSettings.Formation[]? formations = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(formations);

      var component = new CombatRandomEncounterAreaSettings();
      component.m_DefaultEnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(defaultEnterPoint);
      component.m_GoodAvoidanceEnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(goodAvoidanceEnterPoint);
      component.AllowedNaturalSettings = allowedNaturalSettings;
      component.Formations = formations;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AreaSettlementLink"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="settlementRef"><see cref="Kingmaker.Kingdom.BlueprintSettlement"/></param>
    
    
    public AreaConfigurator AddAreaSettlementLink(
        string? settlementRef = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AreaSettlementLink();
      component.SettlementRef = BlueprintTool.GetRef<BlueprintSettlement.Reference>(settlementRef);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="OverrideCampingAction"/> (Auto Generated)
    /// </summary>
    
    
    public AreaConfigurator AddOverrideCampingAction(
        ActionsBuilder? onRestActions = null,
        bool skipRest = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new OverrideCampingAction();
      component.OnRestActions = onRestActions?.Build() ?? Constants.Empty.Actions;
      component.SkipRest = skipRest;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BirthdayTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public AreaConfigurator AddBirthdayTrigger(
        ConditionsBuilder? condition = null,
        ActionsBuilder? actions = null)
    {
      var component = new BirthdayTrigger();
      component.Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EveryDayTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public AreaConfigurator AddEveryDayTrigger(
        ConditionsBuilder? condition = null,
        ActionsBuilder? actions = null,
        int skipDays = default)
    {
      var component = new EveryDayTrigger();
      component.Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.SkipDays = skipDays;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EveryWeekTrigger"/> (Auto Generated)
    /// </summary>
    
    
    public AreaConfigurator AddEveryWeekTrigger(
        ConditionsBuilder? condition = null,
        ActionsBuilder? actions = null,
        int skipWeeks = default)
    {
      var component = new EveryWeekTrigger();
      component.Condition = condition?.Build() ?? Constants.Empty.Conditions;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.SkipWeeks = skipWeeks;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SettlementAISettings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="aIBuildListVillage"><see cref="Kingmaker.Kingdom.AI.SettlementBuildList"/></param>
    /// <param name="aIBuildListTown"><see cref="Kingmaker.Kingdom.AI.SettlementBuildList"/></param>
    /// <param name="aIBuildListCity"><see cref="Kingmaker.Kingdom.AI.SettlementBuildList"/></param>
    
    
    public AreaConfigurator AddSettlementAISettings(
        string? aIBuildListVillage = null,
        string? aIBuildListTown = null,
        string? aIBuildListCity = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new SettlementAISettings();
      component.m_AIBuildListVillage = BlueprintTool.GetRef<SettlementBuildListReference>(aIBuildListVillage);
      component.m_AIBuildListTown = BlueprintTool.GetRef<SettlementBuildListReference>(aIBuildListTown);
      component.m_AIBuildListCity = BlueprintTool.GetRef<SettlementBuildListReference>(aIBuildListCity);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}
