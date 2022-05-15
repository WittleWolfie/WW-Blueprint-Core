//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using System;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCompanionStory"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCompanionStoryConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintCompanionStory
    where TBuilder : BaseCompanionStoryConfigurator<T, TBuilder>
  {
    protected BaseCompanionStoryConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCompanionStory.m_Companion"/>
    /// </summary>
    ///
    /// <param name="companion">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetCompanion(Blueprint<BlueprintUnit, BlueprintUnitReference> companion)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Companion = companion?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCompanionStory.m_Companion"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="companion">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Utils.Blueprint{T, TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyCompanion(Action<BlueprintUnitReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Companion is null) { return; }
          action.Invoke(bp.m_Companion);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCompanionStory.Title"/>
    /// </summary>
    public TBuilder SetTitle(LocalizedString title)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Title = title;
          if (bp.Title is null)
          {
            bp.Title = Utils.Constants.Empty.String;
          }
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCompanionStory.Title"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintCompanionStory.Description"/>
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
    /// Modifies <see cref="BlueprintCompanionStory.Description"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintCompanionStory.m_ImageLink"/>
    /// </summary>
    public TBuilder SetImageLink(SpriteLink imageLink)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(imageLink);
          bp.m_ImageLink = imageLink;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCompanionStory.m_ImageLink"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyImageLink(Action<SpriteLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_ImageLink is null) { return; }
          action.Invoke(bp.m_ImageLink);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCompanionStory.Gender"/>
    /// </summary>
    public TBuilder SetGender(Gender gender)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Gender = gender;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCompanionStory.Gender"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyGender(Action<Gender> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Gender);
        });
    }
  }
}
