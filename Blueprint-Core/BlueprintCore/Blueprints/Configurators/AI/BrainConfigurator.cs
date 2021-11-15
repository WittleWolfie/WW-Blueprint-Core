using BlueprintCore.Utils;
using Kingmaker.AI.Blueprints;
using Kingmaker.Blueprints;
using System.Linq;

namespace BlueprintCore.Blueprints.Configurators.AI
{
  /// <summary>
  /// Implements common fields and components for blueprints inheriting from <see cref="BlueprintBrain"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintBrain))]
  public abstract class BaseBrainConfigurator<T, TBuilder>
      : BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintBrain
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
     protected BaseBrainConfigurator(string name) : base(name) { }

    /// <summary>
    /// Modifies <see cref="BlueprintBrain.m_Actions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAiAction"/></param>
    [Generated]
    public TBuilder AddToActions(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Actions = CommonTool.Append(bp.m_Actions, values.Select(name => BlueprintTool.GetRef<BlueprintAiActionReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintBrain.m_Actions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAiAction"/></param>
    [Generated]
    public TBuilder RemoveFromActions(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintAiActionReference>(name));
            bp.m_Actions =
                bp.m_Actions
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }
  }

  /// <summary>Configurator for <see cref="BlueprintBrain"/>.</summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintBrain))]
  public class BrainConfigurator : BaseBlueprintConfigurator<BlueprintBrain, BrainConfigurator>
  {
     private BrainConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static BrainConfigurator For(string name)
    {
      return new BrainConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string)"/>
    public static BrainConfigurator New(string name)
    {
      BlueprintTool.Create<BlueprintBrain>(name);
      return For(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static BrainConfigurator New(string name, string assetId)
    {
      BlueprintTool.Create<BlueprintBrain>(name, assetId);
      return For(name);
    }

    /// <summary>
    /// Modifies <see cref="BlueprintBrain.m_Actions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAiAction"/></param>
    [Generated]
    public BrainConfigurator AddToActions(params string[] values)
    {
      return OnConfigureInternal(bp => bp.m_Actions = CommonTool.Append(bp.m_Actions, values.Select(name => BlueprintTool.GetRef<BlueprintAiActionReference>(name)).ToArray()));
    }

    /// <summary>
    /// Modifies <see cref="BlueprintBrain.m_Actions"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="values"><see cref="BlueprintAiAction"/></param>
    [Generated]
    public BrainConfigurator RemoveFromActions(params string[] values)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = values.Select(name => BlueprintTool.GetRef<BlueprintAiActionReference>(name));
            bp.m_Actions =
                bp.m_Actions
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }
  }
}
