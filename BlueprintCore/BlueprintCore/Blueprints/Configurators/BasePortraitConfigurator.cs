//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintPortrait"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BasePortraitConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintPortrait
    where TBuilder : BasePortraitConfigurator<T, TBuilder>
  {
    protected BasePortraitConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintPortrait>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Data = copyFrom.Data;
          bp.m_BackupPortrait = copyFrom.m_BackupPortrait;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintPortrait>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Data = copyFrom.Data;
          bp.m_BackupPortrait = copyFrom.m_BackupPortrait;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintPortrait.Data"/>
    /// </summary>
    public TBuilder SetData(PortraitData data)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(data);
          bp.Data = data;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintPortrait.Data"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyData(Action<PortraitData> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Data is null) { return; }
          action.Invoke(bp.Data);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintPortrait.m_BackupPortrait"/>
    /// </summary>
    ///
    /// <param name="backupPortrait">
    /// <para>
    /// Blueprint of type BlueprintPortrait. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetBackupPortrait(Blueprint<BlueprintPortraitReference> backupPortrait)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_BackupPortrait = backupPortrait?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintPortrait.m_BackupPortrait"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyBackupPortrait(Action<BlueprintPortraitReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_BackupPortrait is null) { return; }
          action.Invoke(bp.m_BackupPortrait);
        });
    }

    /// <summary>
    /// Adds <see cref="PortraitDollSettings"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>AasimarMaleBloodrager</term><description>7ba4a4bdb55b46779ebca045d7955e82</description></item>
    /// <item><term>PlayerAasimarFemaleMage_Portrait</term><description>4bb9e147a44d9be43ab4b16fa7d48383</description></item>
    /// <item><term>VillasGunderson_Portrait</term><description>579ffcd508ac4074597892b12b17ee47</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="race">
    /// <para>
    /// Blueprint of type BlueprintRace. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddPortraitDollSettings(
        Gender? gender = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        Blueprint<BlueprintRaceReference>? race = null)
    {
      var component = new PortraitDollSettings();
      component.Gender = gender ?? component.Gender;
      component.m_Race = race?.Reference ?? component.m_Race;
      if (component.m_Race is null)
      {
        component.m_Race = BlueprintTool.GetRef<BlueprintRaceReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="PortraitPremiumSetting"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>SepalLorentus_Portrait</term><description>41db134e53a1908469a2efc6d55cc8f8</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddPortraitPremiumSetting(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new PortraitPremiumSetting();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_BackupPortrait is null)
      {
        Blueprint.m_BackupPortrait = BlueprintTool.GetRef<BlueprintPortraitReference>(null);
      }
    }
  }
}
