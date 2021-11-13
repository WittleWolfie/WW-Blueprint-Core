using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Achievements.Blueprints;
namespace BlueprintCore.Blueprints.Configurators.Achievements
{
  /// <summary>Configurator for <see cref="AchievementData"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(AchievementData))]
  public class AchievementDataConfigurator : BaseBlueprintConfigurator<AchievementData, AchievementDataConfigurator>
  {
     private AchievementDataConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AchievementDataConfigurator For(string name)
    {
      return new AchievementDataConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AchievementDataConfigurator New(string name)
    {
      BlueprintTool.Create<AchievementData>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AchievementDataConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<AchievementData>(name, assetId);
      return For(name);
    }

  }
}
