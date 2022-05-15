//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCheck"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCheckConfigurator<T, TBuilder>
    : BaseCueBaseConfigurator<T, TBuilder>
    where T : BlueprintCheck
    where TBuilder : BaseCheckConfigurator<T, TBuilder>
  {
    protected BaseCheckConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCheck.Type"/>
    /// </summary>
    public TBuilder SetType(StatType type)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Type = type;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCheck.Type"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyType(Action<StatType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Type);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCheck.DC"/>
    /// </summary>
    public TBuilder SetDC(int dC)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DC = dC;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCheck.DC"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDC(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.DC);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCheck.Hidden"/>
    /// </summary>
    public TBuilder SetHidden(bool hidden = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Hidden = hidden;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCheck.Hidden"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHidden(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Hidden);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCheck.DCModifiers"/>
    /// </summary>
    public TBuilder SetDCModifiers(DCModifier[] dCModifiers)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in dCModifiers) { Validate(item); }
          bp.DCModifiers = dCModifiers;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintCheck.DCModifiers"/>
    /// </summary>
    public TBuilder AddToDCModifiers(params DCModifier[] dCModifiers)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DCModifiers = bp.DCModifiers ?? new DCModifier[0];
          bp.DCModifiers = CommonTool.Append(bp.DCModifiers, dCModifiers);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCheck.DCModifiers"/>
    /// </summary>
    public TBuilder RemoveFromDCModifiers(params DCModifier[] dCModifiers)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DCModifiers is null) { return; }
          bp.DCModifiers = bp.DCModifiers.Where(val => !dCModifiers.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCheck.DCModifiers"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromDCModifiers(Func<DCModifier, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DCModifiers is null) { return; }
          bp.DCModifiers = bp.DCModifiers.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintCheck.DCModifiers"/>
    /// </summary>
    public TBuilder ClearDCModifiers()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DCModifiers = new DCModifier[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCheck.DCModifiers"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyDCModifiers(Action<DCModifier> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.DCModifiers is null) { return; }
          bp.DCModifiers.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCheck.m_Success"/>
    /// </summary>
    ///
    /// <param name="success">
    /// <para>
    /// Blueprint of type BlueprintCueBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetSuccess(Blueprint<BlueprintCueBase, BlueprintCueBaseReference> success)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Success = success?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCheck.m_Success"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="success">
    /// <para>
    /// Blueprint of type BlueprintCueBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifySuccess(Action<BlueprintCueBaseReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Success is null) { return; }
          action.Invoke(bp.m_Success);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCheck.m_Fail"/>
    /// </summary>
    ///
    /// <param name="fail">
    /// <para>
    /// Blueprint of type BlueprintCueBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetFail(Blueprint<BlueprintCueBase, BlueprintCueBaseReference> fail)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Fail = fail?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCheck.m_Fail"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="fail">
    /// <para>
    /// Blueprint of type BlueprintCueBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyFail(Action<BlueprintCueBaseReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Fail is null) { return; }
          action.Invoke(bp.m_Fail);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCheck.m_UnitEvaluator"/>
    /// </summary>
    public TBuilder SetUnitEvaluator(UnitEvaluator unitEvaluator)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(unitEvaluator);
          bp.m_UnitEvaluator = unitEvaluator;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCheck.m_UnitEvaluator"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyUnitEvaluator(Action<UnitEvaluator> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_UnitEvaluator is null) { return; }
          action.Invoke(bp.m_UnitEvaluator);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCheck.Experience"/>
    /// </summary>
    public TBuilder SetExperience(DialogExperience experience)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Experience = experience;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCheck.Experience"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyExperience(Action<DialogExperience> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Experience);
        });
    }
  }
}
