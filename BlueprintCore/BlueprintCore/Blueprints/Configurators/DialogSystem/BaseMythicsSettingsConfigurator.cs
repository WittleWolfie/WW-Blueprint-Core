//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.Tutorial;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.DialogSystem
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintMythicsSettings"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseMythicsSettingsConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintMythicsSettings
    where TBuilder : BaseMythicsSettingsConfigurator<T, TBuilder>
  {
    protected BaseMythicsSettingsConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintMythicsSettings.m_MythicsInfos"/>
    /// </summary>
    ///
    /// <param name="mythicsInfos">
    /// <para>
    /// Blueprint of type BlueprintMythicInfo. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetMythicsInfos(params Blueprint<BlueprintMythicInfoReference>[] mythicsInfos)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MythicsInfos = mythicsInfos.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintMythicsSettings.m_MythicsInfos"/>
    /// </summary>
    ///
    /// <param name="mythicsInfos">
    /// <para>
    /// Blueprint of type BlueprintMythicInfo. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToMythicsInfos(params Blueprint<BlueprintMythicInfoReference>[] mythicsInfos)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MythicsInfos = bp.m_MythicsInfos ?? new BlueprintMythicInfoReference[0];
          bp.m_MythicsInfos = CommonTool.Append(bp.m_MythicsInfos, mythicsInfos.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintMythicsSettings.m_MythicsInfos"/>
    /// </summary>
    ///
    /// <param name="mythicsInfos">
    /// <para>
    /// Blueprint of type BlueprintMythicInfo. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromMythicsInfos(params Blueprint<BlueprintMythicInfoReference>[] mythicsInfos)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_MythicsInfos is null) { return; }
          bp.m_MythicsInfos = bp.m_MythicsInfos.Where(val => !mythicsInfos.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintMythicsSettings.m_MythicsInfos"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromMythicsInfos(Func<BlueprintMythicInfoReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_MythicsInfos is null) { return; }
          bp.m_MythicsInfos = bp.m_MythicsInfos.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintMythicsSettings.m_MythicsInfos"/>
    /// </summary>
    public TBuilder ClearMythicsInfos()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MythicsInfos = new BlueprintMythicInfoReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintMythicsSettings.m_MythicsInfos"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyMythicsInfos(Action<BlueprintMythicInfoReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_MythicsInfos is null) { return; }
          bp.m_MythicsInfos.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintMythicsSettings.m_MythicAlignments"/>
    /// </summary>
    public TBuilder SetMythicAlignments(params MythicAlignment[] mythicAlignments)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(mythicAlignments);
          bp.m_MythicAlignments = mythicAlignments;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintMythicsSettings.m_MythicAlignments"/>
    /// </summary>
    public TBuilder AddToMythicAlignments(params MythicAlignment[] mythicAlignments)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MythicAlignments = bp.m_MythicAlignments ?? new MythicAlignment[0];
          bp.m_MythicAlignments = CommonTool.Append(bp.m_MythicAlignments, mythicAlignments);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintMythicsSettings.m_MythicAlignments"/>
    /// </summary>
    public TBuilder RemoveFromMythicAlignments(params MythicAlignment[] mythicAlignments)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_MythicAlignments is null) { return; }
          bp.m_MythicAlignments = bp.m_MythicAlignments.Where(val => !mythicAlignments.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintMythicsSettings.m_MythicAlignments"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromMythicAlignments(Func<MythicAlignment, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_MythicAlignments is null) { return; }
          bp.m_MythicAlignments = bp.m_MythicAlignments.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintMythicsSettings.m_MythicAlignments"/>
    /// </summary>
    public TBuilder ClearMythicAlignments()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_MythicAlignments = new MythicAlignment[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintMythicsSettings.m_MythicAlignments"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyMythicAlignments(Action<MythicAlignment> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_MythicAlignments is null) { return; }
          bp.m_MythicAlignments.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintMythicsSettings.m_TutorialChooseMythic"/>
    /// </summary>
    ///
    /// <param name="tutorialChooseMythic">
    /// <para>
    /// Blueprint of type BlueprintTutorial. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetTutorialChooseMythic(Blueprint<BlueprintTutorial.Reference> tutorialChooseMythic)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TutorialChooseMythic = tutorialChooseMythic?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintMythicsSettings.m_TutorialChooseMythic"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTutorialChooseMythic(Action<BlueprintTutorial.Reference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TutorialChooseMythic is null) { return; }
          action.Invoke(bp.m_TutorialChooseMythic);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintMythicsSettings.CharcaterLevelRestrictions"/>
    /// </summary>
    public TBuilder SetCharcaterLevelRestrictions(params int[] charcaterLevelRestrictions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CharcaterLevelRestrictions = charcaterLevelRestrictions.ToList();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintMythicsSettings.CharcaterLevelRestrictions"/>
    /// </summary>
    public TBuilder AddToCharcaterLevelRestrictions(params int[] charcaterLevelRestrictions)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CharcaterLevelRestrictions = bp.CharcaterLevelRestrictions ?? new();
          bp.CharcaterLevelRestrictions.AddRange(charcaterLevelRestrictions);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintMythicsSettings.CharcaterLevelRestrictions"/>
    /// </summary>
    public TBuilder RemoveFromCharcaterLevelRestrictions(params int[] charcaterLevelRestrictions)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CharcaterLevelRestrictions is null) { return; }
          bp.CharcaterLevelRestrictions = bp.CharcaterLevelRestrictions.Where(val => !charcaterLevelRestrictions.Contains(val)).ToList();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintMythicsSettings.CharcaterLevelRestrictions"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromCharcaterLevelRestrictions(Func<int, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CharcaterLevelRestrictions is null) { return; }
          bp.CharcaterLevelRestrictions = bp.CharcaterLevelRestrictions.Where(e => !predicate(e)).ToList();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintMythicsSettings.CharcaterLevelRestrictions"/>
    /// </summary>
    public TBuilder ClearCharcaterLevelRestrictions()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.CharcaterLevelRestrictions = new();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintMythicsSettings.CharcaterLevelRestrictions"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyCharcaterLevelRestrictions(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.CharcaterLevelRestrictions is null) { return; }
          bp.CharcaterLevelRestrictions.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_MythicsInfos is null)
      {
        Blueprint.m_MythicsInfos = new BlueprintMythicInfoReference[0];
      }
      if (Blueprint.m_MythicAlignments is null)
      {
        Blueprint.m_MythicAlignments = new MythicAlignment[0];
      }
      if (Blueprint.m_TutorialChooseMythic is null)
      {
        Blueprint.m_TutorialChooseMythic = BlueprintTool.GetRef<BlueprintTutorial.Reference>(null);
      }
      if (Blueprint.CharcaterLevelRestrictions is null)
      {
        Blueprint.CharcaterLevelRestrictions = new();
      }
    }
  }
}
