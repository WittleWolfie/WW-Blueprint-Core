//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Quests;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Quests
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintQuestGroups"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseQuestGroupsConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintQuestGroups
    where TBuilder : BaseQuestGroupsConfigurator<T, TBuilder>
  {
    protected BaseQuestGroupsConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintQuestGroups>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Groups = copyFrom.Groups;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintQuestGroups>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Groups = copyFrom.Groups;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintQuestGroups.Groups"/>
    /// </summary>
    public TBuilder SetGroups(params QuestGroup[] groups)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(groups);
          bp.Groups = groups;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintQuestGroups.Groups"/>
    /// </summary>
    public TBuilder AddToGroups(params QuestGroup[] groups)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Groups = bp.Groups ?? new QuestGroup[0];
          bp.Groups = CommonTool.Append(bp.Groups, groups);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintQuestGroups.Groups"/>
    /// </summary>
    public TBuilder RemoveFromGroups(params QuestGroup[] groups)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Groups is null) { return; }
          bp.Groups = bp.Groups.Where(val => !groups.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintQuestGroups.Groups"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromGroups(Func<QuestGroup, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Groups is null) { return; }
          bp.Groups = bp.Groups.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintQuestGroups.Groups"/>
    /// </summary>
    public TBuilder ClearGroups()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Groups = new QuestGroup[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuestGroups.Groups"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyGroups(Action<QuestGroup> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Groups is null) { return; }
          bp.Groups.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Groups is null)
      {
        Blueprint.Groups = new QuestGroup[0];
      }
    }
  }
}
