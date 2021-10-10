using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Buffs.Blueprints;


namespace BlueprintCore.Actions.Builder.BasicEx
{
  /** Extension to ActionListBuilder which supports basic, context-less action types. */
  public static class ActionListBuilderBasicEx
  {
    /**
     * AttachBuff
     *
     * @param buff BlueprintBuff
     */
    public static ActionListBuilder AttachBuff(
        this ActionListBuilder builder, string buff, UnitEvaluator target, IntEvaluator duration)
    {
      builder.Validate(target);
      builder.Validate(duration);

      var attachBuff = ElementTool.Create<AttachBuff>();
      attachBuff.m_Buff = BlueprintTool.GetRef<BlueprintBuff, BlueprintBuffReference>(buff);
      attachBuff.Target = target;
      attachBuff.Duration = duration;
      return builder.Add(attachBuff);
    }

    /** CreaturesAround */
    public static ActionListBuilder OnCreaturesAround(
        this ActionListBuilder builder,
        ActionListBuilder actions,
        FloatEvaluator radius,
        PositionEvaluator center,
        bool checkLos = false,
        bool targetDead = false)
    {
      builder.Validate(radius);
      builder.Validate(center);

      var onCreatures = ElementTool.Create<CreaturesAround>();
      onCreatures.Actions = actions.Build();
      onCreatures.Radius = radius;
      onCreatures.Center = center;
      onCreatures.CheckLos = checkLos;
      onCreatures.IncludeDead = targetDead;
      return builder.Add(onCreatures);
    }

    /**
     * AddFact
     *
     * @param fact BlueprintUnitFact
     */
    public static ActionListBuilder AddFact(
        this ActionListBuilder builder, string fact, UnitEvaluator target)
    {
      builder.Validate(target);

      var addFact = ElementTool.Create<AddFact>();
      addFact.m_Fact = BlueprintTool.GetRef<BlueprintUnitFact, BlueprintUnitFactReference>(fact);
      addFact.Unit = target;
      return builder.Add(addFact);
    }

    /** AddFatigueHours */
    public static ActionListBuilder AddFatigue(
        this ActionListBuilder builder, IntEvaluator hours, UnitEvaluator target)
    {
      builder.Validate(hours);
      builder.Validate(target);

      var fatigue = ElementTool.Create<AddFatigueHours>();
      fatigue.Hours = hours;
      fatigue.Unit = target;
      return builder.Add(fatigue);
    }

    /** DamageParty */
    public static ActionListBuilder DamageParty(
        this ActionListBuilder builder,
        DamageDescription damage,
        UnitEvaluator source = null,
        bool enableBattleLog = true)
    {
      var dmg = ElementTool.Create<DamageParty>();
      dmg.Damage = damage;
      dmg.DisableBattleLog = !enableBattleLog;

      if (source == null)
      {
        dmg.NoSource = true;
      }
      else
      {
        builder.Validate(source);
        dmg.DamageSource = source;
      }
      return builder.Add(dmg);
    }

    /** DealDamage */
    public static ActionListBuilder DealDamage(
        this ActionListBuilder builder,
        UnitEvaluator target,
        DamageDescription damage,
        UnitEvaluator source = null,
        bool enableBattleLog = true,
        bool enableFxAndSound = true)
    {
      builder.Validate(target);

      var dmg = ElementTool.Create<DealDamage>();
      dmg.Target = target;
      dmg.Damage = damage;
      dmg.DisableBattleLog = !enableBattleLog;
      dmg.DisableFxAndSound = !enableFxAndSound;

      if (source == null)
      {
        dmg.NoSource = true;
      }
      else
      {
        builder.Validate(source);
        dmg.Source = source;
      }
      return builder.Add(dmg);
    }

    /** DealStatDamage */
    public static ActionListBuilder DealStatDamage(
        this ActionListBuilder builder,
        UnitEvaluator target,
        StatType type,
        DiceFormula damageDice,
        int damageBonus = 0,
        UnitEvaluator source = null,
        bool drain = false,
        bool enableBattleLog = true)
    {
      // if (!Constants.CoreStats.Contains(type))
      // {
      //   throw new InvalidOperationException($"Only str/dex/con/int/wis/cha can be damaged: {type}");
      // }
      builder.Validate(target);

      var dmg = ElementTool.Create<DealStatDamage>();
      dmg.Target = target;
      dmg.Stat = type;
      dmg.DamageDice = damageDice;
      dmg.DamageBonus = damageBonus;
      dmg.IsDrain = drain;
      dmg.DisableBattleLog = !enableBattleLog;

      if (source == null)
      {
        dmg.NoSource = true;
      }
      else
      {
        builder.Validate(source);
        dmg.Source = source;
      }
      return builder.Add(dmg);
    }
  }
}