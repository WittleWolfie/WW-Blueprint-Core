using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Conditions;

namespace BlueprintCore.Conditions.Builder.ContextEx
{
  /// <summary>
  /// Extension to <see cref="ConditionsCheckerBuilder"/> for most <see cref="ContextCondition"/> types. Some
  /// <see cref="ContextCondition"/> types are in more specific extensions such as
  /// <see cref="KingdomEx.ConditionsCheckerBuilderKingdomEx">KingdomEx</see>.
  /// </summary>
  /// <inheritdoc cref="ConditionsCheckerBuilder"/>
  public static class ConditionsCheckerBuilderContextEx
  {
    /// <summary>
    /// Adds <see cref="ContextConditionHasBuffFromCaster"/>
    /// </summary>
    /// 
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff">BlueprintBuff</see></param>
    public static ConditionsCheckerBuilder HasBuffFromCaster(this ConditionsCheckerBuilder builder, string buff)
    {
      var hasBuff = ElementTool.Create<ContextConditionHasBuffFromCaster>();
      hasBuff.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      return builder.Add(hasBuff);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionCasterHasFact"/>
    /// </summary>
    /// 
    /// <param name="fact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact">BlueprintUnitFact</see></param>
    public static ConditionsCheckerBuilder CasterHasFact(this ConditionsCheckerBuilder builder, string fact)
    {
      var hasFact = ElementTool.Create<ContextConditionCasterHasFact>();
      hasFact.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(fact);
      return builder.Add(hasFact);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionHasFact"/>
    /// </summary>
    /// 
    /// <param name="fact"><see cref="Kingmaker.Blueprints.Facts.BlueprintUnitFact">BlueprintUnitFact</see></param>
    public static ConditionsCheckerBuilder HasFact(this ConditionsCheckerBuilder builder, string fact)
    {
      var hasFact = ElementTool.Create<ContextConditionHasFact>();
      hasFact.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(fact);
      return builder.Add(hasFact);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionTargetIsYourself"/>
    /// </summary>
    public static ConditionsCheckerBuilder TargetIsYourself(this ConditionsCheckerBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextConditionTargetIsYourself>());
    }
  }
}