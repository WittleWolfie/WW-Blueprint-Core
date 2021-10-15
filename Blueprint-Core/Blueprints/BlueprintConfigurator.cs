using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Validation;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.Mechanics.Components;

namespace BlueprintCore.Blueprints
{
  /**
   * Base class for configuring a Blueprint using a fluent API. Does not support primitive and enum
   * fields which can be configured easily using .jsb and .patch files. Flags are supported.
   */
  public abstract class BlueprintConfigurator<T, TBuilder>
      where T : BlueprintScriptableObject
      where TBuilder : BlueprintConfigurator<T, TBuilder>
  {
    /**
     * Describes interaction behavior when there are two components of the same type which does not
     * allow multiples. i.e. Two components of the same type w/o [AllowMultipleComponents].
     *
     * Merge is done using an Action<>() and must modify the existing component in-place. Some
     * unique components will come with a default merge action, see the specific component function
     * for details.
     */
    public enum ComponentMerge
    {
      // Throw an exception and cancel blueprint configuration.
      Fail = 0,
      // Ignore the new component entirely.
      Skip,
      // The new component replaces the existing component. 
      Replace,
      // Attempt to merge the components. Requires a function for handling the merge.
      Merge
    }

    protected static readonly LogWrapper Logger = LogWrapper.GetInternal("BlueprintConfigurator");

    private readonly List<BlueprintComponent> Components = new();
    private readonly HashSet<UniqueComponent> UniqueComponents = new();
    private readonly List<BlueprintComponent> ComponentsToRemove = new();
    private readonly List<Action<T>> InternalOnConfigure = new();
    private readonly List<Action<T>> ExternalOnConfigure = new();
    private readonly ValidationContext Context = new();

    private bool Configured = false;
    private readonly StringBuilder ValidationWarnings = new();

    private long EnableSpellDescriptors;
    private long DisableSpellDescriptors;

    private AlignmentMaskType EnablePrerequisiteAlignment;
    private AlignmentMaskType DisablePrerequisiteAlignment;

    protected readonly TBuilder Self = null;
    protected readonly string Name;
    protected readonly T Blueprint;

    protected BlueprintConfigurator(string name)
    {
      Self = (TBuilder)this;
      Name = name;
      Blueprint = BlueprintTool.Get<T>(name);
    }

    /** Commits the configuration to the blueprint. */
    public T Configure()
    {
      if (Configured)
      {
        throw new InvalidOperationException($"{Name} has already been configured.");
      }

      Configured = true;
      Logger.Verbose($"Configuring {Name}.");
      ConfigureBase();
      ConfigureInternal();

      AddComponents();
      OnConfigure();
      Blueprint.OnEnable();

      Logger.Verbose($"Validating configuration for {Name}.");
      ValidateBase();
      ValidateInternal();

      if (ValidationWarnings.Length > 0)
      {
        ValidationWarnings.Insert(
            /* index= */ 0,
            $"{Name} - {typeof(T)} has warnings:{Environment.NewLine}");
        Logger.Warn(ValidationWarnings.ToString());
      }
      return Blueprint;
    }

    public TBuilder AddComponent(BlueprintComponent component)
    {
      Components.Add(component);
      return Self;
    }

    /**
     * Executes the provided action when Configure() is called. This runs as the last step of
     * configuration, after all other configurations are applied.
     */
    public TBuilder OnConfigure(Action<T> action)
    {
      ExternalOnConfigure.Add(action);
      return Self;
    }

    /**
     * Protected function for running actions when Configure() is called. Executes after all
     * configuration is applied except for changes set using OnConfigure(). All built-in functions
     * should use this to ensure the blueprint is fully configured before user actions are run.
     */
    protected TBuilder OnConfigureInternal(Action<T> action)
    {
      InternalOnConfigure.Add(action);
      return Self;
    }

    /** Use when a component cannot be present multiple times.*/
    public TBuilder AddUniqueComponent(
        BlueprintComponent component,
        ComponentMerge behavior = ComponentMerge.Fail,
        Action<BlueprintComponent, BlueprintComponent> merge = null)
    {
      UniqueComponents.Add(new UniqueComponent(component, behavior, merge));
      return Self;
    }

    /**
     * Removes pre-existing components that match the provided predicate. Will not operate on
     * components added with the configurator or added after this is called.
     */
    public TBuilder RemoveComponents(Func<BlueprintComponent, bool> predicate)
    {
      ComponentsToRemove.AddRange(Blueprint.Components.Where(predicate));
      return Self;
    }

    //------ Start: Misc. Components

    /** SpellDescriptorComponent */
    public TBuilder AddSpellDescriptors(params SpellDescriptor[] descriptors)
    {
      foreach (SpellDescriptor descriptor in descriptors)
      {
        EnableSpellDescriptors |= (long)descriptor;
      }
      return Self;
    }

    /** SpellDescriptorComponent */
    public TBuilder RemoveSpellDescriptors(params SpellDescriptor[] descriptors)
    {
      foreach (SpellDescriptor descriptor in descriptors)
      {
        DisableSpellDescriptors |= (long)descriptor;
      }
      return Self;
    }

    /**
     * ContextRankConfig
     *
     * Use ContextRankConfigs to construct your config.
     */
    public TBuilder ContextRankConfig(ContextRankConfig rankConfig)
    {
      return AddComponent(rankConfig);
    }

    /**
     * AddFactContextActions
     *
     * Merge: Concatenates action lists.
     */
    public TBuilder FactContextActions(
        ActionListBuilder onActivated = null,
        ActionListBuilder onDeactivated = null,
        ActionListBuilder onNewRound = null,
        ComponentMerge behavior = ComponentMerge.Merge,
        Action<BlueprintComponent, BlueprintComponent> merge = null)
    {
      if (onActivated == null && onDeactivated == null && onNewRound == null)
      {
        throw new InvalidOperationException("No actions provided.");
      }
      var contextActions = new AddFactContextActions
      {
        Activated = onActivated?.Build() ?? Constants.Empty.Actions,
        Deactivated = onDeactivated?.Build() ?? Constants.Empty.Actions,
        NewRound = onNewRound?.Build() ?? Constants.Empty.Actions
      };
      return AddUniqueComponent(contextActions, behavior, merge ?? MergeFactContextActions);
    }

    private static void MergeFactContextActions(
        BlueprintComponent current, BlueprintComponent other)
    {
      var source = current as AddFactContextActions;
      var target = other as AddFactContextActions;
      source.Activated.Actions = source.Activated.Actions.AppendToArray(target.Activated.Actions);
      source.Deactivated.Actions =
          source.Deactivated.Actions.AppendToArray(target.Deactivated.Actions);
      source.NewRound.Actions = source.NewRound.Actions.AppendToArray(target.NewRound.Actions);
    }

    //----- Start: Prerequisites

    /** PrerequisiteAlignment */
    public TBuilder AddPrerequisiteAlignment(params AlignmentMaskType[] alignments)
    {
      foreach (AlignmentMaskType alignment in alignments)
      {
        EnablePrerequisiteAlignment |= alignment;
      }
      return Self;
    }

    /** PrerequisiteAlignment */
    public TBuilder RemovePrerequisiteAlignment(params AlignmentMaskType[] alignments)
    {
      foreach (AlignmentMaskType alignment in alignments)
      {
        DisablePrerequisiteAlignment |= alignment;
      }
      return Self;
    }

    /**
     * PrerequisiteArchetypeLevel
     *
     * @param clazz BlueprintCharacterClass
     * @param archetype BlueprintArchetype
     */
    public TBuilder PrerequisiteArchetype(
        string clazz,
        string archetype,
        int level = 1,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq =
          PrereqTools.Create<PrerequisiteArchetypeLevel>(group, checkInProgression, hideInUI);
      prereq.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      prereq.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype);
      prereq.Level = level;
      return AddComponent(prereq);
    }

    /**
     * PrerequisiteCasterType
     * 
     * Merge: Replaces existing component.
     */
    public TBuilder PrerequisiteCasterType(
        bool isArcane,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false,
        ComponentMerge behavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent> merge = null)
    {
      var prereq =
          PrereqTools.Create<PrerequisiteCasterType>(group, checkInProgression, hideInUI);
      prereq.IsArcane = isArcane;
      return AddUniqueComponent(prereq, behavior, merge);
    }

    /** PrerequisiteCasterTypeSpellLevel */
    public TBuilder PrerequisiteCasterTypeSpellLevel(
        bool isArcane,
        bool onlySpontaneous,
        int minSpellLevel,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq =
          PrereqTools.Create<PrerequisiteCasterTypeSpellLevel>(group, checkInProgression, hideInUI);
      prereq.IsArcane = isArcane;
      prereq.OnlySpontaneous = onlySpontaneous;
      prereq.RequiredSpellLevel = minSpellLevel;
      return AddComponent(prereq);
    }

    /**
     * PrerequisiteCharacterLevel
     *
     * Merge: Replaces existing component.
     */
    public TBuilder PrerequisiteCharacterLevel(
        int minLevel,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false,
        ComponentMerge behavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent> merge = null)
    {
      var prereq =
          PrereqTools.Create<PrerequisiteCharacterLevel>(group, checkInProgression, hideInUI);
      prereq.Level = minLevel;
      return AddUniqueComponent(prereq, behavior, merge);
    }

    /**
     * PrerequisiteCharacterLevel
     *
     * @param clazz BlueprintCharacterClass
     */
    public TBuilder PrerequisiteClassLevel(
        string clazz,
        int minLevel,
        bool negate = false,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq =
          PrereqTools.Create<PrerequisiteClassLevel>(group, checkInProgression, hideInUI);
      prereq.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      prereq.Level = minLevel;
      prereq.Not = negate;
      return AddComponent(prereq);
    }

    /**
     * PrerequisiteClassSpellLevel
     * 
     * Merge: Replaces existing component.
     *
     * @param clazz BlueprintCharacterClass
     */
    public TBuilder PrerequisiteClassSpellLevel(
        string clazz,
        int minSpellLevel,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false,
        ComponentMerge behavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent> merge = null)
    {
      var prereq =
          PrereqTools.Create<PrerequisiteClassSpellLevel>(group, checkInProgression, hideInUI);
      prereq.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      prereq.RequiredSpellLevel = minSpellLevel;
      return AddUniqueComponent(prereq, behavior, merge);
    }

    /**
     * PrerequisiteEtude
     *
     * @param etude BlueprintEtude
     */
    public TBuilder PrerequisiteEtude(
        string etude,
        bool playing = true,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq =
          PrereqTools.Create<PrerequisiteEtude>(group, checkInProgression, hideInUI);
      prereq.Etude = BlueprintTool.GetRef<BlueprintEtudeReference>(etude);
      prereq.NotPlaying = !playing;
      return AddComponent(prereq);
    }

    /**
     * PrerequisiteFeature
     *
     * @param feature BlueprintFeature
     */
    public TBuilder PrerequisiteFeature(
        string feature,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq =
          PrereqTools.Create<PrerequisiteFeature>(group, checkInProgression, hideInUI);
      prereq.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      return AddComponent(prereq);
    }

    /**
     * PrerequisiteFeaturesFromList
     *
     * @param features BlueprintFeature
     */
    public TBuilder PrerequisiteFeaturesFromList(
        string[] features,
        int requiredNumber = 1,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq =
          PrereqTools.Create<PrerequisiteFeaturesFromList>(group, checkInProgression, hideInUI);
      prereq.m_Features =
          features
              .Select(feature => BlueprintTool.GetRef<BlueprintFeatureReference>(feature))
              .ToArray();
      prereq.Amount = requiredNumber;
      return AddComponent(prereq);
    }

    /** PrerequisiteIsPet */
    public TBuilder PrerequisiteIsPet(
        bool negate = false,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq =
          PrereqTools.Create<PrerequisiteIsPet>(group, checkInProgression, hideInUI);
      prereq.Not = negate;
      return AddComponent(prereq);
    }

    /**
     * PrerequisiteMainCharacter
     *
     * Merge: Replaces existing component.
     */
    public TBuilder PrerequisiteMainCharacter(
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false,
        ComponentMerge behavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent> merge = null)
    {
      var prereq =
          PrereqTools.Create<PrerequisiteMainCharacter>(group, checkInProgression, hideInUI);
      return AddUniqueComponent(prereq, behavior, merge);
    }

    /**
     * PrerequisiteMainCharacter
     *
     * Merge: Replaces existing component.
     */
    public TBuilder PrerequisiteCompanion(
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false,
        ComponentMerge behavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent> merge = null)
    {
      var prereq =
          PrereqTools.Create<PrerequisiteMainCharacter>(group, checkInProgression, hideInUI);
      prereq.Companion = true;
      return AddUniqueComponent(prereq, behavior, merge);
    }

    /**
     * PrerequisiteMythicLevel
     *
     * Merge: Replaces existing component.
     */
    public TBuilder PrerequisiteMythicLevel(
        int level,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false,
        ComponentMerge behavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent> merge = null)
    {
      var prereq =
          PrereqTools.Create<PrerequisiteMythicLevel>(group, checkInProgression, hideInUI);
      prereq.Level = level;
      return AddUniqueComponent(prereq, behavior, merge);
    }

    /**
     * PrerequisiteNoArchetype
     *
     * @param clazz BlueprintCharacterClass
     * @param archetype BlueprintArchetype
     */
    public TBuilder PrerequisiteNoArchetype(
        string clazz,
        string archetype,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq =
          PrereqTools.Create<PrerequisiteNoArchetype>(group, checkInProgression, hideInUI);
      prereq.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      prereq.m_Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetype);
      return AddComponent(prereq);
    }

    /**
     * PrerequisiteNoClassLevel
     *
     * @param clazz BlueprintCharacterClass
     */
    public TBuilder PrerequisiteNoClass(
        string clazz,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq =
          PrereqTools.Create<PrerequisiteNoClassLevel>(group, checkInProgression, hideInUI);
      prereq.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(clazz);
      return AddComponent(prereq);
    }

    /**
     * PrerequisiteNoFeature
     *
     * @param feature BlueprintFeature
     */
    public TBuilder PrerequisiteNoFeature(
        string feature,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq =
          PrereqTools.Create<PrerequisiteNoFeature>(group, checkInProgression, hideInUI);
      prereq.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      return AddComponent(prereq);
    }

    /**
     * PrerequisiteNotProficient
     *
     * Merge: Replaces existing component.
     *
     * @param feature BlueprintFeature
     */
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
          PrereqTools.Create<PrerequisiteNotProficient>(group, checkInProgression, hideInUI);
      prereq.WeaponProficiencies = weapons ?? Constants.Empty.WeaponCategories;
      prereq.ArmorProficiencies = armors ?? Constants.Empty.ArmorProficiencies;
      return AddUniqueComponent(prereq, behavior, merge);
    }

    /**
     * PrerequisiteParametrizedFeature
     *
     * @param spellFeature BlueprintFeature
     * @param spellAbility BlueprintAbility
     */
    public TBuilder PrerequisiteParameterizedSpellFeature(
        string spellFeature,
        string spellAbility,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq =
          PrereqTools.Create<PrerequisiteParametrizedFeature>(group, checkInProgression, hideInUI);
      // Note: There is no distinction between SpellSpecialization and LearnSpell, despite them
      // being called out independently in the component.
      prereq.ParameterType = FeatureParameterType.LearnSpell;
      prereq.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(spellFeature);
      prereq.m_Spell = BlueprintTool.GetRef<BlueprintAbilityReference>(spellAbility);
      return AddComponent(prereq);
    }

    /**
     * PrerequisiteParametrizedFeature
     *
     * @param feature BlueprintFeature
     */
    public TBuilder PrerequisiteParameterizedWeaponFeature(
        string feature,
        WeaponCategory weapon,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq =
          PrereqTools.Create<PrerequisiteParametrizedFeature>(group, checkInProgression, hideInUI);
      prereq.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      prereq.ParameterType = FeatureParameterType.WeaponCategory;
      prereq.WeaponCategory = weapon;
      return AddComponent(prereq);
    }

    /**
     * PrerequisiteParametrizedFeature
     *
     * @param feature BlueprintFeature
     */
    public TBuilder PrerequisiteParameterizedSpellSchoolFeature(
        string feature,
        SpellSchool school,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq =
          PrereqTools.Create<PrerequisiteParametrizedFeature>(group, checkInProgression, hideInUI);
      prereq.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      prereq.ParameterType = FeatureParameterType.SpellSchool;
      prereq.SpellSchool = school;
      return AddComponent(prereq);
    }

    /**
     * PrerequisiteParametrizedWeaponSubcategory
     *
     * @param weaponFeature BlueprintFeature
     */
    public TBuilder PrerequisiteParameterizedWeaponSubcategory(
        string weaponFeature,
        WeaponSubCategory weapon,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq =
          PrereqTools.Create<PrerequisiteParametrizedWeaponSubcategory>(
                group, checkInProgression, hideInUI);
      prereq.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(weaponFeature);
      prereq.SubCategory = weapon;
      return AddComponent(prereq);
    }

    /** PrerequisitePet */
    public TBuilder PrerequisitePet(
        PetType type,
        bool negate = false,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTools.Create<PrerequisitePet>(group, checkInProgression, hideInUI);
      prereq.Type = type;
      prereq.NoCompanion = negate;
      return AddComponent(prereq);
    }

    /**
     * PrerequisitePlayerHasFeature
     *
     * @param feature BlueprintFeature
     */
    public TBuilder PrerequisitePlayerHasFeature(
        string feature,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq =
          PrereqTools.Create<PrerequisitePlayerHasFeature>(group, checkInProgression, hideInUI);
      prereq.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(feature);
      return AddComponent(prereq);
    }

    /**
     * PrerequisiteProficiency
     *
     * Merge: Replaces existing component.
     */
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
          PrereqTools.Create<PrerequisiteProficiency>(group, checkInProgression, hideInUI);
      prereq.WeaponProficiencies = weapons ?? Constants.Empty.WeaponCategories;
      prereq.ArmorProficiencies = armors ?? Constants.Empty.ArmorProficiencies;
      return AddUniqueComponent(prereq, behavior, merge);
    }

    /** PrerequisiteStatValue */
    public TBuilder PrerequisiteStat(
        StatType type,
        int minValue,
        Prerequisite.GroupType group = Prerequisite.GroupType.All,
        bool checkInProgression = false,
        bool hideInUI = false)
    {
      var prereq = PrereqTools.Create<PrerequisiteStatValue>(group, checkInProgression, hideInUI);
      prereq.Stat = type;
      prereq.Value = minValue;
      return AddComponent(prereq);
    }

    //----- Start: Configure & Validate

    private void ConfigureBase()
    {
      ConfigurePrerequisiteAlignment();
      ConfigureSpellDescriptors();
    }

    /**
     * Handles type specific configuration. Components are added to the Blueprint after this is
     * called, so any configuration that would add a Component should just add to Components.
     */
    protected abstract void ConfigureInternal();

    private void OnConfigure()
    {
      InternalOnConfigure.ForEach(action => action.Invoke(Blueprint));
      ExternalOnConfigure.ForEach(action => action.Invoke(Blueprint));
    }

    private void AddComponents()
    {
      foreach (UniqueComponent component in UniqueComponents)
      {
        var current = Blueprint.GetComponentMatchingType(component.Component);
        if (current == null)
        {
          Components.Add(component.Component);
          continue;
        }
        switch (component.Behavior)
        {
          case ComponentMerge.Skip:
            break;
          case ComponentMerge.Replace:
            ComponentsToRemove.Add(current);
            Components.Add(component.Component);
            break;
          case ComponentMerge.Merge:
            component.Merge(current, component.Component);
            break;
          case ComponentMerge.Fail:
          default:
            throw new InvalidOperationException(
                $"Failed merging components of type {current.GetType()}");
        }
      }

      Blueprint.Components = Blueprint.Components.Except(ComponentsToRemove).ToArray();
      Blueprint.AddComponents(Components.ToArray());
    }

    private void ValidateBase()
    {
      var validationContext = new ValidationContext();
      Blueprint.Validate(validationContext);
      foreach (var error in validationContext.Errors)
      {
        AddValidationWarning(error);
      }

      ValidateComponents();
    }

    /**
     * Confirms if the blueprint configuration is valid. Errors should be reported using
     * {@link AddValidationError}.
     */
    protected abstract void ValidateInternal();

    protected void AddValidationWarning(string msg)
    {
      ValidationWarnings.AppendLine(msg);
    }

    private void ConfigurePrerequisiteAlignment()
    {
      var component = Blueprint.GetComponent<PrerequisiteAlignment>();
      if (component == null)
      {
        // Don't create a component to remove prerequisite alignments
        if (EnablePrerequisiteAlignment == 0) { return; }

        component = new PrerequisiteAlignment();
        AddComponent(component);
      }
      component.Alignment |= EnablePrerequisiteAlignment;
      component.Alignment &= ~DisablePrerequisiteAlignment;
    }

    private void ConfigureSpellDescriptors()
    {
      var component = Blueprint.GetComponent<SpellDescriptorComponent>();
      if (component == null)
      {
        // Don't create a component to remove descriptors
        if (EnableSpellDescriptors == 0) { return; }

        component = new SpellDescriptorComponent();
        AddComponent(component);
      }
      component.Descriptor.m_IntValue |= EnableSpellDescriptors;
      component.Descriptor.m_IntValue &= ~DisableSpellDescriptors;
    }

    /**
     * Validates each of the Blueprint's components using its internal validation and using its
     * attributes.
     */
    private void ValidateComponents()
    {
      if (Blueprint.Components == null) { return; }
      var componentTypes = new HashSet<Type>();
      foreach (BlueprintComponent component in Blueprint.Components)
      {
        component.ApplyValidation(Context);

        var componentType = component.GetType();
        Attribute[] attrs = Attribute.GetCustomAttributes(componentType);

        if (componentTypes.Contains(componentType)
            && attrs.Where(attr => attr is AllowMultipleComponentsAttribute).Count() == 0)
        {
          AddValidationWarning($"Multiple {componentType} present but only one is allowed.");
        }
        else { componentTypes.Add(componentType); }

        List<AllowedOnAttribute> allowedOn =
            attrs
                .Where(attr => attr is AllowedOnAttribute)
                .Select(attr => attr as AllowedOnAttribute)
                .ToList();
        bool componentAllowed = false;
        var blueprintType = Blueprint.GetType();
        foreach (AllowedOnAttribute attr in allowedOn)
        {
          // Need .NET 5.0 for IsAssignableTo()
          if (IsAssignableTo(blueprintType, attr.Type))
          {
            componentAllowed = true;
            break;
          }
        }

        if (allowedOn.Count > 0 && !componentAllowed)
        {
          AddValidationWarning($"Component of {componentType} not allowed on {blueprintType}");
        }
      }

      Context.Errors.ToList().ForEach(str => AddValidationWarning(str));
    }

    private static bool IsAssignableTo(Type child, Type parent)
    {
      return child == parent || child.IsSubclassOf(parent);
    }

    private struct UniqueComponent
    {
      public BlueprintComponent Component { get; }
      public ComponentMerge Behavior { get; }
      public Action<BlueprintComponent, BlueprintComponent> Merge { get; }

      public UniqueComponent(
          BlueprintComponent component,
          ComponentMerge behavior,
          Action<BlueprintComponent, BlueprintComponent> merge)
      {
        Component = component;
        Behavior = behavior;
        Merge = merge;
      }
    }
  }
}