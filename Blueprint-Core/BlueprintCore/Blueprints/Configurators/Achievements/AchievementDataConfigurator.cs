using BlueprintCore.Utils;
using Kingmaker.Achievements;
using Kingmaker.Achievements.Blueprints;
using Kingmaker.Blueprints;
using Kingmaker.Settings;
using Kingmaker.Settings.Difficulty;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Achievements
{
  /// <summary>Configurator for <see cref="AchievementData"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(AchievementData))]
  public class AchievementDataConfigurator : BaseBlueprintConfigurator<AchievementData, AchievementDataConfigurator>
  {
     private AchievementDataConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AchievementDataConfigurator For(string name)
    {
      return new AchievementDataConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AchievementDataConfigurator New(string name)
    {
      BlueprintTool.Create<AchievementData>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AchievementDataConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<AchievementData>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="AchievementData.m_UnlockedIcon"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AchievementDataConfigurator SetUnlockedIcon(Texture2D value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_UnlockedIcon = value);
    }

    /// <summary>
    /// Sets <see cref="AchievementData.m_LockedIcon"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AchievementDataConfigurator SetLockedIcon(Texture2D value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_LockedIcon = value);
    }

    /// <summary>
    /// Sets <see cref="AchievementData.Type"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AchievementDataConfigurator SetType(AchievementType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Type = value);
    }

    /// <summary>
    /// Sets <see cref="AchievementData.SteamId"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AchievementDataConfigurator SetSteamId(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.SteamId = value);
    }

    /// <summary>
    /// Sets <see cref="AchievementData.GogId"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AchievementDataConfigurator SetGogId(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.GogId = value);
    }

    /// <summary>
    /// Sets <see cref="AchievementData.EpicId"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AchievementDataConfigurator SetEpicId(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.EpicId = value);
    }

    /// <summary>
    /// Sets <see cref="AchievementData.PS4TrophyID"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AchievementDataConfigurator SetPS4TrophyID(int value)
    {
      return OnConfigureInternal(bp => bp.PS4TrophyID = value);
    }

    /// <summary>
    /// Sets <see cref="AchievementData.XboxId"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AchievementDataConfigurator SetXboxId(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.XboxId = value);
    }

    /// <summary>
    /// Sets <see cref="AchievementData.Hidden"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AchievementDataConfigurator SetHidden(bool value)
    {
      return OnConfigureInternal(bp => bp.Hidden = value);
    }

    /// <summary>
    /// Sets <see cref="AchievementData.OnlyMainCampaign"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AchievementDataConfigurator SetOnlyMainCampaign(bool value)
    {
      return OnConfigureInternal(bp => bp.OnlyMainCampaign = value);
    }

    /// <summary>
    /// Sets <see cref="AchievementData.SpecificDlc"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintDlcReward"/></param>
    [Generated]
    public AchievementDataConfigurator SetSpecificDlc(string value)
    {
      return OnConfigureInternal(bp => bp.SpecificDlc = BlueprintTool.GetRef<BlueprintDlcRewardReference>(value));
    }

    /// <summary>
    /// Sets <see cref="AchievementData.MinDifficulty"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AchievementDataConfigurator SetMinDifficulty(DifficultyPresetAsset value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.MinDifficulty = value);
    }

    /// <summary>
    /// Sets <see cref="AchievementData.MinCrusadeDifficulty"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AchievementDataConfigurator SetMinCrusadeDifficulty(KingdomDifficulty value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.MinCrusadeDifficulty = value);
    }

    /// <summary>
    /// Sets <see cref="AchievementData.IronMan"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AchievementDataConfigurator SetIronMan(bool value)
    {
      return OnConfigureInternal(bp => bp.IronMan = value);
    }

    /// <summary>
    /// Sets <see cref="AchievementData.AchievementName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AchievementDataConfigurator SetAchievementName(string value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.AchievementName = value);
    }

    /// <summary>
    /// Sets <see cref="AchievementData.EventsCountForUnlock"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AchievementDataConfigurator SetEventsCountForUnlock(int value)
    {
      return OnConfigureInternal(bp => bp.EventsCountForUnlock = value);
    }

    /// <summary>
    /// Sets <see cref="AchievementData.m_FinishGameFlag"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintUnlockableFlag"/></param>
    [Generated]
    public AchievementDataConfigurator SetFinishGameFlag(string value)
    {
      return OnConfigureInternal(bp => bp.m_FinishGameFlag = BlueprintTool.GetRef<BlueprintUnlockableFlagReference>(value));
    }

    /// <summary>
    /// Modifies <see cref="AchievementData.Flags"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AchievementDataConfigurator AddToFlags(params AchievementData.UnlockableFlagsPack[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Flags = CommonTool.Append(bp.Flags, values));
    }

    /// <summary>
    /// Modifies <see cref="AchievementData.Flags"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AchievementDataConfigurator RemoveFromFlags(params AchievementData.UnlockableFlagsPack[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Flags = bp.Flags.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="AchievementData.Etudes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AchievementDataConfigurator AddToEtudes(params AchievementData.EtudesPack[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Etudes = CommonTool.Append(bp.Etudes, values));
    }

    /// <summary>
    /// Modifies <see cref="AchievementData.Etudes"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AchievementDataConfigurator RemoveFromEtudes(params AchievementData.EtudesPack[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Etudes = bp.Etudes.Where(item => !values.Contains(item)).ToArray());
    }
  }
}
