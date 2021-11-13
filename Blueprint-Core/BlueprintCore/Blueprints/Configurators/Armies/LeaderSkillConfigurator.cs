using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils;
using Kingmaker.Armies.Blueprints;
namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>Configurator for <see cref="BlueprintLeaderSkill"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintLeaderSkill))]
  public class LeaderSkillConfigurator : BaseBlueprintConfigurator<BlueprintLeaderSkill, LeaderSkillConfigurator>
  {
     private LeaderSkillConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static LeaderSkillConfigurator For(string name)
    {
      return new LeaderSkillConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static LeaderSkillConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintLeaderSkill>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static LeaderSkillConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintLeaderSkill>(name, assetId);
      return For(name);
    }

  }
}
