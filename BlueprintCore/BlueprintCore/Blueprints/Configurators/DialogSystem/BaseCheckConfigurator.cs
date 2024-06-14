//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.DialogSystem;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
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
    protected BaseCheckConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintCheck>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Type = copyFrom.Type;
          bp.DC = copyFrom.DC;
          bp.Hidden = copyFrom.Hidden;
          bp.DCModifiers = copyFrom.DCModifiers;
          bp.BanPartyCheckInCamp = copyFrom.BanPartyCheckInCamp;
          bp.m_Success = copyFrom.m_Success;
          bp.m_Fail = copyFrom.m_Fail;
          bp.m_UnitEvaluator = copyFrom.m_UnitEvaluator;
          bp.Experience = copyFrom.Experience;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintCheck>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Type = copyFrom.Type;
          bp.DC = copyFrom.DC;
          bp.Hidden = copyFrom.Hidden;
          bp.DCModifiers = copyFrom.DCModifiers;
          bp.BanPartyCheckInCamp = copyFrom.BanPartyCheckInCamp;
          bp.m_Success = copyFrom.m_Success;
          bp.m_Fail = copyFrom.m_Fail;
          bp.m_UnitEvaluator = copyFrom.m_UnitEvaluator;
          bp.Experience = copyFrom.Experience;
        });
    }

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
    /// Sets the value of <see cref="BlueprintCheck.DCModifiers"/>
    /// </summary>
    public TBuilder SetDCModifiers(params DCModifier[] dCModifiers)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(dCModifiers);
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
          bp.DCModifiers = bp.DCModifiers.Where(e => !predicate(e)).ToArray();
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
    /// Sets the value of <see cref="BlueprintCheck.BanPartyCheckInCamp"/>
    /// </summary>
    public TBuilder SetBanPartyCheckInCamp(bool banPartyCheckInCamp = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.BanPartyCheckInCamp = banPartyCheckInCamp;
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetSuccess(Blueprint<BlueprintCueBaseReference> success)
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetFail(Blueprint<BlueprintCueBaseReference> fail)
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

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.DCModifiers is null)
      {
        Blueprint.DCModifiers = new DCModifier[0];
      }
      if (Blueprint.m_Success is null)
      {
        Blueprint.m_Success = BlueprintTool.GetRef<BlueprintCueBaseReference>(null);
      }
      if (Blueprint.m_Fail is null)
      {
        Blueprint.m_Fail = BlueprintTool.GetRef<BlueprintCueBaseReference>(null);
      }
    }
  }
}
