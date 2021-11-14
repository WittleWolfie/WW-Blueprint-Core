using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using System;
namespace BlueprintCore.Blueprints.Configurators.Classes.Spells
{
  /// <summary>Configurator for <see cref="BlueprintSpellbook"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintSpellbook))]
  public class SpellbookConfigurator : BaseBlueprintConfigurator<BlueprintSpellbook, SpellbookConfigurator>
  {
     private SpellbookConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static SpellbookConfigurator For(string name)
    {
      return new SpellbookConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static SpellbookConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintSpellbook>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static SpellbookConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintSpellbook>(name, assetId);
      return For(name);
    }


    /// <summary>
    /// Adds <see cref="AddCustomSpells"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_SpellList"><see cref="BlueprintSpellList"/></param>
    [Generated]
    [Implements(typeof(AddCustomSpells))]
    public SpellbookConfigurator AddAddCustomSpells(
        int CasterLevel,
        string m_SpellList,
        int MaxSpellLevel,
        int Count)
    {
      
      var component =  new AddCustomSpells();
      component.CasterLevel = CasterLevel;
      component.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(m_SpellList);
      component.MaxSpellLevel = MaxSpellLevel;
      component.Count = Count;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IsAlchemistSpellbook"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IsAlchemistSpellbook))]
    public SpellbookConfigurator AddIsAlchemistSpellbook()
    {
      return AddComponent(new IsAlchemistSpellbook());
    }

    /// <summary>
    /// Adds <see cref="IsSinMagicSpecialistSpellbook"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(IsSinMagicSpecialistSpellbook))]
    public SpellbookConfigurator AddIsSinMagicSpecialistSpellbook()
    {
      return AddComponent(new IsSinMagicSpecialistSpellbook());
    }
  }
}
