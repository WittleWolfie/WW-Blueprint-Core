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

    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintParametrizedFeature>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.ParameterType = copyFrom.ParameterType;
          bp.WeaponSubCategory = copyFrom.WeaponSubCategory;
          bp.SelectionFeatureGroup = copyFrom.SelectionFeatureGroup;
          bp.RequireProficiency = copyFrom.RequireProficiency;
          bp.m_SpellList = copyFrom.m_SpellList;
          bp.m_SpellcasterClass = copyFrom.m_SpellcasterClass;
          bp.SpecificSpellLevel = copyFrom.SpecificSpellLevel;
          bp.SpellLevelPenalty = copyFrom.SpellLevelPenalty;
          bp.SpellLevel = copyFrom.SpellLevel;
          bp.DisallowSpellsInSpellList = copyFrom.DisallowSpellsInSpellList;
          bp.m_Prerequisite = copyFrom.m_Prerequisite;
          bp.CustomParameterVariants = copyFrom.CustomParameterVariants;
          bp.HasNoSuchFeature = copyFrom.HasNoSuchFeature;
          bp.IgnoreParameterFeaturePrerequisites = copyFrom.IgnoreParameterFeaturePrerequisites;
          bp.BlueprintParameterVariants = copyFrom.BlueprintParameterVariants;
        });
    }

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
          bp.CustomParameterVariants = bp.CustomParameterVariants.Where(e => !predicate(e)).ToArray();
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
          bp.BlueprintParameterVariants = bp.BlueprintParameterVariants.Where(e => !predicate(e)).ToArray();
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
    /// <item><term>LichSkeletalTeamworkParametrized</term><description>b042ff9901e7b104eac92c05aa39957a</description></item>
    /// <item><term>LichSkeletalWeaponTrainingtParametrized</term><description>bc4cc2147809483fbb195841b8567127</description></item>
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
    /// Adds <see cref="LearnSpellParametrized"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>BloodlineArcaneNewArcanaFeature</term><description>4a2e8388c2f0dd3478811d9c947bebfb</description></item>
    /// <item><term>LoremasterWizardSecretBard</term><description>b8310eac977d2c7498184f2523490f31</description></item>
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

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
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
