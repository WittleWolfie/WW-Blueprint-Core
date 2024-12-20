//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.Configurators.Kingdom;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Quests;
using Kingmaker.ElementsSystem;
using Kingmaker.Kingdom;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Kingdom
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintKingdomEvent"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseKingdomEventConfigurator<T, TBuilder>
    : BaseKingdomEventBaseConfigurator<T, TBuilder>
    where T : BlueprintKingdomEvent
    where TBuilder : BaseKingdomEventConfigurator<T, TBuilder>
  {
    protected BaseKingdomEventConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintKingdomEvent>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.IsOpportunity = copyFrom.IsOpportunity;
          bp.ForceOneTimeOnly = copyFrom.ForceOneTimeOnly;
          bp.m_DependsOnQuest = copyFrom.m_DependsOnQuest;
          bp.m_Tags = copyFrom.m_Tags;
          bp.RequiredTags = copyFrom.RequiredTags;
          bp.OnTrigger = copyFrom.OnTrigger;
          bp.StatsOnTrigger = copyFrom.StatsOnTrigger;
          bp.UnapplyTriggerOnResolve = copyFrom.UnapplyTriggerOnResolve;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintKingdomEvent>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.IsOpportunity = copyFrom.IsOpportunity;
          bp.ForceOneTimeOnly = copyFrom.ForceOneTimeOnly;
          bp.m_DependsOnQuest = copyFrom.m_DependsOnQuest;
          bp.m_Tags = copyFrom.m_Tags;
          bp.RequiredTags = copyFrom.RequiredTags;
          bp.OnTrigger = copyFrom.OnTrigger;
          bp.StatsOnTrigger = copyFrom.StatsOnTrigger;
          bp.UnapplyTriggerOnResolve = copyFrom.UnapplyTriggerOnResolve;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomEvent.IsOpportunity"/>
    /// </summary>
    public TBuilder SetIsOpportunity(bool isOpportunity = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsOpportunity = isOpportunity;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomEvent.ForceOneTimeOnly"/>
    /// </summary>
    public TBuilder SetForceOneTimeOnly(bool forceOneTimeOnly = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ForceOneTimeOnly = forceOneTimeOnly;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomEvent.m_DependsOnQuest"/>
    /// </summary>
    ///
    /// <param name="dependsOnQuest">
    /// <para>
    /// Blueprint of type BlueprintQuest. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetDependsOnQuest(Blueprint<BlueprintQuestReference> dependsOnQuest)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DependsOnQuest = dependsOnQuest?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomEvent.m_DependsOnQuest"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDependsOnQuest(Action<BlueprintQuestReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DependsOnQuest is null) { return; }
          action.Invoke(bp.m_DependsOnQuest);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomEvent.m_Tags"/>
    /// </summary>
    public TBuilder SetTags(BlueprintKingdomEvent.TagList tags)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(tags);
          bp.m_Tags = tags;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomEvent.m_Tags"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTags(Action<BlueprintKingdomEvent.TagList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Tags is null) { return; }
          action.Invoke(bp.m_Tags);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomEvent.RequiredTags"/>
    /// </summary>
    public TBuilder SetRequiredTags(EventLocationTagList requiredTags)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(requiredTags);
          bp.RequiredTags = requiredTags;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomEvent.RequiredTags"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyRequiredTags(Action<EventLocationTagList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RequiredTags is null) { return; }
          action.Invoke(bp.RequiredTags);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomEvent.OnTrigger"/>
    /// </summary>
    public TBuilder SetOnTrigger(ActionsBuilder onTrigger)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OnTrigger = onTrigger?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomEvent.OnTrigger"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOnTrigger(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OnTrigger is null) { return; }
          action.Invoke(bp.OnTrigger);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomEvent.StatsOnTrigger"/>
    /// </summary>
    public TBuilder SetStatsOnTrigger(KingdomStats.Changes statsOnTrigger)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(statsOnTrigger);
          bp.StatsOnTrigger = statsOnTrigger;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintKingdomEvent.StatsOnTrigger"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyStatsOnTrigger(Action<KingdomStats.Changes> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.StatsOnTrigger is null) { return; }
          action.Invoke(bp.StatsOnTrigger);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintKingdomEvent.UnapplyTriggerOnResolve"/>
    /// </summary>
    public TBuilder SetUnapplyTriggerOnResolve(bool unapplyTriggerOnResolve = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.UnapplyTriggerOnResolve = unapplyTriggerOnResolve;
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_DependsOnQuest is null)
      {
        Blueprint.m_DependsOnQuest = BlueprintTool.GetRef<BlueprintQuestReference>(null);
      }
      if (Blueprint.OnTrigger is null)
      {
        Blueprint.OnTrigger = Utils.Constants.Empty.Actions;
      }
    }
  }
}
