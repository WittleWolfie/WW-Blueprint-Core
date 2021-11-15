using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>Configurator for <see cref="BlueprintProgression"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintProgression))]
  public class ProgressionConfigurator : BaseFeatureConfigurator<BlueprintProgression, ProgressionConfigurator>
  {
     private ProgressionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ProgressionConfigurator For(string name)
    {
      return new ProgressionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ProgressionConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintProgression>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ProgressionConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintProgression>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProgression.m_Classes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator AddToClasses(params BlueprintProgression.ClassWithLevel[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_Classes = CommonTool.Append(bp.m_Classes, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProgression.m_Classes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator RemoveFromClasses(params BlueprintProgression.ClassWithLevel[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_Classes = bp.m_Classes.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProgression.m_Archetypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator AddToArchetypes(params BlueprintProgression.ArchetypeWithLevel[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_Archetypes = CommonTool.Append(bp.m_Archetypes, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProgression.m_Archetypes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator RemoveFromArchetypes(params BlueprintProgression.ArchetypeWithLevel[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_Archetypes = bp.m_Archetypes.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="BlueprintProgression.ForAllOtherClasses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator SetForAllOtherClasses(bool value)
    {
      return OnConfigureInternal(bp => bp.ForAllOtherClasses = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProgression.m_AlternateProgressionClasses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator AddToAlternateProgressionClasses(params BlueprintProgression.ClassWithLevel[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_AlternateProgressionClasses = CommonTool.Append(bp.m_AlternateProgressionClasses, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProgression.m_AlternateProgressionClasses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator RemoveFromAlternateProgressionClasses(params BlueprintProgression.ClassWithLevel[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_AlternateProgressionClasses = bp.m_AlternateProgressionClasses.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="BlueprintProgression.AlternateProgressionType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator SetAlternateProgressionType(AlternateProgressionType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.AlternateProgressionType = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProgression.LevelEntries"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator AddToLevelEntries(params LevelEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.LevelEntries = CommonTool.Append(bp.LevelEntries, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProgression.LevelEntries"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator RemoveFromLevelEntries(params LevelEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.LevelEntries = bp.LevelEntries.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProgression.UIGroups"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator AddToUIGroups(params UIGroup[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.UIGroups = CommonTool.Append(bp.UIGroups, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProgression.UIGroups"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator RemoveFromUIGroups(params UIGroup[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.UIGroups = bp.UIGroups.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProgression.m_UIDeterminatorsGroup"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintFeatureBase"/></param>
    [Generated]
    public ProgressionConfigurator AddToUIDeterminatorsGroup(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_UIDeterminatorsGroup = CommonTool.Append(bp.m_UIDeterminatorsGroup, values.Select(name => BlueprintTool.GetRef<BlueprintFeatureBaseReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProgression.m_UIDeterminatorsGroup"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintFeatureBase"/></param>
    [Generated]
    public ProgressionConfigurator RemoveFromUIDeterminatorsGroup(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintFeatureBaseReference>(name));
            bp.m_UIDeterminatorsGroup =
                bp.m_UIDeterminatorsGroup
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintProgression.m_ExclusiveProgression"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    public ProgressionConfigurator SetExclusiveProgression(string value)
    {
      return OnConfigureInternal(bp => bp.m_ExclusiveProgression = BlueprintTool.GetRef<BlueprintCharacterClassReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintProgression.GiveFeaturesForPreviousLevels"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ProgressionConfigurator SetGiveFeaturesForPreviousLevels(bool value)
    {
      return OnConfigureInternal(bp => bp.GiveFeaturesForPreviousLevels = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintProgression.m_FeatureRankIncrease"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintFeature"/></param>
    [Generated]
    public ProgressionConfigurator SetFeatureRankIncrease(string value)
    {
      return OnConfigureInternal(bp => bp.m_FeatureRankIncrease = BlueprintTool.GetRef<BlueprintFeatureReference>(value));
    }
  }
}
