using BlueprintCore.Utils;
using Kingmaker.Achievements;
using Kingmaker.Achievements.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Settings;
using Kingmaker.Settings.Difficulty;
using System.Linq;
using UnityEngine;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Achievements
{
  /// <summary>
  /// Configurator for <see cref="AchievementData"/>.
  /// </summary>
  /// <inheritdoc/>
  
  public class AchievementDataConfigurator : BaseBlueprintConfigurator<AchievementData, AchievementDataConfigurator>
  {
    private AchievementDataConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AchievementDataConfigurator For(string name)
    {
      return new AchievementDataConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AchievementDataConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<AchievementData>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="AchievementData.m_UnlockedIcon"/> (Auto Generated)
    /// </summary>
    
    public AchievementDataConfigurator SetUnlockedIcon(Texture2D unlockedIcon)
    {
      ValidateParam(unlockedIcon);

      return OnConfigureInternal(
          bp =>
          {
            bp.m_UnlockedIcon = unlockedIcon;
          });
    }

    /// <summary>
    /// Sets <see cref="AchievementData.m_LockedIcon"/> (Auto Generated)
    /// </summary>
    
    public AchievementDataConfigurator SetLockedIcon(Texture2D lockedIcon)
    {
      ValidateParam(lockedIcon);

      return OnConfigureInternal(
          bp =>
          {
            bp.m_LockedIcon = lockedIcon;
          });
    }

    /// <summary>
    /// Sets <see cref="AchievementData.Type"/> (Auto Generated)
    /// </summary>
    
    public AchievementDataConfigurator SetType(AchievementType type)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Type = type;
          });
    }

    /// <summary>
    /// Sets <see cref="AchievementData.Hidden"/> (Auto Generated)
    /// </summary>
    
    public AchievementDataConfigurator SetHidden(bool hidden)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.Hidden = hidden;
          });
    }

    /// <summary>
    /// Sets <see cref="AchievementData.OnlyMainCampaign"/> (Auto Generated)
    /// </summary>
    
    public AchievementDataConfigurator SetOnlyMainCampaign(bool onlyMainCampaign)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.OnlyMainCampaign = onlyMainCampaign;
          });
    }

    /// <summary>
    /// Sets <see cref="AchievementData.MinDifficulty"/> (Auto Generated)
    /// </summary>
    
    public AchievementDataConfigurator SetMinDifficulty(DifficultyPresetAsset minDifficulty)
    {
      ValidateParam(minDifficulty);

      return OnConfigureInternal(
          bp =>
          {
            bp.MinDifficulty = minDifficulty;
          });
    }

    /// <summary>
    /// Sets <see cref="AchievementData.MinCrusadeDifficulty"/> (Auto Generated)
    /// </summary>
    
    public AchievementDataConfigurator SetMinCrusadeDifficulty(KingdomDifficulty minCrusadeDifficulty)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MinCrusadeDifficulty = minCrusadeDifficulty;
          });
    }

    /// <summary>
    /// Sets <see cref="AchievementData.IronMan"/> (Auto Generated)
    /// </summary>
    
    public AchievementDataConfigurator SetIronMan(bool ironMan)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.IronMan = ironMan;
          });
    }

    /// <summary>
    /// Sets <see cref="AchievementData.AchievementName"/> (Auto Generated)
    /// </summary>
    
    public AchievementDataConfigurator SetAchievementName(string achievementName)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.AchievementName = achievementName;
          });
    }

    /// <summary>
    /// Sets <see cref="AchievementData.EventsCountForUnlock"/> (Auto Generated)
    /// </summary>
    
    public AchievementDataConfigurator SetEventsCountForUnlock(int eventsCountForUnlock)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.EventsCountForUnlock = eventsCountForUnlock;
          });
    }

    /// <summary>
    /// Sets <see cref="AchievementData.m_FinishGameFlag"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="finishGameFlag"><see cref="Kingmaker.Blueprints.BlueprintUnlockableFlag"/></param>
    
    public AchievementDataConfigurator SetFinishGameFlag(string? finishGameFlag)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_FinishGameFlag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(finishGameFlag);
          });
    }

    /// <summary>
    /// Sets <see cref="AchievementData.Flags"/> (Auto Generated)
    /// </summary>
    
    public AchievementDataConfigurator SetFlags(AchievementData.UnlockableFlagsPack[]? flags)
    {
      ValidateParam(flags);

      return OnConfigureInternal(
          bp =>
          {
            bp.Flags = flags;
          });
    }

    /// <summary>
    /// Adds to <see cref="AchievementData.Flags"/> (Auto Generated)
    /// </summary>
    
    public AchievementDataConfigurator AddToFlags(params AchievementData.UnlockableFlagsPack[] flags)
    {
      ValidateParam(flags);
      return OnConfigureInternal(
          bp =>
          {
            bp.Flags = CommonTool.Append(bp.Flags, flags ?? new AchievementData.UnlockableFlagsPack[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="AchievementData.Flags"/> (Auto Generated)
    /// </summary>
    
    public AchievementDataConfigurator RemoveFromFlags(params AchievementData.UnlockableFlagsPack[] flags)
    {
      ValidateParam(flags);
      return OnConfigureInternal(
          bp =>
          {
            bp.Flags = bp.Flags.Where(item => !flags.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="AchievementData.Etudes"/> (Auto Generated)
    /// </summary>
    
    public AchievementDataConfigurator SetEtudes(AchievementData.EtudesPack[]? etudes)
    {
      ValidateParam(etudes);

      return OnConfigureInternal(
          bp =>
          {
            bp.Etudes = etudes;
          });
    }

    /// <summary>
    /// Adds to <see cref="AchievementData.Etudes"/> (Auto Generated)
    /// </summary>
    
    public AchievementDataConfigurator AddToEtudes(params AchievementData.EtudesPack[] etudes)
    {
      ValidateParam(etudes);
      return OnConfigureInternal(
          bp =>
          {
            bp.Etudes = CommonTool.Append(bp.Etudes, etudes ?? new AchievementData.EtudesPack[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="AchievementData.Etudes"/> (Auto Generated)
    /// </summary>
    
    public AchievementDataConfigurator RemoveFromEtudes(params AchievementData.EtudesPack[] etudes)
    {
      ValidateParam(etudes);
      return OnConfigureInternal(
          bp =>
          {
            bp.Etudes = bp.Etudes.Where(item => !etudes.Contains(item)).ToArray();
          });
    }
  }
}
