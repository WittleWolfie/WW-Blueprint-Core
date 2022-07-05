using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using System.Linq;

namespace BlueprintCore.Blueprints.CustomConfigurators.Classes
{
  /// <summary>
  /// Configurator for <see cref="BlueprintArchetype"/>.
  /// </summary>
  /// <inheritdoc/>
  public class ArchetypeConfigurator
    : BaseArchetypeConfigurator<BlueprintArchetype, ArchetypeConfigurator>
  {
    private ArchetypeConfigurator(Blueprint<BlueprintReference<BlueprintArchetype>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Returns a configurator to modify the specified blueprint.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use this to modify existing blueprints, such as blueprints from the base game.
    /// </para>
    /// <para>
    /// If you're using <see href="https://github.com/OwlcatOpenSource/WrathModificationTemplate">WrathModificationTemplate</see> blueprints defined in JSON already exist.
    /// </para>
    /// </remarks>
    public static ArchetypeConfigurator For(Blueprint<BlueprintReference<BlueprintArchetype>> blueprint)
    {
      return new ArchetypeConfigurator(blueprint);
    }

    /// <summary>
    /// Creates a new blueprint and returns a new configurator to modify it.
    /// </summary>
    /// <remarks>
    /// <para>
    /// After creating a blueprint with this method you can use either name or GUID to reference the blueprint in BlueprintCore API calls.
    /// </para>
    /// <para>
    /// An implicit cast converts the string to <see cref="Utils.Blueprint{TRef}"/>, exposing the blueprint instance and its reference.
    /// </para>
    /// </remarks>
    public static ArchetypeConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintArchetype>(name, guid);
      return For(name);
    }

    // Start AddFeatures

    /// <summary>
    /// Uses <see cref="LevelEntryBuilder"/> to set <see cref="BlueprintArchetype.AddFeatures"/>.
    /// </summary>
    public ArchetypeConfigurator SetAddFeatures(LevelEntryBuilder levelEntries)
    {
      return SetAddFeatures(levelEntries.GetEntries());
    }

    /// <summary>
    /// Sets the LevelEntry in <see cref="BlueprintArchetype.AddFeatures"/> with the specified level and features.
    /// </summary>
    /// 
    /// <remarks>Removes any existing LevelEntry with the specified level.</remarks>
    public ArchetypeConfigurator SetAddFeatureEntry(int level, params Blueprint<BlueprintFeatureBaseReference>[] features)
    {
      var levelEntry =
        new LevelEntry()
        {
          Level = level,
          m_Features = features.Select(f => f.Reference).ToList()
        };
      return OnConfigureInternal(
        bp => bp.AddFeatures = bp.AddFeatures.Where(e => e.Level != level).Append(levelEntry).ToArray());
    }

    /// <param name="level">Features are added to a new LevelEntry with this level</param>
    /// <param name="features">Group of features to add</param>
    /// <inheritdoc cref="BaseArchetypeConfigurator{T, TBuilder}.AddToAddFeatures(LevelEntry[])"/>
    public ArchetypeConfigurator AddToAddFeatures(int level, params Blueprint<BlueprintFeatureBaseReference>[] features)
    {
      return AddToAddFeatures(
        new LevelEntry()
        {
          Level = level,
          m_Features = features.Select(f => f.Reference).ToList()
        });
    }

    /// <summary>
    /// Removes the provided features from any LevelEntry in <see cref="BlueprintArchetype.AddFeatures"/> with the
    /// specified level.
    /// </summary>
    public ArchetypeConfigurator RemoveFromAddFeatures(int level, params Blueprint<BlueprintFeatureBaseReference>[] features)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var entry in bp.AddFeatures)
          {
            if (entry.Level == level)
            {
              entry.m_Features.RemoveAll(e => features.Contains(e));
            }
          }
        });
    }

    /// <summary>
    /// Removes any level entries with the specified level from <see cref="BlueprintArchetype.AddFeatures"/>.
    /// </summary>
    public ArchetypeConfigurator RemoveAddFeaturesEntry(int level)
    {
      return OnConfigureInternal(
        bp => bp.AddFeatures = bp.AddFeatures.ToList().Where(e => e.Level != level).ToArray());
    }

    // End AddFeatures

    // Start RemoveFeatures

    /// <summary>
    /// Uses <see cref="LevelEntryBuilder"/> to set <see cref="BlueprintArchetype.RemoveFeatures"/>.
    /// </summary>
    public ArchetypeConfigurator SetRemoveFeatures(LevelEntryBuilder levelEntries)
    {
      return SetRemoveFeatures(levelEntries.GetEntries());
    }

    /// <summary>
    /// Sets the LevelEntry in <see cref="BlueprintArchetype.RemoveFeatures"/> with the specified level and features.
    /// </summary>
    /// 
    /// <remarks>Removes any existing LevelEntry with the specified level.</remarks>
    public ArchetypeConfigurator SetRemoveFeaturesEntry(int level, params Blueprint<BlueprintFeatureBaseReference>[] features)
    {
      var levelEntry =
        new LevelEntry()
        {
          Level = level,
          m_Features = features.Select(f => f.Reference).ToList()
        };
      return OnConfigureInternal(
        bp => bp.RemoveFeatures = bp.RemoveFeatures.Where(e => e.Level != level).Append(levelEntry).ToArray());
    }

    /// <param name="level">Features are added to a new LevelEntry with this level</param>
    /// <param name="features">Group of features to add</param>
    /// <inheritdoc cref="BaseArchetypeConfigurator{T, TBuilder}.AddToRemoveFeatures(LevelEntry[])"/>
    public ArchetypeConfigurator AddToRemoveFeatures(int level, params Blueprint<BlueprintFeatureBaseReference>[] features)
    {
      return AddToRemoveFeatures(
        new LevelEntry()
        {
          Level = level,
          m_Features = features.Select(f => f.Reference).ToList()
        });
    }

    /// <summary>
    /// Removes the provided features from any LevelEntry in <see cref="BlueprintArchetype.RemoveFeatures"/> with the
    /// specified level.
    /// </summary>
    public ArchetypeConfigurator RemoveFromRemoveFeatures(int level, params Blueprint<BlueprintFeatureBaseReference>[] features)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var entry in bp.RemoveFeatures)
          {
            if (entry.Level == level)
            {
              entry.m_Features.RemoveAll(e => features.Contains(e));
            }
          }
        });
    }

    /// <summary>
    /// Removes any level entries with the specified level from <see cref="BlueprintArchetype.RemoveFeatures"/>.
    /// </summary>
    public ArchetypeConfigurator RemoveRemoveFeaturesEntry(int level)
    {
      return OnConfigureInternal(
        bp => bp.RemoveFeatures = bp.RemoveFeatures.ToList().Where(e => e.Level != level).ToArray());
    }

    // End LevelEntries
  }
}
