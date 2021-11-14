using BlueprintCore.Utils;
using Kingmaker.Armies;

namespace BlueprintCore.Blueprints.Configurators.Armies
{
  /// <summary>Configurator for <see cref="BlueprintLeaderSkillsList"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintLeaderSkillsList))]
  public class LeaderSkillsListConfigurator : BaseBlueprintConfigurator<BlueprintLeaderSkillsList, LeaderSkillsListConfigurator>
  {
     private LeaderSkillsListConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static LeaderSkillsListConfigurator For(string name)
    {
      return new LeaderSkillsListConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static LeaderSkillsListConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintLeaderSkillsList>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static LeaderSkillsListConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintLeaderSkillsList>(name, assetId);
      return For(name);
    }
  }
}
