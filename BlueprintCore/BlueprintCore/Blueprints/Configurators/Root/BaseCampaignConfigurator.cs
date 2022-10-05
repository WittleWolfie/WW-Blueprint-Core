//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;
using Kingmaker.DLC;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.Settings;
using Kingmaker.Sound;
using Kingmaker.UI.SettingsUI;
using Kingmaker.Utility;
using System;
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
    protected BaseCampaignConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <inheritdoc cref="RootConfigurator{T, TBuilder}.CopyFrom(Blueprint{BlueprintReference{BlueprintScriptableObject}}, Type[])"/>
    public TBuilder CopyFrom(
      Blueprint<BlueprintReference<BlueprintCampaign>> blueprint, params Type[] componentTypes)
    {
      base.CopyFrom(blueprint.ToString(), componentTypes);
    
      return OnConfigureInternal(
        bp =>
        {
          var copyFrom = blueprint.Reference.Get();
          bp.Title = copyFrom.Title;
          bp.Description = copyFrom.Description;
          bp.KeyArtLink = copyFrom.KeyArtLink;
          bp.ComingSoon = copyFrom.ComingSoon;
          bp.HideInRelease = copyFrom.HideInRelease;
          bp.HideInUI = copyFrom.HideInUI;
          bp.ToBeContinued = copyFrom.ToBeContinued;
          bp.IsDungeon = copyFrom.IsDungeon;
          bp.AllowMythicChange = copyFrom.AllowMythicChange;
          bp.AudioChunk = copyFrom.AudioChunk;
          bp.m_StartGamePreset = copyFrom.m_StartGamePreset;
          bp.m_Pregens = copyFrom.m_Pregens;
          bp.IsMainGameContent = copyFrom.IsMainGameContent;
          bp.m_IsAvailable = copyFrom.m_IsAvailable;
          bp.m_DlcReward = copyFrom.m_DlcReward;
          bp.ImportSettings = copyFrom.ImportSettings;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCampaign.Title"/>
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
    ///
    /// <param name="keyArtLink">
    /// You can pass in the animation using a SpriteLink or it's AssetId.
    /// </param>
    public TBuilder SetKeyArtLink(AssetLink<SpriteLink> keyArtLink)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.KeyArtLink = keyArtLink?.Get();
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
    /// Sets the value of <see cref="BlueprintCampaign.HideInUI"/>
    /// </summary>
    public TBuilder SetHideInUI(bool hideInUI = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.HideInUI = hideInUI;
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
    /// Sets the value of <see cref="BlueprintCampaign.IsDungeon"/>
    /// </summary>
    public TBuilder SetIsDungeon(bool isDungeon = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IsDungeon = isDungeon;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCampaign.AllowMythicChange"/>
    /// </summary>
    public TBuilder SetAllowMythicChange(bool allowMythicChange = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AllowMythicChange = allowMythicChange;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="BlueprintCampaign.AudioChunk"/>
    /// </summary>
    public TBuilder SetAudioChunk(AudioFilePackagesSettings.AudioChunk audioChunk)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AudioChunk = audioChunk;
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetStartGamePreset(Blueprint<BlueprintAreaPresetReference> startGamePreset)
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetPregens(params Blueprint<BlueprintUnitReference>[] pregens)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_Pregens = pregens.Select(bp => bp.Reference).ToArray();
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddToPregens(params Blueprint<BlueprintUnitReference>[] pregens)
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
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder RemoveFromPregens(params Blueprint<BlueprintUnitReference>[] pregens)
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
    public TBuilder RemoveFromPregens(Func<BlueprintUnitReference, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_Pregens is null) { return; }
          bp.m_Pregens = bp.m_Pregens.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="BlueprintCampaign.m_Pregens"/>
    /// </summary>
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
    public TBuilder SetImportSettings(params SaveImportSettings[] importSettings)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(importSettings);
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
          bp.ImportSettings = bp.ImportSettings.Where(e => !predicate(e)).ToArray();
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
    /// <item><term>Dlc2Campaign</term><description>e6fdda2539274c1e89d236be69f5a984</description></item>
    /// <item><term>Dlc3Campaign</term><description>e1bde745d6ad47c0bc9fb8e479b29153</description></item>
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
    public TBuilder AddBlueprintCampaignCustomCompanion(
        Blueprint<BlueprintUnitReference>? customCompanion = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail)
    {
      var component = new BlueprintCampaignCustomCompanion();
      component.m_CustomCompanion = customCompanion?.Reference ?? component.m_CustomCompanion;
      if (component.m_CustomCompanion is null)
      {
        component.m_CustomCompanion = BlueprintTool.GetRef<BlueprintUnitReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="BlueprintCampaignExperience"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Dlc3Campaign</term><description>e1bde745d6ad47c0bc9fb8e479b29153</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    /// <param name="overrideTrapsProgression">
    /// <para>
    /// InfoBox: By default, BlueprintRoot -&amp;gt; Progression -&amp;gt; DCToCRTable will be used
    /// </para>
    /// </param>
    /// <param name="trapsDCToCRTable">
    /// <para>
    /// Blueprint of type BlueprintStatProgression. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder AddBlueprintCampaignExperience(
        bool? allowChecks = null,
        bool? allowMobs = null,
        bool? allowQuests = null,
        bool? allowTraps = null,
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? overrideTrapsProgression = null,
        Blueprint<BlueprintStatProgressionReference>? trapsDCToCRTable = null)
    {
      var component = new BlueprintCampaignExperience();
      component.AllowChecks = allowChecks ?? component.AllowChecks;
      component.AllowMobs = allowMobs ?? component.AllowMobs;
      component.AllowQuests = allowQuests ?? component.AllowQuests;
      component.AllowTraps = allowTraps ?? component.AllowTraps;
      component.OverrideTrapsProgression = overrideTrapsProgression ?? component.OverrideTrapsProgression;
      component.m_TrapsDCToCRTable = trapsDCToCRTable?.Reference ?? component.m_TrapsDCToCRTable;
      if (component.m_TrapsDCToCRTable is null)
      {
        component.m_TrapsDCToCRTable = BlueprintTool.GetRef<BlueprintStatProgressionReference>(null);
      }
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    /// <summary>
    /// Adds <see cref="BlueprintCampaignOverrideFogOfWarVisionRadius"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Dlc3Campaign</term><description>e1bde745d6ad47c0bc9fb8e479b29153</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddBlueprintCampaignOverrideFogOfWarVisionRadius(
        float? addition = null,
        float? multiplier = null)
    {
      var component = new BlueprintCampaignOverrideFogOfWarVisionRadius();
      component.Addition = addition ?? component.Addition;
      component.Multiplier = multiplier ?? component.Multiplier;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BlueprintCampaignOverrideSettingBool"/>
    /// </summary>
    ///
    /// <remarks>
    ///
    /// <list type="bullet">
    /// <listheader>Used by</listheader>
    /// <item><term>Dlc2Campaign</term><description>e6fdda2539274c1e89d236be69f5a984</description></item>
    /// <item><term>Dlc3Campaign</term><description>e1bde745d6ad47c0bc9fb8e479b29153</description></item>
    /// </list>
    /// </remarks>
    public TBuilder AddBlueprintCampaignOverrideSettingBool(
        UISettingsEntityBool? boolValue = null,
        bool? value = null)
    {
      var component = new BlueprintCampaignOverrideSettingBool();
      Validate(boolValue);
      component.Bool = boolValue ?? component.Bool;
      component.Value = value ?? component.Value;
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
    /// <item><term>Dlc2Campaign</term><description>e6fdda2539274c1e89d236be69f5a984</description></item>
    /// </list>
    /// </remarks>
    ///
    /// <param name="merge">
    /// If mergeBehavior is ComponentMerge.Merge and the component already exists, this expression is called to merge the components.
    /// </param>
    /// <param name="mergeBehavior">
    /// Handling if the component already exists since the component is unique. Defaults to ComponentMerge.Fail.
    /// </param>
    public TBuilder AddBlueprintCampaignRestBehaviour(
        Action<BlueprintComponent, BlueprintComponent>? merge = null,
        ComponentMerge mergeBehavior = ComponentMerge.Fail,
        bool? removeDeathDoor = null,
        GameDifficultyOption? removeDeathDoorDifficultyMax = null)
    {
      var component = new BlueprintCampaignRestBehaviour();
      component.m_RemoveDeathDoor = removeDeathDoor ?? component.m_RemoveDeathDoor;
      component.m_RemoveDeathDoorDifficultyMax = removeDeathDoorDifficultyMax ?? component.m_RemoveDeathDoorDifficultyMax;
      return AddUniqueComponent(component, mergeBehavior, merge);
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.Title is null)
      {
        Blueprint.Title = Utils.Constants.Empty.String;
      }
      if (Blueprint.Description is null)
      {
        Blueprint.Description = Utils.Constants.Empty.String;
      }
      if (Blueprint.m_StartGamePreset is null)
      {
        Blueprint.m_StartGamePreset = BlueprintTool.GetRef<BlueprintAreaPresetReference>(null);
      }
      if (Blueprint.m_Pregens is null)
      {
        Blueprint.m_Pregens = new BlueprintUnitReference[0];
      }
      if (Blueprint.ImportSettings is null)
      {
        Blueprint.ImportSettings = new SaveImportSettings[0];
      }
    }
  }
}
