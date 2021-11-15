using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.Classes
{
  /// <summary>Configurator for <see cref="BlueprintLevelUpPlanFeaturesList"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintLevelUpPlanFeaturesList))]
  public class LevelUpPlanFeaturesListConfigurator : BaseFeatureConfigurator<BlueprintLevelUpPlanFeaturesList, LevelUpPlanFeaturesListConfigurator>
  {
     private LevelUpPlanFeaturesListConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static LevelUpPlanFeaturesListConfigurator For(string name)
    {
      return new LevelUpPlanFeaturesListConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static LevelUpPlanFeaturesListConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintLevelUpPlanFeaturesList>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static LevelUpPlanFeaturesListConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintLevelUpPlanFeaturesList>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintLevelUpPlanFeaturesList.Features"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LevelUpPlanFeaturesListConfigurator AddToFeatures(params BlueprintLevelUpPlanFeaturesList.FeatureWrapper[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Features = CommonTool.Append(bp.Features, values));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintLevelUpPlanFeaturesList.Features"/> (Auto Generated)
    /// </summary>
    [Generated]
    public LevelUpPlanFeaturesListConfigurator RemoveFromFeatures(params BlueprintLevelUpPlanFeaturesList.FeatureWrapper[] values)
    {
      foreach (var item in values)
      {
        ValidateParam(item);
      }
      return OnConfigureInternal(bp => bp.Features = bp.Features.Where(item => !values.Contains(item)).ToArray());
    }
  }
}
