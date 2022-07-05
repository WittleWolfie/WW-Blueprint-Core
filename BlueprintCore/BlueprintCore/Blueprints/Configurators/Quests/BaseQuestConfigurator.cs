//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Experience;
using Kingmaker.Blueprints.Quests;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Quests
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintQuest"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseQuestConfigurator<T, TBuilder>
    : BaseFactConfigurator<T, TBuilder>
    where T : BlueprintQuest
    where TBuilder : BaseQuestConfigurator<T, TBuilder>
  {
    protected BaseQuestConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintQuest.Description"/>
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
    /// Modifies <see cref="BlueprintQuest.Description"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintQuest.Title"/>
    /// </summary>
    ///
    /// <param name="title">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetTitle(LocalString title)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Title = title?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuest.Title"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTitle(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Title is null) { return; }
          action.Invoke(bp.Title);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintQuest.CompletionText"/>
    /// </summary>
    ///
    /// <param name="completionText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetCompletionText(LocalString completionText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CompletionText = completionText?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuest.CompletionText"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCompletionText(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CompletionText is null) { return; }
          action.Invoke(bp.CompletionText);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintQuest.m_Group"/>
    /// </summary>
    public TBuilder SetGroup(QuestGroupId group)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Group = group;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintQuest.m_DescriptionPriority"/>
    /// </summary>
    public TBuilder SetDescriptionPriority(int descriptionPriority)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DescriptionPriority = descriptionPriority;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintQuest.m_Type"/>
    /// </summary>
    public TBuilder SetType(QuestType type)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Type = type;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintQuest.m_LastChapter"/>
    /// </summary>
    public TBuilder SetLastChapter(int lastChapter)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_LastChapter = lastChapter;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintQuest.m_Objectives"/>
    /// </summary>
    ///
    /// <param name="objectives">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetObjectives(params Blueprint<BlueprintQuestObjectiveReference>[] objectives)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Objectives = objectives.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintQuest.m_Objectives"/>
    /// </summary>
    ///
    /// <param name="objectives">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToObjectives(params Blueprint<BlueprintQuestObjectiveReference>[] objectives)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Objectives = bp.m_Objectives ?? new();
          bp.m_Objectives.AddRange(objectives.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintQuest.m_Objectives"/>
    /// </summary>
    ///
    /// <param name="objectives">
    /// <para>
    /// Blueprint of type BlueprintQuestObjective. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromObjectives(params Blueprint<BlueprintQuestObjectiveReference>[] objectives)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Objectives is null) { return; }
          bp.m_Objectives = bp.m_Objectives.Where(val => !objectives.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintQuest.m_Objectives"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromObjectives(Func<BlueprintQuestObjectiveReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Objectives is null) { return; }
          bp.m_Objectives = bp.m_Objectives.Where(predicate).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintQuest.m_Objectives"/>
    /// </summary>
    public TBuilder ClearObjectives()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Objectives = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintQuest.m_Objectives"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyObjectives(Action<BlueprintQuestObjectiveReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Objectives is null) { return; }
          bp.m_Objectives.ForEach(action);
        });
    }

    /// <summary>
    /// Adds <see cref="Experience"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>00_FindEchoLair</term><description>876fc5d40aa5d8b47ac0138cf0a680ae</description></item>
    /// <item><term>CR7_GhoulHuntmaster_RangerRanged</term><description>e884bd90f8936a743ac534bba620c549</description></item>
    /// <item><term>Ziforian_normal</term><description>7ef2998dbeb7fda43a47ce842f4d142d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="playerGainsNoExp">
    /// <para>
    /// InfoBox: When true, Exp will be used in encounter CR calculation, but player will not gained it
    /// </para>
    /// </param>
    public TBuilder AddExperience(
        IntEvaluator? count = null,
        int? cR = null,
        bool? dummy = null,
        EncounterType? encounter = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        float? modifier = null,
        bool? playerGainsNoExp = null)
    {
      var component = new Experience();
      Validate(count);
      component.Count = count ?? component.Count;
      component.CR = cR ?? component.CR;
      component.Dummy = dummy ?? component.Dummy;
      component.Encounter = encounter ?? component.Encounter;
      component.Modifier = modifier ?? component.Modifier;
      component.PlayerGainsNoExp = playerGainsNoExp ?? component.PlayerGainsNoExp;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Description is null)
      {
        Blueprint.Description = Utils.Constants.Empty.String;
      }
      if (Blueprint.Title is null)
      {
        Blueprint.Title = Utils.Constants.Empty.String;
      }
      if (Blueprint.CompletionText is null)
      {
        Blueprint.CompletionText = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_Objectives is null)
      {
        Blueprint.m_Objectives = new();
      }
    }
  }
}
