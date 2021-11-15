using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.RuleSystem;
using Kingmaker.Settings;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAiAction"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAiAction))]
  public abstract class BaseAiActionConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintAiAction
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseAiActionConfigurator(string name) : base(name) { }

    /// <summary>
    /// Sets <see cref="BlueprintAiAction.AdditionalBehaviour"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetAdditionalBehaviour(bool value)
    {
      return OnConfigureInternal(bp => bp.AdditionalBehaviour = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiAction.MinDifficulty"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetMinDifficulty(GameDifficultyOption value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.MinDifficulty = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiAction.InvertDifficultyRequirements"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetInvertDifficultyRequirements(bool value)
    {
      return OnConfigureInternal(bp => bp.InvertDifficultyRequirements = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiAction.OncePerRound"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetOncePerRound(bool value)
    {
      return OnConfigureInternal(bp => bp.OncePerRound = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiAction.CooldownRounds"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCooldownRounds(int value)
    {
      return OnConfigureInternal(bp => bp.CooldownRounds = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiAction.CooldownDice"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCooldownDice(DiceFormula value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.CooldownDice = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiAction.StartCooldownRounds"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetStartCooldownRounds(int value)
    {
      return OnConfigureInternal(bp => bp.StartCooldownRounds = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiAction.CombatCount"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetCombatCount(int value)
    {
      return OnConfigureInternal(bp => bp.CombatCount = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiAction.UseWhenAIDisabled"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetUseWhenAIDisabled(bool value)
    {
      return OnConfigureInternal(bp => bp.UseWhenAIDisabled = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiAction.UseOnLimitedAI"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetUseOnLimitedAI(bool value)
    {
      return OnConfigureInternal(bp => bp.UseOnLimitedAI = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiAction.BaseScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TBuilder SetBaseScore(float value)
    {
      return OnConfigureInternal(bp => bp.BaseScore = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiAction.m_ActorConsiderations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="Consideration"/></param>
    [Generated]
    public TBuilder AddToActorConsiderations(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_ActorConsiderations = CommonTool.Append(bp.m_ActorConsiderations, values.Select(name => BlueprintTool.GetRef<ConsiderationReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiAction.m_ActorConsiderations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="Consideration"/></param>
    [Generated]
    public TBuilder RemoveFromActorConsiderations(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<ConsiderationReference>(name));
            bp.m_ActorConsiderations =
                bp.m_ActorConsiderations
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiAction.m_TargetConsiderations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="Consideration"/></param>
    [Generated]
    public TBuilder AddToTargetConsiderations(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_TargetConsiderations = CommonTool.Append(bp.m_TargetConsiderations, values.Select(name => BlueprintTool.GetRef<ConsiderationReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiAction.m_TargetConsiderations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="Consideration"/></param>
    [Generated]
    public TBuilder RemoveFromTargetConsiderations(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<ConsiderationReference>(name));
            bp.m_TargetConsiderations =
                bp.m_TargetConsiderations
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }
  }
}
