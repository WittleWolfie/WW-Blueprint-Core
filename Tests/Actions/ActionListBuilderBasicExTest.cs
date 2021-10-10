using System;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Tests.Asserts;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Xunit;

namespace BlueprintCore.Tests.Actions
{
  public class ActionListBuilderBasicExTest : ActionListBuilderTestBase
  {
    [Fact]
    public void AttachBuff()
    {
      IntConstant.Value = 5;

      var actions =
          ActionListBuilder.New()
              .AttachBuff(BuffGuid, ClickedUnit, IntConstant)
              .Build();

      Assert.Single(actions.Actions);
      var attachBuff = (AttachBuff)actions.Actions[0];
      ElementAsserts.IsValid(attachBuff);

      Assert.Equal(Buff.ToReference<BlueprintBuffReference>(), attachBuff.m_Buff);
      Assert.Equal(ClickedUnit, attachBuff.Target);
      Assert.Equal(5, attachBuff.Duration.GetValue());
    }

    [Fact]
    public void OnCreaturesAround()
    {
      var actions =
          ActionListBuilder.New()
              .OnCreaturesAround(ActionListBuilder.New().MeleeAttack(), Distance, NearestPosition)
              .Build();

      Assert.Single(actions.Actions);
      var onCreatures = (CreaturesAround)actions.Actions[0];
      ElementAsserts.IsValid(onCreatures);

      Assert.Single(onCreatures.Actions.Actions);
      Assert.IsType<ContextActionMeleeAttack>(onCreatures.Actions.Actions[0]);

      Assert.Equal(Distance, onCreatures.Radius);
      Assert.Equal(NearestPosition, onCreatures.Center);
      Assert.False(onCreatures.CheckLos);
      Assert.False(onCreatures.IncludeDead);
    }

    [Fact]
    public void OnCreaturesAround_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .OnCreaturesAround(
                  ActionListBuilder.New().MeleeAttack(),
                  Distance,
                  NearestPosition,
                  checkLos: true,
                  targetDead: true)
              .Build();

      Assert.Single(actions.Actions);
      var onCreatures = (CreaturesAround)actions.Actions[0];
      ElementAsserts.IsValid(onCreatures);

      Assert.Single(onCreatures.Actions.Actions);
      Assert.IsType<ContextActionMeleeAttack>(onCreatures.Actions.Actions[0]);

      Assert.Equal(Distance, onCreatures.Radius);
      Assert.Equal(NearestPosition, onCreatures.Center);
      Assert.True(onCreatures.CheckLos);
      Assert.True(onCreatures.IncludeDead);
    }

    [Fact]
    public void AddFact()
    {
      var actions = ActionListBuilder.New().AddFact(BuffGuid, ClickedUnit).Build();

      Assert.Single(actions.Actions);
      var addFact = (AddFact)actions.Actions[0];
      ElementAsserts.IsValid(addFact);

      Assert.Equal(Buff.ToReference<BlueprintUnitFactReference>(), addFact.m_Fact);
      Assert.Equal(ClickedUnit, addFact.Unit);
    }

    [Fact]
    public void AddFatigue()
    {
      var hours = ElementTool.Create<IntConstant>();

      var actions = ActionListBuilder.New().AddFatigue(hours, ClickedUnit).Build();

      Assert.Single(actions.Actions);
      var fatigue = (AddFatigueHours)actions.Actions[0];
      ElementAsserts.IsValid(fatigue);

      Assert.Equal(hours, fatigue.Hours);
      Assert.Equal(ClickedUnit, fatigue.Unit);
    }

    [Fact]
    public void DamageParty()
    {
      var actions = ActionListBuilder.New().DamageParty(Damage).Build();

      Assert.Single(actions.Actions);
      var dmg = (DamageParty)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(Damage, dmg.Damage);
      Assert.True(dmg.NoSource);
      Assert.False(dmg.DamageSource);
    }

    [Fact]
    public void DamageParty_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .DamageParty(Damage, source: ClickedUnit, enableBattleLog: false)
              .Build();

      Assert.Single(actions.Actions);
      var dmg = (DamageParty)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(Damage, dmg.Damage);
      Assert.False(dmg.NoSource);
      Assert.True(dmg.DamageSource);
      Assert.Equal(ClickedUnit, dmg.DamageSource);
    }

    [Fact]
    public void DealDamage()
    {
      var actions = ActionListBuilder.New().DealDamage(ClickedUnit, Damage).Build();

      Assert.Single(actions.Actions);
      var dmg = (DealDamage)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(Damage, dmg.Damage);
      Assert.Equal(ClickedUnit, dmg.Target);
      Assert.True(dmg.NoSource);

      Assert.False(dmg.DisableBattleLog);
      Assert.False(dmg.DisableFxAndSound);
    }

    [Fact]
    public void DealDamage_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .DealDamage(
                  ClickedUnit,
                  Damage,
                  source: ClickedUnit,
                  enableBattleLog: false,
                  enableFxAndSound: false)
              .Build();

      Assert.Single(actions.Actions);
      var dmg = (DealDamage)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(Damage, dmg.Damage);
      Assert.Equal(ClickedUnit, dmg.Target);
      Assert.False(dmg.NoSource);
      Assert.Equal(ClickedUnit, dmg.Source);

      Assert.True(dmg.DisableBattleLog);
      Assert.True(dmg.DisableFxAndSound);
    }

    [Fact]
    public void DealStatDamage()
    {
      var actions =
          ActionListBuilder.New()
              .DealStatDamage(ClickedUnit, StatType.Strength, new DiceFormula(1, DiceType.D4))
              .Build();

      Assert.Single(actions.Actions);
      var dmg = (DealStatDamage)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(ClickedUnit, dmg.Target);
      Assert.Equal(StatType.Strength, dmg.Stat);
      Assert.Equal(1, dmg.DamageDice.Rolls);
      Assert.Equal(DiceType.D4, dmg.DamageDice.Dice);
      Assert.Equal(0, dmg.DamageBonus);

      Assert.False(dmg.IsDrain);
      Assert.False(dmg.DisableBattleLog);
      Assert.True(dmg.NoSource);
    }

    [Fact]
    public void DealStatDamage_WithInvalidStat()
    {
      Assert.Throws<InvalidOperationException>(
          () =>
            ActionListBuilder.New()
                .DealStatDamage(ClickedUnit, StatType.AC, new DiceFormula(1, DiceType.D4))
                .Build());
    }

    [Fact]
    public void DealStatDamage_WithOptionalValues()
    {
      var actions =
          ActionListBuilder.New()
              .DealStatDamage(
                  ClickedUnit,
                  StatType.Wisdom,
                  new DiceFormula(2, DiceType.D6),
                  damageBonus: 2,
                  source: ClickedUnit,
                  drain: true,
                  enableBattleLog: false)
              .Build();

      Assert.Single(actions.Actions);
      var dmg = (DealStatDamage)actions.Actions[0];
      ElementAsserts.IsValid(dmg);

      Assert.Equal(ClickedUnit, dmg.Target);
      Assert.Equal(StatType.Wisdom, dmg.Stat);
      Assert.Equal(2, dmg.DamageDice.Rolls);
      Assert.Equal(DiceType.D6, dmg.DamageDice.Dice);
      Assert.Equal(2, dmg.DamageBonus);

      Assert.True(dmg.IsDrain);
      Assert.True(dmg.DisableBattleLog);
      Assert.False(dmg.NoSource);
      Assert.Equal(ClickedUnit, dmg.Source);
    }
  }
}
