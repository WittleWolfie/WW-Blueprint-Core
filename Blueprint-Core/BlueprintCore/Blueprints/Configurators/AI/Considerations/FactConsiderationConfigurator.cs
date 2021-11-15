using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="FactConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(FactConsideration))]
  public class FactConsiderationConfigurator : BaseConsiderationConfigurator<FactConsideration, FactConsiderationConfigurator>
  {
     private FactConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static FactConsiderationConfigurator For(string name)
    {
      return new FactConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static FactConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<FactConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static FactConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<FactConsideration>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="FactConsideration.m_Fact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    public FactConsiderationConfigurator AddToFact(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Fact = CommonTool.Append(bp.m_Fact, values.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="FactConsideration.m_Fact"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintUnitFact"/></param>
    [Generated]
    public FactConsiderationConfigurator RemoveFromFact(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintUnitFactReference>(name));
            bp.m_Fact =
                bp.m_Fact
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="FactConsideration.HasFactScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FactConsiderationConfigurator SetHasFactScore(float value)
    {
      return OnConfigureInternal(bp => bp.HasFactScore = value);
    }

    /// <summary>
    /// Sets <see cref="FactConsideration.NoFactScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public FactConsiderationConfigurator SetNoFactScore(float value)
    {
      return OnConfigureInternal(bp => bp.NoFactScore = value);
    }
  }
}
