//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintProgression"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseProgressionConfigurator<T, TBuilder>
    : BaseFeatureConfigurator<T, TBuilder>
    where T : BlueprintProgression
    where TBuilder : BaseProgressionConfigurator<T, TBuilder>
  {
    protected BaseProgressionConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProgression.m_Classes"/>
    /// </summary>
    public TBuilder SetClasses(params BlueprintProgression.ClassWithLevel[] classes)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(classes);
          bp.m_Classes = classes;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintProgression.m_Classes"/>
    /// </summary>
    public TBuilder AddToClasses(params BlueprintProgression.ClassWithLevel[] classes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Classes = bp.m_Classes ?? new BlueprintProgression.ClassWithLevel[0];
          bp.m_Classes = CommonTool.Append(bp.m_Classes, classes);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintProgression.m_Classes"/>
    /// </summary>
    public TBuilder RemoveFromClasses(params BlueprintProgression.ClassWithLevel[] classes)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Classes is null) { return; }
          bp.m_Classes = bp.m_Classes.Where(val => !classes.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintProgression.m_Classes"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromClasses(Func<BlueprintProgression.ClassWithLevel, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Classes is null) { return; }
          bp.m_Classes = bp.m_Classes.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintProgression.m_Classes"/>
    /// </summary>
    public TBuilder ClearClasses()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Classes = new BlueprintProgression.ClassWithLevel[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProgression.m_Classes"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyClasses(Action<BlueprintProgression.ClassWithLevel> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Classes is null) { return; }
          bp.m_Classes.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProgression.m_Archetypes"/>
    /// </summary>
    public TBuilder SetArchetypes(params BlueprintProgression.ArchetypeWithLevel[] archetypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(archetypes);
          bp.m_Archetypes = archetypes;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintProgression.m_Archetypes"/>
    /// </summary>
    public TBuilder AddToArchetypes(params BlueprintProgression.ArchetypeWithLevel[] archetypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Archetypes = bp.m_Archetypes ?? new BlueprintProgression.ArchetypeWithLevel[0];
          bp.m_Archetypes = CommonTool.Append(bp.m_Archetypes, archetypes);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintProgression.m_Archetypes"/>
    /// </summary>
    public TBuilder RemoveFromArchetypes(params BlueprintProgression.ArchetypeWithLevel[] archetypes)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Archetypes is null) { return; }
          bp.m_Archetypes = bp.m_Archetypes.Where(val => !archetypes.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintProgression.m_Archetypes"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromArchetypes(Func<BlueprintProgression.ArchetypeWithLevel, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Archetypes is null) { return; }
          bp.m_Archetypes = bp.m_Archetypes.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintProgression.m_Archetypes"/>
    /// </summary>
    public TBuilder ClearArchetypes()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Archetypes = new BlueprintProgression.ArchetypeWithLevel[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProgression.m_Archetypes"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyArchetypes(Action<BlueprintProgression.ArchetypeWithLevel> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Archetypes is null) { return; }
          bp.m_Archetypes.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProgression.ForAllOtherClasses"/>
    /// </summary>
    public TBuilder SetForAllOtherClasses(bool forAllOtherClasses = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ForAllOtherClasses = forAllOtherClasses;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProgression.ForAllOtherClasses"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyForAllOtherClasses(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ForAllOtherClasses);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProgression.m_AlternateProgressionClasses"/>
    /// </summary>
    public TBuilder SetAlternateProgressionClasses(params BlueprintProgression.ClassWithLevel[] alternateProgressionClasses)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(alternateProgressionClasses);
          bp.m_AlternateProgressionClasses = alternateProgressionClasses;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintProgression.m_AlternateProgressionClasses"/>
    /// </summary>
    public TBuilder AddToAlternateProgressionClasses(params BlueprintProgression.ClassWithLevel[] alternateProgressionClasses)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AlternateProgressionClasses = bp.m_AlternateProgressionClasses ?? new BlueprintProgression.ClassWithLevel[0];
          bp.m_AlternateProgressionClasses = CommonTool.Append(bp.m_AlternateProgressionClasses, alternateProgressionClasses);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintProgression.m_AlternateProgressionClasses"/>
    /// </summary>
    public TBuilder RemoveFromAlternateProgressionClasses(params BlueprintProgression.ClassWithLevel[] alternateProgressionClasses)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AlternateProgressionClasses is null) { return; }
          bp.m_AlternateProgressionClasses = bp.m_AlternateProgressionClasses.Where(val => !alternateProgressionClasses.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintProgression.m_AlternateProgressionClasses"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromAlternateProgressionClasses(Func<BlueprintProgression.ClassWithLevel, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AlternateProgressionClasses is null) { return; }
          bp.m_AlternateProgressionClasses = bp.m_AlternateProgressionClasses.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintProgression.m_AlternateProgressionClasses"/>
    /// </summary>
    public TBuilder ClearAlternateProgressionClasses()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AlternateProgressionClasses = new BlueprintProgression.ClassWithLevel[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProgression.m_AlternateProgressionClasses"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyAlternateProgressionClasses(Action<BlueprintProgression.ClassWithLevel> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AlternateProgressionClasses is null) { return; }
          bp.m_AlternateProgressionClasses.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProgression.AlternateProgressionType"/>
    /// </summary>
    public TBuilder SetAlternateProgressionType(AlternateProgressionType alternateProgressionType)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AlternateProgressionType = alternateProgressionType;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProgression.AlternateProgressionType"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAlternateProgressionType(Action<AlternateProgressionType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.AlternateProgressionType);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProgression.LevelEntries"/>
    /// </summary>
    public TBuilder SetLevelEntries(params LevelEntry[] levelEntries)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(levelEntries);
          bp.LevelEntries = levelEntries;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintProgression.LevelEntries"/>
    /// </summary>
    public TBuilder AddToLevelEntries(params LevelEntry[] levelEntries)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LevelEntries = bp.LevelEntries ?? new LevelEntry[0];
          bp.LevelEntries = CommonTool.Append(bp.LevelEntries, levelEntries);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintProgression.LevelEntries"/>
    /// </summary>
    public TBuilder RemoveFromLevelEntries(params LevelEntry[] levelEntries)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LevelEntries is null) { return; }
          bp.LevelEntries = bp.LevelEntries.Where(val => !levelEntries.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintProgression.LevelEntries"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromLevelEntries(Func<LevelEntry, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LevelEntries is null) { return; }
          bp.LevelEntries = bp.LevelEntries.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintProgression.LevelEntries"/>
    /// </summary>
    public TBuilder ClearLevelEntries()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.LevelEntries = new LevelEntry[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProgression.LevelEntries"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyLevelEntries(Action<LevelEntry> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.LevelEntries is null) { return; }
          bp.LevelEntries.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProgression.UIGroups"/>
    /// </summary>
    ///
    /// <param name="uIGroups">
    /// <para>
    /// Tooltip: Icons will be connected with line inside one group
    /// </para>
    /// </param>
    public TBuilder SetUIGroups(params UIGroup[] uIGroups)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(uIGroups);
          bp.UIGroups = uIGroups;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintProgression.UIGroups"/>
    /// </summary>
    ///
    /// <param name="uIGroups">
    /// <para>
    /// Tooltip: Icons will be connected with line inside one group
    /// </para>
    /// </param>
    public TBuilder AddToUIGroups(params UIGroup[] uIGroups)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UIGroups = bp.UIGroups ?? new UIGroup[0];
          bp.UIGroups = CommonTool.Append(bp.UIGroups, uIGroups);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintProgression.UIGroups"/>
    /// </summary>
    ///
    /// <param name="uIGroups">
    /// <para>
    /// Tooltip: Icons will be connected with line inside one group
    /// </para>
    /// </param>
    public TBuilder RemoveFromUIGroups(params UIGroup[] uIGroups)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.UIGroups is null) { return; }
          bp.UIGroups = bp.UIGroups.Where(val => !uIGroups.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintProgression.UIGroups"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromUIGroups(Func<UIGroup, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.UIGroups is null) { return; }
          bp.UIGroups = bp.UIGroups.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintProgression.UIGroups"/>
    /// </summary>
    public TBuilder ClearUIGroups()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UIGroups = new UIGroup[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProgression.UIGroups"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyUIGroups(Action<UIGroup> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.UIGroups is null) { return; }
          bp.UIGroups.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProgression.m_UIDeterminatorsGroup"/>
    /// </summary>
    ///
    /// <param name="uIDeterminatorsGroup">
    /// <para>
    /// Tooltip: Icon will be shown in first column of class progression
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintFeatureBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetUIDeterminatorsGroup(params Blueprint<BlueprintFeatureBaseReference>[] uIDeterminatorsGroup)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_UIDeterminatorsGroup = uIDeterminatorsGroup.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintProgression.m_UIDeterminatorsGroup"/>
    /// </summary>
    ///
    /// <param name="uIDeterminatorsGroup">
    /// <para>
    /// Tooltip: Icon will be shown in first column of class progression
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintFeatureBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToUIDeterminatorsGroup(params Blueprint<BlueprintFeatureBaseReference>[] uIDeterminatorsGroup)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_UIDeterminatorsGroup = bp.m_UIDeterminatorsGroup ?? new BlueprintFeatureBaseReference[0];
          bp.m_UIDeterminatorsGroup = CommonTool.Append(bp.m_UIDeterminatorsGroup, uIDeterminatorsGroup.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintProgression.m_UIDeterminatorsGroup"/>
    /// </summary>
    ///
    /// <param name="uIDeterminatorsGroup">
    /// <para>
    /// Tooltip: Icon will be shown in first column of class progression
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintFeatureBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromUIDeterminatorsGroup(params Blueprint<BlueprintFeatureBaseReference>[] uIDeterminatorsGroup)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_UIDeterminatorsGroup is null) { return; }
          bp.m_UIDeterminatorsGroup = bp.m_UIDeterminatorsGroup.Where(val => !uIDeterminatorsGroup.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintProgression.m_UIDeterminatorsGroup"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromUIDeterminatorsGroup(Func<BlueprintFeatureBaseReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_UIDeterminatorsGroup is null) { return; }
          bp.m_UIDeterminatorsGroup = bp.m_UIDeterminatorsGroup.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintProgression.m_UIDeterminatorsGroup"/>
    /// </summary>
    public TBuilder ClearUIDeterminatorsGroup()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_UIDeterminatorsGroup = new BlueprintFeatureBaseReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProgression.m_UIDeterminatorsGroup"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyUIDeterminatorsGroup(Action<BlueprintFeatureBaseReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_UIDeterminatorsGroup is null) { return; }
          bp.m_UIDeterminatorsGroup.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProgression.m_ExclusiveProgression"/>
    /// </summary>
    ///
    /// <param name="exclusiveProgression">
    /// <para>
    /// Blueprint of type BlueprintCharacterClass. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetExclusiveProgression(Blueprint<BlueprintCharacterClassReference> exclusiveProgression)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ExclusiveProgression = exclusiveProgression?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProgression.m_ExclusiveProgression"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyExclusiveProgression(Action<BlueprintCharacterClassReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ExclusiveProgression is null) { return; }
          action.Invoke(bp.m_ExclusiveProgression);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProgression.GiveFeaturesForPreviousLevels"/>
    /// </summary>
    public TBuilder SetGiveFeaturesForPreviousLevels(bool giveFeaturesForPreviousLevels = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.GiveFeaturesForPreviousLevels = giveFeaturesForPreviousLevels;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProgression.GiveFeaturesForPreviousLevels"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyGiveFeaturesForPreviousLevels(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.GiveFeaturesForPreviousLevels);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintProgression.m_FeaturesRankIncrease"/>
    /// </summary>
    ///
    /// <param name="featuresRankIncrease">
    /// <para>
    /// InfoBox: Result level = (All classes) + (all feature ranks) + ((alternative level) / 2)
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetFeaturesRankIncrease(params Blueprint<BlueprintFeatureReference>[] featuresRankIncrease)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_FeaturesRankIncrease = featuresRankIncrease.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintProgression.m_FeaturesRankIncrease"/>
    /// </summary>
    ///
    /// <param name="featuresRankIncrease">
    /// <para>
    /// InfoBox: Result level = (All classes) + (all feature ranks) + ((alternative level) / 2)
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToFeaturesRankIncrease(params Blueprint<BlueprintFeatureReference>[] featuresRankIncrease)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_FeaturesRankIncrease = bp.m_FeaturesRankIncrease ?? new();
          bp.m_FeaturesRankIncrease.AddRange(featuresRankIncrease.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintProgression.m_FeaturesRankIncrease"/>
    /// </summary>
    ///
    /// <param name="featuresRankIncrease">
    /// <para>
    /// InfoBox: Result level = (All classes) + (all feature ranks) + ((alternative level) / 2)
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromFeaturesRankIncrease(params Blueprint<BlueprintFeatureReference>[] featuresRankIncrease)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_FeaturesRankIncrease is null) { return; }
          bp.m_FeaturesRankIncrease = bp.m_FeaturesRankIncrease.Where(val => !featuresRankIncrease.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintProgression.m_FeaturesRankIncrease"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromFeaturesRankIncrease(Func<BlueprintFeatureReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_FeaturesRankIncrease is null) { return; }
          bp.m_FeaturesRankIncrease = bp.m_FeaturesRankIncrease.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintProgression.m_FeaturesRankIncrease"/>
    /// </summary>
    public TBuilder ClearFeaturesRankIncrease()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_FeaturesRankIncrease = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintProgression.m_FeaturesRankIncrease"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyFeaturesRankIncrease(Action<BlueprintFeatureReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_FeaturesRankIncrease is null) { return; }
          bp.m_FeaturesRankIncrease.ForEach(action);
        });
    }

    protected override void SetDefaults()
    {
      base.SetDefaults();
    
      if (Blueprint.m_Classes is null)
      {
        Blueprint.m_Classes = new BlueprintProgression.ClassWithLevel[0];
      }
      if (Blueprint.m_Archetypes is null)
      {
        Blueprint.m_Archetypes = new BlueprintProgression.ArchetypeWithLevel[0];
      }
      if (Blueprint.m_AlternateProgressionClasses is null)
      {
        Blueprint.m_AlternateProgressionClasses = new BlueprintProgression.ClassWithLevel[0];
      }
      if (Blueprint.LevelEntries is null)
      {
        Blueprint.LevelEntries = new LevelEntry[0];
      }
      if (Blueprint.UIGroups is null)
      {
        Blueprint.UIGroups = new UIGroup[0];
      }
      if (Blueprint.m_UIDeterminatorsGroup is null)
      {
        Blueprint.m_UIDeterminatorsGroup = new BlueprintFeatureBaseReference[0];
      }
      if (Blueprint.m_ExclusiveProgression is null)
      {
        Blueprint.m_ExclusiveProgression = BlueprintTool.GetRef<BlueprintCharacterClassReference>(null);
      }
      if (Blueprint.m_FeaturesRankIncrease is null)
      {
        Blueprint.m_FeaturesRankIncrease = new();
      }
    }
  }
}
