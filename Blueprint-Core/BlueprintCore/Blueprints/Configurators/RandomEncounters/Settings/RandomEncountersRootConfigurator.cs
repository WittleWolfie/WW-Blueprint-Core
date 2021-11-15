using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Globalmap.View;
using Kingmaker.RandomEncounters.Settings;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.RandomEncounters.Settings
{
  /// <summary>Configurator for <see cref="RandomEncountersRoot"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(RandomEncountersRoot))]
  public class RandomEncountersRootConfigurator : BaseBlueprintConfigurator<RandomEncountersRoot, RandomEncountersRootConfigurator>
  {
     private RandomEncountersRootConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static RandomEncountersRootConfigurator For(string name)
    {
      return new RandomEncountersRootConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static RandomEncountersRootConfigurator New(string name)
    {
      BlueprintTool.Create<RandomEncountersRoot>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static RandomEncountersRootConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<RandomEncountersRoot>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="RandomEncountersRoot.EncountersEnabled"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator SetEncountersEnabled(bool value)
    {
      return OnConfigureInternal(bp => bp.EncountersEnabled = value);
    }

    /// <summary>
    /// Modifies <see cref="RandomEncountersRoot.m_Chapters"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator AddToChapters(params RandomEncounterChapterSettings[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_Chapters = CommonTool.Append(bp.m_Chapters, values));
    }

    /// <summary>
    /// Modifies <see cref="RandomEncountersRoot.m_Chapters"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator RemoveFromChapters(params RandomEncounterChapterSettings[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_Chapters = bp.m_Chapters.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="RandomEncountersRoot.EncounterPawnPrefab"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator SetEncounterPawnPrefab(GlobalMapRandomEncounterPawn value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.EncounterPawnPrefab = value);
    }

    /// <summary>
    /// Sets <see cref="RandomEncountersRoot.EncounterPawnOffset"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator SetEncounterPawnOffset(float value)
    {
      return OnConfigureInternal(bp => bp.EncounterPawnOffset = value);
    }

    /// <summary>
    /// Sets <see cref="RandomEncountersRoot.EncounterPawnDistanceFromLocation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator SetEncounterPawnDistanceFromLocation(float value)
    {
      return OnConfigureInternal(bp => bp.EncounterPawnDistanceFromLocation = value);
    }

    /// <summary>
    /// Sets <see cref="RandomEncountersRoot.m_TrashLootSettings"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="TrashLootSettings"/></param>
    [Generated]
    public RandomEncountersRootConfigurator SetTrashLootSettings(string value)
    {
      return OnConfigureInternal(bp => bp.m_TrashLootSettings = BlueprintTool.GetRef<TrashLootSettingsReference>(value));
    }

    /// <summary>
    /// Modifies <see cref="RandomEncountersRoot.ZoneSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator AddToZoneSettings(params ZoneCombatRandomEncounterSettings[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.ZoneSettings = CommonTool.Append(bp.ZoneSettings, values));
    }

    /// <summary>
    /// Modifies <see cref="RandomEncountersRoot.ZoneSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator RemoveFromZoneSettings(params ZoneCombatRandomEncounterSettings[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.ZoneSettings = bp.ZoneSettings.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="RandomEncountersRoot.m_Encounters"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintRandomEncounter"/></param>
    [Generated]
    public RandomEncountersRootConfigurator AddToEncounters(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Encounters.AddRange(values.Select(name => BlueprintTool.GetRef<BlueprintRandomEncounterReference>(name))));
    }

    /// <summary>
    /// Modifies <see cref="RandomEncountersRoot.m_Encounters"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintRandomEncounter"/></param>
    [Generated]
    public RandomEncountersRootConfigurator RemoveFromEncounters(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintRandomEncounterReference>(name));
            bp.m_Encounters =
                bp.m_Encounters
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToList();
          });
    }

    /// <summary>
    /// Modifies <see cref="RandomEncountersRoot.Armies"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator AddToArmies(params ArmySettings[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Armies = CommonTool.Append(bp.Armies, values));
    }

    /// <summary>
    /// Modifies <see cref="RandomEncountersRoot.Armies"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator RemoveFromArmies(params ArmySettings[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Armies = bp.Armies.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="RandomEncountersRoot.m_Vendor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator SetVendor(REVendor value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_Vendor = value);
    }

    /// <summary>
    /// Sets <see cref="RandomEncountersRoot.MaxExperiencePerUnitDivisor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator SetMaxExperiencePerUnitDivisor(int value)
    {
      return OnConfigureInternal(bp => bp.MaxExperiencePerUnitDivisor = value);
    }

    /// <summary>
    /// Sets <see cref="RandomEncountersRoot.MinExperiencePerUnitDivisor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator SetMinExperiencePerUnitDivisor(int value)
    {
      return OnConfigureInternal(bp => bp.MinExperiencePerUnitDivisor = value);
    }

    /// <summary>
    /// Sets <see cref="RandomEncountersRoot.MaxTargetExperienceDivisor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RandomEncountersRootConfigurator SetMaxTargetExperienceDivisor(int value)
    {
      return OnConfigureInternal(bp => bp.MaxTargetExperienceDivisor = value);
    }
  }
}
