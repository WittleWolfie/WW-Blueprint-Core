//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.BarkBanters;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.BarkBanters
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintBarkBanter"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseBarkBanterConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintBarkBanter
    where TBuilder : BaseBarkBanterConfigurator<T, TBuilder>
  {
    protected BaseBarkBanterConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintBarkBanter>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_SpeakerType = copyFrom.m_SpeakerType;
          bp.m_Unit = copyFrom.m_Unit;
          bp.Conditions = copyFrom.Conditions;
          bp.m_Weight = copyFrom.m_Weight;
          bp.FirstPhrase = copyFrom.FirstPhrase;
          bp.Responses = copyFrom.Responses;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintBarkBanter>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.m_SpeakerType = copyFrom.m_SpeakerType;
          bp.m_Unit = copyFrom.m_Unit;
          bp.Conditions = copyFrom.Conditions;
          bp.m_Weight = copyFrom.m_Weight;
          bp.FirstPhrase = copyFrom.FirstPhrase;
          bp.Responses = copyFrom.Responses;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintBarkBanter.m_SpeakerType"/>
    /// </summary>
    public TBuilder SetSpeakerType(SpeakerType speakerType)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SpeakerType = speakerType;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintBarkBanter.m_Unit"/>
    /// </summary>
    ///
    /// <param name="unit">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetUnit(Blueprint<BlueprintUnitReference> unit)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Unit = unit?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintBarkBanter.m_Unit"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyUnit(Action<BlueprintUnitReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Unit is null) { return; }
          action.Invoke(bp.m_Unit);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintBarkBanter.Conditions"/>
    /// </summary>
    public TBuilder SetConditions(BanterConditions conditions)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(conditions);
          bp.Conditions = conditions;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintBarkBanter.Conditions"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyConditions(Action<BanterConditions> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Conditions is null) { return; }
          action.Invoke(bp.Conditions);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintBarkBanter.m_Weight"/>
    /// </summary>
    public TBuilder SetWeight(float weight)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Weight = weight;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintBarkBanter.FirstPhrase"/>
    /// </summary>
    ///
    /// <param name="firstPhrase">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetFirstPhrase(params LocalString[] firstPhrase)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FirstPhrase = firstPhrase?.Select(entry => entry?.LocalizedString)?.ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintBarkBanter.FirstPhrase"/>
    /// </summary>
    ///
    /// <param name="firstPhrase">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder AddToFirstPhrase(params LocalString[] firstPhrase)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FirstPhrase = bp.FirstPhrase ?? new LocalizedString[0];
          bp.FirstPhrase = CommonTool.Append(bp.FirstPhrase, firstPhrase?.Select(entry => entry?.LocalizedString).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintBarkBanter.FirstPhrase"/>
    /// </summary>
    ///
    /// <param name="firstPhrase">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder RemoveFromFirstPhrase(params LocalString[] firstPhrase)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FirstPhrase is null) { return; }
          var convertedParams = firstPhrase.Select(entry => entry?.LocalizedString);
          bp.FirstPhrase = bp.FirstPhrase.Where(val => !convertedParams.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintBarkBanter.FirstPhrase"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromFirstPhrase(Func<LocalizedString, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FirstPhrase is null) { return; }
          bp.FirstPhrase = bp.FirstPhrase.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintBarkBanter.FirstPhrase"/>
    /// </summary>
    public TBuilder ClearFirstPhrase()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.FirstPhrase = new LocalizedString[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintBarkBanter.FirstPhrase"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyFirstPhrase(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.FirstPhrase is null) { return; }
          bp.FirstPhrase.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintBarkBanter.Responses"/>
    /// </summary>
    public TBuilder SetResponses(params BlueprintBarkBanter.BanterResponseEntry[] responses)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(responses);
          bp.Responses = responses;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintBarkBanter.Responses"/>
    /// </summary>
    public TBuilder AddToResponses(params BlueprintBarkBanter.BanterResponseEntry[] responses)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Responses = bp.Responses ?? new BlueprintBarkBanter.BanterResponseEntry[0];
          bp.Responses = CommonTool.Append(bp.Responses, responses);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintBarkBanter.Responses"/>
    /// </summary>
    public TBuilder RemoveFromResponses(params BlueprintBarkBanter.BanterResponseEntry[] responses)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Responses is null) { return; }
          bp.Responses = bp.Responses.Where(val => !responses.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintBarkBanter.Responses"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromResponses(Func<BlueprintBarkBanter.BanterResponseEntry, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Responses is null) { return; }
          bp.Responses = bp.Responses.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintBarkBanter.Responses"/>
    /// </summary>
    public TBuilder ClearResponses()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Responses = new BlueprintBarkBanter.BanterResponseEntry[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintBarkBanter.Responses"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyResponses(Action<BlueprintBarkBanter.BanterResponseEntry> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Responses is null) { return; }
          bp.Responses.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Unit is null)
      {
        Blueprint.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      if (Blueprint.FirstPhrase is null)
      {
        Blueprint.FirstPhrase = new LocalizedString[0];
      }
      if (Blueprint.Responses is null)
      {
        Blueprint.Responses = new BlueprintBarkBanter.BanterResponseEntry[0];
      }
    }
  }
}
