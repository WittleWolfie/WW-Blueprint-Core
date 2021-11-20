using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>
  /// Configurator for <see cref="HasAutoCastConsideraion"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(HasAutoCastConsideraion))]
  public class HasAutoCastConsideraionConfigurator : BaseConsiderationConfigurator<HasAutoCastConsideraion, HasAutoCastConsideraionConfigurator>
  {
    private HasAutoCastConsideraionConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static HasAutoCastConsideraionConfigurator For(string name)
    {
      return new HasAutoCastConsideraionConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static HasAutoCastConsideraionConfigurator New(string name)
    {
      BlueprintTool.Create<HasAutoCastConsideraion>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static HasAutoCastConsideraionConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<HasAutoCastConsideraion>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="HasAutoCastConsideraion.NoAutoCastScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HasAutoCastConsideraionConfigurator SetNoAutoCastScore(float noAutoCastScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.NoAutoCastScore = noAutoCastScore;
          });
    }

    /// <summary>
    /// Sets <see cref="HasAutoCastConsideraion.HasAutoCastScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public HasAutoCastConsideraionConfigurator SetHasAutoCastScore(float hasAutoCastScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HasAutoCastScore = hasAutoCastScore;
          });
    }
  }
}
