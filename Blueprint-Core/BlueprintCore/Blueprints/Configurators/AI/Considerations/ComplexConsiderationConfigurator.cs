using BlueprintCore.Blueprints.Configurators.AI.Considerations;
using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="ComplexConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(ComplexConsideration))]
  public class ComplexConsiderationConfigurator : BaseConsiderationConfigurator<ComplexConsideration, ComplexConsiderationConfigurator>
  {
     private ComplexConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static ComplexConsiderationConfigurator For(string name)
    {
      return new ComplexConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static ComplexConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<ComplexConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static ComplexConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<ComplexConsideration>(name, assetId);
      return For(name);
    }
  }
}
