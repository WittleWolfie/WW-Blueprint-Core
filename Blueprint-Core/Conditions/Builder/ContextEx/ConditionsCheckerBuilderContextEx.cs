using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Conditions;

namespace BlueprintCore.Conditions.Builder.ContextEx
{
  /** Extension to ConditionsCheckerBuilder which supports ContexCondition types. */
  public static class ConditionsCheckerBuilderContextEx
  {
    /**
     * ContextConditionHasBuffFromCaster
     *
     * @param buff BlueprintBuff
     */
    public static ConditionsCheckerBuilder HasBuffFromCaster(
        this ConditionsCheckerBuilder builder, string buff)
    {
      var hasBuff = ElementTool.Create<ContextConditionHasBuffFromCaster>();
      hasBuff.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      return builder.Add(hasBuff);
    }

    /**
     * ContextConditionCasterHasFact
     *
     * @param fact BlueprintUnitFact
     */
    public static ConditionsCheckerBuilder CasterHasFact(
        this ConditionsCheckerBuilder builder, string fact)
    {
      var hasFact = ElementTool.Create<ContextConditionCasterHasFact>();
      hasFact.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(fact);
      return builder.Add(hasFact);
    }

    /**
     * ContextConditionHasFact
     *
     * @param fact BlueprintUnitFact
     */
    public static ConditionsCheckerBuilder HasFact(
        this ConditionsCheckerBuilder builder, string fact)
    {
      var hasFact = ElementTool.Create<ContextConditionHasFact>();
      hasFact.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(fact);
      return builder.Add(hasFact);
    }

    /** ContextConditionTargetIsYourself */
    public static ConditionsCheckerBuilder TargetIsYourself(this ConditionsCheckerBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextConditionTargetIsYourself>());
    }
  }
}