//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintBrain"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseBrainConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintBrain
    where TBuilder : BaseBrainConfigurator<T, TBuilder>
  {
    protected BaseBrainConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintBrain.m_Actions"/>
    /// </summary>
    ///
    /// <param name="actions">
    /// <para>
    /// Blueprint of type BlueprintAiAction. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetActions(params Blueprint<BlueprintAiAction, BlueprintAiActionReference>[] actions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Actions = actions.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintBrain.m_Actions"/>
    /// </summary>
    ///
    /// <param name="actions">
    /// <para>
    /// Blueprint of type BlueprintAiAction. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToActions(params Blueprint<BlueprintAiAction, BlueprintAiActionReference>[] actions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Actions = bp.m_Actions ?? new BlueprintAiActionReference[0];
          bp.m_Actions = CommonTool.Append(bp.m_Actions, actions.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintBrain.m_Actions"/>
    /// </summary>
    ///
    /// <param name="actions">
    /// <para>
    /// Blueprint of type BlueprintAiAction. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromActions(params Blueprint<BlueprintAiAction, BlueprintAiActionReference>[] actions)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Actions is null) { return; }
          bp.m_Actions = bp.m_Actions.Where(val => !actions.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintBrain.m_Actions"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromActions(Func<BlueprintAiActionReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Actions is null) { return; }
          bp.m_Actions = bp.m_Actions.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintBrain.m_Actions"/>
    /// </summary>
    public TBuilder ClearActions()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Actions = new BlueprintAiActionReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintBrain.m_Actions"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyActions(Action<BlueprintAiActionReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Actions is null) { return; }
          bp.m_Actions.ForEach(action);
        });
    }
  }
}
