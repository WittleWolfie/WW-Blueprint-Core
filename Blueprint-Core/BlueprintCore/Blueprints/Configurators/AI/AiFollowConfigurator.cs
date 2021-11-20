using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.Utility;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="BlueprintAiFollow"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAiFollow))]
  public class AiFollowConfigurator : BaseAiActionConfigurator<BlueprintAiFollow, AiFollowConfigurator>
  {
    private AiFollowConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AiFollowConfigurator For(string name)
    {
      return new AiFollowConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AiFollowConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintAiFollow>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AiFollowConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintAiFollow>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiFollow.TargetType"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiFollowConfigurator SetTargetType(Kingmaker.AI.Blueprints.TargetType targetType)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.TargetType = targetType;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiFollow.ApproachRange"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiFollowConfigurator SetApproachRange(Feet approachRange)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.ApproachRange = approachRange;
          });
    }
  }
}
