using BlueprintCore.Utils;
using Kingmaker.UnitLogic.Customization;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.UnitLogic.Customization
{
  /// <summary>Configurator for <see cref="RaceGenderDistribution"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(RaceGenderDistribution))]
  public class RaceGenderDistributionConfigurator : BaseBlueprintConfigurator<RaceGenderDistribution, RaceGenderDistributionConfigurator>
  {
     private RaceGenderDistributionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static RaceGenderDistributionConfigurator For(string name)
    {
      return new RaceGenderDistributionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static RaceGenderDistributionConfigurator New(string name)
    {
      BlueprintTool.Create<RaceGenderDistribution>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static RaceGenderDistributionConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<RaceGenderDistribution>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="RaceGenderDistribution.Races"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceGenderDistributionConfigurator AddToRaces(params RaceEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Races = CommonTool.Append(bp.Races, values));
    }

    /// <summary>
    /// Modifies <see cref="RaceGenderDistribution.Races"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceGenderDistributionConfigurator RemoveFromRaces(params RaceEntry[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Races = bp.Races.Where(item => !values.Contains(item)).ToArray());
    }

    /// <summary>
    /// Sets <see cref="RaceGenderDistribution.LeftHandedChance"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceGenderDistributionConfigurator SetLeftHandedChance(float value)
    {
      return OnConfigureInternal(bp => bp.LeftHandedChance = value);
    }

    /// <summary>
    /// Sets <see cref="RaceGenderDistribution.MaleBaseWeight"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceGenderDistributionConfigurator SetMaleBaseWeight(float value)
    {
      return OnConfigureInternal(bp => bp.MaleBaseWeight = value);
    }

    /// <summary>
    /// Sets <see cref="RaceGenderDistribution.FemaleBaseWeight"/> (Auto Generated)
    /// </summary>
    [Generated]
    public RaceGenderDistributionConfigurator SetFemaleBaseWeight(float value)
    {
      return OnConfigureInternal(bp => bp.FemaleBaseWeight = value);
    }
  }
}
