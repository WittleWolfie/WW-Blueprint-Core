using BlueprintCore.Utils;
using Kingmaker.Designers.EventConditionActionSystem.Conditions;
using Kingmaker.ElementsSystem;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;

#nullable enable
namespace BlueprintCore.Conditions.Builder
{
  /// <summary>
  /// Fluent builder for <see cref="ConditionsChecker"/>
  /// </summary>
  /// 
  /// <remarks>
  /// <para>
  /// Conditions are supported using extension methods. Include the extension namespaces as needed.
  /// </para>
  /// 
  /// <para>
  /// When <see cref="Build"/> is called the <see cref="ConditionsChecker"/> is constructed, validated, and
  /// returned. If any errors are detected by <see cref="Validator"/> they will be logged as a warning.
  /// </para>
  /// 
  /// <para>
  /// Do not call <see cref="Build"/> twice on the same builder.
  /// </para>
  /// 
  /// <para>
  /// If a method calls for a string to represent any type of blueprint, you can pass the blueprint's
  /// <see cref="Kingmaker.Blueprints.SimpleBlueprint.AssetGuid">AssetGuid</see> as a string or as a name you already
  /// provided using <see cref="Utils.BlueprintTool.AddGuidsByName">AddGuidsByName()</see>.
  /// </para>
  /// 
  /// <list type="table">
  /// <listheader>Extensions</listheader>
  /// <item>
  ///   <term><see cref="AreaEx.ConditionsBuilderAreaEx">AreaEx</see></term>
  ///   <description>
  ///     Conditions involving the game map, dungeons, or locations. See also
  ///     <see cref="KingdomEx.ConditionsBuilderKingdomEx">KingdomEx</see> for location related conditions
  ///     specifically tied to the Kingdom and Crusade system.
  ///   </description>
  /// </item>
  /// <item>
  ///   <term><see cref="BasicEx.ConditionsBuilderBasicEx">BasicEx</see></term>
  ///   <description>
  ///     Most game mechanics related conditions not included in
  ///     <see cref="ContextEx.ConditionsBuilderContextEx">ContextEx</see>.
  ///   </description>
  /// </item>
  /// <item>
  ///   <term><see cref="ContextEx.ConditionsBuilderContextEx">ContextEx</see></term>
  ///   <description>
  ///     Most <see cref="Kingmaker.UnitLogic.Mechanics.Conditions.ContextCondition">ContextCondition</see> types. Some
  ///     <see cref="Kingmaker.UnitLogic.Mechanics.Conditions.ContextCondition">ContextCondition</see> types are in more
  ///     specific extensions such as <see cref="KingdomEx.ConditionsBuilderKingdomEx">KingdomEx</see>.
  ///   </description>
  /// </item>
  /// <item>
  ///   <term><see cref="KingdomEx.ConditionsBuilderKingdomEx">KingdomEx</see></term>
  ///   <description>
  ///     Conditions involving the Kingdom and Crusade system.
  ///   </description>
  /// </item>
  /// <item>
  ///   <term><see cref="MiscEx.ConditionsBuilderMiscEx">MiscEx</see></term>
  ///   <description>
  ///     Conditions without a better extension container such as game difficulty.
  ///   </description>
  /// </item>
  /// <item>
  ///   <term><see cref="NewEx.ConditionsBuilderNewEx">NewEx</see></term>
  ///   <description>
  ///     Conditions defined in BlueprintCore and not available in the base game.
  ///   </description>
  /// </item>
  /// <item>
  ///   <term><see cref="StoryEx.ConditionsBuilderStoryEx">StoryEx</see></term>
  ///   <description>
  ///     Conditions related to the story such as companion stories, quests, name changes, and etudes.
  ///   </description>
  /// </item>
  /// </list>
  /// 
  /// <example>
  /// Make a melee attack if the target is in range:
  /// <code>
  /// // Provides the MeleeAttack extension for ActionsBuilder
  /// using BlueprintCore.Actions.Builder.ContextEx; 
  /// // Provides the TargetInMeleeRange extension for ConditionsBuilder
  /// using BlueprintCore.Conditions.Builder.NewEx;
  /// 
  /// var actionList =
  ///     ActionsBuilder.New()
  ///         .Conditional(
  ///             ConditionsBuilder.New().TargetInMeleeRange(),
  ///             ifTrue: ActionsBuilder.New().MeleeAttack())
  ///         .build();
  /// </code>
  /// </example>
  /// </remarks>
  public class ConditionsBuilder
  {
    private static readonly LogWrapper Logger = LogWrapper.GetInternal("ConditionsBuilder");

    private Operation OperationType = Operation.And;
    private readonly List<Condition> Conditions = new();
    private readonly List<object> ToValidate = new();

    private ConditionsBuilder() { }

    /// <returns>A new <see cref="ConditionsBuilder"/></returns>
    public static ConditionsBuilder New() { return new ConditionsBuilder(); }

    /// <returns>
    /// A <see cref="ConditionsChecker"/> containing all specified conditions. Any validation errors are logged as a
    /// warning. Do not call twice on the same builder.
    /// </returns>
    /// 
    /// <param name="parentValidator">
    /// If specified, indicates that errors should be reported to this validator. As a result errors will not be logged
    /// by this call but can be logged using the provided validator.
    /// </param>
    public ConditionsChecker Build(Validator? parentValidator = null)
    {
      if (parentValidator == null)
      {
        Validator validator = new("Conditions", "ConditionsBuilder");
        RunValidation(validator);

        if (validator.HasErrors())
        {
          Logger.Warn(validator.GetErrorString());
        }
      }
      else
      {
        RunValidation(parentValidator);
      }

      var checker = new ConditionsChecker
      {
        Operation = OperationType,
        Conditions = Conditions.ToArray()
      };
      return checker;
    }

    /// <summary>
    /// Adds all conditions from <paramref name="conditionsChecker"/>. This is a shallow copy so changes to those
    /// conditions affect the original list as well.
    /// </summary>
    /// <param name="typesToExclude">Types of conditions which will not be added</param>
    public ConditionsBuilder AddAll(ConditionsChecker conditionsChecker, params Type[] typesToExclude)
    {
      conditionsChecker.Conditions.ForEach(
        action =>
        {
          var type = action.GetType();
          if (!typesToExclude.Any(type))
            Add(action);
        });
      return this;
    }

    /// <summary>
    /// Adds all conditions from <paramref name="conditionsChecker"/>. This is a shallow copy so changes to those
    /// conditions affect the original list as well.
    /// </summary>
    /// <param name="matcher">Only conditions matching this function are added</param>
    public ConditionsBuilder AddAll(ConditionsChecker conditionsChecker, Func<Condition, bool> matcher)
    {
      conditionsChecker.Conditions.ForEach(
        condition =>
        {
          if (matcher.Invoke(condition))
            Add(condition);
        });
      return this;
    }

    /// <summary>
    /// Causes the checker to return true if at least one conditions check passes. By default all checks must pass.
    /// </summary>
    public ConditionsBuilder UseOr()
    {
      OperationType = Operation.Or;
      return this;
    }

    /// <summary>Adds the specified <see cref="Condition"/> to the checker, with validation.</summary>
    /// 
    /// <remarks>
    /// It is recommended to only call this from an extension class or when adding a condition type not supported by the
    /// builder.
    /// </remarks>
    public ConditionsBuilder Add(Condition condition)
    {
      Validate(condition);
      Conditions.Add(condition);
      return this;
    }

    /// <summary>Adds a <see cref="Condition"/> of the specified type to the checker.</summary>
    /// 
    /// <remarks>It is recommended to only call this when adding a condition type not supported by the builder.</remarks>
    /// 
    /// <param name="init">Optional initialization <see cref="Action"/> run on the condition.</param>
    public ConditionsBuilder Add<C>(Action<C>? init = null) where C : Condition, new()
    {
      var condition = ElementTool.Create<C>();
      init?.Invoke(condition);
      return Add(condition);
    }

    /// <summary>
    /// Adds <see cref="False"/>
    /// </summary>
    
    public ConditionsBuilder AddFalse()
    {
      return Add(ElementTool.Create<False>());
    }

    /// <summary>
    /// Adds <see cref="False"/>, negated
    /// </summary>
    
    public ConditionsBuilder AddTrue()
    {
      var element = ElementTool.Create<False>();
      element.Not = true;
      return Add(element);
    }

    /// <summary>
    /// Adds <see cref="GreaterThan"/>
    /// </summary>
    
    public ConditionsBuilder AddGreaterThan(IntEvaluator Value, IntEvaluator MinValue)
    {
      Validate(Value);
      Validate(MinValue);

      var element = ElementTool.Create<GreaterThan>();
      element.Value = Value;
      element.MinValue = MinValue;
      return Add(element);
    }

    /// <summary>
    /// Adds <see cref="GreaterThan"/>
    /// </summary>
    
    public ConditionsBuilder AddGreaterThan(FloatEvaluator Value, FloatEvaluator MinValue)
    {
      Validate(Value);
      Validate(MinValue);

      var element = ElementTool.Create<GreaterThan>();
      element.FloatValues = true;
      element.FloatValue = Value;
      element.FloatMinValue = MinValue;
      return Add(element);
    }

    /// <summary>
    /// Adds <see cref="GreaterThan"/>, negated
    /// </summary>
    
    public ConditionsBuilder AddLessThanOrEqualTo(IntEvaluator Value, IntEvaluator MinValue)
    {
      Validate(Value);
      Validate(MinValue);

      var element = ElementTool.Create<GreaterThan>();
      element.Value = Value;
      element.MinValue = MinValue;
      element.Not = true;
      return Add(element);
    }

    /// <summary>
    /// Adds <see cref="GreaterThan"/>, negated
    /// </summary>
    
    public ConditionsBuilder AddLessThanOrEqualTo(FloatEvaluator Value, FloatEvaluator MinValue)
    {
      Validate(Value);
      Validate(MinValue);

      var element = ElementTool.Create<GreaterThan>();
      element.FloatValues = true;
      element.FloatValue = Value;
      element.FloatMinValue = MinValue;
      element.Not = true;
      return Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsEqual"/>
    /// </summary>
    
    public ConditionsBuilder AddIsEqual(IntEvaluator FirstValue, IntEvaluator SecondValue)
    {
      Validate(FirstValue);
      Validate(SecondValue);

      var element = ElementTool.Create<IsEqual>();
      element.FirstValue = FirstValue;
      element.SecondValue = SecondValue;
      return Add(element);
    }

    /// <summary>
    /// Adds <see cref="IsEqual"/>, negated
    /// </summary>
    
    public ConditionsBuilder AddIsNotEqual(IntEvaluator FirstValue, IntEvaluator SecondValue)
    {
      Validate(FirstValue);
      Validate(SecondValue);

      var element = ElementTool.Create<IsEqual>();
      element.FirstValue = FirstValue;
      element.SecondValue = SecondValue;
      element.Not = true;
      return Add(element);
    }

    /// <summary>
    /// Adds <see cref="LessThan"/>
    /// </summary>
    
    public ConditionsBuilder AddLessThan(IntEvaluator Value, IntEvaluator MaxValue)
    {
      Validate(Value);
      Validate(MaxValue);

      var element = ElementTool.Create<LessThan>();
      element.Value = Value;
      element.MaxValue = MaxValue;
      return Add(element);
    }

    /// <summary>
    /// Adds <see cref="LessThan"/>
    /// </summary>
    
    public ConditionsBuilder AddLessThan(FloatEvaluator Value, FloatEvaluator MaxValue)
    {
      Validate(Value);
      Validate(MaxValue);

      var element = ElementTool.Create<LessThan>();
      element.FloatValues = true;
      element.FloatValue = Value;
      element.FloatMaxValue = MaxValue;
      return Add(element);
    }

    /// <summary>
    /// Adds <see cref="LessThan"/>, negated
    /// </summary>
    
    public ConditionsBuilder AddGreaterThanOrEqualTo(IntEvaluator Value, IntEvaluator MaxValue)
    {
      Validate(Value);
      Validate(MaxValue);

      var element = ElementTool.Create<LessThan>();
      element.Value = Value;
      element.MaxValue = MaxValue;
      element.Not = true;
      return Add(element);
    }

    /// <summary>
    /// Adds <see cref="LessThan"/>, negated
    /// </summary>
    
    public ConditionsBuilder AddGreaterThanOrEqualTo(FloatEvaluator Value, FloatEvaluator MaxValue)
    {
      Validate(Value);
      Validate(MaxValue);

      var element = ElementTool.Create<LessThan>();
      element.FloatValues = true;
      element.FloatValue = Value;
      element.FloatMaxValue = MaxValue;
      element.Not = true;
      return Add(element);
    }

    /// <summary>
    /// Adds <see cref="OrAndLogic"/>
    /// </summary>
    
    public ConditionsBuilder AddOrAndLogic(ConditionsBuilder conditions, bool negate = false)
    {
      var element = ElementTool.Create<OrAndLogic>();
      element.ConditionsChecker = conditions.Build();
      element.Not = negate;
      return Add(element);
    }

    /// <summary>
    /// Adds the object to be checked using <see cref="Validator.Check(object)">Validator.Check()</see>.
    /// </summary>
    /// 
    /// <remarks>
    /// Exposed for use by extension classes to bundle warnings into the builder. Other classes can use
    /// <see cref="Validator.Check(object)">Validator.Check()</see> directly.
    /// </remarks>
    internal void Validate(object? obj)
    {
      if (obj is not null)
      {
        ToValidate.Add(obj);
      }
    }

    internal void Validate<T>(IEnumerable<T>? objects)
    {
      if (objects is null) { return; }
      foreach (var obj in objects) { Validate(obj); }
    }

    private void RunValidation(Validator validator)
    {
      ToValidate.ForEach(obj => validator.Check(obj));
    }

    public static implicit operator ConditionsBuilder(ConditionsChecker conditionsChecker)
    {
      var builder = New().AddAll(conditionsChecker);
      builder.OperationType = conditionsChecker.Operation;
      return builder;
    }
  }
}
