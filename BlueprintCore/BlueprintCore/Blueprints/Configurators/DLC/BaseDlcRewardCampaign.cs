//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;
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
    protected BaseDlcRewardCampaignConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintDlcRewardCampaign.ScreenshotForImportSave"/>
    /// </summary>
    public TBuilder SetScreenshotForImportSave(Texture2D screenshotForImportSave)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(screenshotForImportSave);
          bp.ScreenshotForImportSave = screenshotForImportSave;
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetCampaign(Blueprint<BlueprintCampaign, BlueprintCampaignReference> campaign)
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
    ///
    /// <param name="campaign">
    /// <para>
    /// Blueprint of type BlueprintCampaign. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyCampaign(Action<BlueprintCampaignReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Campaign is null) { return; }
          action.Invoke(bp.m_Campaign);
        });
    }
  }
}
