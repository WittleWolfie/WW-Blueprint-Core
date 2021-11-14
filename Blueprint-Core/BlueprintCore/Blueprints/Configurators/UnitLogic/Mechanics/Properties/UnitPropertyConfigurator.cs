using BlueprintCore.Utils;
using Kingmaker.Assets.UnitLogic.Mechanics.Properties;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Class.Kineticist.Properties;
using Kingmaker.UnitLogic.Mechanics.Properties;
using Kingmaker.Utility;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.UnitLogic.Mechanics.Properties
{
  /// <summary>Configurator for <see cref="BlueprintUnitProperty"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintUnitProperty))]
  public class UnitPropertyConfigurator : BaseBlueprintConfigurator<BlueprintUnitProperty, UnitPropertyConfigurator>
  {
     private UnitPropertyConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static UnitPropertyConfigurator For(string name)
    {
      return new UnitPropertyConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static UnitPropertyConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintUnitProperty>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static UnitPropertyConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintUnitProperty>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Adds <see cref="CountCorpsesAroundPropertyGetter"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_OnlyOfType"><see cref="BlueprintUnitType"/></param>
    [Generated]
    [Implements(typeof(CountCorpsesAroundPropertyGetter))]
    public UnitPropertyConfigurator AddCountCorpsesAroundPropertyGetter(
        string m_OnlyOfType,
        Feet m_Radius,
        PropertySettings Settings)
    {
      ValidateParam(m_Radius);
      ValidateParam(Settings);
      
      var component =  new CountCorpsesAroundPropertyGetter();
      component.m_OnlyOfType = BlueprintTool.GetRef<BlueprintUnitTypeReference>(m_OnlyOfType);
      component.m_Radius = m_Radius;
      component.Settings = Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BaseAttackPropertyWithFeatureList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Features"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(BaseAttackPropertyWithFeatureList))]
    public UnitPropertyConfigurator AddBaseAttackPropertyWithFeatureList(
        int BaseValue,
        int BaseAttackDiv,
        int BaseAttackZero,
        string[] m_Features,
        int FeatureBonus,
        PropertySettings Settings)
    {
      ValidateParam(Settings);
      
      var component =  new BaseAttackPropertyWithFeatureList();
      component.BaseValue = BaseValue;
      component.BaseAttackDiv = BaseAttackDiv;
      component.BaseAttackZero = BaseAttackZero;
      component.m_Features = m_Features.Select(bp => BlueprintTool.GetRef<BlueprintFeatureReference>(bp)).ToArray();
      component.FeatureBonus = FeatureBonus;
      component.Settings = Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CurrentMeleeWeaponDamageStatGetter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CurrentMeleeWeaponDamageStatGetter))]
    public UnitPropertyConfigurator AddCurrentMeleeWeaponDamageStatGetter(
        PropertySettings Settings)
    {
      ValidateParam(Settings);
      
      var component =  new CurrentMeleeWeaponDamageStatGetter();
      component.Settings = Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CurrentWeaponCriticalMultiplierGetter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CurrentWeaponCriticalMultiplierGetter))]
    public UnitPropertyConfigurator AddCurrentWeaponCriticalMultiplierGetter(
        PropertySettings Settings)
    {
      ValidateParam(Settings);
      
      var component =  new CurrentWeaponCriticalMultiplierGetter();
      component.Settings = Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FightingDefensivelyACBonusProperty"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Features"><see cref="BlueprintUnitFact"/></param>
    /// <param name="m_DuelingFeatures"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(FightingDefensivelyACBonusProperty))]
    public UnitPropertyConfigurator AddFightingDefensivelyACBonusProperty(
        string[] m_Features,
        string[] m_DuelingFeatures,
        PropertySettings Settings)
    {
      ValidateParam(Settings);
      
      var component =  new FightingDefensivelyACBonusProperty();
      component.m_Features = m_Features.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      component.m_DuelingFeatures = m_DuelingFeatures.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      component.Settings = Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FightingDefensivelyAttackPenaltyProperty"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Features"><see cref="BlueprintUnitFact"/></param>
    /// <param name="m_DuelingFeatures"><see cref="BlueprintUnitFact"/></param>
    /// <param name="m_HalfBuff"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(FightingDefensivelyAttackPenaltyProperty))]
    public UnitPropertyConfigurator AddFightingDefensivelyAttackPenaltyProperty(
        string[] m_Features,
        string[] m_DuelingFeatures,
        string m_HalfBuff,
        PropertySettings Settings)
    {
      ValidateParam(Settings);
      
      var component =  new FightingDefensivelyAttackPenaltyProperty();
      component.m_Features = m_Features.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      component.m_DuelingFeatures = m_DuelingFeatures.Select(bp => BlueprintTool.GetRef<BlueprintUnitFactReference>(bp)).ToArray();
      component.m_HalfBuff = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_HalfBuff);
      component.Settings = Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KineticistBurnPropertyGetter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KineticistBurnPropertyGetter))]
    public UnitPropertyConfigurator AddKineticistBurnPropertyGetter(
        bool MultiplyOnClassLevel,
        bool MultyplyOnCharacterLevel,
        PropertySettings Settings)
    {
      ValidateParam(Settings);
      
      var component =  new KineticistBurnPropertyGetter();
      component.MultiplyOnClassLevel = MultiplyOnClassLevel;
      component.MultyplyOnCharacterLevel = MultyplyOnCharacterLevel;
      component.Settings = Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KineticistMainStatBonusPropertyGetter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(KineticistMainStatBonusPropertyGetter))]
    public UnitPropertyConfigurator AddKineticistMainStatBonusPropertyGetter(
        PropertySettings Settings)
    {
      ValidateParam(Settings);
      
      var component =  new KineticistMainStatBonusPropertyGetter();
      component.Settings = Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="LevelBasedPropertyWithFeatureList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Features"><see cref="BlueprintFeature"/></param>
    [Generated]
    [Implements(typeof(LevelBasedPropertyWithFeatureList))]
    public UnitPropertyConfigurator AddLevelBasedPropertyWithFeatureList(
        int BaseValue,
        int LevelDiv,
        int LevelZero,
        string[] m_Features,
        int FeatureBonus,
        PropertySettings Settings)
    {
      ValidateParam(Settings);
      
      var component =  new LevelBasedPropertyWithFeatureList();
      component.BaseValue = BaseValue;
      component.LevelDiv = LevelDiv;
      component.LevelZero = LevelZero;
      component.m_Features = m_Features.Select(bp => BlueprintTool.GetRef<BlueprintFeatureReference>(bp)).ToArray();
      component.FeatureBonus = FeatureBonus;
      component.Settings = Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="StatBonusIfHasFactProperty"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_RequiredFact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(StatBonusIfHasFactProperty))]
    public UnitPropertyConfigurator AddStatBonusIfHasFactProperty(
        int Multiplier,
        StatType Stat,
        string m_RequiredFact,
        PropertySettings Settings)
    {
      ValidateParam(Stat);
      ValidateParam(Settings);
      
      var component =  new StatBonusIfHasFactProperty();
      component.Multiplier = Multiplier;
      component.Stat = Stat;
      component.m_RequiredFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_RequiredFact);
      component.Settings = Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AnimalPetOwnerRankGetter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AnimalPetOwnerRankGetter))]
    public UnitPropertyConfigurator AddAnimalPetOwnerRankGetter(
        UnitProperty Property,
        PropertySettings Settings)
    {
      ValidateParam(Property);
      ValidateParam(Settings);
      
      var component =  new AnimalPetOwnerRankGetter();
      component.Property = Property;
      component.Settings = Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AreaCrComplexGetter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AreaCrComplexGetter))]
    public UnitPropertyConfigurator AddAreaCrComplexGetter(
        int Bonus,
        int Multiplier,
        int Denominator,
        PropertySettings Settings)
    {
      ValidateParam(Settings);
      
      var component =  new AreaCrComplexGetter();
      component.Bonus = Bonus;
      component.Multiplier = Multiplier;
      component.Denominator = Denominator;
      component.Settings = Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ClassLevelGetter"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Class"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(ClassLevelGetter))]
    public UnitPropertyConfigurator AddClassLevelGetter(
        string m_Class,
        PropertySettings Settings)
    {
      ValidateParam(Settings);
      
      var component =  new ClassLevelGetter();
      component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_Class);
      component.Settings = Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CustomPropertyGetter"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Property"><see cref="BlueprintUnitProperty"/></param>
    [Generated]
    [Implements(typeof(CustomPropertyGetter))]
    public UnitPropertyConfigurator AddCustomPropertyGetter(
        string m_Property,
        PropertySettings Settings)
    {
      ValidateParam(Settings);
      
      var component =  new CustomPropertyGetter();
      component.m_Property = BlueprintTool.GetRef<BlueprintUnitPropertyReference>(m_Property);
      component.Settings = Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="FactRankGetter"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Fact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(FactRankGetter))]
    public UnitPropertyConfigurator AddFactRankGetter(
        string m_Fact,
        PropertySettings Settings)
    {
      ValidateParam(Settings);
      
      var component =  new FactRankGetter();
      component.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_Fact);
      component.Settings = Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ShieldBonusGetter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ShieldBonusGetter))]
    public UnitPropertyConfigurator AddShieldBonusGetter(
        PropertySettings Settings)
    {
      ValidateParam(Settings);
      
      var component =  new ShieldBonusGetter();
      component.Settings = Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SimplePropertyGetter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SimplePropertyGetter))]
    public UnitPropertyConfigurator AddSimplePropertyGetter(
        UnitProperty Property,
        PropertySettings Settings)
    {
      ValidateParam(Property);
      ValidateParam(Settings);
      
      var component =  new SimplePropertyGetter();
      component.Property = Property;
      component.Settings = Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SkillRankGetter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SkillRankGetter))]
    public UnitPropertyConfigurator AddSkillRankGetter(
        StatType Skill,
        PropertySettings Settings)
    {
      ValidateParam(Skill);
      ValidateParam(Settings);
      
      var component =  new SkillRankGetter();
      component.Skill = Skill;
      component.Settings = Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SkillValueGetter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SkillValueGetter))]
    public UnitPropertyConfigurator AddSkillValueGetter(
        StatType Skill,
        PropertySettings Settings)
    {
      ValidateParam(Skill);
      ValidateParam(Settings);
      
      var component =  new SkillValueGetter();
      component.Skill = Skill;
      component.Settings = Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SummClassLevelGetter"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Class"><see cref="BlueprintCharacterClass"/></param>
    /// <param name="Archetype"><see cref="BlueprintArchetype"/></param>
    /// <param name="m_Archetypes"><see cref="BlueprintArchetype"/></param>
    [Generated]
    [Implements(typeof(SummClassLevelGetter))]
    public UnitPropertyConfigurator AddSummClassLevelGetter(
        string[] m_Class,
        string Archetype,
        string[] m_Archetypes,
        PropertySettings Settings)
    {
      ValidateParam(Settings);
      
      var component =  new SummClassLevelGetter();
      component.m_Class = m_Class.Select(bp => BlueprintTool.GetRef<BlueprintCharacterClassReference>(bp)).ToArray();
      component.Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(Archetype);
      component.m_Archetypes = m_Archetypes.Select(bp => BlueprintTool.GetRef<BlueprintArchetypeReference>(bp)).ToArray();
      component.Settings = Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="UnitWeaponEnhancementGetter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitWeaponEnhancementGetter))]
    public UnitPropertyConfigurator AddUnitWeaponEnhancementGetter(
        PropertySettings Settings)
    {
      ValidateParam(Settings);
      
      var component =  new UnitWeaponEnhancementGetter();
      component.Settings = Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CastingAttributeGetter"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Class"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(CastingAttributeGetter))]
    public UnitPropertyConfigurator AddCastingAttributeGetter(
        string m_Class,
        bool AttributeBonus,
        PropertySettings Settings)
    {
      ValidateParam(Settings);
      
      var component =  new CastingAttributeGetter();
      component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_Class);
      component.AttributeBonus = AttributeBonus;
      component.Settings = Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ComplexPropertyGetter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ComplexPropertyGetter))]
    public UnitPropertyConfigurator AddComplexPropertyGetter(
        int Bonus,
        int Multiplier,
        int Denominator,
        UnitProperty Property,
        PropertySettings Settings)
    {
      ValidateParam(Property);
      ValidateParam(Settings);
      
      var component =  new ComplexPropertyGetter();
      component.Bonus = Bonus;
      component.Multiplier = Multiplier;
      component.Denominator = Denominator;
      component.Property = Property;
      component.Settings = Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CustomProgressionPropertyGetter"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CustomProgressionPropertyGetter))]
    public UnitPropertyConfigurator AddCustomProgressionPropertyGetter(
        int Start,
        int Step,
        UnitProperty Property,
        PropertySettings Settings)
    {
      ValidateParam(Property);
      ValidateParam(Settings);
      
      var component =  new CustomProgressionPropertyGetter();
      component.Start = Start;
      component.Step = Step;
      component.Property = Property;
      component.Settings = Settings;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MaxCastingAttributeGetter"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Classes"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(MaxCastingAttributeGetter))]
    public UnitPropertyConfigurator AddMaxCastingAttributeGetter(
        string[] m_Classes,
        bool AttributeBonus,
        StatType DefaultStat,
        PropertySettings Settings)
    {
      ValidateParam(DefaultStat);
      ValidateParam(Settings);
      
      var component =  new MaxCastingAttributeGetter();
      component.m_Classes = m_Classes.Select(bp => BlueprintTool.GetRef<BlueprintCharacterClassReference>(bp)).ToArray();
      component.AttributeBonus = AttributeBonus;
      component.DefaultStat = DefaultStat;
      component.Settings = Settings;
      return AddComponent(component);
    }
  }
}
