using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Components;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Alignments;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Items.Equipment
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemEquipment"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintItemEquipment))]
  public abstract class BaseItemEquipmentConfigurator<T, TBuilder>
      : BaseItemConfigurator<T, TBuilder>
      where T : BlueprintItemEquipment
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseItemEquipmentConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipment.CR"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCR(int value)
    {
      return OnConfigureInternal(bp => bp.CR = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipment.m_Ability"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintAbility"/></param>
    [Generated]
    public TBuilder SetAbility(string value)
    {
      return OnConfigureInternal(bp => bp.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipment.m_ActivatableAbility"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintActivatableAbility"/></param>
    [Generated]
    public TBuilder SetActivatableAbility(string value)
    {
      return OnConfigureInternal(bp => bp.m_ActivatableAbility = BlueprintTool.GetRef<BlueprintActivatableAbilityReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipment.SpendCharges"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetSpendCharges(bool value)
    {
      return OnConfigureInternal(bp => bp.SpendCharges = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipment.Charges"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCharges(int value)
    {
      return OnConfigureInternal(bp => bp.Charges = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipment.RestoreChargesOnRest"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetRestoreChargesOnRest(bool value)
    {
      return OnConfigureInternal(bp => bp.RestoreChargesOnRest = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipment.CasterLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCasterLevel(int value)
    {
      return OnConfigureInternal(bp => bp.CasterLevel = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipment.SpellLevel"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetSpellLevel(int value)
    {
      return OnConfigureInternal(bp => bp.SpellLevel = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipment.DC"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetDC(int value)
    {
      return OnConfigureInternal(bp => bp.DC = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipment.IsNonRemovable"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetIsNonRemovable(bool value)
    {
      return OnConfigureInternal(bp => bp.IsNonRemovable = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipment.m_EquipmentEntity"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="KingmakerEquipmentEntity"/></param>
    [Generated]
    public TBuilder SetEquipmentEntity(string value)
    {
      return OnConfigureInternal(bp => bp.m_EquipmentEntity = BlueprintTool.GetRef<KingmakerEquipmentEntityReference>(value));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItemEquipment.m_EquipmentEntityAlternatives"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="KingmakerEquipmentEntity"/></param>
    [Generated]
    public TBuilder AddToEquipmentEntityAlternatives(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_EquipmentEntityAlternatives = CommonTool.Append(bp.m_EquipmentEntityAlternatives, values.Select(name => BlueprintTool.GetRef<KingmakerEquipmentEntityReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItemEquipment.m_EquipmentEntityAlternatives"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="KingmakerEquipmentEntity"/></param>
    [Generated]
    public TBuilder RemoveFromEquipmentEntityAlternatives(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<KingmakerEquipmentEntityReference>(name));
            bp.m_EquipmentEntityAlternatives =
                bp.m_EquipmentEntityAlternatives
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintItemEquipment.m_ForcedRampColorPresetIndex"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetForcedRampColorPresetIndex(int value)
    {
      return OnConfigureInternal(bp => bp.m_ForcedRampColorPresetIndex = value);
    }

    /// <summary>
    /// Adds <see cref="AddFactToEquipmentWielder"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Fact"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    [Implements(typeof(AddFactToEquipmentWielder))]
    public TBuilder AddAddFactToEquipmentWielder(
        string m_Fact)
    {
      
      var component =  new AddFactToEquipmentWielder();
      component.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(m_Fact);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EquipmentRestrictionAlignment"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EquipmentRestrictionAlignment))]
    public TBuilder AddEquipmentRestrictionAlignment(
        AlignmentMaskType Alignment)
    {
      ValidateParam(Alignment);
      
      var component =  new EquipmentRestrictionAlignment();
      component.Alignment = Alignment;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EquipmentRestrictionCannotEquip"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EquipmentRestrictionCannotEquip))]
    public TBuilder AddEquipmentRestrictionCannotEquip()
    {
      return AddComponent(new EquipmentRestrictionCannotEquip());
    }

    /// <summary>
    /// Adds <see cref="EquipmentRestrictionClass"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Class"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(EquipmentRestrictionClass))]
    public TBuilder AddEquipmentRestrictionClass(
        string m_Class,
        bool Not)
    {
      
      var component =  new EquipmentRestrictionClass();
      component.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(m_Class);
      component.Not = Not;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EquipmentRestrictionHasAnyClassFromList"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Classes"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    [Implements(typeof(EquipmentRestrictionHasAnyClassFromList))]
    public TBuilder AddEquipmentRestrictionHasAnyClassFromList(
        bool Not,
        string[] m_Classes)
    {
      
      var component =  new EquipmentRestrictionHasAnyClassFromList();
      component.Not = Not;
      component.m_Classes = m_Classes.Select(bp => BlueprintTool.GetRef<BlueprintCharacterClassReference>(bp)).ToArray();
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EquipmentRestrictionMainPlayer"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EquipmentRestrictionMainPlayer))]
    public TBuilder AddEquipmentRestrictionMainPlayer()
    {
      return AddComponent(new EquipmentRestrictionMainPlayer());
    }

    /// <summary>
    /// Adds <see cref="EquipmentRestrictionSpecialUnit"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Blueprint"><see cref="BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(EquipmentRestrictionSpecialUnit))]
    public TBuilder AddEquipmentRestrictionSpecialUnit(
        string m_Blueprint)
    {
      
      var component =  new EquipmentRestrictionSpecialUnit();
      component.m_Blueprint = BlueprintTool.GetRef<BlueprintUnitReference>(m_Blueprint);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EquipmentRestrictionStat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EquipmentRestrictionStat))]
    public TBuilder AddEquipmentRestrictionStat(
        StatType Stat,
        int MinValue)
    {
      ValidateParam(Stat);
      
      var component =  new EquipmentRestrictionStat();
      component.Stat = Stat;
      component.MinValue = MinValue;
      return AddComponent(component);
    }
  }
}
