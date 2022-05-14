//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums;

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
    protected BaseParametrizedFeatureConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

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
    /// <param name="spellsOnly">
    /// <para>
    /// InfoBox: Turn on to increase DC only for spells from spellbook
    /// </para>
    /// </param>
    public TBuilder AddAbilityFocusParametrized(
        bool? spellsOnly = null)
    {
      var component = new AbilityFocusParametrized();
      component.SpellsOnly = spellsOnly ?? component.SpellsOnly;
      return AddComponent(component);
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
    public TBuilder AddFeatureParametrized()
    {
      return AddComponent(new AddFeatureParametrized());
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
    public TBuilder AddFeatureToPetParametrized(
        PetType? petType = null)
    {
      var component = new AddFeatureToPetParametrized();
      component.PetType = petType ?? component.PetType;
      return AddComponent(component);
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
    public TBuilder AddExpandedArsenalMagicSchools()
    {
      return AddComponent(new ExpandedArsenalMagicSchools());
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="greaterFeature">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="greaterFocus">
    /// <para>
    /// Blueprint of type BlueprintParametrizedFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="greaterSpecialization">
    /// <para>
    /// Blueprint of type BlueprintParametrizedFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="improvedCritical">
    /// <para>
    /// Blueprint of type BlueprintParametrizedFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="specialization">
    /// <para>
    /// Blueprint of type BlueprintParametrizedFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="weaponMastery">
    /// <para>
    /// Blueprint of type BlueprintParametrizedFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddFullWeaponMasterySkeletonParametrized(
        Blueprint<BlueprintParametrizedFeature, BlueprintParametrizedFeatureReference>? focus = null,
        Blueprint<BlueprintFeature, BlueprintFeatureReference>? greaterFeature = null,
        Blueprint<BlueprintParametrizedFeature, BlueprintParametrizedFeatureReference>? greaterFocus = null,
        Blueprint<BlueprintParametrizedFeature, BlueprintParametrizedFeatureReference>? greaterSpecialization = null,
        Blueprint<BlueprintParametrizedFeature, BlueprintParametrizedFeatureReference>? improvedCritical = null,
        Blueprint<BlueprintParametrizedFeature, BlueprintParametrizedFeatureReference>? specialization = null,
        Blueprint<BlueprintParametrizedFeature, BlueprintParametrizedFeatureReference>? weaponMastery = null)
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
      return AddComponent(component);
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
    public TBuilder AddImprovedCriticalEdgeParametrized()
    {
      return AddComponent(new ImprovedCriticalEdgeParametrized());
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
    public TBuilder AddImprovedCriticalMythicParametrized()
    {
      return AddComponent(new ImprovedCriticalMythicParametrized());
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
    public TBuilder AddImprovedCriticalParametrized()
    {
      return AddComponent(new ImprovedCriticalParametrized());
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddKensaiChosenWeapon(
        Blueprint<BlueprintParametrizedFeature, BlueprintParametrizedFeatureReference>? focus = null)
    {
      var component = new KensaiChosenWeapon();
      component.m_Focus = focus?.Reference ?? component.m_Focus;
      if (component.m_Focus is null)
      {
        component.m_Focus = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(null);
      }
      return AddComponent(component);
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
    /// <item><term>MysticTheurgeOracleLevelParametrized1</term><description>4794ccdbd52760647ae0d5c437da8649</description></item>
    /// <item><term>MysticTheurgeOracleLevelParametrized9</term><description>4a2fa8146d6263649bd91a0a2006ebad</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="spellcasterClass">
    /// <para>
    /// Blueprint of type BlueprintCharacterClass. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="spellList">
    /// <para>
    /// Blueprint of type BlueprintSpellList. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddLearnSpellParametrized(
        bool? specificSpellLevel = null,
        Blueprint<BlueprintCharacterClass, BlueprintCharacterClassReference>? spellcasterClass = null,
        int? spellLevel = null,
        int? spellLevelPenalty = null,
        Blueprint<BlueprintSpellList, BlueprintSpellListReference>? spellList = null)
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
      return AddComponent(component);
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
    public TBuilder AddSavesFixerParamSpellSchool()
    {
      return AddComponent(new SavesFixerParamSpellSchool());
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
    public TBuilder AddSchoolMasteryParametrized()
    {
      return AddComponent(new SchoolMasteryParametrized());
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
    /// <param name="mythicFocus">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
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
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>? mythicFocus = null,
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
      return AddComponent(component);
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
    public TBuilder AddSpellSpecializationParametrized()
    {
      return AddComponent(new SpellSpecializationParametrized());
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
    /// <param name="mythicFocus">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddWeaponFocusParametrized(
        ModifierDescriptor? descriptor = null,
        Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>? mythicFocus = null)
    {
      var component = new WeaponFocusParametrized();
      component.Descriptor = descriptor ?? component.Descriptor;
      component.m_MythicFocus = mythicFocus?.Reference ?? component.m_MythicFocus;
      if (component.m_MythicFocus is null)
      {
        component.m_MythicFocus = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      return AddComponent(component);
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
    public TBuilder AddWeaponMasteryParametrized()
    {
      return AddComponent(new WeaponMasteryParametrized());
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
    public TBuilder AddWeaponSpecializationParametrized(
        bool? mythic = null)
    {
      var component = new WeaponSpecializationParametrized();
      component.Mythic = mythic ?? component.Mythic;
      return AddComponent(component);
    }
  }
}
