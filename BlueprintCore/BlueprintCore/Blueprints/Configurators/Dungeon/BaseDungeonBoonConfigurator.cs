//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.Dungeon.Blueprints.Boons;
using Kingmaker.Localization;
using System;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintDungeonBoon"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDungeonBoonConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintDungeonBoon
    where TBuilder : BaseDungeonBoonConfigurator<T, TBuilder>
  {
    protected BaseDungeonBoonConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintDungeonBoon>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Name = copyFrom.Name;
          bp.Icon = copyFrom.Icon;
          bp.m_Description = copyFrom.m_Description;
          bp.MinStage = copyFrom.MinStage;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintDungeonBoon>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Name = copyFrom.Name;
          bp.Icon = copyFrom.Icon;
          bp.m_Description = copyFrom.m_Description;
          bp.MinStage = copyFrom.MinStage;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonBoon.Name"/>
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
    /// Modifies <see cref="BlueprintDungeonBoon.Name"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintDungeonBoon.Icon"/>
    /// </summary>
    ///
    /// <param name="icon">
    /// You can pass in the animation using a Sprite or it's AssetId.
    /// </param>
    public TBuilder SetIcon(Asset<Sprite> icon)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Icon = icon?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonBoon.Icon"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIcon(Action<Sprite> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Icon is null) { return; }
          action.Invoke(bp.Icon);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonBoon.m_Description"/>
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
          bp.m_Description = description?.LocalizedString;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonBoon.m_Description"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDescription(Action<LocalizedString> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Description is null) { return; }
          action.Invoke(bp.m_Description);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDungeonBoon.MinStage"/>
    /// </summary>
    public TBuilder SetMinStage(int minStage)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MinStage = minStage;
        });
    }

    /// <summary>
    /// Adds <see cref="BoonLogicFeature"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DungeonBoon_Aoe</term><description>5424ec0ee1ef4c06be0b2a847ca77c16</description></item>
    /// <item><term>DungeonBoon_Elven</term><description>dbb242c6be10406799fd659feb40d266</description></item>
    /// <item><term>DungeonBoon_Shieldbuff</term><description>e0a3d1009fd549fe97c57683b0e6cfe8</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="feature">
    /// <para>
    /// Blueprint of type BlueprintFeature. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddBoonLogicFeature(
        Blueprint<BlueprintFeatureReference>? feature = null,
        bool? mainCharacterOnly = null,
        int? start = null,
        int? step = null)
    {
      var component = new BoonLogicFeature();
      component.m_Feature = feature?.Reference ?? component.m_Feature;
      if (component.m_Feature is null)
      {
        component.m_Feature = BlueprintTool.GetRef<BlueprintFeatureReference>(null);
      }
      component.m_MainCharacterOnly = mainCharacterOnly ?? component.m_MainCharacterOnly;
      component.Start = start ?? component.Start;
      component.Step = step ?? component.Step;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BoonLogicPartyBuff"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>DungeonBoon_Acid</term><description>30d5a9af67c844eaba0a9eccd0e10c39</description></item>
    /// <item><term>DungeonBoon_Metamagic</term><description>e8c9809811214863a5aaf4e60ce548ea</description></item>
    /// <item><term>DungeonBoon_UnarmedStrikes</term><description>5c7a5a0220e84b3fa5d78d427d10bf6b</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="buff">
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
    public TBuilder AddBoonLogicPartyBuff(
        Blueprint<BlueprintBuffReference>? buff = null,
        bool? mainCharacterOnly = null,
        bool? onlyRandomCharacterClass = null,
        DungeonBoonLogic.ProgressionType? progression = null,
        int? start = null,
        int? step = null)
    {
      var component = new BoonLogicPartyBuff();
      component.m_Buff = buff?.Reference ?? component.m_Buff;
      if (component.m_Buff is null)
      {
        component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(null);
      }
      component.m_MainCharacterOnly = mainCharacterOnly ?? component.m_MainCharacterOnly;
      component.OnlyRandomCharacterClass = onlyRandomCharacterClass ?? component.OnlyRandomCharacterClass;
      component.m_Progression = progression ?? component.m_Progression;
      component.Start = start ?? component.Start;
      component.Step = step ?? component.Step;
      return AddComponent(component);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Name is null)
      {
        Blueprint.Name = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_Description is null)
      {
        Blueprint.m_Description = Utils.Constants.Empty.String;
      }
    }
  }
}
