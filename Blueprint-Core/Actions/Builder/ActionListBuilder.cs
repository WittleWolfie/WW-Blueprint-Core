using System;
using System.Collections.Generic;
using System.Text;
using BlueprintCore.Conditions;
using BlueprintCore.Utils;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;

namespace BlueprintCore.Actions.Builder
{
  /** 
   * Base class for building an ActionList.
   *
   * Actions are split among the various ActionListBuilder*Ex methods. Include the extension
   * namespaces with the actions you need.
   *
   * E.g. ActionListBuilderContextEx contains extension methods for all ContextAction types. If you
   * are configuring an ability you probably want to include that namespace:
   * `using BlueprintCore.Actions.Builder.ContextEx`
   */
  public class ActionListBuilder
  {
    private static readonly LogWrapper Logger = LogWrapper.Get("ActionListBuilder");

    private readonly List<GameAction> Actions = new();
    private readonly StringBuilder ValidationWarnings = new();

    private ActionListBuilder() { }

    public static ActionListBuilder New() { return new ActionListBuilder(); }

    public ActionList Build()
    {
      if (ValidationWarnings.Length > 0) { Logger.Warn(ValidationWarnings.ToString()); }
      return new ActionList { Actions = Actions.ToArray() };
    }

    public ActionListBuilder Add(GameAction action)
    {
      Validate(action);
      Actions.Add(action);
      return this;
    }

    /** Conditional */
    public ActionListBuilder Conditional(
        ConditionsCheckerBuilder conditions,
        ActionListBuilder ifTrue = null,
        ActionListBuilder ifFalse = null)
    {
      if (ifTrue == null && ifFalse == null)
      {
        throw new InvalidOperationException("A conditional must have some actions.");
      }
      var conditional = ElementTool.Create<Conditional>();
      conditional.ConditionsChecker = conditions.Build();

      conditional.IfTrue = ifTrue?.Build() ?? Constants.Empty.Actions;
      conditional.IfFalse = ifFalse?.Build() ?? Constants.Empty.Actions;
      return Add(conditional);
    }

    /** Exposed for extension classes. */
    internal void Validate(object obj)
    {
      Validator.Check(obj).ForEach(str => ValidationWarnings.AppendLine(str));
    }
  }
}