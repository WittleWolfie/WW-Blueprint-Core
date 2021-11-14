using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.Dungeon.Blueprints.Boons;
using Kingmaker.Dungeon.Enums;
using System;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>Configurator for <see cref="BlueprintDungeonBoon"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintDungeonBoon))]
  public class DungeonBoonConfigurator : BaseBlueprintConfigurator<BlueprintDungeonBoon, DungeonBoonConfigurator>
  {
     private DungeonBoonConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static DungeonBoonConfigurator For(string name)
    {
      return new DungeonBoonConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static DungeonBoonConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintDungeonBoon>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static DungeonBoonConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintDungeonBoon>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Adds <see cref="BoonLogicExperience"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BoonLogicExperience))]
    public DungeonBoonConfigurator AddBoonLogicExperience(
        int Step,
        int Start)
    {
      
      var component =  new BoonLogicExperience();
      component.Step = Step;
      component.Start = Start;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BoonLogicExperienceRate"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BoonLogicExperienceRate))]
    public DungeonBoonConfigurator AddBoonLogicExperienceRate(
        int Step,
        int Start)
    {
      
      var component =  new BoonLogicExperienceRate();
      component.Step = Step;
      component.Start = Start;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BoonLogicGold"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BoonLogicGold))]
    public DungeonBoonConfigurator AddBoonLogicGold(
        int Step,
        int Start)
    {
      
      var component =  new BoonLogicGold();
      component.Step = Step;
      component.Start = Start;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BoonLogicItem"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BoonLogicItem))]
    public DungeonBoonConfigurator AddBoonLogicItem(
        bool IsRandomItemOfType,
        DungeonLootType[] Type,
        bool Pack,
        int Step,
        int Start)
    {
      foreach (var item in Type)
      {
        ValidateParam(item);
      }
      
      var component =  new BoonLogicItem();
      component.IsRandomItemOfType = IsRandomItemOfType;
      component.Type = Type;
      component.Pack = Pack;
      component.Step = Step;
      component.Start = Start;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BoonLogicPartyBuff"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="m_Buff"><see cref="BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(BoonLogicPartyBuff))]
    public DungeonBoonConfigurator AddBoonLogicPartyBuff(
        DungeonBoonLogic.ProgressionType m_Progression,
        bool m_MainCharacterOnly,
        string m_Buff,
        bool OnlyRandomCharacterClass,
        int Step,
        int Start)
    {
      ValidateParam(m_Progression);
      
      var component =  new BoonLogicPartyBuff();
      component.m_Progression = m_Progression;
      component.m_MainCharacterOnly = m_MainCharacterOnly;
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(m_Buff);
      component.OnlyRandomCharacterClass = OnlyRandomCharacterClass;
      component.Step = Step;
      component.Start = Start;
      return AddComponent(component);
    }
  }
}
