//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
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
    protected BaseCompanionStoryConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetCompanion(Blueprint<BlueprintUnitReference> companion)
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
    public TBuilder SetImageLink(AssetLink<SpriteLink> imageLink)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_ImageLink = imageLink?.Get();
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

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Companion is null)
      {
        Blueprint.m_Companion = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      if (Blueprint.Title is null)
      {
        Blueprint.Title = Utils.Constants.Empty.String;
      }
      if (Blueprint.Description is null)
      {
        Blueprint.Description = Utils.Constants.Empty.String;
      }
    }
  }
}
