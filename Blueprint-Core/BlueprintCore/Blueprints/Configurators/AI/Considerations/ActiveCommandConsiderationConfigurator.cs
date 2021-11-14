using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="ActiveCommandConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(ActiveCommandConsideration))]
  public class ActiveCommandConsiderationConfigurator : BaseConsiderationConfigurator<ActiveCommandConsideration, ActiveCommandConsiderationConfigurator>
  {
     private ActiveCommandConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ActiveCommandConsiderationConfigurator For(string name)
    {
      return new ActiveCommandConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ActiveCommandConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<ActiveCommandConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ActiveCommandConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<ActiveCommandConsideration>(name, assetId);
      return For(name);
    }
  }
}
