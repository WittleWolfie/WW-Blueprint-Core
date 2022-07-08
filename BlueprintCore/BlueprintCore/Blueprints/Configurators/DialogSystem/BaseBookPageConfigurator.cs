//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintBookPage"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseBookPageConfigurator<T, TBuilder>
    : BaseCueBaseConfigurator<T, TBuilder>
    where T : BlueprintBookPage
    where TBuilder : BaseBookPageConfigurator<T, TBuilder>
  {
    protected BaseBookPageConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintBookPage.Cues"/>
    /// </summary>
    ///
    /// <param name="cues">
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
    public TBuilder SetCues(params Blueprint<BlueprintCueBaseReference>[] cues)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Cues = cues.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintBookPage.Cues"/>
    /// </summary>
    ///
    /// <param name="cues">
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
    public TBuilder AddToCues(params Blueprint<BlueprintCueBaseReference>[] cues)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Cues = bp.Cues ?? new();
          bp.Cues.AddRange(cues.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintBookPage.Cues"/>
    /// </summary>
    ///
    /// <param name="cues">
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
    public TBuilder RemoveFromCues(params Blueprint<BlueprintCueBaseReference>[] cues)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Cues is null) { return; }
          bp.Cues = bp.Cues.Where(val => !cues.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintBookPage.Cues"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCues(Func<BlueprintCueBaseReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Cues is null) { return; }
          bp.Cues = bp.Cues.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintBookPage.Cues"/>
    /// </summary>
    public TBuilder ClearCues()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Cues = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintBookPage.Cues"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCues(Action<BlueprintCueBaseReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Cues is null) { return; }
          bp.Cues.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintBookPage.Answers"/>
    /// </summary>
    ///
    /// <param name="answers">
    /// <para>
    /// Blueprint of type BlueprintAnswerBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetAnswers(params Blueprint<BlueprintAnswerBaseReference>[] answers)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Answers = answers.Select(bp => bp.Reference).ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintBookPage.Answers"/>
    /// </summary>
    ///
    /// <param name="answers">
    /// <para>
    /// Blueprint of type BlueprintAnswerBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToAnswers(params Blueprint<BlueprintAnswerBaseReference>[] answers)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Answers = bp.Answers ?? new();
          bp.Answers.AddRange(answers.Select(bp => bp.Reference));
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintBookPage.Answers"/>
    /// </summary>
    ///
    /// <param name="answers">
    /// <para>
    /// Blueprint of type BlueprintAnswerBase. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromAnswers(params Blueprint<BlueprintAnswerBaseReference>[] answers)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Answers is null) { return; }
          bp.Answers = bp.Answers.Where(val => !answers.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintBookPage.Answers"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromAnswers(Func<BlueprintAnswerBaseReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Answers is null) { return; }
          bp.Answers = bp.Answers.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintBookPage.Answers"/>
    /// </summary>
    public TBuilder ClearAnswers()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Answers = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintBookPage.Answers"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyAnswers(Action<BlueprintAnswerBaseReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Answers is null) { return; }
          bp.Answers.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintBookPage.OnShow"/>
    /// </summary>
    public TBuilder SetOnShow(ActionsBuilder onShow)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OnShow = onShow?.Build();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintBookPage.OnShow"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyOnShow(Action<ActionList> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.OnShow is null) { return; }
          action.Invoke(bp.OnShow);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintBookPage.ImageLink"/>
    /// </summary>
    public TBuilder SetImageLink(SpriteLink imageLink)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(imageLink);
          bp.ImageLink = imageLink;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintBookPage.ImageLink"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyImageLink(Action<SpriteLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ImageLink is null) { return; }
          action.Invoke(bp.ImageLink);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintBookPage.ForeImageLink"/>
    /// </summary>
    public TBuilder SetForeImageLink(SpriteLink foreImageLink)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(foreImageLink);
          bp.ForeImageLink = foreImageLink;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintBookPage.ForeImageLink"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyForeImageLink(Action<SpriteLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ForeImageLink is null) { return; }
          action.Invoke(bp.ForeImageLink);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintBookPage.Title"/>
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
    /// Modifies <see cref="BlueprintBookPage.Title"/> by invoking the provided action.
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

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Cues is null)
      {
        Blueprint.Cues = new();
      }
      if (Blueprint.Answers is null)
      {
        Blueprint.Answers = new();
      }
      if (Blueprint.OnShow is null)
      {
        Blueprint.OnShow = Utils.Constants.Empty.Actions;
      }
      if (Blueprint.Title is null)
      {
        Blueprint.Title = Utils.Constants.Empty.String;
      }
    }
  }
}
