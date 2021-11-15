using BlueprintCore.Utils;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Blueprints;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>Configurator for <see cref="BlueprintArmyPreset"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintArmyPreset))]
  public class ArmyPresetConfigurator : BaseBlueprintConfigurator<BlueprintArmyPreset, ArmyPresetConfigurator>
  {
     private ArmyPresetConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ArmyPresetConfigurator For(string name)
    {
      return new ArmyPresetConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ArmyPresetConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintArmyPreset>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ArmyPresetConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintArmyPreset>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmyPreset.Morale"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyPresetConfigurator SetMorale(int value)
    {
      return OnConfigureInternal(bp => bp.Morale = value);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmyPreset.Squads"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyPresetConfigurator AddToSquads(params BlueprintArmyPreset.UnitAndCount[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Squads = CommonTool.Append(bp.Squads, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintArmyPreset.Squads"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyPresetConfigurator RemoveFromSquads(params BlueprintArmyPreset.UnitAndCount[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Squads = bp.Squads.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmyPreset.m_Leader"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="value"><see cref="BlueprintArmyLeader"/></param>
    [Generated]
    public ArmyPresetConfigurator SetLeader(string value)
    {
      return OnConfigureInternal(bp => bp.m_Leader = BlueprintTool.GetRef<BlueprintArmyLeaderReference>(value));
    }

    /// <summary>
    /// Sets <see cref="BlueprintArmyPreset.m_ArmyType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public ArmyPresetConfigurator SetArmyType(ArmyType value)
    {
      ValidateParam(value);
      return OnConfigureInternal(bp => bp.m_ArmyType = value);
    }
  }
}
