//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintUnitType"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseUnitTypeConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintUnitType
    where TBuilder : BaseUnitTypeConfigurator<T, TBuilder>
  {
    protected BaseUnitTypeConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnitType.KnowledgeStat"/>
    /// </summary>
    public TBuilder SetKnowledgeStat(StatType knowledgeStat)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.KnowledgeStat = knowledgeStat;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnitType.KnowledgeStat"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyKnowledgeStat(Action<StatType> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.KnowledgeStat);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnitType.Image"/>
    /// </summary>
    public TBuilder SetImage(Sprite image)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(image);
          bp.Image = image;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnitType.Image"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyImage(Action<Sprite> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Image is null) { return; }
          action.Invoke(bp.Image);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnitType.Name"/>
    /// </summary>
    public TBuilder SetName(LocalizedString name)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Name = name;
          if (bp.Name is null)
          {
            bp.Name = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnitType.Name"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyName(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Name is null) { return; }
          action.Invoke(bp.Name);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnitType.Description"/>
    /// </summary>
    public TBuilder SetDescription(LocalizedString description)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Description = description;
          if (bp.Description is null)
          {
            bp.Description = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnitType.Description"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDescription(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Description is null) { return; }
          action.Invoke(bp.Description);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintUnitType.m_SignatureAbilities"/>
    /// </summary>
    ///
    /// <param name="signatureAbilities">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetSignatureAbilities(List<Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>> signatureAbilities)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SignatureAbilities = signatureAbilities?.Select(bp => bp.Reference)?.ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintUnitType.m_SignatureAbilities"/>
    /// </summary>
    ///
    /// <param name="signatureAbilities">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToSignatureAbilities(params Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>[] signatureAbilities)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SignatureAbilities = bp.m_SignatureAbilities ?? new BlueprintUnitFactReference[0];
          bp.m_SignatureAbilities = CommonTool.Append(bp.m_SignatureAbilities, signatureAbilities.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintUnitType.m_SignatureAbilities"/>
    /// </summary>
    ///
    /// <param name="signatureAbilities">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromSignatureAbilities(params Blueprint<BlueprintUnitFact, BlueprintUnitFactReference>[] signatureAbilities)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SignatureAbilities is null) { return; }
          bp.m_SignatureAbilities = bp.m_SignatureAbilities.Where(val => !signatureAbilities.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintUnitType.m_SignatureAbilities"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="signatureAbilities">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromSignatureAbilities(Func<BlueprintUnitFactReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SignatureAbilities is null) { return; }
          bp.m_SignatureAbilities = bp.m_SignatureAbilities.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintUnitType.m_SignatureAbilities"/>
    /// </summary>
    ///
    /// <param name="signatureAbilities">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearSignatureAbilities()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SignatureAbilities = new BlueprintUnitFactReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintUnitType.m_SignatureAbilities"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="signatureAbilities">
    /// <para>
    /// Blueprint of type BlueprintUnitFact. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifySignatureAbilities(Action<BlueprintUnitFactReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SignatureAbilities is null) { return; }
          bp.m_SignatureAbilities.ForEach(action);
        });
    }
  }
}
