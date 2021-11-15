using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;

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
    /// Sets <see cref="BlueprintSpellbook.Name"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellbookConfigurator SetName(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Name = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.IsMythic"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellbookConfigurator SetIsMythic(bool value)
    {
      return OnConfigureInternal(bp => bp.IsMythic = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.m_SpellsPerDay"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintSpellsTable"/></param>
    [Generated]
    public SpellbookConfigurator SetSpellsPerDay(string value)
    {
      return OnConfigureInternal(bp => bp.m_SpellsPerDay = BlueprintTool.GetRef<BlueprintSpellsTableReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.m_SpellsKnown"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintSpellsTable"/></param>
    [Generated]
    public SpellbookConfigurator SetSpellsKnown(string value)
    {
      return OnConfigureInternal(bp => bp.m_SpellsKnown = BlueprintTool.GetRef<BlueprintSpellsTableReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.m_SpellSlots"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintSpellsTable"/></param>
    [Generated]
    public SpellbookConfigurator SetSpellSlots(string value)
    {
      return OnConfigureInternal(bp => bp.m_SpellSlots = BlueprintTool.GetRef<BlueprintSpellsTableReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.m_SpellList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintSpellList"/></param>
    [Generated]
    public SpellbookConfigurator SetSpellList(string value)
    {
      return OnConfigureInternal(bp => bp.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.m_MythicSpellList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintSpellList"/></param>
    [Generated]
    public SpellbookConfigurator SetMythicSpellList(string value)
    {
      return OnConfigureInternal(bp => bp.m_MythicSpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.m_CharacterClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    public SpellbookConfigurator SetCharacterClass(string value)
    {
      return OnConfigureInternal(bp => bp.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.CastingAttribute"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellbookConfigurator SetCastingAttribute(StatType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.CastingAttribute = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.Spontaneous"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellbookConfigurator SetSpontaneous(bool value)
    {
      return OnConfigureInternal(bp => bp.Spontaneous = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.SpellsPerLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellbookConfigurator SetSpellsPerLevel(int value)
    {
      return OnConfigureInternal(bp => bp.SpellsPerLevel = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.AllSpellsKnown"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellbookConfigurator SetAllSpellsKnown(bool value)
    {
      return OnConfigureInternal(bp => bp.AllSpellsKnown = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.CantripsType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellbookConfigurator SetCantripsType(CantripsType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.CantripsType = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.CasterLevelModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellbookConfigurator SetCasterLevelModifier(int value)
    {
      return OnConfigureInternal(bp => bp.CasterLevelModifier = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.CanCopyScrolls"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellbookConfigurator SetCanCopyScrolls(bool value)
    {
      return OnConfigureInternal(bp => bp.CanCopyScrolls = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.IsArcane"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellbookConfigurator SetIsArcane(bool value)
    {
      return OnConfigureInternal(bp => bp.IsArcane = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.IsArcanist"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellbookConfigurator SetIsArcanist(bool value)
    {
      return OnConfigureInternal(bp => bp.IsArcanist = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.HasSpecialSpellList"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellbookConfigurator SetHasSpecialSpellList(bool value)
    {
      return OnConfigureInternal(bp => bp.HasSpecialSpellList = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintSpellbook.SpecialSpellListName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public SpellbookConfigurator SetSpecialSpellListName(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.SpecialSpellListName = value);
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
