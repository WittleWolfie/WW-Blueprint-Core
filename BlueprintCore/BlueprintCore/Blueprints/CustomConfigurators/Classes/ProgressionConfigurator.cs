using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using System.Collections.Generic;
using System.Linq;
using static Kingmaker.Blueprints.Classes.BlueprintProgression;

namespace BlueprintCore.Blueprints.CustomConfigurators.Classes
{
  /// <summary>
  /// Configurator for <see cref="BlueprintProgression"/>.
  /// </summary>
  /// <inheritdoc/>
  public class ProgressionConfigurator
    : BaseProgressionConfigurator<BlueprintProgression, ProgressionConfigurator>
  {
    private ProgressionConfigurator(Blueprint<BlueprintReference<BlueprintProgression>> blueprint) : base(blueprint) { }

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
    public static ProgressionConfigurator For(Blueprint<BlueprintReference<BlueprintProgression>> blueprint)
    {
      return new ProgressionConfigurator(blueprint);
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
    public static ProgressionConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintProgression>(name, guid);
      return For(name);
    }

    /** Start m_Classes */

    /// <inheritdoc cref="BaseProgressionConfigurator{T, TBuilder}.SetClasses(ClassWithLevel[])"/>
    public ProgressionConfigurator SetClasses(params Blueprint<BlueprintCharacterClassReference>[] classes)
    {
      return SetClasses(Convert(classes));
    }

    /// <inheritdoc cref="BaseProgressionConfigurator{T, TBuilder}.SetClasses(ClassWithLevel[])"/>
    public ProgressionConfigurator SetClasses(
      params (Blueprint<BlueprintCharacterClassReference> clazz, int additionalLevel)[] classes)
    {
      return SetClasses(Convert(classes));
    }

    /// <inheritdoc cref="BaseProgressionConfigurator{T, TBuilder}.AddToClasses(ClassWithLevel[])"/>
    public ProgressionConfigurator AddToClasses(params Blueprint<BlueprintCharacterClassReference>[] classes)
    {
      return AddToClasses(Convert(classes));
    }

    /// <inheritdoc cref="BaseProgressionConfigurator{T, TBuilder}.AddToClasses(ClassWithLevel[])"/>
    public ProgressionConfigurator AddToClasses(
      params (Blueprint<BlueprintCharacterClassReference> clazz, int additionalLevel)[] classes)
    {
      return AddToClasses(Convert(classes));
    }

    /// <summary>
    /// Removes the specified classes from <see cref="BlueprintProgression.m_Classes"/>.
    /// </summary>
    public ProgressionConfigurator RemoveFromClasses(params Blueprint<BlueprintCharacterClassReference>[] classes)
    {
      return RemoveFromClasses(c => classes.Contains(c.m_Class));
    }

    /** End m_Classes */

    /** Start m_AlternateProgressionClasses */

    /// <inheritdoc cref="BaseProgressionConfigurator{T, TBuilder}.SetAlternateProgressionClasses(ClassWithLevel[])"/>
    public ProgressionConfigurator SetAlternateProgressionClasses(params Blueprint<BlueprintCharacterClassReference>[] classes)
    {
      return SetAlternateProgressionClasses(Convert(classes));
    }

    /// <inheritdoc cref="BaseProgressionConfigurator{T, TBuilder}.SetAlternateProgressionClasses(ClassWithLevel[])"/>
    public ProgressionConfigurator SetAlternateProgressionClasses(
      params (Blueprint<BlueprintCharacterClassReference> clazz, int additionalLevel)[] classes)
    {
      return SetAlternateProgressionClasses(Convert(classes));
    }

    /// <inheritdoc cref="BaseProgressionConfigurator{T, TBuilder}.AddToAlternateProgressionClasses(ClassWithLevel[])"/>
    public ProgressionConfigurator AddToAlternateProgressionClasses(params Blueprint<BlueprintCharacterClassReference>[] classes)
    {
      return AddToAlternateProgressionClasses(Convert(classes));
    }

    /// <inheritdoc cref="BaseProgressionConfigurator{T, TBuilder}.AddToAlternateProgressionClasses(ClassWithLevel[])"/>
    public ProgressionConfigurator AddToAlternateProgressionClasses(
      params (Blueprint<BlueprintCharacterClassReference> clazz, int additionalLevel)[] classes)
    {
      return AddToAlternateProgressionClasses(Convert(classes));
    }

    /// <summary>
    /// Removes the specified classes from <see cref="BlueprintProgression.m_AlternateProgressionClasses"/>.
    /// </summary>
    public ProgressionConfigurator RemoveFromAlternateProgressionClasses(params Blueprint<BlueprintCharacterClassReference>[] classes)
    {
      return RemoveFromAlternateProgressionClasses(c => classes.Contains(c.m_Class));
    }

    /** End m_AlternateProgressionClasses */

    /** Start m_Archetypes */

    /// <inheritdoc cref="BaseProgressionConfigurator{T, TBuilder}.SetArchetypes(ArchetypeWithLevel[])"/>
    public ProgressionConfigurator SetArchetypes(params Blueprint<BlueprintArchetypeReference>[] archetypes)
    {
      return SetArchetypes(Convert(archetypes));
    }

    /// <inheritdoc cref="BaseProgressionConfigurator{T, TBuilder}.SetArchetypes(ArchetypeWithLevel[])"/>
    public ProgressionConfigurator SetArchetypes(
      params (Blueprint<BlueprintArchetypeReference> archetype, int additionalLevel)[] archetypes)
    {
      return SetArchetypes(Convert(archetypes));
    }

    /// <inheritdoc cref="BaseProgressionConfigurator{T, TBuilder}.AddToArchetypes(ArchetypeWithLevel[])"/>
    public ProgressionConfigurator AddToClasses(params Blueprint<BlueprintArchetypeReference>[] archetypes)
    {
      return AddToArchetypes(Convert(archetypes));
    }

    /// <inheritdoc cref="BaseProgressionConfigurator{T, TBuilder}.AddToArchetypes(ArchetypeWithLevel[])"/>
    public ProgressionConfigurator AddToArchetypes(
      params (Blueprint<BlueprintArchetypeReference> archetype, int additionalLevel)[] archetypes)
    {
      return AddToArchetypes(Convert(archetypes));
    }

    /// <summary>
    /// Removes the specified archetypes from <see cref="BlueprintProgression.m_Archetypes"/>.
    /// </summary>
    public ProgressionConfigurator RemoveFromArchetypes(params Blueprint<BlueprintArchetypeReference>[] archetypes)
    {
      return RemoveFromArchetypes(c => archetypes.Contains(c.m_Archetype));
    }

    // End m_Archetypes

    // Start UIGroups

    /// <summary>
    /// Uses <see cref="UIGroupBuilder"/> to set <see cref="BlueprintProgression.UIGroups"/> and
    /// <see cref="BlueprintProgression.m_UIDeterminatorsGroup"/>.
    /// </summary>
    public ProgressionConfigurator SetUIGroups(UIGroupBuilder uiGroup)
    {
      return SetUIGroups(uiGroup.GetGroups()).SetUIDeterminatorsGroup(uiGroup.GetUIDeterminators());
    }

    /// <param name="features">
    /// A list of features to add as a single UIGroup
    /// </param>
    /// <inheritdoc cref="BaseProgressionConfigurator{T, TBuilder}.AddToUIGroups(UIGroup[])"/>
    public ProgressionConfigurator AddToUIGroups(params Blueprint<BlueprintFeatureBaseReference>[] features)
    {
      return AddToUIGroups(
        new UIGroup()
        {
          m_Features = features.Select(f => f.Reference).ToList()
        });
    }

    // End UIGroups

    // Start LevelEntries

    /// <summary>
    /// Uses <see cref="LevelEntryBuilder"/> to set <see cref="BlueprintProgression.LevelEntries"/>.
    /// </summary>
    public ProgressionConfigurator SetLevelEntries(LevelEntryBuilder levelEntries)
    {
      return SetLevelEntries(levelEntries.GetEntries());
    }

    /// <summary>
    /// Sets the LevelEntry in <see cref="BlueprintProgression.LevelEntries"/> with the specified level and features.
    /// </summary>
    /// 
    /// <remarks>Removes any existing LevelEntry with the specified level.</remarks>
    public ProgressionConfigurator SetLevelEntry(int level, params Blueprint<BlueprintFeatureBaseReference>[] features)
    {
      var levelEntry =
        new LevelEntry()
        {
          Level = level,
          m_Features = features.Select(f => f.Reference).ToList()
        };
      return OnConfigureInternal(
        bp => bp.LevelEntries = bp.LevelEntries.Where(e => e.Level != level).Append(levelEntry).ToArray());
    }

    /// <param name="level">Features are added to a new LevelEntry with this level</param>
    /// <param name="features">Group of features to add</param>
    /// <inheritdoc cref="BaseProgressionConfigurator{T, TBuilder}.AddToLevelEntries(LevelEntry[])"/>
    public ProgressionConfigurator AddToLevelEntries(int level, params Blueprint<BlueprintFeatureBaseReference>[] features)
    {
      return AddToLevelEntries(
        new LevelEntry()
        {
          Level = level,
          m_Features = features.Select(f => f.Reference).ToList()
        });
    }

    /// <summary>
    /// Removes the provided features from any LevelEntry in <see cref="BlueprintProgression.LevelEntries"/> with the
    /// specified level.
    /// </summary>
    public ProgressionConfigurator RemoveFromLevelEntries(int level, params Blueprint<BlueprintFeatureBaseReference>[] features)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var entry in bp.LevelEntries)
          {
            if (entry.Level == level)
            {
              entry.m_Features.RemoveAll(e => features.Contains(e));
            }
          }
        });
    }

    /// <summary>
    /// Removes any level entries with the specified level from <see cref="BlueprintProgression.LevelEntries"/>.
    /// </summary>
    public ProgressionConfigurator RemoveLevelEntry(int level)
    {
      return OnConfigureInternal(
        bp => bp.LevelEntries = bp.LevelEntries.ToList().Where(e => e.Level != level).ToArray());
    }

    // End LevelEntries

    // Start Converters

    private ClassWithLevel[] Convert(
      params (Blueprint<BlueprintCharacterClassReference> clazz, int additionalLevel)[] classes)
    {
      return classes.Select(
          c => new ClassWithLevel()
          {
            m_Class = c.clazz.Reference,
            AdditionalLevel = c.additionalLevel
          })
        .ToArray();
    }

    private ClassWithLevel[] Convert(params Blueprint<BlueprintCharacterClassReference>[] classes)
    {
      return classes.Select(c => new ClassWithLevel() { m_Class = c.Reference }).ToArray();
    }

    private ArchetypeWithLevel[] Convert(
      params (Blueprint<BlueprintArchetypeReference> archetype, int additionalLevel)[] classes)
    {
      return classes.Select(
          c => new ArchetypeWithLevel()
          {
            m_Archetype = c.archetype.Reference,
            AdditionalLevel = c.additionalLevel
          })
        .ToArray();
    }

    private ArchetypeWithLevel[] Convert(params Blueprint<BlueprintArchetypeReference>[] classes)
    {
      return classes.Select(c => new ArchetypeWithLevel() { m_Archetype = c.Reference }).ToArray();
    }

    // End Converters
  }

  /// <summary>
  /// Builder utility for <see cref="UIGroup"/> arrays.
  /// </summary>
  public class UIGroupBuilder
  {
    private static readonly List<UIGroup> UIGroups = new();
    private static readonly List<Blueprint<BlueprintFeatureBaseReference>> UIDeterminators = new();

    public static UIGroupBuilder New()
    {
      return new();
    }

    /// <summary>
    /// Adds a group of features as a <see cref="UIGroup"/>.
    /// </summary>
    public UIGroupBuilder AddGroup(params Blueprint<BlueprintFeatureBaseReference>[] features)
    {
      UIGroups.Add(
        new UIGroup()
        {
          m_Features = features.Select(f => f.Reference).ToList()
        });
      return this;
    }

    /// <summary>
    /// Adds a group of features used as the <see cref="BlueprintProgression.m_UIDeterminatorsGroup"/>.
    /// </summary>
    public UIGroupBuilder SetGroupDeterminators(params Blueprint<BlueprintFeatureBaseReference>[] features)
    {
      UIDeterminators.Clear();
      UIDeterminators.AddRange(features);
      return this;
    }

    /// <summary>
    /// Returns a <see cref="UIGroup"/> array.
    /// </summary>
    public UIGroup[] GetGroups()
    {
      return UIGroups.ToArray();
    }

    /// <summary>
    /// Returns a Blueprint feature array for use as UIDeterminators.
    /// </summary>
    public Blueprint<BlueprintFeatureBaseReference>[] GetUIDeterminators()
    {
      return UIDeterminators.ToArray();
    }
  }
}
