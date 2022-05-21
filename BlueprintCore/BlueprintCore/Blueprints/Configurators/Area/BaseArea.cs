//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Enums;
using Kingmaker.Kingdom.AI;
using Kingmaker.Kingdom.Buffs;
using Kingmaker.Localization;
using Kingmaker.RandomEncounters;
using Kingmaker.RandomEncounters.Settings;
using Kingmaker.ResourceLinks;
using Kingmaker.Utility;
using System;
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
    protected BaseAreaConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetParts(params Blueprint<BlueprintAreaPart, BlueprintAreaPartReference>[] parts)
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToParts(params Blueprint<BlueprintAreaPart, BlueprintAreaPartReference>[] parts)
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromParts(params Blueprint<BlueprintAreaPart, BlueprintAreaPartReference>[] parts)
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromParts(Func<BlueprintAreaPartReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Parts is null) { return; }
          bp.m_Parts = bp.m_Parts.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintArea.m_Parts"/>
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
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
    /// Modifies <see cref="BlueprintArea.IsGlobalMap"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIsGlobalMap(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.IsGlobalMap);
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
    /// Modifies <see cref="BlueprintArea.CameraScrollMultiplier"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCameraScrollMultiplier(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.CameraScrollMultiplier);
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
    /// Modifies <see cref="BlueprintArea.SetDefaultCameraRotation"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySetDefaultCameraRotation(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.SetDefaultCameraRotation);
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
    /// Modifies <see cref="BlueprintArea.CameraRotation"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCameraRotation(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.CameraRotation);
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
    /// Modifies <see cref="BlueprintArea.Designer"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDesigner(Action<BlueprintArea.Designers> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Designer);
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
    /// Modifies <see cref="BlueprintArea.ArtSetting"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyArtSetting(Action<BlueprintArea.SettingType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ArtSetting);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArea.AreaName"/>
    /// </summary>
    public TBuilder SetAreaName(LocalizedString areaName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AreaName = areaName;
          if (bp.AreaName is null)
          {
            bp.AreaName = Utils.Constants.Empty.String;
          }
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
    /// Modifies <see cref="BlueprintArea.ExcludeFromSave"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyExcludeFromSave(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ExcludeFromSave);
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
    /// Modifies <see cref="BlueprintArea.PS4ChunkId"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="pS4ChunkId">
    /// <para>
    /// Tooltip: Используется на PS4 чтобы разрезать игру на части. Пролог и зоны, нужные всю игру (типа глобалмапы) нужно класть в StartUp, остальное в нужную главу
    /// </para>
    /// </param>
    public TBuilder ModifyPS4ChunkId(Action<PS4ChunkId> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.PS4ChunkId);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintArea.LoadingScreenSprites"/>
    /// </summary>
    public TBuilder SetLoadingScreenSprites(params SpriteLink[] loadingScreenSprites)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in loadingScreenSprites) { Validate(item); }
          bp.LoadingScreenSprites = loadingScreenSprites.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintArea.LoadingScreenSprites"/>
    /// </summary>
    public TBuilder AddToLoadingScreenSprites(params SpriteLink[] loadingScreenSprites)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LoadingScreenSprites = bp.LoadingScreenSprites ?? new();
          bp.LoadingScreenSprites.AddRange(loadingScreenSprites);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintArea.LoadingScreenSprites"/>
    /// </summary>
    public TBuilder RemoveFromLoadingScreenSprites(params SpriteLink[] loadingScreenSprites)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LoadingScreenSprites is null) { return; }
          bp.LoadingScreenSprites = bp.LoadingScreenSprites.Where(val => !loadingScreenSprites.Contains(val)).ToList();
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
          bp.LoadingScreenSprites = bp.LoadingScreenSprites.Where(predicate).ToList();
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetDefaultPreset(Blueprint<BlueprintAreaPreset, BlueprintAreaPresetReference> defaultPreset)
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
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
    /// Modifies <see cref="BlueprintArea.CR"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCR(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.CR);
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
    /// Modifies <see cref="BlueprintArea.OverrideCorruption"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOverrideCorruption(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.OverrideCorruption);
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
    /// Modifies <see cref="BlueprintArea.CorruptionGrowth"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCorruptionGrowth(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.CorruptionGrowth);
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
    /// Modifies <see cref="BlueprintArea.LootSetting"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLootSetting(Action<LootSetting> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.LootSetting);
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetHotAreas(params Blueprint<BlueprintArea, BlueprintAreaReference>[] hotAreas)
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToHotAreas(params Blueprint<BlueprintArea, BlueprintAreaReference>[] hotAreas)
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromHotAreas(params Blueprint<BlueprintArea, BlueprintAreaReference>[] hotAreas)
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromHotAreas(Func<BlueprintAreaReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_HotAreas is null) { return; }
          bp.m_HotAreas = bp.m_HotAreas.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintArea.m_HotAreas"/>
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
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
    public TBuilder AddCampingEncounterIncreaseDifficulty(
        float? increaseChance = null,
        int? increaseDifficulty = null)
    {
      var component = new CampingEncounterIncreaseDifficulty();
      component.m_IncreaseChance = increaseChance ?? component.m_IncreaseChance;
      component.m_IncreaseDifficulty = increaseDifficulty ?? component.m_IncreaseDifficulty;
      return AddComponent(component);
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddCombatRandomEncounterAreaSettings(
        GlobalMapZone[]? allowedNaturalSettings = null,
        Blueprint<BlueprintAreaEnterPoint, BlueprintAreaEnterPointReference>? defaultEnterPoint = null,
        CombatRandomEncounterAreaSettings.Formation[]? formations = null,
        Blueprint<BlueprintAreaEnterPoint, BlueprintAreaEnterPointReference>? goodAvoidanceEnterPoint = null)
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
      foreach (var item in formations) { Validate(item); }
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
      return AddComponent(component);
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
    /// <item><term>DLC2_Tavern</term><description>dec10943d88040d0962f530cb4f2be63</description></item>
    /// <item><term>WarCamp</term><description>7a25c101fe6f7aa46b192db13373d03b</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddOverrideCampingAction(
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
      return AddComponent(component);
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
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddEveryDayTrigger(
        ActionsBuilder? actions = null,
        ConditionsBuilder? condition = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
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
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddEveryWeekTrigger(
        ActionsBuilder? actions = null,
        ConditionsBuilder? condition = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Merge,
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
      return AddUniqueComponent(component, mergeBehavior, merge);
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
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
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddSettlementAISettings(
        Blueprint<SettlementBuildList, SettlementBuildListReference>? aIBuildListCity = null,
        Blueprint<SettlementBuildList, SettlementBuildListReference>? aIBuildListTown = null,
        Blueprint<SettlementBuildList, SettlementBuildListReference>? aIBuildListVillage = null)
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
      return AddComponent(component);
    }
  }
}
