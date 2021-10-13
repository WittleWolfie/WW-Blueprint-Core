using System.Collections.Generic;
using BlueprintCore.Blueprints;
using BlueprintCore.Conditions.New;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Conditions;

namespace BlueprintCore.Conditions.Builder
{
  /** 
   * Base class for building a ConditionsChecker.
   *
   * Conditions are split among the various ConditionsCheckerBuilder*Ex methods. Include the
   * extension namespaces with the actions you need.
   *
   * E.g. ConditionsCheckerBuilderContextEx contains extension methods for most ContextAction types.
   * If you are configuring an ability you probably want to include that namespace:
   * `using BlueprintCore.Conditions.Builder.ContextEx`
   */
  public class ConditionsCheckerBuilder
  {
    private static readonly LogWrapper Logger = LogWrapper.GetInternal("ConditionsCheckerBuilder");

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

    /** Exposed for extension classes. */
    internal void Validate(object obj)
    {
      ValidationWarnings.AddRange(Validator.Check(obj));
    }
  }
}