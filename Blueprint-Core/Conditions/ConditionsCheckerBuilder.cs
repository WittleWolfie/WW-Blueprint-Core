using System.Collections.Generic;
using BlueprintCore.Blueprints;
using BlueprintCore.Conditions.New;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Conditions;

namespace BlueprintCore.Conditions
{
  public class ConditionsCheckerBuilder
  {
    private static readonly LogWrapper Logger = LogWrapper.Get("ConditionsCheckerBuilder");

    private Operation OperationType = Operation.And;
    private readonly List<Condition> Conditions = new();
    private readonly List<string> ValidationWarnings = new();

    private ConditionsCheckerBuilder() { }

    public static ConditionsCheckerBuilder New() { return new ConditionsCheckerBuilder(); }

    public ConditionsChecker Build()
    {
      foreach (var warning in ValidationWarnings)
      {
        Logger.Warn(warning);
      }

      var checker = new ConditionsChecker
      {
        Operation = OperationType,
        Conditions = Conditions.ToArray()
      };
      return checker;
    }

    public ConditionsCheckerBuilder UseOr()
    {
      OperationType = Operation.Or;
      return this;
    }

    public ConditionsCheckerBuilder Add(Condition condition)
    {
      Validate(condition);
      Conditions.Add(condition);
      return this;
    }

    /**
     * ContextConditionHasBuffFromCaster
     *
     * @param buff BlueprintBuff
     */
    public ConditionsCheckerBuilder HasBuffFromCaster(string buff)
    {
      var hasBuff = ElementTool.Create<ContextConditionHasBuffFromCaster>();
      hasBuff.m_Buff = BlueprintTool.GetRef<BlueprintBuff, BlueprintBuffReference>(buff);
      return Add(hasBuff);
    }

    /**
     * ContextConditionCasterHasFact
     *
     * @param fact BlueprintUnitFact
     */
    public ConditionsCheckerBuilder CasterHasFact(string fact)
    {
      var hasFact = ElementTool.Create<ContextConditionCasterHasFact>();
      hasFact.m_Fact =
          BlueprintTool.GetRef<BlueprintUnitFact, BlueprintUnitFactReference>(fact);
      return Add(hasFact);
    }

    /**
     * ContextConditionHasFact
     *
     * @param fact BlueprintUnitFact
     */
    public ConditionsCheckerBuilder HasFact(string fact)
    {
      var hasFact = ElementTool.Create<ContextConditionHasFact>();
      hasFact.m_Fact =
          BlueprintTool.GetRef<BlueprintUnitFact, BlueprintUnitFactReference>(fact);
      return Add(hasFact);
    }

    /** (New) IsDemoralizeAction */
    public ConditionsCheckerBuilder IsDemoralizeAction()
    {
      return Add(ElementTool.Create<IsDemoralizeAction>());
    }

    /** (New) TargetInMeleeRange */
    public ConditionsCheckerBuilder TargetInMeleeRange()
    {
      return Add(ElementTool.Create<TargetInMeleeRange>());
    }

    /** ContextConditionTargetIsYourself */
    public ConditionsCheckerBuilder TargetIsYourself()
    {
      return Add(ElementTool.Create<ContextConditionTargetIsYourself>());
    }

    private void Validate(object obj)
    {
      ValidationWarnings.AddRange(Validator.Check(obj));
    }
  }
}