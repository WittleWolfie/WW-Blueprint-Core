//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintFaction"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseFactionConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintFaction
    where TBuilder : BaseFactionConfigurator<T, TBuilder>
  {
    protected BaseFactionConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFaction.m_AttackFactions"/>
    /// </summary>
    ///
    /// <param name="attackFactions">
    /// <para>
    /// Blueprint of type BlueprintFaction. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAttackFactions(List<Blueprint<BlueprintFaction, BlueprintFactionReference>> attackFactions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AttackFactions = attackFactions?.Select(bp => bp.Reference)?.ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintFaction.m_AttackFactions"/>
    /// </summary>
    ///
    /// <param name="attackFactions">
    /// <para>
    /// Blueprint of type BlueprintFaction. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToAttackFactions(params Blueprint<BlueprintFaction, BlueprintFactionReference>[] attackFactions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AttackFactions = bp.m_AttackFactions ?? new BlueprintFactionReference[0];
          bp.m_AttackFactions = CommonTool.Append(bp.m_AttackFactions, attackFactions.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintFaction.m_AttackFactions"/>
    /// </summary>
    ///
    /// <param name="attackFactions">
    /// <para>
    /// Blueprint of type BlueprintFaction. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromAttackFactions(params Blueprint<BlueprintFaction, BlueprintFactionReference>[] attackFactions)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AttackFactions is null) { return; }
          bp.m_AttackFactions = bp.m_AttackFactions.Where(val => !attackFactions.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintFaction.m_AttackFactions"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="attackFactions">
    /// <para>
    /// Blueprint of type BlueprintFaction. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromAttackFactions(Func<BlueprintFactionReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AttackFactions is null) { return; }
          bp.m_AttackFactions = bp.m_AttackFactions.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintFaction.m_AttackFactions"/>
    /// </summary>
    ///
    /// <param name="attackFactions">
    /// <para>
    /// Blueprint of type BlueprintFaction. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearAttackFactions()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AttackFactions = new BlueprintFactionReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFaction.m_AttackFactions"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="attackFactions">
    /// <para>
    /// Blueprint of type BlueprintFaction. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyAttackFactions(Action<BlueprintFactionReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AttackFactions is null) { return; }
          bp.m_AttackFactions.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFaction.m_AllyFactions"/>
    /// </summary>
    ///
    /// <param name="allyFactions">
    /// <para>
    /// Blueprint of type BlueprintFaction. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAllyFactions(List<Blueprint<BlueprintFaction, BlueprintFactionReference>> allyFactions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AllyFactions = allyFactions?.Select(bp => bp.Reference)?.ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintFaction.m_AllyFactions"/>
    /// </summary>
    ///
    /// <param name="allyFactions">
    /// <para>
    /// Blueprint of type BlueprintFaction. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToAllyFactions(params Blueprint<BlueprintFaction, BlueprintFactionReference>[] allyFactions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AllyFactions = bp.m_AllyFactions ?? new BlueprintFactionReference[0];
          bp.m_AllyFactions = CommonTool.Append(bp.m_AllyFactions, allyFactions.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintFaction.m_AllyFactions"/>
    /// </summary>
    ///
    /// <param name="allyFactions">
    /// <para>
    /// Blueprint of type BlueprintFaction. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromAllyFactions(params Blueprint<BlueprintFaction, BlueprintFactionReference>[] allyFactions)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AllyFactions is null) { return; }
          bp.m_AllyFactions = bp.m_AllyFactions.Where(val => !allyFactions.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintFaction.m_AllyFactions"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="allyFactions">
    /// <para>
    /// Blueprint of type BlueprintFaction. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromAllyFactions(Func<BlueprintFactionReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AllyFactions is null) { return; }
          bp.m_AllyFactions = bp.m_AllyFactions.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintFaction.m_AllyFactions"/>
    /// </summary>
    ///
    /// <param name="allyFactions">
    /// <para>
    /// Blueprint of type BlueprintFaction. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearAllyFactions()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AllyFactions = new BlueprintFactionReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFaction.m_AllyFactions"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="allyFactions">
    /// <para>
    /// Blueprint of type BlueprintFaction. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyAllyFactions(Action<BlueprintFactionReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AllyFactions is null) { return; }
          bp.m_AllyFactions.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFaction.m_AllyFactionsBehaviour"/>
    /// </summary>
    public TBuilder SetAllyFactionsBehaviour(BlueprintFaction.EAllyFactions allyFactionsBehaviour)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AllyFactionsBehaviour = allyFactionsBehaviour;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFaction.m_AllyFactionsBehaviour"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAllyFactionsBehaviour(Action<BlueprintFaction.EAllyFactions> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_AllyFactionsBehaviour);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFaction.Peaceful"/>
    /// </summary>
    ///
    /// <param name="peaceful">
    /// <para>
    /// InfoBox: Can't be target, can't join combat
    /// </para>
    /// </param>
    public TBuilder SetPeaceful(bool peaceful = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Peaceful = peaceful;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFaction.Peaceful"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="peaceful">
    /// <para>
    /// InfoBox: Can't be target, can't join combat
    /// </para>
    /// </param>
    public TBuilder ModifyPeaceful(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Peaceful);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFaction.AlwaysEnemy"/>
    /// </summary>
    ///
    /// <param name="alwaysEnemy">
    /// <para>
    /// InfoBox: If you add this to AttackFactions, faction will become enemy for every one. Don't use it!!!
    /// </para>
    /// </param>
    public TBuilder SetAlwaysEnemy(bool alwaysEnemy = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AlwaysEnemy = alwaysEnemy;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFaction.AlwaysEnemy"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="alwaysEnemy">
    /// <para>
    /// InfoBox: If you add this to AttackFactions, faction will become enemy for every one. Don't use it!!!
    /// </para>
    /// </param>
    public TBuilder ModifyAlwaysEnemy(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.AlwaysEnemy);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFaction.EnemyForEveryone"/>
    /// </summary>
    ///
    /// <param name="enemyForEveryone">
    /// <para>
    /// InfoBox: Unit will be always marked as enemy for others. Ignores AttackFactions
    /// </para>
    /// </param>
    public TBuilder SetEnemyForEveryone(bool enemyForEveryone = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.EnemyForEveryone = enemyForEveryone;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFaction.EnemyForEveryone"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="enemyForEveryone">
    /// <para>
    /// InfoBox: Unit will be always marked as enemy for others. Ignores AttackFactions
    /// </para>
    /// </param>
    public TBuilder ModifyEnemyForEveryone(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.EnemyForEveryone);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFaction.Neutral"/>
    /// </summary>
    ///
    /// <param name="neutral">
    /// <para>
    /// InfoBox: Will not start the combat, but can be target and will join combat if was attacked
    /// </para>
    /// </param>
    public TBuilder SetNeutral(bool neutral = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Neutral = neutral;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFaction.Neutral"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="neutral">
    /// <para>
    /// InfoBox: Will not start the combat, but can be target and will join combat if was attacked
    /// </para>
    /// </param>
    public TBuilder ModifyNeutral(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Neutral);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFaction.IsDirectlyControllable"/>
    /// </summary>
    ///
    /// <param name="isDirectlyControllable">
    /// <para>
    /// InfoBox: Can be manually controlled by Player
    /// </para>
    /// </param>
    public TBuilder SetIsDirectlyControllable(bool isDirectlyControllable = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsDirectlyControllable = isDirectlyControllable;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFaction.IsDirectlyControllable"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="isDirectlyControllable">
    /// <para>
    /// InfoBox: Can be manually controlled by Player
    /// </para>
    /// </param>
    public TBuilder ModifyIsDirectlyControllable(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.IsDirectlyControllable);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintFaction.NeverJoinCombat"/>
    /// </summary>
    ///
    /// <param name="neverJoinCombat">
    /// <para>
    /// InfoBox: Can be target by enemies but will not join combat
    /// </para>
    /// </param>
    public TBuilder SetNeverJoinCombat(bool neverJoinCombat = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.NeverJoinCombat = neverJoinCombat;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintFaction.NeverJoinCombat"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="neverJoinCombat">
    /// <para>
    /// InfoBox: Can be target by enemies but will not join combat
    /// </para>
    /// </param>
    public TBuilder ModifyNeverJoinCombat(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.NeverJoinCombat);
        });
    }
  }
}
