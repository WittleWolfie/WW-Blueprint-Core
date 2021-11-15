using BlueprintCore.Utils;
using Kingmaker.Dungeon.Blueprints;
using Kingmaker.Localization;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Dungeon
{
  /// <summary>Configurator for <see cref="BlueprintDungeonLocalizedStrings"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintDungeonLocalizedStrings))]
  public class DungeonLocalizedStringsConfigurator : BaseBlueprintConfigurator<BlueprintDungeonLocalizedStrings, DungeonLocalizedStringsConfigurator>
  {
     private DungeonLocalizedStringsConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static DungeonLocalizedStringsConfigurator For(string name)
    {
      return new DungeonLocalizedStringsConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static DungeonLocalizedStringsConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintDungeonLocalizedStrings>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static DungeonLocalizedStringsConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintDungeonLocalizedStrings>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintDungeonLocalizedStrings.StageNameParameterized"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonLocalizedStringsConfigurator SetStageNameParameterized(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.StageNameParameterized = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonLocalizedStrings.LeaderboardRecordValues"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonLocalizedStringsConfigurator AddToLeaderboardRecordValues(params BlueprintDungeonLocalizedStrings.LeaderboardRecordValue[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.LeaderboardRecordValues = CommonTool.Append(bp.LeaderboardRecordValues, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonLocalizedStrings.LeaderboardRecordValues"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonLocalizedStringsConfigurator RemoveFromLeaderboardRecordValues(params BlueprintDungeonLocalizedStrings.LeaderboardRecordValue[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.LeaderboardRecordValues = bp.LeaderboardRecordValues.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonLocalizedStrings.LeaderboardCharacterValues"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonLocalizedStringsConfigurator AddToLeaderboardCharacterValues(params BlueprintDungeonLocalizedStrings.LeaderboardCharacterValue[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.LeaderboardCharacterValues = CommonTool.Append(bp.LeaderboardCharacterValues, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintDungeonLocalizedStrings.LeaderboardCharacterValues"/> (Auto Generated)
    /// </summary>
    [Generated]
    public DungeonLocalizedStringsConfigurator RemoveFromLeaderboardCharacterValues(params BlueprintDungeonLocalizedStrings.LeaderboardCharacterValue[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.LeaderboardCharacterValues = bp.LeaderboardCharacterValues.Where(item => !values.Contains(item)).ToArray());
    }
  }
}
