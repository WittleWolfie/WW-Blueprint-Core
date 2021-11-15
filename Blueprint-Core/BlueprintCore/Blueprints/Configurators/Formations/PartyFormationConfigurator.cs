using BlueprintCore.Utils;
using Kingmaker.Formations;
using Kingmaker.Localization;
using System.Linq;
using UnityEngine;

namespace BlueprintCore.Blueprints.Configurators.Formations
{
  /// <summary>Configurator for <see cref="BlueprintPartyFormation"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintPartyFormation))]
  public class PartyFormationConfigurator : BaseBlueprintConfigurator<BlueprintPartyFormation, PartyFormationConfigurator>
  {
     private PartyFormationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static PartyFormationConfigurator For(string name)
    {
      return new PartyFormationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static PartyFormationConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintPartyFormation>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static PartyFormationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintPartyFormation>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintPartyFormation.Positions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public PartyFormationConfigurator AddToPositions(params Vector2[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Positions = CommonTool.Append(bp.Positions, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintPartyFormation.Positions"/> (Auto Generated)
    /// </summary>
    [Generated]
    public PartyFormationConfigurator RemoveFromPositions(params Vector2[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Positions = bp.Positions.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="BlueprintPartyFormation.Type"/> (Auto Generated)
    /// </summary>
    [Generated]
    public PartyFormationConfigurator SetType(PartyFormationType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Type = value);
    }

    /// <summary>
    /// Sets <see cref="BlueprintPartyFormation.Name"/> (Auto Generated)
    /// </summary>
    [Generated]
    public PartyFormationConfigurator SetName(LocalizedString value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.Name = value);
    }
  }
}
