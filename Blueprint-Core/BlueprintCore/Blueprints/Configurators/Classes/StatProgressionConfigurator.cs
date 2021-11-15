using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>Configurator for <see cref="BlueprintStatProgression"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintStatProgression))]
  public class StatProgressionConfigurator : BaseBlueprintConfigurator<BlueprintStatProgression, StatProgressionConfigurator>
  {
     private StatProgressionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static StatProgressionConfigurator For(string name)
    {
      return new StatProgressionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static StatProgressionConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintStatProgression>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static StatProgressionConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintStatProgression>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintStatProgression.Bonuses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public StatProgressionConfigurator AddToBonuses(params int[] values)
    {
      return OnConfigureInternal(bp => bp.Bonuses = CommonTool.Append(bp.Bonuses, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintStatProgression.Bonuses"/> (Auto Generated)
    /// </summary>
    [Generated]
    public StatProgressionConfigurator RemoveFromBonuses(params int[] values)
    {
      return OnConfigureInternal(bp => bp.Bonuses = bp.Bonuses.Where(item => !values.Contains(item)).ToArray());
    }
  }
}
