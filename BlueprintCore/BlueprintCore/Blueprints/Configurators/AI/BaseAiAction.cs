//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using Kingmaker.RuleSystem;
using Kingmaker.Settings;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintAiAction"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAiActionConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintAiAction
    where TBuilder : BaseAiActionConfigurator<T, TBuilder>
  {
    protected BaseAiActionConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiAction.AdditionalBehaviour"/>
    /// </summary>
    ///
    /// <param name="additionalBehaviour">
    /// <para>
    /// Tooltip: Action's availability affected by difficulty settings
    /// </para>
    /// </param>
    public TBuilder SetAdditionalBehaviour(bool additionalBehaviour = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AdditionalBehaviour = additionalBehaviour;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiAction.AdditionalBehaviour"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="additionalBehaviour">
    /// <para>
    /// Tooltip: Action's availability affected by difficulty settings
    /// </para>
    /// </param>
    public TBuilder ModifyAdditionalBehaviour(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.AdditionalBehaviour);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiAction.MinDifficulty"/>
    /// </summary>
    public TBuilder SetMinDifficulty(GameDifficultyOption minDifficulty)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MinDifficulty = minDifficulty;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiAction.MinDifficulty"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMinDifficulty(Action<GameDifficultyOption> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.MinDifficulty);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiAction.InvertDifficultyRequirements"/>
    /// </summary>
    public TBuilder SetInvertDifficultyRequirements(bool invertDifficultyRequirements = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.InvertDifficultyRequirements = invertDifficultyRequirements;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiAction.InvertDifficultyRequirements"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyInvertDifficultyRequirements(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.InvertDifficultyRequirements);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiAction.OncePerRound"/>
    /// </summary>
    public TBuilder SetOncePerRound(bool oncePerRound = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OncePerRound = oncePerRound;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiAction.OncePerRound"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOncePerRound(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.OncePerRound);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiAction.CooldownRounds"/>
    /// </summary>
    public TBuilder SetCooldownRounds(int cooldownRounds)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CooldownRounds = cooldownRounds;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiAction.CooldownRounds"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCooldownRounds(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.CooldownRounds);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiAction.CooldownDice"/>
    /// </summary>
    public TBuilder SetCooldownDice(DiceFormula cooldownDice)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CooldownDice = cooldownDice;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiAction.CooldownDice"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCooldownDice(Action<DiceFormula> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.CooldownDice);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiAction.StartCooldownRounds"/>
    /// </summary>
    public TBuilder SetStartCooldownRounds(int startCooldownRounds)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.StartCooldownRounds = startCooldownRounds;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiAction.StartCooldownRounds"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyStartCooldownRounds(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.StartCooldownRounds);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiAction.CombatCount"/>
    /// </summary>
    public TBuilder SetCombatCount(int combatCount)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CombatCount = combatCount;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiAction.CombatCount"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCombatCount(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.CombatCount);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiAction.UseWhenAIDisabled"/>
    /// </summary>
    public TBuilder SetUseWhenAIDisabled(bool useWhenAIDisabled = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UseWhenAIDisabled = useWhenAIDisabled;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiAction.UseWhenAIDisabled"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyUseWhenAIDisabled(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.UseWhenAIDisabled);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiAction.UseOnLimitedAI"/>
    /// </summary>
    public TBuilder SetUseOnLimitedAI(bool useOnLimitedAI = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UseOnLimitedAI = useOnLimitedAI;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiAction.UseOnLimitedAI"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyUseOnLimitedAI(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.UseOnLimitedAI);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiAction.BaseScore"/>
    /// </summary>
    public TBuilder SetBaseScore(float baseScore)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.BaseScore = baseScore;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiAction.BaseScore"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBaseScore(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.BaseScore);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiAction.m_ActorConsiderations"/>
    /// </summary>
    ///
    /// <param name="actorConsiderations">
    /// <para>
    /// Tooltip: Considerations that only depend on deciding unit
    /// </para>
    /// <para>
    /// Blueprint of type Consideration. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetActorConsiderations(List<Blueprint<Consideration, ConsiderationReference>> actorConsiderations)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ActorConsiderations = actorConsiderations?.Select(bp => bp.Reference)?.ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintAiAction.m_ActorConsiderations"/>
    /// </summary>
    ///
    /// <param name="actorConsiderations">
    /// <para>
    /// Tooltip: Considerations that only depend on deciding unit
    /// </para>
    /// <para>
    /// Blueprint of type Consideration. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToActorConsiderations(params Blueprint<Consideration, ConsiderationReference>[] actorConsiderations)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ActorConsiderations = bp.m_ActorConsiderations ?? new ConsiderationReference[0];
          bp.m_ActorConsiderations = CommonTool.Append(bp.m_ActorConsiderations, actorConsiderations.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAiAction.m_ActorConsiderations"/>
    /// </summary>
    ///
    /// <param name="actorConsiderations">
    /// <para>
    /// Tooltip: Considerations that only depend on deciding unit
    /// </para>
    /// <para>
    /// Blueprint of type Consideration. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromActorConsiderations(params Blueprint<Consideration, ConsiderationReference>[] actorConsiderations)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ActorConsiderations is null) { return; }
          bp.m_ActorConsiderations = bp.m_ActorConsiderations.Where(val => !actorConsiderations.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAiAction.m_ActorConsiderations"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="actorConsiderations">
    /// <para>
    /// Tooltip: Considerations that only depend on deciding unit
    /// </para>
    /// <para>
    /// Blueprint of type Consideration. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromActorConsiderations(Func<ConsiderationReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ActorConsiderations is null) { return; }
          bp.m_ActorConsiderations = bp.m_ActorConsiderations.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintAiAction.m_ActorConsiderations"/>
    /// </summary>
    ///
    /// <param name="actorConsiderations">
    /// <para>
    /// Tooltip: Considerations that only depend on deciding unit
    /// </para>
    /// <para>
    /// Blueprint of type Consideration. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearActorConsiderations()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ActorConsiderations = new ConsiderationReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiAction.m_ActorConsiderations"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="actorConsiderations">
    /// <para>
    /// Tooltip: Considerations that only depend on deciding unit
    /// </para>
    /// <para>
    /// Blueprint of type Consideration. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyActorConsiderations(Action<ConsiderationReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ActorConsiderations is null) { return; }
          bp.m_ActorConsiderations.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiAction.m_TargetConsiderations"/>
    /// </summary>
    ///
    /// <param name="targetConsiderations">
    /// <para>
    /// Tooltip: Considerations that also depend on action target
    /// </para>
    /// <para>
    /// Blueprint of type Consideration. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetTargetConsiderations(List<Blueprint<Consideration, ConsiderationReference>> targetConsiderations)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TargetConsiderations = targetConsiderations?.Select(bp => bp.Reference)?.ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintAiAction.m_TargetConsiderations"/>
    /// </summary>
    ///
    /// <param name="targetConsiderations">
    /// <para>
    /// Tooltip: Considerations that also depend on action target
    /// </para>
    /// <para>
    /// Blueprint of type Consideration. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToTargetConsiderations(params Blueprint<Consideration, ConsiderationReference>[] targetConsiderations)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TargetConsiderations = bp.m_TargetConsiderations ?? new ConsiderationReference[0];
          bp.m_TargetConsiderations = CommonTool.Append(bp.m_TargetConsiderations, targetConsiderations.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAiAction.m_TargetConsiderations"/>
    /// </summary>
    ///
    /// <param name="targetConsiderations">
    /// <para>
    /// Tooltip: Considerations that also depend on action target
    /// </para>
    /// <para>
    /// Blueprint of type Consideration. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromTargetConsiderations(params Blueprint<Consideration, ConsiderationReference>[] targetConsiderations)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TargetConsiderations is null) { return; }
          bp.m_TargetConsiderations = bp.m_TargetConsiderations.Where(val => !targetConsiderations.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintAiAction.m_TargetConsiderations"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="targetConsiderations">
    /// <para>
    /// Tooltip: Considerations that also depend on action target
    /// </para>
    /// <para>
    /// Blueprint of type Consideration. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromTargetConsiderations(Func<ConsiderationReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TargetConsiderations is null) { return; }
          bp.m_TargetConsiderations = bp.m_TargetConsiderations.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintAiAction.m_TargetConsiderations"/>
    /// </summary>
    ///
    /// <param name="targetConsiderations">
    /// <para>
    /// Tooltip: Considerations that also depend on action target
    /// </para>
    /// <para>
    /// Blueprint of type Consideration. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearTargetConsiderations()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TargetConsiderations = new ConsiderationReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiAction.m_TargetConsiderations"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="targetConsiderations">
    /// <para>
    /// Tooltip: Considerations that also depend on action target
    /// </para>
    /// <para>
    /// Blueprint of type Consideration. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyTargetConsiderations(Action<ConsiderationReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TargetConsiderations is null) { return; }
          bp.m_TargetConsiderations.ForEach(action);
        });
    }
  }
}
