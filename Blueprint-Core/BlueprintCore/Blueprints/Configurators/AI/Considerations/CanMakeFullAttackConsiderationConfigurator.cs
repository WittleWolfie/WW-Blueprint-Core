using BlueprintCore.Blueprints.Configurators.AI.Considerations;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="CanMakeFullAttackConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(CanMakeFullAttackConsideration))]
  public class CanMakeFullAttackConsiderationConfigurator : BaseConsiderationConfigurator<CanMakeFullAttackConsideration, CanMakeFullAttackConsiderationConfigurator>
  {
     private CanMakeFullAttackConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CanMakeFullAttackConsiderationConfigurator For(string name)
    {
      return new CanMakeFullAttackConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static CanMakeFullAttackConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<CanMakeFullAttackConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CanMakeFullAttackConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<CanMakeFullAttackConsideration>(name, assetId);
      return For(name);
    }

  }
}
