using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>
  /// Configurator for <see cref="NotImpatientConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(NotImpatientConsideration))]
  public class NotImpatientConsiderationConfigurator : BaseConsiderationConfigurator<NotImpatientConsideration, NotImpatientConsiderationConfigurator>
  {
    private NotImpatientConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static NotImpatientConsiderationConfigurator For(string name)
    {
      return new NotImpatientConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static NotImpatientConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<NotImpatientConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static NotImpatientConsiderationConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<NotImpatientConsideration>(name, assetId);
      return For(name);
    }
  }
}
