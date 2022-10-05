//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using Kingmaker.Utility;
using System;
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
    protected BaseUnitTypeConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintUnitType>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.KnowledgeStat = copyFrom.KnowledgeStat;
          bp.Image = copyFrom.Image;
          bp.Name = copyFrom.Name;
          bp.Description = copyFrom.Description;
          bp.m_SignatureAbilities = copyFrom.m_SignatureAbilities;
        });
    }

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
    /// Sets the value of <see cref="BlueprintUnitType.Image"/>
    /// </summary>
    ///
    /// <param name="image">
    /// You can pass in the animation using a Sprite or it's AssetId.
    /// </param>
    public TBuilder SetImage(Asset<Sprite> image)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Image = image?.Get();
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
    ///
    /// <param name="name">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetName(LocalString name)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Name = name?.LocalizedString;
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
    ///
    /// <param name="description">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetDescription(LocalString description)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Description = description?.LocalizedString;
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetSignatureAbilities(params Blueprint<BlueprintUnitFactReference>[] signatureAbilities)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SignatureAbilities = signatureAbilities.Select(bp => bp.Reference).ToArray();
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToSignatureAbilities(params Blueprint<BlueprintUnitFactReference>[] signatureAbilities)
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromSignatureAbilities(params Blueprint<BlueprintUnitFactReference>[] signatureAbilities)
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
    public TBuilder RemoveFromSignatureAbilities(Func<BlueprintUnitFactReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SignatureAbilities is null) { return; }
          bp.m_SignatureAbilities = bp.m_SignatureAbilities.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintUnitType.m_SignatureAbilities"/>
    /// </summary>
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
    public TBuilder ModifySignatureAbilities(Action<BlueprintUnitFactReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SignatureAbilities is null) { return; }
          bp.m_SignatureAbilities.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Name is null)
      {
        Blueprint.Name = Utils.Constants.Empty.String;
      }
      if (Blueprint.Description is null)
      {
        Blueprint.Description = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_SignatureAbilities is null)
      {
        Blueprint.m_SignatureAbilities = new BlueprintUnitFactReference[0];
      }
    }
  }
}
