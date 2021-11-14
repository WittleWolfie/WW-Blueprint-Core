using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Facts;
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
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
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
  public abstract class BaseFeatureConfigurator<T, TBuilder> : BaseUnitFactConfigurator<T, TBuilder>
      where T : BlueprintFeature
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
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
    public TBuilder ContextRankConfig(ContextRankConfig rankConfig)
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
    /// Adds or modifies <see cref="SpellDescriptorComponent"/>
    /// </summary>
    [Implements(typeof(SpellDescriptorComponent))]
    public TBuilder AddSpellDescriptors(params SpellDescriptor[] descriptors)
    {
      foreach (SpellDescriptor descriptor in descriptors)
      {
        EnableSpellDescriptors |= (long)descriptor;
      }
      return Self;
    }

    /// <summary>
    /// Modifies <see cref="SpellDescriptorComponent"/>
    /// </summary>
    [Implements(typeof(SpellDescriptorComponent))]
    public TBuilder RemoveSpellDescriptors(params SpellDescriptor[] descriptors)
    {
      foreach (SpellDescriptor descriptor in descriptors)
      {
        DisableSpellDescriptors |= (long)descriptor;
      }
      return Self;
    }

    /// <summary>
    /// Adds or modifies <see cref="PrerequisiteAlignment"/>
    /// </summary>
    [Implements(typeof(PrerequisiteAlignment))]
    public TBuilder AddPrerequisiteAlignment(params AlignmentMaskType[] alignments)
    {
      foreach (AlignmentMaskType alignment in alignments) { EnablePrerequisiteAlignment |= alignment; }
      return Self;
    }

    /// <summary>
    /// Modifies <see cref="PrerequisiteAlignment"/>
    /// </summary>
    [Implements(typeof(PrerequisiteAlignment))]
    public TBuilder RemovePrerequisiteAlignment(params AlignmentMaskType[] alignments)
    {
      foreach (AlignmentMaskType alignment in alignments) { DisablePrerequisiteAlignment |= alignment; }
      return Self;
    }

    /// <summary>
    /// Adds <see cref="AddGlobalMapSpellFeature"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spell"><see cref="BlueprintGlobalMagicSpell"/></param>
    [Generated]
    [Implements(typeof(AddGlobalMapSpellFeature))]
    public TBuilder AddAddGlobalMapSpellFeature(
        string m_Spell)
    {
      
      var component =  new AddGlobalMapSpellFeature();
      component.m_Spell = BlueprintTool.GetRef<BlueprintGlobalMagicSpell.Reference>(m_Spell);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FeatureSurvivesRespec"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(FeatureSurvivesRespec))]
    public TBuilder AddFeatureSurvivesRespec()
    {
      return AddComponent(new FeatureSurvivesRespec());
    }

    /// <summary>
    /// Adds <see cref="LevelUpRecommendation"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LevelUpRecommendation))]
    public TBuilder AddLevelUpRecommendation(
        ClassesPriority[] ClassPriorities)
    {
      foreach (var item in ClassPriorities)
      {
        ValidateParam(item);
      }
      
      var component =  new LevelUpRecommendation();
      component.ClassPriorities = ClassPriorities;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteLoreMaster"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_LoreMaster"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(PrerequisiteLoreMaster))]
    public TBuilder AddPrerequisiteLoreMaster(
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
    /// Adds <see cref="AddBuffInBadWeather"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AddBuffInBadWeather))]
    public TBuilder AddAddBuffInBadWeather(
        string m_Buff,
        InclemencyType Weather,
        bool WhenCalmer)
    {
      ValidateParam(Weather);
      
      var component =  new AddBuffInBadWeather();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      component.Weather = Weather;
      component.WhenCalmer = WhenCalmer;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddBuffOnApplyingSpell"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddBuffOnApplyingSpell))]
    public TBuilder AddAddBuffOnApplyingSpell(
        bool OnEffectApplied,
        bool OnResistSpell,
        AddBuffOnApplyingSpell.SpellConditionAndBuff[] Buffs)
    {
      foreach (var item in Buffs)
      {
        ValidateParam(item);
      }
      
      var component =  new AddBuffOnApplyingSpell();
      component.OnEffectApplied = OnEffectApplied;
      component.OnResistSpell = OnResistSpell;
      component.Buffs = Buffs;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddContextStatBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddContextStatBonus))]
    public TBuilder AddAddContextStatBonus(
        ModifierDescriptor Descriptor,
        StatType Stat,
        int Multiplier,
        ContextValue Value,
        bool HasMinimal,
        int Minimal)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      ValidateParam(Value);
      
      var component =  new AddContextStatBonus();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.Multiplier = Multiplier;
      component.Value = Value;
      component.HasMinimal = HasMinimal;
      component.Minimal = Minimal;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeaturesFromSelectionToDescription"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_FeatureSelection"><see cref="BlueprintFeatureSelection"/></param>
    [Generated]
    [Implements(typeof(AddFeaturesFromSelectionToDescription))]
    public TBuilder AddAddFeaturesFromSelectionToDescription(
        LocalizedString Introduction,
        string m_FeatureSelection,
        bool OnlyIfRequiresThisFeature)
    {
      ValidateParam(Introduction);
      
      var component =  new AddFeaturesFromSelectionToDescription();
      component.Introduction = Introduction;
      component.m_FeatureSelection = BlueprintTool.GetRef<BlueprintFeatureSelectionReference>(m_FeatureSelection);
      component.OnlyIfRequiresThisFeature = OnlyIfRequiresThisFeature;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddGoldenDragonSkillBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddGoldenDragonSkillBonus))]
    public TBuilder AddAddGoldenDragonSkillBonus(
        ModifierDescriptor Descriptor,
        StatType Stat)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      
      var component =  new AddGoldenDragonSkillBonus();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddLocustSwarmMechanicPart"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddLocustSwarmMechanicPart))]
    public TBuilder AddAddLocustSwarmMechanicPart(
        int m_SwarmStartStrength)
    {
      
      var component =  new AddLocustSwarmMechanicPart();
      component.m_SwarmStartStrength = m_SwarmStartStrength;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddMagusMechanicPart"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddMagusMechanicPart))]
    public TBuilder AddAddMagusMechanicPart(
        AddMagusMechanicPart.Feature m_Feature)
    {
      ValidateParam(m_Feature);
      
      var component =  new AddMagusMechanicPart();
      component.m_Feature = m_Feature;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddNocticulaBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddNocticulaBonus))]
    public TBuilder AddAddNocticulaBonus(
        ModifierDescriptor Descriptor,
        ContextValue HighestStatBonus,
        StatType m_HighestStat,
        ContextValue SecondHighestStatBonus,
        StatType m_SecondHighestStat)
    {
      ValidateParam(Descriptor);
      ValidateParam(HighestStatBonus);
      ValidateParam(m_HighestStat);
      ValidateParam(SecondHighestStatBonus);
      ValidateParam(m_SecondHighestStat);
      
      var component =  new AddNocticulaBonus();
      component.Descriptor = Descriptor;
      component.HighestStatBonus = HighestStatBonus;
      component.m_HighestStat = m_HighestStat;
      component.SecondHighestStatBonus = SecondHighestStatBonus;
      component.m_SecondHighestStat = m_SecondHighestStat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddRestTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddRestTrigger))]
    public TBuilder AddAddRestTrigger(
        ActionsBuilder Action)
    {
      
      var component =  new AddRestTrigger();
      component.Action = Action.Build();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellsToDescription"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_SpellLists"><see cref="BlueprintSpellList"/></param>
    /// <param name="m_Spells"><see cref="BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(AddSpellsToDescription))]
    public TBuilder AddAddSpellsToDescription(
        LocalizedString Introduction,
        string[] m_SpellLists,
        string[] m_Spells)
    {
      ValidateParam(Introduction);
      
      var component =  new AddSpellsToDescription();
      component.Introduction = Introduction;
      component.m_SpellLists = m_SpellLists.Select(bp => BlueprintTool.GetRef<BlueprintSpellListReference>(bp)).ToArray();
      component.m_Spells = m_Spells.Select(bp => BlueprintTool.GetRef<BlueprintAbilityReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddTricksterAthleticBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddTricksterAthleticBonus))]
    public TBuilder AddAddTricksterAthleticBonus(
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Descriptor);
      
      var component =  new AddTricksterAthleticBonus();
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddWeaponEnhancementBonusToStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddWeaponEnhancementBonusToStat))]
    public TBuilder AddAddWeaponEnhancementBonusToStat(
        ModifierDescriptor Descriptor,
        StatType Stat,
        int Multiplier)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      
      var component =  new AddWeaponEnhancementBonusToStat();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.Multiplier = Multiplier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MountedShield"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MountedShield))]
    public TBuilder AddMountedShield(
        ModifierDescriptor Descriptor,
        StatType Stat)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      
      var component =  new MountedShield();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShroudOfWater"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_UpgradeFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(ShroudOfWater))]
    public TBuilder AddShroudOfWater(
        ModifierDescriptor Descriptor,
        StatType Stat,
        ContextValue BaseValue,
        string m_UpgradeFeature)
    {
      ValidateParam(Descriptor);
      ValidateParam(Stat);
      ValidateParam(BaseValue);
      
      var component =  new ShroudOfWater();
      component.Descriptor = Descriptor;
      component.Stat = Stat;
      component.BaseValue = BaseValue;
      component.m_UpgradeFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(m_UpgradeFeature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellResistanceAgainstAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpellResistanceAgainstAlignment))]
    public TBuilder AddSpellResistanceAgainstAlignment(
        ContextValue Value,
        AlignmentComponent Alignment)
    {
      ValidateParam(Value);
      ValidateParam(Alignment);
      
      var component =  new SpellResistanceAgainstAlignment();
      component.Value = Value;
      component.Alignment = Alignment;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellResistanceAgainstSpellDescriptor"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpellResistanceAgainstSpellDescriptor))]
    public TBuilder AddSpellResistanceAgainstSpellDescriptor(
        ContextValue Value,
        SpellDescriptorWrapper SpellDescriptor)
    {
      ValidateParam(Value);
      ValidateParam(SpellDescriptor);
      
      var component =  new SpellResistanceAgainstSpellDescriptor();
      component.Value = Value;
      component.SpellDescriptor = SpellDescriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateAbilityParams"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CustomProperty"><see cref="BlueprintUnitProperty"/></param>
    [Generated]
    [Implements(typeof(ContextCalculateAbilityParams))]
    public TBuilder AddContextCalculateAbilityParams(
        bool UseKineticistMainStat,
        StatType StatType,
        bool StatTypeFromCustomProperty,
        string m_CustomProperty,
        bool ReplaceCasterLevel,
        ContextValue CasterLevel,
        bool ReplaceSpellLevel,
        ContextValue SpellLevel)
    {
      ValidateParam(StatType);
      ValidateParam(CasterLevel);
      ValidateParam(SpellLevel);
      
      var component =  new ContextCalculateAbilityParams();
      component.UseKineticistMainStat = UseKineticistMainStat;
      component.StatType = StatType;
      component.StatTypeFromCustomProperty = StatTypeFromCustomProperty;
      component.m_CustomProperty = BlueprintTool.GetRef<BlueprintUnitPropertyReference>(m_CustomProperty);
      component.ReplaceCasterLevel = ReplaceCasterLevel;
      component.CasterLevel = CasterLevel;
      component.ReplaceSpellLevel = ReplaceSpellLevel;
      component.SpellLevel = SpellLevel;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateAbilityParamsBasedOnClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CharacterClass"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(ContextCalculateAbilityParamsBasedOnClass))]
    public TBuilder AddContextCalculateAbilityParamsBasedOnClass(
        bool UseKineticistMainStat,
        StatType StatType,
        string m_CharacterClass)
    {
      ValidateParam(StatType);
      
      var component =  new ContextCalculateAbilityParamsBasedOnClass();
      component.UseKineticistMainStat = UseKineticistMainStat;
      component.StatType = StatType;
      component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_CharacterClass);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextCalculateSharedValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextCalculateSharedValue))]
    public TBuilder AddContextCalculateSharedValue(
        AbilitySharedValue ValueType,
        ContextDiceValue Value,
        double Modifier)
    {
      ValidateParam(ValueType);
      ValidateParam(Value);
      
      var component =  new ContextCalculateSharedValue();
      component.ValueType = ValueType;
      component.Value = Value;
      component.Modifier = Modifier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ContextSetAbilityParams"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ContextSetAbilityParams))]
    public TBuilder AddContextSetAbilityParams(
        bool Add10ToDC,
        ContextValue DC,
        ContextValue CasterLevel,
        ContextValue Concentration,
        ContextValue SpellLevel)
    {
      ValidateParam(DC);
      ValidateParam(CasterLevel);
      ValidateParam(Concentration);
      ValidateParam(SpellLevel);
      
      var component =  new ContextSetAbilityParams();
      component.Add10ToDC = Add10ToDC;
      component.DC = DC;
      component.CasterLevel = CasterLevel;
      component.Concentration = Concentration;
      component.SpellLevel = SpellLevel;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityDifficultyLimitDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityDifficultyLimitDC))]
    public TBuilder AddAbilityDifficultyLimitDC()
    {
      return AddComponent(new AbilityDifficultyLimitDC());
    }

    /// <summary>
    /// Adds <see cref="TacticalMoraleChanceModifier"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TacticalMoraleChanceModifier))]
    public TBuilder AddTacticalMoraleChanceModifier(
        bool m_ChangePositiveMorale,
        ContextValue m_PositiveMoraleChancePercentDelta,
        bool m_ChangeNegativeMorale,
        ContextValue m_NegativeMoraleChancePercentDelta)
    {
      ValidateParam(m_PositiveMoraleChancePercentDelta);
      ValidateParam(m_NegativeMoraleChancePercentDelta);
      
      var component =  new TacticalMoraleChanceModifier();
      component.m_ChangePositiveMorale = m_ChangePositiveMorale;
      component.m_PositiveMoraleChancePercentDelta = m_PositiveMoraleChancePercentDelta;
      component.m_ChangeNegativeMorale = m_ChangeNegativeMorale;
      component.m_NegativeMoraleChancePercentDelta = m_NegativeMoraleChancePercentDelta;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PureRecommendation"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PureRecommendation))]
    public TBuilder AddPureRecommendation(
        RecommendationPriority Priority)
    {
      ValidateParam(Priority);
      
      var component =  new PureRecommendation();
      component.Priority = Priority;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationAccomplishedSneakAttacker"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationAccomplishedSneakAttacker))]
    public TBuilder AddRecommendationAccomplishedSneakAttacker()
    {
      return AddComponent(new RecommendationAccomplishedSneakAttacker());
    }

    /// <summary>
    /// Adds <see cref="RecommendationBaseAttackPart"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationBaseAttackPart))]
    public TBuilder AddRecommendationBaseAttackPart(
        float MinPart,
        bool NotRecommendIfHigher)
    {
      
      var component =  new RecommendationBaseAttackPart();
      component.MinPart = MinPart;
      component.NotRecommendIfHigher = NotRecommendIfHigher;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationCompanionBoon"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CompanionRank"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(RecommendationCompanionBoon))]
    public TBuilder AddRecommendationCompanionBoon(
        string m_CompanionRank)
    {
      
      var component =  new RecommendationCompanionBoon();
      component.m_CompanionRank = BlueprintTool.GetRef<BlueprintFeatureReference>(m_CompanionRank);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationHasFeature"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Feature"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(RecommendationHasFeature))]
    public TBuilder AddRecommendationHasFeature(
        string m_Feature,
        bool Mandatory)
    {
      
      var component =  new RecommendationHasFeature();
      component.m_Feature = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_Feature);
      component.Mandatory = Mandatory;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationNoFeatFromGroup"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Features"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(RecommendationNoFeatFromGroup))]
    public TBuilder AddRecommendationNoFeatFromGroup(
        string[] m_Features,
        bool GoodIfNoFeature)
    {
      
      var component =  new RecommendationNoFeatFromGroup();
      component.m_Features = m_Features.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      component.GoodIfNoFeature = GoodIfNoFeature;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationRequiresSpellbook"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationRequiresSpellbook))]
    public TBuilder AddRecommendationRequiresSpellbook()
    {
      return AddComponent(new RecommendationRequiresSpellbook());
    }

    /// <summary>
    /// Adds <see cref="RecommendationRequiresSpellbookSource"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationRequiresSpellbookSource))]
    public TBuilder AddRecommendationRequiresSpellbookSource(
        bool Arcane,
        bool Divine,
        bool Alchemist)
    {
      
      var component =  new RecommendationRequiresSpellbookSource();
      component.Arcane = Arcane;
      component.Divine = Divine;
      component.Alchemist = Alchemist;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationStatComparison"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationStatComparison))]
    public TBuilder AddRecommendationStatComparison(
        StatType HigherStat,
        StatType LowerStat,
        int Diff)
    {
      ValidateParam(HigherStat);
      ValidateParam(LowerStat);
      
      var component =  new RecommendationStatComparison();
      component.HigherStat = HigherStat;
      component.LowerStat = LowerStat;
      component.Diff = Diff;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationStatMiminum"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationStatMiminum))]
    public TBuilder AddRecommendationStatMiminum(
        StatType Stat,
        int MinimalValue,
        bool GoodIfHigher)
    {
      ValidateParam(Stat);
      
      var component =  new RecommendationStatMiminum();
      component.Stat = Stat;
      component.MinimalValue = MinimalValue;
      component.GoodIfHigher = GoodIfHigher;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationWeaponSubcategoryFocus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationWeaponSubcategoryFocus))]
    public TBuilder AddRecommendationWeaponSubcategoryFocus(
        WeaponSubCategory Subcategory,
        bool HasFocus,
        bool BadIfNoFocus)
    {
      ValidateParam(Subcategory);
      
      var component =  new RecommendationWeaponSubcategoryFocus();
      component.Subcategory = Subcategory;
      component.HasFocus = HasFocus;
      component.BadIfNoFocus = BadIfNoFocus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="RecommendationWeaponTypeFocus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RecommendationWeaponTypeFocus))]
    public TBuilder AddRecommendationWeaponTypeFocus(
        WeaponRangeType WeaponRangeType,
        bool HasFocus)
    {
      ValidateParam(WeaponRangeType);
      
      var component =  new RecommendationWeaponTypeFocus();
      component.WeaponRangeType = WeaponRangeType;
      component.HasFocus = HasFocus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="StatRecommendationChange"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(StatRecommendationChange))]
    public TBuilder AddStatRecommendationChange(
        StatType Stat,
        bool Recommended)
    {
      ValidateParam(Stat);
      
      var component =  new StatRecommendationChange();
      component.Stat = Stat;
      component.Recommended = Recommended;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PrerequisiteFullStatValue"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PrerequisiteFullStatValue))]
    public TBuilder AddPrerequisiteFullStatValue(
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

    /// <summary>
    /// Adds <see cref="AddSpellbookFeature"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spellbook"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    [Implements(typeof(AddSpellbookFeature))]
    public TBuilder AddAddSpellbookFeature(
        string m_Spellbook,
        int CasterLevel)
    {
      
      var component =  new AddSpellbookFeature();
      component.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(m_Spellbook);
      component.CasterLevel = CasterLevel;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellbookLevel"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Spellbook"><see cref="BlueprintSpellbook"/></param>
    [Generated]
    [Implements(typeof(AddSpellbookLevel))]
    public TBuilder AddAddSpellbookLevel(
        string m_Spellbook)
    {
      
      var component =  new AddSpellbookLevel();
      component.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(m_Spellbook);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddSpellsPerDay"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddSpellsPerDay))]
    public TBuilder AddAddSpellsPerDay(
        int Amount,
        int[] Levels)
    {
      
      var component =  new AddSpellsPerDay();
      component.Amount = Amount;
      component.Levels = Levels;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmorSpeedPenaltyRemoval"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmorSpeedPenaltyRemoval))]
    public TBuilder AddArmorSpeedPenaltyRemoval()
    {
      return AddComponent(new ArmorSpeedPenaltyRemoval());
    }

    /// <summary>
    /// Adds <see cref="BuffExtraEffects"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_CheckedBuff"><see cref="BlueprintBuff"/></param>
    /// <param name="m_ExtraEffectBuff"><see cref="BlueprintBuff"/></param>
    /// <param name="m_ExceptionFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(BuffExtraEffects))]
    public TBuilder AddBuffExtraEffects(
        string m_CheckedBuff,
        string m_ExtraEffectBuff,
        string m_ExceptionFact)
    {
      
      var component =  new BuffExtraEffects();
      component.m_CheckedBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_CheckedBuff);
      component.m_ExtraEffectBuff = BlueprintTool.GetRef<BlueprintBuffReference>(m_ExtraEffectBuff);
      component.m_ExceptionFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_ExceptionFact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="HarmoniousMage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(HarmoniousMage))]
    public TBuilder AddHarmoniousMage()
    {
      return AddComponent(new HarmoniousMage());
    }

    /// <summary>
    /// Adds <see cref="SavesFixerRecalculate"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavesFixerRecalculate))]
    public TBuilder AddSavesFixerRecalculate(
        int Version)
    {
      
      var component =  new SavesFixerRecalculate();
      component.Version = Version;
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
