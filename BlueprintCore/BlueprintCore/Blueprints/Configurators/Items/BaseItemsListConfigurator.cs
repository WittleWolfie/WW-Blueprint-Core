//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Items
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintItemsList"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseItemsListConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintItemsList
    where TBuilder : BaseItemsListConfigurator<T, TBuilder>
  {
    protected BaseItemsListConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintItemsList>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_Items = copyFrom.m_Items;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintItemsList.m_Items"/>
    /// </summary>
    ///
    /// <param name="items">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetItems(params Blueprint<BlueprintItemReference>[] items)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Items = items.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintItemsList.m_Items"/>
    /// </summary>
    ///
    /// <param name="items">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToItems(params Blueprint<BlueprintItemReference>[] items)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Items = bp.m_Items ?? new BlueprintItemReference[0];
          bp.m_Items = CommonTool.Append(bp.m_Items, items.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintItemsList.m_Items"/>
    /// </summary>
    ///
    /// <param name="items">
    /// <para>
    /// Blueprint of type BlueprintItem. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromItems(params Blueprint<BlueprintItemReference>[] items)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Items is null) { return; }
          bp.m_Items = bp.m_Items.Where(val => !items.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintItemsList.m_Items"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromItems(Func<BlueprintItemReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Items is null) { return; }
          bp.m_Items = bp.m_Items.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintItemsList.m_Items"/>
    /// </summary>
    public TBuilder ClearItems()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Items = new BlueprintItemReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintItemsList.m_Items"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyItems(Action<BlueprintItemReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Items is null) { return; }
          bp.m_Items.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Items is null)
      {
        Blueprint.m_Items = new BlueprintItemReference[0];
      }
    }
  }
}
