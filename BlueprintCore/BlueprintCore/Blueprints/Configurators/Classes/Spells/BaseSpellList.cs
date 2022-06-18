//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Classes.Spells
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintSpellList"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseSpellListConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintSpellList
    where TBuilder : BaseSpellListConfigurator<T, TBuilder>
  {
    protected BaseSpellListConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellList.IsMythic"/>
    /// </summary>
    public TBuilder SetIsMythic(bool isMythic = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsMythic = isMythic;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSpellList.IsMythic"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIsMythic(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.IsMythic);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellList.SpellsByLevel"/>
    /// </summary>
    public TBuilder SetSpellsByLevel(params SpellLevelList[] spellsByLevel)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(spellsByLevel);
          bp.SpellsByLevel = spellsByLevel;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintSpellList.SpellsByLevel"/>
    /// </summary>
    public TBuilder AddToSpellsByLevel(params SpellLevelList[] spellsByLevel)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SpellsByLevel = bp.SpellsByLevel ?? new SpellLevelList[0];
          bp.SpellsByLevel = CommonTool.Append(bp.SpellsByLevel, spellsByLevel);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintSpellList.SpellsByLevel"/>
    /// </summary>
    public TBuilder RemoveFromSpellsByLevel(params SpellLevelList[] spellsByLevel)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SpellsByLevel is null) { return; }
          bp.SpellsByLevel = bp.SpellsByLevel.Where(val => !spellsByLevel.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintSpellList.SpellsByLevel"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromSpellsByLevel(Func<SpellLevelList, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SpellsByLevel is null) { return; }
          bp.SpellsByLevel = bp.SpellsByLevel.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintSpellList.SpellsByLevel"/>
    /// </summary>
    public TBuilder ClearSpellsByLevel()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SpellsByLevel = new SpellLevelList[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSpellList.SpellsByLevel"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifySpellsByLevel(Action<SpellLevelList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SpellsByLevel is null) { return; }
          bp.SpellsByLevel.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellList.m_FilteredList"/>
    /// </summary>
    ///
    /// <param name="filteredList">
    /// <para>
    /// Blueprint of type BlueprintSpellList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetFilteredList(Blueprint<BlueprintSpellListReference> filteredList)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_FilteredList = filteredList?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSpellList.m_FilteredList"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFilteredList(Action<BlueprintSpellListReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_FilteredList is null) { return; }
          action.Invoke(bp.m_FilteredList);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellList.FilterByMaxLevel"/>
    /// </summary>
    public TBuilder SetFilterByMaxLevel(int filterByMaxLevel)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FilterByMaxLevel = filterByMaxLevel;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSpellList.FilterByMaxLevel"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFilterByMaxLevel(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.FilterByMaxLevel);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellList.FilterByDescriptor"/>
    /// </summary>
    public TBuilder SetFilterByDescriptor(bool filterByDescriptor = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FilterByDescriptor = filterByDescriptor;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSpellList.FilterByDescriptor"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFilterByDescriptor(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.FilterByDescriptor);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellList.Descriptor"/>
    /// </summary>
    ///
    /// <param name="descriptor">
    /// <para>
    /// InfoBox: Add only spells with any specified descriptors
    /// </para>
    /// </param>
    public TBuilder SetDescriptor(SpellDescriptorWrapper descriptor)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Descriptor = descriptor;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSpellList.Descriptor"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDescriptor(Action<SpellDescriptorWrapper> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Descriptor);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellList.FilterBySchool"/>
    /// </summary>
    public TBuilder SetFilterBySchool(bool filterBySchool = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FilterBySchool = filterBySchool;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSpellList.FilterBySchool"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFilterBySchool(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.FilterBySchool);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellList.ExcludeFilterSchool"/>
    /// </summary>
    public TBuilder SetExcludeFilterSchool(bool excludeFilterSchool = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ExcludeFilterSchool = excludeFilterSchool;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSpellList.ExcludeFilterSchool"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyExcludeFilterSchool(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ExcludeFilterSchool);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellList.FilterSchool"/>
    /// </summary>
    public TBuilder SetFilterSchool(SpellSchool filterSchool)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FilterSchool = filterSchool;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSpellList.FilterSchool"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFilterSchool(Action<SpellSchool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.FilterSchool);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellList.FilterSchool2"/>
    /// </summary>
    public TBuilder SetFilterSchool2(SpellSchool filterSchool2)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FilterSchool2 = filterSchool2;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSpellList.FilterSchool2"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFilterSchool2(Action<SpellSchool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.FilterSchool2);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellList.m_MaxLevel"/>
    /// </summary>
    public TBuilder SetMaxLevel(int maxLevel)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MaxLevel = maxLevel;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSpellList.m_MaxLevel"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMaxLevel(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_MaxLevel);
        });
    }

    protected override void SetDefaults()
    {
      base.SetDefaults();
    
      if (Blueprint.SpellsByLevel is null)
      {
        Blueprint.SpellsByLevel = new SpellLevelList[0];
      }
      if (Blueprint.m_FilteredList is null)
      {
        Blueprint.m_FilteredList = BlueprintTool.GetRef<BlueprintSpellListReference>(null);
      }
    }
  }
}
