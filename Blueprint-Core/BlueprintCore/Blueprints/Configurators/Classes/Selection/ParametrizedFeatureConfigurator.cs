using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;

namespace BlueprintCore.Blueprints.Configurators.Classes.Selection
{
  /// <summary>Configurator for <see cref="BlueprintParametrizedFeature"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintParametrizedFeature))]
  public class ParametrizedFeatureConfigurator : BaseFeatureConfigurator<BlueprintParametrizedFeature, ParametrizedFeatureConfigurator>
  {
     private ParametrizedFeatureConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ParametrizedFeatureConfigurator For(string name)
    {
      return new ParametrizedFeatureConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ParametrizedFeatureConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintParametrizedFeature>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ParametrizedFeatureConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintParametrizedFeature>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Adds <see cref="AddParametrizedClassSkill"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddParametrizedClassSkill))]
    public ParametrizedFeatureConfigurator AddAddParametrizedClassSkill()
    {
      return AddComponent(new AddParametrizedClassSkill());
    }

    /// <summary>
    /// Adds <see cref="AddParametrizedStatBonus"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddParametrizedStatBonus))]
    public ParametrizedFeatureConfigurator AddAddParametrizedStatBonus(
        ContextValue Value,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Value);
      ValidateParam(Descriptor);
      
      var component =  new AddParametrizedStatBonus();
      component.Value = Value;
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AbilityFocusParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AbilityFocusParametrized))]
    public ParametrizedFeatureConfigurator AddAbilityFocusParametrized(
        bool SpellsOnly)
    {
      
      var component =  new AbilityFocusParametrized();
      component.SpellsOnly = SpellsOnly;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddFeatureParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddFeatureParametrized))]
    public ParametrizedFeatureConfigurator AddAddFeatureParametrized()
    {
      return AddComponent(new AddFeatureParametrized());
    }

    /// <summary>
    /// Adds <see cref="AddFeatureToPetParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddFeatureToPetParametrized))]
    public ParametrizedFeatureConfigurator AddAddFeatureToPetParametrized(
        PetType PetType)
    {
      ValidateParam(PetType);
      
      var component =  new AddFeatureToPetParametrized();
      component.PetType = PetType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ExpandedArsenalMagicSchools"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ExpandedArsenalMagicSchools))]
    public ParametrizedFeatureConfigurator AddExpandedArsenalMagicSchools()
    {
      return AddComponent(new ExpandedArsenalMagicSchools());
    }

    /// <summary>
    /// Adds <see cref="FullWeaponMasterySkeletonParametrized"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Focus"><see cref="BlueprintParametrizedFeature"/></param>
    /// <param name="m_Specialization"><see cref="BlueprintParametrizedFeature"/></param>
    /// <param name="m_GreaterFocus"><see cref="BlueprintParametrizedFeature"/></param>
    /// <param name="m_GreaterSpecialization"><see cref="BlueprintParametrizedFeature"/></param>
    /// <param name="m_ImprovedCritical"><see cref="BlueprintParametrizedFeature"/></param>
    /// <param name="m_WeaponMastery"><see cref="BlueprintParametrizedFeature"/></param>
    /// <param name="m_GreaterFeature"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(FullWeaponMasterySkeletonParametrized))]
    public ParametrizedFeatureConfigurator AddFullWeaponMasterySkeletonParametrized(
        string m_Focus,
        string m_Specialization,
        string m_GreaterFocus,
        string m_GreaterSpecialization,
        string m_ImprovedCritical,
        string m_WeaponMastery,
        string m_GreaterFeature)
    {
      
      var component =  new FullWeaponMasterySkeletonParametrized();
      component.m_Focus = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(m_Focus);
      component.m_Specialization = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(m_Specialization);
      component.m_GreaterFocus = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(m_GreaterFocus);
      component.m_GreaterSpecialization = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(m_GreaterSpecialization);
      component.m_ImprovedCritical = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(m_ImprovedCritical);
      component.m_WeaponMastery = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(m_WeaponMastery);
      component.m_GreaterFeature = BlueprintTool.GetRef<BlueprintFeatureReference>(m_GreaterFeature);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ImprovedCriticalEdgeParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ImprovedCriticalEdgeParametrized))]
    public ParametrizedFeatureConfigurator AddImprovedCriticalEdgeParametrized()
    {
      return AddComponent(new ImprovedCriticalEdgeParametrized());
    }

    /// <summary>
    /// Adds <see cref="ImprovedCriticalMythicParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ImprovedCriticalMythicParametrized))]
    public ParametrizedFeatureConfigurator AddImprovedCriticalMythicParametrized()
    {
      return AddComponent(new ImprovedCriticalMythicParametrized());
    }

    /// <summary>
    /// Adds <see cref="ImprovedCriticalParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ImprovedCriticalParametrized))]
    public ParametrizedFeatureConfigurator AddImprovedCriticalParametrized()
    {
      return AddComponent(new ImprovedCriticalParametrized());
    }

    /// <summary>
    /// Adds <see cref="KensaiChosenWeapon"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Focus"><see cref="BlueprintParametrizedFeature"/></param>
    [Generated]
    [Implements(typeof(KensaiChosenWeapon))]
    public ParametrizedFeatureConfigurator AddKensaiChosenWeapon(
        string m_Focus)
    {
      
      var component =  new KensaiChosenWeapon();
      component.m_Focus = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(m_Focus);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LearnSpellParametrized"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_SpellcasterClass"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="m_SpellList"><see cref="BlueprintSpellList"/></param>
    [Generated]
    [Implements(typeof(LearnSpellParametrized))]
    public ParametrizedFeatureConfigurator AddLearnSpellParametrized(
        string m_SpellcasterClass,
        string m_SpellList,
        bool SpecificSpellLevel,
        int SpellLevelPenalty,
        int SpellLevel)
    {
      
      var component =  new LearnSpellParametrized();
      component.m_SpellcasterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_SpellcasterClass);
      component.m_SpellList = BlueprintTool.GetRef<BlueprintSpellListReference>(m_SpellList);
      component.SpecificSpellLevel = SpecificSpellLevel;
      component.SpellLevelPenalty = SpellLevelPenalty;
      component.SpellLevel = SpellLevel;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SavesFixerParamSpellSchool"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SavesFixerParamSpellSchool))]
    public ParametrizedFeatureConfigurator AddSavesFixerParamSpellSchool()
    {
      return AddComponent(new SavesFixerParamSpellSchool());
    }

    /// <summary>
    /// Adds <see cref="SchoolMasteryParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SchoolMasteryParametrized))]
    public ParametrizedFeatureConfigurator AddSchoolMasteryParametrized()
    {
      return AddComponent(new SchoolMasteryParametrized());
    }

    /// <summary>
    /// Adds <see cref="SpellFocusParametrized"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_MythicFocus"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(SpellFocusParametrized))]
    public ParametrizedFeatureConfigurator AddSpellFocusParametrized(
        int BonusDC,
        ModifierDescriptor Descriptor,
        string m_MythicFocus,
        bool SpellsOnly)
    {
      ValidateParam(Descriptor);
      
      var component =  new SpellFocusParametrized();
      component.BonusDC = BonusDC;
      component.Descriptor = Descriptor;
      component.m_MythicFocus = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_MythicFocus);
      component.SpellsOnly = SpellsOnly;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellSpecializationParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SpellSpecializationParametrized))]
    public ParametrizedFeatureConfigurator AddSpellSpecializationParametrized()
    {
      return AddComponent(new SpellSpecializationParametrized());
    }

    /// <summary>
    /// Adds <see cref="WeaponFocusParametrized"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_MythicFocus"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(WeaponFocusParametrized))]
    public ParametrizedFeatureConfigurator AddWeaponFocusParametrized(
        string m_MythicFocus,
        ModifierDescriptor Descriptor)
    {
      ValidateParam(Descriptor);
      
      var component =  new WeaponFocusParametrized();
      component.m_MythicFocus = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_MythicFocus);
      component.Descriptor = Descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="WeaponMasteryParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponMasteryParametrized))]
    public ParametrizedFeatureConfigurator AddWeaponMasteryParametrized()
    {
      return AddComponent(new WeaponMasteryParametrized());
    }

    /// <summary>
    /// Adds <see cref="WeaponSpecializationParametrized"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(WeaponSpecializationParametrized))]
    public ParametrizedFeatureConfigurator AddWeaponSpecializationParametrized(
        bool Mythic)
    {
      
      var component =  new WeaponSpecializationParametrized();
      component.Mythic = Mythic;
      return AddComponent(component);
    }
  }
}
