using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Blueprints.Loot;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using System;
using System.Collections.Generic;

namespace BlueprintCoreGen.Actions.Builder.BasicEx
{
  /// <summary>
  /// Extension to <see cref="ActionsBuilder"/> for most game mechanics related actions not included in
  /// <see cref="ContextEx.ActionsBuilderContextEx">ContextEx</see>.
  /// </summary>
  /// <inheritdoc cref="ActionsBuilder"/>
  public static class ActionsBuilderBasicEx
  {
    //----- Kingmaker.Designers.EventConditionActionSystem.Actions -----//

    /// <summary>
    /// Adds <see cref="AdvanceUnitLevel"/>
    /// </summary>
    [Implements(typeof(AdvanceUnitLevel))]
    public static ActionsBuilder AdvanceLevel(
        this ActionsBuilder builder, UnitEvaluator unit, IntEvaluator targetLevel)
    {
      builder.Validate(unit);
      builder.Validate(targetLevel);

      var advanceLevel = ElementTool.Create<AdvanceUnitLevel>();
      advanceLevel.Unit = unit;
      advanceLevel.Level = targetLevel;
      return builder.Add(advanceLevel);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.DestroyUnit">DestroyUnit</see>
    /// </summary>
    [Implements(typeof(DestroyUnit))]
    public static ActionsBuilder DestroyUnit(
        this ActionsBuilder builder, UnitEvaluator unit, bool fadeOut = false)
    {
      builder.Validate(unit);

      var destroy = ElementTool.Create<DestroyUnit>();
      destroy.Target = unit;
      destroy.FadeOut = fadeOut;
      return builder.Add(destroy);
    }

    /// <summary>
    /// Adds <see cref="CombineToGroup"/>
    /// </summary>
    [Implements(typeof(CombineToGroup))]
    public static ActionsBuilder AddUnitToGroup(
        this ActionsBuilder builder, UnitEvaluator unit, UnitEvaluator group)
    {
      builder.Validate(unit);
      builder.Validate(group);

      var addToGroup = ElementTool.Create<CombineToGroup>();
      addToGroup.TargetUnit = unit;
      addToGroup.GroupHolder = group;
      return builder.Add(addToGroup);
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.ClearUnitReturnPosition">ClearUnitReturnPosition</see>
    /// </summary>
    [Implements(typeof(ClearUnitReturnPosition))]
    public static ActionsBuilder ClearUnitReturnPosition(
        this ActionsBuilder builder, UnitEvaluator unit)
    {
      builder.Validate(unit);

      var clearReturnPosition = ElementTool.Create<ClearUnitReturnPosition>();
      clearReturnPosition.Unit = unit;
      return builder.Add(clearReturnPosition);
    }

    /// <inheritdoc cref="ClearUnitReturnPosition"/>
    [Implements(typeof(ClearUnitReturnPosition))]
    public static ActionsBuilder ClearAllUnitReturnPosition(this ActionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ClearUnitReturnPosition>());
    }

    /// <summary>
    /// Adds <see cref="Kingmaker.Designers.EventConditionActionSystem.Actions.AddUnitToSummonPool">AddUnitToSummonPool</see>
    /// </summary>
    /// 
    /// <param name="pool"><see cref="BlueprintSummonPool"/></param>
    [Implements(typeof(AddUnitToSummonPool))]
    public static ActionsBuilder AddUnitToSummonPool(
        this ActionsBuilder builder, UnitEvaluator unit, string pool)
    {
      builder.Validate(unit);

      var addSummon = ElementTool.Create<AddUnitToSummonPool>();
      addSummon.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(pool);
      addSummon.Unit = unit;
      return builder.Add(addSummon);
    }

    /// <summary>
    /// Adds <see cref="DeleteUnitFromSummonPool"/>
    /// </summary>
    /// 
    /// <param name="pool"><see cref="BlueprintSummonPool"/></param>
    [Implements(typeof(DeleteUnitFromSummonPool))]
    public static ActionsBuilder RemoveUnitFromSummonPool(
        this ActionsBuilder builder, UnitEvaluator unit, string pool)
    {
      builder.Validate(unit);

      var addSummon = ElementTool.Create<DeleteUnitFromSummonPool>();
      addSummon.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(pool);
      addSummon.Unit = unit;
      return builder.Add(addSummon);
    }

    //----- Auto Generated -----//
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.DetachBuff)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.DisableExperienceFromUnit)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.DrainEnergy)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.FakePartyRest)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.GainExp)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.GainMythicLevel)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.HealParty)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.HealUnit)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.ItemSetCharges)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.Kill)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.LevelUpUnit)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.MeleeAttack)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.PartyUnits)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.PartyUseAbility)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.RaiseDead)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.RandomAction)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.RemoveDeathDoor)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.RemoveFact)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.RollPartySkillCheck)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.RollSkillCheck)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.RunActionHolder)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.Spawn)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.SpawnBySummonPool)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.SpawnByUnitGroup)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.StatusEffect)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.Summon)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.SummonPoolUnits)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.SummonUnitCopy)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.SwitchActivatableAbility)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.SwitchDualCompanion)]
    // [Generate(Kingmaker.Designers.EventConditionActionSystem.Actions.UnitsFromSpawnersInUnitGroup)]
  }
}