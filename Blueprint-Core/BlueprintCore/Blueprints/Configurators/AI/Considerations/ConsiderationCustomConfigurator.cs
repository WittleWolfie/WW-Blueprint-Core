using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="ConsiderationCustom"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(ConsiderationCustom))]
  public class ConsiderationCustomConfigurator : BaseConsiderationConfigurator<ConsiderationCustom, ConsiderationCustomConfigurator>
  {
     private ConsiderationCustomConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ConsiderationCustomConfigurator For(string name)
    {
      return new ConsiderationCustomConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ConsiderationCustomConfigurator New(string name)
    {
      BlueprintTool.Create<ConsiderationCustom>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ConsiderationCustomConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<ConsiderationCustom>(name, assetId);
      return For(name);
    }
  }
}
