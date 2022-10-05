//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintDungeonTrapSpellList"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDungeonTrapSpellListConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintDungeonTrapSpellList
    where TBuilder : BaseDungeonTrapSpellListConfigurator<T, TBuilder>
  {
    protected BaseDungeonTrapSpellListConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintDungeonTrapSpellList>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Spells = copyFrom.m_Spells;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonTrapSpellList.m_Spells"/>
    /// </summary>
    public TBuilder SetSpells(params BlueprintDungeonTrapSpellList.TrapSpell[] spells)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(spells);
          bp.m_Spells = spells;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDungeonTrapSpellList.m_Spells"/>
    /// </summary>
    public TBuilder AddToSpells(params BlueprintDungeonTrapSpellList.TrapSpell[] spells)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Spells = bp.m_Spells ?? new BlueprintDungeonTrapSpellList.TrapSpell[0];
          bp.m_Spells = CommonTool.Append(bp.m_Spells, spells);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonTrapSpellList.m_Spells"/>
    /// </summary>
    public TBuilder RemoveFromSpells(params BlueprintDungeonTrapSpellList.TrapSpell[] spells)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Spells is null) { return; }
          bp.m_Spells = bp.m_Spells.Where(val => !spells.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDungeonTrapSpellList.m_Spells"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromSpells(Func<BlueprintDungeonTrapSpellList.TrapSpell, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Spells is null) { return; }
          bp.m_Spells = bp.m_Spells.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDungeonTrapSpellList.m_Spells"/>
    /// </summary>
    public TBuilder ClearSpells()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Spells = new BlueprintDungeonTrapSpellList.TrapSpell[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonTrapSpellList.m_Spells"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifySpells(Action<BlueprintDungeonTrapSpellList.TrapSpell> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Spells is null) { return; }
          bp.m_Spells.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Spells is null)
      {
        Blueprint.m_Spells = new BlueprintDungeonTrapSpellList.TrapSpell[0];
      }
    }
  }
}
