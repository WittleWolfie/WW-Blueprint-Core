//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Localization;
using Kingmaker.Utility;
using System;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="MoraleRoot"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseMoraleRootConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : MoraleRoot
    where TBuilder : BaseMoraleRootConfigurator<T, TBuilder>
  {
    protected BaseMoraleRootConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="MoraleRoot.m_MoraleBorder"/>
    /// </summary>
    public TBuilder SetMoraleBorder(Vector2Int moraleBorder)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MoraleBorder = moraleBorder;
        });
    }

    /// <summary>
    /// Modifies <see cref="MoraleRoot.m_MoraleBorder"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMoraleBorder(Action<Vector2Int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_MoraleBorder);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="MoraleRoot.m_DevineForNegative"/>
    /// </summary>
    ///
    /// <param name="devineForNegative">
    /// <para>
    /// Tooltip: Если мораль < 0. Шанс негативного = UnitMorale/DevineForNegative
    /// </para>
    /// </param>
    public TBuilder SetDevineForNegative(float devineForNegative)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DevineForNegative = devineForNegative;
        });
    }

    /// <summary>
    /// Modifies <see cref="MoraleRoot.m_DevineForNegative"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="devineForNegative">
    /// <para>
    /// Tooltip: Если мораль < 0. Шанс негативного = UnitMorale/DevineForNegative
    /// </para>
    /// </param>
    public TBuilder ModifyDevineForNegative(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_DevineForNegative);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="MoraleRoot.m_DevineForPositive"/>
    /// </summary>
    ///
    /// <param name="devineForPositive">
    /// <para>
    /// Tooltip: Если мораль > 0. Шанс позитивного = UnitMorale/DevineForPositive
    /// </para>
    /// </param>
    public TBuilder SetDevineForPositive(float devineForPositive)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DevineForPositive = devineForPositive;
        });
    }

    /// <summary>
    /// Modifies <see cref="MoraleRoot.m_DevineForPositive"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="devineForPositive">
    /// <para>
    /// Tooltip: Если мораль > 0. Шанс позитивного = UnitMorale/DevineForPositive
    /// </para>
    /// </param>
    public TBuilder ModifyDevineForPositive(Action<float> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_DevineForPositive);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="MoraleRoot.m_NegativeFacts"/>
    /// </summary>
    ///
    /// <param name="negativeFacts">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetNegativeFacts(params Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>[] negativeFacts)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_NegativeFacts = negativeFacts.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="MoraleRoot.m_NegativeFacts"/>
    /// </summary>
    ///
    /// <param name="negativeFacts">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToNegativeFacts(params Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>[] negativeFacts)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_NegativeFacts = bp.m_NegativeFacts ?? new BlueprintUnitFactReference[0];
          bp.m_NegativeFacts = CommonTool.Append(bp.m_NegativeFacts, negativeFacts.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="MoraleRoot.m_NegativeFacts"/>
    /// </summary>
    ///
    /// <param name="negativeFacts">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromNegativeFacts(params Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>[] negativeFacts)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_NegativeFacts is null) { return; }
          bp.m_NegativeFacts = bp.m_NegativeFacts.Where(val => !negativeFacts.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="MoraleRoot.m_NegativeFacts"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="negativeFacts">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromNegativeFacts(Func<BlueprintUnitFactReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_NegativeFacts is null) { return; }
          bp.m_NegativeFacts = bp.m_NegativeFacts.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="MoraleRoot.m_NegativeFacts"/>
    /// </summary>
    ///
    /// <param name="negativeFacts">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearNegativeFacts()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_NegativeFacts = new BlueprintUnitFactReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="MoraleRoot.m_NegativeFacts"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="negativeFacts">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyNegativeFacts(Action<BlueprintUnitFactReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_NegativeFacts is null) { return; }
          bp.m_NegativeFacts.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="MoraleRoot.m_GlobalArmiesMoraleBuff"/>
    /// </summary>
    ///
    /// <param name="globalArmiesMoraleBuff">
    /// <para>
    /// Blueprint of type BlueprintKingdomBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetGlobalArmiesMoraleBuff(Blueprint<BlueprintKingdomBuff, BlueprintKingdomBuffReference> globalArmiesMoraleBuff)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_GlobalArmiesMoraleBuff = globalArmiesMoraleBuff?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="MoraleRoot.m_GlobalArmiesMoraleBuff"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="globalArmiesMoraleBuff">
    /// <para>
    /// Blueprint of type BlueprintKingdomBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyGlobalArmiesMoraleBuff(Action<BlueprintKingdomBuffReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_GlobalArmiesMoraleBuff is null) { return; }
          action.Invoke(bp.m_GlobalArmiesMoraleBuff);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="MoraleRoot.BaseMoraleValue"/>
    /// </summary>
    public TBuilder SetBaseMoraleValue(LocalizedString baseMoraleValue)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.BaseMoraleValue = baseMoraleValue;
          if (bp.BaseMoraleValue is null)
          {
            bp.BaseMoraleValue = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="MoraleRoot.BaseMoraleValue"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBaseMoraleValue(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.BaseMoraleValue is null) { return; }
          action.Invoke(bp.BaseMoraleValue);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="MoraleRoot.ArmyEffectOnSquad"/>
    /// </summary>
    public TBuilder SetArmyEffectOnSquad(LocalizedString armyEffectOnSquad)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ArmyEffectOnSquad = armyEffectOnSquad;
          if (bp.ArmyEffectOnSquad is null)
          {
            bp.ArmyEffectOnSquad = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="MoraleRoot.ArmyEffectOnSquad"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyArmyEffectOnSquad(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ArmyEffectOnSquad is null) { return; }
          action.Invoke(bp.ArmyEffectOnSquad);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="MoraleRoot.UnitNotHaveMorale"/>
    /// </summary>
    public TBuilder SetUnitNotHaveMorale(LocalizedString unitNotHaveMorale)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UnitNotHaveMorale = unitNotHaveMorale;
          if (bp.UnitNotHaveMorale is null)
          {
            bp.UnitNotHaveMorale = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="MoraleRoot.UnitNotHaveMorale"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyUnitNotHaveMorale(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.UnitNotHaveMorale is null) { return; }
          action.Invoke(bp.UnitNotHaveMorale);
        });
    }
  }
}
