//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using System;

namespace BlueprintCore.Blueprints.Configurators.Classes.Spells
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintSpellbook"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseSpellbookConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintSpellbook
    where TBuilder : BaseSpellbookConfigurator<T, TBuilder>
  {
    protected BaseSpellbookConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintSpellbook>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Name = copyFrom.Name;
          bp.IsMythic = copyFrom.IsMythic;
          bp.m_SpellsPerDay = copyFrom.m_SpellsPerDay;
          bp.m_SpellsKnown = copyFrom.m_SpellsKnown;
          bp.m_SpellSlots = copyFrom.m_SpellSlots;
          bp.m_SpellList = copyFrom.m_SpellList;
          bp.m_MythicSpellList = copyFrom.m_MythicSpellList;
          bp.m_CharacterClass = copyFrom.m_CharacterClass;
          bp.CastingAttribute = copyFrom.CastingAttribute;
          bp.Spontaneous = copyFrom.Spontaneous;
          bp.SpellsPerLevel = copyFrom.SpellsPerLevel;
          bp.AllSpellsKnown = copyFrom.AllSpellsKnown;
          bp.CantripsType = copyFrom.CantripsType;
          bp.CasterLevelModifier = copyFrom.CasterLevelModifier;
          bp.CanCopyScrolls = copyFrom.CanCopyScrolls;
          bp.IsArcane = copyFrom.IsArcane;
          bp.IsArcanist = copyFrom.IsArcanist;
          bp.HasSpecialSpellList = copyFrom.HasSpecialSpellList;
          bp.SpecialSpellListName = copyFrom.SpecialSpellListName;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintSpellbook>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Name = copyFrom.Name;
          bp.IsMythic = copyFrom.IsMythic;
          bp.m_SpellsPerDay = copyFrom.m_SpellsPerDay;
          bp.m_SpellsKnown = copyFrom.m_SpellsKnown;
          bp.m_SpellSlots = copyFrom.m_SpellSlots;
          bp.m_SpellList = copyFrom.m_SpellList;
          bp.m_MythicSpellList = copyFrom.m_MythicSpellList;
          bp.m_CharacterClass = copyFrom.m_CharacterClass;
          bp.CastingAttribute = copyFrom.CastingAttribute;
          bp.Spontaneous = copyFrom.Spontaneous;
          bp.SpellsPerLevel = copyFrom.SpellsPerLevel;
          bp.AllSpellsKnown = copyFrom.AllSpellsKnown;
          bp.CantripsType = copyFrom.CantripsType;
          bp.CasterLevelModifier = copyFrom.CasterLevelModifier;
          bp.CanCopyScrolls = copyFrom.CanCopyScrolls;
          bp.IsArcane = copyFrom.IsArcane;
          bp.IsArcanist = copyFrom.IsArcanist;
          bp.HasSpecialSpellList = copyFrom.HasSpecialSpellList;
          bp.SpecialSpellListName = copyFrom.SpecialSpellListName;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellbook.Name"/>
    /// </summary>
    ///
    /// <param name="name">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetName(LocalString name)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Name = name?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSpellbook.Name"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Name is null) { return; }
          action.Invoke(bp.Name);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellbook.IsMythic"/>
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
    /// Sets the value of <see cref="BlueprintSpellbook.m_SpellsPerDay"/>
    /// </summary>
    ///
    /// <param name="spellsPerDay">
    /// <para>
    /// Tooltip: Spells per day table. Further modified by casting stat.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintSpellsTable. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetSpellsPerDay(Blueprint<BlueprintSpellsTableReference> spellsPerDay)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SpellsPerDay = spellsPerDay?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSpellbook.m_SpellsPerDay"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySpellsPerDay(Action<BlueprintSpellsTableReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SpellsPerDay is null) { return; }
          action.Invoke(bp.m_SpellsPerDay);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellbook.m_SpellsKnown"/>
    /// </summary>
    ///
    /// <param name="spellsKnown">
    /// <para>
    /// Tooltip: Spells known table. Only for spontaneous casters (but not for Arcanist).
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintSpellsTable. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetSpellsKnown(Blueprint<BlueprintSpellsTableReference> spellsKnown)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SpellsKnown = spellsKnown?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSpellbook.m_SpellsKnown"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySpellsKnown(Action<BlueprintSpellsTableReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SpellsKnown is null) { return; }
          action.Invoke(bp.m_SpellsKnown);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellbook.m_SpellSlots"/>
    /// </summary>
    ///
    /// <param name="spellSlots">
    /// <para>
    /// Tooltip: Spell slots table for arcanist.
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintSpellsTable. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetSpellSlots(Blueprint<BlueprintSpellsTableReference> spellSlots)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SpellSlots = spellSlots?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSpellbook.m_SpellSlots"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySpellSlots(Action<BlueprintSpellsTableReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SpellSlots is null) { return; }
          action.Invoke(bp.m_SpellSlots);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellbook.m_SpellList"/>
    /// </summary>
    ///
    /// <param name="spellList">
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
    public TBuilder SetSpellList(Blueprint<BlueprintSpellListReference> spellList)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SpellList = spellList?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSpellbook.m_SpellList"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySpellList(Action<BlueprintSpellListReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SpellList is null) { return; }
          action.Invoke(bp.m_SpellList);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellbook.m_MythicSpellList"/>
    /// </summary>
    ///
    /// <param name="mythicSpellList">
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
    public TBuilder SetMythicSpellList(Blueprint<BlueprintSpellListReference> mythicSpellList)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MythicSpellList = mythicSpellList?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSpellbook.m_MythicSpellList"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMythicSpellList(Action<BlueprintSpellListReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_MythicSpellList is null) { return; }
          action.Invoke(bp.m_MythicSpellList);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellbook.m_CharacterClass"/>
    /// </summary>
    ///
    /// <param name="characterClass">
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
    public TBuilder SetCharacterClass(Blueprint<BlueprintCharacterClassReference> characterClass)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_CharacterClass = characterClass?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSpellbook.m_CharacterClass"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCharacterClass(Action<BlueprintCharacterClassReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_CharacterClass is null) { return; }
          action.Invoke(bp.m_CharacterClass);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellbook.CastingAttribute"/>
    /// </summary>
    public TBuilder SetCastingAttribute(StatType castingAttribute)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CastingAttribute = castingAttribute;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellbook.Spontaneous"/>
    /// </summary>
    ///
    /// <param name="spontaneous">
    /// <para>
    /// Tooltip: Spontaneous casting (sorcerers, oracles, bard)
    /// </para>
    /// </param>
    public TBuilder SetSpontaneous(bool spontaneous = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Spontaneous = spontaneous;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellbook.SpellsPerLevel"/>
    /// </summary>
    ///
    /// <param name="spellsPerLevel">
    /// <para>
    /// Tooltip: Spells count learned on each level. For wizards.
    /// </para>
    /// </param>
    public TBuilder SetSpellsPerLevel(int spellsPerLevel)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SpellsPerLevel = spellsPerLevel;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellbook.AllSpellsKnown"/>
    /// </summary>
    ///
    /// <param name="allSpellsKnown">
    /// <para>
    /// Tooltip: No need to learn spells to memorize them. For clerics / druids / rangers.
    /// </para>
    /// </param>
    public TBuilder SetAllSpellsKnown(bool allSpellsKnown = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AllSpellsKnown = allSpellsKnown;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellbook.CantripsType"/>
    /// </summary>
    ///
    /// <param name="cantripsType">
    /// <para>
    /// Tooltip: For UI name.
    /// </para>
    /// </param>
    public TBuilder SetCantripsType(CantripsType cantripsType)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CantripsType = cantripsType;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellbook.CasterLevelModifier"/>
    /// </summary>
    ///
    /// <param name="casterLevelModifier">
    /// <para>
    /// Tooltip: For Ranger - his caster level is class level minus 3
    /// </para>
    /// </param>
    public TBuilder SetCasterLevelModifier(int casterLevelModifier)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CasterLevelModifier = casterLevelModifier;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellbook.CanCopyScrolls"/>
    /// </summary>
    public TBuilder SetCanCopyScrolls(bool canCopyScrolls = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CanCopyScrolls = canCopyScrolls;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellbook.IsArcane"/>
    /// </summary>
    public TBuilder SetIsArcane(bool isArcane = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsArcane = isArcane;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellbook.IsArcanist"/>
    /// </summary>
    public TBuilder SetIsArcanist(bool isArcanist = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsArcanist = isArcanist;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellbook.HasSpecialSpellList"/>
    /// </summary>
    public TBuilder SetHasSpecialSpellList(bool hasSpecialSpellList = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HasSpecialSpellList = hasSpecialSpellList;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintSpellbook.SpecialSpellListName"/>
    /// </summary>
    ///
    /// <param name="specialSpellListName">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetSpecialSpellListName(LocalString specialSpellListName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SpecialSpellListName = specialSpellListName?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintSpellbook.SpecialSpellListName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySpecialSpellListName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SpecialSpellListName is null) { return; }
          action.Invoke(bp.SpecialSpellListName);
        });
    }

    /// <summary>
    /// Adds <see cref="AddCustomSpells"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>EldritchScionSpellbook</term><description>e2763fbfdb91920458c4686c3e7ed085</description></item>
    /// <item><term>LichSkeletalMagusSpellbookMinor</term><description>c9ff1f4b3b26dcb47ba75b218ccadd23</description></item>
    /// <item><term>MagusSpellbook</term><description>5d8d04e76dff6c5439de99af0d57be63</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="spellList">
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
    public TBuilder AddCustomSpells(
        int? casterLevel = null,
        int? count = null,
        int? maxSpellLevel = null,
        Blueprint<BlueprintSpellListReference>? spellList = null)
    {
      var component = new AddCustomSpells();
      component.CasterLevel = casterLevel ?? component.CasterLevel;
      component.Count = count ?? component.Count;
      component.MaxSpellLevel = maxSpellLevel ?? component.MaxSpellLevel;
      component.m_SpellList = spellList?.Reference ?? component.m_SpellList;
      if (component.m_SpellList is null)
      {
        component.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="IsSinMagicSpecialistSpellbook"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ThassilonianAbjurationSpellbook</term><description>58b15cc36ceda8942a7a29aafa755452</description></item>
    /// <item><term>ThassilonianEvocationSpellbook</term><description>05b105ddee654db4fb1547ba48ffa160</description></item>
    /// <item><term>ThassilonianTransmutationSpellbook</term><description>5785f40e7b1bfc94ea078e7156aa9711</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddIsSinMagicSpecialistSpellbook(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new IsSinMagicSpecialistSpellbook();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Name is null)
      {
        Blueprint.Name = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_SpellsPerDay is null)
      {
        Blueprint.m_SpellsPerDay = BlueprintTool.GetRef<BlueprintSpellsTableReference>(null);
      }
      if (Blueprint.m_SpellsKnown is null)
      {
        Blueprint.m_SpellsKnown = BlueprintTool.GetRef<BlueprintSpellsTableReference>(null);
      }
      if (Blueprint.m_SpellSlots is null)
      {
        Blueprint.m_SpellSlots = BlueprintTool.GetRef<BlueprintSpellsTableReference>(null);
      }
      if (Blueprint.m_SpellList is null)
      {
        Blueprint.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(null);
      }
      if (Blueprint.m_MythicSpellList is null)
      {
        Blueprint.m_MythicSpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(null);
      }
      if (Blueprint.m_CharacterClass is null)
      {
        Blueprint.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(null);
      }
      if (Blueprint.SpecialSpellListName is null)
      {
        Blueprint.SpecialSpellListName = Utils.Constants.Empty.String;
      }
    }
  }
}
