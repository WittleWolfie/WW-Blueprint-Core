//***** AUTO-GENERATED - DO NOT EDIT *****//

using BlueprintCore.Utils;
using Kingmaker.Achievements;
using Kingmaker.Achievements.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Settings;
using Kingmaker.Settings.Difficulty;
using Kingmaker.Utility;
using System;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Achievements
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="AchievementData"/>.
  /// </summary>
  /// <inheritdoc/>
  public abstract class BaseAchievementDataConfigurator<T, TBuilder>
    : BaseBlueprintConfigurator<T, TBuilder>
    where T : AchievementData
    where TBuilder : BaseAchievementDataConfigurator<T, TBuilder>
  {
    protected BaseAchievementDataConfigurator(Blueprint<BlueprintReference<T>> blueprint) : base(blueprint) { }

    /// <summary>
    /// Sets the value of <see cref="AchievementData.m_UnlockedIcon"/>
    /// </summary>
    public TBuilder SetUnlockedIcon(Texture2D unlockedIcon)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(unlockedIcon);
          bp.m_UnlockedIcon = unlockedIcon;
        });
    }

    /// <summary>
    /// Modifies <see cref="AchievementData.m_UnlockedIcon"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyUnlockedIcon(Action<Texture2D> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_UnlockedIcon is null) { return; }
          action.Invoke(bp.m_UnlockedIcon);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AchievementData.m_LockedIcon"/>
    /// </summary>
    public TBuilder SetLockedIcon(Texture2D lockedIcon)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(lockedIcon);
          bp.m_LockedIcon = lockedIcon;
        });
    }

    /// <summary>
    /// Modifies <see cref="AchievementData.m_LockedIcon"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyLockedIcon(Action<Texture2D> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_LockedIcon is null) { return; }
          action.Invoke(bp.m_LockedIcon);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AchievementData.Type"/>
    /// </summary>
    public TBuilder SetType(AchievementType type)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Type = type;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AchievementData.Steam"/>
    /// </summary>
    public TBuilder SetSteam(AchievementData.PlatformSettingsSteam steam)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Steam = steam;
        });
    }

    /// <summary>
    /// Modifies <see cref="AchievementData.Steam"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySteam(Action<AchievementData.PlatformSettingsSteam> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Steam);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AchievementData.GOG"/>
    /// </summary>
    public TBuilder SetGOG(AchievementData.PlatformSettingsGOG gOG)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(gOG);
          bp.GOG = gOG;
        });
    }

    /// <summary>
    /// Modifies <see cref="AchievementData.GOG"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyGOG(Action<AchievementData.PlatformSettingsGOG> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.GOG is null) { return; }
          action.Invoke(bp.GOG);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AchievementData.Epic"/>
    /// </summary>
    public TBuilder SetEpic(AchievementData.PlatformSettingsEpic epic)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Epic = epic;
        });
    }

    /// <summary>
    /// Modifies <see cref="AchievementData.Epic"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyEpic(Action<AchievementData.PlatformSettingsEpic> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          action.Invoke(bp.Epic);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AchievementData.PS4"/>
    /// </summary>
    public TBuilder SetPS4(AchievementData.PlatformSettingsPS4 pS4)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(pS4);
          bp.PS4 = pS4;
        });
    }

    /// <summary>
    /// Modifies <see cref="AchievementData.PS4"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyPS4(Action<AchievementData.PlatformSettingsPS4> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.PS4 is null) { return; }
          action.Invoke(bp.PS4);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AchievementData.XBoxOne"/>
    /// </summary>
    public TBuilder SetXBoxOne(AchievementData.PlatformSettingsXBoxOne xBoxOne)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(xBoxOne);
          bp.XBoxOne = xBoxOne;
        });
    }

    /// <summary>
    /// Modifies <see cref="AchievementData.XBoxOne"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyXBoxOne(Action<AchievementData.PlatformSettingsXBoxOne> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.XBoxOne is null) { return; }
          action.Invoke(bp.XBoxOne);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AchievementData.Hidden"/>
    /// </summary>
    public TBuilder SetHidden(bool hidden = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Hidden = hidden;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AchievementData.OnlyMainCampaign"/>
    /// </summary>
    public TBuilder SetOnlyMainCampaign(bool onlyMainCampaign = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.OnlyMainCampaign = onlyMainCampaign;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AchievementData.SpecificCampaign"/>
    /// </summary>
    ///
    /// <param name="specificCampaign">
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
    public TBuilder SetSpecificCampaign(Blueprint<BlueprintCampaignReference> specificCampaign)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.SpecificCampaign = specificCampaign?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="AchievementData.SpecificCampaign"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifySpecificCampaign(Action<BlueprintCampaignReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.SpecificCampaign is null) { return; }
          action.Invoke(bp.SpecificCampaign);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AchievementData.MinDifficulty"/>
    /// </summary>
    public TBuilder SetMinDifficulty(DifficultyPresetAsset minDifficulty)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(minDifficulty);
          bp.MinDifficulty = minDifficulty;
        });
    }

    /// <summary>
    /// Modifies <see cref="AchievementData.MinDifficulty"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyMinDifficulty(Action<DifficultyPresetAsset> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.MinDifficulty is null) { return; }
          action.Invoke(bp.MinDifficulty);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AchievementData.MinCrusadeDifficulty"/>
    /// </summary>
    public TBuilder SetMinCrusadeDifficulty(KingdomDifficulty minCrusadeDifficulty)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.MinCrusadeDifficulty = minCrusadeDifficulty;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AchievementData.IronMan"/>
    /// </summary>
    public TBuilder SetIronMan(bool ironMan = true)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.IronMan = ironMan;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AchievementData.AchievementName"/>
    /// </summary>
    public TBuilder SetAchievementName(string achievementName)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.AchievementName = achievementName;
        });
    }

    /// <summary>
    /// Modifies <see cref="AchievementData.AchievementName"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyAchievementName(Action<string> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.AchievementName is null) { return; }
          action.Invoke(bp.AchievementName);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AchievementData.EventsCountForUnlock"/>
    /// </summary>
    public TBuilder SetEventsCountForUnlock(int eventsCountForUnlock)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.EventsCountForUnlock = eventsCountForUnlock;
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AchievementData.m_FinishGameFlag"/>
    /// </summary>
    ///
    /// <param name="finishGameFlag">
    /// <para>
    /// Blueprint of type BlueprintUnlockableFlag. You can pass in the blueprint using:
    /// <list type ="bullet">
    ///   <item><term>A blueprint instance</term></item>
    ///   <item><term>A blueprint reference</term></item>
    ///   <item><term>A blueprint id as a string, Guid, or BlueprintGuid</term></item>
    ///   <item><term>A blueprint name registered with <see cref="BlueprintTool">BlueprintTool</see></term></item>
    /// </list>
    /// See <see cref="Blueprint{TRef}">Blueprint</see> for more details.
    /// </para>
    /// </param>
    public TBuilder SetFinishGameFlag(Blueprint<BlueprintUnlockableFlagReference> finishGameFlag)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.m_FinishGameFlag = finishGameFlag?.Reference;
        });
    }

    /// <summary>
    /// Modifies <see cref="AchievementData.m_FinishGameFlag"/> by invoking the provided action.
    /// </summary>
    public TBuilder ModifyFinishGameFlag(Action<BlueprintUnlockableFlagReference> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.m_FinishGameFlag is null) { return; }
          action.Invoke(bp.m_FinishGameFlag);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AchievementData.Flags"/>
    /// </summary>
    public TBuilder SetFlags(params AchievementData.UnlockableFlagsPack[] flags)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(flags);
          bp.Flags = flags;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="AchievementData.Flags"/>
    /// </summary>
    public TBuilder AddToFlags(params AchievementData.UnlockableFlagsPack[] flags)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Flags = bp.Flags ?? new AchievementData.UnlockableFlagsPack[0];
          bp.Flags = CommonTool.Append(bp.Flags, flags);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="AchievementData.Flags"/>
    /// </summary>
    public TBuilder RemoveFromFlags(params AchievementData.UnlockableFlagsPack[] flags)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Flags is null) { return; }
          bp.Flags = bp.Flags.Where(val => !flags.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="AchievementData.Flags"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromFlags(Func<AchievementData.UnlockableFlagsPack, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Flags is null) { return; }
          bp.Flags = bp.Flags.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="AchievementData.Flags"/>
    /// </summary>
    public TBuilder ClearFlags()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Flags = new AchievementData.UnlockableFlagsPack[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="AchievementData.Flags"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyFlags(Action<AchievementData.UnlockableFlagsPack> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Flags is null) { return; }
          bp.Flags.ForEach(action);
        });
    }

    /// <summary>
    /// Sets the value of <see cref="AchievementData.Etudes"/>
    /// </summary>
    public TBuilder SetEtudes(params AchievementData.EtudesPack[] etudes)
    {
      return OnConfigureInternal(
        bp =>
        {
          Validate(etudes);
          bp.Etudes = etudes;
        });
    }

    /// <summary>
    /// Adds to the contents of <see cref="AchievementData.Etudes"/>
    /// </summary>
    public TBuilder AddToEtudes(params AchievementData.EtudesPack[] etudes)
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Etudes = bp.Etudes ?? new AchievementData.EtudesPack[0];
          bp.Etudes = CommonTool.Append(bp.Etudes, etudes);
        });
    }

    /// <summary>
    /// Removes elements from <see cref="AchievementData.Etudes"/>
    /// </summary>
    public TBuilder RemoveFromEtudes(params AchievementData.EtudesPack[] etudes)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Etudes is null) { return; }
          bp.Etudes = bp.Etudes.Where(val => !etudes.Contains(val)).ToArray();
        });
    }

    /// <summary>
    /// Removes elements from <see cref="AchievementData.Etudes"/> that match the provided predicate.
    /// </summary>
    public TBuilder RemoveFromEtudes(Func<AchievementData.EtudesPack, bool> predicate)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Etudes is null) { return; }
          bp.Etudes = bp.Etudes.Where(e => !predicate(e)).ToArray();
        });
    }

    /// <summary>
    /// Removes all elements from <see cref="AchievementData.Etudes"/>
    /// </summary>
    public TBuilder ClearEtudes()
    {
      return OnConfigureInternal(
        bp =>
        {
          bp.Etudes = new AchievementData.EtudesPack[0];
        });
    }

    /// <summary>
    /// Modifies <see cref="AchievementData.Etudes"/> by invoking the provided action on each element.
    /// </summary>
    public TBuilder ModifyEtudes(Action<AchievementData.EtudesPack> action)
    {
      return OnConfigureInternal(
        bp =>
        {
          if (bp.Etudes is null) { return; }
          bp.Etudes.ForEach(action);
        });
    }

    protected override void OnConfigureCompleted()
    {
      base.OnConfigureCompleted();
    
      if (Blueprint.SpecificCampaign is null)
      {
        Blueprint.SpecificCampaign = BlueprintTool.GetRef<BlueprintCampaignReference>(null);
      }
      if (Blueprint.m_FinishGameFlag is null)
      {
        Blueprint.m_FinishGameFlag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(null);
      }
      if (Blueprint.Flags is null)
      {
        Blueprint.Flags = new AchievementData.UnlockableFlagsPack[0];
      }
      if (Blueprint.Etudes is null)
      {
        Blueprint.Etudes = new AchievementData.EtudesPack[0];
      }
    }
  }
}
