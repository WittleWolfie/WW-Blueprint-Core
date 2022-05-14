//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Globalmap.View;
using Kingmaker.RandomEncounters.Settings;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.RandomEncounters
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="RandomEncountersRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseRandomEncountersRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : RandomEncountersRoot
    where TBuilder : BaseRandomEncountersRootConfigurator<T, TBuilder>
  {
    protected BaseRandomEncountersRootConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="RandomEncountersRoot.EncountersEnabled"/>
    /// </summary>
    public TBuilder SetEncountersEnabled(bool encountersEnabled = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.EncountersEnabled = encountersEnabled;
        });
    }

    /// <summary>
    /// Modifies <see cref="RandomEncountersRoot.EncountersEnabled"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyEncountersEnabled(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.EncountersEnabled);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="RandomEncountersRoot.m_Chapters"/>
    /// </summary>
    public TBuilder SetChapters(RandomEncounterChapterSettings[] chapters)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in chapters) { Validate(item); }
          bp.m_Chapters = chapters;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="RandomEncountersRoot.m_Chapters"/>
    /// </summary>
    public TBuilder AddToChapters(params RandomEncounterChapterSettings[] chapters)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Chapters = bp.m_Chapters ?? new RandomEncounterChapterSettings[0];
          bp.m_Chapters = CommonTool.Append(bp.m_Chapters, chapters);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="RandomEncountersRoot.m_Chapters"/>
    /// </summary>
    public TBuilder RemoveFromChapters(params RandomEncounterChapterSettings[] chapters)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Chapters is null) { return; }
          bp.m_Chapters = bp.m_Chapters.Where(val => !chapters.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="RandomEncountersRoot.m_Chapters"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromChapters(Func<RandomEncounterChapterSettings, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Chapters is null) { return; }
          bp.m_Chapters = bp.m_Chapters.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="RandomEncountersRoot.m_Chapters"/>
    /// </summary>
    public TBuilder ClearChapters()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Chapters = new RandomEncounterChapterSettings[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="RandomEncountersRoot.m_Chapters"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyChapters(Action<RandomEncounterChapterSettings> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Chapters is null) { return; }
          bp.m_Chapters.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="RandomEncountersRoot.EncounterPawnPrefab"/>
    /// </summary>
    public TBuilder SetEncounterPawnPrefab(GlobalMapRandomEncounterPawn encounterPawnPrefab)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(encounterPawnPrefab);
          bp.EncounterPawnPrefab = encounterPawnPrefab;
        });
    }

    /// <summary>
    /// Modifies <see cref="RandomEncountersRoot.EncounterPawnPrefab"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyEncounterPawnPrefab(Action<GlobalMapRandomEncounterPawn> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.EncounterPawnPrefab is null) { return; }
          action.Invoke(bp.EncounterPawnPrefab);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="RandomEncountersRoot.EncounterPawnOffset"/>
    /// </summary>
    public TBuilder SetEncounterPawnOffset(float encounterPawnOffset)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.EncounterPawnOffset = encounterPawnOffset;
        });
    }

    /// <summary>
    /// Modifies <see cref="RandomEncountersRoot.EncounterPawnOffset"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyEncounterPawnOffset(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.EncounterPawnOffset);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="RandomEncountersRoot.EncounterPawnDistanceFromLocation"/>
    /// </summary>
    public TBuilder SetEncounterPawnDistanceFromLocation(float encounterPawnDistanceFromLocation)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.EncounterPawnDistanceFromLocation = encounterPawnDistanceFromLocation;
        });
    }

    /// <summary>
    /// Modifies <see cref="RandomEncountersRoot.EncounterPawnDistanceFromLocation"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyEncounterPawnDistanceFromLocation(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.EncounterPawnDistanceFromLocation);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="RandomEncountersRoot.m_TrashLootSettings"/>
    /// </summary>
    ///
    /// <param name="trashLootSettings">
    /// <para>
    /// Blueprint of type TrashLootSettings. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetTrashLootSettings(Blueprint<TrashLootSettings, TrashLootSettingsReference> trashLootSettings)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TrashLootSettings = trashLootSettings?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="RandomEncountersRoot.m_TrashLootSettings"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="trashLootSettings">
    /// <para>
    /// Blueprint of type TrashLootSettings. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyTrashLootSettings(Action<TrashLootSettingsReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TrashLootSettings is null) { return; }
          action.Invoke(bp.m_TrashLootSettings);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="RandomEncountersRoot.ZoneSettings"/>
    /// </summary>
    public TBuilder SetZoneSettings(ZoneCombatRandomEncounterSettings[] zoneSettings)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in zoneSettings) { Validate(item); }
          bp.ZoneSettings = zoneSettings;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="RandomEncountersRoot.ZoneSettings"/>
    /// </summary>
    public TBuilder AddToZoneSettings(params ZoneCombatRandomEncounterSettings[] zoneSettings)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ZoneSettings = bp.ZoneSettings ?? new ZoneCombatRandomEncounterSettings[0];
          bp.ZoneSettings = CommonTool.Append(bp.ZoneSettings, zoneSettings);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="RandomEncountersRoot.ZoneSettings"/>
    /// </summary>
    public TBuilder RemoveFromZoneSettings(params ZoneCombatRandomEncounterSettings[] zoneSettings)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ZoneSettings is null) { return; }
          bp.ZoneSettings = bp.ZoneSettings.Where(val => !zoneSettings.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="RandomEncountersRoot.ZoneSettings"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromZoneSettings(Func<ZoneCombatRandomEncounterSettings, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ZoneSettings is null) { return; }
          bp.ZoneSettings = bp.ZoneSettings.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="RandomEncountersRoot.ZoneSettings"/>
    /// </summary>
    public TBuilder ClearZoneSettings()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ZoneSettings = new ZoneCombatRandomEncounterSettings[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="RandomEncountersRoot.ZoneSettings"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyZoneSettings(Action<ZoneCombatRandomEncounterSettings> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ZoneSettings is null) { return; }
          bp.ZoneSettings.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="RandomEncountersRoot.m_Encounters"/>
    /// </summary>
    ///
    /// <param name="encounters">
    /// <para>
    /// Blueprint of type BlueprintRandomEncounter. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetEncounters(List<Blueprint<BlueprintRandomEncounter, BlueprintRandomEncounterReference>> encounters)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Encounters = encounters?.Select(bp => bp.Reference)?.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="RandomEncountersRoot.m_Encounters"/>
    /// </summary>
    ///
    /// <param name="encounters">
    /// <para>
    /// Blueprint of type BlueprintRandomEncounter. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToEncounters(params Blueprint<BlueprintRandomEncounter, BlueprintRandomEncounterReference>[] encounters)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Encounters = bp.m_Encounters ?? new();
          bp.m_Encounters.AddRange(encounters.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="RandomEncountersRoot.m_Encounters"/>
    /// </summary>
    ///
    /// <param name="encounters">
    /// <para>
    /// Blueprint of type BlueprintRandomEncounter. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromEncounters(params Blueprint<BlueprintRandomEncounter, BlueprintRandomEncounterReference>[] encounters)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Encounters is null) { return; }
          bp.m_Encounters = bp.m_Encounters.Where(val => !encounters.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="RandomEncountersRoot.m_Encounters"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="encounters">
    /// <para>
    /// Blueprint of type BlueprintRandomEncounter. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromEncounters(Func<BlueprintRandomEncounterReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Encounters is null) { return; }
          bp.m_Encounters = bp.m_Encounters.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="RandomEncountersRoot.m_Encounters"/>
    /// </summary>
    ///
    /// <param name="encounters">
    /// <para>
    /// Blueprint of type BlueprintRandomEncounter. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearEncounters()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Encounters = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="RandomEncountersRoot.m_Encounters"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="encounters">
    /// <para>
    /// Blueprint of type BlueprintRandomEncounter. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyEncounters(Action<BlueprintRandomEncounterReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Encounters is null) { return; }
          bp.m_Encounters.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="RandomEncountersRoot.Armies"/>
    /// </summary>
    public TBuilder SetArmies(ArmySettings[] armies)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in armies) { Validate(item); }
          bp.Armies = armies;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="RandomEncountersRoot.Armies"/>
    /// </summary>
    public TBuilder AddToArmies(params ArmySettings[] armies)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Armies = bp.Armies ?? new ArmySettings[0];
          bp.Armies = CommonTool.Append(bp.Armies, armies);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="RandomEncountersRoot.Armies"/>
    /// </summary>
    public TBuilder RemoveFromArmies(params ArmySettings[] armies)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Armies is null) { return; }
          bp.Armies = bp.Armies.Where(val => !armies.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="RandomEncountersRoot.Armies"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromArmies(Func<ArmySettings, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Armies is null) { return; }
          bp.Armies = bp.Armies.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="RandomEncountersRoot.Armies"/>
    /// </summary>
    public TBuilder ClearArmies()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Armies = new ArmySettings[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="RandomEncountersRoot.Armies"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyArmies(Action<ArmySettings> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Armies is null) { return; }
          bp.Armies.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="RandomEncountersRoot.m_Vendor"/>
    /// </summary>
    public TBuilder SetVendor(REVendor vendor)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(vendor);
          bp.m_Vendor = vendor;
        });
    }

    /// <summary>
    /// Modifies <see cref="RandomEncountersRoot.m_Vendor"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyVendor(Action<REVendor> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Vendor is null) { return; }
          action.Invoke(bp.m_Vendor);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="RandomEncountersRoot.MaxExperiencePerUnitDivisor"/>
    /// </summary>
    public TBuilder SetMaxExperiencePerUnitDivisor(int maxExperiencePerUnitDivisor)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MaxExperiencePerUnitDivisor = maxExperiencePerUnitDivisor;
        });
    }

    /// <summary>
    /// Modifies <see cref="RandomEncountersRoot.MaxExperiencePerUnitDivisor"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMaxExperiencePerUnitDivisor(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MaxExperiencePerUnitDivisor);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="RandomEncountersRoot.MinExperiencePerUnitDivisor"/>
    /// </summary>
    public TBuilder SetMinExperiencePerUnitDivisor(int minExperiencePerUnitDivisor)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MinExperiencePerUnitDivisor = minExperiencePerUnitDivisor;
        });
    }

    /// <summary>
    /// Modifies <see cref="RandomEncountersRoot.MinExperiencePerUnitDivisor"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMinExperiencePerUnitDivisor(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MinExperiencePerUnitDivisor);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="RandomEncountersRoot.MaxTargetExperienceDivisor"/>
    /// </summary>
    public TBuilder SetMaxTargetExperienceDivisor(int maxTargetExperienceDivisor)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MaxTargetExperienceDivisor = maxTargetExperienceDivisor;
        });
    }

    /// <summary>
    /// Modifies <see cref="RandomEncountersRoot.MaxTargetExperienceDivisor"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMaxTargetExperienceDivisor(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MaxTargetExperienceDivisor);
        });
    }
  }
}
