using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
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

  }
}