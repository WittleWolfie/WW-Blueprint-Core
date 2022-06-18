//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintUnitTemplate"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseUnitTemplateConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintUnitTemplate
    where TBuilder : BaseUnitTemplateConfigurator<T, TBuilder>
  {
    protected BaseUnitTemplateConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnitTemplate.m_RemoveFacts"/>
    /// </summary>
    ///
    /// <param name="removeFacts">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetRemoveFacts(params Blueprint<BlueprintUnitFactReference>[] removeFacts)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_RemoveFacts = removeFacts.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintUnitTemplate.m_RemoveFacts"/>
    /// </summary>
    ///
    /// <param name="removeFacts">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToRemoveFacts(params Blueprint<BlueprintUnitFactReference>[] removeFacts)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_RemoveFacts = bp.m_RemoveFacts ?? new BlueprintUnitFactReference[0];
          bp.m_RemoveFacts = CommonTool.Append(bp.m_RemoveFacts, removeFacts.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintUnitTemplate.m_RemoveFacts"/>
    /// </summary>
    ///
    /// <param name="removeFacts">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromRemoveFacts(params Blueprint<BlueprintUnitFactReference>[] removeFacts)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_RemoveFacts is null) { return; }
          bp.m_RemoveFacts = bp.m_RemoveFacts.Where(val => !removeFacts.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintUnitTemplate.m_RemoveFacts"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromRemoveFacts(Func<BlueprintUnitFactReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_RemoveFacts is null) { return; }
          bp.m_RemoveFacts = bp.m_RemoveFacts.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintUnitTemplate.m_RemoveFacts"/>
    /// </summary>
    public TBuilder ClearRemoveFacts()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_RemoveFacts = new BlueprintUnitFactReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnitTemplate.m_RemoveFacts"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyRemoveFacts(Action<BlueprintUnitFactReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_RemoveFacts is null) { return; }
          bp.m_RemoveFacts.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnitTemplate.m_AddFacts"/>
    /// </summary>
    ///
    /// <param name="addFacts">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAddFacts(params Blueprint<BlueprintUnitFactReference>[] addFacts)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AddFacts = addFacts.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintUnitTemplate.m_AddFacts"/>
    /// </summary>
    ///
    /// <param name="addFacts">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToAddFacts(params Blueprint<BlueprintUnitFactReference>[] addFacts)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AddFacts = bp.m_AddFacts ?? new BlueprintUnitFactReference[0];
          bp.m_AddFacts = CommonTool.Append(bp.m_AddFacts, addFacts.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintUnitTemplate.m_AddFacts"/>
    /// </summary>
    ///
    /// <param name="addFacts">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromAddFacts(params Blueprint<BlueprintUnitFactReference>[] addFacts)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AddFacts is null) { return; }
          bp.m_AddFacts = bp.m_AddFacts.Where(val => !addFacts.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintUnitTemplate.m_AddFacts"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromAddFacts(Func<BlueprintUnitFactReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AddFacts is null) { return; }
          bp.m_AddFacts = bp.m_AddFacts.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintUnitTemplate.m_AddFacts"/>
    /// </summary>
    public TBuilder ClearAddFacts()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_AddFacts = new BlueprintUnitFactReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnitTemplate.m_AddFacts"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyAddFacts(Action<BlueprintUnitFactReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_AddFacts is null) { return; }
          bp.m_AddFacts.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnitTemplate.StatAdjustments"/>
    /// </summary>
    public TBuilder SetStatAdjustments(params BlueprintUnitTemplate.StatAdjustment[] statAdjustments)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(statAdjustments);
          bp.StatAdjustments = statAdjustments;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintUnitTemplate.StatAdjustments"/>
    /// </summary>
    public TBuilder AddToStatAdjustments(params BlueprintUnitTemplate.StatAdjustment[] statAdjustments)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.StatAdjustments = bp.StatAdjustments ?? new BlueprintUnitTemplate.StatAdjustment[0];
          bp.StatAdjustments = CommonTool.Append(bp.StatAdjustments, statAdjustments);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintUnitTemplate.StatAdjustments"/>
    /// </summary>
    public TBuilder RemoveFromStatAdjustments(params BlueprintUnitTemplate.StatAdjustment[] statAdjustments)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.StatAdjustments is null) { return; }
          bp.StatAdjustments = bp.StatAdjustments.Where(val => !statAdjustments.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintUnitTemplate.StatAdjustments"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromStatAdjustments(Func<BlueprintUnitTemplate.StatAdjustment, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.StatAdjustments is null) { return; }
          bp.StatAdjustments = bp.StatAdjustments.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintUnitTemplate.StatAdjustments"/>
    /// </summary>
    public TBuilder ClearStatAdjustments()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.StatAdjustments = new BlueprintUnitTemplate.StatAdjustment[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnitTemplate.StatAdjustments"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyStatAdjustments(Action<BlueprintUnitTemplate.StatAdjustment> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.StatAdjustments is null) { return; }
          bp.StatAdjustments.ForEach(action);
        });
    }

    protected override void SetDefaults()
    {
      base.SetDefaults();
    
      if (Blueprint.m_RemoveFacts is null)
      {
        Blueprint.m_RemoveFacts = new BlueprintUnitFactReference[0];
      }
      if (Blueprint.m_AddFacts is null)
      {
        Blueprint.m_AddFacts = new BlueprintUnitFactReference[0];
      }
      if (Blueprint.StatAdjustments is null)
      {
        Blueprint.StatAdjustments = new BlueprintUnitTemplate.StatAdjustment[0];
      }
    }
  }
}
