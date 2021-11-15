using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Classes.Spells
{
  /// <summary>Configurator for <see cref="BlueprintSpellList"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintSpellList))]
  public class SpellListConfigurator : BaseBlueprintConfigurator<BlueprintSpellList, SpellListConfigurator>
  {
     private SpellListConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SpellListConfigurator For(string name)
    {
      return new SpellListConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static SpellListConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintSpellList>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SpellListConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintSpellList>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellList.IsMythic"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellListConfigurator SetIsMythic(bool value)
    {
      return OnConfigureInternal(bp => bp.IsMythic = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSpellList.SpellsByLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellListConfigurator AddToSpellsByLevel(params SpellLevelList[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.SpellsByLevel = CommonTool.Append(bp.SpellsByLevel, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSpellList.SpellsByLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellListConfigurator RemoveFromSpellsByLevel(params SpellLevelList[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.SpellsByLevel = bp.SpellsByLevel.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellList.m_FilteredList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintSpellList"/></param>
    [Generated]
    public SpellListConfigurator SetFilteredList(string value)
    {
      return OnConfigureInternal(bp => bp.m_FilteredList = BlueprintTool.GetRef<BlueprintSpellListReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellList.FilterByMaxLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellListConfigurator SetFilterByMaxLevel(int value)
    {
      return OnConfigureInternal(bp => bp.FilterByMaxLevel = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellList.FilterByDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellListConfigurator SetFilterByDescriptor(bool value)
    {
      return OnConfigureInternal(bp => bp.FilterByDescriptor = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellList.Descriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellListConfigurator SetDescriptor(SpellDescriptorWrapper value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Descriptor = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellList.FilterBySchool"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellListConfigurator SetFilterBySchool(bool value)
    {
      return OnConfigureInternal(bp => bp.FilterBySchool = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellList.ExcludeFilterSchool"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellListConfigurator SetExcludeFilterSchool(bool value)
    {
      return OnConfigureInternal(bp => bp.ExcludeFilterSchool = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellList.FilterSchool"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellListConfigurator SetFilterSchool(SpellSchool value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.FilterSchool = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellList.FilterSchool2"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellListConfigurator SetFilterSchool2(SpellSchool value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.FilterSchool2 = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellList.m_MaxLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellListConfigurator SetMaxLevel(int value)
    {
      return OnConfigureInternal(bp => bp.m_MaxLevel = value);
    }
  }
}
