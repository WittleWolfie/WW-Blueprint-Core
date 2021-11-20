using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Configurator for <see cref="BlueprintAiRunAway"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintAiRunAway))]
  public class AiRunAwayConfigurator : BaseAiActionConfigurator<BlueprintAiRunAway, AiRunAwayConfigurator>
  {
    private AiRunAwayConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AiRunAwayConfigurator For(string name)
    {
      return new AiRunAwayConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AiRunAwayConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintAiRunAway>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AiRunAwayConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintAiRunAway>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintAiRunAway.BecameStalker"/> (Auto Generated)
    /// </summary>
    [Generated]
    public AiRunAwayConfigurator SetBecameStalker(bool becameStalker)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.BecameStalker = becameStalker;
          });
    }
  }
}
