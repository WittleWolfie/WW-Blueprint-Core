//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.DLC;
using Kingmaker.Localization;
using Kingmaker.Utility;
using System;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.DLC
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintDlc"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDlcConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintDlc
    where TBuilder : BaseDlcConfigurator<T, TBuilder>
  {
    protected BaseDlcConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDlc.Description"/>
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
    /// Modifies <see cref="BlueprintDlc.Description"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintDlc.RewardReferences"/>
    /// </summary>
    ///
    /// <param name="rewardReferences">
    /// <para>
    /// Blueprint of type BlueprintDlcReward. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetRewardReferences(params Blueprint<BlueprintDlcRewardReference>[] rewardReferences)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RewardReferences = rewardReferences.Select(bp => bp.Reference).ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintDlc.RewardReferences"/>
    /// </summary>
    ///
    /// <param name="rewardReferences">
    /// <para>
    /// Blueprint of type BlueprintDlcReward. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToRewardReferences(params Blueprint<BlueprintDlcRewardReference>[] rewardReferences)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RewardReferences = bp.RewardReferences ?? new BlueprintDlcRewardReference[0];
          bp.RewardReferences = CommonTool.Append(bp.RewardReferences, rewardReferences.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDlc.RewardReferences"/>
    /// </summary>
    ///
    /// <param name="rewardReferences">
    /// <para>
    /// Blueprint of type BlueprintDlcReward. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromRewardReferences(params Blueprint<BlueprintDlcRewardReference>[] rewardReferences)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RewardReferences is null) { return; }
          bp.RewardReferences = bp.RewardReferences.Where(val => !rewardReferences.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintDlc.RewardReferences"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromRewardReferences(Func<BlueprintDlcRewardReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RewardReferences is null) { return; }
          bp.RewardReferences = bp.RewardReferences.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintDlc.RewardReferences"/>
    /// </summary>
    public TBuilder ClearRewardReferences()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.RewardReferences = new BlueprintDlcRewardReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDlc.RewardReferences"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyRewardReferences(Action<BlueprintDlcRewardReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.RewardReferences is null) { return; }
          bp.RewardReferences.ForEach(action);
        });
    }

    /// <summary>
    /// Adds <see cref="DlcStoreCheat"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Dlc1</term><description>8576a633c8fe4ce78530b55c1f0d14e5</description></item>
    /// <item><term>DlcPreorder</term><description>cce1376687d1452c9f451b0d921bcd4e</description></item>
    /// <item><term>FreeDlc4</term><description>a9262dad08654d3dbad64476978c0f95</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="isAvailableInDevBuild">
    /// <para>
    /// Tooltip: Is the DLC available in development build
    /// </para>
    /// </param>
    /// <param name="isAvailableInEditor">
    /// <para>
    /// Tooltip: Is the DLC available in editor playmode
    /// </para>
    /// </param>
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddDlcStoreCheat(
        bool? isAvailableInDevBuild = null,
        bool? isAvailableInEditor = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new DlcStoreCheat();
      component.m_IsAvailableInDevBuild = isAvailableInDevBuild ?? component.m_IsAvailableInDevBuild;
      component.m_IsAvailableInEditor = isAvailableInEditor ?? component.m_IsAvailableInEditor;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="DlcStoreConsoleFree"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>FreeDlc1</term><description>d185af74fc5b4c198600e0202ca11de8</description></item>
    /// <item><term>FreeDlc3</term><description>aa65dbd3c0bb44b49343b020c9a4c8a3</description></item>
    /// <item><term>FreeDlc4</term><description>a9262dad08654d3dbad64476978c0f95</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddDlcStoreConsoleFree(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new DlcStoreConsoleFree();
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="DlcStoreEpic"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Dlc1</term><description>8576a633c8fe4ce78530b55c1f0d14e5</description></item>
    /// <item><term>DlcPreorder</term><description>cce1376687d1452c9f451b0d921bcd4e</description></item>
    /// <item><term>FreeDlc4</term><description>a9262dad08654d3dbad64476978c0f95</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddDlcStoreEpic(
        string? epicId = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new DlcStoreEpic();
      component.m_EpicId = epicId ?? component.m_EpicId;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="DlcStoreGog"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Dlc1</term><description>8576a633c8fe4ce78530b55c1f0d14e5</description></item>
    /// <item><term>DlcPreorder</term><description>cce1376687d1452c9f451b0d921bcd4e</description></item>
    /// <item><term>FreeDlc4</term><description>a9262dad08654d3dbad64476978c0f95</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddDlcStoreGog(
        ulong? gogId = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new DlcStoreGog();
      component.m_GogId = gogId ?? component.m_GogId;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="DlcStoreSteam"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Dlc1</term><description>8576a633c8fe4ce78530b55c1f0d14e5</description></item>
    /// <item><term>DlcPreorder</term><description>cce1376687d1452c9f451b0d921bcd4e</description></item>
    /// <item><term>FreeDlc4</term><description>a9262dad08654d3dbad64476978c0f95</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddDlcStoreSteam(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        uint? steamId = null)
    {
      var component = new DlcStoreSteam();
      component.m_SteamId = steamId ?? component.m_SteamId;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Description is null)
      {
        Blueprint.Description = Utils.Constants.Empty.String;
      }
      if (Blueprint.RewardReferences is null)
      {
        Blueprint.RewardReferences = new BlueprintDlcRewardReference[0];
      }
    }
  }
}
