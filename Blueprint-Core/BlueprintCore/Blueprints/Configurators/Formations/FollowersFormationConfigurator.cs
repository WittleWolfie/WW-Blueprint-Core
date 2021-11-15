using BlueprintCore.Utils;
using Kingmaker.Formations;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Formations
{
  /// <summary>Configurator for <see cref="FollowersFormation"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(FollowersFormation))]
  public class FollowersFormationConfigurator : BaseBlueprintConfigurator<FollowersFormation, FollowersFormationConfigurator>
  {
     private FollowersFormationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static FollowersFormationConfigurator For(string name)
    {
      return new FollowersFormationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static FollowersFormationConfigurator New(string name)
    {
      BlueprintTool.Create<FollowersFormation>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static FollowersFormationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<FollowersFormation>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="FollowersFormation.m_PlayerOffset"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FollowersFormationConfigurator SetPlayerOffset(Vector2 value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_PlayerOffset = value);
    }

    /// <summary>
    /// Modifies <see cref="FollowersFormation.m_Formation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FollowersFormationConfigurator AddToFormation(params Vector2[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_Formation = CommonTool.Append(bp.m_Formation, values));
    }

    /// <summary>
    /// Modifies <see cref="FollowersFormation.m_Formation"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FollowersFormationConfigurator RemoveFromFormation(params Vector2[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.m_Formation = bp.m_Formation.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="FollowersFormation.m_RepathDistance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FollowersFormationConfigurator SetRepathDistance(float value)
    {
      return OnConfigureInternal(bp => bp.m_RepathDistance = value);
    }

    /// <summary>
    /// Sets <see cref="FollowersFormation.m_RepathCooldownSec"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FollowersFormationConfigurator SetRepathCooldownSec(float value)
    {
      return OnConfigureInternal(bp => bp.m_RepathCooldownSec = value);
    }

    /// <summary>
    /// Sets <see cref="FollowersFormation.m_LookAngleRandomSpread"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FollowersFormationConfigurator SetLookAngleRandomSpread(float value)
    {
      return OnConfigureInternal(bp => bp.m_LookAngleRandomSpread = value);
    }
  }
}
