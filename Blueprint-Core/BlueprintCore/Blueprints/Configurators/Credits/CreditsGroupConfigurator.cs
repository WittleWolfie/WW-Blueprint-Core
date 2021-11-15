using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Credits;
using Kingmaker.Localization;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Credits
{
  /// <summary>Configurator for <see cref="BlueprintCreditsGroup"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCreditsGroup))]
  public class CreditsGroupConfigurator : BaseBlueprintConfigurator<BlueprintCreditsGroup, CreditsGroupConfigurator>
  {
     private CreditsGroupConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CreditsGroupConfigurator For(string name)
    {
      return new CreditsGroupConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CreditsGroupConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintCreditsGroup>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CreditsGroupConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintCreditsGroup>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCreditsGroup.TabIcon"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CreditsGroupConfigurator SetTabIcon(Sprite value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.TabIcon = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCreditsGroup.HeaderText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CreditsGroupConfigurator SetHeaderText(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.HeaderText = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCreditsGroup.LeftPageImage"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CreditsGroupConfigurator SetLeftPageImage(Sprite value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.LeftPageImage = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCreditsGroup.LeftPageText"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CreditsGroupConfigurator SetLeftPageText(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.LeftPageText = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCreditsGroup.m_RolesData"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintCreditsRoles"/></param>
    [Generated]
    public CreditsGroupConfigurator SetRolesData(string value)
    {
      return OnConfigureInternal(bp => bp.m_RolesData = BlueprintTool.GetRef<BlueprintCreditsRolesReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintCreditsGroup.m_TeamsData"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintCreditsTeams"/></param>
    [Generated]
    public CreditsGroupConfigurator SetTeamsData(string value)
    {
      return OnConfigureInternal(bp => bp.m_TeamsData = BlueprintTool.GetRef<BlueprintCreditsTeamsReference>(value));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCreditsGroup.OrderTeams"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CreditsGroupConfigurator AddToOrderTeams(params string[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.OrderTeams.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCreditsGroup.OrderTeams"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CreditsGroupConfigurator RemoveFromOrderTeams(params string[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.OrderTeams = bp.OrderTeams.Where(item => !values.Contains(item)).ToList());
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCreditsGroup.Persones"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CreditsGroupConfigurator AddToPersones(params CreditPerson[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Persones.AddRange(values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintCreditsGroup.Persones"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CreditsGroupConfigurator RemoveFromPersones(params CreditPerson[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Persones = bp.Persones.Where(item => !values.Contains(item)).ToList());
    }
  }
}
