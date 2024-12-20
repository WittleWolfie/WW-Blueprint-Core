//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Area;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Kingdom.AI;
using Kingmaker.Kingdom.Buffs;
using Kingmaker.Localization;
using Kingmaker.RandomEncounters;
using Kingmaker.RandomEncounters.Settings;
using Kingmaker.ResourceLinks;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

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
    protected BaseAreaConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintArea>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Parts = copyFrom.m_Parts;
          bp.IsGlobalMap = copyFrom.IsGlobalMap;
          bp.CameraScrollMultiplier = copyFrom.CameraScrollMultiplier;
          bp.SetDefaultCameraRotation = copyFrom.SetDefaultCameraRotation;
          bp.CameraRotation = copyFrom.CameraRotation;
          bp.CampingSettings = copyFrom.CampingSettings;
          bp.RandomEncounterSettings = copyFrom.RandomEncounterSettings;
          bp.Designer = copyFrom.Designer;
          bp.ArtSetting = copyFrom.ArtSetting;
          bp.AreaName = copyFrom.AreaName;
          bp.ExcludeFromSave = copyFrom.ExcludeFromSave;
          bp.PS4ChunkId = copyFrom.PS4ChunkId;
          bp.LoadingScreenSprites = copyFrom.LoadingScreenSprites;
          bp.m_DefaultPreset = copyFrom.m_DefaultPreset;
          bp.CR = copyFrom.CR;
          bp.OverrideCorruption = copyFrom.OverrideCorruption;
          bp.CorruptionGrowth = copyFrom.CorruptionGrowth;
          bp.LootSetting = copyFrom.LootSetting;
          bp.m_HotAreas = copyFrom.m_HotAreas;
          bp.IsMayMapWindow = copyFrom.IsMayMapWindow;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintArea>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Parts = copyFrom.m_Parts;
          bp.IsGlobalMap = copyFrom.IsGlobalMap;
          bp.CameraScrollMultiplier = copyFrom.CameraScrollMultiplier;
          bp.SetDefaultCameraRotation = copyFrom.SetDefaultCameraRotation;
          bp.CameraRotation = copyFrom.CameraRotation;
          bp.CampingSettings = copyFrom.CampingSettings;
          bp.RandomEncounterSettings = copyFrom.RandomEncounterSettings;
          bp.Designer = copyFrom.Designer;
          bp.ArtSetting = copyFrom.ArtSetting;
          bp.AreaName = copyFrom.AreaName;
          bp.ExcludeFromSave = copyFrom.ExcludeFromSave;
          bp.PS4ChunkId = copyFrom.PS4ChunkId;
          bp.LoadingScreenSprites = copyFrom.LoadingScreenSprites;
          bp.m_DefaultPreset = copyFrom.m_DefaultPreset;
          bp.CR = copyFrom.CR;
          bp.OverrideCorruption = copyFrom.OverrideCorruption;
          bp.CorruptionGrowth = copyFrom.CorruptionGrowth;
          bp.LootSetting = copyFrom.LootSetting;
          bp.m_HotAreas = copyFrom.m_HotAreas;
          bp.IsMayMapWindow = copyFrom.IsMayMapWindow;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArea.m_Parts"/>
    /// </summary>
    ///
    /// <param name="parts">
    /// <para>
    /// Blueprint of type BlueprintAreaPart. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetParts(params Blueprint<BlueprintAreaPartReference>[] parts)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Parts = parts.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintArea.m_Parts"/>
    /// </summary>
    ///
    /// <param name="parts">
    /// <para>
    /// Blueprint of type BlueprintAreaPart. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToParts(params Blueprint<BlueprintAreaPartReference>[] parts)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Parts = bp.m_Parts ?? new();
          bp.m_Parts.AddRange(parts.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintArea.m_Parts"/>
    /// </summary>
    ///
    /// <param name="parts">
    /// <para>
    /// Blueprint of type BlueprintAreaPart. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromParts(params Blueprint<BlueprintAreaPartReference>[] parts)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Parts is null) { return; }
          bp.m_Parts = bp.m_Parts.Where(val => !parts.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintArea.m_Parts"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromParts(Func<BlueprintAreaPartReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Parts is null) { return; }
          bp.m_Parts = bp.m_Parts.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintArea.m_Parts"/>
    /// </summary>
    public TBuilder ClearParts()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Parts = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArea.m_Parts"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyParts(Action<BlueprintAreaPartReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Parts is null) { return; }
          bp.m_Parts.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArea.IsGlobalMap"/>
    /// </summary>
    public TBuilder SetIsGlobalMap(bool isGlobalMap = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsGlobalMap = isGlobalMap;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArea.CameraScrollMultiplier"/>
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
    /// Sets the value of <see cref="BlueprintArea.SetDefaultCameraRotation"/>
    /// </summary>
    public TBuilder SetSetDefaultCameraRotation(bool setDefaultCameraRotation = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SetDefaultCameraRotation = setDefaultCameraRotation;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArea.CameraRotation"/>
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
    /// Sets the value of <see cref="BlueprintArea.CampingSettings"/>
    /// </summary>
    public TBuilder SetCampingSettings(CampingSettings campingSettings)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(campingSettings);
          bp.CampingSettings = campingSettings;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArea.CampingSettings"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCampingSettings(Action<CampingSettings> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CampingSettings is null) { return; }
          action.Invoke(bp.CampingSettings);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArea.RandomEncounterSettings"/>
    /// </summary>
    public TBuilder SetRandomEncounterSettings(RandomEncounterSettings randomEncounterSettings)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(randomEncounterSettings);
          bp.RandomEncounterSettings = randomEncounterSettings;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArea.RandomEncounterSettings"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRandomEncounterSettings(Action<RandomEncounterSettings> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RandomEncounterSettings is null) { return; }
          action.Invoke(bp.RandomEncounterSettings);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArea.Designer"/>
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
    /// Sets the value of <see cref="BlueprintArea.ArtSetting"/>
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
    /// Sets the value of <see cref="BlueprintArea.AreaName"/>
    /// </summary>
    ///
    /// <param name="areaName">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetAreaName(LocalString areaName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AreaName = areaName?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArea.AreaName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAreaName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.AreaName is null) { return; }
          action.Invoke(bp.AreaName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArea.ExcludeFromSave"/>
    /// </summary>
    public TBuilder SetExcludeFromSave(bool excludeFromSave = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ExcludeFromSave = excludeFromSave;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArea.PS4ChunkId"/>
    /// </summary>
    ///
    /// <param name="pS4ChunkId">
    /// <para>
    /// Tooltip: Используется на PS4 чтобы разрезать игру на части. Пролог и зоны, нужные всю игру (типа глобалмапы) нужно класть в StartUp, остальное в нужную главу
    /// </para>
    /// </param>
    public TBuilder SetPS4ChunkId(PS4ChunkId pS4ChunkId)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.PS4ChunkId = pS4ChunkId;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArea.LoadingScreenSprites"/>
    /// </summary>
    ///
    /// <param name="loadingScreenSprites">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder SetLoadingScreenSprites(params AssetLink<SpriteLink>[] loadingScreenSprites)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LoadingScreenSprites = loadingScreenSprites?.Select(entry => entry?.Get())?.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintArea.LoadingScreenSprites"/>
    /// </summary>
    ///
    /// <param name="loadingScreenSprites">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder AddToLoadingScreenSprites(params AssetLink<SpriteLink>[] loadingScreenSprites)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LoadingScreenSprites = bp.LoadingScreenSprites ?? new();
          bp.LoadingScreenSprites.AddRange(loadingScreenSprites?.Select(entry => entry?.Get()));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintArea.LoadingScreenSprites"/>
    /// </summary>
    ///
    /// <param name="loadingScreenSprites">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder RemoveFromLoadingScreenSprites(params AssetLink<SpriteLink>[] loadingScreenSprites)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LoadingScreenSprites is null) { return; }
          var convertedParams = loadingScreenSprites.Select(entry => entry?.Get());
          bp.LoadingScreenSprites = bp.LoadingScreenSprites.Where(val => !convertedParams.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintArea.LoadingScreenSprites"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromLoadingScreenSprites(Func<SpriteLink, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LoadingScreenSprites is null) { return; }
          bp.LoadingScreenSprites = bp.LoadingScreenSprites.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintArea.LoadingScreenSprites"/>
    /// </summary>
    public TBuilder ClearLoadingScreenSprites()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LoadingScreenSprites = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArea.LoadingScreenSprites"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyLoadingScreenSprites(Action<SpriteLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LoadingScreenSprites is null) { return; }
          bp.LoadingScreenSprites.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArea.m_DefaultPreset"/>
    /// </summary>
    ///
    /// <param name="defaultPreset">
    /// <para>
    /// Blueprint of type BlueprintAreaPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetDefaultPreset(Blueprint<BlueprintAreaPresetReference> defaultPreset)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DefaultPreset = defaultPreset?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArea.m_DefaultPreset"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDefaultPreset(Action<BlueprintAreaPresetReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DefaultPreset is null) { return; }
          action.Invoke(bp.m_DefaultPreset);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArea.CR"/>
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
    /// Sets the value of <see cref="BlueprintArea.OverrideCorruption"/>
    /// </summary>
    public TBuilder SetOverrideCorruption(bool overrideCorruption = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OverrideCorruption = overrideCorruption;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArea.CorruptionGrowth"/>
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
    /// Sets the value of <see cref="BlueprintArea.LootSetting"/>
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
    /// Sets the value of <see cref="BlueprintArea.m_HotAreas"/>
    /// </summary>
    ///
    /// <param name="hotAreas">
    /// <para>
    /// Tooltip: Areas, which scenes should be kept loaded when switching to this area
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintArea. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetHotAreas(params Blueprint<BlueprintAreaReference>[] hotAreas)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_HotAreas = hotAreas.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintArea.m_HotAreas"/>
    /// </summary>
    ///
    /// <param name="hotAreas">
    /// <para>
    /// Tooltip: Areas, which scenes should be kept loaded when switching to this area
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintArea. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToHotAreas(params Blueprint<BlueprintAreaReference>[] hotAreas)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_HotAreas = bp.m_HotAreas ?? new BlueprintAreaReference[0];
          bp.m_HotAreas = CommonTool.Append(bp.m_HotAreas, hotAreas.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintArea.m_HotAreas"/>
    /// </summary>
    ///
    /// <param name="hotAreas">
    /// <para>
    /// Tooltip: Areas, which scenes should be kept loaded when switching to this area
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintArea. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromHotAreas(params Blueprint<BlueprintAreaReference>[] hotAreas)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_HotAreas is null) { return; }
          bp.m_HotAreas = bp.m_HotAreas.Where(val => !hotAreas.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintArea.m_HotAreas"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromHotAreas(Func<BlueprintAreaReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_HotAreas is null) { return; }
          bp.m_HotAreas = bp.m_HotAreas.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintArea.m_HotAreas"/>
    /// </summary>
    public TBuilder ClearHotAreas()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_HotAreas = new BlueprintAreaReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArea.m_HotAreas"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyHotAreas(Action<BlueprintAreaReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_HotAreas is null) { return; }
          bp.m_HotAreas.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArea.IsMayMapWindow"/>
    /// </summary>
    public TBuilder SetIsMayMapWindow(bool isMayMapWindow = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsMayMapWindow = isMayMapWindow;
        });
    }

    /// <summary>
    /// Adds <see cref="CampingEncounterIncreaseDifficulty"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC2_Graveyard</term><description>cda59ec4352849febaf0bf52fd55074d</description></item>
    /// <item><term>DLC2_RichQuarter</term><description>caf98d57bafa456d9a0afc98f25fe720</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddCampingEncounterIncreaseDifficulty(
        float? increaseChance = null,
        int? increaseDifficulty = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new CampingEncounterIncreaseDifficulty();
      component.m_IncreaseChance = increaseChance ?? component.m_IncreaseChance;
      component.m_IncreaseDifficulty = increaseDifficulty ?? component.m_IncreaseDifficulty;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="CombatRandomEncounterAreaSettings"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>RE_KareliaCanyon</term><description>03fca664fc43fb040aae42bb0f41c23c</description></item>
    /// <item><term>RE_SarkorisDisaster_2</term><description>c7125176689d3814199266e2ad2c3077</description></item>
    /// <item><term>RE_WoundedForest</term><description>da702e8d79c6046439c17e7e9cbfd758</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="defaultEnterPoint">
    /// <para>
    /// Blueprint of type BlueprintAreaEnterPoint. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="goodAvoidanceEnterPoint">
    /// <para>
    /// Blueprint of type BlueprintAreaEnterPoint. You can pass in the blueprint using:
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
    public TBuilder AddCombatRandomEncounterAreaSettings(
        GlobalMapZone[]? allowedNaturalSettings = null,
        Blueprint<BlueprintAreaEnterPointReference>? defaultEnterPoint = null,
        CombatRandomEncounterAreaSettings.Formation[]? formations = null,
        Blueprint<BlueprintAreaEnterPointReference>? goodAvoidanceEnterPoint = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new CombatRandomEncounterAreaSettings();
      component.AllowedNaturalSettings = allowedNaturalSettings ?? component.AllowedNaturalSettings;
      if (component.AllowedNaturalSettings is null)
      {
        component.AllowedNaturalSettings = new GlobalMapZone[0];
      }
      component.m_DefaultEnterPoint = defaultEnterPoint?.Reference ?? component.m_DefaultEnterPoint;
      if (component.m_DefaultEnterPoint is null)
      {
        component.m_DefaultEnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(null);
      }
      Validate(formations);
      component.Formations = formations ?? component.Formations;
      if (component.Formations is null)
      {
        component.Formations = new CombatRandomEncounterAreaSettings.Formation[0];
      }
      component.m_GoodAvoidanceEnterPoint = goodAvoidanceEnterPoint?.Reference ?? component.m_GoodAvoidanceEnterPoint;
      if (component.m_GoodAvoidanceEnterPoint is null)
      {
        component.m_GoodAvoidanceEnterPoint = BlueprintTool.GetRef<BlueprintAreaEnterPointReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="DungeonArea"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DLC3_Alushinyrra_Whorehouse_lvl_01</term><description>e25e817958684dbaa34f741ba66bbe8f</description></item>
    /// <item><term>DLC3_Island_PiratesBesmar_3</term><description>ac831d4ca7854fe5a36f355d530929cc</description></item>
    /// <item><term>FireDungeon_lvl_01</term><description>578e9e6c28c34bb980f721add45615e0</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="modifyUnitsFaction">
    /// <para>
    /// Tooltip: Switch the spawned units faction to the one set in the dungeon root
    /// </para>
    /// </param>
    public TBuilder AddDungeonArea(
        DungeonRoomSettings? exterior = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? modifyUnitsFaction = null,
        EntityReference? rewardScriptZone = null,
        List<DungeonRoomSettings>? rooms = null)
    {
      var component = new DungeonArea();
      Validate(exterior);
      component.Exterior = exterior ?? component.Exterior;
      component.ModifyUnitsFaction = modifyUnitsFaction ?? component.ModifyUnitsFaction;
      Validate(rewardScriptZone);
      component.RewardScriptZone = rewardScriptZone ?? component.RewardScriptZone;
      Validate(rooms);
      component.Rooms = rooms ?? component.Rooms;
      if (component.Rooms is null)
      {
        component.Rooms = new();
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="OverrideCampingAction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AzataIsland</term><description>31bab5549f7ea384186159a238360c8d</description></item>
    /// <item><term>DLC3_BloodIvory_lvl_08</term><description>871be5663e764a87b733d0ef472ede13</description></item>
    /// <item><term>WarCamp</term><description>7a25c101fe6f7aa46b192db13373d03b</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddOverrideCampingAction(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        ActionsBuilder? onRestActions = null,
        bool? skipRest = null)
    {
      var component = new OverrideCampingAction();
      component.OnRestActions = onRestActions?.Build() ?? component.OnRestActions;
      if (component.OnRestActions is null)
      {
        component.OnRestActions = Utils.Constants.Empty.Actions;
      }
      component.SkipRest = skipRest ?? component.SkipRest;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="EveryDayTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AutoKingdomProjectsControllerCh3</term><description>b31b96dd34f8415382c8ec26787364d3</description></item>
    /// <item><term>FlagTrickster3Economy</term><description>4b833c6fcdfa47918927d80edf7ef9ae</description></item>
    /// <item><term>SettlementsTracker_buff</term><description>71dd611cd70443fcb04f0dce3bda76ef</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEveryDayTrigger(
        ActionsBuilder? actions = null,
        ConditionsBuilder? condition = null,
        int? skipDays = null)
    {
      var component = new EveryDayTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.Condition = condition?.Build() ?? component.Condition;
      if (component.Condition is null)
      {
        component.Condition = Utils.Constants.Empty.Conditions;
      }
      component.SkipDays = skipDays ?? component.SkipDays;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EveryWeekTrigger"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FlagTrickster1Money</term><description>6c97784129e5492fa08496f2d4139f22</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddEveryWeekTrigger(
        ActionsBuilder? actions = null,
        ConditionsBuilder? condition = null,
        int? skipWeeks = null)
    {
      var component = new EveryWeekTrigger();
      component.Actions = actions?.Build() ?? component.Actions;
      if (component.Actions is null)
      {
        component.Actions = Utils.Constants.Empty.Actions;
      }
      component.Condition = condition?.Build() ?? component.Condition;
      if (component.Condition is null)
      {
        component.Condition = Utils.Constants.Empty.Conditions;
      }
      component.SkipWeeks = skipWeeks ?? component.SkipWeeks;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SettlementAISettings"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DireNarlmarches</term><description>2324df9aed3e41941823f4431ccabe48</description></item>
    /// <item><term>Outskirts</term><description>b383f239d93c0854eafde50bc583226f</description></item>
    /// <item><term>Varnhold_Water</term><description>8928e6ab3ff319d458453f1e037d2205</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="aIBuildListCity">
    /// <para>
    /// Blueprint of type SettlementBuildList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="aIBuildListTown">
    /// <para>
    /// Blueprint of type SettlementBuildList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="aIBuildListVillage">
    /// <para>
    /// Blueprint of type SettlementBuildList. You can pass in the blueprint using:
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
    public TBuilder AddSettlementAISettings(
        Blueprint<SettlementBuildListReference>? aIBuildListCity = null,
        Blueprint<SettlementBuildListReference>? aIBuildListTown = null,
        Blueprint<SettlementBuildListReference>? aIBuildListVillage = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new SettlementAISettings();
      component.m_AIBuildListCity = aIBuildListCity?.Reference ?? component.m_AIBuildListCity;
      if (component.m_AIBuildListCity is null)
      {
        component.m_AIBuildListCity = BlueprintTool.GetRef<SettlementBuildListReference>(null);
      }
      component.m_AIBuildListTown = aIBuildListTown?.Reference ?? component.m_AIBuildListTown;
      if (component.m_AIBuildListTown is null)
      {
        component.m_AIBuildListTown = BlueprintTool.GetRef<SettlementBuildListReference>(null);
      }
      component.m_AIBuildListVillage = aIBuildListVillage?.Reference ?? component.m_AIBuildListVillage;
      if (component.m_AIBuildListVillage is null)
      {
        component.m_AIBuildListVillage = BlueprintTool.GetRef<SettlementBuildListReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Parts is null)
      {
        Blueprint.m_Parts = new();
      }
      if (Blueprint.AreaName is null)
      {
        Blueprint.AreaName = Utils.Constants.Empty.String;
      }
      if (Blueprint.LoadingScreenSprites is null)
      {
        Blueprint.LoadingScreenSprites = new();
      }
      if (Blueprint.m_DefaultPreset is null)
      {
        Blueprint.m_DefaultPreset = BlueprintTool.GetRef<BlueprintAreaPresetReference>(null);
      }
      if (Blueprint.m_HotAreas is null)
      {
        Blueprint.m_HotAreas = new BlueprintAreaReference[0];
      }
    }
  }
}
