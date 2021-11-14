using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Designers.Mechanics.Prerequisites;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.Mechanics.Components;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>Configurator for <see cref="BlueprintCharacterClass"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCharacterClass))]
  public class CharacterClassConfigurator : BaseBlueprintConfigurator<BlueprintCharacterClass, CharacterClassConfigurator>
  {
     private CharacterClassConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CharacterClassConfigurator For(string name)
    {
      return new CharacterClassConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CharacterClassConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintCharacterClass>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CharacterClassConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintCharacterClass>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Adds or modifies <see cref="PrerequisiteAlignment"/>
    /// </summary>
    [Implements(typeof(PrerequisiteAlignment))]
    public CharacterClassConfigurator AddPrerequisiteAlignment(params AlignmentMaskType[] alignments)
    {
      foreach (AlignmentMaskType alignment in alignments) { EnablePrerequisiteAlignment |= alignment; }
      return Self;
    }

    /// <summary>
    /// Modifies <see cref="PrerequisiteAlignment"/>
    /// </summary>
    [Implements(typeof(PrerequisiteAlignment))]
    public CharacterClassConfigurator RemovePrerequisiteAlignment(params AlignmentMaskType[] alignments)
    {
      foreach (AlignmentMaskType alignment in alignments) { DisablePrerequisiteAlignment |= alignment; }
      return Self;
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteArchetypeLevel"/>
    /// </summary>
    /// 
    /// <param name="clazz"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass">BlueprintCharacterClass</see></param>
    /// <param name="archetype"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype">BlueprintArchetype</see></param>
    [Implements(typeof(PrerequisiteArchetypeLevel))]
    public CharacterClassConfigurator PrerequisiteArchetype(
        string clazz,
        string archetype,
        int level = 1,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisiteArchetypeLevel>(group, checkInProgression, hideInUI);
      prereq.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      prereq.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype);
      prereq.Level = level;
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteCasterType">PrerequisiteCasterType</see>
    /// </summary>
    [Implements(typeof(PrerequisiteCasterType))]
    public CharacterClassConfigurator PrerequisiteCasterType(
        bool isArcane,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false,
        ComponentMerge behavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent> merge = null)
    {
      var prereq = PrereqTool.Create<PrerequisiteCasterType>(group, checkInProgression, hideInUI);
      prereq.IsArcane = isArcane;
      return AddUniqueComponent(prereq, behavior, merge);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteCasterTypeSpellLevel">PrerequisiteCasterTypeSpellLevel</see>
    /// </summary>
    [Implements(typeof(PrerequisiteCasterTypeSpellLevel))]
    public CharacterClassConfigurator PrerequisiteCasterTypeSpellLevel(
        bool isArcane,
        bool onlySpontaneous,
        int minSpellLevel,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisiteCasterTypeSpellLevel>(group, checkInProgression, hideInUI);
      prereq.IsArcane = isArcane;
      prereq.OnlySpontaneous = onlySpontaneous;
      prereq.RequiredSpellLevel = minSpellLevel;
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteCharacterLevel">PrerequisiteCharacterLevel</see>
    /// </summary>
    [Implements(typeof(PrerequisiteCharacterLevel))]
    public CharacterClassConfigurator PrerequisiteCharacterLevel(
        int minLevel,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false,
        ComponentMerge behavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent> merge = null)
    {
      var prereq = PrereqTool.Create<PrerequisiteCharacterLevel>(group, checkInProgression, hideInUI);
      prereq.Level = minLevel;
      return AddUniqueComponent(prereq, behavior, merge);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteClassLevel">PrerequisiteClassLevel</see>
    /// </summary>
    /// 
    /// <param name="clazz"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass">BlueprintCharacterClass</see></param>
    [Implements(typeof(PrerequisiteClassLevel))]
    public CharacterClassConfigurator PrerequisiteClassLevel(
        string clazz,
        int minLevel,
        bool negate = false,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisiteClassLevel>(group, checkInProgression, hideInUI);
      prereq.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      prereq.Level = minLevel;
      prereq.Not = negate;
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteClassSpellLevel">PrerequisiteClassSpellLevel</see>
    /// </summary>
    /// 
    /// <param name="clazz"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass">BlueprintCharacterClass</see></param>
    [Implements(typeof(PrerequisiteClassSpellLevel))]
    public CharacterClassConfigurator PrerequisiteClassSpellLevel(
        string clazz,
        int minSpellLevel,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false,
        ComponentMerge behavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent> merge = null)
    {
      var prereq = PrereqTool.Create<PrerequisiteClassSpellLevel>(group, checkInProgression, hideInUI);
      prereq.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      prereq.RequiredSpellLevel = minSpellLevel;
      return AddUniqueComponent(prereq, behavior, merge);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteEtude">PrerequisiteEtude</see>
    /// </summary>
    /// 
    /// <param name="etude"><see cref="Kingmaker.AreaLogic.Etudes.BlueprintEtude">BlueprintEtude</see></param>
    [Implements(typeof(PrerequisiteEtude))]
    public CharacterClassConfigurator PrerequisiteEtude(
        string etude,
        bool playing = true,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisiteEtude>(group, checkInProgression, hideInUI);
      prereq.Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(etude);
      prereq.NotPlaying = !playing;
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteFeature">PrerequisiteFeature</see>
    /// </summary>
    /// 
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
    [Implements(typeof(PrerequisiteFeature))]
    public CharacterClassConfigurator PrerequisiteFeature(
        string feature,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisiteFeature>(group, checkInProgression, hideInUI);
      prereq.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteFeaturesFromList">PrerequisiteFeaturesFromList</see>
    /// </summary>
    /// 
    /// <param name="features"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
    [Implements(typeof(PrerequisiteFeaturesFromList))]
    public CharacterClassConfigurator PrerequisiteFeaturesFromList(
        string[] features,
        int requiredNumber = 1,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisiteFeaturesFromList>(group, checkInProgression, hideInUI);
      prereq.m_Features =
          features.Select(feature => BlueprintTool.GetRef<BlueprintFeatureReference>(feature)).ToArray();
      prereq.Amount = requiredNumber;
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteIsPet">PrerequisiteIsPet</see>
    /// </summary>
    [Implements(typeof(PrerequisiteIsPet))]
    public CharacterClassConfigurator PrerequisiteIsPet(
        bool negate = false,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisiteIsPet>(group, checkInProgression, hideInUI);
      prereq.Not = negate;
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteMainCharacter">PrerequisiteMainCharacter</see>
    /// </summary>
    [Implements(typeof(PrerequisiteMainCharacter))]
    public CharacterClassConfigurator PrerequisiteMainCharacter(
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false,
        ComponentMerge behavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent> merge = null)
    {
      var prereq = PrereqTool.Create<PrerequisiteMainCharacter>(group, checkInProgression, hideInUI);
      return AddUniqueComponent(prereq, behavior, merge);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteMainCharacter">PrerequisiteMainCharacter</see>
    /// </summary>
    [Implements(typeof(PrerequisiteMainCharacter))]
    public CharacterClassConfigurator PrerequisiteCompanion(
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false,
        ComponentMerge behavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent> merge = null)
    {
      var prereq = PrereqTool.Create<PrerequisiteMainCharacter>(group, checkInProgression, hideInUI);
      prereq.Companion = true;
      return AddUniqueComponent(prereq, behavior, merge);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteMythicLevel">PrerequisiteMythicLevel</see>
    /// </summary>
    [Implements(typeof(PrerequisiteMythicLevel))]
    public CharacterClassConfigurator PrerequisiteMythicLevel(
        int level,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false,
        ComponentMerge behavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent> merge = null)
    {
      var prereq = PrereqTool.Create<PrerequisiteMythicLevel>(group, checkInProgression, hideInUI);
      prereq.Level = level;
      return AddUniqueComponent(prereq, behavior, merge);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteNoArchetype">PrerequisiteNoArchetype</see>
    /// </summary>
    /// 
    /// <param name="clazz"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass">BlueprintCharacterClass</see></param>
    /// <param name="archetype"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype">BlueprintArchetype</see></param>
    [Implements(typeof(PrerequisiteNoArchetype))]
    public CharacterClassConfigurator PrerequisiteNoArchetype(
        string clazz,
        string archetype,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisiteNoArchetype>(group, checkInProgression, hideInUI);
      prereq.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      prereq.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype);
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteNoClassLevel"/>
    /// </summary>
    /// 
    /// <param name="clazz"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass">BlueprintCharacterClass</see></param>
    [Implements(typeof(PrerequisiteNoClassLevel))]
    public CharacterClassConfigurator PrerequisiteNoClass(
        string clazz,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisiteNoClassLevel>(group, checkInProgression, hideInUI);
      prereq.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteNoFeature">PrerequisiteNoFeature</see>
    /// </summary>
    /// 
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
    [Implements(typeof(PrerequisiteNoFeature))]
    public CharacterClassConfigurator PrerequisiteNoFeature(
        string feature,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisiteNoFeature>(group, checkInProgression, hideInUI);
      prereq.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteNotProficient">PrerequisiteNotProficient</see>
    /// </summary>
    [Implements(typeof(PrerequisiteNotProficient))]
    public CharacterClassConfigurator PrerequisiteNotProficient(
        WeaponCategory[] weapons,
        ArmorProficiencyGroup[] armors,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false,
        ComponentMerge behavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent> merge = null)
    {
      var prereq =
          PrereqTool.Create<PrerequisiteNotProficient>(group, checkInProgression, hideInUI);
      prereq.WeaponProficiencies = weapons ?? Constants.Empty.WeaponCategories;
      prereq.ArmorProficiencies = armors ?? Constants.Empty.ArmorProficiencies;
      return AddUniqueComponent(prereq, behavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteParametrizedFeature"/>
    /// </summary>
    /// 
    /// <param name="spellFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
    /// <param name="spellAbility"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility">BlueprintAbility</see></param>
    [Implements(typeof(PrerequisiteParametrizedFeature))]
    public CharacterClassConfigurator PrerequisiteParameterizedSpellFeature(
        string spellFeature,
        string spellAbility,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisiteParametrizedFeature>(group, checkInProgression, hideInUI);
      // Note: There is no distinction between SpellSpecialization and LearnSpell, despite them
      // being called out independently in the component.
      prereq.ParameterType = FeatureParameterType.LearnSpell;
      prereq.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(spellFeature);
      prereq.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(spellAbility);
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteParametrizedFeature"/>
    /// </summary>
    /// 
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
    [Implements(typeof(PrerequisiteParametrizedFeature))]
    public CharacterClassConfigurator PrerequisiteParameterizedWeaponFeature(
        string feature,
        WeaponCategory weapon,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq =
          PrereqTool.Create<PrerequisiteParametrizedFeature>(group, checkInProgression, hideInUI);
      prereq.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      prereq.ParameterType = FeatureParameterType.WeaponCategory;
      prereq.WeaponCategory = weapon;
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteParametrizedFeature"/>
    /// </summary>
    /// 
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
    [Implements(typeof(PrerequisiteParametrizedFeature))]
    public CharacterClassConfigurator PrerequisiteParameterizedSpellSchoolFeature(
        string feature,
        SpellSchool school,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisiteParametrizedFeature>(group, checkInProgression, hideInUI);
      prereq.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      prereq.ParameterType = FeatureParameterType.SpellSchool;
      prereq.SpellSchool = school;
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteParametrizedWeaponSubcategory"/>
    /// </summary>
    /// 
    /// <param name="weaponFeature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
    [Implements(typeof(PrerequisiteParametrizedWeaponSubcategory))]
    public CharacterClassConfigurator PrerequisiteParameterizedWeaponSubcategory(
        string weaponFeature,
        WeaponSubCategory weapon,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisiteParametrizedWeaponSubcategory>(group, checkInProgression, hideInUI);
      prereq.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(weaponFeature);
      prereq.SubCategory = weapon;
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisitePet">PrerequisitePet</see>
    /// </summary>
    [Implements(typeof(PrerequisitePet))]
    public CharacterClassConfigurator PrerequisitePet(
        PetType type,
        bool negate = false,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisitePet>(group, checkInProgression, hideInUI);
      prereq.Type = type;
      prereq.NoCompanion = negate;
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisitePlayerHasFeature">PrerequisitePlayerHasFeature</see>
    /// </summary>
    /// 
    /// <param name="feature"><see cref="Kingmaker.Blueprints.Classes.BlueprintFeature">BlueprintFeature</see></param>
    [Implements(typeof(PrerequisitePlayerHasFeature))]
    public CharacterClassConfigurator PrerequisitePlayerHasFeature(
        string feature,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisitePlayerHasFeature>(group, checkInProgression, hideInUI);
      prereq.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteProficiency"/>
    /// </summary>
    [Implements(typeof(PrerequisiteProficiency))]
    public CharacterClassConfigurator PrerequisiteProficient(
        WeaponCategory[] weapons,
        ArmorProficiencyGroup[] armors,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false,
        ComponentMerge behavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent> merge = null)
    {
      var prereq =
          PrereqTool.Create<PrerequisiteProficiency>(group, checkInProgression, hideInUI);
      prereq.WeaponProficiencies = weapons ?? Constants.Empty.WeaponCategories;
      prereq.ArmorProficiencies = armors ?? Constants.Empty.ArmorProficiencies;
      return AddUniqueComponent(prereq, behavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteStatValue"/>
    /// </summary>
    [Implements(typeof(PrerequisiteStatValue))]
    public CharacterClassConfigurator PrerequisiteStat(
        StatType type,
        int minValue,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTool.Create<PrerequisiteStatValue>(group, checkInProgression, hideInUI);
      prereq.Stat = type;
      prereq.Value = minValue;
      return AddComponent(prereq);
    }

    /// <summary>
    /// Adds <see cref="DeityDependencyClass"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DeityDependencyClass))]
    public CharacterClassConfigurator AddDeityDependencyClass(
        bool IsDeityDependencyClass)
    {
      
      var component =  new DeityDependencyClass();
      component.IsDeityDependencyClass = IsDeityDependencyClass;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="HideClassIfPrerequisitesRequiredComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HideClassIfPrerequisitesRequiredComponent))]
    public CharacterClassConfigurator AddHideClassIfPrerequisitesRequiredComponent()
    {
      return AddComponent(new HideClassIfPrerequisitesRequiredComponent());
    }

    /// <summary>
    /// Adds <see cref="MythicClassArtComponent"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Portraits"><see cref="BlueprintPortrait"/></param>
    [Generated]
    [Implements(typeof(MythicClassArtComponent))]
    public CharacterClassConfigurator AddMythicClassArtComponent(
        SpriteLink m_SelectorPortrait,
        SpriteLink m_SelectorPortraitLineart,
        SpriteLink m_CommonFrame,
        SpriteLink m_CommonFrameDecor,
        SpriteLink m_PortraitFrame,
        SpriteLink m_SelectorFrame,
        SpriteLink m_AbilityFrame,
        SpriteLink m_Emblem,
        string[] m_Portraits)
    {
      ValidateParam(m_SelectorPortrait);
      ValidateParam(m_SelectorPortraitLineart);
      ValidateParam(m_CommonFrame);
      ValidateParam(m_CommonFrameDecor);
      ValidateParam(m_PortraitFrame);
      ValidateParam(m_SelectorFrame);
      ValidateParam(m_AbilityFrame);
      ValidateParam(m_Emblem);
      
      var component =  new MythicClassArtComponent();
      component.m_SelectorPortrait = m_SelectorPortrait;
      component.m_SelectorPortraitLineart = m_SelectorPortraitLineart;
      component.m_CommonFrame = m_CommonFrame;
      component.m_CommonFrameDecor = m_CommonFrameDecor;
      component.m_PortraitFrame = m_PortraitFrame;
      component.m_SelectorFrame = m_SelectorFrame;
      component.m_AbilityFrame = m_AbilityFrame;
      component.m_Emblem = m_Emblem;
      component.m_Portraits = m_Portraits.Select(bp => BlueprintTool.GetRef<BlueprintPortraitReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MythicClassLockComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MythicClassLockComponent))]
    public CharacterClassConfigurator AddMythicClassLockComponent(
        Mythic[] Locks)
    {
      foreach (var item in Locks)
      {
        ValidateParam(item);
      }
      
      var component =  new MythicClassLockComponent();
      component.Locks = Locks;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SkipLevelsForSpellProgression"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SkipLevelsForSpellProgression))]
    public CharacterClassConfigurator AddSkipLevelsForSpellProgression(
        int[] Levels)
    {
      
      var component =  new SkipLevelsForSpellProgression();
      component.Levels = Levels;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteLoreMaster"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_LoreMaster"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(PrerequisiteLoreMaster))]
    public CharacterClassConfigurator AddPrerequisiteLoreMaster(
        string m_LoreMaster,
        int Rating,
        Prerequisite.GroupType Group,
        bool CheckInProgression,
        bool HideInUI)
    {
      ValidateParam(Group);
      
      var component =  new PrerequisiteLoreMaster();
      component.m_LoreMaster = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_LoreMaster);
      component.Rating = Rating;
      component.Group = Group;
      component.CheckInProgression = CheckInProgression;
      component.HideInUI = HideInUI;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteSelectionPossible"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_ThisFeature"><see cref="BlueprintFeatureSelection"/></param>
    [Generated]
    [Implements(typeof(PrerequisiteSelectionPossible))]
    public CharacterClassConfigurator AddPrerequisiteSelectionPossible(
        string m_ThisFeature,
        Prerequisite.GroupType Group,
        bool CheckInProgression,
        bool HideInUI)
    {
      ValidateParam(Group);
      
      var component =  new PrerequisiteSelectionPossible();
      component.m_ThisFeature = BlueprintTool.GetRef<BlueprintFeatureSelectionReference>(m_ThisFeature);
      component.Group = Group;
      component.CheckInProgression = CheckInProgression;
      component.HideInUI = HideInUI;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteFullStatValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PrerequisiteFullStatValue))]
    public CharacterClassConfigurator AddPrerequisiteFullStatValue(
        StatType Stat,
        int Value,
        Prerequisite.GroupType Group,
        bool CheckInProgression,
        bool HideInUI)
    {
      ValidateParam(Stat);
      ValidateParam(Group);
      
      var component =  new PrerequisiteFullStatValue();
      component.Stat = Stat;
      component.Value = Value;
      component.Group = Group;
      component.CheckInProgression = CheckInProgression;
      component.HideInUI = HideInUI;
      return AddComponent(component);
    }
  }
}
