//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.DLC;
using System;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.DLC
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintDlcRewardCampaign"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseDlcRewardCampaignConfigurator<T, TBuilder>
    : BaseDlcRewardConfigurator<T, TBuilder>
    where T : BlueprintDlcRewardCampaign
    where TBuilder : BaseDlcRewardCampaignConfigurator<T, TBuilder>
  {
    protected BaseDlcRewardCampaignConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintDlcRewardCampaign>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.ScreenshotForImportSave = copyFrom.ScreenshotForImportSave;
          bp.m_Campaign = copyFrom.m_Campaign;
        });
    }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Predicate{BlueprintComponent})"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintDlcRewardCampaign>> blueprint, Predicate<BlueprintComponent> componentMatcher)
    {
      base.CopyFrom(blueprint.ToString(), componentMatcher);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.ScreenshotForImportSave = copyFrom.ScreenshotForImportSave;
          bp.m_Campaign = copyFrom.m_Campaign;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDlcRewardCampaign.ScreenshotForImportSave"/>
    /// </summary>
    ///
    /// <param name="screenshotForImportSave">
    /// You can pass in the animation using a Texture2D or it's AssetId.
    /// </param>
    public TBuilder SetScreenshotForImportSave(Asset<Texture2D> screenshotForImportSave)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ScreenshotForImportSave = screenshotForImportSave?.Get();
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDlcRewardCampaign.ScreenshotForImportSave"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyScreenshotForImportSave(Action<Texture2D> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ScreenshotForImportSave is null) { return; }
          action.Invoke(bp.ScreenshotForImportSave);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDlcRewardCampaign.m_Campaign"/>
    /// </summary>
    ///
    /// <param name="campaign">
    /// <para>
    /// Blueprint of type BlueprintCampaign. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetCampaign(Blueprint<BlueprintCampaignReference> campaign)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Campaign = campaign?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDlcRewardCampaign.m_Campaign"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyCampaign(Action<BlueprintCampaignReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Campaign is null) { return; }
          action.Invoke(bp.m_Campaign);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.m_Campaign is null)
      {
        Blueprint.m_Campaign = BlueprintTool.GetRef<BlueprintCampaignReference>(null);
      }
    }
  }
}
