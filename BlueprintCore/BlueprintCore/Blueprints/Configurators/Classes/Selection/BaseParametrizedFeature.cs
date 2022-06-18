//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Classes.Selection
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintParametrizedFeature"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseParametrizedFeatureConfigurator<T, TBuilder>
    : BaseFeatureConfigurator<T, TBuilder>
    where T : BlueprintParametrizedFeature
    where TBuilder : BaseParametrizedFeatureConfigurator<T, TBuilder>
  {
    protected BaseParametrizedFeatureConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintParametrizedFeature.ParameterType"/>
    /// </summary>
    public TBuilder SetParameterType(FeatureParameterType parameterType)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ParameterType = parameterType;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintParametrizedFeature.ParameterType"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyParameterType(Action<FeatureParameterType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ParameterType);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintParametrizedFeature.WeaponSubCategory"/>
    /// </summary>
    public TBuilder SetWeaponSubCategory(WeaponSubCategory weaponSubCategory)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.WeaponSubCategory = weaponSubCategory;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintParametrizedFeature.WeaponSubCategory"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyWeaponSubCategory(Action<WeaponSubCategory> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.WeaponSubCategory);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintParametrizedFeature.SelectionFeatureGroup"/>
    /// </summary>
    public TBuilder SetSelectionFeatureGroup(FeatureGroup selectionFeatureGroup)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SelectionFeatureGroup = selectionFeatureGroup;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintParametrizedFeature.SelectionFeatureGroup"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySelectionFeatureGroup(Action<FeatureGroup> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.SelectionFeatureGroup);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintParametrizedFeature.RequireProficiency"/>
    /// </summary>
    public TBuilder SetRequireProficiency(bool requireProficiency = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RequireProficiency = requireProficiency;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintParametrizedFeature.RequireProficiency"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRequireProficiency(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.RequireProficiency);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintParametrizedFeature.m_SpellList"/>
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
    /// Modifies <see cref="BlueprintParametrizedFeature.m_SpellList"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintParametrizedFeature.m_SpellcasterClass"/>
    /// </summary>
    ///
    /// <param name="spellcasterClass">
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
    public TBuilder SetSpellcasterClass(Blueprint<BlueprintCharacterClassReference> spellcasterClass)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SpellcasterClass = spellcasterClass?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintParametrizedFeature.m_SpellcasterClass"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySpellcasterClass(Action<BlueprintCharacterClassReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SpellcasterClass is null) { return; }
          action.Invoke(bp.m_SpellcasterClass);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintParametrizedFeature.SpecificSpellLevel"/>
    /// </summary>
    public TBuilder SetSpecificSpellLevel(bool specificSpellLevel = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SpecificSpellLevel = specificSpellLevel;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintParametrizedFeature.SpecificSpellLevel"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySpecificSpellLevel(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.SpecificSpellLevel);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintParametrizedFeature.SpellLevelPenalty"/>
    /// </summary>
    public TBuilder SetSpellLevelPenalty(int spellLevelPenalty)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SpellLevelPenalty = spellLevelPenalty;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintParametrizedFeature.SpellLevelPenalty"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySpellLevelPenalty(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.SpellLevelPenalty);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintParametrizedFeature.SpellLevel"/>
    /// </summary>
    public TBuilder SetSpellLevel(int spellLevel)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SpellLevel = spellLevel;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintParametrizedFeature.SpellLevel"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySpellLevel(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.SpellLevel);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintParametrizedFeature.DisallowSpellsInSpellList"/>
    /// </summary>
    public TBuilder SetDisallowSpellsInSpellList(bool disallowSpellsInSpellList = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DisallowSpellsInSpellList = disallowSpellsInSpellList;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintParametrizedFeature.DisallowSpellsInSpellList"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDisallowSpellsInSpellList(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.DisallowSpellsInSpellList);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintParametrizedFeature.m_Prerequisite"/>
    /// </summary>
    ///
    /// <param name="prerequisite">
    /// <para>
    /// Blueprint of type BlueprintParametrizedFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetPrerequisite(Blueprint<BlueprintParametrizedFeatureReference> prerequisite)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Prerequisite = prerequisite?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintParametrizedFeature.m_Prerequisite"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPrerequisite(Action<BlueprintParametrizedFeatureReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Prerequisite is null) { return; }
          action.Invoke(bp.m_Prerequisite);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintParametrizedFeature.CustomParameterVariants"/>
    /// </summary>
    ///
    /// <param name="customParameterVariants">
    /// <para>
    /// Blueprint of type BlueprintScriptableObject. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetCustomParameterVariants(params Blueprint<AnyBlueprintReference>[] customParameterVariants)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CustomParameterVariants = customParameterVariants.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintParametrizedFeature.CustomParameterVariants"/>
    /// </summary>
    ///
    /// <param name="customParameterVariants">
    /// <para>
    /// Blueprint of type BlueprintScriptableObject. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToCustomParameterVariants(params Blueprint<AnyBlueprintReference>[] customParameterVariants)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CustomParameterVariants = bp.CustomParameterVariants ?? new AnyBlueprintReference[0];
          bp.CustomParameterVariants = CommonTool.Append(bp.CustomParameterVariants, customParameterVariants.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintParametrizedFeature.CustomParameterVariants"/>
    /// </summary>
    ///
    /// <param name="customParameterVariants">
    /// <para>
    /// Blueprint of type BlueprintScriptableObject. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromCustomParameterVariants(params Blueprint<AnyBlueprintReference>[] customParameterVariants)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CustomParameterVariants is null) { return; }
          bp.CustomParameterVariants = bp.CustomParameterVariants.Where(val => !customParameterVariants.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintParametrizedFeature.CustomParameterVariants"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCustomParameterVariants(Func<AnyBlueprintReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CustomParameterVariants is null) { return; }
          bp.CustomParameterVariants = bp.CustomParameterVariants.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintParametrizedFeature.CustomParameterVariants"/>
    /// </summary>
    public TBuilder ClearCustomParameterVariants()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CustomParameterVariants = new AnyBlueprintReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintParametrizedFeature.CustomParameterVariants"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCustomParameterVariants(Action<AnyBlueprintReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CustomParameterVariants is null) { return; }
          bp.CustomParameterVariants.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintParametrizedFeature.HasNoSuchFeature"/>
    /// </summary>
    public TBuilder SetHasNoSuchFeature(bool hasNoSuchFeature = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HasNoSuchFeature = hasNoSuchFeature;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintParametrizedFeature.HasNoSuchFeature"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHasNoSuchFeature(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.HasNoSuchFeature);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintParametrizedFeature.IgnoreParameterFeaturePrerequisites"/>
    /// </summary>
    public TBuilder SetIgnoreParameterFeaturePrerequisites(bool ignoreParameterFeaturePrerequisites = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IgnoreParameterFeaturePrerequisites = ignoreParameterFeaturePrerequisites;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintParametrizedFeature.IgnoreParameterFeaturePrerequisites"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIgnoreParameterFeaturePrerequisites(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.IgnoreParameterFeaturePrerequisites);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintParametrizedFeature.BlueprintParameterVariants"/>
    /// </summary>
    ///
    /// <param name="blueprintParameterVariants">
    /// <para>
    /// Blueprint of type BlueprintScriptableObject. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetBlueprintParameterVariants(params Blueprint<AnyBlueprintReference>[] blueprintParameterVariants)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.BlueprintParameterVariants = blueprintParameterVariants.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintParametrizedFeature.BlueprintParameterVariants"/>
    /// </summary>
    ///
    /// <param name="blueprintParameterVariants">
    /// <para>
    /// Blueprint of type BlueprintScriptableObject. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToBlueprintParameterVariants(params Blueprint<AnyBlueprintReference>[] blueprintParameterVariants)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.BlueprintParameterVariants = bp.BlueprintParameterVariants ?? new AnyBlueprintReference[0];
          bp.BlueprintParameterVariants = CommonTool.Append(bp.BlueprintParameterVariants, blueprintParameterVariants.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintParametrizedFeature.BlueprintParameterVariants"/>
    /// </summary>
    ///
    /// <param name="blueprintParameterVariants">
    /// <para>
    /// Blueprint of type BlueprintScriptableObject. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromBlueprintParameterVariants(params Blueprint<AnyBlueprintReference>[] blueprintParameterVariants)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.BlueprintParameterVariants is null) { return; }
          bp.BlueprintParameterVariants = bp.BlueprintParameterVariants.Where(val => !blueprintParameterVariants.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintParametrizedFeature.BlueprintParameterVariants"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromBlueprintParameterVariants(Func<AnyBlueprintReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.BlueprintParameterVariants is null) { return; }
          bp.BlueprintParameterVariants = bp.BlueprintParameterVariants.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintParametrizedFeature.BlueprintParameterVariants"/>
    /// </summary>
    public TBuilder ClearBlueprintParameterVariants()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.BlueprintParameterVariants = new AnyBlueprintReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintParametrizedFeature.BlueprintParameterVariants"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyBlueprintParameterVariants(Action<AnyBlueprintReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.BlueprintParameterVariants is null) { return; }
          bp.BlueprintParameterVariants.ForEach(action);
        });
    }

    /// <summary>
    /// Adds <see cref="AbilityFocusParametrized"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AbilityFocus</term><description>b689c0b78297dda40a6ae2ff3b8adb5c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="spellsOnly">
    /// <para>
    /// InfoBox: Turn on to increase DC only for spells from spellbook
    /// </para>
    /// </param>
    public TBuilder AddAbilityFocusParametrized(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? spellsOnly = null)
    {
      var component = new AbilityFocusParametrized();
      component.SpellsOnly = spellsOnly ?? component.SpellsOnly;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureParametrized"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>TricksterLoreReligionTier2Parametrized</term><description>3e006bc9bbf0b884a8d8853350bee846</description></item>
    /// <item><term>TricksterLoreReligionTier3Parametrized</term><description>0466cdfa56f943608760952a6bf2a6fa</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddFeatureParametrized(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new AddFeatureParametrized();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureToPetParametrized"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>LichSkeletalCombatParametrized</term><description>b8a52bbe63e7d6b48b002ee474e90fdd</description></item>
    /// <item><term>LichSkeletalRageParametrized</term><description>aaba9ebd2074e454aaed211698a34db0</description></item>
    /// <item><term>LichSkeletalTeamworkParametrized</term><description>b042ff9901e7b104eac92c05aa39957a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddFeatureToPetParametrized(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        PetType? petType = null)
    {
      var component = new AddFeatureToPetParametrized();
      component.PetType = petType ?? component.PetType;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ExpandedArsenalMagicSchools"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ExpandedArsenalSchool</term><description>f137089c48364014aa3ec3b92ccaf2e2</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddExpandedArsenalMagicSchools(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new ExpandedArsenalMagicSchools();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="FullWeaponMasterySkeletonParametrized"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>LichSkeletalWeaponParametrized</term><description>90f171fadf81f164d9828ce05441e617</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="focus">
    /// <para>
    /// Blueprint of type BlueprintParametrizedFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="greaterFeature">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="greaterFocus">
    /// <para>
    /// Blueprint of type BlueprintParametrizedFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="greaterSpecialization">
    /// <para>
    /// Blueprint of type BlueprintParametrizedFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="improvedCritical">
    /// <para>
    /// Blueprint of type BlueprintParametrizedFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="specialization">
    /// <para>
    /// Blueprint of type BlueprintParametrizedFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="weaponMastery">
    /// <para>
    /// Blueprint of type BlueprintParametrizedFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddFullWeaponMasterySkeletonParametrized(
        Blueprint<BlueprintParametrizedFeatureReference>? focus = null,
        Blueprint<BlueprintFeatureReference>? greaterFeature = null,
        Blueprint<BlueprintParametrizedFeatureReference>? greaterFocus = null,
        Blueprint<BlueprintParametrizedFeatureReference>? greaterSpecialization = null,
        Blueprint<BlueprintParametrizedFeatureReference>? improvedCritical = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Blueprint<BlueprintParametrizedFeatureReference>? specialization = null,
        Blueprint<BlueprintParametrizedFeatureReference>? weaponMastery = null)
    {
      var component = new FullWeaponMasterySkeletonParametrized();
      component.m_Focus = focus?.Reference ?? component.m_Focus;
      if (component.m_Focus is null)
      {
        component.m_Focus = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(null);
      }
      component.m_GreaterFeature = greaterFeature?.Reference ?? component.m_GreaterFeature;
      if (component.m_GreaterFeature is null)
      {
        component.m_GreaterFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      component.m_GreaterFocus = greaterFocus?.Reference ?? component.m_GreaterFocus;
      if (component.m_GreaterFocus is null)
      {
        component.m_GreaterFocus = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(null);
      }
      component.m_GreaterSpecialization = greaterSpecialization?.Reference ?? component.m_GreaterSpecialization;
      if (component.m_GreaterSpecialization is null)
      {
        component.m_GreaterSpecialization = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(null);
      }
      component.m_ImprovedCritical = improvedCritical?.Reference ?? component.m_ImprovedCritical;
      if (component.m_ImprovedCritical is null)
      {
        component.m_ImprovedCritical = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(null);
      }
      component.m_Specialization = specialization?.Reference ?? component.m_Specialization;
      if (component.m_Specialization is null)
      {
        component.m_Specialization = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(null);
      }
      component.m_WeaponMastery = weaponMastery?.Reference ?? component.m_WeaponMastery;
      if (component.m_WeaponMastery is null)
      {
        component.m_WeaponMastery = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ImprovedCriticalEdgeParametrized"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>TricksterImprovedImprovedCritical</term><description>56f94badbba018b4b8277ce6e2e79e72</description></item>
    /// <item><term>TricksterImprovedImprovedImprovedCritical</term><description>006a966007802a0478c9e21007207aac</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddImprovedCriticalEdgeParametrized(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new ImprovedCriticalEdgeParametrized();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ImprovedCriticalMythicParametrized"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ImprovedCriticalMythicFeat</term><description>8bc0190a4ec04bd489eec290aeaa6d07</description></item>
    /// <item><term>TricksterImprovedImprovedImprovedCriticalImproved</term><description>319c882ab3cc51544ad2f3f43633d5b1</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddImprovedCriticalMythicParametrized(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new ImprovedCriticalMythicParametrized();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="ImprovedCriticalParametrized"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ImprovedCritical</term><description>f4201c85a991369408740c6888362e20</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddImprovedCriticalParametrized(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new ImprovedCriticalParametrized();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="KensaiChosenWeapon"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SwordSaintChosenWeaponFeature</term><description>c0b4ec0175e3ff940a45fc21f318a39a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="focus">
    /// <para>
    /// Blueprint of type BlueprintParametrizedFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddKensaiChosenWeapon(
        Blueprint<BlueprintParametrizedFeatureReference>? focus = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new KensaiChosenWeapon();
      component.m_Focus = focus?.Reference ?? component.m_Focus;
      if (component.m_Focus is null)
      {
        component.m_Focus = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="LearnSpellParametrized"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BloodlineArcaneNewArcanaFeature</term><description>4a2e8388c2f0dd3478811d9c947bebfb</description></item>
    /// <item><term>LoremasterDruidSecretWizard</term><description>7d43568733326b547928e1ba1e0c8f14</description></item>
    /// <item><term>MysticTheurgeOracleLevelParametrized9</term><description>4a2fa8146d6263649bd91a0a2006ebad</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="spellcasterClass">
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
    public TBuilder AddLearnSpellParametrized(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? specificSpellLevel = null,
        Blueprint<BlueprintCharacterClassReference>? spellcasterClass = null,
        int? spellLevel = null,
        int? spellLevelPenalty = null,
        Blueprint<BlueprintSpellListReference>? spellList = null)
    {
      var component = new LearnSpellParametrized();
      component.SpecificSpellLevel = specificSpellLevel ?? component.SpecificSpellLevel;
      component.m_SpellcasterClass = spellcasterClass?.Reference ?? component.m_SpellcasterClass;
      if (component.m_SpellcasterClass is null)
      {
        component.m_SpellcasterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(null);
      }
      component.SpellLevel = spellLevel ?? component.SpellLevel;
      component.SpellLevelPenalty = spellLevelPenalty ?? component.SpellLevelPenalty;
      component.m_SpellList = spellList?.Reference ?? component.m_SpellList;
      if (component.m_SpellList is null)
      {
        component.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="SavesFixerParamSpellSchool"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BloodlineArcaneSchoolPowerFeature</term><description>8891303b67eb273428f1691864b08cf8</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddSavesFixerParamSpellSchool(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new SavesFixerParamSpellSchool();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="SchoolMasteryParametrized"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SchoolMasteryMythicFeat</term><description>ac830015569352b458efcdfae00a948c</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddSchoolMasteryParametrized(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new SchoolMasteryParametrized();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="SpellFocusParametrized"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BloodlineArcaneSchoolPowerFeature</term><description>8891303b67eb273428f1691864b08cf8</description></item>
    /// <item><term>SpellFocus</term><description>16fa59cc9a72a6043b566b49184f53fe</description></item>
    /// <item><term>SpellFocusGreater</term><description>5b04b45b228461c43bad768eb0f7c7bf</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="mythicFocus">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="spellsOnly">
    /// <para>
    /// InfoBox: Turn on to increase DC only for spells from spellbook
    /// </para>
    /// </param>
    public TBuilder AddSpellFocusParametrized(
        int? bonusDC = null,
        ModifierDescriptor? descriptor = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Blueprint<BlueprintUnitFactReference>? mythicFocus = null,
        bool? spellsOnly = null)
    {
      var component = new SpellFocusParametrized();
      component.BonusDC = bonusDC ?? component.BonusDC;
      component.Descriptor = descriptor ?? component.Descriptor;
      component.m_MythicFocus = mythicFocus?.Reference ?? component.m_MythicFocus;
      if (component.m_MythicFocus is null)
      {
        component.m_MythicFocus = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      component.SpellsOnly = spellsOnly ?? component.SpellsOnly;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="SpellSpecializationParametrized"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SpellSpecialization1</term><description>e69a85f633ae8ca4398abeb6fa11b1fe</description></item>
    /// <item><term>SpellSpecialization19</term><description>09a6ff29f55dad544b9949702f2ed2c8</description></item>
    /// <item><term>SpellSpecializationFirst</term><description>f327a765a4353d04f872482ef3e48c35</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddSpellSpecializationParametrized(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new SpellSpecializationParametrized();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="WeaponFocusParametrized"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>WeaponFocus</term><description>1e1f627d26ad36f43bbd26cc2bf8ac7e</description></item>
    /// <item><term>WeaponFocusGreater</term><description>09c9e82965fb4334b984a1e9df3bd088</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="mythicFocus">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddWeaponFocusParametrized(
        ModifierDescriptor? descriptor = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Blueprint<BlueprintUnitFactReference>? mythicFocus = null)
    {
      var component = new WeaponFocusParametrized();
      component.Descriptor = descriptor ?? component.Descriptor;
      component.m_MythicFocus = mythicFocus?.Reference ?? component.m_MythicFocus;
      if (component.m_MythicFocus is null)
      {
        component.m_MythicFocus = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="WeaponMasteryParametrized"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>WeaponMasteryParametrized</term><description>38ae5ac04463a8947b7c06a6c72dd6bb</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddWeaponMasteryParametrized(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new WeaponMasteryParametrized();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="WeaponSpecializationParametrized"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>WeaponSpecialization</term><description>31470b17e8446ae4ea0dacd6c5817d86</description></item>
    /// <item><term>WeaponSpecializationGreater</term><description>7cf5edc65e785a24f9cf93af987d66b3</description></item>
    /// <item><term>WeaponSpecializationMythicFeat</term><description>d84ac5b1931bc504a98bfefaa419e34f</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddWeaponSpecializationParametrized(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? mythic = null)
    {
      var component = new WeaponSpecializationParametrized();
      component.Mythic = mythic ?? component.Mythic;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    protected override void SetDefaults()
    {
      base.SetDefaults();
    
      if (Blueprint.m_SpellList is null)
      {
        Blueprint.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(null);
      }
      if (Blueprint.m_SpellcasterClass is null)
      {
        Blueprint.m_SpellcasterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(null);
      }
      if (Blueprint.m_Prerequisite is null)
      {
        Blueprint.m_Prerequisite = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(null);
      }
      if (Blueprint.CustomParameterVariants is null)
      {
        Blueprint.CustomParameterVariants = new AnyBlueprintReference[0];
      }
      if (Blueprint.BlueprintParameterVariants is null)
      {
        Blueprint.BlueprintParameterVariants = new AnyBlueprintReference[0];
      }
    }
  }
}
