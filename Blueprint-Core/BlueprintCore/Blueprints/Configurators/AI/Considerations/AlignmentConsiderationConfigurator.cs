using BlueprintCore.Blueprints.Configurators.AI.Considerations;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="AlignmentConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(AlignmentConsideration))]
  public class AlignmentConsiderationConfigurator : BaseConsiderationConfigurator<AlignmentConsideration, AlignmentConsiderationConfigurator>
  {
     private AlignmentConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static AlignmentConsiderationConfigurator For(string name)
    {
      return new AlignmentConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static AlignmentConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<AlignmentConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static AlignmentConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<AlignmentConsideration>(name, assetId);
      return For(name);
    }

  }
}
