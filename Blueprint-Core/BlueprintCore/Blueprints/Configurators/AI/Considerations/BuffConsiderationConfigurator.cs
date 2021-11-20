using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>
  /// Configurator for <see cref="BuffConsideration"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BuffConsideration))]
  public class BuffConsiderationConfigurator : BaseConsiderationConfigurator<BuffConsideration, BuffConsiderationConfigurator>
  {
    private BuffConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static BuffConsiderationConfigurator For(string name)
    {
      return new BuffConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static BuffConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<BuffConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static BuffConsiderationConfigurator For(string name, string assetId)
    {
      BlueprintTool.Create<BuffConsideration>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BuffConsideration.m_Buffs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buffs"><see cref="BlueprintBuff"/></param>
    [Generated]
    public BuffConsiderationConfigurator SetBuffs(string[] buffs)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Buffs = buffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BuffConsideration.m_Buffs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buffs"><see cref="BlueprintBuff"/></param>
    [Generated]
    public BuffConsiderationConfigurator AddToBuffs(params string[] buffs)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_Buffs = CommonTool.Append(bp.m_Buffs, buffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BuffConsideration.m_Buffs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buffs"><see cref="BlueprintBuff"/></param>
    [Generated]
    public BuffConsiderationConfigurator RemoveFromBuffs(params string[] buffs)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = buffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name));
            bp.m_Buffs =
                bp.m_Buffs
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BuffConsideration.HasBuffScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BuffConsiderationConfigurator SetHasBuffScore(float hasBuffScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.HasBuffScore = hasBuffScore;
          });
    }

    /// <summary>
    /// Sets <see cref="BuffConsideration.NoBuffScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BuffConsiderationConfigurator SetNoBuffScore(float noBuffScore)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.NoBuffScore = noBuffScore;
          });
    }

    /// <summary>
    /// Sets <see cref="BuffConsideration.FromCaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    public BuffConsiderationConfigurator SetFromCaster(bool fromCaster)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.FromCaster = fromCaster;
          });
    }
  }
}
