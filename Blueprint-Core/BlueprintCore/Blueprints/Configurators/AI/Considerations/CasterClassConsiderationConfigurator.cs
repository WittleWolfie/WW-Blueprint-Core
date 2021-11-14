using BlueprintCore.Blueprints.Configurators.AI.Considerations;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="CasterClassConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(CasterClassConsideration))]
  public class CasterClassConsiderationConfigurator : BaseConsiderationConfigurator<CasterClassConsideration, CasterClassConsiderationConfigurator>
  {
     private CasterClassConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CasterClassConsiderationConfigurator For(string name)
    {
      return new CasterClassConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CasterClassConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<CasterClassConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CasterClassConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<CasterClassConsideration>(name, assetId);
      return For(name);
    }
  }
}
