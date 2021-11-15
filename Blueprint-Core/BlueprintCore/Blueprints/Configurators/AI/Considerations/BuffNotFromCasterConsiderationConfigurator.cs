using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="BuffNotFromCasterConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BuffNotFromCasterConsideration))]
  public class BuffNotFromCasterConsiderationConfigurator : BaseConsiderationConfigurator<BuffNotFromCasterConsideration, BuffNotFromCasterConsiderationConfigurator>
  {
     private BuffNotFromCasterConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static BuffNotFromCasterConsiderationConfigurator For(string name)
    {
      return new BuffNotFromCasterConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static BuffNotFromCasterConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<BuffNotFromCasterConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static BuffNotFromCasterConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BuffNotFromCasterConsideration>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="BuffNotFromCasterConsideration.m_Buffs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintBuff"/></param>
    [Generated]
    public BuffNotFromCasterConsiderationConfigurator AddToBuffs(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Buffs = CommonTool.Append(bp.m_Buffs, values.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BuffNotFromCasterConsideration.m_Buffs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintBuff"/></param>
    [Generated]
    public BuffNotFromCasterConsiderationConfigurator RemoveFromBuffs(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name));
            bp.m_Buffs =
                bp.m_Buffs
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BuffNotFromCasterConsideration.HasBuffNotFromCasterScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BuffNotFromCasterConsiderationConfigurator SetHasBuffNotFromCasterScore(float value)
    {
      return OnConfigureInternal(bp => bp.HasBuffNotFromCasterScore = value);
    }

    /// <summary>
    /// Sets <see cref="BuffNotFromCasterConsideration.ElseScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BuffNotFromCasterConsiderationConfigurator SetElseScore(float value)
    {
      return OnConfigureInternal(bp => bp.ElseScore = value);
    }
  }
}
