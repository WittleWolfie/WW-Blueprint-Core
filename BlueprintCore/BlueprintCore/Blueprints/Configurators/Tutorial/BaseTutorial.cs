//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using Kingmaker.PubSubSystem;
using Kingmaker.ResourceLinks;
using Kingmaker.RuleSystem;
using Kingmaker.Settings;
using Kingmaker.Tutorial;
using Kingmaker.Tutorial.Solvers;
using Kingmaker.Tutorial.Triggers;
using Kingmaker.UI.Kingdom;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Buffs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Tutorial
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintTutorial"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseTutorialConfigurator<T, TBuilder>
    : BaseFactConfigurator<T, TBuilder>
    where T : BlueprintTutorial
    where TBuilder : BaseTutorialConfigurator<T, TBuilder>
  {
    protected BaseTutorialConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTutorial.m_Picture"/>
    /// </summary>
    public TBuilder SetPicture(SpriteLink picture)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(picture);
          bp.m_Picture = picture;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTutorial.m_Picture"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPicture(Action<SpriteLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Picture is null) { return; }
          action.Invoke(bp.m_Picture);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTutorial.m_Video"/>
    /// </summary>
    public TBuilder SetVideo(VideoLink video)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(video);
          bp.m_Video = video;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTutorial.m_Video"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyVideo(Action<VideoLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Video is null) { return; }
          action.Invoke(bp.m_Video);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTutorial.m_TitleText"/>
    /// </summary>
    ///
    /// <param name="titleText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetTitleText(LocalString titleText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TitleText = titleText?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTutorial.m_TitleText"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTitleText(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TitleText is null) { return; }
          action.Invoke(bp.m_TitleText);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTutorial.m_TriggerText"/>
    /// </summary>
    ///
    /// <param name="triggerText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetTriggerText(LocalString triggerText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_TriggerText = triggerText?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTutorial.m_TriggerText"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTriggerText(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_TriggerText is null) { return; }
          action.Invoke(bp.m_TriggerText);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTutorial.m_DescriptionText"/>
    /// </summary>
    ///
    /// <param name="descriptionText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetDescriptionText(LocalString descriptionText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_DescriptionText = descriptionText?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTutorial.m_DescriptionText"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDescriptionText(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DescriptionText is null) { return; }
          action.Invoke(bp.m_DescriptionText);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTutorial.m_SolutionFoundText"/>
    /// </summary>
    ///
    /// <param name="solutionFoundText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetSolutionFoundText(LocalString solutionFoundText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SolutionFoundText = solutionFoundText?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTutorial.m_SolutionFoundText"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySolutionFoundText(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SolutionFoundText is null) { return; }
          action.Invoke(bp.m_SolutionFoundText);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTutorial.m_SolutionNotFoundText"/>
    /// </summary>
    ///
    /// <param name="solutionNotFoundText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder SetSolutionNotFoundText(LocalString solutionNotFoundText)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_SolutionNotFoundText = solutionNotFoundText?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTutorial.m_SolutionNotFoundText"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySolutionNotFoundText(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_SolutionNotFoundText is null) { return; }
          action.Invoke(bp.m_SolutionNotFoundText);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTutorial.Tag"/>
    /// </summary>
    public TBuilder SetTag(TutorialTag tag)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Tag = tag;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTutorial.Tag"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyTag(Action<TutorialTag> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Tag);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTutorial.Priority"/>
    /// </summary>
    public TBuilder SetPriority(int priority)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Priority = priority;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTutorial.Priority"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPriority(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Priority);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTutorial.Limit"/>
    /// </summary>
    public TBuilder SetLimit(int limit)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Limit = limit;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTutorial.Limit"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLimit(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Limit);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTutorial.Frequency"/>
    /// </summary>
    public TBuilder SetFrequency(int frequency)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Frequency = frequency;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTutorial.Frequency"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFrequency(Action<int> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Frequency);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTutorial.SetCooldown"/>
    /// </summary>
    public TBuilder SetSetCooldown(bool setCooldown = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SetCooldown = setCooldown;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTutorial.SetCooldown"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySetCooldown(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.SetCooldown);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTutorial.IgnoreCooldown"/>
    /// </summary>
    public TBuilder SetIgnoreCooldown(bool ignoreCooldown = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IgnoreCooldown = ignoreCooldown;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTutorial.IgnoreCooldown"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIgnoreCooldown(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.IgnoreCooldown);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTutorial.Windowed"/>
    /// </summary>
    public TBuilder SetWindowed(bool windowed = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Windowed = windowed;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTutorial.Windowed"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyWindowed(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Windowed);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTutorial.DisableAnalyticsTracking"/>
    /// </summary>
    public TBuilder SetDisableAnalyticsTracking(bool disableAnalyticsTracking = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.DisableAnalyticsTracking = disableAnalyticsTracking;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTutorial.DisableAnalyticsTracking"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDisableAnalyticsTracking(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.DisableAnalyticsTracking);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintTutorial.EncyclopediaReference"/>
    /// </summary>
    ///
    /// <param name="encyclopediaReference">
    /// <para>
    /// Blueprint of type BlueprintEncyclopediaPage. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetEncyclopediaReference(Blueprint<BlueprintEncyclopediaPageReference> encyclopediaReference)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.EncyclopediaReference = encyclopediaReference?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintTutorial.EncyclopediaReference"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyEncyclopediaReference(Action<BlueprintEncyclopediaPageReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.EncyclopediaReference is null) { return; }
          action.Invoke(bp.EncyclopediaReference);
        });
    }

    /// <summary>
    /// Adds <see cref="TutorialPage"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CrusadeTutorial_01_Chapter2Intro</term><description>20073002e0594c88b5af911060e8dde8</description></item>
    /// <item><term>NewTutorial_18_LevelUp_1</term><description>879d9dfee7ddcdd458738e817e3a0913</description></item>
    /// <item><term>TestTutorialSC</term><description>2e48c8330634d544489e1fc14ccf5eaa</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="descriptionText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    /// <param name="solutionFoundText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    /// <param name="solutionNotFoundText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    /// <param name="titleText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    /// <param name="triggerText">
    /// You can pass in the string using a LocalizedString or the Key to a LocalizedString.
    /// </param>
    public TBuilder AddTutorialPage(
        LocalString? descriptionText = null,
        SpriteLink? picture = null,
        LocalString? solutionFoundText = null,
        LocalString? solutionNotFoundText = null,
        LocalString? titleText = null,
        LocalString? triggerText = null,
        VideoLink? video = null)
    {
      var component = new TutorialPage();
      component.m_DescriptionText = descriptionText?.LocalizedString ?? component.m_DescriptionText;
      if (component.m_DescriptionText is null)
      {
        component.m_DescriptionText = Utils.Constants.Empty.String;
      }
      Validate(picture);
      component.m_Picture = picture ?? component.m_Picture;
      component.m_SolutionFoundText = solutionFoundText?.LocalizedString ?? component.m_SolutionFoundText;
      if (component.m_SolutionFoundText is null)
      {
        component.m_SolutionFoundText = Utils.Constants.Empty.String;
      }
      component.m_SolutionNotFoundText = solutionNotFoundText?.LocalizedString ?? component.m_SolutionNotFoundText;
      if (component.m_SolutionNotFoundText is null)
      {
        component.m_SolutionNotFoundText = Utils.Constants.Empty.String;
      }
      component.m_TitleText = titleText?.LocalizedString ?? component.m_TitleText;
      if (component.m_TitleText is null)
      {
        component.m_TitleText = Utils.Constants.Empty.String;
      }
      component.m_TriggerText = triggerText?.LocalizedString ?? component.m_TriggerText;
      if (component.m_TriggerText is null)
      {
        component.m_TriggerText = Utils.Constants.Empty.String;
      }
      Validate(video);
      component.m_Video = video ?? component.m_Video;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerAbilityDamage"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_AbilityDamage</term><description>f579133d7ad865e488551b7aa59c22da</description></item>
    /// <item><term>ContextTutor_AbilityDrain</term><description>7563689f6640b8d40a085fa47c3e375d</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerAbilityDamage(
        DirectlyControllableUnitRequirement? directlyControllableRequirement = null,
        bool? drain = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerAbilityDamage();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement ?? component.m_DirectlyControllableRequirement;
      component.Drain = drain ?? component.Drain;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerAffectedByAreaEffect"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_GazeAttack</term><description>937f0e8f22668324fa20364602960371</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="needAllDescriptors">
    /// <para>
    /// InfoBox: If NeedAllDescriptors is true, only buff that has all listed flags will trigger
    /// </para>
    /// </param>
    public TBuilder AddTutorialTriggerAffectedByAreaEffect(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? needAllDescriptors = null,
        SpellDescriptorWrapper? spellDescriptors = null)
    {
      var component = new TutorialTriggerAffectedByAreaEffect();
      component.NeedAllDescriptors = needAllDescriptors ?? component.NeedAllDescriptors;
      component.SpellDescriptors = spellDescriptors ?? component.SpellDescriptors;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerArcaneSpellFailure"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_ArcaneSpellFailure</term><description>0e7a6a6eb3147db49b4002b612eae140</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerArcaneSpellFailure(
        DirectlyControllableUnitRequirement? directlyControllableRequirement = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerArcaneSpellFailure();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement ?? component.m_DirectlyControllableRequirement;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerAreaLoaded"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CrusadeTutorial_01_Chapter2Intro</term><description>20073002e0594c88b5af911060e8dde8</description></item>
    /// <item><term>CrusadeTutorial_08_Chapter3Intro</term><description>ee3f047c2d2444dc9a85a699ff2bb276</description></item>
    /// <item><term>CrusadeTutorial_14_Buildings</term><description>659b920f412b46b08ab4e66824a7092b</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="area">
    /// <para>
    /// Blueprint of type BlueprintArea. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="condition">
    /// <para>
    /// InfoBox: Always true if empty
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerAreaLoaded(
        Blueprint<BlueprintAreaReference>? area = null,
        ConditionsBuilder? condition = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerAreaLoaded();
      component.m_Area = area?.Reference ?? component.m_Area;
      if (component.m_Area is null)
      {
        component.m_Area = BlueprintTool.GetRef<BlueprintAreaReference>(null);
      }
      component.m_Condition = condition?.Build() ?? component.m_Condition;
      if (component.m_Condition is null)
      {
        component.m_Condition = Utils.Constants.Empty.Conditions;
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerArmorCheckPenalty"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_ArmorCheckPenalty</term><description>dc7226dcd63977d42b861d73ad022a3f</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerArmorCheckPenalty(
        DirectlyControllableUnitRequirement? directlyControllableRequirement = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        float? penaltyTriggerPercent = null)
    {
      var component = new TutorialTriggerArmorCheckPenalty();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement ?? component.m_DirectlyControllableRequirement;
      component.PenaltyTriggerPercent = penaltyTriggerPercent ?? component.PenaltyTriggerPercent;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerArmorDexBonusLimiter"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_ArmorDexMax</term><description>c18bccb5f78f1f746b08228a4595fa51</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerArmorDexBonusLimiter(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerArmorDexBonusLimiter();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerAttackFlatFootedTarget"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_Flatfooted</term><description>cb7d9217140d86e48a1dbfba3ec3aca0</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerAttackFlatFootedTarget(
        DirectlyControllableUnitRequirement? directlyControllableRequirement = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerAttackFlatFootedTarget();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement ?? component.m_DirectlyControllableRequirement;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerAttackOfOpportunity"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_AttackOfOpportunity</term><description>56d0021901fa25f438471cccf846cf4a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerAttackOfOpportunity(
        DirectlyControllableUnitRequirement? directlyControllableRequirement = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerAttackOfOpportunity();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement ?? component.m_DirectlyControllableRequirement;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerBuffAttached"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_Desease</term><description>de6fa33eaf681c2429fa99bc428ab7c4</description></item>
    /// <item><term>ContextTutor_Poison</term><description>3c0c62694dcaab14e8818ac99f096102</description></item>
    /// <item><term>RestTutorial_Corruption</term><description>ec681e0ed44142409e534c3b0d259a42</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="buffs">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="needAllDescriptors">
    /// <para>
    /// InfoBox: If NeedAllDescriptors is true, only buff that has all listed flags will trigger
    /// </para>
    /// </param>
    public TBuilder AddTutorialTriggerBuffAttached(
        List<Blueprint<BlueprintBuffReference>>? buffs = null,
        bool? fromList = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? needAllDescriptors = null,
        SpellDescriptorWrapper? triggerDescriptors = null)
    {
      var component = new TutorialTriggerBuffAttached();
      component.Buffs = buffs?.Select(bp => bp.Reference)?.ToArray() ?? component.Buffs;
      if (component.Buffs is null)
      {
        component.Buffs = new BlueprintBuffReference[0];
      }
      component.FromList = fromList ?? component.FromList;
      component.NeedAllDescriptors = needAllDescriptors ?? component.NeedAllDescriptors;
      component.TriggerDescriptors = triggerDescriptors ?? component.TriggerDescriptors;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerCanBuffAlly"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_PrebuffAttack</term><description>cb79e63a2ac83a340bccccdbd2a2ee33</description></item>
    /// <item><term>ContextTutor_PrebuffDefense</term><description>d91ffc01754561848aeb11f8e6b35f18</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="ability">
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="checkTankStat">
    /// <para>
    /// InfoBox: Check if stat modificator from abilityBuff is greater than current modificator on top-AC unit (Tank) Designed for Barkskin buff. Could work badly with some specific stat modifiers. Contact Dev, if not sure
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="triggerAreas">
    /// <para>
    /// Blueprint of type BlueprintArea. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddTutorialTriggerCanBuffAlly(
        Blueprint<BlueprintAbilityReference>? ability = null,
        bool? allowItemsWithSpell = null,
        bool? checkTankStat = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        List<Blueprint<BlueprintAreaReference>>? triggerAreas = null)
    {
      var component = new TutorialTriggerCanBuffAlly();
      component.m_Ability = ability?.Reference ?? component.m_Ability;
      if (component.m_Ability is null)
      {
        component.m_Ability = BlueprintTool.GetRef<BlueprintAbilityReference>(null);
      }
      component.m_AllowItemsWithSpell = allowItemsWithSpell ?? component.m_AllowItemsWithSpell;
      component.m_CheckTankStat = checkTankStat ?? component.m_CheckTankStat;
      component.m_TriggerAreas = triggerAreas?.Select(bp => bp.Reference)?.ToArray() ?? component.m_TriggerAreas;
      if (component.m_TriggerAreas is null)
      {
        component.m_TriggerAreas = new BlueprintAreaReference[0];
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerCanReadScrollByNPC"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_ScrollNPC</term><description>4865ca21602b9054da69fd6af0eda6e1</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="scrolls">
    /// <para>
    /// Blueprint of type BlueprintItemEquipmentUsable. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddTutorialTriggerCanReadScrollByNPC(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        List<Blueprint<BlueprintItemEquipmentUsableReference>>? scrolls = null)
    {
      var component = new TutorialTriggerCanReadScrollByNPC();
      component.m_Scrolls = scrolls?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Scrolls;
      if (component.m_Scrolls is null)
      {
        component.m_Scrolls = new BlueprintItemEquipmentUsableReference[0];
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerConditionImmunity"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_ConditionImmunity</term><description>2970e3a83ece7214fb13c72dbdf9e911</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerConditionImmunity(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerConditionImmunity();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerCriticalHit"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_CriticalIncoming</term><description>da26a1bc56e6f0041a8aabb7fa7a2b65</description></item>
    /// <item><term>ContextTutor_CriticalOutgoing</term><description>9f6888c45c055c44c93ae943c9cfd195</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerCriticalHit(
        DirectlyControllableUnitRequirement? directlyControllableRequirement = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerCriticalHit();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement ?? component.m_DirectlyControllableRequirement;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerDamageAllyWithSpell"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_ChannelDamageAlly</term><description>05210e10afb86544db88625a944fc784</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="spells">
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddTutorialTriggerDamageAllyWithSpell(
        DirectlyControllableUnitRequirement? directlyControllableRequirement = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        List<Blueprint<BlueprintAbilityReference>>? spells = null)
    {
      var component = new TutorialTriggerDamageAllyWithSpell();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement ?? component.m_DirectlyControllableRequirement;
      component.m_Spells = spells?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Spells;
      if (component.m_Spells is null)
      {
        component.m_Spells = new BlueprintAbilityReference[0];
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerDamageFromWeapon"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>NewTutorial_16_ArmorClass</term><description>e2267e1c76a32d845b864d9c9125a58c</description></item>
    /// <item><term>NewTutorial_16_Damage</term><description>55130d443b9e43f47aa1f5c051aca6e8</description></item>
    /// <item><term>TestTutorialDRSmall</term><description>9b1b19c27c8bf9b40a05e72c07134092</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerDamageFromWeapon(
        bool? allowACTouchAttack = null,
        bool? allowFlatfootedTarget = null,
        DirectlyControllableUnitRequirement? directlyControllableRequirement = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        TutorialContext? savedContext = null,
        bool? showAfterCombat = null)
    {
      var component = new TutorialTriggerDamageFromWeapon();
      component.m_AllowACTouchAttack = allowACTouchAttack ?? component.m_AllowACTouchAttack;
      component.m_AllowFlatfootedTarget = allowFlatfootedTarget ?? component.m_AllowFlatfootedTarget;
      component.m_DirectlyControllableRequirement = directlyControllableRequirement ?? component.m_DirectlyControllableRequirement;
      Validate(savedContext);
      component.m_SavedContext = savedContext ?? component.m_SavedContext;
      component.m_ShowAfterCombat = showAfterCombat ?? component.m_ShowAfterCombat;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerDamageReduction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_DRNormal</term><description>5b809f6c0138a944ab86246002deff0e</description></item>
    /// <item><term>ContextTutor_DRUltimate</term><description>af8d86a8e2d97c04386700b5bef00066</description></item>
    /// <item><term>NewTutorial_24_DamageReduction</term><description>4c0eedee0a882c84388e104ee3f0c67a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerDamageReduction(
        bool? absoluteDR = null,
        DirectlyControllableUnitRequirement? directlyControllableRequirement = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerDamageReduction();
      component.AbsoluteDR = absoluteDR ?? component.AbsoluteDR;
      component.m_DirectlyControllableRequirement = directlyControllableRequirement ?? component.m_DirectlyControllableRequirement;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerDeathDoor"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_DeathDoor</term><description>b8ad3ad7d1ff88f47a387668437b9542</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerDeathDoor(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerDeathDoor();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerDialogMythicAnswer"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_MythicReinforce</term><description>e199599b43f94de88e20deeac7eb08bc</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerDialogMythicAnswer(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerDialogMythicAnswer();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEmptySkillSlotOnRest"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_MemorizedSpells</term><description>1cdde4a89945fd34993b7db7036d50ee</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerEmptySkillSlotOnRest(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerEmptySkillSlotOnRest();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnemyHasAnyFact"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_Incorporeal</term><description>b9afadab86097bf4cbdde2dd91693ff4</description></item>
    /// <item><term>ContextTutor_Swarm</term><description>6e3dfbaedfd815546bcf834124dc7fe9</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="enemyFacts">
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
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerEnemyHasAnyFact(
        List<Blueprint<BlueprintUnitFactReference>>? enemyFacts = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerEnemyHasAnyFact();
      component.m_EnemyFacts = enemyFacts?.Select(bp => bp.Reference)?.ToArray() ?? component.m_EnemyFacts;
      if (component.m_EnemyFacts is null)
      {
        component.m_EnemyFacts = new BlueprintUnitFactReference[0];
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnemyHasBlindsight"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_Blindsight</term><description>610afb3404e01f544b440e8e44a61012</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="buffs">
    /// <para>
    /// Blueprint of type BlueprintBuff. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerEnemyHasBlindsight(
        List<Blueprint<BlueprintBuffReference>>? buffs = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Buff? partyBuff = null,
        UnitEntityData? unit = null)
    {
      var component = new TutorialTriggerEnemyHasBlindsight();
      component.m_Buffs = buffs?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Buffs;
      if (component.m_Buffs is null)
      {
        component.m_Buffs = new BlueprintBuffReference[0];
      }
      Validate(partyBuff);
      component.m_PartyBuff = partyBuff ?? component.m_PartyBuff;
      Validate(unit);
      component.m_Unit = unit ?? component.m_Unit;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnemyHasFact"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_ChannelUndead</term><description>c2d5a99c1d8f26746bf17b543f99d0bb</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="enemyFact">
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
    /// <param name="spells">
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddTutorialTriggerEnemyHasFact(
        bool? allowItemsWithSpell = null,
        Blueprint<BlueprintUnitFactReference>? enemyFact = null,
        List<Blueprint<BlueprintAbilityReference>>? spells = null,
        UnitEntityData? unit = null)
    {
      var component = new TutorialTriggerEnemyHasFact();
      component.m_AllowItemsWithSpell = allowItemsWithSpell ?? component.m_AllowItemsWithSpell;
      component.m_EnemyFact = enemyFact?.Reference ?? component.m_EnemyFact;
      if (component.m_EnemyFact is null)
      {
        component.m_EnemyFact = BlueprintTool.GetRef<BlueprintUnitFactReference>(null);
      }
      component.m_Spells = spells?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Spells;
      if (component.m_Spells is null)
      {
        component.m_Spells = new BlueprintAbilityReference[0];
      }
      Validate(unit);
      component.m_Unit = unit ?? component.m_Unit;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnemyHasRegeneration"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_Regeneration</term><description>8019e7508a1b94f4ebc2f0999f9b7770</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerEnemyHasRegeneration(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerEnemyHasRegeneration();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnergyDrain"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_EnergyDrain</term><description>6d422a0bb5f5d084a9b176afd1a27ed2</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerEnergyDrain(
        DirectlyControllableUnitRequirement? directlyControllableRequirement = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerEnergyDrain();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement ?? component.m_DirectlyControllableRequirement;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnergyImmunity"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_EnergyImmunity</term><description>b2e229e75abf2d04186ba4dc1c145bad</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerEnergyImmunity(
        DirectlyControllableUnitRequirement? directlyControllableRequirement = null,
        bool? fromSpell = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerEnergyImmunity();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement ?? component.m_DirectlyControllableRequirement;
      component.FromSpell = fromSpell ?? component.FromSpell;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerEnergyResistance"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_EnergyResistance</term><description>1bbb43c5acb33b04dba30bdb52b0f3dd</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerEnergyResistance(
        DirectlyControllableUnitRequirement? directlyControllableRequirement = null,
        bool? fromSpell = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerEnergyResistance();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement ?? component.m_DirectlyControllableRequirement;
      component.FromSpell = fromSpell ?? component.FromSpell;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerExtraAttackAfterLevelUp"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_BaseAttackBonus</term><description>941b40cfded225e4099ec5a0646e8efd</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerExtraAttackAfterLevelUp(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        int? startPrimaryAttackCount = null,
        int? startSecondaryAttackCount = null,
        UnitEntityData? triggerUnit = null)
    {
      var component = new TutorialTriggerExtraAttackAfterLevelUp();
      component.m_StartPrimaryAttackCount = startPrimaryAttackCount ?? component.m_StartPrimaryAttackCount;
      component.m_StartSecondaryAttackCount = startSecondaryAttackCount ?? component.m_StartSecondaryAttackCount;
      Validate(triggerUnit);
      component.m_TriggerUnit = triggerUnit ?? component.m_TriggerUnit;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerFormationChangedBadly"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_Formation</term><description>e2a328adc266f9b499490d4528761e79</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="minTankDistance">
    /// <para>
    /// InfoBox: Minimum distance from tank to the rest of party (in UI formation grid cells)
    /// </para>
    /// </param>
    public TBuilder AddTutorialTriggerFormationChangedBadly(
        GameDifficultyOption? maxGameDifficulty = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        float? minTankDistance = null,
        bool? partyWasChanged = null,
        int? tanksCount = null)
    {
      var component = new TutorialTriggerFormationChangedBadly();
      component.MaxGameDifficulty = maxGameDifficulty ?? component.MaxGameDifficulty;
      component.MinTankDistance = minTankDistance ?? component.MinTankDistance;
      component.m_PartyWasChanged = partyWasChanged ?? component.m_PartyWasChanged;
      component.TanksCount = tanksCount ?? component.TanksCount;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerHaveBetterEquipment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_ItemUpgrade</term><description>4284c23456ccafb42bdaff2d987e74a6</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerHaveBetterEquipment(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        int? minGradeDiff = null)
    {
      var component = new TutorialTriggerHaveBetterEquipment();
      component.MinGradeDiff = minGradeDiff ?? component.MinGradeDiff;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerHealEnemyWithSpell"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_ChannelHealEnemy</term><description>cd82af44b4343194b9b74587eaa2e7be</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="spells">
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddTutorialTriggerHealEnemyWithSpell(
        DirectlyControllableUnitRequirement? directlyControllableRequirement = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        List<Blueprint<BlueprintAbilityReference>>? spells = null)
    {
      var component = new TutorialTriggerHealEnemyWithSpell();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement ?? component.m_DirectlyControllableRequirement;
      component.m_Spells = spells?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Spells;
      if (component.m_Spells is null)
      {
        component.m_Spells = new BlueprintAbilityReference[0];
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerHealingScroll"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_Scrolls</term><description>1a0413784e253384bb0927fefb79cdb4</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerHealingScroll(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        float? unitLeftHealthPercent = null)
    {
      var component = new TutorialTriggerHealingScroll();
      component.UnitLeftHealthPercent = unitLeftHealthPercent ?? component.UnitLeftHealthPercent;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerItemIdentificationFailed"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_Identification</term><description>b7f2e9c71d3c4c6282d9d4b2b178b063</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerItemIdentificationFailed(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerItemIdentificationFailed();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerKingdomManagementOpened"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CrusadeTutorial_09_Kingdom</term><description>3b3eef7a42c54323a471a02e9a439a4a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerKingdomManagementOpened(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerKingdomManagementOpened();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerKingdomTabSelected"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CrusadeTutorial_10_Edicts</term><description>b2b0cc9d575a40f6a12ab30c95f0b267</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerKingdomTabSelected(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        KingdomNavigationType? type = null)
    {
      var component = new TutorialTriggerKingdomTabSelected();
      component.m_Type = type ?? component.m_Type;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerLowHitPoints"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_LowHPHeal</term><description>62e42f2bf35ff1e4daa63b2a68c0b264</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerLowHitPoints(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        float? threshold = null)
    {
      var component = new TutorialTriggerLowHitPoints();
      component.Threshold = threshold ?? component.Threshold;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerMemorizeSpontaneousSpell"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_SpontaneousDruid</term><description>d36a752fe4d36e94f820405369fd089a</description></item>
    /// <item><term>ContextTutor_SpontaneousPriest</term><description>89d7f9f286bba444d863231a0700dfb7</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="characterClass">
    /// <para>
    /// Blueprint of type BlueprintCharacterClass. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerMemorizeSpontaneousSpell(
        Blueprint<BlueprintCharacterClassReference>? characterClass = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerMemorizeSpontaneousSpell();
      component.m_CharacterClass = characterClass?.Reference ?? component.m_CharacterClass;
      if (component.m_CharacterClass is null)
      {
        component.m_CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerMissingPreciseShot"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_MeleeShooting</term><description>e5074d54cea27e74497254551b02739e</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerMissingPreciseShot(
        DirectlyControllableUnitRequirement? directlyControllableRequirement = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerMissingPreciseShot();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement ?? component.m_DirectlyControllableRequirement;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerMissingTwoWeaponFighting"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_DualWielding</term><description>9cc716c6e1a054141bc70b3ba9835bf1</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerMissingTwoWeaponFighting(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerMissingTwoWeaponFighting();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerMountAnimal"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_MountCombat</term><description>4e2014b8629e426984f273d2c09885f9</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerMountAnimal(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerMountAnimal();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerMultipleUnitsCondition"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_Exhausted</term><description>62e661dce03f8614190ea795ff5ab512</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerMultipleUnitsCondition(
        bool? allowOnGlobalMap = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        int? minimumUnitsCount = null,
        UnitCondition? triggerCondition = null)
    {
      var component = new TutorialTriggerMultipleUnitsCondition();
      component.AllowOnGlobalMap = allowOnGlobalMap ?? component.AllowOnGlobalMap;
      component.MinimumUnitsCount = minimumUnitsCount ?? component.MinimumUnitsCount;
      component.TriggerCondition = triggerCondition ?? component.TriggerCondition;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNewCrusaderArmy"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CrusadeTutorial_06_ArmyManagement</term><description>ff4852b301114006b9407e2ad54df475</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerNewCrusaderArmy(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        int? minimumNumberOfArmies = null)
    {
      var component = new TutorialTriggerNewCrusaderArmy();
      component.m_MinimumNumberOfArmies = minimumNumberOfArmies ?? component.m_MinimumNumberOfArmies;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNewItemWithEnchantment"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_WeaponPlusFive</term><description>2badff2907b6df44a8ac0f51bbf09038</description></item>
    /// <item><term>ContextTutor_WeaponPlusFour</term><description>7105cd6ae8f8ca74baef5b31c8e1439a</description></item>
    /// <item><term>ContextTutor_WeaponPlusThree</term><description>adba0c27ea864784d97cbe6de61d1b62</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="enchantment">
    /// <para>
    /// Blueprint of type BlueprintItemEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerNewItemWithEnchantment(
        Blueprint<BlueprintItemEnchantmentReference>? enchantment = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerNewItemWithEnchantment();
      component.m_Enchantment = enchantment?.Reference ?? component.m_Enchantment;
      if (component.m_Enchantment is null)
      {
        component.m_Enchantment = BlueprintTool.GetRef<BlueprintItemEnchantmentReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNewNotLearnedScroll"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_ScrollsMemorizing</term><description>283a2b24e3187bb4c91f6034ed090afc</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerNewNotLearnedScroll(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerNewNotLearnedScroll();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNewRecipe"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_NewRecipe</term><description>91a99dbe207e4c14bf58365d64e0eada</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerNewRecipe(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerNewRecipe();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNewRodItem"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_MagicRod</term><description>14ec930dfe4b4394193e2d3a943738fa</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerNewRodItem(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Metamagic? triggerMetamagic = null)
    {
      var component = new TutorialTriggerNewRodItem();
      component.TriggerMetamagic = triggerMetamagic ?? component.TriggerMetamagic;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNewSpellWithoutRequiredMaterial"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_MaterialComponent</term><description>a4105ffe1bcd14c4582a6ac83615d007</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerNewSpellWithoutRequiredMaterial(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerNewSpellWithoutRequiredMaterial();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNewWand"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_MagicWand</term><description>d0304ab7f1236e64c920fac2623c568f</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="spells">
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddTutorialTriggerNewWand(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        List<Blueprint<BlueprintAbilityReference>>? spells = null)
    {
      var component = new TutorialTriggerNewWand();
      component.m_Spells = spells?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Spells;
      if (component.m_Spells is null)
      {
        component.m_Spells = new BlueprintAbilityReference[0];
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNoAutocastSpell"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_Autocast</term><description>eefc2dcadfcecfd429fb5697356fb214</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="companions">
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
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="recommendedAbilities">
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddTutorialTriggerNoAutocastSpell(
        List<Blueprint<BlueprintUnitReference>>? companions = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        List<Blueprint<BlueprintAbilityReference>>? recommendedAbilities = null)
    {
      var component = new TutorialTriggerNoAutocastSpell();
      component.m_Companions = companions?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Companions;
      if (component.m_Companions is null)
      {
        component.m_Companions = new BlueprintUnitReference[0];
      }
      component.m_RecommendedAbilities = recommendedAbilities?.Select(bp => bp.Reference)?.ToArray() ?? component.m_RecommendedAbilities;
      if (component.m_RecommendedAbilities is null)
      {
        component.m_RecommendedAbilities = new BlueprintAbilityReference[0];
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerNonStackBonus"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_NonStackBonus</term><description>37e769643d701604d8f5003bfc651cbb</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerNonStackBonus(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerNonStackBonus();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerOpenArmyRecruit"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CrusadeTutorial_11_Mercs</term><description>368fcc42afa94552b1a67acfd3748bff</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerOpenArmyRecruit(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerOpenArmyRecruit();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerOpenRestUI"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>NewTutorial_25_Camping_2</term><description>05fd974a864e04248b9d503793324419</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerOpenRestUI(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerOpenRestUI();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerPartyEncumbrance"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_EncumbranceParty</term><description>981dd3fa202a85641a0200c245ecb503</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerPartyEncumbrance(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Encumbrance? minTriggerEncumbrance = null)
    {
      var component = new TutorialTriggerPartyEncumbrance();
      component.MinTriggerEncumbrance = minTriggerEncumbrance ?? component.MinTriggerEncumbrance;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerSavingThrow"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_SavingThrow</term><description>a6cba74c40f75494784ca9b22e5e36e8</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerSavingThrow(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerSavingThrow();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerSkillCheck"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>NewTutorial_14_DiceRoll</term><description>930b63a8f29420a4f9221a9feee7b856</description></item>
    /// <item><term>TestTutorialSC</term><description>2e48c8330634d544489e1fc14ccf5eaa</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerSkillCheck(
        DirectlyControllableUnitRequirement? directlyControllableRequirement = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        StatType? skill = null,
        bool? skillRestriction = null,
        TutorialTriggerSkillCheck.ResultType? triggerOnResult = null)
    {
      var component = new TutorialTriggerSkillCheck();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement ?? component.m_DirectlyControllableRequirement;
      component.Skill = skill ?? component.Skill;
      component.SkillRestriction = skillRestriction ?? component.SkillRestriction;
      component.m_TriggerOnResult = triggerOnResult ?? component.m_TriggerOnResult;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerSneakAttack"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_SneakAttack</term><description>29aaa47d3c4415945afe877066b1422a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerSneakAttack(
        DirectlyControllableUnitRequirement? directlyControllableRequirement = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerSneakAttack();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement ?? component.m_DirectlyControllableRequirement;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerSpellResistance"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_SpellResistance</term><description>a0bf48f424eba4946b38f82f622879ff</description></item>
    /// <item><term>ContextTutor_SpellResistanceBuff</term><description>2c11f33e25b226648aa7c57cce9736ea</description></item>
    /// <item><term>ContextTutor_SpellResistanceItem</term><description>5a55e533765fcbe43afc93b46fbe1bb5</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="needAllDescriptors">
    /// <para>
    /// InfoBox: If NeedAllDescriptors is true, only resisted spell with all listed flags will trigger
    /// </para>
    /// </param>
    public TBuilder AddTutorialTriggerSpellResistance(
        SpellDescriptorWrapper? descriptor = null,
        DirectlyControllableUnitRequirement? directlyControllableRequirement = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? needAllDescriptors = null,
        TutorialTriggerSpellResistance.Target? triggerTarget = null)
    {
      var component = new TutorialTriggerSpellResistance();
      component.Descriptor = descriptor ?? component.Descriptor;
      component.m_DirectlyControllableRequirement = directlyControllableRequirement ?? component.m_DirectlyControllableRequirement;
      component.NeedAllDescriptors = needAllDescriptors ?? component.NeedAllDescriptors;
      component.TriggerTarget = triggerTarget ?? component.TriggerTarget;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerTacticalCombatEnd"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CrusadeTutorial_03_General</term><description>bb09900e7a5f49e694b0abd252e3c12c</description></item>
    /// <item><term>CrusadeTutorial_07_Morale</term><description>4568d12fdf8447e38735d811ca7cf07f</description></item>
    /// <item><term>CrusadeTutorial_13_Regions</term><description>4b18c717fcbe481aad4bb181e62cea3a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="demonsWon">
    /// <para>
    /// InfoBox: If true triggers on demon&amp;apos;s victory, otherwise on crusaders&amp;apos;
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="onlyGarrison">
    /// <para>
    /// InfoBox: If true triggers only on garrison capture
    /// </para>
    /// </param>
    public TBuilder AddTutorialTriggerTacticalCombatEnd(
        bool? demonsWon = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? onlyGarrison = null)
    {
      var component = new TutorialTriggerTacticalCombatEnd();
      component.m_DemonsWon = demonsWon ?? component.m_DemonsWon;
      component.m_OnlyGarrison = onlyGarrison ?? component.m_OnlyGarrison;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerTacticalCombatStart"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>CrusadeTutorial_02_Battle</term><description>e00f8f602dc54e04b0d4c65205a25f17</description></item>
    /// <item><term>CrusadeTutorial_04_GeneralInCombat</term><description>c689b8fdec744cb98f4231ff1e5e01af</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="enemyUnits">
    /// <para>
    /// InfoBox: Will trigger if enemy army contains any of specified units
    /// </para>
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
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerTacticalCombatStart(
        bool? enemyShouldHaveLeader = null,
        List<Blueprint<BlueprintUnitReference>>? enemyUnits = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? playerShouldHaveLeader = null,
        bool? specifyEnemyUnits = null)
    {
      var component = new TutorialTriggerTacticalCombatStart();
      component.m_EnemyShouldHaveLeader = enemyShouldHaveLeader ?? component.m_EnemyShouldHaveLeader;
      component.m_EnemyUnits = enemyUnits?.Select(bp => bp.Reference)?.ToArray() ?? component.m_EnemyUnits;
      if (component.m_EnemyUnits is null)
      {
        component.m_EnemyUnits = new BlueprintUnitReference[0];
      }
      component.m_PlayerShouldHaveLeader = playerShouldHaveLeader ?? component.m_PlayerShouldHaveLeader;
      component.m_SpecifyEnemyUnits = specifyEnemyUnits ?? component.m_SpecifyEnemyUnits;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerTargetRestriction"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_TargetType</term><description>77ce529f3d142a14e92b772c3c8d49ce</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerTargetRestriction(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerTargetRestriction();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerTouchAC"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_TouchAC</term><description>9c02f4f3f76d005449f84aefb9c7c086</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerTouchAC(
        DirectlyControllableUnitRequirement? directlyControllableRequirement = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        int? missesInRow = null,
        int? touchACDifference = null)
    {
      var component = new TutorialTriggerTouchAC();
      component.m_DirectlyControllableRequirement = directlyControllableRequirement ?? component.m_DirectlyControllableRequirement;
      component.MissesInRow = missesInRow ?? component.MissesInRow;
      component.TouchACDifference = touchACDifference ?? component.TouchACDifference;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerTurnBaseModeActivated"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>NewTutorial_TBM</term><description>5149409ec9a7457592b1e444d562ff7e</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerTurnBaseModeActivated(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerTurnBaseModeActivated();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerUIEvent"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_FormationHelper</term><description>f4939ebdf5525c247be94d44cb2ef886</description></item>
    /// <item><term>NewTutorial_MythicSpellbook</term><description>83c970f5fe351aa42a43fe323e887bbc</description></item>
    /// <item><term>RestTutorial_CraftingScrolls</term><description>1d1ede439814c4d478a8322ad0af3711</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerUIEvent(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        UIEventType? uIEvent = null)
    {
      var component = new TutorialTriggerUIEvent();
      component.UIEvent = uIEvent ?? component.UIEvent;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerUnitCondition"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_Blindness</term><description>72ef0da93e29f8c4e8fd70b93e4200bd</description></item>
    /// <item><term>ContextTutor_Paralysis</term><description>4e8cc760997161a46a205cee1764a0c7</description></item>
    /// <item><term>ContextTutor_Petrification</term><description>c733a40a8e9a3ef4d86978eb8294e344</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerUnitCondition(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        UnitCondition? triggerCondition = null)
    {
      var component = new TutorialTriggerUnitCondition();
      component.TriggerCondition = triggerCondition ?? component.TriggerCondition;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerUnitDeath"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_CompanionDeath</term><description>bc040513022c03a42a2eee06d3a41f01</description></item>
    /// <item><term>ContextTutor_PetDeath</term><description>3e6ff2fea653bb34395eab8f32d993a8</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerUnitDeath(
        bool? isPet = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerUnitDeath();
      component.IsPet = isPet ?? component.IsPet;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerUnitDiedWithoutBardPerformance"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_BardicPerformance</term><description>f7f41fdcfe0859b419e86b870ace7340</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="performances">
    /// <para>
    /// Blueprint of type BlueprintActivatableAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddTutorialTriggerUnitDiedWithoutBardPerformance(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        List<Blueprint<BlueprintActivatableAbilityReference>>? performances = null)
    {
      var component = new TutorialTriggerUnitDiedWithoutBardPerformance();
      component.m_Performances = performances?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Performances;
      if (component.m_Performances is null)
      {
        component.m_Performances = new BlueprintActivatableAbilityReference[0];
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerUnitEncumbrance"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_EncumbranceUnit</term><description>e53ac21db7f4b5846b1bdec97e75820a</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerUnitEncumbrance(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Encumbrance? minTriggerEncumbrance = null)
    {
      var component = new TutorialTriggerUnitEncumbrance();
      component.MinTriggerEncumbrance = minTriggerEncumbrance ?? component.MinTriggerEncumbrance;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerUnitLostAlignmentFeature"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_ClassAlignment</term><description>3e2d134a46f0abe4b9c966963e3ced2b</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerUnitLostAlignmentFeature(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerUnitLostAlignmentFeature();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialTriggerUnitWithSneakAttackJoinParty"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_SneakAttackRecruit</term><description>7b4c7f77a63911b43a6d007bdea3a35e</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialTriggerUnitWithSneakAttackJoinParty(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialTriggerUnitWithSneakAttackJoinParty();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialSolverBestWeaponAgainstTarget"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_DRNormal</term><description>5b809f6c0138a944ab86246002deff0e</description></item>
    /// <item><term>ContextTutor_EnergyResistance</term><description>1bbb43c5acb33b04dba30bdb52b0f3dd</description></item>
    /// <item><term>ContextTutor_Regeneration</term><description>8019e7508a1b94f4ebc2f0999f9b7770</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="enchantments">
    /// <para>
    /// InfoBox: Considers only weapons with at least one enchantment from list
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintWeaponEnchantment. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddTutorialSolverBestWeaponAgainstTarget(
        bool? checkEnchantment = null,
        bool? checkRegeneration = null,
        List<Blueprint<BlueprintWeaponEnchantmentReference>>? enchantments = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new TutorialSolverBestWeaponAgainstTarget();
      component.CheckEnchantment = checkEnchantment ?? component.CheckEnchantment;
      component.CheckRegeneration = checkRegeneration ?? component.CheckRegeneration;
      component.m_Enchantments = enchantments?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Enchantments;
      if (component.m_Enchantments is null)
      {
        component.m_Enchantments = new BlueprintWeaponEnchantmentReference[0];
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialSolverSpellFromList"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_AbilityDamage</term><description>f579133d7ad865e488551b7aa59c22da</description></item>
    /// <item><term>ContextTutor_GazeAttack</term><description>937f0e8f22668324fa20364602960371</description></item>
    /// <item><term>NewTutorial_9_1_Light</term><description>70d0c00f39ce7104c867ec827df4bfb9</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="spells">
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddTutorialSolverSpellFromList(
        bool? allowItems = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        List<Blueprint<BlueprintAbilityReference>>? spells = null)
    {
      var component = new TutorialSolverSpellFromList();
      component.AllowItems = allowItems ?? component.AllowItems;
      component.m_Spells = spells?.Select(bp => bp.Reference)?.ToArray() ?? component.m_Spells;
      if (component.m_Spells is null)
      {
        component.m_Spells = new BlueprintAbilityReference[0];
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialSolverSpellWithDamage"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_DRNormal</term><description>5b809f6c0138a944ab86246002deff0e</description></item>
    /// <item><term>ContextTutor_EnergyResistance</term><description>1bbb43c5acb33b04dba30bdb52b0f3dd</description></item>
    /// <item><term>ContextTutor_TouchAC</term><description>9c02f4f3f76d005449f84aefb9c7c086</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="checkRegeneration">
    /// <para>
    /// InfoBox: Consider only spells which can disable regeneration
    /// </para>
    /// </param>
    /// <param name="checkVulnerability">
    /// <para>
    /// InfoBox: Consider only spells which have target&amp;apos;s vulnerable descriptors
    /// </para>
    /// </param>
    /// <param name="ignoredSpells">
    /// <para>
    /// InfoBox: These spells can&amp;apos;t be solution. For example, ChannelNegativeEnergy can&amp;apos;t damage all tarrgets
    /// </para>
    /// <para>
    /// Blueprint of type BlueprintAbility. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="needAllDescriptors">
    /// <para>
    /// InfoBox: If NeedAllDescriptors is true, only resisted spell with all listed flags will trigger
    /// </para>
    /// </param>
    public TBuilder AddTutorialSolverSpellWithDamage(
        bool? allowItems = null,
        AttackTypeFlag? attackType = null,
        bool? checkRegeneration = null,
        bool? checkVulnerability = null,
        List<Blueprint<BlueprintAbilityReference>>? ignoredSpells = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? needAllDescriptors = null,
        bool? onlyAoE = null,
        SpellDescriptorWrapper? spellDescriptor = null,
        bool? useDescriptor = null)
    {
      var component = new TutorialSolverSpellWithDamage();
      component.AllowItems = allowItems ?? component.AllowItems;
      component.AttackType = attackType ?? component.AttackType;
      component.CheckRegeneration = checkRegeneration ?? component.CheckRegeneration;
      component.CheckVulnerability = checkVulnerability ?? component.CheckVulnerability;
      component.IgnoredSpells = ignoredSpells?.Select(bp => bp.Reference)?.ToList() ?? component.IgnoredSpells;
      if (component.IgnoredSpells is null)
      {
        component.IgnoredSpells = new();
      }
      component.NeedAllDescriptors = needAllDescriptors ?? component.NeedAllDescriptors;
      component.OnlyAoE = onlyAoE ?? component.OnlyAoE;
      component.SpellDescriptor = spellDescriptor ?? component.SpellDescriptor;
      component.UseDescriptor = useDescriptor ?? component.UseDescriptor;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="TutorialSolverSpellWithDescriptor"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>ContextTutor_LowHPHeal</term><description>62e42f2bf35ff1e4daa63b2a68c0b264</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="excludeOnlySelfTarget">
    /// <para>
    /// InfoBox: To prevent including self healing spells or buffs
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="needAllDescriptors">
    /// <para>
    /// InfoBox: If NeedAllDescriptors is true, only buff that has all listed flags will trigger
    /// </para>
    /// </param>
    public TBuilder AddTutorialSolverSpellWithDescriptor(
        bool? allowItems = null,
        bool? excludeOnlySelfTarget = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? needAllDescriptors = null,
        SpellDescriptorWrapper? spellDescriptors = null)
    {
      var component = new TutorialSolverSpellWithDescriptor();
      component.AllowItems = allowItems ?? component.AllowItems;
      component.ExcludeOnlySelfTarget = excludeOnlySelfTarget ?? component.ExcludeOnlySelfTarget;
      component.NeedAllDescriptors = needAllDescriptors ?? component.NeedAllDescriptors;
      component.SpellDescriptors = spellDescriptors ?? component.SpellDescriptors;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    protected override void SetDefaults()
    {
      base.SetDefaults();
    
      if (Blueprint.m_TitleText is null)
      {
        Blueprint.m_TitleText = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_TriggerText is null)
      {
        Blueprint.m_TriggerText = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_DescriptionText is null)
      {
        Blueprint.m_DescriptionText = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_SolutionFoundText is null)
      {
        Blueprint.m_SolutionFoundText = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_SolutionNotFoundText is null)
      {
        Blueprint.m_SolutionNotFoundText = Utils.Constants.Empty.String;
      }
      if (Blueprint.EncyclopediaReference is null)
      {
        Blueprint.EncyclopediaReference = BlueprintTool.GetRef<BlueprintEncyclopediaPageReference>(null);
      }
    }
  }
}
