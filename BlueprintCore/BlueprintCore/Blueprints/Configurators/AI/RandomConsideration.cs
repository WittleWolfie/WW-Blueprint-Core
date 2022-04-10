using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="RandomConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  
  public class RandomConsiderationConfigurator : BaseConsiderationConfigurator<RandomConsideration, RandomConsiderationConfigurator>
  {
    private RandomConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static RandomConsiderationConfigurator For(string name)
    {
      return new RandomConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static RandomConsiderationConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<RandomConsideration>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="RandomConsideration.MinScore"/> (Auto Generated)
    /// </summary>
    
    public RandomConsiderationConfigurator SetMinScore(float minScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MinScore = minScore;
          });
    }

    /// <summary>
    /// Sets <see cref="RandomConsideration.MaxScore"/> (Auto Generated)
    /// </summary>
    
    public RandomConsiderationConfigurator SetMaxScore(float maxScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.MaxScore = maxScore;
          });
    }
  }
}
