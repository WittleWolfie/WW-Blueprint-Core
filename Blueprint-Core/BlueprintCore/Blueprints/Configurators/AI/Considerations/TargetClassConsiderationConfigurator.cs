using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints.Considerations;
using Kingmaker.Blueprints;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.AI.Considerations
{
  /// <summary>Configurator for <see cref="TargetClassConsideration"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(TargetClassConsideration))]
  public class TargetClassConsiderationConfigurator : BaseConsiderationConfigurator<TargetClassConsideration, TargetClassConsiderationConfigurator>
  {
     private TargetClassConsiderationConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static TargetClassConsiderationConfigurator For(string name)
    {
      return new TargetClassConsiderationConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static TargetClassConsiderationConfigurator New(string name)
    {
      BlueprintTool.Create<TargetClassConsideration>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static TargetClassConsiderationConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<TargetClassConsideration>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="TargetClassConsideration.m_FirstPriorityClasses"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    public TargetClassConsiderationConfigurator AddToFirstPriorityClasses(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_FirstPriorityClasses = CommonTool.Append(bp.m_FirstPriorityClasses, values.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="TargetClassConsideration.m_FirstPriorityClasses"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    public TargetClassConsiderationConfigurator RemoveFromFirstPriorityClasses(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name));
            bp.m_FirstPriorityClasses =
                bp.m_FirstPriorityClasses
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="TargetClassConsideration.FirstPriorityScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TargetClassConsiderationConfigurator SetFirstPriorityScore(float value)
    {
      return OnConfigureInternal(bp => bp.FirstPriorityScore = value);
    }

    /// <summary>
    /// Modifies <see cref="TargetClassConsideration.m_SecondPriorityClasses"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    public TargetClassConsiderationConfigurator AddToSecondPriorityClasses(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_SecondPriorityClasses = CommonTool.Append(bp.m_SecondPriorityClasses, values.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="TargetClassConsideration.m_SecondPriorityClasses"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintCharacterClass"/></param>
    [Generated]
    public TargetClassConsiderationConfigurator RemoveFromSecondPriorityClasses(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintCharacterClassReference>(name));
            bp.m_SecondPriorityClasses =
                bp.m_SecondPriorityClasses
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="TargetClassConsideration.SecondPriorityScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TargetClassConsiderationConfigurator SetSecondPriorityScore(float value)
    {
      return OnConfigureInternal(bp => bp.SecondPriorityScore = value);
    }

    /// <summary>
    /// Sets <see cref="TargetClassConsideration.NoPriorityScore"/> (Auto Generated)
    /// </summary>
    [Generated]
    public TargetClassConsiderationConfigurator SetNoPriorityScore(float value)
    {
      return OnConfigureInternal(bp => bp.NoPriorityScore = value);
    }
  }
}
