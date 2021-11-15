using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System.Linq;

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

    /// <summary>
    /// Modifies <see cref="ComplexConsideration.m_Considerations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="Consideration"/></param>
    [Generated]
    public ComplexConsiderationConfigurator AddToConsiderations(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Considerations = CommonTool.Append(bp.m_Considerations, values.Select(name => BlueprintTool.GetRef<ConsiderationReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="ComplexConsideration.m_Considerations"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="Consideration"/></param>
    [Generated]
    public ComplexConsiderationConfigurator RemoveFromConsiderations(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<ConsiderationReference>(name));
            bp.m_Considerations =
                bp.m_Considerations
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }
  }
}
