using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Components;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Crusade.GlobalMagic;
using Kingmaker.Crusade.GlobalMagic.Actions;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Designers.Mechanics.Prerequisites;
using Kingmaker.Designers.Mechanics.Recommendations;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.Settings;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Owlcat.Runtime.Visual.Effects.WeatherSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>
  /// Implements common fields and component support for blueprints inheriting from <see cref="BlueprintFeature"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintFeature))]
  public abstract class BaseFeatureConfigurator<T, TBuilder> : FeatureBaseConfigurator<T, TBuilder>
      where T : BlueprintFeature
      where TBuilder : BaseFeatureConfigurator<T, TBuilder>
  {
    private FeatureTag EnableFeatureTags;
    private FeatureTag DisableFeatureTags;

    private readonly List<BlueprintFeatureReference> EnableIsPrerequisiteFor = new();
    private readonly List<BlueprintFeatureReference> DisableIsPrerequisiteFor = new();

    private readonly List<FeatureGroup> EnableGroups = new();
    private readonly List<FeatureGroup> DisableGroups = new();

    protected BaseFeatureConfigurator(string name) : base(name) { }

    /// <summary>
    /// Modifies <see cref="BlueprintFeature.Groups"/>
    /// </summary>
    public TBuilder AddFeatureGroups(params FeatureGroup[] groups)
    {
      EnableGroups.AddRange(groups);
      return Self;
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFeature.Groups"/>
    /// </summary>
    public TBuilder RemoveFeatureGroups(params FeatureGroup[] groups)
    {
      DisableGroups.AddRange(groups);
      return Self;
    }

    /// <summary>
    /// Sets <see cref="BlueprintFeature.IsClassFeature"/>
    /// </summary>
    public TBuilder SetIsClassFeature(bool isClassFeature = true)
    {
      return OnConfigureInternal(blueprint => blueprint.IsClassFeature = isClassFeature);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFeature.IsPrerequisiteFor"/>
    /// </summary>
    /// 
    /// <param name="features"><see cref="BlueprintFeature"/></param>
    public TBuilder AddIsPrerequisiteFor(params string[] features)
    {
      EnableIsPrerequisiteFor.AddRange(
          features.Select(feature => BlueprintTool.GetRef<BlueprintFeatureReference>(feature)).ToArray());
      return Self;
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFeature.IsPrerequisiteFor"/>
    /// </summary>
    /// 
    /// <param name="features"><see cref="BlueprintFeature"/></param>
    public TBuilder RemoveIsPrerequisiteFor(params string[] features)
    {
      DisableIsPrerequisiteFor.AddRange(
          features
              .Select(
                  feature => BlueprintTool.GetRef<BlueprintFeatureReference>(feature))
              .ToArray());
      return Self;
    }

    /// <summary>
    /// Sets <see cref="BlueprintFeature.Ranks"/>
    /// </summary>
    public TBuilder SetRanks(int ranks)
    {
      return OnConfigureInternal(blueprint => blueprint.Ranks = ranks);
    }

    /// <summary>
    /// Sets <see cref="BlueprintFeature.ReapplyOnLevelUp"/>
    /// </summary>
    public TBuilder SetReapplyOnLevelUp(bool reapply = true)
    {
      return OnConfigureInternal(blueprint => blueprint.ReapplyOnLevelUp = reapply);
    }

    /// <summary>
    /// Adds or modifies <see cref="FeatureTagsComponent"/>
    /// </summary>
    public TBuilder AddFeatureTags(params FeatureTag[] tags)
    {
      foreach (FeatureTag tag in tags) { EnableFeatureTags |= tag; }
      return Self;
    }

    /// <summary>
    /// Modifies <see cref="FeatureTagsComponent"/>
    /// </summary>
    public TBuilder RemoveFeatureTags(params FeatureTag[] tags)
    {
      foreach (FeatureTag tag in tags) { DisableFeatureTags |= tag; }
      return Self;
    }


    /// <summary>
    /// Adds <see cref="Kingmaker.UnitLogic.Mechanics.Components.ContextRankConfig">ContextRankConfig</see>
    /// </summary>
    /// 
    /// <remarks>Use <see cref="Components.ContextRankConfigs">ContextRankConfigs</see> to create the config</remarks>
    [Implements(typeof(ContextRankConfig))]
    public TBuilder AddContextRankConfig(ContextRankConfig rankConfig)
    {
      return AddComponent(rankConfig);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteSelectionPossible">PrerequisiteSelectionPossible</see>
    /// </summary>
    /// 
    /// <remarks>
    /// <para>
    /// A feature selection with this component only shows up if the character is eligible for at least one feature.
    /// This is useful when a character has access to different feature selections based on some criteria.
    /// </para>
    /// 
    /// <para>
    /// See ExpandedDefense and WildTalentBonusFeatAir3 blueprints for example usages.
    /// </para>
    /// </remarks>
    public TBuilder PrerequisiteSelectionPossible(
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var selectionPossible = PrereqTool.Create<PrerequisiteSelectionPossible>(group, checkInProgression, hideInUI);
      selectionPossible.m_ThisFeature = Blueprint.ToReference<BlueprintFeatureSelectionReference>();
      return AddComponent(selectionPossible);
    }
    
    /// <summary>
    /// Adds <see cref="PrerequisiteArchetypeLevel"/>
    /// </summary>
    /// 
    /// <param name="clazz"><see cref="Kingmaker.Blueprints.Classes.BlueprintCharacterClass">BlueprintCharacterClass</see></param>
    /// <param name="archetype"><see cref="Kingmaker.Blueprints.Classes.BlueprintArchetype">BlueprintArchetype</see></param>
    [Implements(typeof(PrerequisiteArchetypeLevel))]
    public TBuilder PrerequisiteArchetype(
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
    public TBuilder PrerequisiteCasterType(
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
    public TBuilder PrerequisiteCasterTypeSpellLevel(
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
    public TBuilder PrerequisiteCharacterLevel(
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
    public TBuilder PrerequisiteClassLevel(
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
    public TBuilder PrerequisiteClassSpellLevel(
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
    public TBuilder PrerequisiteEtude(
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
    public TBuilder PrerequisiteFeature(
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
    public TBuilder PrerequisiteFeaturesFromList(
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
    public TBuilder PrerequisiteIsPet(
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
    public TBuilder PrerequisiteMainCharacter(
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
    public TBuilder PrerequisiteCompanion(
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
    public TBuilder PrerequisiteMythicLevel(
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
    public TBuilder PrerequisiteNoArchetype(
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
    public TBuilder PrerequisiteNoClass(
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
    public TBuilder PrerequisiteNoFeature(
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
    public TBuilder PrerequisiteNotProficient(
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
    public TBuilder PrerequisiteParameterizedSpellFeature(
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
    public TBuilder PrerequisiteParameterizedWeaponFeature(
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
    public TBuilder PrerequisiteParameterizedSpellSchoolFeature(
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
    public TBuilder PrerequisiteParameterizedWeaponSubcategory(
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
    public TBuilder PrerequisitePet(
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
    public TBuilder PrerequisitePlayerHasFeature(
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
    public TBuilder PrerequisiteProficient(
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
    public TBuilder PrerequisiteStat(
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
    /// Adds or modifies <see cref="PrerequisiteAlignment"/>
    /// </summary>
    [Implements(typeof(PrerequisiteAlignment))]
    public TBuilder AddPrerequisiteAlignment(params AlignmentMaskType[] alignments)
    {
      return OnConfigureInternal(blueprint => AddPrerequisiteAlignment(blueprint, alignments.ToList()));
    }

    [Implements(typeof(PrerequisiteAlignment))]
    private static void AddPrerequisiteAlignment(BlueprintScriptableObject bp, List<AlignmentMaskType> alignments)
    {
      var component = bp.GetComponent<PrerequisiteAlignment>();
      if (component is null)
      {
        component = new PrerequisiteAlignment();
        bp.AddComponents(component);
      }
      alignments.ForEach(alignment => component.Alignment |= alignment);
    }

    /// <summary>
    /// Modifies <see cref="PrerequisiteAlignment"/>
    /// </summary>
    [Implements(typeof(PrerequisiteAlignment))]
    public TBuilder RemovePrerequisiteAlignment(params AlignmentMaskType[] alignments)
    {
      return OnConfigureInternal(blueprint => RemovePrerequisiteAlignment(blueprint, alignments.ToList()));
    }

    [Implements(typeof(PrerequisiteAlignment))]
    private static void RemovePrerequisiteAlignment(BlueprintScriptableObject bp, List<AlignmentMaskType> alignments)
    {
      var component = bp.GetComponent<PrerequisiteAlignment>();
      if (component is null) { return; }
      alignments.ForEach(alignment => component.Alignment &= ~alignment);
    }

    /// <summary>
    /// Adds or modifies <see cref="SpellDescriptorComponent"/>
    /// </summary>
    [Implements(typeof(SpellDescriptorComponent))]
    public TBuilder AddSpellDescriptors(params SpellDescriptor[] descriptors)
    {
      return OnConfigureInternal(blueprint => AddSpellDescriptors(blueprint, descriptors.ToList()));
    }

    [Implements(typeof(SpellDescriptorComponent))]
    private static void AddSpellDescriptors(BlueprintScriptableObject bp, List<SpellDescriptor> descriptors)
    {
      var component = bp.GetComponent<SpellDescriptorComponent>();
      if (component is null)
      {
        component = new SpellDescriptorComponent();
        bp.AddComponents(component);
      }
      descriptors.ForEach(descriptor => component.Descriptor.m_IntValue |= (long)descriptor);
    }

    /// <summary>
    /// Modifies <see cref="SpellDescriptorComponent"/>
    /// </summary>
    [Implements(typeof(SpellDescriptorComponent))]
    public TBuilder RemoveSpellDescriptors(params SpellDescriptor[] descriptors)
    {
      return OnConfigureInternal(blueprint => RemoveSpellDescriptors(blueprint, descriptors.ToList()));
    }

    [Implements(typeof(SpellDescriptorComponent))]
    private static void RemoveSpellDescriptors(BlueprintScriptableObject bp, List<SpellDescriptor> descriptors)
    {
      var component = bp.GetComponent<SpellDescriptorComponent>();
      if (component is null) { return; }
      descriptors.ForEach(descriptor => component.Descriptor.m_IntValue &= ~(long)descriptor);
    }

    /// <summary>
    /// Adds <see cref="AddGlobalMapSpellFeature"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spell"><see cref="BlueprintGlobalMagicSpell"/></param>
    [Generated]
    [Implements(typeof(AddGlobalMapSpellFeature))]
    public TBuilder AddGlobalMapSpellFeature(
        string spell = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddGlobalMapSpellFeature();
      component.m_Spell = BlueprintTool.GetRef<BlueprintGlobalMagicSpell.Reference>(spell);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FeatureSurvivesRespec"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(FeatureSurvivesRespec))]
    public TBuilder AddFeatureSurvivesRespec(
        BlueprintComponent.Flags flags = default)
    {
      var component = new FeatureSurvivesRespec();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LevelUpRecommendation"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LevelUpRecommendation))]
    public TBuilder AddLevelUpRecommendation(
        ClassesPriority[] classPriorities = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(classPriorities);
    
      var component = new LevelUpRecommendation();
      component.ClassPriorities = classPriorities;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteLoreMaster"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="loreMaster"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(PrerequisiteLoreMaster))]
    public TBuilder AddPrerequisiteLoreMaster(
        string loreMaster = null,
        int rating = default,
        Prerequisite.GroupType group = default,
        bool checkInProgression = default,
        bool hideInUI = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new PrerequisiteLoreMaster();
      component.m_LoreMaster = BlueprintTool.GetRef<BlueprintCharacterClassReference>(loreMaster);
      component.Rating = rating;
      component.Group = group;
      component.CheckInProgression = checkInProgression;
      component.HideInUI = hideInUI;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBuffInBadWeather"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AddBuffInBadWeather))]
    public TBuilder AddBuffInBadWeather(
        string buff = null,
        InclemencyType weather = default,
        bool whenCalmer = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddBuffInBadWeather();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.Weather = weather;
      component.WhenCalmer = whenCalmer;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBuffOnApplyingSpell"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddBuffOnApplyingSpell))]
    public TBuilder AddBuffOnApplyingSpell(
        bool onEffectApplied = default,
        bool onResistSpell = default,
        AddBuffOnApplyingSpell.SpellConditionAndBuff[] buffs = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(buffs);
    
      var component = new AddBuffOnApplyingSpell();
      component.OnEffectApplied = onEffectApplied;
      component.OnResistSpell = onResistSpell;
      component.Buffs = buffs;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddContextStatBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddContextStatBonus))]
    public TBuilder AddContextStatBonus(
        ContextValue value,
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int multiplier = default,
        bool hasMinimal = default,
        int minimal = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new AddContextStatBonus();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Multiplier = multiplier;
      component.Value = value;
      component.HasMinimal = hasMinimal;
      component.Minimal = minimal;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeaturesFromSelectionToDescription"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="featureSelection"><see cref="BlueprintFeatureSelection"/></param>
    [Generated]
    [Implements(typeof(AddFeaturesFromSelectionToDescription))]
    public TBuilder AddFeaturesFromSelectionToDescription(
        LocalizedString introduction = null,
        string featureSelection = null,
        bool onlyIfRequiresThisFeature = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(introduction);
    
      var component = new AddFeaturesFromSelectionToDescription();
      component.Introduction = introduction ?? Constants.Empty.String;
      component.m_FeatureSelection = BlueprintTool.GetRef<BlueprintFeatureSelectionReference>(featureSelection);
      component.OnlyIfRequiresThisFeature = onlyIfRequiresThisFeature;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddGoldenDragonSkillBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddGoldenDragonSkillBonus))]
    public TBuilder AddGoldenDragonSkillBonus(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddGoldenDragonSkillBonus();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddLocustSwarmMechanicPart"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddLocustSwarmMechanicPart))]
    public TBuilder AddLocustSwarmMechanicPart(
        int swarmStartStrength = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddLocustSwarmMechanicPart();
      component.m_SwarmStartStrength = swarmStartStrength;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddMagusMechanicPart"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddMagusMechanicPart))]
    public TBuilder AddMagusMechanicPart(
        AddMagusMechanicPart.Feature feature = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddMagusMechanicPart();
      component.m_Feature = feature;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddNocticulaBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddNocticulaBonus))]
    public TBuilder AddNocticulaBonus(
        ContextValue highestStatBonus,
        ContextValue secondHighestStatBonus,
        ModifierDescriptor descriptor = default,
        StatType highestStat = default,
        StatType secondHighestStat = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(highestStatBonus);
      ValidateParam(secondHighestStatBonus);
    
      var component = new AddNocticulaBonus();
      component.Descriptor = descriptor;
      component.HighestStatBonus = highestStatBonus;
      component.m_HighestStat = highestStat;
      component.SecondHighestStatBonus = secondHighestStatBonus;
      component.m_SecondHighestStat = secondHighestStat;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddRestTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddRestTrigger))]
    public TBuilder AddRestTrigger(
        ActionsBuilder action = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddRestTrigger();
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellsToDescription"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellLists"><see cref="BlueprintSpellList"/></param>
    /// <param name="spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddSpellsToDescription))]
    public TBuilder AddSpellsToDescription(
        LocalizedString introduction = null,
        string[] spellLists = null,
        string[] spells = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(introduction);
    
      var component = new AddSpellsToDescription();
      component.Introduction = introduction ?? Constants.Empty.String;
      component.m_SpellLists = spellLists.Select(name => BlueprintTool.GetRef<BlueprintSpellListReference>(name)).ToArray();
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddTricksterAthleticBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddTricksterAthleticBonus))]
    public TBuilder AddTricksterAthleticBonus(
        ModifierDescriptor descriptor = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddTricksterAthleticBonus();
      component.Descriptor = descriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddWeaponEnhancementBonusToStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddWeaponEnhancementBonusToStat))]
    public TBuilder AddWeaponEnhancementBonusToStat(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        int multiplier = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddWeaponEnhancementBonusToStat();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.Multiplier = multiplier;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MountedShield"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MountedShield))]
    public TBuilder AddMountedShield(
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new MountedShield();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShroudOfWater"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="upgradeFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(ShroudOfWater))]
    public TBuilder AddShroudOfWater(
        ContextValue baseValue,
        ModifierDescriptor descriptor = default,
        StatType stat = default,
        string upgradeFeature = null,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(baseValue);
    
      var component = new ShroudOfWater();
      component.Descriptor = descriptor;
      component.Stat = stat;
      component.BaseValue = baseValue;
      component.m_UpgradeFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(upgradeFeature);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellResistanceAgainstAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpellResistanceAgainstAlignment))]
    public TBuilder AddSpellResistanceAgainstAlignment(
        ContextValue value,
        AlignmentComponent alignment = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new SpellResistanceAgainstAlignment();
      component.Value = value;
      component.Alignment = alignment;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellResistanceAgainstSpellDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpellResistanceAgainstSpellDescriptor))]
    public TBuilder AddSpellResistanceAgainstSpellDescriptor(
        ContextValue value,
        SpellDescriptorWrapper spellDescriptor,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new SpellResistanceAgainstSpellDescriptor();
      component.Value = value;
      component.SpellDescriptor = spellDescriptor;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateAbilityParams"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="customProperty"><see cref="BlueprintUnitProperty"/></param>
    [Generated]
    [Implements(typeof(ContextCalculateAbilityParams))]
    public TBuilder AddContextCalculateAbilityParams(
        ContextValue casterLevel,
        ContextValue spellLevel,
        bool useKineticistMainStat = default,
        StatType statType = default,
        bool statTypeFromCustomProperty = default,
        string customProperty = null,
        bool replaceCasterLevel = default,
        bool replaceSpellLevel = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(casterLevel);
      ValidateParam(spellLevel);
    
      var component = new ContextCalculateAbilityParams();
      component.UseKineticistMainStat = useKineticistMainStat;
      component.StatType = statType;
      component.StatTypeFromCustomProperty = statTypeFromCustomProperty;
      component.m_CustomProperty = BlueprintTool.GetRef<BlueprintUnitPropertyReference>(customProperty);
      component.ReplaceCasterLevel = replaceCasterLevel;
      component.CasterLevel = casterLevel;
      component.ReplaceSpellLevel = replaceSpellLevel;
      component.SpellLevel = spellLevel;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateAbilityParamsBasedOnClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="characterClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(ContextCalculateAbilityParamsBasedOnClass))]
    public TBuilder AddContextCalculateAbilityParamsBasedOnClass(
        bool useKineticistMainStat = default,
        StatType statType = default,
        string characterClass = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new ContextCalculateAbilityParamsBasedOnClass();
      component.UseKineticistMainStat = useKineticistMainStat;
      component.StatType = statType;
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(characterClass);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateSharedValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextCalculateSharedValue))]
    public TBuilder AddContextCalculateSharedValue(
        ContextDiceValue value,
        AbilitySharedValue valueType = default,
        double modifier = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(value);
    
      var component = new ContextCalculateSharedValue();
      component.ValueType = valueType;
      component.Value = value;
      component.Modifier = modifier;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextSetAbilityParams"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextSetAbilityParams))]
    public TBuilder AddContextSetAbilityParams(
        ContextValue dC,
        ContextValue casterLevel,
        ContextValue concentration,
        ContextValue spellLevel,
        bool add10ToDC = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(dC);
      ValidateParam(casterLevel);
      ValidateParam(concentration);
      ValidateParam(spellLevel);
    
      var component = new ContextSetAbilityParams();
      component.Add10ToDC = add10ToDC;
      component.DC = dC;
      component.CasterLevel = casterLevel;
      component.Concentration = concentration;
      component.SpellLevel = spellLevel;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityDifficultyLimitDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityDifficultyLimitDC))]
    public TBuilder AddAbilityDifficultyLimitDC(
        BlueprintComponent.Flags flags = default)
    {
      var component = new AbilityDifficultyLimitDC();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TacticalMoraleChanceModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalMoraleChanceModifier))]
    public TBuilder AddTacticalMoraleChanceModifier(
        ContextValue positiveMoraleChancePercentDelta,
        ContextValue negativeMoraleChancePercentDelta,
        bool changePositiveMorale = default,
        bool changeNegativeMorale = default,
        BlueprintComponent.Flags flags = default)
    {
      ValidateParam(positiveMoraleChancePercentDelta);
      ValidateParam(negativeMoraleChancePercentDelta);
    
      var component = new TacticalMoraleChanceModifier();
      component.m_ChangePositiveMorale = changePositiveMorale;
      component.m_PositiveMoraleChancePercentDelta = positiveMoraleChancePercentDelta;
      component.m_ChangeNegativeMorale = changeNegativeMorale;
      component.m_NegativeMoraleChancePercentDelta = negativeMoraleChancePercentDelta;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PureRecommendation"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PureRecommendation))]
    public TBuilder AddPureRecommendation(
        RecommendationPriority priority = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new PureRecommendation();
      component.Priority = priority;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationAccomplishedSneakAttacker"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationAccomplishedSneakAttacker))]
    public TBuilder AddRecommendationAccomplishedSneakAttacker(
        BlueprintComponent.Flags flags = default)
    {
      var component = new RecommendationAccomplishedSneakAttacker();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationBaseAttackPart"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationBaseAttackPart))]
    public TBuilder AddRecommendationBaseAttackPart(
        float minPart = default,
        bool notRecommendIfHigher = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RecommendationBaseAttackPart();
      component.MinPart = minPart;
      component.NotRecommendIfHigher = notRecommendIfHigher;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationCompanionBoon"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companionRank"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(RecommendationCompanionBoon))]
    public TBuilder AddRecommendationCompanionBoon(
        string companionRank = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RecommendationCompanionBoon();
      component.m_CompanionRank = BlueprintTool.GetRef<BlueprintFeatureReference>(companionRank);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationHasFeature"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="feature"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(RecommendationHasFeature))]
    public TBuilder AddRecommendationHasFeature(
        string feature = null,
        bool mandatory = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RecommendationHasFeature();
      component.m_Feature = BlueprintTool.GetRef<BlueprintUnitFactReference>(feature);
      component.Mandatory = mandatory;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationNoFeatFromGroup"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="features"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(RecommendationNoFeatFromGroup))]
    public TBuilder AddRecommendationNoFeatFromGroup(
        string[] features = null,
        bool goodIfNoFeature = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RecommendationNoFeatFromGroup();
      component.m_Features = features.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray();
      component.GoodIfNoFeature = goodIfNoFeature;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationRequiresSpellbook"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationRequiresSpellbook))]
    public TBuilder AddRecommendationRequiresSpellbook(
        BlueprintComponent.Flags flags = default)
    {
      var component = new RecommendationRequiresSpellbook();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationRequiresSpellbookSource"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationRequiresSpellbookSource))]
    public TBuilder AddRecommendationRequiresSpellbookSource(
        bool arcane = default,
        bool divine = default,
        bool alchemist = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RecommendationRequiresSpellbookSource();
      component.Arcane = arcane;
      component.Divine = divine;
      component.Alchemist = alchemist;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationStatComparison"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationStatComparison))]
    public TBuilder AddRecommendationStatComparison(
        StatType higherStat = default,
        StatType lowerStat = default,
        int diff = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RecommendationStatComparison();
      component.HigherStat = higherStat;
      component.LowerStat = lowerStat;
      component.Diff = diff;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationStatMiminum"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationStatMiminum))]
    public TBuilder AddRecommendationStatMiminum(
        StatType stat = default,
        int minimalValue = default,
        bool goodIfHigher = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RecommendationStatMiminum();
      component.Stat = stat;
      component.MinimalValue = minimalValue;
      component.GoodIfHigher = goodIfHigher;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationWeaponSubcategoryFocus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationWeaponSubcategoryFocus))]
    public TBuilder AddRecommendationWeaponSubcategoryFocus(
        WeaponSubCategory subcategory = default,
        bool hasFocus = default,
        bool badIfNoFocus = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RecommendationWeaponSubcategoryFocus();
      component.Subcategory = subcategory;
      component.HasFocus = hasFocus;
      component.BadIfNoFocus = badIfNoFocus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationWeaponTypeFocus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationWeaponTypeFocus))]
    public TBuilder AddRecommendationWeaponTypeFocus(
        WeaponRangeType weaponRangeType = default,
        bool hasFocus = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new RecommendationWeaponTypeFocus();
      component.WeaponRangeType = weaponRangeType;
      component.HasFocus = hasFocus;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="StatRecommendationChange"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(StatRecommendationChange))]
    public TBuilder AddStatRecommendationChange(
        StatType stat = default,
        bool recommended = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new StatRecommendationChange();
      component.Stat = stat;
      component.Recommended = recommended;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteFullStatValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PrerequisiteFullStatValue))]
    public TBuilder AddPrerequisiteFullStatValue(
        StatType stat = default,
        int value = default,
        Prerequisite.GroupType group = default,
        bool checkInProgression = default,
        bool hideInUI = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new PrerequisiteFullStatValue();
      component.Stat = stat;
      component.Value = value;
      component.Group = group;
      component.CheckInProgression = checkInProgression;
      component.HideInUI = hideInUI;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellbookFeature"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbook"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    [Implements(typeof(AddSpellbookFeature))]
    public TBuilder AddSpellbookFeature(
        string spellbook = null,
        int casterLevel = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddSpellbookFeature();
      component.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(spellbook);
      component.CasterLevel = casterLevel;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellbookLevel"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spellbook"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    [Implements(typeof(AddSpellbookLevel))]
    public TBuilder AddSpellbookLevel(
        string spellbook = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddSpellbookLevel();
      component.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(spellbook);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellsPerDay"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddSpellsPerDay))]
    public TBuilder AddSpellsPerDay(
        int amount = default,
        int[] levels = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new AddSpellsPerDay();
      component.Amount = amount;
      component.Levels = levels;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmorSpeedPenaltyRemoval"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmorSpeedPenaltyRemoval))]
    public TBuilder AddArmorSpeedPenaltyRemoval(
        BlueprintComponent.Flags flags = default)
    {
      var component = new ArmorSpeedPenaltyRemoval();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BuffExtraEffects"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="checkedBuff"><see cref="BlueprintBuff"/></param>
    /// <param name="extraEffectBuff"><see cref="BlueprintBuff"/></param>
    /// <param name="exceptionFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(BuffExtraEffects))]
    public TBuilder AddBuffExtraEffects(
        string checkedBuff = null,
        string extraEffectBuff = null,
        string exceptionFact = null,
        BlueprintComponent.Flags flags = default)
    {
      var component = new BuffExtraEffects();
      component.m_CheckedBuff = BlueprintTool.GetRef<BlueprintBuffReference>(checkedBuff);
      component.m_ExtraEffectBuff = BlueprintTool.GetRef<BlueprintBuffReference>(extraEffectBuff);
      component.m_ExceptionFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(exceptionFact);
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="HarmoniousMage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HarmoniousMage))]
    public TBuilder AddHarmoniousMage(
        BlueprintComponent.Flags flags = default)
    {
      var component = new HarmoniousMage();
      component.m_Flags = flags;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavesFixerRecalculate"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavesFixerRecalculate))]
    public TBuilder AddSavesFixerRecalculate(
        int version = default,
        BlueprintComponent.Flags flags = default)
    {
      var component = new SavesFixerRecalculate();
      component.Version = version;
      component.m_Flags = flags;
      return AddComponent(component);
    }

    protected override void ConfigureInternal()
    {
      base.ConfigureInternal();

      if (EnableFeatureTags > 0 || DisableFeatureTags > 0) { ConfigureFeatureTags(); }

      if (EnableIsPrerequisiteFor.Count > 0 || DisableIsPrerequisiteFor.Count > 0)
      {
        ConfigureIsPrerequisiteFor();
      }
      if (EnableGroups.Count > 0 || DisableGroups.Count > 0) { ConfigureFeatureGroups(); }
    }

    protected override void ValidateInternal()
    {
      base.ValidateInternal();

      if (Blueprint.GetComponents<FeatureTagsComponent>().Count() > 1)
      {
        AddValidationWarning("Multiple FeatureTagsComponents present. Only the first is used.");
      }
    }

    private void ConfigureFeatureTags()
    {
      var component = Blueprint.GetComponent<FeatureTagsComponent>();
      if (component == null)
      {
        // Don't create a component to disable tags
        if (EnableFeatureTags == 0) { return; }

        component = new FeatureTagsComponent();
        AddComponent(component);
      }
      component.FeatureTags |= EnableFeatureTags;
      component.FeatureTags &= ~DisableFeatureTags;
    }

    private void ConfigureIsPrerequisiteFor()
    {
      EnableIsPrerequisiteFor.AddRange(
          Blueprint.IsPrerequisiteFor ?? new List<BlueprintFeatureReference>());
      foreach (BlueprintFeatureReference disableRef in DisableIsPrerequisiteFor)
      {
        EnableIsPrerequisiteFor.Remove(disableRef);
      }
      Blueprint.IsPrerequisiteFor = EnableIsPrerequisiteFor;
    }

    private void ConfigureFeatureGroups()
    {
      EnableGroups.AddRange(Blueprint.Groups ?? Array.Empty<FeatureGroup>());
      foreach (FeatureGroup disableGroup in DisableGroups)
      {
        EnableGroups.Remove(disableGroup);
      }
      Blueprint.Groups = EnableGroups.ToArray();
    }
  }

  /// <summary>Configurator for <see cref="BlueprintFeature"/>.</summary>
  /// <inheritdoc/>
  public class FeatureConfigurator : BaseFeatureConfigurator<BlueprintFeature, FeatureConfigurator>
  {
    private FeatureConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static FeatureConfigurator For(string name)
    {
      return new FeatureConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static FeatureConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintFeature>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static FeatureConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintFeature>(name, assetId);
      return For(name);
    }
  }
}
