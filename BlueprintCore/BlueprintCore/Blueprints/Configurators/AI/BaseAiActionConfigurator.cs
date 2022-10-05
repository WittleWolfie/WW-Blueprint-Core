//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.RuleSystem;
using Kingmaker.Settings;
using Kingmaker.Utility;
using System;
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
    protected BaseAiActionConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintAiAction>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.AdditionalBehaviour = copyFrom.AdditionalBehaviour;
          bp.MinDifficulty = copyFrom.MinDifficulty;
          bp.InvertDifficultyRequirements = copyFrom.InvertDifficultyRequirements;
          bp.OncePerRound = copyFrom.OncePerRound;
          bp.CooldownRounds = copyFrom.CooldownRounds;
          bp.CooldownDice = copyFrom.CooldownDice;
          bp.StartCooldownRounds = copyFrom.StartCooldownRounds;
          bp.CombatCount = copyFrom.CombatCount;
          bp.UseWhenAIDisabled = copyFrom.UseWhenAIDisabled;
          bp.UseOnLimitedAI = copyFrom.UseOnLimitedAI;
          bp.BaseScore = copyFrom.BaseScore;
          bp.m_ActorConsiderations = copyFrom.m_ActorConsiderations;
          bp.m_TargetConsiderations = copyFrom.m_TargetConsiderations;
          bp.Actions = copyFrom.Actions;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiAction.AdditionalBehaviour"/>
    /// </summary>
    ///
    /// <param name="additionalBehaviour">
    /// <para>
    /// Tooltip: Action&amp;apos;s availability affected by difficulty settings
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetActorConsiderations(params Blueprint<ConsiderationReference>[] actorConsiderations)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ActorConsiderations = actorConsiderations.Select(bp => bp.Reference).ToArray();
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToActorConsiderations(params Blueprint<ConsiderationReference>[] actorConsiderations)
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromActorConsiderations(params Blueprint<ConsiderationReference>[] actorConsiderations)
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
    public TBuilder RemoveFromActorConsiderations(Func<ConsiderationReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ActorConsiderations is null) { return; }
          bp.m_ActorConsiderations = bp.m_ActorConsiderations.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintAiAction.m_ActorConsiderations"/>
    /// </summary>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetTargetConsiderations(params Blueprint<ConsiderationReference>[] targetConsiderations)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TargetConsiderations = targetConsiderations.Select(bp => bp.Reference).ToArray();
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToTargetConsiderations(params Blueprint<ConsiderationReference>[] targetConsiderations)
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromTargetConsiderations(params Blueprint<ConsiderationReference>[] targetConsiderations)
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
    public TBuilder RemoveFromTargetConsiderations(Func<ConsiderationReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TargetConsiderations is null) { return; }
          bp.m_TargetConsiderations = bp.m_TargetConsiderations.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintAiAction.m_TargetConsiderations"/>
    /// </summary>
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
    public TBuilder ModifyTargetConsiderations(Action<ConsiderationReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TargetConsiderations is null) { return; }
          bp.m_TargetConsiderations.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintAiAction.Actions"/>
    /// </summary>
    ///
    /// <param name="actions">
    /// <para>
    /// Tooltip: Additional actions to run after the action is triggered
    /// </para>
    /// </param>
    public TBuilder SetActions(ActionsBuilder actions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Actions = actions?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintAiAction.Actions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyActions(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Actions is null) { return; }
          action.Invoke(bp.Actions);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_ActorConsiderations is null)
      {
        Blueprint.m_ActorConsiderations = new ConsiderationReference[0];
      }
      if (Blueprint.m_TargetConsiderations is null)
      {
        Blueprint.m_TargetConsiderations = new ConsiderationReference[0];
      }
      if (Blueprint.Actions is null)
      {
        Blueprint.Actions = Utils.Constants.Empty.Actions;
      }
    }
  }
}
