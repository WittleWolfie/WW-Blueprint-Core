//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Classes.Spells
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintSpellsTable"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseSpellsTableConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintSpellsTable
    where TBuilder : BaseSpellsTableConfigurator<T, TBuilder>
  {
    protected BaseSpellsTableConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintSpellsTable>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Levels = copyFrom.Levels;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellsTable.Levels"/>
    /// </summary>
    ///
    /// <param name="levels">
    /// <para>
    /// InfoBox: Usually it&amp;apos;s caster level, for mythic merged with spontaneous book it will be mythic level. Note: leave zero level empty
    /// </para>
    /// </param>
    public TBuilder SetLevels(params SpellsLevelEntry[] levels)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(levels);
          bp.Levels = levels;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintSpellsTable.Levels"/>
    /// </summary>
    ///
    /// <param name="levels">
    /// <para>
    /// InfoBox: Usually it&amp;apos;s caster level, for mythic merged with spontaneous book it will be mythic level. Note: leave zero level empty
    /// </para>
    /// </param>
    public TBuilder AddToLevels(params SpellsLevelEntry[] levels)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Levels = bp.Levels ?? new SpellsLevelEntry[0];
          bp.Levels = CommonTool.Append(bp.Levels, levels);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintSpellsTable.Levels"/>
    /// </summary>
    ///
    /// <param name="levels">
    /// <para>
    /// InfoBox: Usually it&amp;apos;s caster level, for mythic merged with spontaneous book it will be mythic level. Note: leave zero level empty
    /// </para>
    /// </param>
    public TBuilder RemoveFromLevels(params SpellsLevelEntry[] levels)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Levels is null) { return; }
          bp.Levels = bp.Levels.Where(val => !levels.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintSpellsTable.Levels"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromLevels(Func<SpellsLevelEntry, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Levels is null) { return; }
          bp.Levels = bp.Levels.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintSpellsTable.Levels"/>
    /// </summary>
    public TBuilder ClearLevels()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Levels = new SpellsLevelEntry[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSpellsTable.Levels"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyLevels(Action<SpellsLevelEntry> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Levels is null) { return; }
          bp.Levels.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Levels is null)
      {
        Blueprint.Levels = new SpellsLevelEntry[0];
      }
    }
  }
}
