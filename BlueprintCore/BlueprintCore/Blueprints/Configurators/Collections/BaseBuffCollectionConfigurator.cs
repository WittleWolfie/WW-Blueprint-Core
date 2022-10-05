//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Designers.Mechanics.Collections;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Collections
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BuffCollection"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseBuffCollectionConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BuffCollection
    where TBuilder : BaseBuffCollectionConfigurator<T, TBuilder>
  {
    protected BaseBuffCollectionConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BuffCollection>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.CheckHidden = copyFrom.CheckHidden;
          bp.m_BuffList = copyFrom.m_BuffList;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BuffCollection.CheckHidden"/>
    /// </summary>
    public TBuilder SetCheckHidden(bool checkHidden = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CheckHidden = checkHidden;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BuffCollection.m_BuffList"/>
    /// </summary>
    ///
    /// <param name="buffList">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetBuffList(params Blueprint<BlueprintBuffReference>[] buffList)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BuffList = buffList.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BuffCollection.m_BuffList"/>
    /// </summary>
    ///
    /// <param name="buffList">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToBuffList(params Blueprint<BlueprintBuffReference>[] buffList)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BuffList = bp.m_BuffList ?? new BlueprintBuffReference[0];
          bp.m_BuffList = CommonTool.Append(bp.m_BuffList, buffList.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BuffCollection.m_BuffList"/>
    /// </summary>
    ///
    /// <param name="buffList">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromBuffList(params Blueprint<BlueprintBuffReference>[] buffList)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BuffList is null) { return; }
          bp.m_BuffList = bp.m_BuffList.Where(val => !buffList.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BuffCollection.m_BuffList"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromBuffList(Func<BlueprintBuffReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BuffList is null) { return; }
          bp.m_BuffList = bp.m_BuffList.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BuffCollection.m_BuffList"/>
    /// </summary>
    public TBuilder ClearBuffList()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BuffList = new BlueprintBuffReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BuffCollection.m_BuffList"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyBuffList(Action<BlueprintBuffReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BuffList is null) { return; }
          bp.m_BuffList.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_BuffList is null)
      {
        Blueprint.m_BuffList = new BlueprintBuffReference[0];
      }
    }
  }
}
