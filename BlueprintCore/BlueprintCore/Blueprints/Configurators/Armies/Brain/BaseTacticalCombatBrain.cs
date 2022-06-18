//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.AI;
using BlueprintCore.Utils;
using Kingmaker.Armies.TacticalCombat.Brain;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Armies.Brain
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintTacticalCombatBrain"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseTacticalCombatBrainConfigurator<T, TBuilder>
    : BaseBrainConfigurator<T, TBuilder>
    where T : BlueprintTacticalCombatBrain
    where TBuilder : BaseTacticalCombatBrainConfigurator<T, TBuilder>
  {
    protected BaseTacticalCombatBrainConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTacticalCombatBrain.m_TacticalActions"/>
    /// </summary>
    ///
    /// <param name="tacticalActions">
    /// <para>
    /// Blueprint of type BlueprintTacticalCombatAiAction. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetTacticalActions(params Blueprint<BlueprintTacticalCombatAiActionReference>[] tacticalActions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TacticalActions = tacticalActions.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintTacticalCombatBrain.m_TacticalActions"/>
    /// </summary>
    ///
    /// <param name="tacticalActions">
    /// <para>
    /// Blueprint of type BlueprintTacticalCombatAiAction. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToTacticalActions(params Blueprint<BlueprintTacticalCombatAiActionReference>[] tacticalActions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TacticalActions = bp.m_TacticalActions ?? new BlueprintTacticalCombatAiActionReference[0];
          bp.m_TacticalActions = CommonTool.Append(bp.m_TacticalActions, tacticalActions.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintTacticalCombatBrain.m_TacticalActions"/>
    /// </summary>
    ///
    /// <param name="tacticalActions">
    /// <para>
    /// Blueprint of type BlueprintTacticalCombatAiAction. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromTacticalActions(params Blueprint<BlueprintTacticalCombatAiActionReference>[] tacticalActions)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TacticalActions is null) { return; }
          bp.m_TacticalActions = bp.m_TacticalActions.Where(val => !tacticalActions.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintTacticalCombatBrain.m_TacticalActions"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromTacticalActions(Func<BlueprintTacticalCombatAiActionReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TacticalActions is null) { return; }
          bp.m_TacticalActions = bp.m_TacticalActions.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintTacticalCombatBrain.m_TacticalActions"/>
    /// </summary>
    public TBuilder ClearTacticalActions()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TacticalActions = new BlueprintTacticalCombatAiActionReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTacticalCombatBrain.m_TacticalActions"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyTacticalActions(Action<BlueprintTacticalCombatAiActionReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TacticalActions is null) { return; }
          bp.m_TacticalActions.ForEach(action);
        });
    }

    protected override void SetDefaults()
    {
      base.SetDefaults();
    
      if (Blueprint.m_TacticalActions is null)
      {
        Blueprint.m_TacticalActions = new BlueprintTacticalCombatAiActionReference[0];
      }
    }
  }
}
