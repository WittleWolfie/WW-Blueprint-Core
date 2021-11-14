using BlueprintCore.Blueprints.Configurators.Items;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Components;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Alignments;
using System;
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
      ValidateParam(Not);
      
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
      ValidateParam(Not);
      
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
      ValidateParam(MinValue);
      
      var component =  new EquipmentRestrictionStat();
      component.Stat = Stat;
      component.MinValue = MinValue;
      return AddComponent(component);
    }  }
}
