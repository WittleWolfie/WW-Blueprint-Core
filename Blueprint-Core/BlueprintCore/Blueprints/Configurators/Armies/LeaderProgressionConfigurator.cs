using BlueprintCore.Utils;
using Kingmaker.Armies;
using Kingmaker.Localization;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>Configurator for <see cref="BlueprintLeaderProgression"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintLeaderProgression))]
  public class LeaderProgressionConfigurator : BaseBlueprintConfigurator<BlueprintLeaderProgression, LeaderProgressionConfigurator>
  {
     private LeaderProgressionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static LeaderProgressionConfigurator For(string name)
    {
      return new LeaderProgressionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static LeaderProgressionConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintLeaderProgression>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static LeaderProgressionConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintLeaderProgression>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintLeaderProgression.m_ProgressionType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeaderProgressionConfigurator SetProgressionType(LeaderProgressionType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_ProgressionType = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintLeaderProgression.m_ProgressionName"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeaderProgressionConfigurator SetProgressionName(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_ProgressionName = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintLeaderProgression.m_Levels"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeaderProgressionConfigurator AddToLevels(params LeaderLevel[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_Levels = CommonTool.Append(bp.m_Levels, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintLeaderProgression.m_Levels"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LeaderProgressionConfigurator RemoveFromLevels(params LeaderLevel[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_Levels = bp.m_Levels.Where(item => !values.Contains(item)).ToArray());
    }
  }
}
