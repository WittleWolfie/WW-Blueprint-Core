using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;
using Kingmaker.DLC;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.Settings;
using System;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Root
{
  /// <summary>
  /// Configurator for <see cref="BlueprintCampaign"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCampaign))]
  public class CampaignConfigurator : BaseBlueprintConfigurator<BlueprintCampaign, CampaignConfigurator>
  {
    private CampaignConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CampaignConfigurator For(string name)
    {
      return new CampaignConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CampaignConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintCampaign>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCampaign.Title"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CampaignConfigurator SetTitle(LocalizedString? title)
    {
      ValidateParam(title);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Title = title ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCampaign.Description"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CampaignConfigurator SetDescription(LocalizedString? description)
    {
      ValidateParam(description);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Description = description ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCampaign.KeyArtLink"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CampaignConfigurator SetKeyArtLink(SpriteLink keyArtLink)
    {
      ValidateParam(keyArtLink);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.KeyArtLink = keyArtLink;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCampaign.ComingSoon"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CampaignConfigurator SetComingSoon(bool comingSoon)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ComingSoon = comingSoon;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCampaign.HideInRelease"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CampaignConfigurator SetHideInRelease(bool hideInRelease)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HideInRelease = hideInRelease;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCampaign.ToBeContinued"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CampaignConfigurator SetToBeContinued(bool toBeContinued)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ToBeContinued = toBeContinued;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCampaign.m_StartGamePreset"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="startGamePreset"><see cref="Kingmaker.Blueprints.Area.BlueprintAreaPreset"/></param>
    [Generated]
    public CampaignConfigurator SetStartGamePreset(string? startGamePreset)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_StartGamePreset = BlueprintTool.GetRef<BlueprintAreaPresetReference>(startGamePreset);
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCampaign.m_Pregens"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="pregens"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public CampaignConfigurator SetPregens(string[]? pregens)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Pregens = pregens.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintCampaign.m_Pregens"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="pregens"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public CampaignConfigurator AddToPregens(params string[] pregens)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Pregens = CommonTool.Append(bp.m_Pregens, pregens.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintCampaign.m_Pregens"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="pregens"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    public CampaignConfigurator RemoveFromPregens(params string[] pregens)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = pregens.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name));
            bp.m_Pregens =
                bp.m_Pregens
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCampaign.IsMainGameContent"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CampaignConfigurator SetIsMainGameContent(bool isMainGameContent)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IsMainGameContent = isMainGameContent;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCampaign.m_IsAvailable"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CampaignConfigurator SetIsAvailable(bool? isAvailable)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_IsAvailable = isAvailable;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCampaign.m_DlcReward"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CampaignConfigurator SetDlcReward(BlueprintDlcRewardCampaign dlcReward)
    {
      ValidateParam(dlcReward);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.m_DlcReward = dlcReward;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCampaign.ImportSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CampaignConfigurator SetImportSettings(SaveImportSettings[]? importSettings)
    {
      ValidateParam(importSettings);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.ImportSettings = importSettings;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintCampaign.ImportSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CampaignConfigurator AddToImportSettings(params SaveImportSettings[] importSettings)
    {
      ValidateParam(importSettings);
      return OnConfigureInternal(
          bp =>
          {
            bp.ImportSettings = CommonTool.Append(bp.ImportSettings, importSettings ?? new SaveImportSettings[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintCampaign.ImportSettings"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CampaignConfigurator RemoveFromImportSettings(params SaveImportSettings[] importSettings)
    {
      ValidateParam(importSettings);
      return OnConfigureInternal(
          bp =>
          {
            bp.ImportSettings = bp.ImportSettings.Where(item => !importSettings.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Adds <see cref="BlueprintCampaignCustomCompanion"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="customCompanion"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(BlueprintCampaignCustomCompanion))]
    public CampaignConfigurator AddBlueprintCampaignCustomCompanion(
        string? customCompanion = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new BlueprintCampaignCustomCompanion();
      component.m_CustomCompanion = BlueprintTool.GetRef<BlueprintUnitReference>(customCompanion);
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="BlueprintCampaignRestBehaviour"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BlueprintCampaignRestBehaviour))]
    public CampaignConfigurator AddBlueprintCampaignRestBehaviour(
        bool removeDeathDoor = default,
        GameDifficultyOption removeDeathDoorDifficultyMax = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new BlueprintCampaignRestBehaviour();
      component.m_RemoveDeathDoor = removeDeathDoor;
      component.m_RemoveDeathDoorDifficultyMax = removeDeathDoorDifficultyMax;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }
  }
}
