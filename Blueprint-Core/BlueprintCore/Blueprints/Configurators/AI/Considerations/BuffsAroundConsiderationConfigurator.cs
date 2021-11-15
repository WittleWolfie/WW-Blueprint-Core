using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="BuffsAroundConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BuffsAroundConsideration))]
  public class BuffsAroundConsiderationConfigurator : BaseUnitsAroundConsiderationConfigurator<BuffsAroundConsideration, BuffsAroundConsiderationConfigurator>
  {
     private BuffsAroundConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static BuffsAroundConsiderationConfigurator For(string name)
    {
      return new BuffsAroundConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static BuffsAroundConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<BuffsAroundConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static BuffsAroundConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BuffsAroundConsideration>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="BuffsAroundConsideration.m_Buffs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintBuff"/></param>
    [Generated]
    public BuffsAroundConsiderationConfigurator AddToBuffs(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Buffs = CommonTool.Append(bp.m_Buffs, values.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BuffsAroundConsideration.m_Buffs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintBuff"/></param>
    [Generated]
    public BuffsAroundConsiderationConfigurator RemoveFromBuffs(params string[] values)
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
    /// Sets <see cref="BuffsAroundConsideration.CheckAbsence"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BuffsAroundConsiderationConfigurator SetCheckAbsence(bool value)
    {
      return OnConfigureInternal(bp => bp.CheckAbsence = value);
    }
  }
}
