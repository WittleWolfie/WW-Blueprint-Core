//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.Root;
using Kingmaker.DLC;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.Settings;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Root
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintCampaign"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseCampaignConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : BlueprintCampaign
    where TBuilder : BaseCampaignConfigurator<T, TBuilder>
  {
    protected BaseCampaignConfigurator(Blueprint<T, BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCampaign.Title"/>
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
    /// Modifies <see cref="BlueprintCampaign.Title"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintCampaign.Description"/>
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
    /// Modifies <see cref="BlueprintCampaign.Description"/> by invoking the provided action.
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
    /// Sets the value of <see cref="BlueprintCampaign.KeyArtLink"/>
    /// </summary>
    public TBuilder SetKeyArtLink(SpriteLink keyArtLink)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(keyArtLink);
          bp.KeyArtLink = keyArtLink;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCampaign.KeyArtLink"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyKeyArtLink(Action<SpriteLink> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.KeyArtLink is null) { return; }
          action.Invoke(bp.KeyArtLink);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCampaign.ComingSoon"/>
    /// </summary>
    public TBuilder SetComingSoon(bool comingSoon = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ComingSoon = comingSoon;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCampaign.ComingSoon"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyComingSoon(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ComingSoon);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCampaign.HideInRelease"/>
    /// </summary>
    public TBuilder SetHideInRelease(bool hideInRelease = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HideInRelease = hideInRelease;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCampaign.HideInRelease"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyHideInRelease(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.HideInRelease);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCampaign.ToBeContinued"/>
    /// </summary>
    public TBuilder SetToBeContinued(bool toBeContinued = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ToBeContinued = toBeContinued;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCampaign.ToBeContinued"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyToBeContinued(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.ToBeContinued);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCampaign.m_StartGamePreset"/>
    /// </summary>
    ///
    /// <param name="startGamePreset">
    /// <para>
    /// Blueprint of type BlueprintAreaPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetStartGamePreset(Blueprint<BlueprintAreaPreset, BlueprintAreaPresetReference> startGamePreset)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_StartGamePreset = startGamePreset?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCampaign.m_StartGamePreset"/> by invoking the provided action.
    /// </summary>
    ///
    /// <param name="startGamePreset">
    /// <para>
    /// Blueprint of type BlueprintAreaPreset. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyStartGamePreset(Action<BlueprintAreaPresetReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_StartGamePreset is null) { return; }
          action.Invoke(bp.m_StartGamePreset);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCampaign.m_Pregens"/>
    /// </summary>
    ///
    /// <param name="pregens">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetPregens(List<Blueprint<BlueprintUnit, BlueprintUnitReference>> pregens)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Pregens = pregens?.Select(bp => bp.Reference)?.ToArray();
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintCampaign.m_Pregens"/>
    /// </summary>
    ///
    /// <param name="pregens">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToPregens(params Blueprint<BlueprintUnit, BlueprintUnitReference>[] pregens)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Pregens = bp.m_Pregens ?? new BlueprintUnitReference[0];
          bp.m_Pregens = CommonTool.Append(bp.m_Pregens, pregens.Select(bp => bp.Reference).ToArray());
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCampaign.m_Pregens"/>
    /// </summary>
    ///
    /// <param name="pregens">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromPregens(params Blueprint<BlueprintUnit, BlueprintUnitReference>[] pregens)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Pregens is null) { return; }
          bp.m_Pregens = bp.m_Pregens.Where(val => !pregens.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCampaign.m_Pregens"/> that match the provided predicate.
    /// </summary>
    ///
    /// <param name="pregens">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromPregens(Func<BlueprintUnitReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Pregens is null) { return; }
          bp.m_Pregens = bp.m_Pregens.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintCampaign.m_Pregens"/>
    /// </summary>
    ///
    /// <param name="pregens">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ClearPregens()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Pregens = new BlueprintUnitReference[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCampaign.m_Pregens"/> by invoking the provided action on each element.
    /// </summary>
    ///
    /// <param name="pregens">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder ModifyPregens(Action<BlueprintUnitReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Pregens is null) { return; }
          bp.m_Pregens.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCampaign.IsMainGameContent"/>
    /// </summary>
    public TBuilder SetIsMainGameContent(bool isMainGameContent = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsMainGameContent = isMainGameContent;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCampaign.IsMainGameContent"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIsMainGameContent(Action<bool> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.IsMainGameContent);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCampaign.m_IsAvailable"/>
    /// </summary>
    public TBuilder SetIsAvailable(bool isAvailable)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_IsAvailable = isAvailable;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCampaign.m_IsAvailable"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyIsAvailable(Action<bool?> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.m_IsAvailable);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCampaign.m_DlcReward"/>
    /// </summary>
    public TBuilder SetDlcReward(BlueprintDlcRewardCampaign dlcReward)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(dlcReward);
          bp.m_DlcReward = dlcReward;
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCampaign.m_DlcReward"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyDlcReward(Action<BlueprintDlcRewardCampaign> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_DlcReward is null) { return; }
          action.Invoke(bp.m_DlcReward);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCampaign.ImportSettings"/>
    /// </summary>
    public TBuilder SetImportSettings(SaveImportSettings[] importSettings)
    {
      return OnConfigureInternal(
        bp =>
        {
          foreach (var item in importSettings) { Validate(item); }
          bp.ImportSettings = importSettings;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="BlueprintCampaign.ImportSettings"/>
    /// </summary>
    public TBuilder AddToImportSettings(params SaveImportSettings[] importSettings)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ImportSettings = bp.ImportSettings ?? new SaveImportSettings[0];
          bp.ImportSettings = CommonTool.Append(bp.ImportSettings, importSettings);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCampaign.ImportSettings"/>
    /// </summary>
    public TBuilder RemoveFromImportSettings(params SaveImportSettings[] importSettings)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ImportSettings is null) { return; }
          bp.ImportSettings = bp.ImportSettings.Where(val => !importSettings.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="BlueprintCampaign.ImportSettings"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromImportSettings(Func<SaveImportSettings, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ImportSettings is null) { return; }
          bp.ImportSettings = bp.ImportSettings.Where(predicate).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintCampaign.ImportSettings"/>
    /// </summary>
    public TBuilder ClearImportSettings()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.ImportSettings = new SaveImportSettings[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCampaign.ImportSettings"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyImportSettings(Action<SaveImportSettings> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.ImportSettings is null) { return; }
          bp.ImportSettings.ForEach(action);
        });
    }

    /// <summary>
    /// Adds <see cref="BlueprintCampaignCustomCompanion"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// </list>
    /// </remarks>
    ///
    /// <param name="customCompanion">
    /// <para>
    /// Blueprint of type BlueprintUnit. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintCore.Utils.BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="BlueprintCore.Utils.Blueprint{{T, TRef}}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddBlueprintCampaignCustomCompanion(
        Blueprint<BlueprintUnit, BlueprintUnitReference>? customCompanion = null)
    {
      var component = new BlueprintCampaignCustomCompanion();
      component.m_CustomCompanion = customCompanion?.Reference ?? component.m_CustomCompanion;
      if (component.m_CustomCompanion is null)
      {
        component.m_CustomCompanion = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BlueprintCampaignRestBehaviour"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// </list>
    /// </remarks>
    public TBuilder AddBlueprintCampaignRestBehaviour(
        bool? removeDeathDoor = null,
        GameDifficultyOption? removeDeathDoorDifficultyMax = null)
    {
      var component = new BlueprintCampaignRestBehaviour();
      component.m_RemoveDeathDoor = removeDeathDoor ?? component.m_RemoveDeathDoor;
      component.m_RemoveDeathDoorDifficultyMax = removeDeathDoorDifficultyMax ?? component.m_RemoveDeathDoorDifficultyMax;
      return AddComponent(component);
    }
  }
}
