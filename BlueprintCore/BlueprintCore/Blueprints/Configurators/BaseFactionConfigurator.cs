//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using System;
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
    protected BaseFactionConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintFaction>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_AttackFactions = copyFrom.m_AttackFactions;
          bp.m_AllyFactions = copyFrom.m_AllyFactions;
          bp.m_AllyFactionsBehaviour = copyFrom.m_AllyFactionsBehaviour;
          bp.Peaceful = copyFrom.Peaceful;
          bp.AlwaysEnemy = copyFrom.AlwaysEnemy;
          bp.EnemyForEveryone = copyFrom.EnemyForEveryone;
          bp.Neutral = copyFrom.Neutral;
          bp.IsDirectlyControllable = copyFrom.IsDirectlyControllable;
          bp.NeverJoinCombat = copyFrom.NeverJoinCombat;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintFaction>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_AttackFactions = copyFrom.m_AttackFactions;
          bp.m_AllyFactions = copyFrom.m_AllyFactions;
          bp.m_AllyFactionsBehaviour = copyFrom.m_AllyFactionsBehaviour;
          bp.Peaceful = copyFrom.Peaceful;
          bp.AlwaysEnemy = copyFrom.AlwaysEnemy;
          bp.EnemyForEveryone = copyFrom.EnemyForEveryone;
          bp.Neutral = copyFrom.Neutral;
          bp.IsDirectlyControllable = copyFrom.IsDirectlyControllable;
          bp.NeverJoinCombat = copyFrom.NeverJoinCombat;
        });
    }

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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAttackFactions(params Blueprint<BlueprintFactionReference>[] attackFactions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AttackFactions = attackFactions.Select(bp => bp.Reference).ToArray();
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToAttackFactions(params Blueprint<BlueprintFactionReference>[] attackFactions)
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromAttackFactions(params Blueprint<BlueprintFactionReference>[] attackFactions)
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
    public TBuilder RemoveFromAttackFactions(Func<BlueprintFactionReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AttackFactions is null) { return; }
          bp.m_AttackFactions = bp.m_AttackFactions.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintFaction.m_AttackFactions"/>
    /// </summary>
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAllyFactions(params Blueprint<BlueprintFactionReference>[] allyFactions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AllyFactions = allyFactions.Select(bp => bp.Reference).ToArray();
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToAllyFactions(params Blueprint<BlueprintFactionReference>[] allyFactions)
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromAllyFactions(params Blueprint<BlueprintFactionReference>[] allyFactions)
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
    public TBuilder RemoveFromAllyFactions(Func<BlueprintFactionReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AllyFactions is null) { return; }
          bp.m_AllyFactions = bp.m_AllyFactions.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintFaction.m_AllyFactions"/>
    /// </summary>
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
    /// Sets the value of <see cref="BlueprintFaction.Peaceful"/>
    /// </summary>
    ///
    /// <param name="peaceful">
    /// <para>
    /// InfoBox: Can&amp;apos;t be target, can&amp;apos;t join combat
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
    /// Sets the value of <see cref="BlueprintFaction.AlwaysEnemy"/>
    /// </summary>
    ///
    /// <param name="alwaysEnemy">
    /// <para>
    /// InfoBox: If you add this to AttackFactions, faction will become enemy for every one. Don&amp;apos;t use it!!!
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

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_AttackFactions is null)
      {
        Blueprint.m_AttackFactions = new BlueprintFactionReference[0];
      }
      if (Blueprint.m_AllyFactions is null)
      {
        Blueprint.m_AllyFactions = new BlueprintFactionReference[0];
      }
    }
  }
}
