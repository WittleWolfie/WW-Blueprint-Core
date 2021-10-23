using BlueprintCore.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Conditions;

namespace BlueprintCore.Conditions.Builder.ContextEx
{
  /// <summary>
  /// Extension to <see cref="ConditionsBuilder"/> for most <see cref="ContextCondition"/> types. Some
  /// <see cref="ContextCondition"/> types are in more specific extensions such as
  /// <see cref="KingdomEx.ConditionsBuilderKingdomEx">KingdomEx</see>.
  /// </summary>
  /// <inheritdoc cref="ConditionsBuilder"/>
  public static class ConditionsBuilderContextEx
  {
    /// <summary>
    /// Adds <see cref="ContextConditionHasBuffFromCaster"/>
    /// </summary>
    /// 
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff">BlueprintBuff</see></param>
    public static ConditionsBuilder HasBuffFromCaster(this ConditionsBuilder builder, string buff)
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
    public static ConditionsBuilder CasterHasFact(this ConditionsBuilder builder, string fact)
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
    public static ConditionsBuilder HasFact(this ConditionsBuilder builder, string fact)
    {
      var hasFact = ElementTool.Create<ContextConditionHasFact>();
      hasFact.m_Fact = BlueprintTool.GetRef<BlueprintUnitFactReference>(fact);
      return builder.Add(hasFact);
    }

    /// <summary>
    /// Adds <see cref="ContextConditionTargetIsYourself"/>
    /// </summary>
    public static ConditionsBuilder TargetIsYourself(this ConditionsBuilder builder)
    {
      return builder.Add(ElementTool.Create<ContextConditionTargetIsYourself>());
    }
  }
}